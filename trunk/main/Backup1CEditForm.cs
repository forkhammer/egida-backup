using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EgidaBackup
{
    public partial class Backup1CEditForm : BackupEditForm
    {
        public Backup1CEditForm()
        {
            InitializeComponent();
        }

        public new static bool Dialog(TaskItem TI)
        {
            Backup1CEditForm dlg = new Backup1CEditForm();
            dlg.Task = TI;
            return dlg.ShowDialog() == DialogResult.OK;
        }

        protected override void LoadInfoFromTask()
        {
            base.LoadInfoFromTask();
            Backup1CItem BI = (Task as Backup1CItem);
            eCommandFile.Text = BI.CommandFile;
            rbFileMode.Checked = !BI.ClientServer;
            rbServerMode.Checked = BI.ClientServer;
            eCatalogBase.Text = BI.CatalogBase;
            eServer1C.Text = BI.Server1C;
            e1CBase.Text = BI.ServerBase;
            eUser1C.Text = BI.User1C;
            ePass1C.Text = BI.Pass1C;
            cbVersion1C.SelectedIndex = cbVersion1C.Items.IndexOf(BI.Version1C);
            chbDisconnectUsers.Checked = BI.DisconnectUsers;
            chbKillUsers.Checked = BI.KillUsers;
            CheckEnabledTask();
        }

        protected override bool SaveInfoToTask()
        {
            bool res = base.SaveInfoToTask();
            Backup1CItem BI = (Backup1CItem)Task;
            BI.CommandFile = eCommandFile.Text;
            BI.ClientServer = rbServerMode.Checked;
            BI.CatalogBase = eCatalogBase.Text;
            BI.Server1C = eServer1C.Text;
            BI.ServerBase = e1CBase.Text;
            BI.User1C = eUser1C.Text;
            BI.Pass1C = ePass1C.Text;
            BI.Version1C = cbVersion1C.Items[cbVersion1C.SelectedIndex].ToString();
            BI.DisconnectUsers = chbDisconnectUsers.Checked;
            BI.KillUsers = chbKillUsers.Checked;
            return res;
        }

        protected virtual void CheckEnabledTask()
        {
            pFileMode.Visible = rbFileMode.Checked;
            pServerMode.Visible = rbServerMode.Checked;
            chbDisconnectUsers.Enabled = !(rbServerMode.Checked && cbVersion1C.SelectedIndex == 0);
            chbKillUsers.Enabled = chbDisconnectUsers.Checked && chbDisconnectUsers.Enabled;
        }

        private void bChooseCommandFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Exe-файлы|*.exe";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                eCommandFile.Text = dlg.FileName;
            }
            dlg.Dispose();
        }

        private void bChooseCatalogBase_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.Description = "Выберите директорию информационной базы 1С";
            dlg.SelectedPath = eCatalogBase.Text;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                eCatalogBase.Text = dlg.SelectedPath;
            }
            dlg.Dispose();
        }

        private void rbFileMode_CheckedChanged(object sender, EventArgs e)
        {
            CheckEnabledTask();
        }
    }
}
