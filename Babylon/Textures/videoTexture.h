#ifndef BABYLON_VIDEOTEXTURE_H
#define BABYLON_VIDEOTEXTURE_H

#include <memory>
#include <vector>

#include "iengine.h"
#include "iscene.h"
#include "baseTexture.h"

using namespace std;

namespace Babylon {

	class VideoTexture: public BaseTexture, public enable_shared_from_this<VideoTexture> {

	public:
		typedef shared_ptr<VideoTexture> Ptr;
		typedef vector<Ptr> Array;

	public: 
		VideoTexture();		
	};

};

#endif // BABYLON_VIDEOTEXTURE_H