using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
    public interface ISceneLoaderPlugin {
        string extensions;
        System.Func < object, Scene, object, string, Array < AbstractMesh > , Array < ParticleSystem > , Array < Skeleton > , bool > importMesh;
        System.Func < Scene, string, string, bool > load;
    }
    public class SceneLoader {
        private static bool _ForceFullSceneLoadingForIncremental = false;
        public static dynamic ForceFullSceneLoadingForIncremental {
            get {
                return SceneLoader._ForceFullSceneLoadingForIncremental;
            }
            set {
                SceneLoader._ForceFullSceneLoadingForIncremental = value;
            }
        }
        private static Array < ISceneLoaderPlugin > _registeredPlugins = new Array < ISceneLoaderPlugin > ();
        private static ISceneLoaderPlugin _getPluginForFilename(object sceneFilename) {
            var dotPosition = sceneFilename.lastIndexOf("");
            var extension = sceneFilename.substring(dotPosition).toLowerCase();
            for (var index = 0; index < this._registeredPlugins.Length; index++) {
                var plugin = this._registeredPlugins[index];
                if (plugin.extensions.indexOf(extension) != -1) {
                    return plugin;
                }
            }
            return this._registeredPlugins[this._registeredPlugins.Length - 1];
        }
        public static void RegisterPlugin(ISceneLoaderPlugin plugin) {
            plugin.extensions = plugin.extensions.toLowerCase();
            SceneLoader._registeredPlugins.push(plugin);
        }
        public static void ImportMesh(object meshesNames, string rootUrl, string sceneFilename, Scene scene, System.Action < Array < AbstractMesh > , Array < ParticleSystem > , Array < Skeleton > > onsuccess = null, System.Action progressCallBack = null, System.Action < Scene > onerror = null) {
            var manifestChecked = (object success) => {
                scene.database = database;
                var plugin = this._getPluginForFilename(sceneFilename);
                var importMeshFromData = (object data) => {
                    var meshes = new Array < object > ();
                    var particleSystems = new Array < object > ();
                    var skeletons = new Array < object > ();
                    if (!plugin.importMesh(meshesNames, scene, data, rootUrl, meshes, particleSystems, skeletons)) {
                        if (onerror) {
                            onerror(scene);
                        }
                        return;
                    }
                    if (onsuccess) {
                        scene.importedMeshesFiles.push(rootUrl + sceneFilename);
                        onsuccess(meshes, particleSystems, skeletons);
                    }
                };
                if (sceneFilename.substr && sceneFilename.substr(0, 5) == "data") {
                    importMeshFromData(sceneFilename.substr(5));
                    return;
                }
                BABYLON.Tools.LoadFile(rootUrl + sceneFilename, (object data) => {
                    importMeshFromData(data);
                }, progressCallBack, database);
            };
            var database = new BABYLON.Database(rootUrl + sceneFilename, manifestChecked);
        }
        public static void Load(string rootUrl, object sceneFilename, Engine engine, System.Action < Scene > onsuccess = null, object progressCallBack = null, System.Action < Scene > onerror = null) {
            var plugin = this._getPluginForFilename(sceneFilename.name || sceneFilename);
            var database;
            var loadSceneFromData = (object data) => {
                var scene = new BABYLON.Scene(engine);
                scene.database = database;
                if (!plugin.load(scene, data, rootUrl)) {
                    if (onerror) {
                        onerror(scene);
                    }
                    return;
                }
                if (onsuccess) {
                    onsuccess(scene);
                }
            };
            var manifestChecked = (object success) => {
                BABYLON.Tools.LoadFile(rootUrl + sceneFilename, loadSceneFromData, progressCallBack, database);
            };
            if (sceneFilename.substr && sceneFilename.substr(0, 5) == "data") {
                loadSceneFromData(sceneFilename.substr(5));
                return;
            }
            if (rootUrl.indexOf("file") == -1) {
                database = new BABYLON.Database(rootUrl + sceneFilename, manifestChecked);
            } else {
                BABYLON.Tools.ReadFile(sceneFilename, loadSceneFromData, progressCallBack);
            }
        }
    }
}