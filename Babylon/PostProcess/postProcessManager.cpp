#include "postProcessManager.h"
#include "scene.h"

using namespace Babylon;

Babylon::PostProcessManager::PostProcessManager(Scene::Ptr scene)
{
	this->_scene = scene;
}
