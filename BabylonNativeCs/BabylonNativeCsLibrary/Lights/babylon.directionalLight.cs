using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class DirectionalLight : Light
    {
        public Vector3 position;
        private Vector3 _transformedDirection;
        public Vector3 _transformedPosition;
        private Matrix _worldMatrix;
        public Vector3 direction;
        public DirectionalLight(string name, Vector3 direction, Scene scene)
            : base(name, scene)
        {
            this.position = direction.scale(-1);
        }
        public virtual Vector3 setDirectionToTarget(Vector3 target)
        {
            this.direction = BABYLON.Vector3.Normalize(target.subtract(this.position));
            return this.direction;
        }
        public virtual bool _computeTransformedPosition()
        {
            if (this.parent != null)
            {
                if (this._transformedPosition == null)
                {
                    this._transformedPosition = BABYLON.Vector3.Zero();
                }
                BABYLON.Vector3.TransformCoordinatesToRef(this.position, this.parent.getWorldMatrix(), this._transformedPosition);
                return true;
            }
            return false;
        }
        public virtual void transferToEffect(Effect effect, string directionUniformName)
        {
            if (this.parent != null)
            {
                if (this._transformedDirection == null)
                {
                    this._transformedDirection = BABYLON.Vector3.Zero();
                }
                BABYLON.Vector3.TransformNormalToRef(this.direction, this.parent.getWorldMatrix(), this._transformedDirection);
                effect.setFloat4(directionUniformName, this._transformedDirection.x, this._transformedDirection.y, this._transformedDirection.z, 1);
                return;
            }
            effect.setFloat4(directionUniformName, this.direction.x, this.direction.y, this.direction.z, 1);
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