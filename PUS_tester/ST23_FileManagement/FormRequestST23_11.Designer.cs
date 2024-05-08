
namespace PUS_tester
{
    partial class FormRequestST23_11
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
            this.textBoxDirPath = new System.Windows.Forms.TextBox();
            this.textBoxDirOldName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDirNewName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Directory Path";
            // 
            // textBoxDirPath
            // 
            this.textBoxDirPath.Location = new System.Drawing.Point(117, 150);
            this.textBoxDirPath.Name = "textBoxDirPath";
            this.textBoxDirPath.Size = new System.Drawing.Size(445, 20);
            this.textBoxDirPath.TabIndex = 38;
            this.textBoxDirPath.TextChanged += new System.EventHandler(this.textBoxFunctionName_TextChanged);
            // 
            // textBoxDirOldName
            // 
            this.textBoxDirOldName.Location = new System.Drawing.Point(134, 176);
            this.textBoxDirOldName.Name = "textBoxDirOldName";
            this.textBoxDirOldName.Size = new System.Drawing.Size(428, 20);
            this.textBoxDirOldName.TabIndex = 40;
            this.textBoxDirOldName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Old Directory Name";
            // 
            // textBoxDirNewName
            // 
            this.textBoxDirNewName.Location = new System.Drawing.Point(134, 202);
            this.textBoxDirNewName.Name = "textBoxDirNewName";
            this.textBoxDirNewName.Size = new System.Drawing.Size(428, 20);
            this.textBoxDirNewName.TabIndex = 42;
            this.textBoxDirNewName.TextChanged += new System.EventHandler(this.textBoxDirNewName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "New Directory Name";
            // 
            // FormRequestST23_11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 239);
            this.Controls.Add(this.textBoxDirNewName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxDirOldName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDirPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonCommit);
            this.Controls.Add(this.groupBoxPayload);
            this.Name = "FormRequestST23_11";
            this.Text = "ST[23,10] Delete Directory";
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
        private System.Windows.Forms.TextBox textBoxDirPath;
        private System.Windows.Forms.TextBox textBoxDirOldName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDirNewName;
        private System.Windows.Forms.Label label2;
    }
}