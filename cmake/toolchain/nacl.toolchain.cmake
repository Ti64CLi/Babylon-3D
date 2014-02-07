if( NOT EXISTS "${NACL_SDK_ROOT}" )
   SET (NACL_SDK_ROOT $ENV{NACL_SDK_ROOT})
   if( NOT EXISTS "${NACL_SDK_ROOT}" )
      message( FATAL_ERROR "please define a cmake or environment variable: NACL_SDK_ROOT" )
   endif()
endif()

set(HOST win)
#set(ARCH pnacl)
set(ARCH x86_glibc)
#set(HOST_C_COMPILER pnacl-clang.bat)
#set(HOST_CPP_COMPILER pnacl-clang++.bat)
set(HOST_C_COMPILER x86_64-nacl-gcc.exe)
set(HOST_CPP_COMPILER x86_64-nacl-g++.exe)

string( REPLACE "\\" "/" NACL_SDK_ROOT "${NACL_SDK_ROOT}" )

# ---------------------------------------------------------------------------------------------------------------------------------------------------------------

set(CMAKE_SYSTEM_NAME Linux)
set(CMAKE_SYSTEM_VERSION 1)

set(CMAKE_C_COMPILER    "${NACL_SDK_ROOT}/pepper_${PEPPER_API}/toolchain/${HOST}_${ARCH}/bin/${HOST_C_COMPILER}")
set(CMAKE_CXX_COMPILER  "${NACL_SDK_ROOT}/pepper_${PEPPER_API}/toolchain/${HOST}_${ARCH}/bin/${HOST_CPP_COMPILER}")
set(NACL_SYSROOT        "${NACL_SDK_ROOT}/pepper_${PEPPER_API}/toolchain/${HOST}_${ARCH}/sysroot" CACHE PATH "NACL cross compilation system root")

set(CMAKE_CXX_FLAGS           "" 				CACHE STRING "c++ flags")
set(CMAKE_C_FLAGS             ""                    		CACHE STRING "c flags")
set(CMAKE_LD_FLAGS            ""                    		CACHE STRING "ld flags")

set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -I${NACL_SDK_ROOT}/include")
set(CMAKE_C_FLAGS   "${CMAKE_C_FLAGS}   -I${NACL_SDK_ROOT}/include")
set(CMAKE_LD_FLAGS  "${CMAKE_LD_FLAGS}  -L${NACL_SDK_ROOT}/lib/pnacl/Release -lppapi_cpp -lppapi")

set(CMAKE_SHARED_LINKER_FLAGS "${CMAKE_SHARED_LINKER_FLAGS}")
set(CMAKE_MODULE_LINKER_FLAGS "${CMAKE_MODULE_LINKER_FLAGS}")

set(CMAKE_FIND_ROOT_PATH ${CMAKE_FIND_ROOT_PATH} ${NACL_SYSROOT})

set( CMAKE_SKIP_RPATH TRUE CACHE BOOL "If set, runtime paths are not added when using shared libraries." )
set(CMAKE_FIND_ROOT_PATH_MODE_INCLUDE ONLY)
set(CMAKE_FIND_ROOT_PATH_MODE_LIBRARY ONLY)
set(CMAKE_FIND_ROOT_PATH_MODE_PROGRAM ONLY)