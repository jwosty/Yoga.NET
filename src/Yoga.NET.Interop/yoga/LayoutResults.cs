using System.Runtime.InteropServices;

namespace Yoga.NET.Interop
{
    public partial struct LayoutResults
    {
        [NativeTypeName("uint32_t")]
        public uint computedFlexBasisGeneration;

        [NativeTypeName("facebook::yoga::FloatOptional")]
        public FloatOptional computedFlexBasis;

        [NativeTypeName("uint32_t")]
        public uint generationCount;

        [NativeTypeName("uint32_t")]
        public uint configVersion;

        [NativeTypeName("facebook::yoga::Direction")]
        public Direction lastOwnerDirection;

        [NativeTypeName("uint32_t")]
        public uint nextCachedMeasurementsIndex;

        [NativeTypeName("std::array<CachedMeasurement, MaxCachedMeasurements>")]
        public array<CachedMeasurement, MaxCachedMeasurements> cachedMeasurements;

        [NativeTypeName("facebook::yoga::CachedMeasurement")]
        public CachedMeasurement cachedLayout;

        public byte _bitfield;

        [NativeTypeName("facebook::yoga::Direction : 2")]
        private Direction direction_
        {
            readonly get
            {
                return (Direction)(_bitfield & 0x3u);
            }

            set
            {
                _bitfield = (byte)((_bitfield & ~0x3u) | ((byte)(value) & 0x3u));
            }
        }

        [NativeTypeName("bool : 1")]
        private bool hadOverflow_
        {
            readonly get
            {
                return (bool)((_bitfield >> 2) & 0x1u);
            }

            set
            {
                _bitfield = (byte)((_bitfield & ~(0x1u << 2)) | (byte)((value & 0x1) << 2));
            }
        }

        [NativeTypeName("std::array<float, 2>")]
        InlineArray2<float> dimensions_;

        [NativeTypeName("std::array<float, 2>")]
        InlineArray2<float> measuredDimensions_;

        [NativeTypeName("std::array<float, 4>")]
        InlineArray4<float> position_;

        [NativeTypeName("std::array<float, 4>")]
        InlineArray4<float> margin_;

        [NativeTypeName("std::array<float, 4>")]
        InlineArray4<float> border_;

        [NativeTypeName("std::array<float, 4>")]
        InlineArray4<float> padding_;

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZNK8facebook4yoga13LayoutResultseqES1_", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte Equals(LayoutResults* pThis, [NativeTypeName("facebook::yoga::LayoutResults")] LayoutResults layout);

        [NativeTypeName("const int32_t")]
        public const int MaxCachedMeasurements = 8;
    }
}
