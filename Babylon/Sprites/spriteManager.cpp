#include "spriteManager.h"
#include "engine.h"
#include "tools.h"

using namespace Babylon;

Babylon::SpriteManager::SpriteManager(string name, string imgUrl, size_t capacity, size_t cellSize, ScenePtr scene, float epsilon)
{
	this->_scene = scene;
	this->name = name;
	this->_capacity = capacity;
	this->cellSize = cellSize;
	this->_spriteTexture = make_shared<Texture>(imgUrl, scene, true, false);
	this->_spriteTexture->wrapU = CLAMP_ADDRESSMODE;
	this->_spriteTexture->wrapV = CLAMP_ADDRESSMODE;
	this->_epsilon = epsilon;

	this->_scene = scene;
	this->_scene->spriteManagers.push_back(shared_from_this());

	// VBO
	this->_vertexDeclaration.clear();
	this->_vertexDeclaration.push_back(3); 
	this->_vertexDeclaration.push_back(4); 
	this->_vertexDeclaration.push_back(4);
	this->_vertexDeclaration.push_back(4);
	this->_vertexStrideSize = 15 * 4; // 15 floats per sprite (x, y, z, angle, size, offsetX, offsetY, invertU, invertV, cellIndexX, cellIndexY, color)
	this->_vertexBuffer = scene->getEngine()->createDynamicVertexBuffer(capacity * this->_vertexStrideSize * 4);

	Uint16Array indices;
	auto index = 0;
	for (auto count = 0; count < capacity; count++) {
		indices.push_back(index);
		indices.push_back(index + 1);
		indices.push_back(index + 2);
		indices.push_back(index);
		indices.push_back(index + 2);
		indices.push_back(index + 3);
		index += 4;
	}

	this->_indexBuffer = scene->getEngine()->createIndexBuffer(indices);
	this->_vertices.reserve(capacity * this->_vertexStrideSize);

	// Sprites
	this->sprites.clear();

	vector<string> attributes;
	attributes.push_back("position");
	attributes.push_back("options");
	attributes.push_back("cellInfo");
	attributes.push_back("color");

	vector<string> uniformsNames;
	uniformsNames.push_back("view");
	uniformsNames.push_back("projection");
	uniformsNames.push_back("textureInfos");
	uniformsNames.push_back("alphaTest");

	vector<string> samplers;
	samplers.push_back("diffuseSampler");


	// Effects
	this->_effectBase = this->_scene->getEngine()->createEffect("sprites",
		attributes,
		uniformsNames,
		samplers, "", "");

	uniformsNames.push_back("vFogInfos");	
	uniformsNames.push_back("vFogColor");

	this->_effectFog = this->_scene->getEngine()->createEffect("sprites",
		attributes,
		uniformsNames,
		samplers, "#define FOG", "");

// Members
	renderingGroupId = 0;
	onDispose = nullptr;
};

// Methods
void Babylon::SpriteManager::_appendSpriteVertex(int index, Sprite::Ptr sprite, int offsetX, int offsetY, size_t rowSize) {
	auto arrayOffset = index * 15;

	if (offsetX == 0)
		offsetX = this->_epsilon;
	else if (offsetX == 1)
		offsetX = 1 - this->_epsilon;

	if (offsetY == 0)
		offsetY = this->_epsilon;
	else if (offsetY == 1)
		offsetY = 1 - this->_epsilon;

	this->_vertices[arrayOffset] = sprite->position->x;
	this->_vertices[arrayOffset + 1] = sprite->position->y;
	this->_vertices[arrayOffset + 2] = sprite->position->z;
	this->_vertices[arrayOffset + 3] = sprite->angle;
	this->_vertices[arrayOffset + 4] = sprite->size;
	this->_vertices[arrayOffset + 5] = offsetX;
	this->_vertices[arrayOffset + 6] = offsetY;
	this->_vertices[arrayOffset + 7] = sprite->invertU ? 1 : 0;
	this->_vertices[arrayOffset + 8] = sprite->invertV ? 1 : 0;
	auto offset = (sprite->cellIndex / rowSize) >> 0;
	this->_vertices[arrayOffset + 9] = sprite->cellIndex - offset * rowSize;
	this->_vertices[arrayOffset + 10] = offset;
	// Color
	this->_vertices[arrayOffset + 11] = sprite->color->r;
	this->_vertices[arrayOffset + 12] = sprite->color->g;
	this->_vertices[arrayOffset + 13] = sprite->color->b;
	this->_vertices[arrayOffset + 14] = sprite->color->a;
};

bool Babylon::SpriteManager::render() {
	// Check
	if (!this->_effectBase->isReady() || !this->_effectFog->isReady() || !this->_spriteTexture || !this->_spriteTexture->isReady())
		return false;

	auto engine = this->_scene->getEngine();
	auto baseSize = this->_spriteTexture->getBaseSize();

	// Sprites
	auto deltaTime = Tools::GetDeltaTime();
	auto max = min(this->_capacity, this->sprites.size());
	auto rowSize = baseSize.width / this->cellSize;

	auto offset = 0;
	for (auto index = 0; index < max; index++) {
		auto sprite = this->sprites[index];
		if (!sprite) {
			continue;
		}

		sprite->_animate(deltaTime);

		this->_appendSpriteVertex(offset++, sprite, 0, 0, rowSize);
		this->_appendSpriteVertex(offset++, sprite, 1, 0, rowSize);
		this->_appendSpriteVertex(offset++, sprite, 1, 1, rowSize);
		this->_appendSpriteVertex(offset++, sprite, 0, 1, rowSize);
	}
	engine->updateDynamicVertexBuffer(this->_vertexBuffer, this->_vertices, max * this->_vertexStrideSize);

	// Render
	auto effect = this->_effectBase;

	if (this->_scene->fogMode != FOGMODE_NONE) {
		effect = this->_effectFog;
	}

	engine->enableEffect(effect);

	auto viewMatrix = this->_scene->getViewMatrix();
	effect->setTexture("diffuseSampler", this->_spriteTexture);
	effect->setMatrix("view", viewMatrix);
	effect->setMatrix("projection", this->_scene->getProjectionMatrix());

	effect->setFloat2("textureInfos", this->cellSize / baseSize.width, this->cellSize / baseSize.height);

	// Fog
	if (this->_scene->fogMode !=  FOGMODE_NONE) {
		effect->setFloat4("vFogInfos", this->_scene->fogMode, this->_scene->fogStart, this->_scene->fogEnd, this->_scene->fogDensity);
		effect->setColor3("vFogColor", this->_scene->fogColor);
	}

	// VBOs
	engine->bindBuffers(this->_vertexBuffer, this->_indexBuffer, this->_vertexDeclaration, this->_vertexStrideSize, effect);

	// Draw order
	effect->setBool("alphaTest", true);
	engine->setColorWrite(false);
	engine->draw(true, 0, max * 6);
	engine->setColorWrite(true);
	effect->setBool("alphaTest", false);

	engine->setAlphaMode(ALPHA_COMBINE);
	engine->draw(true, 0, max * 6);
	engine->setAlphaMode(ALPHA_DISABLE);
};

void Babylon::SpriteManager::dispose() {
	if (this->_vertexBuffer) {
		this->_scene->getEngine()->_releaseBuffer(this->_vertexBuffer);
		this->_vertexBuffer = nullptr;
	}

	if (this->_indexBuffer) {
		this->_scene->getEngine()->_releaseBuffer(this->_indexBuffer);
		this->_indexBuffer = nullptr;
	}

	if (this->_spriteTexture) {
		this->_spriteTexture->dispose();
		this->_spriteTexture = nullptr;
	}

	// Remove from scene
	auto it = find( begin(this->_scene->spriteManagers), end(this->_scene->spriteManagers), shared_from_this() );
	if (it != end(this->_scene->spriteManagers))
	{
		this->_scene->spriteManagers.erase(it);
	}

	// Callback
	if (this->onDispose) {
		this->onDispose();
	}
};
