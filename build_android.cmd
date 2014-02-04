# install Nvidia Pack (TDP with cygwin)
mkdir cmake-build-android
cd cmake-build-android
cmake -G "Unix Makefiles" -f ..\ -DCMAKE_TOOLCHAIN_FILE=cmake/toolchain/android.toolchain.cmake -DANDROID_NATIVE_API_LEVEL=android-14 -DWITH_NATIVE_CLIENT=OFF
nmake
