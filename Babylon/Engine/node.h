#ifndef BABYLON_NODE_H
#define BABYLON_NODE_H

#include <memory>
#include <vector>

using namespace std;

namespace Babylon {

	class Node: public enable_shared_from_this<Node> {

		typedef shared_ptr<Node> NodePtr;
		typedef vector<NodePtr> Nodes;

	private: 
		NodePtr parent;
		bool _childrenFlag;
		bool _isReady;
		bool _isEnabled;

	public: 
		Node();

		virtual bool isSynchronized ();    

		virtual bool _needToSynchonizeChildren ();    

		virtual bool isReady ();

		virtual bool isEnabled ();

		virtual void setEnabled (bool value);

		virtual bool isDescendantOf (NodePtr ancestor);

		virtual void _getDescendants(Nodes list, Nodes& results);

		virtual Nodes getDescendants ();
	};

};

#endif // BABYLON_NODE_H