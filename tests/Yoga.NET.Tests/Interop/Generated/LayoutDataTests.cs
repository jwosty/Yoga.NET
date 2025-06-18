using System.Runtime.InteropServices;
using Xunit;

namespace Yoga.NET.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="LayoutData" /> struct.</summary>
    public static unsafe partial class LayoutDataTests
    {
        /// <summary>Validates that the <see cref="LayoutData" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(LayoutData), Marshal.SizeOf<LayoutData>());
        }

        /// <summary>Validates that the <see cref="LayoutData" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(LayoutData).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="LayoutData" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(56, sizeof(LayoutData));
        }
    }
}
