#ifndef BABYLON_POINTLIGHT_H
#define BABYLON_POINTLIGHT_H

#include "decls.h"

#include "iengine.h"
#include "node.h"
#include "light.h"
#include "matrix.h"
#include "effect.h"

using namespace std;

namespace Babylon {

	class ShadowGenerator;
	typedef shared_ptr<ShadowGenerator> ShadowGeneratorPtr;

	// TODO: add animations
	class PointLight : public Light {

	public:

		typedef shared_ptr<PointLight> Ptr;
		typedef vector<Ptr> Array;

	private:
		 Matrix::Ptr _worldMatrix;

	protected: 
		PointLight(string name, Vector3::Ptr position, ScenePtr scene);
	public: 
		static PointLight::Ptr New(string name, Vector3::Ptr position, ScenePtr scene);

		// Methods
		virtual void transferToEffect(Effect::Ptr effect, string positionUniformName, string dummay = "");
		virtual ShadowGeneratorPtr getShadowGenerator();
		virtual Matrix::Ptr _getWorldMatrix();
		virtual bool hasWorldMatrix();
	};

};

#endif // BABYLON_POINTLIGHT_H