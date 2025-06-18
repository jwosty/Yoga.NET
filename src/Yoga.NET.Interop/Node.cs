using System;
using System.Runtime.InteropServices;

namespace Yoga.NET.Interop
{

    [NativeTypeName("struct Node : YGNode")]
    public unsafe partial struct Node
    {
        [NativeBitfield("hasNewLayout_", offset: 0, length: 1)]
        [NativeBitfield("isReferenceBaseline_", offset: 1, length: 1)]
        [NativeBitfield("isDirty_", offset: 2, length: 1)]
        [NativeBitfield("alwaysFormsContainingBlock_", offset: 3, length: 1)]
        [NativeBitfield("nodeType_", offset: 4, length: 1)]
        public byte _bitfield;

        [NativeTypeName("bool : 1")]
        private bool hasNewLayout_
        {
            readonly get
            {
                // return (bool)(_bitfield & 0x1);
                return (_bitfield & 0x1) != 0;
            }

            set
            {
                // _bitfield = (bool)((_bitfield & ~0x1) | (value & 0x1));
                _bitfield = (byte)((this._bitfield & ~0x1) | (value ? 1 : 0));
            }
        }

        [NativeTypeName("bool : 1")]
        private bool isReferenceBaseline_
        {
            readonly get
            {
                // return (bool)((_bitfield >> 1) & 0x1);
                return ((_bitfield >> 1) & 0x1) != 0;
            }

            set
            {
                // _bitfield = (bool)((_bitfield & ~(0x1 << 1)) | ((value & 0x1) << 1));
                _bitfield = (byte)((_bitfield & ~(0x1 << 1)) | ((value ? 1 : 0) << 1));
            }
        }

        [NativeTypeName("bool : 1")]
        private bool isDirty_
        {
            readonly get
            {
                // return (bool)((_bitfield >> 2) & 0x1);
                return ((_bitfield >> 2) & 0x1) != 0;
            }

            set
            {
                // _bitfield = (bool)((_bitfield & ~(0x1 << 2)) | ((value & 0x1) << 2));
                _bitfield = (byte)((_bitfield & ~(0x1 << 2)) | ((value ? 1 : 0) << 2));
            }
        }

        [NativeTypeName("bool : 1")]
        private bool alwaysFormsContainingBlock_
        {
            readonly get
            {
                // return (bool)((_bitfield >> 3) & 0x1);
                return ((_bitfield >> 3) & 0x1) != 0;
            }

            set
            {
                // _bitfield = (bool)((_bitfield & ~(0x1 << 3)) | ((value & 0x1) << 3));
                _bitfield = (byte)((_bitfield & ~(0x1 << 3)) | ((value ? 1 : 0) << 3));
            }
        }

        [NativeTypeName("facebook::yoga::NodeType : 1")]
        private NodeType nodeType_
        {
            readonly get
            {
                return (NodeType)((_bitfield >> 4) & 0x1);
            }

            set
            {
                // _bitfield = (bool)((_bitfield & ~(0x1 << 4)) | (((bool)(value) & 0x1u) << 4));
                _bitfield = (byte)((_bitfield & ~(0x1 << 4)) | ((value != NodeType.Default ? 1 : 0) << 4));
            }
        }

        private void* context_;

        [NativeTypeName("YGMeasureFunc")]
        private delegate* unmanaged[Cdecl]<YGNode*, float, YGMeasureMode, float, YGMeasureMode, YGSize> measureFunc_;

        [NativeTypeName("YGBaselineFunc")]
        private delegate* unmanaged[Cdecl]<YGNode*, float, float, float> baselineFunc_;

        [NativeTypeName("YGDirtiedFunc")]
        private delegate* unmanaged[Cdecl]<YGNode*, void> dirtiedFunc_;

        [NativeTypeName("facebook::yoga::Style")]
        private Style style_;

        [NativeTypeName("facebook::yoga::LayoutResults")]
        private LayoutResults layout_;

        [NativeTypeName("size_t")]
        private nuint lineIndex_;

        [NativeTypeName("size_t")]
        private nuint contentsChildrenCount_;

        [NativeTypeName("facebook::yoga::Node *")]
        private Node* owner_;

        [NativeTypeName("vector<Node *>")]
        private vector<IntPtr> children_;

        [NativeTypeName("const Config *")]
        private Config* config_;

        [NativeTypeName("array<Style::Length, 2>")]
        InlineArray2<StyleLength> processedDimensions_;

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4NodeC1Ev", ExactSpelling = true)]
        public static extern Node(Node* pThis);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4NodeC1EPKNS0_6ConfigE", ExactSpelling = true)]
        public static extern Node(Node* pThis, [NativeTypeName("const Config *")] Config* config);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4NodeC1EOS1_", ExactSpelling = true)]
        public static extern Node(Node* pThis, [NativeTypeName("facebook::yoga::Node &")] Node* node);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4Node7measureEfNS0_11MeasureModeEfS2_", ExactSpelling = true)]
        public static extern YGSize measure(Node* pThis, float availableWidth, [NativeTypeName("facebook::yoga::MeasureMode")] MeasureMode widthMode, float availableHeight, [NativeTypeName("facebook::yoga::MeasureMode")] MeasureMode heightMode);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZNK8facebook4yoga4Node8baselineEff", ExactSpelling = true)]
        public static extern float baseline(Node* pThis, float width, float height);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4Node19dimensionWithMarginENS0_13FlexDirectionEf", ExactSpelling = true)]
        public static extern float dimensionWithMargin(Node* pThis, [NativeTypeName("facebook::yoga::FlexDirection")] FlexDirection axis, float widthSize);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4Node24isLayoutDimensionDefinedENS0_13FlexDirectionE", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte isLayoutDimensionDefined(Node* pThis, [NativeTypeName("facebook::yoga::FlexDirection")] FlexDirection axis);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4Node14setMeasureFuncEPF6YGSizePK6YGNodef13YGMeasureModefS6_E", ExactSpelling = true)]
        public static extern void setMeasureFunc(Node* pThis, [NativeTypeName("YGMeasureFunc")] delegate* unmanaged[Cdecl]<YGNode*, float, YGMeasureMode, float, YGMeasureMode, YGSize> measureFunc);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4Node9setConfigEPNS0_6ConfigE", ExactSpelling = true)]
        public static extern void setConfig(Node* pThis, [NativeTypeName("facebook::yoga::Config *")] Config* config);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4Node8setDirtyEb", ExactSpelling = true)]
        public static extern void setDirty(Node* pThis, [NativeTypeName("bool")] byte isDirty);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4Node27setLayoutLastOwnerDirectionENS0_9DirectionE", ExactSpelling = true)]
        public static extern void setLayoutLastOwnerDirection(Node* pThis, [NativeTypeName("facebook::yoga::Direction")] Direction direction);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4Node26setLayoutComputedFlexBasisENS0_13FloatOptionalE", ExactSpelling = true)]
        public static extern void setLayoutComputedFlexBasis(Node* pThis, [NativeTypeName("facebook::yoga::FloatOptional")] FloatOptional computedFlexBasis);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4Node36setLayoutComputedFlexBasisGenerationEj", ExactSpelling = true)]
        public static extern void setLayoutComputedFlexBasisGeneration(Node* pThis, [NativeTypeName("uint32_t")] uint computedFlexBasisGeneration);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4Node26setLayoutMeasuredDimensionEfNS0_9DimensionE", ExactSpelling = true)]
        public static extern void setLayoutMeasuredDimension(Node* pThis, float measuredDimension, [NativeTypeName("facebook::yoga::Dimension")] Dimension dimension);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4Node20setLayoutHadOverflowEb", ExactSpelling = true)]
        public static extern void setLayoutHadOverflow(Node* pThis, [NativeTypeName("bool")] byte hadOverflow);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4Node18setLayoutDimensionEfNS0_9DimensionE", ExactSpelling = true)]
        public static extern void setLayoutDimension(Node* pThis, float LengthValue, [NativeTypeName("facebook::yoga::Dimension")] Dimension dimension);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4Node18setLayoutDirectionENS0_9DirectionE", ExactSpelling = true)]
        public static extern void setLayoutDirection(Node* pThis, [NativeTypeName("facebook::yoga::Direction")] Direction direction);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4Node15setLayoutMarginEfNS0_12PhysicalEdgeE", ExactSpelling = true)]
        public static extern void setLayoutMargin(Node* pThis, float margin, [NativeTypeName("facebook::yoga::PhysicalEdge")] PhysicalEdge edge);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4Node15setLayoutBorderEfNS0_12PhysicalEdgeE", ExactSpelling = true)]
        public static extern void setLayoutBorder(Node* pThis, float border, [NativeTypeName("facebook::yoga::PhysicalEdge")] PhysicalEdge edge);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4Node16setLayoutPaddingEfNS0_12PhysicalEdgeE", ExactSpelling = true)]
        public static extern void setLayoutPadding(Node* pThis, float padding, [NativeTypeName("facebook::yoga::PhysicalEdge")] PhysicalEdge edge);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4Node17setLayoutPositionEfNS0_12PhysicalEdgeE", ExactSpelling = true)]
        public static extern void setLayoutPosition(Node* pThis, float position, [NativeTypeName("facebook::yoga::PhysicalEdge")] PhysicalEdge edge);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4Node11setPositionENS0_9DirectionEff", ExactSpelling = true)]
        public static extern void setPosition(Node* pThis, [NativeTypeName("facebook::yoga::Direction")] Direction direction, float ownerWidth, float ownerHeight);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZNK8facebook4yoga4Node16processFlexBasisEv", ExactSpelling = true)]
        [return: NativeTypeName("facebook::yoga::Style::Length")]
        public static extern StyleLength processFlexBasis(Node* pThis);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZNK8facebook4yoga4Node16resolveFlexBasisENS0_9DirectionENS0_13FlexDirectionEff", ExactSpelling = true)]
        [return: NativeTypeName("facebook::yoga::FloatOptional")]
        public static extern FloatOptional resolveFlexBasis(Node* pThis, [NativeTypeName("facebook::yoga::Direction")] Direction direction, [NativeTypeName("facebook::yoga::FlexDirection")] FlexDirection flexDirection, float referenceLength, float ownerWidth);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4Node17processDimensionsEv", ExactSpelling = true)]
        public static extern void processDimensions(Node* pThis);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4Node16resolveDirectionENS0_9DirectionE", ExactSpelling = true)]
        [return: NativeTypeName("facebook::yoga::Direction")]
        public static extern Direction resolveDirection(Node* pThis, [NativeTypeName("facebook::yoga::Direction")] Direction ownerDirection);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4Node13clearChildrenEv", ExactSpelling = true)]
        public static extern void clearChildren(Node* pThis);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4Node12replaceChildEPS1_S2_", ExactSpelling = true)]
        public static extern void replaceChild(Node* pThis, [NativeTypeName("facebook::yoga::Node *")] Node* oldChild, [NativeTypeName("facebook::yoga::Node *")] Node* newChild);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4Node12replaceChildEPS1_m", ExactSpelling = true)]
        public static extern void replaceChild(Node* pThis, [NativeTypeName("facebook::yoga::Node *")] Node* child, [NativeTypeName("size_t")] nuint index);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4Node11insertChildEPS1_m", ExactSpelling = true)]
        public static extern void insertChild(Node* pThis, [NativeTypeName("facebook::yoga::Node *")] Node* child, [NativeTypeName("size_t")] nuint index);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4Node11removeChildEPS1_", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte removeChild(Node* pThis, [NativeTypeName("facebook::yoga::Node *")] Node* child);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4Node11removeChildEm", ExactSpelling = true)]
        public static extern void removeChild(Node* pThis, [NativeTypeName("size_t")] nuint index);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4Node21cloneChildrenIfNeededEv", ExactSpelling = true)]
        public static extern void cloneChildrenIfNeeded(Node* pThis);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4Node21markDirtyAndPropagateEv", ExactSpelling = true)]
        public static extern void markDirtyAndPropagate(Node* pThis);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZNK8facebook4yoga4Node15resolveFlexGrowEv", ExactSpelling = true)]
        public static extern float resolveFlexGrow(Node* pThis);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZNK8facebook4yoga4Node17resolveFlexShrinkEv", ExactSpelling = true)]
        public static extern float resolveFlexShrink(Node* pThis);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4Node14isNodeFlexibleEv", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte isNodeFlexible(Node* pThis);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga4Node5resetEv", ExactSpelling = true)]
        public static extern void reset(Node* pThis);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZNK8facebook4yoga4Node16relativePositionENS0_13FlexDirectionENS0_9DirectionEf", ExactSpelling = true)]
        private static extern float relativePosition(Node* pThis, [NativeTypeName("facebook::yoga::FlexDirection")] FlexDirection axis, [NativeTypeName("facebook::yoga::Direction")] Direction direction, float axisSize);
    }
}
