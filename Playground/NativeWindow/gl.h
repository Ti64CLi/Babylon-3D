#ifndef GL_H
#define GL_H

#include <memory>
#include <vector>

#include "igl.h"
#include "icanvas.h"

class GL : public Babylon::IGL, public enable_shared_from_this<GL> {

private:
	Babylon::ICanvas::Ptr canvas;
	bool antialias;

public: 

	GL(Babylon::ICanvas::Ptr canvas, bool antialias);

	virtual Babylon::ICanvas::Ptr getCanvas();
	virtual Babylon::GLsizei getDrawingBufferWidth();
	virtual Babylon::GLsizei getDrawingBufferHeight();

	virtual Babylon::GLContextAttributes getContextAttributes();
	virtual bool isContextLost();

	virtual vector<string> getSupportedExtensions();
	virtual Babylon::any getExtension(string name);

	virtual Babylon::GLenum getEnumByName (string name);
	virtual Babylon::GLenum getEnumByNameIndex (string name, int index);

	virtual void activeTexture(Babylon::GLenum texture);
	virtual void attachShader(Babylon::IGLProgram::Ptr program, Babylon::IGLShader::Ptr shader);
	virtual void bindAttribLocation(Babylon::IGLProgram::Ptr program, Babylon::GLuint index, string name);
	virtual void bindBuffer(Babylon::GLenum target, Babylon::IGLBuffer::Ptr buffer);
	virtual void bindFramebuffer(Babylon::GLenum target, Babylon::IGLFramebuffer::Ptr framebuffer);
	virtual void bindRenderbuffer(Babylon::GLenum target, Babylon::IGLRenderbuffer::Ptr renderbuffer);
	virtual void bindTexture(Babylon::GLenum target, Babylon::IGLTexture::Ptr texture);
	virtual void blendColor(Babylon::GLclampf red, Babylon::GLclampf green, Babylon::GLclampf blue, Babylon::GLclampf alpha);
	virtual void blendEquation(Babylon::GLenum mode);
	virtual void blendEquationSeparate(Babylon::GLenum modeRGB, Babylon::GLenum modeAlpha);
	virtual void blendFunc(Babylon::GLenum sfactor, Babylon::GLenum dfactor);
	virtual void blendFuncSeparate(Babylon::GLenum srcRGB, Babylon::GLenum dstRGB, 
		Babylon::GLenum srcAlpha, Babylon::GLenum dstAlpha);

	virtual void bufferData(Babylon::GLenum target, Babylon::GLsizeiptr sizeiptr, Babylon::GLenum usage);
	virtual void bufferData(Babylon::GLenum target, Babylon::Float32Array& data, Babylon::GLenum usage);
	virtual void bufferData(Babylon::GLenum target, Babylon::Int32Array& data, Babylon::GLenum usage);
	virtual void bufferData(Babylon::GLenum target, Babylon::Uint16Array& data, Babylon::GLenum usage);
	virtual void bufferSubData(Babylon::GLenum target, Babylon::GLintptr offset, Babylon::Float32Array& data);
	virtual void bufferSubData(Babylon::GLenum target, Babylon::GLintptr offset, Babylon::Int32Array& data);

	virtual Babylon::GLenum checkFramebufferStatus(Babylon::GLenum target);
	virtual void clear(Babylon::GLbitfield mask);
	virtual void clearColor(Babylon::GLclampf red, Babylon::GLclampf green, Babylon::GLclampf blue, Babylon::GLclampf alpha);
	virtual void clearDepth(Babylon::GLclampf depth);
	virtual void clearStencil(Babylon::GLint s);
	virtual void colorMask(Babylon::GLboolean red, Babylon::GLboolean green, Babylon::GLboolean blue, Babylon::GLboolean alpha);
	virtual void compileShader(Babylon::IGLShader::Ptr shader);

	virtual void compressedTexSubImage2D(Babylon::GLenum target, Babylon::GLint level,
		Babylon::GLint xoffset, Babylon::GLint yoffset,
		Babylon::GLsizei width, Babylon::GLsizei height, Babylon::GLenum format,
		Babylon::GLsizeiptr sizeiptr);

	virtual void copyTexImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLenum internalformat, 
		Babylon::GLint x, Babylon::GLint y, Babylon::GLsizei width, Babylon::GLsizei height, 
		Babylon::GLint border);
	virtual void copyTexSubImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLint xoffset, Babylon::GLint yoffset, 
		Babylon::GLint x, Babylon::GLint y, Babylon::GLsizei width, Babylon::GLsizei height);

	virtual Babylon::IGLBuffer::Ptr createBuffer();
	virtual Babylon::IGLFramebuffer::Ptr createFramebuffer();
	virtual Babylon::IGLProgram::Ptr createProgram();
	virtual Babylon::IGLRenderbuffer::Ptr createRenderbuffer();
	virtual Babylon::IGLShader::Ptr createShader(Babylon::GLenum type);
	virtual Babylon::IGLTexture::Ptr createTexture();

	virtual void cullFace(Babylon::GLenum mode);

	virtual void deleteBuffer(Babylon::IGLBuffer::Ptr buffer);
	virtual void deleteFramebuffer(Babylon::IGLFramebuffer::Ptr framebuffer);
	virtual void deleteProgram(Babylon::IGLProgram::Ptr program);
	virtual void deleteRenderbuffer(Babylon::IGLRenderbuffer::Ptr renderbuffer);
	virtual void deleteShader(Babylon::IGLShader::Ptr shader);
	virtual void deleteTexture(Babylon::IGLTexture::Ptr texture);

	virtual void depthFunc(Babylon::GLenum func);
	virtual void depthMask(Babylon::GLboolean flag);
	virtual void depthRange(Babylon::GLclampf zNear, Babylon::GLclampf zFar);
	virtual void detachShader(Babylon::IGLProgram::Ptr program, Babylon::IGLShader::Ptr shader);
	virtual void disable(Babylon::GLenum cap);
	virtual void disableVertexAttribArray(Babylon::GLuint index);
	virtual void drawArrays(Babylon::GLenum mode, Babylon::GLint first, Babylon::GLsizei count);
	virtual void drawElements(Babylon::GLenum mode, Babylon::GLsizei count, Babylon::GLenum type, Babylon::GLintptr offset);

	virtual void enable(Babylon::GLenum cap);
	virtual void enableVertexAttribArray(Babylon::GLuint index);
	virtual void finish();
	virtual void flush();
	virtual void framebufferRenderbuffer(Babylon::GLenum target, Babylon::GLenum attachment, 
		Babylon::GLenum renderbuffertarget, 
		Babylon::IGLRenderbuffer::Ptr renderbuffer);
	virtual void framebufferTexture2D(Babylon::GLenum target, Babylon::GLenum attachment, Babylon::GLenum textarget, 
		Babylon::IGLTexture::Ptr texture, Babylon::GLint level);
	virtual void frontFace(Babylon::GLenum mode);

	virtual void generateMipmap(Babylon::GLenum target);

	virtual Babylon::IGLActiveInfo::Ptr getActiveAttrib(Babylon::IGLProgram::Ptr program, Babylon::GLuint index);
	virtual Babylon::IGLActiveInfo::Ptr getActiveUniform(Babylon::IGLProgram::Ptr program, Babylon::GLuint index);
	virtual vector<Babylon::IGLShader::Ptr> getAttachedShaders(Babylon::IGLProgram::Ptr program);

	virtual Babylon::GLint getAttribLocation(Babylon::IGLProgram::Ptr program, string name);

	virtual Babylon::any getBufferParameter(Babylon::GLenum target, Babylon::GLenum pname);
	virtual Babylon::any getParameter(Babylon::GLenum pname);

	virtual Babylon::GLenum getError();

	virtual Babylon::any getFramebufferAttachmentParameter(Babylon::GLenum target, Babylon::GLenum attachment, 
		Babylon::GLenum pname);
	virtual Babylon::any getProgramParameter(Babylon::IGLProgram::Ptr program, Babylon::GLenum pname);
	virtual string getProgramInfoLog(Babylon::IGLProgram::Ptr program);
	virtual Babylon::any getRenderbufferParameter(Babylon::GLenum target, Babylon::GLenum pname);
	virtual Babylon::any getShaderParameter(Babylon::IGLShader::Ptr shader, Babylon::GLenum pname);
	virtual Babylon::IGLShaderPrecisionFormat::Ptr getShaderPrecisionFormat(Babylon::GLenum shadertype, Babylon::GLenum precisiontype);
	virtual string getShaderInfoLog(Babylon::IGLShader::Ptr shader);

	virtual string getShaderSource(Babylon::IGLShader::Ptr shader);

	virtual Babylon::any getTexParameter(Babylon::GLenum target, Babylon::GLenum pname);

	virtual Babylon::any getUniform(Babylon::IGLProgram::Ptr program, Babylon::IGLUniformLocation::Ptr location);

	virtual Babylon::IGLUniformLocation::Ptr getUniformLocation(Babylon::IGLProgram::Ptr program, string name);

	virtual Babylon::any getVertexAttrib(Babylon::GLuint index, Babylon::GLenum pname);

	virtual Babylon::GLsizeiptr getVertexAttribOffset(Babylon::GLuint index, Babylon::GLenum pname);

	virtual void hint(Babylon::GLenum target, Babylon::GLenum mode);
	virtual Babylon::GLboolean isBuffer(Babylon::IGLBuffer::Ptr buffer);
	virtual Babylon::GLboolean isEnabled(Babylon::GLenum cap);
	virtual Babylon::GLboolean isFramebuffer(Babylon::IGLFramebuffer::Ptr framebuffer);
	virtual Babylon::GLboolean isProgram(Babylon::IGLProgram::Ptr program);
	virtual Babylon::GLboolean isRenderbuffer(Babylon::IGLRenderbuffer::Ptr renderbuffer);
	virtual Babylon::GLboolean isShader(Babylon::IGLShader::Ptr shader);
	virtual Babylon::GLboolean isTexture(Babylon::IGLTexture::Ptr texture);
	virtual void lineWidth(Babylon::GLfloat width);
	virtual bool linkProgram(Babylon::IGLProgram::Ptr program);
	virtual void pixelStorei(Babylon::GLenum pname, Babylon::GLint param);
	virtual void polygonOffset(Babylon::GLfloat factor, Babylon::GLfloat units);

	virtual void readPixels(Babylon::GLint x, Babylon::GLint y, Babylon::GLsizei width, Babylon::GLsizei height, 
		Babylon::GLenum format, Babylon::GLenum type, Babylon::any pixels);

	virtual void renderbufferStorage(Babylon::GLenum target, Babylon::GLenum internalformat, 
		Babylon::GLsizei width, Babylon::GLsizei height);
	virtual void sampleCoverage(Babylon::GLclampf value, Babylon::GLboolean invert);
	virtual void scissor(Babylon::GLint x, Babylon::GLint y, Babylon::GLsizei width, Babylon::GLsizei height);

	virtual void shaderSource(Babylon::IGLShader::Ptr shader, string source);

	virtual void stencilFunc(Babylon::GLenum func, Babylon::GLint ref, Babylon::GLuint mask);
	virtual void stencilFuncSeparate(Babylon::GLenum face, Babylon::GLenum func, Babylon::GLint ref, Babylon::GLuint mask);
	virtual void stencilMask(Babylon::GLuint mask);
	virtual void stencilMaskSeparate(Babylon::GLenum face, Babylon::GLuint mask);
	virtual void stencilOp(Babylon::GLenum fail, Babylon::GLenum zfail, Babylon::GLenum zpass);
	virtual void stencilOpSeparate(Babylon::GLenum face, Babylon::GLenum fail, Babylon::GLenum zfail, Babylon::GLenum zpass);

	virtual void texImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLenum internalformat, 
		Babylon::GLsizei width, Babylon::GLsizei height, Babylon::GLint border, Babylon::GLenum format, 
		Babylon::GLenum type, Babylon::any pixels);
	virtual void texImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLenum internalformat,
		Babylon::GLenum format, Babylon::GLenum type, Babylon::any pixels);
	virtual void texImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLenum internalformat,
		Babylon::GLenum format, Babylon::GLenum type, Babylon::IImage::Ptr image); // May throw DOMException
	virtual void texImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLenum internalformat,
		Babylon::GLenum format, Babylon::GLenum type, Babylon::ICanvas::Ptr canvas); // May throw DOMException
	virtual void texImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLenum internalformat,
		Babylon::GLenum format, Babylon::GLenum type, Babylon::IVideo::Ptr video); // May throw DOMException

	virtual void texParameterf(Babylon::GLenum target, Babylon::GLenum pname, Babylon::GLfloat param);
	virtual void texParameteri(Babylon::GLenum target, Babylon::GLenum pname, Babylon::GLint param);

	virtual void texSubImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLint xoffset, Babylon::GLint yoffset, 
		Babylon::GLsizei width, Babylon::GLsizei height, 
		Babylon::GLenum format, Babylon::GLenum type, Babylon::any pixels);
	virtual void texSubImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLint xoffset, Babylon::GLint yoffset, 
		Babylon::GLenum format, Babylon::GLenum type, Babylon::any pixels);
	//virtual void texSubImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLint xoffset, Babylon::GLint yoffset, 
	//	Babylon::GLenum format, Babylon::GLenum type, HTMLImageElement image); // May throw DOMException
	virtual void texSubImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLint xoffset, Babylon::GLint yoffset, 
		Babylon::GLenum format, Babylon::GLenum type, Babylon::ICanvas::Ptr canvas); // May throw DOMException
	//virtual void texSubImage2D(Babylon::GLenum target, Babylon::GLint level, Babylon::GLint xoffset, Babylon::GLint yoffset, 
	//	Babylon::GLenum format, Babylon::GLenum type, HTMLVideoElement video); // May throw DOMException

	virtual void uniform1f(Babylon::IGLUniformLocation::Ptr location, Babylon::GLfloat x);
	virtual void uniform1fv(Babylon::IGLUniformLocation::Ptr location, Babylon::Float32Array& v);
	virtual void uniform1i(Babylon::IGLUniformLocation::Ptr location, Babylon::GLint x);
	virtual void uniform1iv(Babylon::IGLUniformLocation::Ptr location, Babylon::Int32Array& v);
	virtual void uniform2f(Babylon::IGLUniformLocation::Ptr location, Babylon::GLfloat x, Babylon::GLfloat y);
	virtual void uniform2fv(Babylon::IGLUniformLocation::Ptr location, Babylon::Float32Array& v);
	virtual void uniform2i(Babylon::IGLUniformLocation::Ptr location, Babylon::GLint x, Babylon::GLint y);
	virtual void uniform2iv(Babylon::IGLUniformLocation::Ptr location, Babylon::Int32Array& v);
	virtual void uniform3f(Babylon::IGLUniformLocation::Ptr location, Babylon::GLfloat x, Babylon::GLfloat y, Babylon::GLfloat z);
	virtual void uniform3fv(Babylon::IGLUniformLocation::Ptr location, Babylon::Float32Array& v);
	virtual void uniform3i(Babylon::IGLUniformLocation::Ptr location, Babylon::GLint x, Babylon::GLint y, Babylon::GLint z);
	virtual void uniform3iv(Babylon::IGLUniformLocation::Ptr location, Babylon::Int32Array& v);
	virtual void uniform4f(Babylon::IGLUniformLocation::Ptr location, Babylon::GLfloat x, Babylon::GLfloat y, Babylon::GLfloat z, Babylon::GLfloat w);
	virtual void uniform4fv(Babylon::IGLUniformLocation::Ptr location, Babylon::Float32Array& v);
	virtual void uniform4i(Babylon::IGLUniformLocation::Ptr location, Babylon::GLint x, Babylon::GLint y, Babylon::GLint z, Babylon::GLint w);
	virtual void uniform4iv(Babylon::IGLUniformLocation::Ptr location, Babylon::Int32Array& v);

	virtual void uniformMatrix2fv(Babylon::IGLUniformLocation::Ptr location, Babylon::GLboolean transpose, 
		Babylon::Float32Array& value);
	virtual void uniformMatrix3fv(Babylon::IGLUniformLocation::Ptr location, Babylon::GLboolean transpose, 
		Babylon::Float32Array& value);
	virtual void uniformMatrix4fv(Babylon::IGLUniformLocation::Ptr location, Babylon::GLboolean transpose, 
		Babylon::Float32Array& value);

	virtual void useProgram(Babylon::IGLProgram::Ptr program);
	virtual void validateProgram(Babylon::IGLProgram::Ptr program);

	virtual void vertexAttrib1f(Babylon::GLuint indx, Babylon::GLfloat x);
	virtual void vertexAttrib1fv(Babylon::GLuint indx, Babylon::Float32Array& values);
	virtual void vertexAttrib2f(Babylon::GLuint indx, Babylon::GLfloat x, Babylon::GLfloat y);
	virtual void vertexAttrib2fv(Babylon::GLuint indx, Babylon::Float32Array& values);
	virtual void vertexAttrib3f(Babylon::GLuint indx, Babylon::GLfloat x, Babylon::GLfloat y, Babylon::GLfloat z);
	virtual void vertexAttrib3fv(Babylon::GLuint indx, Babylon::Float32Array& values);
	virtual void vertexAttrib4f(Babylon::GLuint indx, Babylon::GLfloat x, Babylon::GLfloat y, Babylon::GLfloat z, Babylon::GLfloat w);
	virtual void vertexAttrib4fv(Babylon::GLuint indx, Babylon::Float32Array& values);
	virtual void vertexAttribPointer(Babylon::GLuint indx, Babylon::GLint size, Babylon::GLenum type, 
		Babylon::GLboolean normalized, Babylon::GLsizei stride, Babylon::GLintptr offset);

	virtual void viewport(Babylon::GLint x, Babylon::GLint y, Babylon::GLsizei width, Babylon::GLsizei height);

	// Extra
	virtual void GL::errorCheck();
};

#endif // GL_H