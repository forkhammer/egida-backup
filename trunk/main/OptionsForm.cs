using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EgidaBackup
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
        }

        public static void Dialog()
        {
            OptionsForm Dlg = new OptionsForm();
            Dlg.LoadOptions();
            if (Dlg.ShowDialog() == DialogResult.OK)
                Dlg.SaveOptions();
            Dlg.Dispose();
        }

        public void LoadOptions()
        {
            chbAutorun.Checked = Program.Options["Autorun"].AsBool;
            eSender.Text = Program.Options["Notice.Sender"].AsString;
            eSMTP.Text = Program.Options["Notice.SMTP"].AsString;
            eLogin.Text = Program.Options["Notice.Login"].AsString;
            ePass.Text = Program.Options["Notice.Pass"].AsString;
            eMailTo.Text = Program.Options["Notice.Mailto"].AsString;
        }

        public void SaveOptions()
        {
            Program.Options["Autorun"].AsBool = chbAutorun.Checked;
            Program.Options["Notice.Sender"].AsString = eSender.Text;
            Program.Options["Notice.SMTP"].AsString = eSMTP.Text;
            Program.Options["Notice.Login"].AsString = eLogin.Text;
            Program.Options["Notice.Pass"].AsString = ePass.Text;
            Program.Options["Notice.Mailto"].AsString = eMailTo.Text;
            Program.Options.Save();
        }
    }
}
