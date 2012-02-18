namespace EgidaBackup
{
	partial class CommandEditForm
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
			this.rbCommandFile = new System.Windows.Forms.RadioButton();
			this.rbCommandText = new System.Windows.Forms.RadioButton();
			this.pCommandFile = new System.Windows.Forms.Panel();
			this.bChooseCommandFile = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.eCommandFile = new System.Windows.Forms.TextBox();
			this.richScript = new System.Windows.Forms.RichTextBox();
			this.pScript = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.pCommandFile.SuspendLayout();
			this.pScript.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.pScript);
			this.tabPage1.Controls.Add(this.rbCommandFile);
			this.tabPage1.Controls.Add(this.rbCommandText);
			this.tabPage1.Controls.Add(this.pCommandFile);
			this.tabPage1.Controls.SetChildIndex(this.pCommandFile, 0);
			this.tabPage1.Controls.SetChildIndex(this.rbCommandText, 0);
			this.tabPage1.Controls.SetChildIndex(this.rbCommandFile, 0);
			this.tabPage1.Controls.SetChildIndex(this.eName, 0);
			this.tabPage1.Controls.SetChildIndex(this.pScript, 0);
			// 
			// rbCommandFile
			// 
			this.rbCommandFile.AutoSize = true;
			this.rbCommandFile.Location = new System.Drawing.Point(11, 32);
			this.rbCommandFile.Name = "rbCommandFile";
			this.rbCommandFile.Size = new System.Drawing.Size(54, 17);
			this.rbCommandFile.TabIndex = 2;
			this.rbCommandFile.TabStop = true;
			this.rbCommandFile.Text = "Файл";
			this.rbCommandFile.UseVisualStyleBackColor = true;
			this.rbCommandFile.CheckedChanged += new System.EventHandler(this.rbCommandFile_CheckedChanged);
			// 
			// rbCommandText
			// 
			this.rbCommandText.AutoSize = true;
			this.rbCommandText.Location = new System.Drawing.Point(136, 32);
			this.rbCommandText.Name = "rbCommandText";
			this.rbCommandText.Size = new System.Drawing.Size(70, 17);
			this.rbCommandText.TabIndex = 3;
			this.rbCommandText.TabStop = true;
			this.rbCommandText.Text = "Команда";
			this.rbCommandText.UseVisualStyleBackColor = true;
			this.rbCommandText.CheckedChanged += new System.EventHandler(this.rbCommandFile_CheckedChanged);
			// 
			// pCommandFile
			// 
			this.pCommandFile.Controls.Add(this.bChooseCommandFile);
			this.pCommandFile.Controls.Add(this.label2);
			this.pCommandFile.Controls.Add(this.eCommandFile);
			this.pCommandFile.Location = new System.Drawing.Point(3, 55);
			this.pCommandFile.Name = "pCommandFile";
			this.pCommandFile.Size = new System.Drawing.Size(423, 26);
			this.pCommandFile.TabIndex = 4;
			// 
			// bChooseCommandFile
			// 
			this.bChooseCommandFile.Location = new System.Drawing.Point(375, 1);
			this.bChooseCommandFile.Name = "bChooseCommandFile";
			this.bChooseCommandFile.Size = new System.Drawing.Size(24, 23);
			this.bChooseCommandFile.TabIndex = 2;
			this.bChooseCommandFile.Text = "...";
			this.bChooseCommandFile.UseVisualStyleBackColor = true;
			this.bChooseCommandFile.Click += new System.EventHandler(this.bChooseCommandFile_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Файл";
			// 
			// eCommandFile
			// 
			this.eCommandFile.Location = new System.Drawing.Point(53, 3);
			this.eCommandFile.Name = "eCommandFile";
			this.eCommandFile.Size = new System.Drawing.Size(323, 20);
			this.eCommandFile.TabIndex = 0;
			// 
			// richScript
			// 
			this.richScript.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.richScript.Location = new System.Drawing.Point(3, 18);
			this.richScript.Name = "richScript";
			this.richScript.Size = new System.Drawing.Size(420, 258);
			this.richScript.TabIndex = 5;
			this.richScript.Text = "";
			// 
			// pScript
			// 
			this.pScript.Controls.Add(this.label3);
			this.pScript.Controls.Add(this.richScript);
			this.pScript.Location = new System.Drawing.Point(3, 56);
			this.pScript.Name = "pScript";
			this.pScript.Size = new System.Drawing.Size(423, 279);
			this.pScript.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 2);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(81, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Текст скрипта";
			// 
			// CommandEditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(437, 405);
			this.Name = "CommandEditForm";
			this.Text = "Скрипт";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.pCommandFile.ResumeLayout(false);
			this.pCommandFile.PerformLayout();
			this.pScript.ResumeLayout(false);
			this.pScript.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RadioButton rbCommandFile;
		private System.Windows.Forms.RadioButton rbCommandText;
		private System.Windows.Forms.Panel pCommandFile;
		private System.Windows.Forms.Button bChooseCommandFile;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox eCommandFile;
		private System.Windows.Forms.Panel pScript;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.RichTextBox richScript;
	}
}