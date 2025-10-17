using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace risqq
{
    class InputMonitorService
    {
        public bool isTracking;
        private IKeyboardMouseEvents m_GlobalHook; 
        public event EventHandler InputDetected;

        private void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
        {
            InputDetected?.Invoke(this, EventArgs.Empty);
        }

        private void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e)
        {
            InputDetected?.Invoke(this, EventArgs.Empty);
        }

        public void StartMonitoring()
        {
            isTracking = true;
            m_GlobalHook = Hook.GlobalEvents();

            m_GlobalHook.MouseDownExt += GlobalHookMouseDownExt;
            m_GlobalHook.KeyPress += GlobalHookKeyPress;
        }

        public void StopMonitoring()
        {
            isTracking = false;
            m_GlobalHook.MouseDownExt -= GlobalHookMouseDownExt;
            m_GlobalHook.KeyPress -= GlobalHookKeyPress;

            m_GlobalHook.Dispose();
        }
    }
}
