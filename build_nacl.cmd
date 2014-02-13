mkdir cmake-build-nacl
cd cmake-build-nacl
cmake -G "Unix Makefiles" -f .. -DCMAKE_TOOLCHAIN_FILE=cmake/toolchain/nacl.toolchain.cmake -DCMAKE_BUILD_TYPE=Release -DWITH_NATIVE_CLIENT=ON -DCMAKE_C_COMPILER_FORCED=ON -DCMAKE_CXX_COMPILER_FORCED=ON -DCMAKE_MAKE_PROGRAM="%NACL_SDK_PATH%/pepper_33/tools/make.exe"
"%NACL_SDK_PATH%/pepper_33/tools/make.exe"
