namespace EgidaBackup
{
    partial class CatalogBackupEditForm
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
            this.ePath = new System.Windows.Forms.TextBox();
            this.bChoosePath = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.chbOnlyChanged = new System.Windows.Forms.CheckBox();
            this.label24 = new System.Windows.Forms.Label();
            this.eFileMask = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.chbIncrement = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbCompress = new System.Windows.Forms.ComboBox();
            this.chbArchive = new System.Windows.Forms.CheckBox();
            this.chbUsePassword = new System.Windows.Forms.CheckBox();
            this.eZipPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.eDepositorySize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eCountSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSaveTime)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.eZipPassword);
            this.tabPage3.Controls.Add(this.chbUsePassword);
            this.tabPage3.Controls.Add(this.chbOnlyChanged);
            this.tabPage3.Controls.Add(this.label24);
            this.tabPage3.Controls.Add(this.eFileMask);
            this.tabPage3.Controls.Add(this.label21);
            this.tabPage3.Controls.Add(this.chbIncrement);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.cbCompress);
            this.tabPage3.Controls.Add(this.chbArchive);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Size = new System.Drawing.Size(429, 341);
            this.tabPage3.Controls.SetChildIndex(this.eSaveTime, 0);
            this.tabPage3.Controls.SetChildIndex(this.eCountSave, 0);
            this.tabPage3.Controls.SetChildIndex(this.eDepositorySize, 0);
            this.tabPage3.Controls.SetChildIndex(this.chbArchive, 0);
            this.tabPage3.Controls.SetChildIndex(this.cbCompress, 0);
            this.tabPage3.Controls.SetChildIndex(this.label6, 0);
            this.tabPage3.Controls.SetChildIndex(this.chbIncrement, 0);
            this.tabPage3.Controls.SetChildIndex(this.label21, 0);
            this.tabPage3.Controls.SetChildIndex(this.eFileMask, 0);
            this.tabPage3.Controls.SetChildIndex(this.label24, 0);
            this.tabPage3.Controls.SetChildIndex(this.chbOnlyChanged, 0);
            this.tabPage3.Controls.SetChildIndex(this.chbUsePassword, 0);
            this.tabPage3.Controls.SetChildIndex(this.eZipPassword, 0);
            this.tabPage3.Controls.SetChildIndex(this.label7, 0);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ePath);
            this.tabPage1.Controls.Add(this.bChoosePath);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Size = new System.Drawing.Size(429, 341);
            this.tabPage1.Controls.SetChildIndex(this.eName, 0);
            this.tabPage1.Controls.SetChildIndex(this.label2, 0);
            this.tabPage1.Controls.SetChildIndex(this.bChoosePath, 0);
            this.tabPage1.Controls.SetChildIndex(this.ePath, 0);
            // 
            // ePath
            // 
            this.ePath.Location = new System.Drawing.Point(71, 32);
            this.ePath.Name = "ePath";
            this.ePath.Size = new System.Drawing.Size(288, 20);
            this.ePath.TabIndex = 18;
            // 
            // bChoosePath
            // 
            this.bChoosePath.Location = new System.Drawing.Point(358, 32);
            this.bChoosePath.Name = "bChoosePath";
            this.bChoosePath.Size = new System.Drawing.Size(21, 20);
            this.bChoosePath.TabIndex = 19;
            this.bChoosePath.Text = "...";
            this.bChoosePath.UseVisualStyleBackColor = true;
            this.bChoosePath.Click += new System.EventHandler(this.bChoosePath_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Путь";
            // 
            // chbOnlyChanged
            // 
            this.chbOnlyChanged.AutoSize = true;
            this.chbOnlyChanged.Location = new System.Drawing.Point(11, 224);
            this.chbOnlyChanged.Name = "chbOnlyChanged";
            this.chbOnlyChanged.Size = new System.Drawing.Size(258, 17);
            this.chbOnlyChanged.TabIndex = 58;
            this.chbOnlyChanged.Text = "Резервировать только изменившиеся файлы";
            this.chbOnlyChanged.UseVisualStyleBackColor = true;
            this.chbOnlyChanged.CheckedChanged += new System.EventHandler(this.chbArchive_CheckedChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label24.Location = new System.Drawing.Point(96, 277);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(291, 12);
            this.label24.TabIndex = 57;
            this.label24.Text = "Маски файлов задаются через точку с запятой (по умолчанию *.*)";
            // 
            // eFileMask
            // 
            this.eFileMask.Location = new System.Drawing.Point(98, 254);
            this.eFileMask.Name = "eFileMask";
            this.eFileMask.Size = new System.Drawing.Size(186, 20);
            this.eFileMask.TabIndex = 56;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(11, 257);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(81, 13);
            this.label21.TabIndex = 55;
            this.label21.Text = "Маска файлов";
            // 
            // chbIncrement
            // 
            this.chbIncrement.AutoSize = true;
            this.chbIncrement.Location = new System.Drawing.Point(11, 201);
            this.chbIncrement.Name = "chbIncrement";
            this.chbIncrement.Size = new System.Drawing.Size(170, 17);
            this.chbIncrement.TabIndex = 54;
            this.chbIncrement.Text = "Инкрементное копирования";
            this.chbIncrement.UseVisualStyleBackColor = true;
            this.chbIncrement.CheckedChanged += new System.EventHandler(this.chbArchive_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 53;
            this.label6.Text = "Уровень сжатия";
            // 
            // cbCompress
            // 
            this.cbCompress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompress.FormattingEnabled = true;
            this.cbCompress.Items.AddRange(new object[] {
            "Без сжатия",
            "Скоростной",
            "Быстрый",
            "Обычный",
            "Хороший",
            "Максимальный"});
            this.cbCompress.Location = new System.Drawing.Point(129, 122);
            this.cbCompress.Name = "cbCompress";
            this.cbCompress.Size = new System.Drawing.Size(152, 21);
            this.cbCompress.TabIndex = 52;
            // 
            // chbArchive
            // 
            this.chbArchive.AutoSize = true;
            this.chbArchive.Location = new System.Drawing.Point(11, 99);
            this.chbArchive.Name = "chbArchive";
            this.chbArchive.Size = new System.Drawing.Size(97, 17);
            this.chbArchive.TabIndex = 51;
            this.chbArchive.Text = "Архивировать";
            this.chbArchive.UseVisualStyleBackColor = true;
            this.chbArchive.CheckedChanged += new System.EventHandler(this.chbArchive_CheckedChanged);
            // 
            // chbUsePassword
            // 
            this.chbUsePassword.AutoSize = true;
            this.chbUsePassword.Location = new System.Drawing.Point(11, 152);
            this.chbUsePassword.Name = "chbUsePassword";
            this.chbUsePassword.Size = new System.Drawing.Size(112, 17);
            this.chbUsePassword.TabIndex = 59;
            this.chbUsePassword.Text = "Защита паролем";
            this.chbUsePassword.UseVisualStyleBackColor = true;
            this.chbUsePassword.CheckedChanged += new System.EventHandler(this.chbArchive_CheckedChanged);
            // 
            // eZipPassword
            // 
            this.eZipPassword.Location = new System.Drawing.Point(129, 175);
            this.eZipPassword.Name = "eZipPassword";
            this.eZipPassword.Size = new System.Drawing.Size(152, 20);
            this.eZipPassword.TabIndex = 60;
            this.eZipPassword.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 61;
            this.label7.Text = "Пароль";
            // 
            // CatalogBackupEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 405);
            this.Name = "CatalogBackupEditForm";
            this.Text = "Резервирование каталога";
            ((System.ComponentModel.ISupportInitialize)(this.eDepositorySize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eCountSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSaveTime)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox ePath;
        private System.Windows.Forms.Button bChoosePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbOnlyChanged;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox eFileMask;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox chbIncrement;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbCompress;
        private System.Windows.Forms.CheckBox chbArchive;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox eZipPassword;
        private System.Windows.Forms.CheckBox chbUsePassword;
    }
}