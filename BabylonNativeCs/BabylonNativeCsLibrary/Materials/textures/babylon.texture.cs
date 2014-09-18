// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.texture.cs" company="">
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
    public partial class Texture : BaseTexture
    {
        /// <summary>
        /// </summary>
        public bool _invertY;

        /// <summary>
        /// </summary>
        public double uAng = 0;

        /// <summary>
        /// </summary>
        public double uOffset = 0;

        /// <summary>
        /// </summary>
        public double uScale = 1.0;

        /// <summary>
        /// </summary>
        public string url;

        /// <summary>
        /// </summary>
        public double vAng = 0;

        /// <summary>
        /// </summary>
        public double vOffset = 0;

        /// <summary>
        /// </summary>
        public double vScale = 1.0;

        /// <summary>
        /// </summary>
        public double wAng = 0;

        /// <summary>
        /// </summary>
        private Matrix _cachedTextureMatrix;

        /// <summary>
        /// </summary>
        private double _cachedUAng;

        /// <summary>
        /// </summary>
        private double _cachedUOffset;

        /// <summary>
        /// </summary>
        private double _cachedUScale;

        /// <summary>
        /// </summary>
        private double _cachedVAng;

        /// <summary>
        /// </summary>
        private double _cachedVOffset;

        /// <summary>
        /// </summary>
        private double _cachedVScale;

        /// <summary>
        /// </summary>
        private double _cachedWAng;

        /// <summary>
        /// </summary>
        private readonly bool _noMipmap;

        /// <summary>
        /// </summary>
        private Matrix _projectionModeMatrix;

        /// <summary>
        /// </summary>
        private Matrix _rowGenerationMatrix;

        /// <summary>
        /// </summary>
        private readonly int _samplingMode;

        /// <summary>
        /// </summary>
        private Vector3 _t0;

        /// <summary>
        /// </summary>
        private Vector3 _t1;

        /// <summary>
        /// </summary>
        private Vector3 _t2;

        /// <summary>
        /// </summary>
        /// <param name="url">
        /// </param>
        /// <param name="scene">
        /// </param>
        /// <param name="noMipmap">
        /// </param>
        /// <param name="invertY">
        /// </param>
        /// <param name="samplingMode">
        /// </param>
        public Texture(string url, Scene scene, bool noMipmap = false, bool invertY = false, int samplingMode = TRILINEAR_SAMPLINGMODE)
            : base(scene)
        {
            this.name = url;
            this.url = url;
            this._noMipmap = noMipmap;
            this._invertY = invertY;
            this._samplingMode = samplingMode;
            if (url == null)
            {
                return;
            }

            this._texture = this._getFromCache(url, noMipmap);
            if (this._texture == null)
            {
                if (!scene.useDelayedTextureLoading)
                {
                    this._texture = scene.getEngine().createTexture(url, noMipmap, invertY, scene, this._samplingMode);
                }
                else
                {
                    this.delayLoadState = Engine.DELAYLOADSTATE_NOTLOADED;
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override BaseTexture clone()
        {
            var newTexture = new Texture(this._texture.url, this.getScene(), this._noMipmap, this._invertY);
            newTexture.hasAlpha = this.hasAlpha;
            newTexture.level = this.level;
            newTexture.wrapU = this.wrapU;
            newTexture.wrapV = this.wrapV;
            newTexture.coordinatesIndex = this.coordinatesIndex;
            newTexture.coordinatesMode = this.coordinatesMode;
            newTexture.uOffset = this.uOffset;
            newTexture.vOffset = this.vOffset;
            newTexture.uScale = this.uScale;
            newTexture.vScale = this.vScale;
            newTexture.uAng = this.uAng;
            newTexture.vAng = this.vAng;
            newTexture.wAng = this.wAng;
            return newTexture;
        }

        /// <summary>
        /// </summary>
        public override void delayLoad()
        {
            if (this.delayLoadState != Engine.DELAYLOADSTATE_NOTLOADED)
            {
                return;
            }

            this.delayLoadState = Engine.DELAYLOADSTATE_LOADED;
            this._texture = this._getFromCache(this.url, this._noMipmap);
            if (this._texture == null)
            {
                this._texture = this.getScene().getEngine().createTexture(this.url, this._noMipmap, this._invertY, this.getScene(), this._samplingMode);
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override Matrix getReflectionTextureMatrix()
        {
            if (this.uOffset == this._cachedUOffset && this.vOffset == this._cachedVOffset && this.uScale == this._cachedUScale
                && this.vScale == this._cachedVScale)
            {
                return this._cachedTextureMatrix;
            }

            if (this._cachedTextureMatrix == null)
            {
                this._cachedTextureMatrix = Matrix.Zero();
                this._projectionModeMatrix = Matrix.Zero();
            }

            switch (this.coordinatesMode)
            {
                case SPHERICAL_MODE:
                    Matrix.IdentityToRef(this._cachedTextureMatrix);
                    this._cachedTextureMatrix.m[0] = -0.5 * this.uScale;
                    this._cachedTextureMatrix.m[5] = -0.5 * this.vScale;
                    this._cachedTextureMatrix.m[12] = 0.5 + this.uOffset;
                    this._cachedTextureMatrix.m[13] = 0.5 + this.vOffset;
                    break;
                case PLANAR_MODE:
                    Matrix.IdentityToRef(this._cachedTextureMatrix);
                    this._cachedTextureMatrix.m[0] = this.uScale;
                    this._cachedTextureMatrix.m[5] = this.vScale;
                    this._cachedTextureMatrix.m[12] = this.uOffset;
                    this._cachedTextureMatrix.m[13] = this.vOffset;
                    break;
                case PROJECTION_MODE:
                    Matrix.IdentityToRef(this._projectionModeMatrix);
                    this._projectionModeMatrix.m[0] = 0.5;
                    this._projectionModeMatrix.m[5] = -0.5;
                    this._projectionModeMatrix.m[10] = 0.0;
                    this._projectionModeMatrix.m[12] = 0.5;
                    this._projectionModeMatrix.m[13] = 0.5;
                    this._projectionModeMatrix.m[14] = 1.0;
                    this._projectionModeMatrix.m[15] = 1.0;
                    this.getScene().getProjectionMatrix().multiplyToRef(this._projectionModeMatrix, this._cachedTextureMatrix);
                    break;
                default:
                    Matrix.IdentityToRef(this._cachedTextureMatrix);
                    break;
            }

            return this._cachedTextureMatrix;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override Matrix getTextureMatrix()
        {
            if (this.uOffset == this._cachedUOffset && this.vOffset == this._cachedVOffset && this.uScale == this._cachedUScale
                && this.vScale == this._cachedVScale && this.uAng == this._cachedUAng && this.vAng == this._cachedVAng && this.wAng == this._cachedWAng)
            {
                return this._cachedTextureMatrix;
            }

            this._cachedUOffset = this.uOffset;
            this._cachedVOffset = this.vOffset;
            this._cachedUScale = this.uScale;
            this._cachedVScale = this.vScale;
            this._cachedUAng = this.uAng;
            this._cachedVAng = this.vAng;
            this._cachedWAng = this.wAng;
            if (this._cachedTextureMatrix == null)
            {
                this._cachedTextureMatrix = Matrix.Zero();
                this._rowGenerationMatrix = new Matrix();
                this._t0 = Vector3.Zero();
                this._t1 = Vector3.Zero();
                this._t2 = Vector3.Zero();
            }

            Matrix.RotationYawPitchRollToRef(this.vAng, this.uAng, this.wAng, this._rowGenerationMatrix);
            this._prepareRowForTextureGeneration(0, 0, 0, this._t0);
            this._prepareRowForTextureGeneration(1.0, 0, 0, this._t1);
            this._prepareRowForTextureGeneration(0, 1.0, 0, this._t2);
            this._t1.subtractInPlace(this._t0);
            this._t2.subtractInPlace(this._t0);
            Matrix.IdentityToRef(this._cachedTextureMatrix);
            this._cachedTextureMatrix.m[0] = this._t1.x;
            this._cachedTextureMatrix.m[1] = this._t1.y;
            this._cachedTextureMatrix.m[2] = this._t1.z;
            this._cachedTextureMatrix.m[4] = this._t2.x;
            this._cachedTextureMatrix.m[5] = this._t2.y;
            this._cachedTextureMatrix.m[6] = this._t2.z;
            this._cachedTextureMatrix.m[8] = this._t0.x;
            this._cachedTextureMatrix.m[9] = this._t0.y;
            this._cachedTextureMatrix.m[10] = this._t0.z;
            return this._cachedTextureMatrix;
        }

        /// <summary>
        /// </summary>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        /// <param name="z">
        /// </param>
        /// <param name="t">
        /// </param>
        private void _prepareRowForTextureGeneration(double x, double y, double z, Vector3 t)
        {
            x -= this.uOffset + 0.5;
            y -= this.vOffset + 0.5;
            z -= 0.5;
            Vector3.TransformCoordinatesFromFloatsToRef(x, y, z, this._rowGenerationMatrix, t);
            t.x *= this.uScale;
            t.y *= this.vScale;
            t.x += 0.5;
            t.y += 0.5;
            t.z += 0.5;
        }

        /// <summary>
        /// </summary>
        public const int NEAREST_SAMPLINGMODE = 1;

        /// <summary>
        /// </summary>
        public const int BILINEAR_SAMPLINGMODE = 2;

        /// <summary>
        /// </summary>
        public const int TRILINEAR_SAMPLINGMODE = 3;

        /// <summary>
        /// </summary>
        public const int EXPLICIT_MODE = 0;

        /// <summary>
        /// </summary>
        public const int SPHERICAL_MODE = 1;

        /// <summary>
        /// </summary>
        public const int PLANAR_MODE = 2;

        /// <summary>
        /// </summary>
        public const int CUBIC_MODE = 3;

        /// <summary>
        /// </summary>
        public const int PROJECTION_MODE = 4;

        /// <summary>
        /// </summary>
        public const int SKYBOX_MODE = 5;

        /// <summary>
        /// </summary>
        public const int CLAMP_ADDRESSMODE = 0;

        /// <summary>
        /// </summary>
        public const int WRAP_ADDRESSMODE = 1;

        /// <summary>
        /// </summary>
        public const int MIRROR_ADDRESSMODE = 2;
    }
}