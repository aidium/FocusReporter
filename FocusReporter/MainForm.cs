using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace FocusReporter
{
    public partial class MainForm : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetActiveWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int GetWindowText(IntPtr hWnd, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hwnd, out uint lpdwProcessId);

        private const int SnapDist = 100;
        private Size oldSize;
        private bool snapped = false;
        private bool oldState = false;
        private int oldLeft;

        private Timer timer;

        public MainForm()
        {
            InitializeComponent();

            // Start poll timer
            timer = new Timer();
            timer.Tick += timer_Tick;
            timer.Interval = 250;
            timer.Start();
        }

        /// <summary>
        /// Check if we is close enuff to snapp.
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="edge"></param>
        /// <returns></returns>
        private bool DoSnap(int pos, int edge)
        {
            int delta = pos - edge;
            return delta > 0 && delta <= SnapDist;
        }

        /// <summary>
        /// Overide the resize event, triggerd by move of the window too.
        /// 
        /// This method dose the snapping check, and window resize and restore handeling when snapping.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            Screen scn = Screen.FromPoint(this.Location);
            if (DoSnap(this.Top, scn.WorkingArea.Top))
            {
                snapped = true;
                this.Top = scn.WorkingArea.Top;
            }
            else if (DoSnap(scn.WorkingArea.Bottom, this.Bottom))
            {
                snapped = true;
                this.Top = scn.WorkingArea.Bottom - this.Height;
            }
            else
            {
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                if (snapped)
                {
                    Size = oldSize;
                    Left = oldLeft;
                }
                snapped = false;
            }

            if (snapped && !oldState)
            {
                oldSize = Size;
                Size = new System.Drawing.Size(scn.Bounds.Width, oldSize.Height);
                oldLeft = Left;
                Left = 0;
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            }
            oldState = snapped;
        }

        /// <summary>
        /// The triggered tick from the timer. This method checks with process
        /// that has focus and digsout som information about it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            String result = "NO INFO";
            IntPtr hWnd = GetForegroundWindow();
            uint pid;
            uint tid = GetWindowThreadProcessId(hWnd, out pid);
            try
            {
                Process p = Process.GetProcessById((int)pid);
                result = p.MainModule.FileName;
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            SetActiveWindowName(result, pid, tid);
        }

        /// <summary>
        /// Sets the information to the labels.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pid"></param>
        /// <param name="tid"></param>
        private delegate void SetActiveWindowNameDelegate(String name, uint pid, uint tid);
        private void SetActiveWindowName(String name, uint pid, uint tid)
        {
            if (InvokeRequired)
            {
                SetActiveWindowNameDelegate d = new SetActiveWindowNameDelegate(SetActiveWindowName);
                this.BeginInvoke(d, name);
                return;
            }
            activeWindowLabel.Text = name;
            threadIdLabel.Text = "Thread id: " + tid;
            processIdLabel.Text = "Process id: " + pid;
        }

        /// <summary>
        /// Stop the timer and do cleanup when closing the window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
        }
    }
}
