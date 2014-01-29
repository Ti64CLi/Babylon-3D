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
}

Babylon::GLsizei GL::getDrawingBufferHeight() { 
}

Babylon::GLContextAttributes GL::getContextAttributes() { 
	return getContextAttributes();
}

bool GL::isContextLost() { 
}

vector<string> GL::getSupportedExtensions() { 
}

Babylon::any GL::getExtension(string name) { 
	return glewGetExtension(name.c_str);
}

Babylon::GLenum GL::getEnumByName (string name) { 
}

Babylon::GLenum GL::getEnumByNameIndex (string name, int index) { 
}

void GL::activeTexture(Babylon::GLenum texture) { 
	glActiveTexture(texture);
}

void GL::attachShader(Babylon::IGLProgram::Ptr program, Babylon::IGLShader::Ptr shader) { 
	glAttachShader(program, shader);
}

void GL::bindAttribLocation(Babylon::IGLProgram::Ptr program, Babylon::GLuint index, string name) { 
	glBindAttribLocation(program, index, name);
}

void GL::bindBuffer(Babylon::GLenum target, Babylon::IGLBuffer::Ptr buffer) { 
	glBindBuffer(target, buffer);
}

void GL::bindFramebuffer(Babylon::GLenum target, Babylon::IGLFramebuffer::Ptr framebuffer) { 
	glBindFramebufferEXT(target, framebuffer);
}

void GL::bindRenderbuffer(Babylon::GLenum target, Babylon::IGLRenderbuffer::Ptr renderbuffer) { 
	glBindRenderbufferEXT(target, renderbuffer);
}

void GL::bindTexture(Babylon::GLenum target, Babylon::IGLTexture::Ptr texture) { 
	glBindTextureEXT(target, texture);
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

void GL::bufferData(Babylon::GLenum target, Babylon::GLsizeiptr size, Babylon::GLenum usage) { 
	glBufferData(target, size, usage);
}

void GL::bufferData(Babylon::GLenum target, Babylon::ArrayBuffer data, Babylon::GLenum usage) { 
	glBufferData(target, data, usage);
}

void GL::bufferData(Babylon::GLenum target, Babylon::Float32Array data, Babylon::GLenum usage) { 
	glBufferData(target, data, usage);
}

void GL::bufferData(Babylon::GLenum target, Babylon::Int32Array data, Babylon::GLenum usage) { 
	glBufferData(target, data, usage);
}

void GL::bufferData(Babylon::GLenum target, Babylon::Uint16Array data, Babylon::GLenum usage) { 
	glBufferData(target, data, usage);
}

void GL::bufferSubData(Babylon::GLenum target, Babylon::GLintptr offset, Babylon::ArrayBuffer data) { 
	glBufferSubData(target, offset, data);
}

void GL::bufferSubData(Babylon::GLenum target, Babylon::GLintptr offset, Babylon::Float32Array data) { 
	glBufferSubData(target, offset, data);
}

void GL::bufferSubData(Babylon::GLenum target, Babylon::GLintptr offset, Babylon::Int32Array data) { 
	glBufferSubData(target, offset, data);
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
	glCompileShader(shader);
}

void GL::compressedTexSubImage2D(Babylon::GLenum target, Babylon::GLint level,
								 Babylon::GLint xoffset, Babylon::GLint yoffset,
								 Babylon::GLsizei width, Babylon::GLsizei height, Babylon::GLenum format,
								 Babylon::ArrayBuffer data) { 
									 glCompressedTexSubImage2D(target, level, xoffset, yoffset, width, height, format, data);
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
}

Babylon::IGLFramebuffer::Ptr createFramebuffer() { 
}

Babylon::IGLProgram::Ptr createProgram() { 
	return glCreateProgram();
}

Babylon::IGLRenderbuffer::Ptr createRenderbuffer() { 
}

Babylon::IGLShader::Ptr createShader(Babylon::GLenum type) { 
	return glCreateShader(type);
}

Babylon::IGLTexture::Ptr createTexture() { 
}

void GL::cullFace(Babylon::GLenum mode) { 
	glCullFace(mode);
}

void GL::deleteBuffer(Babylon::IGLBuffer::Ptr buffer) { 
	glDeleteBuffers(1, buffer);
}

void GL::deleteFramebuffer(Babylon::IGLFramebuffer::Ptr framebuffer) { 
	glDeleteFramebuffersEXT(1, framebuffer);
}

void GL::deleteProgram(Babylon::IGLProgram::Ptr program) { 
	glDeleteProgram(program);
}

void GL::deleteRenderbuffer(Babylon::IGLRenderbuffer::Ptr renderbuffer) { 
	glDeleteRenderbuffersEXT(1, renderbuffer);
}

void GL::deleteShader(Babylon::IGLShader::Ptr shader) { 
	glDeleteShader(shader);
}

void GL::deleteTexture(Babylon::IGLTexture::Ptr texture) { 
	glDeleteTextures(1, texture);
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
	glDetachShader(program, shader);
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
	glDrawElements(mode, count, type, offset);
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
									 glFramebufferRenderbufferEXT(target, attachment, renderbuffertarget, renderbuffer);
}

void GL::framebufferTexture2D(Babylon::GLenum target, Babylon::GLenum attachment, Babylon::GLenum textarget, 
							  Babylon::IGLTexture::Ptr texture, Babylon::GLint level) { 
								  glFramebufferTexture2DEXT(target, attachment, textarget, texture, level);
}

void GL::frontFace(Babylon::GLenum mode) { 
	glFrontFace(mode);
}

void GL::generateMipmap(Babylon::GLenum target) { 
	glGenerateMipmapEXT(target);
}

Babylon::IGLActiveInfo::Ptr getActiveAttrib(Babylon::IGLProgram::Ptr program, Babylon::GLuint index) { 
	return glGetActiveAttrib(program, index);
}

Babylon::IGLActiveInfo::Ptr getActiveUniform(Babylon::IGLProgram::Ptr program, Babylon::GLuint index) { 
	return glGetActiveUniform(program, index);
}

vector<Babylon::IGLShader::Ptr> getAttachedShaders(Babylon::IGLProgram::Ptr program) { 
	return glGetAttachedShaders(program);
}

Babylon::GLint getAttribLocation(Babylon::IGLProgram::Ptr program, string name) { 
	return glGetAttribLocation(program, name);
}

Babylon::any getBufferParameter(Babylon::GLenum target, Babylon::GLenum pname) { 
	return glGetBufferParameteriv(target, pname);
}

Babylon::any getParameter(Babylon::GLenum pname) { 
	return getParameter(pname);
}

Babylon::GLenum getError() { 
	return glGetError();
}

Babylon::any getFramebufferAttachmentParameter(Babylon::GLenum target, Babylon::GLenum attachment, 
											   Babylon::GLenum pname) {
												   return glGetFramebufferAttachmentParameterivEXT(target, attachment, pname);
}

Babylon::any getProgramParameter(Babylon::IGLProgram::Ptr program, Babylon::GLenum pname) { 
	return glGetProgramParameterfvNV(program, pname);
}

string getProgramInfoLog(Babylon::IGLProgram::Ptr program) { 
	return glGetProgramInfoLog(program);
}

Babylon::any getRenderbufferParameter(Babylon::GLenum target, Babylon::GLenum pname) { 
	return glGetRenderbufferParameterivEXT(target, pname);
}

Babylon::any getShaderParameter(Babylon::IGLShader::Ptr shader, Babylon::GLenum pname) { 
}

Babylon::IGLShaderPrecisionFormat::Ptr getShaderPrecisionFormat(Babylon::GLenum shadertype, Babylon::GLenum precisiontype) { 
}

string getShaderInfoLog(Babylon::IGLShader::Ptr shader) { 
	return glGetShaderInfoLog(shader);
}

string getShaderSource(Babylon::IGLShader::Ptr shader) { 
	return glGetShaderSource(shader);
}

Babylon::any getTexParameter(Babylon::GLenum target, Babylon::GLenum pname) { 
	return glGetTexParameterfv(target, pname);
}

Babylon::any getUniform(Babylon::IGLProgram::Ptr program, Babylon::IGLUniformLocation::Ptr location) { 
	return glGetUniformfv(program, location);
}

Babylon::IGLUniformLocation::Ptr getUniformLocation(Babylon::IGLProgram::Ptr program, string name) { 
	return glGetUniformLocation(program, name);
}

Babylon::any getVertexAttrib(Babylon::GLuint index, Babylon::GLenum pname) { 
	return glGetVertexAttribdv(index, pname);
}

Babylon::GLsizeiptr getVertexAttribOffset(Babylon::GLuint index, Babylon::GLenum pname) { 
}

void GL::hint(Babylon::GLenum target, Babylon::GLenum mode) { 
	glHint(target, mode);
}

Babylon::GLboolean isBuffer(Babylon::IGLBuffer::Ptr buffer) { 
	return glIsBuffer(buffer);
}

Babylon::GLboolean isEnabled(Babylon::GLenum cap) { 
	return glIsEnabled(cap);
}

Babylon::GLboolean isFramebuffer(Babylon::IGLFramebuffer::Ptr framebuffer) { 
	return glIsFramebufferEXT(framebuffer);
}

Babylon::GLboolean isProgram(Babylon::IGLProgram::Ptr program) { 
	return glIsProgram(program);
}

Babylon::GLboolean isRenderbuffer(Babylon::IGLRenderbuffer::Ptr renderbuffer) { 
	return glIsRenderbufferEXT(renderbuffer);
}

Babylon::GLboolean isShader(Babylon::IGLShader::Ptr shader) { 
	return glIsShader(shader);
}

Babylon::GLboolean isTexture(Babylon::IGLTexture::Ptr texture) { 
	return glIsTexture(texture);
}

void GL::lineWidth(Babylon::GLfloat width) { 
	glLineWidth(width);
}

void GL::linkProgram(Babylon::IGLProgram::Ptr program) { 
	glLinkProgram(program);
}

void GL::pixelStorei(Babylon::GLenum pname, Babylon::GLint param) { 
	glPixelStorei(pname, param);
}

void GL::polygonOffset(Babylon::GLfloat factor, Babylon::GLfloat units) { 
	glPolygonOffset(factor, units);
}

void GL::readPixels(Babylon::GLint x, Babylon::GLint y, Babylon::GLsizei width, Babylon::GLsizei height, 
					Babylon::GLenum format, Babylon::GLenum type, Babylon::ArrayBuffer pixels) { 
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
	glShaderSource(shader, source);
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
					Babylon::GLenum type, Babylon::ArrayBuffer pixels) { 
	glTexImage2D(target, level, internalformat, width, height, border, format, type, pixels);
}

void GL::texImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLenum internalformat,
					Babylon::GLenum format, Babylon::GLenum type, Babylon::any pixels) { 
	glTexImage2D(target, level, internalformat, format, type, pixels);
}

void GL::texImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLenum internalformat,
					Babylon::GLenum format, Babylon::GLenum type, Babylon::IImage::Ptr image) { 
	glTexImage2D(target, level, internalformat, format, type, image);
}
// May throw DOMException
void GL::texImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLenum internalformat,
					Babylon::GLenum format, Babylon::GLenum type, Babylon::ICanvas::Ptr canvas) { 
	glTexImage2D(target, level, internalformat, format, type, canvas);
}
// May throw DOMException
void GL::texImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLenum internalformat,
					Babylon::GLenum format, Babylon::GLenum type, IVideo::Ptr video) { 
}
// May throw DOMException

void GL::texParameterf(Babylon::GLenum target, Babylon::GLenum pname, Babylon::GLfloat param) { 
}

void GL::texParameteri(Babylon::GLenum target, Babylon::GLenum pname, Babylon::GLint param) { 
}

void GL::texSubImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLint xoffset, Babylon::GLint yoffset, 
					   Babylon::GLsizei width, Babylon::GLsizei height, 
					   Babylon::GLenum format, Babylon::GLenum type, Babylon::ArrayBuffer pixels) { 
}

void GL::texSubImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLint xoffset, Babylon::GLint yoffset, 
					   Babylon::GLenum format, Babylon::GLenum type, Babylon::any pixels) { 
}

//void GL::texSubImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLint xoffset, Babylon::GLint yoffset, 
//	Babylon::GLenum format, Babylon::GLenum type, HTMLImageElement image) { 
//}
// May throw DOMException
void GL::texSubImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLint xoffset, Babylon::GLint yoffset, 
					   Babylon::GLenum format, Babylon::GLenum type, Babylon::ICanvas::Ptr canvas) { 
}
// May throw DOMException
//void GL::texSubImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLint xoffset, Babylon::GLint yoffset, 
//	Babylon::GLenum format, Babylon::GLenum type, HTMLVideoElement video) { 
//}
// May throw DOMException

void GL::uniform1f(Babylon::IGLUniformLocation::Ptr location, Babylon::GLfloat x) { 
}

void GL::uniform1fv(Babylon::IGLUniformLocation::Ptr location, Babylon::Float32Array v) { 
}

void GL::uniform1i(Babylon::IGLUniformLocation::Ptr location, Babylon::GLint x) { 
}

void GL::uniform1iv(Babylon::IGLUniformLocation::Ptr location, Babylon::Int32Array v) { 
}

void GL::uniform2f(Babylon::IGLUniformLocation::Ptr location, Babylon::GLfloat x, Babylon::GLfloat y) { 
}

void GL::uniform2fv(Babylon::IGLUniformLocation::Ptr location, Babylon::Float32Array v) { 
}

void GL::uniform2i(Babylon::IGLUniformLocation::Ptr location, Babylon::GLint x, Babylon::GLint y) { 
}

void GL::uniform2iv(Babylon::IGLUniformLocation::Ptr location, Babylon::Int32Array v) { 
}

void GL::uniform3f(Babylon::IGLUniformLocation::Ptr location, Babylon::GLfloat x, Babylon::GLfloat y, Babylon::GLfloat z) { 
}

void GL::uniform3fv(Babylon::IGLUniformLocation::Ptr location, Babylon::Float32Array v) { 
}

void GL::uniform3i(Babylon::IGLUniformLocation::Ptr location, Babylon::GLint x, Babylon::GLint y, Babylon::GLint z) { 
}

void GL::uniform3iv(Babylon::IGLUniformLocation::Ptr location, Babylon::Int32Array v) { 
}

void GL::uniform4f(Babylon::IGLUniformLocation::Ptr location, Babylon::GLfloat x, Babylon::GLfloat y, Babylon::GLfloat z, Babylon::GLfloat w) { 
}

void GL::uniform4fv(Babylon::IGLUniformLocation::Ptr location, Babylon::Float32Array v) { 
}

void GL::uniform4i(Babylon::IGLUniformLocation::Ptr location, Babylon::GLint x, Babylon::GLint y, Babylon::GLint z, Babylon::GLint w) { 
}

void GL::uniform4iv(Babylon::IGLUniformLocation::Ptr location, Babylon::Int32Array v) { 
}

void GL::uniformMatrix2fv(Babylon::IGLUniformLocation::Ptr location, Babylon::GLboolean transpose, 
						  Babylon::Float32Array value) { 
}

void GL::uniformMatrix3fv(Babylon::IGLUniformLocation::Ptr location, Babylon::GLboolean transpose, 
						  Babylon::Float32Array value) { 
}

void GL::uniformMatrix4fv(Babylon::IGLUniformLocation::Ptr location, Babylon::GLboolean transpose, 
						  Babylon::Float32Array value) { 
}

void GL::useProgram(Babylon::IGLProgram::Ptr program) { 
}

void GL::validateProgram(Babylon::IGLProgram::Ptr program) { 
}

void GL::vertexAttrib1f(Babylon::GLuint indx, Babylon::GLfloat x) { 
}

void GL::vertexAttrib1fv(Babylon::GLuint indx, Babylon::Float32Array values) { 
}

void GL::vertexAttrib2f(Babylon::GLuint indx, Babylon::GLfloat x, Babylon::GLfloat y) { 
}

void GL::vertexAttrib2fv(Babylon::GLuint indx, Babylon::Float32Array values) { 
}

void GL::vertexAttrib3f(Babylon::GLuint indx, Babylon::GLfloat x, Babylon::GLfloat y, Babylon::GLfloat z) { 
}

void GL::vertexAttrib3fv(Babylon::GLuint indx, Babylon::Float32Array values) { 
}

void GL::vertexAttrib4f(Babylon::GLuint indx, Babylon::GLfloat x, Babylon::GLfloat y, Babylon::GLfloat z, Babylon::GLfloat w) { 
}

void GL::vertexAttrib4fv(Babylon::GLuint indx, Babylon::Float32Array values) { 
}

void GL::vertexAttribPointer(Babylon::GLuint indx, Babylon::GLint size, Babylon::GLenum type, 
							 Babylon::GLboolean normalized, Babylon::GLsizei stride, Babylon::GLintptr offset) { 
}

void GL::viewport(Babylon::GLint x, Babylon::GLint y, Babylon::GLsizei width, Babylon::GLsizei height) { 
}

