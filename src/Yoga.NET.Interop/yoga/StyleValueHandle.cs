using System.Runtime.InteropServices;

namespace Yoga.NET.Interop
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct StyleValueHandle
    {
        [NativeTypeName("uint16_t")]
        private ushort repr_;

        [NativeTypeName("const uint16_t")]
        private const ushort kHandleTypeMask = 0b0000000000000111;

        [NativeTypeName("const uint16_t")]
        private const ushort kHandleIndexedMask = 0b0000000000001000;

        [NativeTypeName("const uint16_t")]
        private const ushort kHandleValueMask = 0b1111111111110000;

        [NativeTypeName("uint8_t")]
        private enum Type : byte
        {
            Undefined,
            Point,
            Percent,
            Number,
            Auto,
        }
    }
}
