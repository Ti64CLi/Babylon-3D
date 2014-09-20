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

LOCAL_MODULE := native-activity

LOCAL_SRC_FILES := $(wildcard *.cpp)
LOCAL_SRC_FILES += $(wildcard *.c)

# custom build
source_ll_files := $(wildcard *.ll)

%.s:
	llc -o $@ $(patsubst %.s,%.ll,$@)

LOCAL_SRC_FILES += $(patsubst %.ll,%.s,$(source_ll_files))
# end

LOCAL_ARM_MODE   := arm

LOCAL_LDLIBS :=  -lstdc++ -lc -lm -llog -landroid -ldl -lGLESv2 -lEGL -lOpenSLES
LOCAL_STATIC_LIBRARIES := android_native_app_glue

LOCAL_CFLAGS := -DANDROID_NDK \
                -DDISABLE_IMPORTGL

include $(BUILD_SHARED_LIBRARY)

#$(call import-add-path, ../libs/jni)

$(call import-module,android/native_app_glue)