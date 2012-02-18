using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EgidaBackup
{
	public partial class CommandEditForm : EditForm
	{
		public CommandEditForm()
		{
			InitializeComponent();
		}

		public new static bool Dialog(TaskItem TI)
		{
			CommandEditForm dlg = new CommandEditForm();
			dlg.Task = TI;
			return dlg.ShowDialog() == DialogResult.OK;
		}

		protected override void LoadInfoFromTask()
		{
			base.LoadInfoFromTask();
			CommandItem CI = (Task as CommandItem);
			richScript.Text = CI.Command;
			eCommandFile.Text = CI.CommandFile;
			rbCommandFile.Checked = CI.TaskType == CommandTaskType.File;
			rbCommandText.Checked = CI.TaskType == CommandTaskType.Script;
			CheckEnableScript();
		}

		protected override bool SaveInfoToTask()
		{
			bool res = base.SaveInfoToTask();
			CommandItem CI = (Task as CommandItem);
			CI.Command = richScript.Text;
			CI.CommandFile = eCommandFile.Text;
			CI.TaskType = (CommandTaskType)(rbCommandFile.Checked ? 0 : 1);
			return true && res;
		}

		protected virtual void CheckEnableScript()
		{
			pCommandFile.Visible = rbCommandFile.Checked;
			pScript.Visible = rbCommandText.Checked;
		}

		private void rbCommandFile_CheckedChanged(object sender, EventArgs e)
		{
			CheckEnableScript();
		}

		private void bChooseCommandFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Файл *.bat|*.bat";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				eCommandFile.Text = dlg.FileName;
			}
		}
	}
}
