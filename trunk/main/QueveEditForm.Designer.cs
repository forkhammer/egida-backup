namespace EgidaBackup
{
	partial class QueveEditForm
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
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bAdd = new System.Windows.Forms.ToolStripDropDownButton();
            this.bDel = new System.Windows.Forms.ToolStripButton();
            this.bMoveDown = new System.Windows.Forms.ToolStripButton();
            this.bMoveUp = new System.Windows.Forms.ToolStripButton();
            this.mnBackups = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lbQueve = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Size = new System.Drawing.Size(434, 396);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.toolStrip1);
            this.tabPage1.Controls.Add(this.lbQueve);
            this.tabPage1.Size = new System.Drawing.Size(426, 370);
            this.tabPage1.Controls.SetChildIndex(this.lbQueve, 0);
            this.tabPage1.Controls.SetChildIndex(this.toolStrip1, 0);
            this.tabPage1.Controls.SetChildIndex(this.eName, 0);
            // 
            // bOK
            // 
            this.bOK.Location = new System.Drawing.Point(271, 402);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(352, 402);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bAdd,
            this.bDel,
            this.bMoveDown,
            this.bMoveUp});
            this.toolStrip1.Location = new System.Drawing.Point(3, 37);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(420, 25);
            this.toolStrip1.TabIndex = 3;
            // 
            // bAdd
            // 
            this.bAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bAdd.Image = global::EgidaBackup.Properties.Resources.add2;
            this.bAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(29, 22);
            this.bAdd.ToolTipText = "Добавить задание";
            this.bAdd.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.bAdd_DropDownItemClicked);
            this.bAdd.DropDownOpening += new System.EventHandler(this.bAdd_DropDownOpening);
            // 
            // bDel
            // 
            this.bDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bDel.Image = global::EgidaBackup.Properties.Resources.delete2;
            this.bDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bDel.Name = "bDel";
            this.bDel.Size = new System.Drawing.Size(23, 22);
            this.bDel.ToolTipText = "Удалить задание";
            this.bDel.Click += new System.EventHandler(this.bDel_Click);
            // 
            // bMoveDown
            // 
            this.bMoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bMoveDown.Image = global::EgidaBackup.Properties.Resources.arrow_down_green;
            this.bMoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bMoveDown.Name = "bMoveDown";
            this.bMoveDown.Size = new System.Drawing.Size(23, 22);
            this.bMoveDown.ToolTipText = "Вниз";
            this.bMoveDown.Click += new System.EventHandler(this.bMoveDown_Click);
            // 
            // bMoveUp
            // 
            this.bMoveUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bMoveUp.Image = global::EgidaBackup.Properties.Resources.arrow_up_green;
            this.bMoveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bMoveUp.Name = "bMoveUp";
            this.bMoveUp.Size = new System.Drawing.Size(23, 22);
            this.bMoveUp.ToolTipText = "Вверх";
            this.bMoveUp.Click += new System.EventHandler(this.bMoveUp_Click);
            // 
            // mnBackups
            // 
            this.mnBackups.Name = "mnBackups";
            this.mnBackups.Size = new System.Drawing.Size(61, 4);
            // 
            // lbQueve
            // 
            this.lbQueve.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbQueve.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lbQueve.FormattingEnabled = true;
            this.lbQueve.IntegralHeight = false;
            this.lbQueve.ItemHeight = 30;
            this.lbQueve.Location = new System.Drawing.Point(3, 62);
            this.lbQueve.Name = "lbQueve";
            this.lbQueve.Size = new System.Drawing.Size(420, 305);
            this.lbQueve.TabIndex = 4;
            this.lbQueve.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbQueve_DrawItem);
            // 
            // QueveEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 434);
            this.Name = "QueveEditForm";
            this.Text = "Очередь заданий";
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.bCancel, 0);
            this.Controls.SetChildIndex(this.bOK, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton bDel;
		private System.Windows.Forms.ContextMenuStrip mnBackups;
		private System.Windows.Forms.ToolStripDropDownButton bAdd;
		private System.Windows.Forms.ListBox lbQueve;
        private System.Windows.Forms.ToolStripButton bMoveDown;
        private System.Windows.Forms.ToolStripButton bMoveUp;
	}
}