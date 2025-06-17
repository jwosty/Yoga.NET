using System;
using System.Runtime.InteropServices;

namespace Yoga.NET.Interop
{
    public unsafe partial struct Event
    {
        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__ZN8facebook4yoga5Event5resetEv", ExactSpelling = true)]
        public static extern void reset();

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__ZN8facebook4yoga5Event9subscribeEONSt3__18functionIFvPK6YGNodeNS1_4TypeENS1_4DataEEEE", ExactSpelling = true)]
        public static extern void subscribe([NativeTypeName("function<Subscriber> &")] function<IntPtr>* subscriber);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__ZN8facebook4yoga5Event7publishEPK6YGNodeNS1_4TypeERKNS1_4DataE", ExactSpelling = true)]
        private static extern void publish([NativeTypeName("YGNodeConstRef")] YGNode* param0, [NativeTypeName("facebook::yoga::Event::Type")] Type param1, [NativeTypeName("const Data &")] Data* param2);

        [NativeTypeName("unsigned int")]
        public enum Type : uint
        {
            NodeAllocation,
            NodeDeallocation,
            NodeLayout,
            LayoutPassStart,
            LayoutPassEnd,
            MeasureCallbackStart,
            MeasureCallbackEnd,
            NodeBaselineStart,
            NodeBaselineEnd,
        }

        public unsafe partial struct Data
        {
            [NativeTypeName("const void *")]
            private void* data_;
        }
    }
}
