# Low Level Hooking for .NET

[![NuGet](https://img.shields.io/nuget/v/LowLevelHooking.svg)](https://www.nuget.org/packages/LowLevelHooking/1.0.1)
[![Gitter](https://img.shields.io/gitter/room/jnm2/LowLevelHooking.svg)](https://gitter.im/jnm2/LowLevelHooking)

This library is intended to serve as a reference implementation for Windows low
level keyboard hooks. (And mouse hooks, if there is interest.) Very often I see
implementations floating around containing noob mistakes, and let's be honest-
should you actually *have* to roll your own implementation and spend time in the
same pitfalls, just to do something this ordinary? I have, several times over the
years, and I want to contribute back what I believe is the most optimal
implementation. If you spot something that could be done more optimally, please
don't hesitate to [comment](https://github.com/jnm2/LowLevelHooking/issues)!


## Get up and running

 1. Add a [LowLevelHooking](https://www.nuget.org/packages/LowLevelHooking/1.0.1)
    NuGet package reference to your project.

 2. Windows low level hooks communicate with your process by sending a message to
    your thread message pump. That means you'll only be able to receive low level
    notifications while running
    [`Application.Run`](https://msdn.microsoft.com/en-us/library/system.windows.forms.application.run.aspx)
    (already in place if you're using Windows Forms) or
    [`Dispatcher.PushFrame`](https://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.pushframe.aspx)
    (already in place if you're using WPF). SharpDX has
    [`RenderLoop.Run`](https://github.com/sharpdx/SharpDX/blob/master/Source/SharpDX.Desktop/RenderLoop.cs).
    Any UI framework will be running something similar.

    > If you're not running UI at all, for example if you're
      a console app, you'll have to implement your own message loop. This is rare,
      but I do have a .NET Core console app sample planned, so stay tuned.)

    With this in mind, and because you want to create as _few_ hooks as possible
    (read: one), it makes the most logical sense to tie the lifetime of the hook to
    the lifetime of the message loop rather than to a window:

    ```c#    
    public static class Program
    {
        public static GlobalKeyboardHook GlobalKeyboardHook { get; private set; }
        
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            using (GlobalKeyboardHook = new GlobalKeyboardHook())
            {
                Application.Run(new Form1());
            }
        }
    }
    ```
    (See sample [Program.cs](./src/Samples/WinForms/Program.cs))

3. Once that's taken care of, you can subscribe and unsubscribe as needed:

    ```c#
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Program.GlobalKeyboardHook.KeyDownOrUp += GlobalKeyboardHook_KeyDownOrUp;
            Disposed += MainView_Disposed;
        }

        private void MainView_Disposed(object sender, EventArgs e)
        {
            // This isn't strictly necessary since Form1 does not have a shorter lifetime
            // than the whole application, but just in case something should change...
            // Unsubscribing allows the garbage collector to free everything associated with Form1
            // and of course, stops doing unnecessary work on each keypress system-wide.
            Program.GlobalKeyboardHook.KeyDownOrUp -= GlobalKeyboardHook_KeyDownOrUp;
        }

        private void GlobalKeyboardHook_KeyDownOrUp(object sender, GlobalKeyboardHookEventArgs e)
        {
            Debug.WriteLine($"{e.KeyCode} {(e.IsUp ? "up" : "down")}");
        }
    }
    ```
    (See sample [MainView.cs](./src/Samples/WinForms/MainView.cs))

    And that's it!


## Feedback

If you have questions, critiques or contributions, I can't wait to hear from you via
[Gitter](https://gitter.im/jnm2/LowLevelHooking) or 
[GitHub issues](https://github.com/jnm2/LowLevelHooking/issues)!