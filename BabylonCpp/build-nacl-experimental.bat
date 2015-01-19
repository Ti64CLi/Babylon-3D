mkdir cmake-build-nacl
cd cmake-build-nacl
cmake -G "Unix Makefiles" -f .. -DCMAKE_TOOLCHAIN_FILE=cmake/experimental/pnacl.toolchain.cmake -DNACL_TOOLCHAIN_ROOT="C:/Dev/Sdk/nacl_sdk/pepper_33/toolchain/win_pnacl" -DNACL_TOOLCHAIN_MACHINE_NAME=pnacl -DTOOL_OS_SUFFIX=.bat -D_ECLIPSE_VERSION=4.3 -DCMAKE_BUILD_TYPE=Release -DWITH_NATIVE_CLIENT=ON -DCMAKE_C_COMPILER_FORCED=ON -DCMAKE_CXX_COMPILER_FORCED=ON -DCMAKE_MAKE_PROGRAM="%NACL_SDK_PATH%/pepper_33/tools/make.exe"
"%NACL_SDK_PATH%/pepper_33/tools/make.exe"
