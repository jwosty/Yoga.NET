using System;
using JetBrains.Annotations;
using Yoga.NET.Interop;

namespace Yoga.NET;

[PublicAPI]
public unsafe class YogaNode : IDisposable
{
    private bool _disposed;

    public YGNode* Handle { get; }

    private YogaConfig _config;

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
        get => this._config;
        set
        {
            using var oldConfig = this._config;
            this._config = value;
        }
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
