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

    [Fact]
    public void YogaNodeCalcLayout()
    {
        var root = new YogaNode();
        root.FlexDirection = FlexDirection.Row;
        root.Width = 200;
        root.Height = 100;

        var child0 = new YogaNode();
        child0.FlexGrow = 1;
        child0.MarginRight = 10;

        root.InsertChild(0, child0);

        var child1 = new YogaNode();
        child1.FlexGrow = 1;
        root.InsertChild(1, child1);

        root.CalculateLayout(YogaConstants.Undefined, YogaConstants.Undefined, YGDirection.YGDirectionLTR);

        Assert.Equal(0, root.LayoutLeft);
        Assert.Equal(0, root.LayoutRight);
        Assert.Equal(200, root.LayoutWidth);
        Assert.Equal(100, root.LayoutHeight);

        Assert.Equal(0, child0.LayoutLeft);
        Assert.Equal(10, child0.LayoutRight);
        Assert.Equal(95, child0.LayoutWidth);
        Assert.Equal(100, child0.LayoutHeight);

        Assert.Equal(105, child1.LayoutLeft);
        Assert.Equal(0, child1.LayoutRight);
        Assert.Equal(95, child1.LayoutWidth);
        Assert.Equal(100, child1.LayoutHeight);
    }
}
