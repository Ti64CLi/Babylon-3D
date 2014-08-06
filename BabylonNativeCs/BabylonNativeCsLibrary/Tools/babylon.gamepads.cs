// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.gamepads.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    /*
    public partial class Gamepads
    {
        private Array<Gamepad> babylonGamepads = new Array<Gamepad>();
        private bool oneGamepadConnected = false;
        private bool isMonitoring = false;
        private bool gamepadEventSupported = false;//"GamepadEvent" in window;
        private bool gamepadSupportAvailable = false;//(bool)(navigator.getGamepads || !!navigator.webkitGetGamepads || !!navigator.msGetGamepads || !!navigator.webkitGamepads);
        private System.Action<Gamepad> _callbackGamepadConnected;
        private string buttonADataURL = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAEAAAABACAYAAACqaXHeAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAA9aSURBVHja7FtpbBzneX7m3otcihSpm9Z9UJalxPKhVLZlp6ktNzEaxE0CtAnQAgnSoPWPBi3syuiPwordFi5Qt2haFygCoylSV4Vby6os1I3kOLYrS65kXXQoypJJSaFEUTyXy925+rzfzC6HFFlL1kpAIe7i5czO7H7zPs97ft8MtTAMcSu/dNzirxkCZgiYIWCGgBkCZgi4hV/mDR5fSxAt+0ZiX0ucDxMSTJLK+f83BFSA6TFgK75OclshouKBFbA+xaV4k7Z+fD6sNRlmjYFXQMu4NiUVS/oHe5/ecnHo3MYxd7QthN9UcsdW6FqEPwgDOFbqpAajL2VlTrTULzj4Ow8+s4+nipSxWMoxIUkyrl/pGswFtIR7WzHgDCX77K7vfHNkbOA+AryjYZadb27OIJdzCNZBKmXw4kbk35qPsTEfJbeEkZESentHMdBfGtY142gu1bDvqV/925f4tQJlNCaj4hXX7RHXS0AFuJEAXvfHr/zmk67vPjir0V68aFEe8xtuQ6O1FHlrEXLmHBiaDUtzYBlpNYjrF+GFZfhhCcPeBQy53ehzT+H8QBe6uwfRf7l8xjKsvX/y5X98jl8fThDhJ4i46QQkrS5I6v7oX7/++77vPtLUlFnZtnIRlubvxRxnHbJmE79sxD/SqG0oZk8MFarRqufUkQAFrxcXSkfx0eB+nOggKX2jHYZhvf79r/z4L2IiipO84aYRkASfefnAX695p3P3c9mM/UufuaMVdzRvxVx7A0xaWdOMqVULJ6Z3TZv6KmHo0ztK6CkfxpHe3Th0pAuF0fLbn1u+9cmv3vW77bE3fGoSPi0BVfAvvPEHm9rPv//iooWz5m9Z/wCWZx+Go9UrN48QTD9IGMZ1cJIzTPisRQclPMrhME4W9mDfB2+i+2z/+TXz7/z2E7/85+9OIuGGE6BV3H77zm/d33nx6Ktr18zFg2t+DQude2n1tLJ8tcJ90vDhpG5Am7qTkJAQErywiLOld7G3/d9xvL0Hy1vWPbbtS3//00Q4hDeaAFXintrx1fu7+jp2r13bgofX/gaazbVkJQdLT9P6VqRFDSu2hIgXlBUBLgtCr3cce47/CMePX0Rr08qtzz7+8k8TpfKGtcKq1jPZre7oObyjdWkGd628l7AXwvMCeL7HjO6qrS8S1E5kTE9tfbiur665ccU9EB1EF9Ep0WXesEZIJb9j5/b/XUtzNrt29Rw0og2lchmBVqLo8LSAHlCixbTpddGm8Y7pjkttCCUP+JQy3FiatNuxdvUx9F4ayopO/OL9sQeEN4oA/eHn577oWPbGVes11PsrUBxjDafze1Te1VzouqnK2TgmLQljQqmrnAsT+iaPVb5b2co7EC+QhBgUeM1R1AcrsGp9Jy6+4W8U3fZ8r+e3EnOI2uaAX3l+zgNB4O9rW5/B8tY5WGo9BtOrJ4uMfUl+uj0B8HTmPXj8Pex86xVEnTDBBSE2r78fX9i09RPyZfT2A5ceIMSPwDOH8JH7Kk5+fAHtR0Zh6MZ9e7534Wc3wgO0sXLhD9OpFOa0egjGMhguD8BgTJooMfPbV1h/umz25ondcFP90IzY2iTgrfY9uH31aqSc9CeSEHkBEyITv28M8XMGc2/z0HGCpWCs8BS/9sWrDYOrJuCBZ+vu5sUfXbicia5kYGzUw4DWTwJKbApSjHuTBBjT2H68zg0MD4KlEwabZi0Y7wd85u/3O9/B6sVrPlEXeiF9nMmRxPt6Qf4y/HyIbh3HwkdF1zefGt5fUwK8wP2WAGwh02MFE/5ogYr3Qg/STL0W3d8aB1ppa+Pw0uI2Tz6/134Mg+UoIGZlZ2HMLaJYHkPICr6//RBamvPj/UA4dYKsegGrXqAXMaqNsDT6SreOY5Gu/FptCeBFN+caAphGiKFiGaOjA3AJHoGt6r7GgNbjqjo5yQkBUVHQ8PaJExjiaZ2yue12nO27gCNdHSptvf/xGdw11I2UZSmvCIJgQiJMhoEfeqpNDvUSRvUB5hMX9fUecg0aBi+Hm2uaAz633bmbm1VN8+h07LfKJdkOkQB2fL4BTlsj8No4YLG2putMSjwjp3QNvZdH8YsiExV501isFjU30lpF7D8dVfCA8sFHp7BuWYtaIwiCsCrCSDVhh9IX8k0CoHsoMQ84FrfFAE3zQAK0VaLzO9tK79XKAxSj+aYALt3XLfNipZD1v492YexrE/sP0zBgUIQIoYaflAXbz16CzyY6YKqYl8uheTarRioD7xAxCQHUpv18L1Yud+Iloujtk4zQo9WZcKURqjbHclzKvj0Gvcw8UA6oY2WqonSuGQGb5I+TJgEFEsB4daXzc0eopabcX13W0BXwgAnRZL4Q62s8ppnR/pFz/QjF+tRvxeIsY/cizGwRt83P4czACL8HdA1JUivCNGVogvdkNkgaGDNe4CvXFyJ8n+B5XGLJ1FmJXJ53AzjZKgGbatkKL5c/liNWIPO8uM/4VO2uKCQZjLmBqQAGJ4EmI8NMabDTOuyUobYXmPlCEpiqA1IkYdWSBpjpEDl6wsrF9aAjqHNOPXDyXAGprAknY5B0btOGGk/GlfE1taqofCNuuYNIJ+omOiZ1rpUHtEYWjkpWoP5EWV2sb5isA7aIQTHHxaIniNADui8PIs0Eb6SY/Z0UQc+j+mXYuoM7Vy/Age7zkBUyCZGLhRLSOYcWpfXFA1wPhqup8JNKq5UkKeoqSHxPLSoqnUQtw5ioc60IyE/VkOji8mYE2nZELNgCXLaOkGDFJBg4OzCMDEcxCfAzS1pQX5fHSNDLClLGwmwzls6vQ09hGFJYegdZ1hha2bqIBNelB5Qjog02TzpFNVEquYpMuTSYr/lcQPKPJHoRQ8W1GYO3lDgpO9pPWTEZEQGnuodg5Hyk66Lyd8fKOQQ6gqyWict7GeuWz8HQyWEFw+bB7ksF3Nk2V1nfpZTLQqSLslzXlDmHpsQ1osVoy/Solwf/GpdErpaAQUqjWxL2GWcWaSfAMIis7RBwiuCdtD1OgmNHBJCg7r4uZBnbdjaaq+3YewB+USYicY8juYPnMtloqdCjG3f39eO+3JKIAFadSiiZigBdgdcqItMxsmZbIbvUIKlzzQjoEgLGRjU2KTp8AjRCkzEnAG0mtQh8Ku0oAqok8JzP+Lw0MkB3jpKjKpapaL5WKZxafDdBqoC6O8LtyMAQhoZdzG7MwLU8FUYKPINcl+qimismRj26v2I71I3jDxfdpM41I6CTsmG4X0djKyc8RYu9t0Vl2QJbBJ5xFPiICJIg1hdhR3fs5HnWeldleZXABLA98b7Y5HtjkgwNEtbTN4iFC5oI3I1CTsAbsfVjAizJB3Qbx9HphRp6eqr3TDprSYA0FI/3ntOxbpUNM2OjpEcE6HYEWkhIKw+ICeBxi+T09F1WZU+iJq2n8fRDf4Ymu3XSrcOIgg8H9uOFn31fNUVC0oddZ7B5YxtDwlTgo66SEici2fokwCJjju0hw7J54WypQsB7tSRAza+H+nld30Y+m2b7SS+Qn9PKFl1egRciHIfWpxC8x+7tdA97+3zUcNyWX4Ci/THOoD2x/hmlQTox+3gDjWYeg/4gmF853xjBpUsjaGnJR24fu36FNzX5pmfY7EPStlSLIgb6gwk616QRYk8tS88/l/2PT/loyqbQkEmhPpNGNp1CmvtieQHvONGtL4sdy9Hjp5kkpTWmSzM7L529hErHs0cCpt2qW00BymDV3JXSU8HkAXKIjtNnedxS48m4Mr5cR9YlMrx+XTqNRmbP2ZkMOjvHKir/PNa5pouiitFjH44iZ6YwO5tFAy+eo6SdpOUJyhBQTJR+HT9HYLJaFve0PqQmTQLaVOCdmIRIWE+wrmWTzG8iAugF7qgWjSWkGbYa32EjJQTkGFv5dBZNJKCeHdb77UPXZP1rWhKLZ4Rqjv2Fz86lLMNlpusCY9BnqTNUIyTgrVhhs7rVq2KoW2TSxWlXLOCqWX4svmpzZdEjWvgQcdVWPnu+i4ClUS+HyLIFnsVf/9eBduw8eKYy2D1XMxO8Jg+IB9wl+3s/uAC3qKMpXY88m/ecnUHaSis3Na8Ab1UtaCh3j1y+sm8m9o0J+9Fv9MR4Zhw6DufTWasOebsOs+xZKHJOtvtQtertulrwV+0BtH5yWvyW7CxubsCTX9+KUQZ4ga7qmdGUFmrya8QWHwcxlReMF8Mw4QETrR8oy7tq2ivH5Tvya8n8aXZMGc4An/nRDpy52FfR8b5KCJCImt8YkYF/KDtnegfwz3sPodGajQajCTk9z/4mQ6iphMWv9AA9IeMWdyYdn+gBkVc5amwHWV6lHvVaI2YZzfinN95Ngv/htcT/p31CRNbdV8l8e++xD5HPNeHxhx5Bgf18kTN5T1kvjBfEjGjBJCai4gnjHqAnlvqS8e9NeujEjEul/NokDbai4V/2voafHD1S0evdWLeb8ojMNyly5fS//ffbcD0L33j4K4RX4rtMh/UUGLXmr6BWXN9MEFAhYfzmZ6hcXI+TpISRH8061Ui68gTWGUJP4aU9P8ZrB39S+Xkx1ummPSMkbebnJcxU1jm4D5eGhvB7j32HJcpUJHhxLIfxTZpxwGa8eKrHC51a9Tmp+N5P1RsQ01cJAwEflHw8/+pfYn/HgaQ+n7/a1vd6k+BUS2XvVD401TXhu488gQ0r71QUuLJsrWT8mSYtfkBMm0BAmFhNrgDX4oRqqeaJMw4c6TyIv/qPP0Xf8KUJ6sXuP1XluuEEyGsD5TXKgsqBNQvW4RtbnkDb4ttJQlGt/IQqLMJE7tWqOSBZCSrL6dFSqq3AnzhzDC/tewHt5w4nr3suvgN0+P8o3TeegFe3vYDHtj+xhLt/Q3kkeW5d693YuuHXsWHZPcixW4tCwo+trVU9QEs8G6HFqW5kdBiHTu3H64dfxpGuK8r665Tv7tz2D6e/tP23cT0E1OA5QR2iiIbs1i9u/9qTPPC12CtwlIofjZVvW/BZ3LVsC5bPW4u5DQuxaPay2NpRIuy61IkLA+dw8hdHceDUPpw49z9TXUysvWPXtl3bQ4yQtMJ1a18DAsbvRO/atvM5DXXPPbp9yzP8+GXBXTkngKYBdTWvE5RXdm87+HQEfLh2T57UIAdM95Js9+04LKSDbLzG31+Omxpx9xfxKR6AukkhMP0aKuUHsag5VEzE3fGSddsUVu6KFzIE+H/iJry0mX+bu8VfMwTMEDBDwAwBMwTMEHALv/5XgAEASpR5N6rB30UAAAAASUVORK5CYII=";
        private static HTMLElement gamepadDOMInfo;

        private Web.Window window;
        private Web.Document document;

        public Gamepads(System.Action<Gamepad> ongamedpadconnected)
        {
            this._callbackGamepadConnected = ongamedpadconnected;
            if (this.gamepadSupportAvailable)
            {
                if (this.gamepadEventSupported)
                {
                    window.addEventListener("gamepadconnected", (object evt) =>
                    {
                        this._onGamepadConnected(evt);
                    }, false);
                    window.addEventListener("gamepaddisconnected", (object evt) =>
                    {
                        this._onGamepadDisconnected(evt);
                    }, false);
                }
                else
                {
                    this._startMonitoringGamepads();
                }
                if (!this.oneGamepadConnected)
                {
                    this._insertGamepadDOMInstructions();
                }
            }
            else
            {
                this._insertGamepadDOMNotSupported();
            }
        }
        private void _insertGamepadDOMInstructions()
        {
            Gamepads.gamepadDOMInfo = (HTMLDivElement)document.createElement("div");
            var buttonAImage = (HTMLImageElement)document.createElement("img");
            buttonAImage.src = this.buttonADataURL;
            var spanMessage = (HTMLSpanElement)document.createElement("span");
            spanMessage.innerHTML = "<strong>to activate gamepad</strong>";
            Gamepads.gamepadDOMInfo.appendChild(buttonAImage);
            Gamepads.gamepadDOMInfo.appendChild(spanMessage);
            Gamepads.gamepadDOMInfo.style.position = "absolute";
            Gamepads.gamepadDOMInfo.style.width = "100%";
            Gamepads.gamepadDOMInfo.style.height = "48px";
            Gamepads.gamepadDOMInfo.style.bottom = "0px";
            Gamepads.gamepadDOMInfo.style.backgroundColor = "rgba(1, 1, 1, 0.15)";
            Gamepads.gamepadDOMInfo.style.textAlign = "center";
            Gamepads.gamepadDOMInfo.style.zIndex = "10";
            buttonAImage.style.position = "relative";
            buttonAImage.style.bottom = "8px";
            spanMessage.style.position = "relative";
            spanMessage.style.fontSize = "32px";
            spanMessage.style.bottom = "32px";
            spanMessage.style.color = "green";
            document.body.appendChild(Gamepads.gamepadDOMInfo);
        }
        private void _insertGamepadDOMNotSupported()
        {
            Gamepads.gamepadDOMInfo = (HTMLDivElement)document.createElement("div");
            var spanMessage = (HTMLSpanElement)document.createElement("span");
            spanMessage.innerHTML = "<strong>gamepad not supported</strong>";
            Gamepads.gamepadDOMInfo.appendChild(spanMessage);
            Gamepads.gamepadDOMInfo.style.position = "absolute";
            Gamepads.gamepadDOMInfo.style.width = "100%";
            Gamepads.gamepadDOMInfo.style.height = "40px";
            Gamepads.gamepadDOMInfo.style.bottom = "0px";
            Gamepads.gamepadDOMInfo.style.backgroundColor = "rgba(1, 1, 1, 0.15)";
            Gamepads.gamepadDOMInfo.style.textAlign = "center";
            Gamepads.gamepadDOMInfo.style.zIndex = "10";
            spanMessage.style.position = "relative";
            spanMessage.style.fontSize = "32px";
            spanMessage.style.color = "red";
            document.body.appendChild(Gamepads.gamepadDOMInfo);
        }
        public virtual void dispose()
        {
            document.body.removeChild(Gamepads.gamepadDOMInfo);
        }
        private void _onGamepadConnected(object evt)
        {
            var newGamepad = this._addNewGamepad(evt.gamepad);
            if (this._callbackGamepadConnected)
                this._callbackGamepadConnected(newGamepad);
            this._startMonitoringGamepads();
        }
        private Gamepad _addNewGamepad(object gamepad)
        {
            if (!this.oneGamepadConnected)
            {
                this.oneGamepadConnected = true;
                if (Gamepads.gamepadDOMInfo)
                {
                    document.body.removeChild(Gamepads.gamepadDOMInfo);
                    Gamepads.gamepadDOMInfo = null;
                }
            }
            var newGamepad;
            if (((string)gamepad.id).search("Xbox 360") != -1 || ((string)gamepad.id).search("xinput") != -1)
            {
                newGamepad = new BABYLON.Xbox360Pad(gamepad.id, gamepad.index, gamepad);
            }
            else
            {
                newGamepad = new BABYLON.GenericPad(gamepad.id, gamepad.index, gamepad);
            }
            this.babylonGamepads.Add(newGamepad);
            return newGamepad;
        }
        private void _onGamepadDisconnected(object evt)
        {
            foreach (var i in this.babylonGamepads)
            {
                if (this.babylonGamepads[i].index == evt.gamepad.index)
                {
                    this.babylonGamepads.splice(i, 1);
                    break;
                }
            }
            if (this.babylonGamepads.Length == 0)
            {
                this._stopMonitoringGamepads();
            }
        }
        private void _startMonitoringGamepads()
        {
            if (!this.isMonitoring)
            {
                this.isMonitoring = true;
                this._checkGamepadsStatus();
            }
        }
        private void _stopMonitoringGamepads()
        {
            this.isMonitoring = false;
        }
        private void _checkGamepadsStatus()
        {
            this._updateGamepadObjects();
            foreach (var i in this.babylonGamepads)
            {
                this.babylonGamepads[i].update();
            }
            if (this.isMonitoring)
            {
                if (window.requestAnimationFrame)
                {
                    window.requestAnimationFrame(() =>
                    {
                        this._checkGamepadsStatus();
                    });
                }
                else
                    if (window.mozRequestAnimationFrame)
                    {
                        window.mozRequestAnimationFrame(() =>
                        {
                            this._checkGamepadsStatus();
                        });
                    }
                    else
                        if (window.webkitRequestAnimationFrame)
                        {
                            window.webkitRequestAnimationFrame(() =>
                            {
                                this._checkGamepadsStatus();
                            });
                        }
            }
        }
        private void _updateGamepadObjects()
        {
            var gamepads = (navigator.getGamepads) ? navigator.getGamepads() : ((navigator.webkitGetGamepads) ? navigator.webkitGetGamepads() : new Array<object>());
            for (var i = 0; i < gamepads.Length; i++)
            {
                if (gamepads[i])
                {
                    if (!(this.babylonGamepads.Contains(gamepads[i].index)))
                    {
                        var newGamepad = this._addNewGamepad(gamepads[i]);
                        if (this._callbackGamepadConnected)
                        {
                            this._callbackGamepadConnected(newGamepad);
                        }
                    }
                    else
                    {
                        this.babylonGamepads[i].browserGamepad = gamepads[i];
                    }
                }
            }
        }
    }
    public partial class StickValues
    {
        public dynamic x;
        public dynamic y;
        public StickValues(object x, object y) {
            this.x = x;
            this.y = y;
        }
    }
    public partial class Gamepad
    {
        private StickValues _leftStick;
        private StickValues _rightStick;
        private System.Action<StickValues> _onleftstickchanged;
        private System.Action<StickValues> _onrightstickchanged;
        public string id;
        public double index;
        public dynamic browserGamepad;
        public Gamepad(string id, double index, object browserGamepad)
        {
            this.id = id;
            this.index = index;
            this.broeserGamepad = browserGamepad;
     
            if (this.browserGamepad.axes.Length >= 2)
            {
                this._leftStick = new { };
            }
            if (this.browserGamepad.axes.Length >= 4)
            {
                this._rightStick = new { };
            }
        }
        public virtual void onleftstickchanged(System.Action<StickValues> callback)
        {
            this._onleftstickchanged = callback;
        }
        public virtual void onrightstickchanged(System.Action<StickValues> callback)
        {
            this._onrightstickchanged = callback;
        }
        public virtual StickValues leftStick
        {
            get
            {
                return this._leftStick;
            }
            set
            {
                if (this._onleftstickchanged && (this._leftStick.x != newValues.x || this._leftStick.y != newValues.y))
                {
                    this._onleftstickchanged(newValues);
                }
                this._leftStick = newValues;
            }
        }
        public virtual StickValues rightStick
        {
            get
            {
                return this._rightStick;
            }
            set
            {
                if (this._onrightstickchanged && (this._rightStick.x != newValues.x || this._rightStick.y != newValues.y))
                {
                    this._onrightstickchanged(newValues);
                }
                this._rightStick = newValues;
            }
        }
        public virtual void update()
        {
            if (this._leftStick)
            {
                this.leftStick = new { };
            }
            if (this._rightStick)
            {
                this.rightStick = new { };
            }
        }
    }
    public partial class GenericPad : Gamepad
    {
        private Array<double> _buttons;
        private System.Action<double> _onbuttondown;
        private System.Action<double> _onbuttonup;
        public virtual void onbuttondown(System.Action<double> callback)
        {
            this._onbuttondown = callback;
        }
        public virtual void onbuttonup(System.Action<double> callback)
        {
            this._onbuttonup = callback;
        }
        public string id;
        public double index;
        public dynamic gamepad;
        public GenericPad(string id, double index, object gamepad)
            : base(id, index, gamepad)
        {
            this.id = id;
            this.index = index;
            this.gamepad = gamepad;
            this._buttons = new Array(gamepad.buttons.Length);
        }
        private double _setButtonValue(double newValue, double currentValue, double buttonIndex)
        {
            if (newValue != currentValue)
            {
                if (this._onbuttondown && newValue == 1)
                {
                    this._onbuttondown(buttonIndex);
                }
                if (this._onbuttonup && newValue == 0)
                {
                    this._onbuttonup(buttonIndex);
                }
            }
            return newValue;
        }
        public virtual void update()
        {
            base.update();
            for (var index = 0; index < this._buttons.Length; index++)
            {
                this._buttons[index] = this._setButtonValue(this.gamepad.buttons[index].value, this._buttons[index], index);
            }
        }
    }
    public enum Xbox360Button
    {
        A, B, X, Y, Start, Back, LB, RB, LeftStick, RightStick
    }
    public enum Xbox360Dpad
    {
        Up, Down, Left, Right
    }
    public partial class Xbox360Pad : Gamepad
    {
        private double _leftTrigger = 0;
        private double _rightTrigger = 0;
        private System.Action<double> _onlefttriggerchanged;
        private System.Action<double> _onrighttriggerchanged;
        private System.Action<Xbox360Button> _onbuttondown;
        private System.Action<Xbox360Button> _onbuttonup;
        private System.Action<Xbox360Dpad> _ondpaddown;
        private System.Action<Xbox360Dpad> _ondpadup;
        private double _buttonA = 0;
        private double _buttonB = 0;
        private double _buttonX = 0;
        private double _buttonY = 0;
        private double _buttonBack = 0;
        private double _buttonStart = 0;
        private double _buttonLB = 0;
        private double _buttonRB = 0;
        private double _buttonLeftStick = 0;
        private double _buttonRightStick = 0;
        private double _dPadUp = 0;
        private double _dPadDown = 0;
        private double _dPadLeft = 0;
        private double _dPadRight = 0;
        public virtual void onlefttriggerchanged(System.Action<double> callback)
        {
            this._onlefttriggerchanged = callback;
        }
        public virtual void onrighttriggerchanged(System.Action<double> callback)
        {
            this._onrighttriggerchanged = callback;
        }
        public virtual double leftTrigger
        {
            get
            {
                return this._leftTrigger;
            }
            set
            {
                if (this._onlefttriggerchanged && this._leftTrigger != newValue)
                {
                    this._onlefttriggerchanged(newValue);
                }
                this._leftTrigger = newValue;
            }
        }
        public virtual double rightTrigger
        {
            get
            {
                return this._rightTrigger;
            }
            set
            {
                if (this._onrighttriggerchanged && this._rightTrigger != newValue)
                {
                    this._onrighttriggerchanged(newValue);
                }
                this._rightTrigger = newValue;
            }
        }
        public virtual void onbuttondown(System.Action<Xbox360Button> callback)
        {
            this._onbuttondown = callback;
        }
        public virtual void onbuttonup(System.Action<Xbox360Button> callback)
        {
            this._onbuttonup = callback;
        }
        public virtual void ondpaddown(System.Action<Xbox360Dpad> callback)
        {
            this._ondpaddown = callback;
        }
        public virtual void ondpadup(System.Action<Xbox360Dpad> callback)
        {
            this._ondpadup = callback;
        }
        private double _setButtonValue(double newValue, double currentValue, Xbox360Button buttonType)
        {
            if (newValue != currentValue)
            {
                if (this._onbuttondown && newValue == 1)
                {
                    this._onbuttondown(buttonType);
                }
                if (this._onbuttonup && newValue == 0)
                {
                    this._onbuttonup(buttonType);
                }
            }
            return newValue;
        }
        private double _setDPadValue(double newValue, double currentValue, Xbox360Dpad buttonType)
        {
            if (newValue != currentValue)
            {
                if (this._ondpaddown && newValue == 1)
                {
                    this._ondpaddown(buttonType);
                }
                if (this._ondpadup && newValue == 0)
                {
                    this._ondpadup(buttonType);
                }
            }
            return newValue;
        }
        public virtual double buttonA
        {
            get
            {
                return this._buttonA;
            }
            set
            {
                this._buttonA = this._setButtonValue(value, this._buttonA, Xbox360Button.A);
            }
        }
        public virtual double buttonB
        {
            get
            {
                return this._buttonB;
            }
            set
            {
                this._buttonB = this._setButtonValue(value, this._buttonB, Xbox360Button.B);
            }
        }
        public virtual double buttonX
        {
            get
            {
                return this._buttonX;
            }
            set
            {
                this._buttonX = this._setButtonValue(value, this._buttonX, Xbox360Button.X);
            }
        }
        public virtual double buttonY
        {
            get
            {
                return this._buttonY;
            }
            set
            {
                this._buttonY = this._setButtonValue(value, this._buttonY, Xbox360Button.Y);
            }
        }
        public virtual double buttonStart
        {
            get
            {
                return this._buttonStart;
            }
            set
            {
                this._buttonStart = this._setButtonValue(value, this._buttonStart, Xbox360Button.Start);
            }
        }
        public virtual double buttonBack
        {
            get
            {
                return this._buttonBack;
            }
            set
            {
                this._buttonBack = this._setButtonValue(value, this._buttonBack, Xbox360Button.Back);
            }
        }
        public virtual double buttonLB
        {
            get
            {
                return this._buttonLB;
            }
            set
            {
                this._buttonLB = this._setButtonValue(value, this._buttonLB, Xbox360Button.LB);
            }
        }
        public virtual double buttonRB
        {
            get
            {
                return this._buttonRB;
            }
            set
            {
                this._buttonRB = this._setButtonValue(value, this._buttonRB, Xbox360Button.RB);
            }
        }
        public virtual double buttonLeftStick
        {
            get
            {
                return this._buttonLeftStick;
            }
            set
            {
                this._buttonLeftStick = this._setButtonValue(value, this._buttonLeftStick, Xbox360Button.LeftStick);
            }
        }
        public virtual double buttonRightStick
        {
            get
            {
                return this._buttonRightStick;
            }
            set
            {
                this._buttonRightStick = this._setButtonValue(value, this._buttonRightStick, Xbox360Button.RightStick);
            }
        }
        public virtual double dPadUp
        {
            get
            {
                return this._dPadUp;
            }
            set
            {
                this._dPadUp = this._setDPadValue(value, this._dPadUp, Xbox360Dpad.Up);
            }
        }
        public virtual double dPadDown
        {
            get
            {
                return this._dPadDown;
            }
            set
            {
                this._dPadDown = this._setDPadValue(value, this._dPadDown, Xbox360Dpad.Down);
            }
        }
        public virtual double dPadLeft
        {
            get
            {
                return this._dPadLeft;
            }
            set
            {
                this._dPadLeft = this._setDPadValue(value, this._dPadLeft, Xbox360Dpad.Left);
            }
        }
        public virtual double dPadRight
        {
            get
            {
                return this._dPadRight;
            }
            set
            {
                this._dPadRight = this._setDPadValue(value, this._dPadRight, Xbox360Dpad.Right);
            }
        }
        public virtual void update()
        {
            base.update();
            this.buttonA = this.browserGamepad.buttons[0].value;
            this.buttonB = this.browserGamepad.buttons[1].value;
            this.buttonX = this.browserGamepad.buttons[2].value;
            this.buttonY = this.browserGamepad.buttons[3].value;
            this.buttonLB = this.browserGamepad.buttons[4].value;
            this.buttonRB = this.browserGamepad.buttons[5].value;
            this.leftTrigger = this.browserGamepad.buttons[6].value;
            this.rightTrigger = this.browserGamepad.buttons[7].value;
            this.buttonBack = this.browserGamepad.buttons[8].value;
            this.buttonStart = this.browserGamepad.buttons[9].value;
            this.buttonLeftStick = this.browserGamepad.buttons[10].value;
            this.buttonRightStick = this.browserGamepad.buttons[11].value;
            this.dPadUp = this.browserGamepad.buttons[12].value;
            this.dPadDown = this.browserGamepad.buttons[13].value;
            this.dPadLeft = this.browserGamepad.buttons[14].value;
            this.dPadRight = this.browserGamepad.buttons[15].value;
        }
    }
     */
}

/// <summary>
/// </summary>
public partial interface Navigator
{
    /// <summary>
    /// </summary>
    /// <param name="func">
    /// </param>
    /// <returns>
    /// </returns>
    object getGamepads(object func = null);

    /// <summary>
    /// </summary>
    /// <param name="func">
    /// </param>
    /// <returns>
    /// </returns>
    object msGetGamepads(object func = null);

    /// <summary>
    /// </summary>
    /// <param name="func">
    /// </param>
    /// <returns>
    /// </returns>
    object webkitGamepads(object func = null);

    /// <summary>
    /// </summary>
    /// <param name="func">
    /// </param>
    /// <returns>
    /// </returns>
    object webkitGetGamepads(object func = null);
}