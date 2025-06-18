using System.Runtime.InteropServices;
using Xunit;

namespace Yoga.NET.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="FloatOptional" /> struct.</summary>
    public static unsafe partial class FloatOptionalTests
    {
        /// <summary>Validates that the <see cref="FloatOptional" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(FloatOptional), Marshal.SizeOf<FloatOptional>());
        }

        /// <summary>Validates that the <see cref="FloatOptional" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(FloatOptional).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="FloatOptional" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(4, sizeof(FloatOptional));
        }
    }
}
