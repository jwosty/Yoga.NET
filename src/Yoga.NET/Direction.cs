using JetBrains.Annotations;
using Yoga.NET.Interop;
// ReSharper disable InconsistentNaming

namespace Yoga.NET;

[PublicAPI]
public enum Direction : uint
{
    Inherit = YGDirection.YGDirectionInherit,
    LTR = YGDirection.YGDirectionLTR,
    RTL = YGDirection.YGDirectionRTL
}
