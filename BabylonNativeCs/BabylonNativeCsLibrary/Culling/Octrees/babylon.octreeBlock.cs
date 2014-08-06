// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.octreeBlock.cs" company="">
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
    public partial class OctreeBlock<T> : IOctreeContainer<T> where T : class
    {
        /// <summary>
        /// </summary>
        public Array<T> entries = new Array<T>();

        /// <summary>
        /// </summary>
        private readonly Array<Vector3> _boundingVectors = new Array<Vector3>();

        /// <summary>
        /// </summary>
        private readonly int _capacity;

        /// <summary>
        /// </summary>
        private readonly Action<T, OctreeBlock<T>> _creationFunc;

        /// <summary>
        /// </summary>
        private readonly int _depth;

        /// <summary>
        /// </summary>
        private readonly int _maxDepth;

        /// <summary>
        /// </summary>
        private readonly Vector3 _maxPoint;

        /// <summary>
        /// </summary>
        private readonly Vector3 _minPoint;

        /// <summary>
        /// </summary>
        /// <param name="minPoint">
        /// </param>
        /// <param name="maxPoint">
        /// </param>
        /// <param name="capacity">
        /// </param>
        /// <param name="depth">
        /// </param>
        /// <param name="maxDepth">
        /// </param>
        /// <param name="creationFunc">
        /// </param>
        public OctreeBlock(Vector3 minPoint, Vector3 maxPoint, int capacity, int depth, int maxDepth, Action<T, OctreeBlock<T>> creationFunc)
        {
            this._capacity = capacity;
            this._depth = depth;
            this._maxDepth = maxDepth;
            this._creationFunc = creationFunc;
            this._minPoint = minPoint;
            this._maxPoint = maxPoint;
            this._boundingVectors.Add(minPoint.clone());
            this._boundingVectors.Add(maxPoint.clone());
            this._boundingVectors.Add(minPoint.clone());
            this._boundingVectors[2].x = maxPoint.x;
            this._boundingVectors.Add(minPoint.clone());
            this._boundingVectors[3].y = maxPoint.y;
            this._boundingVectors.Add(minPoint.clone());
            this._boundingVectors[4].z = maxPoint.z;
            this._boundingVectors.Add(maxPoint.clone());
            this._boundingVectors[5].z = minPoint.z;
            this._boundingVectors.Add(maxPoint.clone());
            this._boundingVectors[6].x = minPoint.x;
            this._boundingVectors.Add(maxPoint.clone());
            this._boundingVectors[7].y = minPoint.y;
        }

        /// <summary>
        /// </summary>
        public Array<OctreeBlock<T>> blocks { get; set; }

        /// <summary>
        /// </summary>
        public virtual double capacity
        {
            get
            {
                return this._capacity;
            }
        }

        /// <summary>
        /// </summary>
        public virtual Vector3 maxPoint
        {
            get
            {
                return this._maxPoint;
            }
        }

        /// <summary>
        /// </summary>
        public virtual Vector3 minPoint
        {
            get
            {
                return this._minPoint;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="entries">
        /// </param>
        public virtual void addEntries(Array<T> entries)
        {
            for (var index = 0; index < entries.Length; index++)
            {
                var mesh = entries[index];
                this.addEntry(mesh);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="entry">
        /// </param>
        public virtual void addEntry(T entry)
        {
            if (this.blocks != null)
            {
                for (var index = 0; index < this.blocks.Length; index++)
                {
                    var block = this.blocks[index];
                    block.addEntry(entry);
                }

                return;
            }

            this._creationFunc(entry, this);
            if (this.entries.Length > this.capacity && this._depth < this._maxDepth)
            {
                this.createInnerBlocks();
            }
        }

        /// <summary>
        /// </summary>
        public virtual void createInnerBlocks()
        {
            Octree<T>._CreateBlocks(this._minPoint, this._maxPoint, this.entries, this._capacity, this._depth, this._maxDepth, this, this._creationFunc);
        }

        /// <summary>
        /// </summary>
        /// <param name="sphereCenter">
        /// </param>
        /// <param name="sphereRadius">
        /// </param>
        /// <param name="selection">
        /// </param>
        /// <param name="allowDuplicate">
        /// </param>
        public virtual void intersects(Vector3 sphereCenter, double sphereRadius, SmartArray<T> selection, bool allowDuplicate = false)
        {
            if (BoundingBox.IntersectsSphere(this._minPoint, this._maxPoint, sphereCenter, sphereRadius))
            {
                if (this.blocks != null)
                {
                    for (var index = 0; index < this.blocks.Length; index++)
                    {
                        var block = this.blocks[index];
                        block.intersects(sphereCenter, sphereRadius, selection, allowDuplicate);
                    }

                    return;
                }

                if (allowDuplicate)
                {
                    selection.Append(this.entries);
                }
                else
                {
                    selection.concatWithNoDuplicate(this.entries);
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="ray">
        /// </param>
        /// <param name="selection">
        /// </param>
        public virtual void intersectsRay(Ray ray, SmartArray<T> selection)
        {
            if (ray.intersectsBoxMinMax(this._minPoint, this._maxPoint))
            {
                if (this.blocks != null)
                {
                    for (var index = 0; index < this.blocks.Length; index++)
                    {
                        var block = this.blocks[index];
                        block.intersectsRay(ray, selection);
                    }

                    return;
                }

                selection.concatWithNoDuplicate(this.entries);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="frustumPlanes">
        /// </param>
        /// <param name="selection">
        /// </param>
        /// <param name="allowDuplicate">
        /// </param>
        public virtual void select(Array<Plane> frustumPlanes, SmartArray<T> selection, bool allowDuplicate = false)
        {
            if (BoundingBox.IsInFrustum(this._boundingVectors, frustumPlanes))
            {
                if (this.blocks != null)
                {
                    for (var index = 0; index < this.blocks.Length; index++)
                    {
                        var block = this.blocks[index];
                        block.select(frustumPlanes, selection, allowDuplicate);
                    }

                    return;
                }

                if (allowDuplicate)
                {
                    selection.Append(this.entries);
                }
                else
                {
                    selection.concatWithNoDuplicate(this.entries);
                }
            }
        }
    }
}