// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.octree.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    using System;

    /// <summary>
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public partial interface IOctreeContainer<T>
    {
        /// <summary>
        /// </summary>
        Array<OctreeBlock<T>> blocks { get; set; }
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public partial class Octree<T> : IOctreeContainer<T>
    {
        /// <summary>
        /// </summary>
        public Array<T> dynamicContent = new Array<T>();

        /// <summary>
        /// </summary>
        public int maxDepth;

        /// <summary>
        /// </summary>
        private readonly Action<T, OctreeBlock<T>> _creationFunc;

        /// <summary>
        /// </summary>
        private readonly int _maxBlockCapacity;

        /// <summary>
        /// </summary>
        private readonly SmartArray<T> _selectionContent;

        /// <summary>
        /// </summary>
        /// <param name="creationFunc">
        /// </param>
        /// <param name="maxBlockCapacity">
        /// </param>
        /// <param name="maxDepth">
        /// </param>
        public Octree(Action<T, OctreeBlock<T>> creationFunc, int maxBlockCapacity = 64, int maxDepth = 2)
        {
            this.maxDepth = maxDepth;
            this._maxBlockCapacity = maxBlockCapacity;
            this._selectionContent = new SmartArray<T>(1024);
            this._creationFunc = creationFunc;
        }

        /// <summary>
        /// </summary>
        public Array<OctreeBlock<T>> blocks { get; set; }

        /// <summary>
        /// </summary>
        /// <param name="entry">
        /// </param>
        /// <param name="block">
        /// </param>
        public static void CreationFuncForMeshes(AbstractMesh entry, OctreeBlock<AbstractMesh> block)
        {
            if (entry.getBoundingInfo().boundingBox.intersectsMinMax(block.minPoint, block.maxPoint))
            {
                block.entries.Add(entry);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="entry">
        /// </param>
        /// <param name="block">
        /// </param>
        public static void CreationFuncForSubMeshes(SubMesh entry, OctreeBlock<SubMesh> block)
        {
            if (entry.getBoundingInfo().boundingBox.intersectsMinMax(block.minPoint, block.maxPoint))
            {
                block.entries.Add(entry);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="worldMin">
        /// </param>
        /// <param name="worldMax">
        /// </param>
        /// <param name="entries">
        /// </param>
        /// <param name="maxBlockCapacity">
        /// </param>
        /// <param name="currentDepth">
        /// </param>
        /// <param name="maxDepth">
        /// </param>
        /// <param name="target">
        /// </param>
        /// <param name="creationFunc">
        /// </param>
        public static void _CreateBlocks(
            Vector3 worldMin, 
            Vector3 worldMax, 
            Array<T> entries, 
            int maxBlockCapacity, 
            int currentDepth, 
            int maxDepth, 
            IOctreeContainer<T> target, 
            Action<T, OctreeBlock<T>> creationFunc)
        {
            target.blocks = new Array<OctreeBlock<T>>();
            var blockSize = new Vector3((worldMax.x - worldMin.x) / 2, (worldMax.y - worldMin.y) / 2, (worldMax.z - worldMin.z) / 2);
            for (var x = 0; x < 2; x++)
            {
                for (var y = 0; y < 2; y++)
                {
                    for (var z = 0; z < 2; z++)
                    {
                        var localMin = worldMin.add(blockSize.multiplyByFloats(x, y, z));
                        var localMax = worldMin.add(blockSize.multiplyByFloats(x + 1, y + 1, z + 1));
                        var block = new OctreeBlock<T>(localMin, localMax, maxBlockCapacity, currentDepth + 1, maxDepth, creationFunc);
                        block.addEntries(entries);
                        target.blocks.Add(block);
                    }
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="entry">
        /// </param>
        public virtual void addMesh(T entry)
        {
            for (var index = 0; index < this.blocks.Length; index++)
            {
                var block = this.blocks[index];
                block.addEntry(entry);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sphereCenter">
        /// </param>
        /// <param name="sphereRadius">
        /// </param>
        /// <param name="allowDuplicate">
        /// </param>
        /// <returns>
        /// </returns>
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
                this._selectionContent.Append(this.dynamicContent);
            }
            else
            {
                this._selectionContent.concatWithNoDuplicate(this.dynamicContent);
            }

            return this._selectionContent;
        }

        /// <summary>
        /// </summary>
        /// <param name="ray">
        /// </param>
        /// <returns>
        /// </returns>
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

        /// <summary>
        /// </summary>
        /// <param name="frustumPlanes">
        /// </param>
        /// <param name="allowDuplicate">
        /// </param>
        /// <returns>
        /// </returns>
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
                this._selectionContent.Append(this.dynamicContent);
            }
            else
            {
                this._selectionContent.concatWithNoDuplicate(this.dynamicContent);
            }

            return this._selectionContent;
        }

        /// <summary>
        /// </summary>
        /// <param name="worldMin">
        /// </param>
        /// <param name="worldMax">
        /// </param>
        /// <param name="entries">
        /// </param>
        public virtual void update(Vector3 worldMin, Vector3 worldMax, Array<T> entries)
        {
            _CreateBlocks(worldMin, worldMax, entries, this._maxBlockCapacity, 0, this.maxDepth, this, this._creationFunc);
        }
    }
}