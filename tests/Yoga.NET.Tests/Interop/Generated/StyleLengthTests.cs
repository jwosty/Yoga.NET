using System.Runtime.InteropServices;
using Xunit;

namespace Yoga.NET.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="StyleLength" /> struct.</summary>
    public static unsafe partial class StyleLengthTests
    {
        /// <summary>Validates that the <see cref="StyleLength" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(StyleLength), Marshal.SizeOf<StyleLength>());
        }

        /// <summary>Validates that the <see cref="StyleLength" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(StyleLength).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="StyleLength" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(8, sizeof(StyleLength));
        }
    }
}
