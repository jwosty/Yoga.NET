using static Yoga.NET.Interop.YGJustify;

namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum Justify : byte
    {
        FlexStart = YGJustifyFlexStart,
        Center = YGJustifyCenter,
        FlexEnd = YGJustifyFlexEnd,
        SpaceBetween = YGJustifySpaceBetween,
        SpaceAround = YGJustifySpaceAround,
        SpaceEvenly = YGJustifySpaceEvenly,
    }
}
