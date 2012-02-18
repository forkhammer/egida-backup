using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EgidaBackup
{
    public partial class BackupEditForm : EditForm
    {
        public BackupEditForm()
        {
            InitializeComponent();
        }

        protected override void LoadInfoFromTask()
        {
            base.LoadInfoFromTask();
            BackupItem BI = (Task as BackupItem);
            eSaveTime.Value = BI.SaveTime;
            eCountSave.Value = BI.CountSave;
            eDepositorySize.Value = BI.DepositorySize;
            lbDest.Items.AddRange(BI.Dest.ToArray());

			chbSnapshot.Checked = BI.Snapshot;
			eSnapshotInterval.Value = BI.SnapshotInterval;
			chbSnapshotWeek.Checked = BI.SnapshotIntType == 1;
			chbSnapshotMonth.Checked = BI.SnapshotIntType == 2;
			eSnapshotDir.Text = BI.SnapshotDir;
        }

        protected override bool SaveInfoToTask()
        {
            bool res = base.SaveInfoToTask();
            BackupItem BI = (BackupItem)Task;
            BI.SaveTime = (int)eSaveTime.Value;
            BI.CountSave = (int)eCountSave.Value;
            BI.DepositorySize = (int)eDepositorySize.Value;
            BI.Dest.Clear();
            string[] str = new string[lbDest.Items.Count];
            lbDest.Items.CopyTo(str, 0);
            BI.Dest.AddRange(str);

			BI.Snapshot = chbSnapshot.Checked;
			BI.SnapshotInterval = (int)eSnapshotInterval.Value;
			if (chbSnapshotWeek.Checked)
				BI.SnapshotIntType = 1;
			else
				BI.SnapshotIntType = 2;
			BI.SnapshotDir = eSnapshotDir.Text;

            return res;
        }

        private void bAddDest_Click(object sender, EventArgs e)
        {
            string p = ManualChooseDirectoryForm.Dialog("");
            if (p != "")
                lbDest.Items.Add(p);
        }

        private void bDelDest_Click(object sender, EventArgs e)
        {
            if (lbDest.SelectedItem != null)
            {
                lbDest.Items.Remove(lbDest.SelectedItem);
            }
        }

        private void lbDest_DoubleClick(object sender, EventArgs e)
        {
            if (lbDest.SelectedIndex != -1)
            {
                string p = ManualChooseDirectoryForm.Dialog((string)lbDest.Items[lbDest.SelectedIndex]);
                if (p != "")
                    lbDest.Items[lbDest.SelectedIndex] = p;
            }
        }

		private void bChooseSnapshotDir_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dlg = new FolderBrowserDialog();
			dlg.Description = "Выберите директорию для архивации";
			dlg.SelectedPath = eSnapshotDir.Text;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				eSnapshotDir.Text = dlg.SelectedPath;
			}
			dlg.Dispose();
		}
    }
}
