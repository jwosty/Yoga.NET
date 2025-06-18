#!/usr/bin/env bash

set -e
SCRIPT_DIR=$(dirname "$0")
echo "SCRIPT_DIR=${SCRIPT_DIR}"

OUTPUT_DIR="${SCRIPT_DIR}/yoga"

SDK_PATH=$(xcrun --show-sdk-path)
echo "SDK_PATH: ${SDK_PATH}"
LLVM_PATH="$HOMEBREW_PREFIX/Cellar/llvm/20.1.7"
ECHO "LLVM_PATH: ${LLVM_PATH}"

CLANGSHARPPINVOKEGENERATOR_TOOL_VERSDION="20.1.2.1"
LIBCLANG_RUNTIME_VERSION="20.1.2"
LIBCLANG_NAME="libclang.dylib"
LIBCLANGSHARP_RUNTIME_VERSION="20.1.2"
LIBCLANGSHARP_NAME="libClangSharp.dylib"
LIBCLANGSHARP_TARGET_NAME="libClangSharp.dylib"

# On unix this is often ~/.nuget/packages/
NUGET_PACKAGES_DIR=$(dotnet nuget locals global-packages -l | cut -d " " -f 2)

HEADERS_DIR="${SCRIPT_DIR}/../yoga/yoga/"

PACKAGE_ARCH=$(dotnet msbuild "${SCRIPT_DIR}/Yoga.NET.Interop.csproj" -getProperty:NETCoreSdkRuntimeIdentifier)

#LIBCLANG_LOCATION=$(ldconfig -p | grep "${LIBCLANG_NAME}" | tr ' ' '\n' | grep -m 1 /)
LIBCLANG_LOCATION="${NUGET_PACKAGES_DIR}/libclang.runtime.${PACKAGE_ARCH}/${LIBCLANG_RUNTIME_VERSION}/runtimes/${PACKAGE_ARCH}/native/${LIBCLANG_NAME}"
LIBCLANG_DIR=$(dirname "${LIBCLANG_LOCATION}")
LIBCLANG_LINK_TARGET="${NUGET_PACKAGES_DIR}/clangsharppinvokegenerator/${CLANGSHARPPINVOKEGENERATOR_TOOL_VERSDION}/tools/net8.0/any/${LIBCLANG_NAME}"

LIBCLANGSHARP_LOCATION="${NUGET_PACKAGES_DIR}/libclangsharp.runtime.${PACKAGE_ARCH}/${LIBCLANGSHARP_RUNTIME_VERSION}/runtimes/${PACKAGE_ARCH}/native/${LIBCLANGSHARP_NAME}"
LIBCLANGSHARP_DIR=$(dirname "${LIBCLANGSHARP_LOCATION}")
LIBCLANGSHARP_LINK_TARGET="${NUGET_PACKAGES_DIR}/clangsharppinvokegenerator/${CLANGSHARPPINVOKEGENERATOR_TOOL_VERSDION}/tools/net8.0/any/${LIBCLANGSHARP_TARGET_NAME}"

#export LD_LIBRARY_PATH="${LD_LIBRARY_PATH}:${LIBCLANG_DIR}:${LIBCLANGSHARP_DIR}"

if [ ! -f "${LIBCLANG_LINK_TARGET}" ]; then
  echo cp "${LIBCLANG_LOCATION}" "${LIBCLANG_LINK_TARGET}"
  cp "${LIBCLANG_LOCATION}" "${LIBCLANG_LINK_TARGET}"
fi

if [ ! -f "${LIBCLANGSHARP_LINK_TARGET}" ]; then
  echo cp "${LIBCLANGSHARP_LOCATION}" "${LIBCLANGSHARP_LINK_TARGET}"
  cp "${LIBCLANGSHARP_LOCATION}" "${LIBCLANGSHARP_LINK_TARGET}"
fi

rm -f "${OUTPUT_DIR}"/*.cs

#export LD_DEBUG=libs

set +e;

generate_bindings() {
  dotnet ClangSharpPInvokeGenerator \
    --language c++ \
    --std c++20 \
    --config latest-codegen unix-types generate-helper-types multi-file exclude-funcs-with-body generate-native-bitfield-attribute \
    --output "${OUTPUT_DIR}" \
    --namespace "Yoga.NET.Interop" \
    --additional "-isysroot" "${SDK_PATH}" \
    --additional "-stdlib=libc++" \
    --additional "-isystem" "${SDK_PATH}/usr/include/c++/v1" \
    --additional "-isystem" "${LLVM_PATH}/lib/clang/20/include/" \
    --additional "-isystem" "${SDK_PATH}/usr/include" \
    --include-directory "${HEADERS_DIR}" \
    --exclude "Node" \
    "$@";
}

echo "Generating bindings..."

generate_bindings \
  --file-directory "${HEADERS_DIR}" \
  --libraryPath "libyoga.dylib" \
  --file "yoga/YGConfig.h" \
  --file "yoga/YGEnums.h" \
  --file "yoga/YGMacros.h" \
  --file "yoga/YGNode.h" \
  --file "yoga/YGNodeLayout.h" \
  --file "yoga/YGNodeStyle.h" \
  --file "yoga/YGPixelGrid.h" \
  --file "yoga/YGValue.h" \
  --file "yoga/Yoga.h" \
  --file "yoga/algorithm/AbsoluteLayout.h" \
  --file "yoga/algorithm/Align.h" \
  --file "yoga/algorithm/Baseline.h" \
  --file "yoga/algorithm/BoundAxis.h" \
  --file "yoga/algorithm/Cache.h" \
  --file "yoga/algorithm/CalculateLayout.h" \
  --file "yoga/algorithm/FlexDirection.h" \
  --file "yoga/algorithm/FlexLine.h" \
  --file "yoga/algorithm/PixelGrid.h" \
  --file "yoga/algorithm/SizingMode.h" \
  --file "yoga/algorithm/TrailingPosition.h" \
  --file "yoga/config/Config.h" \
  --file "yoga/debug/AssertFatal.h" \
  --file "yoga/debug/Log.h" \
  --file "yoga/enums/Align.h" \
  --file "yoga/enums/BoxSizing.h" \
  --file "yoga/enums/Dimension.h" \
  --file "yoga/enums/Direction.h" \
  --file "yoga/enums/Display.h" \
  --file "yoga/enums/Edge.h" \
  --file "yoga/enums/Errata.h" \
  --file "yoga/enums/ExperimentalFeature.h" \
  --file "yoga/enums/FlexDirection.h" \
  --file "yoga/enums/Gutter.h" \
  --file "yoga/enums/Justify.h" \
  --file "yoga/enums/LogLevel.h" \
  --file "yoga/enums/MeasureMode.h" \
  --file "yoga/enums/NodeType.h" \
  --file "yoga/enums/Overflow.h" \
  --file "yoga/enums/PhysicalEdge.h" \
  --file "yoga/enums/PositionType.h" \
  --file "yoga/enums/Unit.h" \
  --file "yoga/enums/Wrap.h" \
  --file "yoga/enums/YogaEnums.h" \
  --file "yoga/event/event.h" \
  --file "yoga/node/CachedMeasurement.h" \
  --file "yoga/node/LayoutResults.h" \
  --file "yoga/node/LayoutableChildren.h" \
  --file "yoga/node/Node.h" \
  --file "yoga/numeric/Comparison.h" \
  --file "yoga/numeric/FloatOptional.h" \
  --file "yoga/style/SmallValueBuffer.h" \
  --file "yoga/style/Style.h" \
  --file "yoga/style/StyleLength.h" \
  --file "yoga/style/StyleValueHandle.h" \
  --file "yoga/style/StyleValuePool.h"

set -e

dotnet fsi "${SCRIPT_DIR}/FixupBindings.fsx" "${SCRIPT_DIR}/yoga/"
