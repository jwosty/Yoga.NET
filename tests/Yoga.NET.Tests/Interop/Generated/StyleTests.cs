using System;
using System.Runtime.InteropServices;
using Xunit;

namespace Yoga.NET.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="Style" /> struct.</summary>
    public static unsafe partial class StyleTests
    {
        /// <summary>Validates that the <see cref="Style" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(Style), Marshal.SizeOf<Style>());
        }

        /// <summary>Validates that the <see cref="Style" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(Style).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="Style" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(144, sizeof(Style));
            }
            else
            {
                Assert.Equal(132, sizeof(Style));
            }
        }
    }
}
