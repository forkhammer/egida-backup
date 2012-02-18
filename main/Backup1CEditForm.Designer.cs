namespace EgidaBackup
{
    partial class Backup1CEditForm
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
            this.p1CTask = new System.Windows.Forms.Panel();
            this.pFileMode = new System.Windows.Forms.Panel();
            this.bChooseCatalogBase = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.eCatalogBase = new System.Windows.Forms.TextBox();
            this.chbKillUsers = new System.Windows.Forms.CheckBox();
            this.chbDisconnectUsers = new System.Windows.Forms.CheckBox();
            this.cbVersion1C = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.bChooseCommandFile = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.eCommandFile = new System.Windows.Forms.TextBox();
            this.ePass1C = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.eUser1C = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.pServerMode = new System.Windows.Forms.Panel();
            this.e1CBase = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.eServer1C = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rbServerMode = new System.Windows.Forms.RadioButton();
            this.rbFileMode = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.eDepositorySize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eCountSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSaveTime)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.p1CTask.SuspendLayout();
            this.pFileMode.SuspendLayout();
            this.pServerMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Size = new System.Drawing.Size(429, 340);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.p1CTask);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Size = new System.Drawing.Size(429, 340);
            this.tabPage1.Controls.SetChildIndex(this.eName, 0);
            this.tabPage1.Controls.SetChildIndex(this.p1CTask, 0);
            // 
            // p1CTask
            // 
            this.p1CTask.Controls.Add(this.pFileMode);
            this.p1CTask.Controls.Add(this.chbKillUsers);
            this.p1CTask.Controls.Add(this.chbDisconnectUsers);
            this.p1CTask.Controls.Add(this.cbVersion1C);
            this.p1CTask.Controls.Add(this.label18);
            this.p1CTask.Controls.Add(this.bChooseCommandFile);
            this.p1CTask.Controls.Add(this.label17);
            this.p1CTask.Controls.Add(this.eCommandFile);
            this.p1CTask.Controls.Add(this.ePass1C);
            this.p1CTask.Controls.Add(this.label15);
            this.p1CTask.Controls.Add(this.eUser1C);
            this.p1CTask.Controls.Add(this.label14);
            this.p1CTask.Controls.Add(this.pServerMode);
            this.p1CTask.Controls.Add(this.rbServerMode);
            this.p1CTask.Controls.Add(this.rbFileMode);
            this.p1CTask.Location = new System.Drawing.Point(6, 32);
            this.p1CTask.Name = "p1CTask";
            this.p1CTask.Size = new System.Drawing.Size(420, 193);
            this.p1CTask.TabIndex = 11;
            // 
            // pFileMode
            // 
            this.pFileMode.Controls.Add(this.bChooseCatalogBase);
            this.pFileMode.Controls.Add(this.label7);
            this.pFileMode.Controls.Add(this.eCatalogBase);
            this.pFileMode.Location = new System.Drawing.Point(1, 55);
            this.pFileMode.Name = "pFileMode";
            this.pFileMode.Size = new System.Drawing.Size(406, 27);
            this.pFileMode.TabIndex = 2;
            // 
            // bChooseCatalogBase
            // 
            this.bChooseCatalogBase.Location = new System.Drawing.Point(352, 0);
            this.bChooseCatalogBase.Name = "bChooseCatalogBase";
            this.bChooseCatalogBase.Size = new System.Drawing.Size(21, 21);
            this.bChooseCatalogBase.TabIndex = 5;
            this.bChooseCatalogBase.Text = "...";
            this.bChooseCatalogBase.UseVisualStyleBackColor = true;
            this.bChooseCatalogBase.Click += new System.EventHandler(this.bChooseCatalogBase_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(-1, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Каталог";
            // 
            // eCatalogBase
            // 
            this.eCatalogBase.Location = new System.Drawing.Point(64, 0);
            this.eCatalogBase.Name = "eCatalogBase";
            this.eCatalogBase.Size = new System.Drawing.Size(288, 20);
            this.eCatalogBase.TabIndex = 4;
            // 
            // chbKillUsers
            // 
            this.chbKillUsers.AutoSize = true;
            this.chbKillUsers.Location = new System.Drawing.Point(270, 137);
            this.chbKillUsers.Name = "chbKillUsers";
            this.chbKillUsers.Size = new System.Drawing.Size(104, 17);
            this.chbKillUsers.TabIndex = 14;
            this.chbKillUsers.Text = "Принудительно";
            this.chbKillUsers.UseVisualStyleBackColor = true;
            // 
            // chbDisconnectUsers
            // 
            this.chbDisconnectUsers.AutoSize = true;
            this.chbDisconnectUsers.Location = new System.Drawing.Point(246, 114);
            this.chbDisconnectUsers.Name = "chbDisconnectUsers";
            this.chbDisconnectUsers.Size = new System.Drawing.Size(161, 17);
            this.chbDisconnectUsers.TabIndex = 13;
            this.chbDisconnectUsers.Text = "Отключать пользователей";
            this.chbDisconnectUsers.UseVisualStyleBackColor = true;
            this.chbDisconnectUsers.CheckedChanged += new System.EventHandler(this.rbFileMode_CheckedChanged);
            // 
            // cbVersion1C
            // 
            this.cbVersion1C.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVersion1C.FormattingEnabled = true;
            this.cbVersion1C.Items.AddRange(new object[] {
            "7.7",
            "8.0",
            "8.1",
            "8.2"});
            this.cbVersion1C.Location = new System.Drawing.Point(87, 165);
            this.cbVersion1C.Name = "cbVersion1C";
            this.cbVersion1C.Size = new System.Drawing.Size(84, 21);
            this.cbVersion1C.TabIndex = 12;
            this.cbVersion1C.SelectedIndexChanged += new System.EventHandler(this.rbFileMode_CheckedChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 168);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(44, 13);
            this.label18.TabIndex = 11;
            this.label18.Text = "Версия";
            // 
            // bChooseCommandFile
            // 
            this.bChooseCommandFile.Location = new System.Drawing.Point(353, 0);
            this.bChooseCommandFile.Name = "bChooseCommandFile";
            this.bChooseCommandFile.Size = new System.Drawing.Size(21, 21);
            this.bChooseCommandFile.TabIndex = 10;
            this.bChooseCommandFile.Text = "...";
            this.bChooseCommandFile.UseVisualStyleBackColor = true;
            this.bChooseCommandFile.Click += new System.EventHandler(this.bChooseCommandFile_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(0, 3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(152, 13);
            this.label17.TabIndex = 8;
            this.label17.Text = "Путь к исполняемому файлу";
            // 
            // eCommandFile
            // 
            this.eCommandFile.Location = new System.Drawing.Point(158, 0);
            this.eCommandFile.Name = "eCommandFile";
            this.eCommandFile.Size = new System.Drawing.Size(195, 20);
            this.eCommandFile.TabIndex = 9;
            // 
            // ePass1C
            // 
            this.ePass1C.Location = new System.Drawing.Point(87, 139);
            this.ePass1C.Name = "ePass1C";
            this.ePass1C.PasswordChar = '*';
            this.ePass1C.Size = new System.Drawing.Size(144, 20);
            this.ePass1C.TabIndex = 7;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 142);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(45, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Пароль";
            // 
            // eUser1C
            // 
            this.eUser1C.Location = new System.Drawing.Point(87, 112);
            this.eUser1C.Name = "eUser1C";
            this.eUser1C.Size = new System.Drawing.Size(144, 20);
            this.eUser1C.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1, 115);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Пользователь";
            // 
            // pServerMode
            // 
            this.pServerMode.Controls.Add(this.e1CBase);
            this.pServerMode.Controls.Add(this.label13);
            this.pServerMode.Controls.Add(this.eServer1C);
            this.pServerMode.Controls.Add(this.label9);
            this.pServerMode.Location = new System.Drawing.Point(0, 55);
            this.pServerMode.Name = "pServerMode";
            this.pServerMode.Size = new System.Drawing.Size(410, 57);
            this.pServerMode.TabIndex = 3;
            // 
            // e1CBase
            // 
            this.e1CBase.Location = new System.Drawing.Point(64, 29);
            this.e1CBase.Name = "e1CBase";
            this.e1CBase.Size = new System.Drawing.Size(288, 20);
            this.e1CBase.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Имя базы";
            // 
            // eServer1C
            // 
            this.eServer1C.Location = new System.Drawing.Point(64, 3);
            this.eServer1C.Name = "eServer1C";
            this.eServer1C.Size = new System.Drawing.Size(288, 20);
            this.eServer1C.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Сервер 1С";
            // 
            // rbServerMode
            // 
            this.rbServerMode.AutoSize = true;
            this.rbServerMode.Location = new System.Drawing.Point(127, 32);
            this.rbServerMode.Name = "rbServerMode";
            this.rbServerMode.Size = new System.Drawing.Size(157, 17);
            this.rbServerMode.TabIndex = 1;
            this.rbServerMode.TabStop = true;
            this.rbServerMode.Text = "Клиент-серверный режим";
            this.rbServerMode.UseVisualStyleBackColor = true;
            this.rbServerMode.CheckedChanged += new System.EventHandler(this.rbFileMode_CheckedChanged);
            // 
            // rbFileMode
            // 
            this.rbFileMode.AutoSize = true;
            this.rbFileMode.Location = new System.Drawing.Point(4, 32);
            this.rbFileMode.Name = "rbFileMode";
            this.rbFileMode.Size = new System.Drawing.Size(117, 17);
            this.rbFileMode.TabIndex = 0;
            this.rbFileMode.TabStop = true;
            this.rbFileMode.Text = "Файловый режим";
            this.rbFileMode.UseVisualStyleBackColor = true;
            this.rbFileMode.CheckedChanged += new System.EventHandler(this.rbFileMode_CheckedChanged);
            // 
            // Backup1CEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 405);
            this.Name = "Backup1CEditForm";
            this.Text = "Резервирование информационной базы 1С";
            ((System.ComponentModel.ISupportInitialize)(this.eDepositorySize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eCountSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSaveTime)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.p1CTask.ResumeLayout(false);
            this.p1CTask.PerformLayout();
            this.pFileMode.ResumeLayout(false);
            this.pFileMode.PerformLayout();
            this.pServerMode.ResumeLayout(false);
            this.pServerMode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p1CTask;
        private System.Windows.Forms.Panel pFileMode;
        private System.Windows.Forms.Button bChooseCatalogBase;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox eCatalogBase;
        private System.Windows.Forms.CheckBox chbKillUsers;
        private System.Windows.Forms.CheckBox chbDisconnectUsers;
        private System.Windows.Forms.ComboBox cbVersion1C;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button bChooseCommandFile;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox eCommandFile;
        private System.Windows.Forms.TextBox ePass1C;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox eUser1C;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel pServerMode;
        private System.Windows.Forms.TextBox e1CBase;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox eServer1C;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rbServerMode;
        private System.Windows.Forms.RadioButton rbFileMode;
    }
}