namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum Display : byte
    {
        Flex = (byte)YogaDisplay.Flex,
        None = (byte)YogaDisplay.None,
        Contents = (byte)YogaDisplay.Contents,
    }
}
