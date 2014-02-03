# Install script for directory: C:/Dev/BabylonNative/Babylon

# Set the install prefix
IF(NOT DEFINED CMAKE_INSTALL_PREFIX)
  SET(CMAKE_INSTALL_PREFIX "C:/Program Files (x86)/Babylon")
ENDIF(NOT DEFINED CMAKE_INSTALL_PREFIX)
STRING(REGEX REPLACE "/$" "" CMAKE_INSTALL_PREFIX "${CMAKE_INSTALL_PREFIX}")

# Set the install configuration name.
IF(NOT DEFINED CMAKE_INSTALL_CONFIG_NAME)
  IF(BUILD_TYPE)
    STRING(REGEX REPLACE "^[^A-Za-z0-9_]+" ""
           CMAKE_INSTALL_CONFIG_NAME "${BUILD_TYPE}")
  ELSE(BUILD_TYPE)
    SET(CMAKE_INSTALL_CONFIG_NAME "")
  ENDIF(BUILD_TYPE)
  MESSAGE(STATUS "Install configuration: \"${CMAKE_INSTALL_CONFIG_NAME}\"")
ENDIF(NOT DEFINED CMAKE_INSTALL_CONFIG_NAME)

# Set the component getting installed.
IF(NOT CMAKE_INSTALL_COMPONENT)
  IF(COMPONENT)
    MESSAGE(STATUS "Install component: \"${COMPONENT}\"")
    SET(CMAKE_INSTALL_COMPONENT "${COMPONENT}")
  ELSE(COMPONENT)
    SET(CMAKE_INSTALL_COMPONENT)
  ENDIF(COMPONENT)
ENDIF(NOT CMAKE_INSTALL_COMPONENT)

IF(NOT CMAKE_INSTALL_LOCAL_ONLY)
  # Include the install script for each subdirectory.
  INCLUDE("C:/Dev/BabylonNative/cmake-build-MinGW/Babylon/Animations/cmake_install.cmake")
  INCLUDE("C:/Dev/BabylonNative/cmake-build-MinGW/Babylon/Bones/cmake_install.cmake")
  INCLUDE("C:/Dev/BabylonNative/cmake-build-MinGW/Babylon/Cameras/cmake_install.cmake")
  INCLUDE("C:/Dev/BabylonNative/cmake-build-MinGW/Babylon/Collisions/cmake_install.cmake")
  INCLUDE("C:/Dev/BabylonNative/cmake-build-MinGW/Babylon/Context/cmake_install.cmake")
  INCLUDE("C:/Dev/BabylonNative/cmake-build-MinGW/Babylon/Culling/cmake_install.cmake")
  INCLUDE("C:/Dev/BabylonNative/cmake-build-MinGW/Babylon/Engine/cmake_install.cmake")
  INCLUDE("C:/Dev/BabylonNative/cmake-build-MinGW/Babylon/Layer/cmake_install.cmake")
  INCLUDE("C:/Dev/BabylonNative/cmake-build-MinGW/Babylon/LensFlare/cmake_install.cmake")
  INCLUDE("C:/Dev/BabylonNative/cmake-build-MinGW/Babylon/Lights/cmake_install.cmake")
  INCLUDE("C:/Dev/BabylonNative/cmake-build-MinGW/Babylon/Materials/cmake_install.cmake")
  INCLUDE("C:/Dev/BabylonNative/cmake-build-MinGW/Babylon/Mesh/cmake_install.cmake")
  INCLUDE("C:/Dev/BabylonNative/cmake-build-MinGW/Babylon/Particles/cmake_install.cmake")
  INCLUDE("C:/Dev/BabylonNative/cmake-build-MinGW/Babylon/PhysicsEngine/cmake_install.cmake")
  INCLUDE("C:/Dev/BabylonNative/cmake-build-MinGW/Babylon/PostProcess/cmake_install.cmake")
  INCLUDE("C:/Dev/BabylonNative/cmake-build-MinGW/Babylon/Rendering/cmake_install.cmake")
  INCLUDE("C:/Dev/BabylonNative/cmake-build-MinGW/Babylon/Sprites/cmake_install.cmake")
  INCLUDE("C:/Dev/BabylonNative/cmake-build-MinGW/Babylon/Textures/cmake_install.cmake")
  INCLUDE("C:/Dev/BabylonNative/cmake-build-MinGW/Babylon/Tools/cmake_install.cmake")

ENDIF(NOT CMAKE_INSTALL_LOCAL_ONLY)

