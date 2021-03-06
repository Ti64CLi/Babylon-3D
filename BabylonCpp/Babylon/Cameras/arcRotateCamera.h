#ifndef BABYLON_ARCROTATECAMERA_H
#define BABYLON_ARCROTATECAMERA_H

#include "decls.h"

#include "icanvas.h"
#include "iengine.h"

#include "camera.h"
#include "matrix.h"

namespace Babylon {

	class ArcRotateCamera : public Camera {

	public:

		typedef shared_ptr_t<ArcRotateCamera> Ptr;
		typedef vector_t<Ptr> Array;

	private:
		ICanvas::Ptr _attachedCanvas;
		ICanvas::MoveFunc _onMove;
		
		float previousPosition_x;
		float previousPosition_y;

	public:
		float alpha; 
		float beta;
		float radius;
		Vector3::Ptr target;

		Matrix::Ptr _viewMatrix;

		float inertialAlphaOffset;
		float inertialBetaOffset;
		float inertialRadiusOffset;
		float lowerAlphaLimit;
		float upperAlphaLimit;
		float lowerBetaLimit;
		float upperBetaLimit;
		float lowerRadiusLimit;
		float upperRadiusLimit;
		float angularSensibility;

		bool hasLowerAlphaLimit;
		bool hasUpperAlphaLimit;
		bool hasLowerBetaLimit;
		bool hasUpperBetaLimit;
		bool hasLowerRadiusLimit;
		bool hasUpperRadiusLimit;

	protected: 
		ArcRotateCamera(string name, float alpha, float beta, float radius, Vector3::Ptr target, ScenePtr scene);
	public: 
		static ArcRotateCamera::Ptr New(string name, float alpha, float beta, float radius, Vector3::Ptr target, ScenePtr scene);

		virtual Vector3::Ptr _getTargetPosition ();
		// Cache
		virtual void _initCache ();
		virtual void _updateCache (bool ignoreParentClass);
		// Synchronized
		virtual bool _isSynchronizedViewMatrix ();
		// Methods
		virtual void attachControl (ICanvas::Ptr canvas, bool noPreventDefault = false);
		virtual void detachControl (ICanvas::Ptr canvas);
		virtual void _update ();
		virtual void setPosition (Vector3::Ptr position);
		virtual Matrix::Ptr _getViewMatrix ();
	};

};

#endif // BABYLON_ARCROTATECAMERA_H