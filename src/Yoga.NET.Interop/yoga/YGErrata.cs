namespace Yoga.NET.Interop
{
    [NativeTypeName("unsigned int")]
    public enum YogaErrata : uint
    {
        None = 0,
        StretchFlexBasis = 1,
        AbsolutePositionWithoutInsetsExcludesPadding = 2,
        AbsolutePercentAgainstInnerSize = 4,
        All = 2147483647,
        Classic = 2147483646,
    }
}
