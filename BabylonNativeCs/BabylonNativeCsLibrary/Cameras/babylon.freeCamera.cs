// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.freeCamera.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    using System;

    using Web;

    /// <summary>
    /// </summary>
    public partial class FreeCamera : Camera
    {
        /// <summary>
        /// </summary>
        public Matrix _cameraRotationMatrix = Matrix.Zero();

        /// <summary>
        /// </summary>
        public Vector3 _currentTarget = Vector3.Zero();

        /// <summary>
        /// </summary>
        public EventListener _onLostFocus;

        /// <summary>
        /// </summary>
        public Vector3 _referencePoint = new Vector3(0, 0, 1);

        /// <summary>
        /// </summary>
        public Vector3 _transformedReferencePoint = Vector3.Zero();

        /// <summary>
        /// </summary>
        public Matrix _viewMatrix = Matrix.Zero();

        /// <summary>
        /// </summary>
        public string _waitingLockedTargetId;

        /// <summary>
        /// </summary>
        public double angularSensibility = 2000.0;

        /// <summary>
        /// </summary>
        public bool applyGravity = false;

        /// <summary>
        /// </summary>
        public Vector3 cameraDirection = new Vector3(0, 0, 0);

        /// <summary>
        /// </summary>
        public Vector2 cameraRotation = new Vector2(0, 0);

        /// <summary>
        /// </summary>
        public bool checkCollisions = false;

        /// <summary>
        /// </summary>
        public Vector3 ellipsoid = new Vector3(0.5, 1, 0.5);

        /// <summary>
        /// </summary>
        public Array<int> keysDown = new Array<int>(40);

        /// <summary>
        /// </summary>
        public Array<int> keysLeft = new Array<int>(37);

        /// <summary>
        /// </summary>
        public Array<int> keysRight = new Array<int>(39);

        /// <summary>
        /// </summary>
        public Array<int> keysUp = new Array<int>(38);

        /// <summary>
        /// </summary>
        public object lockedTarget = null;

        /// <summary>
        /// </summary>
        public bool noRotationConstraint = false;

        /// <summary>
        /// </summary>
        public Action<AbstractMesh> onCollide = null;

        /// <summary>
        /// </summary>
        public Vector3 rotation = new Vector3(0, 0, 0);

        /// <summary>
        /// </summary>
        public double speed = 2.0;

        /// <summary>
        /// </summary>
        private HTMLElement _attachedElement;

        /// <summary>
        /// </summary>
        private readonly Matrix _camMatrix = Matrix.Zero();

        /// <summary>
        /// </summary>
        private readonly Matrix _cameraTransformMatrix = Matrix.Zero();

        /// <summary>
        /// </summary>
        private readonly Collider _collider = new Collider();

        /// <summary>
        /// </summary>
        private readonly Vector3 _diffPosition = Vector3.Zero();

        /// <summary>
        /// </summary>
        private Array<int> _keys = new Array<int>();

        /// <summary>
        /// </summary>
        private Vector3 _localDirection;

        /// <summary>
        /// </summary>
        private readonly Matrix _lookAtTemp = Matrix.Zero();

        /// <summary>
        /// </summary>
        private bool _needMoveForGravity = true;

        /// <summary>
        /// </summary>
        private readonly Vector3 _newPosition = Vector3.Zero();

        /// <summary>
        /// </summary>
        private readonly Vector3 _oldPosition = Vector3.Zero();

        /// <summary>
        /// </summary>
        private EventListener _onKeyDown;

        /// <summary>
        /// </summary>
        private EventListener _onKeyUp;

        /// <summary>
        /// </summary>
        private EventListener _onMouseDown;

        /// <summary>
        /// </summary>
        private EventListener _onMouseMove;

        /// <summary>
        /// </summary>
        private EventListener _onMouseOut;

        /// <summary>
        /// </summary>
        private EventListener _onMouseUp;

        /// <summary>
        /// </summary>
        private System.Action _reset;

        /// <summary>
        /// </summary>
        private readonly Matrix _tempMatrix = Matrix.Zero();

        /// <summary>
        /// </summary>
        private Vector3 _transformedDirection;

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="position">
        /// </param>
        /// <param name="scene">
        /// </param>
        public FreeCamera(string name, Vector3 position, Scene scene)
            : base(name, position, scene)
        {
        }

        /// <summary>
        /// </summary>
        public virtual void _checkInputs()
        {
            if (this._localDirection == null)
            {
                this._localDirection = Vector3.Zero();
                this._transformedDirection = Vector3.Zero();
            }

            for (var index = 0; index < this._keys.Length; index++)
            {
                var keyCode = this._keys[index];
                var speed = this._computeLocalCameraSpeed();
                if (this.keysLeft.IndexOf(keyCode) != -1)
                {
                    this._localDirection.copyFromFloats(-speed, 0, 0);
                }
                else if (this.keysUp.IndexOf(keyCode) != -1)
                {
                    this._localDirection.copyFromFloats(0, 0, speed);
                }
                else if (this.keysRight.IndexOf(keyCode) != -1)
                {
                    this._localDirection.copyFromFloats(speed, 0, 0);
                }
                else if (this.keysDown.IndexOf(keyCode) != -1)
                {
                    this._localDirection.copyFromFloats(0, 0, -speed);
                }

                this.getViewMatrix().invertToRef(this._cameraTransformMatrix);
                Vector3.TransformNormalToRef(this._localDirection, this._cameraTransformMatrix, this._transformedDirection);
                this.cameraDirection.addInPlace(this._transformedDirection);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="velocity">
        /// </param>
        public virtual void _collideWithWorld(Vector3 velocity)
        {
            Vector3 globalPosition = null;
            if (this.parent != null)
            {
                globalPosition = Vector3.TransformCoordinates(this.position, this.parent.getWorldMatrix());
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

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual double _computeLocalCameraSpeed()
        {
            return this.speed * (Tools.GetDeltaTime() / (Tools.GetFps() * 10.0));
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Vector3 _getLockedTargetPosition()
        {
            if (this.lockedTarget is Mesh)
            {
                return ((Mesh)this.lockedTarget).position;
            }

            return (Vector3)this.lockedTarget;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override Matrix _getViewMatrix()
        {
            if (this.lockedTarget == null)
            {
                if (this.upVector.x != 0 || this.upVector.y != 1.0 || this.upVector.z != 0)
                {
                    Matrix.LookAtLHToRef(Vector3.Zero(), this._referencePoint, this.upVector, this._lookAtTemp);
                    Matrix.RotationYawPitchRollToRef(this.rotation.y, this.rotation.x, this.rotation.z, this._cameraRotationMatrix);
                    this._lookAtTemp.multiplyToRef(this._cameraRotationMatrix, this._tempMatrix);
                    this._lookAtTemp.invert();
                    this._tempMatrix.multiplyToRef(this._lookAtTemp, this._cameraRotationMatrix);
                }
                else
                {
                    Matrix.RotationYawPitchRollToRef(this.rotation.y, this.rotation.x, this.rotation.z, this._cameraRotationMatrix);
                }

                Vector3.TransformCoordinatesToRef(this._referencePoint, this._cameraRotationMatrix, this._transformedReferencePoint);
                this.position.addToRef(this._transformedReferencePoint, this._currentTarget);
            }
            else
            {
                this._currentTarget.copyFrom(this._getLockedTargetPosition());
            }

            Matrix.LookAtLHToRef(this.position, this._currentTarget, this.upVector, this._viewMatrix);
            return this._viewMatrix;
        }

        /// <summary>
        /// </summary>
        public override void _initCache()
        {
            base._initCache();
            this._cache.target = new Vector3(double.MaxValue, double.MaxValue, double.MaxValue);
            this._cache.rotation = new Vector3(double.MaxValue, double.MaxValue, double.MaxValue);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override bool _isSynchronizedViewMatrix()
        {
            if (!base._isSynchronizedViewMatrix())
            {
                return false;
            }

            var lockedTargetPosition = this._getLockedTargetPosition();
            return ((this._cache.target != null) ? this._cache.target.equals(lockedTargetPosition) : lockedTargetPosition == null)
                   && this._cache.rotation.equals(this.rotation);
        }

        /// <summary>
        /// </summary>
        public override void _update()
        {
            this._checkInputs();
            var needToMove = this._needMoveForGravity || Math.Abs(this.cameraDirection.x) > 0 || Math.Abs(this.cameraDirection.y) > 0
                             || Math.Abs(this.cameraDirection.z) > 0;
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
                        this._needMoveForGravity = Vector3.DistanceSquared(oldPosition, this.position) != 0;
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
                    {
                        this.rotation.x = limit;
                    }

                    if (this.rotation.x < -limit)
                    {
                        this.rotation.x = -limit;
                    }
                }
            }

            if (needToMove)
            {
                if (Math.Abs(this.cameraDirection.x) < Engine.Epsilon)
                {
                    this.cameraDirection.x = 0;
                }

                if (Math.Abs(this.cameraDirection.y) < Engine.Epsilon)
                {
                    this.cameraDirection.y = 0;
                }

                if (Math.Abs(this.cameraDirection.z) < Engine.Epsilon)
                {
                    this.cameraDirection.z = 0;
                }

                this.cameraDirection.scaleInPlace(this.inertia);
            }

            if (needToRotate)
            {
                if (Math.Abs(this.cameraRotation.x) < Engine.Epsilon)
                {
                    this.cameraRotation.x = 0;
                }

                if (Math.Abs(this.cameraRotation.y) < Engine.Epsilon)
                {
                    this.cameraRotation.y = 0;
                }

                this.cameraRotation.scaleInPlace(this.inertia);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="ignoreParentClass">
        /// </param>
        public override void _updateCache(bool ignoreParentClass = false)
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

        /// <summary>
        /// </summary>
        /// <param name="element">
        /// </param>
        /// <param name="noPreventDefault">
        /// </param>
<<<<<<< HEAD
        public virtual void attachControl(HTMLElement element, bool noPreventDefault = false)
=======
        public override void attachControl(HTMLElement element, bool noPreventDefault = false)
>>>>>>> f265f07661031677698c527dcba26356bdf55cab
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

                        previousPosition = new PositionCoord { x = evt.clientX, y = evt.clientY };
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
                        previousPosition = new PositionCoord { x = evt.clientX, y = evt.clientY };
                        if (!noPreventDefault)
                        {
                            evt.preventDefault();
                        }
                    };
                this._onKeyDown = (e) =>
                    {
                        var evt = (KeyboardEvent)e;

                        if (this.keysUp.IndexOf(evt.keyCode) != -1 || this.keysDown.IndexOf(evt.keyCode) != -1 || this.keysLeft.IndexOf(evt.keyCode) != -1
                            || this.keysRight.IndexOf(evt.keyCode) != -1)
                        {
                            var index = this._keys.IndexOf(evt.keyCode);
                            if (index == -1)
                            {
                                this._keys.Add(evt.keyCode);
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

                        if (this.keysUp.IndexOf(evt.keyCode) != -1 || this.keysDown.IndexOf(evt.keyCode) != -1 || this.keysLeft.IndexOf(evt.keyCode) != -1
                            || this.keysRight.IndexOf(evt.keyCode) != -1)
                        {
                            var index = this._keys.IndexOf(evt.keyCode);
                            if (index >= 0)
                            {
                                this._keys.RemoveAt(index);
                            }

                            if (!noPreventDefault)
                            {
                                evt.preventDefault();
                            }
                        }
                    };
                this._onLostFocus = (e) => { this._keys = new Array<int>(); };
                this._reset = () =>
                    {
                        this._keys = new Array<int>();
                        previousPosition = null;
                        this.cameraDirection = new Vector3(0, 0, 0);
                        this.cameraRotation = new Vector2(0, 0);
                    };
            }

            element.addEventListener("mousedown", this._onMouseDown, false);
            element.addEventListener("mouseup", this._onMouseUp, false);
            element.addEventListener("mouseout", this._onMouseOut, false);
            element.addEventListener("mousemove", this._onMouseMove, false);
            Tools.RegisterTopRootEvents(
                new Array<EventDts>(
                    new EventDts { name = "keydown", handler = this._onKeyDown }, 
                    new EventDts { name = "keyup", handler = this._onKeyUp }, 
                    new EventDts { name = "blur", handler = this._onLostFocus }));
        }

        /// <summary>
        /// </summary>
        /// <param name="element">
        /// </param>
        public override void detachControl(HTMLElement element)
        {
            if (this._attachedElement != element)
            {
                return;
            }

            element.removeEventListener("mousedown", this._onMouseDown);
            element.removeEventListener("mouseup", this._onMouseUp);
            element.removeEventListener("mouseout", this._onMouseOut);
            element.removeEventListener("mousemove", this._onMouseMove);
            Tools.UnregisterTopRootEvents(
                new Array<EventDts>(
                    new EventDts { name = "keydown", handler = this._onKeyDown }, 
                    new EventDts { name = "keyup", handler = this._onKeyUp }, 
                    new EventDts { name = "blur", handler = this._onLostFocus }));
            this._attachedElement = null;
            if (this._reset != null)
            {
                this._reset();
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Vector3 getTarget()
        {
            return this._currentTarget;
        }

        /// <summary>
        /// </summary>
        /// <param name="target">
        /// </param>
        public virtual void setTarget(Vector3 target)
        {
            this.upVector.normalize();
            Matrix.LookAtLHToRef(this.position, target, this.upVector, this._camMatrix);
            this._camMatrix.invert();
            this.rotation.x = Math.Atan(this._camMatrix.m[6] / this._camMatrix.m[10]);
            var vDir = target.subtract(this.position);
            if (vDir.x >= 0.0)
            {
                this.rotation.y = -Math.Atan(vDir.z / vDir.x) + Math.PI / 2.0;
            }
            else
            {
                this.rotation.y = -Math.Atan(vDir.z / vDir.x) - Math.PI / 2.0;
            }

            this.rotation.z = -Math.Acos(Vector3.Dot(new Vector3(0, 1.0, 0), this.upVector));
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
    }
}