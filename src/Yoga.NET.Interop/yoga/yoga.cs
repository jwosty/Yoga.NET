using System;
using System.Runtime.InteropServices;

namespace Yoga.NET.Interop
{
    public static unsafe partial class yoga
    {
        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("YGConfigRef")]
        public static extern YGConfig* YGConfigNew();

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGConfigFree([NativeTypeName("YGConfigRef")] YGConfig* config);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("YGConfigConstRef")]
        public static extern YGConfig* YGConfigGetDefault();

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGConfigSetUseWebDefaults([NativeTypeName("YGConfigRef")] YGConfig* config, [NativeTypeName("bool")] byte enabled);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte YGConfigGetUseWebDefaults([NativeTypeName("YGConfigConstRef")] YGConfig* config);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGConfigSetPointScaleFactor([NativeTypeName("YGConfigRef")] YGConfig* config, float pixelsInPoint);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float YGConfigGetPointScaleFactor([NativeTypeName("YGConfigConstRef")] YGConfig* config);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGConfigSetErrata([NativeTypeName("YGConfigRef")] YGConfig* config, YogaErrata errata);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern YogaErrata YGConfigGetErrata([NativeTypeName("YGConfigConstRef")] YGConfig* config);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGConfigSetLogger([NativeTypeName("YGConfigRef")] YGConfig* config, [NativeTypeName("YGLogger")] delegate* unmanaged[Cdecl]<YGConfig*, YGNode*, YogaLogLevel, sbyte*, sbyte*, int> logger);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGConfigSetContext([NativeTypeName("YGConfigRef")] YGConfig* config, void* context);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* YGConfigGetContext([NativeTypeName("YGConfigConstRef")] YGConfig* config);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGConfigSetExperimentalFeatureEnabled([NativeTypeName("YGConfigRef")] YGConfig* config, YogaExperimentalFeature feature, [NativeTypeName("bool")] byte enabled);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte YGConfigIsExperimentalFeatureEnabled([NativeTypeName("YGConfigConstRef")] YGConfig* config, YogaExperimentalFeature feature);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGConfigSetCloneNodeFunc([NativeTypeName("YGConfigRef")] YGConfig* config, [NativeTypeName("YGCloneNodeFunc")] delegate* unmanaged[Cdecl]<YGNode*, YGNode*, nuint, YGNode*> callback);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* YogaAlignToString(YogaAlign param0);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* YogaBoxSizingToString(YogaBoxSizing param0);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* YogaDimensionToString(YogaDimension param0);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* YogaDirectionToString(YogaDirection param0);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* YogaDisplayToString(YogaDisplay param0);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* YogaEdgeToString(YogaEdge param0);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* YogaErrataToString(YogaErrata param0);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* YogaExperimentalFeatureToString(YogaExperimentalFeature param0);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* YogaFlexDirectionToString(YogaFlexDirection param0);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* YogaGutterToString(YogaGutter param0);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* YogaJustifyToString(YogaJustify param0);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* YogaLogLevelToString(YogaLogLevel param0);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* YogaMeasureModeToString(YogaMeasureMode param0);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* YogaNodeTypeToString(YogaNodeType param0);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* YogaOverflowToString(YogaOverflow param0);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* YogaPositionTypeToString(YogaPositionType param0);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* YogaUnitToString(YogaUnit param0);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* YogaWrapToString(YogaWrap param0);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("YGNodeRef")]
        public static extern YGNode* YGNodeNew();

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("YGNodeRef")]
        public static extern YGNode* YGNodeNewWithConfig([NativeTypeName("YGConfigConstRef")] YGConfig* config);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("YGNodeRef")]
        public static extern YGNode* YGNodeClone([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeFree([NativeTypeName("YGNodeRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeFreeRecursive([NativeTypeName("YGNodeRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeFinalize([NativeTypeName("YGNodeRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeReset([NativeTypeName("YGNodeRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeCalculateLayout([NativeTypeName("YGNodeRef")] YGNode* node, float availableWidth, float availableHeight, YogaDirection ownerDirection);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte YGNodeGetHasNewLayout([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeSetHasNewLayout([NativeTypeName("YGNodeRef")] YGNode* node, [NativeTypeName("bool")] byte hasNewLayout);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte YGNodeIsDirty([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeMarkDirty([NativeTypeName("YGNodeRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeSetDirtiedFunc([NativeTypeName("YGNodeRef")] YGNode* node, [NativeTypeName("YGDirtiedFunc")] delegate* unmanaged[Cdecl]<YGNode*, void> dirtiedFunc);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("YGDirtiedFunc")]
        public static extern delegate* unmanaged[Cdecl]<YGNode*, void> YGNodeGetDirtiedFunc([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeInsertChild([NativeTypeName("YGNodeRef")] YGNode* node, [NativeTypeName("YGNodeRef")] YGNode* child, [NativeTypeName("size_t")] nuint index);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeSwapChild([NativeTypeName("YGNodeRef")] YGNode* node, [NativeTypeName("YGNodeRef")] YGNode* child, [NativeTypeName("size_t")] nuint index);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeRemoveChild([NativeTypeName("YGNodeRef")] YGNode* node, [NativeTypeName("YGNodeRef")] YGNode* child);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeRemoveAllChildren([NativeTypeName("YGNodeRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeSetChildren([NativeTypeName("YGNodeRef")] YGNode* owner, [NativeTypeName("const YGNodeRef *")] YGNode** children, [NativeTypeName("size_t")] nuint count);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("YGNodeRef")]
        public static extern YGNode* YGNodeGetChild([NativeTypeName("YGNodeRef")] YGNode* node, [NativeTypeName("size_t")] nuint index);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint YGNodeGetChildCount([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("YGNodeRef")]
        public static extern YGNode* YGNodeGetOwner([NativeTypeName("YGNodeRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("YGNodeRef")]
        public static extern YGNode* YGNodeGetParent([NativeTypeName("YGNodeRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeSetConfig([NativeTypeName("YGNodeRef")] YGNode* node, [NativeTypeName("YGConfigRef")] YGConfig* config);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("YGConfigConstRef")]
        public static extern YGConfig* YGNodeGetConfig([NativeTypeName("YGNodeRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeSetContext([NativeTypeName("YGNodeRef")] YGNode* node, void* context);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* YGNodeGetContext([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeSetMeasureFunc([NativeTypeName("YGNodeRef")] YGNode* node, [NativeTypeName("YGMeasureFunc")] delegate* unmanaged[Cdecl]<YGNode*, float, YogaMeasureMode, float, YogaMeasureMode, YGSize> measureFunc);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte YGNodeHasMeasureFunc([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeSetBaselineFunc([NativeTypeName("YGNodeRef")] YGNode* node, [NativeTypeName("YGBaselineFunc")] delegate* unmanaged[Cdecl]<YGNode*, float, float, float> baselineFunc);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte YGNodeHasBaselineFunc([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeSetIsReferenceBaseline([NativeTypeName("YGNodeRef")] YGNode* node, [NativeTypeName("bool")] byte isReferenceBaseline);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte YGNodeIsReferenceBaseline([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeSetNodeType([NativeTypeName("YGNodeRef")] YGNode* node, YogaNodeType nodeType);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern YogaNodeType YGNodeGetNodeType([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeSetAlwaysFormsContainingBlock([NativeTypeName("YGNodeRef")] YGNode* node, [NativeTypeName("bool")] byte alwaysFormsContainingBlock);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte YGNodeGetAlwaysFormsContainingBlock([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        [Obsolete("YGNodeCanUseCachedMeasurement may be removed in a future version of Yoga")]
        public static extern byte YGNodeCanUseCachedMeasurement(YogaMeasureMode widthMode, float availableWidth, YogaMeasureMode heightMode, float availableHeight, YogaMeasureMode lastWidthMode, float lastAvailableWidth, YogaMeasureMode lastHeightMode, float lastAvailableHeight, float lastComputedWidth, float lastComputedHeight, float marginRow, float marginColumn, [NativeTypeName("YGConfigRef")] YGConfig* config);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float YGNodeLayoutGetLeft([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float YGNodeLayoutGetTop([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float YGNodeLayoutGetRight([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float YGNodeLayoutGetBottom([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float YGNodeLayoutGetWidth([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float YGNodeLayoutGetHeight([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern YogaDirection YGNodeLayoutGetDirection([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte YGNodeLayoutGetHadOverflow([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float YGNodeLayoutGetMargin([NativeTypeName("YGNodeConstRef")] YGNode* node, YogaEdge edge);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float YGNodeLayoutGetBorder([NativeTypeName("YGNodeConstRef")] YGNode* node, YogaEdge edge);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float YGNodeLayoutGetPadding([NativeTypeName("YGNodeConstRef")] YGNode* node, YogaEdge edge);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeCopyStyle([NativeTypeName("YGNodeRef")] YGNode* dstNode, [NativeTypeName("YGNodeConstRef")] YGNode* srcNode);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetDirection([NativeTypeName("YGNodeRef")] YGNode* node, YogaDirection direction);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern YogaDirection YGNodeStyleGetDirection([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetFlexDirection([NativeTypeName("YGNodeRef")] YGNode* node, YogaFlexDirection flexDirection);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern YogaFlexDirection YGNodeStyleGetFlexDirection([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetJustifyContent([NativeTypeName("YGNodeRef")] YGNode* node, YogaJustify justifyContent);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern YogaJustify YGNodeStyleGetJustifyContent([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetAlignContent([NativeTypeName("YGNodeRef")] YGNode* node, YogaAlign alignContent);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern YogaAlign YGNodeStyleGetAlignContent([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetAlignItems([NativeTypeName("YGNodeRef")] YGNode* node, YogaAlign alignItems);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern YogaAlign YGNodeStyleGetAlignItems([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetAlignSelf([NativeTypeName("YGNodeRef")] YGNode* node, YogaAlign alignSelf);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern YogaAlign YGNodeStyleGetAlignSelf([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetPositionType([NativeTypeName("YGNodeRef")] YGNode* node, YogaPositionType positionType);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern YogaPositionType YGNodeStyleGetPositionType([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetFlexWrap([NativeTypeName("YGNodeRef")] YGNode* node, YogaWrap flexWrap);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern YogaWrap YGNodeStyleGetFlexWrap([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetOverflow([NativeTypeName("YGNodeRef")] YGNode* node, YogaOverflow overflow);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern YogaOverflow YGNodeStyleGetOverflow([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetDisplay([NativeTypeName("YGNodeRef")] YGNode* node, YogaDisplay display);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern YogaDisplay YGNodeStyleGetDisplay([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetFlex([NativeTypeName("YGNodeRef")] YGNode* node, float flex);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float YGNodeStyleGetFlex([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetFlexGrow([NativeTypeName("YGNodeRef")] YGNode* node, float flexGrow);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float YGNodeStyleGetFlexGrow([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetFlexShrink([NativeTypeName("YGNodeRef")] YGNode* node, float flexShrink);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float YGNodeStyleGetFlexShrink([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetFlexBasis([NativeTypeName("YGNodeRef")] YGNode* node, float flexBasis);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetFlexBasisPercent([NativeTypeName("YGNodeRef")] YGNode* node, float flexBasis);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetFlexBasisAuto([NativeTypeName("YGNodeRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern YGValue YGNodeStyleGetFlexBasis([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetPosition([NativeTypeName("YGNodeRef")] YGNode* node, YogaEdge edge, float position);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetPositionPercent([NativeTypeName("YGNodeRef")] YGNode* node, YogaEdge edge, float position);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern YGValue YGNodeStyleGetPosition([NativeTypeName("YGNodeConstRef")] YGNode* node, YogaEdge edge);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetPositionAuto([NativeTypeName("YGNodeRef")] YGNode* node, YogaEdge edge);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetMargin([NativeTypeName("YGNodeRef")] YGNode* node, YogaEdge edge, float margin);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetMarginPercent([NativeTypeName("YGNodeRef")] YGNode* node, YogaEdge edge, float margin);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetMarginAuto([NativeTypeName("YGNodeRef")] YGNode* node, YogaEdge edge);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern YGValue YGNodeStyleGetMargin([NativeTypeName("YGNodeConstRef")] YGNode* node, YogaEdge edge);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetPadding([NativeTypeName("YGNodeRef")] YGNode* node, YogaEdge edge, float padding);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetPaddingPercent([NativeTypeName("YGNodeRef")] YGNode* node, YogaEdge edge, float padding);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern YGValue YGNodeStyleGetPadding([NativeTypeName("YGNodeConstRef")] YGNode* node, YogaEdge edge);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetBorder([NativeTypeName("YGNodeRef")] YGNode* node, YogaEdge edge, float border);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float YGNodeStyleGetBorder([NativeTypeName("YGNodeConstRef")] YGNode* node, YogaEdge edge);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetGap([NativeTypeName("YGNodeRef")] YGNode* node, YogaGutter gutter, float gapLength);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetGapPercent([NativeTypeName("YGNodeRef")] YGNode* node, YogaGutter gutter, float gapLength);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float YGNodeStyleGetGap([NativeTypeName("YGNodeConstRef")] YGNode* node, YogaGutter gutter);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetBoxSizing([NativeTypeName("YGNodeRef")] YGNode* node, YogaBoxSizing boxSizing);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern YogaBoxSizing YGNodeStyleGetBoxSizing([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetWidth([NativeTypeName("YGNodeRef")] YGNode* node, float width);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetWidthPercent([NativeTypeName("YGNodeRef")] YGNode* node, float width);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetWidthAuto([NativeTypeName("YGNodeRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern YGValue YGNodeStyleGetWidth([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetHeight([NativeTypeName("YGNodeRef")] YGNode* node, float height);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetHeightPercent([NativeTypeName("YGNodeRef")] YGNode* node, float height);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetHeightAuto([NativeTypeName("YGNodeRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern YGValue YGNodeStyleGetHeight([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetMinWidth([NativeTypeName("YGNodeRef")] YGNode* node, float minWidth);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetMinWidthPercent([NativeTypeName("YGNodeRef")] YGNode* node, float minWidth);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern YGValue YGNodeStyleGetMinWidth([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetMinHeight([NativeTypeName("YGNodeRef")] YGNode* node, float minHeight);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetMinHeightPercent([NativeTypeName("YGNodeRef")] YGNode* node, float minHeight);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern YGValue YGNodeStyleGetMinHeight([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetMaxWidth([NativeTypeName("YGNodeRef")] YGNode* node, float maxWidth);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetMaxWidthPercent([NativeTypeName("YGNodeRef")] YGNode* node, float maxWidth);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern YGValue YGNodeStyleGetMaxWidth([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetMaxHeight([NativeTypeName("YGNodeRef")] YGNode* node, float maxHeight);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetMaxHeightPercent([NativeTypeName("YGNodeRef")] YGNode* node, float maxHeight);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern YGValue YGNodeStyleGetMaxHeight([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void YGNodeStyleSetAspectRatio([NativeTypeName("YGNodeRef")] YGNode* node, float aspectRatio);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float YGNodeStyleGetAspectRatio([NativeTypeName("YGNodeConstRef")] YGNode* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float YGRoundValueToPixelGrid(double value, double pointScaleFactor, [NativeTypeName("bool")] byte forceCeil, [NativeTypeName("bool")] byte forceFloor);

        [NativeTypeName("const float")]
        public const float YGUndefined = Single.NaN;

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte YGFloatIsUndefined(float value);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__ZN8facebook4yoga19layoutAbsoluteChildEPKNS0_4NodeES3_PS1_ffNS0_10SizingModeENS0_9DirectionERNS0_10LayoutDataEjj", ExactSpelling = true)]
        public static extern void layoutAbsoluteChild([NativeTypeName("const yoga::Node *")] Node* containingNode, [NativeTypeName("const yoga::Node *")] Node* node, [NativeTypeName("facebook::yoga::Node *")] Node* child, float containingBlockWidth, float containingBlockHeight, [NativeTypeName("facebook::yoga::SizingMode")] SizingMode widthMode, [NativeTypeName("facebook::yoga::Direction")] Direction direction, [NativeTypeName("facebook::yoga::LayoutData &")] LayoutData* layoutMarkerData, [NativeTypeName("uint32_t")] uint depth, [NativeTypeName("uint32_t")] uint generationCount);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__ZN8facebook4yoga25layoutAbsoluteDescendantsEPNS0_4NodeES2_NS0_10SizingModeENS0_9DirectionERNS0_10LayoutDataEjjffff", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte layoutAbsoluteDescendants([NativeTypeName("facebook::yoga::Node *")] Node* containingNode, [NativeTypeName("facebook::yoga::Node *")] Node* currentNode, [NativeTypeName("facebook::yoga::SizingMode")] SizingMode widthSizingMode, [NativeTypeName("facebook::yoga::Direction")] Direction currentNodeDirection, [NativeTypeName("facebook::yoga::LayoutData &")] LayoutData* layoutMarkerData, [NativeTypeName("uint32_t")] uint currentDepth, [NativeTypeName("uint32_t")] uint generationCount, float currentNodeMainOffsetFromContainingBlock, float currentNodeCrossOffsetFromContainingBlock, float containingNodeAvailableInnerWidth, float containingNodeAvailableInnerHeight);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__ZN8facebook4yoga17calculateBaselineEPKNS0_4NodeE", ExactSpelling = true)]
        public static extern float calculateBaseline([NativeTypeName("const yoga::Node *")] Node* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__ZN8facebook4yoga16isBaselineLayoutEPKNS0_4NodeE", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte isBaselineLayout([NativeTypeName("const yoga::Node *")] Node* node);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__ZN8facebook4yoga23canUseCachedMeasurementENS0_10SizingModeEfS1_fS1_fS1_fffffPKNS0_6ConfigE", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte canUseCachedMeasurement([NativeTypeName("facebook::yoga::SizingMode")] SizingMode widthMode, float availableWidth, [NativeTypeName("facebook::yoga::SizingMode")] SizingMode heightMode, float availableHeight, [NativeTypeName("facebook::yoga::SizingMode")] SizingMode lastWidthMode, float lastAvailableWidth, [NativeTypeName("facebook::yoga::SizingMode")] SizingMode lastHeightMode, float lastAvailableHeight, float lastComputedWidth, float lastComputedHeight, float marginRow, float marginColumn, [NativeTypeName("const yoga::Config *")] Config* config);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__ZN8facebook4yoga15calculateLayoutEPNS0_4NodeEffNS0_9DirectionE", ExactSpelling = true)]
        public static extern void calculateLayout([NativeTypeName("facebook::yoga::Node *")] Node* node, float ownerWidth, float ownerHeight, [NativeTypeName("facebook::yoga::Direction")] Direction ownerDirection);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__ZN8facebook4yoga23calculateLayoutInternalEPNS0_4NodeEffNS0_9DirectionENS0_10SizingModeES4_ffbNS0_16LayoutPassReasonERNS0_10LayoutDataEjj", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte calculateLayoutInternal([NativeTypeName("facebook::yoga::Node *")] Node* node, float availableWidth, float availableHeight, [NativeTypeName("facebook::yoga::Direction")] Direction ownerDirection, [NativeTypeName("facebook::yoga::SizingMode")] SizingMode widthSizingMode, [NativeTypeName("facebook::yoga::SizingMode")] SizingMode heightSizingMode, float ownerWidth, float ownerHeight, [NativeTypeName("bool")] byte performLayout, [NativeTypeName("facebook::yoga::LayoutPassReason")] LayoutPassReason reason, [NativeTypeName("facebook::yoga::LayoutData &")] LayoutData* layoutMarkerData, [NativeTypeName("uint32_t")] uint depth, [NativeTypeName("uint32_t")] uint generationCount);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__ZN8facebook4yoga21roundValueToPixelGridEddbb", ExactSpelling = true)]
        public static extern float roundValueToPixelGrid(double value, double pointScaleFactor, [NativeTypeName("bool")] byte forceCeil, [NativeTypeName("bool")] byte forceFloor);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__ZN8facebook4yoga29roundLayoutResultsToPixelGridEPNS0_4NodeEdd", ExactSpelling = true)]
        public static extern void roundLayoutResultsToPixelGrid([NativeTypeName("facebook::yoga::Node *")] Node* node, double absoluteLeft, double absoluteTop);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__ZN8facebook4yoga29configUpdateInvalidatesLayoutERKNS0_6ConfigES3_", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte configUpdateInvalidatesLayout([NativeTypeName("const Config &")] Config* oldConfig, [NativeTypeName("const Config &")] Config* newConfig);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__ZN8facebook4yoga16fatalWithMessageEPKc", ExactSpelling = true)]
        public static extern void fatalWithMessage([NativeTypeName("const char *")] sbyte* message);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__ZN8facebook4yoga11assertFatalEbPKc", ExactSpelling = true)]
        public static extern void assertFatal([NativeTypeName("bool")] byte condition, [NativeTypeName("const char *")] sbyte* message);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__ZN8facebook4yoga19assertFatalWithNodeEPKNS0_4NodeEbPKc", ExactSpelling = true)]
        public static extern void assertFatalWithNode([NativeTypeName("const yoga::Node *")] Node* node, [NativeTypeName("bool")] byte condition, [NativeTypeName("const char *")] sbyte* message);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__ZN8facebook4yoga21assertFatalWithConfigEPKNS0_6ConfigEbPKc", ExactSpelling = true)]
        public static extern void assertFatalWithConfig([NativeTypeName("const yoga::Config *")] Config* config, [NativeTypeName("bool")] byte condition, [NativeTypeName("const char *")] sbyte* message);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__ZN8facebook4yoga3logENS0_8LogLevelEPKcz", ExactSpelling = true)]
        public static extern void log([NativeTypeName("facebook::yoga::LogLevel")] LogLevel level, [NativeTypeName("const char *")] sbyte* format, __arglist);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__ZN8facebook4yoga3logEPKNS0_4NodeENS0_8LogLevelEPKcz", ExactSpelling = true)]
        public static extern void log([NativeTypeName("const yoga::Node *")] Node* node, [NativeTypeName("facebook::yoga::LogLevel")] LogLevel level, [NativeTypeName("const char *")] sbyte* format, __arglist);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__ZN8facebook4yoga3logEPKNS0_6ConfigENS0_8LogLevelEPKcz", ExactSpelling = true)]
        public static extern void log([NativeTypeName("const yoga::Config *")] Config* config, [NativeTypeName("facebook::yoga::LogLevel")] LogLevel level, [NativeTypeName("const char *")] sbyte* format, __arglist);

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__ZN8facebook4yoga16getDefaultLoggerEv", ExactSpelling = true)]
        [return: NativeTypeName("YGLogger")]
        public static extern delegate* unmanaged[Cdecl]<YGConfig*, YGNode*, YogaLogLevel, sbyte*, sbyte*, int> getDefaultLogger();

        [DllImport("libyoga", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__ZN8facebook4yoga24LayoutPassReasonToStringENS0_16LayoutPassReasonE", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* LayoutPassReasonToString([NativeTypeName("facebook::yoga::LayoutPassReason")] LayoutPassReason value);
    }
}
