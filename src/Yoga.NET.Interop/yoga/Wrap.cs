using static Yoga.NET.Interop.YGWrap;

namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum Wrap : byte
    {
        NoWrap = YGWrapNoWrap,
        Wrap = YGWrapWrap,
        WrapReverse = YGWrapWrapReverse,
    }
}
