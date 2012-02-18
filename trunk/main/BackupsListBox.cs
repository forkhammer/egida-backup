using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace EgidaBackup
{
	public partial class BackupsListBox : ListBox
	{
		BackupQueveInterface FQueve = null;

		public BackupQueveInterface Queve
		{
			get { return FQueve; }
			set { FQueve = value; }
		}

		public BackupsListBox()
		{
			InitializeComponent();
			DrawMode = DrawMode.OwnerDrawVariable;
			ItemHeight = 100;
		}

		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			if (e.Index != -1 && Items.Count>0 && e.Bounds.Width != 0 && e.Bounds.Height != 0)
			{
				Rectangle CellRect = GetItemRectangle(e.Index);
				TaskItem BI = (TaskItem)Items[e.Index];
				Bitmap btm = new Bitmap(CellRect.Width, CellRect.Height);
                Graphics Gr = Graphics.FromImage(btm);
				(Items[e.Index] as TaskItem).Paint(Gr, CellRect, e);
				if (FQueve!=null)
				{
					if (BI == FQueve.GetCurrentBackupItem())
					{
						Gr.DrawString("Идет процесс...", e.Font, Brushes.Black, 10, 60);
					}
					else
						if (FQueve.ExistInBackupQueve(BI))
							Gr.DrawString("В очереди. Ожидание обработки...", e.Font, Brushes.Black, 10, 60);
				}
				e.Graphics.DrawImage(btm, CellRect.X, CellRect.Y);
				btm.Dispose();
			}
			if (e.Index == 0 && Items.Count == 0)
			{
				e.Graphics.FillRectangle(Brushes.White, e.Bounds);
			}
		}

		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			//
		}

	}
}
