using Clean.Win.AppUI.Forms;
using Clean.Win.AppUI.UICommon;
using Clean.WinF.Applications.Features.Part.DTOs;
using Clean.WinF.Applications.Features.Part.Interfaces;
using Clean.WinF.Shared.Constants;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Clean.Win.AppUI.UserControls
{
    public partial class ucParts : UserControl
    {
        private readonly IPartQueryServices _queryService;
        private readonly IPartCommandServices _commandService;
        private readonly UICommon.UICommon uiCommon = UICommon.UICommon.Instance;
        TextInputForm textInput = null;

        public ucParts(IPartCommandServices commandService, IPartQueryServices queryServices)
        {
            _commandService = commandService;
            _queryService = queryServices;
            InitializeComponent();
        }

        private void InitialLanguage(string langcode)
        {

        }

        private void DisplayTextFormInput(string txtFieldTag, string txtFieldValue)
        {
            textInput = UIUtility.GetActiveFormOpenning("TextInputForm") as TextInputForm;
            if (textInput is null || !textInput.Visible)
            {
                ProcessTextFormInputs(txtFieldTag, txtFieldValue);
            }
            else
            {
                textInput.Dispose();
                ProcessTextFormInputs(txtFieldTag, txtFieldValue);
            }
        }

        private void ProcessTextFormInputs(string txtFieldTag, string txtFieldValue)
        {
            textInput = new TextInputForm(this);//constructor injection
            textInput.OnFormClose += OnClosingForm;
            if (txtFieldTag.Equals(this.txtPartCode.Tag.ToString()))
            {
                textInput.textFieldTag = txtPartCode.Tag.ToString();
                textInput.textFieldName = "Part Code";
                textInput.isUpperCase = true;
            }

            if (txtFieldTag.Equals(this.txtPartName.Tag.ToString()))
            {
                textInput.textFieldTag = txtPartName.Tag.ToString();
                textInput.textFieldName = "Part Name";
            }

            textInput.textFieldValue = txtFieldValue;

            Form myMainForm = btnInsert.FindForm();
            textInput.Owner = myMainForm;
            textInput.Show();
        }

        private void OnClosingForm(Control subControl)
        {
            if (subControl != null)
                textInput = null;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            RejectChanges();
            this.txtPartCode.ReadOnly = false;
            this.txtPartCode.Focus();
            this.txtPartName.ReadOnly = false;
            DisplayTextFormInput(this.txtPartCode.Tag.ToString(), this.txtPartCode.Text.Trim());
        }

        private void RejectChanges()
        {
            this.txtPartCode.Text = string.Empty;
            this.txtPartName.Text = string.Empty;
        }

        private void btnRejectChanges_Click(object sender, EventArgs e)
        {
            RejectChanges();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var part = new PartDto()
            {
                Code = this.txtPartCode.Text,
                Name = this.txtPartName.Text
            };
            var res = await _commandService.CreateNewPart(part);
            if (res.CustomErrorCode.Equals(CustomOperationCodes.APP_PART_ADD_SUCCESS))
            {
                GridviewDataBingding();
            }
            else
            {
                UIUtility.AppShowMsg(res.MessageRet);
            }
        }

        private void ucParts_Load(object sender, EventArgs e)
        {
            GridviewDataBingding();
        }

        private async void GridviewDataBingding()
        {
            var result = await _queryService.ListAllAsync();

            Control ucControl = uiCommon.FindControlByName(this, "ucCommonGrid");
            if (ucControl != null)
            {
                DataGridView drgMain = uiCommon.FindControlByName(this, "dgrMainControl") as DataGridView;
                if (drgMain != null)
                {
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = result;
                    drgMain.DataSource = bindingSource;
                    drgMain.Tag = UITagControlConstants.MAIN_GRID_TAG_VALUE;
                    drgMain = FormatDataGridView(drgMain);
                    drgMain.Refresh();
                }
            }
        }

        private DataGridView FormatDataGridView(DataGridView drgView)
        {
            drgView.ColumnHeadersHeight = 150;
            for (var i = 0; i < drgView.ColumnCount; i++)
            {
                if (drgView.Columns[i].DataPropertyName.Equals("CreatedBy")
                    || drgView.Columns[i].DataPropertyName.Equals("CreatedOn")
                    || drgView.Columns[i].DataPropertyName.Equals("UpdatedBy")
                    || drgView.Columns[i].DataPropertyName.Equals("UpdatedOn")
                    )
                {
                    drgView.Columns[i].Width = 150;
                    drgView.Columns[i].ReadOnly = true;
                    drgView.Columns[i].DefaultCellStyle.BackColor = Color.LightYellow;
                }
                else
                {
                    drgView.Columns[i].Width = 250;
                    if (i == 0)
                    {
                        drgView.Columns[0].DefaultCellStyle.Font = new Font(drgView.Font, FontStyle.Bold);
                    }
                }
            }

            return drgView;
        }

        public void CompletedValueInput(object sender, ProcessEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.TagValue))
            {
                if (e.TagValue.Equals(this.txtPartCode.Tag.ToString()))
                {
                    this.txtPartCode.Text = e.TextValue;
                }

                if (e.TagValue.Equals(this.txtPartName.Tag.ToString()))
                {
                    this.txtPartName.Text = e.TextValue;
                }
            }
        }

        private void txtPartCode_Click(object sender, EventArgs e)
        {
            DisplayTextFormInput(this.txtPartCode.Tag.ToString(), this.txtPartCode.Text.Trim());
        }

        private void txtPartName_Click(object sender, EventArgs e)
        {
            DisplayTextFormInput(this.txtPartName.Tag.ToString(), this.txtPartName.Text.Trim());
        }
    }
}
