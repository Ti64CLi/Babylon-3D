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
    using Web;
    using System;

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
            BABYLON.Effect.ShadersStore["legacydefaultVertexShader"] = Defaults.LegacyVertexShader;
            BABYLON.Effect.ShadersStore["legacydefaultPixelShader"] = Defaults.LegacyPixelShader;
            //BABYLON.Effect.ShadersStore["legacydefaultVertexShader"] = Defaults.BasicVertexShader;
            //BABYLON.Effect.ShadersStore["legacydefaultPixelShader"] = Defaults.BasicPixelShader;

            BABYLON.Effect.ShadersStore["defaultVertexShader"] = Defaults.DefaultVertexShader;
            BABYLON.Effect.ShadersStore["defaultPixelShader"] = Defaults.DefaultPixelShader;

            BABYLON.Effect.ShadersStore["shadowMapVertexShader"] = Defaults.ShadowMapVertexShader;
            BABYLON.Effect.ShadersStore["shadowMapPixelShader"] = Defaults.ShadowMapPixelShader;

            BABYLON.Effect.ShadersStore["particlesVertexShader"] = Defaults.ParticlesVertexShader;
            BABYLON.Effect.ShadersStore["particlesPixelShader"] = Defaults.ParticlesPixelShader;

            BABYLON.Effect.ShadersStore["postprocessVertexShader"] = Defaults.PostProcessVertexShader;
            BABYLON.Effect.ShadersStore["passPixelShader"] = Defaults.PassPixelShader;

            BABYLON.Effect.ShadersStore["blurPixelShader"] = Defaults.BlurPixelShader;

            this.canvas = new CanvasAdapter(this.Width, this.Height, this.MaxWidth, this.MaxHeight);
            this.engine = new Engine(canvas, true);
            this.scene = new Scene(this.engine);

            this.Scene17();
        }

        private void Scene1()
        {
            var camera = new ArcRotateCamera("Camera", 1, 0.8, 10, new Vector3(0, 0, 0), this.scene);
            var light0 = new PointLight("Omni", new Vector3(0, 0, 10), this.scene);
            var origin = Mesh.CreateSphere("origin", 10, 1.0, this.scene);

            // Attach the camera to the scene
            scene.activeCamera.attachControl(canvas);
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
            scene.activeCamera.attachControl(canvas);
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

        private void Scene9()
        {
            this.scene = new BABYLON.Scene(engine);
            var camera = new BABYLON.ArcRotateCamera("Camera", 0, 0, 10, BABYLON.Vector3.Zero(), scene);
            var light0 = new BABYLON.PointLight("Omni0", new BABYLON.Vector3(0, 10, 0), scene);
            var light1 = new BABYLON.PointLight("Omni1", new BABYLON.Vector3(0, -10, 0), scene);
            var light2 = new BABYLON.PointLight("Omni2", new BABYLON.Vector3(10, 0, 0), scene);
            var light3 = new BABYLON.DirectionalLight("Dir0", new BABYLON.Vector3(1, -1, 0), scene);
            var material = new BABYLON.StandardMaterial("kosh", scene);
            var sphere = BABYLON.Mesh.CreateSphere("Sphere", 16, 3, scene);

            camera.setPosition(new BABYLON.Vector3(-10, 10, 0));

            light3.parent = camera;

            // Creating light sphere
            var lightSphere0 = BABYLON.Mesh.CreateSphere("Sphere0", 16, 0.5, scene);
            var lightSphere1 = BABYLON.Mesh.CreateSphere("Sphere1", 16, 0.5, scene);
            var lightSphere2 = BABYLON.Mesh.CreateSphere("Sphere2", 16, 0.5, scene);

            var material1 = new BABYLON.StandardMaterial("red", scene);
            material1.diffuseColor = new BABYLON.Color3(0, 0, 0);
            material1.specularColor = new BABYLON.Color3(0, 0, 0);
            material1.emissiveColor = new BABYLON.Color3(1, 0, 0);
            lightSphere0.material = material1;

            var material2 = new BABYLON.StandardMaterial("green", scene);
            material2.diffuseColor = new BABYLON.Color3(0, 0, 0);
            material2.specularColor = new BABYLON.Color3(0, 0, 0);
            material2.emissiveColor = new BABYLON.Color3(0, 1, 0);
            lightSphere1.material = material2;

            var material3 = new BABYLON.StandardMaterial("blue", scene);
            material3.diffuseColor = new BABYLON.Color3(0, 0, 0);
            material3.specularColor = new BABYLON.Color3(0, 0, 0);
            material3.emissiveColor = new BABYLON.Color3(0, 0, 1);
            lightSphere2.material = material3;

            // Sphere material
            material.diffuseColor = new BABYLON.Color3(1, 1, 1);
            sphere.material = material;

            // Lights colors
            light0.diffuse = new BABYLON.Color3(1, 0, 0);
            light0.specular = new BABYLON.Color3(1, 0, 0);

            light1.diffuse = new BABYLON.Color3(0, 1, 0);
            light1.specular = new BABYLON.Color3(0, 1, 0);

            light2.diffuse = new BABYLON.Color3(0, 0, 1);
            light2.specular = new BABYLON.Color3(0, 0, 1);

            light3.diffuse = new BABYLON.Color3(1, 1, 1);
            light3.specular = new BABYLON.Color3(1, 1, 1);

            // Skybox
            var skybox = BABYLON.Mesh.CreateBox("skyBox", 100.0, scene);
            var skyboxMaterial = new BABYLON.StandardMaterial("skyBox", scene);
            skyboxMaterial.backFaceCulling = false;
            skyboxMaterial.reflectionTexture = new BABYLON.CubeTexture("skybox", scene);
            skyboxMaterial.reflectionTexture.coordinatesMode = BABYLON.Texture.SKYBOX_MODE;
            skyboxMaterial.diffuseColor = new BABYLON.Color3(0, 0, 0);
            skyboxMaterial.specularColor = new BABYLON.Color3(0, 0, 0);
            skybox.material = skyboxMaterial;
            skybox.infiniteDistance = true;

            // Animations
            var alpha = 0.0;
            scene.registerBeforeRender(() =>
            {
                light0.position = new BABYLON.Vector3(10 * Math.Sin(alpha), 0, 10 * Math.Cos(alpha));
                light1.position = new BABYLON.Vector3(10 * Math.Sin(alpha), 0, -10 * Math.Cos(alpha));
                light2.position = new BABYLON.Vector3(10 * Math.Cos(alpha), 0, 10 * Math.Sin(alpha));

                lightSphere0.position = light0.position;
                lightSphere1.position = light1.position;
                lightSphere2.position = light2.position;

                alpha += 0.01;
            });

            this.scene.activeCamera.attachControl(this.canvas);
        }

        private void Scene10()
        {
            this.scene = new BABYLON.Scene(engine);
            var camera = new BABYLON.FreeCamera("Camera", new BABYLON.Vector3(0, 0, -20), scene);
            var light = new BABYLON.PointLight("Omni", new BABYLON.Vector3(20, 100, 2), scene);
            var sphere0 = BABYLON.Mesh.CreateSphere("Sphere0", 16, 3, scene);
            var sphere1 = BABYLON.Mesh.CreateSphere("Sphere1", 16, 3, scene);
            var sphere2 = BABYLON.Mesh.CreateSphere("Sphere2", 16, 3, scene);

            var material0 = new BABYLON.StandardMaterial("mat0", scene);
            material0.diffuseColor = new BABYLON.Color3(1, 0, 0);
            sphere0.material = material0;
            sphere0.position = new BABYLON.Vector3(-10, 0, 0);

            var material1 = new BABYLON.StandardMaterial("mat1", scene);
            material1.diffuseColor = new BABYLON.Color3(1, 1, 0);
            sphere1.material = material1;

            var material2 = new BABYLON.StandardMaterial("mat2", scene);
            material2.diffuseColor = new BABYLON.Color3(1, 0, 1);
            sphere2.material = material2;
            sphere2.position = new BABYLON.Vector3(10, 0, 0);

            sphere1.convertToFlatShadedMesh();

            camera.setTarget(new BABYLON.Vector3(0, 0, 0));

            // Fog
            scene.fogMode = BABYLON.Scene.FOGMODE_EXP;
            scene.fogDensity = 0.1;

            // Animations
            var alpha = 0.0;
            scene.registerBeforeRender(() =>
            {
                sphere0.position.z = 4 * Math.Cos(alpha);
                sphere1.position.z = 4 * Math.Sin(alpha);
                sphere2.position.z = 4 * Math.Cos(alpha);

                alpha += 0.1;
            });

            this.scene.activeCamera.attachControl(this.canvas);
        }

        private void Scene11()
        {
            this.scene = new BABYLON.Scene(engine);
            var camera = new BABYLON.ArcRotateCamera("Camera", 0, 0, 10, BABYLON.Vector3.Zero(), scene);
            var sun = new BABYLON.PointLight("Omni0", new BABYLON.Vector3(60, 100, 10), scene);

            camera.setPosition(new BABYLON.Vector3(-20, 20, 0));

            // Skybox
            var skybox = BABYLON.Mesh.CreateBox("skyBox", 100.0, scene);
            var skyboxMaterial = new BABYLON.StandardMaterial("skyBox", scene);
            skyboxMaterial.backFaceCulling = false;
            skyboxMaterial.reflectionTexture = new BABYLON.CubeTexture("skybox", scene);
            skyboxMaterial.reflectionTexture.coordinatesMode = BABYLON.Texture.SKYBOX_MODE;
            skyboxMaterial.diffuseColor = new BABYLON.Color3(0, 0, 0);
            skyboxMaterial.specularColor = new BABYLON.Color3(0, 0, 0);
            skybox.material = skyboxMaterial;

            // Ground
            var ground = BABYLON.Mesh.CreateGroundFromHeightMap("ground", "heightMap.png", 100, 100, 100, 0, 10, scene, false);
            var groundMaterial = new BABYLON.StandardMaterial("ground", scene);
            var texture1 = new BABYLON.Texture("ground.jpg", scene);
            texture1.uScale = 6;
            texture1.vScale = 6;
            groundMaterial.diffuseTexture = texture1;
            groundMaterial.specularColor = new BABYLON.Color3(0, 0, 0);
            ground.position.y = -2.05;
            ground.material = groundMaterial;

            System.Action beforeRenderFunction = () =>
            {
                // Camera
                if (camera.beta < 0.1)
                    camera.beta = 0.1;
                else if (camera.beta > (Math.PI / 2) * 0.9)
                    camera.beta = (Math.PI / 2) * 0.9;

                if (camera.radius > 50)
                    camera.radius = 50;

                if (camera.radius < 5)
                    camera.radius = 5;
            };

            scene.registerBeforeRender(beforeRenderFunction);

            this.scene.activeCamera.attachControl(this.canvas);
        }

        private void Scene12()
        {
            this.scene = new BABYLON.Scene(engine);
            var camera = new BABYLON.ArcRotateCamera("Camera", 0, 0, 10, BABYLON.Vector3.Zero(), scene);
            var light = new BABYLON.DirectionalLight("dir01", new BABYLON.Vector3(0, -1, -0.2), scene);
            var light2 = new BABYLON.DirectionalLight("dir02", new BABYLON.Vector3(-1, -2, -1), scene);
            light.position = new BABYLON.Vector3(0, 30, 0);
            light2.position = new BABYLON.Vector3(10, 20, 10);

            light.intensity = 0.6;
            light2.intensity = 0.6;

            camera.setPosition(new BABYLON.Vector3(-20, 20, 0));

            // Skybox
            var skybox = BABYLON.Mesh.CreateBox("skyBox", 1000.0, scene);
            var skyboxMaterial = new BABYLON.StandardMaterial("skyBox", scene);
            skyboxMaterial.backFaceCulling = false;
            skyboxMaterial.reflectionTexture = new BABYLON.CubeTexture("skybox", scene);
            skyboxMaterial.reflectionTexture.coordinatesMode = BABYLON.Texture.SKYBOX_MODE;
            skyboxMaterial.diffuseColor = new BABYLON.Color3(0, 0, 0);
            skyboxMaterial.specularColor = new BABYLON.Color3(0, 0, 0);
            skybox.material = skyboxMaterial;

            // Ground
            var ground = BABYLON.Mesh.CreateGround("ground", 1000, 1000, 1, scene, false);
            var groundMaterial = new BABYLON.StandardMaterial("ground", scene);
            BABYLON.Texture diffuseTexture = null;
            if (engine.getCaps().s3tc != null)
            {
                diffuseTexture = new BABYLON.Texture("grass.dds", scene);
            }
            else
            {
                diffuseTexture = new BABYLON.Texture("grass.jpg", scene);
            }
            diffuseTexture.uScale = 60;
            diffuseTexture.vScale = 60;
            groundMaterial.diffuseTexture = diffuseTexture;
            groundMaterial.specularColor = new BABYLON.Color3(0, 0, 0);
            ground.position.y = -2.05;
            ground.material = groundMaterial;

            // Torus
            var torus = BABYLON.Mesh.CreateTorus("torus", 8, 2, 32, scene, false);
            torus.position.y = 6.0;
            var torus2 = BABYLON.Mesh.CreateTorus("torus2", 4, 1, 32, scene, false);
            torus2.position.y = 6.0;

            var torusMaterial = new BABYLON.StandardMaterial("torus", scene);
            torusMaterial.diffuseColor = new BABYLON.Color3(0.5, 0.5, 0.5);
            torusMaterial.specularColor = new BABYLON.Color3(0.5, 0.5, 0.5);
            torus.material = torusMaterial;
            torus2.material = torusMaterial;

            // Shadows
            var shadowGenerator = new BABYLON.ShadowGenerator(new BABYLON.Size() { width = 512, height = 512 }, light);
            shadowGenerator.getShadowMap().renderList.Add(torus);
            shadowGenerator.getShadowMap().renderList.Add(torus2);
            shadowGenerator.usePoissonSampling = true;

            var shadowGenerator2 = new BABYLON.ShadowGenerator(new BABYLON.Size() { width = 512, height = 512 }, light2);
            shadowGenerator2.getShadowMap().renderList.Add(torus);
            shadowGenerator2.getShadowMap().renderList.Add(torus2);
            shadowGenerator2.useVarianceShadowMap = true;

            ground.receiveShadows = true;

            System.Action beforeRenderFunction = () =>
            {
                // Camera
                if (camera.beta < 0.1)
                    camera.beta = 0.1;
                else if (camera.beta > (Math.PI / 2) * 0.99)
                    camera.beta = (Math.PI / 2) * 0.99;

                if (camera.radius > 150)
                    camera.radius = 150;

                if (camera.radius < 5)
                    camera.radius = 5;
            };

            scene.registerBeforeRender(beforeRenderFunction);

            // Animations
            scene.registerBeforeRender(() =>
            {
                torus.rotation.x += 0.01;
                torus.rotation.z += 0.02;
                torus2.rotation.x += 0.02;
                torus2.rotation.y += 0.01;
            });

            this.scene.activeCamera.attachControl(this.canvas);
        }

        private void Scene13()
        {
            this.scene = new BABYLON.Scene(engine);
            var camera = new BABYLON.ArcRotateCamera("Camera", 0, 0, 10, BABYLON.Vector3.Zero(), scene);
            var light0 = new BABYLON.PointLight("Omni0", new BABYLON.Vector3(0, 10, 0), scene);
            var material = new BABYLON.StandardMaterial("kosh", scene);
            var sphere = BABYLON.Mesh.CreateSphere("sphere0", 16, 1, scene);

            camera.setPosition(new BABYLON.Vector3(-10, 10, 0));

            // Sphere material
            material.diffuseColor = new BABYLON.Color3(0.5, 0.5, 0.5);
            material.specularColor = new BABYLON.Color3(1.0, 1.0, 1.0);
            material.specularPower = 32;
            material.checkReadyOnEveryCall = false;
            sphere.material = material;

            // Fog
            scene.fogMode = BABYLON.Scene.FOGMODE_EXP;
            scene.fogDensity = 0.05;

            // Clone spheres
            var random = new Random();
            var playgroundSize = 50.0;
            for (var index = 0; index < 8000; index++)
            {
                var clone = sphere.clone("sphere" + (index + 1), null, true);
                var scale = random.NextDouble() * 0.8 + 0.6;
                clone.scaling = new BABYLON.Vector3(scale, scale, scale);
                clone.position = new BABYLON.Vector3(random.NextDouble() * 2.0 * playgroundSize - playgroundSize, random.NextDouble() * 2.0 * playgroundSize - playgroundSize, random.NextDouble() * 2.0 * playgroundSize - playgroundSize);
            }
            sphere.setEnabled(false);
            scene.createOrUpdateSelectionOctree();

            this.scene.activeCamera.attachControl(this.canvas);
        }

        private void Scene14()
        {
            SceneLoader.Load(
                "",
                "Dude.babylon",
                engine,
                loadedScene =>
                {
                    this.scene = loadedScene;
                    this.scene.activeCamera.attachControl(this.canvas);
                });
        }

        private void Scene15()
        {
            var scene = new BABYLON.Scene(engine);
            var light = new BABYLON.DirectionalLight("dir01", new BABYLON.Vector3(0, -0.5, -1.0), scene);
            var camera = new BABYLON.ArcRotateCamera("Camera", 0, 0, 10, new BABYLON.Vector3(0, 30, 0), scene);
            camera.setPosition(new BABYLON.Vector3(20, 70, 120));
            light.position = new BABYLON.Vector3(20, 150, 70);
            camera.minZ = 10.0;

            scene.ambientColor = new BABYLON.Color3(0.3, 0.3, 0.3);

            // Ground
            var ground = BABYLON.Mesh.CreateGround("ground", 1000, 1000, 1, scene, false);
            var groundMaterial = new BABYLON.StandardMaterial("ground", scene);
            groundMaterial.diffuseColor = new BABYLON.Color3(0.2, 0.2, 0.2);
            groundMaterial.specularColor = new BABYLON.Color3(0, 0, 0);
            ground.material = groundMaterial;
            ground.receiveShadows = true;

            // Shadows
            var shadowGenerator = new BABYLON.ShadowGenerator(new BABYLON.Size() { width = 1024, height = 1024 }, light);

            // Meshes
            // Dude
            BABYLON.SceneLoader.ImportMesh(new Array<string>("him"), "", "Dude.babylon", scene, (newMeshes2, particleSystems2, skeletons2) =>
            {
                this.scene = scene;
                this.scene.activeCamera.attachControl(this.canvas);

                var dude = newMeshes2[0];

                for (var index = 0; index < newMeshes2.Length; index++)
                {
                    shadowGenerator.getShadowMap().renderList.Add(newMeshes2[index]);
                }

                dude.rotation.y = Math.PI;
                dude.position = new BABYLON.Vector3(0, 0, -80);

                scene.beginAnimation(skeletons2[0], 0, 100, true, 1.0);
            });
        }

        private void Scene16()
        {
            this.scene = new BABYLON.Scene(engine);
            var camera = new BABYLON.ArcRotateCamera("Camera", 0, 0, 10, BABYLON.Vector3.Zero(), scene);
            var light = new BABYLON.DirectionalLight("dir01", new BABYLON.Vector3(0, -1, -0.2), scene);
            var light2 = new BABYLON.DirectionalLight("dir02", new BABYLON.Vector3(-1, -2, -1), scene);
            light.position = new BABYLON.Vector3(0, 30, 0);
            light2.position = new BABYLON.Vector3(10, 20, 10);

            light.intensity = 0.6;
            light2.intensity = 0.6;

            camera.setPosition(new BABYLON.Vector3(-40, 40, 0));
            camera.lowerBetaLimit = (Math.PI / 2) * 0.9;

            // Skybox
            var skybox = BABYLON.Mesh.CreateBox("skyBox", 1000.0, scene);
            var skyboxMaterial = new BABYLON.StandardMaterial("skyBox", scene);
            skyboxMaterial.backFaceCulling = false;
            skyboxMaterial.reflectionTexture = new BABYLON.CubeTexture("skybox", scene);
            skyboxMaterial.reflectionTexture.coordinatesMode = BABYLON.Texture.SKYBOX_MODE;
            skyboxMaterial.diffuseColor = new BABYLON.Color3(0, 0, 0);
            skyboxMaterial.specularColor = new BABYLON.Color3(0, 0, 0);
            skybox.material = skyboxMaterial;

            // Spheres
            var sphere0 = BABYLON.Mesh.CreateSphere("Sphere0", 16, 10, scene);
            var sphere1 = BABYLON.Mesh.CreateSphere("Sphere1", 16, 10, scene);
            var sphere2 = BABYLON.Mesh.CreateSphere("Sphere2", 16, 10, scene);
            var cube = BABYLON.Mesh.CreateBox("Cube", 10.0, scene);

            var material0 = new BABYLON.StandardMaterial("white", scene);
            material0.diffuseColor = new BABYLON.Color3(0, 0, 0);
            material0.specularColor = new BABYLON.Color3(0, 0, 0);
            material0.emissiveColor = new BABYLON.Color3(1.0, 1.0, 1.0);
            sphere0.material = material0;

            sphere1.material = sphere0.material;
            sphere2.material = sphere0.material;

            var material1 = new BABYLON.StandardMaterial("red", scene);
            material1.diffuseColor = new BABYLON.Color3(0, 0, 0);
            material1.specularColor = new BABYLON.Color3(0, 0, 0);
            material1.emissiveColor = new BABYLON.Color3(1.0, 0, 0);
            cube.material = material1;

            // Post-process
            var blurWidth = 1.0;

            var postProcess0 = new BABYLON.PassPostProcess("Scene copy", 1.0, camera);
            var postProcess1 = new BABYLON.PostProcess("Down sample", "./postprocesses/downsample", new Array<string>("screenSize", "highlightThreshold"), null, 0.25, camera, BABYLON.Texture.BILINEAR_SAMPLINGMODE);
            postProcess1.onApply = (effect) =>
            {
                effect.setFloat2("screenSize", postProcess1.width, postProcess1.height);
                effect.setFloat("highlightThreshold", 0.90);
            };
            var postProcess2 = new BABYLON.BlurPostProcess("Horizontal blur", new BABYLON.Vector2(1.0, 0), blurWidth, 0.25, camera);
            var postProcess3 = new BABYLON.BlurPostProcess("Vertical blur", new BABYLON.Vector2(0, 1.0), blurWidth, 0.25, camera);
            var postProcess4 = new BABYLON.PostProcess("Final compose", "./postprocesses/compose", new Array<string>("sceneIntensity", "glowIntensity", "highlightIntensity"), new Array<string>("sceneSampler"), 1, camera, BABYLON.Texture.BILINEAR_SAMPLINGMODE);
            postProcess4.onApply = (effect) =>
            {
                effect.setTextureFromPostProcess("sceneSampler", postProcess0);
                effect.setFloat("sceneIntensity", 0.5);
                effect.setFloat("glowIntensity", 0.4);
                effect.setFloat("highlightIntensity", 1.0);
            };

            // Animations
            var alpha = 0.0;
            scene.registerBeforeRender(() =>
            {
                sphere0.position = new BABYLON.Vector3(20 * Math.Sin(alpha), 0, 20 * Math.Cos(alpha));
                sphere1.position = new BABYLON.Vector3(20 * Math.Sin(alpha), 0, -20 * Math.Cos(alpha));
                sphere2.position = new BABYLON.Vector3(20 * Math.Cos(alpha), 0, 20 * Math.Sin(alpha));

                cube.rotation.y += 0.01;
                cube.rotation.z += 0.01;

                alpha += 0.01;
            });

            this.scene.activeCamera.attachControl(this.canvas);
        }

        private void Scene17()
        {
            this.scene = new BABYLON.Scene(engine);
            var camera = new BABYLON.ArcRotateCamera("Camera", 0, 0, 10, BABYLON.Vector3.Zero(), scene);
            camera.setPosition(new BABYLON.Vector3(-5, 5, 0));
            camera.lowerBetaLimit = 0.1;
            camera.upperBetaLimit = (Math.PI / 2) * 0.99;
            camera.lowerRadiusLimit = 5;

            // Mirror
            var mirror = BABYLON.Mesh.CreateBox("Mirror", 1.0, scene);
            mirror.scaling = new BABYLON.Vector3(100.0, 0.01, 100.0);
            var material = new BABYLON.StandardMaterial("mirror", scene);
            material.diffuseColor = new BABYLON.Color3(0.4, 0.4, 0.4);
            material.specularColor = new BABYLON.Color3(0, 0, 0);
            material.reflectionTexture = new BABYLON.MirrorTexture("mirror", new BABYLON.Size { width = 512, height = 512 }, scene, true);
            //material.reflectionTexture.mirrorPlane = new BABYLON.Plane(0, -1.0, 0, 0.0);
            //material.reflectionTexture.level = 0.2;
            mirror.material = material;
            mirror.position = new BABYLON.Vector3(0, 0.0, 0);

            // Emitters
            var emitter0 = BABYLON.Mesh.CreateBox("emitter0", 0.1, scene);
            emitter0.isVisible = false;

            var emitter1 = BABYLON.Mesh.CreateBox("emitter1", 0.1, scene);
            emitter1.isVisible = false;

            //mirror.material.reflectionTexture.renderList.push(emitter0);
            //mirror.material.reflectionTexture.renderList.push(emitter1);

            // Particles
            var particleSystem = new BABYLON.ParticleSystem("particles", 4000, scene);
            particleSystem.particleTexture = new BABYLON.Texture("Flare.png", scene);
            particleSystem.minAngularSpeed = -0.5;
            particleSystem.maxAngularSpeed = 0.5;
            particleSystem.minSize = 0.1;
            particleSystem.maxSize = 0.5;
            particleSystem.minLifeTime = 0.5;
            particleSystem.maxLifeTime = 2.0;
            particleSystem.minEmitPower = 0.5;
            particleSystem.maxEmitPower = 4.0;
            particleSystem.emitter = emitter0;
            particleSystem.emitRate = 400;
            particleSystem.blendMode = BABYLON.ParticleSystem.BLENDMODE_ONEONE;
            particleSystem.minEmitBox = new BABYLON.Vector3(-0.5, 0, -0.5);
            particleSystem.maxEmitBox = new BABYLON.Vector3(0.5, 0, 0.5);
            particleSystem.direction1 = new BABYLON.Vector3(-1, 1, -1);
            particleSystem.direction2 = new BABYLON.Vector3(1, 1, 1);
            particleSystem.color1 = new BABYLON.Color4(1, 0, 0, 1);
            particleSystem.color2 = new BABYLON.Color4(0, 1, 1, 1);
            particleSystem.gravity = new BABYLON.Vector3(0, -2.0, 0);
            particleSystem.start();

            var particleSystem2 = new BABYLON.ParticleSystem("particles", 4000, scene);
            particleSystem2.particleTexture = new BABYLON.Texture("Flare.png", scene);
            particleSystem2.minSize = 0.1;
            particleSystem2.maxSize = 0.3;
            particleSystem2.minEmitPower = 1.0;
            particleSystem2.maxEmitPower = 2.0;
            particleSystem2.minLifeTime = 0.5;
            particleSystem2.maxLifeTime = 1.0;
            particleSystem2.emitter = emitter1;
            particleSystem2.emitRate = 500;
            particleSystem2.blendMode = BABYLON.ParticleSystem.BLENDMODE_ONEONE;
            particleSystem2.minEmitBox = new BABYLON.Vector3(0, 0, 0);
            particleSystem2.maxEmitBox = new BABYLON.Vector3(0, 0, 0);
            particleSystem2.gravity = new BABYLON.Vector3(0, -0.5, 0);
            particleSystem2.direction1 = new BABYLON.Vector3(0, 0, 0);
            particleSystem2.direction2 = new BABYLON.Vector3(0, 0, 0);
            particleSystem2.start();

            var alpha = 0.0;
            scene.registerBeforeRender(() =>
            {
                emitter1.position.x = 3.0 * Math.Cos(alpha);
                emitter1.position.y = 1.0;
                emitter1.position.z = 3.0 * Math.Sin(alpha);

                alpha += 0.05 * scene.getAnimationRatio();
            });

            this.scene.activeCamera.attachControl(this.canvas);
        }
    }
}