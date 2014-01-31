#ifndef BABYLON_EFFECT_H
#define BABYLON_EFFECT_H

#include <memory>
#include <vector>
#include <string>
#include <map>
#include <functional>

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
		typedef shared_ptr<Effect> Ptr;
		typedef vector<Ptr> Array;
		typedef Ptr ShaderPtr;
		typedef function<void (string)> CallbackFunc;

	public:

		EnginePtr _engine;
		string name;
		string defines;
		vector<string> _uniformsNames;
		vector<string> _samplers;
		bool _isReady;
		string _compilationError;
		vector<VertexBufferKind> _attributes;
		map<VertexBufferKind, int> _attributeLocations;

		map<string, Float32Array> _valueCache;

		IGLProgram::Ptr _program;
		IGLUniformLocation::Array _uniforms;

	public:
		static map<string, string> ShadersStore;

	private:
		void _init(string baseName, string vertex, string fragment, vector<VertexBufferKind> attributesNames, vector<string> uniformsNames, vector<string> samplers, EnginePtr engine, string defines, vector<string> optionalDefines);		
	public: 
		Effect();		
	public: 
		static Effect::Ptr New(string baseName, vector<VertexBufferKind> attributesNames, vector<string> uniformsNames, vector<string> samplers, EnginePtr engine, string defines, vector<string> optionalDefines);		
		static Effect::Ptr New(string baseName, string vertex, string fragment, vector<VertexBufferKind> attributesNames, vector<string> uniformsNames, vector<string> samplers, EnginePtr engine, string defines, vector<string> optionalDefines);		

		// Properties
		virtual bool isReady();
		virtual IGLProgram::Ptr getProgram();
		virtual vector<VertexBufferKind>& getAttributes();
		virtual int getAttributeLocation(VertexBufferKind kind);
		virtual int getUniformIndex(string uniformName);
		virtual IGLUniformLocation::Ptr getUniform(string uniformName);
		virtual IGLUniformLocation::Ptr getUniform(int sample);
		virtual vector<string>& getSamplers();
		virtual string getCompilationError();
		// Methods
		virtual void _loadVertexShader(string vertex, CallbackFunc callback);
		virtual void _loadFragmentShader(string fragment, CallbackFunc callback);
		virtual void _prepareEffect(string vertexSourceCode, string fragmentSourceCode, vector<VertexBufferKind> attributesNames, string defines, vector<string> optionalDefines, bool useFallback = false);
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
		//virtual void setVector2(string uniformName, vector2);
		virtual void setFloat2(string uniformName, float x, float y);
		virtual void setVector3(string uniformName, Vector3::Ptr vector3);
		virtual void setFloat3(string uniformName, float x, float y, float z);
		virtual void setFloat4(string uniformName, float x, float y, float z, float w);
		virtual void setColor3(string uniformName, Color3::Ptr color3);
		virtual void setColor4(string uniformName, Color3::Ptr color3, float alpha);
	};

};

#endif // BABYLON_EFFECT_H