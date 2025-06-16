using static Yoga.NET.Interop.YGPositionType;

namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum PositionType : byte
    {
        Static = YGPositionTypeStatic,
        Relative = YGPositionTypeRelative,
        Absolute = YGPositionTypeAbsolute,
    }
}
