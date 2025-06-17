using static Yoga.NET.Interop.YGLogLevel;

namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum LogLevel : byte
    {
        Error = (byte)YGLogLevelError,
        Warn = (byte)YGLogLevelWarn,
        Info = (byte)YGLogLevelInfo,
        Debug = (byte)YGLogLevelDebug,
        Verbose = (byte)YGLogLevelVerbose,
        Fatal = (byte)YGLogLevelFatal,
    }
}
