#include "canvas.h"
#include "defs.h"

#include <EGL/egl.h>
#include <GLES2/gl2.h>
#include <GLES2/gl2ext.h>

#include "gl.h"

Babylon::IGL::Ptr Canvas::getContext3d(bool antialias) {
	return make_shared<GL>(shared_from_this(), antialias);
}

int Canvas::getWidth() {
	return this->width;
}

int Canvas::getHeight() {
	return this->height;
}

void Canvas::setWidth(int width) {
}

void Canvas::setHeight(int height) {
}

int Canvas::getClientWidth() {
	return this->width;
}

int Canvas::getClientHeight() {
	return this->height;
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
