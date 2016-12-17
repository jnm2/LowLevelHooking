namespace LowLevelHooking
{
    /// <summary>
    /// Enumerates the possible sources of low level key events.
    /// </summary>
    public enum GlobalKeyboardEventSource
    {
        /// <summary>
        /// The key event was reported by an input device.
        /// </summary>
        InputDevice = 0,

        /// <summary>
        /// The key event was simulated by a process.
        /// </summary>
        InjectedByProcess,

        /// <summary>
        /// The key event was simulated by a less-trusted process than the current process.
        /// </summary>
        InjectedByLowerIntegrityLevelProcess
    }
}