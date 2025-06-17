using static Yoga.NET.Interop.YGDirection;

namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum Direction : byte
    {
        Inherit = (byte)YGDirectionInherit,
        LTR = (byte)YGDirectionLTR,
        RTL = (byte)YGDirectionRTL,
    }
}
