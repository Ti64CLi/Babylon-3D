using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
    public class ArcRotateCamera: Camera {
        public float inertialAlphaOffset = 0;
        public float inertialBetaOffset = 0;
        public float inertialRadiusOffset = 0;
        public null lowerAlphaLimit = null;
        public null upperAlphaLimit = null;
        public float lowerBetaLimit = 0.01;
        public null upperBetaLimit = Math.PI;
        public null lowerRadiusLimit = null;
        public null upperRadiusLimit = null;
        public float angularSensibility = 1000.0;
        public float wheelPrecision = 3.0;
        public null keysUp = new Array < object > (38);
        public null keysDown = new Array < object > (40);
        public null keysLeft = new Array < object > (37);
        public null keysRight = new Array < object > (39);
        public float zoomOnFactor = 1;
        private null _keys = new Array < object > ();
        private BABYLON.Matrix _viewMatrix = new BABYLON.Matrix();
        private HTMLElement _attachedElement;
        private System.Action < PointerEvent > _onPointerDown;
        private System.Action < PointerEvent > _onPointerUp;
        private System.Action < PointerEvent > _onPointerMove;
        private System.Action < MouseWheelEvent > _wheel;
        private System.Func < MouseEvent, object > _onMouseMove;
        private System.Func < KeyboardEvent, object > _onKeyDown;
        private System.Func < KeyboardEvent, object > _onKeyUp;
        private System.Func < FocusEvent, object > _onLostFocus;
        private System.Action _reset;
        private System.Action < PointerEvent > _onGestureStart;
        private System.Action < MSGestureEvent > _onGesture;
        private MSGesture _MSGestureHandler;
        public float alpha;
        public float beta;
        public float radius;
        public object target;
        public ArcRotateCamera(string name, float alpha, float beta, float radius, object target, Scene scene): base(name, BABYLON.Vector3.Zero(), scene) {
            this.getViewMatrix();
        }
        void eventPrefixTools.GetPointerPrefix();
        public virtual Vector3 _getTargetPosition() {
            return this.target.position || this.target;
        }
        public virtual void _initCache() {
            base._initCache();
            this._cache.target = new BABYLON.Vector3(Number.MAX_VALUE, Number.MAX_VALUE, Number.MAX_VALUE);
            this._cache.alpha = undefined;
            this._cache.beta = undefined;
            this._cache.radius = undefined;
        }
        public virtual void _updateCache(bool ignoreParentClass = false) {
            if (!ignoreParentClass) {
                base._updateCache();
            }
            this._cache.target.copyFrom(this._getTargetPosition());
            this._cache.alpha = this.alpha;
            this._cache.beta = this.beta;
            this._cache.radius = this.radius;
        }
        public virtual bool _isSynchronizedViewMatrix() {
            if (!base._isSynchronizedViewMatrix())
                return false;
            return this._cache.target.equals(this._getTargetPosition()) && this._cache.alpha == this.alpha && this._cache.beta == this.beta && this._cache.radius == this.radius;
        }
        public virtual void attachControl(HTMLElement element, bool noPreventDefault = false) {
            var previousPosition;
            var pointerId;
            if (this._attachedElement) {
                return;
            }
            this._attachedElement = element;
            var engine = this.getEngine();
            if (this._onPointerDown == undefined) {
                this._onPointerDown = (object evt) => {
                    if (pointerId) {
                        return;
                    }
                    pointerId = evt.pointerId;
                    previousPosition = new {};
                    if (!noPreventDefault) {
                        evt.preventDefault();
                    }
                };
                this._onPointerUp = (object evt) => {
                    previousPosition = null;
                    pointerId = null;
                    if (!noPreventDefault) {
                        evt.preventDefault();
                    }
                };
                this._onPointerMove = (object evt) => {
                    if (!previousPosition) {
                        return;
                    }
                    if (pointerId != evt.pointerId) {
                        return;
                    }
                    var offsetX = evt.clientX - previousPosition.x;
                    var offsetY = evt.clientY - previousPosition.y;
                    this.inertialAlphaOffset -= offsetX / this.angularSensibility;
                    this.inertialBetaOffset -= offsetY / this.angularSensibility;
                    previousPosition = new {};
                    if (!noPreventDefault) {
                        evt.preventDefault();
                    }
                };
                this._onMouseMove = (object evt) => {
                    if (!engine.isPointerLock) {
                        return;
                    }
                    var offsetX = evt.movementX || evt.mozMovementX || evt.webkitMovementX || evt.msMovementX || 0;
                    var offsetY = evt.movementY || evt.mozMovementY || evt.webkitMovementY || evt.msMovementY || 0;
                    this.inertialAlphaOffset -= offsetX / this.angularSensibility;
                    this.inertialBetaOffset -= offsetY / this.angularSensibility;
                    if (!noPreventDefault) {
                        evt.preventDefault();
                    }
                };
                this._wheel = (object event) => {
                    var delta = 0;
                    if (event.wheelDelta) {
                        delta = event.wheelDelta / (this.wheelPrecision * 40);
                    } else
                    if (event.detail) {
                        delta = -event.detail / this.wheelPrecision;
                    }
                    if (delta)
                        this.inertialRadiusOffset += delta;
                    if (event.preventDefault) {
                        if (!noPreventDefault) {
                            event.preventDefault();
                        }
                    }
                };
                this._onKeyDown = (object evt) => {
                    if (this.keysUp.indexOf(evt.keyCode) != -1 || this.keysDown.indexOf(evt.keyCode) != -1 || this.keysLeft.indexOf(evt.keyCode) != -1 || this.keysRight.indexOf(evt.keyCode) != -1) {
                        var index = this._keys.indexOf(evt.keyCode);
                        if (index == -1) {
                            this._keys.push(evt.keyCode);
                        }
                        if (evt.preventDefault) {
                            if (!noPreventDefault) {
                                evt.preventDefault();
                            }
                        }
                    }
                };
                this._onKeyUp = (object evt) => {
                    if (this.keysUp.indexOf(evt.keyCode) != -1 || this.keysDown.indexOf(evt.keyCode) != -1 || this.keysLeft.indexOf(evt.keyCode) != -1 || this.keysRight.indexOf(evt.keyCode) != -1) {
                        var index = this._keys.indexOf(evt.keyCode);
                        if (index >= 0) {
                            this._keys.splice(index, 1);
                        }
                        if (evt.preventDefault) {
                            if (!noPreventDefault) {
                                evt.preventDefault();
                            }
                        }
                    }
                };
                this._onLostFocus = () => {
                    this._keys = new Array < object > ();
                    pointerId = null;
                };
                this._onGestureStart = (object e) => {
                    if (window.MSGesture == undefined) {
                        return;
                    }
                    if (!this._MSGestureHandler) {
                        this._MSGestureHandler = new MSGesture();
                        this._MSGestureHandler.target = element;
                    }
                    this._MSGestureHandler.addPointer(e.pointerId);
                };
                this._onGesture = (object e) => {
                    this.radius *= e.scale;
                    if (e.preventDefault) {
                        if (!noPreventDefault) {
                            e.stopPropagation();
                            e.preventDefault();
                        }
                    }
                };
                this._reset = () => {
                    this._keys = new Array < object > ();
                    this.inertialAlphaOffset = 0;
                    this.inertialBetaOffset = 0;
                    this.inertialRadiusOffset = 0;
                    previousPosition = null;
                    pointerId = null;
                };
            }
            element.addEventListener(eventPrefix + "dow", this._onPointerDown, false);
            element.addEventListener(eventPrefix + "u", this._onPointerUp, false);
            element.addEventListener(eventPrefix + "ou", this._onPointerUp, false);
            element.addEventListener(eventPrefix + "mov", this._onPointerMove, false);
            element.addEventListener("mousemov", this._onMouseMove, false);
            element.addEventListener("MSPointerDow", this._onGestureStart, false);
            element.addEventListener("MSGestureChang", this._onGesture, false);
            element.addEventListener("mousewhee", this._wheel, false);
            element.addEventListener("DOMMouseScrol", this._wheel, false);
            Tools.RegisterTopRootEvents(new Array < object > (new {}, new {}, new {}));
        }
        public virtual void detachControl(HTMLElement element) {
            if (this._attachedElement != element) {
                return;
            }
            element.removeEventListener(eventPrefix + "dow", this._onPointerDown);
            element.removeEventListener(eventPrefix + "u", this._onPointerUp);
            element.removeEventListener(eventPrefix + "ou", this._onPointerUp);
            element.removeEventListener(eventPrefix + "mov", this._onPointerMove);
            element.removeEventListener("mousemov", this._onMouseMove);
            element.removeEventListener("MSPointerDow", this._onGestureStart);
            element.removeEventListener("MSGestureChang", this._onGesture);
            element.removeEventListener("mousewhee", this._wheel);
            element.removeEventListener("DOMMouseScrol", this._wheel);
            Tools.UnregisterTopRootEvents(new Array < object > (new {}, new {}, new {}));
            this._MSGestureHandler = null;
            this._attachedElement = null;
            if (this._reset) {
                this._reset();
            }
        }
        public virtual void _update() {
            for (var index = 0; index < this._keys.Length; index++) {
                var keyCode = this._keys[index];
                if (this.keysLeft.indexOf(keyCode) != -1) {
                    this.inertialAlphaOffset -= 0.01;
                } else
                if (this.keysUp.indexOf(keyCode) != -1) {
                    this.inertialBetaOffset -= 0.01;
                } else
                if (this.keysRight.indexOf(keyCode) != -1) {
                    this.inertialAlphaOffset += 0.01;
                } else
                if (this.keysDown.indexOf(keyCode) != -1) {
                    this.inertialBetaOffset += 0.01;
                }
            }
            if (this.inertialAlphaOffset != 0 || this.inertialBetaOffset != 0 || this.inertialRadiusOffset != 0) {
                this.alpha += this.inertialAlphaOffset;
                this.beta += this.inertialBetaOffset;
                this.radius -= this.inertialRadiusOffset;
                this.inertialAlphaOffset *= this.inertia;
                this.inertialBetaOffset *= this.inertia;
                this.inertialRadiusOffset *= this.inertia;
                if (Math.abs(this.inertialAlphaOffset) < BABYLON.Engine.Epsilon)
                    this.inertialAlphaOffset = 0;
                if (Math.abs(this.inertialBetaOffset) < BABYLON.Engine.Epsilon)
                    this.inertialBetaOffset = 0;
                if (Math.abs(this.inertialRadiusOffset) < BABYLON.Engine.Epsilon)
                    this.inertialRadiusOffset = 0;
            }
            if (this.lowerAlphaLimit && this.alpha < this.lowerAlphaLimit) {
                this.alpha = this.lowerAlphaLimit;
            }
            if (this.upperAlphaLimit && this.alpha > this.upperAlphaLimit) {
                this.alpha = this.upperAlphaLimit;
            }
            if (this.lowerBetaLimit && this.beta < this.lowerBetaLimit) {
                this.beta = this.lowerBetaLimit;
            }
            if (this.upperBetaLimit && this.beta > this.upperBetaLimit) {
                this.beta = this.upperBetaLimit;
            }
            if (this.lowerRadiusLimit && this.radius < this.lowerRadiusLimit) {
                this.radius = this.lowerRadiusLimit;
            }
            if (this.upperRadiusLimit && this.radius > this.upperRadiusLimit) {
                this.radius = this.upperRadiusLimit;
            }
        }
        public virtual void setPosition(Vector3 position) {
            var radiusv3 = position.subtract(this._getTargetPosition());
            this.radius = radiusv3.Length();
            this.alpha = Math.acos(radiusv3.x / Math.sqrt(Math.pow(radiusv3.x, 2) + Math.pow(radiusv3.z, 2)));
            if (radiusv3.z < 0) {
                this.alpha = 2 * Math.PI - this.alpha;
            }
            this.beta = Math.acos(radiusv3.y / this.radius);
        }
        public virtual Matrix _getViewMatrix() {
            var cosa = Math.cos(this.alpha);
            var sina = Math.sin(this.alpha);
            var cosb = Math.cos(this.beta);
            var sinb = Math.sin(this.beta);
            var target = this._getTargetPosition();
            target.addToRef(new BABYLON.Vector3(this.radius * cosa * sinb, this.radius * cosb, this.radius * sina * sinb), this.position);
            Matrix.LookAtLHToRef(this.position, target, this.upVector, this._viewMatrix);
            return this._viewMatrix;
        }
        public virtual void zoomOn(Array < AbstractMesh > meshes = null) {
            meshes = meshes || this.getScene().meshes;
            var minMaxVector = BABYLON.Mesh.MinMax(meshes);
            var distance = BABYLON.Vector3.Distance(minMaxVector.min, minMaxVector.max);
            this.radius = distance * this.zoomOnFactor;
            this.focusOn(new {});
        }
        public virtual void focusOn(object meshesOrMinMaxVectorAndDistance) {
            var meshesOrMinMaxVector;
            var distance;
            if (meshesOrMinMaxVectorAndDistance.min == undefined) {
                meshesOrMinMaxVector = meshesOrMinMaxVectorAndDistance || this.getScene().meshes;
                meshesOrMinMaxVector = BABYLON.Mesh.MinMax(meshesOrMinMaxVector);
                distance = BABYLON.Vector3.Distance(meshesOrMinMaxVector.min, meshesOrMinMaxVector.max);
            } else {
                meshesOrMinMaxVector = meshesOrMinMaxVectorAndDistance;
                distance = meshesOrMinMaxVectorAndDistance.distance;
            }
            this.target = Mesh.Center(meshesOrMinMaxVector);
            this.maxZ = distance * 2;
        }
    }
}