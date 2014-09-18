// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.renderTargetTexture.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    using System;

    /// <summary>
    /// </summary>
    public partial class RenderTargetTexture : Texture
    {
        /// <summary>
        /// </summary>
        public bool _generateMipMaps;

        /// <summary>
        /// </summary>
        public Array<string> _waitingRenderList;

        /// <summary>
        /// </summary>
        public Action<SmartArray<SubMesh>, SmartArray<SubMesh>, SmartArray<SubMesh>, System.Action> customRenderFunction;

        /// <summary>
        /// </summary>
        public System.Action onAfterRender;

        /// <summary>
        /// </summary>
        public System.Action onBeforeRender;

        /// <summary>
        /// </summary>
        public Array<AbstractMesh> renderList = new Array<AbstractMesh>();

        /// <summary>
        /// </summary>
        public bool renderParticles = true;

        /// <summary>
        /// </summary>
        public bool renderSprites = false;

        /// <summary>
        /// </summary>
        private double _currentRefreshId = -1;

        /// <summary>
        /// </summary>
        private readonly bool _doNotChangeAspectRatio;

        /// <summary>
        /// </summary>
        private double _refreshRate = 1;

        /// <summary>
        /// </summary>
        private readonly RenderingManager _renderingManager;

        /// <summary>
        /// </summary>
        private readonly Size _size;

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="size">
        /// </param>
        /// <param name="scene">
        /// </param>
        /// <param name="generateMipMaps">
        /// </param>
        /// <param name="doNotChangeAspectRatio">
        /// </param>
        public RenderTargetTexture(string name, Size size, Scene scene, bool generateMipMaps = false, bool doNotChangeAspectRatio = true)
            : base(null, scene, !generateMipMaps)
        {
            this.coordinatesMode = PROJECTION_MODE;
            this.name = name;
            this.isRenderTarget = true;
            this._size = size;
            this._generateMipMaps = generateMipMaps;
            this._doNotChangeAspectRatio = doNotChangeAspectRatio;
            this._texture = scene.getEngine().createRenderTargetTexture(size, generateMipMaps);
            this._renderingManager = new RenderingManager(scene);
        }

        /// <summary>
        /// </summary>
        public virtual double refreshRate
        {
            get
            {
                return this._refreshRate;
            }

            set
            {
                this._refreshRate = value;
                this.resetRefreshCounter();
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual bool _shouldRender()
        {
            if (this._currentRefreshId == -1)
            {
                this._currentRefreshId = 1;
                return true;
            }

            if (this.refreshRate == this._currentRefreshId)
            {
                this._currentRefreshId = 1;
                return true;
            }

            this._currentRefreshId++;
            return false;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override BaseTexture clone()
        {
            var textureSize = this.getSize();
            var newTexture = new RenderTargetTexture(this.name, textureSize, this.getScene(), this._generateMipMaps);
            newTexture.hasAlpha = this.hasAlpha;
            newTexture.level = this.level;
            newTexture.coordinatesMode = this.coordinatesMode;
            newTexture.renderList = this.renderList.slice(0);
            return newTexture;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Size getRenderSize()
        {
            return this._size;
        }

        /// <summary>
        /// </summary>
        /// <param name="useCameraPostProcess">
        /// </param>
        public virtual void render(bool useCameraPostProcess = false)
        {
            var scene = this.getScene();
            var engine = scene.getEngine();
            if (this._waitingRenderList != null)
            {
                this.renderList = new Array<AbstractMesh>();
                for (var index = 0; index < this._waitingRenderList.Length; index++)
                {
                    var id = this._waitingRenderList[index];
                    this.renderList.Add(scene.getMeshByID(id));
                }

                this._waitingRenderList = null;
            }

            if (this.renderList == null || this.renderList.Length == 0)
            {
                return;
            }

            if (!useCameraPostProcess || !scene.postProcessManager._prepareFrame(this._texture))
            {
                engine.bindFramebuffer(this._texture);
            }

            engine.clear(scene.clearColor, true, true);
            this._renderingManager.reset();
            for (var meshIndex = 0; meshIndex < this.renderList.Length; meshIndex++)
            {
                var mesh = this.renderList[meshIndex];
                if (mesh != null)
                {
                    if (!mesh.isReady() || (mesh.material != null && !mesh.material.isReady()))
                    {
                        this.resetRefreshCounter();
                        continue;
                    }

                    if (mesh.isEnabled() && mesh.isVisible && mesh.subMeshes != null && ((mesh.layerMask & scene.activeCamera.layerMask) != 0))
                    {
                        mesh._activate(scene.getRenderId());
                        for (var subIndex = 0; subIndex < mesh.subMeshes.Length; subIndex++)
                        {
                            var subMesh = mesh.subMeshes[subIndex];
                            scene._activeVertices += subMesh.verticesCount;
                            this._renderingManager.dispatch(subMesh);
                        }
                    }
                }
            }

            if (!this._doNotChangeAspectRatio)
            {
                scene.updateTransformMatrix(true);
            }

            if (this.onBeforeRender != null)
            {
                this.onBeforeRender();
            }

            this._renderingManager.render(this.customRenderFunction, this.renderList, this.renderParticles, this.renderSprites);
            if (useCameraPostProcess)
            {
                scene.postProcessManager._finalizeFrame(false, this._texture);
            }

            if (this.onAfterRender != null)
            {
                this.onAfterRender();
            }

            engine.unBindFramebuffer(this._texture);
            if (!this._doNotChangeAspectRatio)
            {
                scene.updateTransformMatrix(true);
            }
        }

        /// <summary>
        /// </summary>
        public virtual void resetRefreshCounter()
        {
            this._currentRefreshId = -1;
        }

        /// <summary>
        /// </summary>
        /// <param name="size">
        /// </param>
        /// <param name="generateMipMaps">
        /// </param>
        public virtual void resize(Size size, bool generateMipMaps)
        {
            this.releaseInternalTexture();
            this._texture = this.getScene().getEngine().createRenderTargetTexture(size, generateMipMaps: generateMipMaps);
        }
    }
}