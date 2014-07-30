using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class CannonJSPlugin: IPhysicsEnginePlugin {
        public System.Func < double, double > checkWithEpsilon;
        private object _world;
        private Array < object > _registeredMeshes = new Array < object > ();
        private Array < object > _physicsMaterials = new Array < object > ();
        public virtual void initialize(double iterations = 10) {
            this._world = new CANNON.World();
            this._world.broadphase = new CANNON.NaiveBroadphase();
            this._world.solver.iterations = iterations;
        }
        private double _checkWithEpsilon(double value) {
            return (value < BABYLON.PhysicsEngine.Epsilon) ? BABYLON.PhysicsEngine.Epsilon : value;
        }
        public virtual void runOneStep(double delta) {
            this._world.step(delta);
            for (var index = 0; index < this._registeredMeshes.Length; index++) {
                var registeredMesh = this._registeredMeshes[index];
                if (registeredMesh.isChild) {
                    continue;
                }
                registeredMesh.mesh.position.x = registeredMesh.body.position.x;
                registeredMesh.mesh.position.y = registeredMesh.body.position.z;
                registeredMesh.mesh.position.z = registeredMesh.body.position.y;
                if (!registeredMesh.mesh.rotationQuaternion) {
                    registeredMesh.mesh.rotationQuaternion = new BABYLON.Quaternion(0, 0, 0, 1);
                }
                registeredMesh.mesh.rotationQuaternion.x = registeredMesh.body.quaternion.x;
                registeredMesh.mesh.rotationQuaternion.y = registeredMesh.body.quaternion.z;
                registeredMesh.mesh.rotationQuaternion.z = registeredMesh.body.quaternion.y;
                registeredMesh.mesh.rotationQuaternion.w = -registeredMesh.body.quaternion.w;
            }
        }
        public virtual void setGravity(Vector3 gravity) {
            this._world.gravity.set(gravity.x, gravity.z, gravity.y);
        }
        public virtual object registerMesh(AbstractMesh mesh, double impostor, PhysicsBodyCreationOptions options = null) {
            this.unregisterMesh(mesh);
            mesh.computeWorldMatrix(true);
            switch (impostor) {
                case BABYLON.PhysicsEngine.SphereImpostor:
                    var bbox = mesh.getBoundingInfo().boundingBox;
                    var radiusX = bbox.maximumWorld.x - bbox.minimumWorld.x;
                    var radiusY = bbox.maximumWorld.y - bbox.minimumWorld.y;
                    var radiusZ = bbox.maximumWorld.z - bbox.minimumWorld.z;
                    return this._createSphere(Math.Max(this._checkWithEpsilon(radiusX), this._checkWithEpsilon(radiusY), this._checkWithEpsilon(radiusZ)) / 2, mesh, options);
                case BABYLON.PhysicsEngine.BoxImpostor:
                    bbox = mesh.getBoundingInfo().boundingBox;
                    var min = bbox.minimumWorld;
                    var Max = bbox.maximumWorld;
                    var box = Max.subtract(min).scale(0.5);
                    return this._createBox(this._checkWithEpsilon(box.x), this._checkWithEpsilon(box.y), this._checkWithEpsilon(box.z), mesh, options);
                case BABYLON.PhysicsEngine.PlaneImpostor:
                    return this._createPlane(mesh, options);
                case BABYLON.PhysicsEngine.MeshImpostor:
                    var rawVerts = mesh.getVerticesData(BABYLON.VertexBuffer.PositionKind);
                    var rawFaces = mesh.getIndices();
                    return this._createConvexPolyhedron(rawVerts, rawFaces, mesh, options);
            }
            return null;
        }
        private object _createSphere(double radius, AbstractMesh mesh, PhysicsBodyCreationOptions options = null) {
            var shape = new CANNON.Sphere(radius);
            if (!options) {
                return shape;
            }
            return this._createRigidBodyFromShape(shape, mesh, options.mass, options.friction, options.restitution);
        }
        private object _createBox(double x, double y, double z, AbstractMesh mesh, PhysicsBodyCreationOptions options = null) {
            var shape = new CANNON.Box(new CANNON.Vec3(x, z, y));
            if (!options) {
                return shape;
            }
            return this._createRigidBodyFromShape(shape, mesh, options.mass, options.friction, options.restitution);
        }
        private object _createPlane(AbstractMesh mesh, PhysicsBodyCreationOptions options = null) {
            var shape = new CANNON.Plane();
            if (!options) {
                return shape;
            }
            return this._createRigidBodyFromShape(shape, mesh, options.mass, options.friction, options.restitution);
        }
        private object _createConvexPolyhedron(Array < double > rawVerts, Array < double > rawFaces, AbstractMesh mesh, PhysicsBodyCreationOptions options = null) {
            var verts = new Array < object > ();
            var faces = new Array < object > ();
            mesh.computeWorldMatrix(true);
            for (var i = 0; i < rawVerts.Length; i += 3) {
                var transformed = BABYLON.Vector3.Zero();
                BABYLON.Vector3.TransformNormalFromFloatsToRef(rawVerts[i], rawVerts[i + 1], rawVerts[i + 2], mesh.getWorldMatrix(), transformed);
                verts.push(new CANNON.Vec3(transformed.x, transformed.z, transformed.y));
            }
            for (var j = 0; j < rawFaces.Length; j += 3) {
                faces.push(new Array < object > (rawFaces[j], rawFaces[j + 2], rawFaces[j + 1]));
            }
            var shape = new CANNON.ConvexPolyhedron(verts, faces);
            if (!options) {
                return shape;
            }
            return this._createRigidBodyFromShape(shape, mesh, options.mass, options.friction, options.restitution);
        }
        private void _addMaterial(double friction, double restitution) {
            var index;
            var mat;
            for (index = 0; index < this._physicsMaterials.Length; index++) {
                mat = this._physicsMaterials[index];
                if (mat.friction == friction && mat.restitution == restitution) {
                    return mat;
                }
            }
            var currentMat = new CANNON.Material();
            currentMat.friction = friction;
            currentMat.restitution = restitution;
            this._physicsMaterials.push(currentMat);
            for (index = 0; index < this._physicsMaterials.Length; index++) {
                mat = this._physicsMaterials[index];
                var contactMaterial = new CANNON.ContactMaterial(mat, currentMat, mat.friction * currentMat.friction, mat.restitution * currentMat.restitution);
                contactMaterial.contactEquationStiffness = 1e10;
                contactMaterial.contactEquationRegularizationTime = 10;
                this._world.addContactMaterial(contactMaterial);
            }
            return currentMat;
        }
        private object _createRigidBodyFromShape(object shape, AbstractMesh mesh, double mass, double friction, double restitution) {
            var initialRotation = null;
            if (mesh.rotationQuaternion) {
                initialRotation = mesh.rotationQuaternion.clone();
                mesh.rotationQuaternion = new BABYLON.Quaternion(0, 0, 0, 1);
            }
            var material = this._addMaterial(friction, restitution);
            var body = new CANNON.RigidBody(mass, shape, material);
            if (initialRotation) {
                body.quaternion.x = initialRotation.x;
                body.quaternion.z = initialRotation.y;
                body.quaternion.y = initialRotation.z;
                body.quaternion.w = -initialRotation.w;
            }
            body.position.set(mesh.position.x, mesh.position.z, mesh.position.y);
            this._world.add(body);
            this._registeredMeshes.push(new {});
            return body;
        }
        public virtual object registerMeshesAsCompound(Array < PhysicsCompoundBodyPart > parts, PhysicsBodyCreationOptions options) {
            var compoundShape = new CANNON.Compound();
            for (var index = 0; index < parts.Length; index++) {
                var mesh = parts[index].mesh;
                var shape = this.registerMesh(mesh, parts[index].impostor);
                if (index == 0) {
                    compoundShape.addChild(shape, new CANNON.Vec3(0, 0, 0));
                } else {
                    compoundShape.addChild(shape, new CANNON.Vec3(mesh.position.x, mesh.position.z, mesh.position.y));
                }
            }
            var initialMesh = parts[0].mesh;
            var body = this._createRigidBodyFromShape(compoundShape, initialMesh, options.mass, options.friction, options.restitution);
            body.parts = parts;
            return body;
        }
        private void _unbindBody(object body) {
            for (var index = 0; index < this._registeredMeshes.Length; index++) {
                var registeredMesh = this._registeredMeshes[index];
                if (registeredMesh.body == body) {
                    registeredMesh.body = null;
                }
            }
        }
        public virtual void unregisterMesh(AbstractMesh mesh) {
            for (var index = 0; index < this._registeredMeshes.Length; index++) {
                var registeredMesh = this._registeredMeshes[index];
                if (registeredMesh.mesh == mesh) {
                    if (registeredMesh.body) {
                        this._world.remove(registeredMesh.body);
                        this._unbindBody(registeredMesh.body);
                    }
                    this._registeredMeshes.splice(index, 1);
                    return;
                }
            }
        }
        public virtual void applyImpulse(AbstractMesh mesh, Vector3 force, Vector3 contactPoint) {
            var worldPoint = new CANNON.Vec3(contactPoint.x, contactPoint.z, contactPoint.y);
            var impulse = new CANNON.Vec3(force.x, force.z, force.y);
            for (var index = 0; index < this._registeredMeshes.Length; index++) {
                var registeredMesh = this._registeredMeshes[index];
                if (registeredMesh.mesh == mesh) {
                    registeredMesh.body.applyImpulse(impulse, worldPoint);
                    return;
                }
            }
        }
        public virtual bool createLink(AbstractMesh mesh1, AbstractMesh mesh2, Vector3 pivot1, Vector3 pivot2) {
            var body1 = null;
            var body2 = null;
            for (var index = 0; index < this._registeredMeshes.Length; index++) {
                var registeredMesh = this._registeredMeshes[index];
                if (registeredMesh.mesh == mesh1) {
                    body1 = registeredMesh.body;
                } else
                if (registeredMesh.mesh == mesh2) {
                    body2 = registeredMesh.body;
                }
            }
            if (!body1 || !body2) {
                return false;
            }
            var constraint = new CANNON.PointToPointConstraint(body1, new CANNON.Vec3(pivot1.x, pivot1.z, pivot1.y), body2, new CANNON.Vec3(pivot2.x, pivot2.z, pivot2.y));
            this._world.addConstraint(constraint);
            return true;
        }
        public virtual void dispose() {
            while (this._registeredMeshes.Length) {
                this.unregisterMesh(this._registeredMeshes[0].mesh);
            }
        }
        public virtual bool isSupported() {
            return window.CANNON != null;
        }
    }
}