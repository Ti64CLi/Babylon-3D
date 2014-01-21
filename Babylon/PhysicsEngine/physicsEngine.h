#ifndef BABYLON_PHYSICSENGINE_H
#define BABYLON_PHYSICSENGINE_H

#include <memory>
#include <vector>
#include <map>

#include "vector3.h"

using namespace std;

namespace Babylon {

	// TODO: Add your's implementation
	class PhysicsEngine : public enable_shared_from_this<PhysicsEngine> {
	
	public:
		typedef shared_ptr<PhysicsEngine> Ptr;
		typedef vector<Ptr> Array;

	private: 

	public: 
		PhysicsEngine();

		virtual void _runOneStep(float delta);

		virtual void _setGravity(Vector3::Ptr gravity);

		virtual void disablePhysicsEngine();

		virtual void dispose();
	};

};

#endif // BABYLON_PHYSICSENGINE_H