include_directories(
	. 
	${Babylon_SOURCE_DIR}/Babylon/Interfaces 
	${Babylon_SOURCE_DIR}/Babylon/Tools
	${Babylon_SOURCE_DIR}/Babylon/Engine
	${Babylon_SOURCE_DIR}/Babylon/Mesh)

add_library (Collisions pickingInfo.cpp)
