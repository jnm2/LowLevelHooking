using System;

namespace LowLevelHooking
{
    /// <summary>
    /// Provides data for the <see cref="GlobalKeyboardHook.KeyDownOrUp"/> event.
    /// </summary>
    public sealed class GlobalKeyboardHookEventArgs : EventArgs
    {
        /// <summary>
        /// If false, the key is firing. If true, the key is being released.
        /// </summary>
        public bool IsUp { get; }

        /// <summary>
        /// The virtual key code without modifiers.
        /// </summary>
        public VirtualKey KeyCode { get; }

        /// <summary>
        /// The keyboard scan code.
        /// </summary>
        public uint ScanCode { get; }

        /// <summary>
        /// Indicates whether the Alt modifier key is down.
        /// </summary>
        public bool Alt { get; }

        /// <summary>
        /// The elapsed time, in milliseconds, from the time the system was started to the time the hook message was placed in the thread's message queue. 
        /// </summary>
        public uint Time { get; }

        /// <summary>
        /// Indicates whether this key event was injected by a process or received from an input device.
        /// </summary>
        public GlobalKeyboardEventSource Source { get; }

        /// <summary>
        /// If set, prevents the key event from having any further effect on the system.
        /// </summary>
        public bool Handled { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalKeyboardHookEventArgs"/> class.
        /// </summary>
        public GlobalKeyboardHookEventArgs(bool isUp, VirtualKey keyCode, uint scanCode, bool alt, uint time, GlobalKeyboardEventSource source)
        {
            IsUp = isUp;
            KeyCode = keyCode;
            ScanCode = scanCode;
            Alt = alt;
            Time = time;
            Source = source;
        }
    }
}