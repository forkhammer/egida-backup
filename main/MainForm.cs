using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using System.Threading;
using System.Xml;
using System.Diagnostics;
using Microsoft.Win32;

namespace EgidaBackup
{
    public partial class MainForm : Form, LogBackupInterface, BackupQueveInterface
    {
		BackupList FList = new BackupList();
		bool CancelClose = true;
		Thread FThread;
		List<TaskItem> FQueve = new List<TaskItem>();
		LogList FLogList = new LogList(Path.GetDirectoryName(Application.ExecutablePath)+@"\messages.log");
		DateTime FBeginProgress;
		TaskItem FCurrentBackupItem = null;

		public bool FirstStart
		{
			get 
			{
				bool res = false;
				try
				{
					XmlDocument Doc = new XmlDocument();
					Doc.Load(Path.GetDirectoryName(Application.ExecutablePath) + @"\start.xml");
					if (Doc.DocumentElement != null)
						if (Doc.DocumentElement.Name == "Start")
						{
							try
							{
								res = bool.Parse(Doc.DocumentElement.Attributes["First"].Value);
							}
							catch { }
						}
				}
				catch { }
				return res;
			}

			set
			{
				XmlDocument Doc = new XmlDocument();
				XmlNode N = Doc.AppendChild(Doc.CreateElement("Start"));
				N.Attributes.Append(Doc.CreateAttribute("First")).Value=value.ToString();
				Doc.Save(Path.GetDirectoryName(Application.ExecutablePath) + @"\start.xml");
			}
		}

        public MainForm()
        {
            InitializeComponent();
			label2.Text = Environment.OSVersion.VersionString;
            lbAllMessage.Synchronize(FLogList);
			mbAutorun.Checked=Program.Options["Autorun"].AsBool;
			lbBackup.Queve = this;
			notifyIcon1.Icon = EgidaBackup.Properties.Resources.box;
            Program.Options["Autorun"].OptionItemChangeEvent += AutorunHandler;

			string[] args = Environment.GetCommandLineArgs();
			foreach (string arg in args)
				if (arg == "--minimize")
				{
					this.WindowState = FormWindowState.Minimized;
					this.ShowInTaskbar = false;
					break;
				}
        }

		public void UpdateBackupList()
		{
			lbBackup.Items.Clear();
			for (int i = 0; i < FList.Count; i++ )
			{
				lbBackup.Items.Add(FList[i]);
			}
		}

		void ZipBackupTo(object Param)
		{
            InvokeSetStatusLabel("");
			((ZipBackupToParam)Param).BI.BackupTo((Param as ZipBackupToParam).Filename, this);
			Invoke(new EndBackupDelegate(EndBackup), new object[] { (Param as ZipBackupToParam).BI });
		}

		void RunCommand(object Param)
		{
            InvokeSetStatusLabel("");
            if (((TaskItem)Param).Run(this))
                ((TaskItem)Param).SendMailNotice(this);
			Invoke(new EndBackupDelegate(EndBackup), new object[] { (TaskItem)Param });
		}

		void AddLogItem(TaskItem Sender, LogItem LI)
		{
			lbLog.AddItem(LI);
			lbAllMessage.AddItem(LI);
			FLogList.List.Add(LI);
			Sender.Log.List.Add(LI);
			if (Sender == lbBackup.SelectedItem && lbBackup.SelectedItem != null)
				lbCurrent.AddItem(LI);
		}

		public void InvokeAddLogItem(TaskItem Sender, string Text, LogItemType ItemType)
		{
			this.Invoke(new AddLogItemDelegate(AddLogItem), new object[] { Sender,  new LogItem(Text, ItemType, DateTime.Now, LogItemLabel.New) }); 
		}

		void SetStatusLabel(string Text)
		{
			lStatus.Text = Text;
		}

		public void InvokeSetStatusLabel(string Text)
		{
			this.Invoke(new SetStatusLabelDelegate(SetStatusLabel), new object[] { Text });
		}

		void SetProgress(int Progress)
		{
            if (Progress>=pbProcess.Minimum && Progress<=pbProcess.Maximum)
			    pbProcess.Value = Progress;
			if (Progress == 0)
			{
                pbProcess.Style = ProgressBarStyle.Blocks;
				FBeginProgress = DateTime.Now;
				tmElapsed.Enabled = true;
			}
			if (Progress == 100)
			{
				tmElapsed.Enabled = false;
				lElapsed.Text = "";
			}
            if (Progress == -1)
            {
                pbProcess.Style = ProgressBarStyle.Marquee;
            }
		}

		public void InvokeSetProgress(int Progress)
		{
			Invoke(new SetProgressDelegate(SetProgress), new object[] { Progress });
		}

		void EndBackup(TaskItem BI)
		{
			BI.LastStamp = DateTime.Now;
			lbBackup.Refresh();
			FQueve.Remove(BI);
			lbBackup.Invalidate();
			FCurrentBackupItem = null;
			lActiveBackup.Text = "Нет активной задачи";
			pWork.Visible = false;
			tmIcon.Enabled = false;
			notifyIcon1.Icon = EgidaBackup.Properties.Resources.box;
		}

		void CheckQueve()
		{
			if (FThread==null || FThread.ThreadState == System.Threading.ThreadState.Stopped)
			{
				if (FQueve.Count > 0)
				{
					pWork.Visible = true;
					FCurrentBackupItem = FQueve[0];
                    lActiveBackup.Text = "Активная задача: " + FCurrentBackupItem.Name;
					FThread = new Thread(new ParameterizedThreadStart(RunCommand));
					FThread.Start(FQueve[0]);
					lbBackup.Invalidate();
					tmIcon.Enabled = true;
				}
			}
		}

        void AutorunHandler(object Sender)
        {
            try
            {
                if ((Sender as OptionItem).AsBool)
                    Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run", "EgidaBackup", "\"" + Application.ExecutablePath + "\" --minimize");
                else
                    Registry.LocalMachine.OpenSubKey(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true).DeleteValue("EgidaBackup");
            }
            catch { }
            mbAutorun.Checked = (Sender as OptionItem).AsBool;
        }

		private void bAddBackup_Click(object sender, EventArgs e)
		{
			CatalogBackupItem BI = new CatalogBackupItem();
			if (CatalogBackupEditForm.Dialog(BI))
			{
				FList.Add(BI);
				lbBackup.Items.Add(BI);
			}
		}

		private void bdelBackup_Click(object sender, EventArgs e)
		{
			if (lbBackup.SelectedItem != null)
			{
				if (MessageBox.Show("Удалить выделенную запись?", "Подтверждение удаления", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					FList.Delete((TaskItem)lbBackup.SelectedItem);
					lbBackup.Items.Remove(lbBackup.SelectedItem);
				}
			}
		}

		private void bEditBackup_Click(object sender, EventArgs e)
		{
			if (lbBackup.SelectedItem != null)
			{
				bool save = false;
				TaskItem BI = (TaskItem)lbBackup.SelectedItem;
				if (BI is Backup1CItem)
					if (Backup1CEditForm.Dialog(BI))
						save = true;
                if (BI is CatalogBackupItem)
                    if (CatalogBackupEditForm.Dialog(BI))
                        save = true;
				if (BI is CommandItem)
					if (CommandEditForm.Dialog(BI))
						save = true;
				if (BI is Restore1CItem)
					if (Restore1CEditForm.Dialog(BI))
						save = true;
				if (BI is QueveItem)
					if (QueveEditForm.Dialog(BI))
						save = true;
				if (save)
					FList.Save(Path.GetDirectoryName(Application.ExecutablePath) + @"\backups.xml");
				lbBackup.Items[lbBackup.SelectedIndex] = BI;
			}
		}

		private void bExit_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Вы действительно хотите выйти из программы?", "Подтверждение закрытия", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				CancelClose = false;
				Close();
			}
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			FList.Save(Path.GetDirectoryName(Application.ExecutablePath) + @"\backups.xml");
			FLogList.Save();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			FList.Load(Path.GetDirectoryName(Application.ExecutablePath) + @"\backups.xml");
			UpdateBackupList();
			if (FirstStart)
			{
				FirstStart = false;
				HistoryForm.Dialog();
			}
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = CancelClose;
				if (CancelClose)
				{
					WindowState = FormWindowState.Minimized;
					ShowInTaskbar = false;
				}
			}
		}

		private void notifyIcon1_DoubleClick(object sender, EventArgs e)
		{
			if (WindowState == FormWindowState.Minimized)
			{
				WindowState = FormWindowState.Maximized;
				ShowInTaskbar = true;
			}
			else
			{
				WindowState = FormWindowState.Minimized;
				ShowInTaskbar = false;
			}
		}

		private void lbBackup_MouseUp(object sender, MouseEventArgs e)
		{
            if (lbBackup.SelectedItem != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Graphics Gr = Graphics.FromHwnd(lbBackup.Handle);
                    Size checkbox = CheckBoxRenderer.GetGlyphSize(Gr, System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
                    Rectangle ItemRect = lbBackup.GetItemRectangle(lbBackup.SelectedIndex);
                    if (e.X > ItemRect.X + 3 &&
                        e.Y > ItemRect.Y + 4 &&
                        e.X < ItemRect.X + 3 + checkbox.Width &&
                        e.Y < ItemRect.Y + 4 + checkbox.Height)
                        ((TaskItem)lbBackup.SelectedItem).Checked = !((TaskItem)lbBackup.SelectedItem).Checked;
                    lbBackup.Invalidate(ItemRect);
                }
                if (e.Button == MouseButtons.Right)
                {
                    if (lbBackup.GetItemRectangle(lbBackup.SelectedIndex).Contains(e.Location))
                    {
                        mbZipBackup.Visible = mbZipBackupTO.Visible = lbBackup.SelectedItem is BackupItem;
                        mbRunCommand.Visible = lbBackup.SelectedItem is CommandItem;
                        cmBackup.Show(lbBackup.PointToScreen(e.Location));
                    }
                }
            }
		}

		private void tmAuto_Tick(object sender, EventArgs e)
		{
			for (int i = 0; i < FList.Count; i++ )
			{
				TaskItem BI = FList[i];
				if (BI.Scheduled())
					if (!FQueve.Contains(BI))
						FQueve.Add(BI);
			}
			CheckQueve();
		}

		private void tmQueve_Tick(object sender, EventArgs e)
		{
			CheckQueve();
		}

		private void bManualStart_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < FList.Count; i++)
			{
				if (FList[i].Checked)
				{
					if (!FQueve.Contains(FList[i]))
						FQueve.Add(FList[i]);
				}
			}
			CheckQueve();
		}

		private void mbSaveAll_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < FList.Count; i++)
			{
				TaskItem BI = FList[i];
				if (!FQueve.Contains(BI))
				{
					FQueve.Add(BI);
				}
			}
			CheckQueve();
		}

		private void mbClearMessages_Click(object sender, EventArgs e)
		{
			lbLog.Rows.Clear();
		}

		private void mbClearAllMessage_Click(object sender, EventArgs e)
		{
			lbAllMessage.Rows.Clear();
			FLogList.List.Clear();
		}

		private void mbZipBackupTO_Click(object sender, EventArgs e)
		{
			if (lbBackup.SelectedItem != null)
			{
				if ((FThread == null || FThread.ThreadState == System.Threading.ThreadState.Stopped) && FQueve.Count == 0)
				{
					BackupItem BI = (BackupItem)lbBackup.SelectedItem;
					if (BI is Backup1CItem)
					{
						SaveFileDialog dlg = new SaveFileDialog();
						dlg.Filter = "База 1С|*.dt";
						if (dlg.ShowDialog() == DialogResult.OK)
						{
							pWork.Visible = true;
							lActiveBackup.Text = "Активная задача: " + BI.Name;
							FThread = new Thread(new ParameterizedThreadStart(ZipBackupTo));
							FThread.Start(new ZipBackupToParam((BackupItem)lbBackup.SelectedItem, dlg.FileName));
						}
					}
                    if (BI is CatalogBackupItem)
					{
						if ((BI as CatalogBackupItem).Archive)
						{
							SaveFileDialog dlg = new SaveFileDialog();
							dlg.Filter = "Zip-архив|*.zip";
							if (dlg.ShowDialog() == DialogResult.OK)
							{
								pWork.Visible = true;
								lActiveBackup.Text = "Активная задача: " + BI.Name;
								FThread = new Thread(new ParameterizedThreadStart(ZipBackupTo));
								FThread.Start(new ZipBackupToParam((BackupItem)lbBackup.SelectedItem, dlg.FileName));
							}
						}
						else
						{
							FolderBrowserDialog dlg = new FolderBrowserDialog();
							dlg.Description = "Укажите директорию, к которую будут помещены резервные данные";
							if (dlg.ShowDialog() == DialogResult.OK)
							{
								pWork.Visible = true;
								lActiveBackup.Text = "Активная задача: " + BI.Name;
								FThread = new Thread(new ParameterizedThreadStart(ZipBackupTo));
								FThread.Start(new ZipBackupToParam((BackupItem)lbBackup.SelectedItem, dlg.SelectedPath));
							}
						}
					}

				}
				else
				{
					MessageBox.Show("Идет процесс резервирования. Попробуйте позже.");
				}
			}
		}

		private void архивироватьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lbBackup.SelectedItem != null)
			{
				if (!FQueve.Contains((TaskItem)lbBackup.SelectedItem))
				{
					FQueve.Add((TaskItem)lbBackup.SelectedItem);
					CheckQueve();
				}
			}
		}

		private void mb1CReserv_Click(object sender, EventArgs e)
		{
			Backup1CItem BI = new Backup1CItem();
			if (Backup1CEditForm.Dialog(BI))
			{
				FList.Add(BI);
				lbBackup.Items.Add(BI);
			}
		}

		private void pbLogo_Click(object sender, EventArgs e)
		{
			Process P = new Process();
			P.StartInfo = new ProcessStartInfo(@"http:\\www.egida1c.ru");
			P.Start();
			P.Dispose();
		}

		private void tmElapsed_Tick(object sender, EventArgs e)
		{
			if (pbProcess.Value != 0)
			{
				double V = (DateTime.Now - FBeginProgress).TotalSeconds / (double)pbProcess.Value;
				int Elapsed = (int)((100 - pbProcess.Value) * V);
				TimeSpan T = new TimeSpan(0, 0, Elapsed);
				lElapsed.Text = String.Format("{0:00}:{1:00}:{2:00}", T.Hours, T.Minutes, T.Seconds);
			}
			if (FThread == null || FThread.ThreadState == System.Threading.ThreadState.Stopped)
			{
				tmElapsed.Enabled = false;
				lElapsed.Text = "";
			}
		}

		private void lbBackup_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (lbBackup.SelectedItem != null)
            {
                tabPage3.Text = "Текущий - " + (lbBackup.SelectedItem as TaskItem).Name;
                lbCurrent.Synchronize((lbBackup.SelectedItem as TaskItem).Log);
            }
            else
            {
                tabPage3.Text = "Текущий";
                lbCurrent.Rows.Clear();
            }
		}

		private void mbClearCurrent_Click(object sender, EventArgs e)
		{
			if (lbBackup.SelectedItem != null)
			{
				(lbBackup.SelectedItem as TaskItem).Log.List.Clear();
				lbCurrent.Rows.Clear();
			}
		}

		private void bAbout_Click(object sender, EventArgs e)
		{
			HelpForm.Dialog();
		}

		private void bUpdate_Click(object sender, EventArgs e)
		{
			Process P = new Process();
			try
			{
				P.StartInfo = new ProcessStartInfo(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"UpdateProgram.exe"));
				P.StartInfo.WorkingDirectory = Path.GetDirectoryName(Application.ExecutablePath);
				P.Start();
			}
			catch { }
			P.Dispose();
		}

		private void label3_Click(object sender, EventArgs e)
		{
			Process P = new Process();
			try
			{
				P.StartInfo = new ProcessStartInfo("http:\\www.egida1c.ru");
				P.Start();
			}
			catch { }
			P.Dispose();
		}

		private void label3_MouseHover(object sender, EventArgs e)
		{
			(sender as Label).ForeColor = Color.Yellow;
		}

		private void label3_MouseLeave(object sender, EventArgs e)
		{
			(sender as Label).ForeColor = Color.White;
		}

		private void mbAutorun_Click(object sender, EventArgs e)
		{
			Program.Options["Autorun"].AsBool=mbAutorun.Checked=!mbAutorun.Checked;
            Program.Options.Save();
		}

		private void label4_Click(object sender, EventArgs e)
		{
			HistoryForm.Dialog();
		}

		#region BackupQueveInterface Members

		public TaskItem GetCurrentBackupItem()
		{
			return FCurrentBackupItem;
		}

		public bool ExistInBackupQueve(TaskItem BI)
		{
			return FQueve.Contains(BI);
		}

		#endregion

		private void tmIcon_Tick(object sender, EventArgs e)
		{
			if (notifyIcon1.Tag == null)
			{
				notifyIcon1.Icon = EgidaBackup.Properties.Resources.box_new;
				notifyIcon1.Tag = 0;
			}
			else
			{
				notifyIcon1.Icon = EgidaBackup.Properties.Resources.box;
				notifyIcon1.Tag = null;
			}
		}

		private void mbScript_Click(object sender, EventArgs e)
		{
			CommandItem BI = new CommandItem();
			if (CommandEditForm.Dialog(BI))
			{
				FList.Add(BI);
				lbBackup.Items.Add(BI);
			}
		}

		private void mbRestore1C_Click(object sender, EventArgs e)
		{
			Restore1CItem BI = new Restore1CItem();
			if (Restore1CEditForm.Dialog(BI))
			{
				FList.Add(BI);
				lbBackup.Items.Add(BI);
			}
		}

		private void mbQueve_Click(object sender, EventArgs e)
		{
			QueveItem BI = new QueveItem();
			BI.Backups = FList;
			if (QueveEditForm.Dialog(BI))
			{
				FList.Add(BI);
				lbBackup.Items.Add(BI);
			}
		}

        private void bOptions_Click(object sender, EventArgs e)
        {
            OptionsForm.Dialog();
        }

        private void mbCopyAllReport_Click(object sender, EventArgs e)
        {
            ReportClass Report = new ReportClass("Отчет по резервному копированию");
            for (int i = 0; i < FList.Count; i++)
            {
                if (FList[i] is BackupItem)
                    (FList[i] as BackupItem).Report_Backup(Report);
            }
            Report.WriteEnd();
            SaveFileDialog Dlg = new SaveFileDialog();
            Dlg.Filter = "Html отчет *.html|*.html";
            if (Dlg.ShowDialog() == DialogResult.OK)
            {
                Report.Save(Dlg.FileName);
            }
        }

        private void mbCopySmallReport_Click(object sender, EventArgs e)
        {
            ReportClass Report = new ReportClass("Отчет по резервному копированию");
            for (int i = 0; i < FList.Count; i++)
            {
                if (FList[i] is BackupItem)
                    (FList[i] as BackupItem).Report_BackupSmall(Report);
            }
            Report.WriteEnd();
            SaveFileDialog Dlg = new SaveFileDialog();
            Dlg.Filter = "Html отчет *.html|*.html";
            if (Dlg.ShowDialog() == DialogResult.OK)
            {
                Report.Save(Dlg.FileName);
            }
        }
	}

	delegate void AddLogItemDelegate(TaskItem Sender, LogItem LI);
	delegate void SetStatusLabelDelegate(string Text);
	delegate void SetProgressDelegate(int Progress);
	delegate void EndBackupDelegate(TaskItem BI);
	
	class ZipBackupToParam
	{
		public BackupItem BI;
		public string Filename;

		public ZipBackupToParam(BackupItem B, string F)
		{
			BI = B;
			Filename = F;
		}
	}

	public interface LogBackupInterface
	{
		void InvokeSetStatusLabel(string Text);
		void InvokeAddLogItem(TaskItem Sender, string Text, LogItemType ItemType);
		void InvokeSetProgress(int Progress);
	}

	public interface BackupQueveInterface
	{
		TaskItem GetCurrentBackupItem();
		bool ExistInBackupQueve(TaskItem BI);
	}
}
