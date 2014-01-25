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
	${Babylon_SOURCE_DIR}/Babylon/Lights 
	${Babylon_SOURCE_DIR}/Babylon/Materials 
	${Babylon_SOURCE_DIR}/Babylon/Mesh 
	${Babylon_SOURCE_DIR}/Babylon/Particles 
	${Babylon_SOURCE_DIR}/Babylon/PhysicsEngine 
	${Babylon_SOURCE_DIR}/Babylon/PostProcess 
	${Babylon_SOURCE_DIR}/Babylon/Rendering 
	${Babylon_SOURCE_DIR}/Babylon/Textures 
	${Babylon_SOURCE_DIR}/Babylon/Tools)

link_directories (
	${Babylon_BINARY_DIR}/Babylon/Context 
	${Babylon_BINARY_DIR}/Babylon/Tools 
	${Babylon_BINARY_DIR}/Babylon/Culling 
	${Babylon_BINARY_DIR}/Babylon/Textures 
	${Babylon_BINARY_DIR}/Babylon/Materials 
	${Babylon_BINARY_DIR}/Babylon/Animations 
	${Babylon_BINARY_DIR}/Babylon/Bones 
	${Babylon_BINARY_DIR}/Babylon/Mesh 
	${Babylon_BINARY_DIR}/Babylon/Lights 
	${Babylon_BINARY_DIR}/Babylon/Cameras 
	${Babylon_BINARY_DIR}/Babylon/Rendering 
	${Babylon_BINARY_DIR}/Babylon/Collisions 
	${Babylon_BINARY_DIR}/Babylon/PostProcess 
	${Babylon_BINARY_DIR}/Babylon/Layer 
	${Babylon_BINARY_DIR}/Babylon/Particles 
	${Babylon_BINARY_DIR}/Babylon/PhysicsEngine) 

add_library (Engine node.cpp engine.cpp scene.cpp)

target_link_libraries (Engine Context Tools Culling Textures Materials Mesh Lights Cameras Collisions Rendering PostProcess Animations Particles PhysicsEngine)