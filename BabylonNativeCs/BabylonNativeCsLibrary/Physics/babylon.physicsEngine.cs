using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial interface IPhysicsEnginePlugin
    {
        void initialize(double iterations = 0.0);
        void setGravity(Vector3 gravity);
        void runOneStep(double delta);
        object registerMesh(AbstractMesh mesh, double impostor, PhysicsBodyCreationOptions options);
        PhysicsCompound registerMeshesAsCompound(Array<PhysicsCompoundBodyPart> parts, PhysicsBodyCreationOptions options);
        void unregisterMesh(AbstractMesh mesh);
        void applyImpulse(AbstractMesh mesh, Vector3 force, Vector3 contactPoint);
        bool createLink(AbstractMesh mesh1, AbstractMesh mesh2, Vector3 pivot1, Vector3 pivot2);
        void dispose();
        bool isSupported();
    }
    public partial interface PhysicsCompound
    {
        Array<PhysicsCompoundBodyPart> parts
        {
            get;
        }
        PhysicsBodyCreationOptions options
        {
            get;
        }
    }
    public partial interface PhysicsBodyCreationOptions
    {
        double mass
        {
            get;
        }
        double friction
        {
            get;
        }
        double restitution
        {
            get;
        }
    }
    public partial interface PhysicsCompoundBodyPart
    {
        Mesh mesh
        {
            get;
        }
        int impostor
        {
            get;
        }
    }
    public partial class PhysicsEngine
    {
        public Vector3 gravity;
        private IPhysicsEnginePlugin _currentPlugin;
        public PhysicsEngine(IPhysicsEnginePlugin plugin = null)
        {
            this._currentPlugin = plugin ?? new CannonJSPlugin();
        }
        void CANNON;
        public virtual void _initialize(Vector3 gravity = null)
        {
            this._currentPlugin.initialize();
            this._setGravity(gravity);
        }
        public virtual void _runOneStep(double delta)
        {
            if (delta > 0.1)
            {
                delta = 0.1;
            }
            else
                if (delta <= 0)
                {
                    delta = 1.0 / 60.0;
                }
            this._currentPlugin.runOneStep(delta);
        }
        public virtual void _setGravity(Vector3 gravity)
        {
            this.gravity = gravity ?? new BABYLON.Vector3(0, -9.82, 0);
            this._currentPlugin.setGravity(this.gravity);
        }
        public virtual object _registerMesh(AbstractMesh mesh, double impostor, PhysicsBodyCreationOptions options)
        {
            return this._currentPlugin.registerMesh(mesh, impostor, options);
        }
        public virtual PhysicsCompound _registerMeshesAsCompound(Array<PhysicsCompoundBodyPart> parts, PhysicsBodyCreationOptions options)
        {
            return this._currentPlugin.registerMeshesAsCompound(parts, options);
        }
        public virtual void _unregisterMesh(AbstractMesh mesh)
        {
            this._currentPlugin.unregisterMesh(mesh);
        }
        public virtual void _applyImpulse(AbstractMesh mesh, Vector3 force, Vector3 contactPoint)
        {
            this._currentPlugin.applyImpulse(mesh, force, contactPoint);
        }
        public virtual bool _createLink(AbstractMesh mesh1, AbstractMesh mesh2, Vector3 pivot1, Vector3 pivot2)
        {
            return this._currentPlugin.createLink(mesh1, mesh2, pivot1, pivot2);
        }
        public virtual void dispose()
        {
            this._currentPlugin.dispose();
        }
        public virtual bool isSupported()
        {
            return this._currentPlugin.isSupported();
        }
        public static int NoImpostor = 0;
        public static int SphereImpostor = 1;
        public static int BoxImpostor = 2;
        public static int PlaneImpostor = 3;
        public static int CompoundImpostor = 4;
        public static int MeshImpostor = 4;
        public static int CapsuleImpostor = 5;
        public static int ConeImpostor = 6;
        public static int CylinderImpostor = 7;
        public static int ConvexHullImpostor = 8;
        public static double Epsilon = 0.001;
    }
}