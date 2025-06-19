// ReSharper disable InconsistentNaming
using System;

namespace Yoga.NET.Interop;

/// <summary>
/// Attempts to mirror the C++ std::vector type (will NOT work for vector&lt;bool&gt;, which is a special case). Also,
/// I am not sure if the memory layout of std::vector is even guaranteed... so we are just making the assumption that
/// it looks like what libc++ (i.e. the LLVM/clang C++ std lib implementation) has.
/// </summary>
public unsafe struct CppVector<T> where T : unmanaged
{
    private IntPtr __begin_;
    private IntPtr __end_;
    private T* __end_cap_;
}
