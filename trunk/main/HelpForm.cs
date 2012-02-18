using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace EgidaBackup
{
	public partial class HelpForm : Form
	{
		public static HelpForm DialogForm;

		public HelpForm()
		{
			InitializeComponent();
			webBrowser1.Navigate(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"help\index.html"));
		}

		public static void Dialog()
		{
			if (DialogForm == null)
			{
				DialogForm = new HelpForm();
				DialogForm.Show();
			}
			else
				DialogForm.BringToFront();
		}

		private void HelpForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			DialogForm = null;
		}
	}
}
