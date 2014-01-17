#ifndef BABYLON_NODE_H
#define BABYLON_NODE_H

#include <memory>
#include <vector>

using namespace std;

namespace Babylon {

	class Node : public enable_shared_from_this<Node> {

		typedef shared_ptr<Node> Ptr;
		typedef vector<Ptr> Array;

	private: 
		Node::Ptr parent;
		bool _childrenFlag;
		bool _isReady;
		bool _isEnabled;

	public: 
		Node();

		Node(Node::Ptr parent);

		virtual bool isSynchronized ();    

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