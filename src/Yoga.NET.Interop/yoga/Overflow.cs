using static Yoga.NET.Interop.YGOverflow;

namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum Overflow : byte
    {
        Visible = YGOverflowVisible,
        Hidden = YGOverflowHidden,
        Scroll = YGOverflowScroll,
    }
}
