include_directories(. ${Babylon_SOURCE_DIR}/Babylon/Interfaces ${Babylon_SOURCE_DIR}/Babylon/Tools ${Babylon_SOURCE_DIR}/Babylon/Textures ${Babylon_SOURCE_DIR}/Babylon/Materials ${Babylon_SOURCE_DIR}/Babylon/Mesh)

link_directories (${Babylon_BINARY_DIR}/Babylon/Context ${Babylon_BINARY_DIR}/Babylon/Tools ${Babylon_BINARY_DIR}/Babylon/Textures ${Babylon_BINARY_DIR}/Babylon/Materials ${Babylon_BINARY_DIR}/Babylon/Mesh) 

add_library (Engine node.cpp engine.cpp scene.cpp)

target_link_libraries (Engine Context Tools Textures Materials Mesh)