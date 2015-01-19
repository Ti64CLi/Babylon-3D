#include "lensFlare.h"
#include "defs.h"
#include "lensFlareSystem.h"

using namespace Babylon;

Babylon::LensFlare::LensFlare(float size, Vector3::Ptr position, Color3::Ptr color, string imgUrl, LensFlareSystem::Ptr system)
{
	this->color = color != nullptr ? color : make_shared<Color3>(1, 1, 1);
	this->position = position;
	this->size = size;
	this->texture = !imgUrl.empty() ? Texture::New(imgUrl, system->getScene(), true) : nullptr;
	this->_system = system;

	system->lensFlares.push_back(shared_from_this());
}

// Methods
void Babylon::LensFlare::dispose(bool doNotRecurse) {
	if (this->texture) {
		this->texture->dispose();
	}

	// Remove from scene
	auto it = find(begin(this->_system->lensFlares), end(this->_system->lensFlares), shared_from_this());
	if (it != end(this->_system->lensFlares))
	{
		this->_system->lensFlares.erase(it);
	}
};
