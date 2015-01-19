mkdir cmake-build
cd cmake-build
cmake -f .. -DWITH_NATIVE_APP=ON
call vcvars32.bat
MSBuild ALL_BUILD.vcxproj 