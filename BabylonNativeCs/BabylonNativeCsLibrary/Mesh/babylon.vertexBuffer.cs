using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class VertexBuffer {
private Mesh _mesh;
private Engine _engine;
private WebGLBuffer _buffer;
private float[] _data;
private bool _updatable;
private string _kind;
private float _strideSize;
public VertexBuffer(object engine, float[] data, string kind, bool updatable, bool postponeInternalCreation) {
if (engineisMesh) 
{
this._engine=engine.getScene().getEngine();
}
else 
{
this._engine=engine;
}
this._updatable=updatable;
this._data=data;
if (!postponeInternalCreation) 
{
this.create();
}
this._kind=kind;
switch (kind) {
case VertexBuffer.PositionKind: 
this._strideSize=3;
break;
case VertexBuffer.NormalKind: 
this._strideSize=3;
break;
case VertexBuffer.UVKind: 
this._strideSize=2;
break;
case VertexBuffer.UV2Kind: 
this._strideSize=2;
break;
case VertexBuffer.ColorKind: 
this._strideSize=3;
break;
case VertexBuffer.MatricesIndicesKind: 
this._strideSize=4;
break;
case VertexBuffer.MatricesWeightsKind: 
this._strideSize=4;
break;
}
}
public virtual bool isUpdatable() {
return this._updatable;
}
public virtual float[] getData() {
return this._data;
}
public virtual WebGLBuffer getBuffer() {
return this._buffer;
}
public virtual float getStrideSize() {
return this._strideSize;
}
public virtual void create(float[] data) {
if (!data&&this._buffer) 
{
return;
}
data=data||this._data;
if (!this._buffer) 
{
if (this._updatable) 
{
this._buffer=this._engine.createDynamicVertexBuffer(data.length*4);
}
else 
{
this._buffer=this._engine.createVertexBuffer(data);
}
}
if (this._updatable) 
{
this._engine.updateDynamicVertexBuffer(this._buffer, data);
this._data=data;
}
}
public virtual void update(float[] data) {
this.create(data);
}
public virtual void dispose() {
if (!this._buffer) 
{
return;
}
if (this._engine._releaseBuffer(this._buffer)) 
{
this._buffer=null;
}
}
dynamic _PositionKind="positio";
dynamic _NormalKind="norma";
dynamic _UVKind="u";
dynamic _UV2Kind="uv";
dynamic _ColorKind="colo";
dynamic _MatricesIndicesKind="matricesIndice";
dynamic _MatricesWeightsKind="matricesWeight";
}
}
