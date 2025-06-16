using static Yoga.NET.Interop.YGErrata;

namespace Yoga.NET.Interop
{
    [NativeTypeName("uint32_t")]
    public enum Errata : uint
    {
        None = YGErrataNone,
        StretchFlexBasis = YGErrataStretchFlexBasis,
        AbsolutePositionWithoutInsetsExcludesPadding = YGErrataAbsolutePositionWithoutInsetsExcludesPadding,
        AbsolutePercentAgainstInnerSize = YGErrataAbsolutePercentAgainstInnerSize,
        All = YGErrataAll,
        Classic = YGErrataClassic,
    }
}
