namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum Align : byte
    {
        Auto = (byte)YogaAlign.Auto,
        FlexStart = (byte)YogaAlign.FlexStart,
        Center = (byte)YogaAlign.Center,
        FlexEnd = (byte)YogaAlign.FlexEnd,
        Stretch = (byte)YogaAlign.Stretch,
        Baseline = (byte)YogaAlign.Baseline,
        SpaceBetween = (byte)YogaAlign.SpaceBetween,
        SpaceAround = (byte)YogaAlign.SpaceAround,
        SpaceEvenly = (byte)YogaAlign.SpaceEvenly,
    }
}
