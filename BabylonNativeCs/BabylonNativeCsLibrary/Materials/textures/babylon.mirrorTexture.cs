using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class MirrorTexture : RenderTargetTexture
    {
        public BABYLON.Plane mirrorPlane = new BABYLON.Plane(0, 1, 0, 1);
        private BABYLON.Matrix _transformMatrix = BABYLON.Matrix.Zero();
        private BABYLON.Matrix _mirrorMatrix = BABYLON.Matrix.Zero();
        private Matrix _savedViewMatrix;
        public MirrorTexture(string name, Size size, Scene scene, bool generateMipMaps = false)
            : base(name, size, scene, generateMipMaps, true)
        {
            this.onBeforeRender = () =>
            {
                BABYLON.Matrix.ReflectionToRef(this.mirrorPlane, this._mirrorMatrix);
                this._savedViewMatrix = scene.getViewMatrix();
                this._mirrorMatrix.multiplyToRef(this._savedViewMatrix, this._transformMatrix);
                scene.setTransformMatrix(this._transformMatrix, scene.getProjectionMatrix());
                scene.clipPlane = this.mirrorPlane;
                scene.getEngine().cullBackFaces = false;
            };
            this.onAfterRender = () =>
            {
                scene.setTransformMatrix(this._savedViewMatrix, scene.getProjectionMatrix());
                scene.getEngine().cullBackFaces = true;
                scene.clipPlane = null;
            };
        }
        public override BaseTexture clone()
        {
            var textureSize = this.getSize();
            var newTexture = new BABYLON.MirrorTexture(this.name, textureSize, this.getScene(), this._generateMipMaps);
            newTexture.hasAlpha = this.hasAlpha;
            newTexture.level = this.level;
            newTexture.mirrorPlane = this.mirrorPlane.clone();
            newTexture.renderList = this.renderList.slice(0);
            return newTexture;
        }
    }
}