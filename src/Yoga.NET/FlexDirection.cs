using JetBrains.Annotations;
using Yoga.NET.Interop;

namespace Yoga.NET;

[PublicAPI]
public enum FlexDirection : uint
{
    Column = YGFlexDirection.YGFlexDirectionColumn,
    ColumnReverse = YGFlexDirection.YGFlexDirectionColumnReverse,
    Row = YGFlexDirection.YGFlexDirectionRow,
    Reverse = YGFlexDirection.YGFlexDirectionRowReverse,
}
