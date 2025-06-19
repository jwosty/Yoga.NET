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
    public const string WindowsAssemblyName = "libyoga.dll";
    public const string LinuxAssemblyName = "libyoga.so";
    // ReSharper disable once InconsistentNaming
    public const string MacOSAssemblyName = "libyoga.dylib";

    [ModuleInitializer]
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
            var asmDir = Path.GetDirectoryName(assembly.Location);
            if (asmDir is null)
            {
                return IntPtr.Zero;
            }
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
