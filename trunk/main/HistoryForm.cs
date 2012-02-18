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
	public partial class HistoryForm : Form
	{
		public HistoryForm()
		{
			InitializeComponent();
			try
			{
				richHistory.LoadFile(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "history.rtf"));
			}
			catch { }
		}

		public static void Dialog()
		{
			HistoryForm Dlg = new HistoryForm();
			Dlg.ShowDialog();
			Dlg.Dispose();
		}
	}
}
