using System;
using System.Windows.Forms;
using LowLevelHooking;

namespace WinForms
{
    public static class Program
    {
        public static GlobalKeyboardHook GlobalKeyboardHook { get; private set; }
        
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Windows' low level input hooks post messages to the thread's message loop,
            // so the lifetime of the hook may as well be the lifetime of the message loop.
            // The events will not fire without pumping messages.
            // If you weren't using Application.Run (or WPF's equivalent), you'd have to roll your own message loop.
            using (GlobalKeyboardHook = new GlobalKeyboardHook())
            {
                Application.Run(new MainView());
            }
        }
    }
}
