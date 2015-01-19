#ifndef BABYLON_FreeCamera_H
#define BABYLON_FreeCamera_H

#include "decls.h"

#include "icanvas.h"
#include "iengine.h"

#include "camera.h"
#include "matrix.h"
#include "vector2.h"

namespace Babylon {

	class FreeCamera : public Camera {

	public:

		typedef shared_ptr_t<FreeCamera> Ptr;
		typedef vector_t<Ptr> Array;

	private:
		ICanvas::Ptr _attachedCanvas;
		ICanvas::MoveFunc _onMove;
		ICanvas::MoveFunc _onMouseDown;
		ICanvas::MoveFunc _onMouseUp;
		ICanvas::MoveFunc _onMouseOut;
		ICanvas::KeyFunc _onKeyDown;
		ICanvas::KeyFunc _onKeyUp;
		ICanvas::EventFunc _onLostFocus;
		ICanvas::EventFunc _reset;
		
		int previousPosition_X;
		int previousPosition_Y;

	public:
		Vector3::Ptr target;
		//Collider::Ptr _collider;
		Matrix::Ptr _viewMatrix;

		Vector3::Ptr cameraDirection;
		Vector2::Ptr cameraRotation;
		Vector3::Ptr rotation;
		Vector3::Ptr ellipsoid;

		bool _needMoveForGravity;
		Vector3::Ptr _currentTarget;
		Matrix::Ptr _camMatrix;
		Matrix::Ptr _cameraTransformMatrix;
		Matrix::Ptr _cameraRotationMatrix;
		Vector3::Ptr _referencePoint;
		Vector3::Ptr _transformedReferencePoint;
		Vector3::Ptr _oldPosition;
		Vector3::Ptr _diffPosition;
		Vector3::Ptr _newPosition;
		Matrix::Ptr _lookAtTemp;
		Matrix::Ptr _tempMatrix;

		float speed;
		bool checkCollisions;
		bool applyGravity;
		bool noRotationConstraint;
		float angularSensibility;
		Node::Ptr lockedTarget;
		// TODO: finish it
		void* onCollide;

		Vector3::Ptr _localDirection;
		Vector3::Ptr _transformedDirection;

	protected: 
		FreeCamera(string name, Vector3::Ptr position, ScenePtr scene);
	public: 
		static FreeCamera::Ptr New(string name, Vector3::Ptr position, ScenePtr scene);

		virtual Vector3::Ptr _getTargetPosition ();
		// Cache
		virtual void _initCache ();
		virtual void _updateCache (bool ignoreParentClass);
		// Synchronized
		virtual bool _isSynchronizedViewMatrix ();
		// Methods
		virtual float _computeLocalCameraSpeed();
		virtual void setTarget(Vector3::Ptr target);
		virtual void attachControl (ICanvas::Ptr canvas, bool noPreventDefault = false);
		virtual void detachControl (ICanvas::Ptr canvas);
		virtual void _collideWithWorld(Vector3::Ptr velocity);
		virtual void _checkInputs();
		virtual void _update ();
		virtual Matrix::Ptr _getViewMatrix ();
	};

};

#endif // BABYLON_FreeCamera_H