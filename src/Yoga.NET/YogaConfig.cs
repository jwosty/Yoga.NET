using System;
using JetBrains.Annotations;
using Yoga.NET.Interop;

namespace Yoga.NET;

/// <summary>
/// Contains a set of configuration options. The configuration may be applied to
/// multiple nodes (i.e. a single global config), or can be applied more
/// granularly per-node.
/// </summary>
[PublicAPI]
public unsafe class YogaConfig : IDisposable
{
    private bool _disposed;
    private bool _ownsHandle;

    public YGConfig* Handle { get; }

    public YogaConfig(YGConfig* configHandle, bool ownsHandle = true)
    {
        if (configHandle is null)
        {
            throw new ArgumentNullException(nameof(configHandle), $"Native {nameof(YGConfig)} instance handle cannot be null.");
        }
        this.Handle = configHandle;
        this._ownsHandle = ownsHandle;
    }

    /// <summary>
    /// Creates a default set of configuration options.
    /// </summary>
    public YogaConfig() : this(yoga.YGConfigNew()) { }

    public void Dispose(bool disposing)
    {
        if (!this._disposed)
        {
            if (disposing)
            {
                // Dispose managed state (managed objects).
            }

            // Free unmanaged resources.
            if (this._ownsHandle)
            {
                yoga.YGConfigFree(this.Handle);
            }

            this._disposed = true;
        }
    }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~YogaConfig()
    {
        this.Dispose(false);
    }

    public static YogaConfig Default => new YogaConfig(yoga.YGConfigGetDefault(), false);

    /// <summary>
    /// Yoga by default creates new nodes with style defaults different from flexbox
    /// on web (e.g. <see cref="FlexDirection.Column"/> and <see cref="Position.Relative"/>).
    /// <see cref="UseWebDefaults"/> instructs Yoga to instead use a default style consistent
    /// with the web.
    /// </summary>
    public bool UseWebDefaults
    {
        get => yoga.YGConfigGetUseWebDefaults(this.Handle) != 0;
        set => yoga.YGConfigSetUseWebDefaults(this.Handle, (byte)(value ? 1 : 0));
    }

    /// <summary>
    ///     Yoga will by default round final layout positions and dimensions to the
    ///     nearest point. <see cref="PointScaleFactor"/> controls the density of the grid used for
    ///     layout rounding (e.g. to round to the closest display pixel).
    /// </summary>
    /// <remarks>
    /// May be set to 0.0f to avoid rounding the layout results.
    /// </remarks>
    public float PointScaleFactor
    {
        get => yoga.YGConfigGetPointScaleFactor(this.Handle);
        set => yoga.YGConfigSetPointScaleFactor(this.Handle, value);
    }

}
