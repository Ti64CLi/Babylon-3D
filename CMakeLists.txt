# The name of our project is "Babylon". CMakeLists files in this project can 
# refer to the root source directory of the project as ${Babylon_SOURCE_DIR} and 
# to the root binary directory of the project as ${Babylon_BINARY_DIR}. 

cmake_minimum_required (VERSION 2.8.12 FATAL_ERROR) 

project (Babylon) 

##set(CMAKE_MODULE_PATH ${CMAKE_MODULE_PATH} "${CMAKE_SOURCE_DIR}/cmake")
##
##find_package(CXXFeatures)
##
##set(needed_features
## CXXFeatures_auto
## CXXFeatures_class_override_final
## CXXFeatures_constexpr
## CXXFeatures_cstdint_header
## CXXFeatures_decltype
## CXXFeatures_defaulted_functions
## CXXFeatures_delegating_constructors
## CXXFeatures_deleted_functions
## CXXFeatures_func_identifier
## CXXFeatures_initializer_list
## CXXFeatures_lambda
## CXXFeatures_long_long
## CXXFeatures_nullptr
## CXXFeatures_rvalue_references
## CXXFeatures_sizeof_member
## CXXFeatures_static_assert
## CXXFeatures_variadic_templates)
##
##foreach(i ${needed_features})
## if(NOT ${i}_FOUND)
##   message(FATAL_ERROR "CXX feature \"${i}\" is not supported by the compiler")
## endif()
##endforeach()

if(UNIX)
    SET(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -Wall -std=gnu++0x")
endif()


set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} ${CXX11_COMPILER_FLAGS}")

add_subdirectory (Babylon) 
