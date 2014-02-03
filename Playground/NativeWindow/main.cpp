#include <memory>

#include <stdlib.h>
#include <stdio.h>
#include <ctype.h>

#include <GL/glew.h>
#include <GL/glut.h>

#include "iengine.h"
#include "canvas.h"
#include "engine.h"
#include "arcRotateCamera.h"
#include "pointLight.h"
#include "strings.h"

using namespace std;
using namespace Babylon;

class Main {

	// engine
	Canvas::Ptr canvas;
	Engine::Ptr engine;
	Scene::Ptr scene;

public:

	Main()
	{
	}

	void init()
	{
		// engine
		this->canvas = make_shared<Canvas>();
		this->engine = Engine::New(dynamic_pointer_cast<ICanvas>(this->canvas), true);

		// for testing loading shaders manually
		Effect::ShadersStore["defaultVertexShader"] = defaultVertexShader;
		Effect::ShadersStore["defaultPixelShader"] = defaultPixelShader;
	}

	void loadSceneTutorial1() {
		// scene
		this->scene = Scene::New(engine);

		// Creating a camera looking to the zero point (0,0,0), a light, and a sphere of size 1
		auto camera = ArcRotateCamera::New("Camera", 1, 0.8, 10, make_shared<Vector3>(0, 0, 0), scene);
		auto light0 = PointLight::New("Omni", make_shared<Vector3>(0, 0, 10), scene);
		auto origin = Mesh::CreateSphere("origin", 10, 1.0, scene);

		// Attach the camera to the scene
		scene->activeCamera->attachControl(canvas);
	}

	void loadSceneTutorial2() {
		// scene
		this->scene = Scene::New(engine);

		// Creating a camera looking to the zero point (0,0,0), a light, and a sphere of size 1
		auto camera = ArcRotateCamera::New("Camera", 0, 0.8, 100, make_shared<Vector3>(0, 0, 0), scene);
		auto light0 = PointLight::New("Omni", make_shared<Vector3>(10, 10, -30), scene);

		auto box = Mesh::CreateBox("Box", 6.0, scene);
		auto sphere = Mesh::CreateSphere("Sphere", 10.0, 10.0, scene);	
		auto plan = Mesh::CreatePlane("Plane", 50.0, scene);

		// move object
		box->position = make_shared<Vector3>(-10,0,0);
		sphere->position = make_shared<Vector3>(0,10,0);
		plan->position->z = 10;

		// Attach the camera to the scene
		scene->activeCamera->attachControl(canvas);
	}

	void loadSceneTutorial3() {
		// scene
		this->scene = Scene::New(engine);

		// Creating a camera looking to the zero point (0,0,0), a light, and a sphere of size 1
		auto camera = ArcRotateCamera::New("Camera", 0, 0.8, 100, Vector3::Zero(), scene);
		auto light0 = PointLight::New("Omni", make_shared<Vector3>(0, 100, 100), scene);

		auto box1 = Mesh::CreateBox("Box1", 6.0, scene);
		auto box2 = Mesh::CreateBox("Box2", 6.0, scene);
		auto box3 = Mesh::CreateBox("Box3", 6.0, scene);

		//Positioning the boxes
		box1->position = make_shared<Vector3>(-20, 0, 0);
		box2->position->x = -10;
		box3->position->x = 0;

		//Rotate the box around the x axis
		box1->rotation->x = 3.14/4;

		//Rotate the box around the y axis
		box2->rotation->y = 3.14/6;

		//Scaling of 2x on the x axis
		box3->scaling->x = 2;

		//Positioning the box3 relative to the box1
		box3->parent = dynamic_pointer_cast<Node>(box1);
		box3->position->z = -10;

		// Attach the camera to the scene
		scene->activeCamera->attachControl(canvas);
	}

	void loadSceneTutorial4() {
		// scene
		this->scene = Scene::New(engine);

		// Creating a camera looking to the zero point (0,0,0), a light, and a sphere of size 1
		auto camera = ArcRotateCamera::New("Camera", 0, 0.8, 100, Vector3::Zero(), scene);
		auto light0 = PointLight::New("Omni", make_shared<Vector3>(20, 20, 100), scene);

		//Creation of 6 spheres
		auto sphere1 = Mesh::CreateSphere("Sphere1", 10.0, 6.0, scene);
		auto sphere2 = Mesh::CreateSphere("Sphere2", 2.0, 7.0, scene);//Only two segments
		auto sphere3 = Mesh::CreateSphere("Sphere3", 10.0, 9.0, scene);
		auto sphere4 = Mesh::CreateSphere("Sphere4", 10.0, 9.0, scene);
		auto sphere5 = Mesh::CreateSphere("Sphere5", 10.0, 9.0, scene);
		auto sphere6 = Mesh::CreateSphere("Sphere6", 10.0, 9.0, scene);

		//Positioning spheres
		sphere1->position->x = 40;
		sphere2->position->x = 30;
		sphere3->position->x = 10;
		sphere4->position->x = 0;
		sphere5->position->x = -20;
		sphere6->position->x = -30;

		//Creation of a plane
		auto plan = Mesh::CreatePlane("plan", 120, scene);
		plan->position->z = -10;
		plan->rotation->y = 3.14;

		//Creation of a material in wireFrame
		auto materialSphere1 = StandardMaterial::New("texture1", scene);
		materialSphere1->wireframe = true;

		//Creation of a red material with alpha
		auto materialSphere2 = StandardMaterial::New("texture2", scene);
		materialSphere2->diffuseColor = make_shared<Color3>(1, 0, 0); //Red
		materialSphere2->alpha = 0.3;


		//Creation of a material with an image
		auto materialSphere3 = StandardMaterial::New("texture3", scene);
		materialSphere3->diffuseTexture = Texture::New("text.jpg", scene);

		//Creation of a material, with translated texture
		auto materialSphere4 = StandardMaterial::New("texture4", scene);
		materialSphere4->diffuseTexture = Texture::New("text.jpg", scene);
		materialSphere4->diffuseTexture->vOffset = 0.1;//Offset of 10% vertical
		materialSphere4->diffuseTexture->uOffset = 0.4;//Offset of 40% horizontal

		//Creation of a material with alpha texture
		auto materialSphere5 = StandardMaterial::New("texture5", scene);
		materialSphere5->diffuseTexture = Texture::New("Planet.png", scene);//Planet
		materialSphere5->diffuseTexture->hasAlpha = true;//Have an alpha

		//Creation of a material and allways show all the faces
		auto materialSphere6 = StandardMaterial::New("texture6", scene);
		materialSphere6->diffuseTexture =  Texture::New("Planet.png", scene);//Planet
		materialSphere6->diffuseTexture->hasAlpha = true;//Have an alpha
		materialSphere6->backFaceCulling = false;//Allways show all the faces of the element

		//Creation of a repeated textured material
		auto materialPlan = StandardMaterial::New("texturePlane", scene);
		materialPlan->diffuseTexture =  Texture::New("grass_texture.jpg", scene);//Wood effect
		materialPlan->diffuseTexture->uScale = 5.0;//Repeat 5 times on the Vertical Axes
		materialPlan->diffuseTexture->vScale = 5.0;//Repeat 5 times on the Horizontal Axes
		materialPlan->backFaceCulling = false;//Allways show the front and the back of an element

		//Applying the materials to the mesh
		sphere1->material = materialSphere1;
		sphere2->material = materialSphere2;

		sphere3->material = materialSphere3;
		sphere4->material = materialSphere4;

		sphere5->material = materialSphere5;
		sphere6->material = materialSphere6;

		plan->material = materialPlan;

		// Attach the camera to the scene
		scene->activeCamera->attachControl(canvas);
	}

	void render() {
		this->scene->render();
	}

	void onMotion(int x, int y)
	{
		this->canvas->raiseEvent_Move(x, y);
	}
};

Main _main;

void init_opengl() {
	glEnable(GL_DEPTH_TEST);
	glClearColor(0.2, 0.2, 0.2, 1.0);

	glewInit();

	if (!glewIsSupported(
		"GL_VERSION_2_0 "
		"GL_EXT_framebuffer_object "
		"GL_ARB_vertex_program "
		"GL_ARB_fragment_program "
		))
	{
		printf("Unable to load extensions\n\nExiting...\n");
		exit(-1);
	}

	printf("OpenGL Version: %s\n", glGetString(GL_VERSION));
}

void display() {
	_main.render();
	glutSwapBuffers();
}

void idle() {
	glutPostRedisplay();
}

void key(unsigned char k, int x, int y) {
	glutPostRedisplay();
}

void resize(int w, int h) {
}

void mouse(int button, int state, int x, int y) {
	glutPostRedisplay();
}

void passiveMotion(int x, int y) {
	glutPostRedisplay();
}

void motion(int x, int y) {
	_main.onMotion(x, y);
}

int main(int argc, char **argv) {
	glutInit(&argc, argv);

	glutInitWindowSize(512, 512);
	glutInitDisplayMode(GLUT_DOUBLE | GLUT_DEPTH | GLUT_RGB);
	glutCreateWindow("Babylon Native");

	init_opengl();

	glutDisplayFunc(display);
	glutPassiveMotionFunc(passiveMotion);
	glutMouseFunc(mouse);
	glutMotionFunc(motion);
	glutIdleFunc(idle);
	glutKeyboardFunc(key);
	glutReshapeFunc(resize);

	_main.init();
	_main.loadSceneTutorial4();

	// main loop
	glutMainLoop();

	return 0;
}
