#include "shadowGenerator.h"
#include "defs.h"
#include "engine.h"
#include "light.h"

using namespace Babylon;

// Members
bool Babylon::ShadowGenerator::useVarianceShadowMap = true;

// TODO: finish it
Babylon::ShadowGenerator::ShadowGenerator(Size size, Light::Ptr light)
{
	this->_light = light;
	this->_scene = light->getScene();

	light->_shadowGenerator = shared_from_this();

	// Render target
	this->_shadowMap = RenderTargetTexture::New(light->name + "_shadowMap", size, this->_scene, false);
	this->_shadowMap->wrapU = CLAMP_ADDRESSMODE;
	this->_shadowMap->wrapV = CLAMP_ADDRESSMODE;
	this->_shadowMap->renderParticles = false;

	// Custom render function
	

	this->_shadowMap->customRenderFunction = [&](SubMesh::Array& opaqueSubMeshes, SubMesh::Array& alphaTestSubMeshes, SubMesh::Array& transparentSubMeshes, BeforeTransparentsFunc beforeTransparents) {
		for (auto opaqueSubMesh : opaqueSubMeshes) {
			this->renderSubMesh(opaqueSubMesh);
		}

		for (auto alphaTestSubMesh : alphaTestSubMeshes) {
			this->renderSubMesh(alphaTestSubMesh);
		}
	};

	// Internals
	this->_viewMatrix = Matrix::Zero();
	this->_projectionMatrix = Matrix::Zero();
	this->_transformMatrix = Matrix::Zero();
	this->_worldViewProjection = Matrix::Zero();
};

void Babylon::ShadowGenerator::renderSubMesh(SubMesh::Ptr subMesh) {
	

	auto mesh = subMesh->getMesh();
	auto world = mesh->getWorldMatrix();
	auto engine = this->_scene->getEngine();

	if (this->isReady(mesh)) {
		engine->enableEffect(this->_effect);

		// Bones
		if (mesh->skeleton && mesh->isVerticesDataPresent(VertexBufferKind_MatricesIndicesKind) && mesh->isVerticesDataPresent(VertexBufferKind_MatricesWeightsKind)) {
			this->_effect->setMatrix("world", world);
			this->_effect->setMatrix("viewProjection", this->getTransformMatrix());

			this->_effect->setMatrices("mBones", mesh->skeleton->getTransformMatrices());
		} else {
			world->multiplyToRef(this->getTransformMatrix(), this->_worldViewProjection);
			this->_effect->setMatrix("worldViewProjection", this->_worldViewProjection);
		}

		// Bind and draw
		mesh->bindAndDraw(subMesh, this->_effect, false);
	}
};

// Properties
bool Babylon::ShadowGenerator::isReady(Mesh::Ptr mesh) {
	vector_t<string> defines;

	if (this->useVarianceShadowMap) {
		defines.push_back("#define VSM");
	}

	vector_t<VertexBufferKind> attribs;
	attribs.push_back(VertexBufferKind_PositionKind);
	if (mesh->skeleton && mesh->isVerticesDataPresent(VertexBufferKind_MatricesIndicesKind) && mesh->isVerticesDataPresent(VertexBufferKind_MatricesWeightsKind)) {
		attribs.push_back(VertexBufferKind_MatricesIndicesKind);
		attribs.push_back(VertexBufferKind_MatricesWeightsKind);
		defines.push_back("#define BONES");
		defines.push_back("#define BonesPerMesh " + to_string(mesh->skeleton->bones.size()));
	}

	// Get correct effect      
	stringstream ss;
	for_each(begin(defines), end(defines), [&](string& item) { ss << item << endl; });
	auto join = ss.str();

	vector_t<string> uniformNames; 
	uniformNames.push_back("world");
	uniformNames.push_back("mBones");
	uniformNames.push_back("viewProjection");
	uniformNames.push_back("worldViewProjection");

	vector_t<string> samples; 
	vector_t<string> optionalDefines;

	if (this->_cachedDefines != join) {
		this->_cachedDefines = join;
		this->_effect = this->_scene->getEngine()->createEffect(
				"shadowMap",
				attribs,
				uniformNames,
				samples, 
				join, 
				optionalDefines);
	}

	return this->_effect->isReady();
};

RenderTargetTexture::Ptr Babylon::ShadowGenerator::getShadowMap() {
	return this->_shadowMap;
};

Light::Ptr Babylon::ShadowGenerator::getLight() {
	return this->_light;
};

// Methods
Matrix::Ptr Babylon::ShadowGenerator::getTransformMatrix() {
	auto lightPosition = this->_light->position;
	auto lightDirection = this->_light->direction;

	if (this->_light->_computeTransformedPosition()) {
		lightPosition = this->_light->_transformedPosition;
	}

	if (!this->_cachedPosition || !this->_cachedDirection || lightPosition != this->_cachedPosition || lightDirection != this->_cachedDirection) {

		this->_cachedPosition = lightPosition->clone();
		this->_cachedDirection = lightDirection->clone();

		auto activeCamera = this->_scene->activeCamera;

		Matrix::LookAtLHToRef(lightPosition, this->_light->position->add(lightDirection), Vector3::Up(), this->_viewMatrix);
		auto PI = 4. * atan(1.);
		Matrix::PerspectiveFovLHToRef(PI / 2.0, 1.0, activeCamera->minZ, activeCamera->maxZ, this->_projectionMatrix);

		this->_viewMatrix->multiplyToRef(this->_projectionMatrix, this->_transformMatrix);
	}

	return this->_transformMatrix;
};

void Babylon::ShadowGenerator::dispose(bool doNotRecurse) {
	this->_shadowMap->dispose();
};