# install Nvidia Pack (TDP with cygwin)
mkdir cmake-build-android
cd cmake-build-android
cmake -G "Unix Makefiles" -f .. -DCMAKE_TOOLCHAIN_FILE=cmake/toolchain/android.toolchain.cmake -DCMAKE_BUILD_TYPE=Release -DANDROID_NATIVE_API_LEVEL=android-9 -DBGL_ANDROID=1 -DPLATFORM_ANDROID=1 -DFINALIZE_ON_DEMAND=1 -DIGNORE_DYNAMIC_LOADING=1 -DCMAKE_MAKE_PROGRAM="%ANDROID_NDK%/prebuilt/windows/bin/make.exe"
"%ANDROID_NDK%/prebuilt/windows/bin/make.exe"
