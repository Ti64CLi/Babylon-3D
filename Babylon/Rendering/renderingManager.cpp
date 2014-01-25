#include "renderingManager.h"
#include "scene.h"

using namespace Babylon;

Babylon::RenderingManager::RenderingManager(Scene::Ptr scene)
{
	this->_scene = scene;
}
