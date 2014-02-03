if(MSVC)
    SET(CMAKE_EXE_LINKER_FLAGS "${CMAKE_EXE_LINKER_FLAGS} /SAFESEH:NO")
endif()

include_directories(SYSTEM 
	${GLEW_INCLUDE_PATH}
	${GLUT_INCLUDE_PATH}
	${Babylon_SOURCE_DIR}/PlayGround/Deps/NV/include)

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
	${GLEW_LIBRARY}
	${GLUT_LIBRARY}
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

target_link_libraries (NativeWindow glut32.lib glew32.lib Engine.lib Animations.lib Bones.lib Cameras.lib Collisions.lib Context.lib Culling.lib Layer.lib LensFlare.lib Lights.lib Materials.lib Mesh.lib Particles.lib PhysicsEngine.lib PostProcess.lib Rendering.lib Sprites.lib Textures.lib Tools.lib)

if(WIN32)
add_custom_command(TARGET NativeWindow POST_BUILD COMMAND ${CMAKE_COMMAND} -E copy_if_different "${GLUT_LIBRARY}/glut32.dll" $<TARGET_FILE_DIR:NativeWindow>/glut32.dll)  
add_custom_command(TARGET NativeWindow POST_BUILD COMMAND ${CMAKE_COMMAND} -E copy_if_different "${GLEW_LIBRARY}/glew32.dll" $<TARGET_FILE_DIR:NativeWindow>/glew32.dll)  
endif()