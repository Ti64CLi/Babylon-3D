#include "freeCamera.h"
#include "defs.h"
#include "engine.h"
// TODO: finish it
////#include "collider.h"

using namespace Babylon;

// TODO: add functionality to rotate
Babylon::FreeCamera::FreeCamera(string name, Vector3::Ptr position, Scene::Ptr scene) 
	: Camera(name, Vector3::Zero(), scene), previousPosition_X(-1), previousPosition_Y(-1)
{
	this->cameraDirection = make_shared<Vector3>(0, 0, 0);
	this->cameraRotation = make_shared<Vector2>(0, 0);
	this->rotation = make_shared<Vector3>(0, 0, 0);
	this->ellipsoid = make_shared<Vector3>(0.5, 1, 0.5);

	/*
	this->_keys = [];
	this->keysUp = [38];
	this->keysDown = [40];
	this->keysLeft = [37];
	this->keysRight = [39];
	*/

	// TODO: finish it
	// Collisions
	//this->_collider = make_shared<Collider>();
	this->_needMoveForGravity = true;

	// Internals
	this->_currentTarget = Vector3::Zero();
	this->_viewMatrix = Matrix::Zero();
	this->_camMatrix = Matrix::Zero();
	this->_cameraTransformMatrix = Matrix::Zero();
	this->_cameraRotationMatrix = Matrix::Zero();
	this->_referencePoint = Vector3::Zero();
	this->_transformedReferencePoint = Vector3::Zero();
	this->_oldPosition = Vector3::Zero();
	this->_diffPosition = Vector3::Zero();
	this->_newPosition = Vector3::Zero();
	this->_lookAtTemp = Matrix::Zero();
	this->_tempMatrix = Matrix::Zero();

	_initCache();

	// Members
	speed = 2.0;
	checkCollisions = false;
	applyGravity = false;
	noRotationConstraint = false;
	angularSensibility = 2000.0;
	target = nullptr;
	onCollide = nullptr;

	_localDirection = nullptr;
}

FreeCamera::Ptr Babylon::FreeCamera::New(string name, Vector3::Ptr position, Scene::Ptr scene)
{
	auto freeCamera = make_shared<FreeCamera>(FreeCamera(name, position, scene));
	scene->cameras.push_back(freeCamera);

	if (!scene->activeCamera) {
		scene->activeCamera = freeCamera;
	}

	return freeCamera;
}

Vector3::Ptr Babylon::FreeCamera::_getTargetPosition () {
	return this->target;
};

// Cache
void Babylon::FreeCamera::_initCache () {
	this->_cache.target = make_shared<Vector3>(numeric_limits<float>::max(), numeric_limits<float>::max(), numeric_limits<float>::max());
	this->_cache.rotation = make_shared<Vector3>(numeric_limits<float>::max(), numeric_limits<float>::max(), numeric_limits<float>::max());
};

void Babylon::FreeCamera::_updateCache (bool ignoreParentClass) {
	if (!ignoreParentClass)
		Camera::_updateCache(this);

	auto lockedTargetPosition = this->_getTargetPosition();
	if (!lockedTargetPosition) {
		this->_cache.target = nullptr;
	}
	else {
		if (!this->_cache.target)
			this->_cache.target = lockedTargetPosition->clone();
		else
			this->_cache.target->copyFrom(lockedTargetPosition);
	}

	this->_cache.rotation->copyFrom(this->rotation);
};

// Synchronized
bool Babylon::FreeCamera::_isSynchronizedViewMatrix () {
	if (Camera::_isSynchronizedViewMatrix()) {
		return false;
	}

	auto lockedTargetPosition = this->_getTargetPosition();

	return (this->_cache.target ? this->_cache.target == lockedTargetPosition : !lockedTargetPosition)
		&& this->_cache.rotation == this->rotation;
};

// Methods
float Babylon::FreeCamera::_computeLocalCameraSpeed () {
	// TODO: finish it
	//return this->speed * ((Tools::GetDeltaTime() / (Tools::GetFps() * 10.0)));
	return this->speed;
};

// Target
void Babylon::FreeCamera::setTarget (Vector3::Ptr target) {
	this->upVector->normalize();

	Matrix::LookAtLHToRef(this->position, target, this->upVector, this->_camMatrix);
	this->_camMatrix->invert();

	this->rotation->x = atan(this->_camMatrix->m[6] / this->_camMatrix->m[10]);

	auto vDir = target->subtract(this->position);

	auto PI = 4. * atan(1.); // PI

	if (vDir->x >= 0.0) {
		this->rotation->y = (-atan(vDir->z / vDir->x) + PI / 2.0);
	} else {
		this->rotation->y = (-atan(vDir->z / vDir->x) - PI / 2.0);
	}

	this->rotation->z = -acos(Vector3::Dot(make_shared<Vector3>(0, 1.0, 0), this->upVector));

	if (isnan(this->rotation->x)) {
		this->rotation->x = 0;
	}

	if (isnan(this->rotation->y)) {
		this->rotation->y = 0;
	}

	if (isnan(this->rotation->z)) {
		this->rotation->z = 0;
	}
};

void Babylon::FreeCamera::attachControl (ICanvas::Ptr canvas, bool noPreventDefault) {
	auto engine = this->_scene->getEngine();

	if (this->_attachedCanvas) {
		return;
	}
	this->_attachedCanvas = canvas;

	this->_onMouseDown = [=] (int clientX, int clientY) {
		previousPosition_X = clientX;
		previousPosition_Y = clientY;
	};

	this->_onMouseUp = [=] (int clientX, int clientY) {
		previousPosition_X = -1;
		previousPosition_Y = -1;
	};

	this->_onMouseOut = [=] (int clientX, int clientY) {
		previousPosition_X = -1;
		previousPosition_Y = -1;
		// TODO: finish it
		/*
		this->_keys = [];
		*/
	};

	this->_onMove = [&] (int clientX, int clientY) {
		if (!previousPosition_X != -1 && previousPosition_Y != -1 && !engine->isPointerLock) {
			return;
		}

		int offsetX;
		int offsetY;

		// TODO: finish it
		//if (!engine.isPointerLock) {
		offsetX = clientX - previousPosition_X;
		offsetY = clientY - previousPosition_Y;
		//} else {
		//	offsetX = evt.movementX;
		//	offsetY = evt.movementY;
		//}

		this->cameraRotation->y += offsetX / this->angularSensibility;
		this->cameraRotation->x += offsetY / this->angularSensibility;

		previousPosition_X = clientX;
		previousPosition_Y = clientY;
	};

	this->_onKeyDown = [=] (int keyCode) {
		// TODO: finish it
		/*
		if (this->keysUp.indexOf(keyCode) != -1 ||
			this->keysDown.indexOf(keyCode) != -1 ||
			this->keysLeft.indexOf(keyCode) != -1 ||
			this->keysRight.indexOf(keyCode) != -1) {
				auto index = this->_keys.indexOf(keyCode);

				if (index == -1) {
					this->_keys.push(keyCode);
				}
		}
		*/
	};

	this->_onKeyUp = [=] (int keyCode) {
		// TODO: finish it
		/*
		if (this->keysUp.indexOf(keyCode) != -1 ||
			this->keysDown.indexOf(keyCode) != -1 ||
			this->keysLeft.indexOf(keyCode) != -1 ||
			this->keysRight.indexOf(keyCode) != -1) {
				auto index = this->_keys.indexOf(keyCode);

				if (index >= 0) {
					this->_keys.splice(index, 1);
				}
		}
		*/
	};

	this->_onLostFocus = [&] () {
		// TODO: finish it
		//this->_keys = [];
	};

	this->_reset = [&] () {
		// TODO: finish it
		//this->_keys = [];
		previousPosition_X = -1;
		previousPosition_Y = -1;
		this->cameraDirection = make_shared<Vector3>(0, 0, 0);
		this->cameraRotation = make_shared<Vector2>(0, 0);
	};

	// TODO: finish it
	/*
	canvas.addEventListener("mousedown", this->_onMouseDown, false);
	canvas.addEventListener("mouseup", this->_onMouseUp, false);
	canvas.addEventListener("mouseout", this->_onMouseOut, false);
	canvas.addEventListener("mousemove", this->_onMouseMove, false);
	window.addEventListener("keydown", this->_onKeyDown, false);
	window.addEventListener("keyup", this->_onKeyUp, false);
	window.addEventListener("blur", this->_onLostFocus, false);
	*/

	canvas->addEventListener_OnMoveEvent(this->_onMove);
};

void Babylon::FreeCamera::detachControl (ICanvas::Ptr canvas) {
	if (this->_attachedCanvas != canvas) {
		return;
	}

	// TODO: finish it
	/*
	canvas.removeEventListener("mousedown", this->_onMouseDown);
	canvas.removeEventListener("mouseup", this->_onMouseUp);
	canvas.removeEventListener("mouseout", this->_onMouseOut);
	canvas.removeEventListener("mousemove", this->_onMouseMove);
	window.removeEventListener("keydown", this->_onKeyDown);
	window.removeEventListener("keyup", this->_onKeyUp);
	window.removeEventListener("blur", this->_onLostFocus);
	*/

	this->_attachedCanvas = nullptr;

	// TODO: finish it
	if (this->_reset) {
		this->_reset();
	}

	// TODO: do not forget to remove the listener to onMove
};

// TODO: finish it when Collider is finished
void Babylon::FreeCamera::_collideWithWorld (Vector3::Ptr velocity) {
	/*
	this->position->subtractFromFloatsToRef(0, this->ellipsoid->y, 0, this->_oldPosition);
	this->_collider.radius = this->ellipsoid;

	this->_scene->_getNewPosition(this->_oldPosition, velocity, this->_collider, 3, this->_newPosition);
	this->_newPosition->subtractToRef(this->_oldPosition, this->_diffPosition);

	if (this->_diffPosition->length() > Engine::collisionsEpsilon) {
		this->position->addInPlace(this->_diffPosition);
		if (this->onCollide) {
			this->onCollide(this->_collider->collidedMesh);
		}
	}
	*/
};

void Babylon::FreeCamera::_checkInputs () {
	if (!this->_localDirection) {
		this->_localDirection = Vector3::Zero();
		this->_transformedDirection = Vector3::Zero();
	}

	// Keyboard
	// TODO: finish it
	/*
	for (auto index = 0; index < this->_keys.length; index++) {
		auto keyCode = this->_keys[index];
		auto speed = this->_computeLocalCameraSpeed();

		if (this->keysLeft.indexOf(keyCode) != -1) {
			this->_localDirection.copyFromFloats(-speed, 0, 0);
		} else if (this->keysUp.indexOf(keyCode) != -1) {
			this->_localDirection.copyFromFloats(0, 0, speed);
		} else if (this->keysRight.indexOf(keyCode) != -1) {
			this->_localDirection.copyFromFloats(speed, 0, 0);
		} else if (this->keysDown.indexOf(keyCode) != -1) {
			this->_localDirection.copyFromFloats(0, 0, -speed);
		}

		this->getViewMatrix()->invertToRef(this->_cameraTransformMatrix);
		Vector3::TransformNormalToRef(this->_localDirection, this->_cameraTransformMatrix, this->_transformedDirection);
		this->cameraDirection->addInPlace(this->_transformedDirection);
	}
	*/
};


void Babylon::FreeCamera::_update () {
	this->_checkInputs();

	auto needToMove = this->_needMoveForGravity || abs(this->cameraDirection->x) > 0 || abs(this->cameraDirection->y) > 0 || abs(this->cameraDirection->z) > 0;
	auto needToRotate = abs(this->cameraRotation->x) > 0 || abs(this->cameraRotation->y) > 0;

	// Move
	if (needToMove) {
		if (this->checkCollisions && this->_scene->collisionsEnabled) {
			this->_collideWithWorld(this->cameraDirection);


			if (this->applyGravity) {
				auto oldPosition = this->position;
				this->_collideWithWorld(this->_scene->gravity);
				this->_needMoveForGravity = (Vector3::DistanceSquared(oldPosition, this->position) != 0);
			}
		} else {
			this->position->addInPlace(this->cameraDirection);
		}
	}

	// Rotate
	if (needToRotate) {
		this->rotation->x += this->cameraRotation->x;
		this->rotation->y += this->cameraRotation->y;


		if (!this->noRotationConstraint) {
			auto PI = 4. * atan(1.); // PI
			auto limit = (PI / 2) * 0.95;


			if (this->rotation->x > limit)
				this->rotation->x = limit;
			if (this->rotation->x < -limit)
				this->rotation->x = -limit;
		}
	}

	// Inertia
	if (needToMove) {
		if (abs(this->cameraDirection->x) < Engine::epsilon)
			this->cameraDirection->x = 0;

		if (abs(this->cameraDirection->y) < Engine::epsilon)
			this->cameraDirection->y = 0;

		if (abs(this->cameraDirection->z) < Engine::epsilon)
			this->cameraDirection->z = 0;

		this->cameraDirection->scaleInPlace(this->inertia);
	}
	if (needToRotate) {
		if (abs(this->cameraRotation->x) < Engine::epsilon)
			this->cameraRotation->x = 0;

		if (abs(this->cameraRotation->y) < Engine::epsilon)
			this->cameraRotation->y = 0;

		this->cameraRotation->scaleInPlace(this->inertia);
	}
};

Matrix::Ptr Babylon::FreeCamera::_getViewMatrix () {
	Vector3::FromFloatsToRef(0, 0, 1, this->_referencePoint);

	if (!this->lockedTarget) {
		// Compute
		if (this->upVector->x != 0 || this->upVector->y != 1.0 || this->upVector->z != 0) {
			Matrix::LookAtLHToRef(Vector3::Zero(), this->_referencePoint, this->upVector, this->_lookAtTemp);
			Matrix::RotationYawPitchRollToRef(this->rotation->y, this->rotation->x, this->rotation->z, this->_cameraRotationMatrix);


			this->_lookAtTemp->multiplyToRef(this->_cameraRotationMatrix, this->_tempMatrix);
			this->_lookAtTemp->invert();
			this->_tempMatrix->multiplyToRef(this->_lookAtTemp, this->_cameraRotationMatrix);
		} else {
			Matrix::RotationYawPitchRollToRef(this->rotation->y, this->rotation->x, this->rotation->z, this->_cameraRotationMatrix);
		}

		Vector3::TransformCoordinatesToRef(this->_referencePoint, this->_cameraRotationMatrix, this->_transformedReferencePoint);

		// Computing target and final matrix
		this->position->addToRef(this->_transformedReferencePoint, this->_currentTarget);
	} else {
		this->_currentTarget->copyFrom(this->_getTargetPosition());
	}

	Matrix::LookAtLHToRef(this->position, this->_currentTarget, this->upVector, this->_viewMatrix);
	return this->_viewMatrix;
};
