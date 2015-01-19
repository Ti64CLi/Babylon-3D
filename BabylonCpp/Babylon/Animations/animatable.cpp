#include "animatable.h"

using namespace Babylon;

Babylon::_Animatable::_Animatable()
{
	// Members
	this->target = nullptr;
	this->animationStarted = false;
	// TODO: double check if "true" means ANIMATIONLOOPMODE_CYCLE
	this->loopAnimation = ANIMATIONLOOPMODE_CYCLE;
	this->fromFrame = 0;
	this->toFrame = 100;
	this->speedRatio = 1.0;
}

// Methods
bool Babylon::_Animatable::_animate(float delay) {
    ////if (!this->_localDelayOffset) {
        this->_localDelayOffset = delay;
    ////}

    // Animating
    auto running = false;
    auto animations = this->target->animations;
    for (auto animation : animations) {
        auto isRunning = animation->animate(this->target, delay - this->_localDelayOffset, this->fromFrame, this->toFrame, this->loopAnimation, this->speedRatio);
        running = running || isRunning;            
    }

    if (!running) {
        this->onAnimationEnd();
    }

    return running;
};

void Babylon::_Animatable::onAnimationEnd()
{
}