using static Yoga.NET.Interop.YGUnit;

namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum Unit : byte
    {
        Undefined = YGUnitUndefined,
        Point = YGUnitPoint,
        Percent = YGUnitPercent,
        Auto = YGUnitAuto,
    }
}
