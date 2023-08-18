using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;
using Clean.Win.AppUI.UICommon;
using Clean.WinF.Applications.Features.Part.Interfaces;

namespace Clean.Win.Apps
{
    public partial class MainForm : Form
    {
        //DI services
        public IPartCommandServices _partCommandService;
        public IPartQueryServices _partQueryService;

        private readonly UICommon uiCommon = UICommon.Instance;
        public MainForm(IPartCommandServices partCommandServices, IPartQueryServices partQueryServices)
        {
            _partCommandService = partCommandServices;
            _partQueryService = partQueryServices;
            InitializeComponent();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Log.Information("Begin MainForm_FormClosing");
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    if (MessageBox.Show(UIConstants.MSG_MAIN_FORM_CLOSING, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.Yes)
                    {
                        //do something
                    }
                    else
                    {

                    }
                }
                Log.CloseAndFlush();
            }
            catch (Exception ex)
            {
                Log.Error(string.Concat("Error: MainForm_FormClosing() ", ex.Message, Environment.NewLine, ex.StackTrace));
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Log.Error(string.Concat("Error: MainForm_Load() ", ex.Message, Environment.NewLine, ex.StackTrace));
            }
        }

        private void mnuPart_Click(object sender, EventArgs e)
        {
            lblContentTitle.Text = "Material " + mnuPart.Text;
            lblContentTitle.Width = pnlContentTitle.Width;
            uiCommon.DisplayingPartInformation(this, MenuEnums.Parts);
        }
    }
}
