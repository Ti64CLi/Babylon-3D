#ifndef CANVAS_H
#define CANVAS_H

#include "decls.h"
#include "icanvas.h"
#include "igl.h"

namespace Babylon {

class Canvas : public Babylon::ICanvas, public enable_shared_from_this<Canvas> {

public: 

	typedef shared_ptr_t<Canvas> Ptr;

	int32_t width;
	int32_t height;

	Canvas(int32_t width, int32_t height)
	{
		this->width = width;
		this->height = height;
	}

private:
	MoveFuncArray moveHandlers;

public:
	virtual Babylon::IGL::Ptr getContext3d(bool);
	virtual int getWidth();
	virtual int getHeight();
	virtual void setWidth(int);
	virtual void setHeight(int);
	virtual int getClientWidth();
	virtual int getClientHeight();
	virtual Babylon::I2D::Ptr getContext2d();

	virtual void raiseEvent_Move(int x, int y);
	virtual void addEventListener_OnMoveEvent(MoveFunc moveFunc);
};

} // namespace

#endif // CANVAS_H