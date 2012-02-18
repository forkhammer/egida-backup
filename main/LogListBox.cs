using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace EgidaBackup
{
	public partial class LogListBox : DataGridView
	{
		public LogListBox()
		{
			InitializeComponent();
            Columns.Clear();
            DataGridViewColumn C;
            C = new DataGridViewImageColumn();
            C.HeaderText = "";
            C.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            C.Width = 30;
            Columns.Add(C);
            C = new DataGridViewTextBoxColumn();
            C.HeaderText = "Дата";
            C.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            C.Width = 170;
            Columns.Add(C);
            C = new DataGridViewTextBoxColumn();
            C.HeaderText = "Лог";
            Columns.Add(C);
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            ReadOnly = true;
            ColumnHeadersHeight = 18;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            RowHeadersVisible = false;
            BackgroundColor = SystemColors.Window;
            BorderStyle = System.Windows.Forms.BorderStyle.None;
            AllowUserToResizeRows = false;
            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		}

		/*protected override void OnDrawItem(DrawItemEventArgs e)
		{
			if (e.Index != -1 && e.Index<Items.Count)
			{
				LogItem LI = (LogItem)Items[e.Index];
				Brush B, TB;
				switch (LI.TypeItem)
				{
					case LogItemType.Error:
						B = Brushes.LightCoral;
						TB = Brushes.Black;
						break;
					case LogItemType.Warning:
						B = Brushes.LightYellow;
						TB = Brushes.Black;
						break;
					default:
						B = SystemBrushes.Window;
						TB = SystemBrushes.WindowText;
						break;
				}
				if ((e.State & DrawItemState.Selected) != 0)
				{
					B = SystemBrushes.Highlight;
					TB = SystemBrushes.HighlightText;
				}
				e.Graphics.FillRectangle(B, e.Bounds);
				e.Graphics.DrawString(LI.Stamp.ToString("[yyyy-MM-dd HH:mm:ss]")+" "+LI.Text, e.Font, TB, e.Bounds.X+2, e.Bounds.Y+2);
			}
		}*/

		public void Synchronize(LogList List)
		{
            Rows.Clear();
            foreach (LogItem LI in List.List)
            {
                AddItem(LI);
            }
		}

        public void AddItem(LogItem LI)
        {
            Icon Ic = null;
            switch (LI.TypeItem)
            {
                case LogItemType.Information:
                    Ic = EgidaBackup.Properties.Resources.check;
                    break;
                case LogItemType.Warning:
                    Ic = EgidaBackup.Properties.Resources.information;
                    break;
                case LogItemType.Error:
                    Ic = EgidaBackup.Properties.Resources.error;
                    break;
            }
            
            Rows.Add(new object[] { Ic, LI.Stamp, LI.Text });
        }
	}

	public enum LogItemType
	{
		Error,
		Warning,
		Information
	}

    public enum LogItemLabel
    {
        Old,
        New
    }

	public class LogItem
	{
		string FText;
		LogItemType FTypeItem;
		DateTime FStamp;

		public string Text
		{
			get { return FText; }
		}
		public LogItemType TypeItem
		{
			get { return FTypeItem; }
		}
		public DateTime Stamp
		{
			get { return FStamp; }
		}
        public LogItemLabel Label = LogItemLabel.Old;

		public LogItem(string Text, LogItemType TypeItem, DateTime Stamp, LogItemLabel Label)
		{
			FText = Text;
			FTypeItem = TypeItem;
			FStamp = Stamp;
            this.Label = Label;
		}
	}

    

	public class LogList
	{
		List<LogItem> FList=new List<LogItem>();
		string FFilename="";

		public string Filename
		{
			get { return FFilename; }
			set { FFilename = value; }
		}

		public List<LogItem> List
		{
			get { return FList;}
		}

		public LogList()
		{ }

		public LogList(string Filename)
		{
			FFilename = Filename;
			Load();
		}

		public void Load()
		{
			try
			{
				if (File.Exists(FFilename))
				{
					XmlDocument Doc = new XmlDocument();
					Doc.Load(FFilename);
					FList.Clear();
					if (Doc.DocumentElement != null && Doc.DocumentElement.Name == "BackupLog")
					{
						foreach (XmlNode N in Doc.DocumentElement)
						{
							if (N.Name == "Log" && N.ChildNodes.Count > 0)
							{
								string txt = N.ChildNodes[0].Value;
								LogItemType typ = LogItemType.Information;
								switch (N.Attributes["Type"].Value)
								{
									case "Information":
										typ = LogItemType.Information;
										break;
									case "Warning":
										typ = LogItemType.Warning;
										break;
									case "Error":
										typ = LogItemType.Error;
										break;
								}
								DateTime dt = DateTime.Parse(N.Attributes["Stamp"].Value);
								FList.Add(new LogItem(txt, typ, dt, LogItemLabel.Old));
							}
						}
					}
				}
			}
			catch { }
		}

		public void Save()
		{
			XmlDocument Doc = new XmlDocument();
			Doc.AppendChild(Doc.CreateElement("BackupLog"));
			foreach (LogItem LI in FList)
			{
				XmlNode N = Doc.DocumentElement.AppendChild(Doc.CreateElement("Log"));
				XmlAttribute Attr = N.Attributes.Append(Doc.CreateAttribute("Type"));
				switch (LI.TypeItem)
				{
					case LogItemType.Information:
						Attr.Value = "Information";
						break;
					case LogItemType.Warning:
						Attr.Value = "Warning";
						break;
					case LogItemType.Error:
						Attr.Value = "Error";
						break;
				}
				N.Attributes.Append(Doc.CreateAttribute("Stamp")).Value=LI.Stamp.ToString();
				N.AppendChild(Doc.CreateTextNode(LI.Text));
			}
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(FFilename)))
                    Directory.CreateDirectory(Path.GetDirectoryName(FFilename));
                XmlTextWriter XW = new XmlTextWriter(FFilename, Encoding.UTF8);
                XW.Formatting = Formatting.Indented;
                XW.Indentation = 4;
                Doc.Save(XW);
                XW.Close();
            }
            catch { }
		}

        public void SetOld()
        {
            foreach (LogItem I in FList)
                I.Label = LogItemLabel.Old;
        }
	}
}
