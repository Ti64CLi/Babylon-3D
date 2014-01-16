#ifndef BABYLON_CANVAS_H
#define BABYLON_CANVAS_H

#include <memory>
#include <vector>

using namespace std;

namespace Babylon {

	class Canvas: public enable_shared_from_this<Canvas> {

	public:
		typedef shared_ptr<Canvas> Ptr;

	private:
		class CanvasImpl; 
		unique_ptr<CanvasImpl> pimpl; // opaque type here

	public: 
		Canvas();		

		virtual int getWidth();
		virtual int getHeight();
		virtual void setWidth(int);
		virtual void setHeight(int);

		virtual int getClientWidth();
		virtual int getClientHeight();
	};

};

#endif // BABYLON_CANVAS_H