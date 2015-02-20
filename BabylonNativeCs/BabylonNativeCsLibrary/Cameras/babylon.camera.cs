// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.camera.cs" company="">
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
    public abstract class Camera : Node, IAnimatable
    {
        /// <summary>
        /// </summary>
        public Array<PostProcess> _postProcesses = new Array<PostProcess>();

        /// <summary>
        /// </summary>
        public Array<int> _postProcessesTakenIndices = new Array<int>();

        /// <summary>
        /// </summary>
        public Matrix _projectionMatrix = new Matrix();

        /// <summary>
        /// </summary>
        public string _waitingParentId;

        /// <summary>
        /// </summary>
        public double fov = 0.8;

        /// <summary>
        /// </summary>
        public double inertia = 0.9;

        /// <summary>
        /// </summary>
        public bool isIntermediate = false;

        /// <summary>
        /// </summary>
        public uint layerMask = 0xFFFFFFFF;

        /// <summary>
        /// </summary>
        public double maxZ = 1000.0;

        /// <summary>
        /// </summary>
        public double minZ = 0.1;

        /// <summary>
        /// </summary>
        public int mode = PERSPECTIVE_CAMERA;

        /// <summary>
        /// </summary>
        public double? orthoBottom = null;

        /// <summary>
        /// </summary>
        public double? orthoLeft = null;

        /// <summary>
        /// </summary>
        public double? orthoRight = null;

        /// <summary>
        /// </summary>
        public double? orthoTop = null;

        /// <summary>
        /// </summary>
        public Vector3 position;

        /// <summary>
        /// </summary>
        public Array<Camera> subCameras = new Array<Camera>();

        /// <summary>
        /// </summary>
        public Vector3 upVector = Vector3.Up();

        /// <summary>
        /// </summary>
        public Viewport viewport = new Viewport(0, 0, 1.0, 1.0);

        /// <summary>
        /// </summary>
        private Matrix _computedViewMatrix = Matrix.Identity();

        /// <summary>
        /// </summary>
        private Matrix _worldMatrix;

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="position">
        /// </param>
        /// <param name="scene">
        /// </param>
        public Camera(string name, Vector3 position, Scene scene)
            : base(name, scene)
        {
            this.position = position;
            scene.cameras.Add(this);
            if (scene.activeCamera == null)
            {
                scene.activeCamera = this;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="force">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Matrix _computeViewMatrix(bool force = false)
        {
            if (!force && this._isSynchronizedViewMatrix())
            {
                return this._computedViewMatrix;
            }

            this._computedViewMatrix = this._getViewMatrix();
            if (this.parent == null)
            {
                this._currentRenderId = this.getScene().getRenderId();
            }

            return this._computedViewMatrix;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Matrix _getViewMatrix()
        {
            return Matrix.Identity();
        }

        /// <summary>
        /// </summary>
        public override void _initCache()
        {
            base._initCache();
            this._cache.position = new Vector3(double.MaxValue, double.MaxValue, double.MaxValue);
            this._cache.upVector = new Vector3(double.MaxValue, double.MaxValue, double.MaxValue);
            this._cache.mode = 0;
            this._cache.minZ = 0;
            this._cache.maxZ = 0;
            this._cache.fov = 0;
            this._cache.aspectRatio = 0;
            this._cache.orthoLeft = null;
            this._cache.orthoRight = null;
            this._cache.orthoBottom = null;
            this._cache.orthoTop = null;
            this._cache.renderWidth = 0;
            this._cache.renderHeight = 0;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override bool _isSynchronized()
        {
            return this._isSynchronizedViewMatrix() && this._isSynchronizedProjectionMatrix();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual bool _isSynchronizedProjectionMatrix()
        {
            var check = this._cache.mode == this.mode && this._cache.minZ == this.minZ && this._cache.maxZ == this.maxZ;
            if (!check)
            {
                return false;
            }

            var engine = this.getEngine();
            // TODO: this code causes issue with 'select'
            if (this.mode == PERSPECTIVE_CAMERA)
            {
                check = this._cache.fov == this.fov && this._cache.aspectRatio == engine.getAspectRatio(this);
            }
            else
            {
                check = this._cache.orthoLeft == this.orthoLeft && this._cache.orthoRight == this.orthoRight && this._cache.orthoBottom == this.orthoBottom
                        && this._cache.orthoTop == this.orthoTop && this._cache.renderWidth == engine.getRenderWidth()
                        && this._cache.renderHeight == engine.getRenderHeight();
            }

            return check;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual bool _isSynchronizedViewMatrix()
        {
            if (!base._isSynchronized())
            {
                return false;
            }

            return this._cache.position.equals(this.position) && this._cache.upVector.equals(this.upVector) && this.isSynchronizedWithParent();
        }

        /// <summary>
        /// </summary>
        public abstract void _update();

        /// <summary>
        /// </summary>
        /// <param name="ignoreParentClass">
        /// </param>
        public override void _updateCache(bool ignoreParentClass = false)
        {
            if (!ignoreParentClass)
            {
                base._updateCache();
            }

            var engine = this.getEngine();
            this._cache.position.copyFrom(this.position);
            this._cache.upVector.copyFrom(this.upVector);
            this._cache.mode = this.mode;
            this._cache.minZ = this.minZ;
            this._cache.maxZ = this.maxZ;
            this._cache.fov = this.fov;
            this._cache.aspectRatio = engine.getAspectRatio(this);
            this._cache.orthoLeft = this.orthoLeft;
            this._cache.orthoRight = this.orthoRight;
            this._cache.orthoBottom = this.orthoBottom;
            this._cache.orthoTop = this.orthoTop;
            this._cache.renderWidth = engine.getRenderWidth();
            this._cache.renderHeight = engine.getRenderHeight();
        }

        /// <summary>
        /// </summary>
        public virtual void _updateFromScene()
        {
            this.updateCache();
            this._update();
        }

        /// <summary>
        /// </summary>
        /// <param name="element">
        /// </param>
        public abstract void attachControl(HTMLElement element, bool noPreventDefault = false);

        /// <summary>
        /// </summary>
        /// <param name="postProcess">
        /// </param>
        /// <param name="insertAt">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual int attachPostProcess(PostProcess postProcess, int insertAt = -1)
        {
            if (!postProcess.isReusable() && this._postProcesses.IndexOf(postProcess) > -1)
            {
                Tools.Error("You're trying to reuse a post process not defined as reusable.");
                return 0;
            }

            if (insertAt < 0)
            {
                this._postProcesses.Add(postProcess);
                this._postProcessesTakenIndices.Add(this._postProcesses.Length - 1);
                return this._postProcesses.Length - 1;
            }

            var add = 0;
            if (this._postProcesses[insertAt] != null)
            {
                var start = this._postProcesses.Length - 1;
                for (var i = start; i >= insertAt + 1; --i)
                {
                    this._postProcesses[i + 1] = this._postProcesses[i];
                }

                add = 1;
            }

            for (var i = 0; i < this._postProcessesTakenIndices.Length; ++i)
            {
                if (this._postProcessesTakenIndices[i] < insertAt)
                {
                    continue;
                }

                var start = this._postProcessesTakenIndices.Length - 1;
                for (var j = start; j >= i; --j)
                {
                    this._postProcessesTakenIndices[j + 1] = this._postProcessesTakenIndices[j] + add;
                }

                this._postProcessesTakenIndices[i] = insertAt;
                break;
            }

            if (add == 0 && this._postProcessesTakenIndices.IndexOf(insertAt) == -1)
            {
                this._postProcessesTakenIndices.Add(insertAt);
            }

            var result = insertAt + add;
            this._postProcesses[result] = postProcess;
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="element">
        /// </param>
        public abstract void detachControl(HTMLElement element);

        /// <summary>
        /// </summary>
        /// <param name="postProcess">
        /// </param>
        /// <param name="atIndices">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Array<int> detachPostProcess(PostProcess postProcess, Array<int> atIndices = null)
        {
            var result = new Array<int>();
            if (atIndices == null)
            {
                var Length = this._postProcesses.Length;
                for (var i = 0; i < Length; i++)
                {
                    if (this._postProcesses[i] != postProcess)
                    {
                        continue;
                    }

                    this._postProcesses[i] = null;
                    var index = this._postProcessesTakenIndices.IndexOf(i);
                    this._postProcessesTakenIndices.RemoveAt(index);
                }
            }
            else
            {
                for (var i = 0; i < atIndices.Length; i++)
                {
                    var foundPostProcess = this._postProcesses[atIndices[i]];
                    if (foundPostProcess != postProcess)
                    {
                        result.Add(i);
                        continue;
                    }

                    this._postProcesses[atIndices[i]] = null;
                    var index = this._postProcessesTakenIndices.IndexOf(atIndices[i]);
                    this._postProcessesTakenIndices.RemoveAt(index);
                }
            }

            return result;
        }

        /// <summary>
        /// </summary>
        public virtual void dispose()
        {
            var index = this.getScene().cameras.IndexOf(this);
            this.getScene().cameras.RemoveAt(index);
            for (var i = 0; i < this._postProcessesTakenIndices.Length; ++i)
            {
                this._postProcesses[this._postProcessesTakenIndices[i]].dispose(this);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="force">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Matrix getProjectionMatrix(bool force = false)
        {
            if (!force && this._isSynchronizedProjectionMatrix())
            {
                return this._projectionMatrix;
            }

            var engine = this.getEngine();
            if (this.mode == PERSPECTIVE_CAMERA)
            {
                if (this.minZ <= 0)
                {
                    this.minZ = 0.1;
                }

                Matrix.PerspectiveFovLHToRef(this.fov, engine.getAspectRatio(this), this.minZ, this.maxZ, this._projectionMatrix);
                return this._projectionMatrix;
            }

            var halfWidth = engine.getRenderWidth() / 2.0;
            var halfHeight = engine.getRenderHeight() / 2.0;
            Matrix.OrthoOffCenterLHToRef(
                this.orthoLeft ?? -halfWidth, 
                this.orthoRight ?? halfWidth, 
                this.orthoBottom ?? -halfHeight, 
                this.orthoTop ?? halfHeight, 
                this.minZ, 
                this.maxZ, 
                this._projectionMatrix);
            return this._projectionMatrix;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Matrix getViewMatrix()
        {
            this._computedViewMatrix = this._computeViewMatrix();
            if (this.parent == null || this.isSynchronized())
            {
                return this._computedViewMatrix;
            }

            if (this._worldMatrix == null)
            {
                this._worldMatrix = Matrix.Identity();
            }

            this._computedViewMatrix.invertToRef(this._worldMatrix);
            this._worldMatrix.multiplyToRef(this.parent.getWorldMatrix(), this._computedViewMatrix);
            this._computedViewMatrix.invert();
            this._currentRenderId = this.getScene().getRenderId();
            return this._computedViewMatrix;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override Matrix getWorldMatrix()
        {
            if (this._worldMatrix == null)
            {
                this._worldMatrix = Matrix.Identity();
            }

            var viewMatrix = this.getViewMatrix();
            viewMatrix.invertToRef(this._worldMatrix);
            return this._worldMatrix;
        }

        /// <summary>
        /// </summary>
        public const int PERSPECTIVE_CAMERA = 0;

        /// <summary>
        /// </summary>
        public const int ORTHOGRAPHIC_CAMERA = 1;

        public object this[string subPropertyName]
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public object value
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public Array<Animation> animations
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public Array<IAnimatable> getAnimatables()
        {
            throw new System.NotImplementedException();
        }

        public void markAsDirty(string propertyName)
        {
            throw new System.NotImplementedException();
        }
    }
}