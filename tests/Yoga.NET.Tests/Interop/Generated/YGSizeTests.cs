using System.Runtime.InteropServices;
using Xunit;

namespace Yoga.NET.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="YGSize" /> struct.</summary>
    public static unsafe partial class YGSizeTests
    {
        /// <summary>Validates that the <see cref="YGSize" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(YGSize), Marshal.SizeOf<YGSize>());
        }

        /// <summary>Validates that the <see cref="YGSize" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(YGSize).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="YGSize" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(8, sizeof(YGSize));
        }
    }
}
