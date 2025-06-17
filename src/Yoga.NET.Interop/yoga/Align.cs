using static Yoga.NET.Interop.YGAlign;

namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum Align : byte
    {
        Auto = (byte)YGAlignAuto,
        FlexStart = (byte)YGAlignFlexStart,
        Center = (byte)YGAlignCenter,
        FlexEnd = (byte)YGAlignFlexEnd,
        Stretch = (byte)YGAlignStretch,
        Baseline = (byte)YGAlignBaseline,
        SpaceBetween = (byte)YGAlignSpaceBetween,
        SpaceAround = (byte)YGAlignSpaceAround,
        SpaceEvenly = (byte)YGAlignSpaceEvenly,
    }
}
