#include "color4.h"
#include "defs.h"

using namespace Babylon;

Babylon::Color4::Color4(float initialR, float initialG, float initialB, float initialA) {
	this->r = initialR;
	this->g = initialG;
	this->b = initialB;
	this->a = initialA;
};

// Operators
void Babylon::Color4::addInPlace(Color4::Ptr right) {
	this->r += right->r;
	this->g += right->g;
	this->b += right->b;
	this->a += right->a;
};

Color4::Ptr Babylon::Color4::add(Color4::Ptr otherColor) {
	return make_shared<Color4>(this->r + otherColor->r, this->g + otherColor->g, this->b + otherColor->b, this->a + otherColor->a);
};

Color4::Ptr Babylon::Color4::subtract(Color4::Ptr otherColor) {
	return make_shared<Color4>(this->r - otherColor->r, this->g - otherColor->g, this->b - otherColor->b, this->a - otherColor->a);
};

void Babylon::Color4::subtractToRef(Color4::Ptr otherColor, Color4::Ptr result) {
	result->r = this->r - otherColor->r;
	result->g = this->g - otherColor->g;
	result->b = this->b - otherColor->b;
	result->a = this->a - otherColor->a;
};

Babylon::Color4::Ptr Babylon::Color4::scale(float scale) {
	return make_shared<Color4>(this->r * scale, this->g * scale, this->b * scale, this->a * scale);
};

void Babylon::Color4::scaleToRef(float scale, Color4::Ptr result) {
	result->r = this->r * scale;
	result->g = this->g * scale;
	result->b = this->b * scale;
	result->a = this->a * scale;
};

Babylon::Color4::Ptr Babylon::Color4::Lerp(Color4::Ptr left, Color4::Ptr right, float amount) {
	auto result = make_shared<Color4>(0, 0, 0, 0);
	Babylon::Color4::LerpToRef(left, right, amount, result);
	return result;
};

void Babylon::Color4::LerpToRef(Color4::Ptr left, Color4::Ptr right, float amount, Color4::Ptr result) {
	result->r = left->r + (right->r - left->r) * amount;
	result->g = left->g + (right->g - left->g) * amount;
	result->b = left->b + (right->b - left->b) * amount;
	result->a = left->a + (right->a - left->a) * amount;
};

Color4::Ptr Babylon::Color4::clone() {
	return make_shared<Color4>(this->r, this->g, this->b, this->a);
};

// Statics
Color4::Ptr Babylon::Color4::FromArray(vector<float> vals) {
	return make_shared<Color4>(vals[0], vals[1], vals[2], vals[3]);
};
