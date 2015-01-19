# install Nvidia Pack (TDP with cygwin)
mkdir cmake-build-android
cd cmake-build-android
cmake -G "Unix Makefiles" -f .. -DCMAKE_TOOLCHAIN_FILE=cmake/toolchain/android.toolchain.cmake -DCMAKE_BUILD_TYPE=Debug -DANDROID_NATIVE_API_LEVEL=android-14 -DWITH_NATIVE_ACTIVITY=ON -DCMAKE_MAKE_PROGRAM="%ANDROID_NDK%/prebuilt/windows/bin/make.exe"
"%ANDROID_NDK%/prebuilt/windows/bin/make.exe"
