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
		set(GLEW_INCLUDE_PATH "${CMAKE_SOURCE_DIR}/Playground/Deps/GLEW/include")
		set(GLEW_LIBRARY "${CMAKE_SOURCE_DIR}/Playground/Deps/GLEW/lib/Win/x86/glew32.lib")
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
		set(GLUT_INCLUDE_PATH "${CMAKE_SOURCE_DIR}/Playground/Deps/GLUT/include")
		set(GLUT_LIBRARY "${CMAKE_SOURCE_DIR}/Playground/Deps/GLUT/lib/Win/x86/glut32.lib")
	endif()
endif()

#-----------------------------------------------------------------------------
# Configure FreeImage

if(WIN32)
	set(FREEIMAGE_INCLUDE_PATH "${CMAKE_SOURCE_DIR}/Playground/Deps/FreeImage/include")
	set(FREEIMAGE_LIBRARY "${CMAKE_SOURCE_DIR}/Playground/Deps/FreeImage/lib/Win/x86/FreeImage.lib")
else()
    FIND_PATH( FREEIMAGE_INCLUDE_PATH FreeImage.h
        /usr/include
        /usr/local/include
        /sw/include
        /opt/local/include
        DOC "The directory where FreeImage.h resides")
    FIND_LIBRARY( FREEIMAGE_LIBRARY
        NAMES FreeImage freeimage libfreeimage libfreeimage-3.15.2
        PATHS
        /usr/lib64
        /usr/lib
        /usr/local/lib64
        /usr/local/lib
        /sw/lib
        /opt/local/lib
        DOC "The FreeImage library")
endif()

#-----------------------------------------------------------------------------
# Configure Build

if(MSVC)
    SET(CMAKE_EXE_LINKER_FLAGS "${CMAKE_EXE_LINKER_FLAGS} /SAFESEH:NO")
endif()

include_directories(SYSTEM 
	${GLEW_INCLUDE_PATH}
	${GLUT_INCLUDE_PATH}
	${FREEIMAGE_INCLUDE_PATH})

include_directories(
	. 
	${Babylon_SOURCE_DIR}/Babylon/Animations 
	${Babylon_SOURCE_DIR}/Babylon/Bones 
	${Babylon_SOURCE_DIR}/Babylon/Cameras 
	${Babylon_SOURCE_DIR}/Babylon/Collisions 
	${Babylon_SOURCE_DIR}/Babylon/Context 
	${Babylon_SOURCE_DIR}/Babylon/Culling 
	${Babylon_SOURCE_DIR}/Babylon/Engine 
	${Babylon_SOURCE_DIR}/Babylon/Interfaces 
	${Babylon_SOURCE_DIR}/Babylon/Layer
	${Babylon_SOURCE_DIR}/Babylon/LensFlare
	${Babylon_SOURCE_DIR}/Babylon/Lights 
	${Babylon_SOURCE_DIR}/Babylon/Materials 
	${Babylon_SOURCE_DIR}/Babylon/Mesh 
	${Babylon_SOURCE_DIR}/Babylon/Particles 
	${Babylon_SOURCE_DIR}/Babylon/PhysicsEngine 
	${Babylon_SOURCE_DIR}/Babylon/PostProcess 
	${Babylon_SOURCE_DIR}/Babylon/Rendering 
	${Babylon_SOURCE_DIR}/Babylon/Sprites
	${Babylon_SOURCE_DIR}/Babylon/Textures 
	${Babylon_SOURCE_DIR}/Babylon/Tools)

link_directories(
	${Babylon_BINARY_DIR}/Babylon/Animations 
	${Babylon_BINARY_DIR}/Babylon/Bones 
	${Babylon_BINARY_DIR}/Babylon/Cameras 
	${Babylon_BINARY_DIR}/Babylon/Collisions 
	${Babylon_BINARY_DIR}/Babylon/Context 
	${Babylon_BINARY_DIR}/Babylon/Culling 
	${Babylon_BINARY_DIR}/Babylon/Engine 
	${Babylon_BINARY_DIR}/Babylon/Interfaces 
	${Babylon_BINARY_DIR}/Babylon/Layer
	${Babylon_BINARY_DIR}/Babylon/LensFlare
	${Babylon_BINARY_DIR}/Babylon/Lights 
	${Babylon_BINARY_DIR}/Babylon/Materials 
	${Babylon_BINARY_DIR}/Babylon/Mesh 
	${Babylon_BINARY_DIR}/Babylon/Particles 
	${Babylon_BINARY_DIR}/Babylon/PhysicsEngine 
	${Babylon_BINARY_DIR}/Babylon/PostProcess 
	${Babylon_BINARY_DIR}/Babylon/Rendering 
	${Babylon_BINARY_DIR}/Babylon/Sprites
	${Babylon_BINARY_DIR}/Babylon/Textures 
	${Babylon_BINARY_DIR}/Babylon/Tools)

add_executable (NativeWindow main.cpp canvas.cpp gl.cpp)

add_dependencies (NativeWindow Engine)

target_link_libraries (NativeWindow Cameras Engine Animations Bones Collisions Context Layer LensFlare Mesh Materials Lights Culling Particles PhysicsEngine PostProcess Rendering Sprites Textures Tools ${OPENGL_gl_LIBRARY} ${OPENGL_glu_LIBRARY} ${GLEW_LIBRARY} ${GLUT_LIBRARY} ${FREEIMAGE_LIBRARY})

if(WIN32)
add_custom_command(TARGET NativeWindow POST_BUILD COMMAND ${CMAKE_COMMAND} -E copy_if_different "${Babylon_SOURCE_DIR}/Playground/Deps/GLUT/lib/Win/x86/glut32.dll" $<TARGET_FILE_DIR:NativeWindow>/glut32.dll)  
add_custom_command(TARGET NativeWindow POST_BUILD COMMAND ${CMAKE_COMMAND} -E copy_if_different "${Babylon_SOURCE_DIR}/Playground/Deps/GLEW/lib/Win/x86/glew32.dll" $<TARGET_FILE_DIR:NativeWindow>/glew32.dll)  
add_custom_command(TARGET NativeWindow POST_BUILD COMMAND ${CMAKE_COMMAND} -E copy_if_different "${Babylon_SOURCE_DIR}/Playground/Deps/FreeImage/lib/Win/x86/FreeImage.dll" $<TARGET_FILE_DIR:NativeWindow>/FreeImage.dll)  
endif()

#-----------------------------------------------------------------------------
# Copy asset

add_custom_command(TARGET NativeWindow POST_BUILD COMMAND ${CMAKE_COMMAND} -E copy_if_different "${Babylon_SOURCE_DIR}/Playground/NativeWindow/assets/text.jpg" $<TARGET_FILE_DIR:NativeWindow>/text.jpg)  
add_custom_command(TARGET NativeWindow POST_BUILD COMMAND ${CMAKE_COMMAND} -E copy_if_different "${Babylon_SOURCE_DIR}/Playground/NativeWindow/assets/grass_texture.jpg" $<TARGET_FILE_DIR:NativeWindow>/grass_texture.jpg)  
add_custom_command(TARGET NativeWindow POST_BUILD COMMAND ${CMAKE_COMMAND} -E copy_if_different "${Babylon_SOURCE_DIR}/Playground/NativeWindow/assets/Planet.png" $<TARGET_FILE_DIR:NativeWindow>/Planet.png)  