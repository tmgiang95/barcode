using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clean.Win.AppUI.UICommon
{
    public static class UIUtility
    {
        public static Form GetActiveFormOpenning(string formName)
        {
            Form frmActive = null;
            FormCollection frmCollection = Application.OpenForms;
            foreach (Form frm in frmCollection)
            {
                if (frm.Name.Trim().Equals(formName.Trim()))
                {
                    frmActive = frm;
                    break;
                }
            }
            return frmActive;
        }

        public static void AppShowMsg(string msg, string MsgboxInformation = "")
        {
            switch (MsgboxInformation)
            {
                case UIConstants.MSGBOX_ICON_WARNING_STYLE:
                    MessageBox.Show(msg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case UIConstants.MSGBOX_ICON_QUESTION_STYLE:
                    MessageBox.Show(msg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    break;
                case UIConstants.MSGBOX_ICON_ERROR_STYLE:
                    MessageBox.Show(msg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    MessageBox.Show(msg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }
    }
}
