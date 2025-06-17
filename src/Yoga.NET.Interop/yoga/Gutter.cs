using static Yoga.NET.Interop.YGGutter;

namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum Gutter : byte
    {
        Column = (byte)YGGutterColumn,
        Row = (byte)YGGutterRow,
        All = (byte)YGGutterAll,
    }
}
