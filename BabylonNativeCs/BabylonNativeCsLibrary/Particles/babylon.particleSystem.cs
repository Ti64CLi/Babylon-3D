// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.particleSystem.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    using System;

    using Web;

    /// <summary>
    /// </summary>
    public partial class ParticleSystem : IDisposable
    {
        /// <summary>
        /// </summary>
        public double blendMode = BLENDMODE_ONEONE;

        /// <summary>
        /// </summary>
        public Color4 color1 = new Color4(1.0, 1.0, 1.0, 1.0);

        /// <summary>
        /// </summary>
        public Color4 color2 = new Color4(1.0, 1.0, 1.0, 1.0);

        /// <summary>
        /// </summary>
        public Color4 colorDead = new Color4(0, 0, 0, 1.0);

        /// <summary>
        /// </summary>
        public Vector3 direction1 = new Vector3(0, 1.0, 0);

        /// <summary>
        /// </summary>
        public Vector3 direction2 = new Vector3(0, 1.0, 0);

        /// <summary>
        /// </summary>
        public bool disposeOnStop = false;

        /// <summary>
        /// </summary>
        public int emitRate = 10;

        /// <summary>
        /// </summary>
        public object emitter = null;

        /// <summary>
        /// </summary>
        public bool forceDepthWrite = false;

        /// <summary>
        /// </summary>
        public Vector3 gravity = Vector3.Zero();

        /// <summary>
        /// </summary>
        public string id;

        /// <summary>
        /// </summary>
        public int manualEmitCount = -1;

        /// <summary>
        /// </summary>
        public double maxAngularSpeed = 0;

        /// <summary>
        /// </summary>
        public Vector3 maxEmitBox = new Vector3(0.5, 0.5, 0.5);

        /// <summary>
        /// </summary>
        public double maxEmitPower = 1;

        /// <summary>
        /// </summary>
        public double maxLifeTime = 1;

        /// <summary>
        /// </summary>
        public double maxSize = 1;

        /// <summary>
        /// </summary>
        public double minAngularSpeed = 0;

        /// <summary>
        /// </summary>
        public Vector3 minEmitBox = new Vector3(-0.5, -0.5, -0.5);

        /// <summary>
        /// </summary>
        public double minEmitPower = 1;

        /// <summary>
        /// </summary>
        public double minLifeTime = 1;

        /// <summary>
        /// </summary>
        public double minSize = 1;

        /// <summary>
        /// </summary>
        public string name;

        /// <summary>
        /// </summary>
        public System.Action onDispose;

        /// <summary>
        /// </summary>
        public Texture particleTexture;

        /// <summary>
        /// </summary>
        public double renderingGroupId = 0;

        /// <summary>
        /// </summary>
        public Action<double, Matrix, Vector3> startDirectionFunction;

        /// <summary>
        /// </summary>
        public Action<Matrix, Vector3> startPositionFunction;

        /// <summary>
        /// </summary>
        public double targetStopDuration = 0;

        /// <summary>
        /// </summary>
        public Color4 textureMask = new Color4(1.0, 1.0, 1.0, 1.0);

        /// <summary>
        /// </summary>
        public double updateSpeed = 0.01;

        /// <summary>
        /// </summary>
        private double _actualFrame;

        /// <summary>
        /// </summary>
        private bool _alive;

        /// <summary>
        /// </summary>
        private string _cachedDefines;

        /// <summary>
        /// </summary>
        private readonly int _capacity;

        /// <summary>
        /// </summary>
        private readonly Color4 _colorDiff = new Color4(0, 0, 0, 0);

        /// <summary>
        /// </summary>
        private double _currentRenderId = -1;

        /// <summary>
        /// </summary>
        private Effect _effect;

        /// <summary>
        /// </summary>
        private WebGLBuffer _indexBuffer;

        /// <summary>
        /// </summary>
        private double _newPartsExcess;

        /// <summary>
        /// </summary>
        private readonly Color4 _scaledColorStep = new Color4(0, 0, 0, 0);

        /// <summary>
        /// </summary>
        private readonly Vector3 _scaledDirection = Vector3.Zero();

        /// <summary>
        /// </summary>
        private readonly Vector3 _scaledGravity = Vector3.Zero();

        /// <summary>
        /// </summary>
        private double _scaledUpdateSpeed;

        /// <summary>
        /// </summary>
        private readonly Scene _scene;

        /// <summary>
        /// </summary>
        private bool _started;

        /// <summary>
        /// </summary>
        private readonly Array<Particle> _stockParticles = new Array<Particle>();

        /// <summary>
        /// </summary>
        private bool _stopped;

        /// <summary>
        /// </summary>
        private WebGLBuffer _vertexBuffer;

        /// <summary>
        /// </summary>
        private readonly Array<VertexBufferKind> _vertexDeclaration = new Array<VertexBufferKind>(
            VertexBufferKind.UVKind, VertexBufferKind.UV2Kind, VertexBufferKind.UV2Kind);

        /// <summary>
        /// </summary>
        private int _vertexStrideSize = 11 * 4;

        /// <summary>
        /// </summary>
        private readonly double[] _vertices;

        /// <summary>
        /// </summary>
        private readonly Array<Particle> particles = new Array<Particle>();

        /// <summary>
        /// </summary>
        private readonly Random randomGen = new Random();

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="capacity">
        /// </param>
        /// <param name="scene">
        /// </param>
        public ParticleSystem(string name, int capacity, Scene scene)
        {
            this.id = name;
            this._capacity = capacity;
            this._scene = scene;
            scene.particleSystems.Add(this);
            this._vertexBuffer = scene.getEngine().createDynamicVertexBuffer(capacity * this._vertexStrideSize * 4);
            var indices = new Array<int>();
            var index = 0;
            for (var count = 0; count < capacity; count++)
            {
                indices.Add(index);
                indices.Add(index + 1);
                indices.Add(index + 2);
                indices.Add(index);
                indices.Add(index + 2);
                indices.Add(index + 3);
                index += 4;
            }

            this._indexBuffer = scene.getEngine().createIndexBuffer(indices);
            this._vertices = new double[capacity * this._vertexStrideSize];
            this.startDirectionFunction = (double emitPower, Matrix worldMatrix, Vector3 directionToUpdate) =>
                {
                    var randX = this.randomNumber(this.direction1.x, this.direction2.x);
                    var randY = this.randomNumber(this.direction1.y, this.direction2.y);
                    var randZ = this.randomNumber(this.direction1.z, this.direction2.z);
                    Vector3.TransformNormalFromFloatsToRef(randX * emitPower, randY * emitPower, randZ * emitPower, worldMatrix, directionToUpdate);
                };
            this.startPositionFunction = (Matrix worldMatrix, Vector3 positionToUpdate) =>
                {
                    var randX = this.randomNumber(this.minEmitBox.x, this.maxEmitBox.x);
                    var randY = this.randomNumber(this.minEmitBox.y, this.maxEmitBox.y);
                    var randZ = this.randomNumber(this.minEmitBox.z, this.maxEmitBox.z);
                    Vector3.TransformCoordinatesFromFloatsToRef(randX, randY, randZ, worldMatrix, positionToUpdate);
                };
        }

        /// <summary>
        /// </summary>
        /// <param name="index">
        /// </param>
        /// <param name="particle">
        /// </param>
        /// <param name="offsetX">
        /// </param>
        /// <param name="offsetY">
        /// </param>
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

        /// <summary>
        /// </summary>
        public virtual void animate()
        {
            if (!this._started)
            {
                return;
            }

            var effect = this._getEffect();
            if (this.emitter == null || !effect.isReady() || this.particleTexture == null || !this.particleTexture.isReady())
            {
                return;
            }

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
                if (this.targetStopDuration != 0.0 && this._actualFrame >= this.targetStopDuration)
                {
                    this.stop();
                }
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
                        this._scene._toBeDisposed.Add(this);
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

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="newEmitter">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual ParticleSystem clone(string name, object newEmitter)
        {
            var result = new ParticleSystem(name, this._capacity, this._scene);
            Tools.DeepCopy(this, result, new Array<string>("particles"), new Array<string>("_vertexDeclaration", "_vertexStrideSize"));
            if (newEmitter == null)
            {
                newEmitter = this.emitter;
            }

            result.emitter = newEmitter;
            if (this.particleTexture != null)
            {
                result.particleTexture = new Texture(this.particleTexture.url, this._scene);
            }

            result.start();
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="doNotRecurse">
        /// </param>
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

            var index = this._scene.particleSystems.IndexOf(this);
            this._scene.particleSystems.RemoveAt(index);
            if (this.onDispose != null)
            {
                this.onDispose();
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual double getCapacity()
        {
            return this._capacity;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual bool isAlive()
        {
            return this._alive;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual bool isStarted()
        {
            return this._started;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual int render()
        {
            var effect = this._getEffect();
            if (this.emitter == null || !effect.isReady() || this.particleTexture == null || !this.particleTexture.isReady() || this.particles.Length == 0)
            {
                return 0;
            }

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
            if (this.blendMode == BLENDMODE_ONEONE)
            {
                engine.setAlphaMode(Engine.ALPHA_ADD);
            }
            else
            {
                engine.setAlphaMode(Engine.ALPHA_COMBINE);
            }

            if (this.forceDepthWrite)
            {
                engine.setDepthWrite(true);
            }

            engine.draw(true, 0, this.particles.Length * 6);
            engine.setAlphaMode(Engine.ALPHA_DISABLE);
            return this.particles.Length;
        }

        /// <summary>
        /// </summary>
        public virtual void start()
        {
            this._started = true;
            this._stopped = false;
            this._actualFrame = 0;
        }

        /// <summary>
        /// </summary>
        public virtual void stop()
        {
            this._stopped = true;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        private Effect _getEffect()
        {
            var defines = new Array<object>();
            if (this._scene.clipPlane != null)
            {
                defines.Add("#define CLIPPLANE");
            }

            var join = defines.Concat("\n");
            if (this._cachedDefines != join)
            {
                this._cachedDefines = join;
                this._effect = this._scene.getEngine()
                                   .createEffect(
                                       new EffectBaseName { baseName = "particles" }, 
                                       new Array<string>("position", "color", "options"), 
                                       new Array<string>("invView", "view", "projection", "vClipPlane", "textureMask"), 
                                       new Array<string>("diffuseSampler"), 
                                       join);
            }

            return this._effect;
        }

        /// <summary>
        /// </summary>
        /// <param name="newParticles">
        /// </param>
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
                    this._stockParticles.Add(this.particles[0]);
                    index--;
                    continue;
                }
                else
                {
                    particle.colorStep.scaleToRef(this._scaledUpdateSpeed, this._scaledColorStep);
                    particle.color.addInPlace(this._scaledColorStep);
                    if (particle.color.a < 0)
                    {
                        particle.color.a = 0;
                    }

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
                worldMatrix = Matrix.Translation(((Vector3)this.emitter).x, ((Vector3)this.emitter).y, ((Vector3)this.emitter).z);
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
                    particle = this._stockParticles.Pop();
                    particle.age = 0;
                }
                else
                {
                    particle = new Particle();
                }

                this.particles.Add(particle);
                var emitPower = this.randomNumber(this.minEmitPower, this.maxEmitPower);
                this.startDirectionFunction(emitPower, worldMatrix, particle.direction);
                particle.lifeTime = this.randomNumber(this.minLifeTime, this.maxLifeTime);
                particle.size = this.randomNumber(this.minSize, this.maxSize);
                particle.angularSpeed = this.randomNumber(this.minAngularSpeed, this.maxAngularSpeed);
                this.startPositionFunction(worldMatrix, particle.position);
                var step = this.randomNumber(0, 1.0);
                Color4.LerpToRef(this.color1, this.color2, step, particle.color);
                this.colorDead.subtractToRef(particle.color, this._colorDiff);
                this._colorDiff.scaleToRef(1.0 / particle.lifeTime, particle.colorStep);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="min">
        /// </param>
        /// <param name="max">
        /// </param>
        /// <returns>
        /// </returns>
        private double randomNumber(double min, double max)
        {
            if (Math.Abs(min - max) < 0.0001)
            {
                return min;
            }

            var random = this.randomGen.NextDouble();
            return (random * (max - min)) + min;
        }

        /// <summary>
        /// </summary>
        public const int BLENDMODE_ONEONE = 0;

        /// <summary>
        /// </summary>
        public const int BLENDMODE_STANDARD = 1;
    }
}