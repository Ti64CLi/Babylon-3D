using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class FreeCamera : Camera
    {
        public BABYLON.Vector3 cameraDirection = new BABYLON.Vector3(0, 0, 0);
        public BABYLON.Vector2 cameraRotation = new BABYLON.Vector2(0, 0);
        public BABYLON.Vector3 rotation = new BABYLON.Vector3(0, 0, 0);
        public BABYLON.Vector3 ellipsoid = new BABYLON.Vector3(0.5, 1, 0.5);
        public Array<int> keysUp = new Array<int>(38);
        public Array<int> keysDown = new Array<int>(40);
        public Array<int> keysLeft = new Array<int>(37);
        public Array<int> keysRight = new Array<int>(39);
        public double speed = 2.0;
        public bool checkCollisions = false;
        public bool applyGravity = false;
        public bool noRotationConstraint = false;
        public double angularSensibility = 2000.0;
        public object lockedTarget = null;
        public System.Action<AbstractMesh> onCollide = null;
        private Array<int> _keys = new Array<int>();
        private Collider _collider = new Collider();
        private bool _needMoveForGravity = true;
        public BABYLON.Vector3 _currentTarget = BABYLON.Vector3.Zero();
        public BABYLON.Matrix _viewMatrix = BABYLON.Matrix.Zero();
        private BABYLON.Matrix _camMatrix = BABYLON.Matrix.Zero();
        private BABYLON.Matrix _cameraTransformMatrix = BABYLON.Matrix.Zero();
        public BABYLON.Matrix _cameraRotationMatrix = BABYLON.Matrix.Zero();
        public BABYLON.Vector3 _referencePoint = new BABYLON.Vector3(0, 0, 1);
        public BABYLON.Vector3 _transformedReferencePoint = BABYLON.Vector3.Zero();
        private BABYLON.Vector3 _oldPosition = BABYLON.Vector3.Zero();
        private BABYLON.Vector3 _diffPosition = BABYLON.Vector3.Zero();
        private BABYLON.Vector3 _newPosition = BABYLON.Vector3.Zero();
        private BABYLON.Matrix _lookAtTemp = BABYLON.Matrix.Zero();
        private BABYLON.Matrix _tempMatrix = BABYLON.Matrix.Zero();
        private HTMLElement _attachedElement;
        private Vector3 _localDirection;
        private Vector3 _transformedDirection;
        private EventListener _onMouseDown;
        private EventListener _onMouseUp;
        private EventListener _onMouseOut;
        private EventListener _onMouseMove;
        private EventListener _onKeyDown;
        private EventListener _onKeyUp;
        public EventListener _onLostFocus;
        private System.Action _reset;
        public string _waitingLockedTargetId;
        public FreeCamera(string name, Vector3 position, Scene scene) : base(name, position, scene) { }
        public virtual Vector3 _getLockedTargetPosition()
        {
            if (this.lockedTarget is Mesh)
            {
                return ((Mesh)this.lockedTarget).position;
            }

            return (Vector3)this.lockedTarget;
        }
        public virtual void _initCache()
        {
            base._initCache();
            this._cache.target = new BABYLON.Vector3(double.MaxValue, double.MaxValue, double.MaxValue);
            this._cache.rotation = new BABYLON.Vector3(double.MaxValue, double.MaxValue, double.MaxValue);
        }
        public virtual void _updateCache(bool ignoreParentClass = false)
        {
            if (!ignoreParentClass)
            {
                base._updateCache();
            }
            var lockedTargetPosition = this._getLockedTargetPosition();
            if (lockedTargetPosition == null)
            {
                this._cache.target = null;
            }
            else
            {
                if (this._cache.target == null)
                {
                    this._cache.target = lockedTargetPosition.clone();
                }
                else
                {
                    this._cache.target.copyFrom(lockedTargetPosition);
                }
            }
            this._cache.rotation.copyFrom(this.rotation);
        }
        public virtual bool _isSynchronizedViewMatrix()
        {
            if (!base._isSynchronizedViewMatrix())
            {
                return false;
            }
            var lockedTargetPosition = this._getLockedTargetPosition();
            return ((this._cache.target != null) ? this._cache.target.equals(lockedTargetPosition) : lockedTargetPosition == null) && this._cache.rotation.equals(this.rotation);
        }
        public virtual double _computeLocalCameraSpeed()
        {
            return this.speed * ((BABYLON.Tools.GetDeltaTime() / (BABYLON.Tools.GetFps() * 10.0)));
        }
        public virtual void setTarget(Vector3 target)
        {
            this.upVector.normalize();
            BABYLON.Matrix.LookAtLHToRef(this.position, target, this.upVector, this._camMatrix);
            this._camMatrix.invert();
            this.rotation.x = Math.Atan(this._camMatrix.m[6] / this._camMatrix.m[10]);
            var vDir = target.subtract(this.position);
            if (vDir.x >= 0.0)
            {
                this.rotation.y = (-Math.Atan(vDir.z / vDir.x) + Math.PI / 2.0);
            }
            else
            {
                this.rotation.y = (-Math.Atan(vDir.z / vDir.x) - Math.PI / 2.0);
            }
            this.rotation.z = -Math.Acos(BABYLON.Vector3.Dot(new BABYLON.Vector3(0, 1.0, 0), this.upVector));
            if (double.IsNaN(this.rotation.x))
            {
                this.rotation.x = 0;
            }
            if (double.IsNaN(this.rotation.y))
            {
                this.rotation.y = 0;
            }
            if (double.IsNaN(this.rotation.z))
            {
                this.rotation.z = 0;
            }
        }
        public virtual Vector3 getTarget()
        {
            return this._currentTarget;
        }
        public virtual void attachControl(HTMLElement element, bool noPreventDefault = false)
        {
            PositionCoord previousPosition = null;
            var engine = this.getEngine();
            if (this._attachedElement != null)
            {
                return;
            }
            this._attachedElement = element;
            if (this._onMouseDown == null)
            {
                this._onMouseDown = (e) =>
                {
                    var evt = (MouseEvent)e;

                    previousPosition = new PositionCoord
                    {
                        x = evt.clientX,
                        y = evt.clientY
                    };
                    if (!noPreventDefault)
                    {
                        evt.preventDefault();
                    }
                };
                this._onMouseUp = (evt) =>
                {
                    previousPosition = null;
                    if (!noPreventDefault)
                    {
                        evt.preventDefault();
                    }
                };
                this._onMouseOut = (evt) =>
                {
                    previousPosition = null;
                    this._keys = new Array<int>();
                    if (!noPreventDefault)
                    {
                        evt.preventDefault();
                    }
                };
                this._onMouseMove = (e) =>
                {
                    var evt = (MouseEvent)e;

                    if (previousPosition == null && !engine.isPointerLock)
                    {
                        return;
                    }
                    int offsetX;
                    int offsetY;
                    if (!engine.isPointerLock)
                    {
                        offsetX = evt.clientX - previousPosition.x;
                        offsetY = evt.clientY - previousPosition.y;
                    }
                    else
                    {
                        offsetX = evt.offsetX;
                        offsetY = evt.offsetY;
                    }
                    this.cameraRotation.y += offsetX / this.angularSensibility;
                    this.cameraRotation.x += offsetY / this.angularSensibility;
                    previousPosition = new PositionCoord
                    {
                        x = evt.clientX,
                        y = evt.clientY
                    };
                    if (!noPreventDefault)
                    {
                        evt.preventDefault();
                    }
                };
                this._onKeyDown = (e) =>
                {
                    var evt = (KeyboardEvent)e;

                    if (this.keysUp.indexOf(evt.keyCode) != -1 || this.keysDown.indexOf(evt.keyCode) != -1 || this.keysLeft.indexOf(evt.keyCode) != -1 || this.keysRight.indexOf(evt.keyCode) != -1)
                    {
                        var index = this._keys.indexOf(evt.keyCode);
                        if (index == -1)
                        {
                            this._keys.push(evt.keyCode);
                        }
                        if (!noPreventDefault)
                        {
                            evt.preventDefault();
                        }
                    }
                };
                this._onKeyUp = (e) =>
                {
                    var evt = (KeyboardEvent)e;

                    if (this.keysUp.indexOf(evt.keyCode) != -1 || this.keysDown.indexOf(evt.keyCode) != -1 || this.keysLeft.indexOf(evt.keyCode) != -1 || this.keysRight.indexOf(evt.keyCode) != -1)
                    {
                        var index = this._keys.indexOf(evt.keyCode);
                        if (index >= 0)
                        {
                            this._keys.splice(index, 1);
                        }
                        if (!noPreventDefault)
                        {
                            evt.preventDefault();
                        }
                    }
                };
                this._onLostFocus = (e) =>
                {
                    this._keys = new Array<int>();
                };
                this._reset = () =>
                {
                    this._keys = new Array<int>();
                    previousPosition = null;
                    this.cameraDirection = new BABYLON.Vector3(0, 0, 0);
                    this.cameraRotation = new BABYLON.Vector2(0, 0);
                };
            }
            element.addEventListener("mousedown", this._onMouseDown, false);
            element.addEventListener("mouseup", this._onMouseUp, false);
            element.addEventListener("mouseout", this._onMouseOut, false);
            element.addEventListener("mousemove", this._onMouseMove, false);
            Tools.RegisterTopRootEvents(new Array<EventDts>(
                new EventDts { name = "keydown", handler = this._onKeyDown },
                new EventDts { name = "keyup", handler = this._onKeyUp },
                new EventDts { name = "blur", handler = this._onLostFocus }));
        }
        public virtual void detachControl(HTMLElement element)
        {
            if (this._attachedElement != element)
            {
                return;
            }
            element.removeEventListener("mousedown", this._onMouseDown);
            element.removeEventListener("mouseup", this._onMouseUp);
            element.removeEventListener("mouseout", this._onMouseOut);
            element.removeEventListener("mousemove", this._onMouseMove);
            Tools.UnregisterTopRootEvents(new Array<EventDts>(
                new EventDts { name = "keydown", handler = this._onKeyDown },
                new EventDts { name = "keyup", handler = this._onKeyUp },
                new EventDts { name = "blur", handler = this._onLostFocus }));
            this._attachedElement = null;
            if (this._reset != null)
            {
                this._reset();
            }
        }
        public virtual void _collideWithWorld(Vector3 velocity)
        {
            Vector3 globalPosition = null;
            if (this.parent != null)
            {
                globalPosition = BABYLON.Vector3.TransformCoordinates(this.position, this.parent.getWorldMatrix());
            }
            else
            {
                globalPosition = this.position;
            }
            globalPosition.subtractFromFloatsToRef(0, this.ellipsoid.y, 0, this._oldPosition);
            this._collider.radius = this.ellipsoid;
            this.getScene()._getNewPosition(this._oldPosition, velocity, this._collider, 3, this._newPosition);
            this._newPosition.subtractToRef(this._oldPosition, this._diffPosition);
            if (this._diffPosition.Length() > Engine.CollisionsEpsilon)
            {
                this.position.addInPlace(this._diffPosition);
                if (this.onCollide != null)
                {
                    this.onCollide(this._collider.collidedMesh);
                }
            }
        }
        public virtual void _checkInputs()
        {
            if (this._localDirection == null)
            {
                this._localDirection = BABYLON.Vector3.Zero();
                this._transformedDirection = BABYLON.Vector3.Zero();
            }
            for (var index = 0; index < this._keys.Length; index++)
            {
                var keyCode = this._keys[index];
                var speed = this._computeLocalCameraSpeed();
                if (this.keysLeft.indexOf(keyCode) != -1)
                {
                    this._localDirection.copyFromFloats(-speed, 0, 0);
                }
                else
                    if (this.keysUp.indexOf(keyCode) != -1)
                    {
                        this._localDirection.copyFromFloats(0, 0, speed);
                    }
                    else
                        if (this.keysRight.indexOf(keyCode) != -1)
                        {
                            this._localDirection.copyFromFloats(speed, 0, 0);
                        }
                        else
                            if (this.keysDown.indexOf(keyCode) != -1)
                            {
                                this._localDirection.copyFromFloats(0, 0, -speed);
                            }
                this.getViewMatrix().invertToRef(this._cameraTransformMatrix);
                BABYLON.Vector3.TransformNormalToRef(this._localDirection, this._cameraTransformMatrix, this._transformedDirection);
                this.cameraDirection.addInPlace(this._transformedDirection);
            }
        }
        public virtual void _update()
        {
            this._checkInputs();
            var needToMove = this._needMoveForGravity || Math.Abs(this.cameraDirection.x) > 0 || Math.Abs(this.cameraDirection.y) > 0 || Math.Abs(this.cameraDirection.z) > 0;
            var needToRotate = Math.Abs(this.cameraRotation.x) > 0 || Math.Abs(this.cameraRotation.y) > 0;
            if (needToMove)
            {
                if (this.checkCollisions && this.getScene().collisionsEnabled)
                {
                    this._collideWithWorld(this.cameraDirection);
                    if (this.applyGravity)
                    {
                        var oldPosition = this.position;
                        this._collideWithWorld(this.getScene().gravity);
                        this._needMoveForGravity = (BABYLON.Vector3.DistanceSquared(oldPosition, this.position) != 0);
                    }
                }
                else
                {
                    this.position.addInPlace(this.cameraDirection);
                }
            }
            if (needToRotate)
            {
                this.rotation.x += this.cameraRotation.x;
                this.rotation.y += this.cameraRotation.y;
                if (!this.noRotationConstraint)
                {
                    var limit = (Math.PI / 2) * 0.95;
                    if (this.rotation.x > limit)
                        this.rotation.x = limit;
                    if (this.rotation.x < -limit)
                        this.rotation.x = -limit;
                }
            }
            if (needToMove)
            {
                if (Math.Abs(this.cameraDirection.x) < BABYLON.Engine.Epsilon)
                {
                    this.cameraDirection.x = 0;
                }
                if (Math.Abs(this.cameraDirection.y) < BABYLON.Engine.Epsilon)
                {
                    this.cameraDirection.y = 0;
                }
                if (Math.Abs(this.cameraDirection.z) < BABYLON.Engine.Epsilon)
                {
                    this.cameraDirection.z = 0;
                }
                this.cameraDirection.scaleInPlace(this.inertia);
            }
            if (needToRotate)
            {
                if (Math.Abs(this.cameraRotation.x) < BABYLON.Engine.Epsilon)
                {
                    this.cameraRotation.x = 0;
                }
                if (Math.Abs(this.cameraRotation.y) < BABYLON.Engine.Epsilon)
                {
                    this.cameraRotation.y = 0;
                }
                this.cameraRotation.scaleInPlace(this.inertia);
            }
        }
        public virtual Matrix _getViewMatrix()
        {
            if (this.lockedTarget == null)
            {
                if (this.upVector.x != 0 || this.upVector.y != 1.0 || this.upVector.z != 0)
                {
                    BABYLON.Matrix.LookAtLHToRef(BABYLON.Vector3.Zero(), this._referencePoint, this.upVector, this._lookAtTemp);
                    BABYLON.Matrix.RotationYawPitchRollToRef(this.rotation.y, this.rotation.x, this.rotation.z, this._cameraRotationMatrix);
                    this._lookAtTemp.multiplyToRef(this._cameraRotationMatrix, this._tempMatrix);
                    this._lookAtTemp.invert();
                    this._tempMatrix.multiplyToRef(this._lookAtTemp, this._cameraRotationMatrix);
                }
                else
                {
                    BABYLON.Matrix.RotationYawPitchRollToRef(this.rotation.y, this.rotation.x, this.rotation.z, this._cameraRotationMatrix);
                }
                BABYLON.Vector3.TransformCoordinatesToRef(this._referencePoint, this._cameraRotationMatrix, this._transformedReferencePoint);
                this.position.addToRef(this._transformedReferencePoint, this._currentTarget);
            }
            else
            {
                this._currentTarget.copyFrom(this._getLockedTargetPosition());
            }
            BABYLON.Matrix.LookAtLHToRef(this.position, this._currentTarget, this.upVector, this._viewMatrix);
            return this._viewMatrix;
        }
    }
}