#ifndef BABYLON_EFFECT_H
#define BABYLON_EFFECT_H

#include <memory>
#include <vector>

#include "iengine.h"
#include "iscene.h"

using namespace std;

namespace Babylon {

	// TODO: finish it
	class Effect: public enable_shared_from_this<Effect> {

	public:
		typedef shared_ptr<Effect> Ptr;
		typedef vector<Ptr> Array;

	public:
		virtual int getAttribute(int index);
		virtual vector<string>& getAttributesNames();

	public: 
		Effect();		
	};

};

#endif // BABYLON_EFFECT_H