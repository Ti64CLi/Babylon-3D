# The name of our project is "Babylon". CMakeLists files in this project can 
# refer to the root source directory of the project as ${Babylon_SOURCE_DIR} and 
# to the root binary directory of the project as ${Babylon_BINARY_DIR}. 

cmake_minimum_required (VERSION 2.8.11 FATAL_ERROR) 

project (Babylon) 

if(UNIX)
    SET(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -Wall -std=gnu++0x")
endif()

add_subdirectory (Babylon) 
add_subdirectory (PlayGround) 
