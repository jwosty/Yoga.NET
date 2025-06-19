namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum Edge : byte
    {
        Left = (byte)YogaEdge.Left,
        Top = (byte)YogaEdge.Top,
        Right = (byte)YogaEdge.Right,
        Bottom = (byte)YogaEdge.Bottom,
        Start = (byte)YogaEdge.Start,
        End = (byte)YogaEdge.End,
        Horizontal = (byte)YogaEdge.Horizontal,
        Vertical = (byte)YogaEdge.Vertical,
        All = (byte)YogaEdge.All,
    }
}
