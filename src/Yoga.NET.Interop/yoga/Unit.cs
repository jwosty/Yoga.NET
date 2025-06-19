namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum Unit : byte
    {
        Undefined = (byte)YogaUnit.Undefined,
        Point = (byte)YogaUnit.Point,
        Percent = (byte)YogaUnit.Percent,
        Auto = (byte)YogaUnit.Auto,
    }
}
