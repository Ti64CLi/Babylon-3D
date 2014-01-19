#ifndef BABYLON_IGL_H
#define BABYLON_IGL_H

#include <stdint.h>
#include <memory>
#include <vector>
#include "icanvas.h"

using namespace std;

namespace Babylon {

	typedef unsigned long		GLenum;
	typedef bool				GLboolean;
	typedef unsigned long		GLbitfield;
	typedef char				GLbyte;         /* 'byte' should be a signed 8 bit type. */
	typedef short				GLshort;
	typedef long				GLint;
	typedef long				GLsizei;
	typedef long long			GLintptr;
	typedef long long			GLsizeiptr;
	typedef unsigned char		GLubyte;        /* 'unsigned byte' should be an unsigned 8 bit type. */
	typedef unsigned short		GLushort;
	typedef unsigned long		GLuint;
	typedef float				GLfloat;
	typedef float				GLclampf;  

	typedef long long			GLint64;
	typedef unsigned long long	GLuint64;

	typedef void*				any;

	typedef GLubyte* ArrayBuffer;
	typedef vector<GLfloat> Float32Array;
	typedef vector<int32_t> Int32Array;
	typedef vector<uint16_t> Uint16Array;

	class IGLObject {
	public:
		typedef shared_ptr<IGLObject> Ptr;
	};

	class IGLBuffer : public IGLObject {
	public:
		typedef shared_ptr<IGLBuffer> Ptr;
		typedef vector<Ptr> Array;

		// TODO: custom referense count for Babylon - do we need it if we use shared_object?
		// TODO: get rid of it
		int references;
	};

	class IGLFramebuffer : public IGLObject {
	public:
		typedef shared_ptr<IGLFramebuffer> Ptr;
	};

	class IGLProgram : public IGLObject {
	public:
		typedef shared_ptr<IGLProgram> Ptr;
	};

	class IGLRenderbuffer : public IGLObject {
	public:
		typedef shared_ptr<IGLRenderbuffer> Ptr;
	};

	class IGLShader : public IGLObject {
	public:
		typedef shared_ptr<IGLShader> Ptr;
	};

	class IGLTexture : public IGLObject {
	public:
		typedef shared_ptr<IGLTexture> Ptr;
		typedef vector<Ptr> Array;

		virtual GLint get_baseWidth() = 0;
		virtual GLint get_baseHeight() = 0;
		virtual GLint get_width() = 0;
		virtual GLint get_height() = 0;
		virtual bool getIsReady() = 0;
		virtual string getUrl() = 0;
		virtual bool getNoMipmap() = 0;

		virtual void set_baseWidth(GLint) = 0;
		virtual void set_baseHeight(GLint) = 0;
		virtual void set_width(GLint) = 0;
		virtual void set_height(GLint) = 0;
		virtual void setIsReady(bool) = 0;
		virtual void setUrl(string) = 0;
		virtual void setNoMipmap(bool) = 0;

		// TODO: custom referense count for Babylon - do we need it if we use shared_object?
		// TODO: get rid of it
		int references;
	};

	class IGLUniformLocation {
	public:
		typedef shared_ptr<IGLUniformLocation> Ptr;
	};

	class IGLActiveInfo {
	public:
		typedef shared_ptr<IGLActiveInfo> Ptr;

		virtual GLint getSize() = 0;
		virtual GLenum getType() = 0;
		virtual string getName() = 0;
	};

	class IGLShaderPrecisionFormat {
	public:
		typedef shared_ptr<IGLShaderPrecisionFormat> Ptr;

		virtual GLint getRangeMin() = 0;
		virtual GLint getRangeMax() = 0;
		virtual GLint getPrecision() = 0;
	};

	class IGL {

	public:
		/* ClearBufferMask */
		const static GLenum DEPTH_BUFFER_BIT               = 0x00000100;
		const static GLenum STENCIL_BUFFER_BIT             = 0x00000400;
		const static GLenum COLOR_BUFFER_BIT               = 0x00004000;

		/* BeginMode */
		const static GLenum POINTS                         = 0x0000;
		const static GLenum LINES                          = 0x0001;
		const static GLenum LINE_LOOP                      = 0x0002;
		const static GLenum LINE_STRIP                     = 0x0003;
		const static GLenum TRIANGLES                      = 0x0004;
		const static GLenum TRIANGLE_STRIP                 = 0x0005;
		const static GLenum TRIANGLE_FAN                   = 0x0006;

		/* AlphaFunction (not supported in ES20) */
		/*      NEVER */
		/*      LESS */
		/*      EQUAL */
		/*      LEQUAL */
		/*      GREATER */
		/*      NOTEQUAL */
		/*      GEQUAL */
		/*      ALWAYS */

		/* BlendingFactorDest */
		const static GLenum ZERO                           = 0;
		const static GLenum ONE                            = 1;
		const static GLenum SRC_COLOR                      = 0x0300;
		const static GLenum ONE_MINUS_SRC_COLOR            = 0x0301;
		const static GLenum SRC_ALPHA                      = 0x0302;
		const static GLenum ONE_MINUS_SRC_ALPHA            = 0x0303;
		const static GLenum DST_ALPHA                      = 0x0304;
		const static GLenum ONE_MINUS_DST_ALPHA            = 0x0305;

		/* BlendingFactorSrc */
		/*      ZERO */
		/*      ONE */
		const static GLenum DST_COLOR                      = 0x0306;
		const static GLenum ONE_MINUS_DST_COLOR            = 0x0307;
		const static GLenum SRC_ALPHA_SATURATE             = 0x0308;
		/*      SRC_ALPHA */
		/*      ONE_MINUS_SRC_ALPHA */
		/*      DST_ALPHA */
		/*      ONE_MINUS_DST_ALPHA */

		/* BlendEquationSeparate */
		const static GLenum FUNC_ADD                       = 0x8006;
		const static GLenum BLEND_EQUATION                 = 0x8009;
		const static GLenum BLEND_EQUATION_RGB             = 0x8009;   /* same as BLEND_EQUATION */
		const static GLenum BLEND_EQUATION_ALPHA           = 0x883D;

		/* BlendSubtract */
		const static GLenum FUNC_SUBTRACT                  = 0x800A;
		const static GLenum FUNC_REVERSE_SUBTRACT          = 0x800B;

		/* Separate Blend Functions */
		const static GLenum BLEND_DST_RGB                  = 0x80C8;
		const static GLenum BLEND_SRC_RGB                  = 0x80C9;
		const static GLenum BLEND_DST_ALPHA                = 0x80CA;
		const static GLenum BLEND_SRC_ALPHA                = 0x80CB;
		const static GLenum CONSTANT_COLOR                 = 0x8001;
		const static GLenum ONE_MINUS_CONSTANT_COLOR       = 0x8002;
		const static GLenum CONSTANT_ALPHA                 = 0x8003;
		const static GLenum ONE_MINUS_CONSTANT_ALPHA       = 0x8004;
		const static GLenum BLEND_COLOR                    = 0x8005;

		/* Buffer Objects */
		const static GLenum ARRAY_BUFFER                   = 0x8892;
		const static GLenum ELEMENT_ARRAY_BUFFER           = 0x8893;
		const static GLenum ARRAY_BUFFER_BINDING           = 0x8894;
		const static GLenum ELEMENT_ARRAY_BUFFER_BINDING   = 0x8895;

		const static GLenum STREAM_DRAW                    = 0x88E0;
		const static GLenum STATIC_DRAW                    = 0x88E4;
		const static GLenum DYNAMIC_DRAW                   = 0x88E8;

		const static GLenum BUFFER_SIZE                    = 0x8764;
		const static GLenum BUFFER_USAGE                   = 0x8765;

		const static GLenum CURRENT_VERTEX_ATTRIB          = 0x8626;

		/* CullFaceMode */
		const static GLenum FRONT                          = 0x0404;
		const static GLenum BACK                           = 0x0405;
		const static GLenum FRONT_AND_BACK                 = 0x0408;

		/* DepthFunction */
		/*      NEVER */
		/*      LESS */
		/*      EQUAL */
		/*      LEQUAL */
		/*      GREATER */
		/*      NOTEQUAL */
		/*      GEQUAL */
		/*      ALWAYS */

		/* EnableCap */
		/* TEXTURE_2D */
		const static GLenum CULL_FACE                      = 0x0B44;
		const static GLenum BLEND                          = 0x0BE2;
		const static GLenum DITHER                         = 0x0BD0;
		const static GLenum STENCIL_TEST                   = 0x0B90;
		const static GLenum DEPTH_TEST                     = 0x0B71;
		const static GLenum SCISSOR_TEST                   = 0x0C11;
		const static GLenum POLYGON_OFFSET_FILL            = 0x8037;
		const static GLenum SAMPLE_ALPHA_TO_COVERAGE       = 0x809E;
		const static GLenum SAMPLE_COVERAGE                = 0x80A0;

		/* ErrorCode */
		const static GLenum NO_ERROR                       = 0;
		const static GLenum INVALID_ENUM                   = 0x0500;
		const static GLenum INVALID_VALUE                  = 0x0501;
		const static GLenum INVALID_OPERATION              = 0x0502;
		const static GLenum OUT_OF_MEMORY                  = 0x0505;

		/* FrontFaceDirection */
		const static GLenum CW                             = 0x0900;
		const static GLenum CCW                            = 0x0901;

		/* GetPName */
		const static GLenum LINE_WIDTH                     = 0x0B21;
		const static GLenum ALIASED_POINT_SIZE_RANGE       = 0x846D;
		const static GLenum ALIASED_LINE_WIDTH_RANGE       = 0x846E;
		const static GLenum CULL_FACE_MODE                 = 0x0B45;
		const static GLenum FRONT_FACE                     = 0x0B46;
		const static GLenum DEPTH_RANGE                    = 0x0B70;
		const static GLenum DEPTH_WRITEMASK                = 0x0B72;
		const static GLenum DEPTH_CLEAR_VALUE              = 0x0B73;
		const static GLenum DEPTH_FUNC                     = 0x0B74;
		const static GLenum STENCIL_CLEAR_VALUE            = 0x0B91;
		const static GLenum STENCIL_FUNC                   = 0x0B92;
		const static GLenum STENCIL_FAIL                   = 0x0B94;
		const static GLenum STENCIL_PASS_DEPTH_FAIL        = 0x0B95;
		const static GLenum STENCIL_PASS_DEPTH_PASS        = 0x0B96;
		const static GLenum STENCIL_REF                    = 0x0B97;
		const static GLenum STENCIL_VALUE_MASK             = 0x0B93;
		const static GLenum STENCIL_WRITEMASK              = 0x0B98;
		const static GLenum STENCIL_BACK_FUNC              = 0x8800;
		const static GLenum STENCIL_BACK_FAIL              = 0x8801;
		const static GLenum STENCIL_BACK_PASS_DEPTH_FAIL   = 0x8802;
		const static GLenum STENCIL_BACK_PASS_DEPTH_PASS   = 0x8803;
		const static GLenum STENCIL_BACK_REF               = 0x8CA3;
		const static GLenum STENCIL_BACK_VALUE_MASK        = 0x8CA4;
		const static GLenum STENCIL_BACK_WRITEMASK         = 0x8CA5;
		const static GLenum VIEWPORT                       = 0x0BA2;
		const static GLenum SCISSOR_BOX                    = 0x0C10;
		/*      SCISSOR_TEST */
		const static GLenum COLOR_CLEAR_VALUE              = 0x0C22;
		const static GLenum COLOR_WRITEMASK                = 0x0C23;
		const static GLenum UNPACK_ALIGNMENT               = 0x0CF5;
		const static GLenum PACK_ALIGNMENT                 = 0x0D05;
		const static GLenum MAX_TEXTURE_SIZE               = 0x0D33;
		const static GLenum MAX_VIEWPORT_DIMS              = 0x0D3A;
		const static GLenum SUBPIXEL_BITS                  = 0x0D50;
		const static GLenum RED_BITS                       = 0x0D52;
		const static GLenum GREEN_BITS                     = 0x0D53;
		const static GLenum BLUE_BITS                      = 0x0D54;
		const static GLenum ALPHA_BITS                     = 0x0D55;
		const static GLenum DEPTH_BITS                     = 0x0D56;
		const static GLenum STENCIL_BITS                   = 0x0D57;
		const static GLenum POLYGON_OFFSET_UNITS           = 0x2A00;
		/*      POLYGON_OFFSET_FILL */
		const static GLenum POLYGON_OFFSET_FACTOR          = 0x8038;
		const static GLenum TEXTURE_BINDING_2D             = 0x8069;
		const static GLenum SAMPLE_BUFFERS                 = 0x80A8;
		const static GLenum SAMPLES                        = 0x80A9;
		const static GLenum SAMPLE_COVERAGE_VALUE          = 0x80AA;
		const static GLenum SAMPLE_COVERAGE_INVERT         = 0x80AB;

		/* GetTextureParameter */
		/*      TEXTURE_MAG_FILTER */
		/*      TEXTURE_MIN_FILTER */
		/*      TEXTURE_WRAP_S */
		/*      TEXTURE_WRAP_T */

		const static GLenum COMPRESSED_TEXTURE_FORMATS     = 0x86A3;

		/* HintMode */
		const static GLenum DONT_CARE                      = 0x1100;
		const static GLenum FASTEST                        = 0x1101;
		const static GLenum NICEST                         = 0x1102;

		/* HintTarget */
		const static GLenum GENERATE_MIPMAP_HINT            = 0x8192;

		/* DataType */
		const static GLenum BYTE                           = 0x1400;
		const static GLenum UNSIGNED_BYTE                  = 0x1401;
		const static GLenum SHORT                          = 0x1402;
		const static GLenum UNSIGNED_SHORT                 = 0x1403;
		const static GLenum INT                            = 0x1404;
		const static GLenum UNSIGNED_INT                   = 0x1405;
		const static GLenum FLOAT                          = 0x1406;

		/* PixelFormat */
		const static GLenum DEPTH_COMPONENT                = 0x1902;
		const static GLenum ALPHA                          = 0x1906;
		const static GLenum RGB                            = 0x1907;
		const static GLenum RGBA                           = 0x1908;
		const static GLenum LUMINANCE                      = 0x1909;
		const static GLenum LUMINANCE_ALPHA                = 0x190A;

		/* PixelType */
		/*      UNSIGNED_BYTE */
		const static GLenum UNSIGNED_SHORT_4_4_4_4         = 0x8033;
		const static GLenum UNSIGNED_SHORT_5_5_5_1         = 0x8034;
		const static GLenum UNSIGNED_SHORT_5_6_5           = 0x8363;

		/* Shaders */
		const static GLenum FRAGMENT_SHADER                  = 0x8B30;
		const static GLenum VERTEX_SHADER                    = 0x8B31;
		const static GLenum MAX_VERTEX_ATTRIBS               = 0x8869;
		const static GLenum MAX_VERTEX_UNIFORM_VECTORS       = 0x8DFB;
		const static GLenum MAX_VARYING_VECTORS              = 0x8DFC;
		const static GLenum MAX_COMBINED_TEXTURE_IMAGE_UNITS = 0x8B4D;
		const static GLenum MAX_VERTEX_TEXTURE_IMAGE_UNITS   = 0x8B4C;
		const static GLenum MAX_TEXTURE_IMAGE_UNITS          = 0x8872;
		const static GLenum MAX_FRAGMENT_UNIFORM_VECTORS     = 0x8DFD;
		const static GLenum SHADER_TYPE                      = 0x8B4F;
		const static GLenum DELETE_STATUS                    = 0x8B80;
		const static GLenum LINK_STATUS                      = 0x8B82;
		const static GLenum VALIDATE_STATUS                  = 0x8B83;
		const static GLenum ATTACHED_SHADERS                 = 0x8B85;
		const static GLenum ACTIVE_UNIFORMS                  = 0x8B86;
		const static GLenum ACTIVE_ATTRIBUTES                = 0x8B89;
		const static GLenum SHADING_LANGUAGE_VERSION         = 0x8B8C;
		const static GLenum CURRENT_PROGRAM                  = 0x8B8D;

		/* StencilFunction */
		const static GLenum NEVER                          = 0x0200;
		const static GLenum LESS                           = 0x0201;
		const static GLenum EQUAL                          = 0x0202;
		const static GLenum LEQUAL                         = 0x0203;
		const static GLenum GREATER                        = 0x0204;
		const static GLenum NOTEQUAL                       = 0x0205;
		const static GLenum GEQUAL                         = 0x0206;
		const static GLenum ALWAYS                         = 0x0207;

		/* StencilOp */
		/*      ZERO */
		const static GLenum KEEP                           = 0x1E00;
		const static GLenum REPLACE                        = 0x1E01;
		const static GLenum INCR                           = 0x1E02;
		const static GLenum DECR                           = 0x1E03;
		const static GLenum INVERT                         = 0x150A;
		const static GLenum INCR_WRAP                      = 0x8507;
		const static GLenum DECR_WRAP                      = 0x8508;

		/* StringName */
		const static GLenum VENDOR                         = 0x1F00;
		const static GLenum RENDERER                       = 0x1F01;
		const static GLenum VERSION                        = 0x1F02;

		/* TextureMagFilter */
		const static GLenum NEAREST                        = 0x2600;
		const static GLenum LINEAR                         = 0x2601;

		/* TextureMinFilter */
		/*      NEAREST */
		/*      LINEAR */
		const static GLenum NEAREST_MIPMAP_NEAREST         = 0x2700;
		const static GLenum LINEAR_MIPMAP_NEAREST          = 0x2701;
		const static GLenum NEAREST_MIPMAP_LINEAR          = 0x2702;
		const static GLenum LINEAR_MIPMAP_LINEAR           = 0x2703;

		/* TextureParameterName */
		const static GLenum TEXTURE_MAG_FILTER             = 0x2800;
		const static GLenum TEXTURE_MIN_FILTER             = 0x2801;
		const static GLenum TEXTURE_WRAP_S                 = 0x2802;
		const static GLenum TEXTURE_WRAP_T                 = 0x2803;

		/* TextureTarget */
		const static GLenum TEXTURE_2D                     = 0x0DE1;
		const static GLenum TEXTURE                        = 0x1702;

		const static GLenum TEXTURE_CUBE_MAP               = 0x8513;
		const static GLenum TEXTURE_BINDING_CUBE_MAP       = 0x8514;
		const static GLenum TEXTURE_CUBE_MAP_POSITIVE_X    = 0x8515;
		const static GLenum TEXTURE_CUBE_MAP_NEGATIVE_X    = 0x8516;
		const static GLenum TEXTURE_CUBE_MAP_POSITIVE_Y    = 0x8517;
		const static GLenum TEXTURE_CUBE_MAP_NEGATIVE_Y    = 0x8518;
		const static GLenum TEXTURE_CUBE_MAP_POSITIVE_Z    = 0x8519;
		const static GLenum TEXTURE_CUBE_MAP_NEGATIVE_Z    = 0x851A;
		const static GLenum MAX_CUBE_MAP_TEXTURE_SIZE      = 0x851C;

		/* TextureUnit */
		const static GLenum TEXTURE0                       = 0x84C0;
		const static GLenum TEXTURE1                       = 0x84C1;
		const static GLenum TEXTURE2                       = 0x84C2;
		const static GLenum TEXTURE3                       = 0x84C3;
		const static GLenum TEXTURE4                       = 0x84C4;
		const static GLenum TEXTURE5                       = 0x84C5;
		const static GLenum TEXTURE6                       = 0x84C6;
		const static GLenum TEXTURE7                       = 0x84C7;
		const static GLenum TEXTURE8                       = 0x84C8;
		const static GLenum TEXTURE9                       = 0x84C9;
		const static GLenum TEXTURE10                      = 0x84CA;
		const static GLenum TEXTURE11                      = 0x84CB;
		const static GLenum TEXTURE12                      = 0x84CC;
		const static GLenum TEXTURE13                      = 0x84CD;
		const static GLenum TEXTURE14                      = 0x84CE;
		const static GLenum TEXTURE15                      = 0x84CF;
		const static GLenum TEXTURE16                      = 0x84D0;
		const static GLenum TEXTURE17                      = 0x84D1;
		const static GLenum TEXTURE18                      = 0x84D2;
		const static GLenum TEXTURE19                      = 0x84D3;
		const static GLenum TEXTURE20                      = 0x84D4;
		const static GLenum TEXTURE21                      = 0x84D5;
		const static GLenum TEXTURE22                      = 0x84D6;
		const static GLenum TEXTURE23                      = 0x84D7;
		const static GLenum TEXTURE24                      = 0x84D8;
		const static GLenum TEXTURE25                      = 0x84D9;
		const static GLenum TEXTURE26                      = 0x84DA;
		const static GLenum TEXTURE27                      = 0x84DB;
		const static GLenum TEXTURE28                      = 0x84DC;
		const static GLenum TEXTURE29                      = 0x84DD;
		const static GLenum TEXTURE30                      = 0x84DE;
		const static GLenum TEXTURE31                      = 0x84DF;
		const static GLenum ACTIVE_TEXTURE                 = 0x84E0;

		/* TextureWrapMode */
		const static GLenum REPEAT                         = 0x2901;
		const static GLenum CLAMP_TO_EDGE                  = 0x812F;
		const static GLenum MIRRORED_REPEAT                = 0x8370;

		/* Uniform Types */
		const static GLenum FLOAT_VEC2                     = 0x8B50;
		const static GLenum FLOAT_VEC3                     = 0x8B51;
		const static GLenum FLOAT_VEC4                     = 0x8B52;
		const static GLenum INT_VEC2                       = 0x8B53;
		const static GLenum INT_VEC3                       = 0x8B54;
		const static GLenum INT_VEC4                       = 0x8B55;
		const static GLenum BOOL                           = 0x8B56;
		const static GLenum BOOL_VEC2                      = 0x8B57;
		const static GLenum BOOL_VEC3                      = 0x8B58;
		const static GLenum BOOL_VEC4                      = 0x8B59;
		const static GLenum FLOAT_MAT2                     = 0x8B5A;
		const static GLenum FLOAT_MAT3                     = 0x8B5B;
		const static GLenum FLOAT_MAT4                     = 0x8B5C;
		const static GLenum SAMPLER_2D                     = 0x8B5E;
		const static GLenum SAMPLER_CUBE                   = 0x8B60;

		/* Vertex Arrays */
		const static GLenum VERTEX_ATTRIB_ARRAY_ENABLED        = 0x8622;
		const static GLenum VERTEX_ATTRIB_ARRAY_SIZE           = 0x8623;
		const static GLenum VERTEX_ATTRIB_ARRAY_STRIDE         = 0x8624;
		const static GLenum VERTEX_ATTRIB_ARRAY_TYPE           = 0x8625;
		const static GLenum VERTEX_ATTRIB_ARRAY_NORMALIZED     = 0x886A;
		const static GLenum VERTEX_ATTRIB_ARRAY_POINTER        = 0x8645;
		const static GLenum VERTEX_ATTRIB_ARRAY_BUFFER_BINDING = 0x889F;

		/* Shader Source */
		const static GLenum COMPILE_STATUS                 = 0x8B81;

		/* Shader Precision-Specified Types */
		const static GLenum LOW_FLOAT                      = 0x8DF0;
		const static GLenum MEDIUM_FLOAT                   = 0x8DF1;
		const static GLenum HIGH_FLOAT                     = 0x8DF2;
		const static GLenum LOW_INT                        = 0x8DF3;
		const static GLenum MEDIUM_INT                     = 0x8DF4;
		const static GLenum HIGH_INT                       = 0x8DF5;

		/* Framebuffer Object. */
		const static GLenum FRAMEBUFFER                    = 0x8D40;
		const static GLenum RENDERBUFFER                   = 0x8D41;

		const static GLenum RGBA4                          = 0x8056;
		const static GLenum RGB5_A1                        = 0x8057;
		const static GLenum RGB565                         = 0x8D62;
		const static GLenum DEPTH_COMPONENT16              = 0x81A5;
		const static GLenum STENCIL_INDEX                  = 0x1901;
		const static GLenum STENCIL_INDEX8                 = 0x8D48;
		const static GLenum DEPTH_STENCIL                  = 0x84F9;

		const static GLenum RENDERBUFFER_WIDTH             = 0x8D42;
		const static GLenum RENDERBUFFER_HEIGHT            = 0x8D43;
		const static GLenum RENDERBUFFER_INTERNAL_FORMAT   = 0x8D44;
		const static GLenum RENDERBUFFER_RED_SIZE          = 0x8D50;
		const static GLenum RENDERBUFFER_GREEN_SIZE        = 0x8D51;
		const static GLenum RENDERBUFFER_BLUE_SIZE         = 0x8D52;
		const static GLenum RENDERBUFFER_ALPHA_SIZE        = 0x8D53;
		const static GLenum RENDERBUFFER_DEPTH_SIZE        = 0x8D54;
		const static GLenum RENDERBUFFER_STENCIL_SIZE      = 0x8D55;

		const static GLenum FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE           = 0x8CD0;
		const static GLenum FRAMEBUFFER_ATTACHMENT_OBJECT_NAME           = 0x8CD1;
		const static GLenum FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL         = 0x8CD2;
		const static GLenum FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE = 0x8CD3;

		const static GLenum COLOR_ATTACHMENT0              = 0x8CE0;
		const static GLenum DEPTH_ATTACHMENT               = 0x8D00;
		const static GLenum STENCIL_ATTACHMENT             = 0x8D20;
		const static GLenum DEPTH_STENCIL_ATTACHMENT       = 0x821A;

		const static GLenum NONE                           = 0;

		const static GLenum FRAMEBUFFER_COMPLETE                      = 0x8CD5;
		const static GLenum FRAMEBUFFER_INCOMPLETE_ATTACHMENT         = 0x8CD6;
		const static GLenum FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT = 0x8CD7;
		const static GLenum FRAMEBUFFER_INCOMPLETE_DIMENSIONS         = 0x8CD9;
		const static GLenum FRAMEBUFFER_UNSUPPORTED                   = 0x8CDD;

		const static GLenum FRAMEBUFFER_BINDING            = 0x8CA6;
		const static GLenum RENDERBUFFER_BINDING           = 0x8CA7;
		const static GLenum MAX_RENDERBUFFER_SIZE          = 0x84E8;

		const static GLenum INVALID_FRAMEBUFFER_OPERATION  = 0x0506;

		/* WebGL-specific enums */
		const static GLenum UNPACK_FLIP_Y_WEBGL            = 0x9240;
		const static GLenum UNPACK_PREMULTIPLY_ALPHA_WEBGL = 0x9241;
		const static GLenum CONTEXT_LOST_WEBGL             = 0x9242;
		const static GLenum UNPACK_COLORSPACE_CONVERSION_WEBGL = 0x9243;
		const static GLenum BROWSER_DEFAULT_WEBGL          = 0x9244;

		typedef shared_ptr<IGL> Ptr;

	public: 

		virtual GLenum getEnumByName (string name) = 0;
		virtual GLenum getEnumByNameIndex (string name, int index) = 0;

		virtual void activeTexture(GLenum texture) = 0;
		virtual void attachShader(IGLProgram::Ptr program, IGLShader::Ptr shader) = 0;
		virtual void bindAttribLocation(IGLProgram::Ptr program, GLuint index, string name) = 0;
		virtual void bindBuffer(GLenum target, IGLBuffer::Ptr buffer) = 0;
		virtual void bindFramebuffer(GLenum target, IGLFramebuffer::Ptr framebuffer) = 0;
		virtual void bindRenderbuffer(GLenum target, IGLRenderbuffer::Ptr renderbuffer) = 0;
		virtual void bindTexture(GLenum target, IGLTexture::Ptr texture) = 0;
		virtual void blendColor(GLclampf red, GLclampf green, GLclampf blue, GLclampf alpha) = 0;
		virtual void blendEquation(GLenum mode) = 0;
		virtual void blendEquationSeparate(GLenum modeRGB, GLenum modeAlpha) = 0;
		virtual void blendFunc(GLenum sfactor, GLenum dfactor) = 0;
		virtual void blendFuncSeparate(GLenum srcRGB, GLenum dstRGB, 
			GLenum srcAlpha, GLenum dstAlpha) = 0;

		virtual void bufferData(GLenum target, GLsizeiptr size, GLenum usage) = 0;
		virtual void bufferData(GLenum target, ArrayBuffer data, GLenum usage) = 0;
		virtual void bufferData(GLenum target, Float32Array data, GLenum usage) = 0;
		virtual void bufferData(GLenum target, Int32Array data, GLenum usage) = 0;
		virtual void bufferData(GLenum target, Uint16Array data, GLenum usage) = 0;
		virtual void bufferSubData(GLenum target, GLintptr offset, ArrayBuffer data) = 0;
		virtual void bufferSubData(GLenum target, GLintptr offset, Float32Array data) = 0;
		virtual void bufferSubData(GLenum target, GLintptr offset, Int32Array data) = 0;

		virtual GLenum checkFramebufferStatus(GLenum target) = 0;
		virtual void clear(GLbitfield mask) = 0;
		virtual void clearColor(GLclampf red, GLclampf green, GLclampf blue, GLclampf alpha) = 0;
		virtual void clearDepth(GLclampf depth) = 0;
		virtual void clearStencil(GLint s) = 0;
		virtual void colorMask(GLboolean red, GLboolean green, GLboolean blue, GLboolean alpha) = 0;
		virtual void compileShader(IGLShader::Ptr shader) = 0;

		virtual void compressedTexSubImage2D(GLenum target, GLint level,
			GLint xoffset, GLint yoffset,
			GLsizei width, GLsizei height, GLenum format,
			ArrayBuffer data) = 0;

		virtual void copyTexImage2D(GLenum target, GLint level, GLenum internalformat, 
			GLint x, GLint y, GLsizei width, GLsizei height, 
			GLint border) = 0;
		virtual void copyTexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, 
			GLint x, GLint y, GLsizei width, GLsizei height) = 0;

		virtual IGLBuffer::Ptr createBuffer() = 0;
		virtual IGLFramebuffer::Ptr createFramebuffer() = 0;
		virtual IGLProgram::Ptr createProgram() = 0;
		virtual IGLRenderbuffer::Ptr createRenderbuffer() = 0;
		virtual IGLShader::Ptr createShader(GLenum type) = 0;
		virtual IGLTexture::Ptr createTexture() = 0;

		virtual void cullFace(GLenum mode) = 0;

		virtual void deleteBuffer(IGLBuffer::Ptr buffer) = 0;
		virtual void deleteFramebuffer(IGLFramebuffer::Ptr framebuffer) = 0;
		virtual void deleteProgram(IGLProgram::Ptr program) = 0;
		virtual void deleteRenderbuffer(IGLRenderbuffer::Ptr renderbuffer) = 0;
		virtual void deleteShader(IGLShader::Ptr shader) = 0;
		virtual void deleteTexture(IGLTexture::Ptr texture) = 0;

		virtual void depthFunc(GLenum func) = 0;
		virtual void depthMask(GLboolean flag) = 0;
		virtual void depthRange(GLclampf zNear, GLclampf zFar) = 0;
		virtual void detachShader(IGLProgram::Ptr program, IGLShader::Ptr shader) = 0;
		virtual void disable(GLenum cap) = 0;
		virtual void disableVertexAttribArray(GLuint index) = 0;
		virtual void drawArrays(GLenum mode, GLint first, GLsizei count) = 0;
		virtual void drawElements(GLenum mode, GLsizei count, GLenum type, GLintptr offset) = 0;

		virtual void enable(GLenum cap) = 0;
		virtual void enableVertexAttribArray(GLuint index) = 0;
		virtual void finish() = 0;
		virtual void flush() = 0;
		virtual void framebufferRenderbuffer(GLenum target, GLenum attachment, 
			GLenum renderbuffertarget, 
			IGLRenderbuffer::Ptr renderbuffer) = 0;
		virtual void framebufferTexture2D(GLenum target, GLenum attachment, GLenum textarget, 
			IGLTexture::Ptr texture, GLint level) = 0;
		virtual void frontFace(GLenum mode) = 0;

		virtual void generateMipmap(GLenum target) = 0;

		virtual IGLActiveInfo::Ptr getActiveAttrib(IGLProgram::Ptr program, GLuint index) = 0;
		virtual IGLActiveInfo::Ptr getActiveUniform(IGLProgram::Ptr program, GLuint index) = 0;
		virtual vector<IGLShader::Ptr> getAttachedShaders(IGLProgram::Ptr program) = 0;

		virtual GLint getAttribLocation(IGLProgram::Ptr program, string name) = 0;

		virtual any getBufferParameter(GLenum target, GLenum pname) = 0;
		virtual any getParameter(GLenum pname) = 0;

		virtual GLenum getError() = 0;

		virtual any getFramebufferAttachmentParameter(GLenum target, GLenum attachment, 
			GLenum pname) = 0;
		virtual any getProgramParameter(IGLProgram::Ptr program, GLenum pname) = 0;
		virtual string getProgramInfoLog(IGLProgram::Ptr program) = 0;
		virtual any getRenderbufferParameter(GLenum target, GLenum pname) = 0;
		virtual any getShaderParameter(IGLShader::Ptr shader, GLenum pname) = 0;
		virtual IGLShaderPrecisionFormat::Ptr getShaderPrecisionFormat(GLenum shadertype, GLenum precisiontype) = 0;
		virtual string getShaderInfoLog(IGLShader::Ptr shader) = 0;

		virtual string getShaderSource(IGLShader::Ptr shader) = 0;

		virtual any getTexParameter(GLenum target, GLenum pname) = 0;

		virtual any getUniform(IGLProgram::Ptr program, IGLUniformLocation::Ptr location) = 0;

		virtual IGLUniformLocation::Ptr getUniformLocation(IGLProgram::Ptr program, string name) = 0;

		virtual any getVertexAttrib(GLuint index, GLenum pname) = 0;

		virtual GLsizeiptr getVertexAttribOffset(GLuint index, GLenum pname) = 0;

		virtual void hint(GLenum target, GLenum mode) = 0;
		virtual GLboolean isBuffer(IGLBuffer::Ptr buffer) = 0;
		virtual GLboolean isEnabled(GLenum cap) = 0;
		virtual GLboolean isFramebuffer(IGLFramebuffer::Ptr framebuffer) = 0;
		virtual GLboolean isProgram(IGLProgram::Ptr program) = 0;
		virtual GLboolean isRenderbuffer(IGLRenderbuffer::Ptr renderbuffer) = 0;
		virtual GLboolean isShader(IGLShader::Ptr shader) = 0;
		virtual GLboolean isTexture(IGLTexture::Ptr texture) = 0;
		virtual void lineWidth(GLfloat width) = 0;
		virtual void linkProgram(IGLProgram::Ptr program) = 0;
		virtual void pixelStorei(GLenum pname, GLint param) = 0;
		virtual void polygonOffset(GLfloat factor, GLfloat units) = 0;

		virtual void readPixels(GLint x, GLint y, GLsizei width, GLsizei height, 
			GLenum format, GLenum type, ArrayBuffer pixels) = 0;

		virtual void renderbufferStorage(GLenum target, GLenum internalformat, 
			GLsizei width, GLsizei height) = 0;
		virtual void sampleCoverage(GLclampf value, GLboolean invert) = 0;
		virtual void scissor(GLint x, GLint y, GLsizei width, GLsizei height) = 0;

		virtual void shaderSource(IGLShader::Ptr shader, string source) = 0;

		virtual void stencilFunc(GLenum func, GLint ref, GLuint mask) = 0;
		virtual void stencilFuncSeparate(GLenum face, GLenum func, GLint ref, GLuint mask) = 0;
		virtual void stencilMask(GLuint mask) = 0;
		virtual void stencilMaskSeparate(GLenum face, GLuint mask) = 0;
		virtual void stencilOp(GLenum fail, GLenum zfail, GLenum zpass) = 0;
		virtual void stencilOpSeparate(GLenum face, GLenum fail, GLenum zfail, GLenum zpass) = 0;

		virtual void texImage2D(GLenum target, GLint level, GLenum internalformat, 
			GLsizei width, GLsizei height, GLint border, GLenum format, 
			GLenum type, ArrayBuffer pixels) = 0;
		virtual void texImage2D(GLenum target, GLint level, GLenum internalformat,
			GLenum format, GLenum type, any pixels) = 0;
		virtual void texImage2D(GLenum target, GLint level, GLenum internalformat,
			GLenum format, GLenum type, IImage::Ptr image) = 0; // May throw DOMException
		virtual void texImage2D(GLenum target, GLint level, GLenum internalformat,
			GLenum format, GLenum type, ICanvas::Ptr canvas) = 0; // May throw DOMException
		//virtual void texImage2D(GLenum target, GLint level, GLenum internalformat,
		//	GLenum format, GLenum type, HTMLVideoElement video) = 0; // May throw DOMException

		virtual void texParameterf(GLenum target, GLenum pname, GLfloat param) = 0;
		virtual void texParameteri(GLenum target, GLenum pname, GLint param) = 0;

		virtual void texSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, 
			GLsizei width, GLsizei height, 
			GLenum format, GLenum type, ArrayBuffer pixels) = 0;
		virtual void texSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, 
			GLenum format, GLenum type, any pixels) = 0;
		//virtual void texSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, 
		//	GLenum format, GLenum type, HTMLImageElement image) = 0; // May throw DOMException
		virtual void texSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, 
			GLenum format, GLenum type, ICanvas::Ptr canvas) = 0; // May throw DOMException
		//virtual void texSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, 
		//	GLenum format, GLenum type, HTMLVideoElement video) = 0; // May throw DOMException

		virtual void uniform1f(IGLUniformLocation::Ptr location, GLfloat x) = 0;
		virtual void uniform1fv(IGLUniformLocation::Ptr location, Float32Array v) = 0;
		virtual void uniform1i(IGLUniformLocation::Ptr location, GLint x) = 0;
		virtual void uniform1iv(IGLUniformLocation::Ptr location, Int32Array v) = 0;
		virtual void uniform2f(IGLUniformLocation::Ptr location, GLfloat x, GLfloat y) = 0;
		virtual void uniform2fv(IGLUniformLocation::Ptr location, Float32Array v) = 0;
		virtual void uniform2i(IGLUniformLocation::Ptr location, GLint x, GLint y) = 0;
		virtual void uniform2iv(IGLUniformLocation::Ptr location, Int32Array v) = 0;
		virtual void uniform3f(IGLUniformLocation::Ptr location, GLfloat x, GLfloat y, GLfloat z) = 0;
		virtual void uniform3fv(IGLUniformLocation::Ptr location, Float32Array v) = 0;
		virtual void uniform3i(IGLUniformLocation::Ptr location, GLint x, GLint y, GLint z) = 0;
		virtual void uniform3iv(IGLUniformLocation::Ptr location, Int32Array v) = 0;
		virtual void uniform4f(IGLUniformLocation::Ptr location, GLfloat x, GLfloat y, GLfloat z, GLfloat w) = 0;
		virtual void uniform4fv(IGLUniformLocation::Ptr location, Float32Array v) = 0;
		virtual void uniform4i(IGLUniformLocation::Ptr location, GLint x, GLint y, GLint z, GLint w) = 0;
		virtual void uniform4iv(IGLUniformLocation::Ptr location, Int32Array v) = 0;

		virtual void uniformMatrix2fv(IGLUniformLocation::Ptr location, GLboolean transpose, 
			Float32Array value) = 0;
		virtual void uniformMatrix3fv(IGLUniformLocation::Ptr location, GLboolean transpose, 
			Float32Array value) = 0;
		virtual void uniformMatrix4fv(IGLUniformLocation::Ptr location, GLboolean transpose, 
			Float32Array value) = 0;

		virtual void useProgram(IGLProgram::Ptr program) = 0;
		virtual void validateProgram(IGLProgram::Ptr program) = 0;

		virtual void vertexAttrib1f(GLuint indx, GLfloat x) = 0;
		virtual void vertexAttrib1fv(GLuint indx, Float32Array values) = 0;
		virtual void vertexAttrib2f(GLuint indx, GLfloat x, GLfloat y) = 0;
		virtual void vertexAttrib2fv(GLuint indx, Float32Array values) = 0;
		virtual void vertexAttrib3f(GLuint indx, GLfloat x, GLfloat y, GLfloat z) = 0;
		virtual void vertexAttrib3fv(GLuint indx, Float32Array values) = 0;
		virtual void vertexAttrib4f(GLuint indx, GLfloat x, GLfloat y, GLfloat z, GLfloat w) = 0;
		virtual void vertexAttrib4fv(GLuint indx, Float32Array values) = 0;
		virtual void vertexAttribPointer(GLuint indx, GLint size, GLenum type, 
			GLboolean normalized, GLsizei stride, GLintptr offset) = 0;

		virtual void viewport(GLint x, GLint y, GLsizei width, GLsizei height) = 0;
	};

};

#endif // BABYLON_IGL_H