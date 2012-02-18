namespace EgidaBackup
{
    partial class BackupEditForm
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
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.eDepositorySize = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.eCountSave = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.eSaveTime = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bAddDest = new System.Windows.Forms.ToolStripButton();
            this.bDelDest = new System.Windows.Forms.ToolStripButton();
            this.lbDest = new System.Windows.Forms.ListBox();
            this.tabSnapshot = new System.Windows.Forms.TabPage();
            this.bChooseSnapshotDir = new System.Windows.Forms.Button();
            this.eSnapshotDir = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chbSnapshotMonth = new System.Windows.Forms.RadioButton();
            this.chbSnapshotWeek = new System.Windows.Forms.RadioButton();
            this.eSnapshotInterval = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.chbSnapshot = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eDepositorySize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eCountSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSaveTime)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tabSnapshot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eSnapshotInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabSnapshot);
            this.tabControl1.Controls.SetChildIndex(this.tabSnapshot, 0);
            this.tabControl1.Controls.SetChildIndex(this.tabPage3, 0);
            this.tabControl1.Controls.SetChildIndex(this.tabPage1, 0);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.toolStrip1);
            this.tabPage1.Controls.Add(this.lbDest);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Size = new System.Drawing.Size(429, 340);
            this.tabPage1.Controls.SetChildIndex(this.eName, 0);
            this.tabPage1.Controls.SetChildIndex(this.lbDest, 0);
            this.tabPage1.Controls.SetChildIndex(this.toolStrip1, 0);
            this.tabPage1.Controls.SetChildIndex(this.label3, 0);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label22);
            this.tabPage3.Controls.Add(this.label23);
            this.tabPage3.Controls.Add(this.eDepositorySize);
            this.tabPage3.Controls.Add(this.label20);
            this.tabPage3.Controls.Add(this.label19);
            this.tabPage3.Controls.Add(this.eCountSave);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.eSaveTime);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(429, 340);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Резервная копия";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(179, 67);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(125, 13);
            this.label22.TabIndex = 50;
            this.label22.Text = "Мб. (0 - неограниченно)";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(8, 67);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(110, 13);
            this.label23.TabIndex = 49;
            this.label23.Text = "Занимаемый объем";
            // 
            // eDepositorySize
            // 
            this.eDepositorySize.Location = new System.Drawing.Point(124, 65);
            this.eDepositorySize.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.eDepositorySize.Name = "eDepositorySize";
            this.eDepositorySize.Size = new System.Drawing.Size(49, 20);
            this.eDepositorySize.TabIndex = 48;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(177, 40);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(123, 13);
            this.label20.TabIndex = 47;
            this.label20.Text = "шт. (0 - неограниченно)";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 40);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(99, 13);
            this.label19.TabIndex = 46;
            this.label19.Text = "Количество копий";
            // 
            // eCountSave
            // 
            this.eCountSave.Location = new System.Drawing.Point(124, 38);
            this.eCountSave.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.eCountSave.Name = "eCountSave";
            this.eCountSave.Size = new System.Drawing.Size(49, 20);
            this.eCountSave.TabIndex = 45;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(177, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "дней (0 - неограниченно)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Хранить копию";
            // 
            // eSaveTime
            // 
            this.eSaveTime.Location = new System.Drawing.Point(124, 12);
            this.eSaveTime.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.eSaveTime.Name = "eSaveTime";
            this.eSaveTime.Size = new System.Drawing.Size(49, 20);
            this.eSaveTime.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Location = new System.Drawing.Point(3, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Директории для архивных копий";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bAddDest,
            this.bDelDest});
            this.toolStrip1.Location = new System.Drawing.Point(3, 239);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(423, 25);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bAddDest
            // 
            this.bAddDest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bAddDest.Image = global::EgidaBackup.Properties.Resources.add2;
            this.bAddDest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bAddDest.Name = "bAddDest";
            this.bAddDest.Size = new System.Drawing.Size(23, 22);
            this.bAddDest.Text = "Добавить путь";
            this.bAddDest.Click += new System.EventHandler(this.bAddDest_Click);
            // 
            // bDelDest
            // 
            this.bDelDest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bDelDest.Image = global::EgidaBackup.Properties.Resources.delete2;
            this.bDelDest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bDelDest.Name = "bDelDest";
            this.bDelDest.Size = new System.Drawing.Size(23, 22);
            this.bDelDest.Text = "Удалить путь";
            this.bDelDest.Click += new System.EventHandler(this.bDelDest_Click);
            // 
            // lbDest
            // 
            this.lbDest.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbDest.FormattingEnabled = true;
            this.lbDest.IntegralHeight = false;
            this.lbDest.Location = new System.Drawing.Point(3, 264);
            this.lbDest.Name = "lbDest";
            this.lbDest.Size = new System.Drawing.Size(423, 73);
            this.lbDest.TabIndex = 14;
            this.lbDest.DoubleClick += new System.EventHandler(this.lbDest_DoubleClick);
            // 
            // tabSnapshot
            // 
            this.tabSnapshot.Controls.Add(this.bChooseSnapshotDir);
            this.tabSnapshot.Controls.Add(this.eSnapshotDir);
            this.tabSnapshot.Controls.Add(this.label6);
            this.tabSnapshot.Controls.Add(this.chbSnapshotMonth);
            this.tabSnapshot.Controls.Add(this.chbSnapshotWeek);
            this.tabSnapshot.Controls.Add(this.eSnapshotInterval);
            this.tabSnapshot.Controls.Add(this.label2);
            this.tabSnapshot.Controls.Add(this.chbSnapshot);
            this.tabSnapshot.Location = new System.Drawing.Point(4, 23);
            this.tabSnapshot.Name = "tabSnapshot";
            this.tabSnapshot.Padding = new System.Windows.Forms.Padding(3);
            this.tabSnapshot.Size = new System.Drawing.Size(429, 340);
            this.tabSnapshot.TabIndex = 3;
            this.tabSnapshot.Text = "Снимки резервных копий";
            this.tabSnapshot.UseVisualStyleBackColor = true;
            // 
            // bChooseSnapshotDir
            // 
            this.bChooseSnapshotDir.Location = new System.Drawing.Point(396, 89);
            this.bChooseSnapshotDir.Name = "bChooseSnapshotDir";
            this.bChooseSnapshotDir.Size = new System.Drawing.Size(23, 23);
            this.bChooseSnapshotDir.TabIndex = 7;
            this.bChooseSnapshotDir.Text = "...";
            this.bChooseSnapshotDir.UseVisualStyleBackColor = true;
            this.bChooseSnapshotDir.Click += new System.EventHandler(this.bChooseSnapshotDir_Click);
            // 
            // eSnapshotDir
            // 
            this.eSnapshotDir.Location = new System.Drawing.Point(130, 91);
            this.eSnapshotDir.Name = "eSnapshotDir";
            this.eSnapshotDir.Size = new System.Drawing.Size(266, 20);
            this.eSnapshotDir.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Директория снимков";
            // 
            // chbSnapshotMonth
            // 
            this.chbSnapshotMonth.AutoSize = true;
            this.chbSnapshotMonth.Location = new System.Drawing.Point(159, 59);
            this.chbSnapshotMonth.Name = "chbSnapshotMonth";
            this.chbSnapshotMonth.Size = new System.Drawing.Size(69, 17);
            this.chbSnapshotMonth.TabIndex = 4;
            this.chbSnapshotMonth.Text = "месяцев";
            this.chbSnapshotMonth.UseVisualStyleBackColor = true;
            // 
            // chbSnapshotWeek
            // 
            this.chbSnapshotWeek.AutoSize = true;
            this.chbSnapshotWeek.Checked = true;
            this.chbSnapshotWeek.Location = new System.Drawing.Point(159, 36);
            this.chbSnapshotWeek.Name = "chbSnapshotWeek";
            this.chbSnapshotWeek.Size = new System.Drawing.Size(61, 17);
            this.chbSnapshotWeek.TabIndex = 3;
            this.chbSnapshotWeek.TabStop = true;
            this.chbSnapshotWeek.Text = "недели";
            this.chbSnapshotWeek.UseVisualStyleBackColor = true;
            // 
            // eSnapshotInterval
            // 
            this.eSnapshotInterval.Location = new System.Drawing.Point(66, 47);
            this.eSnapshotInterval.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.eSnapshotInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.eSnapshotInterval.Name = "eSnapshotInterval";
            this.eSnapshotInterval.Size = new System.Drawing.Size(77, 20);
            this.eSnapshotInterval.TabIndex = 2;
            this.eSnapshotInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Каждые";
            // 
            // chbSnapshot
            // 
            this.chbSnapshot.AutoSize = true;
            this.chbSnapshot.Location = new System.Drawing.Point(8, 6);
            this.chbSnapshot.Name = "chbSnapshot";
            this.chbSnapshot.Size = new System.Drawing.Size(212, 17);
            this.chbSnapshot.TabIndex = 0;
            this.chbSnapshot.Text = "Создавать снимки резервных копий";
            this.chbSnapshot.UseVisualStyleBackColor = true;
            // 
            // BackupEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 405);
            this.Name = "BackupEditForm";
            this.Text = "BackupEditForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eDepositorySize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eCountSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSaveTime)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabSnapshot.ResumeLayout(false);
            this.tabSnapshot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eSnapshotInterval)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        protected System.Windows.Forms.NumericUpDown eDepositorySize;
        protected System.Windows.Forms.NumericUpDown eCountSave;
        protected System.Windows.Forms.NumericUpDown eSaveTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bAddDest;
        private System.Windows.Forms.ToolStripButton bDelDest;
        private System.Windows.Forms.ListBox lbDest;
        protected System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabSnapshot;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox chbSnapshot;
		private System.Windows.Forms.RadioButton chbSnapshotMonth;
		private System.Windows.Forms.RadioButton chbSnapshotWeek;
		private System.Windows.Forms.NumericUpDown eSnapshotInterval;
		private System.Windows.Forms.TextBox eSnapshotDir;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button bChooseSnapshotDir;
    }
}