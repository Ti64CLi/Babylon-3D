include_directories(
	. 
	${Babylon_SOURCE_DIR}/Babylon/Interfaces 
	${Babylon_SOURCE_DIR}/Babylon/Engine 
	${Babylon_SOURCE_DIR}/Babylon/Tools 
	${Babylon_SOURCE_DIR}/Babylon/Textures 
	${Babylon_SOURCE_DIR}/Babylon/Materials
	${Babylon_SOURCE_DIR}/Babylon/Cameras 
	${Babylon_SOURCE_DIR}/Babylon/Animations
	${Babylon_SOURCE_DIR}/Babylon/Bones
	${Babylon_SOURCE_DIR}/Babylon/Culling)

add_library (Mesh mesh.cpp subMesh.cpp vertexbuffer.cpp)