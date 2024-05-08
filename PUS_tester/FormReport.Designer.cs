
namespace PUS_tester
{
    partial class FormReport
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
            this.labelOBT = new System.Windows.Forms.Label();
            this.labelAPID = new System.Windows.Forms.Label();
            this.labelServiceType = new System.Windows.Forms.Label();
            this.labelServiceSubType = new System.Windows.Forms.Label();
            this.textBoxAPID = new System.Windows.Forms.TextBox();
            this.textBoxOBT = new System.Windows.Forms.TextBox();
            this.textBoxServiceType = new System.Windows.Forms.TextBox();
            this.textBoxServiceSubType = new System.Windows.Forms.TextBox();
            this.groupBoxPrimaryHeader = new System.Windows.Forms.GroupBox();
            this.textBoxSize = new System.Windows.Forms.TextBox();
            this.labelPktVersion = new System.Windows.Forms.Label();
            this.labelSize = new System.Windows.Forms.Label();
            this.textBoxPktVersion = new System.Windows.Forms.TextBox();
            this.textBoxSeqCounter = new System.Windows.Forms.TextBox();
            this.labelSeqCounter = new System.Windows.Forms.Label();
            this.textBoxSeqFlags = new System.Windows.Forms.TextBox();
            this.checkBoxPktTypeTM = new System.Windows.Forms.CheckBox();
            this.labelSeqFlags = new System.Windows.Forms.Label();
            this.checkBoxPktTypeTC = new System.Windows.Forms.CheckBox();
            this.checkBoxSecondaryHeader = new System.Windows.Forms.CheckBox();
            this.groupBoxSecondaryHeader = new System.Windows.Forms.GroupBox();
            this.labelDstID = new System.Windows.Forms.Label();
            this.labelPUSVersion = new System.Windows.Forms.Label();
            this.textBoxDstID = new System.Windows.Forms.TextBox();
            this.textBoxPUSVersion = new System.Windows.Forms.TextBox();
            this.labelMsgCounter = new System.Windows.Forms.Label();
            this.textBoxMsgCounter = new System.Windows.Forms.TextBox();
            this.textBoxSCTimeRef = new System.Windows.Forms.TextBox();
            this.labelSCTimeRef = new System.Windows.Forms.Label();
            this.groupBoxPayload = new System.Windows.Forms.GroupBox();
            this.labelCRC = new System.Windows.Forms.Label();
            this.textBoxOBTFrac = new System.Windows.Forms.TextBox();
            this.textBoxPayload = new System.Windows.Forms.TextBox();
            this.groupBoxPrimaryHeader.SuspendLayout();
            this.groupBoxSecondaryHeader.SuspendLayout();
            this.groupBoxPayload.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelOBT
            // 
            this.labelOBT.AutoSize = true;
            this.labelOBT.Location = new System.Drawing.Point(6, 22);
            this.labelOBT.Name = "labelOBT";
            this.labelOBT.Size = new System.Drawing.Size(32, 13);
            this.labelOBT.TabIndex = 0;
            this.labelOBT.Text = "OBT:";
            // 
            // labelAPID
            // 
            this.labelAPID.AutoSize = true;
            this.labelAPID.Location = new System.Drawing.Point(40, 98);
            this.labelAPID.Name = "labelAPID";
            this.labelAPID.Size = new System.Drawing.Size(35, 13);
            this.labelAPID.TabIndex = 1;
            this.labelAPID.Text = "APID:";
            // 
            // labelServiceType
            // 
            this.labelServiceType.AutoSize = true;
            this.labelServiceType.Location = new System.Drawing.Point(6, 77);
            this.labelServiceType.Name = "labelServiceType";
            this.labelServiceType.Size = new System.Drawing.Size(73, 13);
            this.labelServiceType.TabIndex = 2;
            this.labelServiceType.Text = "Service Type:";
            // 
            // labelServiceSubType
            // 
            this.labelServiceSubType.AutoSize = true;
            this.labelServiceSubType.Location = new System.Drawing.Point(144, 77);
            this.labelServiceSubType.Name = "labelServiceSubType";
            this.labelServiceSubType.Size = new System.Drawing.Size(95, 13);
            this.labelServiceSubType.TabIndex = 3;
            this.labelServiceSubType.Text = "Service Sub Type:";
            // 
            // textBoxAPID
            // 
            this.textBoxAPID.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxAPID.Location = new System.Drawing.Point(81, 95);
            this.textBoxAPID.Name = "textBoxAPID";
            this.textBoxAPID.ReadOnly = true;
            this.textBoxAPID.Size = new System.Drawing.Size(33, 20);
            this.textBoxAPID.TabIndex = 17;
            // 
            // textBoxOBT
            // 
            this.textBoxOBT.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxOBT.Location = new System.Drawing.Point(44, 19);
            this.textBoxOBT.Name = "textBoxOBT";
            this.textBoxOBT.ReadOnly = true;
            this.textBoxOBT.Size = new System.Drawing.Size(77, 20);
            this.textBoxOBT.TabIndex = 18;
            // 
            // textBoxServiceType
            // 
            this.textBoxServiceType.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxServiceType.Location = new System.Drawing.Point(103, 74);
            this.textBoxServiceType.Name = "textBoxServiceType";
            this.textBoxServiceType.ReadOnly = true;
            this.textBoxServiceType.Size = new System.Drawing.Size(33, 20);
            this.textBoxServiceType.TabIndex = 19;
            // 
            // textBoxServiceSubType
            // 
            this.textBoxServiceSubType.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxServiceSubType.Location = new System.Drawing.Point(241, 74);
            this.textBoxServiceSubType.Name = "textBoxServiceSubType";
            this.textBoxServiceSubType.ReadOnly = true;
            this.textBoxServiceSubType.Size = new System.Drawing.Size(33, 20);
            this.textBoxServiceSubType.TabIndex = 20;
            // 
            // groupBoxPrimaryHeader
            // 
            this.groupBoxPrimaryHeader.Controls.Add(this.textBoxSize);
            this.groupBoxPrimaryHeader.Controls.Add(this.labelPktVersion);
            this.groupBoxPrimaryHeader.Controls.Add(this.labelSize);
            this.groupBoxPrimaryHeader.Controls.Add(this.textBoxPktVersion);
            this.groupBoxPrimaryHeader.Controls.Add(this.textBoxSeqCounter);
            this.groupBoxPrimaryHeader.Controls.Add(this.labelAPID);
            this.groupBoxPrimaryHeader.Controls.Add(this.labelSeqCounter);
            this.groupBoxPrimaryHeader.Controls.Add(this.textBoxAPID);
            this.groupBoxPrimaryHeader.Controls.Add(this.textBoxSeqFlags);
            this.groupBoxPrimaryHeader.Controls.Add(this.checkBoxPktTypeTM);
            this.groupBoxPrimaryHeader.Controls.Add(this.labelSeqFlags);
            this.groupBoxPrimaryHeader.Controls.Add(this.checkBoxPktTypeTC);
            this.groupBoxPrimaryHeader.Controls.Add(this.checkBoxSecondaryHeader);
            this.groupBoxPrimaryHeader.Location = new System.Drawing.Point(9, 12);
            this.groupBoxPrimaryHeader.Name = "groupBoxPrimaryHeader";
            this.groupBoxPrimaryHeader.Size = new System.Drawing.Size(239, 179);
            this.groupBoxPrimaryHeader.TabIndex = 21;
            this.groupBoxPrimaryHeader.TabStop = false;
            this.groupBoxPrimaryHeader.Text = "Primary header";
            // 
            // textBoxSize
            // 
            this.textBoxSize.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxSize.Location = new System.Drawing.Point(81, 147);
            this.textBoxSize.Name = "textBoxSize";
            this.textBoxSize.ReadOnly = true;
            this.textBoxSize.Size = new System.Drawing.Size(33, 20);
            this.textBoxSize.TabIndex = 31;
            // 
            // labelPktVersion
            // 
            this.labelPktVersion.AutoSize = true;
            this.labelPktVersion.Location = new System.Drawing.Point(6, 26);
            this.labelPktVersion.Name = "labelPktVersion";
            this.labelPktVersion.Size = new System.Drawing.Size(64, 13);
            this.labelPktVersion.TabIndex = 21;
            this.labelPktVersion.Text = "Pkt Version:";
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(40, 150);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(30, 13);
            this.labelSize.TabIndex = 30;
            this.labelSize.Text = "Size:";
            // 
            // textBoxPktVersion
            // 
            this.textBoxPktVersion.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxPktVersion.Location = new System.Drawing.Point(81, 23);
            this.textBoxPktVersion.Name = "textBoxPktVersion";
            this.textBoxPktVersion.ReadOnly = true;
            this.textBoxPktVersion.Size = new System.Drawing.Size(33, 20);
            this.textBoxPktVersion.TabIndex = 22;
            // 
            // textBoxSeqCounter
            // 
            this.textBoxSeqCounter.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxSeqCounter.Location = new System.Drawing.Point(186, 121);
            this.textBoxSeqCounter.Name = "textBoxSeqCounter";
            this.textBoxSeqCounter.ReadOnly = true;
            this.textBoxSeqCounter.Size = new System.Drawing.Size(48, 20);
            this.textBoxSeqCounter.TabIndex = 29;
            // 
            // labelSeqCounter
            // 
            this.labelSeqCounter.AutoSize = true;
            this.labelSeqCounter.Location = new System.Drawing.Point(118, 124);
            this.labelSeqCounter.Name = "labelSeqCounter";
            this.labelSeqCounter.Size = new System.Drawing.Size(71, 13);
            this.labelSeqCounter.TabIndex = 28;
            this.labelSeqCounter.Text = "Seq. counter:";
            // 
            // textBoxSeqFlags
            // 
            this.textBoxSeqFlags.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxSeqFlags.Location = new System.Drawing.Point(81, 121);
            this.textBoxSeqFlags.Name = "textBoxSeqFlags";
            this.textBoxSeqFlags.ReadOnly = true;
            this.textBoxSeqFlags.Size = new System.Drawing.Size(33, 20);
            this.textBoxSeqFlags.TabIndex = 27;
            // 
            // checkBoxPktTypeTM
            // 
            this.checkBoxPktTypeTM.AutoSize = true;
            this.checkBoxPktTypeTM.Location = new System.Drawing.Point(23, 49);
            this.checkBoxPktTypeTM.Name = "checkBoxPktTypeTM";
            this.checkBoxPktTypeTM.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxPktTypeTM.Size = new System.Drawing.Size(91, 17);
            this.checkBoxPktTypeTM.TabIndex = 23;
            this.checkBoxPktTypeTM.Text = "Telemetry Pkt";
            this.checkBoxPktTypeTM.UseVisualStyleBackColor = true;
            // 
            // labelSeqFlags
            // 
            this.labelSeqFlags.AutoSize = true;
            this.labelSeqFlags.Location = new System.Drawing.Point(22, 124);
            this.labelSeqFlags.Name = "labelSeqFlags";
            this.labelSeqFlags.Size = new System.Drawing.Size(57, 13);
            this.labelSeqFlags.TabIndex = 26;
            this.labelSeqFlags.Text = "Seq. flags:";
            // 
            // checkBoxPktTypeTC
            // 
            this.checkBoxPktTypeTC.AutoSize = true;
            this.checkBoxPktTypeTC.Location = new System.Drawing.Point(121, 49);
            this.checkBoxPktTypeTC.Name = "checkBoxPktTypeTC";
            this.checkBoxPktTypeTC.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxPktTypeTC.Size = new System.Drawing.Size(104, 17);
            this.checkBoxPktTypeTC.TabIndex = 24;
            this.checkBoxPktTypeTC.Text = "Telecomand Pkt";
            this.checkBoxPktTypeTC.UseVisualStyleBackColor = true;
            // 
            // checkBoxSecondaryHeader
            // 
            this.checkBoxSecondaryHeader.AutoSize = true;
            this.checkBoxSecondaryHeader.Location = new System.Drawing.Point(-1, 72);
            this.checkBoxSecondaryHeader.Name = "checkBoxSecondaryHeader";
            this.checkBoxSecondaryHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxSecondaryHeader.Size = new System.Drawing.Size(115, 17);
            this.checkBoxSecondaryHeader.TabIndex = 25;
            this.checkBoxSecondaryHeader.Text = "Secondary Header";
            this.checkBoxSecondaryHeader.UseVisualStyleBackColor = true;
            // 
            // groupBoxSecondaryHeader
            // 
            this.groupBoxSecondaryHeader.Controls.Add(this.labelDstID);
            this.groupBoxSecondaryHeader.Controls.Add(this.labelPUSVersion);
            this.groupBoxSecondaryHeader.Controls.Add(this.textBoxDstID);
            this.groupBoxSecondaryHeader.Controls.Add(this.textBoxPUSVersion);
            this.groupBoxSecondaryHeader.Controls.Add(this.labelMsgCounter);
            this.groupBoxSecondaryHeader.Controls.Add(this.textBoxServiceType);
            this.groupBoxSecondaryHeader.Controls.Add(this.textBoxMsgCounter);
            this.groupBoxSecondaryHeader.Controls.Add(this.textBoxServiceSubType);
            this.groupBoxSecondaryHeader.Controls.Add(this.labelServiceType);
            this.groupBoxSecondaryHeader.Controls.Add(this.textBoxSCTimeRef);
            this.groupBoxSecondaryHeader.Controls.Add(this.labelSCTimeRef);
            this.groupBoxSecondaryHeader.Controls.Add(this.labelServiceSubType);
            this.groupBoxSecondaryHeader.Location = new System.Drawing.Point(254, 12);
            this.groupBoxSecondaryHeader.Name = "groupBoxSecondaryHeader";
            this.groupBoxSecondaryHeader.Size = new System.Drawing.Size(294, 179);
            this.groupBoxSecondaryHeader.TabIndex = 22;
            this.groupBoxSecondaryHeader.TabStop = false;
            this.groupBoxSecondaryHeader.Text = "Secondary header";
            // 
            // labelDstID
            // 
            this.labelDstID.AutoSize = true;
            this.labelDstID.Location = new System.Drawing.Point(6, 128);
            this.labelDstID.Name = "labelDstID";
            this.labelDstID.Size = new System.Drawing.Size(77, 13);
            this.labelDstID.TabIndex = 38;
            this.labelDstID.Text = "Destination ID:";
            // 
            // labelPUSVersion
            // 
            this.labelPUSVersion.AutoSize = true;
            this.labelPUSVersion.Location = new System.Drawing.Point(28, 23);
            this.labelPUSVersion.Name = "labelPUSVersion";
            this.labelPUSVersion.Size = new System.Drawing.Size(70, 13);
            this.labelPUSVersion.TabIndex = 32;
            this.labelPUSVersion.Text = "PUS Version:";
            // 
            // textBoxDstID
            // 
            this.textBoxDstID.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxDstID.Location = new System.Drawing.Point(103, 125);
            this.textBoxDstID.Name = "textBoxDstID";
            this.textBoxDstID.ReadOnly = true;
            this.textBoxDstID.Size = new System.Drawing.Size(33, 20);
            this.textBoxDstID.TabIndex = 39;
            // 
            // textBoxPUSVersion
            // 
            this.textBoxPUSVersion.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxPUSVersion.Location = new System.Drawing.Point(103, 20);
            this.textBoxPUSVersion.Name = "textBoxPUSVersion";
            this.textBoxPUSVersion.ReadOnly = true;
            this.textBoxPUSVersion.Size = new System.Drawing.Size(33, 20);
            this.textBoxPUSVersion.TabIndex = 33;
            // 
            // labelMsgCounter
            // 
            this.labelMsgCounter.AutoSize = true;
            this.labelMsgCounter.Location = new System.Drawing.Point(6, 102);
            this.labelMsgCounter.Name = "labelMsgCounter";
            this.labelMsgCounter.Size = new System.Drawing.Size(92, 13);
            this.labelMsgCounter.TabIndex = 36;
            this.labelMsgCounter.Text = "Msg type counter:";
            // 
            // textBoxMsgCounter
            // 
            this.textBoxMsgCounter.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxMsgCounter.Location = new System.Drawing.Point(103, 99);
            this.textBoxMsgCounter.Name = "textBoxMsgCounter";
            this.textBoxMsgCounter.ReadOnly = true;
            this.textBoxMsgCounter.Size = new System.Drawing.Size(33, 20);
            this.textBoxMsgCounter.TabIndex = 37;
            // 
            // textBoxSCTimeRef
            // 
            this.textBoxSCTimeRef.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxSCTimeRef.Location = new System.Drawing.Point(103, 48);
            this.textBoxSCTimeRef.Name = "textBoxSCTimeRef";
            this.textBoxSCTimeRef.ReadOnly = true;
            this.textBoxSCTimeRef.Size = new System.Drawing.Size(33, 20);
            this.textBoxSCTimeRef.TabIndex = 35;
            // 
            // labelSCTimeRef
            // 
            this.labelSCTimeRef.AutoSize = true;
            this.labelSCTimeRef.Location = new System.Drawing.Point(28, 51);
            this.labelSCTimeRef.Name = "labelSCTimeRef";
            this.labelSCTimeRef.Size = new System.Drawing.Size(70, 13);
            this.labelSCTimeRef.TabIndex = 34;
            this.labelSCTimeRef.Text = "SC Time Ref:";
            // 
            // groupBoxPayload
            // 
            this.groupBoxPayload.Controls.Add(this.labelCRC);
            this.groupBoxPayload.Controls.Add(this.textBoxOBTFrac);
            this.groupBoxPayload.Controls.Add(this.textBoxPayload);
            this.groupBoxPayload.Controls.Add(this.textBoxOBT);
            this.groupBoxPayload.Controls.Add(this.labelOBT);
            this.groupBoxPayload.Location = new System.Drawing.Point(9, 197);
            this.groupBoxPayload.Name = "groupBoxPayload";
            this.groupBoxPayload.Size = new System.Drawing.Size(540, 122);
            this.groupBoxPayload.TabIndex = 23;
            this.groupBoxPayload.TabStop = false;
            this.groupBoxPayload.Text = "Payload";
            // 
            // labelCRC
            // 
            this.labelCRC.AutoSize = true;
            this.labelCRC.Location = new System.Drawing.Point(403, 20);
            this.labelCRC.Name = "labelCRC";
            this.labelCRC.Size = new System.Drawing.Size(10, 13);
            this.labelCRC.TabIndex = 26;
            this.labelCRC.Text = "-";
            // 
            // textBoxOBTFrac
            // 
            this.textBoxOBTFrac.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxOBTFrac.Location = new System.Drawing.Point(127, 19);
            this.textBoxOBTFrac.Name = "textBoxOBTFrac";
            this.textBoxOBTFrac.ReadOnly = true;
            this.textBoxOBTFrac.Size = new System.Drawing.Size(77, 20);
            this.textBoxOBTFrac.TabIndex = 25;
            // 
            // textBoxPayload
            // 
            this.textBoxPayload.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxPayload.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold);
            this.textBoxPayload.Location = new System.Drawing.Point(9, 45);
            this.textBoxPayload.Multiline = true;
            this.textBoxPayload.Name = "textBoxPayload";
            this.textBoxPayload.ReadOnly = true;
            this.textBoxPayload.Size = new System.Drawing.Size(525, 62);
            this.textBoxPayload.TabIndex = 24;
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(560, 328);
            this.Controls.Add(this.groupBoxPayload);
            this.Controls.Add(this.groupBoxSecondaryHeader);
            this.Controls.Add(this.groupBoxPrimaryHeader);
            this.Name = "FormReport";
            this.Text = "FormReport";
            this.groupBoxPrimaryHeader.ResumeLayout(false);
            this.groupBoxPrimaryHeader.PerformLayout();
            this.groupBoxSecondaryHeader.ResumeLayout(false);
            this.groupBoxSecondaryHeader.PerformLayout();
            this.groupBoxPayload.ResumeLayout(false);
            this.groupBoxPayload.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelOBT;
        private System.Windows.Forms.Label labelAPID;
        private System.Windows.Forms.Label labelServiceType;
        private System.Windows.Forms.Label labelServiceSubType;
        private System.Windows.Forms.TextBox textBoxAPID;
        private System.Windows.Forms.TextBox textBoxOBT;
        private System.Windows.Forms.TextBox textBoxServiceType;
        private System.Windows.Forms.TextBox textBoxServiceSubType;
        private System.Windows.Forms.GroupBox groupBoxPrimaryHeader;
        private System.Windows.Forms.GroupBox groupBoxSecondaryHeader;
        private System.Windows.Forms.TextBox textBoxSize;
        private System.Windows.Forms.Label labelPktVersion;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.TextBox textBoxPktVersion;
        private System.Windows.Forms.TextBox textBoxSeqCounter;
        private System.Windows.Forms.Label labelSeqCounter;
        private System.Windows.Forms.TextBox textBoxSeqFlags;
        private System.Windows.Forms.CheckBox checkBoxPktTypeTM;
        private System.Windows.Forms.Label labelSeqFlags;
        private System.Windows.Forms.CheckBox checkBoxPktTypeTC;
        private System.Windows.Forms.CheckBox checkBoxSecondaryHeader;
        private System.Windows.Forms.Label labelDstID;
        private System.Windows.Forms.Label labelPUSVersion;
        private System.Windows.Forms.TextBox textBoxDstID;
        private System.Windows.Forms.TextBox textBoxPUSVersion;
        private System.Windows.Forms.Label labelMsgCounter;
        private System.Windows.Forms.TextBox textBoxMsgCounter;
        private System.Windows.Forms.TextBox textBoxSCTimeRef;
        private System.Windows.Forms.Label labelSCTimeRef;
        private System.Windows.Forms.GroupBox groupBoxPayload;
        private System.Windows.Forms.TextBox textBoxPayload;
        private System.Windows.Forms.TextBox textBoxOBTFrac;
        private System.Windows.Forms.Label labelCRC;
    }
}