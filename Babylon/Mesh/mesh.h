#ifndef BABYLON_MESH_H
#define BABYLON_MESH_H

#include <memory>
#include <vector>

#include "node.h"
#include "igl.h"
#include "iscene.h"
#include "vector3.h"
#include "matrix.h"

using namespace std;

namespace Babylon {

	class Mesh: public Node, public enable_shared_from_this<Mesh> {

	public:
		typedef shared_ptr<Mesh> Ptr;
		typedef vector<Ptr> Array;

	public:
		string name;
		string id;
		IScene::Ptr _scene;
		int _totalVertices;
		Matrix::Ptr _worldMatrix;

		Vector3::Ptr position;
		Vector3::Ptr rotation;
		void* rotationQuaternion;
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

	public: 
		Mesh(string name, IScene::Ptr scene);		
	};

};

#endif // BABYLON_MESH_H