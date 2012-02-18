using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EgidaBackup
{
	public partial class EditForm : Form
	{
		TaskItem FTask = null;

		public TaskItem Task
		{
			get { return FTask; }
			set 
			{ 
				FTask = value;
				LoadInfoFromTask();
			}
		}

		public EditForm()
		{
			InitializeComponent();
		}

		public static bool Dialog(TaskItem TI)
		{
			EditForm dlg = new EditForm();
			dlg.Task = TI;
			return dlg.ShowDialog() == DialogResult.OK;
		}

		protected virtual void LoadInfoFromTask()
		{
			eName.Text = FTask.Name;
			rbOnce.Checked = !FTask.Periodical;
			rbEvery.Checked = FTask.Periodical;
			dtOnceDate.Value = FTask.OnceDate;
			rbEveryDay.Checked = FTask.Everies == 1;
			rbEveryWeek.Checked = FTask.Everies == 2;
			rbEveryMonth.Checked = FTask.Everies == 3;
			ePeriod.Value = FTask.Period;
			lbWeek.SetItemChecked(0, (FTask.DayOfWeek & 1) != 0);
			lbWeek.SetItemChecked(1, (FTask.DayOfWeek & 2) != 0);
			lbWeek.SetItemChecked(2, (FTask.DayOfWeek & 4) != 0);
			lbWeek.SetItemChecked(3, (FTask.DayOfWeek & 8) != 0);
			lbWeek.SetItemChecked(4, (FTask.DayOfWeek & 16) != 0);
			lbWeek.SetItemChecked(5, (FTask.DayOfWeek & 32) != 0);
			lbWeek.SetItemChecked(6, (FTask.DayOfWeek & 64) != 0);
			eDayOfMonth.Value = FTask.DayOfMonth;
			rbOnceTime.Checked = !FTask.PeriodicalTime;
			rbEveryTime.Checked = FTask.PeriodicalTime;
			dtEveryTime.Value = FTask.OnceTime;
			eEveryHour.Value = FTask.EveryTime;
			chbActive.Checked = FTask.Active;
            chbMailNotice.Checked = FTask.MailNotice;

			CheckEnabledRasp();
		}

		protected virtual void CheckEnabledRasp()
		{
			pOnce.Visible = rbOnce.Checked;
			pEvery.Visible = rbEvery.Checked;
			panel4.Visible = rbEveryWeek.Checked;
			panel5.Visible = rbEveryMonth.Checked;
			dtEveryTime.Enabled = rbOnceTime.Checked;
			eEveryHour.Enabled = rbEveryTime.Checked;
		}

		protected virtual bool SaveInfoToTask()
		{
			if (eName.Text.Trim() == "")
			{
				MessageBox.Show("Введите название задания!");
				return false;
			}
			FTask.Name = eName.Text;
			FTask.Periodical = rbEvery.Checked;
			FTask.OnceDate = dtOnceDate.Value;
			if (rbEveryDay.Checked)
				FTask.Everies = 1;
			if (rbEveryWeek.Checked)
				FTask.Everies = 2;
			if (rbEveryMonth.Checked)
				FTask.Everies = 3;
			FTask.Period = (int)ePeriod.Value;
			FTask.DayOfWeek = (byte)((lbWeek.GetItemChecked(0) ? 1 : 0) |
								(lbWeek.GetItemChecked(1) ? 2 : 0) |
								(lbWeek.GetItemChecked(2) ? 4 : 0) |
								(lbWeek.GetItemChecked(3) ? 8 : 0) |
								(lbWeek.GetItemChecked(4) ? 16 : 0) |
								(lbWeek.GetItemChecked(5) ? 32 : 0) |
								(lbWeek.GetItemChecked(6) ? 64 : 0));
			FTask.DayOfMonth = (byte)eDayOfMonth.Value;
			FTask.PeriodicalTime = rbEveryTime.Checked;
			FTask.OnceTime = dtEveryTime.Value;
			FTask.EveryTime = (byte)eEveryHour.Value;
			FTask.Active = chbActive.Checked;
            FTask.MailNotice = chbMailNotice.Checked;

			return true;
		}

		private void bOK_Click(object sender, EventArgs e)
		{
			if (SaveInfoToTask())
				this.DialogResult = DialogResult.OK;
		}

		private void rbOnce_CheckedChanged(object sender, EventArgs e)
		{
			CheckEnabledRasp();
		}
	}
}
