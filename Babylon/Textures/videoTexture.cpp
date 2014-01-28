#include "videoTexture.h"
#include "engine.h"

using namespace Babylon;

Babylon::VideoTexture::VideoTexture(string name, vector<string> urls, Size size, Scene::Ptr scene, bool generateMipMaps)
	: Texture(nullptr, scene, false, false),
	_autoLaunch(false)
{
	this->_scene = scene;
	this->_scene->textures.push_back(enable_shared_from_this<VideoTexture>::shared_from_this());

	this->name = name;

	this->wrapU = WRAP_ADDRESSMODE;
	this->wrapV = WRAP_ADDRESSMODE;

	this->_texture = scene->getEngine()->createDynamicTexture(size.width, size.height, generateMipMaps);
	auto textureSize = this->getSize();

	// TODO: add functionality to create video
	////this->video = document.createElement("video");
	this->video->setVideoWidth(textureSize.width);
	this->video->setVideoHeight(textureSize.height);
	this->video->setAutoplay(false);
	this->video->setLoop(true);
	this->video->setPreload(true);
	this->_autoLaunch = true;

	auto that = this;

	// TODO: finish it
	////this->video.addEventListener("canplaythrough", [&that]() {
	////	if (that->_texture) {
	////		that->_texture->isReady = true;
	////	}
	////});

	for(auto url : urls) {
		this->video->appendSource(url);
	};

	localtime(&this->_lastUpdate);
};

bool Babylon::VideoTexture::_update() {
	if (this->_autoLaunch) {
		this->_autoLaunch = false;
		this->video->play();
	}

	time_t now;
	localtime(&now);

	if (now - this->_lastUpdate < 15) {
		return false;
	}

	this->_lastUpdate = now;
	this->_scene->getEngine()->updateVideoTexture(this->_texture, this->video);
	return true;
};

