// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.spriteManager.cs" company="">
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
    public partial class SpriteManager
    {
        /// <summary>
        /// </summary>
        public int cellSize;

        /// <summary>
        /// </summary>
        public string name;

        /// <summary>
        /// </summary>
        public System.Action onDispose;

        /// <summary>
        /// </summary>
        public double renderingGroupId = 0;

        /// <summary>
        /// </summary>
        public Array<Sprite> sprites = new Array<Sprite>();

        /// <summary>
        /// </summary>
        private readonly int _capacity;

        /// <summary>
        /// </summary>
        private readonly Effect _effectBase;

        /// <summary>
        /// </summary>
        private readonly Effect _effectFog;

        /// <summary>
        /// </summary>
        private readonly double _epsilon;

        /// <summary>
        /// </summary>
        private WebGLBuffer _indexBuffer;

        /// <summary>
        /// </summary>
        private readonly Scene _scene;

        /// <summary>
        /// </summary>
        private Texture _spriteTexture;

        /// <summary>
        /// </summary>
        private WebGLBuffer _vertexBuffer;

        /// <summary>
        /// </summary>
        private readonly Array<VertexBufferKind> _vertexDeclaration = new Array<VertexBufferKind>(
            VertexBufferKind.UVKind, VertexBufferKind.UV2Kind, VertexBufferKind.UV2Kind, VertexBufferKind.UV2Kind);

        /// <summary>
        /// </summary>
        private readonly int _vertexStrideSize = 15 * 4;

        /// <summary>
        /// </summary>
        private readonly double[] _vertices;

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="imgUrl">
        /// </param>
        /// <param name="capacity">
        /// </param>
        /// <param name="cellSize">
        /// </param>
        /// <param name="scene">
        /// </param>
        /// <param name="epsilon">
        /// </param>
        public SpriteManager(string name, string imgUrl, int capacity, int cellSize, Scene scene, double epsilon = 0.01)
        {
            this.name = name;
            this.cellSize = cellSize;
            this._capacity = capacity;
            this._spriteTexture = new Texture(imgUrl, scene, true, false);
            this._spriteTexture.wrapU = Texture.CLAMP_ADDRESSMODE;
            this._spriteTexture.wrapV = Texture.CLAMP_ADDRESSMODE;
            this._epsilon = epsilon;
            this._scene = scene;
            this._scene.spriteManagers.Add(this);
            this._vertexDeclaration = new Array<VertexBufferKind>(
                VertexBufferKind.UVKind, VertexBufferKind.UV2Kind, VertexBufferKind.UV2Kind, VertexBufferKind.UV2Kind);
            this._vertexStrideSize = 15 * 4;
            this._vertexBuffer = scene.getEngine().createDynamicVertexBuffer(capacity * this._vertexStrideSize * 4);
            var indices = new Array<int>();
            var index = 0;
            for (var count = 0; count < capacity; count++)
            {
                indices.Add(index);
                indices.Add(index + 1);
                indices.Add(index + 2);
                indices.Add(index);
                indices.Add(index + 2);
                indices.Add(index + 3);
                index += 4;
            }

            this._indexBuffer = scene.getEngine().createIndexBuffer(indices);
            this._vertices = new double[capacity * this._vertexStrideSize];
            this._effectBase = this._scene.getEngine()
                                   .createEffect(
                                       new EffectBaseName { baseName = "sprites" }, 
                                       new Array<string>("position", "options", "cellInfo", "color"), 
                                       new Array<string>("view", "projection", "textureInfos", "alphaTest"), 
                                       new Array<string>("diffuseSampler"), 
                                       string.Empty);
            this._effectFog = this._scene.getEngine()
                                  .createEffect(
                                      new EffectBaseName { baseName = "sprites" }, 
                                      new Array<string>("position", "options", "cellInfo", "color"), 
                                      new Array<string>("view", "projection", "textureInfos", "alphaTest", "vFogInfos", "vFogColor"), 
                                      new Array<string>("diffuseSampler"), 
                                      "#define FOG");
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

            if (this._spriteTexture != null)
            {
                this._spriteTexture.dispose();
                this._spriteTexture = null;
            }

            var index = this._scene.spriteManagers.IndexOf(this);
            this._scene.spriteManagers.RemoveAt(index);
            if (this.onDispose != null)
            {
                this.onDispose();
            }
        }

        /// <summary>
        /// </summary>
        public virtual void render()
        {
            if (!this._effectBase.isReady() || !this._effectFog.isReady() || this._spriteTexture == null || !this._spriteTexture.isReady())
            {
                return;
            }

            var engine = this._scene.getEngine();
            var baseSize = this._spriteTexture.getBaseSize();
            var deltaTime = Tools.GetDeltaTime();
            var max = Math.Min(this._capacity, this.sprites.Length);
            var rowSize = baseSize.width / this.cellSize;
            var offset = 0;
            for (var index = 0; index < max; index++)
            {
                var sprite = this.sprites[index];
                if (sprite == null)
                {
                    continue;
                }

                sprite._animate(deltaTime);
                this._appendSpriteVertex(offset++, sprite, 0, 0, rowSize);
                this._appendSpriteVertex(offset++, sprite, 1, 0, rowSize);
                this._appendSpriteVertex(offset++, sprite, 1, 1, rowSize);
                this._appendSpriteVertex(offset++, sprite, 0, 1, rowSize);
            }

            engine.updateDynamicVertexBuffer(this._vertexBuffer, this._vertices, max * this._vertexStrideSize);
            var effect = this._effectBase;
            if (this._scene.fogMode != Scene.FOGMODE_NONE)
            {
                effect = this._effectFog;
            }

            engine.enableEffect(effect);
            var viewMatrix = this._scene.getViewMatrix();
            effect.setTexture("diffuseSampler", this._spriteTexture);
            effect.setMatrix("view", viewMatrix);
            effect.setMatrix("projection", this._scene.getProjectionMatrix());
            effect.setFloat2("textureInfos", this.cellSize / baseSize.width, this.cellSize / baseSize.height);
            if (this._scene.fogMode != Scene.FOGMODE_NONE)
            {
                effect.setFloat4("vFogInfos", this._scene.fogMode, this._scene.fogStart, this._scene.fogEnd, this._scene.fogDensity);
                effect.setColor3("vFogColor", this._scene.fogColor);
            }

            engine.bindBuffers(this._vertexBuffer, this._indexBuffer, this._vertexDeclaration, this._vertexStrideSize, effect);
            effect.setBool("alphaTest", true);
            engine.setColorWrite(false);
            engine.draw(true, 0, max * 6);
            engine.setColorWrite(true);
            effect.setBool("alphaTest", false);
            engine.setAlphaMode(Engine.ALPHA_COMBINE);
            engine.draw(true, 0, max * 6);
            engine.setAlphaMode(Engine.ALPHA_DISABLE);
        }

        /// <summary>
        /// </summary>
        /// <param name="index">
        /// </param>
        /// <param name="sprite">
        /// </param>
        /// <param name="offsetX">
        /// </param>
        /// <param name="offsetY">
        /// </param>
        /// <param name="rowSize">
        /// </param>
        private void _appendSpriteVertex(int index, Sprite sprite, double offsetX, double offsetY, int rowSize)
        {
            var arrayOffset = index * 15;
            if (offsetX == 0)
            {
                offsetX = this._epsilon;
            }
            else if (offsetX == 1)
            {
                offsetX = 1 - this._epsilon;
            }

            if (offsetY == 0)
            {
                offsetY = this._epsilon;
            }
            else if (offsetY == 1)
            {
                offsetY = 1 - this._epsilon;
            }

            this._vertices[arrayOffset] = sprite.position.x;
            this._vertices[arrayOffset + 1] = sprite.position.y;
            this._vertices[arrayOffset + 2] = sprite.position.z;
            this._vertices[arrayOffset + 3] = sprite.angle;
            this._vertices[arrayOffset + 4] = sprite.size;
            this._vertices[arrayOffset + 5] = offsetX;
            this._vertices[arrayOffset + 6] = offsetY;
            this._vertices[arrayOffset + 7] = sprite.invertU ? 1 : 0;
            this._vertices[arrayOffset + 8] = sprite.invertV ? 1 : 0;
            var offset = (sprite.cellIndex / rowSize) << 0;
            this._vertices[arrayOffset + 9] = sprite.cellIndex - offset * rowSize;
            this._vertices[arrayOffset + 10] = offset;
            this._vertices[arrayOffset + 11] = sprite.color.r;
            this._vertices[arrayOffset + 12] = sprite.color.g;
            this._vertices[arrayOffset + 13] = sprite.color.b;
            this._vertices[arrayOffset + 14] = sprite.color.a;
        }
    }
}