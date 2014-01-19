#include "mesh.h"

using namespace Babylon;

Babylon::Mesh::Mesh(string name, IScene::Ptr scene) : Node(enable_shared_from_this<Mesh>::shared_from_this()) {
	this->name = name;
	this->id = name;
	this->_scene = scene;

	this->_totalVertices = 0;
	this->_worldMatrix = Matrix::Identity();

	scene->getMeshes().push_back(enable_shared_from_this<Mesh>::shared_from_this());

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
};

// Cache
void Babylon::Mesh::_resetPointsArrayCache() {
	this->_positions.clear();
};
