#include "mesh.h"

using namespace Babylon;

Babylon::Mesh::Mesh(string name, IScene::Ptr scene) : Node(shared_from_this()) {
	this->name = name;
	this->id = name;
	this->_scene = scene;

	this->_totalVertices = 0;
	this->_worldMatrix = Matrix::Identity();

	scene->meshes.push_back(shared_from_this());

	this->position = new Vector3(0, 0, 0);
	this->rotation = new Vector3(0, 0, 0);
	this->rotationQuaternion = nullptr;
	this->scaling = new Vector3(1, 1, 1);

	this->_pivotMatrix = Matrix.Identity();

	this->_indices.clear();
	this->subMeshes.clear();

	this->_renderId = 0;

	this->_onBeforeRenderCallbacks.clear();

	// Animations
	this->animations.clear();

	this->_positions.clear();

	// Cache
	_initCache.call(shared_from_this());

	this->_childrenFlag = false;
	this->_localScaling = Matrix.Zero();
	this->_localRotation = Matrix.Zero();
	this->_localTranslation = Matrix.Zero();
	this->_localBillboard = Matrix.Zero();
	this->_localPivotScaling = Matrix.Zero();
	this->_localPivotScalingRotation = Matrix.Zero();
	this->_localWorld = Matrix.Zero();
	this->_worldMatrix = Matrix.Zero();
	this->_rotateYByPI = Matrix.RotationY(Math.PI);

	this->_collisionsTransformMatrix = Matrix.Zero();
	this->_collisionsScalingMatrix = Matrix.Zero();

	this->_absolutePosition = Vector3.Zero();
};