
namespace PUS_tester
{
    partial class FormRequestST23_15
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
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.numericUpDownOpsID = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.textBoxTofilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxPayload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOpsID)).BeginInit();
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
            this.label3.Location = new System.Drawing.Point(29, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "From File Path";
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Location = new System.Drawing.Point(106, 175);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(456, 20);
            this.textBoxFilePath.TabIndex = 38;
            this.textBoxFilePath.TextChanged += new System.EventHandler(this.textBoxFunctionName_TextChanged);
            // 
            // numericUpDownOpsID
            // 
            this.numericUpDownOpsID.Location = new System.Drawing.Point(106, 149);
            this.numericUpDownOpsID.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownOpsID.Name = "numericUpDownOpsID";
            this.numericUpDownOpsID.Size = new System.Drawing.Size(72, 20);
            this.numericUpDownOpsID.TabIndex = 67;
            this.numericUpDownOpsID.ValueChanged += new System.EventHandler(this.numericUpDownMaxSize_ValueChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(31, 152);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(67, 13);
            this.label22.TabIndex = 66;
            this.label22.Text = "Operation ID";
            // 
            // textBoxTofilePath
            // 
            this.textBoxTofilePath.Location = new System.Drawing.Point(106, 201);
            this.textBoxTofilePath.Name = "textBoxTofilePath";
            this.textBoxTofilePath.Size = new System.Drawing.Size(456, 20);
            this.textBoxTofilePath.TabIndex = 69;
            this.textBoxTofilePath.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 68;
            this.label1.Text = "To File Path";
            // 
            // FormRequestST23_15
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 240);
            this.Controls.Add(this.textBoxTofilePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownOpsID);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.textBoxFilePath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonCommit);
            this.Controls.Add(this.groupBoxPayload);
            this.Name = "FormRequestST23_15";
            this.Text = "ST[23,15] Move File";
            this.groupBoxPayload.ResumeLayout(false);
            this.groupBoxPayload.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOpsID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxPayload;
        private System.Windows.Forms.TextBox textBoxPayload;
        private System.Windows.Forms.Button buttonCommit;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.NumericUpDown numericUpDownOpsID;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBoxTofilePath;
        private System.Windows.Forms.Label label1;
    }
}