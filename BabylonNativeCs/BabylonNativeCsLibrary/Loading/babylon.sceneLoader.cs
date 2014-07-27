using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public interface ISceneLoaderPlugin {
string extensions;
Func<object, Scene, object, string, AbstractMesh[], ParticleSystem[], Skeleton[], bool> importMesh;
Func<Scene, string, string, bool> load;
}
public class SceneLoader {
private static dynamic _ForceFullSceneLoadingForIncremental=false;
private static dynamic _registeredPlugins=new Array();
private static virtual ISceneLoaderPlugin _getPluginForFilename(dynamic sceneFilename) {
var dotPosition = sceneFilename.lastIndexOf("");
var extension = sceneFilename.substring(dotPosition).toLowerCase();
for (var index = 0;index<this._registeredPlugins.length;index++) 
{
var plugin = this._registeredPlugins[index];
if (plugin.extensions.indexOf(extension)!=-1) 
{
return plugin;
}
}
return this._registeredPlugins[this._registeredPlugins.length-1];
}
public static virtual void RegisterPlugin(ISceneLoaderPlugin plugin) {
plugin.extensions=plugin.extensions.toLowerCase();
SceneLoader._registeredPlugins.push(plugin);
}
public static virtual void ImportMesh(object meshesNames, string rootUrl, string sceneFilename, Scene scene, Func<AbstractMesh[], ParticleSystem[], Skeleton[], object> onsuccess, Func<object> progressCallBack, Func<Scene, object> onerror) {
var manifestChecked = (dynamic success) => {
scene.database=database;
var plugin = this._getPluginForFilename(sceneFilename);
var importMeshFromData = (dynamic data) => {
var meshes = new Array<object>();
var particleSystems = new Array<object>();
var skeletons = new Array<object>();
if (!plugin.importMesh(meshesNames, scene, data, rootUrl, meshes, particleSystems, skeletons)) 
{
if (onerror) 
{
onerror(scene);
}
return;
}
if (onsuccess) 
{
scene.importedMeshesFiles.push(rootUrl+sceneFilename);
onsuccess(meshes, particleSystems, skeletons);
}
}
;
if (sceneFilename.substr&&sceneFilename.substr(0, 5)=="data") 
{
importMeshFromData(sceneFilename.substr(5));
return;
}
BABYLON.Tools.LoadFile(rootUrl+sceneFilename, (dynamic data) => {
importMeshFromData(data);
}
, progressCallBack, database);
}
;
var database = new BABYLON.Database(rootUrl+sceneFilename, manifestChecked);
}
public static virtual void Load(string rootUrl, object sceneFilename, Engine engine, Func<Scene, object> onsuccess, object progressCallBack, Func<Scene, object> onerror) {
var plugin = this._getPluginForFilename(sceneFilename.name||sceneFilename);
var database;
var loadSceneFromData = (dynamic data) => {
var scene = new BABYLON.Scene(engine);
scene.database=database;
if (!plugin.load(scene, data, rootUrl)) 
{
if (onerror) 
{
onerror(scene);
}
return;
}
if (onsuccess) 
{
onsuccess(scene);
}
}
;
var manifestChecked = (dynamic success) => {
BABYLON.Tools.LoadFile(rootUrl+sceneFilename, loadSceneFromData, progressCallBack, database);
}
;
if (sceneFilename.substr&&sceneFilename.substr(0, 5)=="data") 
{
loadSceneFromData(sceneFilename.substr(5));
return;
}
if (rootUrl.indexOf("file")==-1) 
{
database=new BABYLON.Database(rootUrl+sceneFilename, manifestChecked);
}
else 
{
BABYLON.Tools.ReadFile(sceneFilename, loadSceneFromData, progressCallBack);
}
}
}
}
