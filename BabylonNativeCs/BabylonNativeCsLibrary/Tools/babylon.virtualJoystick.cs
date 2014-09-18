// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.virtualJoystick.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    /*
    public enum JoystickAxis {
        X, Y, Z
    }
    public partial class VirtualJoystick {
        public bool reverseLeftRight;
        public bool reverseUpDown;
        public Vector3 deltaPosition;
        public bool pressed;
        private static double _globalJoystickIndex = 0;
        private static HTMLCanvasElement vjCanvas;
        private static CanvasRenderingContext2D vjCanvasContext;
        private static double vjCanvasWidth;
        private static double vjCanvasHeight;
        private static double halfWidth;
        private static double halfHeight;
        private System.Func _action;
        private JoystickAxis _axisTargetedByLeftAndRight;
        private JoystickAxis _axisTargetedByUpAndDown;
        private double _joystickSensibility;
        private double _inversedSensibility;
        private double _rotationSpeed;
        private double _inverseRotationSpeed;
        private bool _rotateOnAxisRelativeToMesh;
        private double _joystickPointerID;
        private string _joystickColor;
        private Vector2 _joystickPointerPos;
        private Vector2 _joystickPointerStartPos;
        private Vector2 _deltaJoystickVector;
        private bool _leftJoystick;
        private double _joystickIndex;
        private BABYLON.VirtualJoystick.Collection < PointerEvent > _touches;
        public VirtualJoystick(bool leftJoystick = false) {
            if (leftJoystick) {
                this._leftJoystick = true;
            } else {
                this._leftJoystick = false;
            }
            this._joystickIndex = VirtualJoystick._globalJoystickIndex;
            VirtualJoystick._globalJoystickIndex++;
            this._axisTargetedByLeftAndRight = JoystickAxis.X;
            this._axisTargetedByUpAndDown = JoystickAxis.Y;
            this.reverseLeftRight = false;
            this.reverseUpDown = false;
            this._touches = new BABYLON.VirtualJoystick.Collection < PointerEvent > ();
            this.deltaPosition = BABYLON.Vector3.Zero();
            this._joystickSensibility = 25;
            this._inversedSensibility = 1 / (this._joystickSensibility / 1000);
            this._rotationSpeed = 25;
            this._inverseRotationSpeed = 1 / (this._rotationSpeed / 1000);
            this._rotateOnAxisRelativeToMesh = false;
            if (!VirtualJoystick.vjCanvas) {
                window.addEventListener("resize", () {
                    VirtualJoystick.vjCanvasWidth = window.innerWidth;
                    VirtualJoystick.vjCanvasHeight = window.innerHeight;
                    VirtualJoystick.vjCanvas.width = VirtualJoystick.vjCanvasWidth;
                    VirtualJoystick.vjCanvas.height = VirtualJoystick.vjCanvasHeight;
                    VirtualJoystick.halfWidth = VirtualJoystick.vjCanvasWidth / 2;
                    VirtualJoystick.halfHeight = VirtualJoystick.vjCanvasHeight / 2;
                }, false);
                VirtualJoystick.vjCanvas = document.createElement("canvas");
                VirtualJoystick.vjCanvasWidth = window.innerWidth;
                VirtualJoystick.vjCanvasHeight = window.innerHeight;
                VirtualJoystick.vjCanvas.width = window.innerWidth;
                VirtualJoystick.vjCanvas.height = window.innerHeight;
                VirtualJoystick.vjCanvas.style.width = "100%";
                VirtualJoystick.vjCanvas.style.height = "100%";
                VirtualJoystick.vjCanvas.style.position = "absolute";
                VirtualJoystick.vjCanvas.style.backgroundColor = "transparent";
                VirtualJoystick.vjCanvas.style.top = "0px";
                VirtualJoystick.vjCanvas.style.left = "0px";
                VirtualJoystick.vjCanvas.style.zIndex = "5";
                VirtualJoystick.vjCanvas.style.msTouchAction = "none";
                VirtualJoystick.vjCanvasContext = VirtualJoystick.vjCanvas.getContext("2d");
                VirtualJoystick.vjCanvasContext.strokeStyle = "#ffffff";
                VirtualJoystick.vjCanvasContext.lineWidth = 2;
                document.body.appendChild(VirtualJoystick.vjCanvas);
            }
            VirtualJoystick.halfWidth = VirtualJoystick.vjCanvas.width / 2;
            VirtualJoystick.halfHeight = VirtualJoystick.vjCanvas.height / 2;
            this.pressed = false;
            this._joystickColor = "cyan";
            this._joystickPointerID = -1;
            this._joystickPointerPos = new BABYLON.Vector2(0, 0);
            this._joystickPointerStartPos = new BABYLON.Vector2(0, 0);
            this._deltaJoystickVector = new BABYLON.Vector2(0, 0);
            VirtualJoystick.vjCanvas.addEventListener("pointerdown", (object evt) => {
                this._onPointerDown(evt);
            }, false);
            VirtualJoystick.vjCanvas.addEventListener("pointermove", (object evt) => {
                this._onPointerMove(evt);
            }, false);
            VirtualJoystick.vjCanvas.addEventListener("pointerup", (object evt) => {
                this._onPointerUp(evt);
            }, false);
            VirtualJoystick.vjCanvas.addEventListener("pointerout", (object evt) => {
                this._onPointerUp(evt);
            }, false);
            VirtualJoystick.vjCanvas.addEventListener("contextmenu", (object evt) => {
                evt.preventDefault();
            }, false);
            requestAnimationFrame(() => {
                this._drawVirtualJoystick();
            });
        }
        void DDS_MAGIC0x20534444;
        void DDSD_CAPS0x1;
        void DDSD_HEIGHT0x2;
        void DDSD_WIDTH0x4;
        void DDSD_PITCH0x8;
        void DDSD_PIXELFORMAT0x1000;
        void DDSD_MIPMAPCOUNT0x20000;
        void DDSD_LINEARSIZE0x80000;
        void DDSD_DEPTH0x800000;
        void DDSCAPS_COMPLEX0x8;
        void DDSCAPS_MIPMAP0x400000;
        void DDSCAPS_TEXTURE0x1000;
        void DDSCAPS2_CUBEMAP0x200;
        void DDSCAPS2_CUBEMAP_POSITIVEX0x400;
        void DDSCAPS2_CUBEMAP_NEGATIVEX0x800;
        void DDSCAPS2_CUBEMAP_POSITIVEY0x1000;
        void DDSCAPS2_CUBEMAP_NEGATIVEY0x2000;
        void DDSCAPS2_CUBEMAP_POSITIVEZ0x4000;
        void DDSCAPS2_CUBEMAP_NEGATIVEZ0x8000;
        void DDSCAPS2_VOLUME0x200000;
        void DDPF_ALPHAPIXELS0x1;
        void DDPF_ALPHA0x2;
        void DDPF_FOURCC0x4;
        void DDPF_RGB0x40;
        void DDPF_YUV0x200;
        void DDPF_LUMINANCE0x20000; {} {}
        void FOURCC_DXT1FourCCToInt32("DXT1");
        void FOURCC_DXT3FourCCToInt32("DXT3");
        void FOURCC_DXT5FourCCToInt32("DXT5");
        void headerLengthInt31;
        void off_magic0;
        void off_size1;
        void off_flags2;
        void off_height3;
        void off_width4;
        void off_mipmapCount7;
        void off_pfFlags20;
        void off_pfFourCC21;
        void off_RGBbpp22;
        void off_RMask23;
        void off_GMask24;
        void off_BMask25;
        void off_AMask26;
        void off_caps127;
        void off_caps228;;
        void screenshotCanvas;
        void fpsRange60;
        void previousFramesDurationnew Array < object > ();
        void fps60;
        void deltaTime0;
        void cloneValue(object source, object destinationObject) {
            if (!source)
                return null;
            if (source is Mesh) {
                return null;
            }
            if (source is SubMesh) {
                return source.clone(destinationObject);
            } else
            if (source.clone) {
                return source.clone();
            }
            return null;
        };
        public virtual void setJoystickSensibility(double newJoystickSensibility) {
            this._joystickSensibility = newJoystickSensibility;
            this._inversedSensibility = 1 / (this._joystickSensibility / 1000);
        }
        private void _onPointerDown(PointerEvent e) {
            var positionOnScreenCondition;
            e.preventDefault();
            if (this._leftJoystick == true) {
                positionOnScreenCondition = (e.clientX < VirtualJoystick.halfWidth);
            } else {
                positionOnScreenCondition = (e.clientX > VirtualJoystick.halfWidth);
            }
            if (positionOnScreenCondition && this._joystickPointerID < 0) {
                this._joystickPointerID = e.pointerId;
                this._joystickPointerStartPos.x = e.clientX;
                this._joystickPointerStartPos.y = e.clientY;
                this._joystickPointerPos = this._joystickPointerStartPos.clone();
                this._deltaJoystickVector.x = 0;
                this._deltaJoystickVector.y = 0;
                this.pressed = true;
                this._touches.add(e.pointerId.ToString(), e);
            } else {
                if (VirtualJoystick._globalJoystickIndex < 2 && this._action) {
                    this._action();
                    this._touches.add(e.pointerId.ToString(), e);
                }
            }
        }
        private void _onPointerMove(PointerEvent e) {
            if (this._joystickPointerID == e.pointerId) {
                this._joystickPointerPos.x = e.clientX;
                this._joystickPointerPos.y = e.clientY;
                this._deltaJoystickVector = this._joystickPointerPos.clone();
                this._deltaJoystickVector = this._deltaJoystickVector.subtract(this._joystickPointerStartPos);
                var directionLeftRight = (this.reverseLeftRight) ? -1 : 1;
                var deltaJoystickX = directionLeftRight * this._deltaJoystickVector.x / this._inversedSensibility;
                switch (this._axisTargetedByLeftAndRight) {
                    case JoystickAxis.X:
                        this.deltaPosition.x = Math.min(1, Math.Max(-1, deltaJoystickX));
                        break;
                    case JoystickAxis.Y:
                        this.deltaPosition.y = Math.min(1, Math.Max(-1, deltaJoystickX));
                        break;
                    case JoystickAxis.Z:
                        this.deltaPosition.z = Math.min(1, Math.Max(-1, deltaJoystickX));
                        break;
                }
                var directionUpDown = (this.reverseUpDown) ? 1 : -1;
                var deltaJoystickY = directionUpDown * this._deltaJoystickVector.y / this._inversedSensibility;
                switch (this._axisTargetedByUpAndDown) {
                    case JoystickAxis.X:
                        this.deltaPosition.x = Math.min(1, Math.Max(-1, deltaJoystickY));
                        break;
                    case JoystickAxis.Y:
                        this.deltaPosition.y = Math.min(1, Math.Max(-1, deltaJoystickY));
                        break;
                    case JoystickAxis.Z:
                        this.deltaPosition.z = Math.min(1, Math.Max(-1, deltaJoystickY));
                        break;
                }
            } else {
                if (this._touches.item(e.pointerId.ToString())) {
                    this._touches.item(e.pointerId.ToString()).x = e.clientX;
                    this._touches.item(e.pointerId.ToString()).y = e.clientY;
                }
            }
        }
        private void _onPointerUp(PointerEvent e) {
            this._clearCanvas();
            if (this._joystickPointerID == e.pointerId) {
                this._joystickPointerID = -1;
                this.pressed = false;
            }
            this._deltaJoystickVector.x = 0;
            this._deltaJoystickVector.y = 0;
            this._touches.remove(e.pointerId.ToString());
        }
        public virtual void setJoystickColor(string newColor) {
            this._joystickColor = newColor;
        }
        public virtual void setActionOnTouch(System.Func action) {
            this._action = action;
        }
        public virtual void setAxisForLeftRight(JoystickAxis axis) {
            switch (axis) {
                case JoystickAxis.X:
                case JoystickAxis.Y:
                case JoystickAxis.Z:
                    this._axisTargetedByLeftAndRight = axis;
                    break;
                    this._axisTargetedByLeftAndRight = axis;
                    break;
                default:
                    this._axisTargetedByLeftAndRight = JoystickAxis.X;
                    break;
            }
        }
        public virtual void setAxisForUpDown(JoystickAxis axis) {
            switch (axis) {
                case JoystickAxis.X:
                case JoystickAxis.Y:
                case JoystickAxis.Z:
                    this._axisTargetedByUpAndDown = axis;
                    break;
                default:
                    this._axisTargetedByUpAndDown = JoystickAxis.Y;
                    break;
            }
        }
        private void _clearCanvas() {
            if (this._leftJoystick) {
                VirtualJoystick.vjCanvasContext.clearRect(0, 0, VirtualJoystick.vjCanvasWidth / 2, VirtualJoystick.vjCanvasHeight);
            } else {
                VirtualJoystick.vjCanvasContext.clearRect(VirtualJoystick.vjCanvasWidth / 2, 0, VirtualJoystick.vjCanvasWidth, VirtualJoystick.vjCanvasHeight);
            }
        }
        private void _drawVirtualJoystick() {
            if (this.pressed) {
                this._clearCanvas();
                this._touches.forEach((PointerEvent touch) => {
                    if (touch.pointerId == this._joystickPointerID) {
                        VirtualJoystick.vjCanvasContext.beginPath();
                        VirtualJoystick.vjCanvasContext.strokeStyle = this._joystickColor;
                        VirtualJoystick.vjCanvasContext.lineWidth = 6;
                        VirtualJoystick.vjCanvasContext.arc(this._joystickPointerStartPos.x, this._joystickPointerStartPos.y, 40, 0, Math.PI * 2, true);
                        VirtualJoystick.vjCanvasContext.stroke();
                        VirtualJoystick.vjCanvasContext.beginPath();
                        VirtualJoystick.vjCanvasContext.strokeStyle = this._joystickColor;
                        VirtualJoystick.vjCanvasContext.lineWidth = 2;
                        VirtualJoystick.vjCanvasContext.arc(this._joystickPointerStartPos.x, this._joystickPointerStartPos.y, 60, 0, Math.PI * 2, true);
                        VirtualJoystick.vjCanvasContext.stroke();
                        VirtualJoystick.vjCanvasContext.beginPath();
                        VirtualJoystick.vjCanvasContext.strokeStyle = this._joystickColor;
                        VirtualJoystick.vjCanvasContext.arc(this._joystickPointerPos.x, this._joystickPointerPos.y, 40, 0, Math.PI * 2, true);
                        VirtualJoystick.vjCanvasContext.stroke();
                    } else {
                        VirtualJoystick.vjCanvasContext.beginPath();
                        VirtualJoystick.vjCanvasContext.fillStyle = "white";
                        VirtualJoystick.vjCanvasContext.beginPath();
                        VirtualJoystick.vjCanvasContext.strokeStyle = "red";
                        VirtualJoystick.vjCanvasContext.lineWidth = 6;
                        VirtualJoystick.vjCanvasContext.arc(touch.x, touch.y, 40, 0, Math.PI * 2, true);
                        VirtualJoystick.vjCanvasContext.stroke();
                    };
                });
            }
            requestAnimationFrame(() => {
                this._drawVirtualJoystick();
            });
        }
        public virtual void releaseCanvas() {
            if (VirtualJoystick.vjCanvas) {
                document.body.removeChild(VirtualJoystick.vjCanvas);
                VirtualJoystick.vjCanvas = null;
            }
        }
    }
}
namespace BABYLON.VirtualJoystick {
    public partial class Collection < T > {
        private double _count;
        private Array < T > _collection;
        public Collection() {
            this._count = 0;
            this._collection = new Array < T > ();
        }
        public virtual double Count() {
            return this._count;
        }
        public virtual double add(string key, T item) {
            if (this._collection[key] != null) {
                return null;
            }
            this._collection[key] = item;
            return ++this._count;
        }
        public virtual double remove(string key) {
            if (this._collection[key] == null) {
                return null;
            }
            this._collection[key] = null;
            return --this._count;
        }
        public virtual void item(string key) {
            return this._collection[key];
        }
        public virtual void forEach(System.Action < T > block) {
            var key;
            foreach(key in this._collection) {
                if (this._collection.hasOwnProperty(key)) {
                    block(this._collection[key]);
                }
            }
        }
    }
    */
}