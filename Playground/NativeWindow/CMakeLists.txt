if(MSVC)
    SET(CMAKE_EXE_LINKER_FLAGS "${CMAKE_EXE_LINKER_FLAGS} /SAFESEH:NO")
endif()

include_directories(SYSTEM 
	${Babylon_SOURCE_DIR}/PlayGround/Deps/GLUT/include
	${Babylon_SOURCE_DIR}/PlayGround/Deps/GLEW/include
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
	${Babylon_SOURCE_DIR}/PlayGround/Deps/GLUT/lib
	${Babylon_SOURCE_DIR}/PlayGround/Deps/GLEW/lib
	${Babylon_BINARY_DIR}/Babylon/Engine 
	${Babylon_BINARY_DIR}/Babylon/Materials)


add_executable (NativeWindow main.cpp canvas.cpp gl.cpp)

target_link_libraries(NativeWindow glut32.lib glew32.lib Engine.lib Materials.lib)


