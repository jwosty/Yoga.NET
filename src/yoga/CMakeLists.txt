cmake_minimum_required(VERSION 3.13...3.26)
project(yoga-native)
set(CMAKE_VERBOSE_MAKEFILE on)

if(TARGET yoga-native)
    return()
endif()

include(CheckIPOSupported)

set(YOGA_NATIVE_DIR ${CMAKE_CURRENT_SOURCE_DIR}/yoga/yoga)
set(YOGA_ROOT ${CMAKE_CURRENT_SOURCE_DIR}/yoga)
include(${YOGA_ROOT}/cmake/project-defaults.cmake)


file(GLOB SOURCES CONFIGURE_DEPENDS
    ${YOGA_NATIVE_DIR}/*.cpp
    ${YOGA_NATIVE_DIR}/**/*.cpp)

add_library(yoga SHARED ${SOURCES})

# Yoga conditionally uses <android/log> when building for Android
if (ANDROID)
    target_link_libraries(yoga log)
endif()

check_ipo_supported(RESULT result)
if(result)
  set_target_properties(yoga PROPERTIES
    CMAKE_INTERPROCEDURAL_OPTIMIZATION true)
endif()

if (MSVC)
  SET(CMAKE_CXX_FLAGS  "${CMAKE_CXX_FLAGS} /wd4251")
endif()

target_include_directories(yoga
    PUBLIC
    $<BUILD_INTERFACE:${YOGA_ROOT}>
    $<INSTALL_INTERFACE:${CMAKE_INSTALL_PREFIX}/include/yoga>)
