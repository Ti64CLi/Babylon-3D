#ifndef BABYLON_VIDEOTEXTURE_H
#define BABYLON_VIDEOTEXTURE_H

#include <memory>
#include <vector>
#include <time.h>

#include "iengine.h"
#include "iscene.h"
#include "texture.h"

using namespace std;

namespace Babylon {

	class VideoTexture: public Texture, public enable_shared_from_this<VideoTexture> {

	public:
		typedef shared_ptr<VideoTexture> Ptr;
		typedef vector<Ptr> Array;

	protected:
		IVideo::Ptr video;
		bool _autoLaunch;
		time_t _lastUpdate;

	public: 
		VideoTexture(string name, vector<string> urls, Size size, IScene::Ptr scene, bool generateMipMaps);		

		virtual bool _update();
	};

};

#endif // BABYLON_VIDEOTEXTURE_H