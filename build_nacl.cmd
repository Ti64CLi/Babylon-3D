mkdir cmake-build-nacl
cd cmake-build-nacl
cmake -G "Unix Makefiles" -f .. -DCMAKE_TOOLCHAIN_FILE=cmake/toolchain/nacl.toolchain.cmake -DCMAKE_BUILD_TYPE=Rlease -DWITH_NATIVE_CLIENT=OFF -DWITH_NATIVE_ACTIVITY=OFF -DPEPPER_API=32 -DCMAKE_MAKE_PROGRAM="%NACL_SDK_ROOT%/pepper_32/tools/make.exe"
"%NACL_SDK_ROOT%/pepper_32/tools/make.exe"
