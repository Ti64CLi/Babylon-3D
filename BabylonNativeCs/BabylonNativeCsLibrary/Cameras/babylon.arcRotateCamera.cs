using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class ArcRotateCamera: Camera {
        public double inertialAlphaOffset = 0;
        public double inertialBetaOffset = 0;
        public double inertialRadiusOffset = 0;
        public any lowerAlphaLimit = null;
        public any upperAlphaLimit = null;
        public double lowerBetaLimit = 0.01;
        public any upperBetaLimit = Math.PI;
        public any lowerRadiusLimit = null;
        public any upperRadiusLimit = null;
        public double angularSensibility = 1000.0;
        public double wheelPrecision = 3.0;
        public Array < object > keysUp = new Array < object > (38);
        public Array < object > keysDown = new Array < object > (40);
        public Array < object > keysLeft = new Array < object > (37);
        public Array < object > keysRight = new Array < object > (39);
        public double zoomOnFactor = 1;
        private Array < object > _keys = new Array < object > ();
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
        public double alpha;
        public double beta;
        public double radius;
        public object target;
        public ArcRotateCamera(string name, double alpha, double beta, double radius, object target, Scene scene): base(name, BABYLON.Vector3.Zero(), scene) {
            this.getViewMatrix();
        }
        void eventPrefixTools.GetPointerPrefix();
        public virtual Vector3 _getTargetPosition() {
            return this.target.position || this.target;
        }
        public virtual void _initCache() {
            base._initCache();
            this._cache.target = new BABYLON.Vector3(Number.MAX_VALUE, Number.MAX_VALUE, Number.MAX_VALUE);
            this._cache.alpha = null;
            this._cache.beta = null;
            this._cache.radius = null;
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
            if (this._onPointerDown == null) {
                this._onPointerDown = (evt) => {
                    if (pointerId) {
                        return;
                    }
                    pointerId = evt.pointerId;
                    previousPosition = new {};
                    if (!noPreventDefault) {
                        evt.preventDefault();
                    }
                };
                this._onPointerUp = (evt) => {
                    previousPosition = null;
                    pointerId = null;
                    if (!noPreventDefault) {
                        evt.preventDefault();
                    }
                };
                this._onPointerMove = (evt) => {
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
                this._onMouseMove = (evt) => {
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
                this._wheel = (_event) => {
                    var delta = 0;
                    if (_event.wheelDelta) {
                        delta = _event.wheelDelta / (this.wheelPrecision * 40);
                    } else
                    if (_event.detail) {
                        delta = -_event.detail / this.wheelPrecision;
                    }
                    if (delta)
                        this.inertialRadiusOffset += delta;
                    if (_event.preventDefault) {
                        if (!noPreventDefault) {
                            _event.preventDefault();
                        }
                    }
                };
                this._onKeyDown = (evt) => {
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
                this._onKeyUp = (evt) => {
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
                this._onGestureStart = (e) => {
                    if (window.MSGesture == null) {
                        return;
                    }
                    if (!this._MSGestureHandler) {
                        this._MSGestureHandler = new MSGesture();
                        this._MSGestureHandler.target = element;
                    }
                    this._MSGestureHandler.addPointer(e.pointerId);
                };
                this._onGesture = (e) => {
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
            element.addEventListener(eventPrefix + "down", this._onPointerDown, false);
            element.addEventListener(eventPrefix + "up", this._onPointerUp, false);
            element.addEventListener(eventPrefix + "out", this._onPointerUp, false);
            element.addEventListener(eventPrefix + "move", this._onPointerMove, false);
            element.addEventListener("mousemove", this._onMouseMove, false);
            element.addEventListener("MSPointerDown", this._onGestureStart, false);
            element.addEventListener("MSGestureChange", this._onGesture, false);
            element.addEventListener("mousewheel", this._wheel, false);
            element.addEventListener("DOMMouseScroll", this._wheel, false);
            Tools.RegisterTopRootEvents(new Array < object > (new {}, new {}, new {}));
        }
        public virtual void detachControl(HTMLElement element) {
            if (this._attachedElement != element) {
                return;
            }
            element.removeEventListener(eventPrefix + "down", this._onPointerDown);
            element.removeEventListener(eventPrefix + "up", this._onPointerUp);
            element.removeEventListener(eventPrefix + "out", this._onPointerUp);
            element.removeEventListener(eventPrefix + "move", this._onPointerMove);
            element.removeEventListener("mousemove", this._onMouseMove);
            element.removeEventListener("MSPointerDown", this._onGestureStart);
            element.removeEventListener("MSGestureChange", this._onGesture);
            element.removeEventListener("mousewheel", this._wheel);
            element.removeEventListener("DOMMouseScroll", this._wheel);
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
            this.alpha = Math.acos(radiusv3.x / Math.Sqrt(Math.pow(radiusv3.x, 2) + Math.pow(radiusv3.z, 2)));
            if (radiusv3.z < 0) {
                this.alpha = 2 * Math.PI - this.alpha;
            }
            this.beta = Math.acos(radiusv3.y / this.radius);
        }
        public virtual Matrix _getViewMatrix() {
            var cosa = Math.Cos(this.alpha);
            var sina = Math.Sin(this.alpha);
            var cosb = Math.Cos(this.beta);
            var sinb = Math.Sin(this.beta);
            var target = this._getTargetPosition();
            target.addToRef(new BABYLON.Vector3(this.radius * cosa * sinb, this.radius * cosb, this.radius * sina * sinb), this.position);
            Matrix.LookAtLHToRef(this.position, target, this.upVector, this._viewMatrix);
            return this._viewMatrix;
        }
        public virtual void zoomOn(Array < AbstractMesh > meshes = null) {
            meshes = meshes || this.getScene().meshes;
            var minMaxVector = BABYLON.Mesh.MinMax(meshes);
            var distance = BABYLON.Vector3.Distance(minMaxVector.min, minMaxVector.Max);
            this.radius = distance * this.zoomOnFactor;
            this.focusOn(new {});
        }
        public virtual void focusOn(object meshesOrMinMaxVectorAndDistance) {
            var meshesOrMinMaxVector;
            var distance;
            if (meshesOrMinMaxVectorAndDistance.min == null) {
                meshesOrMinMaxVector = meshesOrMinMaxVectorAndDistance || this.getScene().meshes;
                meshesOrMinMaxVector = BABYLON.Mesh.MinMax(meshesOrMinMaxVector);
                distance = BABYLON.Vector3.Distance(meshesOrMinMaxVector.min, meshesOrMinMaxVector.Max);
            } else {
                meshesOrMinMaxVector = meshesOrMinMaxVectorAndDistance;
                distance = meshesOrMinMaxVectorAndDistance.distance;
            }
            this.target = Mesh.Center(meshesOrMinMaxVector);
            this.maxZ = distance * 2;
        }
    }
}