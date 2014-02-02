document.addEventListener("DOMContentLoaded", function () {
    onload();
}, false);

var onload = function () {
    var canvas = document.getElementById("renderCanvas");

    // Babylon
    var engine = new BABYLON.Engine(canvas, true);
    var scene = new BABYLON.Scene(engine);

    defaultVertexShader = 
	"#ifdef GL_ES\n"+
	"precision mediump float;\n"+
	"#endif\n"+
	"\n"+
	"// Attributes\n"+
	"attribute vec3 position;\n"+
	"attribute vec3 normal;\n"+
	"#ifdef UV1\n"+
	"attribute vec2 uv;\n"+
	"#endif\n"+
	"#ifdef UV2\n"+
	"attribute vec2 uv2;\n"+
	"#endif\n"+
	"#ifdef VERTEXCOLOR\n"+
	"attribute vec3 color;\n"+
	"#endif\n"+
	"#ifdef BONES\n"+
	"attribute vec4 matricesIndices;\n"+
	"attribute vec4 matricesWeights;\n"+
	"#endif\n"+
	"\n"+
	"// Uniforms\n"+
	"uniform mat4 world;\n"+
	"uniform mat4 view;\n"+
	"uniform mat4 viewProjection;\n"+
	"\n"+
	"#ifdef DIFFUSE\n"+
	"varying vec2 vDiffuseUV;\n"+
	"uniform mat4 diffuseMatrix;\n"+
	"uniform vec2 vDiffuseInfos;\n"+
	"#endif\n"+
	"\n"+
	"#ifdef AMBIENT\n"+
	"varying vec2 vAmbientUV;\n"+
	"uniform mat4 ambientMatrix;\n"+
	"uniform vec2 vAmbientInfos;\n"+
	"#endif\n"+
	"\n"+
	"#ifdef OPACITY\n"+
	"varying vec2 vOpacityUV;\n"+
	"uniform mat4 opacityMatrix;\n"+
	"uniform vec2 vOpacityInfos;\n"+
	"#endif\n"+
	"\n"+
	"#ifdef EMISSIVE\n"+
	"varying vec2 vEmissiveUV;\n"+
	"uniform vec2 vEmissiveInfos;\n"+
	"uniform mat4 emissiveMatrix;\n"+
	"#endif\n"+
	"\n"+
	"#ifdef SPECULAR\n"+
	"varying vec2 vSpecularUV;\n"+
	"uniform vec2 vSpecularInfos;\n"+
	"uniform mat4 specularMatrix;\n"+
	"#endif\n"+
	"\n"+
	"#ifdef BUMP\n"+
	"varying vec2 vBumpUV;\n"+
	"uniform vec2 vBumpInfos;\n"+
	"uniform mat4 bumpMatrix;\n"+
	"#endif\n"+
	"\n"+
	"#ifdef BONES\n"+
	"uniform mat4 mBones[BonesPerMesh];\n"+
	"#endif\n"+
	"\n"+
	"// Output\n"+
	"varying vec3 vPositionW;\n"+
	"varying vec3 vNormalW;\n"+
	"\n"+
	"#ifdef VERTEXCOLOR\n"+
	"varying vec3 vColor;\n"+
	"#endif\n"+
	"\n"+
	"#ifdef CLIPPLANE\n"+
	"uniform vec4 vClipPlane;\n"+
	"varying float fClipDistance;\n"+
	"#endif\n"+
	"\n"+
	"#ifdef FOG\n"+
	"varying float fFogDistance;\n"+
	"#endif\n"+
	"\n"+
	"#ifdef SHADOWS\n"+
	"#ifdef LIGHT0\n"+
	"uniform mat4 lightMatrix0;\n"+
	"varying vec4 vPositionFromLight0;\n"+
	"#endif\n"+
	"#ifdef LIGHT1\n"+
	"uniform mat4 lightMatrix1;\n"+
	"varying vec4 vPositionFromLight1;\n"+
	"#endif\n"+
	"#ifdef LIGHT2\n"+
	"uniform mat4 lightMatrix2;\n"+
	"varying vec4 vPositionFromLight2;\n"+
	"#endif\n"+
	"#ifdef LIGHT3\n"+
	"uniform mat4 lightMatrix3;\n"+
	"varying vec4 vPositionFromLight3;\n"+
	"#endif\n"+
	"#endif\n"+
	"\n"+
	"#ifdef REFLECTION\n"+
	"varying vec3 vPositionUVW;\n"+
	"#endif\n"+
	"\n"+
	"void main(void) {\n"+
	"	mat4 finalWorld;\n"+
	"\n"+
	"#ifdef REFLECTION\n"+
	"	vPositionUVW = position;\n"+
	"#endif \n"+
	"\n"+
	"#ifdef BONES\n"+
	"	mat4 m0 = mBones[int(matricesIndices.x)] * matricesWeights.x;\n"+
	"	mat4 m1 = mBones[int(matricesIndices.y)] * matricesWeights.y;\n"+
	"	mat4 m2 = mBones[int(matricesIndices.z)] * matricesWeights.z;\n"+
	"\n"+
	"#ifdef BONES4\n"+
	"	mat4 m3 = mBones[int(matricesIndices.w)] * matricesWeights.w;\n"+
	"	finalWorld = world * (m0 + m1 + m2 + m3);\n"+
	"#else\n"+
	"	finalWorld = world * (m0 + m1 + m2);\n"+
	"#endif \n"+
	"\n"+
	"#else\n"+
	"	finalWorld = world;\n"+
	"#endif\n"+
	"	gl_Position = viewProjection * finalWorld * vec4(position, 1.0);\n"+
	"\n"+
	"	vec4 worldPos = finalWorld * vec4(position, 1.0);\n"+
	"	vPositionW = vec3(worldPos);\n"+
	"	vNormalW = normalize(vec3(finalWorld * vec4(normal, 0.0)));\n"+
	"\n"+
	"	// Texture coordinates\n"+
	"#ifndef UV1\n"+
	"	vec2 uv = vec2(0., 0.);\n"+
	"#endif\n"+
	"#ifndef UV2\n"+
	"	vec2 uv2 = vec2(0., 0.);\n"+
	"#endif\n"+
	"\n"+
	"#ifdef DIFFUSE\n"+
	"	if (vDiffuseInfos.x == 0.)\n"+
	"	{\n"+
	"		vDiffuseUV = vec2(diffuseMatrix * vec4(uv, 1.0, 0.0));\n"+
	"	}\n"+
	"	else\n"+
	"	{\n"+
	"		vDiffuseUV = vec2(diffuseMatrix * vec4(uv2, 1.0, 0.0));\n"+
	"	}\n"+
	"#endif\n"+
	"\n"+
	"#ifdef AMBIENT\n"+
	"	if (vAmbientInfos.x == 0.)\n"+
	"	{\n"+
	"		vAmbientUV = vec2(ambientMatrix * vec4(uv, 1.0, 0.0));\n"+
	"	}\n"+
	"	else\n"+
	"	{\n"+
	"		vAmbientUV = vec2(ambientMatrix * vec4(uv2, 1.0, 0.0));\n"+
	"	}\n"+
	"#endif\n"+
	"\n"+
	"#ifdef OPACITY\n"+
	"	if (vOpacityInfos.x == 0.)\n"+
	"	{\n"+
	"		vOpacityUV = vec2(opacityMatrix * vec4(uv, 1.0, 0.0));\n"+
	"	}\n"+
	"	else\n"+
	"	{\n"+
	"		vOpacityUV = vec2(opacityMatrix * vec4(uv2, 1.0, 0.0));\n"+
	"	}\n"+
	"#endif\n"+
	"\n"+
	"#ifdef EMISSIVE\n"+
	"	if (vEmissiveInfos.x == 0.)\n"+
	"	{\n"+
	"		vEmissiveUV = vec2(emissiveMatrix * vec4(uv, 1.0, 0.0));\n"+
	"	}\n"+
	"	else\n"+
	"	{\n"+
	"		vEmissiveUV = vec2(emissiveMatrix * vec4(uv2, 1.0, 0.0));\n"+
	"	}\n"+
	"#endif\n"+
	"\n"+
	"#ifdef SPECULAR\n"+
	"	if (vSpecularInfos.x == 0.)\n"+
	"	{\n"+
	"		vSpecularUV = vec2(specularMatrix * vec4(uv, 1.0, 0.0));\n"+
	"	}\n"+
	"	else\n"+
	"	{\n"+
	"		vSpecularUV = vec2(specularMatrix * vec4(uv2, 1.0, 0.0));\n"+
	"	}\n"+
	"#endif\n"+
	"\n"+
	"#ifdef BUMP\n"+
	"	if (vBumpInfos.x == 0.)\n"+
	"	{\n"+
	"		vBumpUV = vec2(bumpMatrix * vec4(uv, 1.0, 0.0));\n"+
	"	}\n"+
	"	else\n"+
	"	{\n"+
	"		vBumpUV = vec2(bumpMatrix * vec4(uv2, 1.0, 0.0));\n"+
	"	}\n"+
	"#endif\n"+
	"\n"+
	"	// Clip plane\n"+
	"#ifdef CLIPPLANE\n"+
	"	fClipDistance = dot(worldPos, vClipPlane);\n"+
	"#endif\n"+
	"\n"+
	"	// Fog\n"+
	"#ifdef FOG\n"+
	"	fFogDistance = (view * worldPos).z;\n"+
	"#endif\n"+
	"\n"+
	"	// Shadows\n"+
	"#ifdef SHADOWS\n"+
	"#ifdef LIGHT0\n"+
	"	vPositionFromLight0 = lightMatrix0 * vec4(position, 1.0);\n"+
	"#endif\n"+
	"#ifdef LIGHT1\n"+
	"	vPositionFromLight1 = lightMatrix1 * vec4(position, 1.0);\n"+
	"#endif\n"+
	"#ifdef LIGHT2\n"+
	"	vPositionFromLight2 = lightMatrix2 * vec4(position, 1.0);\n"+
	"#endif\n"+
	"#ifdef LIGHT3\n"+
	"	vPositionFromLight3 = lightMatrix3 * vec4(position, 1.0);\n"+
	"#endif\n"+
	"#endif\n"+
	"\n"+
	"	// Vertex color\n"+
	"#ifdef VERTEXCOLOR\n"+
	"	vColor = color;\n"+
	"#endif\n"+
	"}";

	defaultPixelShader = "#ifdef GL_ES\n"+
	"precision mediump float;\n"+
	"#endif\n"+
	"\n"+
	"#define MAP_EXPLICIT	0.\n"+
	"#define MAP_SPHERICAL	1.\n"+
	"#define MAP_PLANAR		2.\n"+
	"#define MAP_CUBIC		3.\n"+
	"#define MAP_PROJECTION	4.\n"+
	"#define MAP_SKYBOX		5.\n"+
	"\n"+
	"// Constants\n"+
	"uniform vec3 vEyePosition;\n"+
	"uniform vec3 vAmbientColor;\n"+
	"uniform vec4 vDiffuseColor;\n"+
	"uniform vec4 vSpecularColor;\n"+
	"uniform vec3 vEmissiveColor;\n"+
	"\n"+
	"// Input\n"+
	"varying vec3 vPositionW;\n"+
	"varying vec3 vNormalW;\n"+
	"\n"+
	"#ifdef VERTEXCOLOR\n"+
	"varying vec3 vColor;\n"+
	"#endif\n"+
	"\n"+
	"// Lights\n"+
	"#ifdef LIGHT0\n"+
	"uniform vec4 vLightData0;\n"+
	"uniform vec3 vLightDiffuse0;\n"+
	"uniform vec3 vLightSpecular0;\n"+
	"#ifdef SHADOW0\n"+
	"varying vec4 vPositionFromLight0;\n"+
	"uniform sampler2D shadowSampler0;\n"+
	"#endif\n"+
	"#ifdef SPOTLIGHT0\n"+
	"uniform vec4 vLightDirection0;\n"+
	"#endif\n"+
	"#ifdef HEMILIGHT0\n"+
	"uniform vec3 vLightGround0;\n"+
	"#endif\n"+
	"#endif\n"+
	"\n"+
	"#ifdef LIGHT1\n"+
	"uniform vec4 vLightData1;\n"+
	"uniform vec3 vLightDiffuse1;\n"+
	"uniform vec3 vLightSpecular1;\n"+
	"#ifdef SHADOW1\n"+
	"varying vec4 vPositionFromLight1;\n"+
	"uniform sampler2D shadowSampler1;\n"+
	"#endif\n"+
	"#ifdef SPOTLIGHT1\n"+
	"uniform vec4 vLightDirection1;\n"+
	"#endif\n"+
	"#ifdef HEMILIGHT1\n"+
	"uniform vec3 vLightGround1;\n"+
	"#endif\n"+
	"#endif\n"+
	"\n"+
	"#ifdef LIGHT2\n"+
	"uniform vec4 vLightData2;\n"+
	"uniform vec3 vLightDiffuse2;\n"+
	"uniform vec3 vLightSpecular2;\n"+
	"#ifdef SHADOW2\n"+
	"varying vec4 vPositionFromLight2;\n"+
	"uniform sampler2D shadowSampler2;\n"+
	"#endif\n"+
	"#ifdef SPOTLIGHT2\n"+
	"uniform vec4 vLightDirection2;\n"+
	"#endif\n"+
	"#ifdef HEMILIGHT2\n"+
	"uniform vec3 vLightGround2;\n"+
	"#endif\n"+
	"#endif\n"+
	"\n"+
	"#ifdef LIGHT3\n"+
	"uniform vec4 vLightData3;\n"+
	"uniform vec3 vLightDiffuse3;\n"+
	"uniform vec3 vLightSpecular3;\n"+
	"#ifdef SHADOW3\n"+
	"varying vec4 vPositionFromLight3;\n"+
	"uniform sampler2D shadowSampler3;\n"+
	"#endif\n"+
	"#ifdef SPOTLIGHT3\n"+
	"uniform vec4 vLightDirection3;\n"+
	"#endif\n"+
	"#ifdef HEMILIGHT3\n"+
	"uniform vec3 vLightGround3;\n"+
	"#endif\n"+
	"#endif\n"+
	"\n"+
	"// Samplers\n"+
	"#ifdef DIFFUSE\n"+
	"varying vec2 vDiffuseUV;\n"+
	"uniform sampler2D diffuseSampler;\n"+
	"uniform vec2 vDiffuseInfos;\n"+
	"#endif\n"+
	"\n"+
	"#ifdef AMBIENT\n"+
	"varying vec2 vAmbientUV;\n"+
	"uniform sampler2D ambientSampler;\n"+
	"uniform vec2 vAmbientInfos;\n"+
	"#endif\n"+
	"\n"+
	"#ifdef OPACITY	\n"+
	"varying vec2 vOpacityUV;\n"+
	"uniform sampler2D opacitySampler;\n"+
	"uniform vec2 vOpacityInfos;\n"+
	"#endif\n"+
	"\n"+
	"#ifdef EMISSIVE\n"+
	"varying vec2 vEmissiveUV;\n"+
	"uniform vec2 vEmissiveInfos;\n"+
	"uniform sampler2D emissiveSampler;\n"+
	"#endif\n"+
	"\n"+
	"#ifdef SPECULAR\n"+
	"varying vec2 vSpecularUV;\n"+
	"uniform vec2 vSpecularInfos;\n"+
	"uniform sampler2D specularSampler;\n"+
	"#endif\n"+
	"\n"+
	"// Reflection\n"+
	"#ifdef REFLECTION\n"+
	"varying vec3 vPositionUVW;\n"+
	"uniform samplerCube reflectionCubeSampler;\n"+
	"uniform sampler2D reflection2DSampler;\n"+
	"uniform vec3 vReflectionInfos;\n"+
	"uniform mat4 reflectionMatrix;\n"+
	"uniform mat4 view;\n"+
	"\n"+
	"vec3 computeReflectionCoords(float mode, vec4 worldPos, vec3 worldNormal)\n"+
	"{\n"+
	"	if (mode == MAP_SPHERICAL)\n"+
	"	{\n"+
	"		vec3 coords = vec3(view * vec4(worldNormal, 0.0));\n"+
	"\n"+
	"		return vec3(reflectionMatrix * vec4(coords, 1.0));\n"+
	"	}\n"+
	"	else if (mode == MAP_PLANAR)\n"+
	"	{\n"+
	"		vec3 viewDir = worldPos.xyz - vEyePosition;\n"+
	"		vec3 coords = normalize(reflect(viewDir, worldNormal));\n"+
	"\n"+
	"		return vec3(reflectionMatrix * vec4(coords, 1));\n"+
	"	}\n"+
	"	else if (mode == MAP_CUBIC)\n"+
	"	{\n"+
	"		vec3 viewDir = worldPos.xyz - vEyePosition;\n"+
	"		vec3 coords = reflect(viewDir, worldNormal);\n"+
	"\n"+
	"		return vec3(reflectionMatrix * vec4(coords, 0));\n"+
	"	}\n"+
	"	else if (mode == MAP_PROJECTION)\n"+
	"	{\n"+
	"		return vec3(reflectionMatrix * (view * worldPos));\n"+
	"	}\n"+
	"	else if (mode == MAP_SKYBOX)\n"+
	"	{\n"+
	"		return vPositionUVW;\n"+
	"	}\n"+
	"\n"+
	"	return vec3(0, 0, 0);\n"+
	"}\n"+
	"#endif\n"+
	"\n"+
	"// Shadows\n"+
	"#ifdef SHADOWS\n"+
	"\n"+
	"float unpack(vec4 color)\n"+
	"{\n"+
	"	const vec4 bitShift = vec4(1. / (255. * 255. * 255.), 1. / (255. * 255.), 1. / 255., 1.);\n"+
	"	return dot(color, bitShift);\n"+
	"}\n"+
	"\n"+
	"float unpackHalf(vec2 color)\n"+
	"{\n"+
	"	return color.x + (color.y / 255.0);\n"+
	"}\n"+
	"\n"+
	"float computeShadow(vec4 vPositionFromLight, sampler2D shadowSampler)\n"+
	"{\n"+
	"	vec3 depth = vPositionFromLight.xyz / vPositionFromLight.w;\n"+
	"	vec2 uv = 0.5 * depth.xy + vec2(0.5, 0.5);\n"+
	"\n"+
	"	if (uv.x < 0. || uv.x > 1.0 || uv.y < 0. || uv.y > 1.0)\n"+
	"	{\n"+
	"		return 1.0;\n"+
	"	}\n"+
	"\n"+
	"	float shadow = unpack(texture2D(shadowSampler, uv));\n"+
	"\n"+
	"	if (depth.z > shadow)\n"+
	"	{\n"+
	"		return 0.;\n"+
	"	}\n"+
	"	return 1.;\n"+
	"}\n"+
	"\n"+
	"// Thanks to http://devmaster.net/\n"+
	"float ChebychevInequality(vec2 moments, float t)\n"+
	"{\n"+
	"	if (t <= moments.x)\n"+
	"	{\n"+
	"		return 1.0;\n"+
	"	}\n"+
	"\n"+
	"	float variance = moments.y - (moments.x * moments.x);\n"+
	"	variance = max(variance, 0.);\n"+
	"\n"+
	"	float d = t - moments.x;\n"+
	"	return variance / (variance + d * d);\n"+
	"}\n"+
	"\n"+
	"float computeShadowWithVSM(vec4 vPositionFromLight, sampler2D shadowSampler)\n"+
	"{\n"+
	"	vec3 depth = vPositionFromLight.xyz / vPositionFromLight.w;\n"+
	"	vec2 uv = 0.5 * depth.xy + vec2(0.5, 0.5);\n"+
	"\n"+
	"	if (uv.x < 0. || uv.x > 1.0 || uv.y < 0. || uv.y > 1.0)\n"+
	"	{\n"+
	"		return 1.0;\n"+
	"	}\n"+
	"\n"+
	"	vec4 texel = texture2D(shadowSampler, uv);\n"+
	"\n"+
	"	vec2 moments = vec2(unpackHalf(texel.xy), unpackHalf(texel.zw));\n"+
	"	return clamp(1.3 - ChebychevInequality(moments, depth.z), 0., 1.0);\n"+
	"}\n"+
	"#endif\n"+
	"\n"+
	"// Bump\n"+
	"#ifdef BUMP\n"+
	"#extension GL_OES_standard_derivatives : enable\n"+
	"varying vec2 vBumpUV;\n"+
	"uniform vec2 vBumpInfos;\n"+
	"uniform sampler2D bumpSampler;\n"+
	"\n"+
	"// Thanks to http://www.thetenthplanet.de/archives/1180\n"+
	"mat3 cotangent_frame(vec3 normal, vec3 p, vec2 uv)\n"+
	"{\n"+
	"	// get edge vectors of the pixel triangle\n"+
	"	vec3 dp1 = dFdx(p);\n"+
	"	vec3 dp2 = dFdy(p);\n"+
	"	vec2 duv1 = dFdx(uv);\n"+
	"	vec2 duv2 = dFdy(uv);\n"+
	"\n"+
	"	// solve the linear system\n"+
	"	vec3 dp2perp = cross(dp2, normal);\n"+
	"	vec3 dp1perp = cross(normal, dp1);\n"+
	"	vec3 tangent = dp2perp * duv1.x + dp1perp * duv2.x;\n"+
	"	vec3 binormal = dp2perp * duv1.y + dp1perp * duv2.y;\n"+
	"\n"+
	"	// construct a scale-invariant frame \n"+
	"	float invmax = inversesqrt(max(dot(tangent, tangent), dot(binormal, binormal)));\n"+
	"	return mat3(tangent * invmax, binormal * invmax, normal);\n"+
	"}\n"+
	"\n"+
	"vec3 perturbNormal(vec3 viewDir)\n"+
	"{\n"+
	"	vec3 map = texture2D(bumpSampler, vBumpUV).xyz * vBumpInfos.y;\n"+
	"	map = map * 255. / 127. - 128. / 127.;\n"+
	"	mat3 TBN = cotangent_frame(vNormalW, -viewDir, vBumpUV);\n"+
	"	return normalize(TBN * map);\n"+
	"}\n"+
	"#endif\n"+
	"\n"+
	"#ifdef CLIPPLANE\n"+
	"varying float fClipDistance;\n"+
	"#endif\n"+
	"\n"+
	"// Fog\n"+
	"#ifdef FOG\n"+
	"\n"+
	"#define FOGMODE_NONE    0.\n"+
	"#define FOGMODE_EXP     1.\n"+
	"#define FOGMODE_EXP2    2.\n"+
	"#define FOGMODE_LINEAR  3.\n"+
	"#define E 2.71828\n"+
	"\n"+
	"uniform vec4 vFogInfos;\n"+
	"uniform vec3 vFogColor;\n"+
	"varying float fFogDistance;\n"+
	"\n"+
	"float CalcFogFactor()\n"+
	"{\n"+
	"	float fogCoeff = 1.0;\n"+
	"	float fogStart = vFogInfos.y;\n"+
	"	float fogEnd = vFogInfos.z;\n"+
	"	float fogDensity = vFogInfos.w;\n"+
	"\n"+
	"	if (FOGMODE_LINEAR == vFogInfos.x)\n"+
	"	{\n"+
	"		fogCoeff = (fogEnd - fFogDistance) / (fogEnd - fogStart);\n"+
	"	}\n"+
	"	else if (FOGMODE_EXP == vFogInfos.x)\n"+
	"	{\n"+
	"		fogCoeff = 1.0 / pow(E, fFogDistance * fogDensity);\n"+
	"	}\n"+
	"	else if (FOGMODE_EXP2 == vFogInfos.x)\n"+
	"	{\n"+
	"		fogCoeff = 1.0 / pow(E, fFogDistance * fFogDistance * fogDensity * fogDensity);\n"+
	"	}\n"+
	"\n"+
	"	return clamp(fogCoeff, 0.0, 1.0);\n"+
	"}\n"+
	"#endif\n"+
	"\n"+
	"// Light Computing\n"+
	"struct lightingInfo\n"+
	"{\n"+
	"	vec3 diffuse;\n"+
	"	vec3 specular;\n"+
	"};\n"+
	"\n"+
	"lightingInfo computeLighting(vec3 viewDirectionW, vec3 vNormal, vec4 lightData, vec3 diffuseColor, vec3 specularColor) {\n"+
	"	lightingInfo result;\n"+
	"\n"+
	"	vec3 lightVectorW;\n"+
	"	if (lightData.w == 0.)\n"+
	"	{\n"+
	"		lightVectorW = normalize(lightData.xyz - vPositionW);\n"+
	"	}\n"+
	"	else\n"+
	"	{\n"+
	"		lightVectorW = normalize(-lightData.xyz);\n"+
	"	}\n"+
	"\n"+
	"	// diffuse\n"+
	"	float ndl = max(0., dot(vNormal, lightVectorW));\n"+
	"\n"+
	"	// Specular\n"+
	"	vec3 angleW = normalize(viewDirectionW + lightVectorW);\n"+
	"	float specComp = max(0., dot(vNormal, angleW));\n"+
	"	specComp = pow(specComp, vSpecularColor.a);\n"+
	"\n"+
	"	result.diffuse = ndl * diffuseColor;\n"+
	"	result.specular = specComp * specularColor;\n"+
	"\n"+
	"	return result;\n"+
	"}\n"+
	"\n"+
	"lightingInfo computeSpotLighting(vec3 viewDirectionW, vec3 vNormal, vec4 lightData, vec4 lightDirection, vec3 diffuseColor, vec3 specularColor) {\n"+
	"	lightingInfo result;\n"+
	"\n"+
	"	vec3 lightVectorW = normalize(lightData.xyz - vPositionW);\n"+
	"\n"+
	"	// diffuse\n"+
	"	float cosAngle = max(0., dot(-lightDirection.xyz, lightVectorW));\n"+
	"	float spotAtten = 0.0;\n"+
	"\n"+
	"	if (cosAngle >= lightDirection.w)\n"+
	"	{\n"+
	"		cosAngle = max(0., pow(cosAngle, lightData.w));\n"+
	"		spotAtten = max(0., (cosAngle - lightDirection.w) / (1. - cosAngle));\n"+
	"\n"+
	"		// Diffuse\n"+
	"		float ndl = max(0., dot(vNormal, -lightDirection.xyz));\n"+
	"\n"+
	"		// Specular\n"+
	"		vec3 angleW = normalize(viewDirectionW - lightDirection.xyz);\n"+
	"		float specComp = max(0., dot(vNormal, angleW));\n"+
	"		specComp = pow(specComp, vSpecularColor.a);\n"+
	"\n"+
	"		result.diffuse = ndl * spotAtten * diffuseColor;\n"+
	"		result.specular = specComp * specularColor * spotAtten;\n"+
	"\n"+
	"		return result;\n"+
	"	}\n"+
	"\n"+
	"	result.diffuse = vec3(0.);\n"+
	"	result.specular = vec3(0.);\n"+
	"\n"+
	"	return result;\n"+
	"}\n"+
	"\n"+
	"lightingInfo computeHemisphericLighting(vec3 viewDirectionW, vec3 vNormal, vec4 lightData, vec3 diffuseColor, vec3 specularColor, vec3 groundColor) {\n"+
	"	lightingInfo result;\n"+
	"\n"+
	"	// Diffuse\n"+
	"	float ndl = dot(vNormal, lightData.xyz) * 0.5 + 0.5;\n"+
	"\n"+
	"	// Specular\n"+
	"	vec3 angleW = normalize(viewDirectionW + lightData.xyz);\n"+
	"	float specComp = max(0., dot(vNormal, angleW));\n"+
	"	specComp = pow(specComp, vSpecularColor.a);\n"+
	"\n"+
	"	result.diffuse = mix(groundColor, diffuseColor, ndl);\n"+
	"	result.specular = specComp * specularColor;\n"+
	"\n"+
	"	return result;\n"+
	"}\n"+
	"\n"+
	"void main(void) {\n"+
	"	// Clip plane\n"+
	"#ifdef CLIPPLANE\n"+
	"	if (fClipDistance > 0.0)\n"+
	"		discard;\n"+
	"#endif\n"+
	"\n"+
	"	vec3 viewDirectionW = normalize(vEyePosition - vPositionW);\n"+
	"\n"+
	"	// Base color\n"+
	"	vec4 baseColor = vec4(1., 1., 1., 1.);\n"+
	"	vec3 diffuseColor = vDiffuseColor.rgb;\n"+
	"\n"+
	"#ifdef VERTEXCOLOR\n"+
	"	diffuseColor *= vColor;\n"+
	"#endif\n"+
	"\n"+
	"#ifdef DIFFUSE\n"+
	"	baseColor = texture2D(diffuseSampler, vDiffuseUV);\n"+
	"\n"+
	"#ifdef ALPHATEST\n"+
	"	if (baseColor.a < 0.4)\n"+
	"		discard;\n"+
	"#endif\n"+
	"\n"+
	"	baseColor.rgb *= vDiffuseInfos.y;\n"+
	"#endif\n"+
	"\n"+
	"	// Bump\n"+
	"	vec3 normalW = vNormalW;\n"+
	"\n"+
	"#ifdef BUMP\n"+
	"	normalW = perturbNormal(viewDirectionW);\n"+
	"#endif\n"+
	"\n"+
	"	// Ambient color\n"+
	"	vec3 baseAmbientColor = vec3(1., 1., 1.);\n"+
	"\n"+
	"#ifdef AMBIENT\n"+
	"	baseAmbientColor = texture2D(ambientSampler, vAmbientUV).rgb * vAmbientInfos.y;\n"+
	"#endif\n"+
	"\n"+
	"	// Lighting\n"+
	"	vec3 diffuseBase = vec3(0., 0., 0.);\n"+
	"	vec3 specularBase = vec3(0., 0., 0.);\n"+
	"	float shadow = 1.;\n"+
	"\n"+
	"#ifdef LIGHT0\n"+
	"#ifdef SPOTLIGHT0\n"+
	"	lightingInfo info = computeSpotLighting(viewDirectionW, normalW, vLightData0, vLightDirection0, vLightDiffuse0, vLightSpecular0);\n"+
	"#endif\n"+
	"#ifdef HEMILIGHT0\n"+
	"	lightingInfo info = computeHemisphericLighting(viewDirectionW, normalW, vLightData0, vLightDiffuse0, vLightSpecular0, vLightGround0);\n"+
	"#endif\n"+
	"#ifdef POINTDIRLIGHT0\n"+
	"	lightingInfo info = computeLighting(viewDirectionW, normalW, vLightData0, vLightDiffuse0, vLightSpecular0);\n"+
	"#endif\n"+
	"#ifdef SHADOW0\n"+
	"#ifdef SHADOWVSM0\n"+
	"	shadow = computeShadowWithVSM(vPositionFromLight0, shadowSampler0);\n"+
	"#else\n"+
	"	shadow = computeShadow(vPositionFromLight0, shadowSampler0);\n"+
	"#endif\n"+
	"#else\n"+
	"	shadow = 1.;\n"+
	"#endif\n"+
	"	diffuseBase += info.diffuse * shadow;\n"+
	"	specularBase += info.specular * shadow;\n"+
	"#endif\n"+
	"\n"+
	"#ifdef LIGHT1\n"+
	"#ifdef SPOTLIGHT1\n"+
	"	info = computeSpotLighting(viewDirectionW, normalW, vLightData1, vLightDirection1, vLightDiffuse1, vLightSpecular1);\n"+
	"#endif\n"+
	"#ifdef HEMILIGHT1\n"+
	"	info = computeHemisphericLighting(viewDirectionW, normalW, vLightData1, vLightDiffuse1, vLightSpecular1, vLightGround1);\n"+
	"#endif\n"+
	"#ifdef POINTDIRLIGHT1\n"+
	"	info = computeLighting(viewDirectionW, normalW, vLightData1, vLightDiffuse1, vLightSpecular1);\n"+
	"#endif\n"+
	"#ifdef SHADOW1\n"+
	"#ifdef SHADOWVSM1\n"+
	"	shadow = computeShadowWithVSM(vPositionFromLight1, shadowSampler1);\n"+
	"#else\n"+
	"	shadow = computeShadow(vPositionFromLight1, shadowSampler1);\n"+
	"#endif\n"+
	"#else\n"+
	"	shadow = 1.;\n"+
	"#endif\n"+
	"	diffuseBase += info.diffuse * shadow;\n"+
	"	specularBase += info.specular * shadow;\n"+
	"#endif\n"+
	"\n"+
	"#ifdef LIGHT2\n"+
	"#ifdef SPOTLIGHT2\n"+
	"	info = computeSpotLighting(viewDirectionW, normalW, vLightData2, vLightDirection2, vLightDiffuse2, vLightSpecular2);\n"+
	"#endif\n"+
	"#ifdef HEMILIGHT2\n"+
	"	info = computeHemisphericLighting(viewDirectionW, normalW, vLightData2, vLightDiffuse2, vLightSpecular2, vLightGround2);\n"+
	"#endif\n"+
	"#ifdef POINTDIRLIGHT2\n"+
	"	info = computeLighting(viewDirectionW, normalW, vLightData2, vLightDiffuse2, vLightSpecular2);\n"+
	"#endif\n"+
	"#ifdef SHADOW2\n"+
	"#ifdef SHADOWVSM2\n"+
	"	shadow = computeShadowWithVSM(vPositionFromLight2, shadowSampler2);\n"+
	"#else\n"+
	"	shadow = computeShadow(vPositionFromLight2, shadowSampler2);\n"+
	"#endif	\n"+
	"#else\n"+
	"	shadow = 1.;\n"+
	"#endif\n"+
	"	diffuseBase += info.diffuse * shadow;\n"+
	"	specularBase += info.specular * shadow;\n"+
	"#endif\n"+
	"\n"+
	"#ifdef LIGHT3\n"+
	"#ifdef SPOTLIGHT3\n"+
	"	info = computeSpotLighting(viewDirectionW, normalW, vLightData3, vLightDirection3, vLightDiffuse3, vLightSpecular3);\n"+
	"#endif\n"+
	"#ifdef HEMILIGHT3\n"+
	"	info = computeHemisphericLighting(viewDirectionW, normalW, vLightData3, vLightDiffuse3, vLightSpecular3, vLightGround3);\n"+
	"#endif\n"+
	"#ifdef POINTDIRLIGHT3\n"+
	"	info = computeLighting(viewDirectionW, normalW, vLightData3, vLightDiffuse3, vLightSpecular3);\n"+
	"#endif\n"+
	"#ifdef SHADOW3\n"+
	"#ifdef SHADOWVSM3\n"+
	"	shadow = computeShadowWithVSM(vPositionFromLight3, shadowSampler3);\n"+
	"#else\n"+
	"	shadow = computeShadow(vPositionFromLight3, shadowSampler3);\n"+
	"#endif	\n"+
	"#else\n"+
	"	shadow = 1.;\n"+
	"#endif\n"+
	"	diffuseBase += info.diffuse * shadow;\n"+
	"	specularBase += info.specular * shadow;\n"+
	"#endif\n"+
	"\n"+
	"	// Reflection\n"+
	"	vec3 reflectionColor = vec3(0., 0., 0.);\n"+
	"\n"+
	"#ifdef REFLECTION\n"+
	"	vec3 vReflectionUVW = computeReflectionCoords(vReflectionInfos.x, vec4(vPositionW, 1.0), normalW);\n"+
	"\n"+
	"	if (vReflectionInfos.z != 0.0)\n"+
	"	{\n"+
	"		reflectionColor = textureCube(reflectionCubeSampler, vReflectionUVW).rgb * vReflectionInfos.y;\n"+
	"	}\n"+
	"	else\n"+
	"	{\n"+
	"		vec2 coords = vReflectionUVW.xy;\n"+
	"\n"+
	"		if (vReflectionInfos.x == MAP_PROJECTION)\n"+
	"		{\n"+
	"			coords /= vReflectionUVW.z;\n"+
	"		}\n"+
	"\n"+
	"		coords.y = 1.0 - coords.y;\n"+
	"\n"+
	"		reflectionColor = texture2D(reflection2DSampler, coords).rgb * vReflectionInfos.y;\n"+
	"	}\n"+
	"#endif\n"+
	"\n"+
	"	// Alpha\n"+
	"	float alpha = vDiffuseColor.a;\n"+
	"\n"+
	"#ifdef OPACITY\n"+
	"	vec4 opacityMap = texture2D(opacitySampler, vOpacityUV);\n"+
	"	opacityMap.rgb = opacityMap.rgb * vec3(0.3, 0.59, 0.11) * opacityMap.a;\n"+
	"	alpha *= (opacityMap.x + opacityMap.y + opacityMap.z)* vOpacityInfos.y;\n"+
	"#endif\n"+
	"\n"+
	"	// Emissive\n"+
	"	vec3 emissiveColor = vEmissiveColor;\n"+
	"#ifdef EMISSIVE\n"+
	"	emissiveColor += texture2D(emissiveSampler, vEmissiveUV).rgb * vEmissiveInfos.y;\n"+
	"#endif\n"+
	"\n"+
	"	// Specular map\n"+
	"	vec3 specularColor = vSpecularColor.rgb;\n"+
	"#ifdef SPECULAR\n"+
	"	specularColor = texture2D(specularSampler, vSpecularUV).rgb * vSpecularInfos.y;\n"+
	"#endif\n"+
	"\n"+
	"	// Composition\n"+
	"	vec3 finalDiffuse = clamp(diffuseBase * diffuseColor + emissiveColor + vAmbientColor, 0.0, 1.0) * baseColor.rgb;\n"+
	"	vec3 finalSpecular = specularBase * specularColor;\n"+
	"\n"+
	"	vec4 color = vec4(finalDiffuse * baseAmbientColor + finalSpecular + reflectionColor, alpha);\n"+
	"\n"+
	"#ifdef FOG\n"+
	"	float fog = CalcFogFactor();\n"+
	"	color.rgb = fog * color.rgb + (1.0 - fog) * vFogColor;\n"+
	"#endif\n"+
	"\n"+
	"	gl_FragColor = color;\n"+
	"}" ;

	BABYLON.Effect.ShadersStore["defaultVertexShader"] = defaultVertexShader;
	BABYLON.Effect.ShadersStore["defaultPixelShader"] = defaultPixelShader;

  // Creating a camera looking to the zero point (0,0,0), a light, and a sphere of size 1
    var camera = new BABYLON.ArcRotateCamera("Camera", 1, 0.8, 10, new BABYLON.Vector3(0, 0, 0), scene);
    var light0 = new BABYLON.PointLight("Omni", new BABYLON.Vector3(0, 0, 10), scene);
    var origin = BABYLON.Mesh.CreateSphere("origin", 10, 1.0, scene);

    // Attach the camera to the scene
    scene.activeCamera.attachControl(canvas);

    // Once the scene is loaded, just register a render loop to render it
    engine.runRenderLoop(function () {
      scene.render();
    });
};