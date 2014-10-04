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
        public CanvasAdapter canvas { get; set; }

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
            //Gl.glClearColor(1.0f, 0.0f, 0.0f, 1.0f);
            //Gl.glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

            this.scene.render();
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

            this.canvas = new CanvasAdapter(this.Width, this.Height, this.MaxWidth, this.MaxHeight);
            this.engine = new Engine(canvas, true);
            this.scene = new Scene(this.engine);

            this.Scene1();

            // Attach the camera to the scene
            this.scene.activeCamera.attachControl(canvas);
        }

        private void Scene1()
        {
            var camera = new ArcRotateCamera("Camera", 1, 0.8, 10, new Vector3(0, 0, 0), this.scene);
            var light0 = new PointLight("Omni", new Vector3(0, 0, 10), this.scene);
            var origin = Mesh.CreateSphere("origin", 10, 1.0, this.scene);
        }

        private void Scene2()
        {
            // This creates and positions a free camera
            var camera = new BABYLON.FreeCamera("camera1", new BABYLON.Vector3(0, 5, -10), this.scene);

            // This targets the camera to scene origin
            camera.setTarget(BABYLON.Vector3.Zero());

            // This creates a light, aiming 0,1,0 - to the sky.
            var light = new BABYLON.HemisphericLight("light1", new BABYLON.Vector3(0, 1, 0), this.scene);

            // Dim the light a small amount
            light.intensity = .5;

            // Let's try our built-in 'sphere' shape. Params: name, subdivisions, size, scene
            var sphere = BABYLON.Mesh.CreateSphere("sphere1", 16, 2, this.scene);

            // Move the sphere upward 1/2 its height
            sphere.position.y = 1;

            // Let's try our built-in 'ground' shape.  Params: name, width, depth, subdivisions, scene
            BABYLON.Mesh.CreateGround("ground1", 6, 6, 2, this.scene);
        }
    }
}