using static Yoga.NET.Interop.YGMeasureMode;

namespace Yoga.NET.Interop
{
    [NativeTypeName("uint8_t")]
    public enum MeasureMode : byte
    {
        Undefined = YGMeasureModeUndefined,
        Exactly = YGMeasureModeExactly,
        AtMost = YGMeasureModeAtMost,
    }
}
