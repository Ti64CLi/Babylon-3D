#ifndef BABYLON_ANIMATABLE_H
#define BABYLON_ANIMATABLE_H

#include <memory>
#include <vector>
#include <map>
#include "animation.h"

using namespace std;

namespace Babylon {

	struct AnimationValue;

	class _AnimationContainer
	{
	public:

		typedef shared_ptr<_AnimationContainer> Ptr;
		typedef vector<Ptr> Array;

		vector<Animation> animations;

		virtual void markAsDirty(string property) = 0;

		virtual AnimationValue getValue(string key) = 0;

		// TODO: if key has . inside send the value to nested object
		virtual void setValue(string key, AnimationValue value) = 0;
	};

	class _Animatable : public enable_shared_from_this<_Animatable> {

	public:

		typedef shared_ptr<_Animatable> Ptr;
		typedef vector<Ptr> Array;

	private:
		float _localDelayOffset;

	protected:
		_AnimationContainer::Ptr target;

		bool animationStarted;
		ANIMATIONLOOPMODES loopAnimation;
		float fromFrame;
		float toFrame;
		float speedRatio;

	protected:
		virtual void onAnimationEnd();

	public: 
		_Animatable();

		virtual bool _animate(float delay);
	};

};

#endif // BABYLON_ANIMATABLE_H