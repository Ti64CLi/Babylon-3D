set(NACL_LIB "glibc" CACHE STRING "Nacl library")
set(NACL_ARCH "x86_64" CACHE STRING "Nacl architecture")

include("${CMAKE_CURRENT_LIST_DIR}/nacl.generic.toolchain.cmake")

