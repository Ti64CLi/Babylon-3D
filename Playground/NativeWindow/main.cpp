#include <memory>

#include <stdlib.h>
#include <stdio.h>
#include <ctype.h>

#include <GL/glew.h>
#include <GL/glut.h>

#include <nvGlutManipulators.h>

#include "engine.h"
#include "canvas.h"

using namespace std;

nv::GlutExamine manipulator;

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
}

void draw_quad() {
	glBegin(GL_QUADS);
	glTexCoord3f(0.0, 0.0, 0.0);
	glVertex2f(-1.0, -1.0);
	glTexCoord3f(1.0, 0.0, 4.0);
	glVertex2f(1.0, -1.0);
	glTexCoord3f(1.0, 1.0, 4.0);
	glVertex2f(1.0, 1.0);
	glTexCoord3f(0.0, 1.0, 0.0);
	glVertex2f(-1.0, 1.0);
	glEnd();
}

void display() {
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
	//
	// This part is the basic rendering with no postprocessing
	//
	manipulator.applyTransform();

	glPolygonMode( GL_FRONT_AND_BACK, GL_FILL);

	glEnable(GL_LIGHTING);
	glEnable(GL_LIGHT0);
	glEnable(GL_COLOR_MATERIAL);
	glEnable(GL_DEPTH_TEST);
	glColor3f(1.0, 0.0, 0.5);
	glutSolidTorus(0.2, 1.0, 20, 30);
	glColor3f(0.3, 0.5, 1.0);
	glutSolidTeapot(0.5f);
	glRotatef(90.0, 1.0, 0,0);
	glColor3f(1.0, 1.0, 0.5);
	glutWireTorus(0.2, 1.0, 20, 30);
	glDisable(GL_LIGHTING);

	glDisable(GL_FRAGMENT_PROGRAM_ARB);

	glutSwapBuffers();
}

void idle() {
	manipulator.idle();
	glutPostRedisplay();
}

void key(unsigned char k, int x, int y) {
	glutPostRedisplay();
}

void resize(int w, int h) {
	glViewport(0, 0, w, h);

	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();

	gluPerspective(60.0, (GLfloat)w/(GLfloat)h, 0.1, 100.0);

	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();

	manipulator.reshape(w, h);
}

void mouse(int button, int state, int x, int y) {
	manipulator.mouse(button, state, x, y);
	glutPostRedisplay();
}

void passiveMotion(int x, int y) {
	glutPostRedisplay();
}

void motion(int x, int y) {
	manipulator.motion(x, y);
}

int main(int argc, char **argv) {
	glutInit(&argc, argv);
	glutInitWindowSize(512, 512);
	glutInitDisplayMode(GLUT_DOUBLE | GLUT_DEPTH | GLUT_RGB);
	glutCreateWindow("Babylon Native");

	init_opengl();

	manipulator.setDollyActivate( GLUT_LEFT_BUTTON, GLUT_ACTIVE_SHIFT);
	manipulator.setPanActivate( GLUT_LEFT_BUTTON, GLUT_ACTIVE_CTRL);
	manipulator.setDollyPosition( -2.0f);

	glutDisplayFunc(display);
	glutPassiveMotionFunc(passiveMotion);
	glutMouseFunc(mouse);
	glutMotionFunc(motion);
	glutIdleFunc(idle);
	glutKeyboardFunc(key);
	glutReshapeFunc(resize);

	// engine
	auto canvas = dynamic_pointer_cast<Babylon::ICanvas>( make_shared<Canvas>() );
	auto engine = make_shared<Babylon::Engine>(canvas, true);

	// main loop
	glutMainLoop();

	return 0;
}
