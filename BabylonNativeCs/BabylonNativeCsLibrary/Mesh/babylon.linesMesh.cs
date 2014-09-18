// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.linesMesh.cs" company="">
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
    public partial class LinesMesh : Mesh
    {
        /// <summary>
        /// </summary>
        public Color3 color = new Color3(1, 1, 1);

        /// <summary>
        /// </summary>
        private readonly ShaderMaterial _colorShader;

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="scene">
        /// </param>
        public LinesMesh(string name, Scene scene)
            : base(name, scene)
        {
            this._colorShader = new ShaderMaterial(
                "colorShader", 
                scene, 
                "color", 
                new ShaderMaterialOptions { attributes = new Array<string>("position"), uniforms = new Array<string>("worldViewProjection", "color") });
        }

        /// <summary>
        /// </summary>
        public override bool checkCollisions
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// </summary>
        public override bool isPickable
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// </summary>
        public override Material material
        {
            get
            {
                return this._colorShader;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="subMesh">
        /// </param>
        /// <param name="effect">
        /// </param>
        /// <param name="wireframe">
        /// </param>
        public override void _bind(SubMesh subMesh, Effect effect, bool wireframe = false)
        {
            var engine = this.getScene().getEngine();
            var indexToBind = this._geometry.getIndexBuffer();
            engine.bindBuffers(
                this._geometry.getVertexBuffer(VertexBufferKind.PositionKind).getBuffer(), 
                indexToBind, 
                new Array<VertexBufferKind>(VertexBufferKind.UVKind), 
                3 * 4, 
                this._colorShader.getEffect());
            this._colorShader.setColor3("color", this.color);
        }

        /// <summary>
        /// </summary>
        /// <param name="subMesh">
        /// </param>
        /// <param name="useTriangles">
        /// </param>
        /// <param name="instancesCount">
        /// </param>
        public override void _draw(SubMesh subMesh, bool useTriangles, int instancesCount = 0)
        {
            if (this._geometry == null || this._geometry.getVertexBuffers() == null || this._geometry.getIndexBuffer() == null)
            {
                return;
            }

            var engine = this.getScene().getEngine();
            engine.draw(false, subMesh.indexStart, subMesh.indexCount);
        }

        /// <summary>
        /// </summary>
        /// <param name="doNotRecurse">
        /// </param>
        public override void dispose(bool doNotRecurse = false)
        {
            this._colorShader.dispose();
            base.dispose(doNotRecurse);
        }

        /// <summary>
        /// </summary>
        /// <param name="ray">
        /// </param>
        /// <param name="fastCheck">
        /// </param>
        /// <returns>
        /// </returns>
        public override PickingInfo intersects(Ray ray, bool fastCheck = false)
        {
            return null;
        }
    }
}