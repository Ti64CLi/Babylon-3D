#ifndef BABYLON_TOOLS_H
#define BABYLON_TOOLS_H

#include "vector3.h"

namespace Babylon {

	class Tools {
	public:	
		static bool WithinEpsilon(float a, float b);
		static RangeVector ExtractMinAndMax(Float32Array positions, int start, int count);
	};

};

#endif // BABYLON_TOOLS_H