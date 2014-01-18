include_directories(. ${Babylon_SOURCE_DIR}/Babylon/Interfaces ${Babylon_SOURCE_DIR}/Babylon/Engine)

add_library (Tools tools.cpp color3.cpp color4.cpp viewport.cpp vector3.cpp matrix.cpp plane.cpp)