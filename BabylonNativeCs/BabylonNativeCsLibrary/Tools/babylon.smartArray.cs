using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class SmartArray {
public Array<T> data;
public float length=0;
private float _id;
dynamic _duplicateId=0;
public SmartArray(float capacity) {
this.data=new Array(capacity);
this._id=SmartArray._GlobalId++;
}
public virtual void push(dynamic value) {
this.data[this.length++]=value;
if (this.length>this.data.length) 
{
this.data.length*=2;
}
if (!value.__smartArrayFlags) 
{
value.__smartArrayFlags=new dynamic();
}
value.__smartArrayFlags[this._id]=this._duplicateId;
}
public virtual void pushNoDuplicate(dynamic value) {
if (value.__smartArrayFlags&&value.__smartArrayFlags[this._id]==this._duplicateId) 
{
return;
}
this.push(value);
}
public virtual void sort(dynamic compareFn) {
this.data.sort(compareFn);
}
public virtual void reset() {
this.length=0;
this._duplicateId++;
}
public virtual void concat(object array) {
if (array.length==0) 
{
return;
}
if (this.length+array.length>this.data.length) 
{
this.data.length=(this.length+array.length)*2;
}
for (var index = 0;index<array.length;index++) 
{
this.data[this.length++]=(array.data||array)[index];
}
}
public virtual void concatWithNoDuplicate(object array) {
if (array.length==0) 
{
return;
}
if (this.length+array.length>this.data.length) 
{
this.data.length=(this.length+array.length)*2;
}
for (var index = 0;index<array.length;index++) 
{
var item = (array.data||array)[index];
this.pushNoDuplicate(item);
}
}
public virtual float indexOf(dynamic value) {
var position = this.data.indexOf(value);
if (position>=this.length) 
{
return -1;
}
return position;
}
dynamic _GlobalId=0;
}
}
