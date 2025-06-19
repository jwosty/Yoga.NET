using Yoga.NET.Interop;

namespace Yoga.NET.Tests;

public unsafe class Layer0
{
    [Fact]
    public void YGNodeConstructionFreeing()
    {
        var rootPtr = Methods.YGNodeNew();
        AssertExt.NotNull(rootPtr);
        Methods.YGNodeFree(rootPtr);
    }

    [Fact]
    public void YGNodeBasicCalcLayout()
    {
        var rootPtr = Methods.YGNodeNew();
        AssertExt.NotNull(rootPtr);
        Methods.YGNodeStyleSetWidth(rootPtr, 42);
        Methods.YGNodeStyleSetHeight(rootPtr, 84);
        Methods.YGNodeCalculateLayout(rootPtr, Methods.YGUndefined, Methods.YGUndefined, YGDirection.YGDirectionLTR);
        var width = Methods.YGNodeLayoutGetWidth(rootPtr);
        var height = Methods.YGNodeLayoutGetHeight(rootPtr);
        Assert.Equal(42, width);
        Assert.Equal(84, height);
        Methods.YGNodeFree(rootPtr);
    }

    [Fact]
    public void YGNodeCalcLayout()
    {
        var rootPtr = Methods.YGNodeNew();
        AssertExt.NotNull(rootPtr);
        Methods.YGNodeStyleSetFlexDirection(rootPtr, YGFlexDirection.YGFlexDirectionRow);
        Methods.YGNodeStyleSetWidth(rootPtr, 200);
        Methods.YGNodeStyleSetHeight(rootPtr, 100);

        var child0Ptr = Methods.YGNodeNew();
        AssertExt.NotNull(child0Ptr);
        Methods.YGNodeStyleSetFlexGrow(child0Ptr, 1);
        Methods.YGNodeStyleSetMargin(child0Ptr, YGEdge.YGEdgeRight, 10);
        Methods.YGNodeInsertChild(rootPtr, child0Ptr, 0);

        var child1Ptr = Methods.YGNodeNew();
        AssertExt.NotNull(child1Ptr);
        Methods.YGNodeStyleSetFlexGrow(child1Ptr, 1);
        Methods.YGNodeInsertChild(rootPtr, child1Ptr, 1);

        Methods.YGNodeCalculateLayout(rootPtr, Methods.YGUndefined, Methods.YGUndefined, YGDirection.YGDirectionLTR);

        var rootLeft = Methods.YGNodeLayoutGetLeft(rootPtr);
        var rootRight = Methods.YGNodeLayoutGetRight(rootPtr);
        var rootWidth = Methods.YGNodeLayoutGetWidth(rootPtr);
        var rootHeight = Methods.YGNodeLayoutGetHeight(rootPtr);
        Assert.Equal(0, rootLeft);
        Assert.Equal(0, rootRight);
        Assert.Equal(200, rootWidth);
        Assert.Equal(100, rootHeight);

        var child0Left = Methods.YGNodeLayoutGetLeft(child0Ptr);
        var child0Right = Methods.YGNodeLayoutGetRight(child0Ptr);
        var child0Width = Methods.YGNodeLayoutGetWidth(child0Ptr);
        var child0Height = Methods.YGNodeLayoutGetHeight(child0Ptr);
        Assert.Equal(0, child0Left);
        Assert.Equal(10, child0Right);
        Assert.Equal(95, child0Width);
        Assert.Equal(100, child0Height);

        var child1Left = Methods.YGNodeLayoutGetLeft(child1Ptr);
        var child1Right = Methods.YGNodeLayoutGetRight(child1Ptr);
        var child1Width = Methods.YGNodeLayoutGetWidth(child1Ptr);
        var child1Height = Methods.YGNodeLayoutGetHeight(child1Ptr);
        Assert.Equal(105, child1Left);
        Assert.Equal(0, child1Right);
        Assert.Equal(95, child1Width);
        Assert.Equal(100, child1Height);
    }
}
