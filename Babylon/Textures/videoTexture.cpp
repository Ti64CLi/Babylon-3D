#include "videoTexture.h"
#include "engine.h"

using namespace Babylon;

Babylon::VideoTexture::VideoTexture(string name, vector<string> urls, Size size, Scene::Ptr scene, bool generateMipMaps)
	: Texture(nullptr, scene, false, false),
	_autoLaunch(false)
{
	// this is in base class
	//this->_scene = scene;
	// moved to new
	////this->_scene->textures.push_back(enable_shared_from_this<VideoTexture>::shared_from_this());

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

	// TODO: finish it
	////this->video.addEventListener("canplaythrough", [&]() {
	////	if (this->_texture) {
	////		this->_texture->isReady = true;
	////	}
	////});

	for(auto url : urls) {
		this->video->appendSource(url);
	};

	localtime(&this->_lastUpdate);
};

VideoTexture::Ptr Babylon::VideoTexture::New(string name, vector<string> urls, Size size, Scene::Ptr scene, bool generateMipMaps) {
	auto videoTexture = make_shared<VideoTexture>(VideoTexture(name, urls, size, scene, generateMipMaps));
	videoTexture->_scene->textures.push_back(videoTexture);
	return videoTexture;
}

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

