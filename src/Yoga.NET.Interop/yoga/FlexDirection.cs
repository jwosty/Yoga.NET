namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum FlexDirection : byte
    {
        Column = (byte)YogaFlexDirection.Column,
        ColumnReverse = (byte)YogaFlexDirection.ColumnReverse,
        Row = (byte)YogaFlexDirection.Row,
        RowReverse = (byte)YogaFlexDirection.RowReverse,
    }
}
