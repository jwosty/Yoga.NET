cmake_minimum_required(VERSION 3.13...3.26)
project(yoga-native)

set(CMAKE_CXX_STANDARD 20)

add_library(yoga-native SHARED library.cpp)
