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
LOCAL_PATH := $(call my-dir)

include $(CLEAR_VARS)

_INC := $(LOCAL_PATH)/../../../Babylon
LOCAL_C_INCLUDES += $(_INC)/Animations $(_INC)/Bones $(_INC)/Cameras $(_INC)/Collisions $(_INC)/Context $(_INC)/Culling $(_INC)/Engine $(_INC)/Interfaces $(_INC)/Layer $(_INC)/LensFlare $(_INC)/Lights $(_INC)/Materials $(_INC)/Mesh $(_INC)/Particles $(_INC)/PhysicsEngine $(_INC)/PostProcess $(_INC)/Rendering $(_INC)/Sprites $(_INC)/Textures $(_INC)/Tools
LOCAL_LDFLAGS += -Lobj/local/armeabi/ -L$(LOCAL_PATH)/../../../libs/armeabi-v7a/

LOCAL_MODULE    := native-activity
LOCAL_SRC_FILES := main.cpp canvas.cpp gl.cpp
LOCAL_LDLIBS    := -llog -landroid -lEGL -lGLESv2 -lstdlibc++ -lEngine -lAnimations -lBones -lCameras -lCollisions -lContext -lCulling -lLayer -lLensFlare -lLights -lMaterials -lMesh -lParticles -lPhysicsEngine -lPostProcess -lRendering -lSprites -lTextures -lTools
LOCAL_STATIC_LIBRARIES := android_native_app_glue

include $(BUILD_SHARED_LIBRARY)

$(call import-module,android/native_app_glue)
