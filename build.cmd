mkdir cmake-build
cd cmake-build
cmake -f ..\
call vcvars32.bat
MSBuild ALL_BUILD.vcxproj 