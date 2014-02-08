#ifndef BABYLON_PARTICLE_H
#define BABYLON_PARTICLE_H

#include "decls.h"

#include "iengine.h"
#include "vector3.h"
#include "color4.h"

using namespace std;

namespace Babylon {

	struct Particle : public enable_shared_from_this<Particle> {

	public:

		typedef shared_ptr<Particle> Ptr;
		typedef vector<Ptr> Array;

        Vector3::Ptr position;
        Vector3::Ptr direction;
        Color4::Ptr color;
        Color4::Ptr colorStep;

		float lifeTime;
		float age;
		float size;
		float angle;
		float angularSpeed;

	public:
		Particle();

	};

};

#endif // BABYLON_PARTICLE_H