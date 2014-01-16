#include "canvas.h"

class Babylon::Canvas::CanvasImpl {  
public:
	int width;
	int height;

	CanvasImpl() : width(0), height(0) {
	};
};

Babylon::Canvas::Canvas(): pimpl( new Babylon::Canvas::CanvasImpl )
{
};

int Babylon::Canvas::getWidth()
{
	return pimpl->width;
};

int Babylon::Canvas::getHeight()
{
	return pimpl->height;
};
