#ifndef NACL

#include <functional>
#include <set>
#include <string>
#include <map>
#include <memory>
#include <vector>

namespace Babylon {
	#define shared_ptr_t std::shared_ptr
	#define vector_t std::vector
	#define map_t std::map
	#define function_t std::function
}

using namespace std;

#else

#include <functional>
#include <string>
#include <vector>
#include <boost/container/set.hpp>        
#include <boost/container/map.hpp>
#include <boost/container/stable_vector.hpp>
#include <boost/shared_ptr.hpp>
#include <boost/make_shared.hpp>
#include <boost/enable_shared_from_this.hpp>
#include <boost/units/io.hpp>
#include <boost/function.hpp>
#include <boost/function_equal.hpp>

namespace Babylon {
	using boost::shared_ptr;
	using boost::make_shared;
	using boost::enable_shared_from_this;
	using boost::container::map;
	using boost::units::to_string;

	using std::string;
	using std::vector;

	#define shared_ptr_t boost::shared_ptr
	#define vector_t std::vector
	#define map_t boost::container::map
	#define function_t boost::function
}

using namespace std;

#endif
