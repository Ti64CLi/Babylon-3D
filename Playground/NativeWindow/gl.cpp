#include "gl.h"
#include <memory>

#include <GL/glew.h>
#include <GL/glut.h>

using namespace Babylon;

GL::GL(Babylon::ICanvas::Ptr canvas, bool antialias) {
	this->canvas = canvas;
	this->antialias = antialias;
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

Babylon::GLenum GL::getEnumByName (string name) { 
	throw "not supported";
}

Babylon::GLenum GL::getEnumByNameIndex (string name, int index) { 
	throw "not supported";
}

void GL::activeTexture(Babylon::GLenum texture) { 
	glActiveTexture(texture);
}

void GL::attachShader(Babylon::IGLProgram::Ptr program, Babylon::IGLShader::Ptr shader) { 
	glAttachShader(program->value, shader->value);
}

void GL::bindAttribLocation(Babylon::IGLProgram::Ptr program, Babylon::GLuint index, string name) { 
	glBindAttribLocation(program->value, index, name.c_str());
}

void GL::bindBuffer(Babylon::GLenum target, Babylon::IGLBuffer::Ptr buffer) { 
	glBindBuffer(target, buffer->value);
}

void GL::bindFramebuffer(Babylon::GLenum target, Babylon::IGLFramebuffer::Ptr framebuffer) { 
	glBindFramebufferEXT(target, framebuffer->value);
}

void GL::bindRenderbuffer(Babylon::GLenum target, Babylon::IGLRenderbuffer::Ptr renderbuffer) { 
	glBindRenderbufferEXT(target, renderbuffer->value);
}

void GL::bindTexture(Babylon::GLenum target, Babylon::IGLTexture::Ptr texture) { 
	glBindTextureEXT(target, texture->value);
}

void GL::blendColor(Babylon::GLclampf red, Babylon::GLclampf green, Babylon::GLclampf blue, Babylon::GLclampf alpha) { 
	glBlendColor(red, green, blue, alpha);
}

void GL::blendEquation(Babylon::GLenum mode) { 
	glBlendEquation(mode);
}

void GL::blendEquationSeparate(Babylon::GLenum modeRGB, Babylon::GLenum modeAlpha) { 
	glBlendEquationSeparate(modeRGB, modeAlpha);
}

void GL::blendFunc(Babylon::GLenum sfactor, Babylon::GLenum dfactor) { 
	glBlendFunc(sfactor, dfactor);
}

void GL::blendFuncSeparate(Babylon::GLenum srcRGB, Babylon::GLenum dstRGB, 
						   Babylon::GLenum srcAlpha, Babylon::GLenum dstAlpha) { 
	glBlendFuncSeparateEXT(srcRGB, dstRGB, srcAlpha, dstAlpha);
}

void GL::bufferData(Babylon::GLenum target, Babylon::GLsizeiptr sizeiptr, Babylon::GLenum usage) { 
	glBufferData(target, sizeiptr >> 32, (Babylon::any)(sizeiptr & 0x0000ffff), usage);
}

void GL::bufferData(Babylon::GLenum target, Babylon::Float32Array data, Babylon::GLenum usage) { 
	glBufferData(target, data.size() * sizeof(Babylon::GLfloat), data.data(), usage);
}

void GL::bufferData(Babylon::GLenum target, Babylon::Int32Array data, Babylon::GLenum usage) { 
	glBufferData(target, data.size() * sizeof(int32_t), data.data(), usage);
}

void GL::bufferData(Babylon::GLenum target, Babylon::Uint16Array data, Babylon::GLenum usage) { 
	glBufferData(target, data.size() * sizeof(char16_t), data.data(), usage);
}

void GL::bufferSubData(Babylon::GLenum target, Babylon::GLintptr offset, Babylon::Float32Array data) { 
	glBufferSubData(target, offset, data.size() * sizeof(Babylon::GLfloat), data.data());
}

void GL::bufferSubData(Babylon::GLenum target, Babylon::GLintptr offset, Babylon::Int32Array data) { 
	glBufferSubData(target, offset, data.size() * sizeof(int32_t), data.data());
}

Babylon::GLenum checkFramebufferStatus(Babylon::GLenum target) { 
	return glCheckFramebufferStatusEXT(target);
}

void GL::clear(Babylon::GLbitfield mask) { 
	glClear(mask);
}

void GL::clearColor(Babylon::GLclampf red, Babylon::GLclampf green, Babylon::GLclampf blue, Babylon::GLclampf alpha) { 
	glClearColor(red, green, blue, alpha);
}

void GL::clearDepth(Babylon::GLclampf depth) { 
	glClearDepth(depth);
}

void GL::clearStencil(Babylon::GLint s) { 
	glClearStencil(s);
}

void GL::colorMask(Babylon::GLboolean red, Babylon::GLboolean green, Babylon::GLboolean blue, Babylon::GLboolean alpha) { 
	glColorMask(red, green, blue, alpha);
}

void GL::compileShader(Babylon::IGLShader::Ptr shader) { 
	glCompileShader(shader->value);
}

void GL::compressedTexSubImage2D(Babylon::GLenum target, Babylon::GLint level,
								 Babylon::GLint xoffset, Babylon::GLint yoffset,
								 Babylon::GLsizei width, Babylon::GLsizei height, Babylon::GLenum format,
								 Babylon::GLsizeiptr sizeiptr) { 
	glCompressedTexSubImage2D(target, level, xoffset, yoffset, width, height, format, sizeiptr >> 32, (const ::GLint*) (sizeiptr & 0x0000ffff));
}

void GL::copyTexImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLenum internalformat, 
						Babylon::GLint x, Babylon::GLint y, Babylon::GLsizei width, Babylon::GLsizei height, 
						Babylon::GLint border) { 
	glCopyTexImage2D(target, level, internalformat, x, y, width, height, border);
}

void GL::copyTexSubImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLint xoffset, Babylon::GLint yoffset, 
						   Babylon::GLint x, Babylon::GLint y, Babylon::GLsizei width, Babylon::GLsizei height) { 
	glCopyTexSubImage2D(target, level, xoffset, yoffset, x, y, width, height);
}

Babylon::IGLBuffer::Ptr createBuffer() { 
	::GLuint val;
	glGenBuffers(1, &val);
	return make_shared<IGLBuffer>(val);
}

Babylon::IGLFramebuffer::Ptr createFramebuffer() { 
	::GLuint val;
	glGenFramebuffersEXT(1, &val);
	return make_shared<IGLFramebuffer>(val);
}

Babylon::IGLProgram::Ptr createProgram() { 
	return make_shared<IGLProgram>(glCreateProgram());
}

Babylon::IGLRenderbuffer::Ptr createRenderbuffer() { 
	::GLuint val;
	glGenRenderbuffersEXT(1, &val);
	return make_shared<IGLRenderbuffer>(val);
}

Babylon::IGLShader::Ptr createShader(Babylon::GLenum type) { 
	return make_shared<IGLShader>(glCreateShader(type));
}

Babylon::IGLTexture::Ptr createTexture() { 
	::GLuint val;
	glGenTextures(1, &val);
	return make_shared<IGLTexture>(val);
}

void GL::cullFace(Babylon::GLenum mode) { 
	glCullFace(mode);
}

void GL::deleteBuffer(Babylon::IGLBuffer::Ptr buffer) { 
	glDeleteBuffers(1, (const ::GLuint*) &buffer->value);
}

void GL::deleteFramebuffer(Babylon::IGLFramebuffer::Ptr framebuffer) { 
	glDeleteFramebuffersEXT(1, (const ::GLuint*) &framebuffer->value);
}

void GL::deleteProgram(Babylon::IGLProgram::Ptr program) { 
	glDeleteProgram(program->value);
}

void GL::deleteRenderbuffer(Babylon::IGLRenderbuffer::Ptr renderbuffer) { 
	glDeleteRenderbuffersEXT(1, (const ::GLuint*) &renderbuffer->value);
}

void GL::deleteShader(Babylon::IGLShader::Ptr shader) { 
	glDeleteShader(shader->value);
}

void GL::deleteTexture(Babylon::IGLTexture::Ptr texture) { 
	glDeleteTextures(1, (const ::GLuint*) &texture->value);
}

void GL::depthFunc(Babylon::GLenum func) { 
	glDepthFunc(func);
}

void GL::depthMask(Babylon::GLboolean flag) { 
	glDepthMask(flag);
}

void GL::depthRange(Babylon::GLclampf zNear, Babylon::GLclampf zFar) { 
	glDepthRange(zNear, zFar);
}

void GL::detachShader(Babylon::IGLProgram::Ptr program, Babylon::IGLShader::Ptr shader) { 
	glDetachShader(program->value, shader->value);
}

void GL::disable(Babylon::GLenum cap) { 
	glDisable(cap);
}

void GL::disableVertexAttribArray(Babylon::GLuint index) { 
	glDisableVertexAttribArray(index);
}

void GL::drawArrays(Babylon::GLenum mode, Babylon::GLint first, Babylon::GLsizei count) { 
	glDrawArrays(mode, first, count);
}

void GL::drawElements(Babylon::GLenum mode, Babylon::GLsizei count, Babylon::GLenum type, Babylon::GLintptr offset) { 
	glDrawElements(mode, count, type, (Babylon::any)offset);
}

void GL::enable(Babylon::GLenum cap) { 
	glEnable(cap);
}

void GL::enableVertexAttribArray(Babylon::GLuint index) { 
	glEnableVertexAttribArray(index);
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
}

void GL::framebufferTexture2D(Babylon::GLenum target, Babylon::GLenum attachment, Babylon::GLenum textarget, 
							  Babylon::IGLTexture::Ptr texture, Babylon::GLint level) { 
	glFramebufferTexture2DEXT(target, attachment, textarget, texture->value, level);
}

void GL::frontFace(Babylon::GLenum mode) { 
	glFrontFace(mode);
}

void GL::generateMipmap(Babylon::GLenum target) { 
	glGenerateMipmapEXT(target);
}

Babylon::IGLActiveInfo::Ptr getActiveAttrib(Babylon::IGLProgram::Ptr program, Babylon::GLuint index) { 
	////return make_shared<IGLActiveInfo>(glGetActiveAttrib(program->value, index));
	throw "not supported";
}

Babylon::IGLActiveInfo::Ptr getActiveUniform(Babylon::IGLProgram::Ptr program, Babylon::GLuint index) { 
	////return make_shared<IGLActiveInfo>(glGetActiveUniform(program->value, index));
	throw "not supported";
}

vector<Babylon::IGLShader::Ptr> getAttachedShaders(Babylon::IGLProgram::Ptr program) { 
	////return make_shared<IGLShader>(glGetAttachedShaders(program->value));
	throw "not supported";
}

Babylon::GLint getAttribLocation(Babylon::IGLProgram::Ptr program, string name) { 
	return glGetAttribLocation(program->value, name.c_str());
}

Babylon::any getBufferParameter(Babylon::GLenum target, Babylon::GLenum pname) { 
	////return (Babylon::any) glGetBufferParameteriv(target, pname);
	throw "not supported";
}

Babylon::any getParameter(Babylon::GLenum pname) { 
	throw "not supported";
}

Babylon::GLenum getError() { 
	return glGetError();
}

Babylon::any getFramebufferAttachmentParameter(Babylon::GLenum target, Babylon::GLenum attachment, 
											   Babylon::GLenum pname) {
	//return (Babylon::any) glGetFramebufferAttachmentParameterivEXT(target, attachment, pname);
	throw "not supported";
}

Babylon::any getProgramParameter(Babylon::IGLProgram::Ptr program, Babylon::GLenum pname) { 
	////return (Babylon::any)glGetProgramParameterdvNV(program->value, pname);
	throw "not supported";
}

string getProgramInfoLog(Babylon::IGLProgram::Ptr program) { 
	//return glGetProgramInfoLog(program->value);
	throw "not supported";
}

Babylon::any getRenderbufferParameter(Babylon::GLenum target, Babylon::GLenum pname) { 
	::GLint params;
	glGetRenderbufferParameterivEXT(target, pname, &params);
	return &params;
}

Babylon::any getShaderParameter(Babylon::IGLShader::Ptr shader, Babylon::GLenum pname) { 
	throw "not supported";
}

Babylon::IGLShaderPrecisionFormat::Ptr getShaderPrecisionFormat(Babylon::GLenum shadertype, Babylon::GLenum precisiontype) { 
	throw "not supported";
}

string getShaderInfoLog(Babylon::IGLShader::Ptr shader) { 
	//return glGetShaderInfoLog(shader->value);
	throw "not supported";
}

string getShaderSource(Babylon::IGLShader::Ptr shader) { 
	//return glGetShaderSource(shader->value);
	throw "not supported";
}

Babylon::any getTexParameter(Babylon::GLenum target, Babylon::GLenum pname) { 
	////return (Babylon::any) glGetTexParameterfv(target, pname);
	throw "not supported";
}

Babylon::any getUniform(Babylon::IGLProgram::Ptr program, Babylon::IGLUniformLocation::Ptr location) { 
	////return (Babylon::any) glGetUniformfv(program->value, location->value);
	throw "not supported";
}

Babylon::IGLUniformLocation::Ptr getUniformLocation(Babylon::IGLProgram::Ptr program, string name) { 
	return make_shared<IGLUniformLocation>(glGetUniformLocation(program->value, name.c_str()));
}

Babylon::any getVertexAttrib(Babylon::GLuint index, Babylon::GLenum pname) { 
	////return (Babylon::any) glGetVertexAttribdv(index, pname);
	throw "not supported";
}

Babylon::GLsizeiptr getVertexAttribOffset(Babylon::GLuint index, Babylon::GLenum pname) { 
	throw "not supported";
}

void GL::hint(Babylon::GLenum target, Babylon::GLenum mode) { 
	glHint(target, mode);
}

Babylon::GLboolean isBuffer(Babylon::IGLBuffer::Ptr buffer) { 
	return glIsBuffer(buffer->value);
}

Babylon::GLboolean isEnabled(Babylon::GLenum cap) { 
	return glIsEnabled(cap);
}

Babylon::GLboolean isFramebuffer(Babylon::IGLFramebuffer::Ptr framebuffer) { 
	return glIsFramebufferEXT(framebuffer->value);
}

Babylon::GLboolean isProgram(Babylon::IGLProgram::Ptr program) { 
	return glIsProgram(program->value);
}

Babylon::GLboolean isRenderbuffer(Babylon::IGLRenderbuffer::Ptr renderbuffer) { 
	return glIsRenderbufferEXT(renderbuffer->value);
}

Babylon::GLboolean isShader(Babylon::IGLShader::Ptr shader) { 
	return glIsShader(shader->value);
}

Babylon::GLboolean isTexture(Babylon::IGLTexture::Ptr texture) { 
	return glIsTexture(texture->value);
}

void GL::lineWidth(Babylon::GLfloat width) { 
	glLineWidth(width);
}

void GL::linkProgram(Babylon::IGLProgram::Ptr program) { 
	glLinkProgram(program->value);
}

void GL::pixelStorei(Babylon::GLenum pname, Babylon::GLint param) { 
	glPixelStorei(pname, param);
}

void GL::polygonOffset(Babylon::GLfloat factor, Babylon::GLfloat units) { 
	glPolygonOffset(factor, units);
}

void GL::readPixels(Babylon::GLint x, Babylon::GLint y, Babylon::GLsizei width, Babylon::GLsizei height, 
					Babylon::GLenum format, Babylon::GLenum type, Babylon::any pixels) { 
	glReadPixels(x, y, width, height, format, type, pixels);
}

void GL::renderbufferStorage(Babylon::GLenum target, Babylon::GLenum internalformat, 
							 Babylon::GLsizei width, Babylon::GLsizei height) { 
	glRenderbufferStorageEXT(target, internalformat, width, height);
}

void GL::sampleCoverage(Babylon::GLclampf value, Babylon::GLboolean invert) { 
	glSampleCoverage(value, invert);
}

void GL::scissor(Babylon::GLint x, Babylon::GLint y, Babylon::GLsizei width, Babylon::GLsizei height) { 
	glScissor(x, y, width, height);
}

void GL::shaderSource(Babylon::IGLShader::Ptr shader, string source) { 
	////glShaderSource(shader->value, source.c_str());
	throw "not supported";
}

void GL::stencilFunc(Babylon::GLenum func, Babylon::GLint ref, Babylon::GLuint mask) { 
	glStencilFunc(func, ref, mask);
}

void GL::stencilFuncSeparate(Babylon::GLenum face, Babylon::GLenum func, Babylon::GLint ref, Babylon::GLuint mask) { 
	glStencilFuncSeparate(face, func, ref, mask);
}

void GL::stencilMask(Babylon::GLuint mask) { 
	glStencilMask(mask);
}

void GL::stencilMaskSeparate(Babylon::GLenum face, Babylon::GLuint mask) { 
	glStencilMaskSeparate(face, mask);
}

void GL::stencilOp(Babylon::GLenum fail, Babylon::GLenum zfail, Babylon::GLenum zpass) { 
	glStencilOp(fail, zfail, zpass);
}

void GL::stencilOpSeparate(Babylon::GLenum face, Babylon::GLenum fail, Babylon::GLenum zfail, Babylon::GLenum zpass) { 
	glStencilOpSeparate(face, fail, zfail, zpass);
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
					Babylon::GLenum format, Babylon::GLenum type, IVideo::Ptr video) { 
}
// May throw DOMException

void GL::texParameterf(Babylon::GLenum target, Babylon::GLenum pname, Babylon::GLfloat param) { 
	glTexParameterf(target, pname, param);
}

void GL::texParameteri(Babylon::GLenum target, Babylon::GLenum pname, Babylon::GLint param) { 
	glTexParameteri(target, pname, param);
}

void GL::texSubImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLint xoffset, Babylon::GLint yoffset, 
					   Babylon::GLsizei width, Babylon::GLsizei height, 
					   Babylon::GLenum format, Babylon::GLenum type, Babylon::any pixels) { 
	glTexSubImage2D(target, level, xoffset, yoffset, width, height, format, type, pixels);
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
}

void GL::uniform1fv(Babylon::IGLUniformLocation::Ptr location, Babylon::Float32Array v) { 
	glUniform1fv(location->value,v.size() * sizeof(Babylon::GLfloat), v.data());
}

void GL::uniform1i(Babylon::IGLUniformLocation::Ptr location, Babylon::GLint x) { 
	glUniform1i(location->value, x);
}

void GL::uniform1iv(Babylon::IGLUniformLocation::Ptr location, Babylon::Int32Array v) {
	glUniform1iv(location->value, v.size() * sizeof(int32_t), v.data());
}

void GL::uniform2f(Babylon::IGLUniformLocation::Ptr location, Babylon::GLfloat x, Babylon::GLfloat y) { 
	glUniform2f(location->value, x, y);
}

void GL::uniform2fv(Babylon::IGLUniformLocation::Ptr location, Babylon::Float32Array v) { 
	glUniform2fv(location->value, v.size() * sizeof(Babylon::GLfloat), v.data());
}

void GL::uniform2i(Babylon::IGLUniformLocation::Ptr location, Babylon::GLint x, Babylon::GLint y) { 
	glUniform2i(location->value, x, y);
}

void GL::uniform2iv(Babylon::IGLUniformLocation::Ptr location, Babylon::Int32Array v) { 
	glUniform2iv(location->value, v.size() * sizeof(int32_t), v.data());
}

void GL::uniform3f(Babylon::IGLUniformLocation::Ptr location, Babylon::GLfloat x, Babylon::GLfloat y, Babylon::GLfloat z) { 
	glUniform3f(location->value, x, y, z);
}

void GL::uniform3fv(Babylon::IGLUniformLocation::Ptr location, Babylon::Float32Array v) { 
	glUniform3fv(location->value, v.size() * sizeof(Babylon::GLfloat), v.data());
}

void GL::uniform3i(Babylon::IGLUniformLocation::Ptr location, Babylon::GLint x, Babylon::GLint y, Babylon::GLint z) { 
	glUniform3i(location->value, x, y, z);
}

void GL::uniform3iv(Babylon::IGLUniformLocation::Ptr location, Babylon::Int32Array v) { 
	glUniform3iv(location->value, v.size() * sizeof(int32_t), v.data());
}

void GL::uniform4f(Babylon::IGLUniformLocation::Ptr location, Babylon::GLfloat x, Babylon::GLfloat y, Babylon::GLfloat z, Babylon::GLfloat w) {
	glUniform4f(location->value, x, y, z, w);
}

void GL::uniform4fv(Babylon::IGLUniformLocation::Ptr location, Babylon::Float32Array v) { 
	glUniform4fv(location->value, v.size() * sizeof(Babylon::GLfloat), v.data());
}

void GL::uniform4i(Babylon::IGLUniformLocation::Ptr location, Babylon::GLint x, Babylon::GLint y, Babylon::GLint z, Babylon::GLint w) { 
	glUniform4i(location->value, x, y, z, w);
}

void GL::uniform4iv(Babylon::IGLUniformLocation::Ptr location, Babylon::Int32Array v) { 
	glUniform4iv(location->value, v.size() * sizeof(int32_t), v.data());
}

void GL::uniformMatrix2fv(Babylon::IGLUniformLocation::Ptr location, Babylon::GLboolean transpose, 
						  Babylon::Float32Array value) { 
	glUniformMatrix2fv(location->value, transpose, value.size() * sizeof(Babylon::GLfloat), value.data());
}

void GL::uniformMatrix3fv(Babylon::IGLUniformLocation::Ptr location, Babylon::GLboolean transpose, 
						  Babylon::Float32Array value) { 
	glUniformMatrix3fv(location->value, transpose, value.size() * sizeof(Babylon::GLfloat), value.data());
}

void GL::uniformMatrix4fv(Babylon::IGLUniformLocation::Ptr location, Babylon::GLboolean transpose, 
						  Babylon::Float32Array value) {
	glUniformMatrix4fv(location->value, transpose, value.size() * sizeof(Babylon::GLfloat), value.data());
}

void GL::useProgram(Babylon::IGLProgram::Ptr program) {
	glUseProgram(program->value);
}

void GL::validateProgram(Babylon::IGLProgram::Ptr program) {
	glValidateProgram(program->value);
}

void GL::vertexAttrib1f(Babylon::GLuint indx, Babylon::GLfloat x) {
	glVertexAttrib1f(indx, x);
}

void GL::vertexAttrib1fv(Babylon::GLuint indx, Babylon::Float32Array values) { 
	glVertexAttrib1fv(indx, values.data());
}

void GL::vertexAttrib2f(Babylon::GLuint indx, Babylon::GLfloat x, Babylon::GLfloat y) { 
	glVertexAttrib2f(indx, x, y);
}

void GL::vertexAttrib2fv(Babylon::GLuint indx, Babylon::Float32Array values) { 
	glVertexAttrib2fv(indx, values.data());
}

void GL::vertexAttrib3f(Babylon::GLuint indx, Babylon::GLfloat x, Babylon::GLfloat y, Babylon::GLfloat z) { 
	glVertexAttrib3f(indx, x, y, z);
}

void GL::vertexAttrib3fv(Babylon::GLuint indx, Babylon::Float32Array values) { 
	glVertexAttrib3fv(indx, values.data());
}

void GL::vertexAttrib4f(Babylon::GLuint indx, Babylon::GLfloat x, Babylon::GLfloat y, Babylon::GLfloat z, Babylon::GLfloat w) { 
	glVertexAttrib4f(indx, x, y, z, w);
}

void GL::vertexAttrib4fv(Babylon::GLuint indx, Babylon::Float32Array values) {
	glVertexAttrib4fv(indx, values.data());
}

void GL::vertexAttribPointer(Babylon::GLuint indx, Babylon::GLint size, Babylon::GLenum type, 
							 Babylon::GLboolean normalized, Babylon::GLsizei stride, Babylon::GLintptr offset) { 
	glVertexAttribPointer(indx, size, type, normalized, stride, (Babylon::any)offset);
}

void GL::viewport(Babylon::GLint x, Babylon::GLint y, Babylon::GLsizei width, Babylon::GLsizei height) { 
	glViewport(x, y, width, height);
}

