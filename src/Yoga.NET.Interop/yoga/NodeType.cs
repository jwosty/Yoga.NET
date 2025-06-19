namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum NodeType : byte
    {
        Default = (byte)YogaNodeType.Default,
        Text = (byte)YogaNodeType.Text,
    }
}
