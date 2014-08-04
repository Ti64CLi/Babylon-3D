using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class ArcRotateCamera : Camera
    {
        public double inertialAlphaOffset = 0;
        public double inertialBetaOffset = 0;
        public double inertialRadiusOffset = 0;
        public double? lowerAlphaLimit = null;
        public double? upperAlphaLimit = null;
        public double? lowerBetaLimit = 0.01;
        public double? upperBetaLimit = Math.PI;
        public double? lowerRadiusLimit = null;
        public double? upperRadiusLimit = null;
        public double angularSensibility = 1000.0;
        public double wheelPrecision = 3.0;
        public Array<int> keysUp = new Array<int>(38);
        public Array<int> keysDown = new Array<int>(40);
        public Array<int> keysLeft = new Array<int>(37);
        public Array<int> keysRight = new Array<int>(39);
        public double zoomOnFactor = 1;
        private Array<int> _keys = new Array<int>();
        private BABYLON.Matrix _viewMatrix = new BABYLON.Matrix();
        private HTMLElement _attachedElement;
        private EventListener _onPointerDown;
        private EventListener _onPointerUp;
        private EventListener _onPointerMove;
        private EventListener _wheel;
        private EventListener _onMouseMove;
        private EventListener _onKeyDown;
        private EventListener _onKeyUp;
        private EventListener _onLostFocus;
        private System.Action _reset;
        //private EventListener _onGestureStart;
        //private System.Action<MSGestureEvent> _onGesture;
        //private MSGesture _MSGestureHandler;
        public double alpha;
        public double beta;
        public double radius;
        public object target;
        private string eventPrefix = Tools.GetPointerPrefix();

        public ArcRotateCamera(string name, double alpha, double beta, double radius, object target, Scene scene)
            : base(name, BABYLON.Vector3.Zero(), scene)
        {
            this.alpha = alpha;
            this.beta = beta;
            this.radius = radius;
            this.target = target;
            this.getViewMatrix();
        }

        public virtual Vector3 _getTargetPosition()
        {
            if (this.target is Mesh)
            {
                return ((Mesh)this.target).position;
            }

            return (Vector3)this.target;
        }
        public override void _initCache()
        {
            base._initCache();
            this._cache.target = new BABYLON.Vector3(double.MaxValue, double.MaxValue, double.MaxValue);
            this._cache.alpha = null;
            this._cache.beta = null;
            this._cache.radius = null;
        }
        public override void _updateCache(bool ignoreParentClass = false)
        {
            if (!ignoreParentClass)
            {
                base._updateCache();
            }
            this._cache.target.copyFrom(this._getTargetPosition());
            this._cache.alpha = this.alpha;
            this._cache.beta = this.beta;
            this._cache.radius = this.radius;
        }
        public override bool _isSynchronizedViewMatrix()
        {
            if (!base._isSynchronizedViewMatrix())
                return false;
            return this._cache.target.equals(this._getTargetPosition()) && this._cache.alpha == this.alpha && this._cache.beta == this.beta && this._cache.radius == this.radius;
        }
        public virtual void attachControl(HTMLElement element, bool noPreventDefault = false)
        {
            PositionCoord previousPosition = null;
            int pointerId = 0;
            if (this._attachedElement != null)
            {
                return;
            }
            this._attachedElement = element;
            var engine = this.getEngine();
            if (this._onPointerDown == null)
            {
                this._onPointerDown = (e) =>
                {
                    if (pointerId > 0)
                    {
                        return;
                    }

                    var evt = (PointerEvent) e;

                    pointerId = evt.pointerId;
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
                this._onPointerUp = (e) =>
                {
                    var evt = (PointerEvent)e;

                    previousPosition = null;
                    pointerId = 0;
                    if (!noPreventDefault)
                    {
                        evt.preventDefault();
                    }
                };
                this._onPointerMove = (e) =>
                {
                    var evt = (PointerEvent)e;

                    if (previousPosition == null)
                    {
                        return;
                    }
                    if (pointerId != evt.pointerId)
                    {
                        return;
                    }
                    var offsetX = evt.clientX - previousPosition.x;
                    var offsetY = evt.clientY - previousPosition.y;
                    this.inertialAlphaOffset -= offsetX / this.angularSensibility;
                    this.inertialBetaOffset -= offsetY / this.angularSensibility;
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
                this._onMouseMove = (e) =>
                {
                    if (!engine.isPointerLock)
                    {
                        return;
                    }

                    var evt = (MouseEvent)e;

                    var offsetX = evt.offsetX;
                    var offsetY = evt.offsetY;
                    this.inertialAlphaOffset -= offsetX / this.angularSensibility;
                    this.inertialBetaOffset -= offsetY / this.angularSensibility;
                    if (!noPreventDefault)
                    {
                        evt.preventDefault();
                    }
                };
                this._wheel = (e) =>
                {
                    var _event = (MouseWheelEvent)e;

                    var delta = 0.0;
                    delta = _event.wheelDelta / (this.wheelPrecision * 40);
                    if (delta > 0.0)
                        this.inertialRadiusOffset += delta;
                    if (!noPreventDefault)
                    {
                        _event.preventDefault();
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

                        evt.preventDefault();
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
                            this._keys.RemoveAt(index);
                        }

                        evt.preventDefault();
                    }
                };
                this._onLostFocus = (e) =>
                {
                    this._keys = new Array<int>();
                    pointerId = 0;
                };
                /*
                this._onGestureStart = (e) =>
                {
                    if (window.MSGesture == null)
                    {
                        return;
                    }
                    if (this._MSGestureHandler == null)
                    {
                        this._MSGestureHandler = new MSGesture();
                        this._MSGestureHandler.target = element;
                    }
                    this._MSGestureHandler.addPointer(e.pointerId);
                };
                this._onGesture = (e) =>
                {
                    this.radius *= e.scale;
                    if (!noPreventDefault)
                    {
                        e.stopPropagation();
                        e.preventDefault();
                    }
                };
                */
                this._reset = () =>
                {
                    this._keys = new Array<int>();
                    this.inertialAlphaOffset = 0;
                    this.inertialBetaOffset = 0;
                    this.inertialRadiusOffset = 0;
                    previousPosition = null;
                    pointerId = 0;
                };
            }
            element.addEventListener(eventPrefix + "down", this._onPointerDown, false);
            element.addEventListener(eventPrefix + "up", this._onPointerUp, false);
            element.addEventListener(eventPrefix + "out", this._onPointerUp, false);
            element.addEventListener(eventPrefix + "move", this._onPointerMove, false);
            element.addEventListener("mousemove", this._onMouseMove, false);
            //element.addEventListener("MSPointerDown", this._onGestureStart, false);
            //element.addEventListener("MSGestureChange", this._onGesture, false);
            element.addEventListener("mousewheel", this._wheel, false);
            element.addEventListener("DOMMouseScroll", this._wheel, false);
            Tools.RegisterTopRootEvents(new Array<EventDts>(
                new EventDts { name = "keydown", handler = this._onKeyDown }, 
                new EventDts { name = "keyup", handler = this._onKeyUp }, 
                new EventDts { name = "blur", handler = this._onLostFocus}));
        }
        public override void detachControl(HTMLElement element)
        {
            if (this._attachedElement != element)
            {
                return;
            }
            element.removeEventListener(eventPrefix + "down", this._onPointerDown);
            element.removeEventListener(eventPrefix + "up", this._onPointerUp);
            element.removeEventListener(eventPrefix + "out", this._onPointerUp);
            element.removeEventListener(eventPrefix + "move", this._onPointerMove);
            element.removeEventListener("mousemove", this._onMouseMove);
            //element.removeEventListener("MSPointerDown", this._onGestureStart);
            //element.removeEventListener("MSGestureChange", this._onGesture);
            element.removeEventListener("mousewheel", this._wheel);
            element.removeEventListener("DOMMouseScroll", this._wheel);
            Tools.UnregisterTopRootEvents(new Array<EventDts>(
                new EventDts { name = "keydown", handler = this._onKeyDown },
                new EventDts { name = "keyup", handler = this._onKeyUp },
                new EventDts { name = "blur", handler = this._onLostFocus }));
            //this._MSGestureHandler = null;
            //this._attachedElement = null;
            if (this._reset != null)
            {
                this._reset();
            }
        }
        public override void _update()
        {
            for (var index = 0; index < this._keys.Length; index++)
            {
                var keyCode = this._keys[index];
                if (this.keysLeft.indexOf(keyCode) != -1)
                {
                    this.inertialAlphaOffset -= 0.01;
                }
                else
                    if (this.keysUp.indexOf(keyCode) != -1)
                    {
                        this.inertialBetaOffset -= 0.01;
                    }
                    else
                        if (this.keysRight.indexOf(keyCode) != -1)
                        {
                            this.inertialAlphaOffset += 0.01;
                        }
                        else
                            if (this.keysDown.indexOf(keyCode) != -1)
                            {
                                this.inertialBetaOffset += 0.01;
                            }
            }
            if (this.inertialAlphaOffset != 0 || this.inertialBetaOffset != 0 || this.inertialRadiusOffset != 0)
            {
                this.alpha += this.inertialAlphaOffset;
                this.beta += this.inertialBetaOffset;
                this.radius -= this.inertialRadiusOffset;
                this.inertialAlphaOffset *= this.inertia;
                this.inertialBetaOffset *= this.inertia;
                this.inertialRadiusOffset *= this.inertia;
                if (Math.Abs(this.inertialAlphaOffset) < BABYLON.Engine.Epsilon)
                    this.inertialAlphaOffset = 0;
                if (Math.Abs(this.inertialBetaOffset) < BABYLON.Engine.Epsilon)
                    this.inertialBetaOffset = 0;
                if (Math.Abs(this.inertialRadiusOffset) < BABYLON.Engine.Epsilon)
                    this.inertialRadiusOffset = 0;
            }
            if (this.lowerAlphaLimit.HasValue && this.alpha < this.lowerAlphaLimit)
            {
                this.alpha = this.lowerAlphaLimit.Value;
            }
            if (this.upperAlphaLimit.HasValue && this.alpha > this.upperAlphaLimit)
            {
                this.alpha = this.upperAlphaLimit.Value;
            }
            if (this.lowerBetaLimit.HasValue && this.beta < this.lowerBetaLimit)
            {
                this.beta = this.lowerBetaLimit.Value;
            }
            if (this.upperBetaLimit.HasValue && this.beta > this.upperBetaLimit)
            {
                this.beta = this.upperBetaLimit.Value;
            }
            if (this.lowerRadiusLimit.HasValue && this.radius < this.lowerRadiusLimit)
            {
                this.radius = this.lowerRadiusLimit.Value;
            }
            if (this.upperRadiusLimit.HasValue && this.radius > this.upperRadiusLimit)
            {
                this.radius = this.upperRadiusLimit.Value;
            }
        }
        public virtual void setPosition(Vector3 position)
        {
            var radiusv3 = position.subtract(this._getTargetPosition());
            this.radius = radiusv3.Length();
            this.alpha = Math.Acos(radiusv3.x / Math.Sqrt(Math.Pow(radiusv3.x, 2) + Math.Pow(radiusv3.z, 2)));
            if (radiusv3.z < 0)
            {
                this.alpha = 2 * Math.PI - this.alpha;
            }
            this.beta = Math.Acos(radiusv3.y / this.radius);
        }
        public override Matrix _getViewMatrix()
        {
            var cosa = Math.Cos(this.alpha);
            var sina = Math.Sin(this.alpha);
            var cosb = Math.Cos(this.beta);
            var sinb = Math.Sin(this.beta);
            var target = this._getTargetPosition();
            target.addToRef(new BABYLON.Vector3(this.radius * cosa * sinb, this.radius * cosb, this.radius * sina * sinb), this.position);
            Matrix.LookAtLHToRef(this.position, target, this.upVector, this._viewMatrix);
            return this._viewMatrix;
        }
        public virtual void zoomOn(Array<AbstractMesh> meshes = null)
        {
            meshes = meshes ?? this.getScene().meshes;
            var minMaxVector = BABYLON.Mesh.MinMax(meshes);
            var distance = BABYLON.Vector3.Distance(minMaxVector.minimum, minMaxVector.maximum);
            this.radius = distance * this.zoomOnFactor;
            this.focusOn(new MinMaxDistance { minimum = minMaxVector.minimum, maximum = minMaxVector.maximum, distance = distance });
        }
        public virtual void focusOn(MinMaxDistance meshesOrMinMaxVectorAndDistance)
        {
            var distance = meshesOrMinMaxVectorAndDistance.distance;
            var minMax = new MinMax { minimum = meshesOrMinMaxVectorAndDistance.minimum, maximum = meshesOrMinMaxVectorAndDistance.maximum };
            this.target = Mesh.Center(minMax);
            this.maxZ = distance * 2;
        }
        public virtual void focusOn(Array<AbstractMesh> meshesOrMinMaxVectorAndDistance)
        {
            var meshesOrMinMaxVector = BABYLON.Mesh.MinMax(this.getScene().meshes);
            var distance = BABYLON.Vector3.Distance(meshesOrMinMaxVector.minimum, meshesOrMinMaxVector.maximum);
            this.target = Mesh.Center(meshesOrMinMaxVector);
            this.maxZ = distance * 2;
        }
    }
}