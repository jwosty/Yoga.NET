using static Yoga.NET.Interop.YGDisplay;

namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum Display : byte
    {
        Flex = (byte)YGDisplayFlex,
        None = (byte)YGDisplayNone,
        Contents = (byte)YGDisplayContents,
    }
}
