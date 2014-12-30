// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.renderingGroup.cs" company="">
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
    public partial class RenderingGroup
    {
        /// <summary>
        /// </summary>
        public double index;

        /// <summary>
        /// </summary>
        private double _activeVertices;

        /// <summary>
        /// </summary>
        private readonly SmartArray<SubMesh> _alphaTestSubMeshes = new SmartArray<SubMesh>(256);

        /// <summary>
        /// </summary>
        private readonly SmartArray<SubMesh> _opaqueSubMeshes = new SmartArray<SubMesh>(256);

        /// <summary>
        /// </summary>
        private readonly Scene _scene;

        /// <summary>
        /// </summary>
        private readonly SmartArray<SubMesh> _transparentSubMeshes = new SmartArray<SubMesh>(256);

        /// <summary>
        /// </summary>
        /// <param name="index">
        /// </param>
        /// <param name="scene">
        /// </param>
        public RenderingGroup(double index, Scene scene)
        {
            this.index = index;
            this._scene = scene;
        }

        /// <summary>
        /// </summary>
        /// <param name="subMesh">
        /// </param>
        public virtual void dispatch(SubMesh subMesh)
        {
            var material = subMesh.getMaterial();
            var mesh = subMesh.getMesh();
            if (material.needAlphaBlending() || mesh.visibility < 1.0)
            {
                if (material.alpha > 0 || mesh.visibility < 1.0)
                {
                    this._transparentSubMeshes.Add(subMesh);
                }
            }
            else if (material.needAlphaTesting())
            {
                this._alphaTestSubMeshes.Add(subMesh);
            }
            else
            {
                this._opaqueSubMeshes.Add(subMesh);
            }
        }

        /// <summary>
        /// </summary>
        public virtual void prepare()
        {
            this._opaqueSubMeshes.reset();
            this._transparentSubMeshes.reset();
            this._alphaTestSubMeshes.reset();
        }

        /// <summary>
        /// </summary>
        /// <param name="customRenderFunction">
        /// </param>
        /// <param name="beforeTransparents">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool render(
            Action<SmartArray<SubMesh>, SmartArray<SubMesh>, SmartArray<SubMesh>, System.Action> customRenderFunction, System.Action beforeTransparents)
        {
            if (customRenderFunction != null)
            {
                customRenderFunction(this._opaqueSubMeshes, this._alphaTestSubMeshes, this._transparentSubMeshes, beforeTransparents);
                return true;
            }

            if (this._opaqueSubMeshes.Length == 0 && this._alphaTestSubMeshes.Length == 0 && this._transparentSubMeshes.Length == 0)
            {
                return false;
            }

            var engine = this._scene.getEngine();
            SubMesh submesh;
            for (var subIndex = 0; subIndex < this._opaqueSubMeshes.Length; subIndex++)
            {
                submesh = this._opaqueSubMeshes[subIndex];
                this._activeVertices += submesh.verticesCount;
                submesh.render();
            }

            engine.setAlphaTesting(true);
            for (var subIndex = 0; subIndex < this._alphaTestSubMeshes.Length; subIndex++)
            {
                submesh = this._alphaTestSubMeshes[subIndex];
                this._activeVertices += submesh.verticesCount;
                submesh.render();
            }

            engine.setAlphaTesting(false);
            if (beforeTransparents != null)
            {
                beforeTransparents();
            }

            if (this._transparentSubMeshes.Length > 0)
            {
                for (var subIndex = 0; subIndex < this._transparentSubMeshes.Length; subIndex++)
                {
                    submesh = this._transparentSubMeshes[subIndex];
                    submesh._distanceToCamera = submesh.getBoundingInfo().boundingSphere.centerWorld.subtract(this._scene.activeCamera.position).Length();
                }

                var sortedArray = this._transparentSubMeshes.slice(0, this._transparentSubMeshes.Length);
                sortedArray.Sort(
                    (SubMesh a, SubMesh b) =>
                        {
                            if (a == b)
                            {
                                return 0;
                            }

                            if (a == null)
                            {
                                return 1;
                            }

                            if (b == null)
                            {
                                return -1;
                            }

                            if (a._distanceToCamera < b._distanceToCamera)
                            {
                                return 1;
                            }

                            if (a._distanceToCamera > b._distanceToCamera)
                            {
                                return -1;
                            }

                            return 0;
                        });
                engine.setAlphaMode(Engine.ALPHA_COMBINE);
                for (var subIndex = 0; subIndex < sortedArray.Length; subIndex++)
                {
                    submesh = sortedArray[subIndex];
                    this._activeVertices += submesh.verticesCount;
                    submesh.render();
                }

                engine.setAlphaMode(Engine.ALPHA_DISABLE);
            }

            return true;
        }
    }
}