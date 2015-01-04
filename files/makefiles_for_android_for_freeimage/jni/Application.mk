APP_OPTIM := release
APP_PLATFORM := android-15
APP_STL := gnustl_static
APP_CPPFLAGS += -frtti 
APP_CPPFLAGS += -fexceptions
APP_CPPFLAGS += -DANDROID
APP_CPPFLAGS += -Wno-error=format-security -std=c++11
APP_ABI := armeabi-v7a x86
APP_MODULES := FreeImage
NDK_TOOLCHAIN_VERSION=4.8