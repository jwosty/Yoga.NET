using System.Runtime.InteropServices;
using Xunit;

namespace Yoga.NET.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="CachedMeasurement" /> struct.</summary>
    public static unsafe partial class CachedMeasurementTests
    {
        /// <summary>Validates that the <see cref="CachedMeasurement" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(CachedMeasurement), Marshal.SizeOf<CachedMeasurement>());
        }

        /// <summary>Validates that the <see cref="CachedMeasurement" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(CachedMeasurement).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="CachedMeasurement" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(24, sizeof(CachedMeasurement));
        }
    }
}
