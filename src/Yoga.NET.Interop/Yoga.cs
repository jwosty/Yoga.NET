using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using JetBrains.Annotations;

namespace Yoga.NET.Interop;

[PublicAPI]
public static class Yoga
{
    private static bool _isInitialized = false;

    public const string PlaceholderAssemblyName = "libyoga";
    public const string WindowsAssemblyName = "yoga.dll";
    public const string LinuxAssemblyName = "libyoga.so";
    // ReSharper disable once InconsistentNaming
    public const string MacOSAssemblyName = "libyoga.dylib";

    /// <summary>
    /// Performs necessary native library initialization tasks. This should be called before any other library call.
    /// </summary>
    /// <remarks>
    /// The simplest way to ensure proper initialization is to add a method like this into your application:
    /// <code>
    /// [ModuleInitializer]
    /// public static void Initialize() => Yoga.NET.Interop.Yoga.Initialize();
    /// </code>
    /// </remarks>
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void Initialize()
    {
        if (!_isInitialized)
        {
            var asm = Assembly.GetExecutingAssembly();
            NativeLibrary.SetDllImportResolver(asm, DllResolver);
            _isInitialized = true;
        }
    }

    private static IntPtr DllResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
    {
        if (libraryName == PlaceholderAssemblyName)
        {
            // Use AppContext.BaseDirectory (which works under NativeAOT) instead of assembly.Location (which does not)
            var asmDir = AppContext.BaseDirectory;
            var rid = RuntimeInformation.RuntimeIdentifier;
            var osSpecificLibName = libraryName;
            if (OperatingSystem.IsWindows())
            {
                osSpecificLibName = WindowsAssemblyName;
            }
            else if (OperatingSystem.IsLinux())
            {
                osSpecificLibName = LinuxAssemblyName;
            }
            else if (OperatingSystem.IsMacOS())
            {
                osSpecificLibName = MacOSAssemblyName;
            }
            var filePath = Path.Combine(asmDir, "runtimes", rid, "native", osSpecificLibName);
            return NativeLibrary.Load(filePath);
        }
        else
        {
            return IntPtr.Zero;
        }
    }
}
