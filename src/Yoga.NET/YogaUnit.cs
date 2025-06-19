using JetBrains.Annotations;
using Yoga.NET.Interop;

namespace Yoga.NET;

[PublicAPI]
public enum YogaUnit : uint
{
    Undefined = YGUnit.YGUnitUndefined,
    Point = YGUnit.YGUnitPoint,
    Percent = YGUnit.YGUnitPercent,
    Auto = YGUnit.YGUnitAuto,
}
