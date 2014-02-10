cmake_minimum_required( VERSION 2.6.3 )

if( DEFINED CMAKE_CROSSCOMPILING )
 # subsequent toolchain loading is not really needed
 return()
endif()

if( NOT EXISTS "${NACL_SDK_PATH}" )
   SET (NACL_SDK_PATH $ENV{NACL_SDK_PATH})
   if( NOT EXISTS "${NACL_SDK_PATH}" )
      message( FATAL_ERROR "please define a cmake or environment variable: NACL_SDK_PATH" )
   endif()
endif()

# this one is important
set( CMAKE_SYSTEM_NAME Linux )
# this one not so much
set( CMAKE_SYSTEM_VERSION 1 )

set( NACL_TOOLCHAIN_NAME "pnacl" )
#set( NACL_TOOLCHAIN_NAME "x86_glibc" )
set( PEPPER_API 32 )
set( NACL_SDK_HOST_SYSTEM_NAME "win" )

if( NACL_TOOLCHAIN_NAME STREQUAL "pnacl" )
set( NACL_TOOLCHAIN_MACHINE_NAME "pnacl" )
set( NACL_TOOLCHAIN_C "clang" )
set( NACL_TOOLCHAIN_CXX "clang++" )
set( TOOL_OS_SUFFIX ".bat" )
else()
set( NACL_TOOLCHAIN_MACHINE_NAME "i686-nacl" )
set( NACL_TOOLCHAIN_C "gcc" )
set( NACL_TOOLCHAIN_CXX "g++" )
set( TOOL_OS_SUFFIX ".exe" )
endif()

# setup paths
set( NACL_SDK_ROOT "${NACL_SDK_PATH}/pepper_${PEPPER_API}" )
set( NACL_USR_ROOT "${NACL_SDK_ROOT}/toolchain/${NACL_SDK_HOST_SYSTEM_NAME}_${NACL_TOOLCHAIN_NAME}/usr" )
set( NACL_TOOLCHAIN_ROOT "${NACL_SDK_ROOT}/toolchain/${NACL_SDK_HOST_SYSTEM_NAME}_${NACL_TOOLCHAIN_NAME}" )

# specify the cross compiler
set( CMAKE_C_COMPILER   "${NACL_TOOLCHAIN_ROOT}/bin/${NACL_TOOLCHAIN_MACHINE_NAME}-${NACL_TOOLCHAIN_C}${TOOL_OS_SUFFIX}"     CACHE PATH "${NACL_TOOLCHAIN_C}" )
set( CMAKE_CXX_COMPILER "${NACL_TOOLCHAIN_ROOT}/bin/${NACL_TOOLCHAIN_MACHINE_NAME}-${NACL_TOOLCHAIN_CXX}${TOOL_OS_SUFFIX}"   CACHE PATH "${NACL_TOOLCHAIN_CPP}" )
set( CMAKE_ASM_COMPILER "${NACL_TOOLCHAIN_ROOT}/bin/${NACL_TOOLCHAIN_MACHINE_NAME}-${NACL_TOOLCHAIN_C}${TOOL_OS_SUFFIX}"     CACHE PATH "Assembler" )
if( CMAKE_VERSION VERSION_LESS 2.8.5 )
 set( CMAKE_ASM_COMPILER_ARG1 "-c" )
endif()
# there may be a way to make cmake deduce these TODO deduce the rest of the tools
set( CMAKE_STRIP        "${NACL_TOOLCHAIN_ROOT}/bin/${NACL_TOOLCHAIN_MACHINE_NAME}-strip${TOOL_OS_SUFFIX}"   CACHE PATH "strip" )
set( CMAKE_AR           "${NACL_TOOLCHAIN_ROOT}/bin/${NACL_TOOLCHAIN_MACHINE_NAME}-ar${TOOL_OS_SUFFIX}"      CACHE PATH "archive" )
set( CMAKE_LINKER       "${NACL_TOOLCHAIN_ROOT}/bin/${NACL_TOOLCHAIN_MACHINE_NAME}-ld${TOOL_OS_SUFFIX}"      CACHE PATH "linker" )
set( CMAKE_NM           "${NACL_TOOLCHAIN_ROOT}/bin/${NACL_TOOLCHAIN_MACHINE_NAME}-nm${TOOL_OS_SUFFIX}"      CACHE PATH "nm" )
set( CMAKE_OBJCOPY      "${NACL_TOOLCHAIN_ROOT}/bin/${NACL_TOOLCHAIN_MACHINE_NAME}-objcopy${TOOL_OS_SUFFIX}" CACHE PATH "objcopy" )
set( CMAKE_OBJDUMP      "${NACL_TOOLCHAIN_ROOT}/bin/${NACL_TOOLCHAIN_MACHINE_NAME}-objdump${TOOL_OS_SUFFIX}" CACHE PATH "objdump" )
set( CMAKE_RANLIB       "${NACL_TOOLCHAIN_ROOT}/bin/${NACL_TOOLCHAIN_MACHINE_NAME}-ranlib${TOOL_OS_SUFFIX}"  CACHE PATH "ranlib" )
set( _CMAKE_TOOLCHAIN_PREFIX "${NACL_TOOLCHAIN_MACHINE_NAME}-" )
if( APPLE )
 find_program( CMAKE_INSTALL_NAME_TOOL NAMES install_name_tool )
 if( NOT CMAKE_INSTALL_NAME_TOOL )
  message( FATAL_ERROR "Could not find install_name_tool, please check your installation." )
 endif()
 mark_as_advanced( CMAKE_INSTALL_NAME_TOOL )
endif()

# export directories
set( NACL_SYSTEM_INCLUDE_DIRS "" )
set( NACL_SYSTEM_LIB_DIRS "" )

# setup output directories
set( LIBRARY_OUTPUT_PATH_ROOT ${CMAKE_SOURCE_DIR} CACHE PATH "root for library output, set this to change where nacl libs are installed to" )
if(NOT _CMAKE_IN_TRY_COMPILE)
 set( LIBRARY_OUTPUT_PATH "${LIBRARY_OUTPUT_PATH_ROOT}/libs/${NACL_TOOLCHAIN_NAME}" CACHE PATH "path for nacl libs" )
endif()

# includes
list( APPEND NACL_SYSTEM_INCLUDE_DIRS "${NACL_USR_ROOT}/include" "${NACL_SDK_ROOT}/include" )

remove_definitions( -DNACL )
add_definitions( -DNACL )

# linker flags
list( APPEND NACL_SYSTEM_LIB_DIRS "${NACL_SDK_ROOT}/lib/${NACL_TOOLCHAIN_NAME}/${CMAKE_BUILD_TYPE}" "${NACL_USR_ROOT}/lib")
set( NACL_LINKER_FLAGS "" )

include_directories( SYSTEM ${NACL_SYSTEM_INCLUDE_DIRS} )
link_directories( ${NACL_SYSTEM_LIB_DIRS} )

# finish flags
set( CMAKE_CXX_FLAGS           "${CMAKE_CXX_FLAGS} -Wno-long-long -Wswitch-enum -pedantic -pthread" )
set( CMAKE_C_FLAGS             "${CMAKE_C_FLAGS}" )
set( CMAKE_SHARED_LINKER_FLAGS "${CMAKE_SHARED_LINKER_FLAGS}" )
set( CMAKE_MODULE_LINKER_FLAGS "${CMAKE_MODULE_LINKER_FLAGS}" )
set( CMAKE_EXE_LINKER_FLAGS    "${CMAKE_EXE_LINKER_FLAGS} ${NACL_LINKER_FLAGS}" )

# set these global flags for cmake client scripts to change behavior
set( NACL True )
set( BUILD_NACL True )

# where is the target environment
set( CMAKE_FIND_ROOT_PATH "${NACL_TOOLCHAIN_ROOT}/bin" "${NACL_TOOLCHAIN_ROOT}/${NACL_TOOLCHAIN_MACHINE_NAME}" "${NACL_USR_ROOT}" )

# only search for libraries and includes in the nacl_sdk toolchain
set( CMAKE_FIND_ROOT_PATH_MODE_PROGRAM ONLY )
set( CMAKE_FIND_ROOT_PATH_MODE_LIBRARY ONLY )
set( CMAKE_FIND_ROOT_PATH_MODE_INCLUDE BOTH )
