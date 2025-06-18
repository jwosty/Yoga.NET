using System.Runtime.InteropServices;
using Xunit;

namespace Yoga.NET.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="FlexLineRunningLayout" /> struct.</summary>
    public static unsafe partial class FlexLineRunningLayoutTests
    {
        /// <summary>Validates that the <see cref="FlexLineRunningLayout" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(FlexLineRunningLayout), Marshal.SizeOf<FlexLineRunningLayout>());
        }

        /// <summary>Validates that the <see cref="FlexLineRunningLayout" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(FlexLineRunningLayout).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="FlexLineRunningLayout" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(20, sizeof(FlexLineRunningLayout));
        }
    }
}
