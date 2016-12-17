using System;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming
#pragma warning disable 649

namespace LowLevelHooking
{
    internal static class NativeMethods
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern LowLevelHookSafeHandle SetWindowsHookEx(WH idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr CallNextHookEx(LowLevelHookSafeHandle hhk, int nCode, IntPtr wParam, [In] ref KBDLLHOOKSTRUCT lParam);

        public sealed class LowLevelHookSafeHandle : SafeHandle
        {
            private LowLevelHookSafeHandle() : base(IntPtr.Zero, true)
            {
            }

            [DllImport("user32.dll", SetLastError = true)]
            private static extern bool UnhookWindowsHookEx(IntPtr hhk);

            protected override bool ReleaseHandle() => UnhookWindowsHookEx(handle);

            public override bool IsInvalid => handle == IntPtr.Zero;
        }

        public enum WH
        {
            KEYBOARD_LL = 13
        }

        public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, [In] ref KBDLLHOOKSTRUCT lParam);

        public struct KBDLLHOOKSTRUCT
        {
            public readonly uint vkCode;
            public readonly uint scanCode;
            public readonly LLKHF flags;
            public readonly uint time;
            public readonly UIntPtr dwExtraInfo;
        }

        [Flags]
        public enum LLKHF : uint
        {
            EXTENDED = 0x01,
            LOWER_IL_INJECTED = 0x2,
            INJECTED = 0x10,
            ALTDOWN = 0x20,
            UP = 0x80
        }
    }
}