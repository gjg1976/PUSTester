
namespace PUS_tester
{
    partial class FormMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.treeViewTlcmd = new System.Windows.Forms.TreeView();
            this.buttonSendTC = new System.Windows.Forms.Button();
            this.groupBoxTelecommand = new System.Windows.Forms.GroupBox();
            this.numericUpDownSeq = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDelTC = new System.Windows.Forms.Button();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.buttonSaveTC = new System.Windows.Forms.Button();
            this.buttonEditTC = new System.Windows.Forms.Button();
            this.groupBoxAck = new System.Windows.Forms.GroupBox();
            this.checkBoxAckAcc = new System.Windows.Forms.CheckBox();
            this.checkBoxAckProg = new System.Windows.Forms.CheckBox();
            this.checkBoxAckComp = new System.Windows.Forms.CheckBox();
            this.checkBoxAckExec = new System.Windows.Forms.CheckBox();
            this.groupBoxPayloadTx = new System.Windows.Forms.GroupBox();
            this.textBoxPayloadTx = new System.Windows.Forms.TextBox();
            this.labelSizeTx = new System.Windows.Forms.Label();
            this.textBoxSizeTx = new System.Windows.Forms.TextBox();
            this.labelCRC = new System.Windows.Forms.Label();
            this.labelServiceSubTypeTx = new System.Windows.Forms.Label();
            this.textBoxServiceSubTypeTx = new System.Windows.Forms.TextBox();
            this.labelServiceTypeTx = new System.Windows.Forms.Label();
            this.textBoxServiceTypeTx = new System.Windows.Forms.TextBox();
            this.groupBoxSend = new System.Windows.Forms.GroupBox();
            this.labelSend = new System.Windows.Forms.Label();
            this.textBoxSend = new System.Windows.Forms.TextBox();
            this.buttonCloseUart = new System.Windows.Forms.Button();
            this.buttonOpenUart = new System.Windows.Forms.Button();
            this.groupBoxSerialPort = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.labelRS422 = new System.Windows.Forms.Label();
            this.comboBoxRS422bps = new System.Windows.Forms.ComboBox();
            this.labelTitleRS422 = new System.Windows.Forms.Label();
            this.comboBoxRS422 = new System.Windows.Forms.ComboBox();
            this.groupBoxReceive = new System.Windows.Forms.GroupBox();
            this.checkBoxCRC = new System.Windows.Forms.CheckBox();
            this.labelErrorRx = new System.Windows.Forms.Label();
            this.buttonViewReport = new System.Windows.Forms.Button();
            this.textBoxReceive = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelEpoch = new System.Windows.Forms.Label();
            this.dateTimePickerEpoch = new System.Windows.Forms.DateTimePicker();
            this.labelNFracTime = new System.Windows.Forms.Label();
            this.checkBoxPField = new System.Windows.Forms.CheckBox();
            this.labelNBasicTime = new System.Windows.Forms.Label();
            this.comboBoxNFracTime = new System.Windows.Forms.ComboBox();
            this.comboBoxNBasicTime = new System.Windows.Forms.ComboBox();
            this.labelOBTType = new System.Windows.Forms.Label();
            this.comboBoxOBTType = new System.Windows.Forms.ComboBox();
            this.groupBoxSerialData = new System.Windows.Forms.GroupBox();
            this.tabControlSpecialGUI = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label26 = new System.Windows.Forms.Label();
            this.textBoxST06Description = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.numericUpDownMemID = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDownST06Seq = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.labelST06Warning = new System.Windows.Forms.Label();
            this.dataGridViewST06 = new System.Windows.Forms.DataGridView();
            this.labelST6Warning = new System.Windows.Forms.Label();
            this.buttonST06Del = new System.Windows.Forms.Button();
            this.buttonST06Add = new System.Windows.Forms.Button();
            this.buttonST06StoreDB = new System.Windows.Forms.Button();
            this.buttonST06StoreFile = new System.Windows.Forms.Button();
            this.textBoxST06Memory = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonST06File = new System.Windows.Forms.Button();
            this.textBoxST06File = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label29 = new System.Windows.Forms.Label();
            this.numericUpDownST11OverallSeq = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.numericUpDownST11Seq = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.labelST11Warning = new System.Windows.Forms.Label();
            this.textBoxST11Description = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dataGridViewST11 = new System.Windows.Forms.DataGridView();
            this.numericUpDownST11Release = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonST11StoreDB = new System.Windows.Forms.Button();
            this.buttonST11StoreFile = new System.Windows.Forms.Button();
            this.buttonST11Del = new System.Windows.Forms.Button();
            this.buttonST11Add = new System.Windows.Forms.Button();
            this.treeViewST11 = new System.Windows.Forms.TreeView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label30 = new System.Windows.Forms.Label();
            this.textBoxST13Description = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.numericUpDownST12ID = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownST13Seq = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.labelST14Warning = new System.Windows.Forms.Label();
            this.buttonST13StoreDB = new System.Windows.Forms.Button();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonST13StoreFile = new System.Windows.Forms.Button();
            this.buttonST13OpenBin = new System.Windows.Forms.Button();
            this.textBoxST13FileBin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label31 = new System.Windows.Forms.Label();
            this.numericUpDownST19AppID = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.numericUpDownST19OverallSeq = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownST19Seq = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.labelST19Warning = new System.Windows.Forms.Label();
            this.textBoxST19Description = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.dataGridViewST19 = new System.Windows.Forms.DataGridView();
            this.numericUpDownST19EventID = new System.Windows.Forms.NumericUpDown();
            this.label28 = new System.Windows.Forms.Label();
            this.buttonST19StoreDB = new System.Windows.Forms.Button();
            this.buttonST19StoreFile = new System.Windows.Forms.Button();
            this.buttonST19Del = new System.Windows.Forms.Button();
            this.buttonST19Add = new System.Windows.Forms.Button();
            this.treeViewST19 = new System.Windows.Forms.TreeView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label32 = new System.Windows.Forms.Label();
            this.textBoxST21ID = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.numericUpDownST21OverallSeq = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.numericUpDownST21Seq = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.labelST21Warning = new System.Windows.Forms.Label();
            this.textBoxST21Description = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.dataGridViewST21 = new System.Windows.Forms.DataGridView();
            this.numericUpDownST21Delay = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.buttonST21StoreDB = new System.Windows.Forms.Button();
            this.buttonST21StoreFile = new System.Windows.Forms.Button();
            this.buttonST21Del = new System.Windows.Forms.Button();
            this.buttonST21Add = new System.Windows.Forms.Button();
            this.treeViewST21 = new System.Windows.Forms.TreeView();
            this.openFileDialogBin = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogXml = new System.Windows.Forms.OpenFileDialog();
            this.buttonLoadSend = new System.Windows.Forms.Button();
            this.groupBoxRAW = new System.Windows.Forms.GroupBox();
            this.button8 = new System.Windows.Forms.Button();
            this.textBoxRawFile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.saveFileDialogBin = new System.Windows.Forms.SaveFileDialog();
            this.helpProviderPUS = new System.Windows.Forms.HelpProvider();
            this.groupBoxTelecommand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeq)).BeginInit();
            this.groupBoxAck.SuspendLayout();
            this.groupBoxPayloadTx.SuspendLayout();
            this.groupBoxSend.SuspendLayout();
            this.groupBoxSerialPort.SuspendLayout();
            this.groupBoxReceive.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxSerialData.SuspendLayout();
            this.tabControlSpecialGUI.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMemID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownST06Seq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewST06)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownST11OverallSeq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownST11Seq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewST11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownST11Release)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownST12ID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownST13Seq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownST19AppID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownST19OverallSeq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownST19Seq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewST19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownST19EventID)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownST21OverallSeq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownST21Seq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewST21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownST21Delay)).BeginInit();
            this.groupBoxRAW.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewTlcmd
            // 
            this.treeViewTlcmd.Location = new System.Drawing.Point(12, 12);
            this.treeViewTlcmd.Name = "treeViewTlcmd";
            this.treeViewTlcmd.ShowNodeToolTips = true;
            this.treeViewTlcmd.Size = new System.Drawing.Size(475, 762);
            this.treeViewTlcmd.TabIndex = 0;
            this.treeViewTlcmd.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewTlcmd_AfterSelect);
            // 
            // buttonSendTC
            // 
            this.buttonSendTC.Enabled = false;
            this.buttonSendTC.Location = new System.Drawing.Point(308, 225);
            this.buttonSendTC.Name = "buttonSendTC";
            this.buttonSendTC.Size = new System.Drawing.Size(75, 23);
            this.buttonSendTC.TabIndex = 2;
            this.buttonSendTC.Text = "Send";
            this.buttonSendTC.UseVisualStyleBackColor = true;
            this.buttonSendTC.Visible = false;
            this.buttonSendTC.Click += new System.EventHandler(this.buttonSendTC_Click);
            // 
            // groupBoxTelecommand
            // 
            this.groupBoxTelecommand.Controls.Add(this.numericUpDownSeq);
            this.groupBoxTelecommand.Controls.Add(this.label1);
            this.groupBoxTelecommand.Controls.Add(this.buttonDelTC);
            this.groupBoxTelecommand.Controls.Add(this.textBoxDescription);
            this.groupBoxTelecommand.Controls.Add(this.labelDescription);
            this.groupBoxTelecommand.Controls.Add(this.buttonSaveTC);
            this.groupBoxTelecommand.Controls.Add(this.buttonEditTC);
            this.groupBoxTelecommand.Controls.Add(this.groupBoxAck);
            this.groupBoxTelecommand.Controls.Add(this.groupBoxPayloadTx);
            this.groupBoxTelecommand.Controls.Add(this.labelSizeTx);
            this.groupBoxTelecommand.Controls.Add(this.textBoxSizeTx);
            this.groupBoxTelecommand.Controls.Add(this.labelCRC);
            this.groupBoxTelecommand.Controls.Add(this.labelServiceSubTypeTx);
            this.groupBoxTelecommand.Controls.Add(this.textBoxServiceSubTypeTx);
            this.groupBoxTelecommand.Controls.Add(this.labelServiceTypeTx);
            this.groupBoxTelecommand.Controls.Add(this.textBoxServiceTypeTx);
            this.groupBoxTelecommand.Controls.Add(this.buttonSendTC);
            this.groupBoxTelecommand.Enabled = false;
            this.groupBoxTelecommand.Location = new System.Drawing.Point(494, 152);
            this.groupBoxTelecommand.Name = "groupBoxTelecommand";
            this.groupBoxTelecommand.Size = new System.Drawing.Size(390, 259);
            this.groupBoxTelecommand.TabIndex = 3;
            this.groupBoxTelecommand.TabStop = false;
            this.groupBoxTelecommand.Text = "Telecommand";
            // 
            // numericUpDownSeq
            // 
            this.numericUpDownSeq.Hexadecimal = true;
            this.numericUpDownSeq.Location = new System.Drawing.Point(237, 48);
            this.numericUpDownSeq.Maximum = new decimal(new int[] {
            16383,
            0,
            0,
            0});
            this.numericUpDownSeq.Name = "numericUpDownSeq";
            this.numericUpDownSeq.Size = new System.Drawing.Size(57, 20);
            this.numericUpDownSeq.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Seq";
            // 
            // buttonDelTC
            // 
            this.buttonDelTC.Location = new System.Drawing.Point(154, 225);
            this.buttonDelTC.Name = "buttonDelTC";
            this.buttonDelTC.Size = new System.Drawing.Size(62, 23);
            this.buttonDelTC.TabIndex = 19;
            this.buttonDelTC.Text = "Delete";
            this.buttonDelTC.UseVisualStyleBackColor = true;
            this.buttonDelTC.Visible = false;
            this.buttonDelTC.Click += new System.EventHandler(this.buttonDelTC_Click);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxDescription.Location = new System.Drawing.Point(75, 24);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(303, 20);
            this.textBoxDescription.TabIndex = 18;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(9, 27);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(60, 13);
            this.labelDescription.TabIndex = 17;
            this.labelDescription.Text = "Description";
            // 
            // buttonSaveTC
            // 
            this.buttonSaveTC.Location = new System.Drawing.Point(86, 225);
            this.buttonSaveTC.Name = "buttonSaveTC";
            this.buttonSaveTC.Size = new System.Drawing.Size(62, 23);
            this.buttonSaveTC.TabIndex = 16;
            this.buttonSaveTC.Text = "Save";
            this.buttonSaveTC.UseVisualStyleBackColor = true;
            this.buttonSaveTC.Visible = false;
            this.buttonSaveTC.Click += new System.EventHandler(this.buttonSaveTC_Click);
            // 
            // buttonEditTC
            // 
            this.buttonEditTC.Location = new System.Drawing.Point(16, 225);
            this.buttonEditTC.Name = "buttonEditTC";
            this.buttonEditTC.Size = new System.Drawing.Size(64, 23);
            this.buttonEditTC.TabIndex = 15;
            this.buttonEditTC.Text = "Edit";
            this.buttonEditTC.UseVisualStyleBackColor = true;
            this.buttonEditTC.Visible = false;
            this.buttonEditTC.Click += new System.EventHandler(this.buttonEditTC_Click);
            // 
            // groupBoxAck
            // 
            this.groupBoxAck.Controls.Add(this.checkBoxAckAcc);
            this.groupBoxAck.Controls.Add(this.checkBoxAckProg);
            this.groupBoxAck.Controls.Add(this.checkBoxAckComp);
            this.groupBoxAck.Controls.Add(this.checkBoxAckExec);
            this.groupBoxAck.Location = new System.Drawing.Point(10, 74);
            this.groupBoxAck.Name = "groupBoxAck";
            this.groupBoxAck.Size = new System.Drawing.Size(373, 46);
            this.groupBoxAck.TabIndex = 12;
            this.groupBoxAck.TabStop = false;
            this.groupBoxAck.Text = "Ack Flags";
            // 
            // checkBoxAckAcc
            // 
            this.checkBoxAckAcc.AutoSize = true;
            this.checkBoxAckAcc.Location = new System.Drawing.Point(273, 19);
            this.checkBoxAckAcc.Name = "checkBoxAckAcc";
            this.checkBoxAckAcc.Size = new System.Drawing.Size(84, 17);
            this.checkBoxAckAcc.TabIndex = 9;
            this.checkBoxAckAcc.Text = "Acceptance";
            this.checkBoxAckAcc.UseVisualStyleBackColor = true;
            // 
            // checkBoxAckProg
            // 
            this.checkBoxAckProg.AutoSize = true;
            this.checkBoxAckProg.Location = new System.Drawing.Point(107, 19);
            this.checkBoxAckProg.Name = "checkBoxAckProg";
            this.checkBoxAckProg.Size = new System.Drawing.Size(67, 17);
            this.checkBoxAckProg.TabIndex = 11;
            this.checkBoxAckProg.Text = "Progress";
            this.checkBoxAckProg.UseVisualStyleBackColor = true;
            // 
            // checkBoxAckComp
            // 
            this.checkBoxAckComp.AutoSize = true;
            this.checkBoxAckComp.Location = new System.Drawing.Point(7, 19);
            this.checkBoxAckComp.Name = "checkBoxAckComp";
            this.checkBoxAckComp.Size = new System.Drawing.Size(87, 17);
            this.checkBoxAckComp.TabIndex = 10;
            this.checkBoxAckComp.Text = "Completation";
            this.checkBoxAckComp.UseVisualStyleBackColor = true;
            // 
            // checkBoxAckExec
            // 
            this.checkBoxAckExec.AutoSize = true;
            this.checkBoxAckExec.Location = new System.Drawing.Point(187, 19);
            this.checkBoxAckExec.Name = "checkBoxAckExec";
            this.checkBoxAckExec.Size = new System.Drawing.Size(73, 17);
            this.checkBoxAckExec.TabIndex = 10;
            this.checkBoxAckExec.Text = "Execution";
            this.checkBoxAckExec.UseVisualStyleBackColor = true;
            // 
            // groupBoxPayloadTx
            // 
            this.groupBoxPayloadTx.Controls.Add(this.textBoxPayloadTx);
            this.groupBoxPayloadTx.Location = new System.Drawing.Point(10, 126);
            this.groupBoxPayloadTx.Name = "groupBoxPayloadTx";
            this.groupBoxPayloadTx.Size = new System.Drawing.Size(373, 93);
            this.groupBoxPayloadTx.TabIndex = 9;
            this.groupBoxPayloadTx.TabStop = false;
            this.groupBoxPayloadTx.Text = "Payload (hex)";
            // 
            // textBoxPayloadTx
            // 
            this.textBoxPayloadTx.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxPayloadTx.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold);
            this.textBoxPayloadTx.Location = new System.Drawing.Point(6, 19);
            this.textBoxPayloadTx.Multiline = true;
            this.textBoxPayloadTx.Name = "textBoxPayloadTx";
            this.textBoxPayloadTx.ReadOnly = true;
            this.textBoxPayloadTx.Size = new System.Drawing.Size(361, 62);
            this.textBoxPayloadTx.TabIndex = 10;
            // 
            // labelSizeTx
            // 
            this.labelSizeTx.AutoSize = true;
            this.labelSizeTx.Location = new System.Drawing.Point(296, 51);
            this.labelSizeTx.Name = "labelSizeTx";
            this.labelSizeTx.Size = new System.Drawing.Size(27, 13);
            this.labelSizeTx.TabIndex = 14;
            this.labelSizeTx.Text = "Size";
            // 
            // textBoxSizeTx
            // 
            this.textBoxSizeTx.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxSizeTx.Location = new System.Drawing.Point(331, 48);
            this.textBoxSizeTx.Name = "textBoxSizeTx";
            this.textBoxSizeTx.ReadOnly = true;
            this.textBoxSizeTx.Size = new System.Drawing.Size(46, 20);
            this.textBoxSizeTx.TabIndex = 13;
            // 
            // labelCRC
            // 
            this.labelCRC.AutoSize = true;
            this.labelCRC.Location = new System.Drawing.Point(227, 230);
            this.labelCRC.Name = "labelCRC";
            this.labelCRC.Size = new System.Drawing.Size(29, 13);
            this.labelCRC.TabIndex = 12;
            this.labelCRC.Text = "CRC";
            this.labelCRC.Visible = false;
            // 
            // labelServiceSubTypeTx
            // 
            this.labelServiceSubTypeTx.AutoSize = true;
            this.labelServiceSubTypeTx.Location = new System.Drawing.Point(116, 51);
            this.labelServiceSubTypeTx.Name = "labelServiceSubTypeTx";
            this.labelServiceSubTypeTx.Size = new System.Drawing.Size(53, 13);
            this.labelServiceSubTypeTx.TabIndex = 6;
            this.labelServiceSubTypeTx.Text = "Sub Type";
            // 
            // textBoxServiceSubTypeTx
            // 
            this.textBoxServiceSubTypeTx.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxServiceSubTypeTx.Location = new System.Drawing.Point(169, 48);
            this.textBoxServiceSubTypeTx.Name = "textBoxServiceSubTypeTx";
            this.textBoxServiceSubTypeTx.ReadOnly = true;
            this.textBoxServiceSubTypeTx.Size = new System.Drawing.Size(33, 20);
            this.textBoxServiceSubTypeTx.TabIndex = 5;
            // 
            // labelServiceTypeTx
            // 
            this.labelServiceTypeTx.AutoSize = true;
            this.labelServiceTypeTx.Location = new System.Drawing.Point(10, 51);
            this.labelServiceTypeTx.Name = "labelServiceTypeTx";
            this.labelServiceTypeTx.Size = new System.Drawing.Size(70, 13);
            this.labelServiceTypeTx.TabIndex = 4;
            this.labelServiceTypeTx.Text = "Service Type";
            // 
            // textBoxServiceTypeTx
            // 
            this.textBoxServiceTypeTx.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxServiceTypeTx.Location = new System.Drawing.Point(81, 48);
            this.textBoxServiceTypeTx.Name = "textBoxServiceTypeTx";
            this.textBoxServiceTypeTx.ReadOnly = true;
            this.textBoxServiceTypeTx.Size = new System.Drawing.Size(33, 20);
            this.textBoxServiceTypeTx.TabIndex = 3;
            // 
            // groupBoxSend
            // 
            this.groupBoxSend.Controls.Add(this.labelSend);
            this.groupBoxSend.Controls.Add(this.textBoxSend);
            this.groupBoxSend.Location = new System.Drawing.Point(10, 19);
            this.groupBoxSend.Name = "groupBoxSend";
            this.groupBoxSend.Size = new System.Drawing.Size(367, 109);
            this.groupBoxSend.TabIndex = 11;
            this.groupBoxSend.TabStop = false;
            this.groupBoxSend.Text = "Send (hex)";
            // 
            // labelSend
            // 
            this.labelSend.AutoSize = true;
            this.labelSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSend.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelSend.Location = new System.Drawing.Point(324, 10);
            this.labelSend.Name = "labelSend";
            this.labelSend.Size = new System.Drawing.Size(33, 13);
            this.labelSend.TabIndex = 34;
            this.labelSend.Text = "Sent";
            this.labelSend.Visible = false;
            // 
            // textBoxSend
            // 
            this.textBoxSend.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxSend.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold);
            this.textBoxSend.Location = new System.Drawing.Point(6, 26);
            this.textBoxSend.Multiline = true;
            this.textBoxSend.Name = "textBoxSend";
            this.textBoxSend.ReadOnly = true;
            this.textBoxSend.Size = new System.Drawing.Size(351, 72);
            this.textBoxSend.TabIndex = 10;
            // 
            // buttonCloseUart
            // 
            this.buttonCloseUart.Location = new System.Drawing.Point(205, 16);
            this.buttonCloseUart.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCloseUart.Name = "buttonCloseUart";
            this.buttonCloseUart.Size = new System.Drawing.Size(82, 26);
            this.buttonCloseUart.TabIndex = 33;
            this.buttonCloseUart.Text = "Close UART";
            this.buttonCloseUart.UseVisualStyleBackColor = true;
            this.buttonCloseUart.Visible = false;
            this.buttonCloseUart.Click += new System.EventHandler(this.buttonCloseUart_Click);
            // 
            // buttonOpenUart
            // 
            this.buttonOpenUart.Location = new System.Drawing.Point(205, 16);
            this.buttonOpenUart.Margin = new System.Windows.Forms.Padding(2);
            this.buttonOpenUart.Name = "buttonOpenUart";
            this.buttonOpenUart.Size = new System.Drawing.Size(82, 26);
            this.buttonOpenUart.TabIndex = 30;
            this.buttonOpenUart.Text = "Open UART";
            this.buttonOpenUart.UseVisualStyleBackColor = true;
            this.buttonOpenUart.Click += new System.EventHandler(this.buttonOpenUart_Click);
            // 
            // groupBoxSerialPort
            // 
            this.groupBoxSerialPort.Controls.Add(this.label8);
            this.groupBoxSerialPort.Controls.Add(this.labelRS422);
            this.groupBoxSerialPort.Controls.Add(this.buttonOpenUart);
            this.groupBoxSerialPort.Controls.Add(this.buttonCloseUart);
            this.groupBoxSerialPort.Controls.Add(this.comboBoxRS422bps);
            this.groupBoxSerialPort.Controls.Add(this.labelTitleRS422);
            this.groupBoxSerialPort.Controls.Add(this.comboBoxRS422);
            this.groupBoxSerialPort.Location = new System.Drawing.Point(493, 12);
            this.groupBoxSerialPort.Name = "groupBoxSerialPort";
            this.groupBoxSerialPort.Size = new System.Drawing.Size(391, 52);
            this.groupBoxSerialPort.TabIndex = 31;
            this.groupBoxSerialPort.TabStop = false;
            this.groupBoxSerialPort.Text = "Serial Ports Config";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(177, 21);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "bps";
            // 
            // labelRS422
            // 
            this.labelRS422.AutoSize = true;
            this.labelRS422.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRS422.Location = new System.Drawing.Point(291, 22);
            this.labelRS422.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRS422.Name = "labelRS422";
            this.labelRS422.Size = new System.Drawing.Size(53, 12);
            this.labelRS422.TabIndex = 32;
            this.labelRS422.Text = "Port Closed";
            // 
            // comboBoxRS422bps
            // 
            this.comboBoxRS422bps.FormattingEnabled = true;
            this.comboBoxRS422bps.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.comboBoxRS422bps.Location = new System.Drawing.Point(110, 18);
            this.comboBoxRS422bps.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxRS422bps.Name = "comboBoxRS422bps";
            this.comboBoxRS422bps.Size = new System.Drawing.Size(64, 21);
            this.comboBoxRS422bps.TabIndex = 4;
            // 
            // labelTitleRS422
            // 
            this.labelTitleRS422.AutoSize = true;
            this.labelTitleRS422.Location = new System.Drawing.Point(3, 22);
            this.labelTitleRS422.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTitleRS422.Name = "labelTitleRS422";
            this.labelTitleRS422.Size = new System.Drawing.Size(37, 13);
            this.labelTitleRS422.TabIndex = 2;
            this.labelTitleRS422.Text = "UART";
            // 
            // comboBoxRS422
            // 
            this.comboBoxRS422.FormattingEnabled = true;
            this.comboBoxRS422.Location = new System.Drawing.Point(44, 18);
            this.comboBoxRS422.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxRS422.Name = "comboBoxRS422";
            this.comboBoxRS422.Size = new System.Drawing.Size(57, 21);
            this.comboBoxRS422.TabIndex = 3;
            this.comboBoxRS422.SelectedIndexChanged += new System.EventHandler(this.comboBoxRS422_SelectedIndexChanged);
            // 
            // groupBoxReceive
            // 
            this.groupBoxReceive.Controls.Add(this.checkBoxCRC);
            this.groupBoxReceive.Controls.Add(this.labelErrorRx);
            this.groupBoxReceive.Controls.Add(this.buttonViewReport);
            this.groupBoxReceive.Controls.Add(this.textBoxReceive);
            this.groupBoxReceive.Location = new System.Drawing.Point(10, 130);
            this.groupBoxReceive.Name = "groupBoxReceive";
            this.groupBoxReceive.Size = new System.Drawing.Size(366, 138);
            this.groupBoxReceive.TabIndex = 12;
            this.groupBoxReceive.TabStop = false;
            this.groupBoxReceive.Text = "Receive (hex)";
            // 
            // checkBoxCRC
            // 
            this.checkBoxCRC.AutoSize = true;
            this.checkBoxCRC.Enabled = false;
            this.checkBoxCRC.Location = new System.Drawing.Point(12, 108);
            this.checkBoxCRC.Name = "checkBoxCRC";
            this.checkBoxCRC.Size = new System.Drawing.Size(84, 17);
            this.checkBoxCRC.TabIndex = 17;
            this.checkBoxCRC.Text = "CRC Enable";
            this.checkBoxCRC.UseVisualStyleBackColor = true;
            // 
            // labelErrorRx
            // 
            this.labelErrorRx.AutoSize = true;
            this.labelErrorRx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErrorRx.ForeColor = System.Drawing.Color.Crimson;
            this.labelErrorRx.Location = new System.Drawing.Point(93, 10);
            this.labelErrorRx.Name = "labelErrorRx";
            this.labelErrorRx.Size = new System.Drawing.Size(34, 13);
            this.labelErrorRx.TabIndex = 35;
            this.labelErrorRx.Text = "Error";
            this.labelErrorRx.Visible = false;
            // 
            // buttonViewReport
            // 
            this.buttonViewReport.Location = new System.Drawing.Point(282, 104);
            this.buttonViewReport.Name = "buttonViewReport";
            this.buttonViewReport.Size = new System.Drawing.Size(75, 23);
            this.buttonViewReport.TabIndex = 16;
            this.buttonViewReport.Text = "View";
            this.buttonViewReport.UseVisualStyleBackColor = true;
            this.buttonViewReport.Click += new System.EventHandler(this.buttonViewReport_Click);
            // 
            // textBoxReceive
            // 
            this.textBoxReceive.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxReceive.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold);
            this.textBoxReceive.Location = new System.Drawing.Point(8, 26);
            this.textBoxReceive.Multiline = true;
            this.textBoxReceive.Name = "textBoxReceive";
            this.textBoxReceive.ReadOnly = true;
            this.textBoxReceive.Size = new System.Drawing.Size(351, 72);
            this.textBoxReceive.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelEpoch);
            this.groupBox1.Controls.Add(this.dateTimePickerEpoch);
            this.groupBox1.Controls.Add(this.labelNFracTime);
            this.groupBox1.Controls.Add(this.checkBoxPField);
            this.groupBox1.Controls.Add(this.labelNBasicTime);
            this.groupBox1.Controls.Add(this.comboBoxNFracTime);
            this.groupBox1.Controls.Add(this.comboBoxNBasicTime);
            this.groupBox1.Controls.Add(this.labelOBTType);
            this.groupBox1.Controls.Add(this.comboBoxOBTType);
            this.groupBox1.Location = new System.Drawing.Point(493, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 76);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "OnBoard Time Format";
            // 
            // labelEpoch
            // 
            this.labelEpoch.AutoSize = true;
            this.labelEpoch.Location = new System.Drawing.Point(5, 48);
            this.labelEpoch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEpoch.Name = "labelEpoch";
            this.labelEpoch.Size = new System.Drawing.Size(38, 13);
            this.labelEpoch.TabIndex = 16;
            this.labelEpoch.Text = "Epoch";
            // 
            // dateTimePickerEpoch
            // 
            this.dateTimePickerEpoch.Enabled = false;
            this.dateTimePickerEpoch.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerEpoch.Location = new System.Drawing.Point(48, 46);
            this.dateTimePickerEpoch.Name = "dateTimePickerEpoch";
            this.dateTimePickerEpoch.Size = new System.Drawing.Size(100, 20);
            this.dateTimePickerEpoch.TabIndex = 15;
            // 
            // labelNFracTime
            // 
            this.labelNFracTime.AutoSize = true;
            this.labelNFracTime.Location = new System.Drawing.Point(191, 48);
            this.labelNFracTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNFracTime.Name = "labelNFracTime";
            this.labelNFracTime.Size = new System.Drawing.Size(86, 13);
            this.labelNFracTime.TabIndex = 14;
            this.labelNFracTime.Text = "N frac time bytes";
            // 
            // checkBoxPField
            // 
            this.checkBoxPField.AutoSize = true;
            this.checkBoxPField.Enabled = false;
            this.checkBoxPField.Location = new System.Drawing.Point(115, 21);
            this.checkBoxPField.Name = "checkBoxPField";
            this.checkBoxPField.Size = new System.Drawing.Size(58, 17);
            this.checkBoxPField.TabIndex = 12;
            this.checkBoxPField.Text = "P-Field";
            this.checkBoxPField.UseVisualStyleBackColor = true;
            // 
            // labelNBasicTime
            // 
            this.labelNBasicTime.AutoSize = true;
            this.labelNBasicTime.Location = new System.Drawing.Point(191, 23);
            this.labelNBasicTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNBasicTime.Name = "labelNBasicTime";
            this.labelNBasicTime.Size = new System.Drawing.Size(93, 13);
            this.labelNBasicTime.TabIndex = 7;
            this.labelNBasicTime.Text = "N basic time bytes";
            // 
            // comboBoxNFracTime
            // 
            this.comboBoxNFracTime.Enabled = false;
            this.comboBoxNFracTime.FormattingEnabled = true;
            this.comboBoxNFracTime.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.comboBoxNFracTime.Location = new System.Drawing.Point(288, 45);
            this.comboBoxNFracTime.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxNFracTime.Name = "comboBoxNFracTime";
            this.comboBoxNFracTime.Size = new System.Drawing.Size(31, 21);
            this.comboBoxNFracTime.TabIndex = 13;
            // 
            // comboBoxNBasicTime
            // 
            this.comboBoxNBasicTime.Enabled = false;
            this.comboBoxNBasicTime.FormattingEnabled = true;
            this.comboBoxNBasicTime.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBoxNBasicTime.Location = new System.Drawing.Point(288, 20);
            this.comboBoxNBasicTime.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxNBasicTime.Name = "comboBoxNBasicTime";
            this.comboBoxNBasicTime.Size = new System.Drawing.Size(31, 21);
            this.comboBoxNBasicTime.TabIndex = 4;
            // 
            // labelOBTType
            // 
            this.labelOBTType.AutoSize = true;
            this.labelOBTType.Location = new System.Drawing.Point(3, 22);
            this.labelOBTType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOBTType.Name = "labelOBTType";
            this.labelOBTType.Size = new System.Drawing.Size(31, 13);
            this.labelOBTType.TabIndex = 2;
            this.labelOBTType.Text = "Type";
            // 
            // comboBoxOBTType
            // 
            this.comboBoxOBTType.Enabled = false;
            this.comboBoxOBTType.FormattingEnabled = true;
            this.comboBoxOBTType.Items.AddRange(new object[] {
            "CUC1",
            "CUC2",
            "CDS"});
            this.comboBoxOBTType.Location = new System.Drawing.Point(38, 18);
            this.comboBoxOBTType.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxOBTType.Name = "comboBoxOBTType";
            this.comboBoxOBTType.Size = new System.Drawing.Size(57, 21);
            this.comboBoxOBTType.TabIndex = 3;
            // 
            // groupBoxSerialData
            // 
            this.groupBoxSerialData.Controls.Add(this.groupBoxSend);
            this.groupBoxSerialData.Controls.Add(this.groupBoxReceive);
            this.groupBoxSerialData.Location = new System.Drawing.Point(494, 500);
            this.groupBoxSerialData.Name = "groupBoxSerialData";
            this.groupBoxSerialData.Size = new System.Drawing.Size(390, 274);
            this.groupBoxSerialData.TabIndex = 33;
            this.groupBoxSerialData.TabStop = false;
            this.groupBoxSerialData.Text = "Serial Port Data";
            // 
            // tabControlSpecialGUI
            // 
            this.tabControlSpecialGUI.Controls.Add(this.tabPage3);
            this.tabControlSpecialGUI.Controls.Add(this.tabPage1);
            this.tabControlSpecialGUI.Controls.Add(this.tabPage2);
            this.tabControlSpecialGUI.Controls.Add(this.tabPage5);
            this.tabControlSpecialGUI.Controls.Add(this.tabPage4);
            this.tabControlSpecialGUI.Location = new System.Drawing.Point(900, 12);
            this.tabControlSpecialGUI.Name = "tabControlSpecialGUI";
            this.tabControlSpecialGUI.SelectedIndex = 0;
            this.tabControlSpecialGUI.Size = new System.Drawing.Size(467, 762);
            this.tabControlSpecialGUI.TabIndex = 34;
            this.tabControlSpecialGUI.Visible = false;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.label26);
            this.tabPage3.Controls.Add(this.textBoxST06Description);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.numericUpDownMemID);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.numericUpDownST06Seq);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.labelST06Warning);
            this.tabPage3.Controls.Add(this.dataGridViewST06);
            this.tabPage3.Controls.Add(this.labelST6Warning);
            this.tabPage3.Controls.Add(this.buttonST06Del);
            this.tabPage3.Controls.Add(this.buttonST06Add);
            this.tabPage3.Controls.Add(this.buttonST06StoreDB);
            this.tabPage3.Controls.Add(this.buttonST06StoreFile);
            this.tabPage3.Controls.Add(this.textBoxST06Memory);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.buttonST06File);
            this.tabPage3.Controls.Add(this.textBoxST06File);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(459, 736);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ST06 Memory Management";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(12, 10);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(137, 16);
            this.label26.TabIndex = 50;
            this.label26.Text = "Dump data to Memory";
            // 
            // textBoxST06Description
            // 
            this.textBoxST06Description.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxST06Description.Location = new System.Drawing.Point(77, 90);
            this.textBoxST06Description.Name = "textBoxST06Description";
            this.textBoxST06Description.Size = new System.Drawing.Size(303, 20);
            this.textBoxST06Description.TabIndex = 49;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 93);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 13);
            this.label13.TabIndex = 48;
            this.label13.Text = "Description";
            // 
            // numericUpDownMemID
            // 
            this.numericUpDownMemID.Location = new System.Drawing.Point(237, 66);
            this.numericUpDownMemID.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownMemID.Name = "numericUpDownMemID";
            this.numericUpDownMemID.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownMemID.TabIndex = 47;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(187, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 46;
            this.label11.Text = "Mem ID";
            // 
            // numericUpDownST06Seq
            // 
            this.numericUpDownST06Seq.Location = new System.Drawing.Point(319, 66);
            this.numericUpDownST06Seq.Maximum = new decimal(new int[] {
            16383,
            0,
            0,
            0});
            this.numericUpDownST06Seq.Name = "numericUpDownST06Seq";
            this.numericUpDownST06Seq.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownST06Seq.TabIndex = 45;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(284, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 44;
            this.label10.Text = "Seq";
            // 
            // labelST06Warning
            // 
            this.labelST06Warning.AutoSize = true;
            this.labelST06Warning.Location = new System.Drawing.Point(15, 126);
            this.labelST06Warning.Name = "labelST06Warning";
            this.labelST06Warning.Size = new System.Drawing.Size(0, 13);
            this.labelST06Warning.TabIndex = 43;
            // 
            // dataGridViewST06
            // 
            this.dataGridViewST06.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewST06.Location = new System.Drawing.Point(9, 152);
            this.dataGridViewST06.Name = "dataGridViewST06";
            this.dataGridViewST06.Size = new System.Drawing.Size(441, 211);
            this.dataGridViewST06.TabIndex = 42;
            this.dataGridViewST06.SelectionChanged += new System.EventHandler(this.dataGridViewST06_SelectionChanged);
            // 
            // labelST6Warning
            // 
            this.labelST6Warning.AutoSize = true;
            this.labelST6Warning.Location = new System.Drawing.Point(15, 133);
            this.labelST6Warning.Name = "labelST6Warning";
            this.labelST6Warning.Size = new System.Drawing.Size(0, 13);
            this.labelST6Warning.TabIndex = 41;
            // 
            // buttonST06Del
            // 
            this.buttonST06Del.Enabled = false;
            this.buttonST06Del.Location = new System.Drawing.Point(12, 379);
            this.buttonST06Del.Name = "buttonST06Del";
            this.buttonST06Del.Size = new System.Drawing.Size(58, 23);
            this.buttonST06Del.TabIndex = 40;
            this.buttonST06Del.Text = "Delete";
            this.buttonST06Del.UseVisualStyleBackColor = true;
            this.buttonST06Del.Click += new System.EventHandler(this.buttonST06Del_Click);
            // 
            // buttonST06Add
            // 
            this.buttonST06Add.Enabled = false;
            this.buttonST06Add.Location = new System.Drawing.Point(385, 64);
            this.buttonST06Add.Name = "buttonST06Add";
            this.buttonST06Add.Size = new System.Drawing.Size(58, 23);
            this.buttonST06Add.TabIndex = 38;
            this.buttonST06Add.Text = "Add";
            this.buttonST06Add.UseVisualStyleBackColor = true;
            this.buttonST06Add.Click += new System.EventHandler(this.buttonST06Add_Click);
            // 
            // buttonST06StoreDB
            // 
            this.buttonST06StoreDB.Enabled = false;
            this.buttonST06StoreDB.Location = new System.Drawing.Point(365, 379);
            this.buttonST06StoreDB.Name = "buttonST06StoreDB";
            this.buttonST06StoreDB.Size = new System.Drawing.Size(75, 23);
            this.buttonST06StoreDB.TabIndex = 37;
            this.buttonST06StoreDB.Text = "Store in DB";
            this.buttonST06StoreDB.UseVisualStyleBackColor = true;
            this.buttonST06StoreDB.Click += new System.EventHandler(this.buttonST06StoreDB_Click);
            // 
            // buttonST06StoreFile
            // 
            this.buttonST06StoreFile.Enabled = false;
            this.buttonST06StoreFile.Location = new System.Drawing.Point(284, 379);
            this.buttonST06StoreFile.Name = "buttonST06StoreFile";
            this.buttonST06StoreFile.Size = new System.Drawing.Size(75, 23);
            this.buttonST06StoreFile.TabIndex = 36;
            this.buttonST06StoreFile.Text = "Store in File";
            this.buttonST06StoreFile.UseVisualStyleBackColor = true;
            this.buttonST06StoreFile.Click += new System.EventHandler(this.buttonST06StoreFile_Click);
            // 
            // textBoxST06Memory
            // 
            this.textBoxST06Memory.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxST06Memory.Location = new System.Drawing.Point(77, 65);
            this.textBoxST06Memory.Name = "textBoxST06Memory";
            this.textBoxST06Memory.Size = new System.Drawing.Size(106, 20);
            this.textBoxST06Memory.TabIndex = 35;
            this.textBoxST06Memory.Text = "0000000000000000";
            this.textBoxST06Memory.TextChanged += new System.EventHandler(this.textBoxST06Memory_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Mem Offset";
            // 
            // buttonST06File
            // 
            this.buttonST06File.Location = new System.Drawing.Point(385, 38);
            this.buttonST06File.Name = "buttonST06File";
            this.buttonST06File.Size = new System.Drawing.Size(58, 23);
            this.buttonST06File.TabIndex = 33;
            this.buttonST06File.Text = "File";
            this.buttonST06File.UseVisualStyleBackColor = true;
            this.buttonST06File.Click += new System.EventHandler(this.buttonST06File_Click);
            // 
            // textBoxST06File
            // 
            this.textBoxST06File.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxST06File.Location = new System.Drawing.Point(77, 40);
            this.textBoxST06File.Name = "textBoxST06File";
            this.textBoxST06File.Size = new System.Drawing.Size(302, 20);
            this.textBoxST06File.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Select File";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.label29);
            this.tabPage1.Controls.Add(this.numericUpDownST11OverallSeq);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.numericUpDownST11Seq);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.labelST11Warning);
            this.tabPage1.Controls.Add(this.textBoxST11Description);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.dataGridViewST11);
            this.tabPage1.Controls.Add(this.numericUpDownST11Release);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.buttonST11StoreDB);
            this.tabPage1.Controls.Add(this.buttonST11StoreFile);
            this.tabPage1.Controls.Add(this.buttonST11Del);
            this.tabPage1.Controls.Add(this.buttonST11Add);
            this.tabPage1.Controls.Add(this.treeViewST11);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(459, 736);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ST11 Time Based Scheduling";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(14, 4);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(157, 16);
            this.label29.TabIndex = 59;
            this.label29.Text = "Create Time Tagged Table";
            // 
            // numericUpDownST11OverallSeq
            // 
            this.numericUpDownST11OverallSeq.Location = new System.Drawing.Point(81, 593);
            this.numericUpDownST11OverallSeq.Maximum = new decimal(new int[] {
            16383,
            0,
            0,
            0});
            this.numericUpDownST11OverallSeq.Name = "numericUpDownST11OverallSeq";
            this.numericUpDownST11OverallSeq.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownST11OverallSeq.TabIndex = 58;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(22, 597);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 13);
            this.label17.TabIndex = 57;
            this.label17.Text = "Sequence";
            // 
            // numericUpDownST11Seq
            // 
            this.numericUpDownST11Seq.Location = new System.Drawing.Point(246, 310);
            this.numericUpDownST11Seq.Maximum = new decimal(new int[] {
            16383,
            0,
            0,
            0});
            this.numericUpDownST11Seq.Name = "numericUpDownST11Seq";
            this.numericUpDownST11Seq.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownST11Seq.TabIndex = 56;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(218, 314);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(26, 13);
            this.label16.TabIndex = 55;
            this.label16.Text = "Seq";
            // 
            // labelST11Warning
            // 
            this.labelST11Warning.AutoSize = true;
            this.labelST11Warning.Location = new System.Drawing.Point(18, 562);
            this.labelST11Warning.Name = "labelST11Warning";
            this.labelST11Warning.Size = new System.Drawing.Size(0, 13);
            this.labelST11Warning.TabIndex = 54;
            // 
            // textBoxST11Description
            // 
            this.textBoxST11Description.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxST11Description.Location = new System.Drawing.Point(81, 33);
            this.textBoxST11Description.Name = "textBoxST11Description";
            this.textBoxST11Description.Size = new System.Drawing.Size(360, 20);
            this.textBoxST11Description.TabIndex = 53;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 36);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 13);
            this.label15.TabIndex = 52;
            this.label15.Text = "Description";
            // 
            // dataGridViewST11
            // 
            this.dataGridViewST11.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewST11.Location = new System.Drawing.Point(17, 344);
            this.dataGridViewST11.Name = "dataGridViewST11";
            this.dataGridViewST11.Size = new System.Drawing.Size(424, 211);
            this.dataGridViewST11.TabIndex = 49;
            this.dataGridViewST11.SelectionChanged += new System.EventHandler(this.dataGridViewST11_SelectionChanged);
            // 
            // numericUpDownST11Release
            // 
            this.numericUpDownST11Release.Location = new System.Drawing.Point(95, 310);
            this.numericUpDownST11Release.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.numericUpDownST11Release.Name = "numericUpDownST11Release";
            this.numericUpDownST11Release.Size = new System.Drawing.Size(116, 20);
            this.numericUpDownST11Release.TabIndex = 48;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 312);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 45;
            this.label12.Text = "Release Time";
            // 
            // buttonST11StoreDB
            // 
            this.buttonST11StoreDB.Enabled = false;
            this.buttonST11StoreDB.Location = new System.Drawing.Point(366, 593);
            this.buttonST11StoreDB.Name = "buttonST11StoreDB";
            this.buttonST11StoreDB.Size = new System.Drawing.Size(75, 23);
            this.buttonST11StoreDB.TabIndex = 44;
            this.buttonST11StoreDB.Text = "Store in DB";
            this.buttonST11StoreDB.UseVisualStyleBackColor = true;
            this.buttonST11StoreDB.Click += new System.EventHandler(this.buttonST11StoreDB_Click);
            // 
            // buttonST11StoreFile
            // 
            this.buttonST11StoreFile.Enabled = false;
            this.buttonST11StoreFile.Location = new System.Drawing.Point(285, 593);
            this.buttonST11StoreFile.Name = "buttonST11StoreFile";
            this.buttonST11StoreFile.Size = new System.Drawing.Size(75, 23);
            this.buttonST11StoreFile.TabIndex = 43;
            this.buttonST11StoreFile.Text = "Store in File";
            this.buttonST11StoreFile.UseVisualStyleBackColor = true;
            this.buttonST11StoreFile.Click += new System.EventHandler(this.buttonST11StoreFile_Click);
            // 
            // buttonST11Del
            // 
            this.buttonST11Del.Enabled = false;
            this.buttonST11Del.Location = new System.Drawing.Point(383, 309);
            this.buttonST11Del.Name = "buttonST11Del";
            this.buttonST11Del.Size = new System.Drawing.Size(58, 23);
            this.buttonST11Del.TabIndex = 42;
            this.buttonST11Del.Text = "Delete";
            this.buttonST11Del.UseVisualStyleBackColor = true;
            this.buttonST11Del.Click += new System.EventHandler(this.buttonST11Del_Click);
            // 
            // buttonST11Add
            // 
            this.buttonST11Add.Enabled = false;
            this.buttonST11Add.Location = new System.Drawing.Point(319, 309);
            this.buttonST11Add.Name = "buttonST11Add";
            this.buttonST11Add.Size = new System.Drawing.Size(58, 23);
            this.buttonST11Add.TabIndex = 41;
            this.buttonST11Add.Text = "Add";
            this.buttonST11Add.UseVisualStyleBackColor = true;
            this.buttonST11Add.Click += new System.EventHandler(this.buttonST11Add_Click);
            // 
            // treeViewST11
            // 
            this.treeViewST11.Location = new System.Drawing.Point(17, 66);
            this.treeViewST11.Name = "treeViewST11";
            this.treeViewST11.Size = new System.Drawing.Size(426, 230);
            this.treeViewST11.TabIndex = 36;
            this.treeViewST11.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewST11_AfterSelect);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.label30);
            this.tabPage2.Controls.Add(this.textBoxST13Description);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.numericUpDownST12ID);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.numericUpDownST13Seq);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.labelST14Warning);
            this.tabPage2.Controls.Add(this.buttonST13StoreDB);
            this.tabPage2.Controls.Add(this.numericUpDown2);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.buttonST13StoreFile);
            this.tabPage2.Controls.Add(this.buttonST13OpenBin);
            this.tabPage2.Controls.Add(this.textBoxST13FileBin);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(459, 736);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ST13 Large Packet Transfer";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(18, 11);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(115, 16);
            this.label30.TabIndex = 60;
            this.label30.Text = "Split Large Packet";
            // 
            // textBoxST13Description
            // 
            this.textBoxST13Description.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxST13Description.Location = new System.Drawing.Point(82, 85);
            this.textBoxST13Description.Name = "textBoxST13Description";
            this.textBoxST13Description.Size = new System.Drawing.Size(303, 20);
            this.textBoxST13Description.TabIndex = 51;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 88);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 13);
            this.label14.TabIndex = 50;
            this.label14.Text = "Description";
            // 
            // numericUpDownST12ID
            // 
            this.numericUpDownST12ID.Location = new System.Drawing.Point(325, 59);
            this.numericUpDownST12ID.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownST12ID.Name = "numericUpDownST12ID";
            this.numericUpDownST12ID.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownST12ID.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(301, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "ID";
            // 
            // numericUpDownST13Seq
            // 
            this.numericUpDownST13Seq.Location = new System.Drawing.Point(210, 59);
            this.numericUpDownST13Seq.Maximum = new decimal(new int[] {
            16383,
            0,
            0,
            0});
            this.numericUpDownST13Seq.Name = "numericUpDownST13Seq";
            this.numericUpDownST13Seq.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownST13Seq.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(148, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Sequence";
            // 
            // labelST14Warning
            // 
            this.labelST14Warning.AutoSize = true;
            this.labelST14Warning.Location = new System.Drawing.Point(21, 122);
            this.labelST14Warning.Name = "labelST14Warning";
            this.labelST14Warning.Size = new System.Drawing.Size(0, 13);
            this.labelST14Warning.TabIndex = 32;
            // 
            // buttonST13StoreDB
            // 
            this.buttonST13StoreDB.Enabled = false;
            this.buttonST13StoreDB.Location = new System.Drawing.Point(376, 142);
            this.buttonST13StoreDB.Name = "buttonST13StoreDB";
            this.buttonST13StoreDB.Size = new System.Drawing.Size(75, 23);
            this.buttonST13StoreDB.TabIndex = 31;
            this.buttonST13StoreDB.Text = "Store in DB";
            this.buttonST13StoreDB.UseVisualStyleBackColor = true;
            this.buttonST13StoreDB.Click += new System.EventHandler(this.buttonST12StoreDB_Click);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(82, 59);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            16383,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(60, 20);
            this.numericUpDown2.TabIndex = 30;
            this.numericUpDown2.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Max size";
            // 
            // buttonST13StoreFile
            // 
            this.buttonST13StoreFile.Enabled = false;
            this.buttonST13StoreFile.Location = new System.Drawing.Point(295, 142);
            this.buttonST13StoreFile.Name = "buttonST13StoreFile";
            this.buttonST13StoreFile.Size = new System.Drawing.Size(75, 23);
            this.buttonST13StoreFile.TabIndex = 27;
            this.buttonST13StoreFile.Text = "Store in File";
            this.buttonST13StoreFile.UseVisualStyleBackColor = true;
            this.buttonST13StoreFile.Click += new System.EventHandler(this.buttonST12StoreFile_Click);
            // 
            // buttonST13OpenBin
            // 
            this.buttonST13OpenBin.Location = new System.Drawing.Point(393, 31);
            this.buttonST13OpenBin.Name = "buttonST13OpenBin";
            this.buttonST13OpenBin.Size = new System.Drawing.Size(58, 23);
            this.buttonST13OpenBin.TabIndex = 26;
            this.buttonST13OpenBin.Text = "File";
            this.buttonST13OpenBin.UseVisualStyleBackColor = true;
            this.buttonST13OpenBin.Click += new System.EventHandler(this.buttonST14OpenBin_Click);
            // 
            // textBoxST13FileBin
            // 
            this.textBoxST13FileBin.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxST13FileBin.Location = new System.Drawing.Point(82, 33);
            this.textBoxST13FileBin.Name = "textBoxST13FileBin";
            this.textBoxST13FileBin.Size = new System.Drawing.Size(303, 20);
            this.textBoxST13FileBin.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Send file";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage5.Controls.Add(this.label31);
            this.tabPage5.Controls.Add(this.numericUpDownST19AppID);
            this.tabPage5.Controls.Add(this.label24);
            this.tabPage5.Controls.Add(this.label23);
            this.tabPage5.Controls.Add(this.numericUpDownST19OverallSeq);
            this.tabPage5.Controls.Add(this.numericUpDownST19Seq);
            this.tabPage5.Controls.Add(this.label25);
            this.tabPage5.Controls.Add(this.labelST19Warning);
            this.tabPage5.Controls.Add(this.textBoxST19Description);
            this.tabPage5.Controls.Add(this.label27);
            this.tabPage5.Controls.Add(this.dataGridViewST19);
            this.tabPage5.Controls.Add(this.numericUpDownST19EventID);
            this.tabPage5.Controls.Add(this.label28);
            this.tabPage5.Controls.Add(this.buttonST19StoreDB);
            this.tabPage5.Controls.Add(this.buttonST19StoreFile);
            this.tabPage5.Controls.Add(this.buttonST19Del);
            this.tabPage5.Controls.Add(this.buttonST19Add);
            this.tabPage5.Controls.Add(this.treeViewST19);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(459, 736);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "ST19 Event-action";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(14, 4);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(123, 16);
            this.label31.TabIndex = 94;
            this.label31.Text = "Create Events Table";
            // 
            // numericUpDownST19AppID
            // 
            this.numericUpDownST19AppID.Location = new System.Drawing.Point(165, 312);
            this.numericUpDownST19AppID.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownST19AppID.Name = "numericUpDownST19AppID";
            this.numericUpDownST19AppID.Size = new System.Drawing.Size(54, 20);
            this.numericUpDownST19AppID.TabIndex = 93;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(126, 315);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(40, 13);
            this.label24.TabIndex = 92;
            this.label24.Text = "App ID";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(21, 599);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(56, 13);
            this.label23.TabIndex = 91;
            this.label23.Text = "Sequence";
            // 
            // numericUpDownST19OverallSeq
            // 
            this.numericUpDownST19OverallSeq.Location = new System.Drawing.Point(81, 596);
            this.numericUpDownST19OverallSeq.Maximum = new decimal(new int[] {
            16383,
            0,
            0,
            0});
            this.numericUpDownST19OverallSeq.Name = "numericUpDownST19OverallSeq";
            this.numericUpDownST19OverallSeq.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownST19OverallSeq.TabIndex = 90;
            // 
            // numericUpDownST19Seq
            // 
            this.numericUpDownST19Seq.Location = new System.Drawing.Point(253, 313);
            this.numericUpDownST19Seq.Maximum = new decimal(new int[] {
            16383,
            0,
            0,
            0});
            this.numericUpDownST19Seq.Name = "numericUpDownST19Seq";
            this.numericUpDownST19Seq.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownST19Seq.TabIndex = 88;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(221, 315);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(26, 13);
            this.label25.TabIndex = 87;
            this.label25.Text = "Seq";
            // 
            // labelST19Warning
            // 
            this.labelST19Warning.AutoSize = true;
            this.labelST19Warning.Location = new System.Drawing.Point(18, 565);
            this.labelST19Warning.Name = "labelST19Warning";
            this.labelST19Warning.Size = new System.Drawing.Size(0, 13);
            this.labelST19Warning.TabIndex = 86;
            // 
            // textBoxST19Description
            // 
            this.textBoxST19Description.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxST19Description.Location = new System.Drawing.Point(81, 36);
            this.textBoxST19Description.Name = "textBoxST19Description";
            this.textBoxST19Description.Size = new System.Drawing.Size(360, 20);
            this.textBoxST19Description.TabIndex = 85;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(15, 39);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(60, 13);
            this.label27.TabIndex = 84;
            this.label27.Text = "Description";
            // 
            // dataGridViewST19
            // 
            this.dataGridViewST19.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewST19.Location = new System.Drawing.Point(17, 347);
            this.dataGridViewST19.Name = "dataGridViewST19";
            this.dataGridViewST19.Size = new System.Drawing.Size(424, 211);
            this.dataGridViewST19.TabIndex = 83;
            this.dataGridViewST19.SelectionChanged += new System.EventHandler(this.dataGridViewST19_SelectionChanged);
            // 
            // numericUpDownST19EventID
            // 
            this.numericUpDownST19EventID.Location = new System.Drawing.Point(69, 312);
            this.numericUpDownST19EventID.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownST19EventID.Name = "numericUpDownST19EventID";
            this.numericUpDownST19EventID.Size = new System.Drawing.Size(54, 20);
            this.numericUpDownST19EventID.TabIndex = 82;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(17, 315);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(49, 13);
            this.label28.TabIndex = 81;
            this.label28.Text = "Event ID";
            // 
            // buttonST19StoreDB
            // 
            this.buttonST19StoreDB.Enabled = false;
            this.buttonST19StoreDB.Location = new System.Drawing.Point(366, 596);
            this.buttonST19StoreDB.Name = "buttonST19StoreDB";
            this.buttonST19StoreDB.Size = new System.Drawing.Size(75, 23);
            this.buttonST19StoreDB.TabIndex = 80;
            this.buttonST19StoreDB.Text = "Store in DB";
            this.buttonST19StoreDB.UseVisualStyleBackColor = true;
            this.buttonST19StoreDB.Click += new System.EventHandler(this.buttonST19StoreDB_Click);
            // 
            // buttonST19StoreFile
            // 
            this.buttonST19StoreFile.Enabled = false;
            this.buttonST19StoreFile.Location = new System.Drawing.Point(285, 596);
            this.buttonST19StoreFile.Name = "buttonST19StoreFile";
            this.buttonST19StoreFile.Size = new System.Drawing.Size(75, 23);
            this.buttonST19StoreFile.TabIndex = 79;
            this.buttonST19StoreFile.Text = "Store in File";
            this.buttonST19StoreFile.UseVisualStyleBackColor = true;
            this.buttonST19StoreFile.Click += new System.EventHandler(this.buttonST19StoreFile_Click);
            // 
            // buttonST19Del
            // 
            this.buttonST19Del.Enabled = false;
            this.buttonST19Del.Location = new System.Drawing.Point(383, 312);
            this.buttonST19Del.Name = "buttonST19Del";
            this.buttonST19Del.Size = new System.Drawing.Size(58, 23);
            this.buttonST19Del.TabIndex = 78;
            this.buttonST19Del.Text = "Delete";
            this.buttonST19Del.UseVisualStyleBackColor = true;
            this.buttonST19Del.Click += new System.EventHandler(this.buttonST19Del_Click);
            // 
            // buttonST19Add
            // 
            this.buttonST19Add.Enabled = false;
            this.buttonST19Add.Location = new System.Drawing.Point(319, 312);
            this.buttonST19Add.Name = "buttonST19Add";
            this.buttonST19Add.Size = new System.Drawing.Size(58, 23);
            this.buttonST19Add.TabIndex = 77;
            this.buttonST19Add.Text = "Add";
            this.buttonST19Add.UseVisualStyleBackColor = true;
            this.buttonST19Add.Click += new System.EventHandler(this.buttonST19Add_Click);
            // 
            // treeViewST19
            // 
            this.treeViewST19.Location = new System.Drawing.Point(17, 69);
            this.treeViewST19.Name = "treeViewST19";
            this.treeViewST19.Size = new System.Drawing.Size(426, 230);
            this.treeViewST19.TabIndex = 76;
            this.treeViewST19.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewST19_AfterSelect);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.label32);
            this.tabPage4.Controls.Add(this.textBoxST21ID);
            this.tabPage4.Controls.Add(this.label20);
            this.tabPage4.Controls.Add(this.numericUpDownST21OverallSeq);
            this.tabPage4.Controls.Add(this.label18);
            this.tabPage4.Controls.Add(this.numericUpDownST21Seq);
            this.tabPage4.Controls.Add(this.label19);
            this.tabPage4.Controls.Add(this.labelST21Warning);
            this.tabPage4.Controls.Add(this.textBoxST21Description);
            this.tabPage4.Controls.Add(this.label21);
            this.tabPage4.Controls.Add(this.dataGridViewST21);
            this.tabPage4.Controls.Add(this.numericUpDownST21Delay);
            this.tabPage4.Controls.Add(this.label22);
            this.tabPage4.Controls.Add(this.buttonST21StoreDB);
            this.tabPage4.Controls.Add(this.buttonST21StoreFile);
            this.tabPage4.Controls.Add(this.buttonST21Del);
            this.tabPage4.Controls.Add(this.buttonST21Add);
            this.tabPage4.Controls.Add(this.treeViewST21);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(459, 736);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "ST21 Request Sequencing";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(19, 4);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(119, 16);
            this.label32.TabIndex = 95;
            this.label32.Text = "Create a Sequence";
            // 
            // textBoxST21ID
            // 
            this.textBoxST21ID.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxST21ID.Location = new System.Drawing.Point(38, 595);
            this.textBoxST21ID.MaxLength = global::PUS_tester.Properties.Settings.Default.ST21StringSize;
            this.textBoxST21ID.Name = "textBoxST21ID";
            this.textBoxST21ID.Size = new System.Drawing.Size(124, 20);
            this.textBoxST21ID.TabIndex = 75;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(161, 598);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(56, 13);
            this.label20.TabIndex = 74;
            this.label20.Text = "Sequence";
            // 
            // numericUpDownST21OverallSeq
            // 
            this.numericUpDownST21OverallSeq.Location = new System.Drawing.Point(221, 595);
            this.numericUpDownST21OverallSeq.Maximum = new decimal(new int[] {
            16383,
            0,
            0,
            0});
            this.numericUpDownST21OverallSeq.Name = "numericUpDownST21OverallSeq";
            this.numericUpDownST21OverallSeq.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownST21OverallSeq.TabIndex = 73;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(21, 598);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(18, 13);
            this.label18.TabIndex = 72;
            this.label18.Text = "ID";
            // 
            // numericUpDownST21Seq
            // 
            this.numericUpDownST21Seq.Location = new System.Drawing.Point(221, 310);
            this.numericUpDownST21Seq.Maximum = new decimal(new int[] {
            16383,
            0,
            0,
            0});
            this.numericUpDownST21Seq.Name = "numericUpDownST21Seq";
            this.numericUpDownST21Seq.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownST21Seq.TabIndex = 71;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(159, 312);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 13);
            this.label19.TabIndex = 70;
            this.label19.Text = "Sequence";
            // 
            // labelST21Warning
            // 
            this.labelST21Warning.AutoSize = true;
            this.labelST21Warning.Location = new System.Drawing.Point(22, 562);
            this.labelST21Warning.Name = "labelST21Warning";
            this.labelST21Warning.Size = new System.Drawing.Size(0, 13);
            this.labelST21Warning.TabIndex = 69;
            // 
            // textBoxST21Description
            // 
            this.textBoxST21Description.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxST21Description.Location = new System.Drawing.Point(85, 33);
            this.textBoxST21Description.Name = "textBoxST21Description";
            this.textBoxST21Description.Size = new System.Drawing.Size(360, 20);
            this.textBoxST21Description.TabIndex = 68;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(19, 36);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(60, 13);
            this.label21.TabIndex = 67;
            this.label21.Text = "Description";
            // 
            // dataGridViewST21
            // 
            this.dataGridViewST21.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewST21.Location = new System.Drawing.Point(21, 344);
            this.dataGridViewST21.Name = "dataGridViewST21";
            this.dataGridViewST21.Size = new System.Drawing.Size(424, 211);
            this.dataGridViewST21.TabIndex = 66;
            this.dataGridViewST21.SelectionChanged += new System.EventHandler(this.dataGridViewST21_SelectionChanged);
            // 
            // numericUpDownST21Delay
            // 
            this.numericUpDownST21Delay.Location = new System.Drawing.Point(73, 309);
            this.numericUpDownST21Delay.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.numericUpDownST21Delay.Name = "numericUpDownST21Delay";
            this.numericUpDownST21Delay.Size = new System.Drawing.Size(72, 20);
            this.numericUpDownST21Delay.TabIndex = 65;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(21, 312);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(34, 13);
            this.label22.TabIndex = 64;
            this.label22.Text = "Delay";
            // 
            // buttonST21StoreDB
            // 
            this.buttonST21StoreDB.Enabled = false;
            this.buttonST21StoreDB.Location = new System.Drawing.Point(370, 593);
            this.buttonST21StoreDB.Name = "buttonST21StoreDB";
            this.buttonST21StoreDB.Size = new System.Drawing.Size(75, 23);
            this.buttonST21StoreDB.TabIndex = 63;
            this.buttonST21StoreDB.Text = "Store in DB";
            this.buttonST21StoreDB.UseVisualStyleBackColor = true;
            this.buttonST21StoreDB.Click += new System.EventHandler(this.buttonST21StoreDB_Click);
            // 
            // buttonST21StoreFile
            // 
            this.buttonST21StoreFile.Enabled = false;
            this.buttonST21StoreFile.Location = new System.Drawing.Point(289, 593);
            this.buttonST21StoreFile.Name = "buttonST21StoreFile";
            this.buttonST21StoreFile.Size = new System.Drawing.Size(75, 23);
            this.buttonST21StoreFile.TabIndex = 62;
            this.buttonST21StoreFile.Text = "Store in File";
            this.buttonST21StoreFile.UseVisualStyleBackColor = true;
            this.buttonST21StoreFile.Click += new System.EventHandler(this.buttonST21StoreFile_Click);
            // 
            // buttonST21Del
            // 
            this.buttonST21Del.Enabled = false;
            this.buttonST21Del.Location = new System.Drawing.Point(387, 309);
            this.buttonST21Del.Name = "buttonST21Del";
            this.buttonST21Del.Size = new System.Drawing.Size(58, 23);
            this.buttonST21Del.TabIndex = 61;
            this.buttonST21Del.Text = "Delete";
            this.buttonST21Del.UseVisualStyleBackColor = true;
            this.buttonST21Del.Click += new System.EventHandler(this.buttonST21Del_Click);
            // 
            // buttonST21Add
            // 
            this.buttonST21Add.Enabled = false;
            this.buttonST21Add.Location = new System.Drawing.Point(323, 309);
            this.buttonST21Add.Name = "buttonST21Add";
            this.buttonST21Add.Size = new System.Drawing.Size(58, 23);
            this.buttonST21Add.TabIndex = 60;
            this.buttonST21Add.Text = "Add";
            this.buttonST21Add.UseVisualStyleBackColor = true;
            this.buttonST21Add.Click += new System.EventHandler(this.buttonST21Add_Click);
            // 
            // treeViewST21
            // 
            this.treeViewST21.Location = new System.Drawing.Point(21, 66);
            this.treeViewST21.Name = "treeViewST21";
            this.treeViewST21.Size = new System.Drawing.Size(426, 230);
            this.treeViewST21.TabIndex = 59;
            this.treeViewST21.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewST21_AfterSelect);
            // 
            // openFileDialogBin
            // 
            this.openFileDialogBin.FileName = "*.bin";
            this.openFileDialogBin.Filter = "binary files (*.bin)|*.bin|All files (*.*)|*.*";
            // 
            // openFileDialogXml
            // 
            this.openFileDialogXml.Filter = "\"xml files (*.xml)|*.xml|All files (*.*)|*.*\"";
            // 
            // buttonLoadSend
            // 
            this.buttonLoadSend.Enabled = false;
            this.buttonLoadSend.Location = new System.Drawing.Point(300, 46);
            this.buttonLoadSend.Name = "buttonLoadSend";
            this.buttonLoadSend.Size = new System.Drawing.Size(80, 23);
            this.buttonLoadSend.TabIndex = 28;
            this.buttonLoadSend.Text = "Load && Send";
            this.buttonLoadSend.UseVisualStyleBackColor = true;
            this.buttonLoadSend.Click += new System.EventHandler(this.button7_Click);
            // 
            // groupBoxRAW
            // 
            this.groupBoxRAW.Controls.Add(this.button8);
            this.groupBoxRAW.Controls.Add(this.textBoxRawFile);
            this.groupBoxRAW.Controls.Add(this.label5);
            this.groupBoxRAW.Controls.Add(this.buttonLoadSend);
            this.groupBoxRAW.Enabled = false;
            this.groupBoxRAW.Location = new System.Drawing.Point(494, 418);
            this.groupBoxRAW.Name = "groupBoxRAW";
            this.groupBoxRAW.Size = new System.Drawing.Size(390, 76);
            this.groupBoxRAW.TabIndex = 35;
            this.groupBoxRAW.TabStop = false;
            this.groupBoxRAW.Text = "Send Raw Data";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(322, 17);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(58, 23);
            this.button8.TabIndex = 34;
            this.button8.Text = "File";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // textBoxRawFile
            // 
            this.textBoxRawFile.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxRawFile.Location = new System.Drawing.Point(37, 19);
            this.textBoxRawFile.Name = "textBoxRawFile";
            this.textBoxRawFile.Size = new System.Drawing.Size(279, 20);
            this.textBoxRawFile.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "File";
            // 
            // saveFileDialogBin
            // 
            this.saveFileDialogBin.FileName = "*.bin";
            this.saveFileDialogBin.Filter = "binary files (*.bin)|*.bin|All files (*.*)|*.*";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1372, 785);
            this.Controls.Add(this.groupBoxRAW);
            this.Controls.Add(this.groupBoxTelecommand);
            this.Controls.Add(this.tabControlSpecialGUI);
            this.Controls.Add(this.groupBoxSerialData);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxSerialPort);
            this.Controls.Add(this.treeViewTlcmd);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "PUS tester";
            this.groupBoxTelecommand.ResumeLayout(false);
            this.groupBoxTelecommand.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeq)).EndInit();
            this.groupBoxAck.ResumeLayout(false);
            this.groupBoxAck.PerformLayout();
            this.groupBoxPayloadTx.ResumeLayout(false);
            this.groupBoxPayloadTx.PerformLayout();
            this.groupBoxSend.ResumeLayout(false);
            this.groupBoxSend.PerformLayout();
            this.groupBoxSerialPort.ResumeLayout(false);
            this.groupBoxSerialPort.PerformLayout();
            this.groupBoxReceive.ResumeLayout(false);
            this.groupBoxReceive.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxSerialData.ResumeLayout(false);
            this.tabControlSpecialGUI.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMemID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownST06Seq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewST06)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownST11OverallSeq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownST11Seq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewST11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownST11Release)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownST12ID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownST13Seq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownST19AppID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownST19OverallSeq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownST19Seq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewST19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownST19EventID)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownST21OverallSeq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownST21Seq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewST21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownST21Delay)).EndInit();
            this.groupBoxRAW.ResumeLayout(false);
            this.groupBoxRAW.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewTlcmd;
        private System.Windows.Forms.Button buttonSendTC;
        private System.Windows.Forms.GroupBox groupBoxTelecommand;
        private System.Windows.Forms.Label labelServiceSubTypeTx;
        private System.Windows.Forms.TextBox textBoxServiceSubTypeTx;
        private System.Windows.Forms.Label labelServiceTypeTx;
        private System.Windows.Forms.TextBox textBoxServiceTypeTx;
        private System.Windows.Forms.Label labelSizeTx;
        private System.Windows.Forms.TextBox textBoxSizeTx;
        private System.Windows.Forms.Label labelCRC;
        private System.Windows.Forms.TextBox textBoxPayloadTx;
        private System.Windows.Forms.GroupBox groupBoxPayloadTx;
        private System.Windows.Forms.GroupBox groupBoxAck;
        private System.Windows.Forms.CheckBox checkBoxAckAcc;
        private System.Windows.Forms.CheckBox checkBoxAckProg;
        private System.Windows.Forms.CheckBox checkBoxAckComp;
        private System.Windows.Forms.CheckBox checkBoxAckExec;
        private System.Windows.Forms.GroupBox groupBoxSend;
        private System.Windows.Forms.TextBox textBoxSend;
        private System.Windows.Forms.Button buttonEditTC;
        private System.Windows.Forms.Button buttonCloseUart;
        private System.Windows.Forms.Button buttonOpenUart;
        private System.Windows.Forms.GroupBox groupBoxSerialPort;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxRS422bps;
        private System.Windows.Forms.Label labelTitleRS422;
        private System.Windows.Forms.ComboBox comboBoxRS422;
        private System.Windows.Forms.Label labelSend;
        private System.Windows.Forms.GroupBox groupBoxReceive;
        private System.Windows.Forms.TextBox textBoxReceive;
        private System.Windows.Forms.Button buttonViewReport;
        private System.Windows.Forms.Label labelErrorRx;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelNFracTime;
        private System.Windows.Forms.CheckBox checkBoxPField;
        private System.Windows.Forms.Label labelNBasicTime;
        private System.Windows.Forms.ComboBox comboBoxNFracTime;
        private System.Windows.Forms.ComboBox comboBoxNBasicTime;
        private System.Windows.Forms.Label labelOBTType;
        private System.Windows.Forms.ComboBox comboBoxOBTType;
        private System.Windows.Forms.DateTimePicker dateTimePickerEpoch;
        private System.Windows.Forms.Label labelEpoch;
        private System.Windows.Forms.Label labelRS422;
        private System.Windows.Forms.GroupBox groupBoxSerialData;
        private System.Windows.Forms.CheckBox checkBoxCRC;
        private System.Windows.Forms.Button buttonSaveTC;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Button buttonDelTC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownSeq;
        private System.Windows.Forms.TabControl tabControlSpecialGUI;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.OpenFileDialog openFileDialogBin;
        private System.Windows.Forms.Button buttonLoadSend;
        private System.Windows.Forms.Button buttonST13StoreFile;
        private System.Windows.Forms.Button buttonST13OpenBin;
        private System.Windows.Forms.TextBox textBoxST13FileBin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialogXml;
        private System.Windows.Forms.Button buttonST13StoreDB;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBoxRAW;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox textBoxRawFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelST14Warning;
        private System.Windows.Forms.NumericUpDown numericUpDownST13Seq;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownST12ID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.SaveFileDialog saveFileDialogBin;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button buttonST06Del;
        private System.Windows.Forms.Button buttonST06Add;
        private System.Windows.Forms.Button buttonST06StoreDB;
        private System.Windows.Forms.Button buttonST06StoreFile;
        private System.Windows.Forms.TextBox textBoxST06Memory;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonST06File;
        private System.Windows.Forms.TextBox textBoxST06File;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelST6Warning;
        private System.Windows.Forms.Button buttonST11StoreDB;
        private System.Windows.Forms.Button buttonST11StoreFile;
        private System.Windows.Forms.Button buttonST11Del;
        private System.Windows.Forms.Button buttonST11Add;
        private System.Windows.Forms.TreeView treeViewST11;
        private System.Windows.Forms.DataGridView dataGridViewST06;
        private System.Windows.Forms.Label labelST06Warning;
        private System.Windows.Forms.NumericUpDown numericUpDownST06Seq;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDownMemID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dataGridViewST11;
        private System.Windows.Forms.NumericUpDown numericUpDownST11Release;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxST06Description;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxST13Description;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label labelST11Warning;
        private System.Windows.Forms.TextBox textBoxST11Description;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown numericUpDownST11Seq;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown numericUpDownST11OverallSeq;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown numericUpDownST21OverallSeq;
        private System.Windows.Forms.NumericUpDown numericUpDownST21Seq;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label labelST21Warning;
        private System.Windows.Forms.TextBox textBoxST21Description;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DataGridView dataGridViewST21;
        private System.Windows.Forms.NumericUpDown numericUpDownST21Delay;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button buttonST21StoreDB;
        private System.Windows.Forms.Button buttonST21StoreFile;
        private System.Windows.Forms.Button buttonST21Del;
        private System.Windows.Forms.Button buttonST21Add;
        private System.Windows.Forms.TreeView treeViewST21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.NumericUpDown numericUpDownST19AppID;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown numericUpDownST19OverallSeq;
        private System.Windows.Forms.NumericUpDown numericUpDownST19Seq;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label labelST19Warning;
        private System.Windows.Forms.TextBox textBoxST19Description;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.DataGridView dataGridViewST19;
        private System.Windows.Forms.NumericUpDown numericUpDownST19EventID;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button buttonST19StoreDB;
        private System.Windows.Forms.Button buttonST19StoreFile;
        private System.Windows.Forms.Button buttonST19Del;
        private System.Windows.Forms.Button buttonST19Add;
        private System.Windows.Forms.TreeView treeViewST19;
        private System.Windows.Forms.TextBox textBoxST21ID;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.HelpProvider helpProviderPUS;
    }
}

