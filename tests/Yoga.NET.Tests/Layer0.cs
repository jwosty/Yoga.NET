using Yoga.NET.Interop;

namespace Yoga.NET.Tests;

public unsafe class Layer0
{
    [Fact]
    public void YGNodeConstructionFreeing()
    {
        var rootPtr = Methods.YGNodeNew();
        Assert.NotEqual(IntPtr.Zero, (IntPtr)rootPtr);
        Methods.YGNodeFree(rootPtr);
    }
}
