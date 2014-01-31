#include "standardMaterial.h"
#include <string>
#include <algorithm>
#include <sstream>
#include "engine.h"
#include "mesh.h"
#include "shadowGenerator.h"

using namespace Babylon;

Babylon::StandardMaterial::StandardMaterial(string name, Scene::Ptr scene) : Material(name, scene) {
	this->diffuseTexture = nullptr;
	this->ambientTexture = nullptr;
	this->opacityTexture = nullptr;
	this->reflectionTexture = nullptr;
	this->emissiveTexture = nullptr;
	this->specularTexture = nullptr;
	this->bumpTexture = nullptr;

	this->ambientColor = make_shared<Color3>(0, 0, 0);
	this->diffuseColor = make_shared<Color3>(1, 1, 1);
	this->specularColor = make_shared<Color3>(1, 1, 1);
	this->specularPower = 64;
	this->emissiveColor = make_shared<Color3>(0, 0, 0);

	// no need to initialize a string
	//this->_cachedDefines = "";

	this->_renderTargets.reserve(16);

	// Internals
	this->_worldViewProjectionMatrix = Matrix::Zero();
	this->_lightMatrix = Matrix::Zero();
	this->_globalAmbientColor = make_shared<Color3>(0, 0, 0);
	this->_baseColor = make_shared<Color3>(0, 0, 0);
	this->_scaledDiffuse = make_shared<Color3>(0, 0, 0);
	this->_scaledSpecular = make_shared<Color3>(0, 0, 0);
};

StandardMaterial::Ptr Babylon::StandardMaterial::New(string name, Scene::Ptr scene)
{
	auto standardMaterial = make_shared<StandardMaterial>(StandardMaterial(name, scene));
	scene->materials.push_back(standardMaterial);
	return standardMaterial;
};

// Properties   
bool Babylon::StandardMaterial::needAlphaBlending () {
	return (this->alpha < 1.0) || (this->opacityTexture != nullptr);
};

bool Babylon::StandardMaterial::needAlphaTesting () {
	return this->diffuseTexture != nullptr && this->diffuseTexture->hasAlpha;
};

// Methods   
bool Babylon::StandardMaterial::isReady (Mesh::Ptr mesh) {
	if (this->checkReadyOnlyOnce) {
		if (this->_wasPreviouslyReady) {
			return true;
		}
	}

	if (!this->checkReadyOnEveryCall) {
		if (this->_renderId == this->_scene->getRenderId()) {
			return true;
		}
	}       

	auto engine = this->_scene->getEngine();
	vector<string> defines;
	vector<string> optionalDefines;

	// Textures
	if (this->_scene->texturesEnabled) {
		if (this->diffuseTexture) {
			if (!this->diffuseTexture->isReady()) {
				return false;
			} else {
				defines.push_back("#define DIFFUSE");
			}
		}

		if (this->ambientTexture) {
			if (!this->ambientTexture->isReady()) {
				return false;
			} else {
				defines.push_back("#define AMBIENT");
			}
		}

		if (this->opacityTexture) {
			if (!this->opacityTexture->isReady()) {
				return false;
			} else {
				defines.push_back("#define OPACITY");
			}
		}

		if (this->reflectionTexture) {
			if (!this->reflectionTexture->isReady()) {
				return false;
			} else {
				defines.push_back("#define REFLECTION");
			}
		}

		if (this->emissiveTexture) {
			if (!this->emissiveTexture->isReady()) {
				return false;
			} else {
				defines.push_back("#define EMISSIVE");
			}
		}

		if (this->specularTexture) {
			if (!this->specularTexture->isReady()) {
				return false;
			} else {
				defines.push_back("#define SPECULAR");
				optionalDefines.push_back(defines[defines.size() - 1]);
			}
		}
	}

	if (this->_scene->getEngine()->getCaps().standardDerivatives && this->bumpTexture) {
		if (!this->bumpTexture->isReady()) {
			return false;
		} else {
			defines.push_back("#define BUMP");
			optionalDefines.push_back(defines[defines.size() - 1]);
		}
	}

	// Effect
	// TODO: what todo with clipPlane
	////if (BABYLON.clipPlane) {
	////	defines.push_back("#define CLIPPLANE");
	////}

	if (engine->getAlphaTesting()) {
		defines.push_back("#define ALPHATEST");
	}

	// Fog
	if (this->_scene->fogMode != FOGMODE_NONE) {
		defines.push_back("#define FOG");
		optionalDefines.push_back(defines[defines.size() - 1]);
	}

	auto shadowsActivated = false;
	auto lightIndex = 0;
	if (this->_scene->lightsEnabled) {
		for (auto light : this->_scene->lights) {
			if (!light->isEnabled()) {
				continue;
			}

			if (mesh && find(begin(light->excludedMeshes), end(light->excludedMeshes), mesh) != end(light->excludedMeshes)) {
				continue;
			}

			defines.push_back("#define LIGHT" + lightIndex);

			if (lightIndex > 0) {
				optionalDefines.push_back(defines[defines.size() - 1]);
			}

			string type;
			// TODO: finish it when added others lights
			////if (light instanceof BABYLON.SpotLight) {
			////	type = "#define SPOTLIGHT" + lightIndex;
			////} else if (light instanceof BABYLON.HemisphericLight) {
			////	type = "#define HEMILIGHT" + lightIndex;
			////} else {
			type = "#define POINTDIRLIGHT" + lightIndex;
			////}

			defines.push_back(type);
			if (lightIndex > 0) {
				optionalDefines.push_back(defines[defines.size() - 1]);
			}

			// Shadows
			auto shadowGenerator = light->getShadowGenerator();
			if (mesh && mesh->receiveShadows && shadowGenerator) {
				defines.push_back("#define SHADOW" + lightIndex);

				if (lightIndex > 0) {
					optionalDefines.push_back(defines[defines.size() - 1]);
				}

				if (!shadowsActivated) {
					defines.push_back("#define SHADOWS");
					shadowsActivated = true;
				}

				if (shadowGenerator->useVarianceShadowMap) {
					defines.push_back("#define SHADOWVSM" + lightIndex);
					if (lightIndex > 0) {
						optionalDefines.push_back(defines[defines.size() - 1]);
					}
				}
			}

			lightIndex++;
			if (lightIndex == 4)
				break;
		}
	}

	vector<VertexBufferKind> attribs;
	attribs.push_back(VertexBufferKind_PositionKind);
	attribs.push_back(VertexBufferKind_NormalKind);
	if (mesh) {
		if (mesh->isVerticesDataPresent(VertexBufferKind_UVKind)) {
			attribs.push_back(VertexBufferKind_UVKind);
			defines.push_back("#define UV1");
		}
		if (mesh->isVerticesDataPresent(VertexBufferKind_UV2Kind)) {
			attribs.push_back(VertexBufferKind_UV2Kind);
			defines.push_back("#define UV2");
		}
		if (mesh->isVerticesDataPresent(VertexBufferKind_ColorKind)) {
			attribs.push_back(VertexBufferKind_ColorKind);
			defines.push_back("#define VERTEXCOLOR");
		}
		if (mesh->skeleton && mesh->isVerticesDataPresent(VertexBufferKind_MatricesIndicesKind) && mesh->isVerticesDataPresent(VertexBufferKind_MatricesWeightsKind)) {
			attribs.push_back(VertexBufferKind_MatricesIndicesKind);
			attribs.push_back(VertexBufferKind_MatricesWeightsKind);
			defines.push_back("#define BONES");
			defines.push_back("#define BonesPerMesh " + mesh->skeleton->bones.size());
			defines.push_back("#define BONES4");
			optionalDefines.push_back(defines[defines.size() - 1]);
		}
	}

	// Get correct effect      
	stringstream ss;
	for_each(begin(defines), end(defines), [&](string& item) { ss << item << endl; });
	auto join = ss.str();

	if (this->_cachedDefines != join) {
		this->_cachedDefines = join;

		auto shaderName = "default";

		vector<string> uniformNames;
		uniformNames.push_back("world");
		uniformNames.push_back("view");
		uniformNames.push_back("viewProjection");
		uniformNames.push_back("vEyePosition");
		uniformNames.push_back("vLightsType");
		uniformNames.push_back("vAmbientColor");
		uniformNames.push_back("vDiffuseColor");
		uniformNames.push_back("vSpecularColor");
		uniformNames.push_back("vEmissiveColor");
		uniformNames.push_back("vLightData0");
		uniformNames.push_back("vLightDiffuse0");
		uniformNames.push_back("vLightSpecular0");
		uniformNames.push_back("vLightDirection0");
		uniformNames.push_back("vLightGround0");
		uniformNames.push_back("lightMatrix0");
		uniformNames.push_back("vLightData1");
		uniformNames.push_back("vLightDiffuse1");
		uniformNames.push_back("vLightSpecular1");
		uniformNames.push_back("vLightDirection1");
		uniformNames.push_back("vLightGround1");
		uniformNames.push_back("lightMatrix1");
		uniformNames.push_back("vLightData2");
		uniformNames.push_back("vLightDiffuse2");
		uniformNames.push_back("vLightSpecular2");
		uniformNames.push_back("vLightDirection2");
		uniformNames.push_back("vLightGround2");
		uniformNames.push_back("lightMatrix2");
		uniformNames.push_back("vLightData3");
		uniformNames.push_back("vLightDiffuse3");
		uniformNames.push_back("vLightSpecular3");
		uniformNames.push_back("vLightDirection3");
		uniformNames.push_back("vLightGround3");
		uniformNames.push_back("lightMatrix3");
		uniformNames.push_back("vFogInfos");
		uniformNames.push_back("vFogColor");
		uniformNames.push_back("vDiffuseInfos");
		uniformNames.push_back("vAmbientInfos");
		uniformNames.push_back("vOpacityInfos");
		uniformNames.push_back("vReflectionInfos");
		uniformNames.push_back("vEmissiveInfos");
		uniformNames.push_back("vSpecularInfos");
		uniformNames.push_back("vBumpInfos");
		uniformNames.push_back("mBones");
		uniformNames.push_back("vClipPlane");
		uniformNames.push_back("diffuseMatrix");
		uniformNames.push_back("ambientMatrix");
		uniformNames.push_back("opacityMatrix");
		uniformNames.push_back("reflectionMatrix");
		uniformNames.push_back("emissiveMatrix");
		uniformNames.push_back("specularMatrix");
		uniformNames.push_back("bumpMatrix");

		vector<string> samplers;
		samplers.push_back("diffuseSampler");
		samplers.push_back("ambientSampler");
		samplers.push_back("opacitySampler");
		samplers.push_back("reflectionCubeSampler");
		samplers.push_back("reflection2DSampler");
		samplers.push_back("emissiveSampler");
		samplers.push_back("specularSampler");
		samplers.push_back("bumpSampler");
		samplers.push_back("shadowSampler0");
		samplers.push_back("shadowSampler1");
		samplers.push_back("shadowSampler2");
		samplers.push_back("shadowSampler3");

		this->_effect = this->_scene->getEngine()->createEffect(shaderName,
			attribs,
			uniformNames,
			samplers,
			join, 
			optionalDefines);
	}
	if (!this->_effect->isReady()) {
		return false;
	}

	this->_renderId = this->_scene->getRenderId();
	this->_wasPreviouslyReady = true;
	return true;
};

IRenderable::Array Babylon::StandardMaterial::getRenderTargetTextures () {
	this->_renderTargets.clear();

	if (this->reflectionTexture && this->reflectionTexture->isRenderTarget) {
		this->_renderTargets.push_back(dynamic_pointer_cast<IRenderable>(this->reflectionTexture));
	}

	return this->_renderTargets;
};

void Babylon::StandardMaterial::unbind () {
	if (this->reflectionTexture && this->reflectionTexture->isRenderTarget) {
		this->_effect->setTexture("reflection2DSampler", nullptr);
	}
};

void Babylon::StandardMaterial::bind (Matrix::Ptr world, Mesh::Ptr mesh) {
	this->_baseColor->copyFrom(this->diffuseColor);

	// Matrices        
	this->_effect->setMatrix("world", world);
	this->_effect->setMatrix("viewProjection", this->_scene->getTransformMatrix());

	// Bones
	if (mesh->skeleton && mesh->isVerticesDataPresent(VertexBufferKind_MatricesIndicesKind) && mesh->isVerticesDataPresent(VertexBufferKind_MatricesWeightsKind)) {
		this->_effect->setMatrices("mBones", mesh->skeleton->getTransformMatrices());
	}

	// Textures        
	if (this->diffuseTexture) {
		this->_effect->setTexture("diffuseSampler", this->diffuseTexture);

		this->_effect->setFloat2("vDiffuseInfos", this->diffuseTexture->coordinatesIndex, this->diffuseTexture->level);
		this->_effect->setMatrix("diffuseMatrix", this->diffuseTexture->_computeTextureMatrix());

		this->_baseColor->copyFromFloats(1, 1, 1);
	}

	if (this->ambientTexture) {
		this->_effect->setTexture("ambientSampler", this->ambientTexture);

		this->_effect->setFloat2("vAmbientInfos", this->ambientTexture->coordinatesIndex, this->ambientTexture->level);
		this->_effect->setMatrix("ambientMatrix", this->ambientTexture->_computeTextureMatrix());
	}

	if (this->opacityTexture) {
		this->_effect->setTexture("opacitySampler", this->opacityTexture);

		this->_effect->setFloat2("vOpacityInfos", this->opacityTexture->coordinatesIndex, this->opacityTexture->level);
		this->_effect->setMatrix("opacityMatrix", this->opacityTexture->_computeTextureMatrix());
	}

	if (this->reflectionTexture) {
		if (this->reflectionTexture->isCube) {
			this->_effect->setTexture("reflectionCubeSampler", this->reflectionTexture);
		} else {
			this->_effect->setTexture("reflection2DSampler", this->reflectionTexture);
		}

		this->_effect->setMatrix("reflectionMatrix", this->reflectionTexture->_computeReflectionTextureMatrix());
		this->_effect->setFloat3("vReflectionInfos", this->reflectionTexture->coordinatesMode, this->reflectionTexture->level, this->reflectionTexture->isCube ? 1 : 0);
	}

	if (this->emissiveTexture) {
		this->_effect->setTexture("emissiveSampler", this->emissiveTexture);

		this->_effect->setFloat2("vEmissiveInfos", this->emissiveTexture->coordinatesIndex, this->emissiveTexture->level);
		this->_effect->setMatrix("emissiveMatrix", this->emissiveTexture->_computeTextureMatrix());
	}

	if (this->specularTexture) {
		this->_effect->setTexture("specularSampler", this->specularTexture);

		this->_effect->setFloat2("vSpecularInfos", this->specularTexture->coordinatesIndex, this->specularTexture->level);
		this->_effect->setMatrix("specularMatrix", this->specularTexture->_computeTextureMatrix());
	}

	if (this->bumpTexture && this->_scene->getEngine()->getCaps().standardDerivatives) {
		this->_effect->setTexture("bumpSampler", this->bumpTexture);

		this->_effect->setFloat2("vBumpInfos", this->bumpTexture->coordinatesIndex, this->bumpTexture->level);
		this->_effect->setMatrix("bumpMatrix", this->bumpTexture->_computeTextureMatrix());
	}

	// Colors
	this->_scene->ambientColor->multiplyToRef(this->ambientColor, this->_globalAmbientColor);

	this->_effect->setVector3("vEyePosition", this->_scene->activeCamera->position);
	this->_effect->setColor3("vAmbientColor", this->_globalAmbientColor);
	this->_effect->setColor4("vDiffuseColor", this->_baseColor, this->alpha * mesh->visibility);
	this->_effect->setColor4("vSpecularColor", this->specularColor, this->specularPower);
	this->_effect->setColor3("vEmissiveColor", this->emissiveColor);

	if (this->_scene->lightsEnabled) {
		auto lightIndex = 0;
		for (auto light : this->_scene->lights) {
			if (!light->isEnabled()) {
				continue;
			}

			if (mesh && find(begin(light->excludedMeshes), end(light->excludedMeshes), mesh) != end(light->excludedMeshes)) {
				continue;
			}

			// TODO: finish when added all lights
			////if (light instanceof BABYLON.PointLight) {
			////	// Point Light
			////	light->transferToEffect(this->_effect, "vLightData" + lightIndex);
			////} else if (light instanceof BABYLON.DirectionalLight) {
			////	// Directional Light
			////	light->transferToEffect(this->_effect, "vLightData" + lightIndex);
			////} else if (light instanceof BABYLON.SpotLight) {
			////	// Spot Light
			////	light->transferToEffect(this->_effect, "vLightData" + lightIndex, "vLightDirection" + lightIndex);
			////} else if (light instanceof BABYLON.HemisphericLight) {
				// Hemispheric Light
				light->transferToEffect(this->_effect, "vLightData" + lightIndex, "vLightGround" + lightIndex);
			////}

			light->diffuse->scaleToRef(light->intensity, this->_scaledDiffuse);
			light->specular->scaleToRef(light->intensity, this->_scaledSpecular);
			this->_effect->setColor3("vLightDiffuse" + lightIndex, this->_scaledDiffuse);
			this->_effect->setColor3("vLightSpecular" + lightIndex, this->_scaledSpecular);

			// Shadows
			auto shadowGenerator = light->getShadowGenerator();
			if (mesh->receiveShadows && shadowGenerator) {
				world->multiplyToRef(shadowGenerator->getTransformMatrix(), this->_lightMatrix);
				this->_effect->setMatrix("lightMatrix" + lightIndex, this->_lightMatrix);
				this->_effect->setTexture("shadowSampler" + lightIndex, shadowGenerator->getShadowMap());
			}

			lightIndex++;

			if (lightIndex == 4)
				break;
		}
	}

	// TODO: finish when clipPlane added
	////if (BABYLON.clipPlane) {
	////	this->_effect->setFloat4("vClipPlane", BABYLON.clipPlane->normal->x, BABYLON->clipPlane->normal->y, BABYLON->clipPlane->normal->z, BABYLON->clipPlane->d);
	////}

	// View
	if (this->_scene->fogMode != FOGMODE_NONE || this->reflectionTexture) {
		this->_effect->setMatrix("view", this->_scene->getViewMatrix());
	}

	// Fog
	if (this->_scene->fogMode != FOGMODE_NONE) {
		this->_effect->setFloat4("vFogInfos", this->_scene->fogMode, this->_scene->fogStart, this->_scene->fogEnd, this->_scene->fogDensity);
		this->_effect->setColor3("vFogColor", this->_scene->fogColor);
	}
};

Texture::Array Babylon::StandardMaterial::getAnimatables () {
	Texture::Array results;

	if (this->diffuseTexture && this->diffuseTexture->animations.size() > 0) {
		results.push_back(this->diffuseTexture);
	}

	if (this->ambientTexture && this->ambientTexture->animations.size() > 0) {
		results.push_back(this->ambientTexture);
	}

	if (this->opacityTexture && this->opacityTexture->animations.size() > 0) {
		results.push_back(this->opacityTexture);
	}

	if (this->reflectionTexture && this->reflectionTexture->animations.size() > 0) {
		results.push_back(this->reflectionTexture);
	}

	if (this->emissiveTexture && this->emissiveTexture->animations.size() > 0) {
		results.push_back(this->emissiveTexture);
	}

	if (this->specularTexture && this->specularTexture->animations.size() > 0) {
		results.push_back(this->specularTexture);
	}

	if (this->bumpTexture && this->bumpTexture->animations.size() > 0) {
		results.push_back(this->bumpTexture);
	}

	return results;
};

void Babylon::StandardMaterial::dispose () {
	if (this->diffuseTexture) {
		this->diffuseTexture->dispose();
	}

	if (this->ambientTexture) {
		this->ambientTexture->dispose();
	}

	if (this->opacityTexture) {
		this->opacityTexture->dispose();
	}

	if (this->reflectionTexture) {
		this->reflectionTexture->dispose();
	}

	if (this->emissiveTexture) {
		this->emissiveTexture->dispose();
	}

	if (this->specularTexture) {
		this->specularTexture->dispose();
	}

	if (this->bumpTexture) {
		this->bumpTexture->dispose();
	}

	this->baseDispose();
};

StandardMaterial::Ptr Babylon::StandardMaterial::clone (string name) {
	auto newStandardMaterial = StandardMaterial::New(name, this->_scene);

	// Base material
	newStandardMaterial->checkReadyOnEveryCall = this->checkReadyOnEveryCall;
	newStandardMaterial->alpha = this->alpha;
	newStandardMaterial->wireframe = this->wireframe;
	newStandardMaterial->backFaceCulling = this->backFaceCulling;

	// Standard material
	if (this->diffuseTexture) {
		newStandardMaterial->diffuseTexture = this->diffuseTexture->clone();
	}
	if (this->ambientTexture) {
		newStandardMaterial->ambientTexture = this->ambientTexture->clone();
	}
	if (this->opacityTexture) {
		newStandardMaterial->opacityTexture = this->opacityTexture->clone();
	}
	if (this->reflectionTexture) {
		newStandardMaterial->reflectionTexture = dynamic_pointer_cast<RenderTargetTexture>(this->reflectionTexture->clone());
	}
	if (this->emissiveTexture) {
		newStandardMaterial->emissiveTexture = this->emissiveTexture->clone();
	}
	if (this->specularTexture) {
		newStandardMaterial->specularTexture = this->specularTexture->clone();
	}
	if (this->bumpTexture) {
		newStandardMaterial->bumpTexture = this->bumpTexture->clone();
	}

	newStandardMaterial->ambientColor = this->ambientColor->clone();
	newStandardMaterial->diffuseColor = this->diffuseColor->clone();
	newStandardMaterial->specularColor = this->specularColor->clone();
	newStandardMaterial->specularPower = this->specularPower;
	newStandardMaterial->emissiveColor = this->emissiveColor->clone();

	return newStandardMaterial;
};
