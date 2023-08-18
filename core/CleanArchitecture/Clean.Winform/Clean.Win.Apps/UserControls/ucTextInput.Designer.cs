namespace Clean.Win.AppUI.UserControls
{
    partial class ucTextInput
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new System.Windows.Forms.Panel();
            lblFieldName = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            btnOK = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            panel2 = new System.Windows.Forms.Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(lblFieldName);
            panel1.Location = new System.Drawing.Point(16, 26);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(418, 100);
            panel1.TabIndex = 0;
            // 
            // lblFieldName
            // 
            lblFieldName.AutoSize = true;
            lblFieldName.Location = new System.Drawing.Point(14, 11);
            lblFieldName.Name = "lblFieldName";
            lblFieldName.Size = new System.Drawing.Size(0, 20);
            lblFieldName.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(14, 49);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(388, 27);
            textBox1.TabIndex = 3;
            // 
            // btnOK
            // 
            btnOK.Location = new System.Drawing.Point(224, 8);
            btnOK.Name = "btnOK";
            btnOK.Size = new System.Drawing.Size(108, 32);
            btnOK.TabIndex = 2;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(336, 8);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(108, 32);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel2.Controls.Add(btnOK);
            panel2.Controls.Add(btnCancel);
            panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel2.Location = new System.Drawing.Point(0, 174);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(450, 54);
            panel2.TabIndex = 3;
            // 
            // ucTextInput
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ButtonHighlight;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ucTextInput";
            Size = new System.Drawing.Size(450, 228);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblFieldName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel2;
    }
}
