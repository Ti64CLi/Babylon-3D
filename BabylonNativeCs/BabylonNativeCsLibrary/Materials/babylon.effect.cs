using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class Effect {
        public EffectBaseName name;
        public string defines;
        public System.Action < Effect > onCompiled;
        public System.Action < Effect, string > onError;
        private Engine _engine;
        private Array < string > _uniformsNames;
        private Array < string > _samplers;
        private bool _isReady = false;
        private string _compilationError = "";
        private Array < VertexBufferKind > _attributes;
        private Array < string > _attributesNames;
        private Array < int > _attributes;
        private Array < WebGLUniformLocation > _uniforms;
        public string _key;
        public WebGLProgram _program;
        private Array < object > _valueCache = new Array < object > ();

        private Web.Document document;

        public Effect(EffectBaseName baseName, Array < string > attributesNames, Array < string > uniformsNames, Array < string > samplers, object engine, string defines = null, Array < string > optionalDefines = null, System.Action < Effect > onCompiled = null, System.Action < Effect, string > onError = null) {
            this._engine = engine;
            this.name = baseName;
            this.defines = defines;
            this._uniformsNames = uniformsNames.concat(samplers);
            this._samplers = samplers;
            this._attributesNames = attributesNames;
            this.onError = onError;
            this.onCompiled = onCompiled;
            var vertexSource;
            var fragmentSource;
            if (baseName.vertexElement) {
                vertexSource = document.getElementById(baseName.vertexElement);
                fragmentSource = document.getElementById(baseName.fragmentElement);
            } else {
                vertexSource = baseName.vertexElement ?? baseName.vertex ?? baseName.baseName;
                fragmentSource = baseName.fragmentElement ?? baseName.fragment ?? baseName.baseName;
            }
            this._loadVertexShader(vertexSource, (vertexCode) => {
                this._loadFragmentShader(fragmentSource, (object fragmentCode) => {
                    this._prepareEffect(vertexCode, fragmentCode, attributesNames, defines, optionalDefines);
                });
            });
        };
        void loadCubeTexture(object rootUrl, object parsedTexture, object scene) {
            var texture = new BABYLON.CubeTexture(rootUrl + parsedTexture.name, scene);
            texture.name = parsedTexture.name;
            texture.hasAlpha = parsedTexture.hasAlpha;
            texture.level = parsedTexture.level;
            texture.coordinatesMode = parsedTexture.coordinatesMode;
            return texture;
        };
        void loadTexture(object rootUrl, object parsedTexture, object scene) {
            if (!parsedTexture.name && !parsedTexture.isRenderTarget) {
                return null;
            }
            if (parsedTexture.isCube) {
                return loadCubeTexture(rootUrl, parsedTexture, scene);
            }
            var texture;
            if (parsedTexture.mirrorPlane) {
                texture = new BABYLON.MirrorTexture(parsedTexture.name, parsedTexture.renderTargetSize, scene);
                texture._waitingRenderList = parsedTexture.renderList;
                texture.mirrorPlane = BABYLON.Plane.FromArray(parsedTexture.mirrorPlane);
            } else
            if (parsedTexture.isRenderTarget) {
                texture = new BABYLON.RenderTargetTexture(parsedTexture.name, parsedTexture.renderTargetSize, scene);
                texture._waitingRenderList = parsedTexture.renderList;
            } else {
                texture = new BABYLON.Texture(rootUrl + parsedTexture.name, scene);
            }
            texture.name = parsedTexture.name;
            texture.hasAlpha = parsedTexture.hasAlpha;
            texture.getAlphaFromRGB = parsedTexture.getAlphaFromRGB;
            texture.level = parsedTexture.level;
            texture.coordinatesIndex = parsedTexture.coordinatesIndex;
            texture.coordinatesMode = parsedTexture.coordinatesMode;
            texture.uOffset = parsedTexture.uOffset;
            texture.vOffset = parsedTexture.vOffset;
            texture.uScale = parsedTexture.uScale;
            texture.vScale = parsedTexture.vScale;
            texture.uAng = parsedTexture.uAng;
            texture.vAng = parsedTexture.vAng;
            texture.wAng = parsedTexture.wAng;
            texture.wrapU = parsedTexture.wrapU;
            texture.wrapV = parsedTexture.wrapV;
            if (parsedTexture.animations) {
                for (var animationIndex = 0; animationIndex < parsedTexture.animations.Length; animationIndex++) {
                    var parsedAnimation = parsedTexture.animations[animationIndex];
                    texture.animations.push(parseAnimation(parsedAnimation));
                }
            }
            return texture;
        };
        void parseSkeleton(object parsedSkeleton, object scene) {
            var skeleton = new BABYLON.Skeleton(parsedSkeleton.name, parsedSkeleton.id, scene);
            for (var index = 0; index < parsedSkeleton.bones.Length; index++) {
                var parsedBone = parsedSkeleton.bones[index];
                var parentBone = null;
                if (parsedBone.parentBoneIndex > -1) {
                    parentBone = skeleton.bones[parsedBone.parentBoneIndex];
                }
                var bone = new BABYLON.Bone(parsedBone.name, skeleton, parentBone, BABYLON.Matrix.FromArray(parsedBone.matrix));
                if (parsedBone.animation) {
                    bone.animations.push(parseAnimation(parsedBone.animation));
                }
            }
            return skeleton;
        };
        void parseMaterial(object parsedMaterial, object scene, object rootUrl) {
            var material;
            material = new BABYLON.StandardMaterial(parsedMaterial.name, scene);
            material.ambientColor = BABYLON.Color3.FromArray(parsedMaterial.ambient);
            material.diffuseColor = BABYLON.Color3.FromArray(parsedMaterial.diffuse);
            material.specularColor = BABYLON.Color3.FromArray(parsedMaterial.specular);
            material.specularPower = parsedMaterial.specularPower;
            material.emissiveColor = BABYLON.Color3.FromArray(parsedMaterial.emissive);
            material.alpha = parsedMaterial.alpha;
            material.id = parsedMaterial.id;
            BABYLON.Tags.AddTagsTo(material, parsedMaterial.tags);
            material.backFaceCulling = parsedMaterial.backFaceCulling;
            material.wireframe = parsedMaterial.wireframe;
            if (parsedMaterial.diffuseTexture) {
                material.diffuseTexture = loadTexture(rootUrl, parsedMaterial.diffuseTexture, scene);
            }
            if (parsedMaterial.ambientTexture) {
                material.ambientTexture = loadTexture(rootUrl, parsedMaterial.ambientTexture, scene);
            }
            if (parsedMaterial.opacityTexture) {
                material.opacityTexture = loadTexture(rootUrl, parsedMaterial.opacityTexture, scene);
            }
            if (parsedMaterial.reflectionTexture) {
                material.reflectionTexture = loadTexture(rootUrl, parsedMaterial.reflectionTexture, scene);
            }
            if (parsedMaterial.emissiveTexture) {
                material.emissiveTexture = loadTexture(rootUrl, parsedMaterial.emissiveTexture, scene);
            }
            if (parsedMaterial.specularTexture) {
                material.specularTexture = loadTexture(rootUrl, parsedMaterial.specularTexture, scene);
            }
            if (parsedMaterial.bumpTexture) {
                material.bumpTexture = loadTexture(rootUrl, parsedMaterial.bumpTexture, scene);
            }
            return material;
        };
        void parseMaterialById(object id, object parsedData, object scene, object rootUrl) {
            for (var index = 0; index < parsedData.materials.Length; index++) {
                var parsedMaterial = parsedData.materials[index];
                if (parsedMaterial.id == id) {
                    return parseMaterial(parsedMaterial, scene, rootUrl);
                }
            }
            return null;
        };
        void parseMultiMaterial(object parsedMultiMaterial, object scene) {
            var multiMaterial = new BABYLON.MultiMaterial(parsedMultiMaterial.name, scene);
            multiMaterial.id = parsedMultiMaterial.id;
            BABYLON.Tags.AddTagsTo(multiMaterial, parsedMultiMaterial.tags);
            for (var matIndex = 0; matIndex < parsedMultiMaterial.materials.Length; matIndex++) {
                var subMatId = parsedMultiMaterial.materials[matIndex];
                if (subMatId) {
                    multiMaterial.subMaterials.push(scene.getMaterialByID(subMatId));
                } else {
                    multiMaterial.subMaterials.push(null);
                }
            }
            return multiMaterial;
        };
        void parseLensFlareSystem(object parsedLensFlareSystem, object scene, object rootUrl) {
            var emitter = scene.getLastEntryByID(parsedLensFlareSystem.emitterId);
            var lensFlareSystem = new BABYLON.LensFlareSystem("lensFlareSystem#" + parsedLensFlareSystem.emitterId, emitter, scene);
            lensFlareSystem.borderLimit = parsedLensFlareSystem.borderLimit;
            for (var index = 0; index < parsedLensFlareSystem.flares.Length; index++) {
                var parsedFlare = parsedLensFlareSystem.flares[index];
                var flare = new BABYLON.LensFlare(parsedFlare.size, parsedFlare.position, BABYLON.Color3.FromArray(parsedFlare.color), rootUrl + parsedFlare.textureName, lensFlareSystem);
            }
            return lensFlareSystem;
        };
        void parseParticleSystem(object parsedParticleSystem, object scene, object rootUrl) {
            var emitter = scene.getLastMeshByID(parsedParticleSystem.emitterId);
            var particleSystem = new BABYLON.ParticleSystem("particles#" + emitter.name, parsedParticleSystem.capacity, scene);
            if (parsedParticleSystem.textureName) {
                particleSystem.particleTexture = new BABYLON.Texture(rootUrl + parsedParticleSystem.textureName, scene);
                particleSystem.particleTexture.name = parsedParticleSystem.textureName;
            }
            particleSystem.minAngularSpeed = parsedParticleSystem.minAngularSpeed;
            particleSystem.maxAngularSpeed = parsedParticleSystem.maxAngularSpeed;
            particleSystem.minSize = parsedParticleSystem.minSize;
            particleSystem.maxSize = parsedParticleSystem.maxSize;
            particleSystem.minLifeTime = parsedParticleSystem.minLifeTime;
            particleSystem.maxLifeTime = parsedParticleSystem.maxLifeTime;
            particleSystem.emitter = emitter;
            particleSystem.emitRate = parsedParticleSystem.emitRate;
            particleSystem.minEmitBox = BABYLON.Vector3.FromArray(parsedParticleSystem.minEmitBox);
            particleSystem.maxEmitBox = BABYLON.Vector3.FromArray(parsedParticleSystem.maxEmitBox);
            particleSystem.gravity = BABYLON.Vector3.FromArray(parsedParticleSystem.gravity);
            particleSystem.direction1 = BABYLON.Vector3.FromArray(parsedParticleSystem.direction1);
            particleSystem.direction2 = BABYLON.Vector3.FromArray(parsedParticleSystem.direction2);
            particleSystem.color1 = BABYLON.Color4.FromArray(parsedParticleSystem.color1);
            particleSystem.color2 = BABYLON.Color4.FromArray(parsedParticleSystem.color2);
            particleSystem.colorDead = BABYLON.Color4.FromArray(parsedParticleSystem.colorDead);
            particleSystem.updateSpeed = parsedParticleSystem.updateSpeed;
            particleSystem.targetStopDuration = parsedParticleSystem.targetStopFrame;
            particleSystem.textureMask = BABYLON.Color4.FromArray(parsedParticleSystem.textureMask);
            particleSystem.blendMode = parsedParticleSystem.blendMode;
            particleSystem.start();
            return particleSystem;
        };
        void parseShadowGenerator(object parsedShadowGenerator, object scene) {
            var light = scene.getLightByID(parsedShadowGenerator.lightId);
            var shadowGenerator = new BABYLON.ShadowGenerator(parsedShadowGenerator.mapSize, light);
            for (var meshIndex = 0; meshIndex < parsedShadowGenerator.renderList.Length; meshIndex++) {
                var mesh = scene.getMeshByID(parsedShadowGenerator.renderList[meshIndex]);
                shadowGenerator.getShadowMap().renderList.push(mesh);
            }
            if (parsedShadowGenerator.usePoissonSampling) {
                shadowGenerator.usePoissonSampling = true;
            } else {
                shadowGenerator.useVarianceShadowMap = parsedShadowGenerator.useVarianceShadowMap;
            }
            return shadowGenerator;
        };
        void parseAnimation(parsedAnimation) {
            void animationnew BABYLON.Animation(parsedAnimation.name, parsedAnimation.property, parsedAnimation.framePerSecond, parsedAnimation.dataType, parsedAnimation.loopBehavior);
            void dataTypeparsedAnimation.dataType;
            void keysnew Array < object > ();
            for (void index0; index < parsedAnimation.keys.Length; index++) {
                void keyparsedAnimation.keys[index];
                void data;
                switch (dataType) {
                    case BABYLON.Animation.ANIMATIONTYPE_FLOAT:
                        data = key.values[0];
                        break;
                    case BABYLON.Animation.ANIMATIONTYPE_QUATERNION:
                        data = BABYLON.Quaternion.FromArray(key.values);
                        break;
                    case BABYLON.Animation.ANIMATIONTYPE_MATRIX:
                        data = BABYLON.Matrix.FromArray(key.values);
                        break;
                    case BABYLON.Animation.ANIMATIONTYPE_VECTOR3:
                    default:
                        data = BABYLON.Vector3.FromArray(key.values);
                        break;
                }
                keys.push(new {});
            }
            animation.setKeys(keys);
            return animation;
        };
        void parseLight(object parsedLight, object scene) {
            var light;
            switch (parsedLight.type) {
                case 0:
                    light = new BABYLON.PointLight(parsedLight.name, BABYLON.Vector3.FromArray(parsedLight.position), scene);
                    break;
                case 1:
                    light = new BABYLON.DirectionalLight(parsedLight.name, BABYLON.Vector3.FromArray(parsedLight.direction), scene);
                    light.position = BABYLON.Vector3.FromArray(parsedLight.position);
                    break;
                case 2:
                    light = new BABYLON.SpotLight(parsedLight.name, BABYLON.Vector3.FromArray(parsedLight.position), BABYLON.Vector3.FromArray(parsedLight.direction), parsedLight.angle, parsedLight.exponent, scene);
                    break;
                case 3:
                    light = new BABYLON.HemisphericLight(parsedLight.name, BABYLON.Vector3.FromArray(parsedLight.direction), scene);
                    light.groundColor = BABYLON.Color3.FromArray(parsedLight.groundColor);
                    break;
            }
            light.id = parsedLight.id;
            BABYLON.Tags.AddTagsTo(light, parsedLight.tags);
            if (parsedLight.intensity != null) {
                light.intensity = parsedLight.intensity;
            }
            if (parsedLight.range) {
                light.range = parsedLight.range;
            }
            light.diffuse = BABYLON.Color3.FromArray(parsedLight.diffuse);
            light.specular = BABYLON.Color3.FromArray(parsedLight.specular);
            if (parsedLight.excludedMeshesIds) {
                light._excludedMeshesIds = parsedLight.excludedMeshesIds;
            }
            if (parsedLight.animations) {
                for (var animationIndex = 0; animationIndex < parsedLight.animations.Length; animationIndex++) {
                    var parsedAnimation = parsedLight.animations[animationIndex];
                    light.animations.push(parseAnimation(parsedAnimation));
                }
            }
            if (parsedLight.autoAnimate) {
                scene.beginAnimation(light, parsedLight.autoAnimateFrom, parsedLight.autoAnimateTo, parsedLight.autoAnimateLoop, 1.0);
            }
        };
        void parseCamera(object parsedCamera, object scene) {
            var camera = new BABYLON.FreeCamera(parsedCamera.name, BABYLON.Vector3.FromArray(parsedCamera.position), scene);
            camera.id = parsedCamera.id;
            BABYLON.Tags.AddTagsTo(camera, parsedCamera.tags);
            if (parsedCamera.parentId) {
                camera._waitingParentId = parsedCamera.parentId;
            }
            if (parsedCamera.target) {
                camera.setTarget(BABYLON.Vector3.FromArray(parsedCamera.target));
            } else {
                camera.rotation = BABYLON.Vector3.FromArray(parsedCamera.rotation);
            }
            if (parsedCamera.lockedTargetId) {
                camera._waitingLockedTargetId = parsedCamera.lockedTargetId;
            }
            camera.fov = parsedCamera.fov;
            camera.minZ = parsedCamera.minZ;
            camera.maxZ = parsedCamera.maxZ;
            camera.speed = parsedCamera.speed;
            camera.inertia = parsedCamera.inertia;
            camera.checkCollisions = parsedCamera.checkCollisions;
            camera.applyGravity = parsedCamera.applyGravity;
            if (parsedCamera.ellipsoid) {
                camera.ellipsoid = BABYLON.Vector3.FromArray(parsedCamera.ellipsoid);
            }
            if (parsedCamera.animations) {
                for (var animationIndex = 0; animationIndex < parsedCamera.animations.Length; animationIndex++) {
                    var parsedAnimation = parsedCamera.animations[animationIndex];
                    camera.animations.push(parseAnimation(parsedAnimation));
                }
            }
            if (parsedCamera.autoAnimate) {
                scene.beginAnimation(camera, parsedCamera.autoAnimateFrom, parsedCamera.autoAnimateTo, parsedCamera.autoAnimateLoop, 1.0);
            }
            if (parsedCamera.layerMask && (!isNaN(parsedCamera.layerMask))) {
                camera.layerMask = Math.abs(parseInt(parsedCamera.layerMask));
            } else {
                camera.layerMask = 0xFFFFFFFF;
            }
            return camera;
        };
        void parseGeometry(object parsedGeometry, object scene) {
            var id = parsedGeometry.id;
            return scene.getGeometryByID(id);
        };
        void parseBox(object parsedBox, object scene) {
            if (parseGeometry(parsedBox, scene)) {
                return null;
            }
            var box = new BABYLON.Geometry.Primitives.Box(parsedBox.id, scene, parsedBox.size, parsedBox.canBeRegenerated, null);
            BABYLON.Tags.AddTagsTo(box, parsedBox.tags);
            scene.pushGeometry(box, true);
            return box;
        };
        void parseSphere(object parsedSphere, object scene) {
            if (parseGeometry(parsedSphere, scene)) {
                return null;
            }
            var sphere = new BABYLON.Geometry.Primitives.Sphere(parsedSphere.id, scene, parsedSphere.segments, parsedSphere.diameter, parsedSphere.canBeRegenerated, null);
            BABYLON.Tags.AddTagsTo(sphere, parsedSphere.tags);
            scene.pushGeometry(sphere, true);
            return sphere;
        };
        void parseCylinder(object parsedCylinder, object scene) {
            if (parseGeometry(parsedCylinder, scene)) {
                return null;
            }
            var cylinder = new BABYLON.Geometry.Primitives.Cylinder(parsedCylinder.id, scene, parsedCylinder.height, parsedCylinder.diameterTop, parsedCylinder.diameterBottom, parsedCylinder.tessellation, parsedCylinder.subdivisions, parsedCylinder.canBeRegenerated, null);
            BABYLON.Tags.AddTagsTo(cylinder, parsedCylinder.tags);
            scene.pushGeometry(cylinder, true);
            return cylinder;
        };
        void parseTorus(object parsedTorus, object scene) {
            if (parseGeometry(parsedTorus, scene)) {
                return null;
            }
            var torus = new BABYLON.Geometry.Primitives.Torus(parsedTorus.id, scene, parsedTorus.diameter, parsedTorus.thickness, parsedTorus.tessellation, parsedTorus.canBeRegenerated, null);
            BABYLON.Tags.AddTagsTo(torus, parsedTorus.tags);
            scene.pushGeometry(torus, true);
            return torus;
        };
        void parseGround(object parsedGround, object scene) {
            if (parseGeometry(parsedGround, scene)) {
                return null;
            }
            var ground = new BABYLON.Geometry.Primitives.Ground(parsedGround.id, scene, parsedGround.width, parsedGround.height, parsedGround.subdivisions, parsedGround.canBeRegenerated, null);
            BABYLON.Tags.AddTagsTo(ground, parsedGround.tags);
            scene.pushGeometry(ground, true);
            return ground;
        };
        void parsePlane(object parsedPlane, object scene) {
            if (parseGeometry(parsedPlane, scene)) {
                return null;
            }
            var plane = new BABYLON.Geometry.Primitives.Plane(parsedPlane.id, scene, parsedPlane.size, parsedPlane.canBeRegenerated, null);
            BABYLON.Tags.AddTagsTo(plane, parsedPlane.tags);
            scene.pushGeometry(plane, true);
            return plane;
        };
        void parseTorusKnot(object parsedTorusKnot, object scene) {
            if (parseGeometry(parsedTorusKnot, scene)) {
                return null;
            }
            var torusKnot = new BABYLON.Geometry.Primitives.TorusKnot(parsedTorusKnot.id, scene, parsedTorusKnot.radius, parsedTorusKnot.tube, parsedTorusKnot.radialSegments, parsedTorusKnot.tubularSegments, parsedTorusKnot.p, parsedTorusKnot.q, parsedTorusKnot.canBeRegenerated, null);
            BABYLON.Tags.AddTagsTo(torusKnot, parsedTorusKnot.tags);
            scene.pushGeometry(torusKnot, true);
            return torusKnot;
        };
        void parseVertexData(object parsedVertexData, object scene, object rootUrl) {
            if (parseGeometry(parsedVertexData, scene)) {
                return null;
            }
            var geometry = new BABYLON.Geometry(parsedVertexData.id, scene);
            BABYLON.Tags.AddTagsTo(geometry, parsedVertexData.tags);
            if (parsedVertexData.delayLoadingFile) {
                geometry.delayLoadState = BABYLON.Engine.DELAYLOADSTATE_NOTLOADED;
                geometry.delayLoadingFile = rootUrl + parsedVertexData.delayLoadingFile;
                geometry._boundingInfo = new BABYLON.BoundingInfo(BABYLON.Vector3.FromArray(parsedVertexData.boundingBoxMinimum), BABYLON.Vector3.FromArray(parsedVertexData.boundingBoxMaximum));
                geometry._delayInfo = new Array < object > ();
                if (parsedVertexData.hasUVs) {
                    geometry._delayInfo.push(BABYLON.VertexBuffer.UVKind);
                }
                if (parsedVertexData.hasUVs2) {
                    geometry._delayInfo.push(BABYLON.VertexBuffer.UV2Kind);
                }
                if (parsedVertexData.hasColors) {
                    geometry._delayInfo.push(BABYLON.VertexBuffer.ColorKind);
                }
                if (parsedVertexData.hasMatricesIndices) {
                    geometry._delayInfo.push(BABYLON.VertexBuffer.MatricesIndicesKind);
                }
                if (parsedVertexData.hasMatricesWeights) {
                    geometry._delayInfo.push(BABYLON.VertexBuffer.MatricesWeightsKind);
                }
                geometry._delayLoadingFunction = importVertexData;
            } else {
                importVertexData(parsedVertexData, geometry);
            }
            scene.pushGeometry(geometry, true);
            return geometry;
        };
        void parseMesh(object parsedMesh, object scene, object rootUrl) {
            var mesh = new BABYLON.Mesh(parsedMesh.name, scene);
            mesh.id = parsedMesh.id;
            BABYLON.Tags.AddTagsTo(mesh, parsedMesh.tags);
            mesh.position = BABYLON.Vector3.FromArray(parsedMesh.position);
            if (parsedMesh.rotationQuaternion) {
                mesh.rotationQuaternion = BABYLON.Quaternion.FromArray(parsedMesh.rotationQuaternion);
            } else
            if (parsedMesh.rotation) {
                mesh.rotation = BABYLON.Vector3.FromArray(parsedMesh.rotation);
            }
            mesh.scaling = BABYLON.Vector3.FromArray(parsedMesh.scaling);
            if (parsedMesh.localMatrix) {
                mesh.setPivotMatrix(BABYLON.Matrix.FromArray(parsedMesh.localMatrix));
            } else
            if (parsedMesh.pivotMatrix) {
                mesh.setPivotMatrix(BABYLON.Matrix.FromArray(parsedMesh.pivotMatrix));
            }
            mesh.setEnabled(parsedMesh.isEnabled);
            mesh.isVisible = parsedMesh.isVisible;
            mesh.infiniteDistance = parsedMesh.infiniteDistance;
            mesh.showBoundingBox = parsedMesh.showBoundingBox;
            mesh.showSubMeshesBoundingBox = parsedMesh.showSubMeshesBoundingBox;
            if (parsedMesh.pickable != null) {
                mesh.isPickable = parsedMesh.pickable;
            }
            mesh.receiveShadows = parsedMesh.receiveShadows;
            mesh.billboardMode = parsedMesh.billboardMode;
            if (parsedMesh.visibility != null) {
                mesh.visibility = parsedMesh.visibility;
            }
            mesh.checkCollisions = parsedMesh.checkCollisions;
            mesh._shouldGenerateFlatShading = parsedMesh.useFlatShading;
            if (parsedMesh.parentId) {
                mesh.parent = scene.getLastEntryByID(parsedMesh.parentId);
            }
            if (parsedMesh.delayLoadingFile) {
                mesh.delayLoadState = BABYLON.Engine.DELAYLOADSTATE_NOTLOADED;
                mesh.delayLoadingFile = rootUrl + parsedMesh.delayLoadingFile;
                mesh._boundingInfo = new BABYLON.BoundingInfo(BABYLON.Vector3.FromArray(parsedMesh.boundingBoxMinimum), BABYLON.Vector3.FromArray(parsedMesh.boundingBoxMaximum));
                mesh._delayInfo = new Array < object > ();
                if (parsedMesh.hasUVs) {
                    mesh._delayInfo.push(BABYLON.VertexBuffer.UVKind);
                }
                if (parsedMesh.hasUVs2) {
                    mesh._delayInfo.push(BABYLON.VertexBuffer.UV2Kind);
                }
                if (parsedMesh.hasColors) {
                    mesh._delayInfo.push(BABYLON.VertexBuffer.ColorKind);
                }
                if (parsedMesh.hasMatricesIndices) {
                    mesh._delayInfo.push(BABYLON.VertexBuffer.MatricesIndicesKind);
                }
                if (parsedMesh.hasMatricesWeights) {
                    mesh._delayInfo.push(BABYLON.VertexBuffer.MatricesWeightsKind);
                }
                mesh._delayLoadingFunction = importGeometry;
                if (BABYLON.SceneLoader.ForceFullSceneLoadingForIncremental) {
                    mesh._checkDelayState();
                }
            } else {
                importGeometry(parsedMesh, mesh);
            }
            if (parsedMesh.materialId) {
                mesh.setMaterialByID(parsedMesh.materialId);
            } else {
                mesh.material = null;
            }
            if (parsedMesh.skeletonId > -1) {
                mesh.skeleton = scene.getLastSkeletonByID(parsedMesh.skeletonId);
            }
            if (parsedMesh.physicsImpostor) {
                if (!scene.isPhysicsEnabled()) {
                    scene.enablePhysics();
                }
                mesh.setPhysicsState(new {});
            }
            if (parsedMesh.animations) {
                for (var animationIndex = 0; animationIndex < parsedMesh.animations.Length; animationIndex++) {
                    var parsedAnimation = parsedMesh.animations[animationIndex];
                    mesh.animations.push(parseAnimation(parsedAnimation));
                }
            }
            if (parsedMesh.autoAnimate) {
                scene.beginAnimation(mesh, parsedMesh.autoAnimateFrom, parsedMesh.autoAnimateTo, parsedMesh.autoAnimateLoop, 1.0);
            }
            if (parsedMesh.layerMask && (!isNaN(parsedMesh.layerMask))) {
                mesh.layerMask = Math.abs(parseInt(parsedMesh.layerMask));
            } else {
                mesh.layerMask = 0xFFFFFFFF;
            }
            if (parsedMesh.instances) {
                for (var index = 0; index < parsedMesh.instances.Length; index++) {
                    var parsedInstance = parsedMesh.instances[index];
                    var instance = mesh.createInstance(parsedInstance.name);
                    BABYLON.Tags.AddTagsTo(instance, parsedInstance.tags);
                    instance.position = BABYLON.Vector3.FromArray(parsedInstance.position);
                    if (parsedInstance.rotationQuaternion) {
                        instance.rotationQuaternion = BABYLON.Quaternion.FromArray(parsedInstance.rotationQuaternion);
                    } else
                    if (parsedInstance.rotation) {
                        instance.rotation = BABYLON.Vector3.FromArray(parsedInstance.rotation);
                    }
                    instance.scaling = BABYLON.Vector3.FromArray(parsedInstance.scaling);
                    instance.checkCollisions = mesh.checkCollisions;
                    if (parsedMesh.animations) {
                        for (animationIndex = 0; animationIndex < parsedMesh.animations.Length; animationIndex++) {
                            parsedAnimation = parsedMesh.animations[animationIndex];
                            instance.animations.push(parseAnimation(parsedAnimation));
                        }
                    }
                }
            }
            return mesh;
        };
        void isDescendantOf(object mesh, object names, object hierarchyIds) {
            names = ((names is Array)) ? names : new Array < object > (names);
            foreach(var i in names) {
                if (mesh.name == names[i]) {
                    hierarchyIds.push(mesh.id);
                    return true;
                }
            }
            if (mesh.parentId && hierarchyIds.indexOf(mesh.parentId) != -1) {
                hierarchyIds.push(mesh.id);
                return true;
            }
            return false;
        };
        void importVertexData(object parsedVertexData, object geometry) {
            var vertexData = new BABYLON.VertexData();
            var positions = parsedVertexData.positions;
            if (positions) {
                vertexData.set(positions, BABYLON.VertexBuffer.PositionKind);
            }
            var normals = parsedVertexData.normals;
            if (normals) {
                vertexData.set(normals, BABYLON.VertexBuffer.NormalKind);
            }
            var uvs = parsedVertexData.uvs;
            if (uvs) {
                vertexData.set(uvs, BABYLON.VertexBuffer.UVKind);
            }
            var uv2s = parsedVertexData.uv2s;
            if (uv2s) {
                vertexData.set(uv2s, BABYLON.VertexBuffer.UV2Kind);
            }
            var colors = parsedVertexData.colors;
            if (colors) {
                vertexData.set(colors, BABYLON.VertexBuffer.ColorKind);
            }
            var matricesIndices = parsedVertexData.matricesIndices;
            if (matricesIndices) {
                vertexData.set(matricesIndices, BABYLON.VertexBuffer.MatricesIndicesKind);
            }
            var matricesWeights = parsedVertexData.matricesWeights;
            if (matricesWeights) {
                vertexData.set(matricesWeights, BABYLON.VertexBuffer.MatricesWeightsKind);
            }
            var indices = parsedVertexData.indices;
            if (indices) {
                vertexData.indices = indices;
            }
            geometry.setAllVerticesData(vertexData, parsedVertexData.updatable);
        };
        void importGeometry(object parsedGeometry, object mesh) {
            var scene = mesh.getScene();
            var geometryId = parsedGeometry.geometryId;
            if (geometryId) {
                var geometry = scene.getGeometryByID(geometryId);
                if (geometry) {
                    geometry.applyToMesh(mesh);
                }
            } else
            if (parsedGeometry.positions && parsedGeometry.normals && parsedGeometry.indices) {
                mesh.setVerticesData(BABYLON.VertexBuffer.PositionKind, parsedGeometry.positions, false);
                mesh.setVerticesData(BABYLON.VertexBuffer.NormalKind, parsedGeometry.normals, false);
                if (parsedGeometry.uvs) {
                    mesh.setVerticesData(BABYLON.VertexBuffer.UVKind, parsedGeometry.uvs, false);
                }
                if (parsedGeometry.uvs2) {
                    mesh.setVerticesData(BABYLON.VertexBuffer.UV2Kind, parsedGeometry.uvs2, false);
                }
                if (parsedGeometry.colors) {
                    mesh.setVerticesData(BABYLON.VertexBuffer.ColorKind, parsedGeometry.colors, false);
                }
                if (parsedGeometry.matricesIndices) {
                    if (!parsedGeometry.matricesIndices._isExpanded) {
                        var floatIndices = new Array < object > ();
                        for (var i = 0; i < parsedGeometry.matricesIndices.Length; i++) {
                            var matricesIndex = parsedGeometry.matricesIndices[i];
                            floatIndices.push(matricesIndex & 0x000000FF);
                            floatIndices.push((matricesIndex & 0x0000FF00) << 8);
                            floatIndices.push((matricesIndex & 0x00FF0000) << 16);
                            floatIndices.push(matricesIndex << 24);
                        }
                        mesh.setVerticesData(BABYLON.VertexBuffer.MatricesIndicesKind, floatIndices, false);
                    } else {
                        parsedGeometry.matricesIndices._isExpanded = null;
                        mesh.setVerticesData(BABYLON.VertexBuffer.MatricesIndicesKind, parsedGeometry.matricesIndices, false);
                    }
                }
                if (parsedGeometry.matricesWeights) {
                    mesh.setVerticesData(BABYLON.VertexBuffer.MatricesWeightsKind, parsedGeometry.matricesWeights, false);
                }
                mesh.setIndices(parsedGeometry.indices);
            }
            if (parsedGeometry.subMeshes) {
                mesh.subMeshes = new Array < object > ();
                for (var subIndex = 0; subIndex < parsedGeometry.subMeshes.Length; subIndex++) {
                    var parsedSubMesh = parsedGeometry.subMeshes[subIndex];
                    var subMesh = new BABYLON.SubMesh(parsedSubMesh.materialIndex, parsedSubMesh.verticesStart, parsedSubMesh.verticesCount, parsedSubMesh.indexStart, parsedSubMesh.indexCount, mesh);
                }
            }
            if (mesh._shouldGenerateFlatShading) {
                mesh.convertToFlatShadedMesh();
                mesh._shouldGenerateFlatShading = null;
            }
            mesh.computeWorldMatrix(true);
            if (scene._selectionOctree) {
                scene._selectionOctree.addMesh(mesh);
            }
        };
        BABYLON.SceneLoader.RegisterPlugin(new {});
        public virtual bool isReady() {
            return this._isReady;
        }
        public virtual WebGLProgram getProgram() {
            return this._program;
        }
        public virtual Array < string > getAttributesNames() {
            return this._attributesNames;
        }
        public virtual Array < VertexBufferKind > getAttributes() {
            return this._attributes;
        }
        public virtual int getAttributeLocation(double index) {
            return this._attributes[index];
        }
        public virtual double getAttributeLocationByName(string name) {
            var index = this._attributesNames.indexOf(name);
            return this._attributes[index];
        }
        public virtual double getAttributesCount() {
            return this._attributes.Length;
        }
        public virtual double getUniformIndex(string uniformName) {
            return this._uniformsNames.indexOf(uniformName);
        }
        public virtual WebGLUniformLocation getUniform(string uniformName) {
            return this._uniforms[this._uniformsNames.indexOf(uniformName)];
        }
        public virtual Array < string > getSamplers() {
            return this._samplers;
        }
        public virtual string getCompilationError() {
            return this._compilationError;
        }
        public virtual void _loadVertexShader(object vertex, System.Action < object > callback) {
            if (vertex is HTMLElement) {
                var vertexCode = BABYLON.Tools.GetDOMTextContent(vertex);
                callback(vertexCode);
                return;
            }
            if (BABYLON.Effect.ShadersStore[vertex + "VertexShader"]) {
                callback(BABYLON.Effect.ShadersStore[vertex + "VertexShader"]);
                return;
            }
            var vertexShaderUrl;
            if (vertex[0] == ".") {
                vertexShaderUrl = vertex;
            } else {
                vertexShaderUrl = BABYLON.Engine.ShadersRepository + vertex;
            }
            BABYLON.Tools.LoadFile(vertexShaderUrl + ".vertex.fx", callback);
        }
        public virtual void _loadFragmentShader(object fragment, System.Action < object > callback) {
            if (fragment is HTMLElement) {
                var fragmentCode = BABYLON.Tools.GetDOMTextContent(fragment);
                callback(fragmentCode);
                return;
            }
            if (BABYLON.Effect.ShadersStore[fragment + "PixelShader"]) {
                callback(BABYLON.Effect.ShadersStore[fragment + "PixelShader"]);
                return;
            }
            var fragmentShaderUrl;
            if (fragment[0] == ".") {
                fragmentShaderUrl = fragment;
            } else {
                fragmentShaderUrl = BABYLON.Engine.ShadersRepository + fragment;
            }
            BABYLON.Tools.LoadFile(fragmentShaderUrl + ".fragment.fx", callback);
        }
        public virtual void _prepareEffect(string vertexSourceCode, string fragmentSourceCode, Array < string > attributesNames, string defines, Array < string > optionalDefines = null, bool useFallback = false) {
            try {
                var engine = this._engine;
                this._program = engine.createShaderProgram(vertexSourceCode, fragmentSourceCode, defines);
                this._uniforms = engine.getUniforms(this._program, this._uniformsNames);
                this._attributes = engine.getAttributes(this._program, attributesNames);
                for (var index = 0; index < this._samplers.Length; index++) {
                    var sampler = this.getUniform(this._samplers[index]);
                    if (sampler == null) {
                        this._samplers.splice(index, 1);
                        index--;
                    }
                }
                engine.bindSamplers(this);
                this._isReady = true;
                if (this.onCompiled) {
                    this.onCompiled(this);
                }
            } catch (Exception e) {
                if (!useFallback && optionalDefines) {
                    for (index = 0; index < optionalDefines.Length; index++) {
                        defines = defines.replace(optionalDefines[index], "");
                    }
                    this._prepareEffect(vertexSourceCode, fragmentSourceCode, attributesNames, defines, optionalDefines, true);
                } else {
                    Tools.Error("Unable to compile effect: " + this.name);
                    Tools.Error("Defines: " + defines);
                    Tools.Error("Optional defines: " + optionalDefines);
                    Tools.Error("Error: " + e.message);
                    this._compilationError = e.message;
                    if (this.onError) {
                        this.onError(this, this._compilationError);
                    }
                }
            }
        }
        public virtual void _bindTexture(string channel, WebGLTexture texture) {
            this._engine._bindTexture(this._samplers.indexOf(channel), texture);
        }
        public virtual void setTexture(string channel, BaseTexture texture) {
            this._engine.setTexture(this._samplers.indexOf(channel), texture);
        }
        public virtual void setTextureFromPostProcess(string channel, PostProcess postProcess) {
            this._engine.setTextureFromPostProcess(this._samplers.indexOf(channel), postProcess);
        }
        public virtual void _cacheFloat2(string uniformName, double x, double y) {
            if (!this._valueCache[uniformName]) {
                this._valueCache[uniformName] = new Array < object > (x, y);
                return;
            }
            this._valueCache[uniformName][0] = x;
            this._valueCache[uniformName][1] = y;
        }
        public virtual void _cacheFloat3(string uniformName, double x, double y, double z) {
            if (!this._valueCache[uniformName]) {
                this._valueCache[uniformName] = new Array < object > (x, y, z);
                return;
            }
            this._valueCache[uniformName][0] = x;
            this._valueCache[uniformName][1] = y;
            this._valueCache[uniformName][2] = z;
        }
        public virtual void _cacheFloat4(string uniformName, double x, double y, double z, double w) {
            if (!this._valueCache[uniformName]) {
                this._valueCache[uniformName] = new Array < object > (x, y, z, w);
                return;
            }
            this._valueCache[uniformName][0] = x;
            this._valueCache[uniformName][1] = y;
            this._valueCache[uniformName][2] = z;
            this._valueCache[uniformName][3] = w;
        }
        public virtual Effect setArray(string uniformName, Array < double > array) {
            this._engine.setArray(this.getUniform(uniformName), array);
            return this;
        }
        public virtual Effect setMatrices(string uniformName, Float32Array matrices) {
            this._engine.setMatrices(this.getUniform(uniformName), matrices);
            return this;
        }
        public virtual Effect setMatrix(string uniformName, Matrix matrix) {
            this._engine.setMatrix(this.getUniform(uniformName), matrix);
            return this;
        }
        public virtual Effect setFloat(string uniformName, double value) {
            if (this._valueCache[uniformName] && this._valueCache[uniformName] == value)
                return this;
            this._valueCache[uniformName] = value;
            this._engine.setFloat(this.getUniform(uniformName), value);
            return this;
        }
        public virtual Effect setBool(string uniformName, bool _bool) {
            if (this._valueCache[uniformName] && this._valueCache[uniformName] == _bool)
                return this;
            this._valueCache[uniformName] = _bool;
            this._engine.setBool(this.getUniform(uniformName), (_bool) ? 1 : 0);
            return this;
        }
        public virtual Effect setVector2(string uniformName, Vector2 vector2) {
            if (this._valueCache[uniformName] && this._valueCache[uniformName][0] == vector2.x && this._valueCache[uniformName][1] == vector2.y)
                return this;
            this._cacheFloat2(uniformName, vector2.x, vector2.y);
            this._engine.setFloat2(this.getUniform(uniformName), vector2.x, vector2.y);
            return this;
        }
        public virtual Effect setFloat2(string uniformName, double x, double y) {
            if (this._valueCache[uniformName] && this._valueCache[uniformName][0] == x && this._valueCache[uniformName][1] == y)
                return this;
            this._cacheFloat2(uniformName, x, y);
            this._engine.setFloat2(this.getUniform(uniformName), x, y);
            return this;
        }
        public virtual Effect setVector3(string uniformName, Vector3 vector3) {
            if (this._valueCache[uniformName] && this._valueCache[uniformName][0] == vector3.x && this._valueCache[uniformName][1] == vector3.y && this._valueCache[uniformName][2] == vector3.z)
                return this;
            this._cacheFloat3(uniformName, vector3.x, vector3.y, vector3.z);
            this._engine.setFloat3(this.getUniform(uniformName), vector3.x, vector3.y, vector3.z);
            return this;
        }
        public virtual Effect setFloat3(string uniformName, double x, double y, double z) {
            if (this._valueCache[uniformName] && this._valueCache[uniformName][0] == x && this._valueCache[uniformName][1] == y && this._valueCache[uniformName][2] == z)
                return this;
            this._cacheFloat3(uniformName, x, y, z);
            this._engine.setFloat3(this.getUniform(uniformName), x, y, z);
            return this;
        }
        public virtual Effect setFloat4(string uniformName, double x, double y, double z, double w) {
            if (this._valueCache[uniformName] && this._valueCache[uniformName][0] == x && this._valueCache[uniformName][1] == y && this._valueCache[uniformName][2] == z && this._valueCache[uniformName][3] == w)
                return this;
            this._cacheFloat4(uniformName, x, y, z, w);
            this._engine.setFloat4(this.getUniform(uniformName), x, y, z, w);
            return this;
        }
        public virtual Effect setColor3(string uniformName, Color3 color3) {
            if (this._valueCache[uniformName] && this._valueCache[uniformName][0] == color3.r && this._valueCache[uniformName][1] == color3.g && this._valueCache[uniformName][2] == color3.b)
                return this;
            this._cacheFloat3(uniformName, color3.r, color3.g, color3.b);
            this._engine.setColor3(this.getUniform(uniformName), color3);
            return this;
        }
        public virtual Effect setColor4(string uniformName, Color3 color3, double alpha) {
            if (this._valueCache[uniformName] && this._valueCache[uniformName][0] == color3.r && this._valueCache[uniformName][1] == color3.g && this._valueCache[uniformName][2] == color3.b && this._valueCache[uniformName][3] == alpha)
                return this;
            this._cacheFloat4(uniformName, color3.r, color3.g, color3.b, alpha);
            this._engine.setColor4(this.getUniform(uniformName), color3, alpha);
            return this;
        }
        public static dynamic ShadersStore = new {};
    }
}