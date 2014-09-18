// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.filesInput.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    /*
    public partial class FilesInput {
        private BABYLON.Engine engine;
        private BABYLON.Scene currentScene;
        private HTMLCanvasElement canvas;
        private dynamic sceneLoadedCallback;
        private dynamic progressCallback;
        private dynamic additionnalRenderLoopLogicCallback;
        private dynamic textureLoadingCallback;
        private dynamic startingProcessingFilesCallback;
        private HTMLElement elementToMonitor;
        public static Array < object > FilesTextures = new Array();
        public static Array < object > FilesToLoad = new Array();
        public FilesInput(BABYLON.Engine p_engine, BABYLON.Scene p_scene, HTMLCanvasElement p_canvas, object p_sceneLoadedCallback, object p_progressCallback, object p_additionnalRenderLoopLogicCallback, object p_textureLoadingCallback, object p_startingProcessingFilesCallback) {
            this.engine = p_engine;
            this.canvas = p_canvas;
            this.currentScene = p_scene;
            this.sceneLoadedCallback = p_sceneLoadedCallback;
            this.progressCallback = p_progressCallback;
            this.additionnalRenderLoopLogicCallback = p_additionnalRenderLoopLogicCallback;
            this.textureLoadingCallback = p_textureLoadingCallback;
            this.startingProcessingFilesCallback = p_startingProcessingFilesCallback;
        }
        public virtual void monitorElementForDragNDrop(HTMLElement p_elementToMonitor) {
            if (p_elementToMonitor) {
                this.elementToMonitor = p_elementToMonitor;
                this.elementToMonitor.addEventListener("dragenter", (object e) => {
                    this.drag(e);
                }, false);
                this.elementToMonitor.addEventListener("dragover", (object e) => {
                    this.drag(e);
                }, false);
                this.elementToMonitor.addEventListener("drop", (object e) => {
                    this.drop(e);
                }, false);
            }
        }
        private void renderFunction() {
            if (this.additionnalRenderLoopLogicCallback) {
                this.additionnalRenderLoopLogicCallback();
            }
            if (this.currentScene) {
                if (this.textureLoadingCallback) {
                    var remaining = this.currentScene.getWaitingItemsCount();
                    if (remaining > 0) {
                        this.textureLoadingCallback(remaining);
                    }
                }
                this.currentScene.render();
            }
        }
        private void drag(object e) {
            e.stopPropagation();
            e.preventDefault();
        }
        private void drop(object eventDrop) {
            eventDrop.stopPropagation();
            eventDrop.preventDefault();
            this.loadFiles(eventDrop);
        }
        private void loadFiles(object _event) {
            var that = this;
            if (this.startingProcessingFilesCallback)
                this.startingProcessingFilesCallback();
            var sceneFileToLoad;
            var filesToLoad;
            if (_event && _event.dataTransfer && _event.dataTransfer.files) {
                filesToLoad = _event.dataTransfer.files;
            }
            if (_event && _event.target && _event.target.files) {
                filesToLoad = _event.target.files;
            }
            if (filesToLoad && filesToLoad.Length > 0) {
                for (var i = 0; i < filesToLoad.Length; i++) {
                    switch (filesToLoad[i].type) {
                        case "image/jpeg":
                        case "image/png":
                            BABYLON.FilesInput.FilesTextures[filesToLoad[i].name] = filesToLoad[i];
                            break;
                        case "image/targa":
                        case "image/vnd.ms-dds":
                            BABYLON.FilesInput.FilesToLoad[filesToLoad[i].name] = filesToLoad[i];
                            break;
                        default:
                            if (filesToLoad[i].name.IndexOf(".babylon") != -1 && filesToLoad[i].name.IndexOf(".manifest") == -1 && filesToLoad[i].name.IndexOf(".incremental") == -1 && filesToLoad[i].name.IndexOf(".babylonmeshdata") == -1 && filesToLoad[i].name.IndexOf(".babylongeometrydata") == -1) {
                                sceneFileToLoad = filesToLoad[i];
                            }
                            break;
                    }
                }
                if (sceneFileToLoad) {
                    if (this.currentScene) {
                        this.engine.stopRenderLoop();
                        this.currentScene.dispose();
                    }
                    BABYLON.SceneLoader.Load("file:", sceneFileToLoad, this.engine, (object newScene) => {
                        that.currentScene = newScene;
                        that.currentScene.executeWhenReady(() => {
                            if (that.currentScene.activeCamera) {
                                that.currentScene.activeCamera.attachControl(that.canvas);
                            }
                            if (that.sceneLoadedCallback) {
                                that.sceneLoadedCallback(sceneFileToLoad, that.currentScene);
                            }
                            that.engine.runRenderLoop(() => {
                                that.renderFunction();
                            });
                        });
                    }, (progress) => {
                        if (this.progressCallback) {
                            this.progressCallback(progress);
                        }
                    });
                } else {
                    BABYLON.Tools.Error("Please provide a valid .babylon file.");
                }
            }
        }
    }
     */
}