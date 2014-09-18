// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.physicsEngine.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    /// <summary>
    /// </summary>
    public partial interface IPhysicsEnginePlugin
    {
        /// <summary>
        /// </summary>
        /// <param name="mesh">
        /// </param>
        /// <param name="force">
        /// </param>
        /// <param name="contactPoint">
        /// </param>
        void applyImpulse(AbstractMesh mesh, Vector3 force, Vector3 contactPoint);

        /// <summary>
        /// </summary>
        /// <param name="mesh1">
        /// </param>
        /// <param name="mesh2">
        /// </param>
        /// <param name="pivot1">
        /// </param>
        /// <param name="pivot2">
        /// </param>
        /// <returns>
        /// </returns>
        bool createLink(AbstractMesh mesh1, AbstractMesh mesh2, Vector3 pivot1, Vector3 pivot2);

        /// <summary>
        /// </summary>
        void dispose();

        /// <summary>
        /// </summary>
        /// <param name="iterations">
        /// </param>
        void initialize(double iterations = 0.0);

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        bool isSupported();

        /// <summary>
        /// </summary>
        /// <param name="mesh">
        /// </param>
        /// <param name="impostor">
        /// </param>
        /// <param name="options">
        /// </param>
        /// <returns>
        /// </returns>
        object registerMesh(AbstractMesh mesh, double impostor, PhysicsBodyCreationOptions options);

        /// <summary>
        /// </summary>
        /// <param name="parts">
        /// </param>
        /// <param name="options">
        /// </param>
        /// <returns>
        /// </returns>
        PhysicsCompound registerMeshesAsCompound(Array<PhysicsCompoundBodyPart> parts, PhysicsBodyCreationOptions options);

        /// <summary>
        /// </summary>
        /// <param name="delta">
        /// </param>
        void runOneStep(double delta);

        /// <summary>
        /// </summary>
        /// <param name="gravity">
        /// </param>
        void setGravity(Vector3 gravity);

        /// <summary>
        /// </summary>
        /// <param name="mesh">
        /// </param>
        void unregisterMesh(AbstractMesh mesh);
    }

    /// <summary>
    /// </summary>
    public partial interface PhysicsCompound
    {
        /// <summary>
        /// </summary>
        PhysicsBodyCreationOptions options { get; }

        /// <summary>
        /// </summary>
        Array<PhysicsCompoundBodyPart> parts { get; }
    }

    /// <summary>
    /// </summary>
    public partial interface PhysicsBodyCreationOptions
    {
        /// <summary>
        /// </summary>
        double friction { get; set; }

        /// <summary>
        /// </summary>
        double mass { get; }

        /// <summary>
        /// </summary>
        double restitution { get; set; }
    }

    /// <summary>
    /// </summary>
    public partial interface PhysicsCompoundBodyPart
    {
        /// <summary>
        /// </summary>
        int impostor { get; }

        /// <summary>
        /// </summary>
        Mesh mesh { get; }
    }

    /// <summary>
    /// </summary>
    public partial class PhysicsEngine
    {
        /// <summary>
        /// </summary>
        public Vector3 gravity;

        /// <summary>
        /// </summary>
        private readonly IPhysicsEnginePlugin _currentPlugin;

        /// <summary>
        /// </summary>
        /// <param name="plugin">
        /// </param>
        public PhysicsEngine(IPhysicsEnginePlugin plugin = null)
        {
            // TODO: finish
            this._currentPlugin = plugin; // ?? new CannonJSPlugin();
        }

        /// <summary>
        /// </summary>
        /// <param name="mesh">
        /// </param>
        /// <param name="force">
        /// </param>
        /// <param name="contactPoint">
        /// </param>
        public virtual void _applyImpulse(AbstractMesh mesh, Vector3 force, Vector3 contactPoint)
        {
            this._currentPlugin.applyImpulse(mesh, force, contactPoint);
        }

        /// <summary>
        /// </summary>
        /// <param name="mesh1">
        /// </param>
        /// <param name="mesh2">
        /// </param>
        /// <param name="pivot1">
        /// </param>
        /// <param name="pivot2">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool _createLink(AbstractMesh mesh1, AbstractMesh mesh2, Vector3 pivot1, Vector3 pivot2)
        {
            return this._currentPlugin.createLink(mesh1, mesh2, pivot1, pivot2);
        }

        /// <summary>
        /// </summary>
        /// <param name="gravity">
        /// </param>
        public virtual void _initialize(Vector3 gravity = null)
        {
            this._currentPlugin.initialize();
            this._setGravity(gravity);
        }

        /// <summary>
        /// </summary>
        /// <param name="mesh">
        /// </param>
        /// <param name="impostor">
        /// </param>
        /// <param name="options">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual object _registerMesh(AbstractMesh mesh, double impostor, PhysicsBodyCreationOptions options)
        {
            return this._currentPlugin.registerMesh(mesh, impostor, options);
        }

        /// <summary>
        /// </summary>
        /// <param name="parts">
        /// </param>
        /// <param name="options">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual PhysicsCompound _registerMeshesAsCompound(Array<PhysicsCompoundBodyPart> parts, PhysicsBodyCreationOptions options)
        {
            return this._currentPlugin.registerMeshesAsCompound(parts, options);
        }

        /// <summary>
        /// </summary>
        /// <param name="delta">
        /// </param>
        public virtual void _runOneStep(double delta)
        {
            if (delta > 0.1)
            {
                delta = 0.1;
            }
            else if (delta <= 0)
            {
                delta = 1.0 / 60.0;
            }

            this._currentPlugin.runOneStep(delta);
        }

        /// <summary>
        /// </summary>
        /// <param name="gravity">
        /// </param>
        public virtual void _setGravity(Vector3 gravity)
        {
            this.gravity = gravity ?? new Vector3(0, -9.82, 0);
            this._currentPlugin.setGravity(this.gravity);
        }

        /// <summary>
        /// </summary>
        /// <param name="mesh">
        /// </param>
        public virtual void _unregisterMesh(AbstractMesh mesh)
        {
            this._currentPlugin.unregisterMesh(mesh);
        }

        /// <summary>
        /// </summary>
        public virtual void dispose()
        {
            this._currentPlugin.dispose();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual bool isSupported()
        {
            return this._currentPlugin.isSupported();
        }

        /// <summary>
        /// </summary>
        public const int NoImpostor = 0;

        /// <summary>
        /// </summary>
        public const int SphereImpostor = 1;

        /// <summary>
        /// </summary>
        public const int BoxImpostor = 2;

        /// <summary>
        /// </summary>
        public const int PlaneImpostor = 3;

        /// <summary>
        /// </summary>
        public const int CompoundImpostor = 4;

        /// <summary>
        /// </summary>
        public const int MeshImpostor = 4;

        /// <summary>
        /// </summary>
        public const int CapsuleImpostor = 5;

        /// <summary>
        /// </summary>
        public const int ConeImpostor = 6;

        /// <summary>
        /// </summary>
        public const int CylinderImpostor = 7;

        /// <summary>
        /// </summary>
        public const int ConvexHullImpostor = 8;

        /// <summary>
        /// </summary>
        public const double Epsilon = 0.001;
    }
}