namespace EgidaBackup
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bManualStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bAddBackup = new System.Windows.Forms.ToolStripDropDownButton();
            this.mbCatalogReserv = new System.Windows.Forms.ToolStripMenuItem();
            this.mb1CReserv = new System.Windows.Forms.ToolStripMenuItem();
            this.mbRestore1C = new System.Windows.Forms.ToolStripMenuItem();
            this.mbScript = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mbQueve = new System.Windows.Forms.ToolStripMenuItem();
            this.bdelBackup = new System.Windows.Forms.ToolStripButton();
            this.bEditBackup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bOptions = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.mbCopyAllReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mbCopySmallReport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bUpdate = new System.Windows.Forms.ToolStripButton();
            this.bAbout = new System.Windows.Forms.ToolStripButton();
            this.bExit = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mbSaveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mbAutorun = new System.Windows.Forms.ToolStripMenuItem();
            this.mbExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tmAuto = new System.Windows.Forms.Timer(this.components);
            this.tmQueve = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmMessage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mbClearMessages = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cmCurrent = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mbClearCurrent = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.mbAllMessage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mbClearAllMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.cmBackup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mbZipBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.mbZipBackupTO = new System.Windows.Forms.ToolStripMenuItem();
            this.mbRunCommand = new System.Windows.Forms.ToolStripMenuItem();
            this.tmElapsed = new System.Windows.Forms.Timer(this.components);
            this.pWork = new System.Windows.Forms.Panel();
            this.lStatus = new System.Windows.Forms.Label();
            this.lElapsed = new System.Windows.Forms.Label();
            this.lActiveBackup = new System.Windows.Forms.Label();
            this.pbProcess = new System.Windows.Forms.ProgressBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tmIcon = new System.Windows.Forms.Timer(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.lbBackup = new EgidaBackup.BackupsListBox();
            this.lbLog = new EgidaBackup.LogListBox();
            this.lbCurrent = new EgidaBackup.LogListBox();
            this.lbAllMessage = new EgidaBackup.LogListBox();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.cmTray.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.cmMessage.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.cmCurrent.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.mbAllMessage.SuspendLayout();
            this.cmBackup.SuspendLayout();
            this.pWork.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbAllMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bManualStart,
            this.toolStripSeparator3,
            this.bAddBackup,
            this.bdelBackup,
            this.bEditBackup,
            this.toolStripSeparator1,
            this.bOptions,
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.bUpdate,
            this.bAbout,
            this.bExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 60);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(81, 553);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bManualStart
            // 
            this.bManualStart.Image = global::EgidaBackup.Properties.Resources.media_play_green;
            this.bManualStart.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bManualStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bManualStart.Name = "bManualStart";
            this.bManualStart.Size = new System.Drawing.Size(78, 51);
            this.bManualStart.Text = "Запуск";
            this.bManualStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bManualStart.ToolTipText = "Запуск резервирования помеченных заданий";
            this.bManualStart.Click += new System.EventHandler(this.bManualStart_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(78, 6);
            // 
            // bAddBackup
            // 
            this.bAddBackup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbCatalogReserv,
            this.mb1CReserv,
            this.mbRestore1C,
            this.mbScript,
            this.toolStripMenuItem2,
            this.mbQueve});
            this.bAddBackup.Image = global::EgidaBackup.Properties.Resources.data_add;
            this.bAddBackup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bAddBackup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bAddBackup.Name = "bAddBackup";
            this.bAddBackup.Size = new System.Drawing.Size(78, 51);
            this.bAddBackup.Text = "Добавить";
            this.bAddBackup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bAddBackup.ToolTipText = "Добавить задание";
            // 
            // mbCatalogReserv
            // 
            this.mbCatalogReserv.Name = "mbCatalogReserv";
            this.mbCatalogReserv.Size = new System.Drawing.Size(224, 22);
            this.mbCatalogReserv.Text = "Резервирование каталога...";
            this.mbCatalogReserv.Click += new System.EventHandler(this.bAddBackup_Click);
            // 
            // mb1CReserv
            // 
            this.mb1CReserv.Name = "mb1CReserv";
            this.mb1CReserv.Size = new System.Drawing.Size(224, 22);
            this.mb1CReserv.Text = "Резервирование базы 1С...";
            this.mb1CReserv.Click += new System.EventHandler(this.mb1CReserv_Click);
            // 
            // mbRestore1C
            // 
            this.mbRestore1C.Name = "mbRestore1C";
            this.mbRestore1C.Size = new System.Drawing.Size(224, 22);
            this.mbRestore1C.Text = "Восстановление базы 1С...";
            this.mbRestore1C.Click += new System.EventHandler(this.mbRestore1C_Click);
            // 
            // mbScript
            // 
            this.mbScript.Name = "mbScript";
            this.mbScript.Size = new System.Drawing.Size(224, 22);
            this.mbScript.Text = "Командный скрипт...";
            this.mbScript.Click += new System.EventHandler(this.mbScript_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(221, 6);
            // 
            // mbQueve
            // 
            this.mbQueve.Name = "mbQueve";
            this.mbQueve.Size = new System.Drawing.Size(224, 22);
            this.mbQueve.Text = "Очередь заданий...";
            this.mbQueve.Click += new System.EventHandler(this.mbQueve_Click);
            // 
            // bdelBackup
            // 
            this.bdelBackup.Image = global::EgidaBackup.Properties.Resources.data_delete;
            this.bdelBackup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bdelBackup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bdelBackup.Name = "bdelBackup";
            this.bdelBackup.Size = new System.Drawing.Size(78, 51);
            this.bdelBackup.Text = "Удалить";
            this.bdelBackup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bdelBackup.ToolTipText = "Удалить задание";
            this.bdelBackup.Click += new System.EventHandler(this.bdelBackup_Click);
            // 
            // bEditBackup
            // 
            this.bEditBackup.Image = global::EgidaBackup.Properties.Resources.data_edit;
            this.bEditBackup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bEditBackup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bEditBackup.Name = "bEditBackup";
            this.bEditBackup.Size = new System.Drawing.Size(78, 51);
            this.bEditBackup.Text = "Изменить";
            this.bEditBackup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bEditBackup.ToolTipText = "Изменить задание";
            this.bEditBackup.Click += new System.EventHandler(this.bEditBackup_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(78, 6);
            // 
            // bOptions
            // 
            this.bOptions.Image = global::EgidaBackup.Properties.Resources.gear;
            this.bOptions.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bOptions.Name = "bOptions";
            this.bOptions.Size = new System.Drawing.Size(78, 51);
            this.bOptions.Text = "Настройки";
            this.bOptions.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bOptions.ToolTipText = "Вызов окна настроек";
            this.bOptions.Click += new System.EventHandler(this.bOptions_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbCopyAllReport,
            this.mbCopySmallReport});
            this.toolStripButton1.Image = global::EgidaBackup.Properties.Resources.document_text;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(78, 51);
            this.toolStripButton1.Text = "Отчеты";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // mbCopyAllReport
            // 
            this.mbCopyAllReport.Name = "mbCopyAllReport";
            this.mbCopyAllReport.Size = new System.Drawing.Size(285, 22);
            this.mbCopyAllReport.Text = "Отчет о резервировании (подробный)";
            this.mbCopyAllReport.Click += new System.EventHandler(this.mbCopyAllReport_Click);
            // 
            // mbCopySmallReport
            // 
            this.mbCopySmallReport.Name = "mbCopySmallReport";
            this.mbCopySmallReport.Size = new System.Drawing.Size(285, 22);
            this.mbCopySmallReport.Text = "Отчет о резервировании (краткий)";
            this.mbCopySmallReport.Click += new System.EventHandler(this.mbCopySmallReport_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(78, 6);
            // 
            // bUpdate
            // 
            this.bUpdate.Image = global::EgidaBackup.Properties.Resources.download;
            this.bUpdate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(78, 51);
            this.bUpdate.Text = "Обновление";
            this.bUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bUpdate.ToolTipText = "Обновление программы";
            this.bUpdate.Click += new System.EventHandler(this.bUpdate_Click);
            // 
            // bAbout
            // 
            this.bAbout.Image = global::EgidaBackup.Properties.Resources.help2;
            this.bAbout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bAbout.Name = "bAbout";
            this.bAbout.Size = new System.Drawing.Size(78, 51);
            this.bAbout.Text = "Справка";
            this.bAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bAbout.Click += new System.EventHandler(this.bAbout_Click);
            // 
            // bExit
            // 
            this.bExit.Image = global::EgidaBackup.Properties.Resources.door;
            this.bExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(78, 51);
            this.bExit.Text = "Выход";
            this.bExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bExit.ToolTipText = "Выход из программы";
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(741, 60);
            this.panel1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(652, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Версия 1.3.60";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            this.label4.MouseLeave += new System.EventHandler(this.label3_MouseLeave);
            this.label4.MouseHover += new System.EventHandler(this.label3_MouseHover);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(573, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Посетите сайт www.egida1c.ru";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            this.label3.MouseLeave += new System.EventHandler(this.label3_MouseLeave);
            this.label3.MouseHover += new System.EventHandler(this.label3_MouseHover);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::EgidaBackup.Properties.Resources.box_preferences;
            this.pictureBox1.Location = new System.Drawing.Point(7, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 53);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pbLogo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(59, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Egida Backup";
            this.label1.Click += new System.EventHandler(this.pbLogo_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipTitle = "Egida Backup";
            this.notifyIcon1.ContextMenuStrip = this.cmTray;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Egida Backup";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // cmTray
            // 
            this.cmTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbSaveAll,
            this.toolStripMenuItem1,
            this.mbAutorun,
            this.mbExit});
            this.cmTray.Name = "contextMenuStrip1";
            this.cmTray.Size = new System.Drawing.Size(244, 76);
            // 
            // mbSaveAll
            // 
            this.mbSaveAll.Name = "mbSaveAll";
            this.mbSaveAll.Size = new System.Drawing.Size(243, 22);
            this.mbSaveAll.Text = "Запуск архивации";
            this.mbSaveAll.Click += new System.EventHandler(this.mbSaveAll_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(240, 6);
            // 
            // mbAutorun
            // 
            this.mbAutorun.Name = "mbAutorun";
            this.mbAutorun.Size = new System.Drawing.Size(243, 22);
            this.mbAutorun.Text = "Запускать при старте Windows";
            this.mbAutorun.Click += new System.EventHandler(this.mbAutorun_Click);
            // 
            // mbExit
            // 
            this.mbExit.Name = "mbExit";
            this.mbExit.Size = new System.Drawing.Size(243, 22);
            this.mbExit.Text = "Выход";
            this.mbExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // tmAuto
            // 
            this.tmAuto.Enabled = true;
            this.tmAuto.Interval = 15000;
            this.tmAuto.Tick += new System.EventHandler(this.tmAuto_Tick);
            // 
            // tmQueve
            // 
            this.tmQueve.Enabled = true;
            this.tmQueve.Interval = 3000;
            this.tmQueve.Tick += new System.EventHandler(this.tmQueve_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(81, 376);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(660, 165);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbLog);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(652, 139);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Сообщения";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmMessage
            // 
            this.cmMessage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbClearMessages});
            this.cmMessage.Name = "cmMessage";
            this.cmMessage.Size = new System.Drawing.Size(127, 26);
            // 
            // mbClearMessages
            // 
            this.mbClearMessages.Name = "mbClearMessages";
            this.mbClearMessages.Size = new System.Drawing.Size(126, 22);
            this.mbClearMessages.Text = "Очистить";
            this.mbClearMessages.Click += new System.EventHandler(this.mbClearMessages_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lbCurrent);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(652, 139);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Текущий";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cmCurrent
            // 
            this.cmCurrent.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbClearCurrent});
            this.cmCurrent.Name = "cmCurrent";
            this.cmCurrent.Size = new System.Drawing.Size(127, 26);
            // 
            // mbClearCurrent
            // 
            this.mbClearCurrent.Name = "mbClearCurrent";
            this.mbClearCurrent.Size = new System.Drawing.Size(126, 22);
            this.mbClearCurrent.Text = "Очистить";
            this.mbClearCurrent.Click += new System.EventHandler(this.mbClearCurrent_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbAllMessage);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(652, 139);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Все";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // mbAllMessage
            // 
            this.mbAllMessage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbClearAllMessage});
            this.mbAllMessage.Name = "mbAllMessage";
            this.mbAllMessage.Size = new System.Drawing.Size(127, 26);
            // 
            // mbClearAllMessage
            // 
            this.mbClearAllMessage.Name = "mbClearAllMessage";
            this.mbClearAllMessage.Size = new System.Drawing.Size(126, 22);
            this.mbClearAllMessage.Text = "Очистить";
            this.mbClearAllMessage.Click += new System.EventHandler(this.mbClearAllMessage_Click);
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(81, 373);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(660, 3);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // cmBackup
            // 
            this.cmBackup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изменитьToolStripMenuItem,
            this.удалитьToolStripMenuItem,
            this.mbZipBackup,
            this.mbZipBackupTO,
            this.mbRunCommand});
            this.cmBackup.Name = "cmBackup";
            this.cmBackup.Size = new System.Drawing.Size(170, 114);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.bEditBackup_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.bdelBackup_Click);
            // 
            // mbZipBackup
            // 
            this.mbZipBackup.Name = "mbZipBackup";
            this.mbZipBackup.Size = new System.Drawing.Size(169, 22);
            this.mbZipBackup.Text = "Архивировать";
            this.mbZipBackup.Click += new System.EventHandler(this.архивироватьToolStripMenuItem_Click);
            // 
            // mbZipBackupTO
            // 
            this.mbZipBackupTO.Name = "mbZipBackupTO";
            this.mbZipBackupTO.Size = new System.Drawing.Size(169, 22);
            this.mbZipBackupTO.Text = "Архивировать в...";
            this.mbZipBackupTO.Click += new System.EventHandler(this.mbZipBackupTO_Click);
            // 
            // mbRunCommand
            // 
            this.mbRunCommand.Name = "mbRunCommand";
            this.mbRunCommand.Size = new System.Drawing.Size(169, 22);
            this.mbRunCommand.Text = "Запустить";
            this.mbRunCommand.Click += new System.EventHandler(this.архивироватьToolStripMenuItem_Click);
            // 
            // tmElapsed
            // 
            this.tmElapsed.Interval = 1000;
            this.tmElapsed.Tick += new System.EventHandler(this.tmElapsed_Tick);
            // 
            // pWork
            // 
            this.pWork.Controls.Add(this.lStatus);
            this.pWork.Controls.Add(this.lElapsed);
            this.pWork.Controls.Add(this.lActiveBackup);
            this.pWork.Controls.Add(this.pbProcess);
            this.pWork.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pWork.Location = new System.Drawing.Point(81, 541);
            this.pWork.Name = "pWork";
            this.pWork.Size = new System.Drawing.Size(660, 72);
            this.pWork.TabIndex = 9;
            this.pWork.Visible = false;
            // 
            // lStatus
            // 
            this.lStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lStatus.Location = new System.Drawing.Point(4, 45);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(652, 23);
            this.lStatus.TabIndex = 3;
            // 
            // lElapsed
            // 
            this.lElapsed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lElapsed.Location = new System.Drawing.Point(554, 3);
            this.lElapsed.Name = "lElapsed";
            this.lElapsed.Size = new System.Drawing.Size(103, 13);
            this.lElapsed.TabIndex = 2;
            this.lElapsed.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lActiveBackup
            // 
            this.lActiveBackup.AutoSize = true;
            this.lActiveBackup.Location = new System.Drawing.Point(4, 3);
            this.lActiveBackup.Name = "lActiveBackup";
            this.lActiveBackup.Size = new System.Drawing.Size(114, 13);
            this.lActiveBackup.TabIndex = 1;
            this.lActiveBackup.Text = "Нет активной задачи";
            // 
            // pbProcess
            // 
            this.pbProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbProcess.Location = new System.Drawing.Point(7, 19);
            this.pbProcess.MarqueeAnimationSpeed = 50;
            this.pbProcess.Name = "pbProcess";
            this.pbProcess.Size = new System.Drawing.Size(649, 23);
            this.pbProcess.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 613);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(741, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tmIcon
            // 
            this.tmIcon.Interval = 500;
            this.tmIcon.Tick += new System.EventHandler(this.tmIcon_Tick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 237;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 237;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 30;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Width = 30;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn3.HeaderText = "";
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.Width = 30;
            // 
            // lbBackup
            // 
            this.lbBackup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbBackup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lbBackup.FormattingEnabled = true;
            this.lbBackup.ItemHeight = 100;
            this.lbBackup.Location = new System.Drawing.Point(81, 60);
            this.lbBackup.Name = "lbBackup";
            this.lbBackup.Queve = null;
            this.lbBackup.ScrollAlwaysVisible = true;
            this.lbBackup.Size = new System.Drawing.Size(660, 316);
            this.lbBackup.TabIndex = 11;
            this.lbBackup.SelectedIndexChanged += new System.EventHandler(this.lbBackup_SelectedIndexChanged);
            this.lbBackup.DoubleClick += new System.EventHandler(this.bEditBackup_Click);
            this.lbBackup.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbBackup_MouseUp);
            // 
            // lbLog
            // 
            this.lbLog.AllowUserToAddRows = false;
            this.lbLog.AllowUserToDeleteRows = false;
            this.lbLog.AllowUserToResizeRows = false;
            this.lbLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.lbLog.BackgroundColor = System.Drawing.SystemColors.Window;
            this.lbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbLog.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.lbLog.ColumnHeadersHeight = 18;
            this.lbLog.ContextMenuStrip = this.cmMessage;
            this.lbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLog.Location = new System.Drawing.Point(3, 3);
            this.lbLog.Name = "lbLog";
            this.lbLog.ReadOnly = true;
            this.lbLog.RowHeadersVisible = false;
            this.lbLog.Size = new System.Drawing.Size(646, 133);
            this.lbLog.TabIndex = 6;
            // 
            // lbCurrent
            // 
            this.lbCurrent.AllowUserToAddRows = false;
            this.lbCurrent.AllowUserToDeleteRows = false;
            this.lbCurrent.AllowUserToResizeRows = false;
            this.lbCurrent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.lbCurrent.BackgroundColor = System.Drawing.SystemColors.Window;
            this.lbCurrent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbCurrent.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.lbCurrent.ColumnHeadersHeight = 18;
            this.lbCurrent.ContextMenuStrip = this.cmCurrent;
            this.lbCurrent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCurrent.Location = new System.Drawing.Point(3, 3);
            this.lbCurrent.Name = "lbCurrent";
            this.lbCurrent.ReadOnly = true;
            this.lbCurrent.RowHeadersVisible = false;
            this.lbCurrent.Size = new System.Drawing.Size(646, 133);
            this.lbCurrent.TabIndex = 0;
            // 
            // lbAllMessage
            // 
            this.lbAllMessage.AllowUserToAddRows = false;
            this.lbAllMessage.AllowUserToDeleteRows = false;
            this.lbAllMessage.AllowUserToResizeRows = false;
            this.lbAllMessage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.lbAllMessage.BackgroundColor = System.Drawing.SystemColors.Window;
            this.lbAllMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbAllMessage.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.lbAllMessage.ColumnHeadersHeight = 18;
            this.lbAllMessage.ContextMenuStrip = this.mbAllMessage;
            this.lbAllMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAllMessage.Location = new System.Drawing.Point(3, 3);
            this.lbAllMessage.Name = "lbAllMessage";
            this.lbAllMessage.ReadOnly = true;
            this.lbAllMessage.RowHeadersVisible = false;
            this.lbAllMessage.Size = new System.Drawing.Size(646, 133);
            this.lbAllMessage.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 635);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.lbBackup);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pWork);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(650, 490);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Egida Backup";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.cmTray.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.cmMessage.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.cmCurrent.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.mbAllMessage.ResumeLayout(false);
            this.cmBackup.ResumeLayout(false);
            this.pWork.ResumeLayout(false);
            this.pWork.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbAllMessage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bdelBackup;
        private System.Windows.Forms.ToolStripButton bEditBackup;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton bExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.Timer tmAuto;
		private System.Windows.Forms.Timer tmQueve;
		private System.Windows.Forms.ToolStripButton bManualStart;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private LogListBox lbLog;
		private System.Windows.Forms.TabPage tabPage2;
		private LogListBox lbAllMessage;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.ContextMenuStrip cmTray;
		private System.Windows.Forms.ToolStripMenuItem mbSaveAll;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem mbExit;
		private System.Windows.Forms.ContextMenuStrip cmMessage;
		private System.Windows.Forms.ToolStripMenuItem mbClearMessages;
		private System.Windows.Forms.ContextMenuStrip mbAllMessage;
		private System.Windows.Forms.ToolStripMenuItem mbClearAllMessage;
		private System.Windows.Forms.ContextMenuStrip cmBackup;
		private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mbZipBackup;
		private System.Windows.Forms.ToolStripMenuItem mbZipBackupTO;
		private System.Windows.Forms.ToolStripDropDownButton bAddBackup;
		private System.Windows.Forms.ToolStripMenuItem mbCatalogReserv;
		private System.Windows.Forms.ToolStripMenuItem mb1CReserv;
		private System.Windows.Forms.Timer tmElapsed;
		private System.Windows.Forms.TabPage tabPage3;
		private LogListBox lbCurrent;
		private System.Windows.Forms.ContextMenuStrip cmCurrent;
		private System.Windows.Forms.ToolStripMenuItem mbClearCurrent;
		private System.Windows.Forms.ToolStripButton bAbout;
		private System.Windows.Forms.ToolStripButton bUpdate;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ToolStripMenuItem mbAutorun;
		private System.Windows.Forms.Panel pWork;
		private System.Windows.Forms.Label lElapsed;
		private System.Windows.Forms.Label lActiveBackup;
		private System.Windows.Forms.ProgressBar pbProcess;
		private System.Windows.Forms.Label lStatus;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.Label label4;
		private BackupsListBox lbBackup;
		private System.Windows.Forms.Timer tmIcon;
		private System.Windows.Forms.ToolStripMenuItem mbScript;
		private System.Windows.Forms.ToolStripMenuItem mbRunCommand;
		private System.Windows.Forms.ToolStripMenuItem mbRestore1C;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem mbQueve;
        private System.Windows.Forms.ToolStripButton bOptions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem mbCopyAllReport;
        private System.Windows.Forms.ToolStripMenuItem mbCopySmallReport;

    }
}

