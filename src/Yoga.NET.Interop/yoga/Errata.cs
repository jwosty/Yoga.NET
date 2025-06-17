using static Yoga.NET.Interop.YGErrata;

namespace Yoga.NET.Interop
{
    [NativeTypeName("uint32_t")]
    public enum Errata : uint
    {
        None = (uint)YGErrataNone,
        StretchFlexBasis = (uint)YGErrataStretchFlexBasis,
        AbsolutePositionWithoutInsetsExcludesPadding = (uint)YGErrataAbsolutePositionWithoutInsetsExcludesPadding,
        AbsolutePercentAgainstInnerSize = (uint)YGErrataAbsolutePercentAgainstInnerSize,
        All = (uint)YGErrataAll,
        Classic = (uint)YGErrataClassic,
    }
}
