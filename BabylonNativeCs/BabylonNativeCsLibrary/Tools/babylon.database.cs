using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class Database {
private Func<object, object> callbackManifestChecked;
private string currentSceneUrl;
private IDBDatabase db;
private bool enableSceneOffline;
private bool enableTexturesOffline;
private float manifestVersionFound;
private bool mustUpdateRessources;
private bool hasReachedQuota;
private bool isSupported;
dynamic idbFactory=(IDBFactory)(window.indexedDB||window.mozIndexedDB||window.webkitIndexedDB||window.msIndexedDB);
static bool isUASupportingBlobStorage=true;
public Database(string urlToScene, Func<object, object> callbackManifestChecked) {
this.callbackManifestChecked=callbackManifestChecked;
this.currentSceneUrl=BABYLON.Database.ReturnFullUrlLocation(urlToScene);
this.db=null;
this.enableSceneOffline=false;
this.enableTexturesOffline=false;
this.manifestVersionFound=0;
this.mustUpdateRessources=false;
this.hasReachedQuota=false;
this.checkManifestFile();
}
dynamic parseURL=(dynamic url) {
var a = document.createElement("");
a.href=url;
var fileName = url.substring(url.lastIndexOf("")+1, url.length);
var absLocation = url.substring(0, url.indexOf(fileName, 0));
return absLocation;
}
;
dynamic ReturnFullUrlLocation=(dynamic url) {
if (url.indexOf("http:")==-1) 
{
return (BABYLON.Database.parseURL(window.location.href)+url);
}
else 
{
return url;
}
}
;
public virtual void checkManifestFile() {
{
}
var that = this;
var manifestURL = this.currentSceneUrl+".manifes";
var xhr = new XMLHttpRequest();
var manifestURLTimeStamped = manifestURL+((manifestURL.match(new Regex(/\?/))==null) ? "" : "")+(new Date()).getTime();
xhr.open("GE", manifestURLTimeStamped, true);
xhr.addEventListener("loa", () {
if (xhr.status==200||BABYLON.Tools.ValidateXHRData(xhr, 1)) 
{
try{
var manifestFile = JSON.parse(xhr.response);
that.enableSceneOffline=manifestFile.enableSceneOffline;
that.enableTexturesOffline=manifestFile.enableTexturesOffline;
if (manifestFile.version&&!isNaN(parseInt(manifestFile.version))) 
{
that.manifestVersionFound=manifestFile.version;
}
if (that.callbackManifestChecked) 
{
that.callbackManifestChecked(true);
}
}
catch (Exception ex){
noManifestFile();
}
}
else 
{
noManifestFile();
}
}
, false);
xhr.addEventListener("erro", (dynamic event) {
noManifestFile();
}
, false);
try{
xhr.send();
}
catch (Exception ex){
BABYLON.Tools.Error("Error on XHR send request");
that.callbackManifestChecked(false);
}
}
public virtual void openAsync(dynamic successCallback, dynamic errorCallback) {
{
}
var that = this;
if (!this.idbFactory||!(this.enableSceneOffline||this.enableTexturesOffline)) 
{
this.isSupported=false;
if (errorCallback) 
errorCallback();
}
else 
{
if (!this.db) 
{
this.hasReachedQuota=false;
this.isSupported=true;
var request = this.idbFactory.open("babylonj", 1);
request.onerror=(dynamic event) {
handleError();
}
;
request.onblocked=(dynamic event) {
BABYLON.Tools.Error("IDB request blocked. Please reload the page");
handleError();
}
;
request.onsuccess=(dynamic event) {
that.db=request.result;
successCallback();
}
;
request.onupgradeneeded=(IDBVersionChangeEvent event) {
that.db=((object)(event.target)).result;
try{
if (event.oldVersion>0) 
{
that.db.deleteObjectStore("scene");
that.db.deleteObjectStore("version");
that.db.deleteObjectStore("texture");
}
var scenesStore = that.db.createObjectStore("scene", new dynamic());
var versionsStore = that.db.createObjectStore("version", new dynamic());
var texturesStore = that.db.createObjectStore("texture", new dynamic());
}
catch (Exception ex){
BABYLON.Tools.Error("Error while creating object stores. Exception:"+ex.message);
handleError();
}
}
;
}
else 
{
if (successCallback) 
successCallback();
}
}
}
public virtual void loadImageFromDB(string url, HTMLImageElement image) {
var that = this;
var completeURL = BABYLON.Database.ReturnFullUrlLocation(url);
var saveAndLoadImage = () {
if (!that.hasReachedQuota&&that.db!=null) 
{
that._saveImageIntoDBAsync(completeURL, image);
}
else 
{
image.src=url;
}
}
;
if (!this.mustUpdateRessources) 
{
this._loadImageFromDBAsync(completeURL, image, saveAndLoadImage);
}
else 
{
saveAndLoadImage();
}
}
private virtual void _loadImageFromDBAsync(string url, HTMLImageElement image, Func<object> notInDBCallback) {
if (this.isSupported&&this.db!=null) 
{
var texture;
var transaction = this.db.transaction(new Array<object>());
transaction.onabort=(dynamic event) {
image.src=url;
}
;
transaction.oncomplete=(dynamic event) {
var blobTextureURL;
if (texture) 
{
var URL = window.URL||window.webkitURL;
blobTextureURL=URL.createObjectURL(texture.data, new dynamic());
image.onerror=() {
BABYLON.Tools.Error("Error loading image from blob URL:"+blobTextureURL+" switching back to web url:"+url);
image.src=url;
}
;
image.src=blobTextureURL;
}
else 
{
notInDBCallback();
}
}
;
var getRequest = transaction.objectStore("texture").get(url);
getRequest.onsuccess=(dynamic event) {
texture=((object)(event.target)).result;
}
;
getRequest.onerror=(dynamic event) {
BABYLON.Tools.Error("Error loading texture"+url+" from DB");
image.src=url;
}
;
}
else 
{
BABYLON.Tools.Error("Error: IndexedDB not supported by your browser or BabylonJS Database is not open");
image.src=url;
}
}
private virtual void _saveImageIntoDBAsync(string url, HTMLImageElement image) {
if (this.isSupported) 
{
var generateBlobUrl = () {
var blobTextureURL;
if (blob) 
{
var URL = window.URL||window.webkitURL;
try{
blobTextureURL=URL.createObjectURL(blob, new dynamic());
}
catch (Exception ex){
blobTextureURL=URL.createObjectURL(blob);
}
}
image.src=blobTextureURL;
}
;
if (BABYLON.Database.isUASupportingBlobStorage) 
{
var that = this;
var xhr = new XMLHttpRequest()blob;
xhr.open("GE", url, true);
xhr.responseType="blo";
xhr.addEventListener("loa", () {
if (xhr.status==200) 
{
blob=xhr.response;
var transaction = that.db.transaction(new Array<object>(), "readwrit");
transaction.onabort=(dynamic event) {
try{
if (event.srcElement.error.name=="QuotaExceededErro") 
{
that.hasReachedQuota=true;
}
}
catch (Exception ex){
}
generateBlobUrl();
}
;
transaction.oncomplete=(dynamic event) {
generateBlobUrl();
}
;
var newTexture = new dynamic();
try{
var addRequest = transaction.objectStore("texture").put(newTexture);
addRequest.onsuccess=(dynamic event) {
}
;
addRequest.onerror=(dynamic event) {
generateBlobUrl();
}
;
}
catch (Exception ex){
if (ex.code==25) 
{
BABYLON.Database.isUASupportingBlobStorage=false;
}
image.src=url;
}
}
else 
{
image.src=url;
}
}
, false);
xhr.addEventListener("erro", (dynamic event) {
BABYLON.Tools.Error("Error in XHR request in BABYLON.Database");
image.src=url;
}
, false);
xhr.send();
}
else 
{
image.src=url;
}
}
else 
{
BABYLON.Tools.Error("Error: IndexedDB not supported by your browser or BabylonJS Database is not open");
image.src=url;
}
}
private virtual void _checkVersionFromDB(string url, dynamic versionLoaded) {
var that = this;
var updateVersion = (dynamic event) {
that._saveVersionIntoDBAsync(url, versionLoaded);
}
;
this._loadVersionFromDBAsync(url, versionLoaded, updateVersion);
}
private virtual void _loadVersionFromDBAsync(string url, dynamic callback, dynamic updateInDBCallback) {
if (this.isSupported) 
{
var version;
var that = this;
try{
var transaction = this.db.transaction(new Array<object>());
transaction.oncomplete=(dynamic event) {
if (version) 
{
if (that.manifestVersionFound>version.data) 
{
that.mustUpdateRessources=true;
updateInDBCallback();
}
else 
{
callback(version.data);
}
}
else 
{
that.mustUpdateRessources=true;
updateInDBCallback();
}
}
;
transaction.onabort=(dynamic event) {
callback(-1);
}
;
var getRequest = transaction.objectStore("version").get(url);
getRequest.onsuccess=(dynamic event) {
version=((object)(event.target)).result;
}
;
getRequest.onerror=(dynamic event) {
BABYLON.Tools.Error("Error loading version for scene"+url+" from DB");
callback(-1);
}
;
}
catch (Exception ex){
BABYLON.Tools.Error("Error while accessing 'versions' object store (READ OP). Exception:"+ex.message);
callback(-1);
}
}
else 
{
BABYLON.Tools.Error("Error: IndexedDB not supported by your browser or BabylonJS Database is not open");
callback(-1);
}
}
private virtual void _saveVersionIntoDBAsync(string url, dynamic callback) {
if (this.isSupported&&!this.hasReachedQuota) 
{
var that = this;
try{
var transaction = this.db.transaction(new Array<object>(), "readwrit");
transaction.onabort=(dynamic event) {
try{
if (event.srcElement.error.name=="QuotaExceededErro") 
{
that.hasReachedQuota=true;
}
}
catch (Exception ex){
}
callback(-1);
}
;
transaction.oncomplete=(dynamic event) {
callback(that.manifestVersionFound);
}
;
var newVersion = new dynamic();
var addRequest = transaction.objectStore("version").put(newVersion);
addRequest.onsuccess=(dynamic event) {
}
;
addRequest.onerror=(dynamic event) {
BABYLON.Tools.Error("Error in DB add version request in BABYLON.Database");
}
;
}
catch (Exception ex){
BABYLON.Tools.Error("Error while accessing 'versions' object store (WRITE OP). Exception:"+ex.message);
callback(-1);
}
}
else 
{
callback(-1);
}
}
private virtual void loadFileFromDB(string url, dynamic sceneLoaded, dynamic progressCallBack, dynamic errorCallback, bool useArrayBuffer) {
var that = this;
var completeUrl = BABYLON.Database.ReturnFullUrlLocation(url);
var saveAndLoadFile = (dynamic event) {
that._saveFileIntoDBAsync(completeUrl, sceneLoaded, progressCallBack);
}
;
this._checkVersionFromDB(completeUrl, (dynamic version) {
if (version!=-1) 
{
if (!that.mustUpdateRessources) 
{
that._loadFileFromDBAsync(completeUrl, sceneLoaded, saveAndLoadFile, useArrayBuffer);
}
else 
{
that._saveFileIntoDBAsync(completeUrl, sceneLoaded, progressCallBack, useArrayBuffer);
}
}
else 
{
errorCallback();
}
}
);
}
private virtual void _loadFileFromDBAsync(dynamic url, dynamic callback, dynamic notInDBCallback, bool useArrayBuffer) {
if (this.isSupported) 
{
var targetStore;
if (url.indexOf(".babylo")!=-1) 
{
targetStore="scene";
}
else 
{
targetStore="texture";
}
var file;
var transaction = this.db.transaction(new Array<object>());
transaction.oncomplete=(dynamic event) {
if (file) 
{
callback(file.data);
}
else 
{
notInDBCallback();
}
}
;
transaction.onabort=(dynamic event) {
notInDBCallback();
}
;
var getRequest = transaction.objectStore(targetStore).get(url);
getRequest.onsuccess=(dynamic event) {
file=((object)(event.target)).result;
}
;
getRequest.onerror=(dynamic event) {
BABYLON.Tools.Error("Error loading file"+url+" from DB");
notInDBCallback();
}
;
}
else 
{
BABYLON.Tools.Error("Error: IndexedDB not supported by your browser or BabylonJS Database is not open");
callback();
}
}
private virtual void _saveFileIntoDBAsync(string url, dynamic callback, dynamic progressCallback, bool useArrayBuffer) {
if (this.isSupported) 
{
var targetStore;
if (url.indexOf(".babylo")!=-1) 
{
targetStore="scene";
}
else 
{
targetStore="texture";
}
var xhr = new XMLHttpRequest()fileData;
var that = this;
xhr.open("GE", url, true);
if (useArrayBuffer) 
{
xhr.responseType="arraybuffe";
}
xhr.onprogress=progressCallback;
xhr.addEventListener("loa", () {
if (xhr.status==200||BABYLON.Tools.ValidateXHRData(xhr, (!useArrayBuffer) ? 1 : 6)) 
{
fileData=(!useArrayBuffer) ? xhr.responseText : xhr.response;
if (!that.hasReachedQuota) 
{
var transaction = that.db.transaction(new Array<object>(), "readwrit");
transaction.onabort=(dynamic event) {
try{
if (event.srcElement.error.name=="QuotaExceededErro") 
{
that.hasReachedQuota=true;
}
}
catch (Exception ex){
}
callback(fileData);
}
;
transaction.oncomplete=(dynamic event) {
callback(fileData);
}
;
var newFile;
if (targetStore=="scene") 
{
newFile=new dynamic();
}
else 
{
newFile=new dynamic();
}
try{
var addRequest = transaction.objectStore(targetStore).put(newFile);
addRequest.onsuccess=(dynamic event) {
}
;
addRequest.onerror=(dynamic event) {
BABYLON.Tools.Error("Error in DB add file request in BABYLON.Database");
}
;
}
catch (Exception ex){
callback(fileData);
}
}
else 
{
callback(fileData);
}
}
else 
{
callback();
}
}
, false);
xhr.addEventListener("erro", (dynamic event) {
BABYLON.Tools.Error("error on XHR request");
callback();
}
, false);
xhr.send();
}
else 
{
BABYLON.Tools.Error("Error: IndexedDB not supported by your browser or BabylonJS Database is not open");
callback();
}
}
}
}
