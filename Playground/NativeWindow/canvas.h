#ifndef CANVAS_H
#define CANVAS_H

#include <memory>
#include "icanvas.h"
#include "igl.h"

class Canvas : public Babylon::ICanvas, public enable_shared_from_this<Canvas> {

public: 
	Canvas()
	{
	}

	virtual Babylon::IGL::Ptr getContext3d(bool);
	virtual int getWidth();
	virtual int getHeight();
	virtual void setWidth(int);
	virtual void setHeight(int);
	virtual int getClientWidth();
	virtual int getClientHeight();
	virtual Babylon::I2D::Ptr getContext2d();
};

#endif // CANVAS_H