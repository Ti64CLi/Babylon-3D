using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class ShadowGenerator {
private static dynamic _FILTER_NONE=0;
private static dynamic _FILTER_VARIANCESHADOWMAP=1;
private static dynamic _FILTER_POISSONSAMPLING=2;
public dynamic filter=ShadowGenerator.FILTER_VARIANCESHADOWMAP;
private DirectionalLight _light;
private Scene _scene;
private RenderTargetTexture _shadowMap;
private dynamic _darkness=0;
private dynamic _transparencyShadow=false;
private Effect _effect;
private dynamic _viewMatrix=BABYLON.Matrix.Zero();
private dynamic _projectionMatrix=BABYLON.Matrix.Zero();
private dynamic _transformMatrix=BABYLON.Matrix.Zero();
private dynamic _worldViewProjection=BABYLON.Matrix.Zero();
private Vector3 _cachedPosition;
private Vector3 _cachedDirection;
private string _cachedDefines;
public ShadowGenerator(float mapSize, DirectionalLight light) {
this._light=light;
this._scene=light.getScene();
light._shadowGenerator=this;
this._shadowMap=new BABYLON.RenderTargetTexture(light.name+"_shadowMa", mapSize, this._scene, false);
this._shadowMap.wrapU=BABYLON.Texture.CLAMP_ADDRESSMODE;
this._shadowMap.wrapV=BABYLON.Texture.CLAMP_ADDRESSMODE;
this._shadowMap.renderParticles=false;
var renderSubMesh = (SubMesh subMesh) => {
var mesh = subMesh.getRenderingMesh();
var scene = this._scene;
var engine = scene.getEngine();
engine.setState(subMesh.getMaterial().backFaceCulling);
var batch = mesh._getInstancesRenderList(subMesh._id);
if (batch.mustReturn) 
{
return;
}
var hardwareInstancedRendering = (engine.getCaps().instancedArrays!=null)&&(batch.visibleInstances!=null);
if (this.isReady(subMesh, hardwareInstancedRendering)) 
{
engine.enableEffect(this._effect);
mesh._bind(subMesh, this._effect, false);
var material = subMesh.getMaterial();
this._effect.setMatrix("viewProjectio", this.getTransformMatrix());
if (material&&material.needAlphaTesting()) 
{
var alphaTexture = material.getAlphaTestTexture();
this._effect.setTexture("diffuseSample", alphaTexture);
this._effect.setMatrix("diffuseMatri", alphaTexture.getTextureMatrix());
}
var useBones = mesh.skeleton&&mesh.isVerticesDataPresent(BABYLON.VertexBuffer.MatricesIndicesKind)&&mesh.isVerticesDataPresent(BABYLON.VertexBuffer.MatricesWeightsKind);
if (useBones) 
{
this._effect.setMatrices("mBone", mesh.skeleton.getTransformMatrices());
}
if (hardwareInstancedRendering) 
{
mesh._renderWithInstances(subMesh, false, batch, this._effect, engine);
}
else 
{
if (batch.renderSelf[subMesh._id]) 
{
this._effect.setMatrix("worl", mesh.getWorldMatrix());
mesh._draw(subMesh, true);
}
if (batch.visibleInstances[subMesh._id]) 
{
for (var instanceIndex = 0;instanceIndex<batch.visibleInstances[subMesh._id].length;instanceIndex++) 
{
var instance = batch.visibleInstances[subMesh._id][instanceIndex];
this._effect.setMatrix("worl", instance.getWorldMatrix());
mesh._draw(subMesh, true);
}
}
}
}
else 
{
this._shadowMap.resetRefreshCounter();
}
}
;
this._shadowMap.customRenderFunction=(SmartArray<SubMesh> opaqueSubMeshes, SmartArray<SubMesh> alphaTestSubMeshes, SmartArray<SubMesh> transparentSubMeshes) => {
var index;
for (index=0;index<opaqueSubMeshes.length;index++) 
{
renderSubMesh(opaqueSubMeshes.data[index]);
}
for (index=0;index<alphaTestSubMeshes.length;index++) 
{
renderSubMesh(alphaTestSubMeshes.data[index]);
}
if (this._transparencyShadow) 
{
for (index=0;index<transparentSubMeshes.length;index++) 
{
renderSubMesh(transparentSubMeshes.data[index]);
}
}
}
;
}
public virtual bool isReady(SubMesh subMesh, bool useInstances) {
var defines = new Array<object>();
if (this.useVarianceShadowMap) 
{
defines.push("#define VS");
}
var attribs = new Array<object>();
var mesh = subMesh.getMesh();
var material = subMesh.getMaterial();
if (material&&material.needAlphaTesting()) 
{
defines.push("#define ALPHATES");
if (mesh.isVerticesDataPresent(BABYLON.VertexBuffer.UVKind)) 
{
attribs.push(BABYLON.VertexBuffer.UVKind);
defines.push("#define UV");
}
if (mesh.isVerticesDataPresent(BABYLON.VertexBuffer.UV2Kind)) 
{
attribs.push(BABYLON.VertexBuffer.UV2Kind);
defines.push("#define UV");
}
}
if (mesh.skeleton&&mesh.isVerticesDataPresent(BABYLON.VertexBuffer.MatricesIndicesKind)&&mesh.isVerticesDataPresent(BABYLON.VertexBuffer.MatricesWeightsKind)) 
{
attribs.push(BABYLON.VertexBuffer.MatricesIndicesKind);
attribs.push(BABYLON.VertexBuffer.MatricesWeightsKind);
defines.push("#define BONE");
defines.push("#define BonesPerMesh"+(mesh.skeleton.bones.length+1));
}
if (useInstances) 
{
defines.push("#define INSTANCE");
attribs.push("world");
attribs.push("world");
attribs.push("world");
attribs.push("world");
}
var join = defines.join("\\");
if (this._cachedDefines!=join) 
{
this._cachedDefines=join;
this._effect=this._scene.getEngine().createEffect("shadowMa", attribs, new Array<object>(), new Array<object>(), join);
}
return this._effect.isReady();
}
public virtual RenderTargetTexture getShadowMap() {
return this._shadowMap;
}
public virtual DirectionalLight getLight() {
return this._light;
}
public virtual Matrix getTransformMatrix() {
var lightPosition = this._light.position;
var lightDirection = this._light.direction;
if (this._light._computeTransformedPosition()) 
{
lightPosition=this._light._transformedPosition;
}
if (!this._cachedPosition||!this._cachedDirection||!lightPosition.equals(this._cachedPosition)||!lightDirection.equals(this._cachedDirection)) 
{
this._cachedPosition=lightPosition.clone();
this._cachedDirection=lightDirection.clone();
var activeCamera = this._scene.activeCamera;
BABYLON.Matrix.LookAtLHToRef(lightPosition, this._light.position.add(lightDirection), BABYLON.Vector3.Up(), this._viewMatrix);
BABYLON.Matrix.PerspectiveFovLHToRef(Math.PI/2.0, 1.0, activeCamera.minZ, activeCamera.maxZ, this._projectionMatrix);
this._viewMatrix.multiplyToRef(this._projectionMatrix, this._transformMatrix);
}
return this._transformMatrix;
}
public virtual float getDarkness() {
return this._darkness;
}
public virtual void setDarkness(float darkness) {
if (darkness>=1.0) 
this._darkness=1.0;
else 
if (darkness<=0.0) 
this._darkness=0.0;
else 
this._darkness=darkness;
}
public virtual void setTransparencyShadow(bool hasShadow) {
this._transparencyShadow=hasShadow;
}
public virtual void dispose() {
this._shadowMap.dispose();
}
}
}
