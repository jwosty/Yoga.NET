namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum MeasureMode : byte
    {
        Undefined = (byte)YogaMeasureMode.Undefined,
        Exactly = (byte)YogaMeasureMode.Exactly,
        AtMost = (byte)YogaMeasureMode.AtMost,
    }
}
