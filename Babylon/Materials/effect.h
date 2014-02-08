#ifndef BABYLON_EFFECT_H
#define BABYLON_EFFECT_H

#include "decls.h"

#include "igl.h"
#include "iengine.h"
#include "tools_math.h"
#include "vertexbuffer.h"
#include "texture.h"
#include "postProcess.h"


using namespace std;

namespace Babylon {

	// TODO: finish it
	class Effect: public enable_shared_from_this<Effect> {

	public:
		typedef shared_ptr_t<Effect> Ptr;
		typedef vector_t<Ptr> Array;
		typedef Ptr ShaderPtr;
		typedef function<void (string)> CallbackFunc;

	public:

		EnginePtr _engine;
		string name;
		string defines;
		vector_t<string> _uniformsNames;
		vector_t<string> _samplers;
		bool _isReady;
		string _compilationError;
		vector_t<VertexBufferKind> _attributes;
		map_t<VertexBufferKind, int> _attributeLocations;

		map_t<string, Float32Array> _valueCache;

		IGLProgram::Ptr _program;
		IGLUniformLocation::Array _uniforms;

	public:
		static map_t<string, string> ShadersStore;

	private:
		void _init(string baseName, string vertex, string fragment, vector_t<VertexBufferKind> attributesNames, vector_t<string> uniformsNames, vector_t<string> samplers, EnginePtr engine, string defines, vector_t<string> optionalDefines);		
	public: 
		Effect();		
	public: 
		static Effect::Ptr New(string baseName, vector_t<VertexBufferKind> attributesNames, vector_t<string> uniformsNames, vector_t<string> samplers, EnginePtr engine, string defines, vector_t<string> optionalDefines);		
		static Effect::Ptr New(string baseName, string vertex, string fragment, vector_t<VertexBufferKind> attributesNames, vector_t<string> uniformsNames, vector_t<string> samplers, EnginePtr engine, string defines, vector_t<string> optionalDefines);		

		// Properties
		virtual bool isReady();
		virtual IGLProgram::Ptr getProgram();
		virtual vector_t<VertexBufferKind>& getAttributes();
		virtual int getAttributeLocation(VertexBufferKind kind);
		virtual int getUniformIndex(string uniformName);
		virtual IGLUniformLocation::Ptr getUniform(string uniformName);
		virtual IGLUniformLocation::Ptr getUniform(int sample);
		virtual vector_t<string>& getSamplers();
		virtual string getCompilationError();
		// Methods
		virtual void _loadVertexShader(string vertex, CallbackFunc callback);
		virtual void _loadFragmentShader(string fragment, CallbackFunc callback);
		virtual void _prepareEffect(string vertexSourceCode, string fragmentSourceCode, vector_t<VertexBufferKind> attributesNames, string defines, vector_t<string> optionalDefines, bool useFallback = false);
		virtual void _bindTexture(string channel, IGLTexture::Ptr texture);
		virtual void setTexture(string channel, Texture::Ptr texture);
		virtual void setTextureFromPostProcess(string channel, PostProcess::Ptr postProcess);
		virtual void _cacheFloat2(string uniformName, float x, float y);
		virtual void _cacheFloat3(string uniformName, float x, float y, float z);
		virtual void _cacheFloat4(string uniformName, float x, float y, float z, float w);
		virtual void setMatrices(string uniformName, Float32Array matrices);
		virtual void setMatrix(string uniformName, Matrix::Ptr matrix);
		virtual void setFloat(string uniformName, float value);
		virtual void setBool(string uniformName, GLboolean _bool);
		virtual void setVector2(string uniformName, Vector2::Ptr vector2);
		virtual void setFloat2(string uniformName, float x, float y);
		virtual void setVector3(string uniformName, Vector3::Ptr vector3);
		virtual void setFloat3(string uniformName, float x, float y, float z);
		virtual void setFloat4(string uniformName, float x, float y, float z, float w);
		virtual void setColor3(string uniformName, Color3::Ptr color3);
		virtual void setColor4(string uniformName, Color3::Ptr color3, float alpha);
	};

};

#endif // BABYLON_EFFECT_H