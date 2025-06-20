using System;
using JetBrains.Annotations;
using Yoga.NET.Interop;

namespace Yoga.NET;

[PublicAPI]
public unsafe class YogaNode : IDisposable
{
    private bool _disposed;

    public YGNode* Handle { get; }

    private YogaConfig? _config;

    public YogaNode()
    {
        this.Handle = yoga.YGNodeNew();
        if (this.Handle is null)
        {
            throw new InvalidOperationException("Failed to allocate native YGNode object");
        }
    }

    public YogaNode(YogaConfig config)
    {
        this.Handle = yoga.YGNodeNewWithConfig(config.Handle);
        this._config = config;
    }

    public void CalculateLayout(float availableWidth = yoga.YGUndefined, float availableHeight = yoga.YGUndefined, YogaDirection? ownerDirection = null)
    {
        yoga.YGNodeCalculateLayout(this.Handle, availableWidth, availableHeight,
            ownerDirection ?? yoga.YGNodeStyleGetDirection(this.Handle));
    }

    public void Dispose(bool disposing)
    {
        if (!this._disposed)
        {
            if (disposing)
            {
                // Dispose managed state (managed objects).
            }

            // Free unmanaged resources.
            yoga.YGNodeFree(this.Handle);

            this._disposed = true;
        }
    }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~YogaNode()
    {
        this.Dispose(false);
    }

    #region YGNode

    public void InsertChild(int index, YogaNode child) =>
        yoga.YGNodeInsertChild(this.Handle, child.Handle, (nuint)index);

    public void RemoveChild(YogaNode child) => yoga.YGNodeRemoveChild(this.Handle, child.Handle);

    public void Clear() => yoga.YGNodeRemoveAllChildren(this.Handle);

    public YogaConfig Config
    {
        get => this._config ??= new YogaConfig(yoga.YGNodeGetConfig(this.Handle), false);
        set => this._config = value;
    }

    #endregion

    #region Style

    public YogaDirection Direction
    {
        get => yoga.YGNodeStyleGetDirection(this.Handle);
        set =>  yoga.YGNodeStyleSetDirection(this.Handle, value);
    }

    public YogaFlexDirection FlexDirection
    {
        get => yoga.YGNodeStyleGetFlexDirection(this.Handle);
        set => yoga.YGNodeStyleSetFlexDirection(this.Handle, value);
    }

    public YogaJustify JustifyContent
    {
        get => yoga.YGNodeStyleGetJustifyContent(this.Handle);
        set => yoga.YGNodeStyleSetJustifyContent(this.Handle, value);
    }

    public YogaAlign AlignContent
    {
        get => yoga.YGNodeStyleGetAlignContent(this.Handle);
        set => yoga.YGNodeStyleSetAlignContent(this.Handle, value);
    }

    public YogaAlign AlignItems
    {
        get => yoga.YGNodeStyleGetAlignItems(this.Handle);
        set => yoga.YGNodeStyleSetAlignItems(this.Handle, value);
    }

    public YogaAlign AlignSelf
    {
        get => yoga.YGNodeStyleGetAlignSelf(this.Handle);
        set  => yoga.YGNodeStyleSetAlignSelf(this.Handle, value);
    }

    public YogaPositionType PositionType
    {
        get => yoga.YGNodeStyleGetPositionType(this.Handle);
        set => yoga.YGNodeStyleSetPositionType(this.Handle, value);
    }

    public YogaWrap FlexWrap
    {
        get => yoga.YGNodeStyleGetFlexWrap(this.Handle);
        set => yoga.YGNodeStyleSetFlexWrap(this.Handle, value);
    }

    public YogaOverflow Overflow
    {
        get => yoga.YGNodeStyleGetOverflow(this.Handle);
        set => yoga.YGNodeStyleSetOverflow(this.Handle, value);
    }

    public YogaDisplay Display
    {
        get => yoga.YGNodeStyleGetDisplay(this.Handle);
        set => yoga.YGNodeStyleSetDisplay(this.Handle, value);
    }

    public float FlexGrow
    {
        get => yoga.YGNodeStyleGetFlexGrow(this.Handle);
        set => yoga.YGNodeStyleSetFlexGrow(this.Handle, value);
    }

    public float FlexShrink
    {
        get => yoga.YGNodeStyleGetFlexShrink(this.Handle);
        set => yoga.YGNodeStyleSetFlexShrink(this.Handle, value);
    }

    public YogaValue FlexBasis
    {
        get => yoga.YGNodeStyleGetFlexBasis(this.Handle);
        set
        {
            switch (value.Unit)
            {
                case YogaUnit.Percent:
                    yoga.YGNodeStyleSetFlexBasisPercent(this.Handle, value.Value);
                    break;
                case YogaUnit.Auto:
                    yoga.YGNodeStyleSetFlexBasisAuto(this.Handle);
                    break;
                default:
                    yoga.YGNodeStyleSetFlexBasis(this.Handle, value.Value);
                    break;
            }
        }
    }

    #region Position

    public YogaValue Left
    {
        get => yoga.YGNodeStyleGetPosition(this.Handle, YogaEdge.Left);
        set
        {
            var edge = YogaEdge.Left;
            this.SetStylePosition(value, edge);
        }
    }

    public YogaValue Top
    {
        get => yoga.YGNodeStyleGetPosition(this.Handle, YogaEdge.Top);
        set
        {
            var edge = YogaEdge.Top;
            this.SetStylePosition(value, edge);
        }
    }

    public YogaValue Right
    {
        get => yoga.YGNodeStyleGetPosition(this.Handle, YogaEdge.Right);
        set
        {
            var edge = YogaEdge.Right;
            this.SetStylePosition(value, edge);
        }
    }

    public YogaValue Bottom
    {
        get => yoga.YGNodeStyleGetPosition(this.Handle, YogaEdge.Bottom);
        set
        {
            var edge = YogaEdge.Bottom;
            this.SetStylePosition(value, edge);
        }
    }

    public YogaValue Start
    {
        get => yoga.YGNodeStyleGetPosition(this.Handle, YogaEdge.Start);
        set
        {
            var edge = YogaEdge.Start;
            this.SetStylePosition(value, edge);
        }
    }

    public YogaValue End
    {
        get => yoga.YGNodeStyleGetPosition(this.Handle, YogaEdge.End);
        set
        {
            var edge = YogaEdge.End;
            this.SetStylePosition(value, edge);
        }
    }

    public YogaValue Horizontal
    {
        get => yoga.YGNodeStyleGetPosition(this.Handle, YogaEdge.Horizontal);
        set
        {
            var edge = YogaEdge.Horizontal;
            this.SetStylePosition(value, edge);
        }
    }

    public YogaValue Vertical
    {
        get => yoga.YGNodeStyleGetPosition(this.Handle, YogaEdge.Vertical);
        set
        {
            var edge = YogaEdge.Vertical;
            this.SetStylePosition(value, edge);
        }
    }

    public YogaValue PositionAll
    {
        get => yoga.YGNodeStyleGetPosition(this.Handle, YogaEdge.All);
        set
        {
            var edge = YogaEdge.All;
            this.SetStylePosition(value, edge);
        }
    }

    private void SetStylePosition(YogaValue value, YogaEdge edge)
    {
        switch (value.Unit)
        {
            case YogaUnit.Percent:
                yoga.YGNodeStyleSetPositionPercent(this.Handle, edge, value.Value);
                break;
            case YogaUnit.Auto:
                yoga.YGNodeStyleSetPositionAuto(this.Handle, edge);
                break;
            default:
                yoga.YGNodeStyleSetPosition(this.Handle, edge, value.Value);
                break;
        }
    }

    #endregion

    #region Margin

    public YogaValue MarginLeft
    {
        get => yoga.YGNodeStyleGetMargin(this.Handle, YogaEdge.Left);
        set => this.SetStyleMargin(YogaEdge.Left, value);
    }

    public YogaValue MarginTop
    {
        get => yoga.YGNodeStyleGetMargin(this.Handle, YogaEdge.Top);
        set => this.SetStyleMargin(YogaEdge.Top, value);
    }

    public YogaValue MarginRight
    {
        get => yoga.YGNodeStyleGetMargin(this.Handle, YogaEdge.Right);
        set => this.SetStyleMargin(YogaEdge.Right, value);
    }

    public YogaValue MarginBottom
    {
        get => yoga.YGNodeStyleGetMargin(this.Handle, YogaEdge.Bottom);
        set => this.SetStyleMargin(YogaEdge.Bottom, value);
    }

    public YogaValue MarginStart
    {
        get => yoga.YGNodeStyleGetMargin(this.Handle, YogaEdge.Start);
        set => this.SetStyleMargin(YogaEdge.Start, value);
    }

    public YogaValue MarginEnd
    {
        get => yoga.YGNodeStyleGetMargin(this.Handle, YogaEdge.End);
        set => this.SetStyleMargin(YogaEdge.End, value);
    }

    public YogaValue MarginHorizontal
    {
        get => yoga.YGNodeStyleGetMargin(this.Handle, YogaEdge.Horizontal);
        set => this.SetStyleMargin(YogaEdge.Horizontal, value);
    }

    public YogaValue MarginVertical
    {
        get => yoga.YGNodeStyleGetMargin(this.Handle, YogaEdge.Vertical);
        set => this.SetStyleMargin(YogaEdge.Vertical, value);
    }

    public YogaValue Margin
    {
        get => yoga.YGNodeStyleGetMargin(this.Handle, YogaEdge.All);
        set => this.SetStyleMargin(YogaEdge.All, value);
    }

    private void SetStyleMargin(YogaEdge edge, YogaValue value)
    {
        switch (value.Unit)
        {
            case YogaUnit.Percent:
                yoga.YGNodeStyleSetMarginPercent(this.Handle, edge, value.Value);
                break;
            case YogaUnit.Auto:
                yoga.YGNodeStyleSetMarginAuto(this.Handle, edge);
                break;
            default:
                yoga.YGNodeStyleSetMargin(this.Handle, edge, value.Value);
                break;
        }
    }

    #endregion

    #region Padding

    public YogaValue PaddingLeft
    {
        get => yoga.YGNodeStyleGetPadding(this.Handle, YogaEdge.Left);
        set => this.SetStylePadding(YogaEdge.Left, value);
    }

    public YogaValue PaddingTop
    {
        get => yoga.YGNodeStyleGetPadding(this.Handle, YogaEdge.Top);
        set => this.SetStylePadding(YogaEdge.Top, value);
    }

    public YogaValue PaddingRight
    {
        get => yoga.YGNodeStyleGetPadding(this.Handle, YogaEdge.Right);
        set => this.SetStylePadding(YogaEdge.Right, value);
    }

    public YogaValue PaddingBottom
    {
        get => yoga.YGNodeStyleGetPadding(this.Handle, YogaEdge.Bottom);
        set => this.SetStylePadding(YogaEdge.Bottom, value);
    }

    public YogaValue PaddingStart
    {
        get => yoga.YGNodeStyleGetPadding(this.Handle, YogaEdge.Start);
        set => this.SetStylePadding(YogaEdge.Start, value);
    }

    public YogaValue PaddingEnd
    {
        get => yoga.YGNodeStyleGetPadding(this.Handle, YogaEdge.End);
        set => this.SetStylePadding(YogaEdge.End, value);
    }

    public YogaValue PaddingHorizontal
    {
        get => yoga.YGNodeStyleGetPadding(this.Handle, YogaEdge.Horizontal);
        set => this.SetStylePadding(YogaEdge.Horizontal, value);
    }

    public YogaValue PaddingVertical
    {
        get => yoga.YGNodeStyleGetPadding(this.Handle, YogaEdge.Vertical);
        set => this.SetStylePadding(YogaEdge.Vertical, value);
    }

    public YogaValue Padding
    {
        get => yoga.YGNodeStyleGetPadding(this.Handle, YogaEdge.All);
        set => this.SetStylePadding(YogaEdge.All, value);
    }

    private void SetStylePadding(YogaEdge edge, YogaValue value)
    {
        switch (value.Unit)
        {
            case YogaUnit.Percent:
                yoga.YGNodeStyleSetPaddingPercent(this.Handle, edge, value.Value);
                break;
            // Yoga does not support `auto` padding
            default:
                yoga.YGNodeStyleSetPadding(this.Handle, edge, value.Value);
                break;
        }
    }

    #endregion

    #region Border
    public YogaValue BorderLeft
    {
        get => yoga.YGNodeStyleGetBorder(this.Handle, YogaEdge.Left);
        set => yoga.YGNodeStyleSetBorder(this.Handle, YogaEdge.Left, value.Value);
    }

    public YogaValue BorderTop
    {
        get => yoga.YGNodeStyleGetBorder(this.Handle, YogaEdge.Top);
        set => yoga.YGNodeStyleSetBorder(this.Handle, YogaEdge.Top, value.Value);
    }

    public YogaValue BorderRight
    {
        get => yoga.YGNodeStyleGetBorder(this.Handle, YogaEdge.Right);
        set => yoga.YGNodeStyleSetBorder(this.Handle, YogaEdge.Right, value.Value);
    }

    public YogaValue BorderBottom
    {
        get => yoga.YGNodeStyleGetBorder(this.Handle, YogaEdge.Bottom);
        set => yoga.YGNodeStyleSetBorder(this.Handle, YogaEdge.Bottom, value.Value);
    }

    public YogaValue BorderStart
    {
        get => yoga.YGNodeStyleGetBorder(this.Handle, YogaEdge.Start);
        set => yoga.YGNodeStyleSetBorder(this.Handle, YogaEdge.Start, value.Value);
    }

    public YogaValue BorderEnd
    {
        get => yoga.YGNodeStyleGetBorder(this.Handle, YogaEdge.End);
        set => yoga.YGNodeStyleSetBorder(this.Handle, YogaEdge.End, value.Value);
    }

    public YogaValue BorderHorizontal
    {
        get => yoga.YGNodeStyleGetBorder(this.Handle, YogaEdge.Horizontal);
        set => yoga.YGNodeStyleSetBorder(this.Handle, YogaEdge.Horizontal, value.Value);
    }

    public YogaValue BorderVertical
    {
        get => yoga.YGNodeStyleGetBorder(this.Handle, YogaEdge.Vertical);
        set => yoga.YGNodeStyleSetBorder(this.Handle, YogaEdge.Vertical, value.Value);
    }

    public YogaValue Border
    {
        get => yoga.YGNodeStyleGetBorder(this.Handle, YogaEdge.All);
        set => yoga.YGNodeStyleSetBorder(this.Handle, YogaEdge.All, value.Value);
    }

    #endregion

    #region Gap

    public YogaValue GapColumn
    {
        get => yoga.YGNodeStyleGetGap(this.Handle, YogaGutter.Column);
        set => this.SetStyleGap(YogaGutter.Column, value);
    }

    public YogaValue GapRow
    {
        get => yoga.YGNodeStyleGetGap(this.Handle, YogaGutter.Row);
        set => this.SetStyleGap(YogaGutter.Row, value);
    }

    public YogaValue Gap
    {
        get => yoga.YGNodeStyleGetGap(this.Handle, YogaGutter.All);
        set => this.SetStyleGap(YogaGutter.All, value);
    }

    private void SetStyleGap(YogaGutter gutter, YogaValue value)
    {
        switch (value.Unit)
        {
            case YogaUnit.Percent:
                yoga.YGNodeStyleSetGapPercent(this.Handle, gutter, value.Value);
                break;
            // Yoga does not support `auto` gap
            default:
                yoga.YGNodeStyleSetGap(this.Handle, gutter, value.Value);
                break;
        }
    }

    #endregion

    public YogaBoxSizing BoxSizing
    {
        get => yoga.YGNodeStyleGetBoxSizing(this.Handle);
        set => yoga.YGNodeStyleSetBoxSizing(this.Handle, value);
    }

    public YogaValue Width
    {
        get => yoga.YGNodeStyleGetWidth(this.Handle);
        set
        {
            switch (value.Unit)
            {
                case YogaUnit.Percent:
                    yoga.YGNodeStyleSetWidthPercent(this.Handle, value.Value);
                    break;
                case YogaUnit.Auto:
                    yoga.YGNodeStyleSetWidthAuto(this.Handle);
                    break;
                default:
                    yoga.YGNodeStyleSetWidth(this.Handle, value.Value);
                    break;
            }
        }
    }

    public YogaValue Height
    {
        get => yoga.YGNodeStyleGetHeight(this.Handle);
        set
        {
            switch (value.Unit)
            {
                case YogaUnit.Percent:
                    yoga.YGNodeStyleSetHeightPercent(this.Handle, value.Value);
                    break;
                case YogaUnit.Auto:
                    yoga.YGNodeStyleSetHeightAuto(this.Handle);
                    break;
                default:
                    yoga.YGNodeStyleSetHeight(this.Handle, value.Value);
                    break;
            }
        }
    }

    public YogaValue MinWidth
    {
        get => yoga.YGNodeStyleGetMinWidth(this.Handle);
        set  => yoga.YGNodeStyleSetMinWidth(this.Handle, value.Value);
    }

    public YogaValue MinHeight
    {
        get => yoga.YGNodeStyleGetMinHeight(this.Handle);
        set => yoga.YGNodeStyleSetMinHeight(this.Handle, value.Value);
    }

    public YogaValue MaxWidth
    {
        get => yoga.YGNodeStyleGetMaxWidth(this.Handle);
        set => yoga.YGNodeStyleSetMaxWidth(this.Handle, value.Value);
    }

    public YogaValue MaxHeight
    {
        get => yoga.YGNodeStyleGetMaxHeight(this.Handle);
        set => yoga.YGNodeStyleSetMaxHeight(this.Handle, value.Value);
    }

    public float AspectRatio
    {
        get => yoga.YGNodeStyleGetAspectRatio(this.Handle);
        set => yoga.YGNodeStyleSetAspectRatio(this.Handle, value);
    }

    #endregion

    #region Layout

    public float LayoutLeft => yoga.YGNodeLayoutGetLeft(this.Handle);

    public float LayoutTop => yoga.YGNodeLayoutGetTop(this.Handle);

    public float LayoutRight => yoga.YGNodeLayoutGetRight(this.Handle);

    public float LayoutBottom => yoga.YGNodeLayoutGetBottom(this.Handle);

    public float LayoutWidth => yoga.YGNodeLayoutGetWidth(this.Handle);

    public float LayoutHeight => yoga.YGNodeLayoutGetHeight(this.Handle);

    #endregion
}
