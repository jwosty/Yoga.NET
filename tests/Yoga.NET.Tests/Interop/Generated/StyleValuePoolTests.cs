using System;
using System.Runtime.InteropServices;
using Xunit;

namespace Yoga.NET.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="StyleValuePool" /> struct.</summary>
    public static unsafe partial class StyleValuePoolTests
    {
        /// <summary>Validates that the <see cref="StyleValuePool" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(StyleValuePool), Marshal.SizeOf<StyleValuePool>());
        }

        /// <summary>Validates that the <see cref="StyleValuePool" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(StyleValuePool).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="StyleValuePool" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(40, sizeof(StyleValuePool));
            }
            else
            {
                Assert.Equal(28, sizeof(StyleValuePool));
            }
        }
    }
}
