#include "texture.h"
#include "vector3.h"

using namespace Babylon;

Babylon::Texture::Texture(string url, IScene::Ptr scene,  bool noMipmap, bool invertY) :
	BaseTexture(url, scene),
	uOffset (0),
	vOffset (0),
	uScale (1.0),
	vScale (1.0),
	uAng (0),
	vAng (0),
	wAng (0),
	wrapU (WRAP_ADDRESSMODE),
	wrapV (WRAP_ADDRESSMODE),
	coordinatesIndex (0),
	coordinatesMode (EXPLICIT_MODE),
	anisotropicFilteringLevel (4)
{
	// TODO: is it is base class?
	//this->_scene = scene;
	//this->_scene->getTextures().push_back(enable_shared_from_this<Texture>::shared_from_this());

	this->name = url;
	this->url = url;
	this->_noMipmap = noMipmap;
	this->_invertY = invertY;

	this->_texture = this->_getFromCache(url, noMipmap);

	if (!this->_texture) {
		if (!scene->getUseDelayedTextureLoading()) {
			this->_texture = scene->getEngine()->createTexture(url, noMipmap, invertY, scene);
		} else {
			this->delayLoadState = DELAYLOADSTATE_NOTLOADED;
		}
	}

	// Animations
	this->animations.clear();
};

// Methods    
void Babylon::Texture::delayLoad() {
	if (this->delayLoadState != DELAYLOADSTATE_NOTLOADED) {
		return;
	}

	this->delayLoadState = DELAYLOADSTATE_LOADED;
	this->_texture = this->_getFromCache(this->url, this->_noMipmap);

	if (!this->_texture) {
		this->_texture = this->_scene->getEngine()->createTexture(this->url, this->_noMipmap, this->_invertY, this->_scene);
	}
};

void Babylon::Texture::_prepareRowForTextureGeneration(float x, float y, float z, Vector3::Ptr t) {
	x -= this->uOffset + 0.5;
	y -= this->vOffset + 0.5;
	z -= 0.5;

	Vector3::TransformCoordinatesFromFloatsToRef(x, y, z, this->_rowGenerationMatrix, t);

	t->x *= this->uScale;
	t->y *= this->vScale;

	t->x += 0.5;
	t->y += 0.5;
	t->z += 0.5;
};

Matrix::Ptr Babylon::Texture::_computeTextureMatrix() {
	if (
		this->uOffset == this->_cachedUOffset &&
		this->vOffset == this->_cachedVOffset &&
		this->uScale == this->_cachedUScale &&
		this->vScale == this->_cachedVScale &&
		this->uAng == this->_cachedUAng &&
		this->vAng == this->_cachedVAng &&
		this->wAng == this->_cachedWAng) {
			return this->_cachedTextureMatrix;
	}

	this->_cachedUOffset = this->uOffset;
	this->_cachedVOffset = this->vOffset;
	this->_cachedUScale = this->uScale;
	this->_cachedVScale = this->vScale;
	this->_cachedUAng = this->uAng;
	this->_cachedVAng = this->vAng;
	this->_cachedWAng = this->wAng;

	if (!this->_cachedTextureMatrix) {
		this->_cachedTextureMatrix = Matrix::Zero();
		this->_rowGenerationMatrix = make_shared<Matrix>();
		this->_t0 = Vector3::Zero();
		this->_t1 = Vector3::Zero();
		this->_t2 = Vector3::Zero();
	}

	Matrix::RotationYawPitchRollToRef(this->vAng, this->uAng, this->wAng, this->_rowGenerationMatrix);

	this->_prepareRowForTextureGeneration(0, 0, 0, this->_t0);
	this->_prepareRowForTextureGeneration(1.0, 0, 0, this->_t1);
	this->_prepareRowForTextureGeneration(0, 1.0, 0, this->_t2);

	this->_t1->subtractInPlace(this->_t0);
	this->_t2->subtractInPlace(this->_t0);

	Matrix::IdentityToRef(this->_cachedTextureMatrix);
	this->_cachedTextureMatrix->m[0] = this->_t1->x; this->_cachedTextureMatrix->m[1] = this->_t1->y; this->_cachedTextureMatrix->m[2] = this->_t1->z;
	this->_cachedTextureMatrix->m[4] = this->_t2->x; this->_cachedTextureMatrix->m[5] = this->_t2->y; this->_cachedTextureMatrix->m[6] = this->_t2->z;
	this->_cachedTextureMatrix->m[8] = this->_t0->x; this->_cachedTextureMatrix->m[9] = this->_t0->y; this->_cachedTextureMatrix->m[10] = this->_t0->z;

	return this->_cachedTextureMatrix;
};

Matrix::Ptr Babylon::Texture::_computeReflectionTextureMatrix() {
	if (
		this->uOffset == this->_cachedUOffset &&
		this->vOffset == this->_cachedVOffset &&
		this->uScale == this->_cachedUScale &&
		this->vScale == this->_cachedVScale &&
		this->coordinatesMode == this->_cachedCoordinatesMode) {
			return this->_cachedTextureMatrix;
	}

	if (!this->_cachedTextureMatrix) {
		this->_cachedTextureMatrix = Matrix::Zero();
		this->_projectionModeMatrix = Matrix::Zero();
	}

	switch (this->coordinatesMode) {
	case SPHERICAL_MODE:
		Matrix::IdentityToRef(this->_cachedTextureMatrix);
		this->_cachedTextureMatrix->m[0] = -0.5 * this->uScale;
		this->_cachedTextureMatrix->m[5] = -0.5 * this->vScale;
		this->_cachedTextureMatrix->m[12] = 0.5 + this->uOffset;
		this->_cachedTextureMatrix->m[13] = 0.5 + this->vOffset;
		break;
	case PLANAR_MODE:
		Matrix::IdentityToRef(this->_cachedTextureMatrix);
		this->_cachedTextureMatrix->m[0] = this->uScale;
		this->_cachedTextureMatrix->m[5] = this->vScale;
		this->_cachedTextureMatrix->m[12] = this->uOffset;
		this->_cachedTextureMatrix->m[13] = this->vOffset;
		break;
	case PROJECTION_MODE:
		Matrix::IdentityToRef(this->_projectionModeMatrix);

		this->_projectionModeMatrix->m[0] = 0.5;
		this->_projectionModeMatrix->m[5] = -0.5;
		this->_projectionModeMatrix->m[10] = 0.0;
		this->_projectionModeMatrix->m[12] = 0.5;
		this->_projectionModeMatrix->m[13] = 0.5;
		this->_projectionModeMatrix->m[14] = 1.0;
		this->_projectionModeMatrix->m[15] = 1.0;

		this->_scene->getProjectionMatrix()->multiplyToRef(this->_projectionModeMatrix, this->_cachedTextureMatrix);
		break;
	default:
		Matrix::IdentityToRef(this->_cachedTextureMatrix);
		break;
	}
	return this->_cachedTextureMatrix;
};

Texture::Ptr Babylon::Texture::clone() {
	auto newTexture = make_shared<Texture>(this->_texture->url, this->_scene, this->_noMipmap, this->_invertY);

	// Base texture
	newTexture->hasAlpha = this->hasAlpha;
	newTexture->level = this->level;

	// Texture
	newTexture->uOffset = this->uOffset;
	newTexture->vOffset = this->vOffset;
	newTexture->uScale = this->uScale;
	newTexture->vScale = this->vScale;
	newTexture->uAng = this->uAng;
	newTexture->vAng = this->vAng;
	newTexture->wAng = this->wAng;
	newTexture->wrapU = this->wrapU;
	newTexture->wrapV = this->wrapV;
	newTexture->coordinatesIndex = this->coordinatesIndex;
	newTexture->coordinatesMode = this->coordinatesMode;

	return newTexture;
};
