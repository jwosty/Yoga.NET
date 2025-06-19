namespace Yoga.NET.Interop
{
    [NativeTypeName("uint32_t")]
    public enum Errata : uint
    {
        None = (uint)YogaErrata.None,
        StretchFlexBasis = (uint)YogaErrata.StretchFlexBasis,
        AbsolutePositionWithoutInsetsExcludesPadding = (uint)YogaErrata.AbsolutePositionWithoutInsetsExcludesPadding,
        AbsolutePercentAgainstInnerSize = (uint)YogaErrata.AbsolutePercentAgainstInnerSize,
        All = (uint)YogaErrata.All,
        Classic = (uint)YogaErrata.Classic,
    }
}
