using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class RenderingManager
    {
        public
        const int MAX_RENDERINGGROUPS = 4;
        private Scene _scene;
        private Array<RenderingGroup> _renderingGroups = new Array<RenderingGroup>();
        private bool _depthBufferAlreadyCleaned;
        public RenderingManager(Scene scene)
        {
            this._scene = scene;
        }
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
                if (((Mesh)particleSystem.emitter).position == null || activeMeshes == null || activeMeshes.indexOf((Mesh)particleSystem.emitter) != -1)
                {
                    this._scene._activeParticles += particleSystem.render();
                }
            }
            this._scene._particlesDuration += new Date().getTime() - beforeParticlesDate;
        }
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
        private void _clearDepthBuffer()
        {
            if (this._depthBufferAlreadyCleaned)
            {
                return;
            }
            this._scene.getEngine().clear(new Color3(0, 0, 0), false, true);
            this._depthBufferAlreadyCleaned = true;
        }
        public virtual void render(System.Action<SmartArray<SubMesh>, SmartArray<SubMesh>, SmartArray<SubMesh>, System.Action> customRenderFunction, Array<AbstractMesh> activeMeshes, bool renderParticles, bool renderSprites)
        {
            for (var index = 0; index < BABYLON.RenderingManager.MAX_RENDERINGGROUPS; index++)
            {
                this._depthBufferAlreadyCleaned = false;
                var renderingGroup = index < this._renderingGroups.Length ? this._renderingGroups[index] : null;
                if (renderingGroup != null)
                {
                    this._clearDepthBuffer();
                    if (!renderingGroup.render(customRenderFunction, () =>
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
                else
                    if (renderSprites)
                    {
                        this._renderSprites(index);
                    }
                if (renderParticles)
                {
                    this._renderParticles(index, activeMeshes);
                }
            }
        }
        public virtual void reset()
        {
            for (var index = 0; index < this._renderingGroups.Length; index++)
            {
                var renderingGroup = this._renderingGroups[index];
                renderingGroup.prepare();
            }
        }
        public virtual void dispatch(SubMesh subMesh)
        {
            var mesh = subMesh.getMesh();
            var renderingGroupId = mesh.renderingGroupId;
            if (this._renderingGroups[renderingGroupId] == null)
            {
                this._renderingGroups[renderingGroupId] = new BABYLON.RenderingGroup(renderingGroupId, this._scene);
            }
            this._renderingGroups[renderingGroupId].dispatch(subMesh);
        }
    }
}