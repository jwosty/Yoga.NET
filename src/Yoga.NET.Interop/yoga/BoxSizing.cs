using static Yoga.NET.Interop.YGBoxSizing;

namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum BoxSizing : byte
    {
        BorderBox = (byte)YGBoxSizingBorderBox,
        ContentBox = (byte)YGBoxSizingContentBox,
    }
}
