#ifndef BABYLON_ILIGHT_H
#define BABYLON_ILIGHT_H

#include <memory>
#include <vector>
#include <map>

#include "iscene.h"
#include "node.h"
#include "mesh.h"
#include "vector3.h"

using namespace std;

namespace Babylon {

	// TODO: add animations
	class ILight  {

	public:

		typedef shared_ptr<ILight> Ptr;

		Vector3::Ptr _transformedPosition;

		virtual IScene::Ptr getScene() = 0;
		// Methods
		virtual void transferToEffect() = 0;
		virtual Matrix::Ptr getWorldMatrix() = 0;
		virtual void dispose() = 0;

		// for directional light
		virtual bool _computeTransformedPosition() = 0;
	};

};

#endif // BABYLON_ILIGHT_H