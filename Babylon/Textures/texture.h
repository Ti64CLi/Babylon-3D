#ifndef BABYLON_TEXTURE_H
#define BABYLON_TEXTURE_H

#include <memory>
#include <vector>

#include "iengine.h"
#include "iscene.h"
#include "baseTexture.h"

using namespace std;

namespace Babylon {

	// TODO: add animation type
	class Texture: public BaseTexture, public enable_shared_from_this<Texture> {

	public:
		typedef shared_ptr<Texture> Ptr;
		typedef vector<Ptr> Array;

	public:
		string name;
		// Members
		float uOffset;
		float vOffset;
		float uScale;
		float vScale;
		float uAng;
		float vAng;
		float wAng;
		ADDRESSMODES wrapU;
		ADDRESSMODES wrapV;
		float coordinatesIndex;
		MODES coordinatesMode;
		int anisotropicFilteringLevel;
		vector<shared_ptr<void>> animations;
		// TAGS
		int _cachedAnisotropicFilteringLevel;
		bool _noMipmap;
		bool _invertY;

	public: 
		Texture(string url, IScene::Ptr scene, bool noMipmap, bool invertY);		
	};

};

#endif // BABYLON_TEXTURE_H