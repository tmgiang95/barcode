
namespace Clean.Win.Apps
{
    partial class MainForm
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
            mainMenu = new System.Windows.Forms.MenuStrip();
            mnuMasterData = new System.Windows.Forms.ToolStripMenuItem();
            mnuArticle = new System.Windows.Forms.ToolStripMenuItem();
            mnuThread = new System.Windows.Forms.ToolStripMenuItem();
            mnuPart = new System.Windows.Forms.ToolStripMenuItem();
            mnuSupplier = new System.Windows.Forms.ToolStripMenuItem();
            mnuGoodsIncomming = new System.Windows.Forms.ToolStripMenuItem();
            mnuOthers = new System.Windows.Forms.ToolStripMenuItem();
            mnuOther = new System.Windows.Forms.ToolStripMenuItem();
            mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            statusTripBottom = new System.Windows.Forms.StatusStrip();
            lblComputer = new System.Windows.Forms.ToolStripStatusLabel();
            lblSeparator1 = new System.Windows.Forms.ToolStripStatusLabel();
            lblServer = new System.Windows.Forms.ToolStripStatusLabel();
            lblSeparator2 = new System.Windows.Forms.ToolStripStatusLabel();
            lblUser = new System.Windows.Forms.ToolStripStatusLabel();
            lblSeparator3 = new System.Windows.Forms.ToolStripStatusLabel();
            lblCurrentDate = new System.Windows.Forms.ToolStripStatusLabel();
            mainSplitContainer = new System.Windows.Forms.SplitContainer();
            pnlLeftMenu = new System.Windows.Forms.Panel();
            pnlLeftMenuTitle = new System.Windows.Forms.Panel();
            lblLeftPanelTitle = new System.Windows.Forms.Label();
            lstLeftPanelMenu = new System.Windows.Forms.ListBox();
            btnBobbin = new System.Windows.Forms.Button();
            btnReport = new System.Windows.Forms.Button();
            btnMenu = new System.Windows.Forms.Button();
            btnLanguage = new System.Windows.Forms.Button();
            btnLogin = new System.Windows.Forms.Button();
            btnOthers = new System.Windows.Forms.Button();
            tblLayoutContent = new System.Windows.Forms.TableLayoutPanel();
            pnlContentTitle = new System.Windows.Forms.Panel();
            lblContentTitle = new System.Windows.Forms.Label();
            pnlContent = new System.Windows.Forms.Panel();
            mainMenu.SuspendLayout();
            statusTripBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainSplitContainer).BeginInit();
            mainSplitContainer.Panel1.SuspendLayout();
            mainSplitContainer.Panel2.SuspendLayout();
            mainSplitContainer.SuspendLayout();
            pnlLeftMenu.SuspendLayout();
            pnlLeftMenuTitle.SuspendLayout();
            tblLayoutContent.SuspendLayout();
            pnlContentTitle.SuspendLayout();
            SuspendLayout();
            // 
            // mainMenu
            // 
            mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { mnuMasterData, mnuGoodsIncomming, mnuOthers, mnuOther, mnuHelp });
            mainMenu.Location = new System.Drawing.Point(0, 0);
            mainMenu.Name = "mainMenu";
            mainMenu.Size = new System.Drawing.Size(1429, 28);
            mainMenu.TabIndex = 0;
            mainMenu.Text = "menuStrip1";
            // 
            // mnuMasterData
            // 
            mnuMasterData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { mnuArticle, mnuThread, mnuPart, mnuSupplier });
            mnuMasterData.Name = "mnuMasterData";
            mnuMasterData.Size = new System.Drawing.Size(104, 24);
            mnuMasterData.Text = "Master Data";
            // 
            // mnuArticle
            // 
            mnuArticle.Name = "mnuArticle";
            mnuArticle.Size = new System.Drawing.Size(224, 26);
            mnuArticle.Text = "Article";
            // 
            // mnuThread
            // 
            mnuThread.Name = "mnuThread";
            mnuThread.Size = new System.Drawing.Size(224, 26);
            mnuThread.Text = "Threads";
            // 
            // mnuPart
            // 
            mnuPart.Name = "mnuPart";
            mnuPart.Size = new System.Drawing.Size(224, 26);
            mnuPart.Text = "Parts";
            mnuPart.Click += mnuPart_Click;
            // 
            // mnuSupplier
            // 
            mnuSupplier.Name = "mnuSupplier";
            mnuSupplier.Size = new System.Drawing.Size(224, 26);
            mnuSupplier.Text = "Suppliers";
            // 
            // mnuGoodsIncomming
            // 
            mnuGoodsIncomming.Name = "mnuGoodsIncomming";
            mnuGoodsIncomming.Size = new System.Drawing.Size(145, 24);
            mnuGoodsIncomming.Text = "Goods Incomming";
            // 
            // mnuOthers
            // 
            mnuOthers.Name = "mnuOthers";
            mnuOthers.Size = new System.Drawing.Size(66, 24);
            mnuOthers.Text = "Others";
            // 
            // mnuOther
            // 
            mnuOther.Name = "mnuOther";
            mnuOther.Size = new System.Drawing.Size(68, 24);
            mnuOther.Text = "Report";
            // 
            // mnuHelp
            // 
            mnuHelp.Name = "mnuHelp";
            mnuHelp.Size = new System.Drawing.Size(55, 24);
            mnuHelp.Text = "Help";
            // 
            // statusTripBottom
            // 
            statusTripBottom.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusTripBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { lblComputer, lblSeparator1, lblServer, lblSeparator2, lblUser, lblSeparator3, lblCurrentDate });
            statusTripBottom.Location = new System.Drawing.Point(0, 766);
            statusTripBottom.Name = "statusTripBottom";
            statusTripBottom.Size = new System.Drawing.Size(1429, 26);
            statusTripBottom.TabIndex = 2;
            statusTripBottom.Text = "statusStrip";
            // 
            // lblComputer
            // 
            lblComputer.Name = "lblComputer";
            lblComputer.Size = new System.Drawing.Size(78, 20);
            lblComputer.Text = "Computer:";
            // 
            // lblSeparator1
            // 
            lblSeparator1.Name = "lblSeparator1";
            lblSeparator1.Size = new System.Drawing.Size(13, 20);
            lblSeparator1.Text = "|";
            // 
            // lblServer
            // 
            lblServer.Name = "lblServer";
            lblServer.Size = new System.Drawing.Size(53, 20);
            lblServer.Text = "Server:";
            // 
            // lblSeparator2
            // 
            lblSeparator2.Name = "lblSeparator2";
            lblSeparator2.Size = new System.Drawing.Size(13, 20);
            lblSeparator2.Text = "|";
            // 
            // lblUser
            // 
            lblUser.Name = "lblUser";
            lblUser.Size = new System.Drawing.Size(41, 20);
            lblUser.Text = "User:";
            // 
            // lblSeparator3
            // 
            lblSeparator3.Name = "lblSeparator3";
            lblSeparator3.Size = new System.Drawing.Size(13, 20);
            lblSeparator3.Text = "|";
            // 
            // lblCurrentDate
            // 
            lblCurrentDate.Name = "lblCurrentDate";
            lblCurrentDate.Size = new System.Drawing.Size(43, 20);
            lblCurrentDate.Text = "Now:";
            // 
            // mainSplitContainer
            // 
            mainSplitContainer.Cursor = System.Windows.Forms.Cursors.VSplit;
            mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            mainSplitContainer.Location = new System.Drawing.Point(0, 28);
            mainSplitContainer.Margin = new System.Windows.Forms.Padding(4);
            mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            mainSplitContainer.Panel1.Controls.Add(pnlLeftMenu);
            mainSplitContainer.Panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            // 
            // mainSplitContainer.Panel2
            // 
            mainSplitContainer.Panel2.Controls.Add(tblLayoutContent);
            mainSplitContainer.Panel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            mainSplitContainer.Size = new System.Drawing.Size(1429, 738);
            mainSplitContainer.SplitterDistance = 298;
            mainSplitContainer.TabIndex = 3;
            // 
            // pnlLeftMenu
            // 
            pnlLeftMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlLeftMenu.Controls.Add(pnlLeftMenuTitle);
            pnlLeftMenu.Controls.Add(lstLeftPanelMenu);
            pnlLeftMenu.Controls.Add(btnBobbin);
            pnlLeftMenu.Controls.Add(btnReport);
            pnlLeftMenu.Controls.Add(btnMenu);
            pnlLeftMenu.Controls.Add(btnLanguage);
            pnlLeftMenu.Controls.Add(btnLogin);
            pnlLeftMenu.Controls.Add(btnOthers);
            pnlLeftMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlLeftMenu.Location = new System.Drawing.Point(0, 0);
            pnlLeftMenu.Name = "pnlLeftMenu";
            pnlLeftMenu.Size = new System.Drawing.Size(298, 738);
            pnlLeftMenu.TabIndex = 0;
            // 
            // pnlLeftMenuTitle
            // 
            pnlLeftMenuTitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlLeftMenuTitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            pnlLeftMenuTitle.Controls.Add(lblLeftPanelTitle);
            pnlLeftMenuTitle.Location = new System.Drawing.Point(0, 0);
            pnlLeftMenuTitle.Name = "pnlLeftMenuTitle";
            pnlLeftMenuTitle.Size = new System.Drawing.Size(296, 35);
            pnlLeftMenuTitle.TabIndex = 8;
            // 
            // lblLeftPanelTitle
            // 
            lblLeftPanelTitle.AutoSize = true;
            lblLeftPanelTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblLeftPanelTitle.Location = new System.Drawing.Point(116, 8);
            lblLeftPanelTitle.Name = "lblLeftPanelTitle";
            lblLeftPanelTitle.Size = new System.Drawing.Size(0, 20);
            lblLeftPanelTitle.TabIndex = 0;
            lblLeftPanelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstLeftPanelMenu
            // 
            lstLeftPanelMenu.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lstLeftPanelMenu.FormattingEnabled = true;
            lstLeftPanelMenu.ItemHeight = 20;
            lstLeftPanelMenu.Location = new System.Drawing.Point(7, 250);
            lstLeftPanelMenu.Name = "lstLeftPanelMenu";
            lstLeftPanelMenu.Size = new System.Drawing.Size(285, 364);
            lstLeftPanelMenu.TabIndex = 7;
            lstLeftPanelMenu.Visible = false;
            // 
            // btnBobbin
            // 
            btnBobbin.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnBobbin.Location = new System.Drawing.Point(5, 214);
            btnBobbin.Name = "btnBobbin";
            btnBobbin.Size = new System.Drawing.Size(287, 29);
            btnBobbin.TabIndex = 5;
            btnBobbin.Text = "Bobbins";
            btnBobbin.UseVisualStyleBackColor = true;
            // 
            // btnReport
            // 
            btnReport.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnReport.Location = new System.Drawing.Point(5, 179);
            btnReport.Name = "btnReport";
            btnReport.Size = new System.Drawing.Size(287, 29);
            btnReport.TabIndex = 4;
            btnReport.Text = "Report";
            btnReport.UseVisualStyleBackColor = true;
            // 
            // btnMenu
            // 
            btnMenu.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnMenu.Location = new System.Drawing.Point(5, 144);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new System.Drawing.Size(287, 29);
            btnMenu.TabIndex = 3;
            btnMenu.Text = "Menu";
            btnMenu.UseVisualStyleBackColor = true;
            // 
            // btnLanguage
            // 
            btnLanguage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnLanguage.Location = new System.Drawing.Point(5, 110);
            btnLanguage.Name = "btnLanguage";
            btnLanguage.Size = new System.Drawing.Size(287, 29);
            btnLanguage.TabIndex = 2;
            btnLanguage.Text = "Language";
            btnLanguage.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnLogin.Location = new System.Drawing.Point(5, 75);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new System.Drawing.Size(287, 29);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            // 
            // btnOthers
            // 
            btnOthers.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnOthers.Location = new System.Drawing.Point(5, 42);
            btnOthers.Name = "btnOthers";
            btnOthers.Size = new System.Drawing.Size(287, 29);
            btnOthers.TabIndex = 0;
            btnOthers.Text = "Others";
            btnOthers.UseVisualStyleBackColor = true;
            // 
            // tblLayoutContent
            // 
            tblLayoutContent.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            tblLayoutContent.ColumnCount = 1;
            tblLayoutContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tblLayoutContent.Controls.Add(pnlContentTitle, 0, 0);
            tblLayoutContent.Controls.Add(pnlContent, 0, 1);
            tblLayoutContent.Dock = System.Windows.Forms.DockStyle.Fill;
            tblLayoutContent.Location = new System.Drawing.Point(0, 0);
            tblLayoutContent.Name = "tblLayoutContent";
            tblLayoutContent.RowCount = 2;
            tblLayoutContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            tblLayoutContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 99.99999F));
            tblLayoutContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tblLayoutContent.Size = new System.Drawing.Size(1127, 738);
            tblLayoutContent.TabIndex = 8;
            // 
            // pnlContentTitle
            // 
            pnlContentTitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlContentTitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            pnlContentTitle.Controls.Add(lblContentTitle);
            pnlContentTitle.Location = new System.Drawing.Point(4, 4);
            pnlContentTitle.Name = "pnlContentTitle";
            pnlContentTitle.Size = new System.Drawing.Size(1119, 30);
            pnlContentTitle.TabIndex = 7;
            // 
            // lblContentTitle
            // 
            lblContentTitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lblContentTitle.AutoSize = true;
            lblContentTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblContentTitle.Location = new System.Drawing.Point(0, 0);
            lblContentTitle.Name = "lblContentTitle";
            lblContentTitle.Size = new System.Drawing.Size(0, 20);
            lblContentTitle.TabIndex = 1;
            lblContentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlContent
            // 
            pnlContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlContent.Location = new System.Drawing.Point(4, 41);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new System.Drawing.Size(1119, 693);
            pnlContent.TabIndex = 5;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1429, 792);
            Controls.Add(mainSplitContainer);
            Controls.Add(mainMenu);
            Controls.Add(statusTripBottom);
            KeyPreview = true;
            MainMenuStrip = mainMenu;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Main Form";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            KeyDown += MainForm_KeyDown;
            mainMenu.ResumeLayout(false);
            mainMenu.PerformLayout();
            statusTripBottom.ResumeLayout(false);
            statusTripBottom.PerformLayout();
            mainSplitContainer.Panel1.ResumeLayout(false);
            mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainSplitContainer).EndInit();
            mainSplitContainer.ResumeLayout(false);
            pnlLeftMenu.ResumeLayout(false);
            pnlLeftMenuTitle.ResumeLayout(false);
            pnlLeftMenuTitle.PerformLayout();
            tblLayoutContent.ResumeLayout(false);
            pnlContentTitle.ResumeLayout(false);
            pnlContentTitle.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuMasterData;
        private System.Windows.Forms.ToolStripMenuItem mnuGoodsIncomming;
        private System.Windows.Forms.ToolStripMenuItem mnuOthers;
        private System.Windows.Forms.ToolStripMenuItem mnuOther;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.StatusStrip statusTripBottom;
        private System.Windows.Forms.ToolStripStatusLabel lblComputer;
        private System.Windows.Forms.ToolStripStatusLabel lblServer;
        private System.Windows.Forms.ToolStripStatusLabel lblUser;
        private System.Windows.Forms.ToolStripStatusLabel lblSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel lblSeparator2;
        private System.Windows.Forms.ToolStripStatusLabel lblSeparator3;
        private System.Windows.Forms.ToolStripStatusLabel lblCurrentDate;
        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.Panel pnlLeftMenu;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnLanguage;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnOthers;
        private System.Windows.Forms.Button btnBobbin;
        private System.Windows.Forms.ListBox lstLeftPanelMenu;
        private System.Windows.Forms.Panel pnlLeftMenuTitle;
        private System.Windows.Forms.ToolStripMenuItem mnuArticle;
        private System.Windows.Forms.ToolStripMenuItem mnuThread;
        private System.Windows.Forms.ToolStripMenuItem mnuPart;
        private System.Windows.Forms.ToolStripMenuItem mnuSupplier;
        private System.Windows.Forms.Label lblLeftPanelTitle;
        private System.Windows.Forms.TableLayoutPanel tblLayoutContent;
        private System.Windows.Forms.Panel pnlContentTitle;
        private System.Windows.Forms.Label lblContentTitle;
        private System.Windows.Forms.Panel pnlContent;
    }
}