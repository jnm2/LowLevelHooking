using LowLevelHooking;

namespace WinForms
{
    public struct VirtualKeyEvent
    {
        public VirtualKeyEvent(VirtualKey code, bool isUp)
        {
            Code = code;
            IsUp = isUp;
        }

        public VirtualKey Code { get; }
        public bool IsUp { get; }
    }
}
