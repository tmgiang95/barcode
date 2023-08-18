using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clean.Win.Apps;
using Clean.Win.AppUI.UICommon;
using Clean.Win.AppUI.UserControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Azure.Core.HttpHeader;

namespace Clean.Win.AppUI.Forms
{
    public partial class TextInputForm : Form
    {
        public event FormClosed OnFormClose;
        public string textFieldName = string.Empty;
        public string textFieldTag = string.Empty;
        public string textFieldValue = string.Empty;
        public bool isUpperCase = false;
        ucParts parentUC;
        public TextInputForm(UserControl parentControl)
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            parentUC = parentControl as ucParts;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextInputForm_Load(object sender, EventArgs e)
        {
            lblFieldName.Text = textFieldName;
            this.txtTextInput.Tag = textFieldTag;
            this.txtTextInput.Text = textFieldValue;
            this.txtTextInput.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ProcessTextValue();
        }

        private void ProcessTextValue()
        {
            var processRet = new ProcessEventArgs()
            {
                TagValue = txtTextInput.Tag.ToString(),
                TextValue = txtTextInput.Text.Trim()
            };
            parentUC.CompletedValueInput(this, processRet);
            this.Close();
        }

        private void DoClosingForm()
        {
            OnFormClose.Invoke(this);
        }

        private void TextInputForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DoClosingForm();
        }

        private void TextInputForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.Enter)
                ProcessTextValue();
        }

        private void txtTextInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ProcessTextValue();
        }

        private void txtTextInput_TextChanged(object sender, EventArgs e)
        {
            if (isUpperCase)
            {
                this.txtTextInput.Text = txtTextInput.Text.ToUpper();
                txtTextInput.SelectionStart = txtTextInput.Text.Length;
            }
        }
    }
}
