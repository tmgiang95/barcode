using Clean.Win.Apps;
using Clean.Win.AppUI.UserControls;
using Clean.WinF.Applications.Features.Part.Interfaces;
using Clean.WinF.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clean.Win.AppUI.UICommon
{
    public delegate void FormClosed(Control _subControl);
    public sealed class UICommon
    {
        //implement singleton design pattern
        public static UICommon instance = null;
        private static readonly object padlock = new object();         
        public static UICommon Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new UICommon();
                    }
                    return instance;
                }
            }
        }        
        
        public void DisplayingPartInformation(MainForm mainForm, MenuEnums mainMenu)
        {
            if (mainForm != null) 
            {
                var pnlMainContent = FindControlByName(mainForm, UIConstants.PANEL_CONTENT_NAME);
                if (pnlMainContent != null) 
                {
                    var drgHeaderNames = CleanWinFUtility.ConvertStringToArray(UIConstants.GRID_COLUMNS_PART_HEADER_Name, "||");
                    var drgHeaderTexts = CleanWinFUtility.ConvertStringToArray(UIConstants.GRID_COLUMNS_PART_HEADER_Text, "||");
                    var ucPart = GetUserPartControl(mainForm._partCommandService, mainForm._partQueryService, nameof(mainMenu), drgHeaderNames, drgHeaderTexts);
                    ucPart.Dock = DockStyle.Fill;
                    ucPart.pnlPart.Height = pnlMainContent.Height - ucPart.grpDetail.Height - 20;
                    //register 
                    pnlMainContent.Controls.Add(ucPart);
                }
            }
        }

        //This function will help to find any existing controls(label, button, textbox, panel...) in main form
        public Control FindControlByName(Control container, string name)
        {
            if (container.Name == name)
            {
                return container;
            }

            foreach (Control control in container.Controls)
            {
                Control foundControl = FindControlByName(control, name);
                if (foundControl != null)
                {
                    return foundControl;
                }
            }

            return null;
        }

        #region private functions

        //this functions will help to create new user control instance
        private ucCommonGrid GetCommonGridControl(string gridName, string[] gridHeaderNames, string[] gridHeaderTexts)
        {
            var commonGrid = new ucCommonGrid();
            commonGrid.gridDataHeaderNameColumns = gridHeaderNames;
            commonGrid.gridDataHeaderTextColumns = gridHeaderTexts;
            commonGrid.Tag = string.Concat("ucCommon",gridName);
            commonGrid.dgrMainControl.Tag = gridName;
            commonGrid.isLoadData = true;
            return commonGrid;
        }

        private ucParts GetUserPartControl(IPartCommandServices cmdServices, IPartQueryServices queryServices, string gridName, string[] gridHeaderNames, string[] gridHeaderTexts)
        {
            var userPartControl = new ucParts(cmdServices, queryServices);            
            var commonGrid = GetCommonGridControl(gridName, gridHeaderNames, gridHeaderTexts);
            commonGrid.Dock = DockStyle.Fill;
            userPartControl.pnlPart.Controls.Add(commonGrid);
            return userPartControl;
        }
        #endregion
    }

    public class ProcessEventArgs : EventArgs
    {        
        public string TagValue { get; set; }
        public string TextValue { get; set; }        
    }
}
