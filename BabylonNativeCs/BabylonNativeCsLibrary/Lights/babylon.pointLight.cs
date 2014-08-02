using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class PointLight : Light
    {
        private Matrix _worldMatrix;
        private Vector3 _transformedPosition;
        public Vector3 position;
        public PointLight(string name, Vector3 position, Scene scene) : base(name, scene) { }
        public virtual void transferToEffect(Effect effect, string positionUniformName)
        {
            if (this.parent != null)
            {
                if (this._transformedPosition == null)
                {
                    this._transformedPosition = BABYLON.Vector3.Zero();
                }
                BABYLON.Vector3.TransformCoordinatesToRef(this.position, this.parent.getWorldMatrix(), this._transformedPosition);
                effect.setFloat4(positionUniformName, this._transformedPosition.x, this._transformedPosition.y, this._transformedPosition.z, 0);
                return;
            }
            effect.setFloat4(positionUniformName, this.position.x, this.position.y, this.position.z, 0);
        }
        public virtual ShadowGenerator getShadowGenerator()
        {
            return null;
        }
        public virtual Matrix _getWorldMatrix()
        {
            if (this._worldMatrix == null)
            {
                this._worldMatrix = BABYLON.Matrix.Identity();
            }
            Matrix.TranslationToRef(this.position.x, this.position.y, this.position.z, this._worldMatrix);
            return this._worldMatrix;
        }
    }
}