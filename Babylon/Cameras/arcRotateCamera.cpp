#include "arcRotateCamera.h"
#include <limits>
#include "engine.h"

using namespace Babylon;

// TODO: add functionality to rotate
Babylon::ArcRotateCamera::ArcRotateCamera(string name, float alpha, float beta, float radius, Vector3::Ptr target, Scene::Ptr scene) 
	: Camera(name, Vector3::Zero(), scene)
{
	this->alpha = alpha;
	this->beta = beta;
	this->radius = radius;
	this->target = target;

	// TODO: finish it
	/*
        this._keys = [];
        this.keysUp = [38];
        this.keysDown = [40];
        this.keysLeft = [37];
        this.keysRight = [39];
	*/

	this->_viewMatrix = make_shared<Matrix>();

	this->inertialAlphaOffset = 0;
	this->inertialBetaOffset = 0;
	this->inertialRadiusOffset = 0;
	this->lowerAlphaLimit = 0;
	this->upperAlphaLimit = 0;
	this->lowerBetaLimit = 0.01;
	this->upperBetaLimit = 4. * atan(1.); // PI
	this->lowerRadiusLimit = 0;
	this->upperRadiusLimit = 0;
	this->angularSensibility = 1000.0;

	_initCache();

	this->getViewMatrix();

	hasLowerAlphaLimit = 0;
	hasUpperAlphaLimit = 0;
	hasLowerBetaLimit = 0;
	hasUpperBetaLimit = 0;
	hasLowerRadiusLimit = 0;
	hasUpperRadiusLimit = 0;
}

ArcRotateCamera::Ptr Babylon::ArcRotateCamera::New(string name, float alpha, float beta, float radius, Vector3::Ptr target, Scene::Ptr scene)
{
	auto arcRotateCamera = make_shared<ArcRotateCamera>(ArcRotateCamera(name, alpha, beta, radius, target, scene));
	scene->cameras.push_back(arcRotateCamera);

	if (!scene->activeCamera) {
		scene->activeCamera = arcRotateCamera;
	}

	return arcRotateCamera;
}

Vector3::Ptr Babylon::ArcRotateCamera::_getTargetPosition () {
	return this->target;
};

// Cache
void Babylon::ArcRotateCamera::_initCache () {
	this->_cache.target = make_shared<Vector3>(numeric_limits<float>::max(), numeric_limits<float>::max(), numeric_limits<float>::max());
	this->_cache.alpha = 0.;
	this->_cache.beta = 0.;
	this->_cache.radius = 0.;
};

void Babylon::ArcRotateCamera::_updateCache (bool ignoreParentClass) {
	if (!ignoreParentClass)
		Camera::_updateCache(ignoreParentClass);

	this->_cache.target->copyFrom(this->_getTargetPosition());
	this->_cache.alpha = this->alpha;
	this->_cache.beta = this->beta;
	this->_cache.radius = this->radius;
};

// Synchronized
bool Babylon::ArcRotateCamera::_isSynchronizedViewMatrix () {
	if (!Camera::_isSynchronizedViewMatrix())
		return false;

	return this->_cache.target == this->_getTargetPosition()
		&& this->_cache.alpha == this->alpha
		&& this->_cache.beta == this->beta
		&& this->_cache.radius == this->radius;
};

// Methods
void Babylon::ArcRotateCamera::attachControl (ICanvas::Ptr canvas, bool noPreventDefault) {
	////auto previousPosition;
	////auto pointerId;

	if (this->_attachedCanvas) {
		return;
	}
	this->_attachedCanvas = canvas;

	auto engine = this->_scene->getEngine();

// TODO: finish it
/*
	if (!this->_onPointerDown) {
		this->_onPointerDown (evt) {

			if (pointerId) {
				return;
			}

			pointerId = evt.pointerId;

			previousPosition = { x: evt.clientX, y: evt.clientY };

			if (!noPreventDefault) {
				evt.preventDefault();
			}
		};

		this->_onPointerUp (evt) {
			previousPosition = null;
			pointerId = null;
			if (!noPreventDefault) {
				evt.preventDefault();
			}
		};


		this->_onPointerMove (evt) {
			if (!previousPosition) {
				return;
			}

			if (pointerId !== evt.pointerId) {
				return;
			}

			auto offsetX = evt.clientX - previousPosition.x;
			auto offsetY = evt.clientY - previousPosition.y;

			that.inertialAlphaOffset -= offsetX / that.angularSensibility;
			that.inertialBetaOffset -= offsetY / that.angularSensibility;

			previousPosition = { x: evt.clientX, y: evt.clientY	};

			if (!noPreventDefault) {
				evt.preventDefault();
			}
		};
		*/

		this->_onMove = [&] (int x, int y) {
			auto offsetX = x;
			auto offsetY = y;

			this->inertialAlphaOffset -= offsetX / this->angularSensibility;
			this->inertialBetaOffset -= offsetY / this->angularSensibility;
		};

		/*
		this->_wheel (event) {
			auto delta = 0;
			if (event.wheelDelta) {
				delta = event.wheelDelta / 120;
			} else if (event.detail) {
				delta = -event.detail / 3;
			}

			if (delta)
				that.inertialRadiusOffset += delta;

			if (event.preventDefault) {
				if (!noPreventDefault) {
					event.preventDefault();
				}
			}
		};

		this->_onKeyDown (evt) {
			if (that.keysUp.indexOf(evt.keyCode) !== -1 ||
				that.keysDown.indexOf(evt.keyCode) !== -1 ||
				that.keysLeft.indexOf(evt.keyCode) !== -1 ||
				that.keysRight.indexOf(evt.keyCode) !== -1) {
					auto index = that._keys.indexOf(evt.keyCode);

					if (index == -1) {
						that._keys.push(evt.keyCode);
					}

					if (evt.preventDefault) {
						if (!noPreventDefault) {
							evt.preventDefault();
						}
					}
			}
		};

		this->_onKeyUp (evt) {
			if (that.keysUp.indexOf(evt.keyCode) !== -1 ||
				that.keysDown.indexOf(evt.keyCode) !== -1 ||
				that.keysLeft.indexOf(evt.keyCode) !== -1 ||
				that.keysRight.indexOf(evt.keyCode) !== -1) {
					auto index = that._keys.indexOf(evt.keyCode);

					if (index >= 0) {
						that._keys.splice(index, 1);
					}

					if (evt.preventDefault) {
						if (!noPreventDefault) {
							evt.preventDefault();
						}
					}
			}
		};

		this->_onLostFocus () {
			that._keys = [];
			pointerId = null;
		};

		this->_onGestureStart (e) {
			if (window.MSGesture == undefined) {
				return;
			}

			if (!that._MSGestureHandler) {
				that._MSGestureHandler = new MSGesture();
				that._MSGestureHandler.target = canvas;
			}

			that._MSGestureHandler.addPointer(e.pointerId);
		};

		this->_onGesture (e) {
			that.radius *= e.scale;


			if (e.preventDefault) {
				if (!noPreventDefault) {
					e.stopPropagation();
					e.preventDefault();
				}
			}
		};

		this->_reset () {
			that._keys = [];
			that.inertialAlphaOffset = 0;
			that.inertialBetaOffset = 0;
			previousPosition = null;
			pointerId = null;
		};
	}

	canvas.addEventListener(eventPrefix + "down", this->_onPointerDown, false);
	canvas.addEventListener(eventPrefix + "up", this->_onPointerUp, false);
	canvas.addEventListener(eventPrefix + "out", this->_onPointerUp, false);
	canvas.addEventListener(eventPrefix + "move", this->_onPointerMove, false);
	canvas.addEventListener("mousemove", this->_onMouseMove, false);
	canvas.addEventListener("MSPointerDown", this->_onGestureStart, false);
	canvas.addEventListener("MSGestureChange", this->_onGesture, false);
	window.addEventListener("keydown", this->_onKeyDown, false);
	window.addEventListener("keyup", this->_onKeyUp, false);
	window.addEventListener('mousewheel', this->_wheel, false);
	window.addEventListener("blur", this->_onLostFocus, false);
	*/

	canvas->addEventListener_OnMoveEvent(this->_onMove);
};

void Babylon::ArcRotateCamera::detachControl (ICanvas::Ptr canvas) {
	if (this->_attachedCanvas != canvas) {
		return;
	}

	// TODO: finish it
	/*
	canvas.removeEventListener(eventPrefix + "down", this->_onPointerDown);
	canvas.removeEventListener(eventPrefix + "up", this->_onPointerUp);
	canvas.removeEventListener(eventPrefix + "out", this->_onPointerUp);
	canvas.removeEventListener(eventPrefix + "move", this->_onPointerMove);
	canvas.removeEventListener("mousemove", this->_onMouseMove);
	canvas.removeEventListener("MSPointerDown", this->_onGestureStart);
	canvas.removeEventListener("MSGestureChange", this->_onGesture);
	window.removeEventListener("keydown", this->_onKeyDown);
	window.removeEventListener("keyup", this->_onKeyUp);
	window.removeEventListener('mousewheel', this->_wheel);
	window.removeEventListener("blur", this->_onLostFocus);

	this->_MSGestureHandler = null;
	this->_attachedCanvas = null;

	if (this->_reset) {
		this->_reset();
	}
	*/
};

void Babylon::ArcRotateCamera::_update () {
	// Keyboard
	// TODO: finish it
	/*
	for (auto index = 0; index < this->_keys.length; index++) {
		auto keyCode = this->_keys[index];

		if (this->keysLeft.indexOf(keyCode) !== -1) {
			this->inertialAlphaOffset -= 0.01;
		} else if (this->keysUp.indexOf(keyCode) !== -1) {
			this->inertialBetaOffset -= 0.01;
		} else if (this->keysRight.indexOf(keyCode) !== -1) {
			this->inertialAlphaOffset += 0.01;
		} else if (this->keysDown.indexOf(keyCode) !== -1) {
			this->inertialBetaOffset += 0.01;
		}
	}
	*/

	// Inertia
	if (this->inertialAlphaOffset != 0 || this->inertialBetaOffset != 0 || this->inertialRadiusOffset != 0) {

		this->alpha += this->inertialAlphaOffset;
		this->beta += this->inertialBetaOffset;
		this->radius -= this->inertialRadiusOffset;

		this->inertialAlphaOffset *= this->inertia;
		this->inertialBetaOffset *= this->inertia;
		this->inertialRadiusOffset *= this->inertia;

		if (abs(this->inertialAlphaOffset) < Engine::epsilon)
			this->inertialAlphaOffset = 0;

		if (abs(this->inertialBetaOffset) < Engine::epsilon)
			this->inertialBetaOffset = 0;

		if (abs(this->inertialRadiusOffset) < Engine::epsilon)
			this->inertialRadiusOffset = 0;
	}

	// Limits
	if (this->hasLowerAlphaLimit && this->alpha < this->lowerAlphaLimit) {
		this->alpha = this->lowerAlphaLimit;
	}
	if (this->hasUpperAlphaLimit && this->alpha > this->upperAlphaLimit) {
		this->alpha = this->upperAlphaLimit;
	}
	if (this->hasLowerBetaLimit && this->beta < this->lowerBetaLimit) {
		this->beta = this->lowerBetaLimit;
	}
	if (this->hasUpperBetaLimit && this->beta > this->upperBetaLimit) {
		this->beta = this->upperBetaLimit;
	}
	if (this->hasLowerRadiusLimit && this->radius < this->lowerRadiusLimit) {
		this->radius = this->lowerRadiusLimit;
	}
	if (this->hasUpperRadiusLimit && this->radius > this->upperRadiusLimit) {
		this->radius = this->upperRadiusLimit;
	}
};

void Babylon::ArcRotateCamera::setPosition (Vector3::Ptr position) {
	auto radiusv3 = position->subtract(this->_getTargetPosition());
	this->radius = radiusv3->length();

	this->alpha = atan(radiusv3->z / radiusv3->x);
	this->beta = acos(radiusv3->y / this->radius);
};

Matrix::Ptr Babylon::ArcRotateCamera::_getViewMatrix () {
	// Compute
	auto cosa = cos(this->alpha);
	auto sina = sin(this->alpha);
	auto cosb = cos(this->beta);
	auto sinb = sin(this->beta);

	auto target = this->_getTargetPosition();

	target->addToRef(make_shared<Vector3>(this->radius * cosa * sinb, this->radius * cosb, this->radius * sina * sinb), this->position);
	Matrix::LookAtLHToRef(this->position, target, this->upVector, this->_viewMatrix);

	return this->_viewMatrix;
};
