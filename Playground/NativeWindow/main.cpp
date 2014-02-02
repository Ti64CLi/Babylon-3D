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

	void loadSimpleScene() {
		// scene
		this->scene = Scene::New(engine);

		// Creating a camera looking to the zero point (0,0,0), a light, and a sphere of size 1
		auto camera = ArcRotateCamera::New("Camera", 1, 0.8, 10, make_shared<Vector3>(0, 0, 0), scene);
		auto light0 = PointLight::New("Omni", make_shared<Vector3>(0, 0, 10), scene);
		auto origin = Mesh::CreateSphere("origin", 10, 1.0, scene);

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
	_main.loadSimpleScene();

	// main loop
	glutMainLoop();

	return 0;
}
