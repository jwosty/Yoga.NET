using static Yoga.NET.Interop.YGGutter;

namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum Gutter : byte
    {
        Column = YGGutterColumn,
        Row = YGGutterRow,
        All = YGGutterAll,
    }
}
