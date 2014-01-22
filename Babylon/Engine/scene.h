#ifndef BABYLON_SCENE_H
#define BABYLON_SCENE_H

#include <memory>
#include <vector>
#include <functional>
#include <time.h>

#include "iscene.h"
#include "engine.h"
#include "mesh.h"
#include "ray.h"
#include "baseTexture.h"
#include "light.h"
#include "physicsEngine.h"

using namespace std;

namespace Babylon {

	class Scene: public enable_shared_from_this<Scene>, IScene {

	public:

		typedef shared_ptr<Scene> Ptr;
		typedef void (*BeforeRenderFunc)();
		typedef void (*ExecuteWhenReadyFunc)();
		//typedef Ray::Ptr (*RayFunctionFunc)(Matrix::Ptr);
		typedef function<Ray::Ptr (Matrix::Ptr)> RayFunctionFunc;
		typedef bool (*PredicateFunc)(Mesh::Ptr);

	private: 
		Engine::Ptr _engine;
		bool autoClear;
		Color4::Ptr clearColor;
		Color3::Ptr ambientColor;
		int _totalVertices;
		int _activeVertices;
		int _activeParticles;
		int _lastFrameDuration;
		int _evaluateActiveMeshesDuration;
		int _renderTargetsDuration;
		int _renderDuration;
		int _particlesDuration;
		int _spritesDuration;
		int _animationRatio;
		int _renderId;
		int _executeWhenReadyTimeoutId;
		vector<shared_ptr<void>> _toBeDisposed;
		vector<ExecuteWhenReadyFunc> _onReadyCallbacks;
		vector<shared_ptr<void>> _pendingData;
		vector<BeforeRender> _onBeforeRenderCallbacks;
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
		vector<shared_ptr<void>> _processedMaterials;
		vector<shared_ptr<void>> _renderTargets;
		vector<shared_ptr<void>> _activeParticleSystems;
		vector<shared_ptr<void>> _activeSkeletons;
		RenderingManager::Ptr _renderingManager;
		vector<shared_ptr<void>> materials;
		vector<shared_ptr<void>> multiMaterials;
		Material::Ptr defaultMaterial;
		bool texturesEnabled;
		BaseTexture::Array textures;
		bool particlesEnabled;
		vector<shared_ptr<void>> particleSystems;
		vector<shared_ptr<void>> spriteManagers;
		vector<shared_ptr<void>> layers;
		vector<shared_ptr<void>> skeletons;
		vector<shared_ptr<void>> lensFlareSystems;
		bool collisionsEnabled;
		Vector3::Ptr gravity;
		vector<shared_ptr<void>> _activeAnimatables;
		Matrix::Ptr _transformMatrix;
		Vector3::Ptr _scaledPosition;
		Vector3::Ptr _scaledVelocity;
		bool postProcessesEnabled;
		PostProcessManager::Ptr postProcessManager;
		bool renderTargetsEnabled;
		vector<shared_ptr<void>> customRenderTargets;
		vector<shared_ptr<void>> activeCameras;

		time_t _animationStartDate;
		Matrix::Ptr _viewMatrix;
		Matrix::Ptr _projectionMatrix;
		PhysicsEngine::Ptr _physicsEngine;

	public:
		IGLTexture::Array textures;

	public: 
		Scene(Engine::Ptr engine);

		virtual Engine::Ptr getEngine();
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
		virtual void _addPendingData(IGLTexture::Ptr data);
		virtual void _removePendingData(IGLTexture::Ptr data);
		virtual int getWaitingItemsCount();
		virtual void executeWhenReady(ExecuteWhenReadyFunc func);
		virtual bool _checkIsReady();
		// Animations
		virtual void beginAnimation(target, from, to, loop, float speedRatio = 1.0, onAnimationEnd);
		virtual void stopAnimation(target);
		virtual void _animate();
		// Matrix
		virtual Matrix::Ptr getViewMatrix();
		virtual Matrix::Ptr getProjectionMatrix();
		virtual Matrix::Ptr getTransformMatrix();
		virtual void setTransformMatrix(Matrix::Ptr view, Matrix::Ptr projection);
		// Methods
		virtual void activeCameraByID(int id);
		virtual shared_ptr<void> getMaterialByID(int id);
		virtual shared_ptr<void> getMaterialByName(string name);
		virtual shared_ptr<void> getCameraByName(string name);
		virtual shared_ptr<void> getLightByID(int id);
		virtual Mesh::Ptr getMeshByID(int id);
		virtual Mesh::Ptr getLastMeshByID(int id);
		virtual Node::Ptr getLastEntryByID(int id);
		virtual Mesh::Ptr getMeshByName(string name);
		virtual shared_ptr<void> getLastSkeletonByID(int id);
		virtual shared_ptr<void> getSkeletonById(int id);
		virtual shared_ptr<void> getSkeletonByName(string name);
		virtual bool isActiveMesh(Mesh::Ptr mesh);
		virtual void _evaluateSubMesh(SubMesh::Ptr subMesh, Mesh::Ptr mesh);
		virtual void _evaluateActiveMeshes();
		virtual void _renderForCamera(Camera::Ptr camera);
		virtual void render();
		virtual void dispose();
		// Collisions
		virtual void _getNewPosition(Vector3::Ptr position, velocity, Collider::Ptr collider, int maximumRetry, Vector3::Ptr finalPosition);
		virtual void _collideWithWorld(Vector3::Ptr position, velocity, Collider::Ptr collider, int maximumRetry, Vector3::Ptr finalPosition);
		// Octrees
		static void checkExtends(Vector3::Ptr v, Vector3::Ptr min, Vector3::Ptr max);
		virtual void createOrUpdateSelectionOctree();
		// Picking
		virtual void createPickingRay(float x, float y, Matrix::Ptr world = Matrix::Identity());
		virtual PickingInfo::Ptr _internalPick(RayFunctionFunc rayFunction, PredicateFunc predicate, bool fastCheck);
		virtual void pick(float x, float y, PredicateFunc predicate, bool fastCheck);
		virtual void pickWithRay(Ray::Ptr ray, PredicateFunc predicate, bool fastCheck);
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