// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Main.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BabylonGlut
{
    using System.Runtime.InteropServices;

    using BABYLON;

    using BabylonWpf;

    /// <summary>
    /// </summary>
    public class Main
    {
        /// <summary>
        /// </summary>
        public const int GL_COLOR_BUFFER_BIT = 16384;

        /// <summary>
        /// </summary>
        public const int GL_DEPTH_BUFFER_BIT = 256;

        /// <summary>
        /// </summary>
        private Engine engine;

        /// <summary>
        /// </summary>
        private Scene scene;

        /// <summary>
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// </summary>
        public int MaxHeight { get; set; }

        /// <summary>
        /// </summary>
        public int MaxWidth { get; set; }

        /// <summary>
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public void OnDraw()
        {
            Gl.glClearColor(1.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

            // this.scene.render();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public void OnInitialize()
        {
            Effect.ShadersStore["legacydefaultVertexShader"] = Defaults.LegacyVertexShader;
            Effect.ShadersStore["legacydefaultPixelShader"] = Defaults.LegacyPixelShader;

            // BABYLON.Effect.ShadersStore["legacydefaultVertexShader"] = Defaults.BasicVertexShader;
            // BABYLON.Effect.ShadersStore["legacydefaultPixelShader"] = Defaults.BasicPixelShader;
            var canvas = new CanvasAdapter(this.Width, this.Height, this.MaxWidth, this.MaxHeight);

            this.engine = new Engine(canvas, true);

            ////// create scene
            ////this.scene = new Scene(this.engine);

            ////var camera = new ArcRotateCamera("Camera", 1, 0.8, 10, new Vector3(0, 0, 0), this.scene);
            ////var light0 = new PointLight("Omni", new Vector3(0, 0, 10), this.scene);
            ////var origin = Mesh.CreateSphere("origin", 10, 1.0, this.scene);

            ////// Attach the camera to the scene
            ////this.scene.activeCamera.attachControl(canvas);
        }
    }
}