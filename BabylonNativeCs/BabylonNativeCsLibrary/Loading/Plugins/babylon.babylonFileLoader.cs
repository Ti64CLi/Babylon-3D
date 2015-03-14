// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.babylonFileLoader.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON.Internals
{
    using System;

    public class BabylonFileLoader : ISceneLoaderPlugin
    {
        private static string _extensions;

        static BabylonFileLoader()
        {
            _extensions = ".babylon";
        }

        CubeTexture loadCubeTexture(string rootUrl, JsmnParserValue parsedTexture, Scene scene)
        {
            var texture = new BABYLON.CubeTexture(rootUrl + parsedTexture["name"], scene);
            texture.name = parsedTexture["name"];
            texture.hasAlpha = parsedTexture["hasAlpha"];
            texture.level = parsedTexture["level"];
            texture.coordinatesMode = parsedTexture["coordinatesMode"];
            return texture;
        }

        Texture loadTexture(string rootUrl, JsmnParserValue parsedTexture, Scene scene)
        {
            if (!parsedTexture["name"] && !parsedTexture["isRenderTarget"])
            {
                return null;
            }
            if (parsedTexture["isCube"])
            {
                return loadCubeTexture(rootUrl, parsedTexture, scene);
            }
            Texture texture;
            if (parsedTexture["mirrorPlane"])
            {
                var renderTargetSize = parsedTexture["renderTargetSize"];
                var size = CreateSize(renderTargetSize);
                var mirrorTexture = new BABYLON.MirrorTexture(parsedTexture["name"], size, scene);
                mirrorTexture._waitingRenderList = Array<string>.New(parsedTexture["renderList"]);
                mirrorTexture.mirrorPlane = BABYLON.Plane.FromArray(parsedTexture["mirrorPlane"]);
                texture = mirrorTexture;
            }
            else
                if (parsedTexture["isRenderTarget"])
                {
                    var renderTargetSize = parsedTexture["renderTargetSize"];
                    var size = new Size() { width = renderTargetSize["width"], height = renderTargetSize["height"] };
                    var renderTargetTexture = new BABYLON.RenderTargetTexture(parsedTexture["name"], size, scene);
                    renderTargetTexture._waitingRenderList = Array<string>.New(parsedTexture["renderList"]);
                    texture = renderTargetTexture;
                }
                else
                {
                    texture = new BABYLON.Texture(rootUrl + parsedTexture["name"], scene);
                }
            texture.name = parsedTexture["name"];
            texture.hasAlpha = parsedTexture["hasAlpha"];
            texture.getAlphaFromRGB = parsedTexture["getAlphaFromRGB"];
            texture.level = parsedTexture["level"];
            texture.coordinatesIndex = parsedTexture["coordinatesIndex"];
            texture.coordinatesMode = parsedTexture["coordinatesMode"];
            texture.uOffset = parsedTexture["uOffset"];
            texture.vOffset = parsedTexture["vOffset"];
            texture.uScale = parsedTexture["uScale"];
            texture.vScale = parsedTexture["vScale"];
            texture.uAng = parsedTexture["uAng"];
            texture.vAng = parsedTexture["vAng"];
            texture.wAng = parsedTexture["wAng"];
            texture.wrapU = parsedTexture["wrapU"];
            texture.wrapV = parsedTexture["wrapV"];

            var animations = parsedTexture["animations"];
            if (animations)
            {
                for (var animationIndex = 0; animationIndex < animations.Length; animationIndex++)
                {
                    var parsedAnimation = animations[animationIndex];
                    texture.animations.Add(parseAnimation(parsedAnimation));
                }
            }
            return texture;
        }

        private static Size CreateSize(JsmnParserValue renderTargetSize)
        {
            if (renderTargetSize.Type == JsmnType.Primitive)
            {
                return new Size() { width = renderTargetSize, height = renderTargetSize };
            }

            return new Size() { width = renderTargetSize["width"], height = renderTargetSize["height"] };
        }

        Skeleton parseSkeleton(JsmnParserValue parsedSkeleton, Scene scene)
        {
            var skeleton = new BABYLON.Skeleton(parsedSkeleton["name"], parsedSkeleton["id"], scene);
            for (var index = 0; index < parsedSkeleton["bones"].Length; index++)
            {
                var parsedBone = parsedSkeleton["bones"][index];
                Bone parentBone = null;
                if (parsedBone["parentBoneIndex"] > -1)
                {
                    parentBone = skeleton.bones[parsedBone["parentBoneIndex"]];
                }
                var bone = new BABYLON.Bone(parsedBone["name"], skeleton, parentBone, BABYLON.Matrix.FromArray(parsedBone["matrix"]));
                var animation = parsedBone["animation"];
                if (animation)
                {
                    bone.animations.Add(parseAnimation(animation));
                }
            }
            return skeleton;
        }

        Material parseMaterial(JsmnParserValue parsedMaterial, Scene scene, string rootUrl)
        {
            var material = new BABYLON.StandardMaterial(parsedMaterial["name"], scene);
            material.ambientColor = BABYLON.Color3.FromArray(parsedMaterial["ambient"]);
            material.diffuseColor = BABYLON.Color3.FromArray(parsedMaterial["diffuse"]);
            material.specularColor = BABYLON.Color3.FromArray(parsedMaterial["specular"]);
            material.specularPower = parsedMaterial["specularPower"];
            material.emissiveColor = BABYLON.Color3.FromArray(parsedMaterial["emissive"]);
            material.alpha = parsedMaterial["alpha"];
            material.id = parsedMaterial["id"];
            ////BABYLON.Tags.AddTagsTo(material, parsedMaterial["tags"]);
            material.backFaceCulling = parsedMaterial["backFaceCulling"];
            material.wireframe = parsedMaterial["wireframe"];
            if (parsedMaterial["diffuseTexture"])
            {
                material.diffuseTexture = loadTexture(rootUrl, parsedMaterial["diffuseTexture"], scene);
            }
            if (parsedMaterial["ambientTexture"])
            {
                material.ambientTexture = loadTexture(rootUrl, parsedMaterial["ambientTexture"], scene);
            }
            if (parsedMaterial["opacityTexture"])
            {
                material.opacityTexture = loadTexture(rootUrl, parsedMaterial["opacityTexture"], scene);
            }
            if (parsedMaterial["reflectionTexture"])
            {
                material.reflectionTexture = loadTexture(rootUrl, parsedMaterial["reflectionTexture"], scene);
            }
            if (parsedMaterial["emissiveTexture"])
            {
                material.emissiveTexture = loadTexture(rootUrl, parsedMaterial["emissiveTexture"], scene);
            }
            if (parsedMaterial["specularTexture"])
            {
                material.specularTexture = loadTexture(rootUrl, parsedMaterial["specularTexture"], scene);
            }
            if (parsedMaterial["bumpTexture"])
            {
                material.bumpTexture = loadTexture(rootUrl, parsedMaterial["bumpTexture"], scene);
            }

            return material;
        }

        Material parseMaterialById(string id, JsmnParserValue parsedData, Scene scene, string rootUrl)
        {
            var materials = parsedData["materials"];
            for (var index = 0; index < materials.Length; index++)
            {
                var parsedMaterial = materials[index];
                if (parsedMaterial["id"] == id)
                {
                    return parseMaterial(parsedMaterial, scene, rootUrl);
                }
            }
            return null;
        }

        MultiMaterial parseMultiMaterial(JsmnParserValue parsedMultiMaterial, Scene scene)
        {
            var multiMaterial = new BABYLON.MultiMaterial(parsedMultiMaterial["name"], scene);
            multiMaterial.id = parsedMultiMaterial["id"];
            ////BABYLON.Tags.AddTagsTo(multiMaterial, parsedMultiMaterial["tags"]);
            for (var matIndex = 0; matIndex < parsedMultiMaterial["materials"].Length; matIndex++)
            {
                var subMatId = parsedMultiMaterial["materials"][matIndex];
                if (subMatId)
                {
                    multiMaterial.subMaterials.Add(scene.getMaterialByID(subMatId));
                }
                else
                {
                    multiMaterial.subMaterials.Add((Material)null);
                }
            }
            return multiMaterial;
        }

        LensFlareSystem parseLensFlareSystem(JsmnParserValue parsedLensFlareSystem, Scene scene, string rootUrl)
        {
            var emitter = scene.getLastEntryByID(parsedLensFlareSystem["emitterId"]);
            var lensFlareSystem = new BABYLON.LensFlareSystem("lensFlareSystem#" + parsedLensFlareSystem["emitterId"], emitter, scene);
            lensFlareSystem.borderLimit = parsedLensFlareSystem["borderLimit"];
            for (var index = 0; index < parsedLensFlareSystem["flares"].Length; index++)
            {
                var parsedFlare = parsedLensFlareSystem["flares"][index];
                var flare = new BABYLON.LensFlare(parsedFlare["size"], parsedFlare["position"], BABYLON.Color3.FromArray(parsedFlare["color"]), rootUrl + parsedFlare["textureName"], lensFlareSystem);
            }
            return lensFlareSystem;
        }

        ParticleSystem parseParticleSystem(JsmnParserValue parsedParticleSystem, Scene scene, string rootUrl)
        {
            var emitter = scene.getLastMeshByID(parsedParticleSystem["emitterId"]);
            var particleSystem = new BABYLON.ParticleSystem("particles#" + emitter.name, parsedParticleSystem["capacity"], scene);
            if (parsedParticleSystem["textureName"])
            {
                particleSystem.particleTexture = new BABYLON.Texture(rootUrl + parsedParticleSystem["textureName"], scene);
                particleSystem.particleTexture.name = parsedParticleSystem["textureName"];
            }
            particleSystem.minAngularSpeed = parsedParticleSystem["minAngularSpeed"];
            particleSystem.maxAngularSpeed = parsedParticleSystem["maxAngularSpeed"];
            particleSystem.minSize = parsedParticleSystem["minSize"];
            particleSystem.maxSize = parsedParticleSystem["maxSize"];
            particleSystem.minLifeTime = parsedParticleSystem["minLifeTime"];
            particleSystem.maxLifeTime = parsedParticleSystem["maxLifeTime"];
            particleSystem.emitter = emitter;
            particleSystem.emitRate = parsedParticleSystem["emitRate"];
            particleSystem.minEmitBox = BABYLON.Vector3.FromArray(parsedParticleSystem["minEmitBox"]);
            particleSystem.maxEmitBox = BABYLON.Vector3.FromArray(parsedParticleSystem["maxEmitBox"]);
            particleSystem.gravity = BABYLON.Vector3.FromArray(parsedParticleSystem["gravity"]);
            particleSystem.direction1 = BABYLON.Vector3.FromArray(parsedParticleSystem["direction1"]);
            particleSystem.direction2 = BABYLON.Vector3.FromArray(parsedParticleSystem["direction2"]);
            particleSystem.color1 = BABYLON.Color4.FromArray(parsedParticleSystem["color1"]);
            particleSystem.color2 = BABYLON.Color4.FromArray(parsedParticleSystem["color2"]);
            particleSystem.colorDead = BABYLON.Color4.FromArray(parsedParticleSystem["colorDead"]);
            particleSystem.updateSpeed = parsedParticleSystem["updateSpeed"];
            particleSystem.targetStopDuration = parsedParticleSystem["targetStopFrame"];
            particleSystem.textureMask = BABYLON.Color4.FromArray(parsedParticleSystem["textureMask"]);
            particleSystem.blendMode = parsedParticleSystem["blendMode"];
            particleSystem.start();
            return particleSystem;
        }

        ShadowGenerator parseShadowGenerator(JsmnParserValue parsedShadowGenerator, Scene scene)
        {
            var light = scene.getLightByID(parsedShadowGenerator["lightId"]);
            var shadowGenerator = new BABYLON.ShadowGenerator(CreateSize(parsedShadowGenerator["mapSize"]), light as DirectionalLight);
            for (var meshIndex = 0; meshIndex < parsedShadowGenerator["renderList"].Length; meshIndex++)
            {
                var mesh = scene.getMeshByID(parsedShadowGenerator["renderList"][meshIndex]);
                shadowGenerator.getShadowMap().renderList.Add(mesh);
            }
            if (parsedShadowGenerator["usePoissonSampling"])
            {
                shadowGenerator.usePoissonSampling = true;
            }
            else
            {
                shadowGenerator.useVarianceShadowMap = parsedShadowGenerator["useVarianceShadowMap"];
            }
            return shadowGenerator;
        }

        Animation parseAnimation(JsmnParserValue parsedAnimation)
        {
            var animation = new BABYLON.Animation(parsedAnimation["name"], parsedAnimation["property"], parsedAnimation["framePerSecond"], parsedAnimation["dataType"], parsedAnimation["loopBehavior"]);
            var dataType = (int)parsedAnimation["dataType"];
            var animationKeys = new Array<AnimationKey>();
            var keys = parsedAnimation["keys"];
            for (var index = 0; index < keys.Length; index++)
            {
                var key = keys[index];
                var frame = key["frame"];

                object data;
                switch (dataType)
                {
                    case BABYLON.Animation.ANIMATIONTYPE_FLOAT:
                        data = key["values"][0];
                        break;
                    case BABYLON.Animation.ANIMATIONTYPE_QUATERNION:
                        data = BABYLON.Quaternion.FromArray(key["values"]);
                        break;
                    case BABYLON.Animation.ANIMATIONTYPE_MATRIX:
                        data = BABYLON.Matrix.FromArray(key["values"]);
                        break;
                    case BABYLON.Animation.ANIMATIONTYPE_VECTOR3:
                    default:
                        data = BABYLON.Vector3.FromArray(key["values"]);
                        break;
                }
                animationKeys.Add(new AnimationKey() { frame = frame, value = data });
            }

            animation.setKeys(animationKeys);
            return animation;
        }

        void parseLight(JsmnParserValue parsedLight, Scene scene)
        {
            Light light = null;
            switch ((int)parsedLight["type"])
            {
                case 0:
                    light = new BABYLON.PointLight(parsedLight["name"], BABYLON.Vector3.FromArray(parsedLight["position"]), scene);
                    break;
                case 1:
                    var directionalLight = new BABYLON.DirectionalLight(parsedLight["name"], BABYLON.Vector3.FromArray(parsedLight["direction"]), scene);
                    directionalLight.position = BABYLON.Vector3.FromArray(parsedLight["position"]);
                    light = directionalLight;
                    break;
                case 2:
                    light = new BABYLON.SpotLight(parsedLight["name"], BABYLON.Vector3.FromArray(parsedLight["position"]), BABYLON.Vector3.FromArray(parsedLight["direction"]), parsedLight["angle"], parsedLight["exponent"], scene);
                    break;
                case 3:
                    var hemisphericLight = new BABYLON.HemisphericLight(parsedLight["name"], BABYLON.Vector3.FromArray(parsedLight["direction"]), scene);
                    hemisphericLight.groundColor = BABYLON.Color3.FromArray(parsedLight["groundColor"]);
                    light = hemisphericLight;
                    break;
            }

            if (light == null)
            {
                throw new Exception("wrong light type");
            }

            light.id = parsedLight["id"];
            ////BABYLON.Tags.AddTagsTo(light, parsedLight["tags"]);
            if (parsedLight["intensity"])
            {
                light.intensity = parsedLight["intensity"];
            }

            if (parsedLight["range"])
            {
                light.range = parsedLight["range"];
            }

            light.diffuse = BABYLON.Color3.FromArray(parsedLight["diffuse"]);
            light.specular = BABYLON.Color3.FromArray(parsedLight["specular"]);
            if (parsedLight["excludedMeshesIds"])
            {
                light._excludedMeshesIds = Array<string>.New(parsedLight["excludedMeshesIds"]);
            }

            var animations = parsedLight["animations"];
            if (animations)
            {
                for (var animationIndex = 0; animationIndex < animations.Length; animationIndex++)
                {
                    var parsedAnimation = animations[animationIndex];
                    light.animations.Add(parseAnimation(parsedAnimation));
                }
            }

            if (parsedLight["autoAnimate"])
            {
                scene.beginAnimation(light, parsedLight["autoAnimateFrom"], parsedLight["autoAnimateTo"], parsedLight["autoAnimateLoop"], 1.0);
            }
        }

        // TODO: finish tags
        Camera parseCamera(JsmnParserValue parsedCamera, Scene scene)
        {
            var camera = new BABYLON.FreeCamera(parsedCamera["name"], BABYLON.Vector3.FromArray(parsedCamera["position"]), scene);
            camera.id = parsedCamera["id"];
            ////BABYLON.Tags.AddTagsTo(camera, parsedCamera["tags"]);
            if (parsedCamera["parentId"])
            {
                camera._waitingParentId = parsedCamera["parentId"];
            }
            if (parsedCamera["target"])
            {
                camera.setTarget(BABYLON.Vector3.FromArray(parsedCamera["target"]));
            }
            else
            {
                camera.rotation = BABYLON.Vector3.FromArray(parsedCamera["rotation"]);
            }
            if (parsedCamera["lockedTargetId"])
            {
                camera._waitingLockedTargetId = parsedCamera["lockedTargetId"];
            }
            camera.fov = parsedCamera["fov"];
            camera.minZ = parsedCamera["minZ"];
            camera.maxZ = parsedCamera["maxZ"];
            camera.speed = parsedCamera["speed"];
            camera.inertia = parsedCamera["inertia"];
            camera.checkCollisions = parsedCamera["checkCollisions"];
            camera.applyGravity = parsedCamera["applyGravity"];
            if (parsedCamera["ellipsoid"])
            {
                camera.ellipsoid = BABYLON.Vector3.FromArray(parsedCamera["ellipsoid"]);
            }
            if (parsedCamera["animations"])
            {
                for (var animationIndex = 0; animationIndex < parsedCamera["animations"].Length; animationIndex++)
                {
                    var parsedAnimation = parsedCamera["animations"][animationIndex];
                    camera.animations.Add(parseAnimation(parsedAnimation));
                }
            }
            if (parsedCamera["autoAnimate"])
            {
                scene.beginAnimation(camera, parsedCamera["autoAnimateFrom"], parsedCamera["autoAnimateTo"], parsedCamera["autoAnimateLoop"], 1.0);
            }
            if (parsedCamera["layerMask"] && (!Double.IsNaN(parsedCamera["layerMask"])))
            {
                camera.layerMask = (uint)Math.Abs(parsedCamera["layerMask"]);
            }
            else
            {
                camera.layerMask = 0xFFFFFFFF;
            }

            return camera;
        }

        bool parseGeometry(JsmnParserValue parsedGeometry, Scene scene)
        {
            var id = parsedGeometry["id"];
            return scene.getGeometryByID(id) != null;
        }

        Geometry.Primitives.Box parseBox(JsmnParserValue parsedBox, Scene scene)
        {
            if (parseGeometry(parsedBox, scene))
            {
                return null;
            }
            var box = new BABYLON.Geometry.Primitives.Box(parsedBox["id"], scene, parsedBox["size"], parsedBox["canBeRegenerated"], null);
            ////BABYLON.Tags.AddTagsTo(box, parsedBox["tags"]);
            scene.pushGeometry(box, true);
            return box;
        }

        BABYLON.Geometry.Primitives.Sphere parseSphere(JsmnParserValue parsedSphere, Scene scene)
        {
            if (parseGeometry(parsedSphere, scene))
            {
                return null;
            }
            var sphere = new BABYLON.Geometry.Primitives.Sphere(parsedSphere["id"], scene, parsedSphere["segments"], parsedSphere["diameter"], parsedSphere["canBeRegenerated"], null);
            ////BABYLON.Tags.AddTagsTo(sphere, parsedSphere["tags"]);
            scene.pushGeometry(sphere, true);
            return sphere;
        }

        BABYLON.Geometry.Primitives.Cylinder parseCylinder(JsmnParserValue parsedCylinder, Scene scene)
        {
            if (parseGeometry(parsedCylinder, scene))
            {
                return null;
            }
            var cylinder = new BABYLON.Geometry.Primitives.Cylinder(parsedCylinder["id"], scene, parsedCylinder["height"], parsedCylinder["diameterTop"], parsedCylinder["diameterBottom"], parsedCylinder["tessellation"], parsedCylinder["subdivisions"], parsedCylinder["canBeRegenerated"], null);
            ////BABYLON.Tags.AddTagsTo(cylinder, parsedCylinder["tags"]);
            scene.pushGeometry(cylinder, true);
            return cylinder;
        }

        BABYLON.Geometry.Primitives.Torus parseTorus(JsmnParserValue parsedTorus, Scene scene)
        {
            if (parseGeometry(parsedTorus, scene))
            {
                return null;
            }
            var torus = new BABYLON.Geometry.Primitives.Torus(parsedTorus["id"], scene, parsedTorus["diameter"], parsedTorus["thickness"], parsedTorus["tessellation"], parsedTorus["canBeRegenerated"], null);
            ////BABYLON.Tags.AddTagsTo(torus, parsedTorus["tags"]);
            scene.pushGeometry(torus, true);
            return torus;
        }

        BABYLON.Geometry.Primitives.Ground parseGround(JsmnParserValue parsedGround, Scene scene)
        {
            if (parseGeometry(parsedGround, scene))
            {
                return null;
            }
            var ground = new BABYLON.Geometry.Primitives.Ground(parsedGround["id"], scene, parsedGround["width"], parsedGround["height"], parsedGround["subdivisions"], parsedGround["canBeRegenerated"], null);
            ////BABYLON.Tags.AddTagsTo(ground, parsedGround["tags"]);
            scene.pushGeometry(ground, true);
            return ground;
        }

        BABYLON.Geometry.Primitives.Plane parsePlane(JsmnParserValue parsedPlane, Scene scene)
        {
            if (parseGeometry(parsedPlane, scene))
            {
                return null;
            }
            var plane = new BABYLON.Geometry.Primitives.Plane(parsedPlane["id"], scene, parsedPlane["size"], parsedPlane["canBeRegenerated"], null);
            ////BABYLON.Tags.AddTagsTo(plane, parsedPlane["tags"]);
            scene.pushGeometry(plane, true);
            return plane;
        }

        BABYLON.Geometry.Primitives.TorusKnot parseTorusKnot(JsmnParserValue parsedTorusKnot, Scene scene)
        {
            if (parseGeometry(parsedTorusKnot, scene))
            {
                return null;
            }
            var torusKnot = new BABYLON.Geometry.Primitives.TorusKnot(parsedTorusKnot["id"], scene, parsedTorusKnot["radius"], parsedTorusKnot["tube"], parsedTorusKnot["radialSegments"], parsedTorusKnot["tubularSegments"], parsedTorusKnot["p"], parsedTorusKnot["q"], parsedTorusKnot["canBeRegenerated"], null);
            ////BABYLON.Tags.AddTagsTo(torusKnot, parsedTorusKnot["tags"]);
            scene.pushGeometry(torusKnot, true);
            return torusKnot;
        }

        Geometry parseVertexData(JsmnParserValue parsedVertexData, Scene scene, string rootUrl)
        {
            if (parseGeometry(parsedVertexData, scene))
            {
                return null;
            }
            var geometry = new BABYLON.Geometry(parsedVertexData["id"], scene);
            ////BABYLON.Tags.AddTagsTo(geometry, parsedVertexData["tags"]);
            if (parsedVertexData["delayLoadingFile"])
            {
                geometry.delayLoadState = BABYLON.Engine.DELAYLOADSTATE_NOTLOADED;
                geometry.delayLoadingFile = rootUrl + parsedVertexData["delayLoadingFile"];
                geometry._boundingInfo = new BABYLON.BoundingInfo(BABYLON.Vector3.FromArray(parsedVertexData["boundingBoxMinimum"]), BABYLON.Vector3.FromArray(parsedVertexData["boundingBoxMaximum"]));
                geometry._delayInfo = new Array<VertexBufferKind>();
                if (parsedVertexData["hasUVs"])
                {
                    geometry._delayInfo.Add(BABYLON.VertexBufferKind.UVKind);
                }
                if (parsedVertexData["hasUVs2"])
                {
                    geometry._delayInfo.Add(BABYLON.VertexBufferKind.UV2Kind);
                }
                if (parsedVertexData["hasColors"])
                {
                    geometry._delayInfo.Add(BABYLON.VertexBufferKind.ColorKind);
                }
                if (parsedVertexData["hasMatricesIndices"])
                {
                    geometry._delayInfo.Add(BABYLON.VertexBufferKind.MatricesIndicesKind);
                }
                if (parsedVertexData["hasMatricesWeights"])
                {
                    geometry._delayInfo.Add(BABYLON.VertexBufferKind.MatricesWeightsKind);
                }
                geometry._delayLoadingFunction = importVertexData;
            }
            else
            {
                importVertexData(parsedVertexData, geometry);
            }
            scene.pushGeometry(geometry, true);
            return geometry;
        }

        // TODO: finish physics
        Mesh parseMesh(JsmnParserValue parsedMesh, Scene scene, string rootUrl)
        {
            var mesh = new BABYLON.Mesh(parsedMesh["name"], scene);
            mesh.id = parsedMesh["id"];
            ////BABYLON.Tags.AddTagsTo(mesh, parsedMesh["tags"]);
            mesh.position = BABYLON.Vector3.FromArray(parsedMesh["position"]);
            if (parsedMesh["rotationQuaternion"])
            {
                mesh.rotationQuaternion = BABYLON.Quaternion.FromArray(parsedMesh["rotationQuaternion"]);
            }
            else
                if (parsedMesh["rotation"])
                {
                    mesh.rotation = BABYLON.Vector3.FromArray(parsedMesh["rotation"]);
                }
            mesh.scaling = BABYLON.Vector3.FromArray(parsedMesh["scaling"]);
            if (parsedMesh["localMatrix"])
            {
                mesh.setPivotMatrix(BABYLON.Matrix.FromArray(parsedMesh["localMatrix"]));
            }
            else
                if (parsedMesh["pivotMatrix"])
                {
                    mesh.setPivotMatrix(BABYLON.Matrix.FromArray(parsedMesh["pivotMatrix"]));
                }
            mesh.setEnabled(parsedMesh["isEnabled"]);
            mesh.isVisible = parsedMesh["isVisible"];
            mesh.infiniteDistance = parsedMesh["infiniteDistance"];
            mesh.showBoundingBox = parsedMesh["showBoundingBox"];
            mesh.showSubMeshesBoundingBox = parsedMesh["showSubMeshesBoundingBox"];
            if (parsedMesh["pickable"])
            {
                mesh.isPickable = parsedMesh["pickable"];
            }
            mesh.receiveShadows = parsedMesh["receiveShadows"];
            mesh.billboardMode = parsedMesh["billboardMode"];
            if (parsedMesh["visibility"])
            {
                mesh.visibility = parsedMesh["visibility"];
            }
            mesh.checkCollisions = parsedMesh["checkCollisions"];
            mesh._shouldGenerateFlatShading = parsedMesh["useFlatShading"];
            if (parsedMesh["parentId"])
            {
                mesh.parent = scene.getLastEntryByID(parsedMesh["parentId"]);
            }
            if (parsedMesh["delayLoadingFile"])
            {
                mesh.delayLoadState = BABYLON.Engine.DELAYLOADSTATE_NOTLOADED;
                mesh.delayLoadingFile = rootUrl + parsedMesh["delayLoadingFile"];
                mesh._boundingInfo = new BABYLON.BoundingInfo(BABYLON.Vector3.FromArray(parsedMesh["boundingBoxMinimum"]), BABYLON.Vector3.FromArray(parsedMesh["boundingBoxMaximum"]));
                mesh._delayInfo = new Array<VertexBufferKind>();
                if (parsedMesh["hasUVs"])
                {
                    mesh._delayInfo.Add(BABYLON.VertexBufferKind.UVKind);
                }
                if (parsedMesh["hasUVs2"])
                {
                    mesh._delayInfo.Add(BABYLON.VertexBufferKind.UV2Kind);
                }
                if (parsedMesh["hasColors"])
                {
                    mesh._delayInfo.Add(BABYLON.VertexBufferKind.ColorKind);
                }
                if (parsedMesh["hasMatricesIndices"])
                {
                    mesh._delayInfo.Add(BABYLON.VertexBufferKind.MatricesIndicesKind);
                }
                if (parsedMesh["hasMatricesWeights"])
                {
                    mesh._delayInfo.Add(BABYLON.VertexBufferKind.MatricesWeightsKind);
                }
                mesh._delayLoadingFunction = importGeometry;
                if (BABYLON.SceneLoader.ForceFullSceneLoadingForIncremental)
                {
                    mesh._checkDelayState();
                }
            }
            else
            {
                importGeometry(parsedMesh, mesh);
            }
            if (parsedMesh["materialId"])
            {
                mesh.setMaterialByID(parsedMesh["materialId"]);
            }
            else
            {
                mesh.material = null;
            }
            if (parsedMesh["skeletonId"] > -1)
            {
                mesh.skeleton = scene.getLastSkeletonByID(parsedMesh["skeletonId"]);
            }
            if (parsedMesh["physicsImpostor"])
            {
                if (!scene.isPhysicsEnabled())
                {
                    //scene.enablePhysics();
                }
                mesh.setPhysicsState();
            }
            if (parsedMesh["animations"])
            {
                for (var animationIndex = 0; animationIndex < parsedMesh["animations"].Length; animationIndex++)
                {
                    var parsedAnimation = parsedMesh["animations"][animationIndex];
                    mesh.animations.Add(parseAnimation(parsedAnimation));
                }
            }
            if (parsedMesh["autoAnimate"])
            {
                scene.beginAnimation(mesh, parsedMesh["autoAnimateFrom"], parsedMesh["autoAnimateTo"], parsedMesh["autoAnimateLoop"], 1.0);
            }
            if (parsedMesh["layerMask"] && (!Double.IsNaN(parsedMesh["layerMask"])))
            {
                mesh.layerMask = (uint)Math.Abs((int)parsedMesh["layerMask"]);
            }
            else
            {
                mesh.layerMask = 0xFFFFFFFF;
            }
            if (parsedMesh["instances"])
            {
                for (var index = 0; index < parsedMesh["instances"].Length; index++)
                {
                    var parsedInstance = parsedMesh["instances"][index];
                    var instance = mesh.createInstance(parsedInstance["name"]);
                    ////BABYLON.Tags.AddTagsTo(instance, parsedInstance["tags"]);
                    instance.position = BABYLON.Vector3.FromArray(parsedInstance["position"]);
                    if (parsedInstance["rotationQuaternion"])
                    {
                        instance.rotationQuaternion = BABYLON.Quaternion.FromArray(parsedInstance["rotationQuaternion"]);
                    }
                    else
                        if (parsedInstance["rotation"])
                        {
                            instance.rotation = BABYLON.Vector3.FromArray(parsedInstance["rotation"]);
                        }
                    instance.scaling = BABYLON.Vector3.FromArray(parsedInstance["scaling"]);
                    instance.checkCollisions = mesh.checkCollisions;
                    var animations = parsedMesh["animations"];
                    if (animations)
                    {
                        for (var animationIndex = 0; animationIndex < animations.Length; animationIndex++)
                        {
                            var parsedAnimation = animations[animationIndex];
                            instance.animations.Add(parseAnimation(parsedAnimation));
                        }
                    }
                }
            }
            return mesh;
        }

        void importVertexData(JsmnParserValue parsedVertexData, Geometry geometry)
        {
            var vertexData = new BABYLON.VertexData();
            var positions = parsedVertexData["positions"];
            if (positions)
            {
                vertexData.set(Array<double>.New(positions), BABYLON.VertexBufferKind.PositionKind);
            }
            var normals = parsedVertexData["normals"];
            if (normals)
            {
                vertexData.set(Array<double>.New(normals), BABYLON.VertexBufferKind.NormalKind);
            }
            var uvs = parsedVertexData["uvs"];
            if (uvs)
            {
                vertexData.set(Array<double>.New(uvs), BABYLON.VertexBufferKind.UVKind);
            }
            var uv2s = parsedVertexData["uv2s"];
            if (uv2s)
            {
                vertexData.set(Array<double>.New(uv2s), BABYLON.VertexBufferKind.UV2Kind);
            }
            var colors = parsedVertexData["colors"];
            if (colors)
            {
                vertexData.set(Array<double>.New(colors), BABYLON.VertexBufferKind.ColorKind);
            }
            var matricesIndices = parsedVertexData["matricesIndices"];
            if (matricesIndices)
            {
                vertexData.set(Array<double>.New(matricesIndices), BABYLON.VertexBufferKind.MatricesIndicesKind);
            }
            var matricesWeights = parsedVertexData["matricesWeights"];
            if (matricesWeights)
            {
                vertexData.set(Array<double>.New(matricesWeights), BABYLON.VertexBufferKind.MatricesWeightsKind);
            }
            var indices = parsedVertexData["indices"];
            if (indices)
            {
                vertexData.indices = Array<int>.New(ArrayConvert.AsInt(indices));
            }

            geometry.setAllVerticesData(vertexData, parsedVertexData["updatable"]);
        }

        void importGeometry(JsmnParserValue parsedGeometry, Mesh mesh)
        {
            var scene = mesh.getScene();
            var geometryId = parsedGeometry["geometryId"];
            if (geometryId)
            {
                var geometry = scene.getGeometryByID(geometryId);
                if (geometry != null)
                {
                    geometry.applyToMesh(mesh);
                }
            }
            else
            {
                var positions = parsedGeometry["positions"];
                var normals = parsedGeometry["normals"];
                var indices = parsedGeometry["indices"];
                if (positions && normals && indices)
                {
                    mesh.setVerticesData(BABYLON.VertexBufferKind.PositionKind, Array<double>.New(positions), false);
                    mesh.setVerticesData(BABYLON.VertexBufferKind.NormalKind, Array<double>.New(normals), false);
                    var uvs = parsedGeometry["uvs"];
                    if (uvs)
                    {
                        mesh.setVerticesData(BABYLON.VertexBufferKind.UVKind, Array<double>.New(uvs), false);
                    }
                    var uvs2 = parsedGeometry["uvs2"];
                    if (uvs2)
                    {
                        mesh.setVerticesData(BABYLON.VertexBufferKind.UV2Kind, Array<double>.New(uvs2), false);
                    }
                    var colors = parsedGeometry["colors"];
                    if (colors)
                    {
                        mesh.setVerticesData(BABYLON.VertexBufferKind.ColorKind, Array<double>.New(colors), false);
                    }
                    var matricesIndices = parsedGeometry["matricesIndices"];
                    if (matricesIndices)
                    {
                        if (!matricesIndices["_isExpanded"])
                        {
                            var floatIndices = new Array<double>();
                            for (var i = 0; i < matricesIndices.Length; i++)
                            {
                                var matricesIndex = matricesIndices[i];
                                floatIndices.Add(matricesIndex & 0x000000FF);
                                floatIndices.Add((matricesIndex & 0x0000FF00) << 8);
                                floatIndices.Add((matricesIndex & 0x00FF0000) << 16);
                                floatIndices.Add(matricesIndex << 24);
                            }
                            mesh.setVerticesData(BABYLON.VertexBufferKind.MatricesIndicesKind, floatIndices, false);
                        }
                        else
                        {
                            mesh.setVerticesData(BABYLON.VertexBufferKind.MatricesIndicesKind, Array<double>.New(matricesIndices), false);
                        }
                    }
                    
                    var matricesWeights = parsedGeometry["matricesWeights"];
                    if (matricesWeights)
                    {
                        mesh.setVerticesData(BABYLON.VertexBufferKind.MatricesWeightsKind, Array<double>.New(matricesWeights), false);
                    }

                    mesh.setIndices(Array<int>.New(ArrayConvert.AsInt(indices)));
                }
            }
            var subMeshes = parsedGeometry["subMeshes"];
            if (subMeshes)
            {
                mesh.subMeshes = new Array<SubMesh>();
                for (var subIndex = 0; subIndex < subMeshes.Length; subIndex++)
                {
                    var parsedSubMesh = subMeshes[subIndex];
                    var subMesh = new BABYLON.SubMesh(parsedSubMesh["materialIndex"], parsedSubMesh["verticesStart"], parsedSubMesh["verticesCount"], parsedSubMesh["indexStart"], parsedSubMesh["indexCount"], mesh);
                }
            }
            if (mesh._shouldGenerateFlatShading)
            {
                mesh.convertToFlatShadedMesh();
                mesh._shouldGenerateFlatShading = false;
            }
            mesh.computeWorldMatrix(true);
            if (scene._selectionOctree != null)
            {
                scene._selectionOctree.addMesh(mesh);
            }
        }

        public string extensions
        {
            get
            {
                return _extensions;
            }
            set
            {
                _extensions = value;
            }
        }

        public bool isDescendantOf(JsmnParserValue mesh, Array<string> names, Array<string> hierarchyIds)
        {
            foreach (var name in names)
            {
                if (mesh["name"] == name)
                {
                    hierarchyIds.Add((string)mesh["id"]);
                    return true;
                }
            }

            if (mesh["parentId"] && hierarchyIds.IndexOf(mesh["parentId"]) != -1)
            {
                hierarchyIds.Add((string)mesh["id"]);
                return true;
            }

            return false;
        }

        public bool importMesh(Array<string> meshesNames, Scene scene, string data, string rootUrl, Array<AbstractMesh> meshes, Array<ParticleSystem> particleSystems, Array<Skeleton> skeletons)
        {
            var parsedData = JsmnParser.Parse(data);

            var loadedSkeletonsIds = new Array<string>();
            var loadedMaterialsIds = new Array<string>();
            var hierarchyIds = new Array<string>();
            var meshes1 = parsedData["meshes"];
            for (var index = 0; index < meshes1.Length; index++)
            {
                var parsedMesh = meshes1[index];

                if (meshesNames != null || isDescendantOf(parsedMesh, meshesNames, hierarchyIds))
                {
                    // Remove found mesh name from list.
                    var name = parsedMesh["name"];
                    var indexOf = meshesNames.IndexOf(name);
                    if (indexOf != -1)
                    {
                        meshesNames.RemoveAt(indexOf);
                    }

                    // Material ?
                    if (parsedMesh["materialId"])
                    {
                        var materialFound = (loadedMaterialsIds.IndexOf(parsedMesh["materialId"]) != -1);

                        if (!materialFound)
                        {
                            var multiMaterials = parsedData["multiMaterials"];
                            for (var multimatIndex = 0; multimatIndex < multiMaterials.Length; multimatIndex++)
                            {
                                var parsedMultiMaterial = multiMaterials[multimatIndex];
                                if ((string)parsedMultiMaterial["id"] == (string)parsedMesh["materialId"])
                                {
                                    var materials = parsedMultiMaterial["materials"];
                                    for (var matIndex = 0; matIndex < materials.Length; matIndex++)
                                    {
                                        var subMatId = materials[matIndex];
                                        loadedMaterialsIds.Add((string)subMatId);
                                        parseMaterialById(subMatId, parsedData, scene, rootUrl);
                                    }

                                    loadedMaterialsIds.Add((string)parsedMultiMaterial["id"]);
                                    parseMultiMaterial(parsedMultiMaterial, scene);
                                    materialFound = true;
                                    break;
                                }
                            }
                        }

                        if (!materialFound)
                        {
                            loadedMaterialsIds.Add((string)parsedMesh["materialId"]);
                            parseMaterialById(parsedMesh["materialId"], parsedData, scene, rootUrl);
                        }
                    }

                    // Skeleton ?
                    if (parsedMesh["skeletonId"] > -1 && scene.skeletons != null)
                    {
                        var skeletonAlreadyLoaded = (loadedSkeletonsIds.IndexOf(parsedMesh["skeletonId"]) > -1);

                        if (!skeletonAlreadyLoaded)
                        {
                            var skeletons1 = parsedData["skeletons"];
                            for (var skeletonIndex = 0; skeletonIndex < skeletons1.Length; skeletonIndex++)
                            {
                                var parsedSkeleton = skeletons1[skeletonIndex];

                                if ((string)parsedSkeleton["id"] == (string)parsedMesh["skeletonId"])
                                {
                                    skeletons.Add(parseSkeleton(parsedSkeleton, scene));
                                    loadedSkeletonsIds.Add((string)parsedSkeleton["id"]);
                                }
                            }
                        }
                    }

                    var mesh = parseMesh(parsedMesh, scene, rootUrl);
                    meshes.Add(mesh);
                }
            }

            // Particles
            if (parsedData["particleSystems"])
            {
                for (var index = 0; index < parsedData["particleSystems"].Length; index++)
                {
                    var parsedParticleSystem = parsedData["particleSystems"][index];

                    if (hierarchyIds.IndexOf(parsedParticleSystem["emitterId"]) != -1)
                    {
                        particleSystems.Add(parseParticleSystem(parsedParticleSystem, scene, rootUrl));
                    }
                }
            }

            return true;
        }

        public bool load(Scene scene, string data, string rootUrl)
        {
            var parsedData = JsmnParser.Parse(data);

            // Scene
            scene.useDelayedTextureLoading = parsedData["useDelayedTextureLoading"] && !BABYLON.SceneLoader.ForceFullSceneLoadingForIncremental;
            scene.autoClear = parsedData["autoClear"];

            scene.clearColor = BABYLON.Color3.FromArray(parsedData["clearColor"]);

            scene.ambientColor = BABYLON.Color3.FromArray(parsedData["ambientColor"]);

            scene.gravity = BABYLON.Vector3.FromArray(parsedData["gravity"]);

            // Fog
            if (parsedData["fogMode"] && parsedData["fogMode"] != 0)
            {
                scene.fogMode = parsedData["fogMode"];
                scene.fogColor = BABYLON.Color3.FromArray(parsedData["fogColor"]);
                scene.fogStart = parsedData["fogStart"];
                scene.fogEnd = parsedData["fogEnd"];
                scene.fogDensity = parsedData["fogDensity"];
            }

            // Lights
            var lights = parsedData["lights"];
            for (var index = 0; index < lights.Length; index++)
            {
                var parsedLight = lights[index];
                parseLight(parsedLight, scene);
            }

            // Cameras
            var cameras = parsedData["cameras"];
            for (var index = 0; index < cameras.Length; index++)
            {
                var parsedCamera = cameras[index];
                parseCamera(parsedCamera, scene);
            }

            if (parsedData["activeCameraID"])
            {
                scene.setActiveCameraByID(parsedData["activeCameraID"]);
            }

            // Materials
            var materials = parsedData["materials"];
            if (materials)
            {
                for (var index = 0; index < materials.Length; index++)
                {
                    var parsedMaterial = materials[index];
                    parseMaterial(parsedMaterial, scene, rootUrl);
                }
            }

            var multiMaterials = parsedData["multiMaterials"];
            if (multiMaterials)
            {
                for (var index = 0; index < multiMaterials.Length; index++)
                {
                    var parsedMultiMaterial = multiMaterials[index];
                    parseMultiMaterial(parsedMultiMaterial, scene);
                }
            }

            // Skeletons
            var skeletons = parsedData["skeletons"];
            if (skeletons)
            {
                for (var index = 0; index < skeletons.Length; index++)
                {
                    var parsedSkeleton = skeletons[index];
                    parseSkeleton(parsedSkeleton, scene);
                }
            }

            // Geometries
            var geometries = parsedData["geometries"];
            if (geometries)
            {
                // Boxes
                var boxes = geometries["boxes"];
                if (boxes)
                {
                    for (var index = 0; index < boxes.Length; index++)
                    {
                        var parsedBox = boxes[index];
                        parseBox(parsedBox, scene);
                    }
                }

                // Spheres
                var spheres = geometries["spheres"];
                if (spheres)
                {
                    for (var index = 0; index < spheres.Length; index++)
                    {
                        var parsedSphere = spheres[index];
                        parseSphere(parsedSphere, scene);
                    }
                }

                // Cylinders
                var cylinders = geometries["cylinders"];
                if (cylinders)
                {
                    for (var index = 0; index < cylinders.Length; index++)
                    {
                        var parsedCylinder = cylinders[index];
                        parseCylinder(parsedCylinder, scene);
                    }
                }

                // Toruses
                var toruses = geometries["toruses"];
                if (toruses)
                {
                    for (var index = 0; index < toruses.Length; index++)
                    {
                        var parsedTorus = toruses[index];
                        parseTorus(parsedTorus, scene);
                    }
                }

                // Grounds
                var grounds = geometries["grounds"];
                if (grounds)
                {
                    for (var index = 0; index < grounds.Length; index++)
                    {
                        var parsedGround = grounds[index];
                        parseGround(parsedGround, scene);
                    }
                }

                // Planes
                var planes = geometries["planes"];
                if (planes)
                {
                    for (var index = 0; index < planes.Length; index++)
                    {
                        var parsedPlane = planes[index];
                        parsePlane(parsedPlane, scene);
                    }
                }

                // TorusKnots
                var torusKnots = geometries["torusKnots"];
                if (torusKnots)
                {
                    for (var index = 0; index < torusKnots.Length; index++)
                    {
                        var parsedTorusKnot = torusKnots[index];
                        parseTorusKnot(parsedTorusKnot, scene);
                    }
                }

                // VertexData
                var vertexData = geometries["vertexData"];
                if (vertexData)
                {
                    for (var index = 0; index < vertexData.Length; index++)
                    {
                        var parsedVertexData = vertexData[index];
                        parseVertexData(parsedVertexData, scene, rootUrl);
                    }
                }
            }

            // Meshes
            var meshes = parsedData["meshes"];
            for (var index = 0; index < meshes.Length; index++)
            {
                var parsedMesh = meshes[index];
                parseMesh(parsedMesh, scene, rootUrl);
            }

            // Connecting cameras parents and locked target
            for (var index = 0; index < scene.cameras.Length; index++)
            {
                var camera = scene.cameras[index];
                if (camera._waitingParentId != null)
                {
                    camera.parent = scene.getLastEntryByID(camera._waitingParentId);
                    camera._waitingParentId = null;
                }

                if (camera is BABYLON.FreeCamera)
                {
                    var freecamera = (FreeCamera)camera;
                    if (freecamera._waitingLockedTargetId != null)
                    {
                        freecamera.lockedTarget = scene.getLastEntryByID(freecamera._waitingLockedTargetId);
                        freecamera._waitingLockedTargetId = null;
                    }
                }
            }

            // Particles Systems
            var particleSystems = parsedData["particleSystems"];
            if (particleSystems)
            {
                for (var index = 0; index < particleSystems.Length; index++)
                {
                    var parsedParticleSystem = particleSystems[index];
                    parseParticleSystem(parsedParticleSystem, scene, rootUrl);
                }
            }

            // Lens flares
            var lensFlareSystems = parsedData["lensFlareSystems"];
            if (lensFlareSystems)
            {
                for (var index = 0; index < lensFlareSystems.Length; index++)
                {
                    var parsedLensFlareSystem = lensFlareSystems[index];
                    parseLensFlareSystem(parsedLensFlareSystem, scene, rootUrl);
                }
            }

            // Shadows
            var shadowGenerators = parsedData["shadowGenerators"];
            if (shadowGenerators)
            {
                for (var index = 0; index < shadowGenerators.Length; index++)
                {
                    var parsedShadowGenerator = shadowGenerators[index];

                    parseShadowGenerator(parsedShadowGenerator, scene);
                }
            }

            return true;
        }
    }
}