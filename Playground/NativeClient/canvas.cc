#include "canvas.h"
#include "defs.h"

#include <GLES2/gl2.h>
#include "ppapi/lib/gl/gles2/gl2ext_ppapi.h"

#include "gl.h"

Babylon::IGL::Ptr Babylon::Canvas::getContext3d(bool antialias) {
	return make_shared<GL>(shared_from_this(), antialias);
}

int Babylon::Canvas::getWidth() {
	return this->width;
}

int Babylon::Canvas::getHeight() {
	return this->height;
}

void Babylon::Canvas::setWidth(int width) {
}

void Babylon::Canvas::setHeight(int height) {
}

int Babylon::Canvas::getClientWidth() {
	return this->width;
}

int Babylon::Canvas::getClientHeight() {
	return this->height;
}

Babylon::I2D::Ptr Babylon::Canvas::getContext2d() {
	return nullptr;
}

void Babylon::Canvas::raiseEvent_Move(int x, int y) {
	for (auto moveHandler : this->moveHandlers)
	{
		moveHandler(x, y);
	}
}

void Babylon::Canvas::addEventListener_OnMoveEvent(MoveFunc moveFunc) {
	this->moveHandlers.push_back(moveFunc);
}
