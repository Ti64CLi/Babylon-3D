#include "color3.h"
#include "defs.h"

using namespace Babylon;

Babylon::Color3::Color3(int initialR, int initialG, int initialB) {
	this->r = initialR;
	this->g = initialG;
	this->b = initialB;
};

// Operators
Color3::Ptr Babylon::Color3::multiply(Color3::Ptr otherColor) {
	return make_shared<Color3>(this->r * otherColor->r, this->g * otherColor->g, this->b * otherColor->b);
};

void Babylon::Color3::multiplyToRef(Color3::Ptr otherColor, Color3::Ptr result) {
	result->r = this->r * otherColor->r;
	result->g = this->g * otherColor->g;
	result->b = this->b * otherColor->b;
};

bool Babylon::Color3::equals(Color3::Ptr otherColor) {
	return this->r == otherColor->r && this->g == otherColor->g && this->b == otherColor->b;
};

Babylon::Color3::Ptr Babylon::Color3::scale(float scale) {
	return make_shared<Color3>(this->r * scale, this->g * scale, this->b * scale);
};

void Babylon::Color3::scaleToRef(float scale, Color3::Ptr result) {
	result->r = this->r * scale;
	result->g = this->g * scale;
	result->b = this->b * scale;
};

Color3::Ptr Babylon::Color3::clone() {
	return make_shared<Color3>(this->r, this->g, this->b);
};

void Babylon::Color3::copyFrom(Color3::Ptr source) {
	this->r = source->r;
	this->g = source->g;
	this->b = source->b;
};

void Babylon::Color3::copyFromFloats(float r, float g, float b) {
	this->r = r;
	this->g = g;
	this->b = b;
};

// Statics
Color3::Ptr Babylon::Color3::FromArray(Float32Array vals) {
	return make_shared<Color3>(vals[0], vals[1], vals[2]);
};
