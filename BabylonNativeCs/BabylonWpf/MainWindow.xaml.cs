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
           
            this.Scene4();

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

        private void Scene3()
        {
            // Creating a camera looking to the zero point (0,0,0), a light, and a sphere of size 1
            var camera = new ArcRotateCamera("Camera", 0, 0.8, 100, Vector3.Zero(), scene);
            var light0 = new PointLight("Omni", new Vector3(20, 20, 100), scene);

            //Creation of 6 spheres
            var sphere1 = Mesh.CreateSphere("Sphere1", 10, 6.0, scene);
            var sphere2 = Mesh.CreateSphere("Sphere2", 2, 7.0, scene);//Only two segments
            var sphere3 = Mesh.CreateSphere("Sphere3", 10, 9.0, scene);
            var sphere4 = Mesh.CreateSphere("Sphere4", 10, 9.0, scene);
            var sphere5 = Mesh.CreateSphere("Sphere5", 10, 9.0, scene);
            var sphere6 = Mesh.CreateSphere("Sphere6", 10, 9.0, scene);

            //Positioning spheres
            sphere1.position.x = 40;
            sphere2.position.x = 30;
            sphere3.position.x = 10;
            sphere4.position.x = 0;
            sphere5.position.x = -20;
            sphere6.position.x = -30;

            //Creation of a plane
            var plan = Mesh.CreatePlane("plan", 120, scene);
            plan.position.z = -10;
            plan.rotation.y = 3.14;

            //Creation of a material in wireFrame
            var materialSphere1 = new StandardMaterial("texture1", scene);
            materialSphere1.wireframe = true;

            //Creation of a red material with alpha
            var materialSphere2 = new StandardMaterial("texture2", scene);
            materialSphere2.diffuseColor = new Color3(1, 0, 0); //Red
            materialSphere2.alpha = 0.3;


            //Creation of a material with an image
            var materialSphere3 = new StandardMaterial("texture3", scene);
            materialSphere3.diffuseTexture = new Texture("text.jpg", scene);

            //Creation of a material, with translated texture
            var materialSphere4 = new StandardMaterial("texture4", scene);
            materialSphere4.diffuseTexture = new Texture("text.jpg", scene) { vOffset = 0.1, uOffset = 0.4 };
            //Offset of 10% vertical
            //Offset of 40% horizontal

            //Creation of a material with alpha texture
            var materialSphere5 = new StandardMaterial("texture5", scene);
            materialSphere5.diffuseTexture = new Texture("Planet.png", scene);//Planet
            materialSphere5.diffuseTexture.hasAlpha = true;//Have an alpha

            //Creation of a material and allways show all the faces
            var materialSphere6 = new StandardMaterial("texture6", scene);
            materialSphere6.diffuseTexture = new Texture("Planet.png", scene);//Planet
            materialSphere6.diffuseTexture.hasAlpha = true;//Have an alpha
            materialSphere6.backFaceCulling = false;//Allways show all the faces of the element

            //Creation of a repeated textured material
            var materialPlan = new StandardMaterial("texturePlane", scene);
            materialPlan.diffuseTexture = new Texture("grass_texture.jpg", scene) { uScale = 5.0, vScale = 5.0 };
            //Wood effect
            //Repeat 5 times on the Vertical Axes
            //Repeat 5 times on the Horizontal Axes
            materialPlan.backFaceCulling = false;//Allways show the front and the back of an element

            //Applying the materials to the mesh
            sphere1.material = materialSphere1;
            sphere2.material = materialSphere2;

            sphere3.material = materialSphere3;
            sphere4.material = materialSphere4;

            sphere5.material = materialSphere5;
            sphere6.material = materialSphere6;

            plan.material = materialPlan;

            // Attach the camera to the scene
            scene.activeCamera.attachControl(canvas);
        }

        private void Scene4()
        {
            SceneLoader.Load(
                "",
                "skull.babylon",
                engine,
                loadedScene =>
                {
                    this.scene = loadedScene;

                    //// This creates and positions a free camera
                    var camera = new ArcRotateCamera("Camera", 0, 0.8, 100, this.scene.meshes[0], scene);
                    this.scene.activeCamera = camera;
                    ////this.scene.activeCamera.attachControl(canvas);
                });
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
