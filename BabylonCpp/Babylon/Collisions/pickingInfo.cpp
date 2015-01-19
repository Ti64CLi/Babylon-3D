#include "pickingInfo.h"
#include "defs.h"

using namespace Babylon;

Babylon::PickingInfo::PickingInfo() :
	hit(false),
	distance(0),
	pickedPoint(nullptr),
	pickedMesh(nullptr)
{
}
