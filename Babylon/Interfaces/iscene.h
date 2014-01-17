#ifndef BABYLON_ISCENE_H
#define BABYLON_ISCENE_H

#include <memory>
#include <vector>

using namespace std;

namespace Babylon {

	class BaseTexture;

	class IScene {

	public:
		typedef shared_ptr<IScene> Ptr;

	public:
		virtual vector<shared_ptr<BaseTexture>>& getTextures() = 0;
	};

};

#endif // BABYLON_ISCENE_H