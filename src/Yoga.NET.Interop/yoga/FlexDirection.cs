using static Yoga.NET.Interop.YGFlexDirection;

namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum FlexDirection : byte
    {
        Column = YGFlexDirectionColumn,
        ColumnReverse = YGFlexDirectionColumnReverse,
        Row = YGFlexDirectionRow,
        RowReverse = YGFlexDirectionRowReverse,
    }
}
