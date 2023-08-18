using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Win.AppUI.UICommon
{
    public static class UIConstants
    {
        public const string MSG_MAIN_FORM_CLOSING = "There are some changes so are you sure to exit application?";

        //MSGBOX ICON
        public const string MSGBOX_ICON_WARNING_STYLE = "WARNING";
        public const string MSGBOX_ICON_QUESTION_STYLE = "QUESTION";
        public const string MSGBOX_ICON_ERROR_STYLE = "ERROR";

        //Data grid columns definitions
        public const string GRID_COLUMNS_PART_HEADER_Name = "Code||Name||CreatedBy||CreatedOn||UpdatedBy||UpdatedOn";
        public const string GRID_COLUMNS_PART_HEADER_Text = "Parts Code||Parts Name||Created by||Created on||Updated by||Updated on";

        //Panel content name
        public const string PANEL_CONTENT_NAME = "pnlContent";
       
    }
    public static class UITagControlConstants
    {        
        //Tags value for controls
        public const string MAIN_GRID_TAG_VALUE = "MAIN_PART_FEATURE";
    }


}
