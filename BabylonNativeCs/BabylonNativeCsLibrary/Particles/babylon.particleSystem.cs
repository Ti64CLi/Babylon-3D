using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class ParticleSystem : IDisposable
    {
        public const int BLENDMODE_ONEONE = 0;
        public const int BLENDMODE_STANDARD = 1;
        public string id;
        public double renderingGroupId = 0;
        public object emitter = null;
        public int emitRate = 10;
        public int manualEmitCount = -1;
        public double updateSpeed = 0.01;
        public double targetStopDuration = 0;
        public bool disposeOnStop = false;
        public double minEmitPower = 1;
        public double maxEmitPower = 1;
        public double minLifeTime = 1;
        public double maxLifeTime = 1;
        public double minSize = 1;
        public double maxSize = 1;
        public double minAngularSpeed = 0;
        public double maxAngularSpeed = 0;
        public Texture particleTexture;
        public System.Action onDispose;
        public double blendMode = BABYLON.ParticleSystem.BLENDMODE_ONEONE;
        public bool forceDepthWrite = false;
        public BABYLON.Vector3 gravity = BABYLON.Vector3.Zero();
        public BABYLON.Vector3 direction1 = new BABYLON.Vector3(0, 1.0, 0);
        public BABYLON.Vector3 direction2 = new BABYLON.Vector3(0, 1.0, 0);
        public BABYLON.Vector3 minEmitBox = new BABYLON.Vector3(-0.5, -0.5, -0.5);
        public BABYLON.Vector3 maxEmitBox = new BABYLON.Vector3(0.5, 0.5, 0.5);
        public BABYLON.Color4 color1 = new BABYLON.Color4(1.0, 1.0, 1.0, 1.0);
        public BABYLON.Color4 color2 = new BABYLON.Color4(1.0, 1.0, 1.0, 1.0);
        public BABYLON.Color4 colorDead = new BABYLON.Color4(0, 0, 0, 1.0);
        public BABYLON.Color4 textureMask = new BABYLON.Color4(1.0, 1.0, 1.0, 1.0);
        public System.Action<double, Matrix, Vector3> startDirectionFunction;
        public System.Action<Matrix, Vector3> startPositionFunction;
        private Array<Particle> particles = new Array<Particle>();
        private int _capacity;
        private Scene _scene;
        private Array<VertexBufferKind> _vertexDeclaration = new Array<VertexBufferKind>(VertexBufferKind.UVKind, VertexBufferKind.UV2Kind, VertexBufferKind.UV2Kind);
        private int _vertexStrideSize = 11 * 4;
        private Array<Particle> _stockParticles = new Array<Particle>();
        private double _newPartsExcess = 0;
        private WebGLBuffer _vertexBuffer;
        private WebGLBuffer _indexBuffer;
        private double[] _vertices;
        private Effect _effect;
        private string _cachedDefines;
        private BABYLON.Color4 _scaledColorStep = new BABYLON.Color4(0, 0, 0, 0);
        private BABYLON.Color4 _colorDiff = new BABYLON.Color4(0, 0, 0, 0);
        private BABYLON.Vector3 _scaledDirection = BABYLON.Vector3.Zero();
        private BABYLON.Vector3 _scaledGravity = BABYLON.Vector3.Zero();
        private double _currentRenderId = -1;
        private bool _alive;
        private bool _started = false;
        private bool _stopped = false;
        private double _actualFrame = 0;
        private double _scaledUpdateSpeed;
        public string name;
        public ParticleSystem(string name, int capacity, Scene scene)
        {
            this.id = name;
            this._capacity = capacity;
            this._scene = scene;
            scene.particleSystems.push(this);
            this._vertexBuffer = scene.getEngine().createDynamicVertexBuffer(capacity * this._vertexStrideSize * 4);
            var indices = new Array<int>();
            var index = 0;
            for (var count = 0; count < capacity; count++)
            {
                indices.push(index);
                indices.push(index + 1);
                indices.push(index + 2);
                indices.push(index);
                indices.push(index + 2);
                indices.push(index + 3);
                index += 4;
            }
            this._indexBuffer = scene.getEngine().createIndexBuffer(indices);
            this._vertices = new double[capacity * this._vertexStrideSize];
            this.startDirectionFunction = (double emitPower, Matrix worldMatrix, Vector3 directionToUpdate) =>
            {
                var randX = randomNumber(this.direction1.x, this.direction2.x);
                var randY = randomNumber(this.direction1.y, this.direction2.y);
                var randZ = randomNumber(this.direction1.z, this.direction2.z);
                BABYLON.Vector3.TransformNormalFromFloatsToRef(randX * emitPower, randY * emitPower, randZ * emitPower, worldMatrix, directionToUpdate);
            };
            this.startPositionFunction = (Matrix worldMatrix, Vector3 positionToUpdate) =>
            {
                var randX = randomNumber(this.minEmitBox.x, this.maxEmitBox.x);
                var randY = randomNumber(this.minEmitBox.y, this.maxEmitBox.y);
                var randZ = randomNumber(this.minEmitBox.z, this.maxEmitBox.z);
                BABYLON.Vector3.TransformCoordinatesFromFloatsToRef(randX, randY, randZ, worldMatrix, positionToUpdate);
            };
        }
        double randomNumber(double min, double max)
        {
            if (min == max)
            {
                return (min);
            }
            var random = new Random().Next();
            return ((random * (max - min)) + min);
        }
        public virtual double getCapacity()
        {
            return this._capacity;
        }
        public virtual bool isAlive()
        {
            return this._alive;
        }
        public virtual bool isStarted()
        {
            return this._started;
        }
        public virtual void start()
        {
            this._started = true;
            this._stopped = false;
            this._actualFrame = 0;
        }
        public virtual void stop()
        {
            this._stopped = true;
        }
        public virtual void _appendParticleVertex(int index, Particle particle, int offsetX, int offsetY)
        {
            var offset = index * 11;
            this._vertices[offset] = particle.position.x;
            this._vertices[offset + 1] = particle.position.y;
            this._vertices[offset + 2] = particle.position.z;
            this._vertices[offset + 3] = particle.color.r;
            this._vertices[offset + 4] = particle.color.g;
            this._vertices[offset + 5] = particle.color.b;
            this._vertices[offset + 6] = particle.color.a;
            this._vertices[offset + 7] = particle.angle;
            this._vertices[offset + 8] = particle.size;
            this._vertices[offset + 9] = offsetX;
            this._vertices[offset + 10] = offsetY;
        }
        private void _update(double newParticles)
        {
            this._alive = this.particles.Length > 0;
            for (var index = 0; index < this.particles.Length; index++)
            {
                var particle = this.particles[index];
                particle.age += this._scaledUpdateSpeed;
                if (particle.age >= particle.lifeTime)
                {
                    this.particles.RemoveAt(index);
                    this._stockParticles.push(this.particles[0]);
                    index--;
                    continue;
                }
                else
                {
                    particle.colorStep.scaleToRef(this._scaledUpdateSpeed, this._scaledColorStep);
                    particle.color.addInPlace(this._scaledColorStep);
                    if (particle.color.a < 0)
                        particle.color.a = 0;
                    particle.angle += particle.angularSpeed * this._scaledUpdateSpeed;
                    particle.direction.scaleToRef(this._scaledUpdateSpeed, this._scaledDirection);
                    particle.position.addInPlace(this._scaledDirection);
                    this.gravity.scaleToRef(this._scaledUpdateSpeed, this._scaledGravity);
                    particle.direction.addInPlace(this._scaledGravity);
                }
            }
            Matrix worldMatrix;
            if (this.emitter is Mesh)
            {
                worldMatrix = ((Mesh)this.emitter).getWorldMatrix();
            }
            else
            {
                worldMatrix = BABYLON.Matrix.Translation(((Vector3)this.emitter).x, ((Vector3)this.emitter).y, ((Vector3)this.emitter).z);
            }
            for (var index = 0; index < newParticles; index++)
            {
                Particle particle = null;
                if (this.particles.Length == this._capacity)
                {
                    break;
                }
                if (this._stockParticles.Length != 0)
                {
                    particle = this._stockParticles.pop();
                    particle.age = 0;
                }
                else
                {
                    particle = new BABYLON.Particle();
                }
                this.particles.push(particle);
                var emitPower = randomNumber(this.minEmitPower, this.maxEmitPower);
                this.startDirectionFunction(emitPower, worldMatrix, particle.direction);
                particle.lifeTime = randomNumber(this.minLifeTime, this.maxLifeTime);
                particle.size = randomNumber(this.minSize, this.maxSize);
                particle.angularSpeed = randomNumber(this.minAngularSpeed, this.maxAngularSpeed);
                this.startPositionFunction(worldMatrix, particle.position);
                var step = randomNumber(0, 1.0);
                BABYLON.Color4.LerpToRef(this.color1, this.color2, step, particle.color);
                this.colorDead.subtractToRef(particle.color, this._colorDiff);
                this._colorDiff.scaleToRef(1.0 / particle.lifeTime, particle.colorStep);
            }
        }
        private Effect _getEffect()
        {
            var defines = new Array<object>();
            if (this._scene.clipPlane != null)
            {
                defines.push("#define CLIPPLANE");
            }
            var join = defines.join("\\n");
            if (this._cachedDefines != join)
            {
                this._cachedDefines = join;
                this._effect = this._scene.getEngine().createEffect(new EffectBaseName { baseName = "particles" }, new Array<string>("position", "color", "options"), new Array<string>("invView", "view", "projection", "vClipPlane", "textureMask"), new Array<string>("diffuseSampler"), join);
            }
            return this._effect;
        }
        public virtual void animate()
        {
            if (!this._started)
                return;
            var effect = this._getEffect();
            if (this.emitter == null || !effect.isReady() || this.particleTexture == null || !this.particleTexture.isReady())
                return;
            if (this._currentRenderId == this._scene.getRenderId())
            {
                return;
            }
            this._currentRenderId = this._scene.getRenderId();
            this._scaledUpdateSpeed = this.updateSpeed * this._scene.getAnimationRatio();
            int emitCout;
            if (this.manualEmitCount > -1)
            {
                emitCout = this.manualEmitCount;
                this.manualEmitCount = 0;
            }
            else
            {
                emitCout = this.emitRate;
            }
            var newParticles = (int)(emitCout * this._scaledUpdateSpeed);
            this._newPartsExcess += emitCout * this._scaledUpdateSpeed - newParticles;
            if (this._newPartsExcess > 1.0)
            {
                newParticles += (int)this._newPartsExcess;
                this._newPartsExcess -= (int)this._newPartsExcess;
            }
            this._alive = false;
            if (!this._stopped)
            {
                this._actualFrame += this._scaledUpdateSpeed;
                if (this.targetStopDuration != null && this._actualFrame >= this.targetStopDuration)
                    this.stop();
            }
            else
            {
                newParticles = 0;
            }
            this._update(newParticles);
            if (this._stopped)
            {
                if (!this._alive)
                {
                    this._started = false;
                    if (this.disposeOnStop)
                    {
                        this._scene._toBeDisposed.push(this);
                    }
                }
            }
            var offset = 0;
            for (var index = 0; index < this.particles.Length; index++)
            {
                var particle = this.particles[index];
                this._appendParticleVertex(offset++, particle, 0, 0);
                this._appendParticleVertex(offset++, particle, 1, 0);
                this._appendParticleVertex(offset++, particle, 1, 1);
                this._appendParticleVertex(offset++, particle, 0, 1);
            }
            var engine = this._scene.getEngine();
            engine.updateDynamicVertexBuffer(this._vertexBuffer, this._vertices, this.particles.Length * this._vertexStrideSize);
        }
        public virtual int render()
        {
            var effect = this._getEffect();
            if (this.emitter == null || !effect.isReady() || this.particleTexture == null || !this.particleTexture.isReady() || this.particles.Length == 0)
                return 0;
            var engine = this._scene.getEngine();
            engine.enableEffect(effect);
            var viewMatrix = this._scene.getViewMatrix();
            effect.setTexture("diffuseSampler", this.particleTexture);
            effect.setMatrix("view", viewMatrix);
            effect.setMatrix("projection", this._scene.getProjectionMatrix());
            effect.setFloat4("textureMask", this.textureMask.r, this.textureMask.g, this.textureMask.b, this.textureMask.a);
            if (this._scene.clipPlane != null)
            {
                var clipPlane = this._scene.clipPlane;
                var invView = viewMatrix.clone();
                invView.invert();
                effect.setMatrix("invView", invView);
                effect.setFloat4("vClipPlane", clipPlane.normal.x, clipPlane.normal.y, clipPlane.normal.z, clipPlane.d);
            }
            engine.bindBuffers(this._vertexBuffer, this._indexBuffer, this._vertexDeclaration, this._vertexStrideSize, effect);
            if (this.blendMode == BABYLON.ParticleSystem.BLENDMODE_ONEONE)
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
            engine.draw(true, 0, this.particles.Length * 6);
            engine.setAlphaMode(BABYLON.Engine.ALPHA_DISABLE);
            return this.particles.Length;
        }
        public virtual void dispose(bool doNotRecurse = false)
        {
            if (this._vertexBuffer != null)
            {
                this._scene.getEngine()._releaseBuffer(this._vertexBuffer);
                this._vertexBuffer = null;
            }
            if (this._indexBuffer != null)
            {
                this._scene.getEngine()._releaseBuffer(this._indexBuffer);
                this._indexBuffer = null;
            }
            if (this.particleTexture != null)
            {
                this.particleTexture.dispose();
                this.particleTexture = null;
            }
            var index = this._scene.particleSystems.indexOf(this);
            this._scene.particleSystems.RemoveAt(index);
            if (this.onDispose != null)
            {
                this.onDispose();
            }
        }
        public virtual ParticleSystem clone(string name, object newEmitter)
        {
            var result = new BABYLON.ParticleSystem(name, this._capacity, this._scene);
            BABYLON.Tools.DeepCopy(this, result, new Array<string>("particles"), new Array<string>("_vertexDeclaration", "_vertexStrideSize"));
            if (newEmitter == null)
            {
                newEmitter = this.emitter;
            }
            result.emitter = newEmitter;
            if (this.particleTexture != null)
            {
                result.particleTexture = new BABYLON.Texture(this.particleTexture.url, this._scene);
            }
            result.start();
            return result;
        }
    }
}