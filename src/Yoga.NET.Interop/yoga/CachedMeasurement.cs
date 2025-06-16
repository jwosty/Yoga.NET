namespace Yoga.NET.Interop
{
    public partial struct CachedMeasurement
    {
        public float availableWidth;

        public float availableHeight;

        [NativeTypeName("facebook::yoga::SizingMode")]
        public SizingMode widthSizingMode;

        [NativeTypeName("facebook::yoga::SizingMode")]
        public SizingMode heightSizingMode;

        public float computedWidth;

        public float computedHeight;
    }
}
