namespace EgidaBackup
{
	partial class EditForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.eName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pTime = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.eEveryHour = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.rbEveryTime = new System.Windows.Forms.RadioButton();
            this.rbOnceTime = new System.Windows.Forms.RadioButton();
            this.dtEveryTime = new System.Windows.Forms.DateTimePicker();
            this.chbActive = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.GroupBox();
            this.pEvery = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.eDayOfMonth = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.rbEveryMonth = new System.Windows.Forms.RadioButton();
            this.ePeriod = new System.Windows.Forms.NumericUpDown();
            this.rbEveryWeek = new System.Windows.Forms.RadioButton();
            this.rbEveryDay = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbWeek = new System.Windows.Forms.CheckedListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pOnce = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.dtOnceDate = new System.Windows.Forms.DateTimePicker();
            this.rbEvery = new System.Windows.Forms.RadioButton();
            this.rbOnce = new System.Windows.Forms.RadioButton();
            this.bOK = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.tabNotice = new System.Windows.Forms.TabPage();
            this.chbMailNotice = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.pTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eEveryHour)).BeginInit();
            this.panel2.SuspendLayout();
            this.pEvery.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eDayOfMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ePeriod)).BeginInit();
            this.panel4.SuspendLayout();
            this.pOnce.SuspendLayout();
            this.tabNotice.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabNotice);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(437, 367);
            this.tabControl1.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.eName);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(429, 340);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Задание";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // eName
            // 
            this.eName.Location = new System.Drawing.Point(71, 6);
            this.eName.Name = "eName";
            this.eName.Size = new System.Drawing.Size(308, 20);
            this.eName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pTime);
            this.tabPage2.Controls.Add(this.chbActive);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.rbEvery);
            this.tabPage2.Controls.Add(this.rbOnce);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(429, 340);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Расписание";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pTime
            // 
            this.pTime.Controls.Add(this.label12);
            this.pTime.Controls.Add(this.eEveryHour);
            this.pTime.Controls.Add(this.label11);
            this.pTime.Controls.Add(this.rbEveryTime);
            this.pTime.Controls.Add(this.rbOnceTime);
            this.pTime.Controls.Add(this.dtEveryTime);
            this.pTime.Location = new System.Drawing.Point(7, 160);
            this.pTime.Name = "pTime";
            this.pTime.Size = new System.Drawing.Size(412, 76);
            this.pTime.TabIndex = 5;
            this.pTime.TabStop = false;
            this.pTime.Text = "Время";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(135, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "час";
            // 
            // eEveryHour
            // 
            this.eEveryHour.Location = new System.Drawing.Point(79, 47);
            this.eEveryHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.eEveryHour.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.eEveryHour.Name = "eEveryHour";
            this.eEveryHour.Size = new System.Drawing.Size(50, 20);
            this.eEveryHour.TabIndex = 4;
            this.eEveryHour.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "каждый";
            // 
            // rbEveryTime
            // 
            this.rbEveryTime.AutoSize = true;
            this.rbEveryTime.Location = new System.Drawing.Point(7, 49);
            this.rbEveryTime.Name = "rbEveryTime";
            this.rbEveryTime.Size = new System.Drawing.Size(14, 13);
            this.rbEveryTime.TabIndex = 2;
            this.rbEveryTime.UseVisualStyleBackColor = true;
            this.rbEveryTime.CheckedChanged += new System.EventHandler(this.rbOnce_CheckedChanged);
            // 
            // rbOnceTime
            // 
            this.rbOnceTime.AutoSize = true;
            this.rbOnceTime.Checked = true;
            this.rbOnceTime.Location = new System.Drawing.Point(7, 22);
            this.rbOnceTime.Name = "rbOnceTime";
            this.rbOnceTime.Size = new System.Drawing.Size(14, 13);
            this.rbOnceTime.TabIndex = 1;
            this.rbOnceTime.TabStop = true;
            this.rbOnceTime.UseVisualStyleBackColor = true;
            this.rbOnceTime.CheckedChanged += new System.EventHandler(this.rbOnce_CheckedChanged);
            // 
            // dtEveryTime
            // 
            this.dtEveryTime.CustomFormat = "HH:mm";
            this.dtEveryTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEveryTime.Location = new System.Drawing.Point(27, 18);
            this.dtEveryTime.Name = "dtEveryTime";
            this.dtEveryTime.ShowUpDown = true;
            this.dtEveryTime.Size = new System.Drawing.Size(63, 20);
            this.dtEveryTime.TabIndex = 0;
            // 
            // chbActive
            // 
            this.chbActive.AutoSize = true;
            this.chbActive.Location = new System.Drawing.Point(251, 7);
            this.chbActive.Name = "chbActive";
            this.chbActive.Size = new System.Drawing.Size(166, 17);
            this.chbActive.TabIndex = 16;
            this.chbActive.Text = "Задействовать расписание";
            this.chbActive.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pEvery);
            this.panel2.Controls.Add(this.pOnce);
            this.panel2.Location = new System.Drawing.Point(6, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(414, 124);
            this.panel2.TabIndex = 4;
            this.panel2.TabStop = false;
            this.panel2.Text = "День";
            // 
            // pEvery
            // 
            this.pEvery.Controls.Add(this.panel5);
            this.pEvery.Controls.Add(this.rbEveryMonth);
            this.pEvery.Controls.Add(this.ePeriod);
            this.pEvery.Controls.Add(this.rbEveryWeek);
            this.pEvery.Controls.Add(this.rbEveryDay);
            this.pEvery.Controls.Add(this.panel4);
            this.pEvery.Controls.Add(this.label10);
            this.pEvery.Location = new System.Drawing.Point(6, 19);
            this.pEvery.Name = "pEvery";
            this.pEvery.Size = new System.Drawing.Size(402, 100);
            this.pEvery.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.eDayOfMonth);
            this.panel5.Controls.Add(this.label16);
            this.panel5.Location = new System.Drawing.Point(77, 24);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(325, 37);
            this.panel5.TabIndex = 5;
            // 
            // eDayOfMonth
            // 
            this.eDayOfMonth.Location = new System.Drawing.Point(88, 7);
            this.eDayOfMonth.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.eDayOfMonth.Name = "eDayOfMonth";
            this.eDayOfMonth.Size = new System.Drawing.Size(73, 20);
            this.eDayOfMonth.TabIndex = 10;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(-3, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(75, 13);
            this.label16.TabIndex = 9;
            this.label16.Text = "День месяца";
            // 
            // rbEveryMonth
            // 
            this.rbEveryMonth.AutoSize = true;
            this.rbEveryMonth.Location = new System.Drawing.Point(0, 47);
            this.rbEveryMonth.Name = "rbEveryMonth";
            this.rbEveryMonth.Size = new System.Drawing.Size(58, 17);
            this.rbEveryMonth.TabIndex = 2;
            this.rbEveryMonth.Text = "Месяц";
            this.rbEveryMonth.UseVisualStyleBackColor = true;
            this.rbEveryMonth.CheckedChanged += new System.EventHandler(this.rbOnce_CheckedChanged);
            // 
            // ePeriod
            // 
            this.ePeriod.Location = new System.Drawing.Point(165, 1);
            this.ePeriod.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.ePeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ePeriod.Name = "ePeriod";
            this.ePeriod.Size = new System.Drawing.Size(73, 20);
            this.ePeriod.TabIndex = 1;
            this.ePeriod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rbEveryWeek
            // 
            this.rbEveryWeek.AutoSize = true;
            this.rbEveryWeek.Location = new System.Drawing.Point(0, 24);
            this.rbEveryWeek.Name = "rbEveryWeek";
            this.rbEveryWeek.Size = new System.Drawing.Size(63, 17);
            this.rbEveryWeek.TabIndex = 1;
            this.rbEveryWeek.Text = "Неделя";
            this.rbEveryWeek.UseVisualStyleBackColor = true;
            this.rbEveryWeek.CheckedChanged += new System.EventHandler(this.rbOnce_CheckedChanged);
            // 
            // rbEveryDay
            // 
            this.rbEveryDay.AutoSize = true;
            this.rbEveryDay.Checked = true;
            this.rbEveryDay.Location = new System.Drawing.Point(0, 1);
            this.rbEveryDay.Name = "rbEveryDay";
            this.rbEveryDay.Size = new System.Drawing.Size(52, 17);
            this.rbEveryDay.TabIndex = 0;
            this.rbEveryDay.TabStop = true;
            this.rbEveryDay.Text = "День";
            this.rbEveryDay.UseVisualStyleBackColor = true;
            this.rbEveryDay.CheckedChanged += new System.EventHandler(this.rbOnce_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lbWeek);
            this.panel4.Location = new System.Drawing.Point(77, 24);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(325, 70);
            this.panel4.TabIndex = 4;
            // 
            // lbWeek
            // 
            this.lbWeek.CheckOnClick = true;
            this.lbWeek.FormattingEnabled = true;
            this.lbWeek.HorizontalScrollbar = true;
            this.lbWeek.Items.AddRange(new object[] {
            "Понедельник",
            "Вторник",
            "Среда",
            "Четверг",
            "Пятница",
            "Суббота",
            "Воскресенье"});
            this.lbWeek.Location = new System.Drawing.Point(0, 3);
            this.lbWeek.MultiColumn = true;
            this.lbWeek.Name = "lbWeek";
            this.lbWeek.Size = new System.Drawing.Size(322, 64);
            this.lbWeek.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(74, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Периодичность";
            // 
            // pOnce
            // 
            this.pOnce.Controls.Add(this.label8);
            this.pOnce.Controls.Add(this.dtOnceDate);
            this.pOnce.Location = new System.Drawing.Point(6, 19);
            this.pOnce.Name = "pOnce";
            this.pOnce.Size = new System.Drawing.Size(402, 31);
            this.pOnce.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Дата";
            // 
            // dtOnceDate
            // 
            this.dtOnceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtOnceDate.Location = new System.Drawing.Point(81, 3);
            this.dtOnceDate.Name = "dtOnceDate";
            this.dtOnceDate.ShowUpDown = true;
            this.dtOnceDate.Size = new System.Drawing.Size(84, 20);
            this.dtOnceDate.TabIndex = 0;
            // 
            // rbEvery
            // 
            this.rbEvery.AutoSize = true;
            this.rbEvery.Location = new System.Drawing.Point(125, 6);
            this.rbEvery.Name = "rbEvery";
            this.rbEvery.Size = new System.Drawing.Size(98, 17);
            this.rbEvery.TabIndex = 1;
            this.rbEvery.Text = "Периодически";
            this.rbEvery.UseVisualStyleBackColor = true;
            this.rbEvery.CheckedChanged += new System.EventHandler(this.rbOnce_CheckedChanged);
            // 
            // rbOnce
            // 
            this.rbOnce.AutoSize = true;
            this.rbOnce.Checked = true;
            this.rbOnce.Location = new System.Drawing.Point(8, 6);
            this.rbOnce.Name = "rbOnce";
            this.rbOnce.Size = new System.Drawing.Size(72, 17);
            this.rbOnce.TabIndex = 0;
            this.rbOnce.TabStop = true;
            this.rbOnce.Text = "Один раз";
            this.rbOnce.UseVisualStyleBackColor = true;
            this.rbOnce.CheckedChanged += new System.EventHandler(this.rbOnce_CheckedChanged);
            // 
            // bOK
            // 
            this.bOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bOK.Location = new System.Drawing.Point(274, 373);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(75, 23);
            this.bOK.TabIndex = 20;
            this.bOK.Text = "ОК";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(355, 373);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 19;
            this.bCancel.Text = "Отмена";
            this.bCancel.UseVisualStyleBackColor = true;
            // 
            // tabNotice
            // 
            this.tabNotice.Controls.Add(this.chbMailNotice);
            this.tabNotice.Location = new System.Drawing.Point(4, 23);
            this.tabNotice.Name = "tabNotice";
            this.tabNotice.Padding = new System.Windows.Forms.Padding(3);
            this.tabNotice.Size = new System.Drawing.Size(429, 340);
            this.tabNotice.TabIndex = 2;
            this.tabNotice.Text = "Уведомления";
            this.tabNotice.UseVisualStyleBackColor = true;
            // 
            // chbMailNotice
            // 
            this.chbMailNotice.AutoSize = true;
            this.chbMailNotice.Location = new System.Drawing.Point(8, 18);
            this.chbMailNotice.Name = "chbMailNotice";
            this.chbMailNotice.Size = new System.Drawing.Size(209, 17);
            this.chbMailNotice.TabIndex = 0;
            this.chbMailNotice.Text = "Уведомлять о выполнении по почте";
            this.chbMailNotice.UseVisualStyleBackColor = true;
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 405);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.pTime.ResumeLayout(false);
            this.pTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eEveryHour)).EndInit();
            this.panel2.ResumeLayout(false);
            this.pEvery.ResumeLayout(false);
            this.pEvery.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eDayOfMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ePeriod)).EndInit();
            this.panel4.ResumeLayout(false);
            this.pOnce.ResumeLayout(false);
            this.pOnce.PerformLayout();
            this.tabNotice.ResumeLayout(false);
            this.tabNotice.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.GroupBox pTime;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.NumericUpDown eEveryHour;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.RadioButton rbEveryTime;
		private System.Windows.Forms.RadioButton rbOnceTime;
		private System.Windows.Forms.DateTimePicker dtEveryTime;
		private System.Windows.Forms.CheckBox chbActive;
		private System.Windows.Forms.GroupBox panel2;
		private System.Windows.Forms.Panel pEvery;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.NumericUpDown eDayOfMonth;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.RadioButton rbEveryMonth;
		private System.Windows.Forms.NumericUpDown ePeriod;
		private System.Windows.Forms.RadioButton rbEveryWeek;
		private System.Windows.Forms.RadioButton rbEveryDay;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.CheckedListBox lbWeek;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Panel pOnce;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.DateTimePicker dtOnceDate;
		private System.Windows.Forms.RadioButton rbEvery;
		private System.Windows.Forms.RadioButton rbOnce;
		protected System.Windows.Forms.TabControl tabControl1;
		protected System.Windows.Forms.TabPage tabPage1;
		protected System.Windows.Forms.TextBox eName;
		protected System.Windows.Forms.Button bOK;
		protected System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.TabPage tabNotice;
        private System.Windows.Forms.CheckBox chbMailNotice;
	}
}