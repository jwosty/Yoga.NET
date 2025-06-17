using static Yoga.NET.Interop.YGUnit;

namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum Unit : byte
    {
        Undefined = (byte)YGUnitUndefined,
        Point = (byte)YGUnitPoint,
        Percent = (byte)YGUnitPercent,
        Auto = (byte)YGUnitAuto,
    }
}
