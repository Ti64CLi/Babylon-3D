#ifndef BABYLON_HEMISPHERICLIGHT_H
#define BABYLON_HEMISPHERICLIGHT_H

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
	class HemisphericLight : public Light {

	public:

		typedef shared_ptr_t<HemisphericLight> Ptr;
		typedef vector_t<Ptr> Array;

        Color3::Ptr groundColor;

	private:
		Matrix::Ptr _worldMatrix;

	protected: 
		HemisphericLight(string name, Vector3::Ptr direction, ScenePtr scene);
	public: 
		static HemisphericLight::Ptr New(string name, Vector3::Ptr direction, ScenePtr scene);

		// Methods
		virtual void transferToEffect(Effect::Ptr effect, string directionUniformName, string groundColorUniformName);
		virtual Matrix::Ptr _getWorldMatrix();
		virtual bool hasWorldMatrix();
	};

};

#endif // BABYLON_HEMISPHERICLIGHT_H