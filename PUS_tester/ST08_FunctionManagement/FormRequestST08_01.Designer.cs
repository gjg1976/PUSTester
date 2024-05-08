
namespace PUS_tester
{
    partial class FormRequestST08_01
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
            this.textBoxFunctionName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxFunctionArg = new System.Windows.Forms.TextBox();
            this.groupBoxPayload.SuspendLayout();
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
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Function ID";
            // 
            // textBoxFunctionName
            // 
            this.textBoxFunctionName.Location = new System.Drawing.Point(159, 150);
            this.textBoxFunctionName.Name = "textBoxFunctionName";
            this.textBoxFunctionName.Size = new System.Drawing.Size(394, 20);
            this.textBoxFunctionName.TabIndex = 38;
            this.textBoxFunctionName.TextChanged += new System.EventHandler(this.textBoxFunctionName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Function Arg (hex string)";
            // 
            // textBoxFunctionArg
            // 
            this.textBoxFunctionArg.Location = new System.Drawing.Point(159, 182);
            this.textBoxFunctionArg.Name = "textBoxFunctionArg";
            this.textBoxFunctionArg.Size = new System.Drawing.Size(394, 20);
            this.textBoxFunctionArg.TabIndex = 40;
            this.textBoxFunctionArg.TextChanged += new System.EventHandler(this.textBoxFunctionArg_TextChanged);
            // 
            // FormRequestST08_01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 217);
            this.Controls.Add(this.textBoxFunctionArg);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxFunctionName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonCommit);
            this.Controls.Add(this.groupBoxPayload);
            this.Name = "FormRequestST08_01";
            this.Text = "ST[04,01] Report Parameter Statistics";
            this.groupBoxPayload.ResumeLayout(false);
            this.groupBoxPayload.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxPayload;
        private System.Windows.Forms.TextBox textBoxPayload;
        private System.Windows.Forms.Button buttonCommit;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxFunctionName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxFunctionArg;
    }
}