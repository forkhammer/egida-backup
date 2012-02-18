using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EgidaBackup
{
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			InitializeComponent();
			label3.Text = Environment.OSVersion.VersionString;
		}

		public static void Dialog()
		{
			AboutForm Form = new AboutForm();
			Form.ShowDialog();
			Form.Dispose();
		}

		private void bClose_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
