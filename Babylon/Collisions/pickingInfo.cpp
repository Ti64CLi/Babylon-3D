#include "pickingInfo.h"

using namespace Babylon;

Babylon::PickingInfo::PickingInfo() :
	hit(false),
	distance(0),
	pickedPoint(nullptr),
	pickedMesh(nullptr)
{
}
