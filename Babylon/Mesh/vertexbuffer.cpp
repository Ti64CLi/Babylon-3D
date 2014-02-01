#include "vertexbuffer.h"
#include "engine.h"
#include "mesh.h"

using namespace Babylon;

Babylon::VertexBuffer::VertexBuffer(Mesh::Ptr mesh, Float32Array data, VertexBufferKind kind, bool updatable) {
	this->_mesh = mesh;
	this->_engine = mesh->getScene()->getEngine();
	this->_updatable = updatable;

	if (updatable) {
		this->_buffer = this->_engine->createDynamicVertexBuffer(data.size() * 4);
		this->_engine->updateDynamicVertexBuffer(this->_buffer, data);
	} else {
		this->_buffer = this->_engine->createVertexBuffer(data);
	}

	this->_data = data;
	this->_kind = kind;

	switch (kind) {
	case VertexBufferKind_PositionKind:
		this->_strideSize = 3;
		this->_mesh->_resetPointsArrayCache();
		break;
	case VertexBufferKind_NormalKind:
		this->_strideSize = 3;
		break;
	case VertexBufferKind_UVKind:
		this->_strideSize = 2;
		break;
	case VertexBufferKind_UV2Kind:
		this->_strideSize = 2;
		break;
	case VertexBufferKind_ColorKind:
		this->_strideSize = 3;
		break;
	case VertexBufferKind_MatricesIndicesKind:
		this->_strideSize = 4;
		break;
	case VertexBufferKind_MatricesWeightsKind:
		this->_strideSize = 4;
		break;
	}

};

bool Babylon::VertexBuffer::isUpdatable() {
	return this->_updatable;
};

Float32Array Babylon::VertexBuffer::getData() {
	return this->_data;
};

size_t Babylon::VertexBuffer::getStrideSize() {
	return this->_strideSize;
};

// Methods
void Babylon::VertexBuffer::update(Float32Array data) {
	this->_engine->updateDynamicVertexBuffer(this->_buffer, data);
	this->_data = data;

	if (this->_kind == VertexBufferKind_PositionKind) {
		this->_mesh->_resetPointsArrayCache();
	}
};

void Babylon::VertexBuffer::dispose(bool doNotRecurse) {
	this->_engine->_releaseBuffer(this->_buffer);
}; 

const char* Babylon::VertexBuffer::toString(VertexBufferKind kind) {
	switch (kind) {
	// TODO: remove gl after testing
	case VertexBufferKind_PositionKind: return "position";
	case VertexBufferKind_NormalKind: return  "normal";
	case VertexBufferKind_UVKind: return "uv";
	case VertexBufferKind_UV2Kind: return "uv2";
	case VertexBufferKind_ColorKind: return "color";
	case VertexBufferKind_MatricesIndicesKind: return "matricesIndices";
	case VertexBufferKind_MatricesWeightsKind: return "matricesWeights";
	case Attribute_Options: return "options";
	case Attribute_CellInfo: return "cellInfo";
	};
};  
