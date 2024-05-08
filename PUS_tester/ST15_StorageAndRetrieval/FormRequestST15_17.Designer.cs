﻿
namespace PUS_tester
{
    partial class FormRequestST15_17
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
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCommit = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxPayload.SuspendLayout();
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
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(73, 143);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(68, 20);
            this.numericUpDown1.TabIndex = 28;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "N";
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
            // FormRequestST15_17
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 450);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonCommit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.groupBoxPayload);
            this.Name = "FormRequestST15_17";
            this.Text = "ST[15,17] Abort By Time Range Retrieval";
            this.groupBoxPayload.ResumeLayout(false);
            this.groupBoxPayload.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxPayload;
        private System.Windows.Forms.TextBox textBoxPayload;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCommit;
        private System.Windows.Forms.Button buttonCancel;
    }
}