#include "canvas.h"
#include "defs.h"

#include <android/log.h>
#include <EGL/egl.h>
#include <GLES2/gl2.h>
#include <GLES2/gl2ext.h>
#include "FreeImage.h"

#include "gl.h"

#define LOGI(...) ((void)__android_log_print(ANDROID_LOG_INFO, "native-activity", __VA_ARGS__))
#define LOGW(...) ((void)__android_log_print(ANDROID_LOG_WARN, "native-activity", __VA_ARGS__))

using namespace std;

using namespace Ogre;

static bool gInit = false;
static Ogre::Root* gRoot = NULL;
static Ogre::RenderWindow* gRenderWnd = NULL;


Babylon::IGL::Ptr Canvas::getContext3d(bool antialias) {
	FreeImage_Initialise(FALSE);
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

void FreeImage_SwapColorOrder32(BYTE *target, BYTE *source, int width_in_pixels) {
	for (int cols = 0; cols < width_in_pixels; cols++) {
		auto tmp = target[FI_RGBA_RED];
		target[FI_RGBA_RED] = source[FI_RGBA_BLUE];
		target[FI_RGBA_BLUE] = tmp;	
		target += 4;
		source += 4;
	}
}

void Canvas::loadImage(string url, function_t<void (Babylon::IImage::Ptr)> onload, function_t<void (void)> onerror) {
	// load image
	FREE_IMAGE_FORMAT fif = FIF_UNKNOWN;
	//pointer to the image, once loaded
	FIBITMAP *dib(0);
	//pointer to the image data

	LOGI("Loading image");
	LOGI(url.c_str());

	//copy file from Asset
	string path = this->fileLoader(url.c_str());

	fif = FreeImage_GetFileType(path.c_str(), 0);
	//if still unknown, try to guess the file format from the file extension
	if(fif == FIF_UNKNOWN) 
	{
		LOGI("File Format can't be detected. trying to detect file format from filename");

		fif = FreeImage_GetFIFFromFilename(path.c_str());
	}

	//if still unkown, return failure
	if(fif == FIF_UNKNOWN)
	{
		LOGI("File Format still unkown, return failure");

		onerror();
		return;
	}

	//check that the plugin has reading capabilities and load the file
	if(FreeImage_FIFSupportsReading(fif))
		dib = FreeImage_Load(fif, path.c_str());
	//if the image failed to load, return failure
	if(!dib)
	{
		LOGI("the image failed to load, return failure");

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

	// fix color order
	for (int rows = 0; rows < height; rows++) {
		FreeImage_SwapColorOrder32(FreeImage_GetScanLine(dib32bit, rows), FreeImage_GetScanLine(dib32bit, rows), width);
	}

	auto bits = FreeImage_GetBits(dib32bit);

	//if this somehow one of these failed (they shouldn't), return failure
	if((bits == 0) || (width == 0) || (height == 0))
	{
		LOGI("the image failed to load(bits or width or hight is 0), return failure");

		onerror();
		return;
	}

	LOGI("Image loaded.");

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