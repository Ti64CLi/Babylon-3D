// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.layer.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    using Web;

    /// <summary>
    /// </summary>
    public partial class Layer
    {
        /// <summary>
        /// </summary>
        public Color4 color;

        /// <summary>
        /// </summary>
        public bool isBackground;

        /// <summary>
        /// </summary>
        public string name;

        /// <summary>
        /// </summary>
        public System.Action onDispose;

        /// <summary>
        /// </summary>
        public Texture texture;

        /// <summary>
        /// </summary>
        private readonly Effect _effect;

        /// <summary>
        /// </summary>
        private WebGLBuffer _indexBuffer;

        /// <summary>
        /// </summary>
        private readonly Scene _scene;

        /// <summary>
        /// </summary>
        private WebGLBuffer _vertexBuffer;

        /// <summary>
        /// </summary>
        private readonly Array<VertexBufferKind> _vertexDeclaration = new Array<VertexBufferKind>(VertexBufferKind.NormalKind);

        /// <summary>
        /// </summary>
        private int _vertexStrideSize = 2 * 4;

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="imgUrl">
        /// </param>
        /// <param name="scene">
        /// </param>
        /// <param name="isBackground">
        /// </param>
        /// <param name="color">
        /// </param>
        public Layer(string name, string imgUrl, Scene scene, bool isBackground = false, Color4 color = null)
        {
            this.name = name;
            this.texture = (imgUrl != null) ? new Texture(imgUrl, scene, true) : null;
            this.isBackground = isBackground;
            this.color = (color == null) ? new Color4(1, 1, 1, 1) : color;
            this._scene = scene;
            this._scene.layers.Add(this);
            var vertices = new Array<double>();
            vertices.Add(1, 1);
            vertices.Add(-1, 1);
            vertices.Add(-1, -1);
            vertices.Add(1, -1);
            this._vertexBuffer = scene.getEngine().createVertexBuffer(vertices);
            var indices = new Array<int>();
            indices.Add(0);
            indices.Add(1);
            indices.Add(2);
            indices.Add(0);
            indices.Add(2);
            indices.Add(3);
            this._indexBuffer = scene.getEngine().createIndexBuffer(indices);
            this._effect = this._scene.getEngine()
                               .createEffect(
                                   new EffectBaseName { baseName = "layer" }, 
                                   new Array<string>("position"), 
                                   new Array<string>("textureMatrix", "color"), 
                                   new Array<string>("textureSampler"), 
                                   string.Empty);
        }

        /// <summary>
        /// </summary>
        public virtual void dispose()
        {
            if (this._vertexBuffer != null)
            {
                this._scene.getEngine()._releaseBuffer(this._vertexBuffer);
                this._vertexBuffer = null;
            }

            if (this._indexBuffer != null)
            {
                this._scene.getEngine()._releaseBuffer(this._indexBuffer);
                this._indexBuffer = null;
            }

            if (this.texture != null)
            {
                this.texture.dispose();
                this.texture = null;
            }

            var index = this._scene.layers.IndexOf(this);
            this._scene.layers.RemoveAt(index);
            if (this.onDispose != null)
            {
                this.onDispose();
            }
        }

        /// <summary>
        /// </summary>
        public virtual void render()
        {
            if (!this._effect.isReady() || this.texture == null || !this.texture.isReady())
            {
                return;
            }

            var engine = this._scene.getEngine();
            engine.enableEffect(this._effect);
            engine.setState(false);
            this._effect.setTexture("textureSampler", this.texture);
            this._effect.setMatrix("textureMatrix", this.texture.getTextureMatrix());
            this._effect.setFloat4("color", this.color.r, this.color.g, this.color.b, this.color.a);
            engine.bindBuffers(this._vertexBuffer, this._indexBuffer, this._vertexDeclaration, this._vertexStrideSize, this._effect);
            engine.setAlphaMode(Engine.ALPHA_COMBINE);
            engine.draw(true, 0, 6);
            engine.setAlphaMode(Engine.ALPHA_DISABLE);
        }
    }
}