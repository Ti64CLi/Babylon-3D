#include "layer.h"
#include "engine.h"

using namespace Babylon;

Babylon::Layer::Layer(string name, string imgUrl, Scene::Ptr scene, bool isBackground, Color4::Ptr color)
{
	this->_scene = scene;

	this->name = name;
	this->texture = !imgUrl.empty() ? Texture::New(imgUrl, scene, true) : nullptr;
	this->isBackground = isBackground;
	this->color = !color ? make_shared<Color4>(1, 1, 1, 1) : color;

	this->_scene = scene;
	this->_scene->layers.push_back(shared_from_this());

	// VBO
	Float32Array vertices;
	vertices.push_back(1);
	vertices.push_back(1);
	vertices.push_back(-1);
	vertices.push_back(1);
	vertices.push_back(-1);
	vertices.push_back(-1);
	vertices.push_back(1);
	vertices.push_back(-1);

	this->_vertexDeclarations.clear();
	_vertexDeclarations.push_back(VertexBufferKind_NormalKind);

	this->_vertexStrideSize = 2 * 4;
	this->_vertexBuffer = scene->getEngine()->createVertexBuffer(vertices);

	// Indices
	Uint16Array indices;
	indices.push_back(0);
	indices.push_back(1);
	indices.push_back(2);

	indices.push_back(0);
	indices.push_back(2);
	indices.push_back(3);

	this->_indexBuffer = scene->getEngine()->createIndexBuffer(indices);

	vector<VertexBufferKind> attributes;
	attributes.push_back(VertexBufferKind_PositionKind);

	vector<string> uniformsNames;
	uniformsNames.push_back("textureMatrix");
	uniformsNames.push_back("color");

	vector<string> samplers;
	samplers.push_back("textureSampler");

	vector<string> optionalDefines;

	// Effects
	this->_effect = this->_scene->getEngine()->createEffect("layer",
		attributes,
		uniformsNames,
		samplers, 
		"", 
		optionalDefines);

}

// Methods
void Babylon::Layer::render() {
	// Check
	if (!this->_effect->isReady() || !this->texture || !this->texture->isReady())
		return;

	auto engine = this->_scene->getEngine();

	// Render
	engine->enableEffect(this->_effect);
	engine->setState(false);

	// Texture
	this->_effect->setTexture("textureSampler", this->texture);
	this->_effect->setMatrix("textureMatrix", this->texture->_computeTextureMatrix());

	// Color
	this->_effect->setFloat4("color", this->color->r, this->color->g, this->color->b, this->color->a);

	// VBOs
	engine->bindBuffers(this->_vertexBuffer, this->_indexBuffer, this->_vertexDeclarations, this->_vertexStrideSize, this->_effect);

	// Draw order
	engine->setAlphaMode(ALPHA_COMBINE);
	engine->draw(true, 0, 6);
	engine->setAlphaMode(ALPHA_DISABLE);
};

void Babylon::Layer::dispose(bool doNotRecurse) {
	if (this->_vertexBuffer) {
		this->_scene->getEngine()->_releaseBuffer(this->_vertexBuffer);
		this->_vertexBuffer = nullptr;
	}

	if (this->_indexBuffer) {
		this->_scene->getEngine()->_releaseBuffer(this->_indexBuffer);
		this->_indexBuffer = nullptr;
	}

	if (this->texture) {
		this->texture->dispose();
		this->texture = nullptr;
	}

	// Remove from scene
	auto it = find (begin(this->_scene->layers), end(this->_scene->layers), shared_from_this());
	if (it != end(this->_scene->layers))
	{
		this->_scene->layers.erase(it);
	}

	// Callback
	if (this->onDispose) {
		this->onDispose();
	}
};
