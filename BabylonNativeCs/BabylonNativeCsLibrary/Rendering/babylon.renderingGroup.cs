using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class RenderingGroup {
        private Scene _scene;
        private BABYLON.SmartArray < SubMesh > _opaqueSubMeshes = new BABYLON.SmartArray < SubMesh > (256);
        private BABYLON.SmartArray < SubMesh > _transparentSubMeshes = new BABYLON.SmartArray < SubMesh > (256);
        private BABYLON.SmartArray < SubMesh > _alphaTestSubMeshes = new BABYLON.SmartArray < SubMesh > (256);
        private double _activeVertices;
        public double index;
        public RenderingGroup(double index, Scene scene) {
            this._scene = scene;
        }
        public virtual bool render(System.Action < SmartArray < SubMesh > , SmartArray < SubMesh > , SmartArray < SubMesh > , System.Action > customRenderFunction, object beforeTransparents) {
            if (customRenderFunction) {
                customRenderFunction(this._opaqueSubMeshes, this._alphaTestSubMeshes, this._transparentSubMeshes, beforeTransparents);
                return true;
            }
            if (this._opaqueSubMeshes.Length == 0 && this._alphaTestSubMeshes.Length == 0 && this._transparentSubMeshes.Length == 0) {
                return false;
            }
            var engine = this._scene.getEngine();
            var subIndex;
            var submesh;
            for (subIndex = 0; subIndex < this._opaqueSubMeshes.Length; subIndex++) {
                submesh = this._opaqueSubMeshes.data[subIndex];
                this._activeVertices += submesh.verticesCount;
                submesh.render();
            }
            engine.setAlphaTesting(true);
            for (subIndex = 0; subIndex < this._alphaTestSubMeshes.Length; subIndex++) {
                submesh = this._alphaTestSubMeshes.data[subIndex];
                this._activeVertices += submesh.verticesCount;
                submesh.render();
            }
            engine.setAlphaTesting(false);
            if (beforeTransparents) {
                beforeTransparents();
            }
            if (this._transparentSubMeshes.Length) {
                for (subIndex = 0; subIndex < this._transparentSubMeshes.Length; subIndex++) {
                    submesh = this._transparentSubMeshes.data[subIndex];
                    submesh._distanceToCamera = submesh.getBoundingInfo().boundingSphere.centerWorld.subtract(this._scene.activeCamera.position).Length();
                }
                var sortedArray = this._transparentSubMeshes.data.slice(0, this._transparentSubMeshes.Length);
                sortedArray.sort((object a, object b) => {
                    if (a._distanceToCamera < b._distanceToCamera) {
                        return 1;
                    }
                    if (a._distanceToCamera > b._distanceToCamera) {
                        return -1;
                    }
                    return 0;
                });
                engine.setAlphaMode(BABYLON.Engine.ALPHA_COMBINE);
                for (subIndex = 0; subIndex < sortedArray.Length; subIndex++) {
                    submesh = sortedArray[subIndex];
                    this._activeVertices += submesh.verticesCount;
                    submesh.render();
                }
                engine.setAlphaMode(BABYLON.Engine.ALPHA_DISABLE);
            }
            return true;
        }
        public virtual void prepare() {
            this._opaqueSubMeshes.reset();
            this._transparentSubMeshes.reset();
            this._alphaTestSubMeshes.reset();
        }
        public virtual void dispatch(SubMesh subMesh) {
            var material = subMesh.getMaterial();
            var mesh = subMesh.getMesh();
            if (material.needAlphaBlending() || mesh.visibility < 1.0) {
                if (material.alpha > 0 || mesh.visibility < 1.0) {
                    this._transparentSubMeshes.push(subMesh);
                }
            } else
            if (material.needAlphaTesting()) {
                this._alphaTestSubMeshes.push(subMesh);
            } else {
                this._opaqueSubMeshes.push(subMesh);
            }
        }
    }
}