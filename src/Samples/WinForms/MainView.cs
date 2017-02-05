using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LowLevelHooking;

namespace WinForms
{
    // Normally I'd use MVVM with Windows Forms, but to keep the sample focused:
    public partial class MainView : Form
    {
        private readonly HotstringHandler hotstringHandler = new HotstringHandler();
        private readonly List<VirtualKeyEvent> hotstringSearch = new List<VirtualKeyEvent>();
        private readonly List<VirtualKeyEvent> hotstringReplace = new List<VirtualKeyEvent>();

        public MainView()
        {
            InitializeComponent();
            Program.GlobalKeyboardHook.KeyDownOrUp += GlobalKeyboardHook_KeyDownOrUp;
            Disposed += MainView_Disposed;
        }

        private void MainView_Disposed(object sender, EventArgs e)
        {
            // This isn't strictly necessary because MainView does not have a shorter lifetime
            // than the whole application, but just in case something should change...
            // Unsubscribing allows the garbage collector to free everything associated with MainView
            // and of course, stops doing unnecessary work on each keypress system-wide.
            Program.GlobalKeyboardHook.KeyDownOrUp -= GlobalKeyboardHook_KeyDownOrUp;
        }

        private void GlobalKeyboardHook_KeyDownOrUp(object sender, GlobalKeyboardHookEventArgs e)
        {
            logTextBox.AppendText($"{Environment.NewLine}{e.KeyCode} {(e.IsUp ? "up" : "down")}");


            if (hotstringSearchTextBox.Focused || hotstringReplacementTextBox.Focused)
            {
                hotstringDisableButton.Checked = true;

                if (hotstringSearchTextBox.Focused)
                {
                    HandleHotkeyInput(hotstringSearchTextBox, e.KeyCode, e.IsUp, hotstringSearch);
                    hotstringHandler.Search = hotstringSearch;
                }
                else if (hotstringReplacementTextBox.Focused)
                {
                    HandleHotkeyInput(hotstringReplacementTextBox, e.KeyCode, e.IsUp, hotstringReplace);
                    hotstringHandler.Replace = hotstringReplace;
                }
            }
            else
            {
                hotstringHandler.ProcessKeyEvent(e);
            }
        }
        private void hotstringEnableButton_CheckedChanged(object sender, EventArgs e)
        {
            hotstringHandler.Enabled = hotstringEnableButton.Checked;
        }

        private static void HandleHotkeyInput(TextBox textBox, VirtualKey keyCode, bool isUp, List<VirtualKeyEvent> keyList)
        {
            if (textBox.SelectionStart == 0 && textBox.SelectionLength == textBox.TextLength)
            {
                keyList.Clear();
                textBox.Clear();
            }

            keyList.Add(new VirtualKeyEvent(keyCode, isUp));

            // Write some pseudo-markup showing the nesting (for example, <LeftShift><A/></LeftShift>)
            if (keyList.Count != 1 && keyList[keyList.Count - 2].Code == keyCode && !keyList[keyList.Count - 2].IsUp)
            {
                var prevText = textBox.Text;
                textBox.Text = isUp
                    ? prevText.Substring(0, prevText.Length - 1) + "/>"
                    : prevText.Substring(0, prevText.Length - 1) + $"/><{keyCode}>";

                textBox.Select(textBox.TextLength, 0);
            }
            else
            {
                textBox.AppendText($"{(isUp ? "</" : "<")}{keyCode}>");
            }
        }
    }
}
