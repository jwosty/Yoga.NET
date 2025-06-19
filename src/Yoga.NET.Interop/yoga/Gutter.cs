namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum Gutter : byte
    {
        Column = (byte)YogaGutter.Column,
        Row = (byte)YogaGutter.Row,
        All = (byte)YogaGutter.All,
    }
}
