using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
    public class OctreeBlock {
        public Array < T > entries = new Array < T > ();
        public Array < OctreeBlock < T >> blocks;
        private float _depth;
        private float _maxDepth;
        private float _capacity;
        private Vector3 _minPoint;
        private Vector3 _maxPoint;
        private Array < Vector3 > _boundingVectors = new Array < Vector3 > ();
        private System.Action < T, OctreeBlock < T > > _creationFunc;
        public OctreeBlock(Vector3 minPoint, Vector3 maxPoint, float capacity, float depth, float maxDepth, System.Action < T, OctreeBlock < T > > creationFunc) {
            this._capacity = capacity;
            this._depth = depth;
            this._maxDepth = maxDepth;
            this._creationFunc = creationFunc;
            this._minPoint = minPoint;
            this._maxPoint = maxPoint;
            this._boundingVectors.push(minPoint.clone());
            this._boundingVectors.push(maxPoint.clone());
            this._boundingVectors.push(minPoint.clone());
            this._boundingVectors[2].x = maxPoint.x;
            this._boundingVectors.push(minPoint.clone());
            this._boundingVectors[3].y = maxPoint.y;
            this._boundingVectors.push(minPoint.clone());
            this._boundingVectors[4].z = maxPoint.z;
            this._boundingVectors.push(maxPoint.clone());
            this._boundingVectors[5].z = minPoint.z;
            this._boundingVectors.push(maxPoint.clone());
            this._boundingVectors[6].x = minPoint.x;
            this._boundingVectors.push(maxPoint.clone());
            this._boundingVectors[7].y = minPoint.y;
        }
        public virtual float capacity {
            get {
                return this._capacity;
            }
        }
        public virtual Vector3 minPoint {
            get {
                return this._minPoint;
            }
        }
        public virtual Vector3 maxPoint {
            get {
                return this._maxPoint;
            }
        }
        public virtual void addEntry(T entry) {
            if (this.blocks) {
                for (var index = 0; index < this.blocks.Length; index++) {
                    var block = this.blocks[index];
                    block.addEntry(entry);
                }
                return;
            }
            this._creationFunc(entry, this);
            if (this.entries.Length > this.capacity && this._depth < this._maxDepth) {
                this.createInnerBlocks();
            }
        }
        public virtual void addEntries(Array < T > entries) {
            for (var index = 0; index < entries.Length; index++) {
                var mesh = entries[index];
                this.addEntry(mesh);
            }
        }
        public virtual void select(Array < Plane > frustumPlanes, SmartArray < T > selection, bool allowDuplicate = false) {
            if (BABYLON.BoundingBox.IsInFrustum(this._boundingVectors, frustumPlanes)) {
                if (this.blocks) {
                    for (var index = 0; index < this.blocks.Length; index++) {
                        var block = this.blocks[index];
                        block.select(frustumPlanes, selection, allowDuplicate);
                    }
                    return;
                }
                if (allowDuplicate) {
                    selection.concat(this.entries);
                } else {
                    selection.concatWithNoDuplicate(this.entries);
                }
            }
        }
        public virtual void intersects(Vector3 sphereCenter, float sphereRadius, SmartArray < T > selection, bool allowDuplicate = false) {
            if (BABYLON.BoundingBox.IntersectsSphere(this._minPoint, this._maxPoint, sphereCenter, sphereRadius)) {
                if (this.blocks) {
                    for (var index = 0; index < this.blocks.Length; index++) {
                        var block = this.blocks[index];
                        block.intersects(sphereCenter, sphereRadius, selection, allowDuplicate);
                    }
                    return;
                }
                if (allowDuplicate) {
                    selection.concat(this.entries);
                } else {
                    selection.concatWithNoDuplicate(this.entries);
                }
            }
        }
        public virtual void intersectsRay(Ray ray, SmartArray < T > selection) {
            if (ray.intersectsBoxMinMax(this._minPoint, this._maxPoint)) {
                if (this.blocks) {
                    for (var index = 0; index < this.blocks.Length; index++) {
                        var block = this.blocks[index];
                        block.intersectsRay(ray, selection);
                    }
                    return;
                }
                selection.concatWithNoDuplicate(this.entries);
            }
        }
        public virtual void createInnerBlocks() {
            Octree._CreateBlocks(this._minPoint, this._maxPoint, this.entries, this._capacity, this._depth, this._maxDepth, this, this._creationFunc);
        }
    }
}