// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.postProcessRenderPass.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    /// <summary>
    /// </summary>
    public partial class PostProcessRenderPass
    {
        /// <summary>
        /// </summary>
        public string _name;

        /// <summary>
        /// </summary>
        private double _refCount;

        /// <summary>
        /// </summary>
        private readonly Array<AbstractMesh> _renderList = new Array<AbstractMesh>();

        /// <summary>
        /// </summary>
        private readonly RenderTargetTexture _renderTexture;

        /// <summary>
        /// </summary>
        private readonly Scene _scene;

        /// <summary>
        /// </summary>
        /// <param name="scene">
        /// </param>
        /// <param name="name">
        /// </param>
        /// <param name="size">
        /// </param>
        /// <param name="renderList">
        /// </param>
        /// <param name="beforeRender">
        /// </param>
        /// <param name="afterRender">
        /// </param>
        public PostProcessRenderPass(Scene scene, string name, Size size, Array<AbstractMesh> renderList, System.Action beforeRender, System.Action afterRender)
        {
            this._name = name;
            this._renderTexture = new RenderTargetTexture(name, size, scene);
            this.setRenderList(renderList);
            this._renderTexture.onBeforeRender = beforeRender;
            this._renderTexture.onAfterRender = afterRender;
            this._scene = scene;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual double _decRefCount()
        {
            this._refCount--;
            if (this._refCount <= 0)
            {
                this._scene.customRenderTargets.RemoveAt(this._scene.customRenderTargets.IndexOf(this._renderTexture));
            }

            return this._refCount;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual double _incRefCount()
        {
            if (this._refCount == 0)
            {
                this._scene.customRenderTargets.Add(this._renderTexture);
            }

            return ++this._refCount;
        }

        /// <summary>
        /// </summary>
        public virtual void _update()
        {
            this.setRenderList(this._renderList);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual RenderTargetTexture getRenderTexture()
        {
            return this._renderTexture;
        }

        /// <summary>
        /// </summary>
        /// <param name="renderList">
        /// </param>
        public virtual void setRenderList(Array<AbstractMesh> renderList)
        {
            this._renderTexture.renderList = renderList;
        }
    }
}