using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace EgidaBackup
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
		/// 
		[DllImport("User32.dll")]
		static extern IntPtr FindWindow(string cl, string t);
		[DllImport("user32.dll")]
		static extern bool ShowWindow(IntPtr handle, int cmdshow);

        public static OptionsClass Options;

        [STAThread]
        static void Main()
        {
			//проверка на запуск второй копии
            Process[] Procs = Process.GetProcessesByName("egidabackup");
            if (Procs.Length <= 1)
            {
                IntPtr SecondForm = FindWindow(null, "Egida Backup");
                if (SecondForm == (IntPtr)0)
                {
                    Options = new OptionsClass();
                    Options.Load(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "options.xml"));
                    //проверка обновления
                    if (CheckUpdate())
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new MainForm());
                    }
                }
                else
                {
                    ShowWindow(SecondForm, 9);
                }
            }
            
        }

		static bool CheckUpdate()
		{
			bool res = true;
			try
			{
				XmlDocument Doc = new XmlDocument();
				Doc.Load(Path.GetDirectoryName(Application.ExecutablePath) + @"\update.xml");
				if (Doc.DocumentElement != null)
					if (Doc.DocumentElement.Name == "Configuration")
					{
						XmlNode Installed = Doc.DocumentElement.GetElementsByTagName("Installed")[0];
						if (Installed != null)
							try
							{
								res = bool.Parse(Installed.ChildNodes[0].Value);
							}
							catch { }
					}
			}
			catch { }
			if (!res)
			{
				Process P = new Process();
				try
				{
					P.StartInfo = new ProcessStartInfo(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "updateprogram.exe"), "--check");
					P.Start();
				}
				catch { }
				P.Dispose();
			}
			return res;
		}
    }
}
