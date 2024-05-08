
namespace PUS_tester
{
    partial class FormRequestST13_11
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
            this.buttonCommit = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxFunctionData = new System.Windows.Forms.TextBox();
            this.numericUpDownID = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.labelPartSeq = new System.Windows.Forms.Label();
            this.groupBoxPayload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Data (hex string)";
            // 
            // textBoxFunctionData
            // 
            this.textBoxFunctionData.Location = new System.Drawing.Point(119, 205);
            this.textBoxFunctionData.Name = "textBoxFunctionData";
            this.textBoxFunctionData.Size = new System.Drawing.Size(434, 20);
            this.textBoxFunctionData.TabIndex = 40;
            this.textBoxFunctionData.TextChanged += new System.EventHandler(this.textBoxFunctionArg_TextChanged);
            // 
            // numericUpDownID
            // 
            this.numericUpDownID.Location = new System.Drawing.Point(119, 151);
            this.numericUpDownID.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownID.Name = "numericUpDownID";
            this.numericUpDownID.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownID.TabIndex = 41;
            this.numericUpDownID.ValueChanged += new System.EventHandler(this.numericUpDownID_ValueChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.numericUpDown1.Location = new System.Drawing.Point(119, 179);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(67, 20);
            this.numericUpDown1.TabIndex = 43;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // labelPartSeq
            // 
            this.labelPartSeq.AutoSize = true;
            this.labelPartSeq.Location = new System.Drawing.Point(29, 181);
            this.labelPartSeq.Name = "labelPartSeq";
            this.labelPartSeq.Size = new System.Drawing.Size(46, 13);
            this.labelPartSeq.TabIndex = 42;
            this.labelPartSeq.Text = "Part seq";
            // 
            // FormRequestST13_11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 247);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.labelPartSeq);
            this.Controls.Add(this.numericUpDownID);
            this.Controls.Add(this.textBoxFunctionData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonCommit);
            this.Controls.Add(this.groupBoxPayload);
            this.Name = "FormRequestST13_11";
            this.Text = "ST[13,11] Uplink Last Part";
            this.groupBoxPayload.ResumeLayout(false);
            this.groupBoxPayload.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxPayload;
        private System.Windows.Forms.TextBox textBoxPayload;
        private System.Windows.Forms.Button buttonCommit;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxFunctionData;
        private System.Windows.Forms.NumericUpDown numericUpDownID;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label labelPartSeq;
    }
}