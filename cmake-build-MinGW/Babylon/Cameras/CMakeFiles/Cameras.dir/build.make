# CMAKE generated file: DO NOT EDIT!
# Generated by "MinGW Makefiles" Generator, CMake Version 2.8

#=============================================================================
# Special targets provided by cmake.

# Disable implicit rules so canonical targets will work.
.SUFFIXES:

# Remove some rules from gmake that .SUFFIXES does not remove.
SUFFIXES =

.SUFFIXES: .hpux_make_needs_suffix_list

# Suppress display of executed commands.
$(VERBOSE).SILENT:

# A target that is always out of date.
cmake_force:
.PHONY : cmake_force

#=============================================================================
# Set environment variables for the build.

SHELL = cmd.exe

# The CMake executable.
CMAKE_COMMAND = "C:\Program Files (x86)\CMake 2.8\bin\cmake.exe"

# The command to remove a file.
RM = "C:\Program Files (x86)\CMake 2.8\bin\cmake.exe" -E remove -f

# Escaping for special characters.
EQUALS = =

# The program to use to edit the cache.
CMAKE_EDIT_COMMAND = "C:\Program Files (x86)\CMake 2.8\bin\cmake-gui.exe"

# The top-level source directory on which CMake was run.
CMAKE_SOURCE_DIR = C:\Dev\BabylonNative

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = C:\Dev\BabylonNative\cmake-build-MinGW

# Include any dependencies generated for this target.
include Babylon/Cameras/CMakeFiles/Cameras.dir/depend.make

# Include the progress variables for this target.
include Babylon/Cameras/CMakeFiles/Cameras.dir/progress.make

# Include the compile flags for this target's objects.
include Babylon/Cameras/CMakeFiles/Cameras.dir/flags.make

Babylon/Cameras/CMakeFiles/Cameras.dir/camera.cpp.obj: Babylon/Cameras/CMakeFiles/Cameras.dir/flags.make
Babylon/Cameras/CMakeFiles/Cameras.dir/camera.cpp.obj: Babylon/Cameras/CMakeFiles/Cameras.dir/includes_CXX.rsp
Babylon/Cameras/CMakeFiles/Cameras.dir/camera.cpp.obj: ../Babylon/Cameras/camera.cpp
	$(CMAKE_COMMAND) -E cmake_progress_report C:\Dev\BabylonNative\cmake-build-MinGW\CMakeFiles $(CMAKE_PROGRESS_1)
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Building CXX object Babylon/Cameras/CMakeFiles/Cameras.dir/camera.cpp.obj"
	cd /d C:\Dev\BabylonNative\cmake-build-MinGW\Babylon\Cameras && C:\Dev\Utils\MinGW\bin\g++.exe   $(CXX_DEFINES) $(CXX_FLAGS) -o CMakeFiles\Cameras.dir\camera.cpp.obj -c C:\Dev\BabylonNative\Babylon\Cameras\camera.cpp

Babylon/Cameras/CMakeFiles/Cameras.dir/camera.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/Cameras.dir/camera.cpp.i"
	cd /d C:\Dev\BabylonNative\cmake-build-MinGW\Babylon\Cameras && C:\Dev\Utils\MinGW\bin\g++.exe  $(CXX_DEFINES) $(CXX_FLAGS) -E C:\Dev\BabylonNative\Babylon\Cameras\camera.cpp > CMakeFiles\Cameras.dir\camera.cpp.i

Babylon/Cameras/CMakeFiles/Cameras.dir/camera.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/Cameras.dir/camera.cpp.s"
	cd /d C:\Dev\BabylonNative\cmake-build-MinGW\Babylon\Cameras && C:\Dev\Utils\MinGW\bin\g++.exe  $(CXX_DEFINES) $(CXX_FLAGS) -S C:\Dev\BabylonNative\Babylon\Cameras\camera.cpp -o CMakeFiles\Cameras.dir\camera.cpp.s

Babylon/Cameras/CMakeFiles/Cameras.dir/camera.cpp.obj.requires:
.PHONY : Babylon/Cameras/CMakeFiles/Cameras.dir/camera.cpp.obj.requires

Babylon/Cameras/CMakeFiles/Cameras.dir/camera.cpp.obj.provides: Babylon/Cameras/CMakeFiles/Cameras.dir/camera.cpp.obj.requires
	$(MAKE) -f Babylon\Cameras\CMakeFiles\Cameras.dir\build.make Babylon/Cameras/CMakeFiles/Cameras.dir/camera.cpp.obj.provides.build
.PHONY : Babylon/Cameras/CMakeFiles/Cameras.dir/camera.cpp.obj.provides

Babylon/Cameras/CMakeFiles/Cameras.dir/camera.cpp.obj.provides.build: Babylon/Cameras/CMakeFiles/Cameras.dir/camera.cpp.obj

Babylon/Cameras/CMakeFiles/Cameras.dir/arcRotateCamera.cpp.obj: Babylon/Cameras/CMakeFiles/Cameras.dir/flags.make
Babylon/Cameras/CMakeFiles/Cameras.dir/arcRotateCamera.cpp.obj: Babylon/Cameras/CMakeFiles/Cameras.dir/includes_CXX.rsp
Babylon/Cameras/CMakeFiles/Cameras.dir/arcRotateCamera.cpp.obj: ../Babylon/Cameras/arcRotateCamera.cpp
	$(CMAKE_COMMAND) -E cmake_progress_report C:\Dev\BabylonNative\cmake-build-MinGW\CMakeFiles $(CMAKE_PROGRESS_2)
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Building CXX object Babylon/Cameras/CMakeFiles/Cameras.dir/arcRotateCamera.cpp.obj"
	cd /d C:\Dev\BabylonNative\cmake-build-MinGW\Babylon\Cameras && C:\Dev\Utils\MinGW\bin\g++.exe   $(CXX_DEFINES) $(CXX_FLAGS) -o CMakeFiles\Cameras.dir\arcRotateCamera.cpp.obj -c C:\Dev\BabylonNative\Babylon\Cameras\arcRotateCamera.cpp

Babylon/Cameras/CMakeFiles/Cameras.dir/arcRotateCamera.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/Cameras.dir/arcRotateCamera.cpp.i"
	cd /d C:\Dev\BabylonNative\cmake-build-MinGW\Babylon\Cameras && C:\Dev\Utils\MinGW\bin\g++.exe  $(CXX_DEFINES) $(CXX_FLAGS) -E C:\Dev\BabylonNative\Babylon\Cameras\arcRotateCamera.cpp > CMakeFiles\Cameras.dir\arcRotateCamera.cpp.i

Babylon/Cameras/CMakeFiles/Cameras.dir/arcRotateCamera.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/Cameras.dir/arcRotateCamera.cpp.s"
	cd /d C:\Dev\BabylonNative\cmake-build-MinGW\Babylon\Cameras && C:\Dev\Utils\MinGW\bin\g++.exe  $(CXX_DEFINES) $(CXX_FLAGS) -S C:\Dev\BabylonNative\Babylon\Cameras\arcRotateCamera.cpp -o CMakeFiles\Cameras.dir\arcRotateCamera.cpp.s

Babylon/Cameras/CMakeFiles/Cameras.dir/arcRotateCamera.cpp.obj.requires:
.PHONY : Babylon/Cameras/CMakeFiles/Cameras.dir/arcRotateCamera.cpp.obj.requires

Babylon/Cameras/CMakeFiles/Cameras.dir/arcRotateCamera.cpp.obj.provides: Babylon/Cameras/CMakeFiles/Cameras.dir/arcRotateCamera.cpp.obj.requires
	$(MAKE) -f Babylon\Cameras\CMakeFiles\Cameras.dir\build.make Babylon/Cameras/CMakeFiles/Cameras.dir/arcRotateCamera.cpp.obj.provides.build
.PHONY : Babylon/Cameras/CMakeFiles/Cameras.dir/arcRotateCamera.cpp.obj.provides

Babylon/Cameras/CMakeFiles/Cameras.dir/arcRotateCamera.cpp.obj.provides.build: Babylon/Cameras/CMakeFiles/Cameras.dir/arcRotateCamera.cpp.obj

# Object files for target Cameras
Cameras_OBJECTS = \
"CMakeFiles/Cameras.dir/camera.cpp.obj" \
"CMakeFiles/Cameras.dir/arcRotateCamera.cpp.obj"

# External object files for target Cameras
Cameras_EXTERNAL_OBJECTS =

Babylon/Cameras/libCameras.a: Babylon/Cameras/CMakeFiles/Cameras.dir/camera.cpp.obj
Babylon/Cameras/libCameras.a: Babylon/Cameras/CMakeFiles/Cameras.dir/arcRotateCamera.cpp.obj
Babylon/Cameras/libCameras.a: Babylon/Cameras/CMakeFiles/Cameras.dir/build.make
Babylon/Cameras/libCameras.a: Babylon/Cameras/CMakeFiles/Cameras.dir/link.txt
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --red --bold "Linking CXX static library libCameras.a"
	cd /d C:\Dev\BabylonNative\cmake-build-MinGW\Babylon\Cameras && $(CMAKE_COMMAND) -P CMakeFiles\Cameras.dir\cmake_clean_target.cmake
	cd /d C:\Dev\BabylonNative\cmake-build-MinGW\Babylon\Cameras && $(CMAKE_COMMAND) -E cmake_link_script CMakeFiles\Cameras.dir\link.txt --verbose=$(VERBOSE)

# Rule to build all files generated by this target.
Babylon/Cameras/CMakeFiles/Cameras.dir/build: Babylon/Cameras/libCameras.a
.PHONY : Babylon/Cameras/CMakeFiles/Cameras.dir/build

Babylon/Cameras/CMakeFiles/Cameras.dir/requires: Babylon/Cameras/CMakeFiles/Cameras.dir/camera.cpp.obj.requires
Babylon/Cameras/CMakeFiles/Cameras.dir/requires: Babylon/Cameras/CMakeFiles/Cameras.dir/arcRotateCamera.cpp.obj.requires
.PHONY : Babylon/Cameras/CMakeFiles/Cameras.dir/requires

Babylon/Cameras/CMakeFiles/Cameras.dir/clean:
	cd /d C:\Dev\BabylonNative\cmake-build-MinGW\Babylon\Cameras && $(CMAKE_COMMAND) -P CMakeFiles\Cameras.dir\cmake_clean.cmake
.PHONY : Babylon/Cameras/CMakeFiles/Cameras.dir/clean

Babylon/Cameras/CMakeFiles/Cameras.dir/depend:
	$(CMAKE_COMMAND) -E cmake_depends "MinGW Makefiles" C:\Dev\BabylonNative C:\Dev\BabylonNative\Babylon\Cameras C:\Dev\BabylonNative\cmake-build-MinGW C:\Dev\BabylonNative\cmake-build-MinGW\Babylon\Cameras C:\Dev\BabylonNative\cmake-build-MinGW\Babylon\Cameras\CMakeFiles\Cameras.dir\DependInfo.cmake --color=$(COLOR)
.PHONY : Babylon/Cameras/CMakeFiles/Cameras.dir/depend

