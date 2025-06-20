using System;
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
        root.CalculateLayout(yoga.YGUndefined, yoga.YGUndefined, YogaDirection.LTR);
        Assert.Equal(42, root.LayoutWidth);
        Assert.Equal(84, root.LayoutHeight);
    }

    [Fact]
    public void YogaNodeCalcLayout()
    {
        var root = new YogaNode();
        root.FlexDirection = YogaFlexDirection.Row;
        root.Width = 200;
        root.Height = 100;

        var child0 = new YogaNode();
        child0.FlexGrow = 1;
        child0.MarginRight = 10;

        root.InsertChild(0, child0);

        var child1 = new YogaNode();
        child1.FlexGrow = 1;
        root.InsertChild(1, child1);

        root.CalculateLayout(YogaConstants.Undefined, YogaConstants.Undefined, YogaDirection.LTR);

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

    /// Ensures that sharing a config between various nodes doesn't free it
    [Fact]
    public void SharedConfigNonFreeing()
    {
        var config = new YogaConfig();

        config.PointScaleFactor = 42.0f;

        for (var i = 0; i < 10; i++)
        {
            using var node = new YogaNode(config);
        }

        // if the config object was freed, this should stomp all over its memory to really make sure our later check
        // catches a problem
        for (var i = 0; i < 100; i++)
        {
            using var node = new YogaNode();
        }

        GC.Collect();

        Assert.Equal(42.0f, config.PointScaleFactor);
    }

    [Fact]
    public unsafe void GlobalConfigNonFreeing()
    {
        var defaultConfig = YogaConfig.Default;
        var psf = defaultConfig.PointScaleFactor;
        Assert.NotEqual(0.0f, psf);

        for (int i = 0; i < 100; i++)
        {
            using var node = new YogaNode();
            Assert.Equal((nint)defaultConfig.Handle, (nint)node.Config.Handle);
        }

        GC.Collect();

        Assert.Equal(psf, defaultConfig.PointScaleFactor);
    }
}
