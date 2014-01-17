#include "baseTexture.h"

using namespace Babylon;

Babylon::BaseTexture::BaseTexture(string url, IScene::Ptr scene) 
	: delayLoadState(DELAYLOADSTATE_NONE), hasAlpha(false), level(1), _texture(nullptr), onDispose(nullptr) {
		this->scene = scene;
		this->scene->getTextures().push_back(shared_from_this());
};
