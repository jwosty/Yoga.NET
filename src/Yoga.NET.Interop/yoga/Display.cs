using static Yoga.NET.Interop.YGDisplay;

namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum Display : byte
    {
        Flex = YGDisplayFlex,
        None = YGDisplayNone,
        Contents = YGDisplayContents,
    }
}
