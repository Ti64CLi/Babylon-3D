#ifndef BABYLON_ShadowGenerator_H
#define BABYLON_ShadowGenerator_H

#include <memory>
#include <vector>
#include <map>

#include "iengine.h"
#include "node.h"
#include "matrix.h"
#include "mesh.h"
#include "vertexBuffer.h"

using namespace std;

namespace Babylon {

	class Light;
	typedef shared_ptr<Light> LightPtr;

	// TODO: add animations
	class ShadowGenerator : public enable_shared_from_this<ShadowGenerator> {

	public:

		typedef shared_ptr<ShadowGenerator> Ptr;
		typedef vector<Ptr> Array;

	private:
		LightPtr _light;
		ScenePtr _scene;

		Matrix::Ptr _viewMatrix;
		Matrix::Ptr _projectionMatrix;
		Matrix::Ptr _transformMatrix;
		Matrix::Ptr _worldViewProjection;

		Vector3::Ptr _cachedPosition;
		Vector3::Ptr _cachedDirection;
		string _cachedDefines;

	public: 
		static bool useVarianceShadowMap;

	public: 
		ShadowGenerator(int width, int height, LightPtr light);
		virtual bool isReady(Mesh::Ptr mesh);
		virtual Texture::Ptr getShadowMap();
		virtual LightPtr getLight();
		virtual bool dispose();
		virtual Matrix::Ptr getTransformMatrix();
	};

};

#endif // BABYLON_ShadowGenerator_H