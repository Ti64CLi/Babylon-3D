#ifndef BABYLON_COLOR3_H
#define BABYLON_COLOR3_H

#include <memory>
#include <vector>

using namespace std;

namespace Babylon {

	struct Color3: public enable_shared_from_this<Color3> {

	public:
		typedef shared_ptr<Color3> Ptr;

		int r;
		int g;
		int b;

	public: 
		Color3(int initialR, int initialG, int initialB);		

		virtual string toString();
		virtual Color3::Ptr multiply(Color3::Ptr otherColor);
		virtual void multiplyToRef(Color3::Ptr otherColor, Color3::Ptr result);
		virtual bool equals(Color3::Ptr otherColor);

		virtual Color3::Ptr scale(float scale);
		virtual void scaleToRef(float scale, Color3::Ptr result);
		virtual Color3::Ptr clone();
		virtual void copyFrom(Color3::Ptr source);
		virtual void copyFromFloats(float, float, float);
		static Color3::Ptr FromArray(vector<float>);
	};

};

#endif // BABYLON_COLOR3_H