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

link_directories(
	${Babylon_BINARY_DIR}/Babylon/Animations 
	${Babylon_BINARY_DIR}/Babylon/Bones 
	${Babylon_BINARY_DIR}/Babylon/Cameras 
	${Babylon_BINARY_DIR}/Babylon/Collisions 
	${Babylon_BINARY_DIR}/Babylon/Context 
	${Babylon_BINARY_DIR}/Babylon/Culling 
	${Babylon_BINARY_DIR}/Babylon/Engine 
	${Babylon_BINARY_DIR}/Babylon/Interfaces 
	${Babylon_BINARY_DIR}/Babylon/Layer
	${Babylon_BINARY_DIR}/Babylon/LensFlare
	${Babylon_BINARY_DIR}/Babylon/Lights 
	${Babylon_BINARY_DIR}/Babylon/Materials 
	${Babylon_BINARY_DIR}/Babylon/Mesh 
	${Babylon_BINARY_DIR}/Babylon/Particles 
	${Babylon_BINARY_DIR}/Babylon/PhysicsEngine 
	${Babylon_BINARY_DIR}/Babylon/PostProcess 
	${Babylon_BINARY_DIR}/Babylon/Rendering 
	${Babylon_BINARY_DIR}/Babylon/Sprites
	${Babylon_BINARY_DIR}/Babylon/Textures 
	${Babylon_BINARY_DIR}/Babylon/Tools)

add_executable (NativeClient main.cc canvas.cc gl.cc)

add_dependencies (NativeClient Engine)

target_link_libraries (NativeClient ppapi_gles2 ppapi_cpp ppapi pthread Cameras Engine Animations Bones Collisions Context Layer LensFlare Mesh Materials Lights Culling Particles PhysicsEngine PostProcess Rendering Sprites Textures Tools)

add_custom_command(TARGET NativeClient POST_BUILD COMMAND ${NACL_TOOLCHAIN_ROOT}/bin/${NACL_TOOLCHAIN_MACHINE_NAME}-finalize${TOOL_OS_SUFFIX} -o ${Babylon_SOURCE_DIR}/Playground/NativeClient/NativeClient.pexe ${Babylon_BINARY_DIR}/Playground/NativeClient/NativeClient)