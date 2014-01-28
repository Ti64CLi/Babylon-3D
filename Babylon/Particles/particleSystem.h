#ifndef BABYLON_PARTICLESYSTEM_H
#define BABYLON_PARTICLESYSTEM_H

#include <memory>
#include <vector>
#include <map>

#include "iengine.h"
#include "vector3.h"
#include "color4.h"
#include "particle.h"
#include "texture.h"
#include "matrix.h"
#include "effect.h"
#include "plane.h"
#include "mesh.h"

using namespace std;

namespace Babylon {

	class ParticleSystem : public IDisposable, public enable_shared_from_this<ParticleSystem> {

	public:

		typedef shared_ptr<ParticleSystem> Ptr;
		typedef vector<Ptr> Array;

		typedef void (*OnDisposeFunc) ();

	private:
		bool _alive;
		bool _started;
		bool _stopped;
		int _actualFrame;
		float _scaledUpdateSpeed;
		size_t _capacity;
		string _cachedDefines;
		Effect::Ptr _effect;

	public:
		string name;
		string id;
		ScenePtr _scene;

		// Members
		float renderingGroupId;
		Mesh::Ptr emitter;
		float emitRate;
		int manualEmitCount;
		float updateSpeed ;
		float targetStopDuration;
		bool disposeOnStop;

		float minEmitPower;
		float maxEmitPower;

		float minLifeTime;
		float maxLifeTime;

		int minSize;
		int maxSize;
		float minAngularSpeed;
		float maxAngularSpeed;

		Texture::Ptr particleTexture;

		OnDisposeFunc onDispose;

		BLENDMODES blendMode;

		Vector3::Ptr gravity;
		Vector3::Ptr direction1;
		Vector3::Ptr direction2;
		Vector3::Ptr minEmitBox;
		Vector3::Ptr maxEmitBox;
		Color4::Ptr color1;
		Color4::Ptr color2;
		Color4::Ptr colorDead;
		Color4::Ptr textureMask;

		// Particles
		Particle::Array particles;
		Particle::Array _stockParticles;
		size_t _newPartsExcess;

		// VBO
		Int32Array _vertexDeclaration;
		size_t _vertexStrideSize; // 11 floats per particle (x, y, z, r, g, b, a, angle, size, offsetX, offsetY)
		IGLBuffer::Ptr _vertexBuffer;
		IGLBuffer::Ptr _indexBuffer;

		Float32Array _vertices;

		// Internals
		Color4::Ptr _scaledColorStep;
		Color4::Ptr _colorDiff;
		Vector3::Ptr _scaledDirection;
		Vector3::Ptr _scaledGravity;
		int _currentRenderId;

	public: 
		ParticleSystem(string name, int capacity, ScenePtr scene);

		virtual float randomNumber(float min, float max);
		// Methods   
		virtual bool isAlive();
		virtual void start();
		virtual void stop();
		virtual void _appendParticleVertex(int index, Particle::Ptr particle, float offsetX, float offsetY);
		virtual void _update(size_t newParticles);
		virtual Effect::Ptr _getEffect();
		virtual void animate();
		virtual int render();
		virtual void dispose(bool doNotRecurse = false);
		// Clone
		virtual ParticleSystem::Ptr clone(string name, Mesh::Ptr newEmitter);
	};

};

#endif // BABYLON_PARTICLESYSTEM_H