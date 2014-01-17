#ifndef BABYLON_CANVAS_H
#define BABYLON_CANVAS_H

#include <memory>
#include <vector>

using namespace std;

namespace Babylon {

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
	};

};

#endif // BABYLON_CANVAS_H