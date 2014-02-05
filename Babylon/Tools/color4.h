#ifndef BABYLON_COLOR4_H
#define BABYLON_COLOR4_H

#include <memory>
#include <vector>

using namespace std;

namespace Babylon {

	struct Color4: public enable_shared_from_this<Color4> {

	public:
		typedef shared_ptr<Color4> Ptr;

	public:
		float r;
		float g;
		float b;
		float a;

	public: 
		Color4(float initialR, float initialG, float initialB, float initialA);		

		virtual void addInPlace(Color4::Ptr right);
		virtual Color4::Ptr add(Color4::Ptr otherColor);
		virtual Color4::Ptr subtract(Color4::Ptr otherColor);
		virtual void subtractToRef(Color4::Ptr otherColor, Color4::Ptr result);

		virtual Color4::Ptr scale(float scale);
		virtual void scaleToRef(float scale, Color4::Ptr result);
		virtual Color4::Ptr Lerp(Color4::Ptr left, Color4::Ptr right, float amount);
		static void LerpToRef(Color4::Ptr left, Color4::Ptr right, float amount, Color4::Ptr result);
		virtual Color4::Ptr clone();
		static Color4::Ptr FromArray(vector<float>);
	};

};

#endif // BABYLON_COLOR4_H