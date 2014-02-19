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

class LoadedImage : public Babylon::IImage
{
private:
	int _width;
	int _height;
	Babylon::any _bits;

public:
	LoadedImage(int width, int height, Babylon::any bits) : _width(width), _height(height), _bits(bits)
	{
	}

	int getWidth() { return _width; }
	int getHeight() { return _height; };
	Babylon::any getBits() { return _bits; };
};

void Babylon::Canvas::loadImage(string url, function_t<void (Babylon::IImage::Ptr)> onload, function_t<void (void)> onerror) {
	this->onImageLoaded[url] = onload;
	this->onImageError[url] = onerror;
	this->fileLoader(url.c_str());
}

void Babylon::Canvas::raiseEvent_OnImageLoaded(string name, int width, int height, void* pixels) {
	auto image = make_shared<LoadedImage>(width, height, pixels);

 	auto onload = this->onImageLoaded[name];
	auto onerror = this->onImageError[name];

	auto imageInterface = dynamic_pointer_cast<Babylon::IImage>(image);
	onload(imageInterface);

	this->onImageLoaded.erase(name);
	this->onImageError.erase(name);
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
