#ifndef BABYLON_ISCENE_H
#define BABYLON_ISCENE_H

#include <memory>
#include <vector>
#include "igl.h"
#include "iengine.h"

using namespace std;

namespace Babylon {

	class BaseTexture;
	typedef shared_ptr<BaseTexture> BaseTexturePtr;
	typedef vector<BaseTexturePtr> BaseTextureArray;
	class Mesh;
	typedef shared_ptr<Mesh> MeshPtr;
	typedef vector<MeshPtr> MeshArray;
	class Light;
	typedef shared_ptr<Light> LightPtr;
	typedef vector<LightPtr> LightArray;
	class Material;
	typedef shared_ptr<Material> MaterialPtr;
	typedef vector<MaterialPtr> MaterialArray;
	class Camera;
	typedef shared_ptr<Camera> CameraPtr;
	typedef vector<CameraPtr> CameraArray;
	class Matrix;
	typedef shared_ptr<Matrix> MatrixPtr;
	typedef vector<MatrixPtr> MatrixArray;
	class Skeleton;
	typedef shared_ptr<Skeleton> SkeletonPtr;
	typedef vector<SkeletonPtr> SkeletonArray;

	class IScene {

	public:
		typedef shared_ptr<IScene> Ptr;

	public:
		virtual bool getUseDelayedTextureLoading() = 0;
		virtual MatrixPtr getProjectionMatrix() = 0;

		virtual void _addPendingData(IGLTexture::Ptr texture) = 0;
		virtual void _addPendingData(IImage::Ptr image) = 0;
		virtual void _removePendingData(IGLTexture::Ptr texture) = 0;
		virtual void _removePendingData(IImage::Ptr image) = 0;

		virtual BaseTextureArray& getTextures() = 0;
		virtual MeshArray& getMeshes() = 0;
		virtual LightArray& getLights() = 0;
		virtual CameraArray& getCameras() = 0;
		virtual MaterialArray& getMaterials() = 0;
		virtual SkeletonArray& getSkeletons() = 0;
		virtual IEngine::Ptr getEngine() = 0;
		virtual CameraPtr getActiveCamera() = 0;
		virtual int getRenderId() = 0;

		virtual void setActiveCamera(CameraPtr camera) = 0;
		// Dispose
		virtual void dispose() = 0;
	};

};

#endif // BABYLON_ISCENE_H