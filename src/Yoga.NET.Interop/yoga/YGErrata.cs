namespace Yoga.NET.Interop
{
    [NativeTypeName("unsigned int")]
    public enum YGErrata : uint
    {
        YGErrataNone = 0,
        YGErrataStretchFlexBasis = 1,
        YGErrataAbsolutePositionWithoutInsetsExcludesPadding = 2,
        YGErrataAbsolutePercentAgainstInnerSize = 4,
        YGErrataAll = 2147483647,
        YGErrataClassic = 2147483646,
    }
}
