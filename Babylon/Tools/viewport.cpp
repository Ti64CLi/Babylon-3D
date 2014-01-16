#include "viewport.h"

using namespace Babylon;

Babylon::Viewport::Viewport(int x, int y, int width, int height) {
	this->x = x;
	this->y = y;
	this->width = width;
	this->height = height;
};

Viewport::Ptr Babylon::Viewport::toGlobal(Engine::Ptr engine) {
	auto width = engine->getRenderWidth() * engine->getHardwareScalingLevel();
	auto height = engine->getRenderHeight() * engine->getHardwareScalingLevel();
	return make_shared<Viewport>(new Viewport(this->x * width, this->y * height, this->width * width, this->height * height));
};

