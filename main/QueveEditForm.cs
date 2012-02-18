using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EgidaBackup
{
	public partial class QueveEditForm : EditForm
	{
		public QueveEditForm()
		{
			InitializeComponent();
		}

		public new static bool Dialog(TaskItem TI)
		{
			QueveEditForm dlg = new QueveEditForm();
			dlg.Task = TI;
			return dlg.ShowDialog() == DialogResult.OK;
		}

        protected override void LoadInfoFromTask()
        {
            base.LoadInfoFromTask();
            QueveItem BI = (Task as QueveItem);
            for (int i = 0; i < BI.Queve.Count; i++)
                lbQueve.Items.Add(BI.Queve[i]);
        }

        protected override bool SaveInfoToTask()
        {
            bool res = base.SaveInfoToTask();
            QueveItem BI = (QueveItem)Task;
            BI.Queve.Clear();
            foreach (TaskItem TI in lbQueve.Items)
                BI.Queve.Add(TI);
            return res;
        }

		private void bAdd_DropDownOpening(object sender, EventArgs e)
		{
			QueveItem BI = (QueveItem) Task;
			bAdd.DropDownItems.Clear();
            for (int i = 0; i < BI.Backups.Count; i++)
            {
                if (!(BI.Backups[i] is QueveItem))
                {
                    ToolStripMenuItem SI = new ToolStripMenuItem();
                    SI.Text = BI.Backups[i].Name;
                    SI.Tag = BI.Backups[i];
                    bAdd.DropDownItems.Add(SI);
                }
            }
		}

        private void bAdd_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Tag != null)
            {
                lbQueve.Items.Add(e.ClickedItem.Tag);
            }
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            if (lbQueve.SelectedItem != null)
                lbQueve.Items.Remove(lbQueve.SelectedItem);
        }

        private void bMoveDown_Click(object sender, EventArgs e)
        {
            if (lbQueve.SelectedItem!=null)
                if (lbQueve.SelectedItem != lbQueve.Items[lbQueve.Items.Count - 1])
                {
                    TaskItem TI = (TaskItem)lbQueve.Items[lbQueve.SelectedIndex];
                    lbQueve.Items[lbQueve.SelectedIndex] = lbQueve.Items[lbQueve.SelectedIndex + 1];
                    lbQueve.Items[lbQueve.SelectedIndex + 1] = TI;
                    lbQueve.SelectedIndex = lbQueve.SelectedIndex + 1;
                    lbQueve.Refresh();
                }
        }

        private void bMoveUp_Click(object sender, EventArgs e)
        {
            if (lbQueve.SelectedItem != null)
                if (lbQueve.SelectedItem != lbQueve.Items[0])
                {
                    TaskItem TI = (TaskItem)lbQueve.Items[lbQueve.SelectedIndex];
                    lbQueve.Items[lbQueve.SelectedIndex] = lbQueve.Items[lbQueve.SelectedIndex - 1];
                    lbQueve.Items[lbQueve.SelectedIndex - 1] = TI;
                    lbQueve.SelectedIndex = lbQueve.SelectedIndex - 1;
                    lbQueve.Refresh();
                }
        }

        private void lbQueve_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index != -1 && lbQueve.Items.Count > 0 && e.Bounds.Width != 0 && e.Bounds.Height != 0)
            {
                Brush B, TB;
                Pen P;
                if ((e.State & DrawItemState.Selected) == 0)
                {
                    B = SystemBrushes.Window;
                    TB = SystemBrushes.WindowText;
                    P = Pens.Black;
                }
                else
                {
                    B = SystemBrushes.Highlight;
                    TB = SystemBrushes.HighlightText;
                    P = SystemPens.Window;
                }
                Rectangle Rect = lbQueve.GetItemRectangle(e.Index);
                Font NumberFont = new Font(e.Font.FontFamily, e.Font.Size + 5);
                e.Graphics.FillRectangle(B, Rect.Left, Rect.Top, Rect.Width, Rect.Height);
                e.Graphics.DrawString((lbQueve.Items[e.Index] as TaskItem).Name, e.Font, TB, 30, Rect.Top + 8);
                e.Graphics.DrawString((e.Index + 1).ToString(), NumberFont, TB, 5, Rect.Top + 4);
                e.Graphics.DrawEllipse(P, 3, Rect.Top + 5, 20, 20); 
                NumberFont.Dispose();
            }
        }
	}
}
