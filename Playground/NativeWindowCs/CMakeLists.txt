cmake_minimum_required (VERSION 3.0 FATAL_ERROR) 

project (NativeWindowCs) 

if(${CMAKE_SOURCE_DIR} STREQUAL ${CMAKE_BINARY_DIR})
	if(NOT DEFINED WITH_IN_SOURCE_BUILD)
		message(FATAL_ERROR
			"CMake generation for NativeWindowCs is not allowed within the source directory!"
			"\n Remove the CMakeCache.txt file and try again from another folder, e.g.:"
			"\n "
			"\n rm CMakeCache.txt"
			"\n cd .."
			"\n mkdir cmake-make"
			"\n cd cmake-make"
			"\n cmake -f .."
			"\n "
		)
	endif()
endif()

#-----------------------------------------------------------------------------
# Configure OpenGL

find_package(OpenGL)

if(WITH_SYSTEM_GLUT)
	find_package(GLUT)

	mark_as_advanced(
		GLUT_LIBRARY
		GLUT_INCLUDE_PATH
	)
else()
	if(WIN32)
		set(GLUT_INCLUDE_PATH "${CMAKE_SOURCE_DIR}/../Deps/freeglut/include")
		set(GLUT_LIBRARY "${CMAKE_SOURCE_DIR}/../Deps/freeglut/lib/libfreeglut.a")
	endif()
endif()

#-----------------------------------------------------------------------------
# Configure Build

include_directories(SYSTEM 
	${GLUT_INCLUDE_PATH})

link_directories(.)

add_custom_command( OUTPUT CoreLib.obj
               COMMAND llc -mtriple i686-pc-mingw32 -filetype=obj ${NativeWindowCs_SOURCE_DIR}/CoreLib.ll
)

add_custom_command( OUTPUT BabylonGlut.obj
               COMMAND llc -mtriple i686-pc-mingw32 -filetype=obj ${NativeWindowCs_SOURCE_DIR}/BabylonGlut.ll
)

add_custom_command( OUTPUT BabylonNativeCsLibraryForIl.obj
               COMMAND llc -mtriple i686-pc-mingw32 -filetype=obj ${NativeWindowCs_SOURCE_DIR}/BabylonNativeCsLibraryForIl.ll
)

add_executable (NativeWindowCs main.cpp CoreLib.obj BabylonGlut.obj BabylonNativeCsLibraryForIl.obj)

target_link_libraries (NativeWindowCs ${OPENGL_gl_LIBRARY} ${OPENGL_glu_LIBRARY} ${GLUT_LIBRARY})
