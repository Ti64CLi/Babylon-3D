#include "tools.h"

bool Babylon::Tools::WithinEpsilon(float a, float b) {
	auto num = a - b;
	return -1.401298E-45 <= num && num <= 1.401298E-45;
};
