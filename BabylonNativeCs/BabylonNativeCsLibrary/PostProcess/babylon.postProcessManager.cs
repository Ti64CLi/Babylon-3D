// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.postProcessManager.cs" company="">
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
    public partial class PostProcessManager
    {
        /// <summary>
        /// </summary>
        private WebGLBuffer _indexBuffer;

        /// <summary>
        /// </summary>
        private readonly Scene _scene;

        /// <summary>
        /// </summary>
        private WebGLBuffer _vertexBuffer;

        /// <summary>
        /// </summary>
        private readonly Array<VertexBufferKind> _vertexDeclaration = new Array<VertexBufferKind>(VertexBufferKind.NormalKind);

        /// <summary>
        /// </summary>
        private int _vertexStrideSize = 2 * 4;

        /// <summary>
        /// </summary>
        /// <param name="scene">
        /// </param>
        public PostProcessManager(Scene scene)
        {
            this._scene = scene;
            var vertices = new Array<double>();
            vertices.Add(1, 1);
            vertices.Add(-1, 1);
            vertices.Add(-1, -1);
            vertices.Add(1, -1);
            this._vertexBuffer = scene.getEngine().createVertexBuffer(vertices);
            var indices = new Array<int>();
            indices.Add(0);
            indices.Add(1);
            indices.Add(2);
            indices.Add(0);
            indices.Add(2);
            indices.Add(3);
            this._indexBuffer = scene.getEngine().createIndexBuffer(indices);
        }

        /// <summary>
        /// </summary>
        /// <param name="doNotPresent">
        /// </param>
        /// <param name="targetTexture">
        /// </param>
        public virtual void _finalizeFrame(bool doNotPresent = false, WebGLTexture targetTexture = null)
        {
            var postProcesses = this._scene.activeCamera._postProcesses;
            var postProcessesTakenIndices = this._scene.activeCamera._postProcessesTakenIndices;
            if (postProcessesTakenIndices.Length == 0 || !this._scene.postProcessesEnabled)
            {
                return;
            }

            var engine = this._scene.getEngine();
            for (var index = 0; index < postProcessesTakenIndices.Length; index++)
            {
                if (index < postProcessesTakenIndices.Length - 1)
                {
                    postProcesses[postProcessesTakenIndices[index + 1]].activate(this._scene.activeCamera);
                }
                else
                {
                    if (targetTexture != null)
                    {
                        engine.bindFramebuffer(targetTexture);
                    }
                    else
                    {
                        engine.restoreDefaultFramebuffer();
                    }
                }

                if (doNotPresent)
                {
                    break;
                }

                var effect = postProcesses[postProcessesTakenIndices[index]].apply();
                if (effect != null)
                {
                    engine.bindBuffers(this._vertexBuffer, this._indexBuffer, this._vertexDeclaration, this._vertexStrideSize, effect);
                    engine.draw(true, 0, 6);
                }
            }

            engine.setDepthBuffer(true);
            engine.setDepthWrite(true);
        }

        /// <summary>
        /// </summary>
        /// <param name="sourceTexture">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool _prepareFrame(WebGLTexture sourceTexture = null)
        {
            var postProcesses = this._scene.activeCamera._postProcesses;
            var postProcessesTakenIndices = this._scene.activeCamera._postProcessesTakenIndices;
            if (postProcessesTakenIndices.Length == 0 || !this._scene.postProcessesEnabled)
            {
                return false;
            }

            postProcesses[this._scene.activeCamera._postProcessesTakenIndices[0]].activate(this._scene.activeCamera, sourceTexture);
            return true;
        }

        /// <summary>
        /// </summary>
        public virtual void dispose()
        {
            if (this._vertexBuffer != null)
            {
                this._scene.getEngine()._releaseBuffer(this._vertexBuffer);
                this._vertexBuffer = null;
            }

            if (this._indexBuffer != null)
            {
                this._scene.getEngine()._releaseBuffer(this._indexBuffer);
                this._indexBuffer = null;
            }
        }
    }
}