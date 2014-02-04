mkdir cmake-build-android
cd cmake-build-android
cmake -G "Unix Makefiles" -f ..\ -DCMAKE_TOOLCHAIN_FILE=cmake/toolchain/android.toolchain.cmake -DWITH_NATIVE_CLIENT=OFF
nmake
