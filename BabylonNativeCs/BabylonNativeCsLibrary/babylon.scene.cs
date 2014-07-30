using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial interface IDisposable {
        void dispose();
    }
    public partial class Scene {
        public
        const double FOGMODE_NONE = 0;
        public
        const double FOGMODE_EXP = 1;
        public
        const double FOGMODE_EXP2 = 2;
        public
        const double FOGMODE_LINEAR = 3;
        public static double MinDeltaTime = 1.0;
        public static double MaxDeltaTime = 1000.0;
        public bool autoClear = true;
        public BABYLON.Color3 clearColor = new BABYLON.Color3(0.2, 0.2, 0.3);
        public BABYLON.Color3 ambientColor = new BABYLON.Color3(0, 0, 0);
        public System.Action beforeRender;
        public System.Action afterRender;
        public System.Action onDispose;
        public System.Action < Camera > beforeCameraRender;
        public System.Action < Camera > afterCameraRender;
        public bool forceWireframe = false;
        public Plane clipPlane;
        private System.Action < PointerEvent > _onPointerMove;
        private System.Action < PointerEvent > _onPointerDown;
        public System.Action < PointerEvent, PickingInfo > onPointerDown;
        public Camera cameraToUseForPointers = null;
        private double _pointerX;
        private double _pointerY;
        private AbstractMesh _meshUnderPointer;
        public double fogMode = BABYLON.Scene.FOGMODE_NONE;
        public Color3 fogColor = new Color3(0.2, 0.2, 0.3);
        public double fogDensity = 0.1;
        public double fogStart = 0;
        public double fogEnd = 1000.0;
        public bool lightsEnabled = true;
        public Array < Light > lights = new Array < Light > ();
        public Array < Camera > cameras = new Array < Camera > ();
        public Array < Camera > activeCameras = new Array < Camera > ();
        public Camera activeCamera;
        public Array < AbstractMesh > meshes = new Array < AbstractMesh > ();
        private Array < Geometry > _geometries = new Array < Geometry > ();
        public Array < Material > materials = new Array < Material > ();
        public Array < MultiMaterial > multiMaterials = new Array < MultiMaterial > ();
        public BABYLON.StandardMaterial defaultMaterial = new BABYLON.StandardMaterial("default material", this);
        public bool texturesEnabled = true;
        public Array < BaseTexture > textures = new Array < BaseTexture > ();
        public bool particlesEnabled = true;
        public Array < ParticleSystem > particleSystems = new Array < ParticleSystem > ();
        public Array < SpriteManager > spriteManagers = new Array < SpriteManager > ();
        public Array < Layer > layers = new Array < Layer > ();
        public Array < Skeleton > skeletons = new Array < Skeleton > ();
        public Array < LensFlareSystem > lensFlareSystems = new Array < LensFlareSystem > ();
        public bool collisionsEnabled = true;
        public BABYLON.Vector3 gravity = new BABYLON.Vector3(0, -9.0, 0);
        public bool postProcessesEnabled = true;
        public PostProcessManager postProcessManager;
        public PostProcessRenderPipelineManager postProcessRenderPipelineManager;
        public bool renderTargetsEnabled = true;
        public Array < RenderTargetTexture > customRenderTargets = new Array < RenderTargetTexture > ();
        public bool useDelayedTextureLoading;
        public Array < String > importedMeshesFiles = new Array < String > ();
        public dynamic database;
        public ActionManager actionManager;
        public Array < ActionManager > _actionManagers = new Array < ActionManager > ();
        private SmartArray < AbstractMesh > _meshesForIntersections = new SmartArray < AbstractMesh > (256);
        private Engine _engine;
        private double _totalVertices = 0;
        public double _activeVertices = 0;
        public double _activeParticles = 0;
        private double _lastFrameDuration = 0;
        private double _evaluateActiveMeshesDuration = 0;
        private double _renderTargetsDuration = 0;
        public double _particlesDuration = 0;
        private double _renderDuration = 0;
        public double _spritesDuration = 0;
        private double _animationRatio = 0;
        private double _animationStartDate;
        private double _renderId = 0;
        private double _executeWhenReadyTimeoutId = -1;
        public SmartArray < IDisposable > _toBeDisposed = new SmartArray < IDisposable > (256);
        private Array < System.Action > _onReadyCallbacks = new Array < System.Action > ();
        private Array < object > _pendingData = new Array < object > ();
        private Array < System.Action > _onBeforeRenderCallbacks = new Array < System.Action > ();
        private SmartArray < Mesh > _activeMeshes = new SmartArray < Mesh > (256);
        private SmartArray < Material > _processedMaterials = new SmartArray < Material > (256);
        private SmartArray < RenderTargetTexture > _renderTargets = new SmartArray < RenderTargetTexture > (256);
        public SmartArray < ParticleSystem > _activeParticleSystems = new SmartArray < ParticleSystem > (256);
        private SmartArray < Skeleton > _activeSkeletons = new SmartArray < Skeleton > (32);
        private RenderingManager _renderingManager;
        private PhysicsEngine _physicsEngine;
        public Array < Animatable > _activeAnimatables = new Array < Animatable > ();
        private BABYLON.Matrix _transformMatrix = Matrix.Zero();
        private Matrix _pickWithRayInverseMatrix;
        private BABYLON.Vector3 _scaledPosition = Vector3.Zero();
        private BABYLON.Vector3 _scaledVelocity = Vector3.Zero();
        private BoundingBoxRenderer _boundingBoxRenderer;
        private Matrix _viewMatrix;
        private Matrix _projectionMatrix;
        private Array < Plane > _frustumPlanes;
        private Octree < AbstractMesh > _selectionOctree;
        private AbstractMesh _pointerOverMesh;
        public Scene(Engine engine) {
            this._engine = engine;
            engine.scenes.push(this);
            this._renderingManager = new RenderingManager(this);
            this.postProcessManager = new PostProcessManager(this);
            this.postProcessRenderPipelineManager = new PostProcessRenderPipelineManager();
            this._boundingBoxRenderer = new BoundingBoxRenderer(this);
            this.attachControl();
        }
        public virtual AbstractMesh meshUnderPointer {
            get {
                return this._meshUnderPointer;
            }
        }
        public virtual double pointerX {
            get {
                return this._pointerX;
            }
        }
        public virtual double pointerY {
            get {
                return this._pointerY;
            }
        }
        public virtual BoundingBoxRenderer getBoundingBoxRenderer() {
            return this._boundingBoxRenderer;
        }
        public virtual Engine getEngine() {
            return this._engine;
        }
        public virtual double getTotalVertices() {
            return this._totalVertices;
        }
        public virtual double getActiveVertices() {
            return this._activeVertices;
        }
        public virtual double getActiveParticles() {
            return this._activeParticles;
        }
        public virtual double getLastFrameDuration() {
            return this._lastFrameDuration;
        }
        public virtual double getEvaluateActiveMeshesDuration() {
            return this._evaluateActiveMeshesDuration;
        }
        public virtual SmartArray < Mesh > getActiveMeshes() {
            return this._activeMeshes;
        }
        public virtual double getRenderTargetsDuration() {
            return this._renderTargetsDuration;
        }
        public virtual double getRenderDuration() {
            return this._renderDuration;
        }
        public virtual double getParticlesDuration() {
            return this._particlesDuration;
        }
        public virtual double getSpritesDuration() {
            return this._spritesDuration;
        }
        public virtual double getAnimationRatio() {
            return this._animationRatio;
        }
        public virtual double getRenderId() {
            return this._renderId;
        }
        private void _updatePointerPosition(PointerEvent evt) {
            var canvasRect = this._engine.getRenderingCanvasClientRect();
            this._pointerX = evt.clientX - canvasRect.left;
            this._pointerY = evt.clientY - canvasRect.top;
            if (this.cameraToUseForPointers) {
                this._pointerX = this._pointerX - this.cameraToUseForPointers.viewport.x * this._engine.getRenderWidth();
                this._pointerY = this._pointerY - this.cameraToUseForPointers.viewport.y * this._engine.getRenderHeight();
            }
        }
        public virtual void attachControl() {
            this._onPointerMove = (PointerEvent evt) => {
                var canvas = this._engine.getRenderingCanvas();
                this._updatePointerPosition(evt);
                var pickResult = this.pick(this._pointerX, this._pointerY, (AbstractMesh mesh) => mesh.isPickable && mesh.isVisible && mesh.isReady() && mesh.actionManager && mesh.actionManager.hasPointerTriggers, false, this.cameraToUseForPointers);
                if (pickResult.hit) {
                    this.setPointerOverMesh(pickResult.pickedMesh);
                    canvas.style.cursor = "pointer";
                    this._meshUnderPointer = pickResult.pickedMesh;
                } else {
                    this.setPointerOverMesh(null);
                    canvas.style.cursor = "";
                    this._meshUnderPointer = null;
                }
            };
            this._onPointerDown = (PointerEvent evt) => {
                var predicate = null;
                if (!this.onPointerDown) {
                    predicate = (AbstractMesh mesh) => {
                        return mesh.isPickable && mesh.isVisible && mesh.isReady() && mesh.actionManager && mesh.actionManager.hasPickTriggers;
                    };
                }
                this._updatePointerPosition(evt);
                var pickResult = this.pick(this._pointerX, this._pointerY, predicate, false, this.cameraToUseForPointers);
                if (pickResult.hit) {
                    if (pickResult.pickedMesh.actionManager) {
                        switch (evt.button) {
                            case 0:
                                pickResult.pickedMesh.actionManager.processTrigger(BABYLON.ActionManager.OnLeftPickTrigger, ActionEvent.CreateNew(pickResult.pickedMesh));
                                break;
                            case 1:
                                pickResult.pickedMesh.actionManager.processTrigger(BABYLON.ActionManager.OnCenterPickTrigger, ActionEvent.CreateNew(pickResult.pickedMesh));
                                break;
                            case 2:
                                pickResult.pickedMesh.actionManager.processTrigger(BABYLON.ActionManager.OnRightPickTrigger, ActionEvent.CreateNew(pickResult.pickedMesh));
                                break;
                        }
                        pickResult.pickedMesh.actionManager.processTrigger(BABYLON.ActionManager.OnPickTrigger, ActionEvent.CreateNew(pickResult.pickedMesh));
                    }
                }
                if (this.onPointerDown) {
                    this.onPointerDown(evt, pickResult);
                }
            };
            var eventPrefix = Tools.GetPointerPrefix();
            this._engine.getRenderingCanvas().addEventListener(eventPrefix + "move", this._onPointerMove, false);
            this._engine.getRenderingCanvas().addEventListener(eventPrefix + "down", this._onPointerDown, false);
        }
        public virtual void detachControl() {
            var eventPrefix = Tools.GetPointerPrefix();
            this._engine.getRenderingCanvas().removeEventListener(eventPrefix + "move", this._onPointerMove);
            this._engine.getRenderingCanvas().removeEventListener(eventPrefix + "down", this._onPointerDown);
        }
        public virtual bool isReady() {
            if (this._pendingData.Length > 0) {
                return false;
            }
            for (var index = 0; index < this._geometries.Length; index++) {
                var geometry = this._geometries[index];
                if (geometry.delayLoadState == BABYLON.Engine.DELAYLOADSTATE_LOADING) {
                    return false;
                }
            }
            for (index = 0; index < this.meshes.Length; index++) {
                var mesh = this.meshes[index];
                if (!mesh.isReady()) {
                    return false;
                }
                var mat = mesh.material;
                if (mat) {
                    if (!mat.isReady(mesh)) {
                        return false;
                    }
                }
            }
            return true;
        }
        public virtual void registerBeforeRender(System.Action func) {
            this._onBeforeRenderCallbacks.push(func);
        }
        public virtual void unregisterBeforeRender(System.Action func) {
            var index = this._onBeforeRenderCallbacks.indexOf(func);
            if (index > -1) {
                this._onBeforeRenderCallbacks.splice(index, 1);
            }
        }
        public virtual void _addPendingData(object data) {
            this._pendingData.push(data);
        }
        public virtual void _removePendingData(object data) {
            var index = this._pendingData.indexOf(data);
            if (index != -1) {
                this._pendingData.splice(index, 1);
            }
        }
        public virtual double getWaitingItemsCount() {
            return this._pendingData.Length;
        }
        public virtual void executeWhenReady(System.Action func) {
            this._onReadyCallbacks.push(func);
            if (this._executeWhenReadyTimeoutId != -1) {
                return;
            }
            this._executeWhenReadyTimeoutId = setTimeout(() => {
                this._checkIsReady();
            }, 150);
        }
        public virtual void _checkIsReady() {
            if (this.isReady()) {
                this._onReadyCallbacks.forEach((func) => {
                    func();
                });
                this._onReadyCallbacks = new Array < object > ();
                this._executeWhenReadyTimeoutId = -1;
                return;
            }
            this._executeWhenReadyTimeoutId = setTimeout(() => {
                this._checkIsReady();
            }, 150);
        }
        public virtual Animatable beginAnimation(object target, double from, double to, bool loop = false, double speedRatio = 0.0, System.Action onAnimationEnd = null, Animatable animatable = null) {
            if (speedRatio == null) {
                speedRatio = 1.0;
            }
            this.stopAnimation(target);
            if (!animatable) {
                animatable = new Animatable(this, target, from, to, loop, speedRatio, onAnimationEnd);
            }
            if (target.animations) {
                animatable.appendAnimations(target, target.animations);
            }
            if (target.getAnimatables) {
                var animatables = target.getAnimatables();
                for (var index = 0; index < animatables.Length; index++) {
                    this.beginAnimation(animatables[index], from, to, loop, speedRatio, onAnimationEnd, animatable);
                }
            }
            return animatable;
        }
        public virtual Animatable beginDirectAnimation(object target, Array < Animation > animations, double from, double to, bool loop = false, double speedRatio = 0.0, System.Action onAnimationEnd = null) {
            if (speedRatio == null) {
                speedRatio = 1.0;
            }
            var animatable = new BABYLON.Animatable(this, target, from, to, loop, speedRatio, onAnimationEnd, animations);
            return animatable;
        }
        public virtual Animatable getAnimatableByTarget(object target) {
            for (var index = 0; index < this._activeAnimatables.Length; index++) {
                if (this._activeAnimatables[index].target == target) {
                    return this._activeAnimatables[index];
                }
            }
            return null;
        }
        public virtual void stopAnimation(object target) {
            var animatable = this.getAnimatableByTarget(target);
            if (animatable) {
                animatable.stop();
            }
        }
        private void _animate() {
            if (!this._animationStartDate) {
                this._animationStartDate = new Date().getTime();
            }
            var now = new Date().getTime();
            var delay = now - this._animationStartDate;
            for (var index = 0; index < this._activeAnimatables.Length; index++) {
                if (!this._activeAnimatables[index]._animate(delay)) {
                    this._activeAnimatables.splice(index, 1);
                    index--;
                }
            }
        }
        public virtual Matrix getViewMatrix() {
            return this._viewMatrix;
        }
        public virtual Matrix getProjectionMatrix() {
            return this._projectionMatrix;
        }
        public virtual Matrix getTransformMatrix() {
            return this._transformMatrix;
        }
        public virtual void setTransformMatrix(Matrix view, Matrix projection) {
            this._viewMatrix = view;
            this._projectionMatrix = projection;
            this._viewMatrix.multiplyToRef(this._projectionMatrix, this._transformMatrix);
        }
        public virtual Camera setActiveCameraByID(string id) {
            var camera = this.getCameraByID(id);
            if (camera) {
                this.activeCamera = camera;
                return camera;
            }
            return null;
        }
        public virtual Camera setActiveCameraByName(string name) {
            var camera = this.getCameraByName(name);
            if (camera) {
                this.activeCamera = camera;
                return camera;
            }
            return null;
        }
        public virtual Material getMaterialByID(string id) {
            for (var index = 0; index < this.materials.Length; index++) {
                if (this.materials[index].id == id) {
                    return this.materials[index];
                }
            }
            return null;
        }
        public virtual Material getMaterialByName(string name) {
            for (var index = 0; index < this.materials.Length; index++) {
                if (this.materials[index].name == name) {
                    return this.materials[index];
                }
            }
            return null;
        }
        public virtual Camera getCameraByID(string id) {
            for (var index = 0; index < this.cameras.Length; index++) {
                if (this.cameras[index].id == id) {
                    return this.cameras[index];
                }
            }
            return null;
        }
        public virtual Camera getCameraByName(string name) {
            for (var index = 0; index < this.cameras.Length; index++) {
                if (this.cameras[index].name == name) {
                    return this.cameras[index];
                }
            }
            return null;
        }
        public virtual Light getLightByName(string name) {
            for (var index = 0; index < this.lights.Length; index++) {
                if (this.lights[index].name == name) {
                    return this.lights[index];
                }
            }
            return null;
        }
        public virtual Light getLightByID(string id) {
            for (var index = 0; index < this.lights.Length; index++) {
                if (this.lights[index].id == id) {
                    return this.lights[index];
                }
            }
            return null;
        }
        public virtual Geometry getGeometryByID(string id) {
            for (var index = 0; index < this._geometries.Length; index++) {
                if (this._geometries[index].id == id) {
                    return this._geometries[index];
                }
            }
            return null;
        }
        public virtual bool pushGeometry(Geometry geometry, bool force = false) {
            if (!force && this.getGeometryByID(geometry.id)) {
                return false;
            }
            this._geometries.push(geometry);
            return true;
        }
        public virtual Array < Geometry > getGeometries() {
            return this._geometries;
        }
        public virtual AbstractMesh getMeshByID(string id) {
            for (var index = 0; index < this.meshes.Length; index++) {
                if (this.meshes[index].id == id) {
                    return this.meshes[index];
                }
            }
            return null;
        }
        public virtual AbstractMesh getLastMeshByID(string id) {
            for (var index = this.meshes.Length - 1; index >= 0; index--) {
                if (this.meshes[index].id == id) {
                    return this.meshes[index];
                }
            }
            return null;
        }
        public virtual Node getLastEntryByID(string id) {
            for (var index = this.meshes.Length - 1; index >= 0; index--) {
                if (this.meshes[index].id == id) {
                    return this.meshes[index];
                }
            }
            for (index = this.cameras.Length - 1; index >= 0; index--) {
                if (this.cameras[index].id == id) {
                    return this.cameras[index];
                }
            }
            for (index = this.lights.Length - 1; index >= 0; index--) {
                if (this.lights[index].id == id) {
                    return this.lights[index];
                }
            }
            return null;
        }
        public virtual AbstractMesh getMeshByName(string name) {
            for (var index = 0; index < this.meshes.Length; index++) {
                if (this.meshes[index].name == name) {
                    return this.meshes[index];
                }
            }
            return null;
        }
        public virtual Skeleton getLastSkeletonByID(string id) {
            for (var index = this.skeletons.Length - 1; index >= 0; index--) {
                if (this.skeletons[index].id == id) {
                    return this.skeletons[index];
                }
            }
            return null;
        }
        public virtual Skeleton getSkeletonById(string id) {
            for (var index = 0; index < this.skeletons.Length; index++) {
                if (this.skeletons[index].id == id) {
                    return this.skeletons[index];
                }
            }
            return null;
        }
        public virtual Skeleton getSkeletonByName(string name) {
            for (var index = 0; index < this.skeletons.Length; index++) {
                if (this.skeletons[index].name == name) {
                    return this.skeletons[index];
                }
            }
            return null;
        }
        public virtual bool isActiveMesh(Mesh mesh) {
            return (this._activeMeshes.indexOf(mesh) != -1);
        }
        private void _evaluateSubMesh(SubMesh subMesh, AbstractMesh mesh) {
            if (mesh.subMeshes.Length == 1 || subMesh.isInFrustum(this._frustumPlanes)) {
                var material = subMesh.getMaterial();
                if (mesh.showSubMeshesBoundingBox) {
                    this._boundingBoxRenderer.renderList.push(subMesh.getBoundingInfo().boundingBox);
                }
                if (material) {
                    if (material.getRenderTargetTextures) {
                        if (this._processedMaterials.indexOf(material) == -1) {
                            this._processedMaterials.push(material);
                            this._renderTargets.concat(material.getRenderTargetTextures());
                        }
                    }
                    this._activeVertices += subMesh.verticesCount;
                    this._renderingManager.dispatch(subMesh);
                }
            }
        }
        private void _evaluateActiveMeshes() {
            this._activeMeshes.reset();
            this._renderingManager.reset();
            this._processedMaterials.reset();
            this._activeParticleSystems.reset();
            this._activeSkeletons.reset();
            this._boundingBoxRenderer.reset();
            if (!this._frustumPlanes) {
                this._frustumPlanes = BABYLON.Frustum.GetPlanes(this._transformMatrix);
            } else {
                BABYLON.Frustum.GetPlanesToRef(this._transformMatrix, this._frustumPlanes);
            }
            var meshes;
            var len;
            if (this._selectionOctree) {
                var selection = this._selectionOctree.select(this._frustumPlanes);
                meshes = selection.data;
                len = selection.Length;
            } else {
                len = this.meshes.Length;
                meshes = this.meshes;
            }
            for (var meshIndex = 0; meshIndex < len; meshIndex++) {
                var mesh = meshes[meshIndex];
                this._totalVertices += mesh.getTotalVertices();
                if (!mesh.isReady()) {
                    continue;
                }
                mesh.computeWorldMatrix();
                mesh._preActivate();
                if (mesh.actionManager && mesh.actionManager.hasSpecificTriggers(new Array < object > (ActionManager.OnIntersectionEnterTrigger, ActionManager.OnIntersectionExitTrigger))) {
                    this._meshesForIntersections.pushNoDuplicate(mesh);
                }
                if (mesh.isEnabled() && mesh.isVisible && mesh.visibility > 0 && ((mesh.layerMask & this.activeCamera.layerMask) != 0) && mesh.isInFrustum(this._frustumPlanes)) {
                    this._activeMeshes.push(mesh);
                    mesh._activate(this._renderId);
                    this._activeMesh(mesh);
                }
            }
            var beforeParticlesDate = new Date().getTime();
            if (this.particlesEnabled) {
                for (var particleIndex = 0; particleIndex < this.particleSystems.Length; particleIndex++) {
                    var particleSystem = this.particleSystems[particleIndex];
                    if (!particleSystem.isStarted()) {
                        continue;
                    }
                    if (!particleSystem.emitter.position || (particleSystem.emitter && particleSystem.emitter.isEnabled())) {
                        this._activeParticleSystems.push(particleSystem);
                        particleSystem.animate();
                    }
                }
            }
            this._particlesDuration += new Date().getTime() - beforeParticlesDate;
        }
        private void _activeMesh(AbstractMesh mesh) {
            if (mesh.skeleton) {
                this._activeSkeletons.pushNoDuplicate(mesh.skeleton);
            }
            if (mesh.showBoundingBox) {
                this._boundingBoxRenderer.renderList.push(mesh.getBoundingInfo().boundingBox);
            }
            if (mesh.subMeshes) {
                var len;
                var subMeshes;
                if (mesh._submeshesOctree && mesh.useOctreeForRenderingSelection) {
                    var intersections = mesh._submeshesOctree.select(this._frustumPlanes);
                    len = intersections.Length;
                    subMeshes = intersections.data;
                } else {
                    subMeshes = mesh.subMeshes;
                    len = subMeshes.Length;
                }
                for (var subIndex = 0; subIndex < len; subIndex++) {
                    var subMesh = subMeshes[subIndex];
                    this._evaluateSubMesh(subMesh, mesh);
                }
            }
        }
        public virtual void updateTransformMatrix(bool force = false) {
            this.setTransformMatrix(this.activeCamera.getViewMatrix(), this.activeCamera.getProjectionMatrix(force));
        }
        private void _renderForCamera(Camera camera) {
            var engine = this._engine;
            this.activeCamera = camera;
            if (!this.activeCamera)
                throw new Error("Active camera not set");
            engine.setViewport(this.activeCamera.viewport);
            this._renderId++;
            this.updateTransformMatrix();
            if (this.beforeCameraRender) {
                this.beforeCameraRender(this.activeCamera);
            }
            var beforeEvaluateActiveMeshesDate = new Date().getTime();
            this._evaluateActiveMeshes();
            this._evaluateActiveMeshesDuration += new Date().getTime() - beforeEvaluateActiveMeshesDate;
            for (var skeletonIndex = 0; skeletonIndex < this._activeSkeletons.Length; skeletonIndex++) {
                var skeleton = this._activeSkeletons.data[skeletonIndex];
                skeleton.prepare();
            }
            for (var customIndex = 0; customIndex < this.customRenderTargets.Length; customIndex++) {
                var renderTarget = this.customRenderTargets[customIndex];
                this._renderTargets.push(renderTarget);
            }
            var beforeRenderTargetDate = new Date().getTime();
            if (this.renderTargetsEnabled) {
                for (var renderIndex = 0; renderIndex < this._renderTargets.Length; renderIndex++) {
                    renderTarget = this._renderTargets.data[renderIndex];
                    if (renderTarget._shouldRender()) {
                        this._renderId++;
                        renderTarget.render();
                    }
                }
                this._renderId++;
            }
            if (this._renderTargets.Length > 0) {
                engine.restoreDefaultFramebuffer();
            }
            this._renderTargetsDuration = new Date().getTime() - beforeRenderTargetDate;
            this.postProcessManager._prepareFrame();
            var beforeRenderDate = new Date().getTime();
            if (this.layers.Length) {
                engine.setDepthBuffer(false);
                var layerIndex;
                var layer;
                for (layerIndex = 0; layerIndex < this.layers.Length; layerIndex++) {
                    layer = this.layers[layerIndex];
                    if (layer.isBackground) {
                        layer.render();
                    }
                }
                engine.setDepthBuffer(true);
            }
            this._renderingManager.render(null, null, true, true);
            this._boundingBoxRenderer.render();
            for (var lensFlareSystemIndex = 0; lensFlareSystemIndex < this.lensFlareSystems.Length; lensFlareSystemIndex++) {
                this.lensFlareSystems[lensFlareSystemIndex].render();
            }
            if (this.layers.Length) {
                engine.setDepthBuffer(false);
                for (layerIndex = 0; layerIndex < this.layers.Length; layerIndex++) {
                    layer = this.layers[layerIndex];
                    if (!layer.isBackground) {
                        layer.render();
                    }
                }
                engine.setDepthBuffer(true);
            }
            this._renderDuration += new Date().getTime() - beforeRenderDate;
            this.postProcessManager._finalizeFrame(camera.isIntermediate);
            this.activeCamera._updateFromScene();
            this._renderTargets.reset();
            if (this.afterCameraRender) {
                this.afterCameraRender(this.activeCamera);
            }
        }
        private void _processSubCameras(Camera camera) {
            if (camera.subCameras.Length == 0) {
                this._renderForCamera(camera);
                return;
            }
            for (var index = 0; index < camera.subCameras.Length; index++) {
                this._renderForCamera(camera.subCameras[index]);
            }
            this.activeCamera = camera;
            this.setTransformMatrix(this.activeCamera.getViewMatrix(), this.activeCamera.getProjectionMatrix());
            this.activeCamera._updateFromScene();
        }
        private void _checkIntersections() {
            for (var index = 0; index < this._meshesForIntersections.Length; index++) {
                var sourceMesh = this._meshesForIntersections.data[index];
                for (var actionIndex = 0; actionIndex < sourceMesh.actionManager.actions.Length; actionIndex++) {
                    var action = sourceMesh.actionManager.actions[actionIndex];
                    if (action.trigger == ActionManager.OnIntersectionEnterTrigger || action.trigger == ActionManager.OnIntersectionExitTrigger) {
                        var otherMesh = action.getTriggerParameter();
                        var areIntersecting = otherMesh.intersectsMesh(sourceMesh, false);
                        var currentIntersectionInProgress = sourceMesh._intersectionsInProgress.indexOf(otherMesh);
                        if (areIntersecting && currentIntersectionInProgress == -1 && action.trigger == ActionManager.OnIntersectionEnterTrigger) {
                            sourceMesh.actionManager.processTrigger(ActionManager.OnIntersectionEnterTrigger, ActionEvent.CreateNew(sourceMesh));
                            sourceMesh._intersectionsInProgress.push(otherMesh);
                        } else
                        if (!areIntersecting && currentIntersectionInProgress > -1 && action.trigger == ActionManager.OnIntersectionExitTrigger) {
                            sourceMesh.actionManager.processTrigger(ActionManager.OnIntersectionExitTrigger, ActionEvent.CreateNew(sourceMesh));
                            var indexOfOther = sourceMesh._intersectionsInProgress.indexOf(otherMesh);
                            if (indexOfOther > -1) {
                                sourceMesh._intersectionsInProgress.splice(indexOfOther, 1);
                            }
                        }
                    }
                }
            }
        }
        public virtual void render() {
            var startDate = new Date().getTime();
            this._particlesDuration = 0;
            this._spritesDuration = 0;
            this._activeParticles = 0;
            this._renderDuration = 0;
            this._evaluateActiveMeshesDuration = 0;
            this._totalVertices = 0;
            this._activeVertices = 0;
            this._meshesForIntersections.reset();
            if (this.actionManager) {
                this.actionManager.processTrigger(ActionManager.OnEveryFrameTrigger, null);
            }
            if (this.beforeRender) {
                this.beforeRender();
            }
            for (var callbackIndex = 0; callbackIndex < this._onBeforeRenderCallbacks.Length; callbackIndex++) {
                this._onBeforeRenderCallbacks[callbackIndex]();
            }
            var deltaTime = Math.Max(Scene.MinDeltaTime, Math.min(BABYLON.Tools.GetDeltaTime(), Scene.MaxDeltaTime));
            this._animationRatio = deltaTime * (60.0 / 1000.0);
            this._animate();
            if (this._physicsEngine) {
                this._physicsEngine._runOneStep(deltaTime / 1000.0);
            }
            this._engine.clear(this.clearColor, this.autoClear || this.forceWireframe, true);
            for (var lightIndex = 0; lightIndex < this.lights.Length; lightIndex++) {
                var light = this.lights[lightIndex];
                var shadowGenerator = light.getShadowGenerator();
                if (light.isEnabled() && shadowGenerator && shadowGenerator.getShadowMap().getScene().textures.indexOf(shadowGenerator.getShadowMap()) != -1) {
                    this._renderTargets.push(shadowGenerator.getShadowMap());
                }
            }
            this.postProcessRenderPipelineManager.update();
            if (this.activeCameras.Length > 0) {
                var currentRenderId = this._renderId;
                for (var cameraIndex = 0; cameraIndex < this.activeCameras.Length; cameraIndex++) {
                    this._renderId = currentRenderId;
                    this._processSubCameras(this.activeCameras[cameraIndex]);
                }
            } else {
                this._processSubCameras(this.activeCamera);
            }
            this._checkIntersections();
            if (this.afterRender) {
                this.afterRender();
            }
            for (var index = 0; index < this._toBeDisposed.Length; index++) {
                this._toBeDisposed.data[index].dispose();
                this._toBeDisposed[index] = null;
            }
            this._toBeDisposed.reset();
            this._lastFrameDuration = new Date().getTime() - startDate;
        }
        public virtual void dispose() {
            this.beforeRender = null;
            this.afterRender = null;
            this.skeletons = new Array < object > ();
            this._boundingBoxRenderer.dispose();
            if (this.onDispose) {
                this.onDispose();
            }
            this.detachControl();
            var canvas = this._engine.getRenderingCanvas();
            var index;
            for (index = 0; index < this.cameras.Length; index++) {
                this.cameras[index].detachControl(canvas);
            }
            while (this.lights.Length) {
                this.lights[0].dispose();
            }
            while (this.meshes.Length) {
                this.meshes[0].dispose(true);
            }
            while (this.cameras.Length) {
                this.cameras[0].dispose();
            }
            while (this.materials.Length) {
                this.materials[0].dispose();
            }
            while (this.particleSystems.Length) {
                this.particleSystems[0].dispose();
            }
            while (this.spriteManagers.Length) {
                this.spriteManagers[0].dispose();
            }
            while (this.layers.Length) {
                this.layers[0].dispose();
            }
            while (this.textures.Length) {
                this.textures[0].dispose();
            }
            this.postProcessManager.dispose();
            if (this._physicsEngine) {
                this.disablePhysicsEngine();
            }
            index = this._engine.scenes.indexOf(this);
            this._engine.scenes.splice(index, 1);
            this._engine.wipeCaches();
        }
        public virtual void _getNewPosition(Vector3 position, Vector3 velocity, Collider collider, double maximumRetry, Vector3 finalPosition, AbstractMesh excludedMesh = null) {
            position.divideToRef(collider.radius, this._scaledPosition);
            velocity.divideToRef(collider.radius, this._scaledVelocity);
            collider.retry = 0;
            collider.initialVelocity = this._scaledVelocity;
            collider.initialPosition = this._scaledPosition;
            this._collideWithWorld(this._scaledPosition, this._scaledVelocity, collider, maximumRetry, finalPosition, excludedMesh);
            finalPosition.multiplyInPlace(collider.radius);
        }
        private void _collideWithWorld(Vector3 position, Vector3 velocity, Collider collider, double maximumRetry, Vector3 finalPosition, AbstractMesh excludedMesh = null) {
            var closeDistance = BABYLON.Engine.CollisionsEpsilon * 10.0;
            if (collider.retry >= maximumRetry) {
                finalPosition.copyFrom(position);
                return;
            }
            collider._initialize(position, velocity, closeDistance);
            for (var index = 0; index < this.meshes.Length; index++) {
                var mesh = this.meshes[index];
                if (mesh.isEnabled() && mesh.checkCollisions && mesh.subMeshes && mesh != excludedMesh) {
                    mesh._checkCollision(collider);
                }
            }
            if (!collider.collisionFound) {
                position.addToRef(velocity, finalPosition);
                return;
            }
            if (velocity.x != 0 || velocity.y != 0 || velocity.z != 0) {
                collider._getResponse(position, velocity);
            }
            if (velocity.Length() <= closeDistance) {
                finalPosition.copyFrom(position);
                return;
            }
            collider.retry++;
            this._collideWithWorld(position, velocity, collider, maximumRetry, finalPosition, excludedMesh);
        }
        public virtual Octree < AbstractMesh > createOrUpdateSelectionOctree(object maxCapacity = 64, object maxDepth = 2) {
            if (!this._selectionOctree) {
                this._selectionOctree = new BABYLON.Octree < AbstractMesh > (Octree.CreationFuncForMeshes, maxCapacity, maxDepth);
            }
            var min = new BABYLON.Vector3(Number.MAX_VALUE, Number.MAX_VALUE, Number.MAX_VALUE);
            var Max = new BABYLON.Vector3(-Number.MAX_VALUE, -Number.MAX_VALUE, -Number.MAX_VALUE);
            for (var index = 0; index < this.meshes.Length; index++) {
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
        public virtual Ray createPickingRay(double x, double y, Matrix world, Camera camera) {
            var engine = this._engine;
            if (!camera) {
                if (!this.activeCamera)
                    throw new Error("Active camera not set");
                camera = this.activeCamera;
            }
            var cameraViewport = camera.viewport;
            var viewport = cameraViewport.toGlobal(engine);
            x = x / this._engine.getHardwareScalingLevel() - viewport.x;
            y = y / this._engine.getHardwareScalingLevel() - (this._engine.getRenderHeight() - viewport.y - viewport.height);
            return BABYLON.Ray.CreateNew(x, y, viewport.width, viewport.height, (world) ? world : BABYLON.Matrix.Identity(), camera.getViewMatrix(), camera.getProjectionMatrix());
        }
        private PickingInfo _internalPick(System.Func < Matrix, Ray > rayFunction, System.Func < AbstractMesh, bool > predicate, bool fastCheck = false) {
            var pickingInfo = null;
            for (var meshIndex = 0; meshIndex < this.meshes.Length; meshIndex++) {
                var mesh = this.meshes[meshIndex];
                if (predicate) {
                    if (!predicate(mesh)) {
                        continue;
                    }
                } else
                if (!mesh.isEnabled() || !mesh.isVisible || !mesh.isPickable) {
                    continue;
                }
                var world = mesh.getWorldMatrix();
                var ray = rayFunction(world);
                var result = mesh.intersects(ray, fastCheck);
                if (!result || !result.hit)
                    continue;
                if (!fastCheck && pickingInfo != null && result.distance >= pickingInfo.distance)
                    continue;
                pickingInfo = result;
                if (fastCheck) {
                    break;
                }
            }
            return pickingInfo || new BABYLON.PickingInfo();
        }
        public virtual PickingInfo pick(double x, double y, System.Func < AbstractMesh, bool > predicate = null, bool fastCheck = false, Camera camera = null) {
            return this._internalPick((world) => this.createPickingRay(x, y, world, camera), predicate, fastCheck);
        }
        public virtual void pickWithRay(Ray ray, System.Func < Mesh, bool > predicate, bool fastCheck = false) {
            return this._internalPick((world) => {
                if (!this._pickWithRayInverseMatrix) {
                    this._pickWithRayInverseMatrix = BABYLON.Matrix.Identity();
                }
                world.invertToRef(this._pickWithRayInverseMatrix);
                return BABYLON.Ray.Transform(ray, this._pickWithRayInverseMatrix);
            }, predicate, fastCheck);
        }
        public virtual void setPointerOverMesh(AbstractMesh mesh) {
            if (this._pointerOverMesh == mesh) {
                return;
            }
            if (this._pointerOverMesh && this._pointerOverMesh.actionManager) {
                this._pointerOverMesh.actionManager.processTrigger(ActionManager.OnPointerOutTrigger, ActionEvent.CreateNew(this._pointerOverMesh));
            }
            this._pointerOverMesh = mesh;
            if (this._pointerOverMesh && this._pointerOverMesh.actionManager) {
                this._pointerOverMesh.actionManager.processTrigger(ActionManager.OnPointerOverTrigger, ActionEvent.CreateNew(this._pointerOverMesh));
            }
        }
        public virtual AbstractMesh getPointerOverMesh() {
            return this._pointerOverMesh;
        }
        public virtual PhysicsEngine getPhysicsEngine() {
            return this._physicsEngine;
        }
        public virtual bool enablePhysics(Vector3 gravity, IPhysicsEnginePlugin plugin = null) {
            if (this._physicsEngine) {
                return true;
            }
            this._physicsEngine = new BABYLON.PhysicsEngine(plugin);
            if (!this._physicsEngine.isSupported()) {
                this._physicsEngine = null;
                return false;
            }
            this._physicsEngine._initialize(gravity);
            return true;
        }
        public virtual void disablePhysicsEngine() {
            if (!this._physicsEngine) {
                return;
            }
            this._physicsEngine.dispose();
            this._physicsEngine = null;
        }
        public virtual bool isPhysicsEnabled() {
            return this._physicsEngine != null;
        }
        public virtual void setGravity(Vector3 gravity) {
            if (!this._physicsEngine) {
                return;
            }
            this._physicsEngine._setGravity(gravity);
        }
        public virtual object createCompoundImpostor(object parts, PhysicsBodyCreationOptions options) {
            if (parts.parts) {
                options = parts;
                parts = parts.parts;
            }
            if (!this._physicsEngine) {
                return null;
            }
            for (var index = 0; index < parts.Length; index++) {
                var mesh = parts[index].mesh;
                mesh._physicImpostor = parts[index].impostor;
                mesh._physicsMass = options.mass / parts.Length;
                mesh._physicsFriction = options.friction;
                mesh._physicRestitution = options.restitution;
            }
            return this._physicsEngine._registerMeshesAsCompound(parts, options);
        }
        public virtual void deleteCompoundImpostor(object compound) {
            for (var index = 0; index < compound.parts.Length; index++) {
                var mesh = compound.parts[index].mesh;
                mesh._physicImpostor = BABYLON.PhysicsEngine.NoImpostor;
                this._physicsEngine._unregisterMesh(mesh);
            }
        }
        private Array < object > _getByTags(Array < object > list, string tagsQuery) {
            if (tagsQuery == null) {
                return list;
            }
            var listByTags = new Array < object > ();
            foreach(var i in list) {
                var item = list[i];
                if (BABYLON.Tags.MatchesQuery(item, tagsQuery)) {
                    listByTags.push(item);
                }
            }
            return listByTags;
        }
        public virtual Array < Mesh > getMeshesByTags(string tagsQuery) {
            return this._getByTags(this.meshes, tagsQuery);
        }
        public virtual Array < Camera > getCamerasByTags(string tagsQuery) {
            return this._getByTags(this.cameras, tagsQuery);
        }
        public virtual Array < Light > getLightsByTags(string tagsQuery) {
            return this._getByTags(this.lights, tagsQuery);
        }
        public virtual Array < Material > getMaterialByTags(string tagsQuery) {
            return this._getByTags(this.materials, tagsQuery).concat(this._getByTags(this.multiMaterials, tagsQuery));
        }
    }
}