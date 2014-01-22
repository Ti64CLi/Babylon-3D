#ifndef BABYLON_LIGHT_H
#define BABYLON_LIGHT_H

#include <memory>
#include <vector>
#include <map>

#include "iscene.h"
#include "node.h"
#include "mesh.h"
#include "shadowGenerator.h"
#include "ilight.h"

using namespace std;

namespace Babylon {

	// TODO: add animations
	class Light : public Node, public ILight, public enable_shared_from_this<Light> {

	public:

		typedef shared_ptr<Light> Ptr;
		typedef vector<Ptr> Array;

	private:
		Matrix::Ptr _parentedWorldMatrix;

	public: 
		static float intensity;

		string id;
		string name;
		IScene::Ptr _scene;
		Mesh::Array excludedMeshes;
		vector<shared_ptr<void>> animations;
		ShadowGenerator::Ptr _shadowGenerator;

	private:
		////void renderSubMesh(SubMesh::Ptr subMesh);

	public: 
		Light(string name, IScene::Ptr scene);

		virtual IScene::Ptr getScene();
		virtual ShadowGenerator::Ptr getShadowGenerator();
		// Methods
		virtual void transferToEffect();
		virtual Matrix::Ptr getWorldMatrix();
		virtual void dispose();

		// for Lights
		virtual Matrix::Ptr _getWorldMatrix() = 0;
	};

};

#endif // BABYLON_LIGHT_H