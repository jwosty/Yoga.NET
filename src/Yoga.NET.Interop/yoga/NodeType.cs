using static Yoga.NET.Interop.YGNodeType;

namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum NodeType : byte
    {
        Default = (byte)YGNodeTypeDefault,
        Text = (byte)YGNodeTypeText,
    }
}
