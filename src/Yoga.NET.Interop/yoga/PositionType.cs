using static Yoga.NET.Interop.YGPositionType;

namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum PositionType : byte
    {
        Static = (byte)YGPositionTypeStatic,
        Relative = (byte)YGPositionTypeRelative,
        Absolute = (byte)YGPositionTypeAbsolute,
    }
}
