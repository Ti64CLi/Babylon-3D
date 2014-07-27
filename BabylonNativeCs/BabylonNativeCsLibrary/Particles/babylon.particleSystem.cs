using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
var randomNumber = (float min, float max) => {
if (min==max) 
{
return (min);
}
var random = Math.random();
return ((random*(max-min))+min);
}
;
public class ParticleSystem: IDisposable {
dynamic BLENDMODE_ONEONE=0;
dynamic BLENDMODE_STANDARD=1;
public string id;
dynamic renderingGroupId=0;
dynamic emitter=null;
dynamic emitRate=10;
dynamic manualEmitCount=-1;
dynamic updateSpeed=0.01;
dynamic targetStopDuration=0;
dynamic disposeOnStop=false;
dynamic minEmitPower=1;
dynamic maxEmitPower=1;
dynamic minLifeTime=1;
dynamic maxLifeTime=1;
dynamic minSize=1;
dynamic maxSize=1;
dynamic minAngularSpeed=0;
dynamic maxAngularSpeed=0;
public Texture particleTexture;
public Func<object> onDispose;
dynamic blendMode=BABYLON.ParticleSystem.BLENDMODE_ONEONE;
dynamic forceDepthWrite=false;
dynamic gravity=BABYLON.Vector3.Zero();
dynamic direction1=new BABYLON.Vector3(0, 1.0, 0);
dynamic direction2=new BABYLON.Vector3(0, 1.0, 0);
dynamic minEmitBox=new BABYLON.Vector3(-0.5, -0.5, -0.5);
dynamic maxEmitBox=new BABYLON.Vector3(0.5, 0.5, 0.5);
dynamic color1=new BABYLON.Color4(1.0, 1.0, 1.0, 1.0);
dynamic color2=new BABYLON.Color4(1.0, 1.0, 1.0, 1.0);
dynamic colorDead=new BABYLON.Color4(0, 0, 0, 1.0);
dynamic textureMask=new BABYLON.Color4(1.0, 1.0, 1.0, 1.0);
public Func<float, Matrix, Vector3, object> startDirectionFunction;
public Func<Matrix, Vector3, object> startPositionFunction;
dynamic particles=new Array();
private float _capacity;
private Scene _scene;
dynamic _vertexDeclaration=new Array<object>();
dynamic _vertexStrideSize=11*4;
dynamic _stockParticles=new Array();
dynamic _newPartsExcess=0;
private WebGLBuffer _vertexBuffer;
private WebGLBuffer _indexBuffer;
private Float32Array _vertices;
private Effect _effect;
private string _cachedDefines;
dynamic _scaledColorStep=new BABYLON.Color4(0, 0, 0, 0);
dynamic _colorDiff=new BABYLON.Color4(0, 0, 0, 0);
dynamic _scaledDirection=BABYLON.Vector3.Zero();
dynamic _scaledGravity=BABYLON.Vector3.Zero();
dynamic _currentRenderId=-1;
private bool _alive;
dynamic _started=false;
dynamic _stopped=false;
dynamic _actualFrame=0;
private float _scaledUpdateSpeed;
public string name;
public ParticleSystem(string name, float capacity, Scene scene) {
this.id=name;
this._capacity=capacity;
this._scene=scene;
scene.particleSystems.push(this);
this._vertexBuffer=scene.getEngine().createDynamicVertexBuffer(capacity*this._vertexStrideSize*4);
var indices = new Array<object>();
var index = 0;
for (var count = 0;count<capacity;count++) 
{
indices.push(index);
indices.push(index+1);
indices.push(index+2);
indices.push(index);
indices.push(index+2);
indices.push(index+3);
index+=4;
}
this._indexBuffer=scene.getEngine().createIndexBuffer(indices);
this._vertices=new Float32Array(capacity*this._vertexStrideSize);
this.startDirectionFunction=(float emitPower, Matrix worldMatrix, Vector3 directionToUpdate) => {
var randX = randomNumber(this.direction1.x, this.direction2.x);
var randY = randomNumber(this.direction1.y, this.direction2.y);
var randZ = randomNumber(this.direction1.z, this.direction2.z);
BABYLON.Vector3.TransformNormalFromFloatsToRef(randX*emitPower, randY*emitPower, randZ*emitPower, worldMatrix, directionToUpdate);
}
;
this.startPositionFunction=(Matrix worldMatrix, Vector3 positionToUpdate) => {
var randX = randomNumber(this.minEmitBox.x, this.maxEmitBox.x);
var randY = randomNumber(this.minEmitBox.y, this.maxEmitBox.y);
var randZ = randomNumber(this.minEmitBox.z, this.maxEmitBox.z);
BABYLON.Vector3.TransformCoordinatesFromFloatsToRef(randX, randY, randZ, worldMatrix, positionToUpdate);
}
;
}
public virtual float getCapacity() {
return this._capacity;
}
public virtual bool isAlive() {
return this._alive;
}
public virtual bool isStarted() {
return this._started;
}
public virtual void start() {
this._started=true;
this._stopped=false;
this._actualFrame=0;
}
public virtual void stop() {
this._stopped=true;
}
public virtual void _appendParticleVertex(float index, Particle particle, float offsetX, float offsetY) {
var offset = index*11;
this._vertices[offset]=particle.position.x;
this._vertices[offset+1]=particle.position.y;
this._vertices[offset+2]=particle.position.z;
this._vertices[offset+3]=particle.color.r;
this._vertices[offset+4]=particle.color.g;
this._vertices[offset+5]=particle.color.b;
this._vertices[offset+6]=particle.color.a;
this._vertices[offset+7]=particle.angle;
this._vertices[offset+8]=particle.size;
this._vertices[offset+9]=offsetX;
this._vertices[offset+10]=offsetY;
}
private virtual void _update(float newParticles) {
this._alive=this.particles.length>0;
for (var index = 0;index<this.particles.length;index++) 
{
var particle = this.particles[index];
particle.age+=this._scaledUpdateSpeed;
if (particle.age>=particle.lifeTime) 
{
this._stockParticles.push(this.particles.splice(index, 1)[0]);
index--;
continue;
}
else 
{
particle.colorStep.scaleToRef(this._scaledUpdateSpeed, this._scaledColorStep);
particle.color.addInPlace(this._scaledColorStep);
if (particle.color.a<0) 
particle.color.a=0;
particle.angle+=particle.angularSpeed*this._scaledUpdateSpeed;
particle.direction.scaleToRef(this._scaledUpdateSpeed, this._scaledDirection);
particle.position.addInPlace(this._scaledDirection);
this.gravity.scaleToRef(this._scaledUpdateSpeed, this._scaledGravity);
particle.direction.addInPlace(this._scaledGravity);
}
}
var worldMatrix;
if (this.emitter.position) 
{
worldMatrix=this.emitter.getWorldMatrix();
}
else 
{
worldMatrix=BABYLON.Matrix.Translation(this.emitter.x, this.emitter.y, this.emitter.z);
}
for (index=0;index<newParticles;index++) 
{
if (this.particles.length==this._capacity) 
{
break;
}
if (this._stockParticles.length!=0) 
{
particle=this._stockParticles.pop();
particle.age=0;
}
else 
{
particle=new BABYLON.Particle();
}
this.particles.push(particle);
var emitPower = randomNumber(this.minEmitPower, this.maxEmitPower);
this.startDirectionFunction(emitPower, worldMatrix, particle.direction);
particle.lifeTime=randomNumber(this.minLifeTime, this.maxLifeTime);
particle.size=randomNumber(this.minSize, this.maxSize);
particle.angularSpeed=randomNumber(this.minAngularSpeed, this.maxAngularSpeed);
this.startPositionFunction(worldMatrix, particle.position);
var step = randomNumber(0, 1.0);
BABYLON.Color4.LerpToRef(this.color1, this.color2, step, particle.color);
this.colorDead.subtractToRef(particle.color, this._colorDiff);
this._colorDiff.scaleToRef(1.0/particle.lifeTime, particle.colorStep);
}
}
private virtual Effect _getEffect() {
var defines = new Array<object>();
if (this._scene.clipPlane) 
{
defines.push("#define CLIPPLAN");
}
var join = defines.join("\\");
if (this._cachedDefines!=join) 
{
this._cachedDefines=join;
this._effect=this._scene.getEngine().createEffect("particle", new Array<object>(), new Array<object>(), new Array<object>(), join);
}
return this._effect;
}
public virtual void animate() {
if (!this._started) 
return;
var effect = this._getEffect();
if (!this.emitter||!effect.isReady()||!this.particleTexture||!this.particleTexture.isReady()) 
return;
if (this._currentRenderId==this._scene.getRenderId()) 
{
return;
}
this._currentRenderId=this._scene.getRenderId();
this._scaledUpdateSpeed=this.updateSpeed*this._scene.getAnimationRatio();
var emitCout;
if (this.manualEmitCount>-1) 
{
emitCout=this.manualEmitCount;
this.manualEmitCount=0;
}
else 
{
emitCout=this.emitRate;
}
var newParticles = ((emitCout*this._scaledUpdateSpeed)<<0);
this._newPartsExcess+=emitCout*this._scaledUpdateSpeed-newParticles;
if (this._newPartsExcess>1.0) 
{
newParticles+=this._newPartsExcess<<0;
this._newPartsExcess-=this._newPartsExcess<<0;
}
this._alive=false;
if (!this._stopped) 
{
this._actualFrame+=this._scaledUpdateSpeed;
if (this.targetStopDuration&&this._actualFrame>=this.targetStopDuration) 
this.stop();
}
else 
{
newParticles=0;
}
this._update(newParticles);
if (this._stopped) 
{
if (!this._alive) 
{
this._started=false;
if (this.disposeOnStop) 
{
this._scene._toBeDisposed.push(this);
}
}
}
var offset = 0;
for (var index = 0;index<this.particles.length;index++) 
{
var particle = this.particles[index];
this._appendParticleVertex(offset++, particle, 0, 0);
this._appendParticleVertex(offset++, particle, 1, 0);
this._appendParticleVertex(offset++, particle, 1, 1);
this._appendParticleVertex(offset++, particle, 0, 1);
}
var engine = this._scene.getEngine();
engine.updateDynamicVertexBuffer(this._vertexBuffer, this._vertices, this.particles.length*this._vertexStrideSize);
}
public virtual float render() {
var effect = this._getEffect();
if (!this.emitter||!effect.isReady()||!this.particleTexture||!this.particleTexture.isReady()||!this.particles.length) 
return 0;
var engine = this._scene.getEngine();
engine.enableEffect(effect);
var viewMatrix = this._scene.getViewMatrix();
effect.setTexture("diffuseSample", this.particleTexture);
effect.setMatrix("vie", viewMatrix);
effect.setMatrix("projectio", this._scene.getProjectionMatrix());
effect.setFloat4("textureMas", this.textureMask.r, this.textureMask.g, this.textureMask.b, this.textureMask.a);
if (this._scene.clipPlane) 
{
var clipPlane = this._scene.clipPlane;
var invView = viewMatrix.clone();
invView.invert();
effect.setMatrix("invVie", invView);
effect.setFloat4("vClipPlan", clipPlane.normal.x, clipPlane.normal.y, clipPlane.normal.z, clipPlane.d);
}
engine.bindBuffers(this._vertexBuffer, this._indexBuffer, this._vertexDeclaration, this._vertexStrideSize, effect);
if (this.blendMode==BABYLON.ParticleSystem.BLENDMODE_ONEONE) 
{
engine.setAlphaMode(BABYLON.Engine.ALPHA_ADD);
}
else 
{
engine.setAlphaMode(BABYLON.Engine.ALPHA_COMBINE);
}
if (this.forceDepthWrite) 
{
engine.setDepthWrite(true);
}
engine.draw(true, 0, this.particles.length*6);
engine.setAlphaMode(BABYLON.Engine.ALPHA_DISABLE);
return this.particles.length;
}
public virtual void dispose() {
if (this._vertexBuffer) 
{
this._scene.getEngine()._releaseBuffer(this._vertexBuffer);
this._vertexBuffer=null;
}
if (this._indexBuffer) 
{
this._scene.getEngine()._releaseBuffer(this._indexBuffer);
this._indexBuffer=null;
}
if (this.particleTexture) 
{
this.particleTexture.dispose();
this.particleTexture=null;
}
var index = this._scene.particleSystems.indexOf(this);
this._scene.particleSystems.splice(index, 1);
if (this.onDispose) 
{
this.onDispose();
}
}
public virtual ParticleSystem clone(string name, object newEmitter) {
var result = new BABYLON.ParticleSystem(name, this._capacity, this._scene);
BABYLON.Tools.DeepCopy(this, result, new Array<object>(), new Array<object>());
if (newEmitter==undefined) 
{
newEmitter=this.emitter;
}
result.emitter=newEmitter;
if (this.particleTexture) 
{
result.particleTexture=new BABYLON.Texture(this.particleTexture.url, this._scene);
}
result.start();
return result;
}
}
}
