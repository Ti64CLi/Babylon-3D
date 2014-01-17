#ifndef BABYLON_VERTEXBUFFER_H
#define BABYLON_VERTEXBUFFER_H

#include <memory>
#include <vector>

using namespace std;

namespace Babylon {

	class VertexBuffer: public enable_shared_from_this<VertexBuffer> {

	public:
		typedef shared_ptr<VertexBuffer> Ptr;
		typedef vector<Ptr> Array;

	public:

	public: 
		VertexBuffer();		
	};

};

#endif // BABYLON_VERTEXBUFFER_H