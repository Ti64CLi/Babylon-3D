mkdir cmake-build-linux
cd cmake-build-linux
cmake -f .. -DWITH_SYSTEM_GLEW=ON -DWITH_SYSTEM_GLUT=ON
make