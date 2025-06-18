using System.Runtime.InteropServices;
using Xunit;

namespace Yoga.NET.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="YGConfig" /> struct.</summary>
    public static unsafe partial class YGConfigTests
    {
        /// <summary>Validates that the <see cref="YGConfig" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(YGConfig), Marshal.SizeOf<YGConfig>());
        }

        /// <summary>Validates that the <see cref="YGConfig" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(YGConfig).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="YGConfig" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(YGConfig));
        }
    }
}
