#ifndef NACL

#include <algorithm>
#include <cmath>
#include <limits>
#include <sstream>
#include <stdexcept>

namespace Babylon {
}

#else

#include <boost/range/algorithm/find.hpp>
#include <boost/range/algorithm/for_each.hpp>
#include <boost/range/algorithm/sort.hpp>
#include <boost/units/cmath.hpp>
#include <boost/units/limits.hpp>
#include <boost/units/io.hpp>
#include <sstream>
#include <boost/tr1/tr1/stdexcept>

namespace Babylon {
	using boost::shared_ptr;
	using boost::make_shared;
	using boost::enable_shared_from_this;
	using boost::container::map;
	using boost::units::to_string;

	using std::function;
	using std::string;
	using std::vector;
}

#endif

#ifdef _MSC_VER
#define isnan _isnan
#endif

#ifdef ANDROID

// TODO: hack for Android
template < typename T > std::string to_string( const T& n )
{
	char buff [128]; 
	int ret = snprintf(buff, sizeof(buff), "%d", n); 
	return string (buff, ret);
}

#endif

#ifdef NACL
	#define nullptr 0
#endif
