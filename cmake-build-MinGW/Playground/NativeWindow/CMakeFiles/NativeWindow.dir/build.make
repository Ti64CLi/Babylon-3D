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
include Playground/NativeWindow/CMakeFiles/NativeWindow.dir/depend.make

# Include the progress variables for this target.
include Playground/NativeWindow/CMakeFiles/NativeWindow.dir/progress.make

# Include the compile flags for this target's objects.
include Playground/NativeWindow/CMakeFiles/NativeWindow.dir/flags.make

Playground/NativeWindow/CMakeFiles/NativeWindow.dir/main.cpp.obj: Playground/NativeWindow/CMakeFiles/NativeWindow.dir/flags.make
Playground/NativeWindow/CMakeFiles/NativeWindow.dir/main.cpp.obj: Playground/NativeWindow/CMakeFiles/NativeWindow.dir/includes_CXX.rsp
Playground/NativeWindow/CMakeFiles/NativeWindow.dir/main.cpp.obj: ../Playground/NativeWindow/main.cpp
	$(CMAKE_COMMAND) -E cmake_progress_report C:\Dev\BabylonNative\cmake-build-MinGW\CMakeFiles $(CMAKE_PROGRESS_1)
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Building CXX object Playground/NativeWindow/CMakeFiles/NativeWindow.dir/main.cpp.obj"
	cd /d C:\Dev\BabylonNative\cmake-build-MinGW\Playground\NativeWindow && C:\Dev\Utils\MinGW\bin\g++.exe   $(CXX_DEFINES) $(CXX_FLAGS) -o CMakeFiles\NativeWindow.dir\main.cpp.obj -c C:\Dev\BabylonNative\Playground\NativeWindow\main.cpp

Playground/NativeWindow/CMakeFiles/NativeWindow.dir/main.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/NativeWindow.dir/main.cpp.i"
	cd /d C:\Dev\BabylonNative\cmake-build-MinGW\Playground\NativeWindow && C:\Dev\Utils\MinGW\bin\g++.exe  $(CXX_DEFINES) $(CXX_FLAGS) -E C:\Dev\BabylonNative\Playground\NativeWindow\main.cpp > CMakeFiles\NativeWindow.dir\main.cpp.i

Playground/NativeWindow/CMakeFiles/NativeWindow.dir/main.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/NativeWindow.dir/main.cpp.s"
	cd /d C:\Dev\BabylonNative\cmake-build-MinGW\Playground\NativeWindow && C:\Dev\Utils\MinGW\bin\g++.exe  $(CXX_DEFINES) $(CXX_FLAGS) -S C:\Dev\BabylonNative\Playground\NativeWindow\main.cpp -o CMakeFiles\NativeWindow.dir\main.cpp.s

Playground/NativeWindow/CMakeFiles/NativeWindow.dir/main.cpp.obj.requires:
.PHONY : Playground/NativeWindow/CMakeFiles/NativeWindow.dir/main.cpp.obj.requires

Playground/NativeWindow/CMakeFiles/NativeWindow.dir/main.cpp.obj.provides: Playground/NativeWindow/CMakeFiles/NativeWindow.dir/main.cpp.obj.requires
	$(MAKE) -f Playground\NativeWindow\CMakeFiles\NativeWindow.dir\build.make Playground/NativeWindow/CMakeFiles/NativeWindow.dir/main.cpp.obj.provides.build
.PHONY : Playground/NativeWindow/CMakeFiles/NativeWindow.dir/main.cpp.obj.provides

Playground/NativeWindow/CMakeFiles/NativeWindow.dir/main.cpp.obj.provides.build: Playground/NativeWindow/CMakeFiles/NativeWindow.dir/main.cpp.obj

Playground/NativeWindow/CMakeFiles/NativeWindow.dir/canvas.cpp.obj: Playground/NativeWindow/CMakeFiles/NativeWindow.dir/flags.make
Playground/NativeWindow/CMakeFiles/NativeWindow.dir/canvas.cpp.obj: Playground/NativeWindow/CMakeFiles/NativeWindow.dir/includes_CXX.rsp
Playground/NativeWindow/CMakeFiles/NativeWindow.dir/canvas.cpp.obj: ../Playground/NativeWindow/canvas.cpp
	$(CMAKE_COMMAND) -E cmake_progress_report C:\Dev\BabylonNative\cmake-build-MinGW\CMakeFiles $(CMAKE_PROGRESS_2)
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Building CXX object Playground/NativeWindow/CMakeFiles/NativeWindow.dir/canvas.cpp.obj"
	cd /d C:\Dev\BabylonNative\cmake-build-MinGW\Playground\NativeWindow && C:\Dev\Utils\MinGW\bin\g++.exe   $(CXX_DEFINES) $(CXX_FLAGS) -o CMakeFiles\NativeWindow.dir\canvas.cpp.obj -c C:\Dev\BabylonNative\Playground\NativeWindow\canvas.cpp

Playground/NativeWindow/CMakeFiles/NativeWindow.dir/canvas.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/NativeWindow.dir/canvas.cpp.i"
	cd /d C:\Dev\BabylonNative\cmake-build-MinGW\Playground\NativeWindow && C:\Dev\Utils\MinGW\bin\g++.exe  $(CXX_DEFINES) $(CXX_FLAGS) -E C:\Dev\BabylonNative\Playground\NativeWindow\canvas.cpp > CMakeFiles\NativeWindow.dir\canvas.cpp.i

Playground/NativeWindow/CMakeFiles/NativeWindow.dir/canvas.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/NativeWindow.dir/canvas.cpp.s"
	cd /d C:\Dev\BabylonNative\cmake-build-MinGW\Playground\NativeWindow && C:\Dev\Utils\MinGW\bin\g++.exe  $(CXX_DEFINES) $(CXX_FLAGS) -S C:\Dev\BabylonNative\Playground\NativeWindow\canvas.cpp -o CMakeFiles\NativeWindow.dir\canvas.cpp.s

Playground/NativeWindow/CMakeFiles/NativeWindow.dir/canvas.cpp.obj.requires:
.PHONY : Playground/NativeWindow/CMakeFiles/NativeWindow.dir/canvas.cpp.obj.requires

Playground/NativeWindow/CMakeFiles/NativeWindow.dir/canvas.cpp.obj.provides: Playground/NativeWindow/CMakeFiles/NativeWindow.dir/canvas.cpp.obj.requires
	$(MAKE) -f Playground\NativeWindow\CMakeFiles\NativeWindow.dir\build.make Playground/NativeWindow/CMakeFiles/NativeWindow.dir/canvas.cpp.obj.provides.build
.PHONY : Playground/NativeWindow/CMakeFiles/NativeWindow.dir/canvas.cpp.obj.provides

Playground/NativeWindow/CMakeFiles/NativeWindow.dir/canvas.cpp.obj.provides.build: Playground/NativeWindow/CMakeFiles/NativeWindow.dir/canvas.cpp.obj

Playground/NativeWindow/CMakeFiles/NativeWindow.dir/gl.cpp.obj: Playground/NativeWindow/CMakeFiles/NativeWindow.dir/flags.make
Playground/NativeWindow/CMakeFiles/NativeWindow.dir/gl.cpp.obj: Playground/NativeWindow/CMakeFiles/NativeWindow.dir/includes_CXX.rsp
Playground/NativeWindow/CMakeFiles/NativeWindow.dir/gl.cpp.obj: ../Playground/NativeWindow/gl.cpp
	$(CMAKE_COMMAND) -E cmake_progress_report C:\Dev\BabylonNative\cmake-build-MinGW\CMakeFiles $(CMAKE_PROGRESS_3)
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Building CXX object Playground/NativeWindow/CMakeFiles/NativeWindow.dir/gl.cpp.obj"
	cd /d C:\Dev\BabylonNative\cmake-build-MinGW\Playground\NativeWindow && C:\Dev\Utils\MinGW\bin\g++.exe   $(CXX_DEFINES) $(CXX_FLAGS) -o CMakeFiles\NativeWindow.dir\gl.cpp.obj -c C:\Dev\BabylonNative\Playground\NativeWindow\gl.cpp

Playground/NativeWindow/CMakeFiles/NativeWindow.dir/gl.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/NativeWindow.dir/gl.cpp.i"
	cd /d C:\Dev\BabylonNative\cmake-build-MinGW\Playground\NativeWindow && C:\Dev\Utils\MinGW\bin\g++.exe  $(CXX_DEFINES) $(CXX_FLAGS) -E C:\Dev\BabylonNative\Playground\NativeWindow\gl.cpp > CMakeFiles\NativeWindow.dir\gl.cpp.i

Playground/NativeWindow/CMakeFiles/NativeWindow.dir/gl.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/NativeWindow.dir/gl.cpp.s"
	cd /d C:\Dev\BabylonNative\cmake-build-MinGW\Playground\NativeWindow && C:\Dev\Utils\MinGW\bin\g++.exe  $(CXX_DEFINES) $(CXX_FLAGS) -S C:\Dev\BabylonNative\Playground\NativeWindow\gl.cpp -o CMakeFiles\NativeWindow.dir\gl.cpp.s

Playground/NativeWindow/CMakeFiles/NativeWindow.dir/gl.cpp.obj.requires:
.PHONY : Playground/NativeWindow/CMakeFiles/NativeWindow.dir/gl.cpp.obj.requires

Playground/NativeWindow/CMakeFiles/NativeWindow.dir/gl.cpp.obj.provides: Playground/NativeWindow/CMakeFiles/NativeWindow.dir/gl.cpp.obj.requires
	$(MAKE) -f Playground\NativeWindow\CMakeFiles\NativeWindow.dir\build.make Playground/NativeWindow/CMakeFiles/NativeWindow.dir/gl.cpp.obj.provides.build
.PHONY : Playground/NativeWindow/CMakeFiles/NativeWindow.dir/gl.cpp.obj.provides

Playground/NativeWindow/CMakeFiles/NativeWindow.dir/gl.cpp.obj.provides.build: Playground/NativeWindow/CMakeFiles/NativeWindow.dir/gl.cpp.obj

# Object files for target NativeWindow
NativeWindow_OBJECTS = \
"CMakeFiles/NativeWindow.dir/main.cpp.obj" \
"CMakeFiles/NativeWindow.dir/canvas.cpp.obj" \
"CMakeFiles/NativeWindow.dir/gl.cpp.obj"

# External object files for target NativeWindow
NativeWindow_EXTERNAL_OBJECTS =

Playground/NativeWindow/NativeWindow.exe: Playground/NativeWindow/CMakeFiles/NativeWindow.dir/main.cpp.obj
Playground/NativeWindow/NativeWindow.exe: Playground/NativeWindow/CMakeFiles/NativeWindow.dir/canvas.cpp.obj
Playground/NativeWindow/NativeWindow.exe: Playground/NativeWindow/CMakeFiles/NativeWindow.dir/gl.cpp.obj
Playground/NativeWindow/NativeWindow.exe: Playground/NativeWindow/CMakeFiles/NativeWindow.dir/build.make
Playground/NativeWindow/NativeWindow.exe: Playground/NativeWindow/CMakeFiles/NativeWindow.dir/objects1.rsp
Playground/NativeWindow/NativeWindow.exe: Playground/NativeWindow/CMakeFiles/NativeWindow.dir/link.txt
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --red --bold "Linking CXX executable NativeWindow.exe"
	cd /d C:\Dev\BabylonNative\cmake-build-MinGW\Playground\NativeWindow && $(CMAKE_COMMAND) -E cmake_link_script CMakeFiles\NativeWindow.dir\link.txt --verbose=$(VERBOSE)
	cd /d C:\Dev\BabylonNative\cmake-build-MinGW\Playground\NativeWindow && "C:\Program Files (x86)\CMake 2.8\bin\cmake.exe" -E copy_if_different C:/Dev/BabylonNative/Playground/Deps/MinGW/GLUT/lib/glut32.dll C:/Dev/BabylonNative/cmake-build-MinGW/Playground/NativeWindow/glut32.dll
	cd /d C:\Dev\BabylonNative\cmake-build-MinGW\Playground\NativeWindow && "C:\Program Files (x86)\CMake 2.8\bin\cmake.exe" -E copy_if_different C:/Dev/BabylonNative/Playground/Deps/MinGW/GLEW/lib/glew32.dll C:/Dev/BabylonNative/cmake-build-MinGW/Playground/NativeWindow/glew32.dll

# Rule to build all files generated by this target.
Playground/NativeWindow/CMakeFiles/NativeWindow.dir/build: Playground/NativeWindow/NativeWindow.exe
.PHONY : Playground/NativeWindow/CMakeFiles/NativeWindow.dir/build

Playground/NativeWindow/CMakeFiles/NativeWindow.dir/requires: Playground/NativeWindow/CMakeFiles/NativeWindow.dir/main.cpp.obj.requires
Playground/NativeWindow/CMakeFiles/NativeWindow.dir/requires: Playground/NativeWindow/CMakeFiles/NativeWindow.dir/canvas.cpp.obj.requires
Playground/NativeWindow/CMakeFiles/NativeWindow.dir/requires: Playground/NativeWindow/CMakeFiles/NativeWindow.dir/gl.cpp.obj.requires
.PHONY : Playground/NativeWindow/CMakeFiles/NativeWindow.dir/requires

Playground/NativeWindow/CMakeFiles/NativeWindow.dir/clean:
	cd /d C:\Dev\BabylonNative\cmake-build-MinGW\Playground\NativeWindow && $(CMAKE_COMMAND) -P CMakeFiles\NativeWindow.dir\cmake_clean.cmake
.PHONY : Playground/NativeWindow/CMakeFiles/NativeWindow.dir/clean

Playground/NativeWindow/CMakeFiles/NativeWindow.dir/depend:
	$(CMAKE_COMMAND) -E cmake_depends "MinGW Makefiles" C:\Dev\BabylonNative C:\Dev\BabylonNative\Playground\NativeWindow C:\Dev\BabylonNative\cmake-build-MinGW C:\Dev\BabylonNative\cmake-build-MinGW\Playground\NativeWindow C:\Dev\BabylonNative\cmake-build-MinGW\Playground\NativeWindow\CMakeFiles\NativeWindow.dir\DependInfo.cmake --color=$(COLOR)
.PHONY : Playground/NativeWindow/CMakeFiles/NativeWindow.dir/depend

