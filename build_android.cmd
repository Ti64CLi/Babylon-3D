# install Nvidia Pack (TDP with cygwin)
mkdir cmake-build-android
cd cmake-build-android
cmake -G "Unix Makefiles" -f ..\ -DCMAKE_TOOLCHAIN_FILE=cmake/toolchain/android.toolchain.cmake -DANDROID_NATIVE_API_LEVEL=android-14 -DWITH_NATIVE_CLIENT=OFF -DWITH_NATIVE_ACTIVITY=ON -DCMAKE_MAKE_PROGRAM=F:\Dev\NVPACK\android-ndk-r9b\prebuilt\windows\bin\make.exe
F:\Dev\NVPACK\android-ndk-r9b\prebuilt\windows\bin\make.exe