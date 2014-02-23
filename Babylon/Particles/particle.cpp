#include "particle.h"

using namespace Babylon;

Babylon::Particle::Particle()
{
	this->position = Vector3::Zero();
	this->direction = Vector3::Zero();
	this->color = make_shared<Color4>(0, 0, 0, 0);
	this->colorStep = make_shared<Color4>(0, 0, 0, 0);

	lifeTime = 1.0;
	age = 0;
	size = 0;
	angle = 0;
	angularSpeed = 0;
}
