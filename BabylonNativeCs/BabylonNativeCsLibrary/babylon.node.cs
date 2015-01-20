// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.node.cs" company="">
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
    public partial class Node
    {
        /// <summary>
        /// </summary>
        public Cache _cache;

        /// <summary>
        /// </summary>
        public int _currentRenderId = -1;

        /// <summary>
        /// </summary>
        public Array<Animation> animations = new Array<Animation>();

        /// <summary>
        /// </summary>
        public string id;

        /// <summary>
        /// </summary>
        public string name;

        /// <summary>
        /// </summary>
        public Action<Node> onReady;

        /// <summary>
        /// </summary>
        public Node parent;

        /// <summary>
        /// </summary>
        public string state = string.Empty;

        /// <summary>
        /// </summary>
        private bool _isEnabled = true;

        /// <summary>
        /// </summary>
        private bool _isReady = true;

        /// <summary>
        /// </summary>
        private readonly Scene _scene;

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="scene">
        /// </param>
        public Node(string name, Scene scene)
        {
            this.name = name;
            this.id = name;
            this._scene = scene;
            this._initCache();
        }

        /// <summary>
        /// </summary>
        /// <param name="list">
        /// </param>
        /// <param name="results">
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        public void _getDescendants<T>(Array<T> list, Array<Node> results) where T : Node
        {
            for (var index = 0; index < list.Length; index++)
            {
                var item = list[index];
                if (item.isDescendantOf(this))
                {
                    results.Add(item);
                }
            }
        }

        /// <summary>
        /// </summary>
        public virtual void _initCache()
        {
            this._cache = new Cache();
            this._cache.parent = null;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual bool _isSynchronized()
        {
            return true;
        }

        /// <summary>
        /// </summary>
        /// <param name="state">
        /// </param>
        public virtual void _setReady(bool state)
        {
            if (state == this._isReady)
            {
                return;
            }

            if (!state)
            {
                this._isReady = false;
                return;
            }

            this._isReady = true;
            if (this.onReady != null)
            {
                this.onReady(this);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="ignoreParentClass">
        /// </param>
        public virtual void _updateCache(bool ignoreParentClass = false)
        {
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Array<Node> getDescendants()
        {
            var results = new Array<Node>();
            this._getDescendants(this._scene.meshes, results);
            this._getDescendants(this._scene.lights, results);
            this._getDescendants(this._scene.cameras, results);
            return results;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Engine getEngine()
        {
            return this._scene.getEngine();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Scene getScene()
        {
            return this._scene;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Matrix getWorldMatrix()
        {
            return Matrix.Identity();
        }

        /// <summary>
        /// </summary>
        /// <param name="update">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool hasNewParent(bool update = false)
        {
            if (this._cache.parent == this.parent)
            {
                return false;
            }

            if (update)
            {
                this._cache.parent = this.parent;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        /// <param name="ancestor">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool isDescendantOf(Node ancestor)
        {
            if (this.parent != null)
            {
                if (this.parent == ancestor)
                {
                    return true;
                }

                return this.parent.isDescendantOf(ancestor);
            }

            return false;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual bool isEnabled()
        {
            if (!this._isEnabled)
            {
                return false;
            }

            if (this.parent != null)
            {
                return this.parent.isEnabled();
            }

            return true;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual bool isReady()
        {
            return this._isReady;
        }

        /// <summary>
        /// </summary>
        /// <param name="updateCache">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool isSynchronized(bool updateCache = false)
        {
            var check = this.hasNewParent();

            check = check || !this.isSynchronizedWithParent();
            check = check || !this._isSynchronized();
            if (updateCache)
            {
                this.updateCache(true);
            }

            return !check;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual bool isSynchronizedWithParent()
        {
            return (this.parent != null) ? this.parent._currentRenderId <= this._currentRenderId : true;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        /// </param>
        public virtual void setEnabled(bool value)
        {
            this._isEnabled = value;
        }

        /// <summary>
        /// </summary>
        /// <param name="force">
        /// </param>
        public virtual void updateCache(bool force = false)
        {
            if (!force && this.isSynchronized())
            {
                return;
            }

            this._cache.parent = this.parent;
            this._updateCache();
        }
    }
}