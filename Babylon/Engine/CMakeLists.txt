include_directories(. ${Babylon_SOURCE_DIR}/Babylon/Context ${Babylon_SOURCE_DIR}/Babylon/Tools)

link_directories (${Babylon_BINARY_DIR}/Babylon/Context ${Babylon_BINARY_DIR}/Babylon/Tools) 

add_library (Engine engine.cpp node.cpp)

target_link_libraries (Engine Context Tools)