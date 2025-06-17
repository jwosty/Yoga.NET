namespace Yoga.NET.Interop
{
    [NativeTypeName("unsigned int")]
    public enum YGLogLevel : uint
    {
        YGLogLevelError,
        YGLogLevelWarn,
        YGLogLevelInfo,
        YGLogLevelDebug,
        YGLogLevelVerbose,
        YGLogLevelFatal,
    }
}
