using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EgidaBackup
{
    public partial class CatalogBackupEditForm : BackupEditForm
    {
        public CatalogBackupEditForm()
        {
            InitializeComponent();
        }

        public new static bool Dialog(TaskItem TI)
        {
            CatalogBackupEditForm dlg = new CatalogBackupEditForm();
            dlg.Task = TI;
            return dlg.ShowDialog() == DialogResult.OK;
        }

        protected virtual void CheckEnabledCopy()
        {
            chbIncrement.Enabled = !chbArchive.Checked;
            cbCompress.Enabled = chbUsePassword.Enabled = chbArchive.Checked;
            eZipPassword.Enabled = chbUsePassword.Enabled && chbUsePassword.Checked;
            chbArchive.Enabled = chbArchive.Checked || !chbIncrement.Checked;
            eSaveTime.Enabled = eCountSave.Enabled = eDepositorySize.Enabled = !(chbIncrement.Enabled && chbIncrement.Checked) && !chbOnlyChanged.Checked;
            chbOnlyChanged.Enabled = !chbIncrement.Checked;
        }

        protected override void LoadInfoFromTask()
		{
			base.LoadInfoFromTask();
            CatalogBackupItem BI = (Task as CatalogBackupItem);
            ePath.Text = BI.Path;
            chbArchive.Checked = BI.Archive;
            switch (BI.Compress)
            {
                case 0:
                    cbCompress.SelectedIndex = 0;
                    break;
                case 1:
                    cbCompress.SelectedIndex = 1;
                    break;
                case 3:
                    cbCompress.SelectedIndex = 2;
                    break;
                case 5:
                    cbCompress.SelectedIndex = 3;
                    break;
                case 7:
                    cbCompress.SelectedIndex = 4;
                    break;
                case 9:
                    cbCompress.SelectedIndex = 5;
                    break;
            }
            chbIncrement.Checked = BI.Increment;
            eFileMask.Text = BI.FileMask;
            chbOnlyChanged.Checked = BI.RecoveryPoint;

            //использование пароля
            chbUsePassword.Checked = BI.UsePassword;
            eZipPassword.Text = BI.ZipPassword;

            CheckEnabledCopy();
        }

        protected override bool SaveInfoToTask()
        {
            bool res = base.SaveInfoToTask();
            CatalogBackupItem BI = (CatalogBackupItem)Task;
            BI.Path = ePath.Text;
            BI.Archive = chbArchive.Checked;
            switch (cbCompress.SelectedIndex)
            {
                case 0:
                    BI.Compress = 0;
                    break;
                case 1:
                    BI.Compress = 1;
                    break;
                case 2:
                    BI.Compress = 3;
                    break;
                case 3:
                    BI.Compress = 5;
                    break;
                case 4:
                    BI.Compress = 7;
                    break;
                case 5:
                    BI.Compress = 9;
                    break;
            }
            BI.Increment = chbIncrement.Checked;
            BI.FileMask = eFileMask.Text;
            BI.RecoveryPoint = chbOnlyChanged.Checked;

            //использование пароля
            BI.UsePassword = chbUsePassword.Checked;
            BI.ZipPassword = eZipPassword.Text;

            return res;
        }

        private void chbArchive_CheckedChanged(object sender, EventArgs e)
        {
            CheckEnabledCopy();
        }

        private void bChoosePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.Description = "Выберите директорию для архивации";
            dlg.SelectedPath = ePath.Text;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ePath.Text = dlg.SelectedPath;
                if (eName.Text == "")
                    eName.Text = System.IO.Path.GetFileName(ePath.Text);
            }
            dlg.Dispose();
        }
    }
}
