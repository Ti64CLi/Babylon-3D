using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial interface IOctreeContainer<T>
    {
        Array<OctreeBlock<T>> blocks
        {
            get;
        }
    }
    public partial class Octree<T> : IOctreeContainer<T>
    {
        public Array<OctreeBlock<T>> blocks;
        public Array<T> dynamicContent = new Array<T>();
        private int _maxBlockCapacity;
        private SmartArray<T> _selectionContent;
        private System.Action<T, OctreeBlock<T>> _creationFunc;
        public int maxDepth;
        public Octree(System.Action<T, OctreeBlock<T>> creationFunc, int maxBlockCapacity = 64, int maxDepth = 2)
        {
            this._maxBlockCapacity = maxBlockCapacity;
            this._selectionContent = new BABYLON.SmartArray<T>(1024);
            this._creationFunc = creationFunc;
        }
        public virtual void update(Vector3 worldMin, Vector3 worldMax, Array<T> entries)
        {
            Octree<T>._CreateBlocks(worldMin, worldMax, entries, this._maxBlockCapacity, 0, this.maxDepth, this, this._creationFunc);
        }
        public virtual void addMesh(T entry)
        {
            for (var index = 0; index < this.blocks.Length; index++)
            {
                var block = this.blocks[index];
                block.addEntry(entry);
            }
        }
        public virtual SmartArray<T> select(Array<Plane> frustumPlanes, bool allowDuplicate = false)
        {
            this._selectionContent.reset();
            for (var index = 0; index < this.blocks.Length; index++)
            {
                var block = this.blocks[index];
                block.select(frustumPlanes, this._selectionContent, allowDuplicate);
            }
            if (allowDuplicate)
            {
                this._selectionContent.concat(this.dynamicContent);
            }
            else
            {
                this._selectionContent.concatWithNoDuplicate(this.dynamicContent);
            }
            return this._selectionContent;
        }
        public virtual SmartArray<T> intersects(Vector3 sphereCenter, double sphereRadius, bool allowDuplicate = false)
        {
            this._selectionContent.reset();
            for (var index = 0; index < this.blocks.Length; index++)
            {
                var block = this.blocks[index];
                block.intersects(sphereCenter, sphereRadius, this._selectionContent, allowDuplicate);
            }
            if (allowDuplicate)
            {
                this._selectionContent.concat(this.dynamicContent);
            }
            else
            {
                this._selectionContent.concatWithNoDuplicate(this.dynamicContent);
            }
            return this._selectionContent;
        }
        public virtual SmartArray<T> intersectsRay(Ray ray)
        {
            this._selectionContent.reset();
            for (var index = 0; index < this.blocks.Length; index++)
            {
                var block = this.blocks[index];
                block.intersectsRay(ray, this._selectionContent);
            }
            this._selectionContent.concatWithNoDuplicate(this.dynamicContent);
            return this._selectionContent;
        }
        public static void _CreateBlocks(Vector3 worldMin, Vector3 worldMax, Array<T> entries, int maxBlockCapacity, int currentDepth, int maxDepth, IOctreeContainer<T> target, System.Action<T, OctreeBlock<T>> creationFunc)
        {
            target.blocks = new Array<OctreeBlock<T>>();
            var blockSize = new BABYLON.Vector3((worldMax.x - worldMin.x) / 2, (worldMax.y - worldMin.y) / 2, (worldMax.z - worldMin.z) / 2);
            for (var x = 0; x < 2; x++)
            {
                for (var y = 0; y < 2; y++)
                {
                    for (var z = 0; z < 2; z++)
                    {
                        var localMin = worldMin.add(blockSize.multiplyByFloats(x, y, z));
                        var localMax = worldMin.add(blockSize.multiplyByFloats(x + 1, y + 1, z + 1));
                        var block = new BABYLON.OctreeBlock<T>(localMin, localMax, maxBlockCapacity, currentDepth + 1, maxDepth, creationFunc);
                        block.addEntries(entries);
                        target.blocks.push(block);
                    }
                }
            }
        }
        public static void CreationFuncForMeshes(AbstractMesh entry, OctreeBlock<AbstractMesh> block)
        {
            if (entry.getBoundingInfo().boundingBox.intersectsMinMax(block.minPoint, block.maxPoint))
            {
                block.entries.push(entry);
            }
        }
        public static void CreationFuncForSubMeshes(SubMesh entry, OctreeBlock<SubMesh> block)
        {
            if (entry.getBoundingInfo().boundingBox.intersectsMinMax(block.minPoint, block.maxPoint))
            {
                block.entries.push(entry);
            }
        }
    }
}