#ifndef BABYLON_SHADOWGENERATOR_H
#define BABYLON_SHADOWGENERATOR_H

#include <memory>
#include <vector>
#include <map>

#include "iengine.h"
#include "node.h"
#include "matrix.h"
#include "mesh.h"
#include "vertexbuffer.h"
#include "renderTargetTexture.h"

using namespace std;

namespace Babylon {

	class Light;
	typedef shared_ptr<Light> LightPtr;

	// TODO: add animations
	class ShadowGenerator : public IDisposable, public enable_shared_from_this<ShadowGenerator> {

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

		RenderTargetTexture::Ptr _shadowMap;
		Effect::Ptr _effect;

	public: 
		static bool useVarianceShadowMap;

	public: 
		ShadowGenerator(Size size, LightPtr light);
		virtual bool isReady(Mesh::Ptr mesh);
		virtual RenderTargetTexture::Ptr getShadowMap();
		virtual LightPtr getLight();
		virtual void dispose(bool doNotRecurse = false);
		virtual Matrix::Ptr getTransformMatrix();

	protected:
		virtual void renderSubMesh(SubMesh::Ptr subMesh);
	};

};

#endif // BABYLON_SHADOWGENERATOR_H