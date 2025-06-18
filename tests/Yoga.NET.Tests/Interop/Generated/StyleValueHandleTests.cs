using System.Runtime.InteropServices;
using Xunit;

namespace Yoga.NET.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="StyleValueHandle" /> struct.</summary>
    public static unsafe partial class StyleValueHandleTests
    {
        /// <summary>Validates that the <see cref="StyleValueHandle" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(StyleValueHandle), Marshal.SizeOf<StyleValueHandle>());
        }

        /// <summary>Validates that the <see cref="StyleValueHandle" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(StyleValueHandle).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="StyleValueHandle" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(2, sizeof(StyleValueHandle));
        }
    }
}
