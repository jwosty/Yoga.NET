using static Yoga.NET.Interop.YGAlign;

namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum Align : byte
    {
        Auto = YGAlignAuto,
        FlexStart = YGAlignFlexStart,
        Center = YGAlignCenter,
        FlexEnd = YGAlignFlexEnd,
        Stretch = YGAlignStretch,
        Baseline = YGAlignBaseline,
        SpaceBetween = YGAlignSpaceBetween,
        SpaceAround = YGAlignSpaceAround,
        SpaceEvenly = YGAlignSpaceEvenly,
    }
}
