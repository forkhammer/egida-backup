using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UpdateProgram
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			string[] Params = Environment.GetCommandLineArgs();
			if (Params.Length >= 2 && Params[1] == "--check")
			{
				if (!UpdateForm.UpdateInstalled())
				{
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);
					UpdateForm F = new UpdateForm();
					F.Show();
					F.BeginInstallProgram();
					if (!F.CancelAll)
						Application.Run(F);
				}
			}
			else
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				UpdateForm F = new UpdateForm();
				F.Show();
				F.BeginUpdateProgram();
				if (!F.CancelAll)
					Application.Run(F);
			}
			
		}
	}
}
