#ifndef BABYLON_DIRECTIONALLIGHT_H
#define BABYLON_DIRECTIONALLIGHT_H

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
	class DirectionalLight : public Light {

	public:

		typedef shared_ptr_t<DirectionalLight> Ptr;
		typedef vector_t<Ptr> Array;

		Vector3::Ptr _transformedDirection;

		float angle;
		float exponent;

	private:
		Matrix::Ptr _worldMatrix;

	protected: 
		DirectionalLight(string name, Vector3::Ptr direction, ScenePtr scene);
	public: 
		static DirectionalLight::Ptr New(string name, Vector3::Ptr direction, ScenePtr scene);

		// Methods
		virtual void transferToEffect(Effect::Ptr effect, string directionUniformName, string dummy);
		virtual Matrix::Ptr _getWorldMatrix();
		virtual bool hasWorldMatrix();
	};

};

#endif // BABYLON_DIRECTIONALLIGHT_H