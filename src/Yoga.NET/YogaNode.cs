using System;
using JetBrains.Annotations;
using Yoga.NET.Interop;

namespace Yoga.NET;

[PublicAPI]
public unsafe class YogaNode : IDisposable
{
    private bool _disposed;

    public YGNode* Handle { get; }

    public YogaNode()
    {
        this.Handle = yoga.YGNodeNew();
        if (this.Handle is null)
        {
            throw new InvalidOperationException("Failed to allocate native memory");
        }
    }

    public void CalculateLayout(float availableWidth = yoga.YGUndefined, float availableHeight = yoga.YGUndefined, YGDirection? ownerDirection = null)
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

    #region YGNode

    public void InsertChild(int index, YogaNode child) =>
        yoga.YGNodeInsertChild(this.Handle, child.Handle, (nuint)index);

    public void RemoveChild(YogaNode child) => yoga.YGNodeRemoveChild(this.Handle, child.Handle);

    public void Clear() => yoga.YGNodeRemoveAllChildren(this.Handle);

    #endregion

    #region Style

    public YGDirection Direction
    {
        get => yoga.YGNodeStyleGetDirection(this.Handle);
        set =>  yoga.YGNodeStyleSetDirection(this.Handle, value);
    }

    public FlexDirection FlexDirection
    {
        get => (FlexDirection)yoga.YGNodeStyleGetFlexDirection(this.Handle);
        set => yoga.YGNodeStyleSetFlexDirection(this.Handle, (YGFlexDirection)value);
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
                    yoga.YGNodeStyleSetFlex(this.Handle, value.Value);
                    break;
            }
        }
    }

    public YogaValue MarginLeft
    {
        get => yoga.YGNodeStyleGetMargin(this.Handle, YGEdge.YGEdgeLeft);
        set => this.SetStyleMargin(YGEdge.YGEdgeLeft, value);
    }

    public YogaValue MarginTop
    {
        get => yoga.YGNodeStyleGetMargin(this.Handle, YGEdge.YGEdgeTop);
        set => this.SetStyleMargin(YGEdge.YGEdgeTop, value);
    }

    public YogaValue MarginRight
    {
        get => yoga.YGNodeStyleGetMargin(this.Handle, YGEdge.YGEdgeRight);
        set => this.SetStyleMargin(YGEdge.YGEdgeRight, value);
    }

    public YogaValue MarginBottom
    {
        get => yoga.YGNodeStyleGetMargin(this.Handle, YGEdge.YGEdgeBottom);
        set => this.SetStyleMargin(YGEdge.YGEdgeBottom, value);
    }

    public YogaValue MarginStart
    {
        get => yoga.YGNodeStyleGetMargin(this.Handle, YGEdge.YGEdgeStart);
        set => this.SetStyleMargin(YGEdge.YGEdgeStart, value);
    }

    public YogaValue MarginEnd
    {
        get => yoga.YGNodeStyleGetMargin(this.Handle, YGEdge.YGEdgeEnd);
        set => this.SetStyleMargin(YGEdge.YGEdgeEnd, value);
    }

    public YogaValue MarginHorizontal
    {
        get => yoga.YGNodeStyleGetMargin(this.Handle, YGEdge.YGEdgeHorizontal);
        set => this.SetStyleMargin(YGEdge.YGEdgeHorizontal, value);
    }

    public YogaValue MarginVertical
    {
        get => yoga.YGNodeStyleGetMargin(this.Handle, YGEdge.YGEdgeVertical);
        set => this.SetStyleMargin(YGEdge.YGEdgeVertical, value);
    }

    public YogaValue Margin
    {
        get => yoga.YGNodeStyleGetMargin(this.Handle, YGEdge.YGEdgeAll);
        set => this.SetStyleMargin(YGEdge.YGEdgeAll, value);
    }

    private void SetStyleMargin(YGEdge edge, YogaValue value)
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
