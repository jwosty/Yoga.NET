using System;

namespace Yoga.NET.Interop
{
    public partial struct FlexLine
    {
        [NativeTypeName("const std::vector<yoga::Node *>")]
        public vector<IntPtr> itemsInFlow;

        [NativeTypeName("const float")]
        public float sizeConsumed;

        [NativeTypeName("const size_t")]
        public nuint numberOfAutoMargins;

        [NativeTypeName("facebook::yoga::FlexLineRunningLayout")]
        public FlexLineRunningLayout layout;
    }
}
