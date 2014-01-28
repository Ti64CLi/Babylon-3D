#include "sprite.h"
#include "spriteManager.h"
#include <algorithm>

using namespace Babylon;

Babylon::Sprite::Sprite(string name, SpriteManager::Ptr manager)
{
	this->name = name;
	this->_manager = manager;

	this->_manager->sprites.push_back(shared_from_this());

	this->position = Vector3::Zero();
	this->color = make_shared<Color4>(1.0, 1.0, 1.0, 1.0);

	this->_frameCount = 0;

	// Members
	this->size = 1.0;
	this->angle = 0;
	this->cellIndex = 0;
	this->invertU = 0;
	this->invertV = 0;
	this->disposeWhenFinishedAnimating = false;

	this->_animationStarted = false;
	this->_loopAnimation = false;
	this->_fromIndex = false;
	this->_toIndex = false;
	this->_delay = false;
	this->_direction = 1;
}

// Methods
void Babylon::Sprite::playAnimation(int from, int to, bool loop, bool delay) {
	this->_fromIndex = from;
	this->_toIndex = to;
	this->_loopAnimation = loop;
	this->_delay = delay;
	this->_animationStarted = true;

	this->_direction = from < to ? 1 : -1;

	this->cellIndex = from;
	this->_time = 0;
};

void Babylon::Sprite::stopAnimation() {
	this->_animationStarted = false;
};

void Babylon::Sprite::_animate(int deltaTime) {
	if (!this->_animationStarted)
		return;

	this->_time += deltaTime;
	if (this->_time > this->_delay) {
		this->_time = this->_time % this->_delay;
		this->cellIndex += this->_direction;
		if (this->cellIndex == this->_toIndex) {
			if (this->_loopAnimation) {
				this->cellIndex = this->_fromIndex;
			} else {
				this->_animationStarted = false;
				if (this->disposeWhenFinishedAnimating) {
					this->dispose();
				}
			}
		}
	}
};

void Babylon::Sprite::dispose(bool doNotRecurse) {
	std::remove_if (
		begin(this->_manager->sprites), 
		end(this->_manager->sprites
		), [&](Sprite::Ptr& sprite) { return sprite == shared_from_this(); } );
};
