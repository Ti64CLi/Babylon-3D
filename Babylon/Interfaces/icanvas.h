#ifndef BABYLON_CANVAS_H
#define BABYLON_CANVAS_H

#include "decls.h"

namespace Babylon {

	class IGL;
	typedef shared_ptr<IGL> IGLPtr;

	class IImage {
	public:
		typedef shared_ptr<IImage> Ptr;
		typedef vector<Ptr> Array;

	public: 
		virtual int getWidth() = 0;
		virtual int getHeight() = 0;
	};

	class IVideo {
	public:
		typedef shared_ptr<IVideo> Ptr;

	public: 
		virtual int getVideoWidth() = 0;
		virtual int getVideoHeight() = 0;
		virtual bool getAutoplay() = 0;
		virtual bool getLoop() = 0;
		virtual bool getPreload() = 0;

		virtual void setVideoWidth(int) = 0;
		virtual void setVideoHeight(int) = 0;
		virtual void setAutoplay(bool) = 0;
		virtual void setLoop(bool) = 0;
		virtual void setPreload(bool) = 0;

		virtual void appendSource(string url) = 0;
		virtual void play() = 0;
	};

	class I2D {

	public:
		typedef shared_ptr<I2D> Ptr;

	public: 
		virtual int drawImage(IImage::Ptr image, int sx, int sy, int sw, int sh, int dx, int dy, int dw, int dh) = 0;
		virtual int drawImage(IVideo::Ptr video, int sx, int sy, int sw, int sh, int dx, int dy, int dw, int dh) = 0;
	};

	class ICanvas {

	public:
		typedef shared_ptr<ICanvas> Ptr;

		typedef function<void (int x, int y)> MoveFunc;
		typedef vector<MoveFunc> MoveFuncArray;

	public: 

		virtual IGLPtr getContext3d(bool) = 0; 

		virtual int getWidth() = 0;
		virtual int getHeight() = 0;
		virtual void setWidth(int) = 0;
		virtual void setHeight(int) = 0;

		virtual int getClientWidth() = 0;
		virtual int getClientHeight() = 0;
		virtual I2D::Ptr getContext2d() = 0;

		virtual void addEventListener_OnMoveEvent(MoveFunc moveFunc) = 0;
	};

};

#endif // BABYLON_CANVAS_H