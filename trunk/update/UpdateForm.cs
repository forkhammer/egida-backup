using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Net;
using System.Threading;
using ICSharpCode.SharpZipLib.Zip;
using System.Diagnostics;

namespace UpdateProgram
{
	public partial class UpdateForm : Form
	{
		UpdateVersionInfo Current = new UpdateVersionInfo();
		UpdateVersionInfo UpdateInfo = new UpdateVersionInfo();
		object FDownloadResult = null;
		Exception FDownloadError = null;
		public bool CancelAll = false;
		bool InProcess = false;
		byte CountSystem = 1;
		bool StartMainProgram = false;

		public UpdateForm()
		{
			InitializeComponent();
		}

		public void BeginUpdateProgram()
		{
			InProcess = true;
			LoadCurrentInfo();
			if (DownloadVersionInfo())
			{
				if (Current.Version != UpdateInfo.Version)
				{
					if (UpdateInfo.Path != "" && UpdateInfo.Size > 0)
					{
						if (DownloadArchive())
						{
							if (FDownloadResult is string)
							{
								string ArchiveFile = (string)FDownloadResult;
								Current.Version = UpdateInfo.Version;
								Current.Name = UpdateInfo.Name;
								Current.Installed = false;
								Current.SaveToFile(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "update.xml"));
								MessageBox.Show("Перезапустите программу Egida Backup!");
								CancelAll = true;
								/*if (ExtractArchive(ArchiveFile))
								{
									label1.Text = "Обновление завершено";
									this.Text = label1.Text;
									File.Delete(ArchiveFile);
									Current.Version = UpdateInfo.Version;
									Current.SaveToFile(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "update.xml"));
								}
								else
									if (FDownloadError is Exception)
									{
										label1.Text = (FDownloadError as Exception).Message;
										return;
									}
									else
										label1.Text = "Не удалось распаковать обновление";*/
							}
						}
						else
						{
							if (FDownloadError is Exception)
							{
								label1.Text = (FDownloadError as Exception).Message;
								return;
							}
							else
								label1.Text = "Не удалось скачать обновление";
						}
					}
				}
				else
					label1.Text = "Версия программы новейшая";
			}
			else
			{
				if (FDownloadError is Exception)
				{
					MessageBox.Show((FDownloadError as Exception).Message);
					return;
				}
			}
			InProcess = false;
			bCancel.Text = "Закрыть";
			if (CancelAll)
				Close();
		}

		public void BeginInstallProgram()
		{
			InProcess = true;
			LoadCurrentInfo();
			string updatezip =Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), Current.Name+".zip");
			label1.Text = "Установка обновления";
			if (File.Exists(updatezip))
			{
				if (ExtractArchive(updatezip))
				{
					label1.Text = "Обновление завершено";
					this.Text = label1.Text;
					File.Delete(updatezip);
				}
				else
					if (FDownloadError is Exception)
					{
						label1.Text = (FDownloadError as Exception).Message;
						return;
					}
					else
						label1.Text = "Не удалось распаковать обновление";
			}
			else
				label1.Text = "Файл обновления не обнаружен";
			Current.Installed = true;
			Current.SaveToFile(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "update.xml"));
			InProcess = false;
			StartMainProgram = true;
			bCancel.Text = "Закрыть";
		}

		public static bool UpdateInstalled()
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
			return res;
		}

		void LoadCurrentInfo()
		{
			try
			{
				XmlDocument Doc = new XmlDocument();
				Doc.Load(Path.GetDirectoryName(Application.ExecutablePath) + @"\update.xml");
				if (Doc.DocumentElement != null)
					if (Doc.DocumentElement.Name == "Configuration")
					{
						XmlNode Version = Doc.DocumentElement.GetElementsByTagName("Version")[0];
						if (Version != null)
							Current.Version = Version.ChildNodes[0].Value;
						XmlNode ProgramName = Doc.DocumentElement.GetElementsByTagName("Name")[0];
						if (ProgramName != null)
							Current.Name = ProgramName.ChildNodes[0].Value;
						Current.Installed = true;
						XmlNode Installed= Doc.DocumentElement.GetElementsByTagName("Installed")[0];
						if (Installed != null)
							try
							{
								Current.Installed = bool.Parse(Installed.ChildNodes[0].Value);
							}
							catch { }
					}
			}
			catch { };
		}

		bool DownloadVersionInfo()
		{
			FDownloadError = null;
			FDownloadResult = null;
			CountSystem = 1;
			label1.Text = "Загрузка описания обновления...";
			pbProgress.Maximum = 100;
			pbProgress.Value = 0;
			bool res = false;
			try
			{
				bwDownload.DoWork += Worker_DownloadUpdateInfo;
				bwDownload.RunWorkerAsync();
				while (bwDownload.IsBusy)
				{
					Application.DoEvents();
					Thread.Sleep(100);
					if (CancelAll)
						bwDownload.CancelAsync();
				}
				bwDownload.DoWork -= Worker_DownloadUpdateInfo;
				if (CancelAll)
					return false;
				if (FDownloadResult is XmlDocument)
				{
					XmlDocument Doc = (XmlDocument)FDownloadResult;
					if (Doc.DocumentElement != null)
						if (Doc.DocumentElement.Name == "Configuration")
						{
							XmlNode Version = Doc.DocumentElement.GetElementsByTagName("Version")[0];
							if (Version != null)
								UpdateInfo.Version = Version.ChildNodes[0].Value;
							XmlNode ProgramName = Doc.DocumentElement.GetElementsByTagName("Name")[0];
							if (ProgramName != null)
								UpdateInfo.Name = ProgramName.ChildNodes[0].Value;
							XmlNode ProgramSize = Doc.DocumentElement.GetElementsByTagName("Size")[0];
							if (ProgramSize != null)
								UpdateInfo.Size = Int64.Parse(ProgramSize.ChildNodes[0].Value);
							XmlNode ProgramPath = Doc.DocumentElement.GetElementsByTagName("Path")[0];
							if (ProgramPath != null)
								UpdateInfo.Path = ProgramPath.ChildNodes[0].Value;
						}
				}
				res = FDownloadError == null;
			}
			catch 
			{
				res = false;
			}
			pbProgress.Value = 100;
			label1.Text="";
			return res;
		}

		bool DownloadArchive()
		{
			FDownloadError = null;
			FDownloadResult = null;
			CountSystem = 2;
			label1.Text = "Загрузка обновления...";
			bool res = false;
			try
			{
				pbProgress.Value = 0;
				pbProgress.Maximum = (int)UpdateInfo.Size;
				bwDownload.DoWork += Worker_DownloadUpdateArchive;
				bwDownload.RunWorkerAsync();
				while (bwDownload.IsBusy)
				{
					Application.DoEvents();
					Thread.Sleep(100);
					if (CancelAll)
						bwDownload.CancelAsync();
				}
				bwDownload.DoWork -= Worker_DownloadUpdateArchive;
				if (CancelAll)
					return false;
				res = FDownloadError == null;
			}
			catch { }
			label1.Text = "";
			return res;
		}

		bool ExtractArchive(string Archive)
		{
			FDownloadError = null;
			FDownloadResult = null;
			CountSystem = 3;
			label1.Text = "Извлечение архива...";
			bool res = false;
			while (Process.GetProcessesByName("EgidaBackup").Length > 0)
			{
				label1.Text = "Ожидание закрытия Egida backup...";
				Thread.Sleep(500);
				Application.DoEvents();
			}
			try
			{
				pbProgress.Value = 0;
				pbProgress.Maximum = 100;
				bwDownload.DoWork += Worker_ExtractArchive;
				bwDownload.RunWorkerAsync(Archive);
				while (bwDownload.IsBusy)
				{
					Application.DoEvents();
					Thread.Sleep(100);
					if (CancelAll)
						bwDownload.CancelAsync();
				}
				bwDownload.DoWork -= Worker_ExtractArchive;
				if (CancelAll)
					return false;
				res = FDownloadError == null;
			}
			catch { }
			label1.Text = "";
			return res;
		}

		void Worker_DownloadUpdateInfo(object sender, DoWorkEventArgs e)
		{
			WebClient Web = new WebClient();
			try
			{
				byte[] InfoBytes = Web.DownloadData(@"http://egida1c.ru/download/update/egidabackup.xml");
				XmlDocument Doc = new XmlDocument();
				Doc.LoadXml(Encoding.UTF8.GetString(InfoBytes));
				e.Result = Doc;
			}
			catch (Exception ex) 
			{
				FDownloadError = ex;
			}
			Web.Dispose();
		}

		void Worker_DownloadUpdateArchive(object sender, DoWorkEventArgs e)
		{
			WebClient Web = new WebClient();
			try
			{
				string FName = Path.GetDirectoryName(Application.ExecutablePath) + @"\" + UpdateInfo.Name + ".zip";
				//Web.DownloadFile(UpdateInfo.Path, FName);
				FileStream F = new FileStream(FName, FileMode.Create);
				Stream S = Web.OpenRead(UpdateInfo.Path);
				Int64 l=UpdateInfo.Size;
				Int64 i=0;
				byte[] bufer =new byte[16000];
				bwDownload.ReportProgress(0);
				while (i < l)
				{
					if (bwDownload.CancellationPending)
						break;
					int readed = S.Read(bufer, 0, 16000);
					i += readed;
					F.Write(bufer, 0, readed);
					bwDownload.ReportProgress((int)i);
				}
				F.Dispose();
				S.Dispose();
				e.Result = FName;
			}
			catch (Exception ex)
			{
				FDownloadError = ex;
			}
			Web.Dispose();
		}

		void Worker_ExtractArchive(object sender, DoWorkEventArgs e)
		{
			bwDownload.ReportProgress(0);
			try
			{
				ZipFile Zip = new ZipFile((string)e.Argument);
				long unpacked = 0;
				long allsize = 0;
				foreach (ZipEntry ent in Zip)
				{
					if (ent.IsFile)
						allsize++;
				}

				foreach (ZipEntry ent in Zip)
				{
					if (bwDownload.CancellationPending)
						break;
					if (ent.IsFile)
					{
						try
						{
							string fname = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), ent.Name);
							if (!Directory.Exists(Path.GetDirectoryName(fname)))
								Directory.CreateDirectory(Path.GetDirectoryName(fname));
							Stream S = Zip.GetInputStream(ent);
							FileStream F = File.Create(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), ent.Name));
							byte[] bufer = new byte[16000];
							long fsize = 0; 
							while (fsize < ent.Size)
							{
								if (bwDownload.CancellationPending)
									break;
								int readed = S.Read(bufer, 0, 16000);
								F.Write(bufer, 0, readed);
								fsize += readed;	
							}
							F.Dispose();
						}
						catch { }
						unpacked++;
						bwDownload.ReportProgress((int)((float)unpacked / (float)allsize * 100));
					}
					if (ent.IsDirectory)
					{
						try
						{
							Directory.CreateDirectory(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), ent.Name));
						}
						catch { }
					}
				}
				Zip.Close();
			}
			catch (Exception ex)
			{
				FDownloadError = ex;
			}
		}

		void ProgressChange(int Progress)
		{
			if (Progress<=pbProgress.Maximum)
				pbProgress.Value = Progress;
			switch (CountSystem)
			{
				case 1:
					label2.Text = "Загрузка " + Progress.ToString() + "%";
					break;
				case 2:
					label2.Text = "Загрузка " + IntToCountBytes(Progress) + " из " + IntToCountBytes(pbProgress.Maximum);
					break;
				case 3:
					label2.Text = "Извлечение " + Progress.ToString() + "%";
					break;
			}
			this.Text = label2.Text;
		}

		string IntToCountBytes(int bytes)
		{
			if (bytes >= 1048576)
				return ((float)bytes / 1048576).ToString("F2") + " Мб";
			else
			{
				if (bytes >= 1024)
					return ((float)bytes / 1024).ToString("F0") + " Кб";
				else
					return bytes.ToString() + " б";
			}
		}

		private void bwDownload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			FDownloadResult = e.Result;
			FDownloadError = e.Error;
		}

		private void bwDownload_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			try
			{
				this.Invoke(new ProgressChangeDelegate(ProgressChange), new object[] { e.ProgressPercentage });
			}
			catch { }
		}

		private void bCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void UpdateForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (InProcess)
			{
				if (MessageBox.Show("Данные программы могут быть повреждены. Прекратить обновление?",
					"Отмена обновления", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					CancelAll = true;
					e.Cancel = true;
				}
			}
		}

		private void UpdateForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (StartMainProgram)
			{
				Process P = new Process();
				try
				{
					P.StartInfo = new ProcessStartInfo(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "egidabackup.exe"));
					P.Start();
				}
				catch { }
				P.Dispose();
			}
		}
	}

	struct UpdateVersionInfo
	{
		public string Name;
		public string Version;
		public Int64 Size;
		public string Path;
		public bool Installed;

		public void SaveToFile(string Filename)
		{
			XmlDocument Doc = new XmlDocument();
			XmlNode DN = Doc.AppendChild(Doc.CreateNode(XmlNodeType.Element, "Configuration", ""));
			DN.AppendChild(Doc.CreateElement("Name")).InnerText=Name;
			DN.AppendChild(Doc.CreateElement("Version")).InnerText=Version;
			DN.AppendChild(Doc.CreateElement("Installed")).InnerText = Installed.ToString();
			XmlTextWriter Wr = new XmlTextWriter(Filename, Encoding.UTF8);
			Wr.Formatting = Formatting.Indented;
			Wr.Indentation = 4;
			Doc.Save(Wr);
			Wr.Close();
		}
	}

	delegate void ProgressChangeDelegate(int Progress);
}
