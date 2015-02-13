// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Main.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BabylonAndroid
{
    using System;
    using BABYLON;
    using System.Runtime.InteropServices;

    //using BABYLON;

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
            ////Gl.glClearColor(1.0f, 0.0f, 0.0f, 1.0f);
            ////Gl.glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

#if _DEBUG
            Log.Info("OnDraw");
#endif
            this.scene.render();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public void OnInitialize(IntPtr assetManager)
        {
            Log.Info("OnInitialize");

            Effect.ShadersStore["legacydefaultVertexShader"] = Defaults.LegacyVertexShader;
            Effect.ShadersStore["legacydefaultPixelShader"] = Defaults.LegacyPixelShader;

            ////Effect.ShadersStore["legacydefaultVertexShader"] = Defaults.BasicVertexShader;
            ////Effect.ShadersStore["legacydefaultPixelShader"] = Defaults.BasicPixelShader;

            this.canvas = new CanvasAdapter(this.Width, this.Height, this.MaxWidth, this.MaxHeight, assetManager);
            this.engine = new Engine(canvas, true);
            this.scene = new Scene(this.engine);

            this.Scene8();
        }

        private void Scene1()
        {
            var camera = new ArcRotateCamera("Camera", 1, 0.8, 10, new Vector3(0, 0, 0), this.scene);
            var light0 = new PointLight("Omni", new Vector3(0, 0, 10), this.scene);
            var origin = Mesh.CreateSphere("origin", 10, 1.0, this.scene);

            // Attach the camera to the scene
            this.scene.activeCamera.attachControl(canvas);
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

            // Attach the camera to the scene
            this.scene.activeCamera.attachControl(canvas);
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
                    // Attach the camera to the scene
                    this.scene.activeCamera.attachControl(canvas);
                });
        }

        private void Scene5()
        {
            SceneLoader.Load(
                "",
                "Spaceship.babylon",
                engine,
                loadedScene =>
                {
                    this.scene = loadedScene;
                    var camera = new ArcRotateCamera("Camera", 0, 0.8, 100, this.scene.meshes[0], scene);
                    this.scene.meshes[0].scaling = new Vector3(0.04, 0.04, 0.04);
                    this.scene.activeCamera.detachControl(this.canvas);
                    this.scene.activeCamera = camera;
                    this.scene.activeCamera.attachControl(this.canvas);
                });
        }

        private void Scene6()
        {
            SceneLoader.Load(
                "",
                "Viper.babylon",
                engine,
                loadedScene =>
                {
                    this.scene = loadedScene;
                    var camera = new ArcRotateCamera("Camera", 0, 0.8, 100, this.scene.meshes[0], scene);
                    // Attach the camera to the scene
                    this.scene.meshes[0].scaling = new Vector3(4.0, 4.0, 4.0);
                    this.scene.activeCamera.detachControl(this.canvas);
                    this.scene.activeCamera = camera;
                    this.scene.activeCamera.attachControl(this.canvas);
                });
        }

        private void Scene7()
        {
            this.scene = new BABYLON.Scene(engine);
            var camera = new BABYLON.ArcRotateCamera("Camera", 0, 0, 10, BABYLON.Vector3.Zero(), scene);
            var light = new BABYLON.PointLight("Omni", new BABYLON.Vector3(20, 100, 2), scene);
            var sphere = BABYLON.Mesh.CreateSphere("Sphere", 16, 3, scene);
            var material = new BABYLON.StandardMaterial("kosh", scene);
            material.bumpTexture = new BABYLON.Texture("normalMap.jpg", scene);
            material.diffuseColor = new BABYLON.Color3(1, 0, 0);

            sphere.material = material;

            camera.setPosition(new BABYLON.Vector3(-5, 5, 0));

            // Animations
            scene.registerBeforeRender(() =>
            {
                sphere.rotation.y += 0.02;
            });

            this.scene.activeCamera.attachControl(this.canvas);
        }

        private void Scene8()
        {
            this.scene = new BABYLON.Scene(engine);
            var camera = new BABYLON.ArcRotateCamera("Camera", 0, 0, 10, BABYLON.Vector3.Zero(), scene);
            var light = new BABYLON.PointLight("Omni", new BABYLON.Vector3(20, 100, 2), scene);


            var material0 = new BABYLON.StandardMaterial("mat0", scene);
            material0.diffuseColor = new BABYLON.Color3(1, 0, 0);
            material0.bumpTexture = new BABYLON.Texture("normalMap.jpg", scene);

            var material1 = new BABYLON.StandardMaterial("mat1", scene);
            material1.diffuseColor = new BABYLON.Color3(0, 0, 1);

            var material2 = new BABYLON.StandardMaterial("mat2", scene);
            material2.emissiveColor = new BABYLON.Color3(0.4, 0, 0.4);

            var multimat = new BABYLON.MultiMaterial("multi", scene);
            multimat.subMaterials.Add(material0);
            multimat.subMaterials.Add(material1);
            multimat.subMaterials.Add(material2);

            var sphere = BABYLON.Mesh.CreateSphere("Sphere0", 16, 3, scene);
            sphere.material = multimat;

            sphere.subMeshes = new Array<SubMesh>();
            ;
            var verticesCount = sphere.getTotalVertices();

            sphere.subMeshes.Add(new BABYLON.SubMesh(0, 0, verticesCount, 0, 900, sphere));
            sphere.subMeshes.Add(new BABYLON.SubMesh(1, 0, verticesCount, 900, 900, sphere));
            sphere.subMeshes.Add(new BABYLON.SubMesh(2, 0, verticesCount, 1800, 2088, sphere));

            camera.setPosition(new BABYLON.Vector3(-3, 3, 0));

            // Animations
            scene.registerBeforeRender(
                () => { sphere.rotation.y += 0.01; });

            this.scene.activeCamera.attachControl(this.canvas);
        }
    }
}