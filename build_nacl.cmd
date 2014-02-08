mkdir cmake-build-nacl
cd cmake-build-nacl

# set ENV BOOST_ROOT
cmake -G "Unix Makefiles" -f .. -DCMAKE_TOOLCHAIN_FILE=cmake/toolchain/nacl.toolchain.cmake -DCMAKE_BUILD_TYPE=Rlease -DBoost_INCLUDE_DIR="F:/Dev/Boost/include/boost-1_55" -DBoost_NO_SYSTEM_PATHS=ON -DWITH_NATIVE_CLIENT=OFF -DWITH_NATIVE_ACTIVITY=OFF -DPEPPER_API=32 -DCMAKE_C_COMPILER_FORCED=ON -DCMAKE_CXX_COMPILER_FORCED=ON -DCMAKE_MAKE_PROGRAM="%NACL_SDK_ROOT%/pepper_32/tools/make.exe"
"%NACL_SDK_ROOT%/pepper_32/tools/make.exe"
