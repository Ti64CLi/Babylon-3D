# install Nvidia Pack (TDP with cygwin)
mkdir cmake-build-android
cd cmake-build-android
rem to enable threads support
rem -DCMAKE_USE_PTHREADS_INIT=1
cmake -G "Unix Makefiles" -f .. -DCMAKE_TOOLCHAIN_FILE=cmake/toolchain/android.toolchain.cmake -DCMAKE_BUILD_TYPE=Release -DANDROID_NATIVE_API_LEVEL=android-9 -DCMAKE_MAKE_PROGRAM="%ANDROID_NDK%/prebuilt/windows/bin/make.exe"
"%ANDROID_NDK%/prebuilt/windows/bin/make.exe"
