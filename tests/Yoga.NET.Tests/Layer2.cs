using Yoga.NET.Interop;

namespace Yoga.NET.Tests;

public class Layer2
{
    [Fact]
    public void YogaNodeNewFree()
    {
        using var node = new YogaNode();
        Assert.NotNull(node);
    }

    [Fact]
    public void YGNodeBasicCalcLayout()
    {
        using var root = new YogaNode();
        root.Width = 42;
        root.Height = 84;
        root.CalculateLayout(yoga.YGUndefined, yoga.YGUndefined, YGDirection.YGDirectionLTR);
        Assert.Equal(42, root.LayoutWidth);
        Assert.Equal(84, root.LayoutHeight);
    }
}
