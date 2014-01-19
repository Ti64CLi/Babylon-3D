#ifndef BABYLON_CANVAS_H
#define BABYLON_CANVAS_H

#include <memory>
#include <vector>

using namespace std;

namespace Babylon {

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

	public: 
		virtual int getWidth() = 0;
		virtual int getHeight() = 0;
		virtual void setWidth(int) = 0;
		virtual void setHeight(int) = 0;

		virtual int getClientWidth() = 0;
		virtual int getClientHeight() = 0;
		virtual I2D::Ptr getContext2d() = 0;
	};

};

#endif // BABYLON_CANVAS_H