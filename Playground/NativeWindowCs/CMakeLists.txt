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

#-----------------------------------------------------------------------------
# Configure GLEW

if(WITH_SYSTEM_GLEW)
	find_package(GLEW)

	mark_as_advanced(
		GLEW_LIBRARY
		GLEW_INCLUDE_PATH
	)
else()
	if(WIN32)
		set(GLEW_INCLUDE_PATH "${CMAKE_SOURCE_DIR}/../Deps/GLEW/include")
		set(GLEW_LIBRARY "${CMAKE_SOURCE_DIR}/../Deps/GLEW/lib/Win/x86/glew32s.lib")
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
	if(WIN32)		
		set(GLUT_INCLUDE_PATH "${CMAKE_SOURCE_DIR}/../Deps/freeglut/include")
		if (MSVC)
			set(GLUT_LIBRARY "${CMAKE_SOURCE_DIR}/../Deps/freeglut/lib/freeglut.lib")
		else()
			set(GLUT_LIBRARY "${CMAKE_SOURCE_DIR}/../Deps/freeglut/lib/libfreeglut.a")
		endif()
	endif()
endif()

#-----------------------------------------------------------------------------
# Configure Build

include_directories(SYSTEM 
	${GLEW_INCLUDE_PATH}
	${GLUT_INCLUDE_PATH})

link_directories(.)

#SET(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -march=i686 -std=c++11 -Wall -Wl,--subsystem,windows")
SET(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -march=i686 -std=c++11 -Wall")

add_custom_command( OUTPUT CoreLib.obj
               COMMAND llc -mtriple i686-pc-mingw32 -filetype=obj ${NativeWindowCs_SOURCE_DIR}/CoreLib.ll -o=${CMAKE_BINARY_DIR}/CoreLib.obj
)

add_custom_command( OUTPUT BabylonGlut.obj
               COMMAND llc -mtriple i686-pc-mingw32 -filetype=obj ${NativeWindowCs_SOURCE_DIR}/BabylonGlut.ll -o=${CMAKE_BINARY_DIR}/BabylonGlut.obj
)

add_custom_command( OUTPUT BabylonNativeCsLibraryForIl.obj
               COMMAND llc -mtriple i686-pc-mingw32 -filetype=obj ${NativeWindowCs_SOURCE_DIR}/BabylonNativeCsLibraryForIl.ll -o=${CMAKE_BINARY_DIR}/BabylonNativeCsLibraryForIl.obj
)

add_executable (NativeWindowCs main.cpp ${CMAKE_BINARY_DIR}/BabylonGlut.obj ${CMAKE_BINARY_DIR}/BabylonNativeCsLibraryForIl.obj ${CMAKE_BINARY_DIR}/CoreLib.obj)

target_link_libraries (NativeWindowCs ${OPENGL_gl_LIBRARY} ${OPENGL_glu_LIBRARY} ${GLEW_LIBRARY} ${GLUT_LIBRARY} "stdc++")

if(WIN32)
add_custom_command(TARGET NativeWindowCs POST_BUILD COMMAND ${CMAKE_COMMAND} -E copy_if_different "${NativeWindowCs_SOURCE_DIR}/../Deps/freeglut/dll/freeglut.dll" $<TARGET_FILE_DIR:NativeWindowCs>/freeglut.dll)  
endif()
