namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum Overflow : byte
    {
        Visible = (byte)YogaOverflow.Visible,
        Hidden = (byte)YogaOverflow.Hidden,
        Scroll = (byte)YogaOverflow.Scroll,
    }
}
