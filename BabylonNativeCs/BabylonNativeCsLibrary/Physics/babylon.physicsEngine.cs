using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
var CANNON;
public interface IPhysicsEnginePlugin {
void initialize(float iterations);
void setGravity(Vector3 gravity);
void runOneStep(float delta);
object registerMesh(AbstractMesh mesh, float impostor, PhysicsBodyCreationOptions options);
object registerMeshesAsCompound(PhysicsCompoundBodyPart[] parts, PhysicsBodyCreationOptions options);
void unregisterMesh(AbstractMesh mesh);
void applyImpulse(AbstractMesh mesh, Vector3 force, Vector3 contactPoint);
bool createLink(AbstractMesh mesh1, AbstractMesh mesh2, Vector3 pivot1, Vector3 pivot2);
void dispose();
bool isSupported();
}
public interface PhysicsBodyCreationOptions {
float mass;
float friction;
float restitution;
}
public interface PhysicsCompoundBodyPart {
Mesh mesh;
float impostor;
}
public class PhysicsEngine {
public Vector3 gravity;
private IPhysicsEnginePlugin _currentPlugin;
public PhysicsEngine(IPhysicsEnginePlugin plugin) {
this._currentPlugin=plugin||new CannonJSPlugin();
}
public virtual void _initialize(Vector3 gravity) {
this._currentPlugin.initialize();
this._setGravity(gravity);
}
public virtual void _runOneStep(float delta) {
if (delta>0.1) 
{
delta=0.1;
}
else 
if (delta<=0) 
{
delta=1.0/60.0;
}
this._currentPlugin.runOneStep(delta);
}
public virtual void _setGravity(Vector3 gravity) {
this.gravity=gravity||new BABYLON.Vector3(0, -9.82, 0);
this._currentPlugin.setGravity(this.gravity);
}
public virtual object _registerMesh(AbstractMesh mesh, float impostor, PhysicsBodyCreationOptions options) {
return this._currentPlugin.registerMesh(mesh, impostor, options);
}
public virtual object _registerMeshesAsCompound(PhysicsCompoundBodyPart[] parts, PhysicsBodyCreationOptions options) {
return this._currentPlugin.registerMeshesAsCompound(parts, options);
}
public virtual void _unregisterMesh(AbstractMesh mesh) {
this._currentPlugin.unregisterMesh(mesh);
}
public virtual void _applyImpulse(AbstractMesh mesh, Vector3 force, Vector3 contactPoint) {
this._currentPlugin.applyImpulse(mesh, force, contactPoint);
}
public virtual bool _createLink(AbstractMesh mesh1, AbstractMesh mesh2, Vector3 pivot1, Vector3 pivot2) {
return this._currentPlugin.createLink(mesh1, mesh2, pivot1, pivot2);
}
public virtual void dispose() {
this._currentPlugin.dispose();
}
public virtual bool isSupported() {
return this._currentPlugin.isSupported();
}
dynamic NoImpostor=0;
dynamic SphereImpostor=1;
dynamic BoxImpostor=2;
dynamic PlaneImpostor=3;
dynamic CompoundImpostor=4;
dynamic MeshImpostor=4;
dynamic CapsuleImpostor=5;
dynamic ConeImpostor=6;
dynamic CylinderImpostor=7;
dynamic ConvexHullImpostor=8;
dynamic Epsilon=0.001;
}
}
