# Copyright (C) 2010 The Android Open Source Project
#
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
#
#      http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
#
LOCAL_PATH := $(subst //,/,$(call my-dir))

include $(CLEAR_VARS)

LOCAL_MODULE := FreeImage
LOCAL_ARM_MODE  := arm
LOCAL_SRC_FILES := ../../../Deps/FreeImage/lib/Android/$(TARGET_ARCH_ABI)/lib$(LOCAL_MODULE).a
#LOCAL_EXPORT_C_INCLUDES := $(LOCAL_PATH)/..

include $(PREBUILT_STATIC_LIBRARY)

include $(CLEAR_VARS)

LOCAL_MODULE := native-activity-cs

#LOCAL_SRC_FILES := $(wildcard *.cpp)
#LOCAL_SRC_FILES += $(wildcard *.c)
#LOCAL_SRC_FILES += $(wildcard *.ll)
#LOCAL_SRC_FILES += $(wildcard *.bc)

# APP
LOCAL_SRC_FILES := dummy.cpp main.c BabylonAndroid.ll BabylonNativeCsLibraryForIl.ll CoreLib.ll

LOCAL_ARM_MODE  := arm

LOCAL_LDLIBS := -lgc-lib -lstdc++ -lc -lm -llog -landroid -ldl -lGLESv2 -lEGL -lOpenSLES

LOCAL_STATIC_LIBRARIES := android_native_app_glue FreeImage

LOCAL_LDFLAGS := -L$(LOCAL_PATH)/../../../Deps/GC/lib/armeabi-v7a/

LOCAL_CFLAGS := -DANDROID_NDK \
                -DDISABLE_IMPORTGL

LOCAL_LLFLAGS := -enable-pie -relocation-model=pic

include $(BUILD_SHARED_LIBRARY)

$(call import-module,android/native_app_glue)
# uncomment next 2 lines to rebuild FreeImage shared lib
#$(call import-add-path, $(LOCAL_PATH)/../../../../../LibSources/)
#$(call import-module,FreeImage/jni)
