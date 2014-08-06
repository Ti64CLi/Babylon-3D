// --------------------------------------------------------------------------------------------------------------------
// <copyright file="extras.const.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BabylonNativeCsLibrary
{
    /// <summary>
    /// </summary>
    public class Gl
    {
        /* ClearBufferMask */

        /// <summary>
        /// </summary>
        public const int DEPTH_BUFFER_BIT = 0x00000100;

        /// <summary>
        /// </summary>
        public const int STENCIL_BUFFER_BIT = 0x00000400;

        /// <summary>
        /// </summary>
        public const int COLOR_BUFFER_BIT = 0x00004000;

        /* BeginMode */

        /// <summary>
        /// </summary>
        public const int POINTS = 0x0000;

        /// <summary>
        /// </summary>
        public const int LINES = 0x0001;

        /// <summary>
        /// </summary>
        public const int LINE_LOOP = 0x0002;

        /// <summary>
        /// </summary>
        public const int LINE_STRIP = 0x0003;

        /// <summary>
        /// </summary>
        public const int TRIANGLES = 0x0004;

        /// <summary>
        /// </summary>
        public const int TRIANGLE_STRIP = 0x0005;

        /// <summary>
        /// </summary>
        public const int TRIANGLE_FAN = 0x0006;

        /* AlphaFunction (not supported in ES20) */
        /*      public const int NEVER*/
        /*      public const int LESS*/
        /*      public const int EQUAL*/
        /*      public const int LEQUAL*/
        /*      public const int GREATER*/
        /*      public const int NOTEQUAL*/
        /*      public const int GEQUAL*/
        /*      public const int ALWAYS*/

        /* BlendingFactorDest */

        /// <summary>
        /// </summary>
        public const int ZERO = 0;

        /// <summary>
        /// </summary>
        public const int ONE = 1;

        /// <summary>
        /// </summary>
        public const int SRC_COLOR = 0x0300;

        /// <summary>
        /// </summary>
        public const int ONE_MINUS_SRC_COLOR = 0x0301;

        /// <summary>
        /// </summary>
        public const int SRC_ALPHA = 0x0302;

        /// <summary>
        /// </summary>
        public const int ONE_MINUS_SRC_ALPHA = 0x0303;

        /// <summary>
        /// </summary>
        public const int DST_ALPHA = 0x0304;

        /// <summary>
        /// </summary>
        public const int ONE_MINUS_DST_ALPHA = 0x0305;

        /* BlendingFactorSrc */
        /*      public const int ZERO*/
        /*      public const int ONE*/

        /// <summary>
        /// </summary>
        public const int DST_COLOR = 0x0306;

        /// <summary>
        /// </summary>
        public const int ONE_MINUS_DST_COLOR = 0x0307;

        /// <summary>
        /// </summary>
        public const int SRC_ALPHA_SATURATE = 0x0308;

        /*      public const int SRC_ALPHA*/
        /*      public const int ONE_MINUS_SRC_ALPHA*/
        /*      public const int DST_ALPHA*/
        /*      public const int ONE_MINUS_DST_ALPHA*/

        /* BlendEquationSeparate */

        /// <summary>
        /// </summary>
        public const int FUNC_ADD = 0x8006;

        /// <summary>
        /// </summary>
        public const int BLEND_EQUATION = 0x8009;

        /// <summary>
        /// </summary>
        public const int BLEND_EQUATION_RGB = 0x8009; /* same as public const int BLEND_EQUATION*/

        /// <summary>
        /// </summary>
        public const int BLEND_EQUATION_ALPHA = 0x883D;

        /* BlendSubtract */

        /// <summary>
        /// </summary>
        public const int FUNC_SUBTRACT = 0x800A;

        /// <summary>
        /// </summary>
        public const int FUNC_REVERSE_SUBTRACT = 0x800B;

        /* Separate Blend Functions */

        /// <summary>
        /// </summary>
        public const int BLEND_DST_RGB = 0x80C8;

        /// <summary>
        /// </summary>
        public const int BLEND_SRC_RGB = 0x80C9;

        /// <summary>
        /// </summary>
        public const int BLEND_DST_ALPHA = 0x80CA;

        /// <summary>
        /// </summary>
        public const int BLEND_SRC_ALPHA = 0x80CB;

        /// <summary>
        /// </summary>
        public const int CONSTANT_COLOR = 0x8001;

        /// <summary>
        /// </summary>
        public const int ONE_MINUS_CONSTANT_COLOR = 0x8002;

        /// <summary>
        /// </summary>
        public const int CONSTANT_ALPHA = 0x8003;

        /// <summary>
        /// </summary>
        public const int ONE_MINUS_CONSTANT_ALPHA = 0x8004;

        /// <summary>
        /// </summary>
        public const int BLEND_COLOR = 0x8005;

        /* Buffer Objects */

        /// <summary>
        /// </summary>
        public const int ARRAY_BUFFER = 0x8892;

        /// <summary>
        /// </summary>
        public const int ELEMENT_ARRAY_BUFFER = 0x8893;

        /// <summary>
        /// </summary>
        public const int ARRAY_BUFFER_BINDING = 0x8894;

        /// <summary>
        /// </summary>
        public const int ELEMENT_ARRAY_BUFFER_BINDING = 0x8895;

        /// <summary>
        /// </summary>
        public const int STREAM_DRAW = 0x88E0;

        /// <summary>
        /// </summary>
        public const int STATIC_DRAW = 0x88E4;

        /// <summary>
        /// </summary>
        public const int DYNAMIC_DRAW = 0x88E8;

        /// <summary>
        /// </summary>
        public const int BUFFER_SIZE = 0x8764;

        /// <summary>
        /// </summary>
        public const int BUFFER_USAGE = 0x8765;

        /// <summary>
        /// </summary>
        public const int CURRENT_VERTEX_ATTRIB = 0x8626;

        /* CullFaceMode */

        /// <summary>
        /// </summary>
        public const int FRONT = 0x0404;

        /// <summary>
        /// </summary>
        public const int BACK = 0x0405;

        /// <summary>
        /// </summary>
        public const int FRONT_AND_BACK = 0x0408;

        /* DepthFunction */
        /*      public const int NEVER*/
        /*      public const int LESS*/
        /*      public const int EQUAL*/
        /*      public const int LEQUAL*/
        /*      public const int GREATER*/
        /*      public const int NOTEQUAL*/
        /*      public const int GEQUAL*/
        /*      public const int ALWAYS*/

        /* EnableCap */
        /* public const int TEXTURE_2D*/

        /// <summary>
        /// </summary>
        public const int CULL_FACE = 0x0B44;

        /// <summary>
        /// </summary>
        public const int BLEND = 0x0BE2;

        /// <summary>
        /// </summary>
        public const int DITHER = 0x0BD0;

        /// <summary>
        /// </summary>
        public const int STENCIL_TEST = 0x0B90;

        /// <summary>
        /// </summary>
        public const int DEPTH_TEST = 0x0B71;

        /// <summary>
        /// </summary>
        public const int SCISSOR_TEST = 0x0C11;

        /// <summary>
        /// </summary>
        public const int POLYGON_OFFSET_FILL = 0x8037;

        /// <summary>
        /// </summary>
        public const int SAMPLE_ALPHA_TO_COVERAGE = 0x809E;

        /// <summary>
        /// </summary>
        public const int SAMPLE_COVERAGE = 0x80A0;

        /* ErrorCode */

        /// <summary>
        /// </summary>
        public const int NO_ERROR = 0;

        /// <summary>
        /// </summary>
        public const int INVALID_ENUM = 0x0500;

        /// <summary>
        /// </summary>
        public const int INVALID_VALUE = 0x0501;

        /// <summary>
        /// </summary>
        public const int INVALID_OPERATION = 0x0502;

        /// <summary>
        /// </summary>
        public const int OUT_OF_MEMORY = 0x0505;

        /* FrontFaceDirection */

        /// <summary>
        /// </summary>
        public const int CW = 0x0900;

        /// <summary>
        /// </summary>
        public const int CCW = 0x0901;

        /* GetPName */

        /// <summary>
        /// </summary>
        public const int LINE_WIDTH = 0x0B21;

        /// <summary>
        /// </summary>
        public const int ALIASED_POINT_SIZE_RANGE = 0x846D;

        /// <summary>
        /// </summary>
        public const int ALIASED_LINE_WIDTH_RANGE = 0x846E;

        /// <summary>
        /// </summary>
        public const int CULL_FACE_MODE = 0x0B45;

        /// <summary>
        /// </summary>
        public const int FRONT_FACE = 0x0B46;

        /// <summary>
        /// </summary>
        public const int DEPTH_RANGE = 0x0B70;

        /// <summary>
        /// </summary>
        public const int DEPTH_WRITEMASK = 0x0B72;

        /// <summary>
        /// </summary>
        public const int DEPTH_CLEAR_VALUE = 0x0B73;

        /// <summary>
        /// </summary>
        public const int DEPTH_FUNC = 0x0B74;

        /// <summary>
        /// </summary>
        public const int STENCIL_CLEAR_VALUE = 0x0B91;

        /// <summary>
        /// </summary>
        public const int STENCIL_FUNC = 0x0B92;

        /// <summary>
        /// </summary>
        public const int STENCIL_FAIL = 0x0B94;

        /// <summary>
        /// </summary>
        public const int STENCIL_PASS_DEPTH_FAIL = 0x0B95;

        /// <summary>
        /// </summary>
        public const int STENCIL_PASS_DEPTH_PASS = 0x0B96;

        /// <summary>
        /// </summary>
        public const int STENCIL_REF = 0x0B97;

        /// <summary>
        /// </summary>
        public const int STENCIL_VALUE_MASK = 0x0B93;

        /// <summary>
        /// </summary>
        public const int STENCIL_WRITEMASK = 0x0B98;

        /// <summary>
        /// </summary>
        public const int STENCIL_BACK_FUNC = 0x8800;

        /// <summary>
        /// </summary>
        public const int STENCIL_BACK_FAIL = 0x8801;

        /// <summary>
        /// </summary>
        public const int STENCIL_BACK_PASS_DEPTH_FAIL = 0x8802;

        /// <summary>
        /// </summary>
        public const int STENCIL_BACK_PASS_DEPTH_PASS = 0x8803;

        /// <summary>
        /// </summary>
        public const int STENCIL_BACK_REF = 0x8CA3;

        /// <summary>
        /// </summary>
        public const int STENCIL_BACK_VALUE_MASK = 0x8CA4;

        /// <summary>
        /// </summary>
        public const int STENCIL_BACK_WRITEMASK = 0x8CA5;

        /// <summary>
        /// </summary>
        public const int VIEWPORT = 0x0BA2;

        /// <summary>
        /// </summary>
        public const int SCISSOR_BOX = 0x0C10;

        /*      public const int SCISSOR_TEST*/

        /// <summary>
        /// </summary>
        public const int COLOR_CLEAR_VALUE = 0x0C22;

        /// <summary>
        /// </summary>
        public const int COLOR_WRITEMASK = 0x0C23;

        /// <summary>
        /// </summary>
        public const int UNPACK_ALIGNMENT = 0x0CF5;

        /// <summary>
        /// </summary>
        public const int PACK_ALIGNMENT = 0x0D05;

        /// <summary>
        /// </summary>
        public const int MAX_TEXTURE_SIZE = 0x0D33;

        /// <summary>
        /// </summary>
        public const int MAX_VIEWPORT_DIMS = 0x0D3A;

        /// <summary>
        /// </summary>
        public const int SUBPIXEL_BITS = 0x0D50;

        /// <summary>
        /// </summary>
        public const int RED_BITS = 0x0D52;

        /// <summary>
        /// </summary>
        public const int GREEN_BITS = 0x0D53;

        /// <summary>
        /// </summary>
        public const int BLUE_BITS = 0x0D54;

        /// <summary>
        /// </summary>
        public const int ALPHA_BITS = 0x0D55;

        /// <summary>
        /// </summary>
        public const int DEPTH_BITS = 0x0D56;

        /// <summary>
        /// </summary>
        public const int STENCIL_BITS = 0x0D57;

        /// <summary>
        /// </summary>
        public const int POLYGON_OFFSET_UNITS = 0x2A00;

        /*      public const int POLYGON_OFFSET_FILL*/

        /// <summary>
        /// </summary>
        public const int POLYGON_OFFSET_FACTOR = 0x8038;

        /// <summary>
        /// </summary>
        public const int TEXTURE_BINDING_2D = 0x8069;

        /// <summary>
        /// </summary>
        public const int SAMPLE_BUFFERS = 0x80A8;

        /// <summary>
        /// </summary>
        public const int SAMPLES = 0x80A9;

        /// <summary>
        /// </summary>
        public const int SAMPLE_COVERAGE_VALUE = 0x80AA;

        /// <summary>
        /// </summary>
        public const int SAMPLE_COVERAGE_INVERT = 0x80AB;

        /* GetTextureParameter */
        /*      public const int TEXTURE_MAG_FILTER*/
        /*      public const int TEXTURE_MIN_FILTER*/
        /*      public const int TEXTURE_WRAP_S*/
        /*      public const int TEXTURE_WRAP_T*/

        /// <summary>
        /// </summary>
        public const int COMPRESSED_TEXTURE_FORMATS = 0x86A3;

        /* HintMode */

        /// <summary>
        /// </summary>
        public const int DONT_CARE = 0x1100;

        /// <summary>
        /// </summary>
        public const int FASTEST = 0x1101;

        /// <summary>
        /// </summary>
        public const int NICEST = 0x1102;

        /* HintTarget */

        /// <summary>
        /// </summary>
        public const int GENERATE_MIPMAP_HINT = 0x8192;

        /* DataType */

        /// <summary>
        /// </summary>
        public const int BYTE = 0x1400;

        /// <summary>
        /// </summary>
        public const int UNSIGNED_BYTE = 0x1401;

        /// <summary>
        /// </summary>
        public const int SHORT = 0x1402;

        /// <summary>
        /// </summary>
        public const int UNSIGNED_SHORT = 0x1403;

        /// <summary>
        /// </summary>
        public const int INT = 0x1404;

        /// <summary>
        /// </summary>
        public const int UNSIGNED_INT = 0x1405;

        /// <summary>
        /// </summary>
        public const int FLOAT = 0x1406;

        /* PixelFormat */

        /// <summary>
        /// </summary>
        public const int DEPTH_COMPONENT = 0x1902;

        /// <summary>
        /// </summary>
        public const int ALPHA = 0x1906;

        /// <summary>
        /// </summary>
        public const int RGB = 0x1907;

        /// <summary>
        /// </summary>
        public const int RGBA = 0x1908;

        /// <summary>
        /// </summary>
        public const int LUMINANCE = 0x1909;

        /// <summary>
        /// </summary>
        public const int LUMINANCE_ALPHA = 0x190A;

        /* PixelType */
        /*      public const int UNSIGNED_BYTE*/

        /// <summary>
        /// </summary>
        public const int UNSIGNED_SHORT_4_4_4_4 = 0x8033;

        /// <summary>
        /// </summary>
        public const int UNSIGNED_SHORT_5_5_5_1 = 0x8034;

        /// <summary>
        /// </summary>
        public const int UNSIGNED_SHORT_5_6_5 = 0x8363;

        /* Shaders */

        /// <summary>
        /// </summary>
        public const int FRAGMENT_SHADER = 0x8B30;

        /// <summary>
        /// </summary>
        public const int VERTEX_SHADER = 0x8B31;

        /// <summary>
        /// </summary>
        public const int MAX_VERTEX_ATTRIBS = 0x8869;

        /// <summary>
        /// </summary>
        public const int MAX_VERTEX_UNIFORM_VECTORS = 0x8DFB;

        /// <summary>
        /// </summary>
        public const int MAX_VARYING_VECTORS = 0x8DFC;

        /// <summary>
        /// </summary>
        public const int MAX_COMBINED_TEXTURE_IMAGE_UNITS = 0x8B4D;

        /// <summary>
        /// </summary>
        public const int MAX_VERTEX_TEXTURE_IMAGE_UNITS = 0x8B4C;

        /// <summary>
        /// </summary>
        public const int MAX_TEXTURE_IMAGE_UNITS = 0x8872;

        /// <summary>
        /// </summary>
        public const int MAX_FRAGMENT_UNIFORM_VECTORS = 0x8DFD;

        /// <summary>
        /// </summary>
        public const int SHADER_TYPE = 0x8B4F;

        /// <summary>
        /// </summary>
        public const int DELETE_STATUS = 0x8B80;

        /// <summary>
        /// </summary>
        public const int LINK_STATUS = 0x8B82;

        /// <summary>
        /// </summary>
        public const int VALIDATE_STATUS = 0x8B83;

        /// <summary>
        /// </summary>
        public const int ATTACHED_SHADERS = 0x8B85;

        /// <summary>
        /// </summary>
        public const int ACTIVE_UNIFORMS = 0x8B86;

        /// <summary>
        /// </summary>
        public const int ACTIVE_ATTRIBUTES = 0x8B89;

        /// <summary>
        /// </summary>
        public const int SHADING_LANGUAGE_VERSION = 0x8B8C;

        /// <summary>
        /// </summary>
        public const int CURRENT_PROGRAM = 0x8B8D;

        /* StencilFunction */

        /// <summary>
        /// </summary>
        public const int NEVER = 0x0200;

        /// <summary>
        /// </summary>
        public const int LESS = 0x0201;

        /// <summary>
        /// </summary>
        public const int EQUAL = 0x0202;

        /// <summary>
        /// </summary>
        public const int LEQUAL = 0x0203;

        /// <summary>
        /// </summary>
        public const int GREATER = 0x0204;

        /// <summary>
        /// </summary>
        public const int NOTEQUAL = 0x0205;

        /// <summary>
        /// </summary>
        public const int GEQUAL = 0x0206;

        /// <summary>
        /// </summary>
        public const int ALWAYS = 0x0207;

        /* StencilOp */
        /*      public const int ZERO*/

        /// <summary>
        /// </summary>
        public const int KEEP = 0x1E00;

        /// <summary>
        /// </summary>
        public const int REPLACE = 0x1E01;

        /// <summary>
        /// </summary>
        public const int INCR = 0x1E02;

        /// <summary>
        /// </summary>
        public const int DECR = 0x1E03;

        /// <summary>
        /// </summary>
        public const int INVERT = 0x150A;

        /// <summary>
        /// </summary>
        public const int INCR_WRAP = 0x8507;

        /// <summary>
        /// </summary>
        public const int DECR_WRAP = 0x8508;

        /* StringName */

        /// <summary>
        /// </summary>
        public const int VENDOR = 0x1F00;

        /// <summary>
        /// </summary>
        public const int RENDERER = 0x1F01;

        /// <summary>
        /// </summary>
        public const int VERSION = 0x1F02;

        /* TextureMagFilter */

        /// <summary>
        /// </summary>
        public const int NEAREST = 0x2600;

        /// <summary>
        /// </summary>
        public const int LINEAR = 0x2601;

        /* TextureMinFilter */
        /*      public const int NEAREST*/
        /*      public const int LINEAR*/

        /// <summary>
        /// </summary>
        public const int NEAREST_MIPMAP_NEAREST = 0x2700;

        /// <summary>
        /// </summary>
        public const int LINEAR_MIPMAP_NEAREST = 0x2701;

        /// <summary>
        /// </summary>
        public const int NEAREST_MIPMAP_LINEAR = 0x2702;

        /// <summary>
        /// </summary>
        public const int LINEAR_MIPMAP_LINEAR = 0x2703;

        /* TextureParameterName */

        /// <summary>
        /// </summary>
        public const int TEXTURE_MAG_FILTER = 0x2800;

        /// <summary>
        /// </summary>
        public const int TEXTURE_MIN_FILTER = 0x2801;

        /// <summary>
        /// </summary>
        public const int TEXTURE_WRAP_S = 0x2802;

        /// <summary>
        /// </summary>
        public const int TEXTURE_WRAP_T = 0x2803;

        /* TextureTarget */

        /// <summary>
        /// </summary>
        public const int TEXTURE_2D = 0x0DE1;

        /// <summary>
        /// </summary>
        public const int TEXTURE = 0x1702;

        /// <summary>
        /// </summary>
        public const int TEXTURE_CUBE_MAP = 0x8513;

        /// <summary>
        /// </summary>
        public const int TEXTURE_BINDING_CUBE_MAP = 0x8514;

        /// <summary>
        /// </summary>
        public const int TEXTURE_CUBE_MAP_POSITIVE_X = 0x8515;

        /// <summary>
        /// </summary>
        public const int TEXTURE_CUBE_MAP_NEGATIVE_X = 0x8516;

        /// <summary>
        /// </summary>
        public const int TEXTURE_CUBE_MAP_POSITIVE_Y = 0x8517;

        /// <summary>
        /// </summary>
        public const int TEXTURE_CUBE_MAP_NEGATIVE_Y = 0x8518;

        /// <summary>
        /// </summary>
        public const int TEXTURE_CUBE_MAP_POSITIVE_Z = 0x8519;

        /// <summary>
        /// </summary>
        public const int TEXTURE_CUBE_MAP_NEGATIVE_Z = 0x851A;

        /// <summary>
        /// </summary>
        public const int MAX_CUBE_MAP_TEXTURE_SIZE = 0x851C;

        /* TextureUnit */

        /// <summary>
        /// </summary>
        public const int TEXTURE0 = 0x84C0;

        /// <summary>
        /// </summary>
        public const int TEXTURE1 = 0x84C1;

        /// <summary>
        /// </summary>
        public const int TEXTURE2 = 0x84C2;

        /// <summary>
        /// </summary>
        public const int TEXTURE3 = 0x84C3;

        /// <summary>
        /// </summary>
        public const int TEXTURE4 = 0x84C4;

        /// <summary>
        /// </summary>
        public const int TEXTURE5 = 0x84C5;

        /// <summary>
        /// </summary>
        public const int TEXTURE6 = 0x84C6;

        /// <summary>
        /// </summary>
        public const int TEXTURE7 = 0x84C7;

        /// <summary>
        /// </summary>
        public const int TEXTURE8 = 0x84C8;

        /// <summary>
        /// </summary>
        public const int TEXTURE9 = 0x84C9;

        /// <summary>
        /// </summary>
        public const int TEXTURE10 = 0x84CA;

        /// <summary>
        /// </summary>
        public const int TEXTURE11 = 0x84CB;

        /// <summary>
        /// </summary>
        public const int TEXTURE12 = 0x84CC;

        /// <summary>
        /// </summary>
        public const int TEXTURE13 = 0x84CD;

        /// <summary>
        /// </summary>
        public const int TEXTURE14 = 0x84CE;

        /// <summary>
        /// </summary>
        public const int TEXTURE15 = 0x84CF;

        /// <summary>
        /// </summary>
        public const int TEXTURE16 = 0x84D0;

        /// <summary>
        /// </summary>
        public const int TEXTURE17 = 0x84D1;

        /// <summary>
        /// </summary>
        public const int TEXTURE18 = 0x84D2;

        /// <summary>
        /// </summary>
        public const int TEXTURE19 = 0x84D3;

        /// <summary>
        /// </summary>
        public const int TEXTURE20 = 0x84D4;

        /// <summary>
        /// </summary>
        public const int TEXTURE21 = 0x84D5;

        /// <summary>
        /// </summary>
        public const int TEXTURE22 = 0x84D6;

        /// <summary>
        /// </summary>
        public const int TEXTURE23 = 0x84D7;

        /// <summary>
        /// </summary>
        public const int TEXTURE24 = 0x84D8;

        /// <summary>
        /// </summary>
        public const int TEXTURE25 = 0x84D9;

        /// <summary>
        /// </summary>
        public const int TEXTURE26 = 0x84DA;

        /// <summary>
        /// </summary>
        public const int TEXTURE27 = 0x84DB;

        /// <summary>
        /// </summary>
        public const int TEXTURE28 = 0x84DC;

        /// <summary>
        /// </summary>
        public const int TEXTURE29 = 0x84DD;

        /// <summary>
        /// </summary>
        public const int TEXTURE30 = 0x84DE;

        /// <summary>
        /// </summary>
        public const int TEXTURE31 = 0x84DF;

        /// <summary>
        /// </summary>
        public const int ACTIVE_TEXTURE = 0x84E0;

        /* TextureWrapMode */

        /// <summary>
        /// </summary>
        public const int REPEAT = 0x2901;

        /// <summary>
        /// </summary>
        public const int CLAMP_TO_EDGE = 0x812F;

        /// <summary>
        /// </summary>
        public const int MIRRORED_REPEAT = 0x8370;

        /* Uniform Types */

        /// <summary>
        /// </summary>
        public const int FLOAT_VEC2 = 0x8B50;

        /// <summary>
        /// </summary>
        public const int FLOAT_VEC3 = 0x8B51;

        /// <summary>
        /// </summary>
        public const int FLOAT_VEC4 = 0x8B52;

        /// <summary>
        /// </summary>
        public const int INT_VEC2 = 0x8B53;

        /// <summary>
        /// </summary>
        public const int INT_VEC3 = 0x8B54;

        /// <summary>
        /// </summary>
        public const int INT_VEC4 = 0x8B55;

        /// <summary>
        /// </summary>
        public const int BOOL = 0x8B56;

        /// <summary>
        /// </summary>
        public const int BOOL_VEC2 = 0x8B57;

        /// <summary>
        /// </summary>
        public const int BOOL_VEC3 = 0x8B58;

        /// <summary>
        /// </summary>
        public const int BOOL_VEC4 = 0x8B59;

        /// <summary>
        /// </summary>
        public const int FLOAT_MAT2 = 0x8B5A;

        /// <summary>
        /// </summary>
        public const int FLOAT_MAT3 = 0x8B5B;

        /// <summary>
        /// </summary>
        public const int FLOAT_MAT4 = 0x8B5C;

        /// <summary>
        /// </summary>
        public const int SAMPLER_2D = 0x8B5E;

        /// <summary>
        /// </summary>
        public const int SAMPLER_CUBE = 0x8B60;

        /* Vertex Arrays */

        /// <summary>
        /// </summary>
        public const int VERTEX_ATTRIB_ARRAY_ENABLED = 0x8622;

        /// <summary>
        /// </summary>
        public const int VERTEX_ATTRIB_ARRAY_SIZE = 0x8623;

        /// <summary>
        /// </summary>
        public const int VERTEX_ATTRIB_ARRAY_STRIDE = 0x8624;

        /// <summary>
        /// </summary>
        public const int VERTEX_ATTRIB_ARRAY_TYPE = 0x8625;

        /// <summary>
        /// </summary>
        public const int VERTEX_ATTRIB_ARRAY_NORMALIZED = 0x886A;

        /// <summary>
        /// </summary>
        public const int VERTEX_ATTRIB_ARRAY_POINTER = 0x8645;

        /// <summary>
        /// </summary>
        public const int VERTEX_ATTRIB_ARRAY_BUFFER_BINDING = 0x889F;

        /* Shader Source */

        /// <summary>
        /// </summary>
        public const int COMPILE_STATUS = 0x8B81;

        /* Shader Precision-Specified Types */

        /// <summary>
        /// </summary>
        public const int LOW_FLOAT = 0x8DF0;

        /// <summary>
        /// </summary>
        public const int MEDIUM_FLOAT = 0x8DF1;

        /// <summary>
        /// </summary>
        public const int HIGH_FLOAT = 0x8DF2;

        /// <summary>
        /// </summary>
        public const int LOW_INT = 0x8DF3;

        /// <summary>
        /// </summary>
        public const int MEDIUM_INT = 0x8DF4;

        /// <summary>
        /// </summary>
        public const int HIGH_INT = 0x8DF5;

        /* Framebuffer Object. */

        /// <summary>
        /// </summary>
        public const int FRAMEBUFFER = 0x8D40;

        /// <summary>
        /// </summary>
        public const int RENDERBUFFER = 0x8D41;

        /// <summary>
        /// </summary>
        public const int RGBA4 = 0x8056;

        /// <summary>
        /// </summary>
        public const int RGB5_A1 = 0x8057;

        /// <summary>
        /// </summary>
        public const int RGB565 = 0x8D62;

        /// <summary>
        /// </summary>
        public const int DEPTH_COMPONENT16 = 0x81A5;

        /// <summary>
        /// </summary>
        public const int STENCIL_INDEX = 0x1901;

        /// <summary>
        /// </summary>
        public const int STENCIL_INDEX8 = 0x8D48;

        /// <summary>
        /// </summary>
        public const int DEPTH_STENCIL = 0x84F9;

        /// <summary>
        /// </summary>
        public const int RENDERBUFFER_WIDTH = 0x8D42;

        /// <summary>
        /// </summary>
        public const int RENDERBUFFER_HEIGHT = 0x8D43;

        /// <summary>
        /// </summary>
        public const int RENDERBUFFER_INTERNAL_FORMAT = 0x8D44;

        /// <summary>
        /// </summary>
        public const int RENDERBUFFER_RED_SIZE = 0x8D50;

        /// <summary>
        /// </summary>
        public const int RENDERBUFFER_GREEN_SIZE = 0x8D51;

        /// <summary>
        /// </summary>
        public const int RENDERBUFFER_BLUE_SIZE = 0x8D52;

        /// <summary>
        /// </summary>
        public const int RENDERBUFFER_ALPHA_SIZE = 0x8D53;

        /// <summary>
        /// </summary>
        public const int RENDERBUFFER_DEPTH_SIZE = 0x8D54;

        /// <summary>
        /// </summary>
        public const int RENDERBUFFER_STENCIL_SIZE = 0x8D55;

        /// <summary>
        /// </summary>
        public const int FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE = 0x8CD0;

        /// <summary>
        /// </summary>
        public const int FRAMEBUFFER_ATTACHMENT_OBJECT_NAME = 0x8CD1;

        /// <summary>
        /// </summary>
        public const int FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL = 0x8CD2;

        /// <summary>
        /// </summary>
        public const int FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE = 0x8CD3;

        /// <summary>
        /// </summary>
        public const int COLOR_ATTACHMENT0 = 0x8CE0;

        /// <summary>
        /// </summary>
        public const int DEPTH_ATTACHMENT = 0x8D00;

        /// <summary>
        /// </summary>
        public const int STENCIL_ATTACHMENT = 0x8D20;

        /// <summary>
        /// </summary>
        public const int DEPTH_STENCIL_ATTACHMENT = 0x821A;

        /// <summary>
        /// </summary>
        public const int NONE = 0;

        /// <summary>
        /// </summary>
        public const int FRAMEBUFFER_COMPLETE = 0x8CD5;

        /// <summary>
        /// </summary>
        public const int FRAMEBUFFER_INCOMPLETE_ATTACHMENT = 0x8CD6;

        /// <summary>
        /// </summary>
        public const int FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT = 0x8CD7;

        /// <summary>
        /// </summary>
        public const int FRAMEBUFFER_INCOMPLETE_DIMENSIONS = 0x8CD9;

        /// <summary>
        /// </summary>
        public const int FRAMEBUFFER_UNSUPPORTED = 0x8CDD;

        /// <summary>
        /// </summary>
        public const int FRAMEBUFFER_BINDING = 0x8CA6;

        /// <summary>
        /// </summary>
        public const int RENDERBUFFER_BINDING = 0x8CA7;

        /// <summary>
        /// </summary>
        public const int MAX_RENDERBUFFER_SIZE = 0x84E8;

        /// <summary>
        /// </summary>
        public const int INVALID_FRAMEBUFFER_OPERATION = 0x0506;

        /* WebGL-specific enums */

        /// <summary>
        /// </summary>
        public const int UNPACK_FLIP_Y_WEBGL = 0x9240;

        /// <summary>
        /// </summary>
        public const int UNPACK_PREMULTIPLY_ALPHA_WEBGL = 0x9241;

        /// <summary>
        /// </summary>
        public const int CONTEXT_LOST_WEBGL = 0x9242;

        /// <summary>
        /// </summary>
        public const int UNPACK_COLORSPACE_CONVERSION_WEBGL = 0x9243;

        /// <summary>
        /// </summary>
        public const int BROWSER_DEFAULT_WEBGL = 0x9244;

        // IGL_EXT_texture_filter_anisotropic
        /// <summary>
        /// </summary>
        public const int TEXTURE_MAX_ANISOTROPY_EXT = 0x84FE;

        /// <summary>
        /// </summary>
        public const int MAX_TEXTURE_MAX_ANISOTROPY_EXT = 0x84FF;
    }
}