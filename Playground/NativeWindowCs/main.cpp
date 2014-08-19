#include <GL/glut.h>

int main(int argc, char **argv) {
	glutInit(&argc, argv);

	glutInitWindowSize(400, 640);
	glutInitDisplayMode(GLUT_DOUBLE | GLUT_DEPTH | GLUT_RGB);
	glutCreateWindow("Babylon Native CS");

	/*
	glutDisplayFunc(display);
	glutPassiveMotionFunc(passiveMotion);
	glutMouseFunc(mouse);
	glutMotionFunc(motion);
	glutIdleFunc(idle);
	glutKeyboardFunc(key);
	glutReshapeFunc(resize);
	*/

	//_main.init();
	//_main.loadSceneTutorial4();

	// main loop
	glutMainLoop();

	return 0;
}
