#ifndef BABYLON_NODE_H
#define BABYLON_NODE_H

#include <memory>
#include <vector>
#include <map>

using namespace std;

namespace Babylon {

	class Node : public enable_shared_from_this<Node> {

	public:

		typedef shared_ptr<Node> Ptr;
		typedef vector<Ptr> Array;

	private: 
		Node::Ptr parent;
		bool _childrenFlag;
		bool _isReady;
		bool _isEnabled;
		map<string, Node::Ptr> _cache;
		Node::Ptr _cache_parent;

	public: 
		Node();

		Node(Node::Ptr parent);

		virtual void _init(Node::Ptr parent);

		virtual void _initCache();

		virtual void updateCache(bool force);

		virtual void _updateCache(bool ignoreParentClass = false);

		virtual bool _isSynchronized ();    

		virtual bool isSynchronized (bool updateCache = false);    

		virtual bool hasNewParent(bool update = false);

		virtual bool _needToSynchonizeChildren ();    

		virtual bool isReady ();

		virtual bool isEnabled ();

		virtual void setEnabled (bool value);

		virtual bool isDescendantOf (Node::Ptr ancestor);

		virtual void _getDescendants(Node::Array list, Node::Array& results);

		virtual Node::Array getDescendants ();
	};

};

#endif // BABYLON_NODE_H