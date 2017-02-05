using System;
using System.Collections.Generic;
using System.Linq;
using LowLevelHooking;

namespace WinForms
{
    public sealed class HotstringHandler
    {
        private int nextSearchIndex;

        private IReadOnlyList<VirtualKeyEvent> search = Array.Empty<VirtualKeyEvent>();

        public IReadOnlyList<VirtualKeyEvent> Search
        {
            get { return search; }
            set
            {
                value = value?.ToArray() ?? Array.Empty<VirtualKeyEvent>();
                if (search.SequenceEqual(value)) return;
                search = value;
                CancelHotstring();
            }
        }

        private IReadOnlyList<VirtualKeyEvent> replace = Array.Empty<VirtualKeyEvent>();

        public IReadOnlyList<VirtualKeyEvent> Replace
        {
            get { return replace; }
            set
            {
                if (replace.SequenceEqual(value)) return;
                replace = value;
                CancelHotstring();
            }
        }


        private bool enabled;

        public bool Enabled
        {
            get { return enabled; }
            set
            {
                if (enabled == value) return;
                enabled = value;
                CancelHotstring();
            }
        }

        public void ProcessKeyEvent(GlobalKeyboardHookEventArgs e)
        {
            if (isSendingKeys || !enabled || search.Count == 0) return;
            
            if (e.KeyCode == search[nextSearchIndex].Code && e.IsUp == search[nextSearchIndex].IsUp)
            {
                e.Handled = true;
                nextSearchIndex++;
                if (nextSearchIndex == search.Count)
                {
                    nextSearchIndex = 0;
                    SendKeys(replace);
                }
            }
            else
            {
                CancelHotstring();
            }
        }

        private void CancelHotstring()
        {
            if (nextSearchIndex == 0) return;
            var keysToSend = search.Take(nextSearchIndex).ToList();
            nextSearchIndex = 0;

            SendKeys(keysToSend);
        }

        private bool isSendingKeys;
        private void SendKeys(IReadOnlyList<VirtualKeyEvent> keys)
        {
            isSendingKeys = true;
            try
            {
                NativeInput.SendKeys(keys);
            }
            finally
            {
                isSendingKeys = false;
            }
        }
    }
}
