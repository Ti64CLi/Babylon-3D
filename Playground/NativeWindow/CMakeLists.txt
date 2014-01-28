if(EGL)
include_directories(
	. 
	${Babylon_SOURCE_DIR}/PlayGround/Deps/ATI/gles_sdk/include/EGL
	${Babylon_SOURCE_DIR}/PlayGround/Deps/ATI/gles_sdk/include/GLES2
	${Babylon_SOURCE_DIR}/PlayGround/Deps/ATI/gles_sdk/include/KHR)
end()

if(GLUT)
include_directories(
	. 
	${Babylon_SOURCE_DIR}/PlayGround/Deps/GLEW/include
	${Babylon_SOURCE_DIR}/PlayGround/Deps/GLUT)
end()

if(WIN32)
	add_executable (NativeWindow nativewin_win32.cpp main.cpp)
endif()

if(UNIX)
	add_executable (NativeWindow nativewin_x11.cpp main.cpp)
endif()
