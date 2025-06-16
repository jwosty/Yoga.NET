using static Yoga.NET.Interop.YGLogLevel;

namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum LogLevel : byte
    {
        Error = YGLogLevelError,
        Warn = YGLogLevelWarn,
        Info = YGLogLevelInfo,
        Debug = YGLogLevelDebug,
        Verbose = YGLogLevelVerbose,
        Fatal = YGLogLevelFatal,
    }
}
