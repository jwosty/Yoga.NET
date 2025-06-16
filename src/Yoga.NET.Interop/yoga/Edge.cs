using static Yoga.NET.Interop.YGEdge;

namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum Edge : byte
    {
        Left = YGEdgeLeft,
        Top = YGEdgeTop,
        Right = YGEdgeRight,
        Bottom = YGEdgeBottom,
        Start = YGEdgeStart,
        End = YGEdgeEnd,
        Horizontal = YGEdgeHorizontal,
        Vertical = YGEdgeVertical,
        All = YGEdgeAll,
    }
}
