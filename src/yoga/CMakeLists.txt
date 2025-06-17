cmake_minimum_required(VERSION 3.13...3.26)
project(yoga-native)

set(CMAKE_CXX_STANDARD 20)

set(YOGA_ROOT ${CMAKE_CURRENT_SOURCE_DIR}/yoga)
include(${YOGA_ROOT}/cmake/project-defaults.cmake)

add_subdirectory(${YOGA_ROOT})

add_library(yoga SHARED library.cpp)
target_link_libraries(yoga PRIVATE "$<LINK_LIBRARY:WHOLE_ARCHIVE,yogacore>")
