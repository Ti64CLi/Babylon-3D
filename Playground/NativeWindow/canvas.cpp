#include "canvas.h"
#include <memory>

#include <GL/glew.h>
#include <GL/glut.h>

#include "gl.h"

using namespace Babylon;

IGL::Ptr Canvas::getContext3d(bool antialias) {
	return make_shared<GL>(shared_from_this(), antialias);
}

int Canvas::getWidth() {
	return glutGet(GLUT_SCREEN_WIDTH);
}

int Canvas::getHeight() {
	return glutGet(GLUT_SCREEN_HEIGHT);
}

void Canvas::setWidth(int width) {
	glutReshapeWindow(width, getClientHeight());
}

void Canvas::setHeight(int height) {
	glutReshapeWindow(getClientWidth(), height);
}

int Canvas::getClientWidth() {
	return glutGet(GLUT_WINDOW_WIDTH);
}

int Canvas::getClientHeight() {
	return glutGet(GLUT_WINDOW_WIDTH);
}

I2D::Ptr Canvas::getContext2d() {
	return nullptr;
}
