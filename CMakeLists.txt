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

cmake_minimum_required (VERSION 2.8.11 FATAL_ERROR) 

if(NOT EXECUTABLE_OUTPUT_PATH)
	set(FIRST_RUN "TRUE")
endif()

#-----------------------------------------------------------------------------
# Initialize project.

project (Babylon) 

#-----------------------------------------------------------------------------
# Set default config options
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
    SET(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -Wall -std=gnu++0x")
endif()

#-----------------------------------------------------------------------------
# Configure OpenGL

find_package(OpenGL)

#-----------------------------------------------------------------------------
# Configure GLEW

if(WITH_SYSTEM_GLEW)
	find_package(GLEW)

	mark_as_advanced(
		GLEW_LIBRARY
		GLEW_INCLUDE_PATH
	)
else()
	if(WIN32 AND NOT MINGW)
		set(GLEW_INCLUDE_PATH "${CMAKE_SOURCE_DIR}/Playground/Deps/Win32/GLEW/include")
		set(GLEW_LIBRARY "${CMAKE_SOURCE_DIR}/Playground/Deps/Win32/GLEW/lib")
	else()
		set(GLEW_INCLUDE_PATH "${CMAKE_SOURCE_DIR}/Playground/Deps/MinGW/GLEW/include")
		set(GLEW_LIBRARY "${CMAKE_SOURCE_DIR}/Playground/Deps/MinGW/GLEW/lib")
	endif()
endif()
#-----------------------------------------------------------------------------
# Configure GLUT

if(WITH_SYSTEM_GLUT)
	find_package(GLUT)

	mark_as_advanced(
		GLUT_LIBRARY
		GLUT_INCLUDE_PATH
	)
else()
	if(WIN32 AND NOT MINGW)
		set(GLUT_INCLUDE_PATH "${CMAKE_SOURCE_DIR}/Playground/Deps/Win32/GLUT/include")
		set(GLUT_LIBRARY "${CMAKE_SOURCE_DIR}/Playground/Deps/Win32/GLUT/lib")
	else()
		set(GLUT_INCLUDE_PATH "${CMAKE_SOURCE_DIR}/Playground/Deps/MinGW/GLUT/include")
		set(GLUT_LIBRARY "${CMAKE_SOURCE_DIR}/Playground/Deps/MinGW/GLUT/lib")
	endif()
endif()

add_subdirectory (Babylon) 
add_subdirectory (PlayGround) 
