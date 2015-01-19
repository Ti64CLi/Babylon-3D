mkdir cmake-build-linux
cd cmake-build-linux
cmake -f .. -DWITH_SYSTEM_GLEW=ON -DWITH_SYSTEM_GLUT=ON -DWITH_NATIVE_APP=ON -DWITH_NATIVE_CLIENT=OFF
make