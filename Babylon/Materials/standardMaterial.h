#ifndef BABYLON_STANDARDMATERIAL_H
#define BABYLON_STANDARDMATERIAL_H

#include <memory>
#include <vector>
#include <string>
#include <map>

#include "igl.h"
#include "iengine.h"
#include "tools_math.h"
#include "effect.h"
#include "animatable.h"
#include "material.h"
#include "renderTargetTexture.h"

using namespace std;

namespace Babylon {

	class Mesh;
	typedef shared_ptr<Mesh> MeshPtr;

	class StandardMaterial: public Material {

	public:
		typedef shared_ptr<StandardMaterial> Ptr;
		typedef vector<Ptr> Array;

	private:
		int _renderId;

	public:
		Texture::Ptr diffuseTexture;
		Texture::Ptr ambientTexture;
		Texture::Ptr opacityTexture;
		RenderTargetTexture::Ptr reflectionTexture;
		Texture::Ptr emissiveTexture;
		Texture::Ptr specularTexture;
		Texture::Ptr bumpTexture;

		Color3::Ptr ambientColor;
		Color3::Ptr diffuseColor;
		Color3::Ptr specularColor;
		int specularPower;
		Color3::Ptr emissiveColor;

		IRenderable::Array _renderTargets;

		Matrix::Ptr _worldViewProjectionMatrix;
		Matrix::Ptr _lightMatrix;

		Color3::Ptr _globalAmbientColor;
		Color3::Ptr _baseColor;
		Color3::Ptr _scaledDiffuse;
		Color3::Ptr _scaledSpecular;

		Effect::Ptr _effect;

		string _cachedDefines;

	protected: 
		StandardMaterial(string name, ScenePtr scene);
	public: 
		static StandardMaterial::Ptr New(string name, ScenePtr scene);

		virtual bool needAlphaBlending();
		virtual bool needAlphaTesting();
		// Methods   
		virtual bool isReady(MeshPtr mesh);
		virtual IRenderable::Array getRenderTargetTextures();
		virtual void unbind();
		virtual void bind(Matrix::Ptr world, MeshPtr mesh);
		virtual Texture::Array getAnimatables();
		virtual void dispose();
		virtual StandardMaterial::Ptr clone(string name);
	};

};

#endif // BABYLON_STANDARDMATERIAL_H