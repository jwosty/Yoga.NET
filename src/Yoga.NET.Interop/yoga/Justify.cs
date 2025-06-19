namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum Justify : byte
    {
        FlexStart = (byte)YogaJustify.FlexStart,
        Center = (byte)YogaJustify.Center,
        FlexEnd = (byte)YogaJustify.FlexEnd,
        SpaceBetween = (byte)YogaJustify.SpaceBetween,
        SpaceAround = (byte)YogaJustify.SpaceAround,
        SpaceEvenly = (byte)YogaJustify.SpaceEvenly,
    }
}
