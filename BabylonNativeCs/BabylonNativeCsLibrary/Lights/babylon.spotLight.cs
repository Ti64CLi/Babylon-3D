using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class SpotLight : Light
    {
        private Vector3 _transformedDirection;
        private Vector3 _transformedPosition;
        private Matrix _worldMatrix;
        public Vector3 position;
        public Vector3 direction;
        public double angle;
        public double exponent;
        public SpotLight(string name, Vector3 position, Vector3 direction, double angle, double exponent, Scene scene) : base(name, scene) { }
        public virtual Vector3 setDirectionToTarget(Vector3 target)
        {
            this.direction = BABYLON.Vector3.Normalize(target.subtract(this.position));
            return this.direction;
        }
        public virtual void transferToEffect(Effect effect, string positionUniformName, string directionUniformName)
        {
            Vector3 normalizeDirection = null;
            if (this.parent != null)
            {
                if (this._transformedDirection == null)
                {
                    this._transformedDirection = BABYLON.Vector3.Zero();
                }
                if (this._transformedPosition == null)
                {
                    this._transformedPosition = BABYLON.Vector3.Zero();
                }
                var parentWorldMatrix = this.parent.getWorldMatrix();
                BABYLON.Vector3.TransformCoordinatesToRef(this.position, parentWorldMatrix, this._transformedPosition);
                BABYLON.Vector3.TransformNormalToRef(this.direction, parentWorldMatrix, this._transformedDirection);
                effect.setFloat4(positionUniformName, this._transformedPosition.x, this._transformedPosition.y, this._transformedPosition.z, this.exponent);
                normalizeDirection = BABYLON.Vector3.Normalize(this._transformedDirection);
            }
            else
            {
                effect.setFloat4(positionUniformName, this.position.x, this.position.y, this.position.z, this.exponent);
                normalizeDirection = BABYLON.Vector3.Normalize(this.direction);
            }
            effect.setFloat4(directionUniformName, normalizeDirection.x, normalizeDirection.y, normalizeDirection.z, Math.Cos(this.angle * 0.5));
        }
        public virtual Matrix _getWorldMatrix()
        {
            if (this._worldMatrix == null)
            {
                this._worldMatrix = BABYLON.Matrix.Identity();
            }
            BABYLON.Matrix.TranslationToRef(this.position.x, this.position.y, this.position.z, this._worldMatrix);
            return this._worldMatrix;
        }
    }
}