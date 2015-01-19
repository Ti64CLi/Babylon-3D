#ifndef BABYLON_LIGHT_H
#define BABYLON_LIGHT_H

#include "decls.h"

#include "iengine.h"
#include "node.h"
#include "mesh.h"

using namespace std;

namespace Babylon {

	class ShadowGenerator;
	typedef shared_ptr_t<ShadowGenerator> ShadowGeneratorPtr;

	// TODO: add animations
	class Light : public Node, public IDisposable {

	public:

		typedef shared_ptr_t<Light> Ptr;
		typedef vector_t<Ptr> Array;

	private:
		Matrix::Ptr _parentedWorldMatrix;

	public: 
		static float intensity;

		string id;
		string name;
		ScenePtr _scene;
		Mesh::Array excludedMeshes;
		vector_t<shared_ptr_t<void>> animations;
		ShadowGeneratorPtr _shadowGenerator;

		// base properties for
		Vector3::Ptr position;
		Vector3::Ptr direction;
		Color3::Ptr diffuse;
        Color3::Ptr specular;

		Vector3::Ptr _transformedPosition;

	private:
		void renderSubMesh(SubMesh::Ptr subMesh);

	protected: 
		Light(string name, ScenePtr scene);

	public: 
		virtual ScenePtr getScene();
		virtual ShadowGeneratorPtr getShadowGenerator();
		// Methods
		virtual void transferToEffect(Effect::Ptr effect, string directionUniformName, string groundColorUniformName = "");
		virtual Matrix::Ptr getWorldMatrix();
		virtual void dispose(bool doNotRecurse = false);

		// for Lights
		virtual Matrix::Ptr _getWorldMatrix() = 0;
		virtual bool _computeTransformedPosition();
	};

};

#endif // BABYLON_LIGHT_H