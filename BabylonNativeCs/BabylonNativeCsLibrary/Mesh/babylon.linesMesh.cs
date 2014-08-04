using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class LinesMesh : Mesh
    {
        public BABYLON.Color3 color = new BABYLON.Color3(1, 1, 1);
        private ShaderMaterial _colorShader;
        public LinesMesh(string name, Scene scene)
            : base(name, scene)
        {
            this._colorShader = new ShaderMaterial("colorShader", scene, "color", new ShaderMaterialOptions
            {
                attributes = new Array<string>("position"),
                uniforms = new Array<string>("worldViewProjection", "color")
            });
        }
        public override Material material
        {
            get
            {
                return this._colorShader;
            }
        }
        public override bool isPickable
        {
            get
            {
                return false;
            }
        }
        public override bool checkCollisions
        {
            get
            {
                return false;
            }
        }
        public override void _bind(SubMesh subMesh, Effect effect, bool wireframe = false)
        {
            var engine = this.getScene().getEngine();
            var indexToBind = this._geometry.getIndexBuffer();
            engine.bindBuffers(this._geometry.getVertexBuffer(VertexBufferKind.PositionKind).getBuffer(), indexToBind, new Array<VertexBufferKind>(VertexBufferKind.UVKind), 3 * 4, this._colorShader.getEffect());
            this._colorShader.setColor3("color", this.color);
        }
        public override void _draw(SubMesh subMesh, bool useTriangles, int instancesCount = 0)
        {
            if (this._geometry == null || this._geometry.getVertexBuffers() == null || this._geometry.getIndexBuffer() == null)
            {
                return;
            }
            var engine = this.getScene().getEngine();
            engine.draw(false, subMesh.indexStart, subMesh.indexCount);
        }
        public override PickingInfo intersects(Ray ray, bool fastCheck = false)
        {
            return null;
        }
        public override void dispose(bool doNotRecurse = false)
        {
            this._colorShader.dispose();
            base.dispose(doNotRecurse);
        }
    }
}