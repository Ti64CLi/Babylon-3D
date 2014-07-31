using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class AbstractMesh: Node, IDisposable {
        private
        const int _BILLBOARDMODE_NONE = 0;
        private
        const int _BILLBOARDMODE_X = 1;
        private
        const int _BILLBOARDMODE_Y = 2;
        private
        const int _BILLBOARDMODE_Z = 4;
        private
        const int _BILLBOARDMODE_ALL = 7;
        public static int BILLBOARDMODE_NONE {
            get {
                return AbstractMesh._BILLBOARDMODE_NONE;
            }
        }
        public static int BILLBOARDMODE_X {
            get {
                return AbstractMesh._BILLBOARDMODE_X;
            }
        }
        public static int BILLBOARDMODE_Y {
            get {
                return AbstractMesh._BILLBOARDMODE_Y;
            }
        }
        public static int BILLBOARDMODE_Z {
            get {
                return AbstractMesh._BILLBOARDMODE_Z;
            }
        }
        public static int BILLBOARDMODE_ALL {
            get {
                return AbstractMesh._BILLBOARDMODE_ALL;
            }
        }
        public BABYLON.Vector3 position = new BABYLON.Vector3(0, 0, 0);
        public BABYLON.Vector3 rotation = new BABYLON.Vector3(0, 0, 0);
        public Quaternion rotationQuaternion;
        public BABYLON.Vector3 scaling = new BABYLON.Vector3(1, 1, 1);
        public double billboardMode = BABYLON.AbstractMesh.BILLBOARDMODE_NONE;
        public double visibility = 1.0;
        public bool infiniteDistance = false;
        public bool isVisible = true;
        public bool isPickable = true;
        public bool showBoundingBox = false;
        public bool showSubMeshesBoundingBox = false;
        public object onDispose = null;
        public bool checkCollisions = false;
        public Skeleton skeleton;
        public double renderingGroupId = 0;
        public Material material;
        public bool receiveShadows = false;
        public ActionManager actionManager;
        public bool useOctreeForRenderingSelection = true;
        public bool useOctreeForPicking = true;
        public bool useOctreeForCollisions = true;
        public uint layerMask = 0xFFFFFFFF;
        public int _physicImpostor = PhysicsEngine.NoImpostor;
        public double _physicsMass;
        public double _physicsFriction;
        public double _physicRestitution;
        public BABYLON.Vector3 ellipsoid = new BABYLON.Vector3(0.5, 1, 0.5);
        public BABYLON.Vector3 ellipsoidOffset = new BABYLON.Vector3(0, 0, 0);
        private Collider _collider = new Collider();
        private BABYLON.Vector3 _oldPositionForCollisions = new BABYLON.Vector3(0, 0, 0);
        private BABYLON.Vector3 _diffPositionForCollisions = new BABYLON.Vector3(0, 0, 0);
        private BABYLON.Vector3 _newPositionForCollisions = new BABYLON.Vector3(0, 0, 0);
        private BABYLON.Matrix _localScaling = BABYLON.Matrix.Zero();
        private BABYLON.Matrix _localRotation = BABYLON.Matrix.Zero();
        private BABYLON.Matrix _localTranslation = BABYLON.Matrix.Zero();
        private BABYLON.Matrix _localBillboard = BABYLON.Matrix.Zero();
        private BABYLON.Matrix _localPivotScaling = BABYLON.Matrix.Zero();
        private BABYLON.Matrix _localPivotScalingRotation = BABYLON.Matrix.Zero();
        private BABYLON.Matrix _localWorld = BABYLON.Matrix.Zero();
        private BABYLON.Matrix _worldMatrix = BABYLON.Matrix.Zero();
        private BABYLON.Matrix _rotateYByPI = BABYLON.Matrix.RotationY(Math.PI);
        private BABYLON.Vector3 _absolutePosition = BABYLON.Vector3.Zero();
        private BABYLON.Matrix _collisionsTransformMatrix = BABYLON.Matrix.Zero();
        private BABYLON.Matrix _collisionsScalingMatrix = BABYLON.Matrix.Zero();
        public Array < Vector3 > _positions;
        private bool _isDirty = false;
        public BoundingInfo _boundingInfo;
        private BABYLON.Matrix _pivotMatrix = BABYLON.Matrix.Identity();
        public bool _isDisposed = false;
        public double _renderId = 0;
        public Array < SubMesh > subMeshes;
        public Octree < SubMesh > _submeshesOctree;
        public Array < AbstractMesh > _intersectionsInProgress = new Array < AbstractMesh > ();
        public AbstractMesh(string name, Scene scene): base(name, scene) {
            scene.meshes.push(this);
        };
        public virtual int getTotalVertices() {
            return 0;
        }
        public virtual Array < double > getIndices() {
            return null;
        }
        public virtual Array < double > getVerticesData(string kind) {
            return null;
        }
        public virtual bool isVerticesDataPresent(string kind) {
            return false;
        }
        public virtual BoundingInfo getBoundingInfo() {
            if (!this._boundingInfo) {
                this._updateBoundingInfo();
            }
            return this._boundingInfo;
        }
        public virtual void _preActivate() {}
        public virtual void _activate(double renderId) {
            this._renderId = renderId;
        }
        public virtual Matrix getWorldMatrix() {
            if (this._currentRenderId != this.getScene().getRenderId()) {
                this.computeWorldMatrix();
            }
            return this._worldMatrix;
        }
        public virtual Matrix worldMatrixFromCache {
            get {
                return this._worldMatrix;
            }
        }
        public virtual Vector3 absolutePosition {
            get {
                return this._absolutePosition;
            }
        }
        public virtual void rotate(Vector3 axis, double amount, Space space) {
            if (!this.rotationQuaternion) {
                this.rotationQuaternion = BABYLON.Quaternion.RotationYawPitchRoll(this.rotation.y, this.rotation.x, this.rotation.z);
                this.rotation = BABYLON.Vector3.Zero();
            }
            if (!space || space == BABYLON.Space.LOCAL) {
                var rotationQuaternion = BABYLON.Quaternion.RotationAxis(axis, amount);
                this.rotationQuaternion = this.rotationQuaternion.multiply(rotationQuaternion);
            } else {
                if (this.parent) {
                    var invertParentWorldMatrix = this.parent.getWorldMatrix().clone();
                    invertParentWorldMatrix.invert();
                    axis = BABYLON.Vector3.TransformNormal(axis, invertParentWorldMatrix);
                }
                rotationQuaternion = BABYLON.Quaternion.RotationAxis(axis, amount);
                this.rotationQuaternion = rotationQuaternion.multiply(this.rotationQuaternion);
            }
        }
        public virtual void translate(Vector3 axis, double distance, Space space) {
            var displacementVector = axis.scale(distance);
            if (!space || space == BABYLON.Space.LOCAL) {
                var tempV3 = this.getPositionExpressedInLocalSpace().add(displacementVector);
                this.setPositionWithLocalVector(tempV3);
            } else {
                this.setAbsolutePosition(this.getAbsolutePosition().add(displacementVector));
            }
        }
        public virtual Vector3 getAbsolutePosition() {
            this.computeWorldMatrix();
            return this._absolutePosition;
        }
        public virtual void setAbsolutePosition(Vector3 absolutePosition) {
            if (!absolutePosition) {
                return;
            }
            var absolutePositionX;
            var absolutePositionY;
            var absolutePositionZ;
            if (absolutePosition.x == null) {
                if (arguments.Length < 3) {
                    return;
                }
                absolutePositionX = arguments[0];
                absolutePositionY = arguments[1];
                absolutePositionZ = arguments[2];
            } else {
                absolutePositionX = absolutePosition.x;
                absolutePositionY = absolutePosition.y;
                absolutePositionZ = absolutePosition.z;
            }
            if (this.parent) {
                var invertParentWorldMatrix = this.parent.getWorldMatrix().clone();
                invertParentWorldMatrix.invert();
                var worldPosition = new BABYLON.Vector3(absolutePositionX, absolutePositionY, absolutePositionZ);
                this.position = BABYLON.Vector3.TransformCoordinates(worldPosition, invertParentWorldMatrix);
            } else {
                this.position.x = absolutePositionX;
                this.position.y = absolutePositionY;
                this.position.z = absolutePositionZ;
            }
        }
        public virtual void setPivotMatrix(Matrix matrix) {
            this._pivotMatrix = matrix;
            this._cache.pivotMatrixUpdated = true;
        }
        public virtual Matrix getPivotMatrix() {
            return this._pivotMatrix;
        }
        public virtual bool _isSynchronized() {
            if (this._isDirty) {
                return false;
            }
            if (this.billboardMode != AbstractMesh.BILLBOARDMODE_NONE)
                return false;
            if (this._cache.pivotMatrixUpdated) {
                return false;
            }
            if (this.infiniteDistance) {
                return false;
            }
            if (!this._cache.position.equals(this.position))
                return false;
            if (this.rotationQuaternion) {
                if (!this._cache.rotationQuaternion.equals(this.rotationQuaternion))
                    return false;
            } else {
                if (!this._cache.rotation.equals(this.rotation))
                    return false;
            }
            if (!this._cache.scaling.equals(this.scaling))
                return false;
            return true;
        }
        public virtual void _initCache() {
            base._initCache();
            this._cache.localMatrixUpdated = false;
            this._cache.position = BABYLON.Vector3.Zero();
            this._cache.scaling = BABYLON.Vector3.Zero();
            this._cache.rotation = BABYLON.Vector3.Zero();
            this._cache.rotationQuaternion = new BABYLON.Quaternion(0, 0, 0, 0);
        }
        public virtual void markAsDirty(string property) {
            if (property == "rotation") {
                this.rotationQuaternion = null;
            }
            this._currentRenderId = double.MaxValue;
            this._isDirty = true;
        }
        public virtual void _updateBoundingInfo() {
            this._boundingInfo = this._boundingInfo || new BABYLON.BoundingInfo(this.absolutePosition, this.absolutePosition);
            this._boundingInfo._update(this.worldMatrixFromCache);
            if (!this.subMeshes) {
                return;
            }
            for (var subIndex = 0; subIndex < this.subMeshes.Length; subIndex++) {
                var subMesh = this.subMeshes[subIndex];
                subMesh.updateBoundingInfo(this.worldMatrixFromCache);
            }
        }
        public virtual Matrix computeWorldMatrix(bool force = false) {
            if (!force && (this._currentRenderId == this.getScene().getRenderId() || this.isSynchronized(true))) {
                return this._worldMatrix;
            }
            this._cache.position.copyFrom(this.position);
            this._cache.scaling.copyFrom(this.scaling);
            this._cache.pivotMatrixUpdated = false;
            this._currentRenderId = this.getScene().getRenderId();
            this._isDirty = false;
            BABYLON.Matrix.ScalingToRef(this.scaling.x, this.scaling.y, this.scaling.z, this._localScaling);
            if (this.rotationQuaternion) {
                this.rotationQuaternion.toRotationMatrix(this._localRotation);
                this._cache.rotationQuaternion.copyFrom(this.rotationQuaternion);
            } else {
                BABYLON.Matrix.RotationYawPitchRollToRef(this.rotation.y, this.rotation.x, this.rotation.z, this._localRotation);
                this._cache.rotation.copyFrom(this.rotation);
            }
            if (this.infiniteDistance && !this.parent) {
                var camera = this.getScene().activeCamera;
                var cameraWorldMatrix = camera.getWorldMatrix();
                var cameraGlobalPosition = new BABYLON.Vector3(cameraWorldMatrix.m[12], cameraWorldMatrix.m[13], cameraWorldMatrix.m[14]);
                BABYLON.Matrix.TranslationToRef(this.position.x + cameraGlobalPosition.x, this.position.y + cameraGlobalPosition.y, this.position.z + cameraGlobalPosition.z, this._localTranslation);
            } else {
                BABYLON.Matrix.TranslationToRef(this.position.x, this.position.y, this.position.z, this._localTranslation);
            }
            this._pivotMatrix.multiplyToRef(this._localScaling, this._localPivotScaling);
            this._localPivotScaling.multiplyToRef(this._localRotation, this._localPivotScalingRotation);
            if (this.billboardMode != AbstractMesh.BILLBOARDMODE_NONE) {
                var localPosition = this.position.clone();
                var zero = this.getScene().activeCamera.position.clone();
                if (this.parent && ((object) this.parent).position) {
                    localPosition.addInPlace(((object) this.parent).position);
                    BABYLON.Matrix.TranslationToRef(localPosition.x, localPosition.y, localPosition.z, this._localTranslation);
                }
                if ((this.billboardMode & AbstractMesh.BILLBOARDMODE_ALL) == AbstractMesh.BILLBOARDMODE_ALL) {
                    zero = this.getScene().activeCamera.position;
                } else {
                    if (this.billboardMode & BABYLON.AbstractMesh.BILLBOARDMODE_X)
                        zero.x = localPosition.x + BABYLON.Engine.Epsilon;
                    if (this.billboardMode & BABYLON.AbstractMesh.BILLBOARDMODE_Y)
                        zero.y = localPosition.y + 0.001;
                    if (this.billboardMode & BABYLON.AbstractMesh.BILLBOARDMODE_Z)
                        zero.z = localPosition.z + 0.001;
                }
                BABYLON.Matrix.LookAtLHToRef(localPosition, zero, BABYLON.Vector3.Up(), this._localBillboard);
                this._localBillboard.m[12] = this._localBillboard.m[13] = this._localBillboard.m[14] = 0;
                this._localBillboard.invert();
                this._localPivotScalingRotation.multiplyToRef(this._localBillboard, this._localWorld);
                this._rotateYByPI.multiplyToRef(this._localWorld, this._localPivotScalingRotation);
            }
            this._localPivotScalingRotation.multiplyToRef(this._localTranslation, this._localWorld);
            if (this.parent && this.parent.getWorldMatrix && this.billboardMode == BABYLON.AbstractMesh.BILLBOARDMODE_NONE) {
                this._localWorld.multiplyToRef(this.parent.getWorldMatrix(), this._worldMatrix);
            } else {
                this._worldMatrix.copyFrom(this._localWorld);
            }
            this._updateBoundingInfo();
            this._absolutePosition.copyFromFloats(this._worldMatrix.m[12], this._worldMatrix.m[13], this._worldMatrix.m[14]);
            return this._worldMatrix;
        }
        public virtual void setPositionWithLocalVector(Vector3 vector3) {
            this.computeWorldMatrix();
            this.position = BABYLON.Vector3.TransformNormal(vector3, this._localWorld);
        }
        public virtual Vector3 getPositionExpressedInLocalSpace() {
            this.computeWorldMatrix();
            var invLocalWorldMatrix = this._localWorld.clone();
            invLocalWorldMatrix.invert();
            return BABYLON.Vector3.TransformNormal(this.position, invLocalWorldMatrix);
        }
        public virtual void locallyTranslate(Vector3 vector3) {
            this.computeWorldMatrix();
            this.position = BABYLON.Vector3.TransformCoordinates(vector3, this._localWorld);
        }
        public virtual void lookAt(Vector3 targetPoint, double yawCor, double pitchCor, double rollCor) {
            yawCor = yawCor || 0;
            pitchCor = pitchCor || 0;
            rollCor = rollCor || 0;
            var dv = targetPoint.subtract(this.position);
            var yaw = -Math.Atan2(dv.z, dv.x) - Math.PI / 2;
            var len = Math.Sqrt(dv.x * dv.x + dv.z * dv.z);
            var pitch = Math.Atan2(dv.y, len);
            this.rotationQuaternion = BABYLON.Quaternion.RotationYawPitchRoll(yaw + yawCor, pitch + pitchCor, rollCor);
        }
        public virtual bool isInFrustum(Array < Plane > frustumPlanes) {
            if (!this._boundingInfo.isInFrustum(frustumPlanes)) {
                return false;
            }
            return true;
        }
        public virtual bool intersectsMesh(AbstractMesh mesh, bool precise = false) {
            if (!this._boundingInfo || !mesh._boundingInfo) {
                return false;
            }
            return this._boundingInfo.intersects(mesh._boundingInfo, precise);
        }
        public virtual bool intersectsPoint(Vector3 point) {
            if (!this._boundingInfo) {
                return false;
            }
            return this._boundingInfo.intersectsPoint(point);
        }
        public virtual void setPhysicsState(object impostor = null, PhysicsBodyCreationOptions options = null) {
            var physicsEngine = this.getScene().getPhysicsEngine();
            if (!physicsEngine) {
                return;
            }
            if (impostor.impostor) {
                options = impostor;
                impostor = impostor.impostor;
            }
            impostor = impostor || PhysicsEngine.NoImpostor;
            if (impostor == BABYLON.PhysicsEngine.NoImpostor) {
                physicsEngine._unregisterMesh(this);
                return;
            }
            options.mass = options.mass || 0;
            options.friction = options.friction || 0.2;
            options.restitution = options.restitution || 0.9;
            this._physicImpostor = impostor;
            this._physicsMass = options.mass;
            this._physicsFriction = options.friction;
            this._physicRestitution = options.restitution;
            physicsEngine._registerMesh(this, impostor, options);
        }
        public virtual double getPhysicsImpostor() {
            if (!this._physicImpostor) {
                return BABYLON.PhysicsEngine.NoImpostor;
            }
            return this._physicImpostor;
        }
        public virtual double getPhysicsMass() {
            if (!this._physicsMass) {
                return 0;
            }
            return this._physicsMass;
        }
        public virtual double getPhysicsFriction() {
            if (!this._physicsFriction) {
                return 0;
            }
            return this._physicsFriction;
        }
        public virtual double getPhysicsRestitution() {
            if (!this._physicRestitution) {
                return 0;
            }
            return this._physicRestitution;
        }
        public virtual void applyImpulse(Vector3 force, Vector3 contactPoint) {
            if (!this._physicImpostor) {
                return;
            }
            this.getScene().getPhysicsEngine()._applyImpulse(this, force, contactPoint);
        }
        public virtual void setPhysicsLinkWith(Mesh otherMesh, Vector3 pivot1, Vector3 pivot2) {
            if (!this._physicImpostor) {
                return;
            }
            this.getScene().getPhysicsEngine()._createLink(this, otherMesh, pivot1, pivot2);
        }
        public virtual void moveWithCollisions(Vector3 velocity) {
            var globalPosition = this.getAbsolutePosition();
            globalPosition.subtractFromFloatsToRef(0, this.ellipsoid.y, 0, this._oldPositionForCollisions);
            this._oldPositionForCollisions.addInPlace(this.ellipsoidOffset);
            this._collider.radius = this.ellipsoid;
            this.getScene()._getNewPosition(this._oldPositionForCollisions, velocity, this._collider, 3, this._newPositionForCollisions, this);
            this._newPositionForCollisions.subtractToRef(this._oldPositionForCollisions, this._diffPositionForCollisions);
            if (this._diffPositionForCollisions.Length() > Engine.CollisionsEpsilon) {
                this.position.addInPlace(this._diffPositionForCollisions);
            }
        }
        public virtual Octree < SubMesh > createOrUpdateSubmeshesOctree(object maxCapacity = 64, object maxDepth = 2) {
            if (!this._submeshesOctree) {
                this._submeshesOctree = new BABYLON.Octree < SubMesh > (Octree.CreationFuncForSubMeshes, maxCapacity, maxDepth);
            }
            this.computeWorldMatrix(true);
            var bbox = this.getBoundingInfo().boundingBox;
            this._submeshesOctree.update(bbox.minimumWorld, bbox.maximumWorld, this.subMeshes);
            return this._submeshesOctree;
        }
        public virtual void _collideForSubMesh(SubMesh subMesh, Matrix transformMatrix, Collider collider) {
            this._generatePointsArray();
            if (!subMesh._lastColliderWorldVertices || !subMesh._lastColliderTransformMatrix.equals(transformMatrix)) {
                subMesh._lastColliderTransformMatrix = transformMatrix.clone();
                subMesh._lastColliderWorldVertices = new Array < object > ();
                subMesh._trianglePlanes = new Array < object > ();
                var start = subMesh.verticesStart;
                var end = (subMesh.verticesStart + subMesh.verticesCount);
                for (var i = start; i < end; i++) {
                    subMesh._lastColliderWorldVertices.push(BABYLON.Vector3.TransformCoordinates(this._positions[i], transformMatrix));
                }
            }
            collider._collide(subMesh, subMesh._lastColliderWorldVertices, this.getIndices(), subMesh.indexStart, subMesh.indexStart + subMesh.indexCount, subMesh.verticesStart);
        }
        public virtual void _processCollisionsForSubMeshes(Collider collider, Matrix transformMatrix) {
            var subMeshes;
            var len;
            if (this._submeshesOctree && this.useOctreeForCollisions) {
                var radius = collider.velocityWorldLength + Math.Max(collider.radius.x, collider.radius.y, collider.radius.z);
                var intersections = this._submeshesOctree.intersects(collider.basePointWorld, radius);
                len = intersections.Length;
                subMeshes = intersections.data;
            } else {
                subMeshes = this.subMeshes;
                len = subMeshes.Length;
            }
            for (var index = 0; index < len; index++) {
                var subMesh = subMeshes[index];
                if (len > 1 && !subMesh._checkCollision(collider))
                    continue;
                this._collideForSubMesh(subMesh, transformMatrix, collider);
            }
        }
        public virtual void _checkCollision(Collider collider) {
            if (!this._boundingInfo._checkCollision(collider))
                return;
            BABYLON.Matrix.ScalingToRef(1.0 / collider.radius.x, 1.0 / collider.radius.y, 1.0 / collider.radius.z, this._collisionsScalingMatrix);
            this.worldMatrixFromCache.multiplyToRef(this._collisionsScalingMatrix, this._collisionsTransformMatrix);
            this._processCollisionsForSubMeshes(collider, this._collisionsTransformMatrix);
        }
        public virtual bool _generatePointsArray() {
            return false;
        }
        public virtual PickingInfo intersects(Ray ray, bool fastCheck = false) {
            var pickingInfo = new BABYLON.PickingInfo();
            if (!this.subMeshes || !this._boundingInfo || !ray.intersectsSphere(this._boundingInfo.boundingSphere) || !ray.intersectsBox(this._boundingInfo.boundingBox)) {
                return pickingInfo;
            }
            if (!this._generatePointsArray()) {
                return pickingInfo;
            }
            var intersectInfo = null;
            var subMeshes;
            var len;
            if (this._submeshesOctree && this.useOctreeForPicking) {
                var worldRay = Ray.Transform(ray, this.getWorldMatrix());
                var intersections = this._submeshesOctree.intersectsRay(worldRay);
                len = intersections.Length;
                subMeshes = intersections.data;
            } else {
                subMeshes = this.subMeshes;
                len = subMeshes.Length;
            }
            for (var index = 0; index < len; index++) {
                var subMesh = subMeshes[index];
                if (len > 1 && !subMesh.canIntersects(ray))
                    continue;
                var currentIntersectInfo = subMesh.intersects(ray, this._positions, this.getIndices(), fastCheck);
                if (currentIntersectInfo) {
                    if (fastCheck || !intersectInfo || currentIntersectInfo.distance < intersectInfo.distance) {
                        intersectInfo = currentIntersectInfo;
                        if (fastCheck) {
                            break;
                        }
                    }
                }
            }
            if (intersectInfo) {
                var world = this.getWorldMatrix();
                var worldOrigin = BABYLON.Vector3.TransformCoordinates(ray.origin, world);
                var direction = ray.direction.clone();
                direction.normalize();
                direction = direction.scale(intersectInfo.distance);
                var worldDirection = BABYLON.Vector3.TransformNormal(direction, world);
                var pickedPoint = worldOrigin.add(worldDirection);
                pickingInfo.hit = true;
                pickingInfo.distance = BABYLON.Vector3.Distance(worldOrigin, pickedPoint);
                pickingInfo.pickedPoint = pickedPoint;
                pickingInfo.pickedMesh = this;
                pickingInfo.bu = intersectInfo.bu;
                pickingInfo.bv = intersectInfo.bv;
                pickingInfo.faceId = intersectInfo.faceId;
                return pickingInfo;
            }
            return pickingInfo;
        }
        public virtual AbstractMesh clone(string name, Node newParent, bool doNotCloneChildren = false) {
            return null;
        }
        public virtual void releaseSubMeshes() {
            if (this.subMeshes) {
                while (this.subMeshes.Length) {
                    this.subMeshes[0].dispose();
                }
            } else {
                this.subMeshes = new Array < SubMesh > ();
            }
        }
        public virtual void dispose(bool doNotRecurse = false) {
            if (this.getPhysicsImpostor() != PhysicsEngine.NoImpostor) {
                this.setPhysicsState(PhysicsEngine.NoImpostor);
            }
            for (index = 0; index < this._intersectionsInProgress.Length; index++) {
                var other = this._intersectionsInProgress[index];
                var pos = other._intersectionsInProgress.indexOf(this);
                other._intersectionsInProgress.splice(pos, 1);
            }
            this._intersectionsInProgress = new Array < object > ();
            this.releaseSubMeshes();
            var index = this.getScene().meshes.indexOf(this);
            this.getScene().meshes.splice(index, 1);
            if (!doNotRecurse) {
                for (index = 0; index < this.getScene().particleSystems.Length; index++) {
                    if (this.getScene().particleSystems[index].emitter == this) {
                        this.getScene().particleSystems[index].dispose();
                        index--;
                    }
                }
                var objects = this.getScene().meshes.slice(0);
                for (index = 0; index < objects.Length; index++) {
                    if (objects[index].parent == this) {
                        objects[index].dispose();
                    }
                }
            } else {
                for (index = 0; index < this.getScene().meshes.Length; index++) {
                    var obj = this.getScene().meshes[index];
                    if (obj.parent == this) {
                        obj.parent = null;
                        obj.computeWorldMatrix(true);
                    }
                }
            }
            this._isDisposed = true;
            if (this.onDispose) {
                this.onDispose();
            }
        }
    }
}