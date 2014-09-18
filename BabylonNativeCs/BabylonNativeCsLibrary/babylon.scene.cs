// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.scene.cs" company="">
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
    public partial interface IDisposable
    {
        /// <summary>
        /// </summary>
        /// <param name="doNotRecurse">
        /// </param> 
        void dispose(bool doNotRecurse = false);
    }

    /// <summary>
    /// </summary>
    public partial class Scene
    {
        /// <summary>
        /// </summary>
        public static double MaxDeltaTime = 1000.0;

        /// <summary>
        /// </summary>
        public static double MinDeltaTime = 1.0;

        /// <summary>
        /// </summary>
        public Array<ActionManager> _actionManagers = new Array<ActionManager>();

        /// <summary>
        /// </summary>
        public Array<Animatable> _activeAnimatables = new Array<Animatable>();

        /// <summary>
        /// </summary>
        public SmartArray<ParticleSystem> _activeParticleSystems = new SmartArray<ParticleSystem>(256);

        /// <summary>
        /// </summary>
        public int _activeParticles = 0;

        /// <summary>
        /// </summary>
        public int _activeVertices = 0;

        /// <summary>
        /// </summary>
        public double _particlesDuration = 0;

        /// <summary>
        /// </summary>
        public double _spritesDuration = 0;

        /// <summary>
        /// </summary>
        public SmartArray<IDisposable> _toBeDisposed = new SmartArray<IDisposable>(256);

        /// <summary>
        /// </summary>
        public ActionManager actionManager;

        /// <summary>
        /// </summary>
        public Camera activeCamera;

        /// <summary>
        /// </summary>
        public Array<Camera> activeCameras = new Array<Camera>();

        /// <summary>
        /// </summary>
        public Action<Camera> afterCameraRender;

        /// <summary>
        /// </summary>
        public System.Action afterRender;

        /// <summary>
        /// </summary>
        public Color3 ambientColor = new Color3(0, 0, 0);

        /// <summary>
        /// </summary>
        public bool autoClear = true;

        /// <summary>
        /// </summary>
        public Action<Camera> beforeCameraRender;

        /// <summary>
        /// </summary>
        public System.Action beforeRender;

        /// <summary>
        /// </summary>
        public Camera cameraToUseForPointers = null;

        /// <summary>
        /// </summary>
        public Array<Camera> cameras = new Array<Camera>();

        /// <summary>
        /// </summary>
        public Color3 clearColor = new Color3(0.2, 0.2, 0.3);

        /// <summary>
        /// </summary>
        public Plane clipPlane;

        /// <summary>
        /// </summary>
        public bool collisionsEnabled = true;

        /// <summary>
        /// </summary>
        public Array<RenderTargetTexture> customRenderTargets = new Array<RenderTargetTexture>();

        /// <summary>
        /// </summary>
        public object database;

        /// <summary>
        /// </summary>
        public StandardMaterial defaultMaterial; // = new BABYLON.StandardMaterial("default material", this);

        /// <summary>
        /// </summary>
        public Color3 fogColor = new Color3(0.2, 0.2, 0.3);

        /// <summary>
        /// </summary>
        public double fogDensity = 0.1;

        /// <summary>
        /// </summary>
        public double fogEnd = 1000.0;

        /// <summary>
        /// </summary>
        public double fogMode = FOGMODE_NONE;

        /// <summary>
        /// </summary>
        public double fogStart = 0;

        /// <summary>
        /// </summary>
        public bool forceWireframe = false;

        /// <summary>
        /// </summary>
        public Vector3 gravity = new Vector3(0, -9.0, 0);

        /// <summary>
        /// </summary>
        public Array<string> importedMeshesFiles = new Array<string>();

        /// <summary>
        /// </summary>
        public Array<Layer> layers = new Array<Layer>();

        /// <summary>
        /// </summary>
        public Array<LensFlareSystem> lensFlareSystems = new Array<LensFlareSystem>();

        /// <summary>
        /// </summary>
        public Array<Light> lights = new Array<Light>();

        /// <summary>
        /// </summary>
        public bool lightsEnabled = true;

        /// <summary>
        /// </summary>
        public Array<Material> materials = new Array<Material>();

        /// <summary>
        /// </summary>
        public Array<AbstractMesh> meshes = new Array<AbstractMesh>();

        /// <summary>
        /// </summary>
        public Array<MultiMaterial> multiMaterials = new Array<MultiMaterial>();

        /// <summary>
        /// </summary>
        public System.Action onDispose;

        /// <summary>
        /// </summary>
        public Action<PointerEvent, PickingInfo> onPointerDown;

        /// <summary>
        /// </summary>
        public Array<ParticleSystem> particleSystems = new Array<ParticleSystem>();

        /// <summary>
        /// </summary>
        public bool particlesEnabled = true;

        /// <summary>
        /// </summary>
        public PostProcessManager postProcessManager;

        /// <summary>
        /// </summary>
        public PostProcessRenderPipelineManager postProcessRenderPipelineManager;

        /// <summary>
        /// </summary>
        public bool postProcessesEnabled = true;

        /// <summary>
        /// </summary>
        public bool renderTargetsEnabled = true;

        /// <summary>
        /// </summary>
        public Array<Skeleton> skeletons = new Array<Skeleton>();

        /// <summary>
        /// </summary>
        public Array<SpriteManager> spriteManagers = new Array<SpriteManager>();

        /// <summary>
        /// </summary>
        public Array<BaseTexture> textures = new Array<BaseTexture>();

        /// <summary>
        /// </summary>
        public bool texturesEnabled = true;

        /// <summary>
        /// </summary>
        public bool useDelayedTextureLoading;

        /// <summary>
        /// </summary>
        private readonly SmartArray<AbstractMesh> _activeMeshes = new SmartArray<AbstractMesh>(256);

        /// <summary>
        /// </summary>
        private readonly SmartArray<Skeleton> _activeSkeletons = new SmartArray<Skeleton>(32);

        /// <summary>
        /// </summary>
        private double _animationRatio;

        /// <summary>
        /// </summary>
        private int? _animationStartDate;

        /// <summary>
        /// </summary>
        private readonly BoundingBoxRenderer _boundingBoxRenderer;

        /// <summary>
        /// </summary>
        private readonly Engine _engine;

        /// <summary>
        /// </summary>
        private double _evaluateActiveMeshesDuration;

        /// <summary>
        /// </summary>
        private int _executeWhenReadyTimeoutId = -1;

        /// <summary>
        /// </summary>
        private Array<Plane> _frustumPlanes;

        /// <summary>
        /// </summary>
        private readonly Array<Geometry> _geometries = new Array<Geometry>();

        /// <summary>
        /// </summary>
        private double _lastFrameDuration;

        /// <summary>
        /// </summary>
        private AbstractMesh _meshUnderPointer;

        /// <summary>
        /// </summary>
        private readonly SmartArray<AbstractMesh> _meshesForIntersections = new SmartArray<AbstractMesh>(256);

        /// <summary>
        /// </summary>
        private readonly Array<System.Action> _onBeforeRenderCallbacks = new Array<System.Action>();

        /// <summary>
        /// </summary>
        private EventListener _onPointerDown;

        /// <summary>
        /// </summary>
        private EventListener _onPointerMove;

        /// <summary>
        /// </summary>
        private Array<System.Action> _onReadyCallbacks = new Array<System.Action>();

        /// <summary>
        /// </summary>
        private readonly Array<object> _pendingData = new Array<object>();

        /// <summary>
        /// </summary>
        private PhysicsEngine _physicsEngine;

        /// <summary>
        /// </summary>
        private Matrix _pickWithRayInverseMatrix;

        /// <summary>
        /// </summary>
        private AbstractMesh _pointerOverMesh;

        /// <summary>
        /// </summary>
        private double _pointerX;

        /// <summary>
        /// </summary>
        private double _pointerY;

        /// <summary>
        /// </summary>
        private readonly SmartArray<Material> _processedMaterials = new SmartArray<Material>(256);

        /// <summary>
        /// </summary>
        private Matrix _projectionMatrix;

        /// <summary>
        /// </summary>
        private double _renderDuration;

        /// <summary>
        /// </summary>
        private int _renderId;

        /// <summary>
        /// </summary>
        private readonly SmartArray<RenderTargetTexture> _renderTargets = new SmartArray<RenderTargetTexture>(256);

        /// <summary>
        /// </summary>
        private double _renderTargetsDuration;

        /// <summary>
        /// </summary>
        private readonly RenderingManager _renderingManager;

        /// <summary>
        /// </summary>
        private readonly Vector3 _scaledPosition = Vector3.Zero();

        /// <summary>
        /// </summary>
        private readonly Vector3 _scaledVelocity = Vector3.Zero();

        /// <summary>
        /// </summary>
        private Octree<AbstractMesh> _selectionOctree;

        /// <summary>
        /// </summary>
        private int _totalVertices;

        /// <summary>
        /// </summary>
        private readonly Matrix _transformMatrix = Matrix.Zero();

        /// <summary>
        /// </summary>
        private Matrix _viewMatrix;

        /// <summary>
        /// </summary>
        /// <param name="engine">
        /// </param>
        public Scene(Engine engine)
        {
            this.defaultMaterial = new StandardMaterial("default material", this);

            this._engine = engine;
            engine.scenes.Add(this);
            this._renderingManager = new RenderingManager(this);
            this.postProcessManager = new PostProcessManager(this);
            this.postProcessRenderPipelineManager = new PostProcessRenderPipelineManager();
            this._boundingBoxRenderer = new BoundingBoxRenderer(this);
            this.attachControl();
        }

        /// <summary>
        /// </summary>
        public virtual AbstractMesh meshUnderPointer
        {
            get
            {
                return this._meshUnderPointer;
            }
        }

        /// <summary>
        /// </summary>
        public virtual double pointerX
        {
            get
            {
                return this._pointerX;
            }
        }

        /// <summary>
        /// </summary>
        public virtual double pointerY
        {
            get
            {
                return this._pointerY;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="data">
        /// </param>
        public virtual void _addPendingData(object data)
        {
            this._pendingData.Add(data);
        }

        /// <summary>
        /// </summary>
        public virtual void _checkIsReady()
        {
            if (this.isReady())
            {
                foreach (var func in this._onReadyCallbacks)
                {
                    func();
                }

                ;

                this._onReadyCallbacks = new Array<System.Action>();
                this._executeWhenReadyTimeoutId = -1;
                return;
            }

            ////this._executeWhenReadyTimeoutId = setTimeout(() =>
            ////{
            ////    this._checkIsReady();
            ////}, 150);
            this._checkIsReady();
        }

        /// <summary>
        /// </summary>
        /// <param name="position">
        /// </param>
        /// <param name="velocity">
        /// </param>
        /// <param name="collider">
        /// </param>
        /// <param name="maximumRetry">
        /// </param>
        /// <param name="finalPosition">
        /// </param>
        /// <param name="excludedMesh">
        /// </param>
        public virtual void _getNewPosition(
            Vector3 position, Vector3 velocity, Collider collider, double maximumRetry, Vector3 finalPosition, AbstractMesh excludedMesh = null)
        {
            position.divideToRef(collider.radius, this._scaledPosition);
            velocity.divideToRef(collider.radius, this._scaledVelocity);
            collider.retry = 0;
            collider.initialVelocity = this._scaledVelocity;
            collider.initialPosition = this._scaledPosition;
            this._collideWithWorld(this._scaledPosition, this._scaledVelocity, collider, maximumRetry, finalPosition, excludedMesh);
            finalPosition.multiplyInPlace(collider.radius);
        }

        /// <summary>
        /// </summary>
        /// <param name="data">
        /// </param>
        public virtual void _removePendingData(object data)
        {
            var index = this._pendingData.IndexOf(data);
            if (index != -1)
            {
                this._pendingData.RemoveAt(index);
            }
        }

        /// <summary>
        /// </summary>
        public virtual void attachControl()
        {
            this._onPointerMove = (Event evt) =>
                {
                    var canvas = this._engine.getRenderingCanvas();
                    this._updatePointerPosition((PointerEvent)evt);
                    var pickResult = this.pick(
                        this._pointerX, 
                        this._pointerY, 
                        (AbstractMesh mesh) =>
                        mesh.isPickable && mesh.isVisible && mesh.isReady() && mesh.actionManager != null && mesh.actionManager.hasPointerTriggers, 
                        false, 
                        this.cameraToUseForPointers);
                    if (pickResult.hit)
                    {
                        this.setPointerOverMesh(pickResult.pickedMesh);
                        canvas.style.cursor = "pointer";
                        this._meshUnderPointer = pickResult.pickedMesh;
                    }
                    else
                    {
                        this.setPointerOverMesh(null);
                        canvas.style.cursor = string.Empty;
                        this._meshUnderPointer = null;
                    }
                };
            this._onPointerDown = (Event evt) =>
                {
                    Func<AbstractMesh, bool> predicate = null;
                    if (this.onPointerDown == null)
                    {
                        predicate =
                            (AbstractMesh mesh) =>
                                {
                                    return mesh.isPickable && mesh.isVisible && mesh.isReady() && mesh.actionManager != null
                                           && mesh.actionManager.hasPickTriggers;
                                };
                    }

                    this._updatePointerPosition((PointerEvent)evt);
                    var pickResult = this.pick(this._pointerX, this._pointerY, predicate, false, this.cameraToUseForPointers);
                    if (pickResult.hit)
                    {
                        if (pickResult.pickedMesh.actionManager != null)
                        {
                            switch (((PointerEvent)evt).button)
                            {
                                case 0:
                                    pickResult.pickedMesh.actionManager.processTrigger(
                                        ActionManager.OnLeftPickTrigger, ActionEvent.CreateNew(pickResult.pickedMesh));
                                    break;
                                case 1:
                                    pickResult.pickedMesh.actionManager.processTrigger(
                                        ActionManager.OnCenterPickTrigger, ActionEvent.CreateNew(pickResult.pickedMesh));
                                    break;
                                case 2:
                                    pickResult.pickedMesh.actionManager.processTrigger(
                                        ActionManager.OnRightPickTrigger, ActionEvent.CreateNew(pickResult.pickedMesh));
                                    break;
                            }

                            pickResult.pickedMesh.actionManager.processTrigger(ActionManager.OnPickTrigger, ActionEvent.CreateNew(pickResult.pickedMesh));
                        }
                    }

                    if (this.onPointerDown != null)
                    {
                        this.onPointerDown((PointerEvent)evt, pickResult);
                    }
                };
            var eventPrefix = Tools.GetPointerPrefix();
            this._engine.getRenderingCanvas().addEventListener(eventPrefix + "move", this._onPointerMove, false);
            this._engine.getRenderingCanvas().addEventListener(eventPrefix + "down", this._onPointerDown, false);
        }

        /// <summary>
        /// </summary>
        /// <param name="target">
        /// </param>
        /// <param name="from">
        /// </param>
        /// <param name="to">
        /// </param>
        /// <param name="loop">
        /// </param>
        /// <param name="speedRatio">
        /// </param>
        /// <param name="onAnimationEnd">
        /// </param>
        /// <param name="animatable">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Animatable beginAnimation(
            IAnimatable target, int from, int to, bool loop = false, double speedRatio = 1.0, System.Action onAnimationEnd = null, Animatable animatable = null)
        {
            this.stopAnimation(target);
            if (animatable == null)
            {
                animatable = new Animatable(this, target, from, to, loop, speedRatio, onAnimationEnd);
            }

            if (target.animations != null)
            {
                animatable.appendAnimations(target, target.animations);
            }

            if (target.getAnimatables() != null)
            {
                var animatables = target.getAnimatables();
                for (var index = 0; index < animatables.Length; index++)
                {
                    this.beginAnimation(animatables[index], from, to, loop, speedRatio, onAnimationEnd, animatable);
                }
            }

            return animatable;
        }

        /// <summary>
        /// </summary>
        /// <param name="target">
        /// </param>
        /// <param name="animations">
        /// </param>
        /// <param name="from">
        /// </param>
        /// <param name="to">
        /// </param>
        /// <param name="loop">
        /// </param>
        /// <param name="speedRatio">
        /// </param>
        /// <param name="onAnimationEnd">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Animatable beginDirectAnimation(
            IAnimatable target, Array<Animation> animations, int from, int to, bool loop = false, double speedRatio = 1.0, System.Action onAnimationEnd = null)
        {
            var animatable = new Animatable(this, target, from, to, loop, speedRatio, onAnimationEnd, animations);
            return animatable;
        }

        /// <summary>
        /// </summary>
        /// <param name="parts">
        /// </param>
        /// <param name="options">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual PhysicsCompound createCompoundImpostor(Array<PhysicsCompoundBodyPart> parts, PhysicsBodyCreationOptions options)
        {
            if (this._physicsEngine == null)
            {
                return null;
            }

            for (var index = 0; index < parts.Length; index++)
            {
                var mesh = parts[index].mesh;
                mesh._physicImpostor = parts[index].impostor;
                mesh._physicsMass = options.mass / parts.Length;
                mesh._physicsFriction = options.friction;
                mesh._physicRestitution = options.restitution;
            }

            return this._physicsEngine._registerMeshesAsCompound(parts, options);
        }

        /// <summary>
        /// </summary>
        /// <param name="maxCapacity">
        /// </param>
        /// <param name="maxDepth">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Octree<AbstractMesh> createOrUpdateSelectionOctree(int maxCapacity = 64, int maxDepth = 2)
        {
            if (this._selectionOctree == null)
            {
                this._selectionOctree = new Octree<AbstractMesh>(Octree<AbstractMesh>.CreationFuncForMeshes, maxCapacity, maxDepth);
            }

            var min = new Vector3(double.MaxValue, double.MaxValue, double.MaxValue);
            var Max = new Vector3(-double.MaxValue, -double.MaxValue, -double.MaxValue);
            for (var index = 0; index < this.meshes.Length; index++)
            {
                var mesh = this.meshes[index];
                mesh.computeWorldMatrix(true);
                var minBox = mesh.getBoundingInfo().boundingBox.minimumWorld;
                var maxBox = mesh.getBoundingInfo().boundingBox.maximumWorld;
                Tools.CheckExtends(minBox, min, Max);
                Tools.CheckExtends(maxBox, min, Max);
            }

            this._selectionOctree.update(min, Max, this.meshes);
            return this._selectionOctree;
        }

        /// <summary>
        /// </summary>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        /// <param name="world">
        /// </param>
        /// <param name="camera">
        /// </param>
        /// <returns>
        /// </returns>
        /// <exception cref="Error">
        /// </exception>
        public virtual Ray createPickingRay(double x, double y, Matrix world, Camera camera)
        {
            var engine = this._engine;
            if (camera == null)
            {
                if (this.activeCamera == null)
                {
                    throw new Error("Active camera not set");
                }

                camera = this.activeCamera;
            }

            var cameraViewport = camera.viewport;
            var viewport = cameraViewport.toGlobal(engine);
            x = x / this._engine.getHardwareScalingLevel() - viewport.x;
            y = y / this._engine.getHardwareScalingLevel() - (this._engine.getRenderHeight() - viewport.y - viewport.height);
            return Ray.CreateNew(
                x, y, viewport.width, viewport.height, (world != null) ? world : Matrix.Identity(), camera.getViewMatrix(), camera.getProjectionMatrix());
        }

        /// <summary>
        /// </summary>
        /// <param name="compound">
        /// </param>
        public virtual void deleteCompoundImpostor(PhysicsCompound compound)
        {
            for (var index = 0; index < compound.parts.Length; index++)
            {
                var mesh = compound.parts[index].mesh;
                mesh._physicImpostor = PhysicsEngine.NoImpostor;
                this._physicsEngine._unregisterMesh(mesh);
            }
        }

        /// <summary>
        /// </summary>
        public virtual void detachControl()
        {
            var eventPrefix = Tools.GetPointerPrefix();
            this._engine.getRenderingCanvas().removeEventListener(eventPrefix + "move", this._onPointerMove);
            this._engine.getRenderingCanvas().removeEventListener(eventPrefix + "down", this._onPointerDown);
        }

        /// <summary>
        /// </summary>
        public virtual void disablePhysicsEngine()
        {
            if (this._physicsEngine == null)
            {
                return;
            }

            this._physicsEngine.dispose();
            this._physicsEngine = null;
        }

        /// <summary>
        /// </summary>
        public virtual void dispose()
        {
            this.beforeRender = null;
            this.afterRender = null;
            this.skeletons = new Array<Skeleton>();
            this._boundingBoxRenderer.dispose();
            if (this.onDispose != null)
            {
                this.onDispose();
            }

            this.detachControl();
            var canvas = this._engine.getRenderingCanvas();
            for (var index = 0; index < this.cameras.Length; index++)
            {
                this.cameras[index].detachControl(canvas);
            }

            while (this.lights.Length > 0)
            {
                this.lights[0].dispose();
            }

            while (this.meshes.Length > 0)
            {
                this.meshes[0].dispose(true);
            }

            while (this.cameras.Length > 0)
            {
                this.cameras[0].dispose();
            }

            while (this.materials.Length > 0)
            {
                this.materials[0].dispose();
            }

            while (this.particleSystems.Length > 0)
            {
                this.particleSystems[0].dispose();
            }

            while (this.spriteManagers.Length > 0)
            {
                this.spriteManagers[0].dispose();
            }

            while (this.layers.Length > 0)
            {
                this.layers[0].dispose();
            }

            while (this.textures.Length > 0)
            {
                this.textures[0].dispose();
            }

            this.postProcessManager.dispose();
            if (this._physicsEngine != null)
            {
                this.disablePhysicsEngine();
            }

            var _index = this._engine.scenes.IndexOf(this);
            this._engine.scenes.RemoveAt(_index);
            this._engine.wipeCaches();
        }

        /// <summary>
        /// </summary>
        /// <param name="gravity">
        /// </param>
        /// <param name="plugin">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool enablePhysics(Vector3 gravity, IPhysicsEnginePlugin plugin = null)
        {
            if (this._physicsEngine != null)
            {
                return true;
            }

            this._physicsEngine = new PhysicsEngine(plugin);
            if (!this._physicsEngine.isSupported())
            {
                this._physicsEngine = null;
                return false;
            }

            this._physicsEngine._initialize(gravity);
            return true;
        }

        /// <summary>
        /// </summary>
        /// <param name="func">
        /// </param>
        public virtual void executeWhenReady(System.Action func)
        {
            this._onReadyCallbacks.Add(func);
            if (this._executeWhenReadyTimeoutId != -1)
            {
                return;
            }

            ////this._executeWhenReadyTimeoutId = window.setTimeout((time) =>
            ////{
            ////    this._checkIsReady();
            ////}, 150);
            this._checkIsReady();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual SmartArray<AbstractMesh> getActiveMeshes()
        {
            return this._activeMeshes;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual double getActiveParticles()
        {
            return this._activeParticles;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual double getActiveVertices()
        {
            return this._activeVertices;
        }

        /// <summary>
        /// </summary>
        /// <param name="target">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Animatable getAnimatableByTarget(object target)
        {
            for (var index = 0; index < this._activeAnimatables.Length; index++)
            {
                if (this._activeAnimatables[index].target == target)
                {
                    return this._activeAnimatables[index];
                }
            }

            return null;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual double getAnimationRatio()
        {
            return this._animationRatio;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual BoundingBoxRenderer getBoundingBoxRenderer()
        {
            return this._boundingBoxRenderer;
        }

        /// <summary>
        /// </summary>
        /// <param name="id">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Camera getCameraByID(string id)
        {
            for (var index = 0; index < this.cameras.Length; index++)
            {
                if (this.cameras[index].id == id)
                {
                    return this.cameras[index];
                }
            }

            return null;
        }

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Camera getCameraByName(string name)
        {
            for (var index = 0; index < this.cameras.Length; index++)
            {
                if (this.cameras[index].name == name)
                {
                    return this.cameras[index];
                }
            }

            return null;
        }

        /// <summary>
        /// </summary>
        /// <param name="tagsQuery">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Array<Camera> getCamerasByTags(string tagsQuery)
        {
            return this._getByTags(this.cameras, tagsQuery);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Engine getEngine()
        {
            return this._engine;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual double getEvaluateActiveMeshesDuration()
        {
            return this._evaluateActiveMeshesDuration;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Array<Geometry> getGeometries()
        {
            return this._geometries;
        }

        /// <summary>
        /// </summary>
        /// <param name="id">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Geometry getGeometryByID(int id)
        {
            for (var index = 0; index < this._geometries.Length; index++)
            {
                if (this._geometries[index].id == id)
                {
                    return this._geometries[index];
                }
            }

            return null;
        }

        /// <summary>
        /// </summary>
        /// <param name="id">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Node getLastEntryByID(string id)
        {
            for (var index = this.meshes.Length - 1; index >= 0; index--)
            {
                if (this.meshes[index].id == id)
                {
                    return this.meshes[index];
                }
            }

            for (var index = this.cameras.Length - 1; index >= 0; index--)
            {
                if (this.cameras[index].id == id)
                {
                    return this.cameras[index];
                }
            }

            for (var index = this.lights.Length - 1; index >= 0; index--)
            {
                if (this.lights[index].id == id)
                {
                    return this.lights[index];
                }
            }

            return null;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual double getLastFrameDuration()
        {
            return this._lastFrameDuration;
        }

        /// <summary>
        /// </summary>
        /// <param name="id">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual AbstractMesh getLastMeshByID(string id)
        {
            for (var index = this.meshes.Length - 1; index >= 0; index--)
            {
                if (this.meshes[index].id == id)
                {
                    return this.meshes[index];
                }
            }

            return null;
        }

        /// <summary>
        /// </summary>
        /// <param name="id">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Skeleton getLastSkeletonByID(string id)
        {
            for (var index = this.skeletons.Length - 1; index >= 0; index--)
            {
                if (this.skeletons[index].id == id)
                {
                    return this.skeletons[index];
                }
            }

            return null;
        }

        /// <summary>
        /// </summary>
        /// <param name="id">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Light getLightByID(string id)
        {
            for (var index = 0; index < this.lights.Length; index++)
            {
                if (this.lights[index].id == id)
                {
                    return this.lights[index];
                }
            }

            return null;
        }

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Light getLightByName(string name)
        {
            for (var index = 0; index < this.lights.Length; index++)
            {
                if (this.lights[index].name == name)
                {
                    return this.lights[index];
                }
            }

            return null;
        }

        /// <summary>
        /// </summary>
        /// <param name="tagsQuery">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Array<Light> getLightsByTags(string tagsQuery)
        {
            return this._getByTags(this.lights, tagsQuery);
        }

        /// <summary>
        /// </summary>
        /// <param name="id">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Material getMaterialByID(string id)
        {
            for (var index = 0; index < this.materials.Length; index++)
            {
                if (this.materials[index].id == id)
                {
                    return this.materials[index];
                }
            }

            return null;
        }

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Material getMaterialByName(string name)
        {
            for (var index = 0; index < this.materials.Length; index++)
            {
                if (this.materials[index].name == name)
                {
                    return this.materials[index];
                }
            }

            return null;
        }

        /// <summary>
        /// </summary>
        /// <param name="tagsQuery">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Array<Material> getMaterialByTags(string tagsQuery)
        {
            // TODO: finish it
            return this._getByTags(this.materials, tagsQuery); // .concat(this._getByTags(this.multiMaterials, tagsQuery));
        }

        /// <summary>
        /// </summary>
        /// <param name="id">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual AbstractMesh getMeshByID(string id)
        {
            for (var index = 0; index < this.meshes.Length; index++)
            {
                if (this.meshes[index].id == id)
                {
                    return this.meshes[index];
                }
            }

            return null;
        }

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual AbstractMesh getMeshByName(string name)
        {
            for (var index = 0; index < this.meshes.Length; index++)
            {
                if (this.meshes[index].name == name)
                {
                    return this.meshes[index];
                }
            }

            return null;
        }

        /// <summary>
        /// </summary>
        /// <param name="tagsQuery">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Array<AbstractMesh> getMeshesByTags(string tagsQuery)
        {
            return this._getByTags(this.meshes, tagsQuery);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual double getParticlesDuration()
        {
            return this._particlesDuration;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual PhysicsEngine getPhysicsEngine()
        {
            return this._physicsEngine;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual AbstractMesh getPointerOverMesh()
        {
            return this._pointerOverMesh;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Matrix getProjectionMatrix()
        {
            return this._projectionMatrix;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual double getRenderDuration()
        {
            return this._renderDuration;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual int getRenderId()
        {
            return this._renderId;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual double getRenderTargetsDuration()
        {
            return this._renderTargetsDuration;
        }

        /// <summary>
        /// </summary>
        /// <param name="id">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Skeleton getSkeletonById(string id)
        {
            for (var index = 0; index < this.skeletons.Length; index++)
            {
                if (this.skeletons[index].id == id)
                {
                    return this.skeletons[index];
                }
            }

            return null;
        }

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Skeleton getSkeletonByName(string name)
        {
            for (var index = 0; index < this.skeletons.Length; index++)
            {
                if (this.skeletons[index].name == name)
                {
                    return this.skeletons[index];
                }
            }

            return null;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual double getSpritesDuration()
        {
            return this._spritesDuration;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual double getTotalVertices()
        {
            return this._totalVertices;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Matrix getTransformMatrix()
        {
            return this._transformMatrix;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Matrix getViewMatrix()
        {
            return this._viewMatrix;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual double getWaitingItemsCount()
        {
            return this._pendingData.Length;
        }

        /// <summary>
        /// </summary>
        /// <param name="mesh">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool isActiveMesh(Mesh mesh)
        {
            return this._activeMeshes.IndexOf(mesh) != -1;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual bool isPhysicsEnabled()
        {
            return this._physicsEngine != null;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual bool isReady()
        {
            if (this._pendingData.Length > 0)
            {
                return false;
            }

            for (var index = 0; index < this._geometries.Length; index++)
            {
                var geometry = this._geometries[index];
                if (geometry.delayLoadState == Engine.DELAYLOADSTATE_LOADING)
                {
                    return false;
                }
            }

            for (var index = 0; index < this.meshes.Length; index++)
            {
                var mesh = this.meshes[index];
                if (!mesh.isReady())
                {
                    return false;
                }

                var mat = mesh.material;
                if (mat != null)
                {
                    if (!mat.isReady(mesh))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// </summary>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        /// <param name="predicate">
        /// </param>
        /// <param name="fastCheck">
        /// </param>
        /// <param name="camera">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual PickingInfo pick(double x, double y, Func<AbstractMesh, bool> predicate = null, bool fastCheck = false, Camera camera = null)
        {
            return this._internalPick((world) => this.createPickingRay(x, y, world, camera), predicate, fastCheck);
        }

        /// <summary>
        /// </summary>
        /// <param name="ray">
        /// </param>
        /// <param name="predicate">
        /// </param>
        /// <param name="fastCheck">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual PickingInfo pickWithRay(Ray ray, Func<AbstractMesh, bool> predicate, bool fastCheck = false)
        {
            return this._internalPick(
                (world) =>
                    {
                        if (this._pickWithRayInverseMatrix == null)
                        {
                            this._pickWithRayInverseMatrix = Matrix.Identity();
                        }

                        world.invertToRef(this._pickWithRayInverseMatrix);
                        return Ray.Transform(ray, this._pickWithRayInverseMatrix);
                    }, 
                predicate, 
                fastCheck);
        }

        /// <summary>
        /// </summary>
        /// <param name="geometry">
        /// </param>
        /// <param name="force">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool pushGeometry(Geometry geometry, bool force = false)
        {
            if (!force && this.getGeometryByID(geometry.id) != null)
            {
                return false;
            }

            this._geometries.Add(geometry);
            return true;
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
        public virtual void render()
        {
            var startDate = new Date().getTime();
            this._particlesDuration = 0;
            this._spritesDuration = 0;
            this._activeParticles = 0;
            this._renderDuration = 0;
            this._evaluateActiveMeshesDuration = 0;
            this._totalVertices = 0;
            this._activeVertices = 0;
            this._meshesForIntersections.reset();
            if (this.actionManager != null)
            {
                this.actionManager.processTrigger(ActionManager.OnEveryFrameTrigger, null);
            }

            if (this.beforeRender != null)
            {
                this.beforeRender();
            }

            for (var callbackIndex = 0; callbackIndex < this._onBeforeRenderCallbacks.Length; callbackIndex++)
            {
                this._onBeforeRenderCallbacks[callbackIndex]();
            }

            var deltaTime = Math.Max(MinDeltaTime, Math.Min(Tools.GetDeltaTime(), MaxDeltaTime));
            this._animationRatio = deltaTime * (60.0 / 1000.0);
            this._animate();
            if (this._physicsEngine != null)
            {
                this._physicsEngine._runOneStep(deltaTime / 1000.0);
            }

            this._engine.clear(this.clearColor, this.autoClear || this.forceWireframe, true);
            for (var lightIndex = 0; lightIndex < this.lights.Length; lightIndex++)
            {
                var light = this.lights[lightIndex];
                var shadowGenerator = light.getShadowGenerator();
                if (light.isEnabled() && shadowGenerator != null
                    && shadowGenerator.getShadowMap().getScene().textures.IndexOf(shadowGenerator.getShadowMap()) != -1)
                {
                    this._renderTargets.Add(shadowGenerator.getShadowMap());
                }
            }

            this.postProcessRenderPipelineManager.update();
            if (this.activeCameras.Length > 0)
            {
                var currentRenderId = this._renderId;
                for (var cameraIndex = 0; cameraIndex < this.activeCameras.Length; cameraIndex++)
                {
                    this._renderId = currentRenderId;
                    this._processSubCameras(this.activeCameras[cameraIndex]);
                }
            }
            else
            {
                this._processSubCameras(this.activeCamera);
            }

            this._checkIntersections();
            if (this.afterRender != null)
            {
                this.afterRender();
            }

            for (var index = 0; index < this._toBeDisposed.Length; index++)
            {
                this._toBeDisposed[index].dispose();
                this._toBeDisposed[index] = null;
            }

            this._toBeDisposed.reset();
            this._lastFrameDuration = new Date().getTime() - startDate;
        }

        /// <summary>
        /// </summary>
        /// <param name="id">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Camera setActiveCameraByID(string id)
        {
            var camera = this.getCameraByID(id);
            if (camera != null)
            {
                this.activeCamera = camera;
                return camera;
            }

            return null;
        }

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Camera setActiveCameraByName(string name)
        {
            var camera = this.getCameraByName(name);
            if (camera != null)
            {
                this.activeCamera = camera;
                return camera;
            }

            return null;
        }

        /// <summary>
        /// </summary>
        /// <param name="gravity">
        /// </param>
        public virtual void setGravity(Vector3 gravity)
        {
            if (this._physicsEngine == null)
            {
                return;
            }

            this._physicsEngine._setGravity(gravity);
        }

        /// <summary>
        /// </summary>
        /// <param name="mesh">
        /// </param>
        public virtual void setPointerOverMesh(AbstractMesh mesh)
        {
            if (this._pointerOverMesh == mesh)
            {
                return;
            }

            if (this._pointerOverMesh != null && this._pointerOverMesh.actionManager != null)
            {
                this._pointerOverMesh.actionManager.processTrigger(ActionManager.OnPointerOutTrigger, ActionEvent.CreateNew(this._pointerOverMesh));
            }

            this._pointerOverMesh = mesh;
            if (this._pointerOverMesh != null && this._pointerOverMesh.actionManager != null)
            {
                this._pointerOverMesh.actionManager.processTrigger(ActionManager.OnPointerOverTrigger, ActionEvent.CreateNew(this._pointerOverMesh));
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="view">
        /// </param>
        /// <param name="projection">
        /// </param>
        public virtual void setTransformMatrix(Matrix view, Matrix projection)
        {
            this._viewMatrix = view;
            this._projectionMatrix = projection;
            this._viewMatrix.multiplyToRef(this._projectionMatrix, this._transformMatrix);
        }

        /// <summary>
        /// </summary>
        /// <param name="target">
        /// </param>
        public virtual void stopAnimation(object target)
        {
            var animatable = this.getAnimatableByTarget(target);
            if (animatable != null)
            {
                animatable.stop();
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
        /// <param name="force">
        /// </param>
        public virtual void updateTransformMatrix(bool force = false)
        {
            this.setTransformMatrix(this.activeCamera.getViewMatrix(), this.activeCamera.getProjectionMatrix(force));
        }

        /// <summary>
        /// </summary>
        /// <param name="mesh">
        /// </param>
        private void _activeMesh(AbstractMesh mesh)
        {
            if (mesh.skeleton != null)
            {
                this._activeSkeletons.pushNoDuplicate(mesh.skeleton);
            }

            if (mesh.showBoundingBox)
            {
                this._boundingBoxRenderer.renderList.Add(mesh.getBoundingInfo().boundingBox);
            }

            if (mesh.subMeshes != null)
            {
                int len;
                Array<SubMesh> subMeshes;
                if (mesh._submeshesOctree != null && mesh.useOctreeForRenderingSelection)
                {
                    var intersections = mesh._submeshesOctree.select(this._frustumPlanes);
                    len = intersections.Length;
                    subMeshes = intersections;
                }
                else
                {
                    subMeshes = mesh.subMeshes;
                    len = subMeshes.Length;
                }

                for (var subIndex = 0; subIndex < len; subIndex++)
                {
                    var subMesh = subMeshes[subIndex];
                    this._evaluateSubMesh(subMesh, mesh);
                }
            }
        }

        /// <summary>
        /// </summary>
        private void _animate()
        {
            if (!this._animationStartDate.HasValue)
            {
                this._animationStartDate = new Date().getTime();
            }

            var now = new Date().getTime();
            var delay = now - this._animationStartDate.Value;
            for (var index = 0; index < this._activeAnimatables.Length; index++)
            {
                if (!this._activeAnimatables[index]._animate(delay))
                {
                    this._activeAnimatables.RemoveAt(index);
                    index--;
                }
            }
        }

        /// <summary>
        /// </summary>
        private void _checkIntersections()
        {
            for (var index = 0; index < this._meshesForIntersections.Length; index++)
            {
                var sourceMesh = this._meshesForIntersections[index];
                for (var actionIndex = 0; actionIndex < sourceMesh.actionManager.actions.Length; actionIndex++)
                {
                    var action = sourceMesh.actionManager.actions[actionIndex];
                    if (action.trigger == ActionManager.OnIntersectionEnterTrigger || action.trigger == ActionManager.OnIntersectionExitTrigger)
                    {
                        var otherMesh = action.getTriggerParameter();
                        var areIntersecting = otherMesh.intersectsMesh(sourceMesh, false);
                        var currentIntersectionInProgress = sourceMesh._intersectionsInProgress.IndexOf(otherMesh);
                        if (areIntersecting && currentIntersectionInProgress == -1 && action.trigger == ActionManager.OnIntersectionEnterTrigger)
                        {
                            sourceMesh.actionManager.processTrigger(ActionManager.OnIntersectionEnterTrigger, ActionEvent.CreateNew(sourceMesh));
                            sourceMesh._intersectionsInProgress.Add(otherMesh);
                        }
                        else if (!areIntersecting && currentIntersectionInProgress > -1 && action.trigger == ActionManager.OnIntersectionExitTrigger)
                        {
                            sourceMesh.actionManager.processTrigger(ActionManager.OnIntersectionExitTrigger, ActionEvent.CreateNew(sourceMesh));
                            var indexOfOther = sourceMesh._intersectionsInProgress.IndexOf(otherMesh);
                            if (indexOfOther > -1)
                            {
                                sourceMesh._intersectionsInProgress.RemoveAt(indexOfOther);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="position">
        /// </param>
        /// <param name="velocity">
        /// </param>
        /// <param name="collider">
        /// </param>
        /// <param name="maximumRetry">
        /// </param>
        /// <param name="finalPosition">
        /// </param>
        /// <param name="excludedMesh">
        /// </param>
        private void _collideWithWorld(
            Vector3 position, Vector3 velocity, Collider collider, double maximumRetry, Vector3 finalPosition, AbstractMesh excludedMesh = null)
        {
            var closeDistance = Engine.CollisionsEpsilon * 10.0;
            if (collider.retry >= maximumRetry)
            {
                finalPosition.copyFrom(position);
                return;
            }

            collider._initialize(position, velocity, closeDistance);
            for (var index = 0; index < this.meshes.Length; index++)
            {
                var mesh = this.meshes[index];
                if (mesh.isEnabled() && mesh.checkCollisions && mesh.subMeshes != null && mesh != excludedMesh)
                {
                    mesh._checkCollision(collider);
                }
            }

            if (!collider.collisionFound)
            {
                position.addToRef(velocity, finalPosition);
                return;
            }

            if (velocity.x != 0 || velocity.y != 0 || velocity.z != 0)
            {
                collider._getResponse(position, velocity);
            }

            if (velocity.Length() <= closeDistance)
            {
                finalPosition.copyFrom(position);
                return;
            }

            collider.retry++;
            this._collideWithWorld(position, velocity, collider, maximumRetry, finalPosition, excludedMesh);
        }

        /// <summary>
        /// </summary>
        private void _evaluateActiveMeshes()
        {
            this._activeMeshes.reset();
            this._renderingManager.reset();
            this._processedMaterials.reset();
            this._activeParticleSystems.reset();
            this._activeSkeletons.reset();
            this._boundingBoxRenderer.reset();
            if (this._frustumPlanes == null)
            {
                this._frustumPlanes = Frustum.GetPlanes(this._transformMatrix);
            }
            else
            {
                Frustum.GetPlanesToRef(this._transformMatrix, this._frustumPlanes);
            }

            Array<AbstractMesh> meshes;
            int len;
            if (this._selectionOctree != null)
            {
                var selection = this._selectionOctree.select(this._frustumPlanes);
                meshes = selection;
                len = selection.Length;
            }
            else
            {
                len = this.meshes.Length;
                meshes = this.meshes;
            }

            for (var meshIndex = 0; meshIndex < len; meshIndex++)
            {
                var mesh = meshes[meshIndex];
                this._totalVertices += mesh.getTotalVertices();
                if (!mesh.isReady())
                {
                    continue;
                }

                mesh.computeWorldMatrix();
                mesh._preActivate();
                if (mesh.actionManager != null
                    && mesh.actionManager.hasSpecificTriggers(new Array<int>(ActionManager.OnIntersectionEnterTrigger, ActionManager.OnIntersectionExitTrigger)))
                {
                    this._meshesForIntersections.pushNoDuplicate(mesh);
                }

                if (mesh.isEnabled() && mesh.isVisible && mesh.visibility > 0 && ((mesh.layerMask & this.activeCamera.layerMask) != 0)
                    && mesh.isInFrustum(this._frustumPlanes))
                {
                    this._activeMeshes.Add(mesh);
                    mesh._activate(this._renderId);
                    this._activeMesh(mesh);
                }
            }

            var beforeParticlesDate = new Date().getTime();
            if (this.particlesEnabled)
            {
                for (var particleIndex = 0; particleIndex < this.particleSystems.Length; particleIndex++)
                {
                    var particleSystem = this.particleSystems[particleIndex];
                    if (!particleSystem.isStarted())
                    {
                        continue;
                    }

                    if (((Mesh)particleSystem.emitter).position == null || (particleSystem.emitter != null && ((Mesh)particleSystem.emitter).isEnabled()))
                    {
                        this._activeParticleSystems.Add(particleSystem);
                        particleSystem.animate();
                    }
                }
            }

            this._particlesDuration += new Date().getTime() - beforeParticlesDate;
        }

        /// <summary>
        /// </summary>
        /// <param name="subMesh">
        /// </param>
        /// <param name="mesh">
        /// </param>
        private void _evaluateSubMesh(SubMesh subMesh, AbstractMesh mesh)
        {
            if (mesh.subMeshes.Length == 1 || subMesh.isInFrustum(this._frustumPlanes))
            {
                var material = subMesh.getMaterial();
                if (mesh.showSubMeshesBoundingBox)
                {
                    this._boundingBoxRenderer.renderList.Add(subMesh.getBoundingInfo().boundingBox);
                }

                if (material != null)
                {
                    if (material.getRenderTargetTextures != null)
                    {
                        if (this._processedMaterials.IndexOf(material) == -1)
                        {
                            this._processedMaterials.Add(material);
                            this._renderTargets.Append(material.getRenderTargetTextures());
                        }
                    }

                    this._activeVertices += subMesh.verticesCount;
                    this._renderingManager.dispatch(subMesh);
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="list">
        /// </param>
        /// <param name="tagsQuery">
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// </returns>
        private Array<T> _getByTags<T>(Array<T> list, string tagsQuery) where T : class
        {
            if (tagsQuery == null)
            {
                return list;
            }

            var listByTags = new Array<T>();

            // TODO: finish it
            ////for (var i = 0; i < list.Length; i++)
            ////{
            ////    var item = list[i];
            ////    if (BABYLON.Tags.MatchesQuery(item, tagsQuery))
            ////    {
            ////        listByTags.Add(item);
            ////    }
            ////}
            return listByTags;
        }

        /// <summary>
        /// </summary>
        /// <param name="rayFunction">
        /// </param>
        /// <param name="predicate">
        /// </param>
        /// <param name="fastCheck">
        /// </param>
        /// <returns>
        /// </returns>
        private PickingInfo _internalPick(Func<Matrix, Ray> rayFunction, Func<AbstractMesh, bool> predicate, bool fastCheck = false)
        {
            PickingInfo pickingInfo = null;
            for (var meshIndex = 0; meshIndex < this.meshes.Length; meshIndex++)
            {
                var mesh = this.meshes[meshIndex];
                if (predicate != null)
                {
                    if (!predicate(mesh))
                    {
                        continue;
                    }
                }
                else if (!mesh.isEnabled() || !mesh.isVisible || !mesh.isPickable)
                {
                    continue;
                }

                var world = mesh.getWorldMatrix();
                var ray = rayFunction(world);
                var result = mesh.intersects(ray, fastCheck);
                if (result == null || !result.hit)
                {
                    continue;
                }

                if (!fastCheck && pickingInfo != null && result.distance >= pickingInfo.distance)
                {
                    continue;
                }

                pickingInfo = result;
                if (fastCheck)
                {
                    break;
                }
            }

            return pickingInfo ?? new PickingInfo();
        }

        /// <summary>
        /// </summary>
        /// <param name="camera">
        /// </param>
        private void _processSubCameras(Camera camera)
        {
            if (camera.subCameras.Length == 0)
            {
                this._renderForCamera(camera);
                return;
            }

            for (var index = 0; index < camera.subCameras.Length; index++)
            {
                this._renderForCamera(camera.subCameras[index]);
            }

            this.activeCamera = camera;
            this.setTransformMatrix(this.activeCamera.getViewMatrix(), this.activeCamera.getProjectionMatrix());
            this.activeCamera._updateFromScene();
        }

        /// <summary>
        /// </summary>
        /// <param name="camera">
        /// </param>
        /// <exception cref="Error">
        /// </exception>
        private void _renderForCamera(Camera camera)
        {
            var engine = this._engine;
            this.activeCamera = camera;
            if (this.activeCamera == null)
            {
                throw new Error("Active camera not set");
            }

            engine.setViewport(this.activeCamera.viewport);
            this._renderId++;
            this.updateTransformMatrix();
            if (this.beforeCameraRender != null)
            {
                this.beforeCameraRender(this.activeCamera);
            }

            var beforeEvaluateActiveMeshesDate = new Date().getTime();
            this._evaluateActiveMeshes();
            this._evaluateActiveMeshesDuration += new Date().getTime() - beforeEvaluateActiveMeshesDate;
            for (var skeletonIndex = 0; skeletonIndex < this._activeSkeletons.Length; skeletonIndex++)
            {
                var skeleton = this._activeSkeletons[skeletonIndex];
                skeleton.prepare();
            }

            for (var customIndex = 0; customIndex < this.customRenderTargets.Length; customIndex++)
            {
                var renderTarget = this.customRenderTargets[customIndex];
                this._renderTargets.Add(renderTarget);
            }

            var beforeRenderTargetDate = new Date().getTime();
            if (this.renderTargetsEnabled)
            {
                for (var renderIndex = 0; renderIndex < this._renderTargets.Length; renderIndex++)
                {
                    var renderTarget = this._renderTargets[renderIndex];
                    if (renderTarget._shouldRender())
                    {
                        this._renderId++;
                        renderTarget.render();
                    }
                }

                this._renderId++;
            }

            if (this._renderTargets.Length > 0)
            {
                engine.restoreDefaultFramebuffer();
            }

            this._renderTargetsDuration = new Date().getTime() - beforeRenderTargetDate;
            this.postProcessManager._prepareFrame();
            var beforeRenderDate = new Date().getTime();
            if (this.layers.Length > 0)
            {
                engine.setDepthBuffer(false);
                int layerIndex;
                Layer layer;
                for (layerIndex = 0; layerIndex < this.layers.Length; layerIndex++)
                {
                    layer = this.layers[layerIndex];
                    if (layer.isBackground)
                    {
                        layer.render();
                    }
                }

                engine.setDepthBuffer(true);
            }

            this._renderingManager.render(null, null, true, true);
            this._boundingBoxRenderer.render();
            for (var lensFlareSystemIndex = 0; lensFlareSystemIndex < this.lensFlareSystems.Length; lensFlareSystemIndex++)
            {
                this.lensFlareSystems[lensFlareSystemIndex].render();
            }

            if (this.layers.Length > 0)
            {
                engine.setDepthBuffer(false);
                for (var layerIndex = 0; layerIndex < this.layers.Length; layerIndex++)
                {
                    var layer = this.layers[layerIndex];
                    if (!layer.isBackground)
                    {
                        layer.render();
                    }
                }

                engine.setDepthBuffer(true);
            }

            this._renderDuration += new Date().getTime() - beforeRenderDate;
            this.postProcessManager._finalizeFrame(camera.isIntermediate);
            this.activeCamera._updateFromScene();
            this._renderTargets.reset();
            if (this.afterCameraRender != null)
            {
                this.afterCameraRender(this.activeCamera);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="evt">
        /// </param>
        private void _updatePointerPosition(PointerEvent evt)
        {
            var canvasRect = this._engine.getRenderingCanvasClientRect();
            this._pointerX = evt.clientX - canvasRect.left;
            this._pointerY = evt.clientY - canvasRect.top;
            if (this.cameraToUseForPointers != null)
            {
                this._pointerX = this._pointerX - this.cameraToUseForPointers.viewport.x * this._engine.getRenderWidth();
                this._pointerY = this._pointerY - this.cameraToUseForPointers.viewport.y * this._engine.getRenderHeight();
            }
        }

        /// <summary>
        /// </summary>
        public const int FOGMODE_NONE = 0;

        /// <summary>
        /// </summary>
        public const int FOGMODE_EXP = 1;

        /// <summary>
        /// </summary>
        public const int FOGMODE_EXP2 = 2;

        /// <summary>
        /// </summary>
        public const int FOGMODE_LINEAR = 3;
    }
}