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

    #region Style

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
