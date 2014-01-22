#ifndef BABYLON_NODE_H
#define BABYLON_NODE_H

#include <memory>
#include <vector>
#include <map>

#include "iscene.h"
#include "matrix.h"

using namespace std;

namespace Babylon {

	struct _Cache {
	public:
		// Camera Cache
		float orthoLeft;
		float orthoRight;
		float orthoBottom;
		float orthoTop;
		float fov;
		float aspectRatio;
		float minZ;
		float maxZ;
		CAMERAS mode;
		int renderWidth;
		int renderHeight;
		Vector3::Ptr position;
		Vector3::Ptr upVector;
	};

	class Node : public enable_shared_from_this<Node> {

	public:

		typedef shared_ptr<Node> Ptr;
		typedef vector<Ptr> Array;

	private: 
		int _childrenFlag;
		bool _isReady;
		bool _isEnabled;
		Node::Ptr _cache_parent;

	protected:
		_Cache _cache;
		IScene::Ptr _scene;
		Node::Ptr parent;

	public: 
		Node(IScene::Ptr scene);

		virtual void _initCache();
		virtual void updateCache(bool force = false);
		virtual void _updateCache(bool ignoreParentClass = false);
		virtual void _syncChildFlag();
		virtual bool isSynchronizedWithParent();
		virtual bool _isSynchronized ();    
		virtual bool isSynchronized (bool updateCache = false);    
		virtual bool hasNewParent(bool update = false);
		virtual bool _needToSynchonizeChildren (bool childFlag);    
		virtual bool isReady ();
		virtual bool isEnabled ();
		virtual void setEnabled (bool value);
		virtual bool isDescendantOf (Node::Ptr ancestor);
		virtual void _getDescendants(Node::Array list, Node::Array& results);
		virtual Node::Array getDescendants ();

		// my fix for using WorldMatrix for some nodes
		virtual bool hasWorldMatrix() = 0;
		virtual Matrix::Ptr getWorldMatrix();
	};

};

#endif // BABYLON_NODE_H