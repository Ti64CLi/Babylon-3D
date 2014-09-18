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
    /*
    //BABYLON.SceneLoader.RegisterPlugin(new {});

    CubeTexture loadCubeTexture(object rootUrl, object parsedTexture, Scene scene)
    {
        var texture = new BABYLON.CubeTexture(rootUrl + parsedTexture.name, scene);
        texture.name = parsedTexture.name;
        texture.hasAlpha = parsedTexture.hasAlpha;
        texture.level = parsedTexture.level;
        texture.coordinatesMode = parsedTexture.coordinatesMode;
        return texture;
    }
    Texture loadTexture(object rootUrl, object parsedTexture, Scene scene)
    {
        if (!parsedTexture.name && !parsedTexture.isRenderTarget)
        {
            return null;
        }
        if (parsedTexture.isCube)
        {
            return loadCubeTexture(rootUrl, parsedTexture, scene);
        }
        Texture texture;
        if (parsedTexture.mirrorPlane)
        {
            texture = new BABYLON.MirrorTexture(parsedTexture.name, parsedTexture.renderTargetSize, scene);
            texture._waitingRenderList = parsedTexture.renderList;
            texture.mirrorPlane = BABYLON.Plane.FromArray(parsedTexture.mirrorPlane);
        }
        else
            if (parsedTexture.isRenderTarget)
            {
                texture = new BABYLON.RenderTargetTexture(parsedTexture.name, parsedTexture.renderTargetSize, scene);
                texture._waitingRenderList = parsedTexture.renderList;
            }
            else
            {
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
        if (parsedTexture.animations)
        {
            for (var animationIndex = 0; animationIndex < parsedTexture.animations.Length; animationIndex++)
            {
                var parsedAnimation = parsedTexture.animations[animationIndex];
                texture.animations.Add(parseAnimation(parsedAnimation));
            }
        }
        return texture;
    }
    Skeleton parseSkeleton(object parsedSkeleton, Scene scene)
    {
        var skeleton = new BABYLON.Skeleton(parsedSkeleton.name, parsedSkeleton.id, scene);
        for (var index = 0; index < parsedSkeleton.bones.Length; index++)
        {
            var parsedBone = parsedSkeleton.bones[index];
            var parentBone = null;
            if (parsedBone.parentBoneIndex > -1)
            {
                parentBone = skeleton.bones[parsedBone.parentBoneIndex];
            }
            var bone = new BABYLON.Bone(parsedBone.name, skeleton, parentBone, BABYLON.Matrix.FromArray(parsedBone.matrix));
            if (parsedBone.animation)
            {
                bone.animations.Add(parseAnimation(parsedBone.animation));
            }
        }
        return skeleton;
    }
    Material parseMaterial(object parsedMaterial, Scene scene, object rootUrl)
    {
        Material material;
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
        if (parsedMaterial.diffuseTexture)
        {
            material.diffuseTexture = loadTexture(rootUrl, parsedMaterial.diffuseTexture, scene);
        }
        if (parsedMaterial.ambientTexture)
        {
            material.ambientTexture = loadTexture(rootUrl, parsedMaterial.ambientTexture, scene);
        }
        if (parsedMaterial.opacityTexture)
        {
            material.opacityTexture = loadTexture(rootUrl, parsedMaterial.opacityTexture, scene);
        }
        if (parsedMaterial.reflectionTexture)
        {
            material.reflectionTexture = loadTexture(rootUrl, parsedMaterial.reflectionTexture, scene);
        }
        if (parsedMaterial.emissiveTexture)
        {
            material.emissiveTexture = loadTexture(rootUrl, parsedMaterial.emissiveTexture, scene);
        }
        if (parsedMaterial.specularTexture)
        {
            material.specularTexture = loadTexture(rootUrl, parsedMaterial.specularTexture, scene);
        }
        if (parsedMaterial.bumpTexture)
        {
            material.bumpTexture = loadTexture(rootUrl, parsedMaterial.bumpTexture, scene);
        }
        return material;
    }
    Material parseMaterialById(object id, object parsedData, Scene scene, object rootUrl)
    {
        for (var index = 0; index < parsedData.materials.Length; index++)
        {
            var parsedMaterial = parsedData.materials[index];
            if (parsedMaterial.id == id)
            {
                return parseMaterial(parsedMaterial, scene, rootUrl);
            }
        }
        return null;
    }
    MultiMaterial parseMultiMaterial(object parsedMultiMaterial, Scene scene)
    {
        var multiMaterial = new BABYLON.MultiMaterial(parsedMultiMaterial.name, scene);
        multiMaterial.id = parsedMultiMaterial.id;
        BABYLON.Tags.AddTagsTo(multiMaterial, parsedMultiMaterial.tags);
        for (var matIndex = 0; matIndex < parsedMultiMaterial.materials.Length; matIndex++)
        {
            var subMatId = parsedMultiMaterial.materials[matIndex];
            if (subMatId)
            {
                multiMaterial.subMaterials.Add(scene.getMaterialByID(subMatId));
            }
            else
            {
                multiMaterial.subMaterials.Add(null);
            }
        }
        return multiMaterial;
    }
    LensFlareSystem parseLensFlareSystem(object parsedLensFlareSystem, Scene scene, object rootUrl)
    {
        var emitter = scene.getLastEntryByID(parsedLensFlareSystem.emitterId);
        var lensFlareSystem = new BABYLON.LensFlareSystem("lensFlareSystem#" + parsedLensFlareSystem.emitterId, emitter, scene);
        lensFlareSystem.borderLimit = parsedLensFlareSystem.borderLimit;
        for (var index = 0; index < parsedLensFlareSystem.flares.Length; index++)
        {
            var parsedFlare = parsedLensFlareSystem.flares[index];
            var flare = new BABYLON.LensFlare(parsedFlare.size, parsedFlare.position, BABYLON.Color3.FromArray(parsedFlare.color), rootUrl + parsedFlare.textureName, lensFlareSystem);
        }
        return lensFlareSystem;
    }
    ParticleSystem parseParticleSystem(object parsedParticleSystem, Scene scene, object rootUrl)
    {
        var emitter = scene.getLastMeshByID(parsedParticleSystem.emitterId);
        var particleSystem = new BABYLON.ParticleSystem("particles#" + emitter.name, parsedParticleSystem.capacity, scene);
        if (parsedParticleSystem.textureName)
        {
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
    }
    ShadowGenerator parseShadowGenerator(object parsedShadowGenerator, Scene scene)
    {
        var light = scene.getLightByID(parsedShadowGenerator.lightId);
        var shadowGenerator = new BABYLON.ShadowGenerator(parsedShadowGenerator.mapSize, light);
        for (var meshIndex = 0; meshIndex < parsedShadowGenerator.renderList.Length; meshIndex++)
        {
            var mesh = scene.getMeshByID(parsedShadowGenerator.renderList[meshIndex]);
            shadowGenerator.getShadowMap().renderList.Add(mesh);
        }
        if (parsedShadowGenerator.usePoissonSampling)
        {
            shadowGenerator.usePoissonSampling = true;
        }
        else
        {
            shadowGenerator.useVarianceShadowMap = parsedShadowGenerator.useVarianceShadowMap;
        }
        return shadowGenerator;
    }
    Animation parseAnimation(Animation parsedAnimation)
    {
        var animation = new BABYLON.Animation(parsedAnimation.name, parsedAnimation.property, parsedAnimation.framePerSecond, parsedAnimation.dataType, parsedAnimation.loopBehavior);
        var dataType = parsedAnimation.dataType;
        var keys = new Array<object>();
        for (var index = 0; index < parsedAnimation.keys.Length; index++)
        {
            var key = parsedAnimation.keys[index];
            int data;
            switch (dataType)
            {
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
            keys.Add(new { });
        }
        animation.setKeys(keys);
        return animation;
    }
    Light parseLight(object parsedLight, Scene scene)
    {
        Light light;
        switch (parsedLight.type)
        {
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
        if (parsedLight.intensity != null)
        {
            light.intensity = parsedLight.intensity;
        }
        if (parsedLight.range)
        {
            light.range = parsedLight.range;
        }
        light.diffuse = BABYLON.Color3.FromArray(parsedLight.diffuse);
        light.specular = BABYLON.Color3.FromArray(parsedLight.specular);
        if (parsedLight.excludedMeshesIds)
        {
            light._excludedMeshesIds = parsedLight.excludedMeshesIds;
        }
        if (parsedLight.animations)
        {
            for (var animationIndex = 0; animationIndex < parsedLight.animations.Length; animationIndex++)
            {
                var parsedAnimation = parsedLight.animations[animationIndex];
                light.animations.Add(parseAnimation(parsedAnimation));
            }
        }
        if (parsedLight.autoAnimate)
        {
            scene.beginAnimation(light, parsedLight.autoAnimateFrom, parsedLight.autoAnimateTo, parsedLight.autoAnimateLoop, 1.0);
        }
    }
    Camera parseCamera(object parsedCamera, Scene scene)
    {
        var camera = new BABYLON.FreeCamera(parsedCamera.name, BABYLON.Vector3.FromArray(parsedCamera.position), scene);
        camera.id = parsedCamera.id;
        BABYLON.Tags.AddTagsTo(camera, parsedCamera.tags);
        if (parsedCamera.parentId)
        {
            camera._waitingParentId = parsedCamera.parentId;
        }
        if (parsedCamera.target)
        {
            camera.setTarget(BABYLON.Vector3.FromArray(parsedCamera.target));
        }
        else
        {
            camera.rotation = BABYLON.Vector3.FromArray(parsedCamera.rotation);
        }
        if (parsedCamera.lockedTargetId)
        {
            camera._waitingLockedTargetId = parsedCamera.lockedTargetId;
        }
        camera.fov = parsedCamera.fov;
        camera.minZ = parsedCamera.minZ;
        camera.maxZ = parsedCamera.maxZ;
        camera.speed = parsedCamera.speed;
        camera.inertia = parsedCamera.inertia;
        camera.checkCollisions = parsedCamera.checkCollisions;
        camera.applyGravity = parsedCamera.applyGravity;
        if (parsedCamera.ellipsoid)
        {
            camera.ellipsoid = BABYLON.Vector3.FromArray(parsedCamera.ellipsoid);
        }
        if (parsedCamera.animations)
        {
            for (var animationIndex = 0; animationIndex < parsedCamera.animations.Length; animationIndex++)
            {
                var parsedAnimation = parsedCamera.animations[animationIndex];
                camera.animations.Add(parseAnimation(parsedAnimation));
            }
        }
        if (parsedCamera.autoAnimate)
        {
            scene.beginAnimation(camera, parsedCamera.autoAnimateFrom, parsedCamera.autoAnimateTo, parsedCamera.autoAnimateLoop, 1.0);
        }
        if (parsedCamera.layerMask && (!isNaN(parsedCamera.layerMask)))
        {
            camera.layerMask = Math.Abs(parseInt(parsedCamera.layerMask));
        }
        else
        {
            camera.layerMask = 0xFFFFFFFF;
        }
        return camera;
    }
    Geometry parseGeometry(object parsedGeometry, Scene scene)
    {
        var id = parsedGeometry.id;
        return scene.getGeometryByID(id);
    }
    Geometry.Primitives.Box parseBox(object parsedBox, Scene scene)
    {
        if (parseGeometry(parsedBox, scene))
        {
            return null;
        }
        var box = new BABYLON.Geometry.Primitives.Box(parsedBox.id, scene, parsedBox.size, parsedBox.canBeRegenerated, null);
        BABYLON.Tags.AddTagsTo(box, parsedBox.tags);
        scene.pushGeometry(box, true);
        return box;
    }
    BABYLON.Geometry.Primitives.Sphere parseSphere(object parsedSphere, Scene scene)
    {
        if (parseGeometry(parsedSphere, scene))
        {
            return null;
        }
        var sphere = new BABYLON.Geometry.Primitives.Sphere(parsedSphere.id, scene, parsedSphere.segments, parsedSphere.diameter, parsedSphere.canBeRegenerated, null);
        BABYLON.Tags.AddTagsTo(sphere, parsedSphere.tags);
        scene.pushGeometry(sphere, true);
        return sphere;
    }
    BABYLON.Geometry.Primitives.Cylinder parseCylinder(object parsedCylinder, Scene scene)
    {
        if (parseGeometry(parsedCylinder, scene))
        {
            return null;
        }
        var cylinder = new BABYLON.Geometry.Primitives.Cylinder(parsedCylinder.id, scene, parsedCylinder.height, parsedCylinder.diameterTop, parsedCylinder.diameterBottom, parsedCylinder.tessellation, parsedCylinder.subdivisions, parsedCylinder.canBeRegenerated, null);
        BABYLON.Tags.AddTagsTo(cylinder, parsedCylinder.tags);
        scene.pushGeometry(cylinder, true);
        return cylinder;
    }
    BABYLON.Geometry.Primitives.Torus parseTorus(object parsedTorus, Scene scene)
    {
        if (parseGeometry(parsedTorus, scene))
        {
            return null;
        }
        var torus = new BABYLON.Geometry.Primitives.Torus(parsedTorus.id, scene, parsedTorus.diameter, parsedTorus.thickness, parsedTorus.tessellation, parsedTorus.canBeRegenerated, null);
        BABYLON.Tags.AddTagsTo(torus, parsedTorus.tags);
        scene.pushGeometry(torus, true);
        return torus;
    }
    BABYLON.Geometry.Primitives.Ground parseGround(object parsedGround, Scene scene)
    {
        if (parseGeometry(parsedGround, scene))
        {
            return null;
        }
        var ground = new BABYLON.Geometry.Primitives.Ground(parsedGround.id, scene, parsedGround.width, parsedGround.height, parsedGround.subdivisions, parsedGround.canBeRegenerated, null);
        BABYLON.Tags.AddTagsTo(ground, parsedGround.tags);
        scene.pushGeometry(ground, true);
        return ground;
    }
    BABYLON.Geometry.Primitives.Plane parsePlane(object parsedPlane, Scene scene)
    {
        if (parseGeometry(parsedPlane, scene))
        {
            return null;
        }
        var plane = new BABYLON.Geometry.Primitives.Plane(parsedPlane.id, scene, parsedPlane.size, parsedPlane.canBeRegenerated, null);
        BABYLON.Tags.AddTagsTo(plane, parsedPlane.tags);
        scene.pushGeometry(plane, true);
        return plane;
    }
    BABYLON.Geometry.Primitives.TorusKnot parseTorusKnot(object parsedTorusKnot, Scene scene)
    {
        if (parseGeometry(parsedTorusKnot, scene))
        {
            return null;
        }
        var torusKnot = new BABYLON.Geometry.Primitives.TorusKnot(parsedTorusKnot.id, scene, parsedTorusKnot.radius, parsedTorusKnot.tube, parsedTorusKnot.radialSegments, parsedTorusKnot.tubularSegments, parsedTorusKnot.p, parsedTorusKnot.q, parsedTorusKnot.canBeRegenerated, null);
        BABYLON.Tags.AddTagsTo(torusKnot, parsedTorusKnot.tags);
        scene.pushGeometry(torusKnot, true);
        return torusKnot;
    }
    Geometry parseVertexData(object parsedVertexData, Scene scene, object rootUrl)
    {
        if (parseGeometry(parsedVertexData, scene))
        {
            return null;
        }
        var geometry = new BABYLON.Geometry(parsedVertexData.id, scene);
        BABYLON.Tags.AddTagsTo(geometry, parsedVertexData.tags);
        if (parsedVertexData.delayLoadingFile)
        {
            geometry.delayLoadState = BABYLON.Engine.DELAYLOADSTATE_NOTLOADED;
            geometry.delayLoadingFile = rootUrl + parsedVertexData.delayLoadingFile;
            geometry._boundingInfo = new BABYLON.BoundingInfo(BABYLON.Vector3.FromArray(parsedVertexData.boundingBoxMinimum), BABYLON.Vector3.FromArray(parsedVertexData.boundingBoxMaximum));
            geometry._delayInfo = new Array<object>();
            if (parsedVertexData.hasUVs)
            {
                geometry._delayInfo.Add(BABYLON.VertexBufferKind.UVKind);
            }
            if (parsedVertexData.hasUVs2)
            {
                geometry._delayInfo.Add(BABYLON.VertexBufferKind.UV2Kind);
            }
            if (parsedVertexData.hasColors)
            {
                geometry._delayInfo.Add(BABYLON.VertexBufferKind.ColorKind);
            }
            if (parsedVertexData.hasMatricesIndices)
            {
                geometry._delayInfo.Add(BABYLON.VertexBufferKind.MatricesIndicesKind);
            }
            if (parsedVertexData.hasMatricesWeights)
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
    Mesh parseMesh(object parsedMesh, Scene scene, object rootUrl)
    {
        var mesh = new BABYLON.Mesh(parsedMesh.name, scene);
        mesh.id = parsedMesh.id;
        BABYLON.Tags.AddTagsTo(mesh, parsedMesh.tags);
        mesh.position = BABYLON.Vector3.FromArray(parsedMesh.position);
        if (parsedMesh.rotationQuaternion)
        {
            mesh.rotationQuaternion = BABYLON.Quaternion.FromArray(parsedMesh.rotationQuaternion);
        }
        else
            if (parsedMesh.rotation)
            {
                mesh.rotation = BABYLON.Vector3.FromArray(parsedMesh.rotation);
            }
        mesh.scaling = BABYLON.Vector3.FromArray(parsedMesh.scaling);
        if (parsedMesh.localMatrix)
        {
            mesh.setPivotMatrix(BABYLON.Matrix.FromArray(parsedMesh.localMatrix));
        }
        else
            if (parsedMesh.pivotMatrix)
            {
                mesh.setPivotMatrix(BABYLON.Matrix.FromArray(parsedMesh.pivotMatrix));
            }
        mesh.setEnabled(parsedMesh.isEnabled);
        mesh.isVisible = parsedMesh.isVisible;
        mesh.infiniteDistance = parsedMesh.infiniteDistance;
        mesh.showBoundingBox = parsedMesh.showBoundingBox;
        mesh.showSubMeshesBoundingBox = parsedMesh.showSubMeshesBoundingBox;
        if (parsedMesh.pickable != null)
        {
            mesh.isPickable = parsedMesh.pickable;
        }
        mesh.receiveShadows = parsedMesh.receiveShadows;
        mesh.billboardMode = parsedMesh.billboardMode;
        if (parsedMesh.visibility != null)
        {
            mesh.visibility = parsedMesh.visibility;
        }
        mesh.checkCollisions = parsedMesh.checkCollisions;
        mesh._shouldGenerateFlatShading = parsedMesh.useFlatShading;
        if (parsedMesh.parentId)
        {
            mesh.parent = scene.getLastEntryByID(parsedMesh.parentId);
        }
        if (parsedMesh.delayLoadingFile)
        {
            mesh.delayLoadState = BABYLON.Engine.DELAYLOADSTATE_NOTLOADED;
            mesh.delayLoadingFile = rootUrl + parsedMesh.delayLoadingFile;
            mesh._boundingInfo = new BABYLON.BoundingInfo(BABYLON.Vector3.FromArray(parsedMesh.boundingBoxMinimum), BABYLON.Vector3.FromArray(parsedMesh.boundingBoxMaximum));
            mesh._delayInfo = new Array<object>();
            if (parsedMesh.hasUVs)
            {
                mesh._delayInfo.Add(BABYLON.VertexBufferKind.UVKind);
            }
            if (parsedMesh.hasUVs2)
            {
                mesh._delayInfo.Add(BABYLON.VertexBufferKind.UV2Kind);
            }
            if (parsedMesh.hasColors)
            {
                mesh._delayInfo.Add(BABYLON.VertexBufferKind.ColorKind);
            }
            if (parsedMesh.hasMatricesIndices)
            {
                mesh._delayInfo.Add(BABYLON.VertexBufferKind.MatricesIndicesKind);
            }
            if (parsedMesh.hasMatricesWeights)
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
        if (parsedMesh.materialId)
        {
            mesh.setMaterialByID(parsedMesh.materialId);
        }
        else
        {
            mesh.material = null;
        }
        if (parsedMesh.skeletonId > -1)
        {
            mesh.skeleton = scene.getLastSkeletonByID(parsedMesh.skeletonId);
        }
        if (parsedMesh.physicsImpostor)
        {
            if (!scene.isPhysicsEnabled())
            {
                scene.enablePhysics();
            }
            mesh.setPhysicsState(new { });
        }
        if (parsedMesh.animations)
        {
            for (var animationIndex = 0; animationIndex < parsedMesh.animations.Length; animationIndex++)
            {
                var parsedAnimation = parsedMesh.animations[animationIndex];
                mesh.animations.Add(parseAnimation(parsedAnimation));
            }
        }
        if (parsedMesh.autoAnimate)
        {
            scene.beginAnimation(mesh, parsedMesh.autoAnimateFrom, parsedMesh.autoAnimateTo, parsedMesh.autoAnimateLoop, 1.0);
        }
        if (parsedMesh.layerMask && (!isNaN(parsedMesh.layerMask)))
        {
            mesh.layerMask = Math.Abs(parseInt(parsedMesh.layerMask));
        }
        else
        {
            mesh.layerMask = 0xFFFFFFFF;
        }
        if (parsedMesh.instances)
        {
            for (var index = 0; index < parsedMesh.instances.Length; index++)
            {
                var parsedInstance = parsedMesh.instances[index];
                var instance = mesh.createInstance(parsedInstance.name);
                BABYLON.Tags.AddTagsTo(instance, parsedInstance.tags);
                instance.position = BABYLON.Vector3.FromArray(parsedInstance.position);
                if (parsedInstance.rotationQuaternion)
                {
                    instance.rotationQuaternion = BABYLON.Quaternion.FromArray(parsedInstance.rotationQuaternion);
                }
                else
                    if (parsedInstance.rotation)
                    {
                        instance.rotation = BABYLON.Vector3.FromArray(parsedInstance.rotation);
                    }
                instance.scaling = BABYLON.Vector3.FromArray(parsedInstance.scaling);
                instance.checkCollisions = mesh.checkCollisions;
                if (parsedMesh.animations)
                {
                    for (animationIndex = 0; animationIndex < parsedMesh.animations.Length; animationIndex++)
                    {
                        parsedAnimation = parsedMesh.animations[animationIndex];
                        instance.animations.Add(parseAnimation(parsedAnimation));
                    }
                }
            }
        }
        return mesh;
    }
    bool isDescendantOf(object mesh, object names, object hierarchyIds)
    {
        names = ((names is Array)) ? names : new Array<object>(names);
        foreach (var i in names)
        {
            if (mesh.name == names[i])
            {
                hierarchyIds.Add(mesh.id);
                return true;
            }
        }
        if (mesh.parentId && hierarchyIds.IndexOf(mesh.parentId) != -1)
        {
            hierarchyIds.Add(mesh.id);
            return true;
        }
        return false;
    }
    VertexData importVertexData(object parsedVertexData, object geometry)
    {
        var vertexData = new BABYLON.VertexData();
        var positions = parsedVertexData.positions;
        if (positions)
        {
            vertexData.set(positions, BABYLON.VertexBufferKind.PositionKind);
        }
        var normals = parsedVertexData.normals;
        if (normals)
        {
            vertexData.set(normals, BABYLON.VertexBufferKind.NormalKind);
        }
        var uvs = parsedVertexData.uvs;
        if (uvs)
        {
            vertexData.set(uvs, BABYLON.VertexBufferKind.UVKind);
        }
        var uv2s = parsedVertexData.uv2s;
        if (uv2s)
        {
            vertexData.set(uv2s, BABYLON.VertexBufferKind.UV2Kind);
        }
        var colors = parsedVertexData.colors;
        if (colors)
        {
            vertexData.set(colors, BABYLON.VertexBufferKind.ColorKind);
        }
        var matricesIndices = parsedVertexData.matricesIndices;
        if (matricesIndices)
        {
            vertexData.set(matricesIndices, BABYLON.VertexBufferKind.MatricesIndicesKind);
        }
        var matricesWeights = parsedVertexData.matricesWeights;
        if (matricesWeights)
        {
            vertexData.set(matricesWeights, BABYLON.VertexBufferKind.MatricesWeightsKind);
        }
        var indices = parsedVertexData.indices;
        if (indices)
        {
            vertexData.indices = indices;
        }
        geometry.setAllVerticesData(vertexData, parsedVertexData.updatable);
    }
    void importGeometry(Geometry parsedGeometry, AbstractMesh mesh)
    {
        var scene = mesh.getScene();
        var geometryId = parsedGeometry.geometryId;
        if (geometryId)
        {
            var geometry = scene.getGeometryByID(geometryId);
            if (geometry)
            {
                geometry.applyToMesh(mesh);
            }
        }
        else
            if (parsedGeometry.positions && parsedGeometry.normals && parsedGeometry.indices)
            {
                mesh.setVerticesData(BABYLON.VertexBufferKind.PositionKind, parsedGeometry.positions, false);
                mesh.setVerticesData(BABYLON.VertexBufferKind.NormalKind, parsedGeometry.normals, false);
                if (parsedGeometry.uvs)
                {
                    mesh.setVerticesData(BABYLON.VertexBufferKind.UVKind, parsedGeometry.uvs, false);
                }
                if (parsedGeometry.uvs2)
                {
                    mesh.setVerticesData(BABYLON.VertexBufferKind.UV2Kind, parsedGeometry.uvs2, false);
                }
                if (parsedGeometry.colors)
                {
                    mesh.setVerticesData(BABYLON.VertexBufferKind.ColorKind, parsedGeometry.colors, false);
                }
                if (parsedGeometry.matricesIndices)
                {
                    if (!parsedGeometry.matricesIndices._isExpanded)
                    {
                        var floatIndices = new Array<object>();
                        for (var i = 0; i < parsedGeometry.matricesIndices.Length; i++)
                        {
                            var matricesIndex = parsedGeometry.matricesIndices[i];
                            floatIndices.Add(matricesIndex & 0x000000FF);
                            floatIndices.Add((matricesIndex & 0x0000FF00) << 8);
                            floatIndices.Add((matricesIndex & 0x00FF0000) << 16);
                            floatIndices.Add(matricesIndex << 24);
                        }
                        mesh.setVerticesData(BABYLON.VertexBufferKind.MatricesIndicesKind, floatIndices, false);
                    }
                    else
                    {
                        parsedGeometry.matricesIndices._isExpanded = null;
                        mesh.setVerticesData(BABYLON.VertexBufferKind.MatricesIndicesKind, parsedGeometry.matricesIndices, false);
                    }
                }
                if (parsedGeometry.matricesWeights)
                {
                    mesh.setVerticesData(BABYLON.VertexBufferKind.MatricesWeightsKind, parsedGeometry.matricesWeights, false);
                }
                mesh.setIndices(parsedGeometry.indices);
            }
        if (parsedGeometry.subMeshes)
        {
            mesh.subMeshes = new Array<object>();
            for (var subIndex = 0; subIndex < parsedGeometry.subMeshes.Length; subIndex++)
            {
                var parsedSubMesh = parsedGeometry.subMeshes[subIndex];
                var subMesh = new BABYLON.SubMesh(parsedSubMesh.materialIndex, parsedSubMesh.verticesStart, parsedSubMesh.verticesCount, parsedSubMesh.indexStart, parsedSubMesh.indexCount, mesh);
            }
        }
        if (mesh._shouldGenerateFlatShading)
        {
            mesh.convertToFlatShadedMesh();
            mesh._shouldGenerateFlatShading = null;
        }
        mesh.computeWorldMatrix(true);
        if (scene._selectionOctree)
        {
            scene._selectionOctree.addMesh(mesh);
        }
    }
    */
}