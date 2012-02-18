using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

namespace EgidaBackup
{
    public class BackupList
    {
		List<TaskItem> FList = new List<TaskItem>();

		public TaskItem this[int Index]
		{
			get { return FList[Index]; }
			set { FList[Index] = value; }
		}

		public int Count
		{
			get { return FList.Count; }
		}

		public BackupList()
		{
 
		}

		public void Add(TaskItem TI)
		{
			FList.Add(TI);
		}

		public void Delete(int Index)
		{
			FList.RemoveAt(Index);
		}

		public void Delete(TaskItem TI)
		{
			FList.Remove(TI);
		}

        public void Save(string Filename)
        {
            XmlDocument Doc = new XmlDocument();
			Doc.AppendChild(Doc.CreateElement("BackupManager"));
            foreach (TaskItem Item in FList)
            {
				if (Item is Backup1CItem)
					Item.Save(Doc, Doc.DocumentElement.AppendChild(Doc.CreateElement("Backup1C")));
                if (Item is CatalogBackupItem)
                    Item.Save(Doc, Doc.DocumentElement.AppendChild(Doc.CreateElement("CatalogBackup")));
				if (Item is CommandItem)
					Item.Save(Doc, Doc.DocumentElement.AppendChild(Doc.CreateElement("Command")));
				if (Item is Restore1CItem)
					Item.Save(Doc, Doc.DocumentElement.AppendChild(Doc.CreateElement("Restore1C")));
				if (Item is QueveItem)
					Item.Save(Doc, Doc.DocumentElement.AppendChild(Doc.CreateElement("QueveTasks")));
            }

			XmlTextWriter XW = new XmlTextWriter(Filename, Encoding.UTF8);
			XW.IndentChar = ' ';
			XW.Indentation = 4;
			XW.Formatting = Formatting.Indented;
			Doc.Save(XW);
			XW.Close();
        }

		public void Load(string Filename)
		{
            try
            {
                XmlDocument Doc = new XmlDocument();
                Doc.Load(Filename);
                if (Doc.DocumentElement.Name == "BackupManager")
                {
                    foreach (XmlNode N in Doc.DocumentElement)
                    {
                        if (N.Name == "Backup1C")
                        {
                            Backup1CItem BI = new Backup1CItem();
                            FList.Add(BI);
                            BI.Load((XmlElement)N);
                        }
                        if (N.Name == "CatalogBackup")
                        {
                            CatalogBackupItem BI = new CatalogBackupItem();
                            FList.Add(BI);
                            BI.Load((XmlElement)N);
                        }
                        if (N.Name == "Command")
                        {
                            CommandItem BI = new CommandItem();
                            FList.Add(BI);
                            BI.Load((XmlElement)N);
                        }
                        if (N.Name == "Restore1C")
                        {
                            Restore1CItem BI = new Restore1CItem();
                            FList.Add(BI);
                            BI.Load((XmlElement)N);
                        }
                    }
                    foreach (XmlNode N in Doc.DocumentElement)
                    {
                        if (N.Name == "QueveTasks")
                        {
                            QueveItem BI = new QueveItem();
                            BI.Backups = this;
                            FList.Add(BI);
                            BI.Load((XmlElement)N);
                        }
                    }

                }
            }
            catch { }
		}

		public TaskItem GetTaskByID(string ID)
		{
			foreach (TaskItem T in FList)
				if (T.ID==ID)
					return T;
			return null;
		}
    }

	public class TaskItem
	{
        string FID = System.Guid.NewGuid().ToString();
		string FName = "";
		DateTime FLastStamp; //последнее архивирование
		bool FActive = false; //активность расписания
		bool FChecked = false;
		DateTime ReservDay = DateTime.MinValue;

		bool FPeriodical = true; //один раз или периодически
		bool FPeriodicalTime = false; //один раз или периодически по времени
		DateTime FOnceDate = DateTime.Today; //дата резервирования
		byte FEveries = 0; //по дням, неделям или месяцам
		int FPeriod = 1; //периодичность
		byte FDayOfWeek = 0; //дни недели
		byte FDayOfMonth = 1; //день месяца
		DateTime FOnceTime = DateTime.Today; //время резервирования
		byte FEveryTime = 12; //периодичность по времени в часах
        bool FMailNotice = false;  //отправлять уведомление по почте

		public LogList Log = new LogList();

        public string ID
        {
            get { return FID; }
            set { FID = value; }
        }
		public string Name
		{
			get { return FName; }
			set
			{
				FName = value;
				Log.Filename = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\Logs\" + FName + ".log";
				Log.Load();
			}
		}
		public bool Active
		{
			get { return FActive; }
			set { FActive = value; }
		}
		public bool Checked
		{
			get { return FChecked; }
			set { FChecked = value; }
		}
		public DateTime LastStamp
		{
			get { return FLastStamp; }
			set { FLastStamp = value; }
		}
		public bool Periodical
		{
			get { return FPeriodical; }
			set { FPeriodical = value; }
		}
		public bool PeriodicalTime
		{
			get { return FPeriodicalTime; }
			set { FPeriodicalTime = value; }
		}
		public DateTime OnceDate
		{
			get { return FOnceDate; }
			set { FOnceDate = value; }
		}
		public byte Everies
		{
			get { return FEveries; }
			set { FEveries = value; }
		}
		public int Period
		{
			get { return FPeriod; }
			set { FPeriod = value; }
		}
		public byte DayOfWeek
		{
			get { return FDayOfWeek; }
			set { FDayOfWeek = value; }
		}
		public byte DayOfMonth
		{
			get { return FDayOfMonth; }
			set { FDayOfMonth = value; }
		}
		public DateTime OnceTime
		{
			get { return FOnceTime; }
			set { FOnceTime = value; }
		}
		public byte EveryTime
		{
			get { return FEveryTime; }
			set { FEveryTime = value; }
		}
        public bool MailNotice
        {
            get { return FMailNotice; }
            set { FMailNotice = value; }
        }

		public override string ToString()
		{
			return FName;
		}

		public virtual void Save(XmlDocument Doc, XmlNode Node)
		{
			XmlNode N;
            N = Node.AppendChild(Doc.CreateElement("ID"));
            N.AppendChild(Doc.CreateTextNode(FID));
			N = Node.AppendChild(Doc.CreateElement("Name"));
			N.AppendChild(Doc.CreateTextNode(FName));
			N = Node.AppendChild(Doc.CreateElement("Periodical"));
			N.AppendChild(Doc.CreateTextNode(FPeriodical.ToString()));
			N = Node.AppendChild(Doc.CreateElement("PeriodicalTime"));
			N.AppendChild(Doc.CreateTextNode(FPeriodicalTime.ToString()));
			N = Node.AppendChild(Doc.CreateElement("OnceDate"));
			N.AppendChild(Doc.CreateTextNode(FOnceDate.ToString()));
			N = Node.AppendChild(Doc.CreateElement("Everies"));
			N.AppendChild(Doc.CreateTextNode(FEveries.ToString()));
			N = Node.AppendChild(Doc.CreateElement("Period"));
			N.AppendChild(Doc.CreateTextNode(FPeriod.ToString()));
			N = Node.AppendChild(Doc.CreateElement("DayOfWeek"));
			N.AppendChild(Doc.CreateTextNode(FDayOfWeek.ToString()));
			N = Node.AppendChild(Doc.CreateElement("DayOfMonth"));
			N.AppendChild(Doc.CreateTextNode(FDayOfMonth.ToString()));
			N = Node.AppendChild(Doc.CreateElement("OnceTime"));
			N.AppendChild(Doc.CreateTextNode(FOnceTime.ToString()));
			N = Node.AppendChild(Doc.CreateElement("EveryTime"));
			N.AppendChild(Doc.CreateTextNode(FEveryTime.ToString()));
			N = Node.AppendChild(Doc.CreateElement("Active"));
			N.AppendChild(Doc.CreateTextNode(FActive.ToString()));
			N = Node.AppendChild(Doc.CreateElement("Checked"));
			N.AppendChild(Doc.CreateTextNode(FChecked.ToString()));
			N = Node.AppendChild(Doc.CreateElement("LastStamp"));
			N.AppendChild(Doc.CreateTextNode(FLastStamp.ToString()));
            N = Node.AppendChild(Doc.CreateElement("MailNotice"));
            N.AppendChild(Doc.CreateTextNode(FMailNotice.ToString()));
			Log.Save();
		}

		public virtual void Load(XmlElement Node)
		{
			XmlNode N;
            N = Node.GetElementsByTagName("ID")[0];
            if (N != null)
                if (N.HasChildNodes)
                    ID = N.ChildNodes.Item(0).Value;
			N = Node.GetElementsByTagName("Name")[0];
			if (N != null)
				if (N.HasChildNodes)
					Name = N.ChildNodes.Item(0).Value;
			N = Node.GetElementsByTagName("Periodical")[0];
			if (N != null)
				if (N.HasChildNodes)
					FPeriodical = bool.Parse(N.ChildNodes.Item(0).Value);
			N = Node.GetElementsByTagName("PeriodicalTime")[0];
			if (N != null)
				if (N.HasChildNodes)
					FPeriodicalTime = bool.Parse(N.ChildNodes.Item(0).Value);
			N = Node.GetElementsByTagName("OnceDate")[0];
			if (N != null)
				if (N.HasChildNodes)
					FOnceDate = DateTime.Parse(N.ChildNodes.Item(0).Value);
			N = Node.GetElementsByTagName("Everies")[0];
			if (N != null)
				if (N.HasChildNodes)
					FEveries = byte.Parse(N.ChildNodes.Item(0).Value);
			N = Node.GetElementsByTagName("Period")[0];
			if (N != null)
				if (N.HasChildNodes)
					FPeriod = int.Parse(N.ChildNodes.Item(0).Value);
			N = Node.GetElementsByTagName("DayOfWeek")[0];
			if (N != null)
				if (N.HasChildNodes)
					FDayOfWeek = byte.Parse(N.ChildNodes.Item(0).Value);
			N = Node.GetElementsByTagName("DayOfMonth")[0];
			if (N != null)
				if (N.HasChildNodes)
					FDayOfMonth = byte.Parse(N.ChildNodes.Item(0).Value);
			N = Node.GetElementsByTagName("OnceTime")[0];
			if (N != null)
				if (N.HasChildNodes)
					FOnceTime = DateTime.Parse(N.ChildNodes.Item(0).Value);
			N = Node.GetElementsByTagName("EveryTime")[0];
			if (N != null)
				if (N.HasChildNodes)
					FEveryTime = byte.Parse(N.ChildNodes.Item(0).Value);
			N = Node.GetElementsByTagName("Active")[0];
			if (N != null)
				if (N.HasChildNodes)
					FActive = bool.Parse(N.ChildNodes.Item(0).Value);
			N = Node.GetElementsByTagName("Checked")[0];
			if (N != null)
				if (N.HasChildNodes)
					FChecked = bool.Parse(N.ChildNodes.Item(0).Value);
			N = Node.GetElementsByTagName("LastStamp")[0];
			if (N != null)
				if (N.HasChildNodes)
					FLastStamp = DateTime.Parse(N.ChildNodes.Item(0).Value);
            N = Node.GetElementsByTagName("MailNotice")[0];
            if (N != null)
                if (N.HasChildNodes)
                    FMailNotice = bool.Parse(N.ChildNodes.Item(0).Value);
		}

		public bool Scheduled()
		{
			if (Active)
			{
				if ((LastStamp.Date != DateTime.Now.Date) ||
					(LastStamp.Hour != DateTime.Now.Hour) ||
					(LastStamp.Minute != DateTime.Now.Minute))
				{
					bool YesDate = false;
					bool YesTime = false;
					if (ReservDay == DateTime.Today)
						YesDate = true;
					else
					{
						if (!Periodical)
						{
							YesDate = DateTime.Now.Date == OnceDate;
						}
						else
						{
							switch (Everies)
							{
								case 1:
									YesDate = Math.Abs((DateTime.Now - LastStamp).TotalDays) >= Period - 1;
									break;
								case 2:
									byte CurDay = 0;
									switch (DateTime.Now.DayOfWeek)
									{
										case System.DayOfWeek.Monday:
											CurDay = 1;
											break;
										case System.DayOfWeek.Tuesday:
											CurDay = 2;
											break;
										case System.DayOfWeek.Wednesday:
											CurDay = 4;
											break;
										case System.DayOfWeek.Thursday:
											CurDay = 8;
											break;
										case System.DayOfWeek.Friday:
											CurDay = 16;
											break;
										case System.DayOfWeek.Saturday:
											CurDay = 32;
											break;
										case System.DayOfWeek.Sunday:
											CurDay = 64;
											break;
									}
									YesDate = ((DateTime.Now - LastStamp).TotalDays >= Period * 7) && ((CurDay & DayOfWeek) != 0);
									break;
								case 3:
									int M = DateTime.Now.Month + (DateTime.Now.Year - LastStamp.Year) * 12;
									YesDate = ((M - LastStamp.Month) >= Period) && (DateTime.Now.Day == DayOfMonth);
									break;
							}
						}
					}
					if (YesDate)
						ReservDay = DateTime.Today;
					if (!PeriodicalTime)
					{
						YesTime = (DateTime.Now.Hour == OnceTime.Hour) && (DateTime.Now.Minute == OnceTime.Minute);
					}
					else
					{
						YesTime = (DateTime.Now - LastStamp).TotalHours >= EveryTime;
					}
					if (YesDate && YesTime)
						if ((LastStamp.Date != DateTime.Now.Date) ||
							(LastStamp.Hour != DateTime.Now.Hour) ||
							(LastStamp.Minute != DateTime.Now.Minute))
							return true;
				}
			}
			return false;
		}

		public virtual void Paint(Graphics Gr, Rectangle Rect, DrawItemEventArgs e)
		{
			Brush B, TB;
			if ((e.State & DrawItemState.Selected) == 0)
			{
				B = SystemBrushes.ButtonFace;
				TB = SystemBrushes.WindowText;
			}
			else
			{
				B = SystemBrushes.Highlight;
				TB = SystemBrushes.HighlightText;
			}
			Gr.FillRectangle(SystemBrushes.Window, 0, 0, Rect.Width, Rect.Height);
			Gr.FillRectangle(B, new Rectangle(1, 1, Rect.Width - 2, 18));
			Gr.DrawRectangle(SystemPens.ButtonFace, new Rectangle(1, 1, Rect.Width - 3, Rect.Height - 2));
			if (Checked)
				CheckBoxRenderer.DrawCheckBox(Gr, new Point(3, 4),
					System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal);
			else
				CheckBoxRenderer.DrawCheckBox(Gr, new Point(3, 4),
					System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
			string FirstStr = Name;
			if (Active)
				FirstStr += " (автоматическая архивация)";
			Gr.DrawString(FirstStr, SystemFonts.DefaultFont, TB, 20, 3);
			if (LastStamp.Year > 1)
				Gr.DrawString(LastStamp.ToString(), SystemFonts.DefaultFont, TB, Rect.Width - 130, 3);
		}

        public virtual bool Run(LogBackupInterface Log)
        {
            this.Log.SetOld();
            return true; 
        }

        public void SendMailNotice(LogBackupInterface Log)
        {
            if (MailNotice)
            {
                string Subject = "Egida Backup - отчет о выполнении задания " + Name + " " + DateTime.Now.ToString();
                string Body = "Задание: " + Name + "<br>" +
                    "Дата: " + LastStamp.ToString() + "<br><br>" +
                    "Лог сообщений:<br>";
                foreach (LogItem L in this.Log.List)
                    if (L.Label==LogItemLabel.New)
                        Body += " >> "+L.Stamp.ToString() + " " + L.Text + "<br>";
                Utils.SendMail(this, Subject, Body, Log);
                this.Log.SetOld();
            }
        }

	}

    public class BackupItem : TaskItem
    {
        List<string> FDest=new List<string>();
        int FSaveTime = 0; //срок хранения архива в часах
        int FCountSave = 0; //количество копий
        int FDepositorySize = 0; //объем хранилища в мегах

		//снимки
		bool FSnapshot = false; //создавать снимки резарвных копий
		int FSnapshotInterval = 1; //интервал создания
		byte FSnapshotIntType = 1; //1 - недели, 2 - месяцы
		DateTime FSnapshotStamp = DateTime.Now; //дата последнего снимка
		string FSnapshotDir = ""; //директория снимков

        public List<string> Dest
		{
			get { return FDest; }
		}
        public int SaveTime
        {
            get { return FSaveTime; }
            set { FSaveTime = value; }
        }
        public int CountSave
        {
            get { return FCountSave; }
            set { FCountSave = value; }
        }
        public int DepositorySize
        {
            get { return FDepositorySize; }
            set { FDepositorySize = value; }
        }
		public bool Snapshot
		{
			get { return FSnapshot; }
			set { FSnapshot = value; }
		}
		public int SnapshotInterval
		{
			get { return FSnapshotInterval; }
			set { FSnapshotInterval = value; }
		}
		public byte SnapshotIntType
		{
			get { return FSnapshotIntType; }
			set { FSnapshotIntType = value; }
		}
		public DateTime SnapshotStamp
		{
			get { return FSnapshotStamp; }
			set { FSnapshotStamp = value; }
		}
		public string SnapshotDir
		{
			get { return FSnapshotDir; }
			set { FSnapshotDir = value; }
		}

        protected const int CopyBufferSize = 32768; //размер буфера копирования

        public override void Save(XmlDocument Doc, XmlNode Node)
        {
            base.Save(Doc, Node);
            XmlNode N, N1;
            N = Node.AppendChild(Doc.CreateElement("Destination"));
            foreach (string P in FDest)
            {
                N1 = N.AppendChild(Doc.CreateElement("Dest"));
                N1.AppendChild(Doc.CreateTextNode(P));
            }
            N = Node.AppendChild(Doc.CreateElement("SaveTime"));
            N.AppendChild(Doc.CreateTextNode(FSaveTime.ToString()));
            N = Node.AppendChild(Doc.CreateElement("CountSave"));
            N.AppendChild(Doc.CreateTextNode(FCountSave.ToString()));
            N = Node.AppendChild(Doc.CreateElement("DepositorySize"));
            N.AppendChild(Doc.CreateTextNode(FDepositorySize.ToString()));
			//снимки
			N = Node.AppendChild(Doc.CreateElement("Snapshot"));
			N.AppendChild(Doc.CreateTextNode(FSnapshot.ToString()));
			N = Node.AppendChild(Doc.CreateElement("SnapshotInterval"));
			N.AppendChild(Doc.CreateTextNode(FSnapshotInterval.ToString()));
			N = Node.AppendChild(Doc.CreateElement("SnapshotIntType"));
			N.AppendChild(Doc.CreateTextNode(FSnapshotIntType.ToString()));
			N = Node.AppendChild(Doc.CreateElement("SnapshotStamp"));
			N.AppendChild(Doc.CreateTextNode(FSnapshotStamp.ToString()));
			N = Node.AppendChild(Doc.CreateElement("SnapshotDir"));
			N.AppendChild(Doc.CreateTextNode(FSnapshotDir));
        }

        public override void Load(XmlElement Node)
        {
            base.Load(Node);
            XmlNode N;

            N = Node.GetElementsByTagName("Destination")[0];
            if (N != null)
                foreach (XmlNode N1 in N)
                    if (N1.HasChildNodes && N1.Name == "Dest")
                        FDest.Add(N1.ChildNodes.Item(0).Value);
            N = Node.GetElementsByTagName("SaveTime")[0];
            if (N != null)
                if (N.HasChildNodes)
                    FSaveTime = byte.Parse(N.ChildNodes.Item(0).Value);
            N = Node.GetElementsByTagName("CountSave")[0];
            if (N != null)
                if (N.HasChildNodes)
                    FCountSave = int.Parse(N.ChildNodes.Item(0).Value);
            N = Node.GetElementsByTagName("DepositorySize")[0];
            if (N != null)
                if (N.HasChildNodes)
                    FDepositorySize = int.Parse(N.ChildNodes.Item(0).Value);
			//снимки
			N = Node.GetElementsByTagName("Snapshot")[0];
			if (N != null)
				if (N.HasChildNodes)
					FSnapshot = bool.Parse(N.ChildNodes.Item(0).Value);
			N = Node.GetElementsByTagName("SnapshotInterval")[0];
			if (N != null)
				if (N.HasChildNodes)
					FSnapshotInterval = int.Parse(N.ChildNodes.Item(0).Value);
			N = Node.GetElementsByTagName("FSnapshotIntType")[0];
			if (N != null)
				if (N.HasChildNodes)
					FSnapshotIntType = byte.Parse(N.ChildNodes.Item(0).Value);
			N = Node.GetElementsByTagName("SnapshotStamp")[0];
			if (N != null)
				if (N.HasChildNodes)
					FSnapshotStamp = DateTime.Parse(N.ChildNodes.Item(0).Value);
			N = Node.GetElementsByTagName("SnapshotDir")[0];
			if (N != null)
				if (N.HasChildNodes)
					FSnapshotDir = N.ChildNodes.Item(0).Value;
        }

        protected void ProcessLogFile(XmlDocument Doc, string P, LogBackupInterface Log)
        {
            if (SaveTime > 0 || CountSave > 0 || DepositorySize > 0)
            {
                int needremove = Doc.DocumentElement.ChildNodes.Count - CountSave + 1;
                int depository = 0;

                #region подсчет объема хранилища
                foreach (XmlNode N in Doc.DocumentElement)
                    if (N.Name == "Backup")
                        try
                        {
                            depository += int.Parse(N.Attributes["Size"].Value);
                        }
                        catch { }
                #endregion

                List<XmlNode> removes = new List<XmlNode>();
                foreach (XmlNode N in Doc.DocumentElement)
                    if (N.Name == "Backup")
                    {
                        bool del = false;
                        if (SaveTime > 0)
                        {
                            DateTime DT = DateTime.Parse(N.Attributes["Stamp"].Value);
                            if ((DateTime.Now - DT).Days >= SaveTime)
                            {
                                del = true;
                            }
                        }
                        if (CountSave > 0)
                        {
                            if (needremove > 0)
                            {
                                del = true;
                                needremove--;
                            }
                        }
                        if (DepositorySize > 0)
                            if (depository > DepositorySize * 1048576)
                            {
                                try
                                {
                                    depository -= int.Parse(N.Attributes["Size"].Value);
                                    del = true;
                                }
                                catch { }
                            }
                        if (del)
                        {
                            string fname = N.Attributes["Filename"].Value;
                            try
                            {
                                if (N.Attributes["Dir"] != null && N.Attributes["Dir"].Value == "true")
                                {
                                    Directory.Delete(System.IO.Path.Combine(P, fname), true);
                                    //if (!Directory.Exists(System.IO.Path.Combine(P, fname)))
                                    //	removes.Add(N);
                                }
                                else
                                {
                                    File.Delete(System.IO.Path.Combine(P, fname));
                                    //if (!File.Exists(System.IO.Path.Combine(P, fname)))
                                    //	removes.Add(N);
                                }
                                Log.InvokeAddLogItem(this, "Удалена архивная копия " + System.IO.Path.Combine(P, fname), LogItemType.Warning);
                            }
                            catch (Exception ex)
                            {
                                Log.InvokeAddLogItem(this, ex.Message, LogItemType.Error);
                            }
                            if (N.Attributes["Dir"] != null && N.Attributes["Dir"].Value == "true")
                            {
                                if (!Directory.Exists(System.IO.Path.Combine(P, fname)))
                                    removes.Add(N);
                            }
                            else
                            {
                                if (!File.Exists(System.IO.Path.Combine(P, fname)))
                                    removes.Add(N);
                            }
                        }

                    }
                foreach (XmlNode N in removes)
                    Doc.DocumentElement.RemoveChild(N);
                removes.Clear();
            }
        }

        protected void ClearLogFile(XmlDocument Doc, string P)
        {
            List<XmlNode> removes = new List<XmlNode>();
            foreach (XmlNode N in Doc.DocumentElement)
                if (N.Name == "Backup")
                {
                    string fname = N.Attributes["Filename"].Value;
                    if (N.Attributes["Dir"] != null && N.Attributes["Dir"].Value == "true")
                    {
                        if (!Directory.Exists(System.IO.Path.Combine(P, fname)))
                            removes.Add(N);
                    }
                    else
                    {
                        if (!File.Exists(System.IO.Path.Combine(P, fname)))
                            removes.Add(N);
                    }
                }
            foreach (XmlNode N in removes)
                Doc.DocumentElement.RemoveChild(N);
            removes.Clear();
        }

        public override bool Run(LogBackupInterface Log)
        {
            base.Run(Log);
            if (Dest.Count == 0)
            {
                Log.InvokeAddLogItem(this, "Не указан ни один каталог назначения резервной копии", LogItemType.Error);
                return false;
            }
			if (SnapshotSheduled())
				CreateSnapshot(Log);
            return true;
        }

        public virtual bool BackupTo(string Filename, LogBackupInterface Log)
        {
            this.Log.SetOld();
            return true;
        }

		public bool SnapshotSheduled()
		{
			bool res = false;
			if (FSnapshot && FSnapshotInterval>0)
			{
				switch (FSnapshotIntType)
				{
					case 1:
						res = (DateTime.Now-FSnapshotStamp).Days >= 7 * FSnapshotInterval;
						break;
					case 2:
						res = (FSnapshotStamp.Month != DateTime.Now.Month);
						break;
				}
			}
			return res;
		}

		public void CreateSnapshot(LogBackupInterface Log)
		{
			if (FDest.Count > 0 && Directory.Exists(FSnapshotDir))
				try
				{
					string SnapshotFolder = Path.Combine(SnapshotDir, Name + "(Snapshot)" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"));
					Log.InvokeAddLogItem(this, "Создание снимка " + SnapshotFolder, LogItemType.Information);
					Directory.CreateDirectory(SnapshotFolder);
					XmlDocument Doc = new XmlDocument();
					Doc.Load(Path.Combine(FDest[0], Name+".log"));
					ClearLogFile(Doc, FDest[0]);
					Log.InvokeSetProgress(0);
					foreach (XmlNode N in Doc.DocumentElement)
					{
						if (N.Attributes["Dir"] != null && N.Attributes["Dir"].Value == "true")
						{
							try
							{
								Utils.CopyDirectory(this, Path.Combine(FDest[0], N.Attributes["Filename"].Value),
										Path.Combine(SnapshotFolder, N.Attributes["Filename"].Value), "*.*", Log);
								Directory.Delete(Path.Combine(FDest[0], N.Attributes["Filename"].Value), true);
							}
							catch (Exception ex)
							{
                                Log.InvokeAddLogItem(this, "Снимок: " + ex.Message, LogItemType.Error);
							}
						}
						else
							try
							{
								Utils.CopyFile(Path.Combine(FDest[0], N.Attributes["Filename"].Value),
									Path.Combine(SnapshotFolder, N.Attributes["Filename"].Value), Log);
								File.Delete(Path.Combine(FDest[0], N.Attributes["Filename"].Value));
							}
							catch (Exception ex)
							{
								Log.InvokeAddLogItem(this, "Снимок: "+ex.Message, LogItemType.Error);
							}
					}
					SnapshotStamp = DateTime.Now;
					ClearLogFile(Doc, FDest[0]);
					Doc.Save(Path.Combine(FDest[0], Name + ".log"));
				}
				catch (Exception ex)
				{
					Log.InvokeAddLogItem(this, "Снимок: "+ex.Message, LogItemType.Error);
				}
		}

        public virtual void Report_Backup(ReportClass Report)
        {
            Report.WriteH2("Задание «" + Name + "»");
            Report_BackupsList(Report);
            Report.WriteLine("<br>");
        }

        public virtual void Report_BackupSmall(ReportClass Report)
        {
            Report.WriteH2("Задание «" + Name + "»");
            Report_BackupsListSmall(Report);
            Report.WriteLine("<br>");
        }

        protected virtual void Report_BackupsList(ReportClass Report)
        {
            foreach (string P in Dest)
            {
                Report.WriteP("<b>Каталог копирования:</b> "+P);
                XmlDocument Doc = new XmlDocument();
                try
                {
                    Doc.Load(System.IO.Path.Combine(P, Name + ".log"));
                }
                catch { break; }
                Report.WriteTableHeader(new string[] { "Дата", "Файл", "Размер" });
                if (Doc.DocumentElement.Name == "BackupManager")
                {
                    foreach (XmlNode N in Doc.DocumentElement.ChildNodes)
                        if (N.Name == "Backup")
                        {
                            string Stamp = N.Attributes["Stamp"] != null ? N.Attributes["Stamp"].Value : "";
                            string Filename = N.Attributes["Filename"] != null ? N.Attributes["Filename"].Value : "";
                            string Filesize = N.Attributes["Size"] != null ? N.Attributes["Size"].Value : "";
                            Report.WriteTableRow(new string[] {Stamp, Filename, Filesize});
                        }
                }
                Report.WriteTableFooter();
            }
        }

        protected virtual void Report_BackupsListSmall(ReportClass Report)
        {
            foreach (string P in Dest)
            {
                Report.WriteLine("Каталог копирования: " + P);
            }
        }
    }

    public class CatalogBackupItem: BackupItem
    {
        string FPath=""; //резервируемый каталог
		
		bool FArchive = true; //архивировать в зип
		byte FCompress = 5; //степент сжатия
		bool FIncrement = false; // инкрементное копирование
		string FFileMask = "*.*"; //маска файлов
		bool FRecoveryPoint = false; //резервировать как точки восстановления
        bool FUsePassword = false;
        string FZipPassword = "";

		public string Path
        {
            get { return FPath; }
            set { FPath = value; }
        }
		public bool Archive
		{
			get { return FArchive; }
			set { FArchive = value; }
		}
		public byte Compress
		{
			get { return FCompress; }
			set { FCompress = value; }
		}
		public bool Increment
		{
			get { return FIncrement; }
			set { FIncrement = value; }
		}
		public string FileMask
		{
			get { return FFileMask; }
			set { FFileMask = value; }
		}
		public bool RecoveryPoint
		{
			get { return FRecoveryPoint; }
			set { FRecoveryPoint = value; }
		}
        public bool UsePassword
        {
            get { return FUsePassword; }
            set { FUsePassword = value; }
        }
        public string ZipPassword
        {
            get { return FZipPassword; }
            set { FZipPassword=value; }
        }

        public CatalogBackupItem()
        { 

        }

        public override void Save(XmlDocument Doc, XmlNode Node)
        {
			base.Save(Doc, Node);
			XmlNode N;
			N = Node.AppendChild(Doc.CreateElement("Path"));
			N.AppendChild(Doc.CreateTextNode(FPath));
			N = Node.AppendChild(Doc.CreateElement("Archive"));
			N.AppendChild(Doc.CreateTextNode(FArchive.ToString()));
			N = Node.AppendChild(Doc.CreateElement("Compress"));
			N.AppendChild(Doc.CreateTextNode(FCompress.ToString()));
			N = Node.AppendChild(Doc.CreateElement("Increment"));
			N.AppendChild(Doc.CreateTextNode(FIncrement.ToString()));
            
			N = Node.AppendChild(Doc.CreateElement("FileMask"));
			N.AppendChild(Doc.CreateTextNode(FFileMask));
			N = Node.AppendChild(Doc.CreateElement("RecoveryPoint"));
			N.AppendChild(Doc.CreateTextNode(FRecoveryPoint.ToString()));

            N = Node.AppendChild(Doc.CreateElement("UsePassword"));
            N.AppendChild(Doc.CreateTextNode(FUsePassword.ToString()));
            N = Node.AppendChild(Doc.CreateElement("ZipPassword"));
            N.AppendChild(Doc.CreateTextNode(Convert.ToBase64String(Encoding.UTF8.GetBytes(FZipPassword.ToString()))));
        }

		public override void Load(XmlElement Node)
		{
			base.Load(Node);
			XmlNode N;
			N = Node.GetElementsByTagName("Path")[0];
			if (N != null)
				if (N.HasChildNodes)
					FPath = N.ChildNodes.Item(0).Value;
			N = Node.GetElementsByTagName("Archive")[0];
			if (N != null)
				if (N.HasChildNodes)
					FArchive = bool.Parse(N.ChildNodes.Item(0).Value);
			N = Node.GetElementsByTagName("Compress")[0];
			if (N != null)
				if (N.HasChildNodes)
					FCompress = byte.Parse(N.ChildNodes.Item(0).Value);
			N = Node.GetElementsByTagName("Increment")[0];
			if (N != null)
				if (N.HasChildNodes)
					FIncrement = bool.Parse(N.ChildNodes.Item(0).Value);
			N = Node.GetElementsByTagName("FileMask")[0];
			if (N != null)
				if (N.HasChildNodes)
					FFileMask = N.ChildNodes.Item(0).Value;
			N = Node.GetElementsByTagName("RecoveryPoint")[0];
			if (N != null)
				if (N.HasChildNodes)
					FRecoveryPoint = bool.Parse(N.ChildNodes.Item(0).Value);

            //использование пароля
            N = Node.GetElementsByTagName("UsePassword")[0];
            if (N != null)
                if (N.HasChildNodes)
                    FUsePassword = bool.Parse(N.ChildNodes.Item(0).Value);
            N = Node.GetElementsByTagName("ZipPassword")[0];
            if (N != null)
                if (N.HasChildNodes)
                    try
                    {
                        FZipPassword = Encoding.UTF8.GetString(Convert.FromBase64String(N.ChildNodes.Item(0).Value));
                    }
                    catch { }
		}

		public bool Zip(LogBackupInterface Log)
		{
			if (Path == "")
				return false;
            bool result = true;
			string TempFile = System.IO.Path.Combine(System.IO.Path.GetTempPath(), @"_backup_" + Name + ".zip");

			try
			{
                if (ZipTo(TempFile, "", Log))
                {

                    foreach (string P in Dest)
                    {

                        //проверка на старые копии
                        XmlDocument Doc = new XmlDocument();
                        if (File.Exists(System.IO.Path.Combine(P, Name + ".log")))
                            Doc.Load(System.IO.Path.Combine(P, Name + ".log"));
                        else
                        {
                            Doc.AppendChild(Doc.CreateElement("BackupManager"));
                        }
                        ProcessLogFile(Doc, P, Log);
                        ClearLogFile(Doc, P);

                        //создание новой копии
                        DateTime NowDate = DateTime.Now;
                        string BackupFile = Name + " " + NowDate.ToString("yyyy-MM-dd HH-mm-ss") + ".zip";
                        Log.InvokeSetStatusLabel("Создание резервной копии " + System.IO.Path.Combine(P, BackupFile));
                        try
                        {
                            Utils.CopyFile(TempFile, System.IO.Path.Combine(P, BackupFile), Log);
                            XmlNode N1 = Doc.CreateElement("Backup");
                            Doc.DocumentElement.AppendChild(N1);
                            N1.Attributes.Append(Doc.CreateAttribute("Stamp")).Value = NowDate.ToString();
                            N1.Attributes.Append(Doc.CreateAttribute("Filename")).Value = BackupFile;
                            N1.Attributes.Append(Doc.CreateAttribute("Size")).Value = (new FileInfo(System.IO.Path.Combine(P, BackupFile))).Length.ToString();
                            Log.InvokeAddLogItem(this, "Создана архивная копия " +
                                System.IO.Path.Combine(P, BackupFile),
                                LogItemType.Information);
                        }
                        catch (Exception ex)
                        {
                            Log.InvokeAddLogItem(this, "Копия (Zip, OldCopy): " + ex.Message, LogItemType.Error);
                            result = false;
                        }

                        try
                        {
                            XmlTextWriter XW = new XmlTextWriter(System.IO.Path.Combine(P, Name + ".log"), Encoding.UTF8);
                            XW.Formatting = Formatting.Indented;
                            XW.Indentation = 4;
                            Doc.Save(XW);
                            XW.Close();
                        }
                        catch (Exception ex)
                        {
                            Log.InvokeAddLogItem(this, "Копия (Zip, XML): " + ex.Message, LogItemType.Error);
                        }
                    }

                    File.Delete(TempFile);
                }
                else
                    result = false;
			}
			catch (System.Exception ex)
			{
                Log.InvokeAddLogItem(this, "Копия (Zip, Global): " + ex.Message, LogItemType.Error);
                result = false;
				//if (Output != null)
				//	Output.Dispose();
			}
			Log.InvokeSetStatusLabel("");
            return result;
		}

        public bool ZipRecoveryPoint(LogBackupInterface Log) 
        {
            if (Path == "")
                return false;
            bool result = true;
            try
            {
                foreach (string P in Dest)
                {
                    XmlDocument Doc = new XmlDocument();
                    if (File.Exists(System.IO.Path.Combine(P, Name + ".log")))
                        Doc.Load(System.IO.Path.Combine(P, Name + ".log"));
                    else
                    {
                        Doc.AppendChild(Doc.CreateElement("BackupManager"));
                    }
                    //создание новой копии
                    DateTime NowDate = DateTime.Now;
                    string BackupFile = Name + " " + NowDate.ToString("yyyy-MM-dd HH-mm-ss") + ".zip";
                    Log.InvokeSetStatusLabel("Создание резервной копии " + System.IO.Path.Combine(P, BackupFile));
                    if (ZipTo(System.IO.Path.Combine(P, BackupFile), P, Log))
                    {
                        try
                        {
                            XmlNode N1 = Doc.CreateElement("Backup");
                            Doc.DocumentElement.AppendChild(N1);
                            N1.Attributes.Append(Doc.CreateAttribute("Stamp")).Value = NowDate.ToString();
                            N1.Attributes.Append(Doc.CreateAttribute("Filename")).Value = BackupFile;
                            N1.Attributes.Append(Doc.CreateAttribute("Size")).Value = (new FileInfo(System.IO.Path.Combine(P, BackupFile))).Length.ToString();
                            Log.InvokeAddLogItem(this, "Создана архивная копия " +
                                System.IO.Path.Combine(P, BackupFile),
                                LogItemType.Information);
                        }
                        catch (Exception ex)
                        {
                            Log.InvokeAddLogItem(this, "Точка восстановления: " + ex.Message, LogItemType.Error);
                            result = false;
                        }
                        ClearLogFile(Doc, P);
                        try
                        {
                            XmlTextWriter XW = new XmlTextWriter(System.IO.Path.Combine(P, Name + ".log"), Encoding.UTF8);
                            XW.Formatting = Formatting.Indented;
                            XW.Indentation = 4;
                            Doc.Save(XW);
                            XW.Close();
                        }
                        catch (Exception ex)
                        {
                            Log.InvokeAddLogItem(this, "Точка восстановления: " + ex.Message, LogItemType.Error);
                        }
                    }
                    else
                        result = false;
                }
            }
            catch (System.Exception ex)
            {
                Log.InvokeAddLogItem(this, "Точка восстановления: " + ex.Message, LogItemType.Error);
                result = false;
            }
            Log.InvokeSetStatusLabel("");
            return result;
        }

		public bool ZipTo(string Filename, string RecoveryPath, LogBackupInterface Log)
		{
			FileStream Output = null;
			ZipOutputStream Zip;
			

			if (Path == "")
				return false;

			Log.InvokeAddLogItem(this, "Начало архивации " + Path, LogItemType.Information);
			try
			{
				Output = File.Create(Filename);
				Zip = new ZipOutputStream(Output);
                if (UsePassword)
                    Zip.Password = ZipPassword;

				Zip.SetLevel(Compress);

				ArrayList filenames =  GenerateFiles(Path, FFileMask, SearchOption.AllDirectories);
				//string[] filenames = Directory.GetFiles(Path, "*.*", SearchOption.AllDirectories);
				Int64 TotalFilesSize = 0;
				Int64 TotalFilesZipped = 0;
				bool CanCopy;
				foreach (string fname in filenames)
					//if (!fname.EndsWith("\\"))
						TotalFilesSize += (new FileInfo(fname)).Length;
				byte[] buffer = new byte[CopyBufferSize];
				int TrimLength = Path.Length + 1;
				Log.InvokeSetProgress(0);
				foreach (string fname in filenames)
				{
					Log.InvokeSetStatusLabel(fname);
					CanCopy = true;
					if (RecoveryPath!="" && RecoveryPoint)
						if (GetFileDate(RecoveryPath, fname.Remove(0, TrimLength)) >= File.GetLastWriteTime(fname))
							CanCopy = false;
					if (CanCopy)
					{
						ZipEntry ent = new ZipEntry(fname.Remove(0, TrimLength));
						ent.Size = (new FileInfo(fname)).Length;
						Zip.PutNextEntry(ent);
						FileStream source = new FileStream(fname, FileMode.Open, FileAccess.Read, FileShare.Read);
						int sourcebyte;
						do
						{
							sourcebyte = source.Read(buffer, 0, buffer.Length);
							Zip.Write(buffer, 0, sourcebyte);
							TotalFilesZipped += sourcebyte;
							Log.InvokeSetProgress((int)(((double)TotalFilesZipped / (double)TotalFilesSize) * 100));
						}
						while (sourcebyte > 0);
						source.Close();
						source.Dispose();
						Zip.CloseEntry();
					}
					else
					{
						TotalFilesZipped += (new FileInfo(fname)).Length;
						Log.InvokeSetProgress((int)(((double)TotalFilesZipped / (double)TotalFilesSize) * 100));
					}
				}

				Zip.Finish();
				Zip.Close();
				Output.Close();
				Output.Dispose();
				Output = null;

				Log.InvokeAddLogItem(this, "Конец архивации " + Path, LogItemType.Information);
				//Log.InvokeAddLogItem("Создана архивная копия " + Filename, LogItemType.Information);
				return true;
			}
			catch (Exception ex)
			{
                Log.InvokeAddLogItem(this, "Архивирование: " + ex.Message, LogItemType.Error);
				return false;
			}
		}

		public bool Copy(LogBackupInterface Log)
		{
			if (Path == "")
                return false;
            bool result = true;
			try
			{
				foreach (string P in Dest)
				{
					//проверка на старые копии
					XmlDocument Doc = new XmlDocument();
					if (File.Exists(System.IO.Path.Combine(P, Name + ".log")))
						Doc.Load(System.IO.Path.Combine(P, Name + ".log"));
					else
					{
						Doc.AppendChild(Doc.CreateElement("BackupManager"));
					}
					if (!RecoveryPoint)
					{
						ProcessLogFile(Doc, P, Log);
						ClearLogFile(Doc, P);
					}
					//создание новой копии
					DateTime NowDate = DateTime.Now;
					string BackupFile = Name + " " + NowDate.ToString("yyyy-MM-dd HH-mm-ss");
					Log.InvokeSetStatusLabel("Создание резервной копии " + System.IO.Path.Combine(P, BackupFile));
					try
					{
						Log.InvokeSetProgress(0);
						if (RecoveryPoint)
							CopyDirectory(Path, System.IO.Path.Combine(P, BackupFile), P, Log);
						else
							CopyDirectory(Path, System.IO.Path.Combine(P, BackupFile), "", Log);
						XmlNode N1 = Doc.CreateElement("Backup");
						Doc.DocumentElement.AppendChild(N1);
						N1.Attributes.Append(Doc.CreateAttribute("Stamp")).Value = NowDate.ToString();
						N1.Attributes.Append(Doc.CreateAttribute("Filename")).Value = BackupFile;
						N1.Attributes.Append(Doc.CreateAttribute("Dir")).Value = "true";
						N1.Attributes.Append(Doc.CreateAttribute("Size")).Value = DirectorySize(System.IO.Path.Combine(P, BackupFile)).ToString();
						Log.InvokeAddLogItem(this, "Создана архивная копия " +
							System.IO.Path.Combine(P, BackupFile),
							LogItemType.Information);
					}
					catch (Exception ex)
					{
						Log.InvokeAddLogItem(this, "Создание копии: "+ex.Message, LogItemType.Error);
                        result = false;
					}

					try
					{
						XmlTextWriter XW = new XmlTextWriter(System.IO.Path.Combine(P, Name + ".log"), Encoding.UTF8);
						XW.Formatting = Formatting.Indented;
						XW.Indentation = 4;
						Doc.Save(XW);
						XW.Close();
					}
					catch (Exception ex)
					{
                        Log.InvokeAddLogItem(this, "Создание копии: " + ex.Message, LogItemType.Error);
					}
				}
			}
			catch (System.Exception ex)
			{
                Log.InvokeAddLogItem(this, "Создание копии: " + ex.Message, LogItemType.Error);
                result = false;
			}
			Log.InvokeSetStatusLabel("");
            return result;
		}

		public bool IncrementCopy(LogBackupInterface Log)
		{
			if (Path == "")
                return false;
            bool result = true;
			try
			{
				foreach (string P in Dest)
				{
					
					//создание новой копии
					Log.InvokeSetStatusLabel("Создание резервной копии " + P);
					try
					{
						Directory.CreateDirectory(System.IO.Path.Combine(P, Name));
						int current = 0;
						int count = Directory.GetFiles(Path, "*.*", SearchOption.AllDirectories).Length;
						Log.InvokeSetProgress(0);
						CopyDirectory(Path, System.IO.Path.Combine(P, Name), count, ref current, "", "", Log);
						Log.InvokeAddLogItem(this, "Создана архивная копия " + System.IO.Path.Combine(P, Name),
							LogItemType.Information);
					}
					catch (Exception ex)
					{
                        Log.InvokeAddLogItem(this, "Инкремент: " + ex.Message, LogItemType.Error);
                        result = false;
					}

				}
			}
			catch (Exception ex)
			{
                Log.InvokeAddLogItem(this, "Инкремент: " + ex.Message, LogItemType.Error);
                result = false;
			}
			Log.InvokeSetStatusLabel("");
            return result;
		}

		public override bool Run(LogBackupInterface Log)
		{
            if (base.Run(Log))
            {
                if (Archive)
                {
                    if (RecoveryPoint)
                        return ZipRecoveryPoint(Log);
                    else
                        return Zip(Log);
                }
                else
                {
                    if (Increment)
                        return IncrementCopy(Log);
                    else
                    {
                        return Copy(Log);
                    }
                }
            }
            return true;
		}

		public override bool BackupTo(string Filename, LogBackupInterface Log)
		{
            if (base.BackupTo(Filename, Log))
            {
                if (Archive)
                    ZipTo(Filename, "", Log);
                else
                {
                    CopyDirectory(Path, Filename, "", Log);
                }
            }
            return true;
		}

		ArrayList GenerateFiles(string PathString, string FileMask, SearchOption SO)
		{
			if (FileMask == "")
				FileMask = "*.*";
			ArrayList Files = new ArrayList();
			string[] Masks = FileMask.Split(';');
			foreach (string M in Masks)
				Files.AddRange(Directory.GetFiles(PathString, M.Trim(), SO));
			return Files;
		}

		bool CopyDirectory(string source, string dest, string RecoveryPath, LogBackupInterface Log)
		{
			int current = 0;
			int count = GenerateFiles(Path, FileMask, SearchOption.AllDirectories).Count;
			Log.InvokeAddLogItem(this, "Начало копирования каталога " + source, LogItemType.Information);
			return CopyDirectory(source, dest, count, ref current, RecoveryPath, dest, Log);
		}

		bool CopyDirectory(string source, string dest, int count, ref int current, string RecoveryPath, string BackupRoot, LogBackupInterface Log)
		{
			try
			{
				Directory.CreateDirectory(dest);
				string[] dirs = Directory.GetDirectories(source);
				ArrayList files = GenerateFiles(source, FileMask, SearchOption.TopDirectoryOnly);
				bool CanCopy;
				foreach (string file in files)
				{
					Log.InvokeSetStatusLabel(file);
					CanCopy = true;
					if (RecoveryPath != "")
						if (GetFileDate(RecoveryPath, System.IO.Path.Combine(dest, System.IO.Path.GetFileName(file)).Remove(0, BackupRoot.Length + 1)) >= File.GetLastWriteTime(file))
							CanCopy = false;
					if (CanCopy)
						Utils.CopyFile(file, System.IO.Path.Combine(dest, System.IO.Path.GetFileName(file)), null);
					current++;
					Log.InvokeSetProgress((int)((float)current / (float)count * 100.0f));
				}
				foreach (string dir in dirs)
				{
					CopyDirectory(dir, System.IO.Path.Combine(dest, System.IO.Path.GetFileName(dir)), count, ref current, RecoveryPath, BackupRoot, Log);
				}
				return true;
			}
			catch (Exception ex)
			{
                Log.InvokeAddLogItem(this, "Копирование директории: " + ex.Message, LogItemType.Error);
				return false;
			}
		}
		
		long DirectorySize(string P)
		{
			string[] filenames = Directory.GetFiles(P, "*.*", SearchOption.AllDirectories);
			long l = 0;
			foreach (string f in filenames)
				l += (new FileInfo(f)).Length;
			return l;
		}

		public override void Paint(Graphics Gr, Rectangle Rect, DrawItemEventArgs e)
		{
			base.Paint(Gr, Rect, e);
			Gr.DrawString("Путь: " + Path, e.Font, SystemBrushes.WindowText, 5, 20);
            Gr.DrawString("Директории для архивных копий:", SystemFonts.DefaultFont, SystemBrushes.WindowText, 5, 35);
			for (int i = 0; (i < Dest.Count) && (i < 2); i++)
			{
				Gr.DrawString(Dest[i], e.Font, Brushes.Blue, 180, 35 + i * 15);
			}
		}

		DateTime GetFileDate(string P, string Filename)
		{
			XmlDocument Doc = new XmlDocument();
			if (File.Exists(System.IO.Path.Combine(P, Name + ".log")))
				Doc.Load(System.IO.Path.Combine(P, Name + ".log"));
			if (Doc.DocumentElement != null)
			{
				for (int i = Doc.DocumentElement.ChildNodes.Count - 1; i >= 0; i-- )
				{
					XmlNode Node = Doc.DocumentElement.ChildNodes[i];
					if (Node.Name == "Backup")
					{
						if (Node.Attributes["Dir"] != null && Node.Attributes["Dir"].Value == "true")
						{
							//в каталоге
							if (File.Exists(System.IO.Path.Combine(System.IO.Path.Combine(P, Node.Attributes["Filename"].Value), Filename)))
								return DateTime.Parse(Node.Attributes["Stamp"].Value);
						}
						else
						{
							//в архиве
                            try
                            {
                                ZipFile Zip = new ZipFile(System.IO.Path.Combine(P, Node.Attributes["Filename"].Value));
                                ZipEntry ent = Zip.GetEntry(Filename);
                                Zip.Close();
                                if (ent != null)
                                    return DateTime.Parse(Node.Attributes["Stamp"].Value);
                            }
                            catch { }
						}
					}
				}
			}
			return new DateTime();
		}

        protected override void Report_BackupsListSmall(ReportClass Report)
        {
            Report.WriteLine("Источник: "+Path);
            base.Report_BackupsListSmall(Report);
        }

        protected override void Report_BackupsList(ReportClass Report)
        {
            Report.WriteP("<b>Источник:</b> " + Path);
            base.Report_BackupsList(Report);
        }
    }

    public class Backup1CItem : BackupItem
    {
        //1C
        bool FClientServer = false; //клиент-cервер или файловый сервер
        string FCommandFile = ""; //путь к екзешнику
        string FCatalogBase = ""; //каталог базы
        string FServer1C = ""; //адрес сервака
        string FServerBase = ""; //название ьазы на серваке
        string FUser1C = ""; //юзер
        string FPass1C = ""; //пароль юзера
        string FVersion1C = "8.1"; //версия 1с
        bool FDisconnectUsers = false; //отключать юзеров
        bool FKillUsers = false; //убивать юзеров

        public bool ClientServer
        {
            get { return FClientServer; }
            set { FClientServer = value; }
        }
        public string CommandFile
        {
            get { return FCommandFile; }
            set { FCommandFile = value; }
        }
        public string CatalogBase
        {
            get { return FCatalogBase; }
            set { FCatalogBase = value; }
        }
        public string Server1C
        {
            get { return FServer1C; }
            set { FServer1C = value; }
        }
        public string ServerBase
        {
            get { return FServerBase; }
            set { FServerBase = value; }
        }
        public string User1C
        {
            get { return FUser1C; }
            set { FUser1C = value; }
        }
        public string Pass1C
        {
            get { return FPass1C; }
            set { FPass1C = value; }
        }
        public string Version1C
        {
            get { return FVersion1C; }
            set { FVersion1C = value; }
        }
        public bool DisconnectUsers
        {
            get { return FDisconnectUsers; }
            set { FDisconnectUsers = value; }
        }
        public bool KillUsers
        {
            get { return FKillUsers; }
            set { FKillUsers = value; }
        }

        public override void Load(XmlElement Node)
        {
            base.Load(Node);
            XmlNode N;
            //1c
            N = Node.GetElementsByTagName("CommandFile")[0];
            if (N != null)
                if (N.HasChildNodes)
                    FCommandFile = N.ChildNodes.Item(0).Value;
            N = Node.GetElementsByTagName("ClientServer")[0];
            if (N != null)
                if (N.HasChildNodes)
                    FClientServer = bool.Parse(N.ChildNodes.Item(0).Value);
            N = Node.GetElementsByTagName("CatalogBase")[0];
            if (N != null)
                if (N.HasChildNodes)
                    FCatalogBase = N.ChildNodes.Item(0).Value;
            N = Node.GetElementsByTagName("Server1C")[0];
            if (N != null)
                if (N.HasChildNodes)
                    FServer1C = N.ChildNodes.Item(0).Value;
            N = Node.GetElementsByTagName("ServerBase")[0];
            if (N != null)
                if (N.HasChildNodes)
                    FServerBase = N.ChildNodes.Item(0).Value;
            N = Node.GetElementsByTagName("User1C")[0];
            if (N != null)
                if (N.HasChildNodes)
                    FUser1C = N.ChildNodes.Item(0).Value;
            N = Node.GetElementsByTagName("Pass1C")[0];
            if (N != null)
                if (N.HasChildNodes)
                    try
                    {
                        FPass1C = Encoding.UTF8.GetString(Convert.FromBase64String(N.ChildNodes.Item(0).Value));
                    }
                    catch { }
            N = Node.GetElementsByTagName("Version1C")[0];
            if (N != null)
                if (N.HasChildNodes)
                    FVersion1C = N.ChildNodes.Item(0).Value;
            N = Node.GetElementsByTagName("DisconnectUsers")[0];
            if (N != null)
                if (N.HasChildNodes)
                    FDisconnectUsers = bool.Parse(N.ChildNodes.Item(0).Value);
            N = Node.GetElementsByTagName("KillUsers")[0];
            if (N != null)
                if (N.HasChildNodes)
                    FKillUsers = bool.Parse(N.ChildNodes.Item(0).Value);
        }

        public override void Save(XmlDocument Doc, XmlNode Node)
        {
            base.Save(Doc, Node);
            XmlNode N;
            //1c
            N = Node.AppendChild(Doc.CreateElement("ClientServer"));
            N.AppendChild(Doc.CreateTextNode(FClientServer.ToString()));
            N = Node.AppendChild(Doc.CreateElement("CommandFile"));
            N.AppendChild(Doc.CreateTextNode(FCommandFile));
            N = Node.AppendChild(Doc.CreateElement("CatalogBase"));
            N.AppendChild(Doc.CreateTextNode(FCatalogBase));
            N = Node.AppendChild(Doc.CreateElement("Server1C"));
            N.AppendChild(Doc.CreateTextNode(FServer1C));
            N = Node.AppendChild(Doc.CreateElement("ServerBase"));
            N.AppendChild(Doc.CreateTextNode(FServerBase));
            N = Node.AppendChild(Doc.CreateElement("User1C"));
            N.AppendChild(Doc.CreateTextNode(FUser1C));
            N = Node.AppendChild(Doc.CreateElement("Pass1C"));
            N.AppendChild(Doc.CreateTextNode(Convert.ToBase64String(Encoding.UTF8.GetBytes(FPass1C))));
            N = Node.AppendChild(Doc.CreateElement("Version1C"));
            N.AppendChild(Doc.CreateTextNode(FVersion1C));
            N = Node.AppendChild(Doc.CreateElement("DisconnectUsers"));
            N.AppendChild(Doc.CreateTextNode(FDisconnectUsers.ToString()));
            N = Node.AppendChild(Doc.CreateElement("KillUsers"));
            N.AppendChild(Doc.CreateTextNode(FKillUsers.ToString()));
        }

        public bool Copy1C(LogBackupInterface Log)
        {
            bool result = true;
            try
            {
                string TempFile = System.IO.Path.Combine(System.IO.Path.GetTempPath(), @"_backup_" + Name + ".dt");
                if (Copy1CTo(TempFile, Log))
                {

                    foreach (string P in Dest)
                    {

                        //проверка на старые копии
                        XmlDocument Doc = new XmlDocument();
                        if (File.Exists(System.IO.Path.Combine(P, Name + ".log")))
                            Doc.Load(System.IO.Path.Combine(P, Name + ".log"));
                        else
                        {
                            Doc.AppendChild(Doc.CreateElement("BackupManager"));
                        }
                        ProcessLogFile(Doc, P, Log);
                        //создание новой копии
                        DateTime NowDate = DateTime.Now;
                        string BackupFilename;
                        if (Version1C == "7.7")
                            BackupFilename = Name + " " + NowDate.ToString("yyyy-MM-dd HH-mm-ss") + ".zip";
                        else
                            BackupFilename = Name + " " + NowDate.ToString("yyyy-MM-dd HH-mm-ss") + ".dt";
                        Log.InvokeSetStatusLabel("Создание резервной копии " + System.IO.Path.Combine(P, BackupFilename));
                        try
                        {
							Utils.CopyFile(TempFile, System.IO.Path.Combine(P, BackupFilename), Log);
                            XmlNode N1 = Doc.CreateElement("Backup");
                            Doc.DocumentElement.AppendChild(N1);
                            N1.Attributes.Append(Doc.CreateAttribute("Stamp")).Value = NowDate.ToString();
                            N1.Attributes.Append(Doc.CreateAttribute("Filename")).Value = BackupFilename;
                            N1.Attributes.Append(Doc.CreateAttribute("Size")).Value = (new FileInfo(System.IO.Path.Combine(P, BackupFilename))).Length.ToString();
                            Log.InvokeAddLogItem(this, "Создана архивная копия " +
                                System.IO.Path.Combine(P, BackupFilename),
                                LogItemType.Information);
                        }
                        catch (Exception ex)
                        {
                            Log.InvokeAddLogItem(this, "Копия (Copy1C, NewCopy): "+ex.Message, LogItemType.Error);
                            result = false;
                        }

                        try
                        {
                            XmlTextWriter XW = new XmlTextWriter(System.IO.Path.Combine(P, Name + ".log"), Encoding.UTF8);
                            XW.Formatting = Formatting.Indented;
                            XW.Indentation = 4;
                            Doc.Save(XW);
                            XW.Close();
                        }
                        catch (Exception ex)
                        {
                            Log.InvokeAddLogItem(this, "Копия (Copy1C, XML): " + ex.Message, LogItemType.Error);
                        }
                    }
                }
                File.Delete(TempFile);
            }
            catch (Exception ex)
            {
                Log.InvokeAddLogItem(this, "Копия (Copy1C, Global): " + ex.Message, LogItemType.Error);
                result = false;
            }
            return result;
        }

        public bool Copy1CTo(string Filename, LogBackupInterface Log)
        {
            if (CommandFile == "")
                return false;
            if (ClientServer)
            {
                if ((Server1C == "") || (ServerBase == ""))
                    return false;
            }
            else
            {
                if (CatalogBase == "")
                    return false;
            }
            try
            {
                if (ClientServer)
                    Log.InvokeAddLogItem(this, "Начало резервирования информационной базы " + Server1C + ":" + ServerBase, LogItemType.Information);
                else
                    Log.InvokeAddLogItem(this, "Начало резервирования информационной базы " + CatalogBase, LogItemType.Information);
                Log.InvokeSetStatusLabel("Резервирование информационной базы");
                Log.InvokeSetProgress(0);
                switch (Version1C)
                {
                    case "7.7":
                        Copy1C7(Filename, Log);
                        break;
                    case "8.0":
                        Copy1C80(Filename, Log);
                        break;
                    case "8.1":
                        Copy1C81(Filename, Log);
                        break;
                    case "8.2":
                        Copy1C82(Filename, Log);
                        break;
                }

                Log.InvokeSetProgress(100);
                Log.InvokeSetStatusLabel("Резервирование информационной базы завершено");
                if (ClientServer)
                    Log.InvokeAddLogItem(this, "Конец резервирования информационной базы " + Server1C + ":" + ServerBase, LogItemType.Information);
                else
                    Log.InvokeAddLogItem(this, "Конец резервирования информационной базы " + CatalogBase, LogItemType.Information);
                Log.InvokeSetStatusLabel("Резервирование информационной базы завершено");
                return true;
            }
            catch (Exception ex)
            {
                Log.InvokeAddLogItem(this, "Копия (Copy1CTo): " + ex.Message, LogItemType.Error);
                return false;
            }
        }

        public void Copy1C7(string Filename, LogBackupInterface Log)
        {
            string ConnectionString = "";
            if (ClientServer)
            {
                ConnectionString = "/S" + Server1C + @"\" + ServerBase;
            }
            else
            {
                ConnectionString = "/d\"" + CatalogBase + "\"";
            }
            if (User1C != "")
            {
                ConnectionString += " /N\"" + User1C + "\"";
                if (Pass1C != "")
                    ConnectionString += " /P" + Pass1C;
            }
            //отключение пользователей
            try
            {
                if (DisconnectUsers)
                {
                    Utils.DisconnectUsers1C7(this, ClientServer, KillUsers, Log);
                }
            }
            catch (Exception ex)
            {
                Log.InvokeAddLogItem(this, "1с77: " + ex.Message, LogItemType.Error);
            }

            string Packet = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "_packet77_.prm");
            StreamWriter F = new StreamWriter(Packet, false, Encoding.Default);
            F.Write("[General]\nQuit=1\nUnloadData=1\n[UnloadData]\nUnloadToFile=" + Filename + "\nIncludeUserDef=1");
            F.Close();
            Utils.RunProcess(CommandFile, "config " + ConnectionString + " /@\"" + Packet + "\"");
            File.Delete(Packet);
        }

        public void Copy1C80(string Filename, LogBackupInterface Log)
        {
            string ConnectionString;
            if (ClientServer)
            {
                ConnectionString = "/S" + Server1C + @"\" + ServerBase;
            }
            else
            {
                ConnectionString = "/F\"" + CatalogBase + "\"";
            }
            if (User1C != "")
            {
                ConnectionString += " /N\"" + User1C + "\"";
                if (Pass1C != "")
                    ConnectionString += " /P" + Pass1C;
            }
            //отключение пользователей
            try
            {
                if (DisconnectUsers)
                {
                    Utils.DisconnectUsers1C8(this, ClientServer, Server1C, ServerBase, User1C, Pass1C, KillUsers, Log);
                }
            }
            catch (Exception ex)
            {
                Log.InvokeAddLogItem(this, "1с80: " + ex.Message, LogItemType.Error);
            }
			Utils.RunProcess(CommandFile, "CONFIG " + ConnectionString + " /DumpIB\"" + Filename + "\"");
        }

        public void Copy1C81(string Filename, LogBackupInterface Log)
        {
            string ConnectionString;
            if (ClientServer)
            {
                ConnectionString = "/S" + Server1C + @"\" + ServerBase;
            }
            else
            {
                ConnectionString = "/F\"" + CatalogBase + "\"";
            }
            if (User1C != "")
            {
                ConnectionString += " /N\"" + User1C + "\"";
                if (Pass1C != "")
                    ConnectionString += " /P" + Pass1C;
            }
            //отключение пользователей
            try
            {
                if (DisconnectUsers)
                {
                    Utils.DisconnectUsers1C81(this, ClientServer, Server1C, ServerBase, User1C, Pass1C, KillUsers, Log);
                }
            }
            catch (Exception ex)
            {
                Log.InvokeAddLogItem(this, "1с81: " + ex.Message, LogItemType.Error);
            }
            string Output = "";
			Utils.RunProcess(CommandFile, "DESIGNER " + ConnectionString + " /DumpIB \"" + Filename + "\"", ref Output);
            if (Output != "")
                Log.InvokeAddLogItem(this, Output, LogItemType.Warning);
        }

        public void Copy1C82(string Filename, LogBackupInterface Log)
        {
            string ConnectionString;
            if (ClientServer)
            {
                ConnectionString = "/S" + Server1C + @"\" + ServerBase;
            }
            else
            {
                ConnectionString = "/F\"" + CatalogBase + "\"";
            }
            if (User1C != "")
            {
                ConnectionString += " /N\"" + User1C + "\"";
                if (Pass1C != "")
                    ConnectionString += " /P" + Pass1C;
            }
            //отключение пользователей
            try
            {
                if (DisconnectUsers)
                {
                    Utils.DisconnectUsers1C82(this, ClientServer, Server1C, ServerBase, User1C, Pass1C, KillUsers, Log);
                }
            }
            catch (Exception ex)
            {
                Log.InvokeAddLogItem(this, "1с82: " + ex.Message, LogItemType.Error);
            }
            string Output = "";
            Utils.RunProcess(CommandFile, "DESIGNER " + ConnectionString + " /DumpIB \"" + Filename + "\"", ref Output);
            if (Output != "")
                Log.InvokeAddLogItem(this, Output, LogItemType.Warning);
        }

        public override void Paint(Graphics Gr, Rectangle Rect, DrawItemEventArgs e)
        {
            base.Paint(Gr, Rect, e);
            if (ClientServer)
                Gr.DrawString("Сервер: " + Server1C + "; Информационная база: " + ServerBase, e.Font, SystemBrushes.WindowText, 5, 20);
            else
                Gr.DrawString("Информационная база: " + CatalogBase, e.Font, SystemBrushes.WindowText, 5, 20);
            Gr.DrawString("Директории для архивных копий:", SystemFonts.DefaultFont, SystemBrushes.WindowText, 5, 35);
            for (int i = 0; (i < Dest.Count) && (i < 2); i++)
            {
                Gr.DrawString(Dest[i], e.Font, Brushes.Blue, 180, 35 + i * 15);
            }
        }

        public override bool Run(LogBackupInterface Log)
        {
            if (base.Run(Log))
            {
                Log.InvokeSetProgress(-1);
                return Copy1C(Log);
            }
            return false;
        }

        public override bool BackupTo(string Filename, LogBackupInterface Log)
        {
            if (base.BackupTo(Filename, Log))
            {
                Copy1CTo(Filename, Log);
            }
            return true;
        }

        protected override void Report_BackupsListSmall(ReportClass Report)
        {
            if (ClientServer)
            {
                Report.WriteLine("Сервер: " + Server1C);
                Report.WriteLine("Информационная база: " + ServerBase);
            }
            else
            {
                Report.WriteLine("Источник: " + CatalogBase);
            }
            base.Report_BackupsListSmall(Report);
        }

        protected override void Report_BackupsList(ReportClass Report)
        {
            if (ClientServer)
            {
                Report.WriteP("<b>Сервер:</b> " + Server1C);
                Report.WriteP("<b>Информационная база: </b>" + ServerBase);
            }
            else
            {
                Report.WriteLine("<b>Источник:</b> " + CatalogBase);
            }
            base.Report_BackupsList(Report);
        }
    }

	public class Restore1CItem : TaskItem
	{
		bool FReindex = false;
		byte FLogIntegrity = 0;
		bool FRecalcTotals = false;
		bool FIBCompression = false;
		bool FTestOnly = false;
		byte FBadRef = 0;
		byte FBadData = 0;

		bool FClientServer = false; //клиент-cервер или файловый сервер
		string FCommandFile = ""; //путь к екзешнику
		string FCatalogBase = ""; //каталог базы
		string FServer1C = ""; //адрес сервака
		string FServerBase = ""; //название ьазы на серваке
		string FUser1C = ""; //юзер
		string FPass1C = ""; //пароль юзера
		string FVersion1C = "8.1"; //версия 1с
		bool FDisconnectUsers = false; //отключать юзеров
		bool FKillUsers = false; //убивать юзеров
		
		public bool Reindex
		{
			get { return FReindex; }
			set { FReindex = value; }
		}
		public byte LogIntegrity
		{
			get { return FLogIntegrity; }
			set { FLogIntegrity = value; }
		}
		public bool RecalcTotals
		{
			get { return FRecalcTotals; }
			set { FRecalcTotals = value; }
		}
		public bool IBCompression
		{
			get { return FIBCompression; }
			set { FIBCompression = value; }
		}
		public bool TestOnly
		{
			get { return FTestOnly; }
			set { FTestOnly = value; }
		}
		public byte BadRef
		{
			get { return FBadRef; }
			set { FBadRef = value; }
		}
		public byte BadData
		{
			get { return FBadData; }
			set { FBadData = value; }
		}

		public bool ClientServer
		{
			get { return FClientServer; }
			set { FClientServer = value; }
		}
		public string CommandFile
		{
			get { return FCommandFile; }
			set { FCommandFile = value; }
		}
		public string CatalogBase
		{
			get { return FCatalogBase; }
			set { FCatalogBase = value; }
		}
		public string Server1C
		{
			get { return FServer1C; }
			set { FServer1C = value; }
		}
		public string ServerBase
		{
			get { return FServerBase; }
			set { FServerBase = value; }
		}
		public string User1C
		{
			get { return FUser1C; }
			set { FUser1C = value; }
		}
		public string Pass1C
		{
			get { return FPass1C; }
			set { FPass1C = value; }
		}
		public string Version1C
		{
			get { return FVersion1C; }
			set { FVersion1C = value; }
		}
		public bool DisconnectUsers
		{
			get { return FDisconnectUsers; }
			set { FDisconnectUsers = value; }
		}
		public bool KillUsers
		{
			get { return FKillUsers; }
			set { FKillUsers = value; }
		}

		string GetCommandRestoreString()
		{
			string res = "";
			if (Reindex)
				res += " -ReIndex";
			if (RecalcTotals)
				res += " -RecalcTotals";
			if (IBCompression)
				res += " -IBCompression";
			switch (LogIntegrity)
			{
				case 1:
					res += " -LogIntegrity";
					break;
				case 2:
					res += " -LogAndRefsIntegrity";
					break;
			}
			if (TestOnly)
				res += " -TestOnly";
			if (!TestOnly && LogIntegrity>0)
			{
				switch (BadRef)
				{
					case 1:
						res += " -BadRefCreate";
						break;
					case 2:
						res += " -BadRefClear";
						break;
				}
				switch (BadData)
				{
					case 1:
						res += " -BadDataCreate";
						break;
					case 2:
						res += " -BadDataDelete";
						break;
				}
			}
			return res;
		}

		string GetCommandRestoreString77()
		{
			string res = "[General]\nQuit=1\nCheckAndRepair=1\n[CheckAndRepair]\n";
			if (Reindex)
				res += "ReIndex=1\n";
			if (RecalcTotals)
				res += "RecalcTotals=1\n";
			if (IBCompression)
				res += "Pack=1\n";
			switch (LogIntegrity)
			{
				case 1:
					res += "LogicalIntegrity=1\n";
					break;
				case 2:
					res += "PhysicalIntegrity=1\n";
					break;
			}
			if (TestOnly)
				res += "Repair=0\n";
			else
				res += "Repair=1\n";
			if (!TestOnly && LogIntegrity > 0)
			{
				switch (BadRef)
				{
					case 1:
						res += "CreateForUnresolved=1\n";
						break;
					case 2:
						res += "SkipUnresolved=1\n";
						break;
				}
				switch (BadData)
				{
					case 1:
						res += "Reconstruct=1\n";
						break;
					case 2:
						res += "Reconstruct=0\n";
						break;
				}
			}
			return res;
		}

		string GetRestoreText()
		{
			string res = "";
			if (Reindex)
				res += "Переиндексация; ";
			if (RecalcTotals)
				res += "Пересчет итогов; ";
			if (IBCompression)
				res += "Сжатие БД; ";
			switch (LogIntegrity)
			{
				case 1:
					res += "Проверка логической целостности; ";
					break;
				case 2:
					res += "Проверка логической и ссылочной целостности; ";
					break;
			}
			if (TestOnly)
				res += "Только тестирование; ";
            if (!TestOnly && LogIntegrity > 0)
			{
				switch (BadRef)
				{
					case 1:
						res += "Создавать объекты при наличии ссылок на несуществующие объекты; ";
						break;
					case 2:
						res += "Очищать объекты при наличии ссылок на несуществующие объекты; ";
						break;
				}
				switch (BadData)
				{
					case 1:
						res += "Создавать объекты при частичной потере данных; ";
						break;
					case 2:
						res += "Удалять объекты при частичной потере данных; ";
						break;
				}
			}
			return res;
		}

		public override void Save(XmlDocument Doc, XmlNode Node)
		{
			base.Save(Doc, Node);
			XmlNode N;
			N = Node.AppendChild(Doc.CreateElement("Reindex"));
			N.AppendChild(Doc.CreateTextNode(FReindex.ToString()));
			N = Node.AppendChild(Doc.CreateElement("LogIntegrity"));
			N.AppendChild(Doc.CreateTextNode(FLogIntegrity.ToString()));
			N = Node.AppendChild(Doc.CreateElement("RecalcTotals"));
			N.AppendChild(Doc.CreateTextNode(FRecalcTotals.ToString()));
			N = Node.AppendChild(Doc.CreateElement("IBCompression"));
			N.AppendChild(Doc.CreateTextNode(FIBCompression.ToString()));
			N = Node.AppendChild(Doc.CreateElement("TestOnly"));
			N.AppendChild(Doc.CreateTextNode(FTestOnly.ToString()));
			N = Node.AppendChild(Doc.CreateElement("BadRef"));
			N.AppendChild(Doc.CreateTextNode(FBadRef.ToString()));
			N = Node.AppendChild(Doc.CreateElement("BadData"));
			N.AppendChild(Doc.CreateTextNode(FBadData.ToString()));
			//1c
			N = Node.AppendChild(Doc.CreateElement("ClientServer"));
			N.AppendChild(Doc.CreateTextNode(FClientServer.ToString()));
			N = Node.AppendChild(Doc.CreateElement("CommandFile"));
			N.AppendChild(Doc.CreateTextNode(FCommandFile));
			N = Node.AppendChild(Doc.CreateElement("CatalogBase"));
			N.AppendChild(Doc.CreateTextNode(FCatalogBase));
			N = Node.AppendChild(Doc.CreateElement("Server1C"));
			N.AppendChild(Doc.CreateTextNode(FServer1C));
			N = Node.AppendChild(Doc.CreateElement("ServerBase"));
			N.AppendChild(Doc.CreateTextNode(FServerBase));
			N = Node.AppendChild(Doc.CreateElement("User1C"));
			N.AppendChild(Doc.CreateTextNode(FUser1C));
			N = Node.AppendChild(Doc.CreateElement("Pass1C"));
			N.AppendChild(Doc.CreateTextNode(Convert.ToBase64String(Encoding.UTF8.GetBytes(FPass1C))));
			N = Node.AppendChild(Doc.CreateElement("Version1C"));
			N.AppendChild(Doc.CreateTextNode(FVersion1C));
			N = Node.AppendChild(Doc.CreateElement("DisconnectUsers"));
			N.AppendChild(Doc.CreateTextNode(FDisconnectUsers.ToString()));
			N = Node.AppendChild(Doc.CreateElement("KillUsers"));
			N.AppendChild(Doc.CreateTextNode(FKillUsers.ToString()));
		}

		public override void Load(XmlElement Node)
		{
			base.Load(Node);
			XmlNode N;
			N = Node.GetElementsByTagName("Reindex")[0];
			if (N != null)
				if (N.HasChildNodes)
					FReindex = bool.Parse(N.ChildNodes.Item(0).Value);
			N = Node.GetElementsByTagName("LogIntegrity")[0];
			if (N != null)
				if (N.HasChildNodes)
					FLogIntegrity = byte.Parse(N.ChildNodes.Item(0).Value);
			N = Node.GetElementsByTagName("RecalcTotals")[0];
			if (N != null)
				if (N.HasChildNodes)
					FRecalcTotals = bool.Parse(N.ChildNodes.Item(0).Value);
			N = Node.GetElementsByTagName("IBCompression")[0];
			if (N != null)
				if (N.HasChildNodes)
					FIBCompression = bool.Parse(N.ChildNodes.Item(0).Value);
			N = Node.GetElementsByTagName("TestOnly")[0];
			if (N != null)
				if (N.HasChildNodes)
					FTestOnly = bool.Parse(N.ChildNodes.Item(0).Value);
			N = Node.GetElementsByTagName("BadRef")[0];
			if (N != null)
				if (N.HasChildNodes)
					FBadRef = byte.Parse(N.ChildNodes.Item(0).Value);
			N = Node.GetElementsByTagName("BadData")[0];
			if (N != null)
				if (N.HasChildNodes)
					FBadData = byte.Parse(N.ChildNodes.Item(0).Value);
			//1c
			N = Node.GetElementsByTagName("CommandFile")[0];
			if (N != null)
				if (N.HasChildNodes)
					FCommandFile = N.ChildNodes.Item(0).Value;
			N = Node.GetElementsByTagName("ClientServer")[0];
			if (N != null)
				if (N.HasChildNodes)
					FClientServer = bool.Parse(N.ChildNodes.Item(0).Value);
			N = Node.GetElementsByTagName("CatalogBase")[0];
			if (N != null)
				if (N.HasChildNodes)
					FCatalogBase = N.ChildNodes.Item(0).Value;
			N = Node.GetElementsByTagName("Server1C")[0];
			if (N != null)
				if (N.HasChildNodes)
					FServer1C = N.ChildNodes.Item(0).Value;
			N = Node.GetElementsByTagName("ServerBase")[0];
			if (N != null)
				if (N.HasChildNodes)
					FServerBase = N.ChildNodes.Item(0).Value;
			N = Node.GetElementsByTagName("User1C")[0];
			if (N != null)
				if (N.HasChildNodes)
					FUser1C = N.ChildNodes.Item(0).Value;
			N = Node.GetElementsByTagName("Pass1C")[0];
			if (N != null)
				if (N.HasChildNodes)
					try
					{
						FPass1C = Encoding.UTF8.GetString(Convert.FromBase64String(N.ChildNodes.Item(0).Value));
					}
					catch { }
			N = Node.GetElementsByTagName("Version1C")[0];
			if (N != null)
				if (N.HasChildNodes)
					FVersion1C = N.ChildNodes.Item(0).Value;
			N = Node.GetElementsByTagName("DisconnectUsers")[0];
			if (N != null)
				if (N.HasChildNodes)
					FDisconnectUsers = bool.Parse(N.ChildNodes.Item(0).Value);
			N = Node.GetElementsByTagName("KillUsers")[0];
			if (N != null)
				if (N.HasChildNodes)
					FKillUsers = bool.Parse(N.ChildNodes.Item(0).Value);
		}

		public override void Paint(Graphics Gr, Rectangle Rect, DrawItemEventArgs e)
		{
			base.Paint(Gr, Rect, e);
			if (ClientServer)
				Gr.DrawString("Сервер: " + Server1C + "; Информационная база: " + ServerBase, e.Font, SystemBrushes.WindowText, 5, 20);
			else
				Gr.DrawString("Информационная база: " + CatalogBase, e.Font, SystemBrushes.WindowText, 5, 20);
			Gr.DrawString(GetRestoreText(), e.Font, Brushes.Blue, new RectangleF(5, 35, Rect.Width-10, Rect.Height-40));
		}

		public override bool Run(LogBackupInterface Log)
		{
            Log.InvokeSetProgress(-1);
            if (ClientServer)
                Log.InvokeAddLogItem(this, "Тестирование ИБ " + Server1C + ":" + ServerBase, LogItemType.Information);
            else
                Log.InvokeAddLogItem(this, "Тестирование ИБ " + CatalogBase, LogItemType.Information);
			switch (Version1C)
			{
				case "7.7":
					break;
				case "8.0":
                    Restore1C80(Log);
					break;
				case "8.1":
                    Restore1C81(Log);
					break;
                case "8.2":
                    Restore1C81(Log);
                    break;
			}
            if (ClientServer)
                Log.InvokeAddLogItem(this, "Тестирование ИБ " + Server1C + ":" + ServerBase + " закончено", LogItemType.Information);
            else
                Log.InvokeAddLogItem(this, "Тестирование ИБ " + CatalogBase + " закончено", LogItemType.Information);
            return true;
		}

		public void Restore1C77(LogBackupInterface Log)
		{
			string ConnectionString;
			if (ClientServer)
			{
				ConnectionString = "/S" + Server1C + @"\" + ServerBase;
			}
			else
			{
				ConnectionString = "/d\"" + CatalogBase + "\"";
			}
			if (User1C != "")
			{
				ConnectionString += " /N\"" + User1C + "\"";
				if (Pass1C != "")
					ConnectionString += " /P" + Pass1C;
			}
			//отключение пользователей
			try
			{
				if (DisconnectUsers)
				{
					Utils.DisconnectUsers1C7(this, ClientServer, KillUsers, Log);
				}
			}
			catch (Exception ex)
			{
				Log.InvokeAddLogItem(this, ex.Message, LogItemType.Error);
			}
			string Packet = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "_packet77_.prm");
			StreamWriter F = new StreamWriter(Packet, false, Encoding.Default);
			F.Write(GetCommandRestoreString77());
			F.Close();
			Utils.RunProcess(CommandFile, "config " + ConnectionString + " /@\"" + Packet + "\"");
			File.Delete(Packet);
		}

        public void Restore1C80(LogBackupInterface Log)
        {
            string ConnectionString;
            if (ClientServer)
            {
                ConnectionString = "/S" + Server1C + @"\" + ServerBase;
            }
            else
            {
                ConnectionString = "/F\"" + CatalogBase + "\"";
            }
            if (User1C != "")
            {
                ConnectionString += " /N\"" + User1C + "\"";
                if (Pass1C != "")
                    ConnectionString += " /P" + Pass1C;
            }
			//отключение пользователей
			try
			{
				if (DisconnectUsers)
				{
					Utils.DisconnectUsers1C8(this, ClientServer, Server1C, ServerBase, User1C, Pass1C, KillUsers, Log);
				}
			}
			catch (Exception ex)
			{
				Log.InvokeAddLogItem(this, ex.Message, LogItemType.Error);
			}
            Utils.RunProcess(CommandFile, "CONFIG " + ConnectionString + " /IBCheckAndRepair " + GetCommandRestoreString());
        }

		public void Restore1C81(LogBackupInterface Log)
		{
			string ConnectionString;
			if (ClientServer)
			{
				ConnectionString = "/S" + Server1C + @"\" + ServerBase;
			}
			else
			{
				ConnectionString = "/F\"" + CatalogBase + "\"";
			}
			if (User1C != "")
			{
				ConnectionString += " /N\"" + User1C+"\"";
				if (Pass1C != "")
					ConnectionString += " /P" + Pass1C;
			}
			//отключение пользователей
			try
			{
				if (DisconnectUsers)
				{
					Utils.DisconnectUsers1C81(this, ClientServer, Server1C, ServerBase, User1C, Pass1C, KillUsers, Log);
				}
			}
			catch (Exception ex)
			{
				Log.InvokeAddLogItem(this, ex.Message, LogItemType.Error);
			}
			Utils.RunProcess(CommandFile, "DESIGNER " + ConnectionString + " /IBCheckAndRepair " + GetCommandRestoreString());
		}
	}

	public enum CommandTaskType
	{
		File = 0,
		Script = 1
	}

	public class CommandItem:TaskItem
	{
		string FCommand="";
		CommandTaskType FTaskType = CommandTaskType.Script;
		string FCommandFile = "";

		public string Command
		{
			get { return FCommand; }
			set { FCommand = value; }
		}

		public CommandTaskType TaskType
		{
			get { return FTaskType; }
			set { FTaskType = value; }
		}

		public string CommandFile
		{
			get { return FCommandFile; }
			set { FCommandFile = value; }
		}

		public override void Save(XmlDocument Doc, XmlNode Node)
		{
			base.Save(Doc, Node);
			XmlNode N;
			N = Node.AppendChild(Doc.CreateElement("Command"));
			N.AppendChild(Doc.CreateTextNode(FCommand));
			N = Node.AppendChild(Doc.CreateElement("CommandFile"));
			N.AppendChild(Doc.CreateTextNode(FCommandFile));
			N = Node.AppendChild(Doc.CreateElement("TaskType"));
			N.AppendChild(Doc.CreateTextNode(FTaskType.ToString()));
		}

		public override void Load(XmlElement Node)
		{
			base.Load(Node);
			XmlNode N;
			N = Node.GetElementsByTagName("Command")[0];
			if (N != null)
				if (N.HasChildNodes)
					Command = N.ChildNodes.Item(0).Value;
			N = Node.GetElementsByTagName("CommandFile")[0];
			if (N != null)
				if (N.HasChildNodes)
					CommandFile = N.ChildNodes.Item(0).Value;
			N = Node.GetElementsByTagName("TaskType")[0];
			if (N != null)
				if (N.HasChildNodes)
					switch (N.ChildNodes.Item(0).Value) 
					{
						case "File":
							TaskType=CommandTaskType.File;
							break;
						case "Script":
							TaskType=CommandTaskType.Script;
							break;
					}

		}

		public override void Paint(Graphics Gr, Rectangle Rect, DrawItemEventArgs e)
		{
			base.Paint(Gr, Rect, e);
			switch (TaskType)
			{
				case CommandTaskType.File:
					Gr.DrawString("Команда: " + CommandFile, e.Font, SystemBrushes.WindowText, 5, 20);
					break;
				case CommandTaskType.Script:
					Gr.DrawString("Команда: " + Command, e.Font, SystemBrushes.WindowText, 5, 20);
					break;
			}
			
		}

		public override bool Run(LogBackupInterface Log)
		{
            base.Run(Log
                );
			Process P;
            Log.InvokeSetProgress(-1);
			switch (TaskType)
			{
				case CommandTaskType.File:
					P = new Process();
					try
					{
						P.StartInfo = new ProcessStartInfo(CommandFile);
						P.Start();
						P.WaitForExit();
					}
					catch (Exception e)
					{
						Log.InvokeAddLogItem(this, e.Message, LogItemType.Error);
					}
					P.Dispose();
					break;
				case CommandTaskType.Script:
					string TempFile = Path.Combine(Path.GetTempPath(), "_egida_command_.bat");
					try
					{
						StreamWriter F = new StreamWriter(TempFile);
						F.Write(Command);
						F.Close();
						F.Dispose();
					}
					catch (Exception e)
					{
						Log.InvokeAddLogItem(this, e.Message, LogItemType.Error);
					}
					P = new Process();
					try
					{
						P.StartInfo = new ProcessStartInfo(TempFile);
						P.Start();
						P.WaitForExit();
					}
					catch (Exception e)
					{
						Log.InvokeAddLogItem(this, e.Message, LogItemType.Error);
					}
					P.Dispose();
					break;
			}
            return true;
		}
	}

	public class QueveItem : TaskItem
	{
		List<TaskItem> FList = new List<TaskItem>();
		BackupList FBackups = null;

		public BackupList Backups
		{
			get { return FBackups; }
			set { FBackups = value; }
		}
		public List<TaskItem> Queve
		{
			get { return FList; }
			set { FList = value; }
		}

		public override void Save(XmlDocument Doc, XmlNode Node)
		{
			base.Save(Doc, Node);
			XmlNode N, N1;
			N = Node.AppendChild(Doc.CreateElement("Queve"));
			foreach (TaskItem T in FList)
			{
				N1=N.AppendChild(Doc.CreateElement("Task"));
				N1.Attributes.Append(Doc.CreateAttribute("ID")).Value=T.ID;
			}
		}

		public override void Load(XmlElement Node)
		{
			base.Load(Node);
			XmlNode N;
			TaskItem T;
			N = Node.GetElementsByTagName("Queve")[0];
			if (N != null)
			{
				foreach (XmlNode N1 in N)
					if (N1.Name == "Task")
						if (N1.Attributes["ID"] != null)
						{
							T = FBackups.GetTaskByID(N1.Attributes["ID"].Value);
							if (T != null)
								FList.Add(T);
						}
			}
		}

        public override bool Run(LogBackupInterface Log)
        {
            base.Run(Log);
            bool result = true;
            foreach (TaskItem TI in Queve)
            {
                result &= TI.Run(Log);
            }
            return result;
        }

        public override void Paint(Graphics Gr, Rectangle Rect, DrawItemEventArgs e)
        {
            base.Paint(Gr, Rect, e);
            for (int i = 0; i < Queve.Count && i < 4; i++)
				if (i == 3)
					Gr.DrawString("   ...", e.Font, Brushes.Blue, 10, 23 + i * 18);
				else
					Gr.DrawString((i+1).ToString()+". " + Queve[i].Name, e.Font, Brushes.Blue, 10, 23+i*18);
        }
	}
}
