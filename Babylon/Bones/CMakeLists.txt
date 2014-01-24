include_directories(
	. 
	${Babylon_SOURCE_DIR}/Babylon/Interfaces 
	${Babylon_SOURCE_DIR}/Babylon/Tools
	${Babylon_SOURCE_DIR}/Babylon/Animations)

add_library (Bones bone.cpp skeleton.cpp)
