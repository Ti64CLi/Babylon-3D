using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class _InstancesBatch
    {
        public bool mustReturn = false;
        public Array<Array<InstancedMesh>> visibleInstances = new Array<Array<InstancedMesh>>();
        public Array<bool> renderSelf = new Array<bool>();
    }
    public partial class Mesh : AbstractMesh, IGetSetVerticesData
    {
        public int delayLoadState = BABYLON.Engine.DELAYLOADSTATE_NONE;
        public Array<InstancedMesh> instances = new Array<InstancedMesh>();
        public string delayLoadingFile;
        public Geometry _geometry;
        private Array<System.Action> _onBeforeRenderCallbacks = new Array<System.Action>();
        public Array<VertexBufferKind> _delayInfo;
        public System.Action<string, Mesh> _delayLoadingFunction;
        public InstancedMeshes _visibleInstances = null;
        private Array<int> _renderIdForInstances = new Array<int>();
        private _InstancesBatch _batchCache = new _InstancesBatch();
        private WebGLBuffer _worldMatricesInstancesBuffer;
        private Float32Array _worldMatricesInstancesArray;
        private int _instancesBufferSize = 32 * 16 * 4;
        public bool _shouldGenerateFlatShading;

        private static Web.Document document;

        public Mesh(string name, Scene scene) : base(name, scene) { }
        public virtual int getTotalVertices()
        {
            if (this._geometry == null)
            {
                return 0;
            }
            return this._geometry.getTotalVertices();
        }
        public virtual Array<double> getVerticesData(VertexBufferKind kind)
        {
            if (this._geometry == null)
            {
                return null;
            }
            return this._geometry.getVerticesData(kind);
        }
        public virtual VertexBuffer getVertexBuffer(VertexBufferKind kind)
        {
            if (this._geometry == null)
            {
                return null;
            }
            return this._geometry.getVertexBuffer(kind);
        }
        public virtual bool isVerticesDataPresent(VertexBufferKind kind)
        {
            if (this._geometry == null)
            {
                if (this._delayInfo != null)
                {
                    return this._delayInfo.indexOf(kind) != -1;
                }
                return false;
            }
            return this._geometry.isVerticesDataPresent(kind);
        }
        public virtual Array<VertexBufferKind> getVerticesDataKinds()
        {
            if (this._geometry == null)
            {
                var result = new Array<VertexBufferKind>();
                if (this._delayInfo != null)
                {
                    foreach (var kind in this._delayInfo)
                    {
                        result.push(kind);
                    }
                }
                return result;
            }
            return this._geometry.getVerticesDataKinds();
        }
        public virtual int getTotalIndices()
        {
            if (this._geometry == null)
            {
                return 0;
            }
            return this._geometry.getTotalIndices();
        }
        public virtual Array<int> getIndices()
        {
            if (this._geometry == null)
            {
                return new Array<int>();
            }
            return this._geometry.getIndices();
        }
        public virtual bool isReady()
        {
            if (this.delayLoadState == BABYLON.Engine.DELAYLOADSTATE_LOADING)
            {
                return false;
            }
            return base.isReady();
        }
        public virtual bool isDisposed()
        {
            return this._isDisposed;
        }
        public virtual void _preActivate()
        {
            this._visibleInstances = null;
        }
        public virtual void _registerInstanceForRenderId(InstancedMesh instance, int renderId)
        {
            if (this._visibleInstances == null)
            {
                this._visibleInstances = new InstancedMeshes();
                this._visibleInstances.defaultRenderId = renderId;
                this._visibleInstances.selfDefaultRenderId = this._renderId;
            }
            if (this._visibleInstances[renderId] == null)
            {
                this._visibleInstances[renderId] = new Array<InstancedMesh>();
            }
            this._visibleInstances[renderId].push(instance);
        }
        public virtual void refreshBoundingInfo()
        {
            var data = this.getVerticesData(BABYLON.VertexBufferKind.PositionKind);
            if (data != null)
            {
                var extend = BABYLON.Tools.ExtractMinAndMax(data, 0, this.getTotalVertices());
                this._boundingInfo = new BABYLON.BoundingInfo(extend.minimum, extend.maximum);
            }
            if (this.subMeshes != null)
            {
                for (var index = 0; index < this.subMeshes.Length; index++)
                {
                    this.subMeshes[index].refreshBoundingInfo();
                }
            }
            this._updateBoundingInfo();
        }
        public virtual SubMesh _createGlobalSubMesh()
        {
            var totalVertices = this.getTotalVertices();
            if (totalVertices == null || this.getIndices() == null)
            {
                return null;
            }
            this.releaseSubMeshes();
            return new BABYLON.SubMesh(0, 0, totalVertices, 0, this.getTotalIndices(), this);
        }
        public virtual void subdivide(int count)
        {
            if (count < 1)
            {
                return;
            }
            var totalIndices = this.getTotalIndices();
            var subdivisionSize = (totalIndices / count);
            var offset = 0;
            while (subdivisionSize % 3 != 0)
            {
                subdivisionSize++;
            }
            this.releaseSubMeshes();
            for (var index = 0; index < count; index++)
            {
                if (offset >= totalIndices)
                {
                    break;
                }
                BABYLON.SubMesh.CreateFromIndices(0, offset, Math.Min(subdivisionSize, totalIndices - offset), this);
                offset += subdivisionSize;
            }
            this.synchronizeInstances();
        }
        public virtual void setVerticesData(VertexBufferKind kind, Array<double> data, bool updatable = false)
        {
            if (this._geometry == null)
            {
                var vertexData = new BABYLON.VertexData();
                vertexData.set(data, kind);
                var scene = this.getScene();
                new BABYLON.Geometry(Geometry.RandomId(), scene, vertexData, updatable, this);
            }
            else
            {
                this._geometry.setVerticesData(kind, data, updatable);
            }
        }
        public virtual void updateVerticesData(VertexBufferKind kind, Array<double> data, bool updateExtends = false, bool makeItUnique = false)
        {
            if (this._geometry == null)
            {
                return;
            }
            if (!makeItUnique)
            {
                this._geometry.updateVerticesData(kind, data, updateExtends);
            }
            else
            {
                this.makeGeometryUnique();
                this.updateVerticesData(kind, data, updateExtends, false);
            }
        }
        public virtual void makeGeometryUnique()
        {
            if (this._geometry == null)
            {
                return;
            }
            var geometry = this._geometry.copy(Geometry.RandomId());
            geometry.applyToMesh(this);
        }
        public virtual void setIndices(Array<int> indices)
        {
            if (this._geometry == null)
            {
                var vertexData = new BABYLON.VertexData();
                vertexData.indices = indices;
                var scene = this.getScene();
                new BABYLON.Geometry(BABYLON.Geometry.RandomId(), scene, vertexData, false, this);
            }
            else
            {
                this._geometry.setIndices(indices);
            }
        }
        public virtual void _bind(SubMesh subMesh, Effect effect, bool wireframe = false)
        {
            var engine = this.getScene().getEngine();
            var indexToBind = this._geometry.getIndexBuffer();
            if (wireframe)
            {
                indexToBind = subMesh.getLinesIndexBuffer(this.getIndices(), engine);
            }
            engine.bindMultiBuffers(this._geometry.getVertexBuffers(), indexToBind, effect);
        }
        public virtual void _draw(SubMesh subMesh, bool useTriangles, int instancesCount = 0)
        {
            if (this._geometry == null || this._geometry.getVertexBuffers() == null || this._geometry.getIndexBuffer() == null)
            {
                return;
            }
            var engine = this.getScene().getEngine();
            engine.draw(useTriangles, (useTriangles) ? subMesh.indexStart : 0, (useTriangles) ? subMesh.indexCount : subMesh.linesIndexCount, instancesCount);
        }
        public virtual void registerBeforeRender(System.Action func)
        {
            this._onBeforeRenderCallbacks.push(func);
        }
        public virtual void unregisterBeforeRender(System.Action func)
        {
            var index = this._onBeforeRenderCallbacks.indexOf(func);
            if (index > -1)
            {
                this._onBeforeRenderCallbacks.splice(index, 1);
            }
        }
        public virtual _InstancesBatch _getInstancesRenderList(int subMeshId)
        {
            var scene = this.getScene();
            this._batchCache.mustReturn = false;
            this._batchCache.renderSelf[subMeshId] = true;
            this._batchCache.visibleInstances[subMeshId] = null;
            if (this._visibleInstances != null)
            {
                var currentRenderId = scene.getRenderId();
                this._batchCache.visibleInstances[subMeshId] = this._visibleInstances[currentRenderId];
                var selfRenderId = this._renderId;
                if (this._batchCache.visibleInstances[subMeshId] == null && this._visibleInstances.defaultRenderId > 0)
                {
                    this._batchCache.visibleInstances[subMeshId] = this._visibleInstances[this._visibleInstances.defaultRenderId];
                    currentRenderId = this._visibleInstances.defaultRenderId;
                    selfRenderId = this._visibleInstances.selfDefaultRenderId;
                }
                if (this._batchCache.visibleInstances[subMeshId] != null && this._batchCache.visibleInstances[subMeshId].Length > 0)
                {
                    if (this._renderIdForInstances[subMeshId] == currentRenderId)
                    {
                        this._batchCache.mustReturn = true;
                        return this._batchCache;
                    }
                    if (currentRenderId != selfRenderId)
                    {
                        this._batchCache.renderSelf[subMeshId] = false;
                    }
                }
                this._renderIdForInstances[subMeshId] = currentRenderId;
            }
            return this._batchCache;
        }
        public virtual void _renderWithInstances(SubMesh subMesh, bool wireFrame, _InstancesBatch batch, Effect effect, Engine engine)
        {
            var matricesCount = this.instances.Length + 1;
            var bufferSize = matricesCount * 16 * 4;
            while (this._instancesBufferSize < bufferSize)
            {
                this._instancesBufferSize *= 2;
            }
            if (this._worldMatricesInstancesBuffer == null || this._worldMatricesInstancesBuffer.capacity < this._instancesBufferSize)
            {
                if (this._worldMatricesInstancesBuffer != null)
                {
                    engine.deleteInstancesBuffer(this._worldMatricesInstancesBuffer);
                }
                this._worldMatricesInstancesBuffer = engine.createInstancesBuffer(this._instancesBufferSize);
                this._worldMatricesInstancesArray = new Float32Array(this._instancesBufferSize / 4);
            }
            var offset = 0;
            var instancesCount = 0;
            var world = this.getWorldMatrix();
            if (batch.renderSelf[subMesh._id])
            {
                world.copyToArray(this._worldMatricesInstancesArray, offset);
                offset += 16;
                instancesCount++;
            }
            var visibleInstances = batch.visibleInstances[subMesh._id];
            if (visibleInstances != null)
            {
                for (var instanceIndex = 0; instanceIndex < visibleInstances.Length; instanceIndex++)
                {
                    var instance = visibleInstances[instanceIndex];
                    instance.getWorldMatrix().copyToArray(this._worldMatricesInstancesArray, offset);
                    offset += 16;
                    instancesCount++;
                }
            }
            var offsetLocation0 = effect.getAttributeLocationByName("world0");
            var offsetLocation1 = effect.getAttributeLocationByName("world1");
            var offsetLocation2 = effect.getAttributeLocationByName("world2");
            var offsetLocation3 = effect.getAttributeLocationByName("world3");
            var offsetLocations = new Array<VertexBufferKind>(offsetLocation0, offsetLocation1, offsetLocation2, offsetLocation3);
            engine.updateAndBindInstancesBuffer(this._worldMatricesInstancesBuffer, this._worldMatricesInstancesArray, offsetLocations);
            this._draw(subMesh, !wireFrame, instancesCount);
            engine.unBindInstancesBuffer(this._worldMatricesInstancesBuffer, offsetLocations);
        }
        public virtual void render(SubMesh subMesh)
        {
            var scene = this.getScene();
            var batch = this._getInstancesRenderList(subMesh._id);
            if (batch.mustReturn)
            {
                return;
            }
            if (this._geometry == null || this._geometry.getVertexBuffers() == null || this._geometry.getIndexBuffer() == null)
            {
                return;
            }
            for (var callbackIndex = 0; callbackIndex < this._onBeforeRenderCallbacks.Length; callbackIndex++)
            {
                this._onBeforeRenderCallbacks[callbackIndex]();
            }
            var engine = scene.getEngine();
            var hardwareInstancedRendering = (engine.getCaps().instancedArrays != null) && (batch.visibleInstances[subMesh._id] != null);
            var effectiveMaterial = subMesh.getMaterial();
            if (effectiveMaterial == null || !effectiveMaterial.isReady(this, hardwareInstancedRendering))
            {
                return;
            }
            effectiveMaterial._preBind();
            var effect = effectiveMaterial.getEffect();
            var wireFrame = engine.forceWireframe || effectiveMaterial.wireframe;
            this._bind(subMesh, effect, wireFrame);
            var world = this.getWorldMatrix();
            effectiveMaterial.bind(world, this);
            if (hardwareInstancedRendering)
            {
                this._renderWithInstances(subMesh, wireFrame, batch, effect, engine);
            }
            else
            {
                if (batch.renderSelf[subMesh._id])
                {
                    this._draw(subMesh, !wireFrame);
                }
                if (batch.visibleInstances[subMesh._id] != null)
                {
                    for (var instanceIndex = 0; instanceIndex < batch.visibleInstances[subMesh._id].Length; instanceIndex++)
                    {
                        var instance = batch.visibleInstances[subMesh._id][instanceIndex];
                        world = instance.getWorldMatrix();
                        effectiveMaterial.bindOnlyWorldMatrix(world);
                        this._draw(subMesh, !wireFrame);
                    }
                }
            }
            effectiveMaterial.unbind();
        }
        public virtual Array<ParticleSystem> getEmittedParticleSystems()
        {
            var results = new Array<ParticleSystem>();
            for (var index = 0; index < this.getScene().particleSystems.Length; index++)
            {
                var particleSystem = this.getScene().particleSystems[index];
                if (particleSystem.emitter == this)
                {
                    results.push(particleSystem);
                }
            }
            return results;
        }
        public virtual Array<ParticleSystem> getHierarchyEmittedParticleSystems()
        {
            var results = new Array<ParticleSystem>();
            var descendants = this.getDescendants();
            descendants.push(this);
            for (var index = 0; index < this.getScene().particleSystems.Length; index++)
            {
                var particleSystem = this.getScene().particleSystems[index];
                if (descendants.indexOf(particleSystem.emitter as Mesh) != -1)
                {
                    results.push(particleSystem);
                }
            }
            return results;
        }
        public virtual Array<Node> getChildren()
        {
            var results = new Array<Node>();
            for (var index = 0; index < this.getScene().meshes.Length; index++)
            {
                var mesh = this.getScene().meshes[index];
                if (mesh.parent == this)
                {
                    results.push(mesh);
                }
            }
            return results;
        }
        public virtual void _checkDelayState()
        {
            var that = this;
            var scene = this.getScene();
            if (this._geometry != null)
            {
                this._geometry.load(scene);
            }
            else
                if (that.delayLoadState == BABYLON.Engine.DELAYLOADSTATE_NOTLOADED)
                {
                    that.delayLoadState = BABYLON.Engine.DELAYLOADSTATE_LOADING;
                    scene._addPendingData(that);
                    BABYLON.Tools.LoadFile(this.delayLoadingFile, (data) =>
                    {
                        // TODO: finish it
                        this._delayLoadingFunction(data/*JSON.parse(data)*/, this);
                        this.delayLoadState = BABYLON.Engine.DELAYLOADSTATE_LOADED;
                        scene._removePendingData(this);
                    }, (o) => { }, scene.database);
                }
        }
        public virtual bool isInFrustum(Array<Plane> frustumPlanes)
        {
            if (this.delayLoadState == BABYLON.Engine.DELAYLOADSTATE_LOADING)
            {
                return false;
            }
            if (!base.isInFrustum(frustumPlanes))
            {
                return false;
            }
            this._checkDelayState();
            return true;
        }
        public virtual void setMaterialByID(string id)
        {
            var materials = this.getScene().materials;
            for (var index = 0; index < materials.Length; index++)
            {
                if (materials[index].id == id)
                {
                    this.material = materials[index];
                    return;
                }
            }
            var multiMaterials = this.getScene().multiMaterials;
            for (var index = 0; index < multiMaterials.Length; index++)
            {
                if (multiMaterials[index].id == id)
                {
                    this.material = multiMaterials[index];
                    return;
                }
            }
        }
        public virtual Array<IAnimatable> getAnimatables()
        {
            var results = new Array<IAnimatable>();
            if (this.material != null)
            {
                results.push(this.material);
            }
            return results;
        }
        public virtual void bakeTransformIntoVertices(Matrix transform)
        {
            if (!this.isVerticesDataPresent(BABYLON.VertexBufferKind.PositionKind))
            {
                return;
            }
            this._resetPointsArrayCache();
            var data = this.getVerticesData(BABYLON.VertexBufferKind.PositionKind);
            var temp = new Array<double>();
            for (var index = 0; index < data.Length; index += 3)
            {
                BABYLON.Vector3.TransformCoordinates(BABYLON.Vector3.FromArray(data, index), transform).toArray(temp, index);
            }
            this.setVerticesData(BABYLON.VertexBufferKind.PositionKind, temp, this.getVertexBuffer(BABYLON.VertexBufferKind.PositionKind).isUpdatable());
            if (!this.isVerticesDataPresent(BABYLON.VertexBufferKind.NormalKind))
            {
                return;
            }
            data = this.getVerticesData(BABYLON.VertexBufferKind.NormalKind);
            for (var index = 0; index < data.Length; index += 3)
            {
                BABYLON.Vector3.TransformNormal(BABYLON.Vector3.FromArray(data, index), transform).toArray(temp, index);
            }
            this.setVerticesData(BABYLON.VertexBufferKind.NormalKind, temp, this.getVertexBuffer(BABYLON.VertexBufferKind.NormalKind).isUpdatable());
        }
        public virtual void _resetPointsArrayCache()
        {
            this._positions = null;
        }
        public virtual bool _generatePointsArray()
        {
            if (this._positions != null)
                return true;
            this._positions = new Array<Vector3>();
            var data = this.getVerticesData(BABYLON.VertexBufferKind.PositionKind);
            if (data == null)
            {
                return false;
            }
            for (var index = 0; index < data.Length; index += 3)
            {
                this._positions.push(BABYLON.Vector3.FromArray(data, index));
            }
            return true;
        }
        public virtual Mesh clone(string name, Node newParent, bool doNotCloneChildren = false)
        {
            var result = new BABYLON.Mesh(name, this.getScene());
            this._geometry.applyToMesh(result);
            BABYLON.Tools.DeepCopy(this, result, new Array<string>("name", "material", "skeleton"), new Array<string>());
            result.material = this.material;
            if (newParent != null)
            {
                result.parent = newParent;
            }
            if (!doNotCloneChildren)
            {
                for (var index = 0; index < this.getScene().meshes.Length; index++)
                {
                    var mesh = this.getScene().meshes[index];
                    if (mesh.parent == this)
                    {
                        mesh.clone(mesh.name, result);
                    }
                }
            }
            for (var index = 0; index < this.getScene().particleSystems.Length; index++)
            {
                var system = this.getScene().particleSystems[index];
                if (system.emitter == this)
                {
                    system.clone(system.name, result);
                }
            }
            result.computeWorldMatrix(true);
            return result;
        }
        public virtual void dispose(bool doNotRecurse = false)
        {
            if (this._geometry != null)
            {
                this._geometry.releaseForMesh(this, true);
            }
            if (this._worldMatricesInstancesBuffer != null)
            {
                this.getEngine().deleteInstancesBuffer(this._worldMatricesInstancesBuffer);
                this._worldMatricesInstancesBuffer = null;
            }
            while (this.instances.Length > 0)
            {
                this.instances[0].dispose();
            }
            base.dispose(doNotRecurse);
        }
        public virtual void convertToFlatShadedMesh()
        {
            var kinds = this.getVerticesDataKinds();
            var vbs = new Array<VertexBuffer>();
            var data = new Array<Array<double>>();
            var newdata = new Array<Array<double>>();
            var updatableNormals = false;
            for (var kindIndex = 0; kindIndex < kinds.Length; kindIndex++)
            {
                var kind = kinds[kindIndex];
                var vertexBuffer = this.getVertexBuffer(kind);
                if (kind == BABYLON.VertexBufferKind.NormalKind)
                {
                    updatableNormals = vertexBuffer.isUpdatable();
                    kinds.splice(kindIndex, 1);
                    kindIndex--;
                    continue;
                }
                vbs[(int)kind] = vertexBuffer;
                data[(int)kind] = vbs[(int)kind].getData();
                newdata[(int)kind] = new Array<double>();
            }
            var previousSubmeshes = this.subMeshes.slice(0);
            var indices = this.getIndices();
            var totalIndices = this.getTotalIndices();
            for (var index = 0; index < totalIndices; index++)
            {
                var vertexIndex = indices[index];
                for (var kindIndex = 0; kindIndex < kinds.Length; kindIndex++)
                {
                    var kind = kinds[kindIndex];
                    var stride = vbs[(int)kind].getStrideSize();
                    for (var offset = 0; offset < stride; offset++)
                    {
                        newdata[(int)kind].push(data[(int)kind][vertexIndex * stride + offset]);
                    }
                }
            }
            var normals = new Array<double>();
            var positions = newdata[(int)BABYLON.VertexBufferKind.PositionKind];
            for (var index = 0; index < totalIndices; index += 3)
            {
                indices[index] = index;
                indices[index + 1] = index + 1;
                indices[index + 2] = index + 2;
                var p1 = BABYLON.Vector3.FromArray(positions, index * 3);
                var p2 = BABYLON.Vector3.FromArray(positions, (index + 1) * 3);
                var p3 = BABYLON.Vector3.FromArray(positions, (index + 2) * 3);
                var p1p2 = p1.subtract(p2);
                var p3p2 = p3.subtract(p2);
                var normal = BABYLON.Vector3.Normalize(BABYLON.Vector3.Cross(p1p2, p3p2));
                for (var localIndex = 0; localIndex < 3; localIndex++)
                {
                    normals.push(normal.x);
                    normals.push(normal.y);
                    normals.push(normal.z);
                }
            }
            this.setIndices(indices);
            this.setVerticesData(BABYLON.VertexBufferKind.NormalKind, normals, updatableNormals);
            for (var kindIndex = 0; kindIndex < kinds.Length; kindIndex++)
            {
                var kind = kinds[kindIndex];
                this.setVerticesData(kind, newdata[(int)kind], vbs[(int)kind].isUpdatable());
            }
            this.releaseSubMeshes();
            for (var submeshIndex = 0; submeshIndex < previousSubmeshes.Length; submeshIndex++)
            {
                var previousOne = previousSubmeshes[submeshIndex];
                var subMesh = new BABYLON.SubMesh(previousOne.materialIndex, previousOne.indexStart, previousOne.indexCount, previousOne.indexStart, previousOne.indexCount, this);
            }
            this.synchronizeInstances();
        }
        public virtual InstancedMesh createInstance(string name)
        {
            return new InstancedMesh(name, this);
        }
        public virtual void synchronizeInstances()
        {
            for (var instanceIndex = 0; instanceIndex < this.instances.Length; instanceIndex++)
            {
                var instance = this.instances[instanceIndex];
                instance._syncSubMeshes();
            }
        }
        public static Mesh CreateBox(string name, double size, Scene scene, bool updatable = false)
        {
            var box = new BABYLON.Mesh(name, scene);
            var vertexData = BABYLON.VertexData.CreateBox(size);
            vertexData.applyToMesh(box, updatable);
            return box;
        }
        public static Mesh CreateSphere(string name, int segments, double diameter, Scene scene, bool updatable = false)
        {
            var sphere = new BABYLON.Mesh(name, scene);
            var vertexData = BABYLON.VertexData.CreateSphere(segments, diameter);
            vertexData.applyToMesh(sphere, updatable);
            return sphere;
        }
        public static Mesh CreateCylinder(string name, double height, double diameterTop, double diameterBottom, int tessellation, int subdivisions, Scene scene, bool updatable = false)
        {
            var cylinder = new BABYLON.Mesh(name, scene);
            var vertexData = BABYLON.VertexData.CreateCylinder(height, diameterTop, diameterBottom, tessellation, subdivisions);
            vertexData.applyToMesh(cylinder, updatable);
            return cylinder;
        }
        public static Mesh CreateTorus(string name, double diameter, double thickness, int tessellation, Scene scene, bool updatable = false)
        {
            var torus = new BABYLON.Mesh(name, scene);
            var vertexData = BABYLON.VertexData.CreateTorus(diameter, thickness, tessellation);
            vertexData.applyToMesh(torus, updatable);
            return torus;
        }
        public static Mesh CreateTorusKnot(string name, double radius, double tube, int radialSegments, int tubularSegments, double p, double q, Scene scene, bool updatable = false)
        {
            var torusKnot = new BABYLON.Mesh(name, scene);
            var vertexData = BABYLON.VertexData.CreateTorusKnot(radius, tube, radialSegments, tubularSegments, p, q);
            vertexData.applyToMesh(torusKnot, updatable);
            return torusKnot;
        }
        public static LinesMesh CreateLines(string name, Array<Vector3> points, Scene scene, bool updatable = false)
        {
            var lines = new LinesMesh(name, scene, updatable);
            var vertexData = BABYLON.VertexData.CreateLines(points);
            vertexData.applyToMesh(lines, updatable);
            return lines;
        }
        public static Mesh CreatePlane(string name, double size, Scene scene, bool updatable = false)
        {
            var plane = new BABYLON.Mesh(name, scene);
            var vertexData = BABYLON.VertexData.CreatePlane(size);
            vertexData.applyToMesh(plane, updatable);
            return plane;
        }
        public static Mesh CreateGround(string name, double width, double height, int subdivisions, Scene scene, bool updatable = false)
        {
            var ground = new BABYLON.GroundMesh(name, scene);
            ground._setReady(false);
            ground._subdivisions = subdivisions;
            var vertexData = BABYLON.VertexData.CreateGround(width, height, subdivisions);
            vertexData.applyToMesh(ground, updatable);
            ground._setReady(true);
            return ground;
        }
        public static Mesh CreateTiledGround(string name, double xmin, double zmin, double xmax, double zmax, SizeI subdivisions, SizeI precision, Scene scene, bool updatable = false)
        {
            var tiledGround = new BABYLON.Mesh(name, scene);
            var vertexData = BABYLON.VertexData.CreateTiledGround(xmin, zmin, xmax, zmax, subdivisions, precision);
            vertexData.applyToMesh(tiledGround, updatable);
            return tiledGround;
        }
        public static GroundMesh CreateGroundFromHeightMap(string name, string url, double width, double height, int subdivisions, double minHeight, double maxHeight, Scene scene, bool updatable = false)
        {
            var ground = new BABYLON.GroundMesh(name, scene);
            ground._subdivisions = subdivisions;
            ground._setReady(false);
            Action<HTMLImageElement> onload = (img) =>
            {
                var canvas = (HTMLCanvasElement)document.createElement("canvas");
                var context = (CanvasRenderingContext2D)canvas.getContext("2d");
                var heightMapWidth = img.width;
                var heightMapHeight = img.height;
                canvas.width = heightMapWidth;
                canvas.height = heightMapHeight;
                context.drawImage(img, 0, 0);
                var buffer = context.getImageData(0, 0, heightMapWidth, heightMapHeight).data;
                var vertexData = VertexData.CreateGroundFromHeightMap(width, height, subdivisions, minHeight, maxHeight, buffer, heightMapWidth, heightMapHeight);
                vertexData.applyToMesh(ground, updatable);
                ground._setReady(true);
            };
            Tools.LoadImage(url, onload, (img, err) => { }, scene.database);
            return ground;
        }
        public static MinMax MinMax(Array<AbstractMesh> meshes)
        {
            Vector3 minVector = null;
            Vector3 maxVector = null;
            for (var i = 0; i < meshes.Length; i++)
            {
                var mesh = meshes[i];
                var boundingBox = mesh.getBoundingInfo().boundingBox;
                if (minVector == null)
                {
                    minVector = boundingBox.minimumWorld;
                    maxVector = boundingBox.maximumWorld;
                    continue;
                }
                minVector.MinimizeInPlace(boundingBox.minimumWorld);
                maxVector.MaximizeInPlace(boundingBox.maximumWorld);
            }
            return new MinMax { minimum = minVector, maximum = maxVector };
        }
        public static Vector3 Center(MinMax meshesOrMinMaxVector)
        {
            var minMaxVector = meshesOrMinMaxVector;
            return BABYLON.Vector3.Center(minMaxVector.minimum, minMaxVector.maximum);
        }
        public static Vector3 Center(Array<AbstractMesh> meshesOrMinMaxVector)
        {
            var minMaxVector = BABYLON.Mesh.MinMax(meshesOrMinMaxVector);
            return BABYLON.Vector3.Center(minMaxVector.minimum, minMaxVector.maximum);
        }
    }
}