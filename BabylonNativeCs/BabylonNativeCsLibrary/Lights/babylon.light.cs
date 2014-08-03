using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class Light : Node
    {
        public Color3 diffuse = new Color3(1.0, 1.0, 1.0);
        public Color3 specular = new Color3(1.0, 1.0, 1.0);
        public double intensity = 1.0;
        public double range = double.MaxValue;
        public Array<AbstractMesh> excludedMeshes = new Array<AbstractMesh>();
        public ShadowGenerator _shadowGenerator;
        private Matrix _parentedWorldMatrix;
        public Array<string> _excludedMeshesIds = new Array<string>();
        public Light(string name, Scene scene)
            : base(name, scene)
        {
            scene.lights.push(this);
        }
        public virtual ShadowGenerator getShadowGenerator()
        {
            return this._shadowGenerator;
        }
        public virtual void transferToEffect(Effect effect, string uniformName0 = null, string uniformName1 = null) { }
        public virtual Matrix _getWorldMatrix()
        {
            return Matrix.Identity();
        }
        public virtual Matrix getWorldMatrix()
        {
            this._currentRenderId = this.getScene().getRenderId();
            var worldMatrix = this._getWorldMatrix();
            if (this.parent != null)
            {
                if (this._parentedWorldMatrix == null)
                {
                    this._parentedWorldMatrix = BABYLON.Matrix.Identity();
                }
                worldMatrix.multiplyToRef(this.parent.getWorldMatrix(), this._parentedWorldMatrix);
                return this._parentedWorldMatrix;
            }
            return worldMatrix;
        }
        public virtual void dispose()
        {
            if (this._shadowGenerator != null)
            {
                this._shadowGenerator.dispose();
                this._shadowGenerator = null;
            }
            var index = this.getScene().lights.indexOf(this);
            this.getScene().lights.RemoveAt(index);
        }
    }
}