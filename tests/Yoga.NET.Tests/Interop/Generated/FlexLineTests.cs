using System;
using System.Runtime.InteropServices;
using Xunit;

namespace Yoga.NET.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="FlexLine" /> struct.</summary>
    public static unsafe partial class FlexLineTests
    {
        /// <summary>Validates that the <see cref="FlexLine" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(FlexLine), Marshal.SizeOf<FlexLine>());
        }

        /// <summary>Validates that the <see cref="FlexLine" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(FlexLine).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="FlexLine" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(64, sizeof(FlexLine));
            }
            else
            {
                Assert.Equal(40, sizeof(FlexLine));
            }
        }
    }
}
