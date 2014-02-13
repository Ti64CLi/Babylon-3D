set( LIBRARY_OUTPUT_PATH ${LIBRARY_OUTPUT_PATH_ROOT} CACHE PATH "Single Directory for all Libraries")

include_directories(
	${CMAKE_CURRENT_SOURCE_DIR} 
	${ANDROID_SYSTEM_INCLUDE_DIRS}
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

link_directories(${ANDROID_SYSTEM_LIB_DIRS})
        
add_library(native-activity SHARED main.cpp android_native_app_glue.c canvas.cpp gl.cpp)

target_link_libraries(native-activity log android EGL GLESv2 Cameras Engine Animations Bones Collisions Context Layer LensFlare Mesh Materials Lights Culling Particles PhysicsEngine PostProcess Rendering Sprites Textures Tools)