
namespace PUS_tester
{
    partial class FormRequestST15_24
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
            this.textBoxToName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFromName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownTag1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownTag2 = new System.Windows.Forms.NumericUpDown();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.groupBoxPayload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTag1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTag2)).BeginInit();
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
            // textBoxToName
            // 
            this.textBoxToName.Location = new System.Drawing.Point(101, 234);
            this.textBoxToName.MaxLength = global::PUS_tester.Properties.Settings.Default.ST15StoresIDSize;
            this.textBoxToName.Name = "textBoxToName";
            this.textBoxToName.Size = new System.Drawing.Size(450, 20);
            this.textBoxToName.TabIndex = 40;
            this.textBoxToName.TextChanged += new System.EventHandler(this.textBoxToName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "From Store ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Type";
            // 
            // textBoxFromName
            // 
            this.textBoxFromName.Location = new System.Drawing.Point(101, 260);
            this.textBoxFromName.MaxLength = global::PUS_tester.Properties.Settings.Default.ST15StoresIDSize;
            this.textBoxFromName.Name = "textBoxFromName";
            this.textBoxFromName.Size = new System.Drawing.Size(450, 20);
            this.textBoxFromName.TabIndex = 44;
            this.textBoxFromName.TextChanged += new System.EventHandler(this.textBoxFromName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "To Store ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "Time tag 1";
            // 
            // numericUpDownTag1
            // 
            this.numericUpDownTag1.Location = new System.Drawing.Point(101, 181);
            this.numericUpDownTag1.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.numericUpDownTag1.Name = "numericUpDownTag1";
            this.numericUpDownTag1.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownTag1.TabIndex = 45;
            this.numericUpDownTag1.ValueChanged += new System.EventHandler(this.numericUpDownTag1_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "Time tag 2";
            // 
            // numericUpDownTag2
            // 
            this.numericUpDownTag2.Location = new System.Drawing.Point(101, 207);
            this.numericUpDownTag2.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.numericUpDownTag2.Name = "numericUpDownTag2";
            this.numericUpDownTag2.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownTag2.TabIndex = 47;
            this.numericUpDownTag2.ValueChanged += new System.EventHandler(this.numericUpDownTag2_ValueChanged);
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "Circular",
            "Bounded"});
            this.comboBoxType.Location = new System.Drawing.Point(101, 151);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(95, 21);
            this.comboBoxType.TabIndex = 49;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // FormRequestST15_24
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(599, 450);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDownTag2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDownTag1);
            this.Controls.Add(this.textBoxFromName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxToName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonCommit);
            this.Controls.Add(this.groupBoxPayload);
            this.Name = "FormRequestST15_24";
            this.Text = "ST[15,24] Copy Packets In Time Window";
            this.groupBoxPayload.ResumeLayout(false);
            this.groupBoxPayload.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTag1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTag2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxPayload;
        private System.Windows.Forms.TextBox textBoxPayload;
        private System.Windows.Forms.Button buttonCommit;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxToName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFromName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownTag1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownTag2;
        private System.Windows.Forms.ComboBox comboBoxType;
    }
}