using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SharpGL;
using SharpGL.Enumerations;
using SharpGL.SceneGraph;
using BABYLON;

namespace BabylonWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CanvasAdapter canvas;
        private Engine engine;
        private BABYLON.Scene scene;
        private int pointerId;
        private bool pointerLocked;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenGLControl_OpenGLInitialized(object sender, OpenGLEventArgs args)
        {
            BABYLON.Effect.ShadersStore["legacydefaultVertexShader"] = Defaults.LegacyVertexShader;
            BABYLON.Effect.ShadersStore["legacydefaultPixelShader"] = Defaults.LegacyPixelShader;
            //BABYLON.Effect.ShadersStore["legacydefaultVertexShader"] = Defaults.BasicVertexShader;
            //BABYLON.Effect.ShadersStore["legacydefaultPixelShader"] = Defaults.BasicPixelShader;

            this.canvas = new CanvasAdapter((int)this.Width, (int)this.Height, (int)this.MaxWidth, (int)this.MaxHeight, args.OpenGL);
            this.engine = new Engine(canvas, true);
            this.scene = new BABYLON.Scene(this.engine);

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
            var camera = new BABYLON.FreeCamera("camera1", new BABYLON.Vector3(0, 5, -10), scene);

            // This targets the camera to scene origin
            camera.setTarget(BABYLON.Vector3.Zero());

            // This creates a light, aiming 0,1,0 - to the sky.
            var light = new BABYLON.HemisphericLight("light1", new BABYLON.Vector3(0, 1, 0), scene);

            // Dim the light a small amount
            light.intensity = .5;

            // Let's try our built-in 'sphere' shape. Params: name, subdivisions, size, scene
            var sphere = BABYLON.Mesh.CreateSphere("sphere1", 16, 2, scene);

            // Move the sphere upward 1/2 its height
            sphere.position.y = 1;

            // Let's try our built-in 'ground' shape.  Params: name, width, depth, subdivisions, scene
            BABYLON.Mesh.CreateGround("ground1", 6, 6, 2, scene);
        }

        private void openGLControl1_OpenGLDraw(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            //  Get the OpenGL instance. 
            var gl = args.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            this.scene.render();
        }

        private void openGLControl1_Resized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            //  Get the OpenGL instance.
            var gl = args.OpenGL;

            //  Create an orthographic projection.
            gl.MatrixMode(MatrixMode.Projection);
            gl.LoadIdentity();
            gl.Ortho(0, openGLControl1.ActualWidth, openGLControl1.ActualHeight, 0, -10, 10);

            //  Back to the modelview.
            gl.MatrixMode(MatrixMode.Modelview);
        }

        private void openGLControl1_MouseLeftButtonUp(object sender, MouseEventArgs e)
        {
            if (this.canvas.onmouseup != null)
            {
                System.Windows.Point position = e.GetPosition(this);
                var pX = position.X;
                var pY = position.Y;

                this.canvas.onmouseup(new MouseEventAdapter(0, (int)pX, (int)pY));
            }

            if (this.canvas.onpointerup != null)
            {
                System.Windows.Point position = e.GetPosition(this);
                var pX = position.X;
                var pY = position.Y;

                this.canvas.onpointerup(new PointerEventAdapter(this.pointerId, (int)pX, (int)pY));

                this.pointerLocked = false;
            }
        }

        private void openGLControl1_MouseLeftButtonDown(object sender, MouseEventArgs e)
        {
            if (this.canvas.onmousedown != null)
            {
                System.Windows.Point position = e.GetPosition(this);
                var pX = position.X;
                var pY = position.Y;

                this.canvas.onmousedown(new MouseEventAdapter(0, (int)pX, (int)pY));
            }

            if (this.canvas.onpointerdown != null)
            {
                System.Windows.Point position = e.GetPosition(this);
                var pX = position.X;
                var pY = position.Y;

                this.canvas.onpointerdown(new PointerEventAdapter(++this.pointerId, (int)pX, (int)pY));

                this.pointerLocked = true;
            }
        }

        private void openGLControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.canvas.onmousemove != null)
            {
                System.Windows.Point position = e.GetPosition(this);
                var pX = position.X;
                var pY = position.Y;

                this.canvas.onmousemove(new MouseEventAdapter(-1, (int)pX, (int)pY));
            }

            if (this.pointerLocked && this.canvas.onpointermove != null)
            {
                System.Windows.Point position = e.GetPosition(this);
                var pX = position.X;
                var pY = position.Y;

                this.canvas.onpointermove(new PointerEventAdapter(this.pointerId, (int)pX, (int)pY));
            }
        }
    }
}
