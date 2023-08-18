namespace Clean.Win.AppUI.UserControls
{
    partial class ucParts
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
            grpDetail = new System.Windows.Forms.GroupBox();
            panel1 = new System.Windows.Forms.Panel();
            lnkStockFabrics = new System.Windows.Forms.LinkLabel();
            lnkProductionData = new System.Windows.Forms.LinkLabel();
            btnImport = new System.Windows.Forms.Button();
            btnExport = new System.Windows.Forms.Button();
            btnInsert = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            btnRejectChanges = new System.Windows.Forms.Button();
            txtPartName = new System.Windows.Forms.TextBox();
            txtPartCode = new System.Windows.Forms.TextBox();
            lblPart = new System.Windows.Forms.Label();
            pnlPart = new System.Windows.Forms.Panel();
            grpDetail.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // grpDetail
            // 
            grpDetail.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            grpDetail.BackColor = System.Drawing.SystemColors.ControlLightLight;
            grpDetail.Controls.Add(panel1);
            grpDetail.Controls.Add(txtPartName);
            grpDetail.Controls.Add(txtPartCode);
            grpDetail.Controls.Add(lblPart);
            grpDetail.Location = new System.Drawing.Point(1, 404);
            grpDetail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            grpDetail.Name = "grpDetail";
            grpDetail.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            grpDetail.Size = new System.Drawing.Size(965, 110);
            grpDetail.TabIndex = 0;
            grpDetail.TabStop = false;
            grpDetail.Text = "Details";
            // 
            // panel1
            // 
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            panel1.Controls.Add(lnkStockFabrics);
            panel1.Controls.Add(lnkProductionData);
            panel1.Controls.Add(btnImport);
            panel1.Controls.Add(btnExport);
            panel1.Controls.Add(btnInsert);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(btnRejectChanges);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(3, 50);
            panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(959, 58);
            panel1.TabIndex = 2;
            // 
            // lnkStockFabrics
            // 
            lnkStockFabrics.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lnkStockFabrics.AutoSize = true;
            lnkStockFabrics.Location = new System.Drawing.Point(869, 5);
            lnkStockFabrics.Name = "lnkStockFabrics";
            lnkStockFabrics.Size = new System.Drawing.Size(76, 15);
            lnkStockFabrics.TabIndex = 1;
            lnkStockFabrics.TabStop = true;
            lnkStockFabrics.Text = "Stock Fabrics";
            // 
            // lnkProductionData
            // 
            lnkProductionData.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lnkProductionData.AutoSize = true;
            lnkProductionData.Location = new System.Drawing.Point(849, 24);
            lnkProductionData.Name = "lnkProductionData";
            lnkProductionData.Size = new System.Drawing.Size(93, 15);
            lnkProductionData.TabIndex = 1;
            lnkProductionData.TabStop = true;
            lnkProductionData.Text = "Production Data";
            // 
            // btnImport
            // 
            btnImport.Location = new System.Drawing.Point(723, 8);
            btnImport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnImport.Name = "btnImport";
            btnImport.Size = new System.Drawing.Size(121, 28);
            btnImport.TabIndex = 0;
            btnImport.Text = "Import";
            btnImport.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            btnExport.Location = new System.Drawing.Point(597, 8);
            btnExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnExport.Name = "btnExport";
            btnExport.Size = new System.Drawing.Size(121, 28);
            btnExport.TabIndex = 0;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            // 
            // btnInsert
            // 
            btnInsert.Location = new System.Drawing.Point(262, 8);
            btnInsert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new System.Drawing.Size(121, 28);
            btnInsert.TabIndex = 0;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new System.Drawing.Point(136, 8);
            btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(121, 28);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnRejectChanges
            // 
            btnRejectChanges.Location = new System.Drawing.Point(10, 8);
            btnRejectChanges.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnRejectChanges.Name = "btnRejectChanges";
            btnRejectChanges.Size = new System.Drawing.Size(121, 28);
            btnRejectChanges.TabIndex = 0;
            btnRejectChanges.Text = "Reject Changes";
            btnRejectChanges.UseVisualStyleBackColor = true;
            btnRejectChanges.Click += btnRejectChanges_Click;
            // 
            // txtPartName
            // 
            txtPartName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtPartName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            txtPartName.Location = new System.Drawing.Point(231, 18);
            txtPartName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtPartName.Name = "txtPartName";
            txtPartName.ReadOnly = true;
            txtPartName.Size = new System.Drawing.Size(727, 23);
            txtPartName.TabIndex = 1;
            txtPartName.Tag = "PartName";
            txtPartName.Click += txtPartName_Click;
            // 
            // txtPartCode
            // 
            txtPartCode.BackColor = System.Drawing.SystemColors.ControlLightLight;
            txtPartCode.Location = new System.Drawing.Point(80, 18);
            txtPartCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtPartCode.Name = "txtPartCode";
            txtPartCode.ReadOnly = true;
            txtPartCode.Size = new System.Drawing.Size(143, 23);
            txtPartCode.TabIndex = 1;
            txtPartCode.Tag = "PartCode";
            txtPartCode.Click += txtPartCode_Click;
            // 
            // lblPart
            // 
            lblPart.AutoSize = true;
            lblPart.Location = new System.Drawing.Point(24, 20);
            lblPart.Name = "lblPart";
            lblPart.Size = new System.Drawing.Size(33, 15);
            lblPart.TabIndex = 0;
            lblPart.Text = "Parts";
            // 
            // pnlPart
            // 
            pnlPart.BackColor = System.Drawing.SystemColors.ControlLightLight;
            pnlPart.Dock = System.Windows.Forms.DockStyle.Top;
            pnlPart.Location = new System.Drawing.Point(0, 0);
            pnlPart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            pnlPart.Name = "pnlPart";
            pnlPart.Size = new System.Drawing.Size(967, 404);
            pnlPart.TabIndex = 1;
            // 
            // ucParts
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Controls.Add(pnlPart);
            Controls.Add(grpDetail);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "ucParts";
            Size = new System.Drawing.Size(967, 515);
            Load += ucParts_Load;
            grpDetail.ResumeLayout(false);
            grpDetail.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        public System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel lnkStockFabrics;
        public System.Windows.Forms.Button btnImport;
        public System.Windows.Forms.Button btnExport;
        public System.Windows.Forms.Button btnInsert;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnRejectChanges;
        private System.Windows.Forms.TextBox txtPartName;
        private System.Windows.Forms.TextBox txtPartCode;
        public System.Windows.Forms.Label lblPart;
        private System.Windows.Forms.LinkLabel lnkProductionData;
        public System.Windows.Forms.Panel pnlPart;
    }
}
