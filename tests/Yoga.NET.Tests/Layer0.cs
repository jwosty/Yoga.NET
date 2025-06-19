using Yoga.NET.Interop;
// ReSharper disable InconsistentNaming

namespace Yoga.NET.Tests;

public unsafe class Layer0
{
    [Fact]
    public void YGNodeConstructionFreeing()
    {
        var rootPtr = yoga.YGNodeNew();
        AssertExt.NotNull(rootPtr);
        yoga.YGNodeFree(rootPtr);
    }

    [Fact]
    public void YGNodeBasicCalcLayout()
    {
        var rootPtr = yoga.YGNodeNew();
        AssertExt.NotNull(rootPtr);
        yoga.YGNodeStyleSetWidth(rootPtr, 42);
        yoga.YGNodeStyleSetHeight(rootPtr, 84);
        yoga.YGNodeCalculateLayout(rootPtr, yoga.YGUndefined, yoga.YGUndefined, YGDirection.YGDirectionLTR);
        var width = yoga.YGNodeLayoutGetWidth(rootPtr);
        var height = yoga.YGNodeLayoutGetHeight(rootPtr);
        Assert.Equal(42, width);
        Assert.Equal(84, height);
        yoga.YGNodeFree(rootPtr);
    }

    [Fact]
    public void YGNodeCalcLayout()
    {
        var rootPtr = yoga.YGNodeNew();
        AssertExt.NotNull(rootPtr);
        yoga.YGNodeStyleSetFlexDirection(rootPtr, YGFlexDirection.YGFlexDirectionRow);
        yoga.YGNodeStyleSetWidth(rootPtr, 200);
        yoga.YGNodeStyleSetHeight(rootPtr, 100);

        var child0Ptr = yoga.YGNodeNew();
        AssertExt.NotNull(child0Ptr);
        yoga.YGNodeStyleSetFlexGrow(child0Ptr, 1);
        yoga.YGNodeStyleSetMargin(child0Ptr, YGEdge.YGEdgeRight, 10);
        yoga.YGNodeInsertChild(rootPtr, child0Ptr, 0);

        var child1Ptr = yoga.YGNodeNew();
        AssertExt.NotNull(child1Ptr);
        yoga.YGNodeStyleSetFlexGrow(child1Ptr, 1);
        yoga.YGNodeInsertChild(rootPtr, child1Ptr, 1);

        yoga.YGNodeCalculateLayout(rootPtr, yoga.YGUndefined, yoga.YGUndefined, YGDirection.YGDirectionLTR);

        var rootLeft = yoga.YGNodeLayoutGetLeft(rootPtr);
        var rootRight = yoga.YGNodeLayoutGetRight(rootPtr);
        var rootWidth = yoga.YGNodeLayoutGetWidth(rootPtr);
        var rootHeight = yoga.YGNodeLayoutGetHeight(rootPtr);
        Assert.Equal(0, rootLeft);
        Assert.Equal(0, rootRight);
        Assert.Equal(200, rootWidth);
        Assert.Equal(100, rootHeight);

        var child0Left = yoga.YGNodeLayoutGetLeft(child0Ptr);
        var child0Right = yoga.YGNodeLayoutGetRight(child0Ptr);
        var child0Width = yoga.YGNodeLayoutGetWidth(child0Ptr);
        var child0Height = yoga.YGNodeLayoutGetHeight(child0Ptr);
        Assert.Equal(0, child0Left);
        Assert.Equal(10, child0Right);
        Assert.Equal(95, child0Width);
        Assert.Equal(100, child0Height);

        var child1Left = yoga.YGNodeLayoutGetLeft(child1Ptr);
        var child1Right = yoga.YGNodeLayoutGetRight(child1Ptr);
        var child1Width = yoga.YGNodeLayoutGetWidth(child1Ptr);
        var child1Height = yoga.YGNodeLayoutGetHeight(child1Ptr);
        Assert.Equal(105, child1Left);
        Assert.Equal(0, child1Right);
        Assert.Equal(95, child1Width);
        Assert.Equal(100, child1Height);
    }
}
