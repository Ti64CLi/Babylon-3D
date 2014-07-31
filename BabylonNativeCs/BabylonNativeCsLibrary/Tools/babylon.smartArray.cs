using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class SmartArray < T > {
        public Array < T > data;
        public int Length = 0;
        private int _id;
        private int _duplicateId = 0;
        public SmartArray(double capacity) {
            this.data = new Array(capacity);
            this._id = SmartArray._GlobalId++;
        }
        void serializeLight(Light light) {
            var serializationObject = new {};
            serializationObject.name = light.name;
            serializationObject.id = light.id;
            serializationObject.tags = Tags.GetTags(light);
            if (light is BABYLON.PointLight) {
                serializationObject.type = 0;
                serializationObject.position = ((PointLight) light).position.asArray();
            } else
            if (light is BABYLON.DirectionalLight) {
                serializationObject.type = 1;
                var directionalLight = (DirectionalLight) light;
                serializationObject.position = directionalLight.position.asArray();
                serializationObject.direction = directionalLight.direction.asArray();
            } else
            if (light is BABYLON.SpotLight) {
                serializationObject.type = 2;
                var spotLight = (SpotLight) light;
                serializationObject.position = spotLight.position.asArray();
                serializationObject.direction = spotLight.position.asArray();
                serializationObject.angle = spotLight.angle;
                serializationObject.exponent = spotLight.exponent;
            } else
            if (light is BABYLON.HemisphericLight) {
                serializationObject.type = 3;
                var hemisphericLight = (HemisphericLight) light;
                serializationObject.direction = hemisphericLight.direction.asArray();
                serializationObject.groundColor = hemisphericLight.groundColor.asArray();
            }
            if (light.intensity) {
                serializationObject.intensity = light.intensity;
            }
            serializationObject.range = light.range;
            serializationObject.diffuse = light.diffuse.asArray();
            serializationObject.specular = light.specular.asArray();
            return serializationObject;
        };
        void serializeCamera(FreeCamera camera) {
            var serializationObject = new {};
            serializationObject.name = camera.name;
            serializationObject.tags = Tags.GetTags(camera);
            serializationObject.id = camera.id;
            serializationObject.position = camera.position.asArray();
            if (camera.parent) {
                serializationObject.parentId = camera.parent.id;
            }
            serializationObject.rotation = camera.rotation.asArray();
            if (camera.lockedTarget && camera.lockedTarget.id) {
                serializationObject.lockedTargetId = camera.lockedTarget.id;
            }
            serializationObject.fov = camera.fov;
            serializationObject.minZ = camera.minZ;
            serializationObject.maxZ = camera.maxZ;
            serializationObject.speed = camera.speed;
            serializationObject.inertia = camera.inertia;
            serializationObject.checkCollisions = camera.checkCollisions;
            serializationObject.applyGravity = camera.applyGravity;
            if (camera.ellipsoid) {
                serializationObject.ellipsoid = camera.ellipsoid.asArray();
            }
            appendAnimations(camera, serializationObject);
            serializationObject.layerMask = camera.layerMask;
            return serializationObject;
        };
        void appendAnimations(IAnimatable source, object destination) {
            if (source.animations) {
                destination.animations = new Array < object > ();
                for (var animationIndex = 0; animationIndex < source.animations.Length; animationIndex++) {
                    var animation = source.animations[animationIndex];
                    destination.animations.push(serializeAnimation(animation));
                }
            }
        };
        void serializeAnimation(Animation animation) {
            var serializationObject = new {};
            serializationObject.name = animation.name;
            serializationObject.property = animation.targetProperty;
            serializationObject.framePerSecond = animation.framePerSecond;
            serializationObject.dataType = animation.dataType;
            serializationObject.loopBehavior = animation.loopMode;
            var dataType = animation.dataType;
            serializationObject.keys = new Array < object > ();
            var keys = animation.getKeys();
            for (var index = 0; index < keys.Length; index++) {
                var animationKey = keys[index];
                var key = new {};
                key.frame = animationKey.frame;
                switch (dataType) {
                    case BABYLON.Animation.ANIMATIONTYPE_FLOAT:
                        key.values = new Array < object > (animationKey.value);
                        break;
                    case BABYLON.Animation.ANIMATIONTYPE_QUATERNION:
                    case BABYLON.Animation.ANIMATIONTYPE_MATRIX:
                    case BABYLON.Animation.ANIMATIONTYPE_VECTOR3:
                        key.values = animationKey.value.asArray();
                        break;
                }
                serializationObject.keys.push(key);
            }
            return serializationObject;
        };
        void serializeMultiMaterial(MultiMaterial material) {
            var serializationObject = new {};
            serializationObject.name = material.name;
            serializationObject.id = material.id;
            serializationObject.tags = Tags.GetTags(material);
            serializationObject.materials = new Array < object > ();
            for (var matIndex = 0; matIndex < material.subMaterials.Length; matIndex++) {
                var subMat = material.subMaterials[matIndex];
                if (subMat) {
                    serializationObject.materials.push(subMat.id);
                } else {
                    serializationObject.materials.push(null);
                }
            }
            return serializationObject;
        };
        void serializeMaterial(StandardMaterial material) {
            var serializationObject = new {};
            serializationObject.name = material.name;
            serializationObject.ambient = material.ambientColor.asArray();
            serializationObject.diffuse = material.diffuseColor.asArray();
            serializationObject.specular = material.specularColor.asArray();
            serializationObject.specularPower = material.specularPower;
            serializationObject.emissive = material.emissiveColor.asArray();
            serializationObject.alpha = material.alpha;
            serializationObject.id = material.id;
            serializationObject.tags = Tags.GetTags(material);
            serializationObject.backFaceCulling = material.backFaceCulling;
            if (material.diffuseTexture) {
                serializationObject.diffuseTexture = serializeTexture(material.diffuseTexture);
            }
            if (material.ambientTexture) {
                serializationObject.ambientTexture = serializeTexture(material.ambientTexture);
            }
            if (material.opacityTexture) {
                serializationObject.opacityTexture = serializeTexture(material.opacityTexture);
            }
            if (material.reflectionTexture) {
                serializationObject.reflectionTexture = serializeTexture(material.reflectionTexture);
            }
            if (material.emissiveTexture) {
                serializationObject.emissiveTexture = serializeTexture(material.emissiveTexture);
            }
            if (material.specularTexture) {
                serializationObject.specularTexture = serializeTexture(material.specularTexture);
            }
            if (material.bumpTexture) {
                serializationObject.bumpTexture = serializeTexture(material.bumpTexture);
            }
            return serializationObject;
        };
        void serializeTexture(BaseTexture texture) {
            var serializationObject = new {};
            if (!texture.name) {
                return null;
            }
            if (texture is BABYLON.CubeTexture) {
                serializationObject.name = texture.name;
                serializationObject.hasAlpha = texture.hasAlpha;
                serializationObject.level = texture.level;
                serializationObject.coordinatesMode = texture.coordinatesMode;
                return serializationObject;
            }
            if (texture is BABYLON.MirrorTexture) {
                var mirrorTexture = (MirrorTexture) texture;
                serializationObject.renderTargetSize = mirrorTexture.getRenderSize();
                serializationObject.renderList = new Array < object > ();
                for (var index = 0; index < mirrorTexture.renderList.Length; index++) {
                    serializationObject.renderList.push(mirrorTexture.renderList[index].id);
                }
                serializationObject.mirrorPlane = mirrorTexture.mirrorPlane.asArray();
            } else
            if (texture is BABYLON.RenderTargetTexture) {
                var renderTargetTexture = (RenderTargetTexture) texture;
                serializationObject.renderTargetSize = renderTargetTexture.getRenderSize();
                serializationObject.renderList = new Array < object > ();
                for (index = 0; index < renderTargetTexture.renderList.Length; index++) {
                    serializationObject.renderList.push(renderTargetTexture.renderList[index].id);
                }
            }
            var regularTexture = (Texture) texture;
            serializationObject.name = texture.name;
            serializationObject.hasAlpha = texture.hasAlpha;
            serializationObject.level = texture.level;
            serializationObject.coordinatesIndex = texture.coordinatesIndex;
            serializationObject.coordinatesMode = texture.coordinatesMode;
            serializationObject.uOffset = regularTexture.uOffset;
            serializationObject.vOffset = regularTexture.vOffset;
            serializationObject.uScale = regularTexture.uScale;
            serializationObject.vScale = regularTexture.vScale;
            serializationObject.uAng = regularTexture.uAng;
            serializationObject.vAng = regularTexture.vAng;
            serializationObject.wAng = regularTexture.wAng;
            serializationObject.wrapU = texture.wrapU;
            serializationObject.wrapV = texture.wrapV;
            appendAnimations(texture, serializationObject);
            return serializationObject;
        };
        void serializeSkeleton(Skeleton skeleton) {
            var serializationObject = new {};
            serializationObject.name = skeleton.name;
            serializationObject.id = skeleton.id;
            serializationObject.bones = new Array < object > ();
            for (var index = 0; index < skeleton.bones.Length; index++) {
                var bone = skeleton.bones[index];
                var serializedBone = new {};
                serializationObject.bones.push(serializedBone);
                if (bone.animations && bone.animations.Length > 0) {
                    serializedBone.animation = serializeAnimation(bone.animations[0]);
                }
            }
            return serializationObject;
        };
        void serializeParticleSystem(ParticleSystem particleSystem) {
            var serializationObject = new {};
            serializationObject.emitterId = particleSystem.emitter.id;
            serializationObject.capacity = particleSystem.getCapacity();
            if (particleSystem.particleTexture) {
                serializationObject.textureName = particleSystem.particleTexture.name;
            }
            serializationObject.minAngularSpeed = particleSystem.minAngularSpeed;
            serializationObject.maxAngularSpeed = particleSystem.maxAngularSpeed;
            serializationObject.minSize = particleSystem.minSize;
            serializationObject.maxSize = particleSystem.maxSize;
            serializationObject.minLifeTime = particleSystem.minLifeTime;
            serializationObject.maxLifeTime = particleSystem.maxLifeTime;
            serializationObject.emitRate = particleSystem.emitRate;
            serializationObject.minEmitBox = particleSystem.minEmitBox.asArray();
            serializationObject.maxEmitBox = particleSystem.maxEmitBox.asArray();
            serializationObject.gravity = particleSystem.gravity.asArray();
            serializationObject.direction1 = particleSystem.direction1.asArray();
            serializationObject.direction2 = particleSystem.direction2.asArray();
            serializationObject.color1 = particleSystem.color1.asArray();
            serializationObject.color2 = particleSystem.color2.asArray();
            serializationObject.colorDead = particleSystem.colorDead.asArray();
            serializationObject.updateSpeed = particleSystem.updateSpeed;
            serializationObject.targetStopDuration = particleSystem.targetStopDuration;
            serializationObject.textureMask = particleSystem.textureMask.asArray();
            serializationObject.blendMode = particleSystem.blendMode;
            return serializationObject;
        };
        void serializeLensFlareSystem(LensFlareSystem lensFlareSystem) {
            var serializationObject = new {};
            serializationObject.emitterId = lensFlareSystem.getEmitter().id;
            serializationObject.borderLimit = lensFlareSystem.borderLimit;
            serializationObject.flares = new Array < object > ();
            for (var index = 0; index < lensFlareSystem.lensFlares.Length; index++) {
                var flare = lensFlareSystem.lensFlares[index];
                serializationObject.flares.push(new {});
            }
            return serializationObject;
        };
        void serializeShadowGenerator(Light light) {
            var serializationObject = new {};
            var shadowGenerator = light.getShadowGenerator();
            serializationObject.lightId = light.id;
            serializationObject.mapSize = shadowGenerator.getShadowMap().getRenderSize();
            serializationObject.useVarianceShadowMap = shadowGenerator.useVarianceShadowMap;
            serializationObject.usePoissonSampling = shadowGenerator.usePoissonSampling;
            serializationObject.renderList = new Array < object > ();
            for (var meshIndex = 0; meshIndex < shadowGenerator.getShadowMap().renderList.Length; meshIndex++) {
                var mesh = shadowGenerator.getShadowMap().renderList[meshIndex];
                serializationObject.renderList.push(mesh.id);
            }
            return serializationObject;
        };
        void serializedGeometriesnew Array < object > ();
        void serializeGeometry(Geometry geometry, object serializationGeometries) {
            if (serializedGeometries[geometry.id]) {
                return;
            }
            if (geometry is Geometry.Primitives.Box) {
                serializationGeometries.boxes.push(serializeBox((Geometry.Primitives.Box) geometry));
            } else
            if (geometry is Geometry.Primitives.Sphere) {
                serializationGeometries.spheres.push(serializeSphere((Geometry.Primitives.Sphere) geometry));
            } else
            if (geometry is Geometry.Primitives.Cylinder) {
                serializationGeometries.cylinders.push(serializeCylinder((Geometry.Primitives.Cylinder) geometry));
            } else
            if (geometry is Geometry.Primitives.Torus) {
                serializationGeometries.toruses.push(serializeTorus((Geometry.Primitives.Torus) geometry));
            } else
            if (geometry is Geometry.Primitives.Ground) {
                serializationGeometries.grounds.push(serializeGround((Geometry.Primitives.Ground) geometry));
            } else
            if (geometry is Geometry.Primitives.Plane) {
                serializationGeometries.planes.push(serializePlane((Geometry.Primitives.Plane) geometry));
            } else
            if (geometry is Geometry.Primitives.TorusKnot) {
                serializationGeometries.torusKnots.push(serializeTorusKnot((Geometry.Primitives.TorusKnot) geometry));
            } else
            if (geometry is Geometry.Primitives._Primitive) {
                throw new Error("Unknow primitive type");
            } else {
                serializationGeometries.vertexData.push(serializeVertexData(geometry));
            }
            serializedGeometries[geometry.id] = true;
        };
        void serializeGeometryBase(Geometry geometry) {
            var serializationObject = new {};
            serializationObject.id = geometry.id;
            if (Tags.HasTags(geometry)) {
                serializationObject.tags = Tags.GetTags(geometry);
            }
            return serializationObject;
        };
        void serializeVertexData(Geometry vertexData) {
            var serializationObject = serializeGeometryBase(vertexData);
            if (vertexData.isVerticesDataPresent(BABYLON.VertexBuffer.PositionKind)) {
                serializationObject.positions = vertexData.getVerticesData(BABYLON.VertexBuffer.PositionKind);
            }
            if (vertexData.isVerticesDataPresent(BABYLON.VertexBuffer.NormalKind)) {
                serializationObject.normals = vertexData.getVerticesData(BABYLON.VertexBuffer.NormalKind);
            }
            if (vertexData.isVerticesDataPresent(BABYLON.VertexBuffer.UVKind)) {
                serializationObject.uvs = vertexData.getVerticesData(BABYLON.VertexBuffer.UVKind);
            }
            if (vertexData.isVerticesDataPresent(BABYLON.VertexBuffer.UV2Kind)) {
                serializationObject.uvs2 = vertexData.getVerticesData(BABYLON.VertexBuffer.UV2Kind);
            }
            if (vertexData.isVerticesDataPresent(BABYLON.VertexBuffer.ColorKind)) {
                serializationObject.colors = vertexData.getVerticesData(BABYLON.VertexBuffer.ColorKind);
            }
            if (vertexData.isVerticesDataPresent(BABYLON.VertexBuffer.MatricesIndicesKind)) {
                serializationObject.matricesIndices = vertexData.getVerticesData(BABYLON.VertexBuffer.MatricesIndicesKind);
                serializationObject.matricesIndices._isExpanded = true;
            }
            if (vertexData.isVerticesDataPresent(BABYLON.VertexBuffer.MatricesWeightsKind)) {
                serializationObject.matricesWeights = vertexData.getVerticesData(BABYLON.VertexBuffer.MatricesWeightsKind);
            }
            serializationObject.indices = vertexData.getIndices();
            return serializationObject;
        };
        void serializePrimitive(Geometry.Primitives._Primitive primitive) {
            var serializationObject = serializeGeometryBase(primitive);
            serializationObject.canBeRegenerated = primitive.canBeRegenerated();
            return serializationObject;
        };
        void serializeBox(Geometry.Primitives.Box box) {
            var serializationObject = serializePrimitive(box);
            serializationObject.size = box.size;
            return serializationObject;
        };
        void serializeSphere(Geometry.Primitives.Sphere sphere) {
            var serializationObject = serializePrimitive(sphere);
            serializationObject.segments = sphere.segments;
            serializationObject.diameter = sphere.diameter;
            return serializationObject;
        };
        void serializeCylinder(Geometry.Primitives.Cylinder cylinder) {
            var serializationObject = serializePrimitive(cylinder);
            serializationObject.height = cylinder.height;
            serializationObject.diameterTop = cylinder.diameterTop;
            serializationObject.diameterBottom = cylinder.diameterBottom;
            serializationObject.tessellation = cylinder.tessellation;
            return serializationObject;
        };
        void serializeTorus(Geometry.Primitives.Torus torus) {
            var serializationObject = serializePrimitive(torus);
            serializationObject.diameter = torus.diameter;
            serializationObject.thickness = torus.thickness;
            serializationObject.tessellation = torus.tessellation;
            return serializationObject;
        };
        void serializeGround(Geometry.Primitives.Ground ground) {
            var serializationObject = serializePrimitive(ground);
            serializationObject.width = ground.width;
            serializationObject.height = ground.height;
            serializationObject.subdivisions = ground.subdivisions;
            return serializationObject;
        };
        void serializePlane(Geometry.Primitives.Plane plane) {
            var serializationObject = serializePrimitive(plane);
            serializationObject.size = plane.size;
            return serializationObject;
        };
        void serializeTorusKnot(Geometry.Primitives.TorusKnot torusKnot) {
            var serializationObject = serializePrimitive(torusKnot);
            serializationObject.radius = torusKnot.radius;
            serializationObject.tube = torusKnot.tube;
            serializationObject.radialSegments = torusKnot.radialSegments;
            serializationObject.tubularSegments = torusKnot.tubularSegments;
            serializationObject.p = torusKnot.p;
            serializationObject.q = torusKnot.q;
            return serializationObject;
        };
        void serializeMesh(Mesh mesh, object serializationScene) {
            var serializationObject = new {};
            serializationObject.name = mesh.name;
            serializationObject.id = mesh.id;
            if (Tags.HasTags(mesh)) {
                serializationObject.tags = Tags.GetTags(mesh);
            }
            serializationObject.position = mesh.position.asArray();
            if (mesh.rotationQuaternion) {
                serializationObject.rotationQuaternion = mesh.rotationQuaternion.asArray();
            } else
            if (mesh.rotation) {
                serializationObject.rotation = mesh.rotation.asArray();
            }
            serializationObject.scaling = mesh.scaling.asArray();
            serializationObject.localMatrix = mesh.getPivotMatrix().asArray();
            serializationObject.isEnabled = mesh.isEnabled();
            serializationObject.isVisible = mesh.isVisible;
            serializationObject.infiniteDistance = mesh.infiniteDistance;
            serializationObject.pickable = mesh.isPickable;
            serializationObject.receiveShadows = mesh.receiveShadows;
            serializationObject.billboardMode = mesh.billboardMode;
            serializationObject.visibility = mesh.visibility;
            serializationObject.checkCollisions = mesh.checkCollisions;
            if (mesh.parent) {
                serializationObject.parentId = mesh.parent.id;
            }
            var geometry = mesh._geometry;
            if (geometry) {
                var geometryId = geometry.id;
                serializationObject.geometryId = geometryId;
                if (!mesh.getScene().getGeometryByID(geometryId)) {
                    serializeGeometry(geometry, serializationScene.geometries);
                }
                serializationObject.subMeshes = new Array < object > ();
                for (var subIndex = 0; subIndex < mesh.subMeshes.Length; subIndex++) {
                    var subMesh = mesh.subMeshes[subIndex];
                    serializationObject.subMeshes.push(new {});
                }
            }
            if (mesh.material) {
                serializationObject.materialId = mesh.material.id;
            } else {
                mesh.material = null;
            }
            if (mesh.skeleton) {
                serializationObject.skeletonId = mesh.skeleton.id;
            }
            if (mesh.getPhysicsImpostor() != BABYLON.PhysicsEngine.NoImpostor) {
                serializationObject.physicsMass = mesh.getPhysicsMass();
                serializationObject.physicsFriction = mesh.getPhysicsFriction();
                serializationObject.physicsRestitution = mesh.getPhysicsRestitution();
                switch (mesh.getPhysicsImpostor()) {
                    case BABYLON.PhysicsEngine.BoxImpostor:
                        serializationObject.physicsImpostor = 1;
                        break;
                    case BABYLON.PhysicsEngine.SphereImpostor:
                        serializationObject.physicsImpostor = 2;
                        break;
                }
            }
            appendAnimations(mesh, serializationObject);
            serializationObject.layerMask = mesh.layerMask;
            return serializationObject;
        };
        public virtual void push(object value) {
            this.data[this.Length++] = value;
            if (this.Length > this.data.Length) {
                this.data.Length *= 2;
            }
            if (!value.__smartArrayFlags) {
                value.__smartArrayFlags = new {};
            }
            value.__smartArrayFlags[this._id] = this._duplicateId;
        }
        public virtual void pushNoDuplicate(object value) {
            if (value.__smartArrayFlags && value.__smartArrayFlags[this._id] == this._duplicateId) {
                return;
            }
            this.push(value);
        }
        public virtual void sort(object compareFn) {
            this.data.sort(compareFn);
        }
        public virtual void reset() {
            this.Length = 0;
            this._duplicateId++;
        }
        public virtual void concat(object array) {
            if (array.Length == 0) {
                return;
            }
            if (this.Length + array.Length > this.data.Length) {
                this.data.Length = (this.Length + array.Length) * 2;
            }
            for (var index = 0; index < array.Length; index++) {
                this.data[this.Length++] = (array.data || array)[index];
            }
        }
        public virtual void concatWithNoDuplicate(object array) {
            if (array.Length == 0) {
                return;
            }
            if (this.Length + array.Length > this.data.Length) {
                this.data.Length = (this.Length + array.Length) * 2;
            }
            for (var index = 0; index < array.Length; index++) {
                var item = (array.data || array)[index];
                this.pushNoDuplicate(item);
            }
        }
        public virtual double indexOf(object value) {
            var position = this.data.indexOf(value);
            if (position >= this.Length) {
                return -1;
            }
            return position;
        }
        private static double _GlobalId = 0;
    }
}