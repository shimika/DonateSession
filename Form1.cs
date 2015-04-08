using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DonateSession {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		int count = 0;
		private void timer1_Tick(object sender, EventArgs e) {
			this.Text = (++count).ToString();
			IntPtr windowPtr = FindWindowByCaption(IntPtr.Zero, "후원 세션");
			if (windowPtr != IntPtr.Zero) {
				SetWindowPos(windowPtr, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOACTIVATE | SWP_HIDEWINDOW);
			}
			windowPtr = IntPtr.Zero;
		}

		#region WIN32 API

		[DllImport("user32.dll", SetLastError = true)]
		static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		/// <summary>
		/// Find window by Caption only. Note you must pass IntPtr.Zero as the first parameter.
		/// </summary>
		[DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
		static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll")]
		static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

		static readonly IntPtr HWND_TOPMOST = new IntPtr(-2);
		const UInt32 SWP_NOSIZE = 0x0001;
		const UInt32 SWP_NOMOVE = 0x0002;
		const UInt32 SWP_SHOWWINDOW = 0x0040;
		const UInt32 SWP_NOACTIVATE = 0x0010;
		const UInt32 SWP_HIDEWINDOW = 0x0080;

		const UInt32 WM_CLOSE = 0x0010;

		#endregion

		private void toolStripMenuItem1_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void Form1_Load(object sender, EventArgs e) {
			this.Hide();
		}
	}
}
