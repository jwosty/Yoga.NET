# Yoga.NET

C# / .NET bindings for Yoga, Facebook's embeddable flexbox layout engine.

## Building

To build the native library (after cloning the repository and the submodules):

On macOS:

```bash
# Optionally add `-G Ninja` to use the Ninja build system
cmake -DCMAKE_BUILD_TYPE=Release -S . -B build
cmake --build build
```

On Windows:

```powershell
cmake -DCMAKE_BUILD_TYPE=Release -S . -B build
cmake --build build --config Release
```

Then just build the C# project. For example, using the .NET CLI:

```bash
dotnet build
```

Alternatively, for the C# project, you can use your favorite .NET IDE.

## Running Tests

The test projects assume the native library is built and available in the `build` directory. To run the tests via the .NET CLI:

```bash
dotnet test
```

Alternatively, you can use your favorite .NET IDE.

## Using In Your Project

For now, you can reference the `Yoga.NET` project in your solution.
You must also ensure that the native library is built and available in the output directory of your project. The `Yoga.NET.Interop` project expects the native library to be in a specific location relative to the output directory. See the `Yoga.NET.Tests` project for an example of how to set this up.

In the future, this library will be available on NuGet (both the C# bindings and the native library).

## Project structure

* Yoga.NET: High-level C#-style abstraction layer. It is recommended to use this when possible.
* Yoga.NET.Interop: Low-level Yoga bindings closely matching the C API. You can resort to this when the high-level API is not sufficient.
* Yoga.NET.Tests: Test suite.

## Regenerating Bindings

This library uses ClangSharpPInvokeGenerator to generate the C# bindings from the Yoga C/C++ API headers (included as a submodule).

```bash
dotnet tool restore
cd src/Yoga.NET.Interop
./GenerateBindings.sh
```
