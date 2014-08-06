// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.boundingBoxRenderer.cs" company="">
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
    public partial class BoundingBoxRenderer
    {
        /// <summary>
        /// </summary>
        public Color3 backColor = new Color3(0.1, 0.1, 0.1);

        /// <summary>
        /// </summary>
        public Color3 frontColor = new Color3(1, 1, 1);

        /// <summary>
        /// </summary>
        public SmartArray<BoundingBox> renderList = new SmartArray<BoundingBox>(32);

        /// <summary>
        /// </summary>
        public bool showBackLines = true;

        /// <summary>
        /// </summary>
        private readonly ShaderMaterial _colorShader;

        /// <summary>
        /// </summary>
        private readonly WebGLBuffer _ib;

        /// <summary>
        /// </summary>
        private readonly Scene _scene;

        /// <summary>
        /// </summary>
        private readonly VertexBuffer _vb;

        /// <summary>
        /// </summary>
        /// <param name="scene">
        /// </param>
        public BoundingBoxRenderer(Scene scene)
        {
            this._scene = scene;
            this._colorShader = new ShaderMaterial(
                "colorShader", 
                scene, 
                "color", 
                new ShaderMaterialOptions { attributes = new Array<string>("position"), uniforms = new Array<string>("worldViewProjection", "color") });
            var engine = this._scene.getEngine();
            var boxdata = VertexData.CreateBox(1.0);
            this._vb = new VertexBuffer(engine, boxdata.positions, VertexBufferKind.PositionKind, false);
            this._ib = engine.createIndexBuffer(new Array<int>(0, 1, 1, 2, 2, 3, 3, 0, 4, 5, 5, 6, 6, 7, 7, 4, 0, 7, 1, 6, 2, 5, 3, 4));
        }

        /// <summary>
        /// </summary>
        public virtual void dispose()
        {
            this._colorShader.dispose();
            this._vb.dispose();
            this._scene.getEngine()._releaseBuffer(this._ib);
        }

        /// <summary>
        /// </summary>
        public virtual void render()
        {
            if (this.renderList.Length == 0 || !this._colorShader.isReady())
            {
                return;
            }

            var engine = this._scene.getEngine();
            engine.setDepthWrite(false);
            this._colorShader._preBind();
            for (var boundingBoxIndex = 0; boundingBoxIndex < this.renderList.Length; boundingBoxIndex++)
            {
                var boundingBox = this.renderList[boundingBoxIndex];
                var min = boundingBox.minimum;
                var Max = boundingBox.maximum;
                var diff = Max.subtract(min);
                var median = min.add(diff.scale(0.5));
                var worldMatrix =
                    Matrix.Scaling(diff.x, diff.y, diff.z).multiply(Matrix.Translation(median.x, median.y, median.z)).multiply(boundingBox.getWorldMatrix());
                engine.bindBuffers(this._vb.getBuffer(), this._ib, new Array<VertexBufferKind>(VertexBufferKind.UVKind), 3 * 4, this._colorShader.getEffect());
                if (this.showBackLines)
                {
                    engine.setDepthFunctionToGreaterOrEqual();
                    this._colorShader.setColor3("color", this.backColor);
                    this._colorShader.bind(worldMatrix);
                    engine.draw(false, 0, 24);
                }

                engine.setDepthFunctionToLess();
                this._colorShader.setColor3("color", this.frontColor);
                this._colorShader.bind(worldMatrix);
                engine.draw(false, 0, 24);
            }

            this._colorShader.unbind();
            engine.setDepthFunctionToLessOrEqual();
            engine.setDepthWrite(true);
        }

        /// <summary>
        /// </summary>
        public virtual void reset()
        {
            this.renderList.reset();
        }
    }
}