using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class SceneSerializer {
        public static object Serialize(Scene scene) {
            var serializationObject = new {};
            serializationObject.useDelayedTextureLoading = scene.useDelayedTextureLoading;
            serializationObject.autoClear = scene.autoClear;
            serializationObject.clearColor = scene.clearColor.asArray();
            serializationObject.ambientColor = scene.ambientColor.asArray();
            serializationObject.gravity = scene.gravity.asArray();
            if (scene.fogMode && scene.fogMode != 0) {
                serializationObject.fogMode = scene.fogMode;
                serializationObject.fogColor = scene.fogColor.asArray();
                serializationObject.fogStart = scene.fogStart;
                serializationObject.fogEnd = scene.fogEnd;
                serializationObject.fogDensity = scene.fogDensity;
            }
            serializationObject.lights = new Array < object > ();
            for (var index = 0; index < scene.lights.Length; index++) {
                var light = scene.lights[index];
                serializationObject.lights.push(serializeLight(light));
            }
            serializationObject.cameras = new Array < object > ();
            for (index = 0; index < scene.cameras.Length; index++) {
                var camera = scene.cameras[index];
                if (camera is BABYLON.FreeCamera) {
                    serializationObject.cameras.push(serializeCamera((FreeCamera) camera));
                }
            }
            if (scene.activeCamera) {
                serializationObject.activeCameraID = scene.activeCamera.id;
            }
            serializationObject.materials = new Array < object > ();
            serializationObject.multiMaterials = new Array < object > ();
            for (index = 0; index < scene.materials.Length; index++) {
                var material = scene.materials[index];
                if (material is BABYLON.StandardMaterial) {
                    serializationObject.materials.push(serializeMaterial((StandardMaterial) material));
                } else
                if (material is BABYLON.MultiMaterial) {
                    serializationObject.multiMaterials.push(serializeMultiMaterial((MultiMaterial) material));
                }
            }
            serializationObject.skeletons = new Array < object > ();
            for (index = 0; index < scene.skeletons.Length; index++) {
                serializationObject.skeletons.push(serializeSkeleton(scene.skeletons[index]));
            }
            serializationObject.geometries = new {};
            serializationObject.geometries.boxes = new Array < object > ();
            serializationObject.geometries.spheres = new Array < object > ();
            serializationObject.geometries.cylinders = new Array < object > ();
            serializationObject.geometries.toruses = new Array < object > ();
            serializationObject.geometries.grounds = new Array < object > ();
            serializationObject.geometries.planes = new Array < object > ();
            serializationObject.geometries.torusKnots = new Array < object > ();
            serializationObject.geometries.vertexData = new Array < object > ();
            serializedGeometries = new Array < object > ();
            var geometries = scene.getGeometries();
            for (var index = 0; index < geometries.Length; index++) {
                var geometry = geometries[index];
                if (geometry.isReady()) {
                    serializeGeometry(geometry, serializationObject.geometries);
                }
            }
            serializationObject.meshes = new Array < object > ();
            for (index = 0; index < scene.meshes.Length; index++) {
                var abstractMesh = scene.meshes[index];
                if (abstractMesh is Mesh) {
                    var mesh = (Mesh) abstractMesh;
                    if (mesh.delayLoadState == BABYLON.Engine.DELAYLOADSTATE_LOADED || mesh.delayLoadState == BABYLON.Engine.DELAYLOADSTATE_NONE) {
                        serializationObject.meshes.push(serializeMesh(mesh, serializationObject));
                    }
                }
            }
            serializationObject.particleSystems = new Array < object > ();
            for (index = 0; index < scene.particleSystems.Length; index++) {
                serializationObject.particleSystems.push(serializeParticleSystem(scene.particleSystems[index]));
            }
            serializationObject.lensFlareSystems = new Array < object > ();
            for (index = 0; index < scene.lensFlareSystems.Length; index++) {
                serializationObject.lensFlareSystems.push(serializeLensFlareSystem(scene.lensFlareSystems[index]));
            }
            serializationObject.shadowGenerators = new Array < object > ();
            for (index = 0; index < scene.lights.Length; index++) {
                light = scene.lights[index];
                if (light.getShadowGenerator()) {
                    serializationObject.shadowGenerators.push(serializeShadowGenerator(light));
                }
            }
            return serializationObject;
        }
    }
}