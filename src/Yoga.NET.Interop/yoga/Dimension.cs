using static Yoga.NET.Interop.YGDimension;

namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum Dimension : byte
    {
        Width = (byte)YGDimensionWidth,
        Height = (byte)YGDimensionHeight,
    }
}
