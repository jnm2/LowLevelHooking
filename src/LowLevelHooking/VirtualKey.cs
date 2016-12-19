namespace LowLevelHooking
{
    /// <summary>
    /// Windows virtual key codes
    /// </summary>
    public enum VirtualKey : byte
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

        /* Mouse buttons can be used for GetAsyncState but will never be reported from a keyboard hook
        MouseLeftButton = 0x01,
        MouseRightButton = 0x02, 
        MouseMiddleButton = 0x04,
        MouseXButton1 = 0x05,
        MouseXButton2 = 0x06,
        */

        /// <summary>
        /// Ctrl+Break causes <see cref="Break"/> rather than <see cref="Pause"/>.
        /// </summary>
        Break = 0x03,

        Backspace = 0x8,
        Tab = 0x9,

        /// <summary>
        /// Caused by pressing numpad 5 when Num Lock is off.
        /// </summary>
        Clear = 0xC,
        Enter = 0xD,
        
        /* These are translated to left and right virtual keys before being hooked.
        Shift = 0x10,
        Control = 0x11,
        Alt = 0x12,
        */

        /// <summary>
        /// The Pause key. (Ctrl+Break is reported as <see cref="Break"/>.)
        /// </summary>
        Pause = 0x13,

        CapsLock = 0x14,

        /// <summary>
        /// Kana/Hangul mode
        /// </summary>
        ImeKanaHangul = 0x15,
        /// <summary>
        /// Junja mode
        /// </summary>
        ImeJunja = 0x17,
        /// <summary>
        /// Final mode
        /// </summary>
        ImeFinal = 0x18,
        /// <summary>
        /// Hanja/Kanji mode
        /// </summary>
        ImeHanjaKanji = 0x19,

        Escape = 0x1B,

        ImeConvert = 0x1C,
        ImeNonConvert = 0x1D,
        ImeAccept = 0x1E,
        ImeModeChange = 0x1F,

        Spacebar = 0x20,
        PageUp = 0x21,
        PageDown = 0x22,
        End = 0x23,
        Home = 0x24,
        LeftArrow = 0x25,
        UpArrow = 0x26,
        RightArrow = 0x27,
        DownArrow = 0x28,
        Select = 0x29,
        Print = 0x2A,
        Execute = 0x2B,
        PrintScreen = 0x2C,
        Insert = 0x2D,
        Delete = 0x2E,
        Help = 0x2F,

        D0 = 0x30,
        D1 = 0x31,
        D2 = 0x32,
        D3 = 0x33,
        D4 = 0x34,
        D5 = 0x35,
        D6 = 0x36,
        D7 = 0x37,
        D8 = 0x38,
        D9 = 0x39,

        A = 0x41,
        B = 0x42,
        C = 0x43,
        D = 0x44,
        E = 0x45,
        F = 0x46,
        G = 0x47,
        H = 0x48,
        I = 0x49,
        J = 0x4A,
        K = 0x4B,
        L = 0x4C,
        M = 0x4D,
        N = 0x4E,
        O = 0x4F,
        P = 0x50,
        Q = 0x51,
        R = 0x52,
        S = 0x53,
        T = 0x54,
        U = 0x55,
        V = 0x56,
        W = 0x57,
        X = 0x58,
        Y = 0x59,
        Z = 0x5A,

        LeftWindows = 0x5B,
        RightWindows = 0x5C,
        ContextMenu = 0x5D,
        
        Sleep = 0x5F,
        NumPad0 = 0x60,
        NumPad1 = 0x61,
        NumPad2 = 0x62,
        NumPad3 = 0x63,
        NumPad4 = 0x64,
        NumPad5 = 0x65,
        NumPad6 = 0x66,
        NumPad7 = 0x67,
        NumPad8 = 0x68,
        NumPad9 = 0x69,
        Multiply = 0x6A,
        Add = 0x6B,
        Separator = 0x6C,
        Subtract = 0x6D,
        Decimal = 0x6E,
        Divide = 0x6F,
        F1 = 0x70,
        F2 = 0x71,
        F3 = 0x72,
        F4 = 0x73,
        F5 = 0x74,
        F6 = 0x75,
        F7 = 0x76,
        F8 = 0x77,
        F9 = 0x78,
        F10 = 0x79,
        F11 = 0x7A,
        F12 = 0x7B,
        F13 = 0x7C,
        F14 = 0x7D,
        F15 = 0x7E,
        F16 = 0x7F,
        F17 = 0x80,
        F18 = 0x81,
        F19 = 0x82,
        F20 = 0x83,
        F21 = 0x84,
        F22 = 0x85,
        F23 = 0x86,
        F24 = 0x87,

        NumLock = 0x90,
        ScrollLock = 0x91,

        // 0x92 to 0x96 conflict depending on which keyboard OEM

        LeftShift = 0xA0,
        RightShift = 0xA1,
        LeftControl = 0xA2,
        RightControl = 0xA3,
        LeftAlt = 0xA4,
        RightAlt = 0xA5,
        BrowserBack = 0xA6,
        BrowserForward = 0xA7,
        BrowserRefresh = 0xA8,
        BrowserStop = 0xA9,
        BrowserSearch = 0xAA,
        BrowserFavorites = 0xAB,
        BrowserHome = 0xAC,
        VolumeMute = 0xAD,
        VolumeDown = 0xAE,
        VolumeUp = 0xAF,
        MediaNext = 0xB0,
        MediaPrevious = 0xB1,
        MediaStop = 0xB2,
        MediaPlay = 0xB3,
        LaunchMail = 0xB4,
        LaunchMediaSelect = 0xB5,
        LaunchApp1 = 0xB6,
        LaunchApp2 = 0xB7,

        /// <summary>
        /// OEM specific. For US standard, ;:
        /// </summary>
        Oem1 = 0xBA,
        /// <summary>
        /// OEM specific. For US standard, +
        /// </summary>
        OemPlus = 0xBB,
        /// <summary>
        /// OEM specific. For US standard, ,
        /// </summary>
        OemComma = 0xBC,
        /// <summary>
        /// OEM specific. For US standard, -
        /// </summary>
        OemMinus = 0xBD,
        /// <summary>
        /// OEM specific. For US standard, .
        /// </summary>
        OemPeriod = 0xBE,
        /// <summary>
        /// OEM specific. For US standard, /?
        /// </summary>
        Oem2 = 0xBF,
        /// <summary>
        /// OEM specific. For US standard, `~
        /// </summary>
        Oem3 = 0xC0,

        /// <summary>
        /// OEM specific. For US standard, [{
        /// </summary>
        Oem4 = 0xDB,
        /// <summary>
        /// OEM specific. For US standard, \|
        /// </summary>
        Oem5 = 0xDC,
        /// <summary>
        /// OEM specific. For US standard, ]}
        /// </summary>
        Oem6 = 0xDD,
        /// <summary>
        /// OEM specific. For US standard, '"
        /// </summary>
        Oem7 = 0xDE,
        /// <summary>
        /// OEM specific.
        /// </summary>
        Oem8 = 0xDF,

        /// <summary>
        /// OEM specific. AX key on Japanese AX kbd
        /// </summary>
        OemAX = 0xE1,

        /// <summary>
        /// OEM specific. &lt;> or \| on RT 102-key kbd.
        /// </summary>
        Oem102 = 0xE2,

        // 0xE3-0xE4, 0xE6: single OEM

        ImeProcess = 0xE5,

        /// <summary>
        /// Used to pass Unicode chars as if keystrokes.
        /// </summary>
        Packet = 0xE7,

        // 0xE9-0xF5: single OEM

        Attention = 0xF6,
        CrSel = 0xF7,
        ExSel = 0xF8,
        EraseEndOfFile = 0xF9,
        Play = 0xFA,
        Zoom = 0xFB,
        Pa1 = 0xFD,
        OemClear = 0xFE
    }
}
