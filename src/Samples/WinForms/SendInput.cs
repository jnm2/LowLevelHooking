using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using LowLevelHooking;

namespace WinForms
{
    public static class NativeInput
    {
        public static void SendKeys(IReadOnlyList<VirtualKeyEvent> keys)
        {
            if (keys == null || keys.Count == 0) return;

            var inputArray = new INPUT[keys.Count];

            for (var i = 0; i < inputArray.Length; i++)
                inputArray[i] = new INPUT(new KEYBDINPUT((ushort)keys[i].Code, keys[i].IsUp));
            
            if (SendInput(inputArray.Length, inputArray, Marshal.SizeOf(typeof(INPUT))) == 0)
                throw new Win32Exception();
        }


        #region Native methods
        #pragma warning disable 169
        #pragma warning disable 649
        #pragma warning disable 414
        // ReSharper disable InconsistentNaming
        // ReSharper disable PrivateFieldCanBeConvertedToLocalVariable
        // ReSharper disable NotAccessedField.Local

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(int nInputs, [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs, int cbSize);
        
        private struct INPUT
        {
            private readonly InputType type;
            private readonly InputUnion union;

            public INPUT(KEYBDINPUT ki)
            {
                type = InputType.KEYBOARD;
                union = new InputUnion(ki);
            }
        }

        private enum InputType : uint
        {
            KEYBOARD = 1
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct InputUnion
        {
            [FieldOffset(0)]
            private readonly MOUSEINPUT mi;
            [FieldOffset(0)]
            private readonly KEYBDINPUT ki;

            public InputUnion(KEYBDINPUT ki) : this()
            {
                this.ki = ki;
            }
        }

        private struct KEYBDINPUT
        {
            private readonly ushort wVk;
            private readonly ushort wScan;
            private readonly KEYEVENTF dwFlags;
            private readonly uint time;
            private readonly UIntPtr dwExtraInfo;

            public KEYBDINPUT(ushort wVk, bool isUp) 
            {
                this.wVk = wVk;
                wScan = 0;
                dwFlags = isUp ? KEYEVENTF.KEYUP : 0;
                time = 0;
                dwExtraInfo = UIntPtr.Zero;
            }
        }

        private enum KEYEVENTF : uint
        {
            KEYUP = 2
        }

        // Included simply for setting the size of InputUnion
        private struct MOUSEINPUT
        {
            private readonly int dx;
            private readonly int dy;
            private readonly int mouseData;
            private readonly uint dwFlags;
            private readonly uint time;
            private readonly UIntPtr dwExtraInfo;
        }

        #pragma warning restore 169
        #pragma warning restore 649
        #pragma warning restore 414
        // ReSharper restore InconsistentNaming
        // ReSharper restore PrivateFieldCanBeConvertedToLocalVariable
        // ReSharper restore NotAccessedField.Local
        #endregion
    }
}
