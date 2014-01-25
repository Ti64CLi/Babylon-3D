#ifndef BABYLON_TOOLS_H
#define BABYLON_TOOLS_H

#include "vector3.h"

namespace Babylon {

	class Tools {

		static int deltaTime;

	public:	
		static bool WithinEpsilon(float a, float b);
		static RangeVector ExtractMinAndMax(Float32Array positions, int start, int count);
		static int GetDeltaTime();
	};

};

#endif // BABYLON_TOOLS_H