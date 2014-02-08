#ifndef BABYLON_CAMERA_H
#define BABYLON_CAMERA_H

#include "decls.h"

#include "iengine.h"
#include "node.h"
#include "postProcess.h"

namespace Babylon {

	class Camera : public Node, public IDisposable {

	public:

		typedef shared_ptr<Camera> Ptr;
		typedef vector<Ptr> Array;

	public:
		ScenePtr _scene;
		string name;
		string id;
		Vector3::Ptr position;
		Vector3::Ptr upVector;
		bool _childrenFlag;
		Matrix::Ptr _computedViewMatrix;
		Matrix::Ptr _projectionMatrix;

		// Animations
		vector<shared_ptr<void>> animations;
		// Postprocesses
		PostProcess::Array postProcesses;

		// Viewport
		Viewport::Ptr viewport;

		Matrix::Ptr _worldMatrix;

		float orthoLeft;
		float orthoRight;
		float orthoBottom;
		float orthoTop;
		float fov;
		float minZ;
		float maxZ;
		float inertia;
		CAMERAS mode;

	protected: 
		Camera(string name, Vector3::Ptr position, ScenePtr scene);
	public: 
		static Camera::Ptr New(string name, Vector3::Ptr position, ScenePtr scene);

		virtual ScenePtr getScene();
		virtual void _initCache();
		virtual void _updateCache(bool ignoreParentClass);
		virtual bool _isSynchronized();
		virtual bool _isSynchronizedViewMatrix();
		virtual bool _isSynchronizedProjectionMatrix();
		virtual void attachControl(ICanvas::Ptr canvas, bool noPreventDefault = false);
		virtual void detachControl(ICanvas::Ptr canvas);
		virtual void _update();
		virtual void _updateFromScene();
		virtual Matrix::Ptr getWorldMatrix();
		virtual Matrix::Ptr _getViewMatrix();
		virtual Matrix::Ptr getViewMatrix();
		virtual Matrix::Ptr _computeViewMatrix(bool force = false);
		virtual Matrix::Ptr getProjectionMatrix(bool force = false);
		virtual void dispose(bool doNotRecurse = false);

		virtual bool hasWorldMatrix();
	};

};

#endif // BABYLON_CAMERA_H