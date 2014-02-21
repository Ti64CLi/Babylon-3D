#include "canvas.h"
#include "defs.h"

#include <GL/glew.h>
#include <GL/glut.h>
#include <FreeImage.h>

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

void Canvas::loadImage(string url, function_t<void (Babylon::IImage::Ptr)> onload, function_t<void (void)> onerror) {
	// load image
 	FREE_IMAGE_FORMAT fif = FIF_UNKNOWN;
	//pointer to the image, once loaded
	FIBITMAP *dib(0);
	//pointer to the image data
	
	//check the file signature and deduce its format
	fif = FreeImage_GetFileType(url.c_str(), 0);
	//if still unknown, try to guess the file format from the file extension
	if(fif == FIF_UNKNOWN) 
		fif = FreeImage_GetFIFFromFilename(url.c_str());
	//if still unkown, return failure
	if(fif == FIF_UNKNOWN)
	{
		onerror();
		return;
	}

	//check that the plugin has reading capabilities and load the file
	if(FreeImage_FIFSupportsReading(fif))
		dib = FreeImage_Load(fif, url.c_str());
	//if the image failed to load, return failure
	if(!dib)
	{
		onerror();
		return;
	}

	//retrieve the image data
	//auto bits = FreeImage_GetBits(dib);
	//get the image width and height
	auto dib32bit = FreeImage_ConvertTo32Bits(dib);

	//Free FreeImage's copy of the data
	FreeImage_Unload(dib);

	auto width = FreeImage_GetWidth(dib32bit);
	auto height = FreeImage_GetHeight(dib32bit);

	auto bits = FreeImage_GetBits(dib32bit);

	//if this somehow one of these failed (they shouldn't), return failure
	if((bits == 0) || (width == 0) || (height == 0))
	{
		onerror();
		return;
	}

	auto image = make_shared<LoadedImage>(width, height, bits);
	onload(dynamic_pointer_cast<Babylon::IImage>(image));

	//Free FreeImage's copy of the data
	FreeImage_Unload(dib32bit);
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
