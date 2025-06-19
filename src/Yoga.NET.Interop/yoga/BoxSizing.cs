namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum BoxSizing : byte
    {
        BorderBox = (byte)YogaBoxSizing.BorderBox,
        ContentBox = (byte)YogaBoxSizing.ContentBox,
    }
}
