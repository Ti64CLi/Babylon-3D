#ifndef BABYLON_ShadowGenerator_H
#define BABYLON_ShadowGenerator_H

#include <memory>
#include <vector>
#include <map>

#include "iscene.h"
#include "node.h"
#include "matrix.h"
#include "mesh.h"
#include "vertexBuffer.h"
#include "ilight.h"

using namespace std;

namespace Babylon {

	// TODO: add animations
	// TODO: to avoid cercular reference we do not store light here
	class ShadowGenerator : public enable_shared_from_this<ShadowGenerator> {

	public:

		typedef shared_ptr<ShadowGenerator> Ptr;
		typedef vector<Ptr> Array;

		class Light;
		typedef shared_ptr<Light> LightPtr;

	private:
		ILight::Ptr _light;
		IScene::Ptr _scene;

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
		ShadowGenerator(int width, int height, ILight::Ptr light);
		virtual bool isReady(Mesh::Ptr mesh);
		////virtual RenderTargetTexture::Ptr getShadowMap();
		virtual ILight::Ptr getLight();
		virtual bool dispose();
		virtual Matrix::Ptr getTransformMatrix();
	};

};

#endif // BABYLON_ShadowGenerator_H