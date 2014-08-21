namespace BabylonGlut
{
    using System;
    using System.Runtime.CompilerServices;

    using BABYLON;
    using BabylonWpf;

    public class Main
    {
        public const int GL_COLOR_BUFFER_BIT = 16384;
        public const int GL_DEPTH_BUFFER_BIT = 256;

        [MethodImplAttribute(MethodImplOptions.Unmanaged)]
        public static extern void glClear(int flags);
        
        private Engine engine;
        private BABYLON.Scene scene;

        public Main()
        {
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public int MaxWidth { get; set; }

        public int MaxHeight { get; set; }

        public void OnInitialize()
        {
            BABYLON.Effect.ShadersStore["legacydefaultVertexShader"] = Defaults.LegacyVertexShader;
            BABYLON.Effect.ShadersStore["legacydefaultPixelShader"] = Defaults.LegacyPixelShader;
            //BABYLON.Effect.ShadersStore["legacydefaultVertexShader"] = Defaults.BasicVertexShader;
            //BABYLON.Effect.ShadersStore["legacydefaultPixelShader"] = Defaults.BasicPixelShader;

            var canvas = new CanvasAdapter(this.Width, this.Height, this.MaxWidth, this.MaxHeight);

            this.engine = new Engine(canvas, true);

            // create scene
            this.scene = new BABYLON.Scene(this.engine);

            var camera = new ArcRotateCamera("Camera", 1, 0.8, 10, new Vector3(0, 0, 0), scene);
            var light0 = new PointLight("Omni", new Vector3(0, 0, 10), scene);
            var origin = Mesh.CreateSphere("origin", 10, 1.0, scene);

            // Attach the camera to the scene
            scene.activeCamera.attachControl(canvas);
        }

        public void OnDraw()
        {
            glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
            //this.scene.render();
        }
    }
}
