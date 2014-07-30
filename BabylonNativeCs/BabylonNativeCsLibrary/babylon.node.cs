using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class Node {
        public Node parent;
        public string name;
        public string id;
        public string state = "";
        public Array < Animation > animations = new Array < Animation > ();
        public System.Action < Node > onReady;
        private double _childrenFlag = -1;
        private bool _isEnabled = true;
        private bool _isReady = true;
        public double _currentRenderId = -1;
        private Scene _scene;
        public dynamic _cache;
        public Node(string name, object scene) {
            this.name = name;
            this.id = name;
            this._scene = scene;
            this._initCache();
        }
        public virtual Scene getScene() {
            return this._scene;
        }
        public virtual Engine getEngine() {
            return this._scene.getEngine();
        }
        public virtual Matrix getWorldMatrix() {
            return Matrix.Identity();
        }
        public virtual void _initCache() {
            this._cache = new {};
            this._cache.parent = null;
        }
        public virtual void updateCache(bool force = false) {
            if (!force && this.isSynchronized())
                return;
            this._cache.parent = this.parent;
            this._updateCache();
        }
        public virtual void _updateCache(bool ignoreParentClass = false) {}
        public virtual bool _isSynchronized() {
            return true;
        }
        public virtual bool isSynchronizedWithParent() {
            return (this.parent) ? this.parent._currentRenderId <= this._currentRenderId : true;
        }
        public virtual bool isSynchronized(bool updateCache = false) {
            var check = this.hasNewParent();
            check = check || !this.isSynchronizedWithParent();
            check = check || !this._isSynchronized();
            if (updateCache)
                this.updateCache(true);
            return !check;
        }
        public virtual bool hasNewParent(bool update = false) {
            if (this._cache.parent == this.parent)
                return false;
            if (update)
                this._cache.parent = this.parent;
            return true;
        }
        public virtual bool isReady() {
            return this._isReady;
        }
        public virtual bool isEnabled() {
            if (!this._isEnabled) {
                return false;
            }
            if (this.parent) {
                return this.parent.isEnabled();
            }
            return true;
        }
        public virtual void setEnabled(bool value) {
            this._isEnabled = value;
        }
        public virtual bool isDescendantOf(Node ancestor) {
            if (this.parent) {
                if (this.parent == ancestor) {
                    return true;
                }
                return this.parent.isDescendantOf(ancestor);
            }
            return false;
        }
        public virtual void _getDescendants(Array < Node > list, Array < Node > results) {
            for (var index = 0; index < list.Length; index++) {
                var item = list[index];
                if (item.isDescendantOf(this)) {
                    results.push(item);
                }
            }
        }
        public virtual Array < Node > getDescendants() {
            var results = new Array < object > ();
            this._getDescendants(this._scene.meshes, results);
            this._getDescendants(this._scene.lights, results);
            this._getDescendants(this._scene.cameras, results);
            return results;
        }
        public virtual void _setReady(bool state) {
            if (state == this._isReady) {
                return;
            }
            if (!state) {
                this._isReady = false;
                return;
            }
            this._isReady = true;
            if (this.onReady) {
                this.onReady(this);
            }
        }
    }
}