# The name of our project is "Babylon". CMakeLists files in this project can 
# refer to the root source directory of the project as ${Babylon_SOURCE_DIR} and 
# to the root binary directory of the project as ${Babylon_BINARY_DIR}. 

if(${CMAKE_SOURCE_DIR} STREQUAL ${CMAKE_BINARY_DIR})
	if(NOT DEFINED WITH_IN_SOURCE_BUILD)
		message(FATAL_ERROR
			"CMake generation for Babylon Native is not allowed within the source directory!"
			"\n Remove the CMakeCache.txt file and try again from another folder, e.g.:"
			"\n "
			"\n rm CMakeCache.txt"
			"\n cd .."
			"\n mkdir cmake-make"
			"\n cd cmake-make"
			"\n cmake ../babylonNative"
			"\n "
		)
	endif()
endif()

cmake_minimum_required (VERSION 2.8.10 FATAL_ERROR) 

if(NOT EXECUTABLE_OUTPUT_PATH)
	set(FIRST_RUN "TRUE")
endif()

#-----------------------------------------------------------------------------
# Initialize project.

project (Babylon) 

#-----------------------------------------------------------------------------
# Set default config options
option(WITH_NATIVE_CLIENT "Compile Native Client" ON)

if(UNIX AND NOT APPLE)
	option(WITH_SYSTEM_GLEW "Use GLEW OpenGL wrapper library provided by the operating system" ON)
else()
	# not an option for other OS's
	set(WITH_SYSTEM_GLEW OFF)
endif()

if(UNIX AND NOT APPLE)
	option(WITH_SYSTEM_GLUT "Use GLUT The OpenGL Utility Toolkit library provided by the operating system" ON)
else()
	# not an option for other OS's
	set(WITH_SYSTEM_GLUT OFF)
endif()

#-----------------------------------------------------------------------------
# Configure C++0x

if(NOT MSVC)
    SET(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -Wall -std=c++0x")
    if(${CMAKE_BUILD_TYPE} STREQUAL Debug)
        SET(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -g2 -gdwarf-2")
    endif()
endif()

#-----------------------------------------------------------------------------
# Configure Boost

find_package(Boost 1.55)
if(Boost_FOUND)
   include_directories(${Boost_INCLUDE_DIRS})
endif()

#-----------------------------------------------------------------------------
# add sub directories

add_subdirectory (Babylon)
add_subdirectory (Playground)