include_directories(. ${Babylon_SOURCE_DIR}/Babylon/Interfaces ${Babylon_SOURCE_DIR}/Babylon/Tools)

add_library (Culling boundingBox.cpp boundingSphere.cpp)