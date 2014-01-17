#ifndef BABYLON_MESH_H
#define BABYLON_MESH_H

#include <memory>
#include <vector>

#include "node.h"
#include "igl.h"
#include "iscene.h"

using namespace std;

namespace Babylon {

	class Mesh: public Node {

	public:
		typedef shared_ptr<Mesh> Ptr;
		typedef vector<Ptr> Array;

	public:
		string name;
		string id;
		IScene::Ptr _scene;
		int _totalVertices;
		Matrix _worldMatrix;

		Vector3 position;
		Vector3 rotation;
		void* rotationQuaternion;
		Vector3 scaling = new BABYLON.Vector3(1, 1, 1);

		Matrix _pivotMatrix;

		Int32Array _indices;
		Mesh::Array subMeshes;

		int _renderId = 0;

		Int32Array _onBeforeRenderCallbacks;

		// Animations
		Int32Array animations;

		Int32Array _positions;

		bool _childrenFlag;
		Matrix _localScaling;
		Matrix _localRotation;
		Matrix _localTranslation;
		Matrix _localBillboard;
		Matrix _localPivotScaling;
		Matrix _localPivotScalingRotation;
		Matrix _localWorld;
		Matrix _worldMatrix;
		Matrix _rotateYByPI;

		Matrix _collisionsTransformMatrix;
		Matrix _collisionsScalingMatrix;

		Vector3 _absolutePosition;

	public: 
		Mesh(string name, IScene::Ptr scene);		
	};

};

#endif // BABYLON_MESH_H