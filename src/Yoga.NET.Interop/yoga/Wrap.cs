namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum Wrap : byte
    {
        NoWrap = (byte)YogaWrap.NoWrap,
        Wrap = (byte)YogaWrap.Wrap,
        Reverse = (byte)YogaWrap.WrapReverse,
    }
}
