using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
public interface Window
{
    object mozIndexedDB(object func);
    object webkitIndexedDB(object func);
    object IDBTransaction(object func);
    object webkitIDBTransaction(object func);
    object msIDBTransaction(object func);
    object IDBKeyRange(object func);
    object webkitIDBKeyRange(object func);
    object msIDBKeyRange(object func);
    HTMLURL URL;
    HTMLURL webkitURL;
    object webkitRequestAnimationFrame(object func);
    object mozRequestAnimationFrame(object func);
    object oRequestAnimationFrame(object func);
    WebGLRenderingContext WebGLRenderingContext;
    MSGesture MSGesture;
}
public interface HTMLURL
{
    void createObjectURL(object param1, object param2);
}
public interface Document
{
    void exitFullscreen();
    void webkitCancelFullScreen();
    void mozCancelFullScreen();
    void msCancelFullScreen();
    bool webkitIsFullScreen;
    bool mozFullScreen;
    bool msIsFullScreen;
    bool fullscreen;
    HTMLElement mozPointerLockElement;
    HTMLElement msPointerLockElement;
    HTMLElement webkitPointerLockElement;
    HTMLElement pointerLockElement;
}
public interface HTMLCanvasElement
{
    void requestPointerLock();
    void msRequestPointerLock();
    void mozRequestPointerLock();
    void webkitRequestPointerLock();
}
public interface WebGLTexture
{
    bool isReady;
    bool isCube;
    string url;
    bool noMipmap;
    float references;
    bool generateMipMaps;
    float _size;
    float _baseWidth;
    float _baseHeight;
    float _width;
    float _height;
    HTMLCanvasElement _workingCanvas;
    CanvasRenderingContext2D _workingContext;
    WebGLFramebuffer _framebuffer;
    WebGLRenderbuffer _depthBuffer;
    float _cachedCoordinatesMode;
    float _cachedWrapU;
    float _cachedWrapV;
}
public interface WebGLBuffer
{
    float references;
    float capacity;
}
public interface MouseEvent
{
    float movementX;
    float movementY;
    float mozMovementX;
    float mozMovementY;
    float webkitMovementX;
    float webkitMovementY;
    float msMovementX;
    float msMovementY;
}
