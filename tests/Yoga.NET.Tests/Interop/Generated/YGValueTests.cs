using System.Runtime.InteropServices;
using Xunit;

namespace Yoga.NET.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="YGValue" /> struct.</summary>
    public static unsafe partial class YGValueTests
    {
        /// <summary>Validates that the <see cref="YGValue" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(YGValue), Marshal.SizeOf<YGValue>());
        }

        /// <summary>Validates that the <see cref="YGValue" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(YGValue).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="YGValue" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(8, sizeof(YGValue));
        }
    }
}
