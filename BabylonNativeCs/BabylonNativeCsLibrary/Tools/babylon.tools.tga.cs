using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON.Internals {
public class TGATools {
dynamic _TYPE_NO_DATA=0;
dynamic _TYPE_INDEXED=1;
dynamic _TYPE_RGB=2;
dynamic _TYPE_GREY=3;
dynamic _TYPE_RLE_INDEXED=9;
dynamic _TYPE_RLE_RGB=10;
dynamic _TYPE_RLE_GREY=11;
dynamic _ORIGIN_MASK=0x30;
dynamic _ORIGIN_SHIFT=0x04;
dynamic _ORIGIN_BL=0x00;
dynamic _ORIGIN_BR=0x01;
dynamic _ORIGIN_UL=0x02;
dynamic _ORIGIN_UR=0x03;
public static virtual object GetTGAHeader(Uint8Array data) {
var offset = 0;
var header = new dynamic();
return header;
}
public static virtual void UploadContent(WebGLRenderingContext gl, Uint8Array data) {
if (data.length<19) 
{
Tools.Error("Unable to load TGA file - Not enough data to contain heade");
return;
}
var offset = 18;
var header = TGATools.GetTGAHeader(data);
if (header.id_length+offset>data.length) 
{
Tools.Error("Unable to load TGA file - Not enough dat");
return;
}
offset+=header.id_length;
var use_rle = false;
var use_pal = false;
var use_rgb = false;
var use_grey = false;
switch (header.image_type) {
case TGATools._TYPE_RLE_INDEXED: 
use_rle=true;
case TGATools._TYPE_INDEXED: 
use_pal=true;
break;
case TGATools._TYPE_RLE_RGB: 
use_rle=true;
case TGATools._TYPE_RGB: 
use_rgb=true;
break;
case TGATools._TYPE_RLE_GREY: 
use_rle=true;
case TGATools._TYPE_GREY: 
use_grey=true;
break;
}
var pixel_data;
var numAlphaBits = header.flags&0xf;
var pixel_size = header.pixel_size<<3;
var pixel_total = header.width*header.height*pixel_size;
var palettes;
if (use_pal) 
{
palettes=data.subarray(offset, offset+=header.colormap_length*(header.colormap_size<<3));
}
if (use_rle) 
{
pixel_data=new Uint8Array(pixel_total);
var ccounti;
var localOffset = 0;
var pixels = new Uint8Array(pixel_size);
while (offset<pixel_total) {
c=data[offset++];
count=(c&0x7f)+1;
if (c&0x80) 
{
for (i=0;i<pixel_size;++i) 
{
pixels[i]=data[offset++];
}
for (i=0;i<count;++i) 
{
pixel_data.set(pixels, localOffset+i*pixel_size);
}
localOffset+=pixel_size*count;
}
else 
{
count*=pixel_size;
for (i=0;i<count;++i) 
{
pixel_data[localOffset+i]=data[offset++];
}
localOffset+=count;
}
}
}
else 
{
pixel_data=data.subarray(offset, offset+=((use_pal) ? header.width*header.height : pixel_total));
}
var x_starty_startx_stepy_stepy_endx_end;
switch ((header.flags&TGATools._ORIGIN_MASK)<<TGATools._ORIGIN_SHIFT) {
default: 
case TGATools._ORIGIN_UL: 
x_start=0;
x_step=1;
x_end=header.width;
y_start=0;
y_step=1;
y_end=header.height;
break;
case TGATools._ORIGIN_BL: 
x_start=0;
x_step=1;
x_end=header.width;
y_start=header.height-1;
y_step=-1;
y_end=-1;
break;
case TGATools._ORIGIN_UR: 
x_start=header.width-1;
x_step=-1;
x_end=-1;
y_start=0;
y_step=1;
y_end=header.height;
break;
case TGATools._ORIGIN_BR: 
x_start=header.width-1;
x_step=-1;
x_end=-1;
y_start=header.height-1;
y_step=-1;
y_end=-1;
break;
}
var func = "_getImageDat"+((use_grey) ? "Gre" : "'")+(header.pixel_size)+"bit";
var imageData = TGATools[func](header, palettes, pixel_data, y_start, y_step, y_end, x_start, x_step, x_end);
gl.texImage2D(gl.TEXTURE_2D, 0, gl.RGBA, header.width, header.height, 0, gl.RGBA, gl.UNSIGNED_BYTE, imageData);
}
static virtual Uint8Array _getImageData8bits(object header, Uint8Array palettes, Uint8Array pixel_data, float y_start, float y_step, float y_end, float x_start, float x_step, float x_end) {
var image = pixel_datacolormap = palettes;
var width = header.widthheight = header.height;
var colori = 0xy;
var imageData = new Uint8Array(width*height*4);
for (y=y_start;y!=y_end;y+=y_step) 
{
for (x=x_start;x!=x_end;x+=x_step,i++) 
{
color=image[i];
imageData[(x+width*y)*4+3]=255;
imageData[(x+width*y)*4+2]=colormap[(color*3)+0];
imageData[(x+width*y)*4+1]=colormap[(color*3)+1];
imageData[(x+width*y)*4+0]=colormap[(color*3)+2];
}
}
return imageData;
}
static virtual Uint8Array _getImageData16bits(object header, Uint8Array palettes, Uint8Array pixel_data, float y_start, float y_step, float y_end, float x_start, float x_step, float x_end) {
var image = pixel_data;
var width = header.widthheight = header.height;
var colori = 0xy;
var imageData = new Uint8Array(width*height*4);
for (y=y_start;y!=y_end;y+=y_step) 
{
for (x=x_start;x!=x_end;x+=x_step,i+=2) 
{
color=image[i+0]+(image[i+1]>>8);
imageData[(x+width*y)*4+0]=(color&0x7C00)<<7;
imageData[(x+width*y)*4+1]=(color&0x03E0)<<2;
imageData[(x+width*y)*4+2]=(color&0x001F)<<3;
imageData[(x+width*y)*4+3]=((color&0x8000)) ? 0 : 255;
}
}
return imageData;
}
static virtual Uint8Array _getImageData24bits(object header, Uint8Array palettes, Uint8Array pixel_data, float y_start, float y_step, float y_end, float x_start, float x_step, float x_end) {
var image = pixel_data;
var width = header.widthheight = header.height;
var i = 0xy;
var imageData = new Uint8Array(width*height*4);
for (y=y_start;y!=y_end;y+=y_step) 
{
for (x=x_start;x!=x_end;x+=x_step,i+=3) 
{
imageData[(x+width*y)*4+3]=255;
imageData[(x+width*y)*4+2]=image[i+0];
imageData[(x+width*y)*4+1]=image[i+1];
imageData[(x+width*y)*4+0]=image[i+2];
}
}
return imageData;
}
static virtual Uint8Array _getImageData32bits(object header, Uint8Array palettes, Uint8Array pixel_data, float y_start, float y_step, float y_end, float x_start, float x_step, float x_end) {
var image = pixel_data;
var width = header.widthheight = header.height;
var i = 0xy;
var imageData = new Uint8Array(width*height*4);
for (y=y_start;y!=y_end;y+=y_step) 
{
for (x=x_start;x!=x_end;x+=x_step,i+=4) 
{
imageData[(x+width*y)*4+2]=image[i+0];
imageData[(x+width*y)*4+1]=image[i+1];
imageData[(x+width*y)*4+0]=image[i+2];
imageData[(x+width*y)*4+3]=image[i+3];
}
}
return imageData;
}
static virtual Uint8Array _getImageDataGrey8bits(object header, Uint8Array palettes, Uint8Array pixel_data, float y_start, float y_step, float y_end, float x_start, float x_step, float x_end) {
var image = pixel_data;
var width = header.widthheight = header.height;
var colori = 0xy;
var imageData = new Uint8Array(width*height*4);
for (y=y_start;y!=y_end;y+=y_step) 
{
for (x=x_start;x!=x_end;x+=x_step,i++) 
{
color=image[i];
imageData[(x+width*y)*4+0]=color;
imageData[(x+width*y)*4+1]=color;
imageData[(x+width*y)*4+2]=color;
imageData[(x+width*y)*4+3]=255;
}
}
return imageData;
}
static virtual Uint8Array _getImageDataGrey16bits(object header, Uint8Array palettes, Uint8Array pixel_data, float y_start, float y_step, float y_end, float x_start, float x_step, float x_end) {
var image = pixel_data;
var width = header.widthheight = header.height;
var i = 0xy;
var imageData = new Uint8Array(width*height*4);
for (y=y_start;y!=y_end;y+=y_step) 
{
for (x=x_start;x!=x_end;x+=x_step,i+=2) 
{
imageData[(x+width*y)*4+0]=image[i+0];
imageData[(x+width*y)*4+1]=image[i+0];
imageData[(x+width*y)*4+2]=image[i+0];
imageData[(x+width*y)*4+3]=image[i+1];
}
}
return imageData;
}
}
}
