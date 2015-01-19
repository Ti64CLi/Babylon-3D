#ifndef BABYLON_SPOTLIGHT_H
#define BABYLON_SPOTLIGHT_H

#include "decls.h"

#include "iengine.h"
#include "node.h"
#include "light.h"
#include "matrix.h"
#include "effect.h"

using namespace std;

namespace Babylon {

	class ShadowGenerator;
	typedef shared_ptr_t<ShadowGenerator> ShadowGeneratorPtr;

	// TODO: add animations
	class SpotLight : public Light {

	public:

		typedef shared_ptr_t<SpotLight> Ptr;
		typedef vector_t<Ptr> Array;

		Vector3::Ptr _transformedDirection;

		float angle;
		float exponent;

	private:
		Matrix::Ptr _worldMatrix;

	protected: 
		SpotLight(string name, Vector3::Ptr position, Vector3::Ptr direction, float angle, float exponent, ScenePtr scene);
	public: 
		static SpotLight::Ptr New(string name, Vector3::Ptr position, Vector3::Ptr direction, float angle, float exponent, ScenePtr scene);

		// Methods
		virtual void transferToEffect(Effect::Ptr effect, string positionUniformName, string directionUniformName);
		virtual Matrix::Ptr _getWorldMatrix();
		virtual bool hasWorldMatrix();
	};

};

#endif // BABYLON_SPOTLIGHT_H