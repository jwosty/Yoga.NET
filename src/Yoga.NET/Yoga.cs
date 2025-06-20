using Yoga.NET.Interop;

namespace Yoga.NET;

public static class Yoga
{
    public static float RoundValueToPixelGrid(double value, double pointScaleFactor, bool forceCeil, bool forceFloor) =>
        yoga.YGRoundValueToPixelGrid(value, pointScaleFactor, (byte)(forceCeil ? 1 : 0), (byte)(forceFloor ? 1 : 0));
}
