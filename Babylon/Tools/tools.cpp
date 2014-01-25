#include "tools.h"
#include <limits>

int Babylon::Tools::deltaTime = 0;

bool Babylon::Tools::WithinEpsilon(float a, float b) {
	auto num = a - b;
	return -1.401298E-45 <= num && num <= 1.401298E-45;
};

Babylon::RangeVector Babylon::Tools::ExtractMinAndMax(Float32Array positions, int start, int count) {
	auto minimum = make_shared<Vector3>(numeric_limits<float>::max(), numeric_limits<float>::max(), numeric_limits<float>::max());
	auto maximum = make_shared<Vector3>(-numeric_limits<float>::max(), -numeric_limits<float>::max(), -numeric_limits<float>::max());

	for (auto index = start; index < start + count; index++) {
		auto current = make_shared<Vector3>(positions[index * 3], positions[index * 3 + 1], positions[index * 3 + 2]);

		minimum = Vector3::Minimize(current, minimum);
		maximum = Vector3::Maximize(current, maximum);
	}

	return RangeVector(minimum, maximum);
};

int Babylon::Tools::GetDeltaTime()
{
	return deltaTime;
}
