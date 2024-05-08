
namespace PUS_tester
{
    partial class FormRequestST03_01
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
            this.groupBoxPayload = new System.Windows.Forms.GroupBox();
            this.textBoxPayload = new System.Windows.Forms.TextBox();
            this.numericUpDownStructID = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCommit = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownN1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
            this.labelNFA = new System.Windows.Forms.Label();
            this.numericUpDownNFA = new System.Windows.Forms.NumericUpDown();
            this.groupBoxPayload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStructID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownN1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNFA)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxPayload
            // 
            this.groupBoxPayload.Controls.Add(this.textBoxPayload);
            this.groupBoxPayload.Location = new System.Drawing.Point(22, 12);
            this.groupBoxPayload.Name = "groupBoxPayload";
            this.groupBoxPayload.Size = new System.Drawing.Size(540, 92);
            this.groupBoxPayload.TabIndex = 27;
            this.groupBoxPayload.TabStop = false;
            this.groupBoxPayload.Text = "Payload";
            // 
            // textBoxPayload
            // 
            this.textBoxPayload.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxPayload.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold);
            this.textBoxPayload.Location = new System.Drawing.Point(6, 19);
            this.textBoxPayload.Multiline = true;
            this.textBoxPayload.Name = "textBoxPayload";
            this.textBoxPayload.ReadOnly = true;
            this.textBoxPayload.Size = new System.Drawing.Size(525, 62);
            this.textBoxPayload.TabIndex = 24;
            // 
            // numericUpDownStructID
            // 
            this.numericUpDownStructID.Location = new System.Drawing.Point(96, 141);
            this.numericUpDownStructID.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownStructID.Name = "numericUpDownStructID";
            this.numericUpDownStructID.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownStructID.TabIndex = 28;
            this.numericUpDownStructID.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Structure ID";
            // 
            // buttonCommit
            // 
            this.buttonCommit.Location = new System.Drawing.Point(487, 112);
            this.buttonCommit.Name = "buttonCommit";
            this.buttonCommit.Size = new System.Drawing.Size(75, 23);
            this.buttonCommit.TabIndex = 30;
            this.buttonCommit.Text = "Commit";
            this.buttonCommit.UseVisualStyleBackColor = true;
            this.buttonCommit.Click += new System.EventHandler(this.buttonCommit_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(22, 112);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 31;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "N1";
            // 
            // numericUpDownN1
            // 
            this.numericUpDownN1.Location = new System.Drawing.Point(96, 193);
            this.numericUpDownN1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownN1.Name = "numericUpDownN1";
            this.numericUpDownN1.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownN1.TabIndex = 32;
            this.numericUpDownN1.ValueChanged += new System.EventHandler(this.numericUpDownN1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Interval";
            // 
            // numericUpDownInterval
            // 
            this.numericUpDownInterval.Location = new System.Drawing.Point(96, 167);
            this.numericUpDownInterval.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownInterval.Name = "numericUpDownInterval";
            this.numericUpDownInterval.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownInterval.TabIndex = 34;
            this.numericUpDownInterval.ValueChanged += new System.EventHandler(this.numericUpDownInterval_ValueChanged_1);
            // 
            // labelNFA
            // 
            this.labelNFA.AutoSize = true;
            this.labelNFA.Location = new System.Drawing.Point(26, 221);
            this.labelNFA.Name = "labelNFA";
            this.labelNFA.Size = new System.Drawing.Size(28, 13);
            this.labelNFA.TabIndex = 37;
            this.labelNFA.Text = "NFA";
            // 
            // numericUpDownNFA
            // 
            this.numericUpDownNFA.Location = new System.Drawing.Point(96, 219);
            this.numericUpDownNFA.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownNFA.Name = "numericUpDownNFA";
            this.numericUpDownNFA.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownNFA.TabIndex = 36;
            this.numericUpDownNFA.ValueChanged += new System.EventHandler(this.numericUpDownNFA_ValueChanged);
            // 
            // FormRequestST3_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(599, 450);
            this.Controls.Add(this.labelNFA);
            this.Controls.Add(this.numericUpDownNFA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDownInterval);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownN1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonCommit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownStructID);
            this.Controls.Add(this.groupBoxPayload);
            this.Name = "FormRequestST3_1";
            this.Text = "ST[03,01] Create Housekeeping Report Structure";
            this.groupBoxPayload.ResumeLayout(false);
            this.groupBoxPayload.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStructID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownN1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNFA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxPayload;
        private System.Windows.Forms.TextBox textBoxPayload;
        private System.Windows.Forms.NumericUpDown numericUpDownStructID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCommit;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownN1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownInterval;
        private System.Windows.Forms.Label labelNFA;
        private System.Windows.Forms.NumericUpDown numericUpDownNFA;
    }
}