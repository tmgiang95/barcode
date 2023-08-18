using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clean.Win.AppUI.UserControls
{
    public partial class ucCommonGrid : UserControl
    {
        public ucCommonGrid()
        {
            InitializeComponent();
        }

        public bool isLoadData = false;
        public bool isChangedData = false;
        public string[] gridDataHeaderNameColumns;
        public string[] gridDataHeaderTextColumns;
        private void ucCommonGrid_Load(object sender, EventArgs e)
        {
            //Common format and we can custom formatting grid in a user control
            dgrMainControl.AutoGenerateColumns = false;
            dgrMainControl.AllowUserToDeleteRows = false;
            dgrMainControl.AllowUserToAddRows = false;
            dgrMainControl.AllowDrop = false;
            dgrMainControl.AllowUserToOrderColumns = false;
            dgrMainControl.AllowUserToResizeColumns = false;
            dgrMainControl.AllowUserToResizeRows = false;
            dgrMainControl.AlternatingRowsDefaultCellStyle = null;
            dgrMainControl.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgrMainControl.ScrollBars = ScrollBars.Both;
            //dgrMainControl.RowHeadersVisible = false;//display a column in the left side
            dgrMainControl.EnableHeadersVisualStyles = false;
            dgrMainControl.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgrMainControl.MultiSelect = false;

            if (gridDataHeaderNameColumns != null && gridDataHeaderNameColumns.Length > 0)
            {
                for (var i = 0; i < gridDataHeaderNameColumns.Length; i++)
                {
                    var col = new DataGridViewTextBoxColumn();
                    col.HeaderText = gridDataHeaderTextColumns[i];
                    col.DataPropertyName = gridDataHeaderNameColumns[i];
                    dgrMainControl.Columns.Add(col);
                }
                dgrMainControl.Dock = DockStyle.Fill;
            }
        }
    }
}
