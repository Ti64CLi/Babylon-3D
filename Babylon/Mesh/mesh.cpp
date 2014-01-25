#include "mesh.h"
#include "camera.h"
#include "engine.h"
#include "tools.h"

using namespace Babylon;

Babylon::Mesh::Mesh(string name, IScene::Ptr scene) : Node(scene) {
	this->name = name;
	this->id = name;
	this->_scene = scene;

	this->_totalVertices = 0;
	this->_worldMatrix = Matrix::Identity();

	scene->getMeshes().push_back_back(enable_shared_from_this<Mesh>::shared_from_this());

	this->position = make_shared<Vector3>(0, 0, 0);
	this->rotation = make_shared<Vector3>(0, 0, 0);
	this->rotationQuaternion = nullptr;
	this->scaling = make_shared<Vector3>(1, 1, 1);

	this->_pivotMatrix = Matrix::Identity();

	this->_indices.clear();
	this->subMeshes.clear();

	this->_renderId = 0;

	this->_onBeforeRenderCallbacks.clear();

	// Animations
	this->animations.clear();

	this->_positions.clear();

	// Cache
	_initCache();

	this->_childrenFlag = false;
	this->_localScaling = Matrix::Zero();
	this->_localRotation = Matrix::Zero();
	this->_localTranslation = Matrix::Zero();
	this->_localBillboard = Matrix::Zero();
	this->_localPivotScaling = Matrix::Zero();
	this->_localPivotScalingRotation = Matrix::Zero();
	this->_localWorld = Matrix::Zero();
	this->_worldMatrix = Matrix::Zero();

	auto PI = 4. * atan(1.);
	this->_rotateYByPI = Matrix::RotationY(PI);

	this->_collisionsTransformMatrix = Matrix::Zero();
	this->_collisionsScalingMatrix = Matrix::Zero();

	this->_absolutePosition = Vector3::Zero();

	delayLoadState = DELAYLOADSTATE_NONE;
	material = nullptr;
	isVisible = true;
	isPickable = true;
	visibility = 1.0;
	billboardMode = BILLBOARDMODE_NONE;
	checkCollisions = false;
	receiveShadows = false;
	_isDisposed = false;
	onDispose = nullptr;
	skeleton = nullptr;
	renderingGroupId = 0;
	infiniteDistance = false;
};

// Cache
void Babylon::Mesh::_resetPointsArrayCache() {
	this->_positions.clear();
};

// Properties
BoundingInfo::Ptr Babylon::Mesh::getBoundingInfo() {
	return this->_boundingInfo;
};

IScene::Ptr Babylon::Mesh::getScene() {
	return this->_scene;
};

Matrix::Ptr Babylon::Mesh::getWorldMatrix() {
	if (this->_currentRenderId != this->_scene->getRenderId()) {
		this->computeWorldMatrix();
	}
	return this->_worldMatrix;
};

Vector3::Ptr Babylon::Mesh::getAbsolutePosition() {
	return this->_absolutePosition;
};

int Babylon::Mesh::getTotalVertices() {
	return this->_totalVertices;
};

Float32Array& Babylon::Mesh::getVerticesData(VertexBufferKind kind) {
	return this->_vertexBuffers[kind]->getData();
};

bool Babylon::Mesh::isVerticesDataPresent(VertexBufferKind kind) {
	if (this->_delayInfo.size() > 0) {
		return find(begin(this->_delayInfo), end(this->_delayInfo), kind) != end(this->_delayInfo);
	}

	return this->_vertexBuffers[kind] != nullptr;
};

size_t Babylon::Mesh::getTotalIndices() {
	return this->_indices.size();
};

Uint16Array Babylon::Mesh::getIndices() {
	return this->_indices;
};

size_t Babylon::Mesh::getVertexStrideSize() {
	return this->_vertexStrideSize;
};

void Babylon::Mesh::setPivotMatrix(Matrix::Ptr matrix) {
	this->_pivotMatrix = matrix;
	this->_cache.pivotMatrixUpdated = true;
};

Matrix::Ptr Babylon::Mesh::getPivotMatrix() {
	return this->_pivotMatrix;
};

bool Babylon::Mesh::_isSynchronized() {
	if (this->billboardMode != BILLBOARDMODE_NONE)
		return false;

	if (this->_cache.pivotMatrixUpdated) {
		return false;
	}

	if (this->infiniteDistance) {
		return false;
	}

	if (this->_cache.position != this->position)
		return false;

	if (this->rotationQuaternion) {
		if (this->_cache.rotationQuaternion != this->rotationQuaternion)
			return false;
	} else {
		if (this->_cache.rotation != this->rotation)
			return false;
	}

	if (this->_cache.scaling != this->scaling)
		return false;

	return true;
};

bool Babylon::Mesh::isReady() {
	return this->_isReady;
};

bool Babylon::Mesh::isAnimated() {
	return this->_animationStarted;
};

bool Babylon::Mesh::isDisposed() {
	return this->_isDisposed;
};

// Methods
void Babylon::Mesh::_initCache() {
	this->_cache.localMatrixUpdated = false;
	this->_cache.position = Vector3::Zero();
	this->_cache.scaling = Vector3::Zero();
	this->_cache.rotation = Vector3::Zero();
	this->_cache.rotationQuaternion = make_shared<Quaternion>(0, 0, 0, 0);
};

void Babylon::Mesh::markAsDirty(string property) {
	if (property == "rotation") {
		this->rotationQuaternion = nullptr;
	}
	this->_syncChildFlag();
};

void Babylon::Mesh::refreshBoundingInfo() {
	auto data = this->getVerticesData(VertexBufferKind_PositionKind);

	if (data.size() == 0) {
		return;
	}

	auto extend = Tools::ExtractMinAndMax(data, 0, this->_totalVertices);
	this->_boundingInfo = make_shared<BoundingInfo>(extend.minimum, extend.maximum);

	for (auto subMesh : this->subMeshes) {
		subMesh->refreshBoundingInfo();
	}

	this->_updateBoundingInfo();
};

void Babylon::Mesh::_updateBoundingInfo() {
	if (this->_boundingInfo) {
		this->_scaleFactor = max(this->scaling->x, this->scaling->y);
		this->_scaleFactor = max(this->_scaleFactor, this->scaling->z);

		auto parentMesh = dynamic_pointer_cast<Mesh>(this->parent);
		if (parentMesh)
			this->_scaleFactor = this->_scaleFactor * parentMesh->_scaleFactor;

		this->_boundingInfo->_update(this->_worldMatrix, this->_scaleFactor);

		for (auto subMesh : this->subMeshes) {
			subMesh->updateBoundingInfo(this->_worldMatrix, this->_scaleFactor);
		}
	}
};

Matrix::Ptr Babylon::Mesh::computeWorldMatrix(bool force) {
	if (!force && (this->_currentRenderId == this->_scene->getRenderId() || this->isSynchronized(true))) {
		return this->_worldMatrix;
	}

	this->_syncChildFlag();
	this->_cache.position->copyFrom(this->position);
	this->_cache.scaling->copyFrom(this->scaling);
	this->_cache.pivotMatrixUpdated = false;
	this->_currentRenderId = this->_scene->getRenderId();

	// Scaling
	Matrix::ScalingToRef(this->scaling->x, this->scaling->y, this->scaling->z, this->_localScaling);

	// Rotation
	if (this->rotationQuaternion) {
		this->rotationQuaternion->toRotationMatrix(this->_localRotation);
		this->_cache.rotationQuaternion->copyFrom(this->rotationQuaternion);
	} else {
		Matrix::RotationYawPitchRollToRef(this->rotation->y, this->rotation->x, this->rotation->z, this->_localRotation);
		this->_cache.rotation->copyFrom(this->rotation);
	}

	// Translation
	if (this->infiniteDistance) {
		auto camera = this->_scene->getActiveCamera();
		Matrix::TranslationToRef(this->position->x + camera->position->x, this->position->y + camera->position->y, this->position->z + camera->position->z, this->_localTranslation);
	} else {
		Matrix::TranslationToRef(this->position->x, this->position->y, this->position->z, this->_localTranslation);
	}

	// Composing transformations
	this->_pivotMatrix->multiplyToRef(this->_localScaling, this->_localPivotScaling);
	this->_localPivotScaling->multiplyToRef(this->_localRotation, this->_localPivotScalingRotation);

	// Billboarding
	if (this->billboardMode != BILLBOARDMODE_NONE) {
		auto localPosition = this->position->clone();
		auto zero = this->_scene->getActiveCamera()->position->clone();

		auto parentMesh = dynamic_pointer_cast<Mesh>(this->parent);
		if (parentMesh) {
			localPosition->addInPlace(parentMesh->position);
			Matrix::TranslationToRef(localPosition->x, localPosition->y, localPosition->z, this->_localTranslation);
		}

		if (this->billboardMode & BILLBOARDMODE_ALL == BILLBOARDMODE_ALL) {
			zero = this->_scene->getActiveCamera()->position;
		} else {
			if (this->billboardMode & BILLBOARDMODE_X)
				zero->x = localPosition->x + Engine::epsilon;
			if (this->billboardMode & BILLBOARDMODE_Y)
				zero->y = localPosition->y + Engine::epsilon;
			if (this->billboardMode & BILLBOARDMODE_Z)
				zero->z = localPosition->z + Engine::epsilon;
		}

		Matrix::LookAtLHToRef(localPosition, zero, Vector3::Up(), this->_localBillboard);
		this->_localBillboard->m[12] = this->_localBillboard->m[13] = this->_localBillboard->m[14] = 0;

		this->_localBillboard->invert();

		this->_localPivotScalingRotation->multiplyToRef(this->_localBillboard, this->_localWorld);
		this->_rotateYByPI->multiplyToRef(this->_localWorld, this->_localPivotScalingRotation);
	}

	// Local world
	this->_localPivotScalingRotation->multiplyToRef(this->_localTranslation, this->_localWorld);

	// Parent
	if (this->parent && this->parent->hasWorldMatrix() && this->billboardMode == BILLBOARDMODE_NONE) {
		this->_localWorld->multiplyToRef(this->parent->getWorldMatrix(), this->_worldMatrix);
	} else {
		this->_localPivotScalingRotation->multiplyToRef(this->_localTranslation, this->_worldMatrix);
	}

	// Bounding info
	this->_updateBoundingInfo();

	// Absolute position
	this->_absolutePosition->copyFromFloats(this->_worldMatrix->m[12], this->_worldMatrix->m[13], this->_worldMatrix->m[14]);

	return this->_worldMatrix;
};

SubMesh::Ptr Babylon::Mesh::_createGlobalSubMesh() {
	if (!this->_totalVertices || this->_indices.size() == 0) {
		return nullptr;
	}

	this->subMeshes.clear();
	return make_shared<SubMesh>(0, 0, this->_totalVertices, 0, this->_indices.size(), enable_shared_from_this<Mesh>::shared_from_this());
};

bool Babylon::Mesh::subdivide(int count) {
	if (count < 1) {
		return;
	}

	auto subdivisionSize = this->_indices.size() / count;
	auto offset = 0;

	this->subMeshes.clear();
	for (auto index = 0; index < count; index++) {
		SubMesh::CreateFromIndices(0, offset, min(subdivisionSize, this->_indices.size() - offset), this);

		offset += subdivisionSize;
	}
};

void Babylon::Mesh::setVerticesData(Float32Array data, VertexBufferKind kind, bool updatable) {
	this->_vertexBuffers.clear();

	if (this->_vertexBuffers[kind]) {
		this->_vertexBuffers[kind]->dispose();
	}

	this->_vertexBuffers[kind] = make_shared<VertexBuffer>(enable_shared_from_this<Mesh>::shared_from_this(), data, kind, updatable);

	if (kind == VertexBufferKind_PositionKind) {
		auto stride = this->_vertexBuffers[kind]->getStrideSize();
		this->_totalVertices = data.size() / stride;

		auto extend = Tools::ExtractMinAndMax(data, 0, this->_totalVertices);
		this->_boundingInfo = make_shared<BoundingInfo>(extend.minimum, extend.maximum);

		this->_createGlobalSubMesh();
	}
};

void Babylon::Mesh::updateVerticesData(VertexBufferKind kind, Float32Array data) {
	if (this->_vertexBuffers[kind]) {
		this->_vertexBuffers[kind]->update(data);
	}
};

void Babylon::Mesh::setIndices(Uint16Array indices) {
	if (this->_indexBuffer) {
		this->_scene->getEngine()->_releaseBuffer(this->_indexBuffer);
	}

	this->_indexBuffer = this->_scene->getEngine()->createIndexBuffer(indices);
	this->_indices = indices;

	this->_createGlobalSubMesh();
};

void Babylon::Mesh::bindAndDraw(SubMesh::Ptr subMesh, Effect::Ptr effect, bool wireframe) {
	auto engine = this->_scene->getEngine();

	// Wireframe
	auto indexToBind = this->_indexBuffer;
	auto useTriangles = true;

	if (wireframe) {
		indexToBind = subMesh->getLinesIndexBuffer(this->_indices, engine);
		useTriangles = false;
	}

	// VBOs
	engine->bindMultiBuffers(this->_vertexBuffers, indexToBind, effect);

	// Draw order
	engine->draw(useTriangles, useTriangles ? subMesh->indexStart : 0, useTriangles ? subMesh->indexCount : subMesh->linesIndexCount);
};

void Babylon::Mesh::registerBeforeRender(OnBeforeRenderFunc func) {
	this->_onBeforeRenderCallbacks.push_back_back(func);
};

void Babylon::Mesh::unregisterBeforeRender(OnBeforeRenderFunc func) {
	auto it = find( begin(this->_onBeforeRenderCallbacks), end(this->_onBeforeRenderCallbacks), func);

	if (it != end(this->_onBeforeRenderCallbacks)) {
		this->_onBeforeRenderCallbacks.erase(it);
	}
};

void Babylon::Mesh::render(SubMesh::Ptr subMesh) {
	if (!this->_vertexBuffers || !this->_indexBuffer) {
		return;
	}

	for (auto callbackIndex = 0; callbackIndex < this->_onBeforeRenderCallbacks.size(); callbackIndex++) {
		this->_onBeforeRenderCallbacks[callbackIndex]();
	}

	// World
	auto world = this->getWorldMatrix();

	// Material
	auto effectiveMaterial = subMesh->getMaterial();

	if (!effectiveMaterial || !effectiveMaterial->isReady(enable_shared_from_this<Mesh>::shared_from_this())) {
		return;
	}

	effectiveMaterial->_preBind();
	effectiveMaterial->bind(world, enable_shared_from_this<Mesh>::shared_from_this());

	// Bind and draw
	auto engine = this->_scene->getEngine();
	this->bindAndDraw(subMesh, effectiveMaterial->getEffect(), engine->forceWireframe || effectiveMaterial->wireframe);

	// Unbind
	effectiveMaterial->unbind();
};

vector<shared_ptr<void>> Babylon::Mesh::getEmittedParticleSystems() {
	vector<shared_ptr<void>> results;
	for (auto particleSystem : this->_scene->particleSystems) {
		if (particleSystem.emitter == enable_shared_from_this<Mesh>::shared_from_this()) {
			results.push_back(particleSystem);
		}
	}

	return results;
};

vector<shared_ptr<void>> Babylon::Mesh::getHierarchyEmittedParticleSystems() {
	vector<shared_ptr<void>> results;
	auto descendants = this->getDescendants();
	descendants.push_back(enable_shared_from_this<Mesh>::shared_from_this());

	for (auto particleSystem : this->_scene->particleSystems) {
		if (find(begin(descendants), end(descendants), particleSystem.emitter) != end(descendants)) {
			results.push_back(particleSystem);
		}
	}

	return results;
};

Mesh::Array Babylon::Mesh::getChildren() {
	Mesh::Array results;
	for (auto mesh : this->_scene->meshes) {
		if (mesh->parent == enable_shared_from_this<Mesh>::shared_from_this()) {
			results.push_back(mesh);
		}
	}

	return results;
};

bool Babylon::Mesh::isInFrustum(Plane::Array frustumPlanes) {
	if (this->delayLoadState == DELAYLOADSTATE_LOADING) {
		return false;
	}

	auto result = this->_boundingInfo->isInFrustum(frustumPlanes);

	if (result && this->delayLoadState == DELAYLOADSTATE_NOTLOADED) {
		this->delayLoadState = DELAYLOADSTATE_LOADING;
		auto that = this;

		this->_scene->_addPendingData(this);

		// TODO: finish it when finish LoadFile
		////Tools::LoadFile(this->delayLoadingFile, [] (data) {
		////	BABYLON.SceneLoader._ImportGeometry(JSON.parse(data), that);
		////	that->delayLoadState = DELAYLOADSTATE_LOADED;
		////	that->_scene->_removePendingData(that);
		////}, [] () { }, this->_scene->database);
	}

	return result;
};

void Babylon::Mesh::setMaterialByID(string id) {
	auto materials = this->_scene->materials;
	for (auto _material : materials) {
		if (_material->id == id) {
			this->material = _material;
			return;
		}
	}

	// Multi
	auto multiMaterials = this->_scene->multiMaterials;
	for (auto multiMaterial : multiMaterials) {
		if (multiMaterial->id == id) {
			this->material = multiMaterial;
			return;
		}
	}
};

Animatable::Array Babylon::Mesh::getAnimatables() {
	Animatable::Array results;

	if (this->material) {
		results.push_back(this->material);
	}

	return results;
};

// Geometry
// Deprecated: use setPositionWithLocalVector instead 
void Babylon::Mesh::setLocalTranslation(Vector3::Ptr vector3) {
	////console.warn("deprecated: use setPositionWithLocalVector instead");
	this->computeWorldMatrix();
	auto worldMatrix = this->_worldMatrix->clone();
	worldMatrix.setTranslation(Vector3::Zero());

	this->position = Vector3::TransformCoordinates(vector3, worldMatrix);
};

// Deprecated: use getPositionExpressedInLocalSpace instead 
Vector3::Ptr Babylon::Mesh::getLocalTranslation() {
	/////console.warn("deprecated: use getPositionExpressedInLocalSpace instead");
	this->computeWorldMatrix();
	auto invWorldMatrix = this->_worldMatrix->clone();
	invWorldMatrix->setTranslation(Vector3::Zero());
	invWorldMatrix->invert();

	return Vector3::TransformCoordinates(this->position, invWorldMatrix);
};

void Babylon::Mesh::setPositionWithLocalVector(Vector3::Ptr vector3) {
	this->computeWorldMatrix();

	this->position = Vector3::TransformNormal(vector3, this->_localWorld);
};

Vector3::Ptr Babylon::Mesh::getPositionExpressedInLocalSpace() {
	this->computeWorldMatrix();
	auto invLocalWorldMatrix = this->_localWorld->clone();
	invLocalWorldMatrix.invert();

	return Vector3::TransformNormal(this->position, invLocalWorldMatrix);
};

void Babylon::Mesh::locallyTranslate(Vector3::Ptr vector3) {
	this->computeWorldMatrix();

	this->position = Vector3::TransformCoordinates(vector3, this->_localWorld);
};

void Babylon::Mesh::bakeTransformIntoVertices(Matrix::Ptr transform) {
	// Position
	if (!this->isVerticesDataPresent(VertexBufferKind_PositionKind)) {
		return;
	}

	this->_resetPointsArrayCache();

	auto data = this->_vertexBuffers[VertexBufferKind_PositionKind].getData();
	auto temp = Float32Array(data.size());
	for (auto index = 0; index < data.size(); index += 3) {
		Vector3::TransformCoordinates(Vector3::FromArray(data, index), transform)->toArray(temp, index);
	}

	this->setVerticesData(temp, VertexBufferKind_PositionKind, this->_vertexBuffers[VertexBufferKind_PositionKind].isUpdatable());

	// Normals
	if (!this->isVerticesDataPresent(VertexBufferKind_NormalKind)) {
		return;
	}

	data = this->_vertexBuffers[VertexBufferKind_NormalKind]->getData();
	for (auto index = 0; index < data.size(); index += 3) {
		Vector3::TransformNormal(Vector3::FromArray(data, index), transform)->toArray(temp, index);
	}

	this->setVerticesData(temp, VertexBufferKind_NormalKind, this->_vertexBuffers[VertexBufferKind_NormalKind].isUpdatable());
};

void Babylon::Mesh::lookAt(Vector3::Ptr targetPoint, float yawCor, float pitchCor, float rollCor) {
	/// <summary>Orients a mesh towards a target point. Mesh must be drawn facing user.</summary>
	/// <param name="targetPoint" type="BABYLON.Vector3">The position (must be in same space as current mesh) to look at</param>
	/// <param name="yawCor" type="Number">optional yaw (y-axis) correction in radians</param>
	/// <param name="pitchCor" type="Number">optional pitch (x-axis) correction in radians</param>
	/// <param name="rollCor" type="Number">optional roll (z-axis) correction in radians</param>
	/// <returns>Mesh oriented towards targetMesh</returns>

	auto dv = targetPoint->subtract(this->position);
	auto yaw = -atan2(dv->z, dv->x) - PI / 2;
	auto len = sqrt(dv->x * dv->x + dv->z * dv->z);
	auto pitch = atan2(dv->y, len);
	this->rotationQuaternion = Quaternion::RotationYawPitchRoll(yaw + yawCor, pitch + pitchCor, rollCor);
};

// Cache
void Babylon::Mesh::_resetPointsArrayCache() {
	this->_positions.clear()
};

void Babylon::Mesh::_generatePointsArray() {
	if (this->_positions)
		return;

	this->_positions.clear();

	auto data = this->_vertexBuffers[VertexBufferKind_PositionKind].getData();
	for (auto index = 0; index < data.size(); index += 3) {
		this->_positions.push_back(Vector3::FromArray(data, index));
	}
};

// Collisions
// TODO: finish it when Collider is done
/*
void Babylon::Mesh::_collideForSubMesh(SubMesh::Ptr subMesh, Matrix::Ptr transformMatrix, Collider::Ptr collider) {
	this->_generatePointsArray();
	// Transformation
	if (!subMesh->_lastColliderWorldVertices || !subMesh->_lastColliderTransformMatrix.equals(transformMatrix)) {
		subMesh->_lastColliderTransformMatrix = transformMatrix;
		subMesh->_lastColliderWorldVertices.clear();
		auto start = subMesh->verticesStart;
		auto end = (subMesh->verticesStart + subMesh->verticesCount);
		for (auto i = start; i < end; i++) {
			subMesh->_lastColliderWorldVertices.push_back(Vector3::TransformCoordinates(this->_positions[i], transformMatrix));
		}
	}
	// Collide
	collider._collide(subMesh, subMesh->_lastColliderWorldVertices, this->_indices, subMesh->indexStart, subMesh->indexStart + subMesh->indexCount, subMesh->verticesStart);
};

void Babylon::Mesh::_processCollisionsForSubModels(Collider::Ptr collider, Matrix::Ptr transformMatrix) {
	for (auto subMesh : this->subMeshes) {
		// Bounding test
		if (this->subMeshes.size() > 1 && !subMesh->_checkCollision(collider))
			continue;

		this->_collideForSubMesh(subMesh, transformMatrix, collider);
	}
};

void Babylon::Mesh::_checkCollision(Collider::Ptr collider) {
	// Bounding box test
	if (!this->_boundingInfo->_checkCollision(collider))
		return;

	// Transformation matrix
	Matrix::ScalingToRef(1.0 / collider.radius->x, 1.0 / collider.radius->y, 1.0 / collider.radius->z, this->_collisionsScalingMatrix);
	this->_worldMatrix->multiplyToRef(this->_collisionsScalingMatrix, this->_collisionsTransformMatrix);

	this->_processCollisionsForSubModels(collider, this->_collisionsTransformMatrix);
};
*/

bool Babylon::Mesh::intersectsMesh(Mesh::Ptr mesh, float precise) {
	if (!this->_boundingInfo || !mesh->_boundingInfo) {
		return false;
	}

	return this->_boundingInfo->intersects(mesh->_boundingInfo, precise);
};

bool Babylon::Mesh::intersectsPoint(Vector3::Ptr point) {
	if (!this->_boundingInfo) {
		return false;
	}

	return this->_boundingInfo->intersectsPoint(point);
};

// Picking
PickingInfo::Ptr Babylon::Mesh::intersects(Ray::Ptr ray, bool fastCheck) {
	auto pickingInfo = make_shared<PickingInfo>();

	if (!this->_boundingInfo || !ray->intersectsSphere(this->_boundingInfo->boundingSphere) || !ray->intersectsBox(this->_boundingInfo->boundingBox)) {
		return pickingInfo;
	}

	this->_generatePointsArray();

	auto distance = numeric_limits<float>::max();

	for (auto subMesh : this->subMeshes) {
		// Bounding test
		if (this->subMeshes.size() > 1 && !subMesh->canIntersects(ray))
			continue;

		auto currentDistance = subMesh->intersects(ray, this->_positions, this->_indices, fastCheck);

		if (currentDistance > 0) {
			if (fastCheck || currentDistance < distance) {
				distance = currentDistance;

				if (fastCheck) {
					break;
				}
			}
		}
	}

	if (distance >= 0 && distance < numeric_limits<float>::max()) {
		// Get picked point
		auto world = this->getWorldMatrix();
		auto worldOrigin = Vector3::TransformCoordinates(ray->origin, world);
		auto direction = ray->direction->clone();
		direction->normalize();
		direction = direction->scale(distance);
		auto worldDirection = Vector3::TransformNormal(direction, world);

		auto pickedPoint = worldOrigin->add(worldDirection);

		// Return result
		pickingInfo->hit = true;
		pickingInfo->distance = Vector3::Distance(worldOrigin, pickedPoint);
		pickingInfo->pickedPoint = pickedPoint;
		pickingInfo->pickedMesh = this;
		return pickingInfo;
	}

	return pickingInfo;
};

// Clone
Mesh::Ptr Babylon::Mesh::clone(string name, Node::Ptr newParent, bool doNotCloneChildren) {
	auto result = make_shared<Mesh>(name, this->_scene);

	// Buffers
	result->_vertexBuffers = this->_vertexBuffers;
	for (auto kind : result->_vertexBuffers) {
		result->_vertexBuffers[kind].references++;
	}

	result->_indexBuffer = this->_indexBuffer;
	this->_indexBuffer.references++;

	// Deep copy
	// TODO: finish it
	////Tools::DeepCopy(this, result, ["name", "material", "skeleton"], ["_indices", "_totalVertices"]);

	// Bounding info
	auto extend = Tools::ExtractMinAndMax(this->getVerticesData(VertexBufferKind_PositionKind), 0, this->_totalVertices);
	result->_boundingInfo = make_shared<BoundingInfo>(extend.minimum, extend.maximum);

	// Material
	result->material = this->material;

	// Parent
	if (newParent) {
		result->parent = newParent;
	}

	if (!doNotCloneChildren) {
		// Children
		for (auto mesh : this->_scene->meshes) {
			if (mesh->parent == enable_shared_from_this<Mesh>::shared_from_this()) {
				mesh->clone(mesh->name, result);
			}
		}
	}

	// Particles
	for (auto system : this->_scene->particleSystems) {
		if (system.emitter == enable_shared_from_this<Mesh>::shared_from_this()) {
			system->clone(system->name, result);
		}
	}

	result->computeWorldMatrix(true);

	return result;
};

// Dispose
void Babylon::Mesh::dispose(bool doNotRecurse) {
	for (auto _vertexBuffer : this->_vertexBuffers) {
		_vertexBuffer->dispose();
	}
	this->_vertexBuffers.clear();

	if (this->_indexBuffer) {
		this->_scene->getEngine()->_releaseBuffer(this->_indexBuffer);
		this->_indexBuffer = nullptr;
	}

	// Remove from scene
	auto it = find(begin(this->_scene->meshes), end(this->_scene->meshes), enable_shared_from_this<Mesh>::shared_from_this());
	if (it != end(this->_scene->meshes))
	{
		this->_scene->meshes.erase(it);
	}

	if (!doNotRecurse) {

		/// TODO: remove disposed elements from array

		// Particles
		for (auto particleSystem : this->_scene->particleSystems) {
			if (particleSystem.emitter == enable_shared_from_this<Mesh>::shared_from_this()) {
				particleSystem.dispose();
			}
		}

		/// TODO: remove disposed elements from array

		// Children
		auto objects = this->_scene->meshes;
		for (auto object : objects) {
			if (object->parent == this) {
				object->dispose();
			}
		}
	} else {
		for (auto obj : this->_scene->meshes) {
			if (obj->parent == enable_shared_from_this<Mesh>::shared_from_this()) {
				obj->parent = nullptr;
				obj->computeWorldMatrix(true);
			}
		}
	}

	this->_isDisposed = true;

	// Callback
	if (this->onDispose) {
		this->onDispose();
	}
};

// Physics
Babylon::Mesh::setPhysicsState(options) {
	if (!this->_scene->_physicsEngine) {
		return;
	}

	options.impostor = options.impostor || BABYLON.PhysicsEngine.NoImpostor;
	options.mass = options.mass || 0;
	options.friction = options.friction || 0.2;
	options.restitution = options.restitution || 0.9;

	this->_physicImpostor = options.impostor;
	this->_physicsMass = options.mass;
	this->_physicsFriction = options.friction;
	this->_physicRestitution = options.restitution;

	if (options.impostor == BABYLON.PhysicsEngine.NoImpostor) {
		this->_scene->_physicsEngine._unregisterMesh(this);
		return;
	}

	this->_scene->_physicsEngine._registerMesh(this, options);
};

Babylon::Mesh::getPhysicsImpostor() {
	if (!this->_physicImpostor) {
		return BABYLON.PhysicsEngine.NoImpostor;
	}

	return this->_physicImpostor;
};

Babylon::Mesh::getPhysicsMass() {
	if (!this->_physicsMass) {
		return 0;
	}

	return this->_physicsMass;
};

Babylon::Mesh::getPhysicsFriction() {
	if (!this->_physicsFriction) {
		return 0;
	}

	return this->_physicsFriction;
};

Babylon::Mesh::getPhysicsRestitution() {
	if (!this->_physicRestitution) {
		return 0;
	}

	return this->_physicRestitution;
};

Babylon::Mesh::applyImpulse(force, contactPoint) {
	if (!this->_physicImpostor) {
		return;
	}

	this->_scene->_physicsEngine._applyImpulse(this, force, contactPoint);
};

Babylon::Mesh::setPhysicsLinkWith(otherMesh, pivot1, pivot2) {
	if (!this->_physicImpostor) {
		return;
	}

	this->_scene->_physicsEngine._createLink(this, otherMesh, pivot1, pivot2);
};

// Statics
BABYLON.Mesh.CreateBox(name, size, scene, updatable) {
	auto box = make_shared<Mesh>(name, scene);

	auto normalsSource = [
		make_shared<Vector3>(0, 0, 1),
			make_shared<Vector3>(0, 0, -1),
			make_shared<Vector3>(1, 0, 0),
			make_shared<Vector3>(-1, 0, 0),
			make_shared<Vector3>(0, 1, 0),
			make_shared<Vector3>(0, -1, 0)
	];

	auto indices = [];
	auto positions = [];
	auto normals = [];
	auto uvs = [];

	// Create each face in turn.
	for (auto index = 0; index < normalsSource.size(); index++) {
		auto normal = normalsSource[index];

		// Get two vectors perpendicular to the face normal and to each other.
		auto side1 = make_shared<Vector3>(normal->y, normal->z, normal->x);
		auto side2 = Vector3::Cross(normal, side1);

		// Six indices (two triangles) per face.
		auto verticesLength = positions.size() / 3;
		indices.push_back(verticesLength);
		indices.push_back(verticesLength + 1);
		indices.push_back(verticesLength + 2);

		indices.push_back(verticesLength);
		indices.push_back(verticesLength + 2);
		indices.push_back(verticesLength + 3);

		// Four vertices per face.
		auto vertex = normal.subtract(side1).subtract(side2).scale(size / 2);
		positions.push_back(vertex->x, vertex->y, vertex->z);
		normals.push_back(normal->x, normal->y, normal->z);
		uvs.push_back(1.0, 1.0);

		vertex = normal.subtract(side1).add(side2).scale(size / 2);
		positions.push_back(vertex->x, vertex->y, vertex->z);
		normals.push_back(normal->x, normal->y, normal->z);
		uvs.push_back(0.0, 1.0);

		vertex = normal.add(side1).add(side2).scale(size / 2);
		positions.push_back(vertex->x, vertex->y, vertex->z);
		normals.push_back(normal->x, normal->y, normal->z);
		uvs.push_back(0.0, 0.0);

		vertex = normal.add(side1).subtract(side2).scale(size / 2);
		positions.push_back(vertex->x, vertex->y, vertex->z);
		normals.push_back(normal->x, normal->y, normal->z);
		uvs.push_back(1.0, 0.0);
	}

	box.setVerticesData(positions, VertexBufferKind_PositionKind, updatable);
	box.setVerticesData(normals, VertexBufferKind_NormalKind, updatable);
	box.setVerticesData(uvs, BABYLON.VertexBuffer.UVKind, updatable);
	box.setIndices(indices);

	return box;
};

BABYLON.Mesh.CreateSphere(name, segments, diameter, scene, updatable) {
	auto sphere = make_shared<Mesh>(name, scene);

	auto radius = diameter / 2;

	auto totalZRotationSteps = 2 + segments;
	auto totalYRotationSteps = 2 * totalZRotationSteps;

	auto indices = [];
	auto positions = [];
	auto normals = [];
	auto uvs = [];

	for (auto zRotationStep = 0; zRotationStep <= totalZRotationSteps; zRotationStep++) {
		auto normalizedZ = zRotationStep / totalZRotationSteps;
		auto angleZ = (normalizedZ * PI);

		for (auto yRotationStep = 0; yRotationStep <= totalYRotationSteps; yRotationStep++) {
			auto normalizedY = yRotationStep / totalYRotationSteps;

			auto angleY = normalizedY * PI * 2;

			auto rotationZ = Matrix::RotationZ(-angleZ);
			auto rotationY = Matrix::RotationY(angleY);
			auto afterRotZ = Vector3::TransformCoordinates(Vector3::Up(), rotationZ);
			auto complete = Vector3::TransformCoordinates(afterRotZ, rotationY);

			auto vertex = complete.scale(radius);
			auto normal = Vector3::Normalize(vertex);

			positions.push_back(vertex->x, vertex->y, vertex->z);
			normals.push_back(normal->x, normal->y, normal->z);
			uvs.push_back(normalizedZ, normalizedY);
		}

		if (zRotationStep > 0) {
			auto verticesCount = positions.size() / 3;
			for (auto firstIndex = verticesCount - 2 * (totalYRotationSteps + 1) ; (firstIndex + totalYRotationSteps + 2) < verticesCount; firstIndex++) {
				indices.push_back((firstIndex));
				indices.push_back((firstIndex + 1));
				indices.push_back(firstIndex + totalYRotationSteps + 1);

				indices.push_back((firstIndex + totalYRotationSteps + 1));
				indices.push_back((firstIndex + 1));
				indices.push_back((firstIndex + totalYRotationSteps + 2));
			}
		}
	}

	sphere.setVerticesData(positions, VertexBufferKind_PositionKind, updatable);
	sphere.setVerticesData(normals, VertexBufferKind_NormalKind, updatable);
	sphere.setVerticesData(uvs, BABYLON.VertexBuffer.UVKind, updatable);
	sphere.setIndices(indices);

	return sphere;
};

// Cylinder and cone (Code inspired by SharpDX.org)
BABYLON.Mesh.CreateCylinder(name, height, diameterTop, diameterBottom, tessellation, scene, updatable) {
	auto radiusTop = diameterTop / 2;
	auto radiusBottom = diameterBottom / 2;
	auto indices = [];
	auto positions = [];
	auto normals = [];
	auto uvs = [];
	auto cylinder = make_shared<Mesh>(name, scene);

	auto getCircleVector(i) {
		auto angle = (i * 2.0 * PI / tessellation);
		auto dx = sin(angle);
		auto dz = cos(angle);

		return make_shared<Vector3>(dx, 0, dz);
	};

	auto createCylinderCap(isTop) {
		auto radius = isTop ? radiusTop : radiusBottom;

		if (radius == 0) {
			return
		}

		// Create cap indices.
		for (auto i = 0; i < tessellation - 2; i++) {
			auto i1 = (i + 1) % tessellation;
			auto i2 = (i + 2) % tessellation;

			if (!isTop) {
				auto tmp = i1;
				auto i1 = i2;
				i2 = tmp;
			}

			auto vbase = positions.size() / 3;
			indices.push_back(vbase);
			indices.push_back(vbase + i1);
			indices.push_back(vbase + i2);
		}


		// Which end of the cylinder is this?
		auto normal = make_shared<Vector3>(0, -1, 0);
		auto textureScale = make_shared<Vector2>(-0.5, -0.5);

		if (!isTop) {
			normal = normal.scale(-1);
			textureScale->x = -textureScale->x;
		}

		// Create cap vertices.
		for (auto i = 0; i < tessellation; i++) {
			auto circleVector = getCircleVector(i);
			auto position = circleVector.scale(radius).add(normal.scale(height));
			auto textureCoordinate = make_shared<Vector2>(circleVector->x * textureScale->x + 0.5, circleVector->z * textureScale->y + 0.5);

			positions.push_back(position->x, position->y, position->z);
			normals.push_back(normal->x, normal->y, normal->z);
			uvs.push_back(textureCoordinate->x, textureCoordinate->y);
		}
	};

	height /= 2;

	auto topOffset = make_shared<Vector3>(0, 1, 0).scale(height);

	auto stride = tessellation + 1;

	// Create a ring of triangles around the outside of the cylinder->
	for (auto i = 0; i <= tessellation; i++) {
		auto normal = getCircleVector(i);
		auto sideOffsetBottom = normal.scale(radiusBottom);
		auto sideOffsetTop = normal.scale(radiusTop);
		auto textureCoordinate = make_shared<Vector2>(i / tessellation, 0);

		auto position = sideOffsetBottom.add(topOffset);
		positions.push_back(position->x, position->y, position->z);
		normals.push_back(normal->x, normal->y, normal->z);
		uvs.push_back(textureCoordinate->x, textureCoordinate->y);

		position = sideOffsetTop.subtract(topOffset);
		textureCoordinate->y += 1;
		positions.push_back(position->x, position->y, position->z);
		normals.push_back(normal->x, normal->y, normal->z);
		uvs.push_back(textureCoordinate->x, textureCoordinate->y);

		indices.push_back(i * 2);
		indices.push_back((i * 2 + 2) % (stride * 2));
		indices.push_back(i * 2 + 1);

		indices.push_back(i * 2 + 1);
		indices.push_back((i * 2 + 2) % (stride * 2));
		indices.push_back((i * 2 + 3) % (stride * 2));
	}

	// Create flat triangle fan caps to seal the top and bottom.
	createCylinderCap(true);
	createCylinderCap(false);

	cylinder->setVerticesData(positions, VertexBufferKind_PositionKind, updatable);
	cylinder->setVerticesData(normals, VertexBufferKind_NormalKind, updatable);
	cylinder->setVerticesData(uvs, BABYLON.VertexBuffer.UVKind, updatable);
	cylinder->setIndices(indices);

	return cylinder;
};

// Torus  (Code from SharpDX.org)
BABYLON.Mesh.CreateTorus(name, diameter, thickness, tessellation, scene, updatable) {
	auto torus = make_shared<Mesh>(name, scene);

	auto indices = [];
	auto positions = [];
	auto normals = [];
	auto uvs = [];

	auto stride = tessellation + 1;

	for (auto i = 0; i <= tessellation; i++) {
		auto u = i / tessellation;

		auto outerAngle = i * PI * 2.0 / tessellation - PI / 2.0;

		auto transform = Matrix::Translation(diameter / 2.0, 0, 0).multiply(Matrix::RotationY(outerAngle));

		for (auto j = 0; j <= tessellation; j++) {
			auto v = 1 - j / tessellation;

			auto innerAngle = j * PI * 2.0 / tessellation + PI;
			auto dx = cos(innerAngle);
			auto dy = sin(innerAngle);

			// Create a vertex.
			auto normal = make_shared<Vector3>(dx, dy, 0);
			auto position = normal.scale(thickness / 2);
			auto textureCoordinate = make_shared<Vector2>(u, v);

			position = Vector3::TransformCoordinates(position, transform);
			normal = Vector3::TransformNormal(normal, transform);

			positions.push_back(position->x, position->y, position->z);
			normals.push_back(normal->x, normal->y, normal->z);
			uvs.push_back(textureCoordinate->x, textureCoordinate->y);

			// And create indices for two triangles.
			auto nextI = (i + 1) % stride;
			auto nextJ = (j + 1) % stride;

			indices.push_back(i * stride + j);
			indices.push_back(i * stride + nextJ);
			indices.push_back(nextI * stride + j);

			indices.push_back(i * stride + nextJ);
			indices.push_back(nextI * stride + nextJ);
			indices.push_back(nextI * stride + j);
		}
	}

	torus.setVerticesData(positions, VertexBufferKind_PositionKind, updatable);
	torus.setVerticesData(normals, VertexBufferKind_NormalKind, updatable);
	torus.setVerticesData(uvs, BABYLON.VertexBuffer.UVKind, updatable);
	torus.setIndices(indices);

	return torus;
};

// Plane
BABYLON.Mesh.CreatePlane(name, size, scene, updatable) {
	auto plane = make_shared<Mesh>(name, scene);

	auto indices = [];
	auto positions = [];
	auto normals = [];
	auto uvs = [];

	// Vertices
	auto halfSize = size / 2.0;
	positions.push_back(-halfSize, -halfSize, 0);
	normals.push_back(0, 0, -1.0);
	uvs.push_back(0.0, 0.0);

	positions.push_back(halfSize, -halfSize, 0);
	normals.push_back(0, 0, -1.0);
	uvs.push_back(1.0, 0.0);

	positions.push_back(halfSize, halfSize, 0);
	normals.push_back(0, 0, -1.0);
	uvs.push_back(1.0, 1.0);

	positions.push_back(-halfSize, halfSize, 0);
	normals.push_back(0, 0, -1.0);
	uvs.push_back(0.0, 1.0);

	// Indices
	indices.push_back(0);
	indices.push_back(1);
	indices.push_back(2);

	indices.push_back(0);
	indices.push_back(2);
	indices.push_back(3);

	plane.setVerticesData(positions, VertexBufferKind_PositionKind, updatable);
	plane.setVerticesData(normals, VertexBufferKind_NormalKind, updatable);
	plane.setVerticesData(uvs, BABYLON.VertexBuffer.UVKind, updatable);
	plane.setIndices(indices);

	return plane;
};

BABYLON.Mesh.CreateGround(name, width, height, subdivisions, scene, updatable) {
	auto ground = make_shared<Mesh>(name, scene);

	auto indices = [];
	auto positions = [];
	auto normals = [];
	auto uvs = [];
	auto row, col;

	for (row = 0; row <= subdivisions; row++) {
		for (col = 0; col <= subdivisions; col++) {
			auto position = make_shared<Vector3>((col * width) / subdivisions - (width / 2.0), 0, ((subdivisions - row) * height) / subdivisions - (height / 2.0));
			auto normal = make_shared<Vector3>(0, 1.0, 0);

			positions.push_back(position->x, position->y, position->z);
			normals.push_back(normal->x, normal->y, normal->z);
			uvs.push_back(col / subdivisions, 1.0 - row / subdivisions);
		}
	}

	for (row = 0; row < subdivisions; row++) {
		for (col = 0; col < subdivisions; col++) {
			indices.push_back(col + 1 + (row + 1) * (subdivisions + 1));
			indices.push_back(col + 1 + row * (subdivisions + 1));
			indices.push_back(col + row * (subdivisions + 1));

			indices.push_back(col + (row + 1) * (subdivisions + 1));
			indices.push_back(col + 1 + (row + 1) * (subdivisions + 1));
			indices.push_back(col + row * (subdivisions + 1));
		}
	}

	ground.setVerticesData(positions, VertexBufferKind_PositionKind, updatable);
	ground.setVerticesData(normals, VertexBufferKind_NormalKind, updatable);
	ground.setVerticesData(uvs, BABYLON.VertexBuffer.UVKind, updatable);
	ground.setIndices(indices);

	return ground;
};

BABYLON.Mesh.CreateGroundFromHeightMap(name, url, width, height, subdivisions, minHeight, maxHeight, scene, updatable) {
	auto ground = make_shared<Mesh>(name, scene);

	auto onload(img) {
		auto indices = [];
		auto positions = [];
		auto normals = [];
		auto uvs = [];
		auto row, col;

		// Getting height map data
		auto canvas = document.createElement("canvas");
		auto context = canvas.getContext("2d");
		auto heightMapWidth = img.width;
		auto heightMapHeight = img.height;
		canvas.width = heightMapWidth;
		canvas.height = heightMapHeight;

		context.drawImage(img, 0, 0);

		auto buffer = context.getImageData(0, 0, heightMapWidth, heightMapHeight).data;

		// Vertices
		for (row = 0; row <= subdivisions; row++) {
			for (col = 0; col <= subdivisions; col++) {
				auto position = make_shared<Vector3>((col * width) / subdivisions - (width / 2.0), 0, ((subdivisions - row) * height) / subdivisions - (height / 2.0));

				// Compute height
				auto heightMapX = (((position->x + width / 2) / width) * (heightMapWidth - 1)) | 0;
				auto heightMapY = ((1.0 - (position->z + height / 2) / height) * (heightMapHeight - 1)) | 0;

				auto pos = (heightMapX + heightMapY * heightMapWidth) * 4;
				auto r = buffer[pos] / 255.0;
				auto g = buffer[pos + 1] / 255.0;
				auto b = buffer[pos + 2] / 255.0;

				auto gradient = r * 0.3 + g * 0.59 + b * 0.11;

				position->y = minHeight + (maxHeight - minHeight) * gradient;

				// Add  vertex
				positions.push_back(position->x, position->y, position->z);
				normals.push_back(0, 0, 0);
				uvs.push_back(col / subdivisions, 1.0 - row / subdivisions);
			}
		}

		// Indices
		for (row = 0; row < subdivisions; row++) {
			for (col = 0; col < subdivisions; col++) {
				indices.push_back(col + 1 + (row + 1) * (subdivisions + 1));
				indices.push_back(col + 1 + row * (subdivisions + 1));
				indices.push_back(col + row * (subdivisions + 1));

				indices.push_back(col + (row + 1) * (subdivisions + 1));
				indices.push_back(col + 1 + (row + 1) * (subdivisions + 1));
				indices.push_back(col + row * (subdivisions + 1));
			}
		}

		// Normals
		BABYLON.Mesh.ComputeNormal(positions, normals, indices);

		// Transfer
		ground.setVerticesData(positions, VertexBufferKind_PositionKind, updatable);
		ground.setVerticesData(normals, VertexBufferKind_NormalKind, updatable);
		ground.setVerticesData(uvs, BABYLON.VertexBuffer.UVKind, updatable);
		ground.setIndices(indices);

		ground._isReady = true;
	};

	BABYLON.Tools.LoadImage(url, onload, scene.database);

	ground._isReady = false;

	return ground;
};

// Tools
BABYLON.Mesh.ComputeNormal(positions, normals, indices) {
	auto positionVectors = [];
	auto facesOfVertices = [];
	auto index;

	for (index = 0; index < positions.size(); index += 3) {
		auto vector3 = make_shared<Vector3>(positions[index], positions[index + 1], positions[index + 2]);
		positionVectors.push_back(vector3);
		facesOfVertices.push_back([]);
	}
	// Compute normals
	auto facesNormals = [];
	for (index = 0; index < indices.size() / 3; index++) {
		auto i1 = indices[index * 3];
		auto i2 = indices[index * 3 + 1];
		auto i3 = indices[index * 3 + 2];

		auto p1 = positionVectors[i1];
		auto p2 = positionVectors[i2];
		auto p3 = positionVectors[i3];

		auto p1p2 = p1.subtract(p2);
		auto p3p2 = p3.subtract(p2);

		facesNormals[index] = Vector3::Normalize(Vector3::Cross(p1p2, p3p2));
		facesOfVertices[i1].push_back(index);
		facesOfVertices[i2].push_back(index);
		facesOfVertices[i3].push_back(index);
	}

	for (index = 0; index < positionVectors.size(); index++) {
		auto faces = facesOfVertices[index];

		auto normal = Vector3::Zero();
		for (auto faceIndex = 0; faceIndex < faces.size(); faceIndex++) {
			normal.addInPlace(facesNormals[faces[faceIndex]]);
		}

		normal = Vector3::Normalize(normal.scale(1.0 / faces.size()));

		normals[index * 3] = normal->x;
		normals[index * 3 + 1] = normal->y;
		normals[index * 3 + 2] = normal->z;
	}
};
