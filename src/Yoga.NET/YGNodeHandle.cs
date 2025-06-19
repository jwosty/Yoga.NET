// using System.Runtime.InteropServices;
// using JetBrains.Annotations;
// using Yoga.NET.Interop;
// // ReSharper disable InconsistentNaming
//
// namespace Yoga.NET;
//
// [PublicAPI]
// internal unsafe class YGNodeHandle : SafeHandle
// {
//     private GCHandle _managedNodeHandle;
//
//     private YGNode* typedHandle => (YGNode*)handle;
//
//     public YGNode* DangerousGetTypedHandle() => this.typedHandle;
//
//     public YGNodeHandle()
//         : base(IntPtr.Zero, true)
//     {
//     }
//
//     public YGNodeHandle(YGNode* handle) : base((IntPtr)handle, true) { }
//
//     public override bool IsInvalid => this.handle == IntPtr.Zero;
//
//     protected override bool ReleaseHandle()
//     {
//         this.ReleaseManaged();
//         if (!this.IsInvalid)
//         {
//             yoga.YGNodeFree(this.typedHandle);
//             GC.KeepAlive((object) this);
//         }
//         return true;
//     }
//
//     public void SetContext(YogaNode node)
//     {
//         if (this._managedNodeHandle.IsAllocated)
//             return;
//         this._managedNodeHandle = GCHandle.Alloc((object) node, GCHandleType.Weak);
//         yoga.YGNodeSetContext(this.typedHandle, (void*)GCHandle.ToIntPtr(this._managedNodeHandle));
//     }
//
//     public void ReleaseManaged()
//     {
//         if (!this._managedNodeHandle.IsAllocated)
//             return;
//         this._managedNodeHandle.Free();
//     }
//
//     public static YogaNode? GetManaged(YGNode* unmanagedNodePtr)
//     {
//         if (unmanagedNodePtr is null)
//             return null;
//         if (GCHandle.FromIntPtr((IntPtr)yoga.YGNodeGetContext(unmanagedNodePtr)).Target is YogaNode target)
//             return target;
//         throw new InvalidOperationException("YogaNode is already deallocated");
//     }
// }
