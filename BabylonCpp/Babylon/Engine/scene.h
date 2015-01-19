#ifndef BABYLON_SCENE_H
#define BABYLON_SCENE_H

#include "decls.h"
#include <time.h>

#include "iengine.h"
#include "mesh.h"
#include "ray.h"
#include "baseTexture.h"
#include "light.h"
#include "standardMaterial.h"
#include "multiMaterial.h"
#include "camera.h"
#include "pickingInfo.h"
#include "renderingManager.h"
#include "postProcessManager.h"
#include "physicsEngine.h"
#include "particleSystem.h"
#include "octree.h"
#include "layer.h"
#include "lensFlareSystem.h"
#include "spriteManager.h"

namespace Babylon {

	class Scene : public IDisposable, public enable_shared_from_this<Scene> {

	public:

		typedef shared_ptr_t<Scene> Ptr;
		typedef void (*BeforeRenderFunc)();
		typedef void (*ExecuteWhenReadyFunc)();
		//typedef Ray::Ptr (*RayFunctionFunc)(Matrix::Ptr);
		typedef function_t<Ray::Ptr (Matrix::Ptr)> RayFunctionFunc;
		typedef function_t<bool (Mesh::Ptr)> PredicateFunc;

		EnginePtr _engine;
		bool autoClear;
		bool forceWireframe;
		Color4::Ptr clearColor;
		Color3::Ptr ambientColor;
		int _totalVertices;
		int _activeVertices;
		int _activeParticles;
		time_t _lastFrameDuration;
		time_t _evaluateActiveMeshesDuration;
		time_t _renderTargetsDuration;
		time_t _renderDuration;
		time_t _particlesDuration;
		time_t _spritesDuration;
		time_t _animationRatio;
		int _renderId;
		int _executeWhenReadyTimeoutId;
		Matrix::Ptr _pickWithRayInverseMatrix;
		IDisposable::Array _toBeDisposed;
		vector_t<ExecuteWhenReadyFunc> _onReadyCallbacks;
		vector_t<shared_ptr_t<void>> _pendingData;
		vector_t<BeforeRenderFunc> _onBeforeRenderCallbacks;
		FOGMODES fogMode;
		Color3::Ptr fogColor;
		float fogDensity;
		float fogStart;
		float fogEnd;
		bool lightsEnabled;
		Light::Array lights;
		Camera::Array cameras;
		Camera::Ptr activeCamera;
		Mesh::Array meshes;
		Mesh::Array _activeMeshes;
		Material::Array _processedMaterials;
		IRenderable::Array _renderTargets;
		ParticleSystem::Array _activeParticleSystems;
		Skeleton::Array _activeSkeletons;
		Octree::Ptr _selectionOctree;
		RenderingManager::Ptr _renderingManager;
		Material::Array materials;
		MultiMaterial::Array multiMaterials;
		Material::Ptr defaultMaterial;
		bool texturesEnabled;
		BaseTexture::Array textures;
		bool particlesEnabled;
		ParticleSystem::Array particleSystems;
		SpriteManager::Array spriteManagers;
		Layer::Array layers;
		Skeleton::Array skeletons;
		LensFlareSystem::Array lensFlareSystems;
		bool collisionsEnabled;
		Vector3::Ptr gravity;
		vector_t<shared_ptr_t<void>> _activeAnimatables;
		Matrix::Ptr _transformMatrix;
		Vector3::Ptr _scaledPosition;
		Vector3::Ptr _scaledVelocity;
		bool postProcessesEnabled;
		PostProcessManager::Ptr postProcessManager;
		bool renderTargetsEnabled;
		IRenderable::Array customRenderTargets;
		Camera::Array activeCameras;

		time_t _animationStartDate;
		Matrix::Ptr _viewMatrix;
		Matrix::Ptr _projectionMatrix;
		PhysicsEngine::Ptr _physicsEngine;
		Plane::Array _frustumPlanes;

		bool useDelayedTextureLoading;

	protected: 
		Scene(EnginePtr engine);
	public: 
		static ScenePtr New(EnginePtr engine);

		virtual EnginePtr getEngine();
		virtual int getTotalVertices();
		virtual int getActiveVertices();
		virtual int getActiveParticles();
		// Stats
		virtual int getLastFrameDuration();
		virtual int getEvaluateActiveMeshesDuration();
		virtual Mesh::Array& geActiveMeshes();
		virtual int getRenderTargetsDuration();
		virtual int getRenderDuration();
		virtual int getParticlesDuration();
		virtual int getSpritesDuration();
		virtual int getAnimationRatio();
		virtual int getRenderId();
		// Ready
		virtual bool isReady();
		virtual void registerBeforeRender(BeforeRenderFunc func);
		virtual void unregisterBeforeRender(BeforeRenderFunc func);
		virtual void _addPendingData(shared_ptr_t<void> data);
		virtual void _removePendingData(shared_ptr_t<void> data);
		virtual int getWaitingItemsCount();
		virtual void executeWhenReady(ExecuteWhenReadyFunc func);
		virtual void _checkIsReady();
		// Animations
		////virtual void beginAnimation(target, from, to, loop, float speedRatio = 1.0, onAnimationEnd);
		////virtual void stopAnimation(target);
		////virtual void _animate();
		// Matrix
		virtual Matrix::Ptr getViewMatrix();
		virtual Matrix::Ptr getProjectionMatrix();
		virtual Matrix::Ptr getTransformMatrix();
		virtual void setTransformMatrix(Matrix::Ptr view, Matrix::Ptr projection);
		// Methods
		virtual void activeCameraByID(string id);
		virtual Material::Ptr getMaterialByID(string id);
		virtual Material::Ptr getMaterialByName(string name);
		virtual Camera::Ptr getCameraByName(string name);
		virtual Light::Ptr getLightByID(string id);
		virtual Mesh::Ptr getMeshByID(string id);
		virtual Mesh::Ptr getLastMeshByID(string id);
		virtual Node::Ptr getLastEntryByID(string id);
		virtual Mesh::Ptr getMeshByName(string name);
		virtual Skeleton::Ptr getLastSkeletonByID(string id);
		virtual Skeleton::Ptr getSkeletonById(string id);
		virtual Skeleton::Ptr getSkeletonByName(string name);
		virtual bool isActiveMesh(Mesh::Ptr mesh);
		virtual void _evaluateSubMesh(SubMesh::Ptr subMesh, Mesh::Ptr mesh);
		virtual void _evaluateActiveMeshes();
		virtual void _renderForCamera(Camera::Ptr camera);
		virtual void render();
		virtual void dispose(bool doNotRecurse = false);
		// Collisions
		////virtual void _getNewPosition(Vector3::Ptr position, velocity, Collider::Ptr collider, int maximumRetry, Vector3::Ptr finalPosition);
		////virtual void _collideWithWorld(Vector3::Ptr position, velocity, Collider::Ptr collider, int maximumRetry, Vector3::Ptr finalPosition);
		// Octrees
		static void checkExtends(Vector3::Ptr v, Vector3::Ptr min, Vector3::Ptr max);
		virtual void createOrUpdateSelectionOctree();
		// Picking
		virtual Ray::Ptr createPickingRay(float x, float y, Matrix::Ptr world = Matrix::Identity());
		virtual PickingInfo::Ptr _internalPick(RayFunctionFunc rayFunction, PredicateFunc predicate, bool fastCheck);
		virtual PickingInfo::Ptr pick(float x, float y, PredicateFunc predicate, bool fastCheck);
		virtual PickingInfo::Ptr pickWithRay(Ray::Ptr ray, PredicateFunc predicate, bool fastCheck);
		// Physics
		virtual bool enablePhysics(float gravity, int iterations = 10);
		virtual void disablePhysicsEngine();
		virtual bool isPhysicsEnabled();
		virtual void setGravity(Vector3::Ptr gravity);
		////virtual Compound::Ptr createCompoundImpostor(options);
		////virtual void deleteCompoundImpostor(Compound::Ptr compound);
	};

};

#endif // BABYLON_NODE_H