cmake_minimum_required( VERSION 2.8 )

SET(NACL_BUILD_TYPE "${CMAKE_CFG_INTDIR}")
message(STATUS "NACL Build Type ${NACL_BUILD_TYPE}")
# single-config generators use . as a value for CMAKE_CFG_INTDIR
if(NOT NACL_BUILD_TYPE OR NACL_BUILD_TYPE STREQUAL ".")
	message(STATUS "Bad build type")
	if(NOT CMAKE_BUILD_TYPE)
		#no config is defined, assume a default
		set(CMAKE_BUILD_TYPE "Debug")
	endif()
	SET(NACL_BUILD_TYPE "${CMAKE_BUILD_TYPE}")	
endif()

if (NOT DEFINED ENV{NACL_SDK_ROOT})
	message(FATAL_ERROR "Environment variable NACL_SDK_ROOT is not defined. Please use a more specific NACL toolchain file.")
endif()

set(NACL_SDK_ROOT $ENV{NACL_SDK_ROOT})
if (NOT EXISTS "${NACL_SDK_ROOT}")
	message(FATAL_ERROR "Environment variable NACL_SDK_ROOT points to an invalid directory (${NACL_SDK_ROOT}). Please use a more specific NACL toolchain file.")
endif()

STRING(REGEX REPLACE "\\\\" "/" NACL_SDK_ROOT ${NACL_SDK_ROOT})
STRING(REGEX REPLACE "//" "/" NACL_SDK_ROOT ${NACL_SDK_ROOT})

message(STATUS "NACL SDK root set to ${NACL_SDK_ROOT}")

if(NOT NACL_LIB MATCHES "(newlib)|(pnacl)|(glibc)")
	message(FATAL_ERROR "NACL_LIB is either not defined or invalid. Possible values are glibc, newlib or pnacl. Currently set to '${NACL_LIB}'.")
endif()	

if(NOT NACL_LIB STREQUAL "pnacl" AND NOT NACL_ARCH MATCHES "(x86_32)|(x86_64)|(arm)")
	message(FATAL_ERROR "NACL_ARCH is either not defined or invalid. Possible values are x86_32, x86_64 or arm. Currently set to '${NACL_ARCH}'.")
endif()

# figure out what we're running on
if (CMAKE_HOST_APPLE)
	# section not tested
	set(NACL_HOST_SYSTEM_NAME "mac")
	set(NACL_TOOL_SUFFIX "")	
elseif(CMAKE_HOST_WIN32)
	set(NACL_HOST_SYSTEM_NAME "win") 
	if(NACL_LIB STREQUAL "pnacl")
		set(NACL_TOOL_SUFFIX ".bat")	
	else(NACL_LIB STREQUAL "pnacl")
		set(NACL_TOOL_SUFFIX ".exe")	
	endif(NACL_LIB STREQUAL "pnacl")
elseif(CMAKE_HOST_UNIX)
	# section not tested
	set(NACL_HOST_SYSTEM_NAME "linux")
	set(NACL_TOOL_SUFFIX "")	
else()
	message(FATAL_ERROR "Unknown host platform.")
endif()

#libs are next 
if(NACL_LIB STREQUAL "pnacl")
	set(NACL_LIB_PATH "${NACL_SDK_ROOT}/lib/pnacl/${NACL_BUILD_TYPE}")
	set(NACL_PORTS_LIB_PATH "${NACL_SDK_ROOT}/ports/lib/newlib_pnacl/${NACL_BUILD_TYPE}")
else()
	set(NACL_LIB_PATH "${NACL_SDK_ROOT}/lib/${NACL_LIB}_${NACL_ARCH}/${NACL_BUILD_TYPE}")
	set(NACL_PORTS_LIB_PATH "${NACL_SDK_ROOT}/ports/lib/${NACL_LIB}_${NACL_ARCH}/${NACL_BUILD_TYPE}")
endif()
SET(CMAKE_LIBRARY_PATH ${CMAKE_LIBRARY_PATH} "${NACL_LIB_PATH}" "${NACL_PORTS_LIB_PATH}")
message(STATUS "Library paths set to ${CMAKE_LIBRARY_PATH}")
SET(CMAKE_FIND_LIBRARY_PREFIXES "lib")
SET(CMAKE_FIND_LIBRARY_SUFFIXES ".so" ".a")
link_directories( ${CMAKE_LIBRARY_PATH} )

#includes follow
set(NACL_INC_PATH "${NACL_SDK_ROOT}/include")
set(NACL_PORTS_INC_PATH "${NACL_SDK_ROOT}/ports/include")
SET(CMAKE_INCLUDE_PATH ${CMAKE_INCLUDE_PATH} "${NACL_INC_PATH}" "${NACL_PORTS_INC_PATH}")
include_directories(SYSTEM ${CMAKE_INCLUDE_PATH})
message(STATUS "Include paths set to ${CMAKE_INCLUDE_PATH}")

#set some specific architecture & build settings
#https://developers.google.com/native-client/dev/devguide/devcycle/building#compile-flags
if(NACL_LIB STREQUAL "pnacl")
	# section not tested
	SET(NACL_TOOLCHAIN_PATH "${NACL_SDK_ROOT}/toolchain/${NACL_HOST_SYSTEM_NAME}_pnacl")
	#set(NACL_TOOLCHAIN_INC_PATH "${NACL_TOOLCHAIN_PATH}/usr/include")
	
	SET(NACL_TOOL_PREFIX "pnacl")
	SET(NACL_COMPILER_ID "Clang")
	
	# specific compiler settings
	# note: libc++ doesn't yet work with exceptions turned on --pnacl-exceptions=sjlj
	set(CMAKE_CXX_FLAGS            		"-stdlib=libc++  -U__STRICT_ANSI__" CACHE INTERNAL "" FORCE)
	set(CMAKE_CXX_FLAGS_RELEASE    		"-O2 -ffast-math" CACHE INTERNAL "" FORCE)		
	set(CMAKE_CXX_FLAGS_DEBUG    		"-g -O0" CACHE INTERNAL "" FORCE)			
	set(CMAKE_CXX_FLAGS_RELWITHDEBINFO	${CMAKE_CXX_FLAGS_DEBUG} CACHE INTERNAL "" FORCE)

	set(CMAKE_EXECUTABLE_SUFFIX ".pexe")
	#STATIC_LIBRARY_FLAGS,#LINK_FLAGS to be used  with set_target_properties
	
	#CMAKE_EXE_LINKER_FLAGS
	#CMAKE_SHARED_LINKER_FLAGS
	#CMAKE_MODULE_LINKER_FLAGS			
	#set(CMAKE_EXE_LINKER_FLAGS		"--pnacl-exceptions=sjlj" CACHE INTERNAL "" FORCE)
elseif(NACL_ARCH STREQUAL "arm")
	# section not tested
	SET(NACL_TOOLCHAIN_PATH "${NACL_SDK_ROOT}/toolchain/${NACL_HOST_SYSTEM_NAME}_arm_${NACL_LIB}")	
	
	SET(NACL_TOOL_PREFIX "arm-nacl")
	SET(NACL_COMPILER_ID "GNU")
	set(CMAKE_EXECUTABLE_SUFFIX ".nexe")
else()
	SET(NACL_TOOLCHAIN_PATH "${NACL_SDK_ROOT}/toolchain/${NACL_HOST_SYSTEM_NAME}_x86_${NACL_LIB}")	
	
	if(NACL_ARCH STREQUAL "x86_32")
		SET(NACL_TOOL_PREFIX "i686-nacl")
	else(NACL_ARCH STREQUAL "x86_32")
		SET(NACL_TOOL_PREFIX "x86_64-nacl")
	endif(NACL_ARCH STREQUAL "x86_32")	
	SET(NACL_COMPILER_ID "GNU")	
	set(CMAKE_EXECUTABLE_SUFFIX ".nexe")	
	
	#https://developers.google.com/native-client/dev/devguide/devcycle/dynamic-loading?hl=en#building-a-shared-library-so-file	
	#specific compiler and linker flags
	# original: -m${NACL_ARCH_ADDR} -pedantic -std=gnu++98 -Wno-deprecated-declarations -Wno-write-strings -pthread -pedantic -O2 -Wno-long-long -fno-builtin -fno-stack-protector -fdiagnostics-show-option -D_GNU_SOURCE=1 -D__STDC_FORMAT_MACROS=1 -D_BSD_SOURCE=1 -D_POSIX_C_SOURCE=199506 -D_XOPEN_SOURCE=600
	# -c does not link, only compiles
	set(CMAKE_CXX_FLAGS 			"-std=c++0x -pthread -fno-builtin -Wno-deprecated-declarations -Wno-write-strings -Wno-long-long" CACHE INTERNAL "" FORCE)
	set(CMAKE_CXX_FLAGS_RELEASE 	"-O2" CACHE INTERNAL "" FORCE)
	set(CMAKE_CXX_FLAGS_DEBUG 		"-O0 -g" CACHE INTERNAL "" FORCE)
	set(CMAKE_SHARED_LINKER_FLAGS	"-fPIC -shared" CACHE INTERNAL "" FORCE)
	# linker flags are combined with the compiler flags
	set(CMAKE_EXE_LINKER_FLAGS 		"--strip-all -ldl -lppapi -lppapi_cpp -lnosys -lppapi_gles2 -L${NACL_LIB_PATH} -L${NACL_PORTS_LIB_PATH}" CACHE INTERNAL "" FORCE)
endif()

set(CMAKE_C_FLAGS ${CMAKE_CXX_FLAGS} CACHE INTERNAL "" FORCE)	
set(CMAKE_C_FLAGS_RELEASE ${CMAKE_CXX_FLAGS_RELEASE} CACHE INTERNAL "" FORCE)	
set(CMAKE_C_FLAGS_DEBUG ${CMAKE_CXX_FLAGS_DEBUG} CACHE INTERNAL "" FORCE)	
set(CMAKE_C_FLAGS_RELWITHDEBINFO ${CMAKE_CXX_FLAGS_RELWITHDEBINFO} CACHE INTERNAL "" FORCE)	

message(STATUS "NACL toolchain path set to ${NACL_TOOLCHAIN_PATH}")

# CMake setup
set(CMAKETOOLS_CONFIG_NO_INLINE_ASM ON)
SET(NACL ON)
set(PCH_DISABLE ON)
set(PLATFORM_EMBEDDED ON)

if (NACL_LIB STREQUAL "pnacl")
	set(PLATFORM_NAME "PNaCl" )
	set(PLATFORM_EXE_SUFFIX ".pexe" )	
	#set(CMAKE_EXECUTABLE_POSFIX "pexe")	
else()
	set(PLATFORM_NAME "NaCl" )
	set(PLATFORM_EXE_SUFFIX ".nexe" )	
	#set(CMAKE_EXECUTABLE_POSFIX "nexe")	
endif()

set(CMAKE_SYSTEM_NAME "Linux")
set(CMAKE_SYSTEM_VERSION "4.3")
SET (CMAKE_CROSSCOMPILING TRUE)
if(NACL_LIB STREQUAL "pnacl")
	set(CMAKE_SYSTEM_PROCESSOR "LLVM-IR")
elseif(NACL_ARCH STREQUAL "arm")
	set(CMAKE_SYSTEM_PROCESSOR "arm")
else()
	set(CMAKE_SYSTEM_PROCESSOR "x86")
endif()
set(CMAKETOOLS_CONFIG_NO_INLINE_ASM ON)

# turn off any compatibility checks
SET(CMAKE_SKIP_COMPATIBILITY_TESTS ON)

# size of pointers as enforced by nacl
SET(CMAKE_C_SIZEOF_DATA_PTR 4)
SET(CMAKE_CXX_SIZEOF_DATA_PTR 4)
SET(CMAKE_SIZEOF_VOID_P 4)
SET(OGREDEPS_PTR_SIZE 4)
SET(OGREDEPS_PLATFORM_X64 FALSE)
SET(OGRE_PTR_SIZE 4)
SET(OGRE_PLATFORM_X64 FALSE)
SET(OGRE_TEST_BIG_ENDIAN FALSE)

# set cmake tools
set(CMAKE_ASM_COMPILER 				"${NACL_TOOLCHAIN_PATH}/bin/${NACL_TOOL_PREFIX}-as${NACL_TOOL_SUFFIX}" 		CACHE INTERNAL "" FORCE)
set(CMAKE_C_COMPILER				"${NACL_TOOLCHAIN_PATH}/bin/${NACL_TOOL_PREFIX}-gcc${NACL_TOOL_SUFFIX}"		CACHE INTERNAL "" FORCE)
set(CMAKE_CXX_COMPILER				"${NACL_TOOLCHAIN_PATH}/bin/${NACL_TOOL_PREFIX}-g++${NACL_TOOL_SUFFIX}"		CACHE INTERNAL "" FORCE)
set(CMAKE_LINKER					"${NACL_TOOLCHAIN_PATH}/bin/${NACL_TOOL_PREFIX}-ld${NACL_TOOL_SUFFIX}"		CACHE INTERNAL "" FORCE)
set(CMAKE_AR						"${NACL_TOOLCHAIN_PATH}/bin/${NACL_TOOL_PREFIX}-ar${NACL_TOOL_SUFFIX}"		CACHE INTERNAL "" FORCE)
set(CMAKE_STRIP                		"${NACL_TOOLCHAIN_PATH}/bin/${NACL_TOOL_PREFIX}-strip${NACL_TOOL_SUFFIX}"	CACHE INTERNAL "" FORCE)
set(CMAKE_RANLIB               		"${NACL_TOOLCHAIN_PATH}/bin/${NACL_TOOL_PREFIX}-ranlib${NACL_TOOL_SUFFIX}"	CACHE INTERNAL "" FORCE)	
set(CMAKE_FIND_ROOT_PATH 			"${NACL_SDK_ROOT}" "${NACL_TOOLCHAIN_PATH}" "${NACL_TOOLCHAIN_PATH}/x86_64-nacl" CACHE INTERNAL "" FORCE)
message(STATUS "CMake root path set to ${CMAKE_FIND_ROOT_PATH}")
message(STATUS "Library architecture set to '${CMAKE_LIBRARY_ARCHITECTURE}'. It should not be set")

# some overrides
if (NACL_LIB STREQUAL "pnacl")
	set( CMAKE_C_COMPILER           "${NACL_TOOLCHAIN_PATH}/bin/pnacl-clang${NACL_TOOL_SUFFIX}" 				CACHE INTERNAL "" FORCE)
	set( CMAKE_CXX_COMPILER         "${NACL_TOOLCHAIN_PATH}/bin/pnacl-clang++${NACL_TOOL_SUFFIX}" 				CACHE INTERNAL "" FORCE)
	set( NACL_PNACL_FINALIZER		"${NACL_TOOLCHAIN_PATH}/bin/pnacl-finalize${NACL_TOOL_SUFFIX}")
endif()

message(STATUS "Using ${CMAKE_ASM_COMPILER}, ${CMAKE_C_COMPILER}, ${CMAKE_CXX_COMPILER}, ${CMAKE_LINKER}, ${CMAKE_AR}, ${CMAKE_STRIP}, ${CMAKE_RANLIB}")

# force the compilers
include( CMakeForceCompiler )
cmake_force_c_compiler(         "${CMAKE_C_COMPILER}" ${NACL_COMPILER_ID})
cmake_force_cxx_compiler(       "${CMAKE_CXX_COMPILER}" ${NACL_COMPILER_ID})		

# dependencies require these flags
remove_definitions( -DNACL )
add_definitions( -DNACL )

set( CMAKE_FIND_ROOT_PATH_MODE_PROGRAM NEVER )
set( CMAKE_FIND_ROOT_PATH_MODE_LIBRARY BOTH )
set( CMAKE_FIND_ROOT_PATH_MODE_INCLUDE BOTH )
set( CMAKE_FIND_ROOT_PATH_MODE_PACKAGE BOTH )

# the nacl compiler is currently not generating the proper system include dirs for project file generators (problem reproduced in WIN + ECLIPSE CDT (N)Make generator)
# hence we'll fix the paths returned as /libexec/.... and replace them with <path_to_compiler>/...
# this does not affect compilation via (N)Make
include(CMakeExtraGeneratorDetermineCompilerMacrosAndIncludeDirs)
MACRO(FIX_SYSTEM_INCLUDE_PATHS path_list compiler)
	set(include_temp_list)
	get_filename_component(compiler_temp_path ${compiler} DIRECTORY)
	FOREACH(path IN LISTS ${path_list})
		# replace all the invalid paths
		string(REGEX REPLACE "^(/libexec)(.*)" "${compiler_temp_path}\\2" path "${path}")
		list(APPEND include_temp_list "${path}")
	ENDFOREACH()
	set(${path_list} ${include_temp_list})
ENDMACRO()
FIX_SYSTEM_INCLUDE_PATHS(CMAKE_EXTRA_GENERATOR_C_SYSTEM_INCLUDE_DIRS "${CMAKE_C_COMPILER}")
FIX_SYSTEM_INCLUDE_PATHS(CMAKE_EXTRA_GENERATOR_CXX_SYSTEM_INCLUDE_DIRS "${CMAKE_CXX_COMPILER}")
message("C system include dirs = ${CMAKE_EXTRA_GENERATOR_C_SYSTEM_INCLUDE_DIRS}")
message("C++ system include dirs = ${CMAKE_EXTRA_GENERATOR_CXX_SYSTEM_INCLUDE_DIRS}")

# macro to be used to call the finalizer for PNACL projects
macro( pnacl_finalise target )
  add_custom_command( TARGET ${target}
    POST_BUILD COMMAND "${NACL_PNACL_FINALIZER}"
                       "$<TARGET_FILE:${target}>" )
endmacro()