namespace Clean.Win.AppUI.Forms
{
    partial class TextInputForm
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
            panel2 = new System.Windows.Forms.Panel();
            btnOK = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            txtTextInput = new System.Windows.Forms.TextBox();
            lblFieldName = new System.Windows.Forms.Label();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            panel2.Controls.Add(btnOK);
            panel2.Controls.Add(btnCancel);
            panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel2.Location = new System.Drawing.Point(0, 131);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(451, 56);
            panel2.TabIndex = 5;
            // 
            // btnOK
            // 
            btnOK.Location = new System.Drawing.Point(205, 10);
            btnOK.Name = "btnOK";
            btnOK.Size = new System.Drawing.Size(108, 32);
            btnOK.TabIndex = 2;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(327, 10);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(108, 32);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(txtTextInput);
            panel1.Controls.Add(lblFieldName);
            panel1.Location = new System.Drawing.Point(16, 13);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(418, 100);
            panel1.TabIndex = 4;
            // 
            // txtTextInput
            // 
            txtTextInput.Location = new System.Drawing.Point(14, 49);
            txtTextInput.Name = "txtTextInput";
            txtTextInput.Size = new System.Drawing.Size(388, 27);
            txtTextInput.TabIndex = 3;
            txtTextInput.TextChanged += txtTextInput_TextChanged;
            txtTextInput.KeyDown += txtTextInput_KeyDown;
            // 
            // lblFieldName
            // 
            lblFieldName.AutoSize = true;
            lblFieldName.Location = new System.Drawing.Point(14, 11);
            lblFieldName.Name = "lblFieldName";
            lblFieldName.Size = new System.Drawing.Size(0, 20);
            lblFieldName.TabIndex = 2;
            // 
            // TextInputForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ButtonHighlight;
            ClientSize = new System.Drawing.Size(451, 187);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TextInputForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Text Input";
            FormClosed += TextInputForm_FormClosed;
            Load += TextInputForm_Load;
            KeyDown += TextInputForm_KeyDown;
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTextInput;
        private System.Windows.Forms.Label lblFieldName;
        public System.Windows.Forms.Panel panel2;
    }
}