#ifndef BABYLON_MESH_H
#define BABYLON_MESH_H

#include "decls.h"

#include "igl.h"
#include "iengine.h"
#include "node.h"
#include "tools_math.h"

#include "material.h"
#include "skeleton.h"
#include "boundingInfo.h"
#include "vertexbuffer.h"
#include "subMesh.h"
#include "pickingInfo.h"

using namespace std;

namespace Babylon {

	class Mesh: public Node, public IDisposable {

	public:
		typedef shared_ptr_t<Mesh> Ptr;
		typedef vector_t<Ptr> Array;

		typedef void (*OnDisposeFunc)();
		typedef void (*OnBeforeRenderFunc)();

	private:
		int _currentRenderId;

	public:
		string name;
		string id;
		ScenePtr _scene;
		size_t _totalVertices;
		Matrix::Ptr _worldMatrix;

		Vector3::Ptr position;
		Vector3::Ptr rotation;
		Quaternion::Ptr rotationQuaternion;
		Vector3::Ptr scaling;

		Matrix::Ptr _pivotMatrix;

		Uint16Array _indices;
		SubMesh::Array subMeshes;

		int _renderId;

		vector_t<OnBeforeRenderFunc> _onBeforeRenderCallbacks;

		// Animations
		Int32Array animations;

		Vector3::Array _positions;

		bool _childrenFlag;
		Matrix::Ptr _localScaling;
		Matrix::Ptr _localRotation;
		Matrix::Ptr _localTranslation;
		Matrix::Ptr _localBillboard;
		Matrix::Ptr _localPivotScaling;
		Matrix::Ptr _localPivotScalingRotation;
		Matrix::Ptr _localWorld;
		Matrix::Ptr _rotateYByPI;

		Matrix::Ptr _collisionsTransformMatrix;
		Matrix::Ptr _collisionsScalingMatrix;

		Vector3::Ptr _absolutePosition;
		
		// members
		DELAYLOADSTATE delayLoadState;
		Material::Ptr material;
		bool isVisible;
		bool isPickable;
		float visibility;
		BILLBOARDMODES billboardMode;
		bool checkCollisions;
		bool receiveShadows;
		bool _isDisposed;
		OnDisposeFunc onDispose;
		Skeleton::Ptr skeleton;
		size_t renderingGroupId;
		bool infiniteDistance;

		BoundingInfo::Ptr _boundingInfo;
		VertexBuffer::Map _vertexBuffers;
		VertexBuffer::Array _delayInfo;
		float _scaleFactor;
		size_t _vertexStrideSize;
		IGLBuffer::Ptr _indexBuffer;

	protected: 
		Mesh(string name, ScenePtr scene);	
	public: 
		static MeshPtr New(string name, ScenePtr scene);	

		virtual ScenePtr getScene();
		
		virtual BoundingInfo::Ptr getBoundingInfo();
		virtual bool hasWorldMatrix();
		virtual Matrix::Ptr getWorldMatrix();
		virtual Vector3::Ptr getAbsolutePosition();
		virtual int getTotalVertices();
		virtual Float32Array getVerticesData(VertexBufferKind kind);
		virtual bool isVerticesDataPresent(VertexBufferKind kind);
		virtual size_t getTotalIndices();
		virtual Uint16Array getIndices();
		virtual size_t getVertexStrideSize();
		virtual void setPivotMatrix(Matrix::Ptr matrix);
		virtual Matrix::Ptr getPivotMatrix();
		virtual bool _isSynchronized();
		virtual bool isReady();
		virtual bool isAnimated();
		virtual bool isDisposed();
		virtual void _initCache();
		virtual void markAsDirty(string property);
		virtual void refreshBoundingInfo();
		virtual void _updateBoundingInfo();
		virtual Matrix::Ptr computeWorldMatrix(bool force = false);
		virtual SubMesh::Ptr _createGlobalSubMesh();
		virtual void subdivide(int count);
		virtual void setVerticesData(Float32Array data, VertexBufferKind kind, bool updatable);
		virtual void updateVerticesData(VertexBufferKind kind, Float32Array data);
		virtual void setIndices(Uint16Array indices);
		virtual void bindAndDraw(SubMesh::Ptr subMesh, Effect::Ptr effect, bool wireframe);
		virtual void registerBeforeRender(OnBeforeRenderFunc func);
		virtual void unregisterBeforeRender(OnBeforeRenderFunc func);
		virtual void render(SubMesh::Ptr subMesh);
		virtual vector_t<shared_ptr_t<void>> getEmittedParticleSystems();
		virtual vector_t<shared_ptr_t<void>> getHierarchyEmittedParticleSystems();
		virtual Mesh::Array getChildren();
		virtual bool isInFrustum(Plane::Array frustumPlanes);
		virtual void setMaterialByID(string id);
		virtual Animatable::Array getAnimatables();
		virtual void setLocalTranslation(Vector3::Ptr vector3);
		virtual Vector3::Ptr getLocalTranslation();
		virtual void setPositionWithLocalVector(Vector3::Ptr vector3);
		virtual Vector3::Ptr getPositionExpressedInLocalSpace();
		virtual void locallyTranslate(Vector3::Ptr vector3);
		virtual void bakeTransformIntoVertices(Matrix::Ptr transform);
		virtual void lookAt(Vector3::Ptr targetPoint, float yawCor = 0., float pitchCor = 0., float rollCor = 0.);
		// Cache
	    virtual void _resetPointsArrayCache();
		virtual void _generatePointsArray();
		////virtual void _collideForSubMesh(SubMesh::Ptr subMesh, Matrix::Ptr transformMatrix, Collider::Ptr collider);
		////virtual void _processCollisionsForSubModels(Collider::Ptr collider, Matrix::Ptr transformMatrix);
		////virtual void Babylon::Mesh::_checkCollision(Collider::Ptr collider);
		virtual bool intersectsMesh(Mesh::Ptr mesh, float precise);
		virtual bool intersectsPoint(Vector3::Ptr point);
		virtual PickingInfo::Ptr intersects(Ray::Ptr ray, bool fastCheck);
		virtual Mesh::Ptr clone(string name, Node::Ptr newParent, bool doNotCloneChildren = false);
		virtual void dispose(bool doNotRecurse = false);
		static Mesh::Ptr CreateBox(string name, float size, ScenePtr scene, bool updatable = false);
		static Mesh::Ptr CreateSphere(string name, size_t segments, float diameter, ScenePtr scene, bool updatable = false);
		static Mesh::Ptr CreateTorus(string name, float diameter, float thickness, int tessellation, ScenePtr scene, bool updatable = false);
		static Mesh::Ptr CreatePlane(string name, float size, ScenePtr scene, bool updatable = false);
		static Mesh::Ptr CreateGround(string name, int width, int height, int subdivisions, ScenePtr scene, bool updatable = false);
	};

};

#endif // BABYLON_MESH_H