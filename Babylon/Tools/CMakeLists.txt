include_directories(
	. 
	${Babylon_SOURCE_DIR}/Babylon/Interfaces 
	${Babylon_SOURCE_DIR}/Babylon/Engine 
	${Babylon_SOURCE_DIR}/Babylon/Culling)

add_library (Tools tools.cpp ray.cpp color3.cpp color4.cpp viewport.cpp vector3.cpp quaternion.cpp matrix.cpp plane.cpp frustum.cpp)