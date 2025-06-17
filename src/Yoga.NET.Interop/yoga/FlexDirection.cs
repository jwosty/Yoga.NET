using static Yoga.NET.Interop.YGFlexDirection;

namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum FlexDirection : byte
    {
        Column = (byte)YGFlexDirectionColumn,
        ColumnReverse = (byte)YGFlexDirectionColumnReverse,
        Row = (byte)YGFlexDirectionRow,
        RowReverse = (byte)YGFlexDirectionRowReverse,
    }
}
