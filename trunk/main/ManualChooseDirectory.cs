using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EgidaBackup
{
    public partial class ManualChooseDirectoryForm : Form
    {
        public ManualChooseDirectoryForm()
        {
            InitializeComponent();
        }

        public string Path
        {
            get { return ePath.Text; }
            set { ePath.Text = value; }
        }

        public static string Dialog(string Default)
        {
            ManualChooseDirectoryForm dlg = new ManualChooseDirectoryForm();
            dlg.Path = Default;
            string res="";
            if (dlg.ShowDialog()==DialogResult.OK)
                res=dlg.Path;
            dlg.Dispose();
            return res;
        }

        private void bChoose_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.Description = "Выберите директорию для архивации";
            dlg.SelectedPath = ePath.Text;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ePath.Text = dlg.SelectedPath;
            }
            dlg.Dispose();
        }
    }
}
