using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public interface IAnimatable {
Array<Animation> animations;
}
public interface ISize {
float width;
float height;
}
var screenshotCanvas;
var fpsRange = 60;
var previousFramesDuration = new Array<object>();
var fps = 60;
var deltaTime = 0;
var cloneValue = (dynamic source, dynamic destinationObject) => {
if (!source) 
return null;
if (sourceisMesh) 
{
return null;
}
if (sourceisSubMesh) 
{
return source.clone(destinationObject);
}
else 
if (source.clone) 
{
return source.clone();
}
return null;
}
;
public class Tools {
dynamic BaseUrl="\"";
public static virtual string GetFilename(string path) {
var index = path.lastIndexOf("");
if (index<0) 
return path;
return path.substring(index+1);
}
public static virtual string GetDOMTextContent(HTMLElement element) {
var result = "\"";
var child = element.firstChild;
while (child) {
if (child.nodeType==3) 
{
result+=child.textContent;
}
child=child.nextSibling;
}
return result;
}
public static virtual float ToDegrees(float angle) {
return angle*180/Math.PI;
}
public static virtual float ToRadians(float angle) {
return angle*Math.PI/180;
}
public static virtual new {Vector3 minimum;
, Vector3 maximum;
} ExtractMinAndMaxIndexed(float[] positions, float[] indices, float indexStart, float indexCount) {
var minimum = new Vector3(Number.MAX_VALUE, Number.MAX_VALUE, Number.MAX_VALUE);
var maximum = new Vector3(-Number.MAX_VALUE, -Number.MAX_VALUE, -Number.MAX_VALUE);
for (var index = indexStart;index<indexStart+indexCount;index++) 
{
var current = new Vector3(positions[indices[index]*3], positions[indices[index]*3+1], positions[indices[index]*3+2]);
minimum=BABYLON.Vector3.Minimize(current, minimum);
maximum=BABYLON.Vector3.Maximize(current, maximum);
}
return new dynamic();
}
public static virtual new {Vector3 minimum;
, Vector3 maximum;
} ExtractMinAndMax(float[] positions, float start, float count) {
var minimum = new Vector3(Number.MAX_VALUE, Number.MAX_VALUE, Number.MAX_VALUE);
var maximum = new Vector3(-Number.MAX_VALUE, -Number.MAX_VALUE, -Number.MAX_VALUE);
for (var index = start;index<start+count;index++) 
{
var current = new Vector3(positions[index*3], positions[index*3+1], positions[index*3+2]);
minimum=BABYLON.Vector3.Minimize(current, minimum);
maximum=BABYLON.Vector3.Maximize(current, maximum);
}
return new dynamic();
}
public static virtual Array<object> MakeArray(dynamic obj, bool allowsNullUndefined) {
if (allowsNullUndefined!=true&&(obj==undefined||obj==null)) 
return undefined;
return (Array.isArray(obj)) ? obj : new Array<object>();
}
public static virtual string GetPointerPrefix() {
var eventPrefix = "pointe";
if (!navigator.pointerEnabled) 
{
eventPrefix="mous";
}
return eventPrefix;
}
public static virtual void QueueNewFrame(dynamic func) {
if (window.requestAnimationFrame) 
window.requestAnimationFrame(func);
else 
if (window.msRequestAnimationFrame) 
window.msRequestAnimationFrame(func);
else 
if (window.webkitRequestAnimationFrame) 
window.webkitRequestAnimationFrame(func);
else 
if (window.mozRequestAnimationFrame) 
window.mozRequestAnimationFrame(func);
else 
if (window.oRequestAnimationFrame) 
window.oRequestAnimationFrame(func);
else 
{
window.setTimeout(func, 16);
}
}
public static virtual void RequestFullscreen(dynamic element) {
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
}
public static virtual void ExitFullscreen() {
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
}
public static virtual string CleanUrl(string url) {
url=url.replace(new Regex(/#/mg), "%2");
return url;
}
public static virtual HTMLImageElement LoadImage(string url, dynamic onload, dynamic onerror, dynamic database) {
url=Tools.CleanUrl(url);
var img = new Image();
img.crossOrigin="anonymou";
img.onload=() => {
onload(img);
}
;
img.onerror=(dynamic err) => {
onerror(img, err);
}
;
var noIndexedDB = () => {
img.src=url;
}
;
var loadFromIndexedDB = () => {
database.loadImageFromDB(url, img);
}
;
if (database&&database.enableTexturesOffline&&BABYLON.Database.isUASupportingBlobStorage) 
{
database.openAsync(loadFromIndexedDB, noIndexedDB);
}
else 
{
if (url.indexOf("file")==-1) 
{
noIndexedDB();
}
else 
{
try{
var textureName = url.substring(5);
var blobURL;
try{
blobURL=URL.createObjectURL(BABYLON.FilesInput.FilesTextures[textureName], new dynamic());
}
catch (Exception ex){
blobURL=URL.createObjectURL(BABYLON.FilesInput.FilesTextures[textureName]);
}
img.src=blobURL;
}
catch (Exception e){
Tools.Log("Error while trying to load texture:"+textureName);
img.src=null;
}
}
}
return img;
}
public static virtual void LoadFile(string url, Func<object, object> callback, Func<object> progressCallBack, dynamic database, bool useArrayBuffer) {
url=Tools.CleanUrl(url);
var noIndexedDB = () => {
var request = new XMLHttpRequest();
var loadUrl = Tools.BaseUrl+url;
request.open("GE", loadUrl, true);
if (useArrayBuffer) 
{
request.responseType="arraybuffe";
}
request.onprogress=progressCallBack;
request.onreadystatechange=() => {
if (request.readyState==4) 
{
if (request.status==200||BABYLON.Tools.ValidateXHRData(request, (!useArrayBuffer) ? 1 : 6)) 
{
callback((!useArrayBuffer) ? request.responseText : request.response);
}
else 
{
throw new Error("Error status:"+request.status+" - Unable to load"+loadUrl);
}
}
}
;
request.send(null);
}
;
var loadFromIndexedDB = () => {
database.loadFileFromDB(url, callback, progressCallBack, noIndexedDB, useArrayBuffer);
}
;
if (url.indexOf("file")!=-1) 
{
var fileName = url.substring(5);
BABYLON.Tools.ReadFile(BABYLON.FilesInput.FilesToLoad[fileName], callback, progressCallBack, true);
}
else 
{
if (database&&database.enableSceneOffline) 
{
database.openAsync(loadFromIndexedDB, noIndexedDB);
}
else 
{
noIndexedDB();
}
}
}
public static virtual void ReadFile(dynamic fileToLoad, dynamic callback, dynamic progressCallBack, bool useArrayBuffer) {
var reader = new FileReader();
reader.onload=(dynamic e) => {
callback(e.target.result);
}
;
reader.onprogress=progressCallBack;
if (!useArrayBuffer) 
{
reader.readAsText(fileToLoad);
}
else 
{
reader.readAsArrayBuffer(fileToLoad);
}
}
public static virtual void CheckExtends(Vector3 v, Vector3 min, Vector3 max) {
if (v.x<min.x) 
min.x=v.x;
if (v.y<min.y) 
min.y=v.y;
if (v.z<min.z) 
min.z=v.z;
if (v.x>max.x) 
max.x=v.x;
if (v.y>max.y) 
max.y=v.y;
if (v.z>max.z) 
max.z=v.z;
}
public static virtual bool WithinEpsilon(float a, float b) {
var num = a-b;
return -1.401298E-45<=num&&num<=1.401298E-45;
}
public static virtual void DeepCopy(dynamic source, dynamic destination, string[] doNotCopyList, string[] mustCopyList) {
foreach (var prop in source) 
{
if (prop[0]==""&&(!mustCopyList||mustCopyList.indexOf(prop)==-1)) 
{
continue;
}
if (doNotCopyList&&doNotCopyList.indexOf(prop)!=-1) 
{
continue;
}
var sourceValue = source[prop];
var typeOfSourceValue = typeof (sourceValue);
if (typeOfSourceValue=="functio") 
{
continue;
}
if (typeOfSourceValue=="objec") 
{
if (sourceValueisArray) 
{
destination[prop]=new Array<object>();
if (sourceValue.length>0) 
{
if (typeof (sourceValue[0])=="objec") 
{
for (var index = 0;index<sourceValue.length;index++) 
{
var clonedValue = cloneValue(sourceValue[index], destination);
if (destination[prop].indexOf(clonedValue)==-1) 
{
destination[prop].push(clonedValue);
}
}
}
else 
{
destination[prop]=sourceValue.slice(0);
}
}
}
else 
{
destination[prop]=cloneValue(sourceValue, destination);
}
}
else 
{
destination[prop]=sourceValue;
}
}
}
public static virtual bool IsEmpty(dynamic obj) {
foreach (var i in obj) 
{
return false;
}
return true;
}
public static virtual void RegisterTopRootEvents(new {string name;
, EventListener handler;
}[] events) {
for (var index = 0;index<events.length;index++) 
{
var event = events[index];
window.addEventListener(event.name, event.handler, false);
try{
if (window.parent) 
{
window.parent.addEventListener(event.name, event.handler, false);
}
}
catch (Exception e){
}
}
}
public static virtual void UnregisterTopRootEvents(new {string name;
, EventListener handler;
}[] events) {
for (var index = 0;index<events.length;index++) 
{
var event = events[index];
window.removeEventListener(event.name, event.handler);
try{
if (window.parent) 
{
window.parent.removeEventListener(event.name, event.handler);
}
}
catch (Exception e){
}
}
}
public static virtual float GetFps() {
return fps;
}
public static virtual float GetDeltaTime() {
return deltaTime;
}
public static virtual void _MeasureFps() {
previousFramesDuration.push((new Date()).getTime());
var length = previousFramesDuration.length;
if (length>=2) 
{
deltaTime=previousFramesDuration[length-1]-previousFramesDuration[length-2];
}
if (length>=fpsRange) 
{
if (length>fpsRange) 
{
previousFramesDuration.splice(0, 1);
length=previousFramesDuration.length;
}
var sum = 0;
for (var id = 0;id<length-1;id++) 
{
sum+=previousFramesDuration[id+1]-previousFramesDuration[id];
}
fps=1000.0/(sum/(length-1));
}
}
public static virtual void CreateScreenshot(Engine engine, Camera camera, object size) {
var width;
var height;
var scene = camera.getScene();
var previousCamera = null;
if (scene.activeCamera!=camera) 
{
previousCamera=scene.activeCamera;
scene.activeCamera=camera;
}
if (size.precision) 
{
width=Math.round(engine.getRenderWidth()*size.precision);
height=Math.round(width/engine.getAspectRatio(camera));
size=new dynamic();
}
else 
if (size.width&&size.height) 
{
width=size.width;
height=size.height;
}
else 
if (size.width&&!size.height) 
{
width=size.width;
height=Math.round(width/engine.getAspectRatio(camera));
size=new dynamic();
}
else 
if (size.height&&!size.width) 
{
height=size.height;
width=Math.round(height*engine.getAspectRatio(camera));
size=new dynamic();
}
else 
if (!isNaN(size)) 
{
height=size;
width=size;
}
else 
{
Tools.Error("Invalid 'size' parameter ");
return;
}
var texture = new RenderTargetTexture("screenSho", size, engine.scenes[0], false, false);
texture.renderList=engine.scenes[0].meshes;
texture.onAfterRender=() => {
var numberOfChannelsByLine = width*4;
var halfHeight = height/2;
var data = engine.readPixels(0, 0, width, height);
for (var i = 0;i<halfHeight;i++) 
{
for (var j = 0;j<numberOfChannelsByLine;j++) 
{
var currentCell = j+i*numberOfChannelsByLine;
var targetLine = height-i-1;
var targetCell = j+targetLine*numberOfChannelsByLine;
var temp = data[currentCell];
data[currentCell]=data[targetCell];
data[targetCell]=temp;
}
}
if (!screenshotCanvas) 
{
screenshotCanvas=document.createElement("canva");
}
screenshotCanvas.width=width;
screenshotCanvas.height=height;
var context = screenshotCanvas.getContext("2");
var imageData = context.createImageData(width, height);
imageData.data.set(data);
context.putImageData(imageData, 0, 0);
var base64Image = screenshotCanvas.toDataURL();
if (("downloa"indocument.createElement(""))) 
{
var a = window.document.createElement("");
a.href=base64Image;
var date = new Date();
var stringDate = date.getFullYear()+""+date.getMonth()+""+date.getDate()+""+date.getHours()+""+date.getMinutes();
a.setAttribute("downloa", "screenshot"+stringDate+".pn");
window.document.body.appendChild(a);
a.addEventListener("clic", () => {
a.parentElement.removeChild(a);
}
);
a.click();
}
else 
{
var newWindow = window.open("\"");
var img = newWindow.document.createElement("im");
img.src=base64Image;
newWindow.document.body.appendChild(img);
}
}
;
texture.render(true);
texture.dispose();
if (previousCamera) 
{
scene.activeCamera=previousCamera;
}
}
public static virtual bool ValidateXHRData(XMLHttpRequest xhr, dynamic dataType) {
try{
if (dataType&1) 
{
if (xhr.responseText&&xhr.responseText.length>0) 
{
return true;
}
else 
if (dataType==1) 
{
return false;
}
}
if (dataType&2) 
{
var tgaHeader = BABYLON.Internals.TGATools.GetTGAHeader(xhr.response);
if (tgaHeader.width&&tgaHeader.height&&tgaHeader.width>0&&tgaHeader.height>0) 
{
return true;
}
else 
if (dataType==2) 
{
return false;
}
}
if (dataType&4) 
{
var ddsHeader = new Uint8Array(xhr.response, 0, 3);
if (ddsHeader[0]==68&&ddsHeader[1]==68&&ddsHeader[2]==83) 
{
return true;
}
else 
{
return false;
}
}
}
catch (Exception e){
}
return false;
}
dynamic _NoneLogLevel=0;
dynamic _MessageLogLevel=1;
dynamic _WarningLogLevel=2;
dynamic _ErrorLogLevel=4;
private static virtual string _FormatMessage(string message) {
var padStr = (dynamic i) => {
}
;
var date = new Date();
return "BJS - "+padStr(date.getHours())+""+padStr(date.getMinutes())+""+padStr(date.getSeconds())+"]:"+message;
}
public static Func<string, object> Log=Tools._LogEnabled;
private static virtual void _LogDisabled(string message) {
}
private static virtual void _LogEnabled(string message) {
console.log(Tools._FormatMessage(message));
}
public static Func<string, object> Warn=Tools._WarnEnabled;
private static virtual void _WarnDisabled(string message) {
}
private static virtual void _WarnEnabled(string message) {
console.warn(Tools._FormatMessage(message));
}
public static Func<string, object> Error=Tools._ErrorEnabled;
private static virtual void _ErrorDisabled(string message) {
}
private static virtual void _ErrorEnabled(string message) {
console.error(Tools._FormatMessage(message));
}
}
}
