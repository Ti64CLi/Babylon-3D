#include "texture.h"

using namespace Babylon;

Babylon::Texture::Texture(string url, IScene::Ptr scene,  bool noMipmap, bool invertY) :
	BaseTexture(url, scene),
	uOffset (0),
	vOffset (0),
	uScale (1.0),
	vScale (1.0),
	uAng (0),
	vAng (0),
	wAng (0),
	wrapU (WRAP_ADDRESSMODE),
	wrapV (WRAP_ADDRESSMODE),
	coordinatesIndex (0),
	coordinatesMode (EXPLICIT_MODE),
	anisotropicFilteringLevel (4)
{
	// TODO: is it is base class?
	//this->_scene = scene;
	//this->_scene->getTextures().push_back(enable_shared_from_this<Texture>::shared_from_this());

	this->name = url;
	this->url = url;
	this->_noMipmap = noMipmap;
	this->_invertY = invertY;

	this->_texture = this->_getFromCache(url, noMipmap);

	if (!this->_texture) {
		if (!scene->getUseDelayedTextureLoading()) {
			this->_texture = scene->getEngine()->createTexture(url, noMipmap, invertY, scene);
		} else {
			this->delayLoadState = DELAYLOADSTATE_NOTLOADED;
		}
	}

	// Animations
	this->animations.clear();
};

