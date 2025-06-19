namespace Yoga.NET.Tests;

public static unsafe class AssertExt
{
    public static void NotNull<T>(T* ptr) where T : unmanaged
    {
        Assert.NotEqual(IntPtr.Zero, (IntPtr)ptr);
    }

    public static void NotNull(IntPtr ptr)
    {
        Assert.NotEqual(IntPtr.Zero, ptr);
    }
}
