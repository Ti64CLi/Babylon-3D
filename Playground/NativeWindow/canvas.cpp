#include "canvas.h"
#include <memory>

#include <GL/glew.h>
#include <GL/glut.h>

#include "gl.h"

Babylon::IGL::Ptr Canvas::getContext3d(bool antialias) {
	return make_shared<GL>(shared_from_this(), antialias);
}

int Canvas::getWidth() {
	return glutGet(GLUT_WINDOW_WIDTH);
}

int Canvas::getHeight() {
	return glutGet(GLUT_WINDOW_HEIGHT);
}

void Canvas::setWidth(int width) {
	glutReshapeWindow(width, getClientHeight());
}

void Canvas::setHeight(int height) {
	glutReshapeWindow(getClientWidth(), height);
}

int Canvas::getClientWidth() {
	return glutGet(GLUT_WINDOW_WIDTH); // GLUT_SCREEN_WIDTH?
}

int Canvas::getClientHeight() {
	return glutGet(GLUT_WINDOW_HEIGHT);// GLUT_SCREEN_HEIGHT?
}

Babylon::I2D::Ptr Canvas::getContext2d() {
	return nullptr;
}

void Canvas::raiseEvent_Move(int x, int y) {
	for (auto moveHandler : this->moveHandlers)
	{
		moveHandler(x, y);
	}
}

void Canvas::addEventListener_OnMoveEvent(MoveFunc moveFunc) {
	this->moveHandlers.push_back(moveFunc);
}
