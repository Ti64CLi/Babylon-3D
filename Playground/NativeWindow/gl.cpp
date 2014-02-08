#include "gl.h"
#include <memory>
#include <stdexcept>

#include <GL/glew.h>
#include <GL/glut.h>

GL::GL(Babylon::ICanvas::Ptr canvas, bool antialias) {
	this->canvas = canvas;
	this->antialias = antialias;

	// build map of string vs enums
	EnumMap["TEXTURE"] = Babylon::TEXTURE;
	EnumMap["TEXTURE0"] = Babylon::TEXTURE0;
	EnumMap["TEXTURE1"] = Babylon::TEXTURE1;
	EnumMap["TEXTURE2"] = Babylon::TEXTURE2;
	EnumMap["TEXTURE3"] = Babylon::TEXTURE3;
	EnumMap["TEXTURE4"] = Babylon::TEXTURE4;
	EnumMap["TEXTURE5"] = Babylon::TEXTURE5;
	EnumMap["TEXTURE6"] = Babylon::TEXTURE6;
	EnumMap["TEXTURE7"] = Babylon::TEXTURE7;
	EnumMap["TEXTURE8"] = Babylon::TEXTURE8;
	EnumMap["TEXTURE9"] = Babylon::TEXTURE9;
	EnumMap["TEXTURE10"] = Babylon::TEXTURE10;
	EnumMap["TEXTURE11"] = Babylon::TEXTURE11;
	EnumMap["TEXTURE12"] = Babylon::TEXTURE12;
	EnumMap["TEXTURE13"] = Babylon::TEXTURE13;
	EnumMap["TEXTURE14"] = Babylon::TEXTURE14;
	EnumMap["TEXTURE15"] = Babylon::TEXTURE15;
	EnumMap["TEXTURE16"] = Babylon::TEXTURE16;
	EnumMap["TEXTURE17"] = Babylon::TEXTURE17;
	EnumMap["TEXTURE18"] = Babylon::TEXTURE18;
	EnumMap["TEXTURE19"] = Babylon::TEXTURE19;
	EnumMap["TEXTURE20"] = Babylon::TEXTURE20;
	EnumMap["TEXTURE21"] = Babylon::TEXTURE21;
	EnumMap["TEXTURE22"] = Babylon::TEXTURE22;
	EnumMap["TEXTURE23"] = Babylon::TEXTURE23;
	EnumMap["TEXTURE24"] = Babylon::TEXTURE24;
	EnumMap["TEXTURE25"] = Babylon::TEXTURE25;
	EnumMap["TEXTURE26"] = Babylon::TEXTURE26;
	EnumMap["TEXTURE27"] = Babylon::TEXTURE27;
	EnumMap["TEXTURE28"] = Babylon::TEXTURE28;
	EnumMap["TEXTURE29"] = Babylon::TEXTURE29;
	EnumMap["TEXTURE30"] = Babylon::TEXTURE30;
	EnumMap["TEXTURE31"] = Babylon::TEXTURE31;
}

Babylon::ICanvas::Ptr GL::getCanvas() { 
	return this->canvas;
}

Babylon::GLsizei GL::getDrawingBufferWidth() { 
	throw "not supported";
}

Babylon::GLsizei GL::getDrawingBufferHeight() { 
	throw "not supported";
}

Babylon::GLContextAttributes GL::getContextAttributes() { 
	return getContextAttributes();
}

bool GL::isContextLost() { 
	throw "not supported";
}

vector<string> GL::getSupportedExtensions() { 
	//// glGetString(GL_EXTENSIONS);
	throw "not supported";
}

Babylon::any GL::getExtension(string name) {
	bool result;
	if (glewGetExtension(name.c_str()))
	{
		result = true;
		return &result;
	}

	return nullptr;
}

Babylon::GLenum GL::operator[] (string name) { 
	return EnumMap[name];
}

void GL::activeTexture(Babylon::GLenum texture) { 
	glActiveTexture(texture);
	errorCheck();
}

void GL::attachShader(Babylon::IGLProgram::Ptr program, Babylon::IGLShader::Ptr shader) { 
	glAttachShader(program->value, shader->value);
	errorCheck();
}

void GL::bindAttribLocation(Babylon::IGLProgram::Ptr program, Babylon::GLuint index, string name) { 
	glBindAttribLocation(program->value, index, name.c_str());
	errorCheck();
}

void GL::bindBuffer(Babylon::GLenum target, Babylon::IGLBuffer::Ptr buffer) { 
	glBindBuffer(target, buffer ? buffer->value : 0);
	errorCheck();
}

void GL::bindFramebuffer(Babylon::GLenum target, Babylon::IGLFramebuffer::Ptr framebuffer) { 
	glBindFramebufferEXT(target, framebuffer->value);
	errorCheck();
}

void GL::bindRenderbuffer(Babylon::GLenum target, Babylon::IGLRenderbuffer::Ptr renderbuffer) { 
	glBindRenderbufferEXT(target, renderbuffer->value);
	errorCheck();
}

void GL::bindTexture(Babylon::GLenum target, Babylon::IGLTexture::Ptr texture) { 
	glBindTextureEXT(target, texture->value);
	errorCheck();
}

void GL::blendColor(Babylon::GLclampf red, Babylon::GLclampf green, Babylon::GLclampf blue, Babylon::GLclampf alpha) { 
	glBlendColor(red, green, blue, alpha);
	errorCheck();
}

void GL::blendEquation(Babylon::GLenum mode) { 
	glBlendEquation(mode);
	errorCheck();
}

void GL::blendEquationSeparate(Babylon::GLenum modeRGB, Babylon::GLenum modeAlpha) { 
	glBlendEquationSeparate(modeRGB, modeAlpha);
	errorCheck();
}

void GL::blendFunc(Babylon::GLenum sfactor, Babylon::GLenum dfactor) { 
	glBlendFunc(sfactor, dfactor);
	errorCheck();
}

void GL::blendFuncSeparate(Babylon::GLenum srcRGB, Babylon::GLenum dstRGB, 
						   Babylon::GLenum srcAlpha, Babylon::GLenum dstAlpha) { 
							   glBlendFuncSeparateEXT(srcRGB, dstRGB, srcAlpha, dstAlpha);
							   errorCheck();
}

void GL::bufferData(Babylon::GLenum target, Babylon::GLsizeiptr sizeiptr, Babylon::GLenum usage) { 
	glBufferData(target, sizeiptr >> 32, (Babylon::any)(sizeiptr & 0x0000ffff), usage);
	errorCheck();
}

void GL::bufferData(Babylon::GLenum target, Babylon::Float32Array& data, Babylon::GLenum usage) { 
	glBufferData(target, data.size() * sizeof(Babylon::GLfloat), data.data(), usage);
	errorCheck();
}

void GL::bufferData(Babylon::GLenum target, Babylon::Int32Array& data, Babylon::GLenum usage) { 
	glBufferData(target, data.size() * sizeof(int32_t), data.data(), usage);
	errorCheck();
}

void GL::bufferData(Babylon::GLenum target, Babylon::Uint16Array& data, Babylon::GLenum usage) { 
	glBufferData(target, data.size() * sizeof(char16_t), data.data(), usage);
	errorCheck();
}

void GL::bufferSubData(Babylon::GLenum target, Babylon::GLintptr offset, Babylon::Float32Array& data) { 
	glBufferSubData(target, offset, data.size() * sizeof(Babylon::GLfloat), data.data());
	errorCheck();
}

void GL::bufferSubData(Babylon::GLenum target, Babylon::GLintptr offset, Babylon::Int32Array& data) { 
	glBufferSubData(target, offset, data.size() * sizeof(int32_t), data.data());
	errorCheck();
}

Babylon::GLenum GL::checkFramebufferStatus(Babylon::GLenum target) { 
	return glCheckFramebufferStatusEXT(target);
}

void GL::clear(Babylon::GLbitfield mask) { 
	glClear(mask);
	errorCheck();
}

void GL::clearColor(Babylon::GLclampf red, Babylon::GLclampf green, Babylon::GLclampf blue, Babylon::GLclampf alpha) { 
	glClearColor(red, green, blue, alpha);
	errorCheck();
}

void GL::clearDepth(Babylon::GLclampf depth) { 
	glClearDepth(depth);
	errorCheck();
}

void GL::clearStencil(Babylon::GLint s) { 
	glClearStencil(s);
	errorCheck();
}

void GL::colorMask(Babylon::GLboolean red, Babylon::GLboolean green, Babylon::GLboolean blue, Babylon::GLboolean alpha) { 
	glColorMask(red, green, blue, alpha);
	errorCheck();
}

void GL::compileShader(Babylon::IGLShader::Ptr shader) { 
	glCompileShader(shader->value);
	errorCheck();
}

void GL::compressedTexSubImage2D(Babylon::GLenum target, Babylon::GLint level,
								 Babylon::GLint xoffset, Babylon::GLint yoffset,
								 Babylon::GLsizei width, Babylon::GLsizei height, Babylon::GLenum format,
								 Babylon::GLsizeiptr sizeiptr) { 
									 glCompressedTexSubImage2D(target, level, xoffset, yoffset, width, height, format, sizeiptr >> 32, (const ::GLint*) (sizeiptr & 0x0000ffff));
									 errorCheck();
}

void GL::copyTexImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLenum internalformat, 
						Babylon::GLint x, Babylon::GLint y, Babylon::GLsizei width, Babylon::GLsizei height, 
						Babylon::GLint border) { 
							glCopyTexImage2D(target, level, internalformat, x, y, width, height, border);
							errorCheck();
}

void GL::copyTexSubImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLint xoffset, Babylon::GLint yoffset, 
						   Babylon::GLint x, Babylon::GLint y, Babylon::GLsizei width, Babylon::GLsizei height) { 
							   glCopyTexSubImage2D(target, level, xoffset, yoffset, x, y, width, height);
							   errorCheck();
}

Babylon::IGLBuffer::Ptr GL::createBuffer() { 
	::GLuint val;
	glGenBuffers(1, &val);
	return make_shared<Babylon::IGLBuffer>(val);
}

Babylon::IGLFramebuffer::Ptr GL::createFramebuffer() { 
	::GLuint val;
	glGenFramebuffersEXT(1, &val);
	return make_shared<Babylon::IGLFramebuffer>(val);
}

Babylon::IGLProgram::Ptr GL::createProgram() { 
	return make_shared<Babylon::IGLProgram>(glCreateProgram());
}

Babylon::IGLRenderbuffer::Ptr GL::createRenderbuffer() { 
	::GLuint val;
	glGenRenderbuffersEXT(1, &val);
	return make_shared<Babylon::IGLRenderbuffer>(val);
}

Babylon::IGLShader::Ptr GL::createShader(Babylon::GLenum type) { 
	return make_shared<Babylon::IGLShader>(glCreateShader(type));
}

Babylon::IGLTexture::Ptr GL::createTexture() { 
	::GLuint val;
	glGenTextures(1, &val);
	return make_shared<Babylon::IGLTexture>(val);
}

void GL::cullFace(Babylon::GLenum mode) { 
	glCullFace(mode);
	errorCheck();
}

void GL::deleteBuffer(Babylon::IGLBuffer::Ptr buffer) { 
	glDeleteBuffers(1, (const ::GLuint*) &buffer->value);
	errorCheck();
}

void GL::deleteFramebuffer(Babylon::IGLFramebuffer::Ptr framebuffer) { 
	glDeleteFramebuffersEXT(1, (const ::GLuint*) &framebuffer->value);
	errorCheck();
}

void GL::deleteProgram(Babylon::IGLProgram::Ptr program) { 
	glDeleteProgram(program->value);
	errorCheck();
}

void GL::deleteRenderbuffer(Babylon::IGLRenderbuffer::Ptr renderbuffer) { 
	glDeleteRenderbuffersEXT(1, (const ::GLuint*) &renderbuffer->value);
	errorCheck();
}

void GL::deleteShader(Babylon::IGLShader::Ptr shader) { 
	glDeleteShader(shader->value);
	errorCheck();
}

void GL::deleteTexture(Babylon::IGLTexture::Ptr texture) { 
	glDeleteTextures(1, (const ::GLuint*) &texture->value);
	errorCheck();
}

void GL::depthFunc(Babylon::GLenum func) { 
	glDepthFunc(func);
	errorCheck();
}

void GL::depthMask(Babylon::GLboolean flag) { 
	glDepthMask(flag);
	errorCheck();
}

void GL::depthRange(Babylon::GLclampf zNear, Babylon::GLclampf zFar) { 
	glDepthRange(zNear, zFar);
	errorCheck();
}

void GL::detachShader(Babylon::IGLProgram::Ptr program, Babylon::IGLShader::Ptr shader) { 
	glDetachShader(program->value, shader->value);
	errorCheck();
}

void GL::disable(Babylon::GLenum cap) { 
	glDisable(cap);
}

void GL::disableVertexAttribArray(Babylon::GLuint index) { 
	glDisableVertexAttribArray(index);
	errorCheck();
}

void GL::drawArrays(Babylon::GLenum mode, Babylon::GLint first, Babylon::GLsizei count) { 
	glDrawArrays(mode, first, count);
	errorCheck();
}

void GL::drawElements(Babylon::GLenum mode, Babylon::GLsizei count, Babylon::GLenum type, Babylon::GLintptr offset) { 
	glDrawElements(mode, count, type, (Babylon::any)offset);
	errorCheck();
}

void GL::enable(Babylon::GLenum cap) { 
	glEnable(cap);
}

void GL::enableVertexAttribArray(Babylon::GLuint index) { 
	glEnableVertexAttribArray(index);
	errorCheck();
}

void GL::finish() { 
	glFinish();
}

void GL::flush() { 
	glFlush();
}

void GL::framebufferRenderbuffer(Babylon::GLenum target, Babylon::GLenum attachment, 
								 Babylon::GLenum renderbuffertarget, 
								 Babylon::IGLRenderbuffer::Ptr renderbuffer) { 
									 glFramebufferRenderbufferEXT(target, attachment, renderbuffertarget, renderbuffer->value);
									 errorCheck();
}

void GL::framebufferTexture2D(Babylon::GLenum target, Babylon::GLenum attachment, Babylon::GLenum textarget, 
							  Babylon::IGLTexture::Ptr texture, Babylon::GLint level) { 
								  glFramebufferTexture2DEXT(target, attachment, textarget, texture->value, level);
								  errorCheck();
}

void GL::frontFace(Babylon::GLenum mode) { 
	glFrontFace(mode);
	errorCheck();
}

void GL::generateMipmap(Babylon::GLenum target) { 
	glGenerateMipmapEXT(target);
	errorCheck();
}

Babylon::IGLActiveInfo::Ptr GL::getActiveAttrib(Babylon::IGLProgram::Ptr program, Babylon::GLuint index) { 
	////return make_shared<Babylon::IGLActiveInfo>(glGetActiveAttrib(program->value, index));
	throw "not supported";
}

Babylon::IGLActiveInfo::Ptr GL::getActiveUniform(Babylon::IGLProgram::Ptr program, Babylon::GLuint index) { 
	////return make_shared<Babylon::IGLActiveInfo>(glGetActiveUniform(program->value, index));
	throw "not supported";
}

vector<Babylon::IGLShader::Ptr> GL::getAttachedShaders(Babylon::IGLProgram::Ptr program) { 
	////return make_shared<Babylon::IGLShader>(glGetAttachedShaders(program->value));
	throw "not supported";
}

Babylon::GLint GL::getAttribLocation(Babylon::IGLProgram::Ptr program, string name) { 
	return glGetAttribLocation(program->value, name.c_str());
}

Babylon::any GL::getBufferParameter(Babylon::GLenum target, Babylon::GLenum pname) { 
	////return (Babylon::any) glGetBufferParameteriv(target, pname);
	throw "not supported";
}

Babylon::any GL::getParameter(Babylon::GLenum pname) { 
	::GLint params;
	glGetIntegerv(pname, &params);
	return (Babylon::any)params;
}

Babylon::GLenum GL::getError() { 
	return glGetError();
}

Babylon::any GL::getFramebufferAttachmentParameter(Babylon::GLenum target, Babylon::GLenum attachment, 
												   Babylon::GLenum pname) {
													   //return (Babylon::any) glGetFramebufferAttachmentParameterivEXT(target, attachment, pname);
													   throw "not supported";
}

Babylon::any GL::getProgramParameter(Babylon::IGLProgram::Ptr program, Babylon::GLenum pname) { 
	////return (Babylon::any)glGetProgramParameterdvNV(program->value, pname);
	throw "not supported";
}

string GL::getProgramInfoLog(Babylon::IGLProgram::Ptr program) { 
	//return glGetProgramInfoLog(program->value);
	::GLint k = -1;
	glGetProgramiv(program->value, GL_INFO_LOG_LENGTH, &k);
	if (k == -1) {
		// XXX GL Error? should never happen.
		return "";
	}

	if (k == 0) {
		return "";
	}

	string result;
	result.reserve(k + 1);
	glGetProgramInfoLog(program->value, k, &k, (char *) result.c_str());
	return result;
}

Babylon::any GL::getRenderbufferParameter(Babylon::GLenum target, Babylon::GLenum pname) { 
	::GLint params;
	glGetRenderbufferParameterivEXT(target, pname, &params);
	return &params;
}

Babylon::any GL::getShaderParameter(Babylon::IGLShader::Ptr shader, Babylon::GLenum pname) { 
	switch (pname) {
	case Babylon::SHADER_TYPE:
		{
			::GLint i = 0;
			glGetShaderiv(shader->value, GL_SHADER_TYPE, &i);
			return (Babylon::any) i;
		}
		break;
	case Babylon::COMPILE_STATUS:
		{
			::GLint i = 0;
			glGetShaderiv(shader->value, GL_COMPILE_STATUS, &i);
			return (Babylon::any) i;
		}
		break;
	default:
		throw "not supported getShaderParameter: parameter" + pname;
	}

}

Babylon::IGLShaderPrecisionFormat::Ptr GL::getShaderPrecisionFormat(Babylon::GLenum shadertype, Babylon::GLenum precisiontype) { 
	throw "not supported";
}

string GL::getShaderInfoLog(Babylon::IGLShader::Ptr shader) { 
	//return glGetShaderInfoLog(shader->value);
	::GLint k = -1;
	glGetShaderiv(shader->value, GL_INFO_LOG_LENGTH, &k);
	if (k == -1) {
		// XXX GL Error? should never happen.
		return "";
	}

	if (k == 0) {
		return "";
	}

	string result;
	result.reserve(k + 1);
	glGetShaderInfoLog(shader->value, k, &k, (char *) result.c_str());
	return result;
}

string GL::getShaderSource(Babylon::IGLShader::Ptr shader) { 
	//return glGetShaderSource(shader->value);
	throw "not supported";
}

Babylon::any GL::getTexParameter(Babylon::GLenum target, Babylon::GLenum pname) { 
	////return (Babylon::any) glGetTexParameterfv(target, pname);
	throw "not supported";
}

Babylon::any GL::getUniform(Babylon::IGLProgram::Ptr program, Babylon::IGLUniformLocation::Ptr location) { 
	////return (Babylon::any) glGetUniformfv(program->value, location->value);
	throw "not supported";
}

Babylon::IGLUniformLocation::Ptr GL::getUniformLocation(Babylon::IGLProgram::Ptr program, string name) { 
	auto value = glGetUniformLocation(program->value, name.c_str());
	if (value != -1)
	{
		return make_shared<Babylon::IGLUniformLocation>(value);
	}

	return nullptr;
}

Babylon::any GL::getVertexAttrib(Babylon::GLuint index, Babylon::GLenum pname) { 
	////return (Babylon::any) glGetVertexAttribdv(index, pname);
	throw "not supported";
}

Babylon::GLsizeiptr GL::getVertexAttribOffset(Babylon::GLuint index, Babylon::GLenum pname) { 
	throw "not supported";
}

void GL::hint(Babylon::GLenum target, Babylon::GLenum mode) { 
	glHint(target, mode);
	errorCheck();
}

Babylon::GLboolean GL::isBuffer(Babylon::IGLBuffer::Ptr buffer) { 
	return glIsBuffer(buffer->value) == GL_TRUE;
}

Babylon::GLboolean GL::isEnabled(Babylon::GLenum cap) { 
	return glIsEnabled(cap) == GL_TRUE;
}

Babylon::GLboolean GL::isFramebuffer(Babylon::IGLFramebuffer::Ptr framebuffer) { 
	return glIsFramebufferEXT(framebuffer->value) == GL_TRUE;
}

Babylon::GLboolean GL::isProgram(Babylon::IGLProgram::Ptr program) { 
	return glIsProgram(program->value) == GL_TRUE;
}

Babylon::GLboolean GL::isRenderbuffer(Babylon::IGLRenderbuffer::Ptr renderbuffer) { 
	return glIsRenderbufferEXT(renderbuffer->value) == GL_TRUE;
}

Babylon::GLboolean GL::isShader(Babylon::IGLShader::Ptr shader) { 
	return glIsShader(shader->value) == GL_TRUE;
}

Babylon::GLboolean GL::isTexture(Babylon::IGLTexture::Ptr texture) { 
	return glIsTexture(texture->value) == GL_TRUE;
}

void GL::lineWidth(Babylon::GLfloat width) { 
	glLineWidth(width);
	errorCheck();
}

bool GL::linkProgram(Babylon::IGLProgram::Ptr program) { 
	glLinkProgram(program->value);

	// Test linker result.
	::GLint linkSucceed = GL_FALSE;
	glGetProgramiv(program->value, GL_LINK_STATUS, &linkSucceed);

	return linkSucceed != GL_FALSE;
}

void GL::pixelStorei(Babylon::GLenum pname, Babylon::GLint param) { 
	glPixelStorei(pname, param);
	errorCheck();
}

void GL::polygonOffset(Babylon::GLfloat factor, Babylon::GLfloat units) { 
	glPolygonOffset(factor, units);
	errorCheck();
}

void GL::readPixels(Babylon::GLint x, Babylon::GLint y, Babylon::GLsizei width, Babylon::GLsizei height, Babylon::GLenum format, Babylon::GLenum type, Babylon::any pixels) { 
	glReadPixels(x, y, width, height, format, type, pixels);
	errorCheck();
}

void GL::renderbufferStorage(Babylon::GLenum target, Babylon::GLenum internalformat, Babylon::GLsizei width, Babylon::GLsizei height) { 
	glRenderbufferStorageEXT(target, internalformat, width, height);
	errorCheck();
}

void GL::sampleCoverage(Babylon::GLclampf value, Babylon::GLboolean invert) { 
	glSampleCoverage(value, invert);
	errorCheck();
}

void GL::scissor(Babylon::GLint x, Babylon::GLint y, Babylon::GLsizei width, Babylon::GLsizei height) { 
	glScissor(x, y, width, height);
	errorCheck();
}

void GL::shaderSource(Babylon::IGLShader::Ptr shader, string source) { 
	::GLint length = source.length();
	const ::GLchar* line = (::GLchar*) source.c_str();
	glShaderSource(shader->value, 1, &line, &length);
	errorCheck();
}

void GL::stencilFunc(Babylon::GLenum func, Babylon::GLint ref, Babylon::GLuint mask) { 
	glStencilFunc(func, ref, mask);
	errorCheck();
}

void GL::stencilFuncSeparate(Babylon::GLenum face, Babylon::GLenum func, Babylon::GLint ref, Babylon::GLuint mask) { 
	glStencilFuncSeparate(face, func, ref, mask);
	errorCheck();
}

void GL::stencilMask(Babylon::GLuint mask) { 
	glStencilMask(mask);
	errorCheck();
}

void GL::stencilMaskSeparate(Babylon::GLenum face, Babylon::GLuint mask) { 
	glStencilMaskSeparate(face, mask);
	errorCheck();
}

void GL::stencilOp(Babylon::GLenum fail, Babylon::GLenum zfail, Babylon::GLenum zpass) { 
	glStencilOp(fail, zfail, zpass);
	errorCheck();
}

void GL::stencilOpSeparate(Babylon::GLenum face, Babylon::GLenum fail, Babylon::GLenum zfail, Babylon::GLenum zpass) { 
	glStencilOpSeparate(face, fail, zfail, zpass);
	errorCheck();
}

void GL::texImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLenum internalformat, 
					Babylon::GLsizei width, Babylon::GLsizei height, Babylon::GLint border, Babylon::GLenum format, 
					Babylon::GLenum type, Babylon::any pixels) { 
						glTexImage2D(target, level, internalformat, width, height, border, format, type, pixels);
}

void GL::texImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLenum internalformat,
					Babylon::GLenum format, Babylon::GLenum type, Babylon::any pixels) { 
						////glTexImage2D(target, level, internalformat, format, type, pixels);
						throw "not supported";
}

void GL::texImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLenum internalformat,
					Babylon::GLenum format, Babylon::GLenum type, Babylon::IImage::Ptr image) { 
						////glTexImage2D(target, level, internalformat, format, type, image);
						throw "not supported";
}
// May throw DOMException
void GL::texImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLenum internalformat,
					Babylon::GLenum format, Babylon::GLenum type, Babylon::ICanvas::Ptr canvas) { 
						////glTexImage2D(target, level, internalformat, format, type, canvas);
						throw "not supported";
}
// May throw DOMException
void GL::texImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLenum internalformat,
					Babylon::GLenum format, Babylon::GLenum type, Babylon::IVideo::Ptr video) { 
						throw "not supported";
}
// May throw DOMException

void GL::texParameterf(Babylon::GLenum target, Babylon::GLenum pname, Babylon::GLfloat param) { 
	glTexParameterf(target, pname, param);
	errorCheck();
}

void GL::texParameteri(Babylon::GLenum target, Babylon::GLenum pname, Babylon::GLint param) { 
	glTexParameteri(target, pname, param);
	errorCheck();
}

void GL::texSubImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLint xoffset, Babylon::GLint yoffset, 
					   Babylon::GLsizei width, Babylon::GLsizei height, 
					   Babylon::GLenum format, Babylon::GLenum type, Babylon::any pixels) { 
						   glTexSubImage2D(target, level, xoffset, yoffset, width, height, format, type, pixels);
						   errorCheck();
}

void GL::texSubImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLint xoffset, Babylon::GLint yoffset, 
					   Babylon::GLenum format, Babylon::GLenum type, Babylon::any pixels) { 
						   ////glTexSubImage2D(target, level, xoffset, yoffset, format, type, pixels);
						   throw "not supported";
}

void GL::texSubImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLint xoffset, Babylon::GLint yoffset, 
					   Babylon::GLenum format, Babylon::GLenum type, Babylon::ICanvas::Ptr canvas) { 
						   ////glTexSubImage2D(target, level, xoffset, yoffset, format, type, canvas);
						   throw "not supported";
}

void GL::uniform1f(Babylon::IGLUniformLocation::Ptr location, Babylon::GLfloat x) { 
	glUniform1f(location->value, x);
	errorCheck();
}

void GL::uniform1fv(Babylon::IGLUniformLocation::Ptr location, Babylon::Float32Array& v) { 
	glUniform1fv(location->value,v.size() * sizeof(Babylon::GLfloat), v.data());
	errorCheck();
}

void GL::uniform1i(Babylon::IGLUniformLocation::Ptr location, Babylon::GLint x) { 
	glUniform1i(location->value, x);
	errorCheck();
}

void GL::uniform1iv(Babylon::IGLUniformLocation::Ptr location, Babylon::Int32Array& v) {
	glUniform1iv(location->value, v.size() * sizeof(int32_t), v.data());
	errorCheck();
}

void GL::uniform2f(Babylon::IGLUniformLocation::Ptr location, Babylon::GLfloat x, Babylon::GLfloat y) { 
	glUniform2f(location->value, x, y);
	errorCheck();
}

void GL::uniform2fv(Babylon::IGLUniformLocation::Ptr location, Babylon::Float32Array& v) { 
	glUniform2fv(location->value, v.size() * sizeof(Babylon::GLfloat), v.data());
	errorCheck();
}

void GL::uniform2i(Babylon::IGLUniformLocation::Ptr location, Babylon::GLint x, Babylon::GLint y) { 
	glUniform2i(location->value, x, y);
	errorCheck();
}

void GL::uniform2iv(Babylon::IGLUniformLocation::Ptr location, Babylon::Int32Array& v) { 
	glUniform2iv(location->value, v.size() * sizeof(int32_t), v.data());
	errorCheck();
}

void GL::uniform3f(Babylon::IGLUniformLocation::Ptr location, Babylon::GLfloat x, Babylon::GLfloat y, Babylon::GLfloat z) { 
	glUniform3f(location->value, x, y, z);
	errorCheck();
}

void GL::uniform3fv(Babylon::IGLUniformLocation::Ptr location, Babylon::Float32Array& v) { 
	glUniform3fv(location->value, v.size() * sizeof(Babylon::GLfloat), v.data());
	errorCheck();
}

void GL::uniform3i(Babylon::IGLUniformLocation::Ptr location, Babylon::GLint x, Babylon::GLint y, Babylon::GLint z) { 
	glUniform3i(location->value, x, y, z);
	errorCheck();
}

void GL::uniform3iv(Babylon::IGLUniformLocation::Ptr location, Babylon::Int32Array& v) { 
	glUniform3iv(location->value, v.size() * sizeof(int32_t), v.data());
	errorCheck();
}

void GL::uniform4f(Babylon::IGLUniformLocation::Ptr location, Babylon::GLfloat x, Babylon::GLfloat y, Babylon::GLfloat z, Babylon::GLfloat w) {
	glUniform4f(location->value, x, y, z, w);
	errorCheck();
}

void GL::uniform4fv(Babylon::IGLUniformLocation::Ptr location, Babylon::Float32Array& v) { 
	glUniform4fv(location->value, v.size() * sizeof(Babylon::GLfloat), v.data());
	errorCheck();
}

void GL::uniform4i(Babylon::IGLUniformLocation::Ptr location, Babylon::GLint x, Babylon::GLint y, Babylon::GLint z, Babylon::GLint w) { 
	glUniform4i(location->value, x, y, z, w);
	errorCheck();
}

void GL::uniform4iv(Babylon::IGLUniformLocation::Ptr location, Babylon::Int32Array& v) { 
	glUniform4iv(location->value, v.size() * sizeof(int32_t), v.data());
	errorCheck();
}

void GL::uniformMatrix2fv(Babylon::IGLUniformLocation::Ptr location, Babylon::GLboolean transpose, Babylon::Float32Array& value) { 
	glUniformMatrix2fv(location->value, value.size() / 16, transpose, value.data());
	errorCheck();
}

void GL::uniformMatrix3fv(Babylon::IGLUniformLocation::Ptr location, Babylon::GLboolean transpose, Babylon::Float32Array& value) { 
	glUniformMatrix3fv(location->value, value.size() / 16, transpose, value.data());
	errorCheck();
}

void GL::uniformMatrix4fv(Babylon::IGLUniformLocation::Ptr location, Babylon::GLboolean transpose, Babylon::Float32Array& value) {
	glUniformMatrix4fv(location->value, value.size() / 16, transpose, value.data());
	errorCheck();
}

void GL::useProgram(Babylon::IGLProgram::Ptr program) {
	glUseProgram(program->value);
	errorCheck();
}

void GL::validateProgram(Babylon::IGLProgram::Ptr program) {
	glValidateProgram(program->value);
	errorCheck();
}

void GL::vertexAttrib1f(Babylon::GLuint indx, Babylon::GLfloat x) {
	glVertexAttrib1f(indx, x);
	errorCheck();
}

void GL::vertexAttrib1fv(Babylon::GLuint indx, Babylon::Float32Array& values) { 
	glVertexAttrib1fv(indx, values.data());
	errorCheck();
}

void GL::vertexAttrib2f(Babylon::GLuint indx, Babylon::GLfloat x, Babylon::GLfloat y) { 
	glVertexAttrib2f(indx, x, y);
	errorCheck();
}

void GL::vertexAttrib2fv(Babylon::GLuint indx, Babylon::Float32Array& values) { 
	glVertexAttrib2fv(indx, values.data());
	errorCheck();
}

void GL::vertexAttrib3f(Babylon::GLuint indx, Babylon::GLfloat x, Babylon::GLfloat y, Babylon::GLfloat z) { 
	glVertexAttrib3f(indx, x, y, z);
	errorCheck();
}

void GL::vertexAttrib3fv(Babylon::GLuint indx, Babylon::Float32Array& values) { 
	glVertexAttrib3fv(indx, values.data());
	errorCheck();
}

void GL::vertexAttrib4f(Babylon::GLuint indx, Babylon::GLfloat x, Babylon::GLfloat y, Babylon::GLfloat z, Babylon::GLfloat w) { 
	glVertexAttrib4f(indx, x, y, z, w);
	errorCheck();
}

void GL::vertexAttrib4fv(Babylon::GLuint indx, Babylon::Float32Array& values) {
	glVertexAttrib4fv(indx, values.data());
	errorCheck();
}

void GL::vertexAttribPointer(Babylon::GLuint indx, Babylon::GLint size, Babylon::GLenum type, 
							 Babylon::GLboolean normalized, Babylon::GLsizei stride, Babylon::GLintptr offset) { 
								 glVertexAttribPointer(indx, size, type, normalized, stride, (Babylon::any)offset);
								 errorCheck();
}

void GL::viewport(Babylon::GLint x, Babylon::GLint y, Babylon::GLsizei width, Babylon::GLsizei height) { 
	glViewport(x, y, width, height);
}

void GL::errorCheck() {
	::GLenum error = GL_NO_ERROR;
	error = glGetError();
	if (GL_NO_ERROR != error) {
		switch (error)
		{
		case GL_INVALID_ENUM:
			throw runtime_error("GL error: enumeration parameter is not a legal enumeration for that function");
		case GL_INVALID_VALUE:
			throw runtime_error("GL error: value parameter is not a legal value for that function");
		case GL_INVALID_OPERATION:
			throw runtime_error("GL error: the set of state for a command is not legal for the parameters given to that command");
		case GL_STACK_OVERFLOW:
			throw runtime_error("GL error: stack pushing operation cannot be done because it would overflow the limit of that stack's size");
		case GL_STACK_UNDERFLOW:
			throw runtime_error("GL error: stack popping operation cannot be done because the stack is already at its lowest point");
		case GL_OUT_OF_MEMORY:
			throw runtime_error("GL error: performing an operation that can allocate memory, and the memory cannot be allocated");
		case GL_INVALID_FRAMEBUFFER_OPERATION_EXT:
			throw runtime_error("GL error: doing anything that would attempt to read from or write/render to a framebuffer that is not complete");
		case GL_TABLE_TOO_LARGE:
			throw runtime_error("GL error: Table is too large");
		}
	}
}