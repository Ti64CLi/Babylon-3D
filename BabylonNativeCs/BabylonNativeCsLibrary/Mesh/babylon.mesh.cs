// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.mesh.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    using System;

    using Web;

    /// <summary>
    /// </summary>
    public partial class _InstancesBatch
    {
        /// <summary>
        /// </summary>
        public bool mustReturn = false;

        /// <summary>
        /// </summary>
        public Array<bool> renderSelf = new Array<bool>();

        /// <summary>
        /// </summary>
        public Array<Array<InstancedMesh>> visibleInstances = new Array<Array<InstancedMesh>>();
    }

    /// <summary>
    /// </summary>
    public partial class Mesh : AbstractMesh, IGetSetVerticesData, IAnimatable
    {
        /// <summary>
        /// </summary>
        public Array<VertexBufferKind> _delayInfo;

        /// <summary>
        /// </summary>
        public Action<JsmnParserValue, Mesh> _delayLoadingFunction;

        /// <summary>
        /// </summary>
        public Geometry _geometry;

        /// <summary>
        /// </summary>
        public bool _shouldGenerateFlatShading;

        /// <summary>
        /// </summary>
        public InstancedMeshes _visibleInstances = null;

        /// <summary>
        /// </summary>
        public int delayLoadState = Engine.DELAYLOADSTATE_NONE;

        /// <summary>
        /// </summary>
        public string delayLoadingFile;

        /// <summary>
        /// </summary>
        public Array<InstancedMesh> instances = new Array<InstancedMesh>();

        /// <summary>
        /// </summary>
        private readonly _InstancesBatch _batchCache = new _InstancesBatch();

        /// <summary>
        /// </summary>
        private int _instancesBufferSize = 32 * 16 * 4;

        /// <summary>
        /// </summary>
        private readonly Array<System.Action> _onBeforeRenderCallbacks = new Array<System.Action>();

        /// <summary>
        /// </summary>
        private readonly Array<int> _renderIdForInstances = new Array<int>();

        /// <summary>
        /// </summary>
        private double[] _worldMatricesInstancesArray;

        /// <summary>
        /// </summary>
        private WebGLBuffer _worldMatricesInstancesBuffer;

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="scene">
        /// </param>
        public Mesh(string name, Scene scene)
            : base(name, scene)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="meshesOrMinMaxVector">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector3 Center(MinMax meshesOrMinMaxVector)
        {
            var minMaxVector = meshesOrMinMaxVector;
            return Vector3.Center(minMaxVector.minimum, minMaxVector.maximum);
        }

        /// <summary>
        /// </summary>
        /// <param name="meshesOrMinMaxVector">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector3 Center(Array<AbstractMesh> meshesOrMinMaxVector)
        {
            var minMaxVector = MinMax(meshesOrMinMaxVector);
            return Vector3.Center(minMaxVector.minimum, minMaxVector.maximum);
        }

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="size">
        /// </param>
        /// <param name="scene">
        /// </param>
        /// <param name="updatable">
        /// </param>
        /// <returns>
        /// </returns>
        public static Mesh CreateBox(string name, double size, Scene scene, bool updatable = false)
        {
            var box = new Mesh(name, scene);
            var vertexData = VertexData.CreateBox(size);
            vertexData.applyToMesh(box, updatable);
            return box;
        }

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="height">
        /// </param>
        /// <param name="diameterTop">
        /// </param>
        /// <param name="diameterBottom">
        /// </param>
        /// <param name="tessellation">
        /// </param>
        /// <param name="subdivisions">
        /// </param>
        /// <param name="scene">
        /// </param>
        /// <param name="updatable">
        /// </param>
        /// <returns>
        /// </returns>
        public static Mesh CreateCylinder(
            string name, double height, double diameterTop, double diameterBottom, int tessellation, int subdivisions, Scene scene, bool updatable = false)
        {
            var cylinder = new Mesh(name, scene);
            var vertexData = VertexData.CreateCylinder(height, diameterTop, diameterBottom, tessellation, subdivisions);
            vertexData.applyToMesh(cylinder, updatable);
            return cylinder;
        }

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="width">
        /// </param>
        /// <param name="height">
        /// </param>
        /// <param name="subdivisions">
        /// </param>
        /// <param name="scene">
        /// </param>
        /// <param name="updatable">
        /// </param>
        /// <returns>
        /// </returns>
        public static Mesh CreateGround(string name, double width, double height, int subdivisions, Scene scene, bool updatable = false)
        {
            var ground = new GroundMesh(name, scene);
            ground._setReady(false);
            ground._subdivisions = subdivisions;
            var vertexData = VertexData.CreateGround(width, height, subdivisions);
            vertexData.applyToMesh(ground, updatable);
            ground._setReady(true);
            return ground;
        }

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="url">
        /// </param>
        /// <param name="width">
        /// </param>
        /// <param name="height">
        /// </param>
        /// <param name="subdivisions">
        /// </param>
        /// <param name="minHeight">
        /// </param>
        /// <param name="maxHeight">
        /// </param>
        /// <param name="scene">
        /// </param>
        /// <param name="updatable">
        /// </param>
        /// <returns>
        /// </returns>
        public static GroundMesh CreateGroundFromHeightMap(
            string name, string url, double width, double height, int subdivisions, double minHeight, double maxHeight, Scene scene, bool updatable = false)
        {
            var ground = new GroundMesh(name, scene);
            ground._subdivisions = subdivisions;
            ground._setReady(false);
            Action<Web.ImageData> onload = (img) =>
                {
                    //var canvas = (HTMLCanvasElement)Engine.document.createElement("canvas");
                    //var context = (CanvasRenderingContext2D)canvas.getContext("2d");
                    var heightMapWidth = img.width;
                    var heightMapHeight = img.height;
                    //canvas.width = heightMapWidth;
                    //canvas.height = heightMapHeight;
                    //context.drawImage(img, 0, 0);
                    //var buffer = context.getImageData(0, 0, heightMapWidth, heightMapHeight).data;
                    var vertexData = VertexData.CreateGroundFromHeightMap(
                        width, height, subdivisions, minHeight, maxHeight, img.dataBytes, heightMapWidth, heightMapHeight);
                    vertexData.applyToMesh(ground, updatable);
                    ground._setReady(true);
                };
            Tools.LoadImage(scene.getEngine()._canvas, url, onload, (img, err) => { }, scene.database);
            return ground;
        }

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="points">
        /// </param>
        /// <param name="scene">
        /// </param>
        /// <param name="updatable">
        /// </param>
        /// <returns>
        /// </returns>
        public static LinesMesh CreateLines(string name, Array<Vector3> points, Scene scene, bool updatable = false)
        {
            var lines = new LinesMesh(name, scene);
            var vertexData = VertexData.CreateLines(points);
            vertexData.applyToMesh(lines, updatable);
            return lines;
        }

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="size">
        /// </param>
        /// <param name="scene">
        /// </param>
        /// <param name="updatable">
        /// </param>
        /// <returns>
        /// </returns>
        public static Mesh CreatePlane(string name, double size, Scene scene, bool updatable = false)
        {
            var plane = new Mesh(name, scene);
            var vertexData = VertexData.CreatePlane(size);
            vertexData.applyToMesh(plane, updatable);
            return plane;
        }

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="segments">
        /// </param>
        /// <param name="diameter">
        /// </param>
        /// <param name="scene">
        /// </param>
        /// <param name="updatable">
        /// </param>
        /// <returns>
        /// </returns>
        public static Mesh CreateSphere(string name, int segments, double diameter, Scene scene, bool updatable = false)
        {
            var sphere = new Mesh(name, scene);
            var vertexData = VertexData.CreateSphere(segments, diameter);
            vertexData.applyToMesh(sphere, updatable);
            return sphere;
        }

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="xmin">
        /// </param>
        /// <param name="zmin">
        /// </param>
        /// <param name="xmax">
        /// </param>
        /// <param name="zmax">
        /// </param>
        /// <param name="subdivisions">
        /// </param>
        /// <param name="precision">
        /// </param>
        /// <param name="scene">
        /// </param>
        /// <param name="updatable">
        /// </param>
        /// <returns>
        /// </returns>
        public static Mesh CreateTiledGround(
            string name, double xmin, double zmin, double xmax, double zmax, SizeI subdivisions, SizeI precision, Scene scene, bool updatable = false)
        {
            var tiledGround = new Mesh(name, scene);
            var vertexData = VertexData.CreateTiledGround(xmin, zmin, xmax, zmax, subdivisions, precision);
            vertexData.applyToMesh(tiledGround, updatable);
            return tiledGround;
        }

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="diameter">
        /// </param>
        /// <param name="thickness">
        /// </param>
        /// <param name="tessellation">
        /// </param>
        /// <param name="scene">
        /// </param>
        /// <param name="updatable">
        /// </param>
        /// <returns>
        /// </returns>
        public static Mesh CreateTorus(string name, double diameter, double thickness, int tessellation, Scene scene, bool updatable = false)
        {
            var torus = new Mesh(name, scene);
            var vertexData = VertexData.CreateTorus(diameter, thickness, tessellation);
            vertexData.applyToMesh(torus, updatable);
            return torus;
        }

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="radius">
        /// </param>
        /// <param name="tube">
        /// </param>
        /// <param name="radialSegments">
        /// </param>
        /// <param name="tubularSegments">
        /// </param>
        /// <param name="p">
        /// </param>
        /// <param name="q">
        /// </param>
        /// <param name="scene">
        /// </param>
        /// <param name="updatable">
        /// </param>
        /// <returns>
        /// </returns>
        public static Mesh CreateTorusKnot(
            string name, double radius, double tube, int radialSegments, int tubularSegments, double p, double q, Scene scene, bool updatable = false)
        {
            var torusKnot = new Mesh(name, scene);
            var vertexData = VertexData.CreateTorusKnot(radius, tube, radialSegments, tubularSegments, p, q);
            vertexData.applyToMesh(torusKnot, updatable);
            return torusKnot;
        }

        /// <summary>
        /// </summary>
        /// <param name="meshes">
        /// </param>
        /// <returns>
        /// </returns>
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

        /// <summary>
        /// </summary>
        /// <param name="subMesh">
        /// </param>
        /// <param name="effect">
        /// </param>
        /// <param name="wireframe">
        /// </param>
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

        /// <summary>
        /// </summary>
        public virtual void _checkDelayState()
        {
            var that = this;
            var scene = this.getScene();
            if (this._geometry != null)
            {
                this._geometry.load(scene);
            }
            else if (that.delayLoadState == Engine.DELAYLOADSTATE_NOTLOADED)
            {
                that.delayLoadState = Engine.DELAYLOADSTATE_LOADING;
                scene._addPendingData(that);
                Tools.LoadFile(
                    this.delayLoadingFile, 
                    (data) =>
                        {
                            // TODO: finish it
                            this._delayLoadingFunction(JsmnParser.Parse(data), this);
                            this.delayLoadState = Engine.DELAYLOADSTATE_LOADED;
                            scene._removePendingData(this);
                        }, 
                    (max, pos) => { }, 
                    scene.database);
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual SubMesh _createGlobalSubMesh()
        {
            var totalVertices = this.getTotalVertices();
            if (totalVertices == 0 || this.getIndices() == null)
            {
                return null;
            }

            this.releaseSubMeshes();
            return new SubMesh(0, 0, totalVertices, 0, this.getTotalIndices(), this);
        }

        /// <summary>
        /// </summary>
        /// <param name="subMesh">
        /// </param>
        /// <param name="useTriangles">
        /// </param>
        /// <param name="instancesCount">
        /// </param>
        public virtual void _draw(SubMesh subMesh, bool useTriangles, int instancesCount = 0)
        {
            if (this._geometry == null || this._geometry.getVertexBuffers() == null || this._geometry.getIndexBuffer() == null)
            {
                return;
            }

            var engine = this.getScene().getEngine();
            engine.draw(useTriangles, useTriangles ? subMesh.indexStart : 0, useTriangles ? subMesh.indexCount : subMesh.linesIndexCount, instancesCount);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override bool _generatePointsArray()
        {
            if (this._positions != null)
            {
                return true;
            }

            this._positions = new Array<Vector3>();
            var data = this.getVerticesData(VertexBufferKind.PositionKind);
            if (data == null)
            {
                return false;
            }

            for (var index = 0; index < data.Length; index += 3)
            {
                this._positions.Add(Vector3.FromArray(data, index));
            }

            return true;
        }

        /// <summary>
        /// </summary>
        /// <param name="subMeshId">
        /// </param>
        /// <returns>
        /// </returns>
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

        /// <summary>
        /// </summary>
        public override void _preActivate()
        {
            this._visibleInstances = null;
        }

        /// <summary>
        /// </summary>
        /// <param name="instance">
        /// </param>
        /// <param name="renderId">
        /// </param>
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

            this._visibleInstances[renderId].Add(instance);
        }

        /// <summary>
        /// </summary>
        /// <param name="subMesh">
        /// </param>
        /// <param name="wireFrame">
        /// </param>
        /// <param name="batch">
        /// </param>
        /// <param name="effect">
        /// </param>
        /// <param name="engine">
        /// </param>
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
                this._worldMatricesInstancesArray = new double[this._instancesBufferSize / 4];
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
            var offsetLocations = new Array<int>(offsetLocation0, offsetLocation1, offsetLocation2, offsetLocation3);
            engine.updateAndBindInstancesBuffer(this._worldMatricesInstancesBuffer, this._worldMatricesInstancesArray, offsetLocations);
            this._draw(subMesh, !wireFrame, instancesCount);
            engine.unBindInstancesBuffer(this._worldMatricesInstancesBuffer, offsetLocations);
        }

        /// <summary>
        /// </summary>
        public virtual void _resetPointsArrayCache()
        {
            this._positions = null;
        }

        /// <summary>
        /// </summary>
        /// <param name="transform">
        /// </param>
        public virtual void bakeTransformIntoVertices(Matrix transform)
        {
            if (!this.isVerticesDataPresent(VertexBufferKind.PositionKind))
            {
                return;
            }

            this._resetPointsArrayCache();
            var data = this.getVerticesData(VertexBufferKind.PositionKind);
            var temp = new Array<double>();
            for (var index = 0; index < data.Length; index += 3)
            {
                Vector3.TransformCoordinates(Vector3.FromArray(data, index), transform).toArray(temp, index);
            }

            this.setVerticesData(VertexBufferKind.PositionKind, temp, this.getVertexBuffer(VertexBufferKind.PositionKind).isUpdatable());
            if (!this.isVerticesDataPresent(VertexBufferKind.NormalKind))
            {
                return;
            }

            data = this.getVerticesData(VertexBufferKind.NormalKind);
            for (var index = 0; index < data.Length; index += 3)
            {
                Vector3.TransformNormal(Vector3.FromArray(data, index), transform).toArray(temp, index);
            }

            this.setVerticesData(VertexBufferKind.NormalKind, temp, this.getVertexBuffer(VertexBufferKind.NormalKind).isUpdatable());
        }

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="newParent">
        /// </param>
        /// <param name="doNotCloneChildren">
        /// </param>
        /// <returns>
        /// </returns>
        public override AbstractMesh clone(string name, Node newParent, bool doNotCloneChildren = false)
        {
            var result = new Mesh(name, this.getScene());
            this._geometry.applyToMesh(result);
            // TODO: finish it
            //Tools.DeepCopy(this, result, new Array<string>("name", "material", "skeleton"), new Array<string>());
            result.material = this.material;
            result.name = name;
            result.skeleton = null;

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

        /// <summary>
        /// </summary>
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
                if (kind == VertexBufferKind.NormalKind)
                {
                    updatableNormals = vertexBuffer.isUpdatable();
                    kinds.RemoveAt(kindIndex);
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
                        newdata[(int)kind].Add(data[(int)kind][vertexIndex * stride + offset]);
                    }
                }
            }

            var normals = new Array<double>();
            var positions = newdata[(int)VertexBufferKind.PositionKind];
            for (var index = 0; index < totalIndices; index += 3)
            {
                indices[index] = index;
                indices[index + 1] = index + 1;
                indices[index + 2] = index + 2;
                var p1 = Vector3.FromArray(positions, index * 3);
                var p2 = Vector3.FromArray(positions, (index + 1) * 3);
                var p3 = Vector3.FromArray(positions, (index + 2) * 3);
                var p1p2 = p1.subtract(p2);
                var p3p2 = p3.subtract(p2);
                var normal = Vector3.Normalize(Vector3.Cross(p1p2, p3p2));
                for (var localIndex = 0; localIndex < 3; localIndex++)
                {
                    normals.Add(normal.x);
                    normals.Add(normal.y);
                    normals.Add(normal.z);
                }
            }

            this.setIndices(indices);
            this.setVerticesData(VertexBufferKind.NormalKind, normals, updatableNormals);
            for (var kindIndex = 0; kindIndex < kinds.Length; kindIndex++)
            {
                var kind = kinds[kindIndex];
                this.setVerticesData(kind, newdata[(int)kind], vbs[(int)kind].isUpdatable());
            }

            this.releaseSubMeshes();
            for (var submeshIndex = 0; submeshIndex < previousSubmeshes.Length; submeshIndex++)
            {
                var previousOne = previousSubmeshes[submeshIndex];
                var subMesh = new SubMesh(
                    previousOne.materialIndex, previousOne.indexStart, previousOne.indexCount, previousOne.indexStart, previousOne.indexCount, this);
            }

            this.synchronizeInstances();
        }

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual InstancedMesh createInstance(string name)
        {
            return new InstancedMesh(name, this);
        }

        /// <summary>
        /// </summary>
        /// <param name="doNotRecurse">
        /// </param>
        public override void dispose(bool doNotRecurse = false)
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

        public Array<Animation> animations
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Array<IAnimatable> getAnimatables()
        {
            var results = new Array<IAnimatable>();
            if (this.material != null)
            {
                results.Add(this.material);
            }

            return results;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Array<Node> getChildren()
        {
            var results = new Array<Node>();
            for (var index = 0; index < this.getScene().meshes.Length; index++)
            {
                var mesh = this.getScene().meshes[index];
                if (mesh.parent == this)
                {
                    results.Add(mesh);
                }
            }

            return results;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Array<ParticleSystem> getEmittedParticleSystems()
        {
            var results = new Array<ParticleSystem>();
            for (var index = 0; index < this.getScene().particleSystems.Length; index++)
            {
                var particleSystem = this.getScene().particleSystems[index];
                if (particleSystem.emitter == this)
                {
                    results.Add(particleSystem);
                }
            }

            return results;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Array<ParticleSystem> getHierarchyEmittedParticleSystems()
        {
            var results = new Array<ParticleSystem>();
            var descendants = this.getDescendants();
            descendants.Add(this);
            for (var index = 0; index < this.getScene().particleSystems.Length; index++)
            {
                var particleSystem = this.getScene().particleSystems[index];
                if (descendants.IndexOf(particleSystem.emitter as Mesh) != -1)
                {
                    results.Add(particleSystem);
                }
            }

            return results;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override Array<int> getIndices()
        {
            if (this._geometry == null)
            {
                return new Array<int>();
            }

            return this._geometry.getIndices();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual int getTotalIndices()
        {
            if (this._geometry == null)
            {
                return 0;
            }

            return this._geometry.getTotalIndices();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override int getTotalVertices()
        {
            if (this._geometry == null)
            {
                return 0;
            }

            return this._geometry.getTotalVertices();
        }

        /// <summary>
        /// </summary>
        /// <param name="kind">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual VertexBuffer getVertexBuffer(VertexBufferKind kind)
        {
            if (this._geometry == null)
            {
                return null;
            }

            return this._geometry.getVertexBuffer(kind);
        }

        /// <summary>
        /// </summary>
        /// <param name="kind">
        /// </param>
        /// <returns>
        /// </returns>
        public override Array<double> getVerticesData(VertexBufferKind kind)
        {
            if (this._geometry == null)
            {
                return null;
            }

            return this._geometry.getVerticesData(kind);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Array<VertexBufferKind> getVerticesDataKinds()
        {
            if (this._geometry == null)
            {
                var result = new Array<VertexBufferKind>();
                if (this._delayInfo != null)
                {
                    foreach (var kind in this._delayInfo)
                    {
                        result.Add(kind);
                    }
                }

                return result;
            }

            return this._geometry.getVerticesDataKinds();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual bool isDisposed()
        {
            return this._isDisposed;
        }

        /// <summary>
        /// </summary>
        /// <param name="frustumPlanes">
        /// </param>
        /// <returns>
        /// </returns>
        public override bool isInFrustum(Array<Plane> frustumPlanes)
        {
            if (this.delayLoadState == Engine.DELAYLOADSTATE_LOADING)
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

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override bool isReady()
        {
            if (this.delayLoadState == Engine.DELAYLOADSTATE_LOADING)
            {
                return false;
            }

            return base.isReady();
        }

        /// <summary>
        /// </summary>
        /// <param name="kind">
        /// </param>
        /// <returns>
        /// </returns>
        public override bool isVerticesDataPresent(VertexBufferKind kind)
        {
            if (this._geometry == null)
            {
                if (this._delayInfo != null)
                {
                    return this._delayInfo.IndexOf(kind) != -1;
                }

                return false;
            }

            return this._geometry.isVerticesDataPresent(kind);
        }

        /// <summary>
        /// </summary>
        public virtual void makeGeometryUnique()
        {
            if (this._geometry == null)
            {
                return;
            }

            var geometry = this._geometry.copy(Geometry.RandomId());
            geometry.applyToMesh(this);
        }

        /// <summary>
        /// </summary>
        public virtual void refreshBoundingInfo()
        {
            var data = this.getVerticesData(VertexBufferKind.PositionKind);
            if (data != null)
            {
                var extend = Tools.ExtractMinAndMax(data, 0, this.getTotalVertices());
                this._boundingInfo = new BoundingInfo(extend.minimum, extend.maximum);
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

        /// <summary>
        /// </summary>
        /// <param name="func">
        /// </param>
        public virtual void registerBeforeRender(System.Action func)
        {
            this._onBeforeRenderCallbacks.Add(func);
        }

        /// <summary>
        /// </summary>
        /// <param name="subMesh">
        /// </param>
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

        /// <summary>
        /// </summary>
        /// <param name="indices">
        /// </param>
        public virtual void setIndices(Array<int> indices)
        {
            if (this._geometry == null)
            {
                var vertexData = new VertexData();
                vertexData.indices = indices;
                var scene = this.getScene();
                new Geometry(Geometry.RandomId(), scene, vertexData, false, this);
            }
            else
            {
                this._geometry.setIndices(indices);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="id">
        /// </param>
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

        /// <summary>
        /// </summary>
        /// <param name="kind">
        /// </param>
        /// <param name="data">
        /// </param>
        /// <param name="updatable">
        /// </param>
        public virtual void setVerticesData(VertexBufferKind kind, Array<double> data, bool updatable = false)
        {
            if (this._geometry == null)
            {
                var vertexData = new VertexData();
                vertexData.set(data, kind);
                var scene = this.getScene();
                new Geometry(Geometry.RandomId(), scene, vertexData, updatable, this);
            }
            else
            {
                this._geometry.setVerticesData(kind, data, updatable);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="count">
        /// </param>
        public virtual void subdivide(int count)
        {
            if (count < 1)
            {
                return;
            }

            var totalIndices = this.getTotalIndices();
            var subdivisionSize = totalIndices / count;
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

                SubMesh.CreateFromIndices(0, offset, Math.Min(subdivisionSize, totalIndices - offset), this);
                offset += subdivisionSize;
            }

            this.synchronizeInstances();
        }

        /// <summary>
        /// </summary>
        public virtual void synchronizeInstances()
        {
            for (var instanceIndex = 0; instanceIndex < this.instances.Length; instanceIndex++)
            {
                var instance = this.instances[instanceIndex];
                instance._syncSubMeshes();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="func">
        /// </param>
        public virtual void unregisterBeforeRender(System.Action func)
        {
            var index = this._onBeforeRenderCallbacks.IndexOf(func);
            if (index > -1)
            {
                this._onBeforeRenderCallbacks.RemoveAt(index);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="kind">
        /// </param>
        /// <param name="data">
        /// </param>
        /// <param name="updateExtends">
        /// </param>
        /// <param name="makeItUnique">
        /// </param>
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

        public override bool Equals(object obj)
        {
            var mesh = obj as Mesh;
            if (mesh != null)
            {
                return mesh.name.Equals(name);
            }

            return base.Equals(obj);
        }

        public IAnimatableProperty this[string subPropertyName]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public object value
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}