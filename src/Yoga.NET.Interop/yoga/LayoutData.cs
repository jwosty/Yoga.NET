namespace Yoga.NET.Interop
{
    public partial struct LayoutData
    {
        public int layouts;

        public int measures;

        [NativeTypeName("uint32_t")]
        public uint maxMeasureCache;

        public int cachedLayouts;

        public int cachedMeasures;

        public int measureCallbacks;

        [NativeTypeName("array<int, static_cast<uint8_t>(LayoutPassReason::COUNT)>")]
        public InlineArray8<byte> measureCallbackReasonsCount;
    }
}
