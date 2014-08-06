// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.renderingManager.cs" company="">
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
    public partial class RenderingManager
    {
        /// <summary>
        /// </summary>
        private bool _depthBufferAlreadyCleaned;

        /// <summary>
        /// </summary>
        private readonly Array<RenderingGroup> _renderingGroups = new Array<RenderingGroup>();

        /// <summary>
        /// </summary>
        private readonly Scene _scene;

        /// <summary>
        /// </summary>
        /// <param name="scene">
        /// </param>
        public RenderingManager(Scene scene)
        {
            this._scene = scene;
        }

        /// <summary>
        /// </summary>
        /// <param name="subMesh">
        /// </param>
        public virtual void dispatch(SubMesh subMesh)
        {
            var mesh = subMesh.getMesh();
            var renderingGroupId = mesh.renderingGroupId;

            if (this._renderingGroups[renderingGroupId] == null)
            {
                this._renderingGroups[renderingGroupId] = new RenderingGroup(renderingGroupId, this._scene);
            }

            this._renderingGroups[renderingGroupId].dispatch(subMesh);
        }

        /// <summary>
        /// </summary>
        /// <param name="customRenderFunction">
        /// </param>
        /// <param name="activeMeshes">
        /// </param>
        /// <param name="renderParticles">
        /// </param>
        /// <param name="renderSprites">
        /// </param>
        public virtual void render(
            Action<SmartArray<SubMesh>, SmartArray<SubMesh>, SmartArray<SubMesh>, System.Action> customRenderFunction, 
            Array<AbstractMesh> activeMeshes, 
            bool renderParticles, 
            bool renderSprites)
        {
            for (var index = 0; index < MAX_RENDERINGGROUPS; index++)
            {
                this._depthBufferAlreadyCleaned = false;
                var renderingGroup = index < this._renderingGroups.Length ? this._renderingGroups[index] : null;
                if (renderingGroup != null)
                {
                    this._clearDepthBuffer();
                    if (!renderingGroup.render(
                        customRenderFunction, 
                        () =>
                            {
                                if (renderSprites)
                                {
                                    this._renderSprites(index);
                                }
                            }))
                    {
                        this._renderingGroups.RemoveAt(index);
                    }
                }
                else if (renderSprites)
                {
                    this._renderSprites(index);
                }

                if (renderParticles)
                {
                    this._renderParticles(index, activeMeshes);
                }
            }
        }

        /// <summary>
        /// </summary>
        public virtual void reset()
        {
            for (var index = 0; index < this._renderingGroups.Length; index++)
            {
                var renderingGroup = this._renderingGroups[index];
                renderingGroup.prepare();
            }
        }

        /// <summary>
        /// </summary>
        private void _clearDepthBuffer()
        {
            if (this._depthBufferAlreadyCleaned)
            {
                return;
            }

            this._scene.getEngine().clear(new Color3(0, 0, 0), false, true);
            this._depthBufferAlreadyCleaned = true;
        }

        /// <summary>
        /// </summary>
        /// <param name="index">
        /// </param>
        /// <param name="activeMeshes">
        /// </param>
        private void _renderParticles(double index, Array<AbstractMesh> activeMeshes)
        {
            if (this._scene._activeParticleSystems.Length == 0)
            {
                return;
            }

            var beforeParticlesDate = new Date().getTime();
            for (var particleIndex = 0; particleIndex < this._scene._activeParticleSystems.Length; particleIndex++)
            {
                var particleSystem = this._scene._activeParticleSystems[particleIndex];
                if (particleSystem.renderingGroupId != index)
                {
                    continue;
                }

                this._clearDepthBuffer();
                if (((Mesh)particleSystem.emitter).position == null || activeMeshes == null || activeMeshes.IndexOf((Mesh)particleSystem.emitter) != -1)
                {
                    this._scene._activeParticles += particleSystem.render();
                }
            }

            this._scene._particlesDuration += new Date().getTime() - beforeParticlesDate;
        }

        /// <summary>
        /// </summary>
        /// <param name="index">
        /// </param>
        private void _renderSprites(double index)
        {
            if (this._scene.spriteManagers.Length == 0)
            {
                return;
            }

            var beforeSpritessDate = new Date().getTime();
            for (var id = 0; id < this._scene.spriteManagers.Length; id++)
            {
                var spriteManager = this._scene.spriteManagers[id];
                if (spriteManager.renderingGroupId == index)
                {
                    this._clearDepthBuffer();
                    spriteManager.render();
                }
            }

            this._scene._spritesDuration += new Date().getTime() - beforeSpritessDate;
        }

        /// <summary>
        /// </summary>
        public const int MAX_RENDERINGGROUPS = 4;
    }
}