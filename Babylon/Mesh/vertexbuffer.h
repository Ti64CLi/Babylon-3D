#ifndef BABYLON_VERTEXBUFFER_H
#define BABYLON_VERTEXBUFFER_H

#include <memory>
#include <vector>
#include <map>

#include "iengine.h"

using namespace std;

namespace Babylon {

	class Mesh;
	typedef shared_ptr<Mesh> MeshPtr;

	class VertexBuffer: public IDisposable, public enable_shared_from_this<VertexBuffer> {

	public:
		typedef shared_ptr<VertexBuffer> Ptr;
		typedef vector<Ptr> Array;
		typedef map<VertexBufferKind, Ptr> Map;

	public:
		EnginePtr _engine;
		size_t _strideSize;
		VertexBufferKind _kind;
		Float32Array _data;
		bool _updatable;
		IGLBuffer::Ptr _buffer;
		MeshPtr _mesh;

	public: 
		VertexBuffer(MeshPtr mesh, Float32Array data, VertexBufferKind kind, bool updatable);		

		virtual bool isUpdatable();
		virtual Float32Array getData();
		virtual size_t getStrideSize();
		// Methods
		virtual void update(Float32Array data);
		virtual void dispose(bool doNotRecurse = false);

		// helper
		static const char* toString(VertexBufferKind kind);
	};

};

#endif // BABYLON_VERTEXBUFFER_H