#ifndef BABYLON_MATRIX_H
#define BABYLON_MATRIX_H

#include <memory>
#include <vector>

#include "igl.h"

using namespace std;

namespace Babylon {

	struct Matrix: public enable_shared_from_this<Matrix> {

	public:
		typedef shared_ptr<Matrix> Ptr;

	public:
		Float32Array m;

	public: 
		Matrix();		
	};

};

#endif // BABYLON_MATRIX_H