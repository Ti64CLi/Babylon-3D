using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class FilesInput {
private BABYLON.Engine engine;
private BABYLON.Scene currentScene;
private HTMLCanvasElement canvas;
dynamic sceneLoadedCallback;
dynamic progressCallback;
dynamic additionnalRenderLoopLogicCallback;
dynamic textureLoadingCallback;
dynamic startingProcessingFilesCallback;
private HTMLElement elementToMonitor;
public static object[] FilesTextures=new Array();
public static object[] FilesToLoad=new Array();
public FilesInput(BABYLON.Engine p_engine, BABYLON.Scene p_scene, HTMLCanvasElement p_canvas, dynamic p_sceneLoadedCallback, dynamic p_progressCallback, dynamic p_additionnalRenderLoopLogicCallback, dynamic p_textureLoadingCallback, dynamic p_startingProcessingFilesCallback) {
this.engine=p_engine;
this.canvas=p_canvas;
this.currentScene=p_scene;
this.sceneLoadedCallback=p_sceneLoadedCallback;
this.progressCallback=p_progressCallback;
this.additionnalRenderLoopLogicCallback=p_additionnalRenderLoopLogicCallback;
this.textureLoadingCallback=p_textureLoadingCallback;
this.startingProcessingFilesCallback=p_startingProcessingFilesCallback;
}
public virtual void monitorElementForDragNDrop(HTMLElement p_elementToMonitor) {
if (p_elementToMonitor) 
{
this.elementToMonitor=p_elementToMonitor;
this.elementToMonitor.addEventListener("dragente", (dynamic e) => {
this.drag(e);
}
, false);
this.elementToMonitor.addEventListener("dragove", (dynamic e) => {
this.drag(e);
}
, false);
this.elementToMonitor.addEventListener("dro", (dynamic e) => {
this.drop(e);
}
, false);
}
}
private virtual void renderFunction() {
if (this.additionnalRenderLoopLogicCallback) 
{
this.additionnalRenderLoopLogicCallback();
}
if (this.currentScene) 
{
if (this.textureLoadingCallback) 
{
var remaining = this.currentScene.getWaitingItemsCount();
if (remaining>0) 
{
this.textureLoadingCallback(remaining);
}
}
this.currentScene.render();
}
}
private virtual void drag(dynamic e) {
e.stopPropagation();
e.preventDefault();
}
private virtual void drop(dynamic eventDrop) {
eventDrop.stopPropagation();
eventDrop.preventDefault();
this.loadFiles(eventDrop);
}
private virtual void loadFiles(dynamic event) {
var that = this;
if (this.startingProcessingFilesCallback) 
this.startingProcessingFilesCallback();
var sceneFileToLoad;
var filesToLoad;
if (event&&event.dataTransfer&&event.dataTransfer.files) 
{
filesToLoad=event.dataTransfer.files;
}
if (event&&event.target&&event.target.files) 
{
filesToLoad=event.target.files;
}
if (filesToLoad&&filesToLoad.length>0) 
{
for (var i = 0;i<filesToLoad.length;i++) 
{
switch (filesToLoad[i].type) {
case "image/jpe": 
case "image/pn": 
BABYLON.FilesInput.FilesTextures[filesToLoad[i].name]=filesToLoad[i];
break;
case "image/targ": 
case "image/vnd.ms-dd": 
BABYLON.FilesInput.FilesToLoad[filesToLoad[i].name]=filesToLoad[i];
break;
default: 
if (filesToLoad[i].name.indexOf(".babylo")!=-1&&filesToLoad[i].name.indexOf(".manifes")==-1&&filesToLoad[i].name.indexOf(".incrementa")==-1&&filesToLoad[i].name.indexOf(".babylonmeshdat")==-1&&filesToLoad[i].name.indexOf(".babylongeometrydat")==-1) 
{
sceneFileToLoad=filesToLoad[i];
}
break;
}
}
if (sceneFileToLoad) 
{
if (this.currentScene) 
{
this.engine.stopRenderLoop();
this.currentScene.dispose();
}
BABYLON.SceneLoader.Load("file", sceneFileToLoad, this.engine, (dynamic newScene) => {
that.currentScene=newScene;
that.currentScene.executeWhenReady(() => {
if (that.currentScene.activeCamera) 
{
that.currentScene.activeCamera.attachControl(that.canvas);
}
if (that.sceneLoadedCallback) 
{
that.sceneLoadedCallback(sceneFileToLoad, that.currentScene);
}
that.engine.runRenderLoop(() => {
that.renderFunction();
}
);
}
);
}
, (dynamic progress) => {
if (this.progressCallback) 
{
this.progressCallback(progress);
}
}
);
}
else 
{
BABYLON.Tools.Error("Please provide a valid .babylon file");
}
}
}
}
}
