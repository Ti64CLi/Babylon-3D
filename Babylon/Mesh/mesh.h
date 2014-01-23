#ifndef BABYLON_MESH_H
#define BABYLON_MESH_H

#include <memory>
#include <vector>

#include "node.h"
#include "igl.h"
#include "iscene.h"
#include "vector3.h"
#include "matrix.h"
#include "material.h"
#include "skeleton.h"
#include "boundingInfo.h"
#include "vertexbuffer.h"

using namespace std;

namespace Babylon {

	class Mesh: public Node, public enable_shared_from_this<Mesh> {

	public:
		typedef shared_ptr<Mesh> Ptr;
		typedef vector<Ptr> Array;

		typedef void (*OnDisposeFunc)();

	private:
		int _currentRenderId;

	public:
		string name;
		string id;
		IScene::Ptr _scene;
		int _totalVertices;
		Matrix::Ptr _worldMatrix;

		Vector3::Ptr position;
		Vector3::Ptr rotation;
		Quaternion::Ptr rotationQuaternion;
		Vector3::Ptr scaling;

		Matrix::Ptr _pivotMatrix;

		Int32Array _indices;
		Mesh::Array subMeshes;

		int _renderId;

		Int32Array _onBeforeRenderCallbacks;

		// Animations
		Int32Array animations;

		Int32Array _positions;

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
		bool isVisible = true;
		bool isPickable = true;
		float visibility = 1.0;
		BILLBOARDMODES billboardMode;
		bool checkCollisions;
		bool receiveShadows;
		bool _isDisposed;
		OnDisposeFunc onDispose;
		Skeleton::Ptr skeleton;
		int renderingGroupId;
		bool infiniteDistance;

		BoundingInfo::Ptr _boundingInfo;
		map<VertexBufferKind, VertexBuffer::Ptr> _vertexBuffers;
		VertexBuffer::Array _delayInfo;
		Float32Array _indices;
		float _scaleFactor;
		size_t _vertexStrideSize;

	public: 
		Mesh(string name, IScene::Ptr scene);	

		virtual IScene::Ptr getScene();
		
		virtual BoundingInfo::Ptr getBoundingInfo();
		virtual Matrix::Ptr getWorldMatrix();
		virtual Vector3::Ptr getAbsolutePosition();
		virtual int getTotalVertices();
		virtual Float32Array& getVerticesData(VertexBufferKind kind);
		virtual bool isVerticesDataPresent(VertexBufferKind kind);
		virtual size_t getTotalIndices();
		virtual Float32Array getIndices();
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
		virtual Matrix::Ptr computeWorldMatrix(bool force);
		virtual void _createGlobalSubMesh();

		// Cache
	    virtual void _resetPointsArrayCache();
	};

};

#endif // BABYLON_MESH_H