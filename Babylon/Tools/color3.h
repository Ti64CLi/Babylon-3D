#ifndef BABYLON_COLOR3_H
#define BABYLON_COLOR3_H

#include "decls.h"
#include "iengine.h"

namespace Babylon {

	struct Color3: public enable_shared_from_this<Color3> {

	public:
		typedef shared_ptr_t<Color3> Ptr;

		int r;
		int g;
		int b;

	public: 
		Color3(int initialR, int initialG, int initialB);		

		virtual Color3::Ptr multiply(Color3::Ptr otherColor);
		virtual void multiplyToRef(Color3::Ptr otherColor, Color3::Ptr result);
		virtual bool equals(Color3::Ptr otherColor);

		virtual Color3::Ptr scale(float scale);
		virtual void scaleToRef(float scale, Color3::Ptr result);
		virtual Color3::Ptr clone();
		virtual void copyFrom(Color3::Ptr source);
		virtual void copyFromFloats(float, float, float);
		static Color3::Ptr FromArray(Float32Array);
	};

};

#endif // BABYLON_COLOR3_H