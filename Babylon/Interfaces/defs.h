#ifndef NACL

#include <algorithm>
#include <cmath>
#include <limits>
#include <sstream>
#include <stdexcept>

using namespace std;

#else

#include <boost/range/algorithm/find.hpp>
#include <boost/range/algorithm/for_each.hpp>
#include <boost/range/algorithm/sort.hpp>
#include <boost/units/cmath.hpp>
#include <boost/units/limits.hpp>
#include <sstream>
#include <boost/tr1/tr1/stdexcept>

using namespace boost;
using namespace boost::range::for_each;
using namespace boost::units;
using namespace boost::tr1::tr1;
using namespace std;

#endif