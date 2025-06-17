using static Yoga.NET.Interop.YGEdge;

namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum Edge : byte
    {
        Left = (byte)YGEdgeLeft,
        Top = (byte)YGEdgeTop,
        Right = (byte)YGEdgeRight,
        Bottom = (byte)YGEdgeBottom,
        Start = (byte)YGEdgeStart,
        End = (byte)YGEdgeEnd,
        Horizontal = (byte)YGEdgeHorizontal,
        Vertical = (byte)YGEdgeVertical,
        All = (byte)YGEdgeAll,
    }
}
