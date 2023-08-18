namespace Clean.Win.AppUI.UserControls
{
    partial class ucCommonGrid
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dgrMainControl = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgrMainControl).BeginInit();
            SuspendLayout();
            // 
            // dgrMainControl
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgrMainControl.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgrMainControl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgrMainControl.Location = new System.Drawing.Point(1, 1);
            dgrMainControl.Name = "dgrMainControl";
            dgrMainControl.ReadOnly = true;
            dgrMainControl.RowHeadersWidth = 51;
            dgrMainControl.RowTemplate.Height = 29;
            dgrMainControl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgrMainControl.Size = new System.Drawing.Size(1137, 562);
            dgrMainControl.TabIndex = 0;
            // 
            // ucCommonGrid
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Controls.Add(dgrMainControl);
            Name = "ucCommonGrid";
            Size = new System.Drawing.Size(1139, 564);
            Load += ucCommonGrid_Load;
            ((System.ComponentModel.ISupportInitialize)dgrMainControl).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public System.Windows.Forms.DataGridView dgrMainControl;
    }
}
