// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.sceneLoader.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    using System;

    public interface ISceneLoaderPlugin
    {
        string extensions { get; set; }

        System.Func<object, Scene, object, string, Array<AbstractMesh>, Array<ParticleSystem>, Array<Skeleton>, bool> importMesh
        {
            get;
        }

        System.Func<Scene, string, string, bool> load
        {
            get;
        }
    }

    public class SceneLoader
    {
        public static bool ForceFullSceneLoadingForIncremental { get; set; }

        private static Array<ISceneLoaderPlugin> _registeredPlugins = new Array<ISceneLoaderPlugin>();

        static SceneLoader()
        {
            ForceFullSceneLoadingForIncremental = false;
        }

        private static ISceneLoaderPlugin _getPluginForFilename(string sceneFilename)
        {
            var dotPosition = sceneFilename.LastIndexOf(".");
            var extension = sceneFilename.Substring(dotPosition).ToLower();
            foreach (var plugin in _registeredPlugins)
            {
                if (plugin.extensions.IndexOf(extension) != -1)
                {
                    return plugin;
                }
            }

            return _registeredPlugins[_registeredPlugins.Length - 1];
        }

        public static void RegisterPlugin(ISceneLoaderPlugin plugin)
        {
            plugin.extensions = plugin.extensions.ToLower();
            SceneLoader._registeredPlugins.Add(plugin);
        }

        public static void ImportMesh(object meshesNames, string rootUrl, string sceneFilename, Scene scene, System.Action<Array<AbstractMesh>, Array<ParticleSystem>, Array<Skeleton>> onsuccess = null, System.Action progressCallBack = null, System.Action<Scene> onerror = null)
        {
            Database database = null;

            var manifestChecked = new Func<object, object>(
                success =>
                {
                    scene.database = database;
                    var plugin = _getPluginForFilename(sceneFilename);
                    var importMeshFromData = new Action<string>(
                        data =>
                        {
                            var meshes = new Array<AbstractMesh>();
                            var particleSystems = new Array<ParticleSystem>();
                            var skeletons = new Array<Skeleton>();
                            if (
                                !plugin.importMesh(
                                    meshesNames,
                                    scene,
                                    data,
                                    rootUrl,
                                    meshes,
                                    particleSystems,
                                    skeletons))
                            {
                                if (onerror != null)
                                {
                                    onerror(scene);
                                }
                                return;
                            }
                            if (onsuccess != null)
                            {
                                scene.importedMeshesFiles.Add(rootUrl + sceneFilename);
                                onsuccess(meshes, particleSystems, skeletons);
                            }
                        });

                    if (sceneFilename.Substring(0, 5) == "data:")
                    {
                        importMeshFromData(sceneFilename.Substring(5));
                        return null;
                    }

                    BABYLON.Tools.LoadFile(
                        rootUrl + sceneFilename,
                        (data) =>
                        {
                            importMeshFromData(data);
                        },
                        progressCallBack,
                        database);

                    return null;
                });

            database = new BABYLON.Database(rootUrl + sceneFilename, manifestChecked);
        }

        public static void Load(string rootUrl, string sceneFilename, Engine engine, System.Action<Scene> onsuccess = null, System.Action progressCallBack = null, System.Action<Scene> onerror = null)
        {
            var plugin = _getPluginForFilename(sceneFilename);
            Database database = null;
            var loadSceneFromData = new Action<string>(
                data =>
                {
                    var scene = new BABYLON.Scene(engine);
                    scene.database = database;
                    if (!plugin.load(scene, data, rootUrl))
                    {
                        if (onerror != null)
                        {
                            onerror(scene);
                        }
                        return;
                    }

                    if (onsuccess != null)
                    {
                        onsuccess(scene);
                    }
                });

            var manifestChecked = new Func<object, object>(
                success =>
                {
                    BABYLON.Tools.LoadFile(rootUrl + sceneFilename, loadSceneFromData, progressCallBack, database);
                    return null;
                });

            if (sceneFilename.Substring(0, 5) == "data:")
            {
                loadSceneFromData(sceneFilename.Substring(5));
                return;
            }
            if (rootUrl.IndexOf("file:") == -1)
            {
                database = new BABYLON.Database(rootUrl + sceneFilename, manifestChecked);
            }
            else
            {
                BABYLON.Tools.ReadFile(sceneFilename, loadSceneFromData, progressCallBack);
            }
        }
    }
}