namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum Direction : byte
    {
        Inherit = (byte)YogaDirection.Inherit,
        LTR = (byte)YogaDirection.LTR,
        RTL = (byte)YogaDirection.RTL,
    }
}
