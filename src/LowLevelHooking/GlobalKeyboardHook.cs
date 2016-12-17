using System;
using System.ComponentModel;
using static LowLevelHooking.NativeMethods;

namespace LowLevelHooking
{
    /// <summary>
    /// A global low-level keyboard hook which raises events using the message loop of the thread on which it was created.
    /// </summary>
    public sealed class GlobalKeyboardHook : IDisposable
    {
        private readonly LowLevelHookSafeHandle handle;
        private LowLevelKeyboardProc callbackGCKeepAliveDelegate;

        /// <summary>
        /// Raised when any key fires or is released.
        /// </summary>
        public event EventHandler<GlobalKeyboardHookEventArgs> KeyDownOrUp;

        /// <summary>
        /// Installs a global low-level keyboard hook which raises events using the current thread's message loop.
        /// </summary>
        public GlobalKeyboardHook()
        {
            callbackGCKeepAliveDelegate = HookCallback;
            handle = SetWindowsHookEx(WH.KEYBOARD_LL, callbackGCKeepAliveDelegate, IntPtr.Zero, 0);
            if (handle.IsInvalid) throw new Win32Exception();
        }

        /// <summary>
        /// Uninstalls the hook.
        /// </summary>
        public void Dispose()
        {
            handle.Dispose();
            callbackGCKeepAliveDelegate = null;
        }


        
        private IntPtr HookCallback(int nCode, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam)
        {
            if (nCode >= 0)
            {
                var e = new GlobalKeyboardHookEventArgs(
                    (lParam.flags & LLKHF.UP) != 0,
                    lParam.vkCode,
                    lParam.scanCode,
                    (lParam.flags & LLKHF.ALTDOWN) != 0,
                    lParam.time,
                    (lParam.flags & LLKHF.INJECTED) == 0 ? GlobalKeyboardEventSource.InputDevice :
                    (lParam.flags & LLKHF.LOWER_IL_INJECTED) == 0 ? GlobalKeyboardEventSource.InjectedByLowerIntegrityLevelProcess :
                    GlobalKeyboardEventSource.InjectedByProcess);

                KeyDownOrUp?.Invoke(null, e);

                if (e.Handled) return (IntPtr)1;
            }

            return CallNextHookEx(handle, nCode, wParam, ref lParam);
        }
    }
}