using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class LinesMesh: Mesh {
dynamic color=new BABYLON.Color3(1, 1, 1);
private ShaderMaterial _colorShader;
private WebGLBuffer _ib;
private float _indicesLength;
dynamic _indices=new Array();
public LinesMesh(string name, Scene scene, dynamic updatable) {
base(name, scene);
this._colorShader=new ShaderMaterial("colorShade", scene, "colo", new dynamic());
}
public virtual void _bind(SubMesh subMesh, Effect effect, bool wireframe) {
var engine = this.getScene().getEngine();
var indexToBind = this._geometry.getIndexBuffer();
engine.bindBuffers(this._geometry.getVertexBuffer(VertexBuffer.PositionKind).getBuffer(), indexToBind, new Array<object>(), 3*4, this._colorShader.getEffect());
this._colorShader.setColor3("colo", this.color);
}
public virtual void _draw(SubMesh subMesh, bool useTriangles, float instancesCount) {
if (!this._geometry||!this._geometry.getVertexBuffers()||!this._geometry.getIndexBuffer()) 
{
return;
}
var engine = this.getScene().getEngine();
engine.draw(false, subMesh.indexStart, subMesh.indexCount);
}
public virtual void intersects(Ray ray, bool fastCheck) {
return null;
}
public virtual void dispose(bool doNotRecurse) {
this._colorShader.dispose();
base.dispose(doNotRecurse);
}
}
}
