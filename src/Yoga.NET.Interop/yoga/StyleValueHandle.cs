using System.Runtime.InteropServices;

namespace Yoga.NET.Interop
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct StyleValueHandle
    {
        [NativeTypeName("uint16_t")]
        private ushort repr_;

        [NativeTypeName("const uint16_t")]
        private const ushort kHandleTypeMask = 0b0000'0000'0000'0111;

        [NativeTypeName("const uint16_t")]
        private const ushort kHandleIndexedMask = 0b0000'0000'0000'1000;

        [NativeTypeName("const uint16_t")]
        private const ushort kHandleValueMask = 0b1111'1111'1111'0000;

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
