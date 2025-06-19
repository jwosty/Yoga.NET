namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum LogLevel : byte
    {
        Error = (byte)YogaLogLevel.Error,
        Warn = (byte)YogaLogLevel.Warn,
        Info = (byte)YogaLogLevel.Info,
        Debug = (byte)YogaLogLevel.Debug,
        Verbose = (byte)YogaLogLevel.Verbose,
        Fatal = (byte)YogaLogLevel.Fatal,
    }
}
