#ifndef BABYLON_Sprite_H
#define BABYLON_Sprite_H

#include "decls.h"

#include "iengine.h"
#include "tools_math.h"

using namespace std;

namespace Babylon {

	class SpriteManager;
	typedef shared_ptr_t<SpriteManager> SpriteManagerPtr;

	class Sprite : public IDisposable, public enable_shared_from_this<Sprite> {

	public:

		typedef shared_ptr_t<Sprite> Ptr;
		typedef vector_t<Ptr> Array;

		string name;
		SpriteManagerPtr _manager;
		Vector3::Ptr position;
		Color4::Ptr color;
		float _frameCount;

		float size;
		float angle;
		int cellIndex;
		float invertU;
		float invertV;
		bool disposeWhenFinishedAnimating;

		bool _animationStarted;
		bool _loopAnimation;
		bool _fromIndex;
		bool _toIndex;
		bool _delay;
		int _direction;
		int _time;

	public: 
		Sprite(string name, SpriteManagerPtr manager);

		// Methods
		virtual void playAnimation(int from, int to, bool loop, bool delay);
		virtual void stopAnimation();
		virtual void _animate(int deltaTime);
		virtual void dispose(bool doNotRecurse = false);
	};

};

#endif // BABYLON_Sprite_H