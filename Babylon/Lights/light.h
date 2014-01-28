#ifndef BABYLON_LIGHT_H
#define BABYLON_LIGHT_H

#include <memory>
#include <vector>
#include <map>

#include "iengine.h"
#include "node.h"
#include "mesh.h"

using namespace std;

namespace Babylon {

	class ShadowGenerator;
	typedef shared_ptr<ShadowGenerator> ShadowGeneratorPtr;

	// TODO: add animations
	class Light : public Node, public IDisposable, public enable_shared_from_this<Light> {

	public:

		typedef shared_ptr<Light> Ptr;
		typedef vector<Ptr> Array;

	private:
		Matrix::Ptr _parentedWorldMatrix;

	public: 
		static float intensity;

		string id;
		string name;
		ScenePtr _scene;
		Mesh::Array excludedMeshes;
		vector<shared_ptr<void>> animations;
		ShadowGeneratorPtr _shadowGenerator;

		// base properties for
		Vector3::Ptr position;
		Vector3::Ptr direction;
		Vector3::Ptr _transformedPosition;

	private:
		void renderSubMesh(SubMesh::Ptr subMesh);

	public: 
		Light(string name, ScenePtr scene);

		virtual ScenePtr getScene();
		virtual ShadowGeneratorPtr getShadowGenerator();
		// Methods
		virtual void transferToEffect();
		virtual Matrix::Ptr getWorldMatrix();
		virtual void dispose(bool doNotRecurse = false);

		// for Lights
		virtual Matrix::Ptr _getWorldMatrix();
		virtual bool _computeTransformedPosition();
	};

};

#endif // BABYLON_LIGHT_H