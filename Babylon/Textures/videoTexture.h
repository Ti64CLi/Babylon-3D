#ifndef BABYLON_VIDEOTEXTURE_H
#define BABYLON_VIDEOTEXTURE_H

#include <memory>
#include <vector>
#include <time.h>

#include "iengine.h"
#include "texture.h"

using namespace std;

namespace Babylon {

	class VideoTexture: public Texture {

	public:
		typedef shared_ptr<VideoTexture> Ptr;
		typedef vector<Ptr> Array;

	protected:
		IVideo::Ptr video;
		bool _autoLaunch;
		time_t _lastUpdate;

	protected: 
		VideoTexture(string name, vector<string> urls, Size size, ScenePtr scene, bool generateMipMaps);		
	public: 
		static VideoTexture::Ptr New(string name, vector<string> urls, Size size, ScenePtr scene, bool generateMipMaps);

		virtual bool _update();
	};

};

#endif // BABYLON_VIDEOTEXTURE_H