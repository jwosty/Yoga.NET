using System.Runtime.InteropServices;
using Xunit;

namespace Yoga.NET.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="YGNode" /> struct.</summary>
    public static unsafe partial class YGNodeTests
    {
        /// <summary>Validates that the <see cref="YGNode" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(YGNode), Marshal.SizeOf<YGNode>());
        }

        /// <summary>Validates that the <see cref="YGNode" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(YGNode).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="YGNode" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(YGNode));
        }
    }
}
