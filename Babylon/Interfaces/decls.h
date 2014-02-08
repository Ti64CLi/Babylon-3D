#ifndef NACL

#include <functional>
#include <set>
#include <string>
#include <map>
#include <memory>
#include <vector>

using namespace std;

#else

#include <boost/functional.hpp>
#include <boost/container/set.hpp>        
#include <boost/container/string.hpp>
#include <boost/container/map.hpp>
#include <boost/shared_ptr.hpp>
#include <boost/container/vector.hpp>

using namespace boost;
using namespace boost::container;

#endif