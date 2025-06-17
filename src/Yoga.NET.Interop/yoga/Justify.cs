using static Yoga.NET.Interop.YGJustify;

namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum Justify : byte
    {
        FlexStart = (byte)YGJustifyFlexStart,
        Center = (byte)YGJustifyCenter,
        FlexEnd = (byte)YGJustifyFlexEnd,
        SpaceBetween = (byte)YGJustifySpaceBetween,
        SpaceAround = (byte)YGJustifySpaceAround,
        SpaceEvenly = (byte)YGJustifySpaceEvenly,
    }
}
