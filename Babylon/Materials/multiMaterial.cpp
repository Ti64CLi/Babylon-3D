#include "multiMaterial.h"
#include "engine.h"
#include "mesh.h"

using namespace Babylon;

Babylon::MultiMaterial::MultiMaterial(string name, Scene::Ptr scene) : Material(name, scene) {
	// moved to new
	/////scene->multiMaterials.push_back(enable_shared_from_this<MultiMaterial>::shared_from_this());
	subMaterials.clear();
};

MultiMaterial::Ptr Babylon::MultiMaterial::New(string name, Scene::Ptr scene)
{
	auto multiMaterial = make_shared<MultiMaterial>(MultiMaterial(name, scene));
	scene->multiMaterials.push_back(multiMaterial);
	return multiMaterial;
};

// Properties
bool Babylon::MultiMaterial::isReady(Mesh::Ptr mesh) {
	auto result = true;
	for (auto subMaterial : this->subMaterials) {
		if (subMaterial) {
			result &= subMaterial->isReady(mesh);
		}
	}

	return result;
};

Material::Ptr Babylon::MultiMaterial::getSubMaterial(int index) {
	if (index < 0 || index >= this->subMaterials.size()) {
		return this->_scene->defaultMaterial;
	}

	return this->subMaterials[index];
};
