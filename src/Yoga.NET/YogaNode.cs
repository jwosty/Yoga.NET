using JetBrains.Annotations;
using Yoga.NET.Interop;

namespace Yoga.NET;

[PublicAPI]
public unsafe class YogaNode : IDisposable
{
    private YGNodeHandle _ygNodeHandle;
    private bool _disposed;

    public YogaNode()
    {
        this._ygNodeHandle = new YGNodeHandle(yoga.YGNodeNew());
        if (this._ygNodeHandle.IsInvalid)
            throw new InvalidOperationException("Failed to allocate native memory");
    }

    public void CalculateLayout(float availableWidth = yoga.YGUndefined, float availableHeight = yoga.YGUndefined, YGDirection? ownerDirection = null)
    {
        yoga.YGNodeCalculateLayout(this._ygNodeHandle.DangerousGetTypedHandle(), availableWidth, availableHeight,
            ownerDirection ?? yoga.YGNodeStyleGetDirection(this._ygNodeHandle.DangerousGetTypedHandle()));
    }

    public void Dispose(bool disposing)
    {
        if (!this._disposed)
        {
            if (disposing)
            {
                // Dispose managed state (managed objects).
                this._ygNodeHandle.Dispose();
            }

            // Free unmanaged resources.

            this._disposed = true;
        }
    }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    // public float Width
    // {
    //     get => yoga.YGNodeStyleGetWidth(this._ygNodeHandle.DangerousGetTypedHandle());
    // }
}
