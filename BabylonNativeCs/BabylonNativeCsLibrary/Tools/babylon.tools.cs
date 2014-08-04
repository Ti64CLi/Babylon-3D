using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial interface IAnimatable : IAnimatableProperty
    {
        Array<Animation> animations { get; set; }

        Array<IAnimatable> getAnimatables();

        void markAsDirty(string propertyName);
    }
    public partial class Tools
    {
        // Screenshots
        private static HTMLCanvasElement screenshotCanvas;

        // FPS
        private static int fpsRange = 60;
        private static Array<int> previousFramesDuration = new Array<int>();
        private static int fps = 60;
        private static int deltaTime = 0;

        object cloneValue(object source, object destinationObject)
        {
            if (source == null)
                return null;

            if (source is Mesh)
            {
                return null;
            }

            var subMesh = source as SubMesh;
            if (subMesh != null)
            {
                return subMesh.clone(destinationObject as AbstractMesh);
            }

            var abstractMesh = source as AbstractMesh;
            if (abstractMesh != null)
            {
                return abstractMesh.clone();
            }

            return null;
        }

        public static string BaseUrl = "";
        public static string GetFilename(string path)
        {
            var index = path.LastIndexOf("/");
            if (index < 0)
                return path;
            return path.Substring(index + 1);
        }
        public static string GetDOMTextContent(HTMLElement element)
        {
            var result = "";
            var child = element.firstChild;
            while (child != null)
            {
                if (child.nodeType == 3)
                {
                    result += child.textContent;
                }
                child = child.nextSibling;
            }

            return result;
        }
        public static double ToDegrees(double angle)
        {
            return angle * 180 / Math.PI;
        }
        public static double ToRadians(double angle)
        {
            return angle * Math.PI / 180;
        }
        public static MinMax ExtractMinAndMaxIndexed(Array<double> positions, Array<int> indices, int indexStart, int indexCount)
        {
            var minimum = new Vector3(double.MaxValue, double.MaxValue, double.MaxValue);
            var maximum = new Vector3(-double.MaxValue, -double.MaxValue, -double.MaxValue);
            for (var index = indexStart; index < indexStart + indexCount; index++)
            {
                var current = new Vector3(positions[indices[index] * 3], positions[indices[index] * 3 + 1], positions[indices[index] * 3 + 2]);
                minimum = BABYLON.Vector3.Minimize(current, minimum);
                maximum = BABYLON.Vector3.Maximize(current, maximum);
            }
            return new MinMax { minimum = minimum, maximum = maximum };
        }
        public static MinMax ExtractMinAndMax(Array<double> positions, int start, int count)
        {
            var minimum = new Vector3(double.MaxValue, double.MaxValue, double.MaxValue);
            var maximum = new Vector3(-double.MaxValue, -double.MaxValue, -double.MaxValue);
            for (var index = start; index < start + count; index++)
            {
                var current = new Vector3(positions[index * 3], positions[index * 3 + 1], positions[index * 3 + 2]);
                minimum = BABYLON.Vector3.Minimize(current, minimum);
                maximum = BABYLON.Vector3.Maximize(current, maximum);
            }
            return new MinMax { minimum = minimum, maximum = maximum };
        }
        public static string GetPointerPrefix()
        {
            var eventPrefix = "pointer";
            /*
            if (!navigator.pointerEnabled)
            {
                eventPrefix = "mouse";
            }
            */
            return eventPrefix;
        }
        public static void QueueNewFrame(FrameRequestCallback func)
        {
            Engine.window.requestAnimationFrame(func);
        }
        public static void RequestFullscreen(object element)
        {
            /*
            if (element.requestFullscreen)
                element.requestFullscreen();
            else
                if (element.msRequestFullscreen)
                    element.msRequestFullscreen();
                else
                    if (element.webkitRequestFullscreen)
                        element.webkitRequestFullscreen();
                    else
                        if (element.mozRequestFullScreen)
                            element.mozRequestFullScreen();
             */

            throw new NotImplementedException();
        }
        public static void ExitFullscreen()
        {
            /*
            if (document.exitFullscreen)
            {
                document.exitFullscreen();
            }
            else
                if (document.mozCancelFullScreen)
                {
                    document.mozCancelFullScreen();
                }
                else
                    if (document.webkitCancelFullScreen)
                    {
                        document.webkitCancelFullScreen();
                    }
                    else
                        if (document.msCancelFullScreen)
                        {
                            document.msCancelFullScreen();
                        }
             */
            throw new NotImplementedException();
        }
        public static string CleanUrl(string url)
        {
            url = url.Replace("#", "%23");
            return url;
        }
        public static HTMLImageElement LoadImage(string url, Action<HTMLImageElement> onload, Action<HTMLImageElement, object> onerror, object database)
        {
            /*
            url = Tools.CleanUrl(url);
            var img = new Image();
            img.crossOrigin = "anonymous";
            img.onload = () => {
                onload(img);
            };
            img.onerror = (err) => {
                onerror(img, err);
            };
            var noIndexedDB = () => {
                img.src = url;
            };
            var loadFromIndexedDB = () => {
                database.loadImageFromDB(url, img);
            };
            if (database && database.enableTexturesOffline && BABYLON.Database.isUASupportingBlobStorage) {
                database.openAsync(loadFromIndexedDB, noIndexedDB);
            } else {
                if (url.indexOf("file:") == -1) {
                    noIndexedDB();
                } else {
                    try {
                        var textureName = url.Substring(5);
                        var blobURL;
                        try {
                            blobURL = URL.createObjectURL(BABYLON.FilesInput.FilesTextures[textureName], new {});
                        } catch (Exception ex) {
                            blobURL = URL.createObjectURL(BABYLON.FilesInput.FilesTextures[textureName]);
                        }
                        img.src = blobURL;
                    } catch (Exception e) {
                        Tools.Log("Error while trying to load texture: " + textureName);
                        img.src = null;
                    }
                }
            }
            return img;
             */

            throw new NotImplementedException();
        }
        public static void LoadFile(string url, System.Action<byte[]> callback, System.Action<object> progressCallBack = null, object database = null, bool useArrayBuffer = false)
        {
            /*
            url = Tools.CleanUrl(url);
            var noIndexedDB = () => {
                var request = new XMLHttpRequest();
                var loadUrl = Tools.BaseUrl + url;
                request.open("GET", loadUrl, true);
                if (useArrayBuffer) {
                    request.responseType = "arraybuffer";
                }
                request.onprogress = progressCallBack;
                request.onreadystatechange = () => {
                    if (request.readyState == 4) {
                        if (request.status == 200 || BABYLON.Tools.ValidateXHRData(request, (!useArrayBuffer) ? 1 : 6)) {
                            callback((!useArrayBuffer) ? request.responseText : request.response);
                        } else {
                            throw new Error("Error status: " + request.status + " - Unable to load " + loadUrl);
                        }
                    }
                };
                request.send(null);
            };
            var loadFromIndexedDB = () => {
                database.loadFileFromDB(url, callback, progressCallBack, noIndexedDB, useArrayBuffer);
            };
            if (url.indexOf("file:") != -1) {
                var fileName = url.Substring(5);
                BABYLON.Tools.ReadFile(BABYLON.FilesInput.FilesToLoad[fileName], callback, progressCallBack, true);
            } else {
                if (database && database.enableSceneOffline) {
                    database.openAsync(loadFromIndexedDB, noIndexedDB);
                } else {
                    noIndexedDB();
                }
            }
             */

            throw new NotImplementedException();
        }

        public static void LoadFile(
            string url, System.Action<string> callback, System.Action<object> progressCallBack = null, object database = null, bool useArrayBuffer = false)
        {
            throw new NotImplementedException();
        }

        public static void ReadFile(object fileToLoad, object callback, object progressCallBack, bool useArrayBuffer = false)
        {
            /*
            FileReader reader = null;// new FileReader();
            reader.onload = (e) => {
                callback(e.target.result);
            };
            reader.onprogress = progressCallBack;
            if (!useArrayBuffer) {
                reader.readAsText(fileToLoad);
            } else {
                reader.readAsArrayBuffer(fileToLoad);
            }
            */

            throw new NotImplementedException();
        }
        public static void CheckExtends(Vector3 v, Vector3 min, Vector3 Max)
        {
            if (v.x < min.x)
                min.x = v.x;
            if (v.y < min.y)
                min.y = v.y;
            if (v.z < min.z)
                min.z = v.z;
            if (v.x > Max.x)
                Max.x = v.x;
            if (v.y > Max.y)
                Max.y = v.y;
            if (v.z > Max.z)
                Max.z = v.z;
        }
        public static bool WithinEpsilon(double a, double b)
        {
            var num = a - b;
            return -1.401298E-45 <= num && num <= 1.401298E-45;
        }
        public static void DeepCopy(object source, object destination, Array<string> doNotCopyList = null, Array<string> mustCopyList = null)
        {
            /*
            foreach(var prop in source) {
                if (prop[0] == "_" && (!mustCopyList || mustCopyList.indexOf(prop) == -1)) {
                    continue;
                }
                if (doNotCopyList && doNotCopyList.indexOf(prop) != -1) {
                    continue;
                }
                var sourceValue = source[prop];
                var typeOfSourceValue = typeof(sourceValue);
                if (typeOfSourceValue == "function") {
                    continue;
                }
                if (typeOfSourceValue == "object") {
                    if (sourceValue is Array) {
                        destination[prop] = new Array < object > ();
                        if (sourceValue.Length > 0) {
                            if (typeof(sourceValue[0]) == "object") {
                                for (var index = 0; index < sourceValue.Length; index++) {
                                    var clonedValue = cloneValue(sourceValue[index], destination);
                                    if (destination[prop].indexOf(clonedValue) == -1) {
                                        destination[prop].push(clonedValue);
                                    }
                                }
                            } else {
                                destination[prop] = sourceValue.slice(0);
                            }
                        }
                    } else {
                        destination[prop] = cloneValue(sourceValue, destination);
                    }
                } else {
                    destination[prop] = sourceValue;
                }
            }
            */

            throw new NotImplementedException();
        }
        public static bool IsEmpty(object obj)
        {
            /*
            foreach(var i in obj) {
                return false;
            }
            return true;
            */

            throw new NotImplementedException();
        }
        public static void RegisterTopRootEvents(Array<EventDts> events)
        {
            for (var index = 0; index < events.Length; index++)
            {
                var _event = events[index];
                Engine.window.addEventListener(_event.name, _event.handler, false);
                try
                {
                    if (Engine.window.parent != null)
                    {
                        Engine.window.parent.addEventListener(_event.name, _event.handler, false);
                    }
                }
                catch (Exception) { }
            }
        }
        public static void UnregisterTopRootEvents(Array<EventDts> events)
        {
            for (var index = 0; index < events.Length; index++)
            {
                var _event = events[index];
                Engine.window.removeEventListener(_event.name, _event.handler);
                try
                {
                    if (Engine.window.parent != null)
                    {
                        Engine.window.parent.removeEventListener(_event.name, _event.handler);
                    }
                }
                catch (Exception) { }
            }
        }
        public static int GetFps()
        {
            return fps;
        }
        public static int GetDeltaTime()
        {
            return deltaTime;
        }
        public static void _MeasureFps()
        {
            previousFramesDuration.push(new Date().getTime());
            var Length = previousFramesDuration.Length;
            if (Length >= 2)
            {
                deltaTime = previousFramesDuration[Length - 1] - previousFramesDuration[Length - 2];
            }
            if (Length >= fpsRange)
            {
                if (Length > fpsRange)
                {
                    previousFramesDuration.RemoveAt(0);
                    Length = previousFramesDuration.Length;
                }
                var sum = 0;
                for (var id = 0; id < Length - 1; id++)
                {
                    sum += previousFramesDuration[id + 1] - previousFramesDuration[id];
                }
                fps = (int)(1000.0 / (sum / (Length - 1)));
            }
        }
        public static void CreateScreenshot(Engine engine, Camera camera, object size)
        {
            /*
            var width;
            var height;
            var scene = camera.getScene();
            var previousCamera = null;
            if (scene.activeCamera != camera) {
                previousCamera = scene.activeCamera;
                scene.activeCamera = camera;
            }
            if (size.precision) {
                width = Math.round(engine.getRenderWidth() * size.precision);
                height = Math.round(width / engine.getAspectRatio(camera));
                size = new {};
            } else
            if (size.width && size.height) {
                width = size.width;
                height = size.height;
            } else
            if (size.width && !size.height) {
                width = size.width;
                height = Math.round(width / engine.getAspectRatio(camera));
                size = new {};
            } else
            if (size.height && !size.width) {
                height = size.height;
                width = Math.round(height * engine.getAspectRatio(camera));
                size = new {};
            } else
            if (!isNaN(size)) {
                height = size;
                width = size;
            } else {
                Tools.Error("Invalid 'size' parameter !");
                return;
            }
            var texture = new RenderTargetTexture("screenShot", size, engine.scenes[0], false, false);
            texture.renderList = engine.scenes[0].meshes;
            texture.onAfterRender = () => {
                var numberOfChannelsByLine = width * 4;
                var halfHeight = height / 2;
                var data = engine.readPixels(0, 0, width, height);
                for (var i = 0; i < halfHeight; i++) {
                    for (var j = 0; j < numberOfChannelsByLine; j++) {
                        var currentCell = j + i * numberOfChannelsByLine;
                        var targetLine = height - i - 1;
                        var targetCell = j + targetLine * numberOfChannelsByLine;
                        var temp = data[currentCell];
                        data[currentCell] = data[targetCell];
                        data[targetCell] = temp;
                    }
                }
                if (!screenshotCanvas) {
                    screenshotCanvas = document.createElement("canvas");
                }
                screenshotCanvas.width = width;
                screenshotCanvas.height = height;
                var context = screenshotCanvas.getContext("2d");
                var imageData = context.createImageData(width, height);
                imageData.data.set(data);
                context.putImageData(imageData, 0, 0);
                var base64Image = screenshotCanvas.toDataURL();
                if (("download" in document.createElement("a"))) {
                    var a = window.document.createElement("a");
                    a.href = base64Image;
                    var date = new Date();
                    var stringDate = date.getFullYear() + "/" + date.getMonth() + "/" + date.getDate() + "-" + date.getHours() + ":" + date.getMinutes();
                    a.setAttribute("download", "screenshot-" + stringDate + ".png");
                    window.document.body.appendChild(a);
                    a.addEventListener("click", () => {
                        a.parentElement.removeChild(a);
                    });
                    a.click();
                } else {
                    var newWindow = window.open("");
                    var img = newWindow.document.createElement("img");
                    img.src = base64Image;
                    newWindow.document.body.appendChild(img);
                }
            };
            texture.render(true);
            texture.dispose();
            if (previousCamera) {
                scene.activeCamera = previousCamera;
            }
            */

            throw new NotImplementedException();
        }
        public static bool ValidateXHRData(XMLHttpRequest xhr, int dataType = 7)
        {
            /*
            try
            {
                if ((dataType & 1) > 0)
                {
                    if (xhr.responseText != null && xhr.responseText.Length > 0)
                    {
                        return true;
                    }
                    else
                        if (dataType == 1)
                        {
                            return false;
                        }
                }
                if ((dataType & 2) > 0)
                {
                    var tgaHeader = BABYLON.Internals.TGATools.GetTGAHeader(xhr.response);
                    if (tgaHeader.width && tgaHeader.height && tgaHeader.width > 0 && tgaHeader.height > 0)
                    {
                        return true;
                    }
                    else
                        if (dataType == 2)
                        {
                            return false;
                        }
                }
                if ((dataType & 4) > 0)
                {
                    var ddsHeader = new Uint8Array(xhr.response, 0, 3);
                    if (ddsHeader[0] == 68 && ddsHeader[1] == 68 && ddsHeader[2] == 83)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e) { }
            return false;
            */

            throw new NotImplementedException();
        }
        private static int _NoneLogLevel = 0;
        private static int _MessageLogLevel = 1;
        private static int _WarningLogLevel = 2;
        private static int _ErrorLogLevel = 4;
        static int NoneLogLevel
        {
            get
            {
                return Tools._NoneLogLevel;
            }
        }
        static int MessageLogLevel
        {
            get
            {
                return Tools._MessageLogLevel;
            }
        }
        static int WarningLogLevel
        {
            get
            {
                return Tools._WarningLogLevel;
            }
        }
        static int ErrorLogLevel
        {
            get
            {
                return Tools._ErrorLogLevel;
            }
        }
        static int AllLogLevel
        {
            get
            {
                return Tools._MessageLogLevel | Tools._WarningLogLevel | Tools._ErrorLogLevel;
            }
        }
        private static string _FormatMessage(string message)
        {
            Func<int, string> padStr = (i) => ((i < 10)) ? "0" + i : "" + i;
            var date = new Date();
            return "BJS - [" + padStr(date.getHours()) + ":" + padStr(date.getMinutes()) + ":" + padStr(date.getSeconds()) + "]: " + message;
        }
        public static System.Action<string> Log = Tools._LogEnabled;
        private static void _LogDisabled(string message) { }
        private static void _LogEnabled(string message)
        {
            Engine.console.log(Tools._FormatMessage(message));
        }
        public static System.Action<string> Warn = Tools._WarnEnabled;
        private static void _WarnDisabled(string message) { }
        private static void _WarnEnabled(string message)
        {
            Engine.console.warn(Tools._FormatMessage(message));
        }
        public static System.Action<string> Error = Tools._ErrorEnabled;
        private static void _ErrorDisabled(string message) { }
        private static void _ErrorEnabled(string message)
        {
            Engine.console.error(Tools._FormatMessage(message));
        }
        public static int LogLevels
        {
            set
            {
                if ((value & Tools.MessageLogLevel) == Tools.MessageLogLevel)
                {
                    Tools.Log = Tools._LogEnabled;
                }
                else
                {
                    Tools.Log = Tools._LogDisabled;
                }
                if ((value & Tools.WarningLogLevel) == Tools.WarningLogLevel)
                {
                    Tools.Warn = Tools._WarnEnabled;
                }
                else
                {
                    Tools.Warn = Tools._WarnDisabled;
                }
                if ((value & Tools.ErrorLogLevel) == Tools.ErrorLogLevel)
                {
                    Tools.Error = Tools._ErrorEnabled;
                }
                else
                {
                    Tools.Error = Tools._ErrorDisabled;
                }
            }
        }
    }
}