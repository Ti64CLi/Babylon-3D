#ifndef BABYLON_IENGINE_H
#define BABYLON_IENGINE_H

#include <memory>
#include <vector>

#include "igl.h"

namespace Babylon {

	const string ShadersRepository = "Babylon/Shaders/";

	enum ALPHA_MODES {
		ALPHA_DISABLE = 0,
		ALPHA_ADD =  1,
		ALPHA_COMBINE = 2,
	};

	// TODO: Move to Engine class
	enum DELAYLOADSTATE {
		DELAYLOADSTATE_NONE = 0,
		DELAYLOADSTATE_LOADED = 1,
		DELAYLOADSTATE_LOADING = 2,
		DELAYLOADSTATE_NOTLOADED = 4
	};

	// TODO: Move to Texture class
	enum SAMPLINGMODES {
		NEAREST_SAMPLINGMODE = 1,
		BILINEAR_SAMPLINGMODE = 2,
		TRILINEAR_SAMPLINGMODE = 3
	};

	// TODO: Move to Texture class
	enum MODES {
		EXPLICIT_MODE = 0,
		SPHERICAL_MODE = 1,
		PLANAR_MODE = 2,
		CUBIC_MODE = 3,
		PROJECTION_MODE = 4,
		SKYBOX_MODE = 5
	};

	// TODO: Move to Texture class
	enum ADDRESSMODES {
		CLAMP_ADDRESSMODE = 0,
		WRAP_ADDRESSMODE = 1,
		MIRROR_ADDRESSMODE = 2
	};

	enum FOGMODES {
		FOGMODE_NONE = 0,
		FOGMODE_EXP = 1,
		FOGMODE_EXP2 = 2,
		FOGMODE_LINEAR = 3
	};

	enum CAMERAS {
		PERSPECTIVE_CAMERA = 0,
		ORTHOGRAPHIC_CAMERA = 1,
	};

	enum BILLBOARDMODES {
		BILLBOARDMODE_NONE = 0,
		BILLBOARDMODE_X = 1,
		BILLBOARDMODE_Y = 2,
		BILLBOARDMODE_Z = 4,
		BILLBOARDMODE_ALL = 7
	};

	enum ANIMATIONTYPES {
		ANIMATIONTYPE_FLOAT = 0,
		ANIMATIONTYPE_VECTOR3 = 1,
		ANIMATIONTYPE_QUATERNION = 2,
		ANIMATIONTYPE_MATRIX = 3
	};

	enum ANIMATIONLOOPMODES {
		ANIMATIONLOOPMODE_RELATIVE = 0,
		ANIMATIONLOOPMODE_CYCLE = 1,
		ANIMATIONLOOPMODE_CONSTANT = 2
	};

	enum BLENDMODES {
		BLENDMODE_ONEONE = 0,
		BLENDMODE_STANDARD = 1
	};

	enum VertexBufferKind {
		VertexBufferKind_PositionKind = 1,
		VertexBufferKind_NormalKind,
		VertexBufferKind_UVKind,
		VertexBufferKind_UV2Kind,
		VertexBufferKind_ColorKind,
		VertexBufferKind_MatricesIndicesKind,
		VertexBufferKind_MatricesWeightsKind,
		Attribute_Options,
		Attribute_CellInfo,
	};

	class Matrix;
	typedef shared_ptr_t<Matrix> MatrixPtr;
	struct Vector3;
	typedef shared_ptr_t<Vector3> Vector3Ptr;
	struct Color3;
	typedef shared_ptr_t<Color3> Color3Ptr;
	class IScene;
	typedef shared_ptr_t<IScene> IScenePtr;
	class Effect;
	typedef shared_ptr_t<Effect> EffectPtr;

	struct Size {
	public:
		GLint width;
		GLint height;

		Size(GLint width_, GLint height_)
			: width(width_), height(height_)
		{
		}
	};

	struct Range {
	public:
		GLfloat min;
		GLfloat max;

		Range(GLfloat min_, GLfloat max_)
			: min(min_), max(max_)
		{
		}
	};

	struct Capabilities {
		// Caps
		size_t maxTexturesImageUnits;
		size_t maxTextureSize;
		size_t maxCubemapTextureSize;
		size_t maxRenderTextureSize;

		// Extensions
		bool standardDerivatives;
		bool textureFloat;        
		bool textureAnisotropicFilterExtension;
		int maxAnisotropy;
	};

	struct State {
		bool culling;
	};

	class IDisposable {
	public:
		typedef shared_ptr_t<IDisposable> Ptr;
		typedef vector_t<Ptr> Array;

		virtual void dispose(bool doNotRecurse = false) = 0;
	};

	class IRenderable {
	public:
		typedef shared_ptr_t<IRenderable> Ptr;
		typedef vector_t<Ptr> Array;

		virtual void render() = 0;
	};

	class Scene;
	typedef shared_ptr_t<Scene> ScenePtr;

	class Engine;
	typedef shared_ptr_t<Engine> EnginePtr;
};

#endif // BABYLON_IENGINE_H
