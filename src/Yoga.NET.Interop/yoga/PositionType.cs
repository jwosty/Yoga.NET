namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum PositionType : byte
    {
        Static = (byte)YogaPositionType.Static,
        Relative = (byte)YogaPositionType.Relative,
        Absolute = (byte)YogaPositionType.Absolute,
    }
}
