#ifndef BABYLON_TEXTURE_H
#define BABYLON_TEXTURE_H

#include <memory>
#include <vector>

#include "iengine.h"
#include "baseTexture.h"
#include "matrix.h"

using namespace std;

namespace Babylon {

	// TODO: add animation type
	class Texture: public BaseTexture, public enable_shared_from_this<Texture> {

	public:
		typedef shared_ptr<Texture> Ptr;
		typedef vector<Ptr> Array;

	protected:
		float _cachedUOffset;
		float _cachedVOffset;
		float _cachedUScale;
		float _cachedVScale;
		float _cachedUAng;
		float _cachedVAng;
		float _cachedWAng;
		Matrix::Ptr _cachedTextureMatrix;
		Matrix::Ptr _rowGenerationMatrix;
		Matrix::Ptr _projectionModeMatrix;
		Vector3::Ptr _t0;
		Vector3::Ptr _t1;
		Vector3::Ptr _t2;

		// TAGS
		bool _noMipmap;
		bool _invertY;
		MODES _cachedCoordinatesMode;

	public:
		string name;
		// Members
		float uOffset;
		float vOffset;
		float uScale;
		float vScale;
		float uAng;
		float vAng;
		float wAng;
		ADDRESSMODES wrapU;
		ADDRESSMODES wrapV;
		float coordinatesIndex;
		MODES coordinatesMode;
		int anisotropicFilteringLevel;
		vector<shared_ptr<void>> animations;

		// TAGS
		int _cachedAnisotropicFilteringLevel;


	public: 
		Texture(string url, ScenePtr scene, bool noMipmap = false, bool invertY = false);		
		
		// Methods    
		virtual void delayLoad ();
		virtual Matrix::Ptr _computeTextureMatrix ();
		virtual void _prepareRowForTextureGeneration(float x, float y, float z, Vector3::Ptr t);
		virtual Matrix::Ptr _computeReflectionTextureMatrix ();
		virtual Texture::Ptr clone ();
	};

};

#endif // BABYLON_TEXTURE_H