using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

namespace Fields
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // ///////////////////////////////
        // Set Control
        // ////////////////////////////
        public static void SetControlsStatus(Page wpage)
        {
            string session_id = wpage.Request.Cookies["Session_ID"].Value.ToString();
            ArrayList al = new ArrayList();
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retresult_", "out", "cursor", null));
            DataTable tbl = SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_web_pages_managmwnts.get_controls_", al);
            foreach (DataRow dr in tbl.Rows)
            {
                SetOneControlStatus(wpage, dr["control_name"].ToString(), dr["control_type"].ToString(), dr["control_state"].ToString(), dr["control_state_status"].ToString());
            }
        }

        public static void HideRequiredLabe(Page wpage, string control_name)
        {
           
            Label lbl = Bas_Utility.Utilities.GetLabel2(wpage, control_name);
            if (lbl != null)
                lbl.ForeColor = System.Drawing.Color.White;
        }

        public static void ShowRequiredLabe(Page wpage, string control_name)
        {
            Label lbl = Bas_Utility.Utilities.GetLabel2(wpage, control_name);
            if (lbl != null)
                lbl.ForeColor = System.Drawing.Color.Magenta;
        }

        public static void DisableRequired(Page wpage, string control_name)
        {            
            RequiredFieldValidator val = Bas_Utility.Utilities.GetRequiredFieldValidator2(wpage, control_name);
            if (val != null)
                val.Visible = false;
            RegularExpressionValidator val2 = Bas_Utility.Utilities.GetRegularExpressionValidator2(wpage, control_name);
            if (val2 != null)
                val2.Visible = false;
            RangeValidator val3 = Bas_Utility.Utilities.GetRangeValidator2(wpage, control_name);
            if (val3 != null)
                val3.Visible = false;
        }

        public static void EnableRequired(Page wpage, string control_name)
        {
            RequiredFieldValidator val = Bas_Utility.Utilities.GetRequiredFieldValidator2(wpage, control_name);
            if (val != null)
            {
                val.Visible = true;
                val.Enabled = true;
            }
            RegularExpressionValidator val2 = Bas_Utility.Utilities.GetRegularExpressionValidator2(wpage, control_name);
            if (val2 != null)
            {
                val2.Visible = true;
                val2.Enabled = true;
            }
            RangeValidator val3 = Bas_Utility.Utilities.GetRangeValidator2(wpage, control_name);
            if (val3 != null)
            {
                val3.Visible = true;
                val3.Enabled = true;
            }
        }

        public static void SetOneControlStatus(Page wpage, string control_name, string control_type, string control_state, string control_state_status)
        {
            switch (control_state)
            {
                case "1":
                    ProcessRequired(wpage, control_name, control_type, control_state_status);
                    break;
                case "2":
                    ProcessEnableVisible(wpage, control_name, control_type,  control_state_status,1);
                    if (control_state_status.Equals("0"))
                        ProcessRequired(wpage, control_name, control_type, control_state_status);
                    break;
                case "3":
                    ProcessEnableVisible(wpage, control_name, control_type, control_state_status, 2);
                    break;     
            }
            
        }

        public static void ProcessRequired(Page wpage, string control_name, string control_type, string control_state_status)
        {
            if (control_type.Equals("TextBox"))
            {
                TextBox txt = Bas_Utility.Utilities.GetTextBox(wpage, control_name);
                if (txt != null)
                    DoRequired(wpage, control_name, control_state_status);
                return;
            }
            if (control_type.Equals("DropDownList"))
            {
                DropDownList ddl = Bas_Utility.Utilities.GetDropDown(wpage, control_name);
                if (ddl != null)
                    DoRequired(wpage, control_name, control_state_status);
                return;
            }
            if (control_type.Equals("RadMaskedTextBox"))
            {
                RadMaskedTextBox txt = Bas_Utility.Utilities.GetRadMaskedTextBox(wpage, control_name);
                if (txt != null)
                    DoRequired(wpage, control_name, control_state_status);
                return;
            }
            if (control_type.Equals("RadNumericTextBox"))
            {
                RadNumericTextBox txt = Bas_Utility.Utilities.GetRadNumericTextBox(wpage, control_name);
                if (txt != null)
                    DoRequired(wpage, control_name, control_state_status);
                return;
            }
            if (control_type.Equals("RadTextBox"))
            {
                RadTextBox txt = Bas_Utility.Utilities.GetRadTextBox(wpage, control_name);
                if (txt != null)
                    DoRequired(wpage, control_name, control_state_status);
                return;
            }
            if (control_type.Equals("LinkButton"))
            {
                LinkButton txt = Bas_Utility.Utilities.GetLinkButton(wpage, control_name);
                if (txt != null)
                    DoRequired(wpage, control_name, control_state_status);
                return;
            }
            if (control_type.Equals("ImageButton"))
            {
                ImageButton txt = Bas_Utility.Utilities.GetImageButton(wpage, control_name);
                if (txt != null)
                    DoRequired(wpage, control_name, control_state_status);
                return;
            }
            
            if (control_type.Equals("HyperLink"))
            {
                HyperLink cntrl = Bas_Utility.Utilities.GetHyperLink(wpage, control_name);
                if (cntrl != null)
                    DoRequired(wpage, control_name, control_state_status);
                return;
            }
            if (control_type.Equals("ListBox"))
            {
                ListBox cntrl = Bas_Utility.Utilities.GetListBox(wpage, control_name);
                if (cntrl != null)
                    DoRequired(wpage, control_name, control_state_status);
                return;
            }
            if (control_type.Equals("CheckBox"))
            {
                CheckBox cntrl = Bas_Utility.Utilities.GetCheckBox(wpage, control_name);
                if (cntrl != null)
                    DoRequired(wpage, control_name, control_state_status);
                return;
            }
            if (control_type.Equals("CheckBoxList"))
            {
                CheckBoxList cntrl = Bas_Utility.Utilities.GetCheckBoxList(wpage, control_name);
                if (cntrl != null)
                    DoRequired(wpage, control_name, control_state_status);
                return;
            }
            if (control_type.Equals("RadioButton"))
            {
                RadioButton cntrl = Bas_Utility.Utilities.GetRadioButton(wpage, control_name);
                if (cntrl != null)
                    DoRequired(wpage, control_name, control_state_status);
                return;
            }

        }

        public static void DoRequired(Page wpage, string control_name, string control_state_status)
        {
            if (control_state_status.Equals("1"))
            {
                ShowRequiredLabe(wpage, control_name);
                EnableRequired(wpage, control_name);
            }
            else
            {
                HideRequiredLabe(wpage, control_name);
                DisableRequired(wpage, control_name);
            }
        }



        public static void ProcessEnableVisible(Page wpage, string control_name, string control_type, string control_state_status,int iAction)
        {
            if (control_type.Equals("TextBox"))
            {
                TextBox txt = Bas_Utility.Utilities.GetTextBox(wpage, control_name);
                if (txt != null)
                {                    
                    if (control_state_status.Equals("1"))
                    {
                        switch (iAction)
                        {
                            case 1:
                                txt.Enabled = true;
                                break;
                            case 2:
                                txt.Visible = true;
                                break;
                        }
                        
                    }
                    else
                    {
                        if (control_state_status.Equals("0"))
                        {
                            switch (iAction)
                            {
                                case 1:
                                    txt.Enabled = false;
                                    txt.BackColor = System.Drawing.Color.FromName("ffffcc");
                                    break;
                                case 2:
                                    txt.Visible = false;
                                    break;
                            }

                        }
                    
                    }                    
                }
                return;
            }

            // --------------------------- Panel
            if (control_type.Equals("Panel"))
            {
                Panel pnl = Bas_Utility.Utilities.GetPanel(wpage, control_name);
                if (pnl != null)
                {
                    if (control_state_status.Equals("1"))
                    {
                        switch (iAction)
                        {
                            case 1:
                                pnl.Enabled = true;
                                break;
                            case 2:
                                pnl.Visible = true;
                                break;
                        }

                    }
                    else
                    {
                        if (control_state_status.Equals("0"))
                        {
                            switch (iAction)
                            {
                                case 1:
                                    pnl.Enabled = false;
                                    pnl.BackColor = System.Drawing.Color.FromName("ffffcc");
                                    break;
                                case 2:
                                    pnl.Visible = false;
                                    break;
                            }

                        }

                    }
                }
                return;
            }

            // --------------------------- DropDownList
            if (control_type.Equals("DropDownList"))
            {
                DropDownList ddl = Bas_Utility.Utilities.GetDropDown(wpage, control_name);
                if (ddl != null)
                {                    
                    if (control_state_status.Equals("1"))
                    {
                        if (control_state_status.Equals("1"))
                        {
                            switch (iAction)
                            {
                                case 1:
                                    ddl.Enabled = true;
                                    break;
                                case 2:
                                    ddl.Visible = true;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        switch (iAction)
                        {
                            case 1:
                                ddl.Enabled = false;
                                ddl.BackColor = System.Drawing.Color.FromName("ffffcc");
                                break;
                            case 2:
                                ddl.Visible = false;
                                break;
                        }
                       
                    }                    
                }
                return;
            }
            // --------------------------- ListBox
            if (control_type.Equals("ListBox"))
            {
                ListBox ddl = Bas_Utility.Utilities.GetListBox(wpage, control_name);
                if (ddl != null)
                {                    
                    if (control_state_status.Equals("1"))
                    {
                        if (control_state_status.Equals("1"))
                        {
                            switch (iAction)
                            {
                                case 1:
                                    ddl.Enabled = true;
                                    break;
                                case 2:
                                    ddl.Visible = true;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        switch (iAction)
                        {
                            case 1:
                                ddl.Enabled = false;
                                ddl.BackColor = System.Drawing.Color.FromName("ffffcc");
                                break;
                            case 2:
                                ddl.Visible = false;
                                break;
                        }

                    }                    
                }
                return;
            }
            // --------------------------- RadioButton
            if (control_type.Equals("RadioButton"))
            {
                RadioButton ddl = Bas_Utility.Utilities.GetRadioButton(wpage, control_name);
                if (ddl != null)
                {
                    if (control_state_status.Equals("1"))
                    {
                        if (control_state_status.Equals("1"))
                        {
                            switch (iAction)
                            {
                                case 1:
                                    ddl.Enabled = true;
                                    break;
                                case 2:
                                    ddl.Visible = true;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        switch (iAction)
                        {
                            case 1:
                                ddl.Enabled = false;
                                ddl.BackColor = System.Drawing.Color.FromName("ffffcc");
                                break;
                            case 2:
                                ddl.Visible = false;
                                break;
                        }
                    }
                }
                return;
            }
            // --------------------------- CheckBoxList
            if (control_type.Equals("CheckBoxList"))
            {
                CheckBoxList ddl = Bas_Utility.Utilities.GetCheckBoxList(wpage, control_name);
                if (ddl != null)
                {
                    if (control_state_status.Equals("1"))
                    {
                        if (control_state_status.Equals("1"))
                        {
                            switch (iAction)
                            {
                                case 1:
                                    ddl.Enabled = true;
                                    break;
                                case 2:
                                    ddl.Visible = true;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        switch (iAction)
                        {
                            case 1:
                                ddl.Enabled = false;
                                ddl.BackColor = System.Drawing.Color.FromName("ffffcc");
                                break;
                            case 2:
                                ddl.Visible = false;
                                break;
                        }
                    }
                }
                return;
            }
            // --------------------------- CheckBox
            if (control_type.Equals("CheckBox"))
            {
                CheckBox ddl = Bas_Utility.Utilities.GetCheckBox(wpage, control_name);
                if (ddl != null)
                {
                    if (control_state_status.Equals("1"))
                    {
                        if (control_state_status.Equals("1"))
                        {
                            switch (iAction)
                            {
                                case 1:
                                    ddl.Enabled = true;
                                    break;
                                case 2:
                                    ddl.Visible = true;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        switch (iAction)
                        {
                            case 1:
                                ddl.Enabled = false;
                                ddl.BackColor = System.Drawing.Color.FromName("ffffcc");
                                break;
                            case 2:
                                ddl.Visible = false;
                                break;
                        }
                    }
                }
                return;
            }
            // --------------------------- LinkButton
            if (control_type.Equals("LinkButton"))
            {
                LinkButton cntrl = Bas_Utility.Utilities.GetLinkButton(wpage, control_name);
                if (cntrl != null)
                {
                    if (control_state_status.Equals("1"))
                    {
                        if (control_state_status.Equals("1"))
                        {
                            switch (iAction)
                            {
                                case 1:
                                    cntrl.Enabled = true;
                                    break;
                                case 2:
                                    cntrl.Visible = true;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        switch (iAction)
                        {
                            case 1:
                                cntrl.Enabled = false;
                                cntrl.BackColor = System.Drawing.Color.FromName("ffffcc");
                                break;
                            case 2:
                                cntrl.Visible = false;
                                break;
                        }
                    }
                }
                return;
            }
            // --------------------------- LinkButton
            if (control_type.Equals("LinkButton"))
            {
                LinkButton cntrl = Bas_Utility.Utilities.GetLinkButton(wpage, control_name);
                if (cntrl != null)
                {
                    if (control_state_status.Equals("1"))
                    {
                        if (control_state_status.Equals("1"))
                        {
                            switch (iAction)
                            {
                                case 1:
                                    cntrl.Enabled = true;
                                    break;
                                case 2:
                                    cntrl.Visible = true;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        switch (iAction)
                        {
                            case 1:
                                cntrl.Enabled = false;
                                cntrl.BackColor = System.Drawing.Color.FromName("ffffcc");
                                break;
                            case 2:
                                cntrl.Visible = false;
                                break;
                        }
                     
                    }
                }
                return;
            }
            // --------------------------- ImageButton
            if (control_type.Equals("ImageButton"))
            {
                ImageButton cntrl = Bas_Utility.Utilities.GetImageButton(wpage, control_name);
                if (cntrl != null)
                {
                    if (control_state_status.Equals("1"))
                    {
                        if (control_state_status.Equals("1"))
                        {
                            switch (iAction)
                            {
                                case 1:
                                    cntrl.Enabled = true;
                                    break;
                                case 2:
                                    cntrl.Visible = true;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        switch (iAction)
                        {
                            case 1:
                                cntrl.Enabled = false;
                                cntrl.BackColor = System.Drawing.Color.FromName("ffffcc");
                                break;
                            case 2:
                                cntrl.Visible = false;
                                break;
                        }
                    }
                }
                return;
            }

            // --------------------------- HyperLink
            if (control_type.Equals("HyperLink"))
            {
                HyperLink cntrl = Bas_Utility.Utilities.GetHyperLink(wpage, control_name);
                if (cntrl != null)
                {
                    if (control_state_status.Equals("1"))
                    {
                        if (control_state_status.Equals("1"))
                        {
                            switch (iAction)
                            {
                                case 1:
                                    cntrl.Enabled = true;
                                    break;
                                case 2:
                                    cntrl.Visible = true;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        switch (iAction)
                        {
                            case 1:
                                cntrl.Enabled = false;
                                cntrl.BackColor = System.Drawing.Color.FromName("ffffcc");
                                break;
                            case 2:
                                cntrl.Visible = false;
                                break;
                        }
                    }
                }
                return;
            }
            // --------------------------- HyperLink
            if (control_type.Equals("HyperLink"))
            {
                HyperLink cntrl = Bas_Utility.Utilities.GetHyperLink(wpage, control_name);
                if (cntrl != null)
                {
                    if (control_state_status.Equals("1"))
                    {
                        if (control_state_status.Equals("1"))
                        {
                            switch (iAction)
                            {
                                case 1:
                                    cntrl.Enabled = true;
                                    break;
                                case 2:
                                    cntrl.Visible = true;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        switch (iAction)
                        {
                            case 1:
                                cntrl.Enabled = false;
                                cntrl.BackColor = System.Drawing.Color.FromName("ffffcc");
                                break;
                            case 2:
                                cntrl.Visible = false;
                                break;
                        }
                    }
                }
                return;
            }
            // --------------------------- RadioButton
            if (control_type.Equals("RadioButton"))
            {
                RadioButton ctrl = Bas_Utility.Utilities.GetRadioButton(wpage, control_name);
                if (ctrl != null)
                {
                    if (control_state_status.Equals("1"))
                    {
                        if (control_state_status.Equals("1"))
                        {
                            switch (iAction)
                            {
                                case 1:
                                    ctrl.Enabled = true;
                                    break;
                                case 2:
                                    ctrl.Visible = true;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        switch (iAction)
                        {
                            case 1:
                                ctrl.Enabled = false;
                                ctrl.BackColor = System.Drawing.Color.FromName("ffffcc");
                                break;
                            case 2:
                                ctrl.Visible = false;
                                break;
                        }
                    }
                }
                return;
            }
            // --------------------------- RadioButton
            if (control_type.Equals("RadioButton"))
            {
                RadioButton ctrl = Bas_Utility.Utilities.GetRadioButton(wpage, control_name);
                if (ctrl != null)
                {
                    if (control_state_status.Equals("1"))
                    {
                        if (control_state_status.Equals("1"))
                        {
                            switch (iAction)
                            {
                                case 1:
                                    ctrl.Enabled = true;
                                    break;
                                case 2:
                                    ctrl.Visible = true;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        switch (iAction)
                        {
                            case 1:
                                ctrl.Enabled = false;
                                ctrl.BackColor = System.Drawing.Color.FromName("ffffcc");
                                break;
                            case 2:
                                ctrl.Visible = false;
                                break;
                        }
                    }
                }
                return;
            }
            // --------------------------- CheckBoxList
            if (control_type.Equals("CheckBoxList"))
            {
                CheckBoxList ctrl = Bas_Utility.Utilities.GetCheckBoxList(wpage, control_name);
                if (ctrl != null)
                {
                    if (control_state_status.Equals("1"))
                    {
                        if (control_state_status.Equals("1"))
                        {
                            switch (iAction)
                            {
                                case 1:
                                    ctrl.Enabled = true;
                                    break;
                                case 2:
                                    ctrl.Visible = true;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        switch (iAction)
                        {
                            case 1:
                                ctrl.Enabled = false;
                                ctrl.BackColor = System.Drawing.Color.FromName("ffffcc");
                                break;
                            case 2:
                                ctrl.Visible = false;
                                break;
                        }
                    }
                }
                return;
            }
            // --------------------------- CheckBox
            if (control_type.Equals("CheckBox"))
            {
                CheckBox ctrl = Bas_Utility.Utilities.GetCheckBox(wpage, control_name);
                if (ctrl != null)
                {
                    if (control_state_status.Equals("1"))
                    {
                        if (control_state_status.Equals("1"))
                        {
                            switch (iAction)
                            {
                                case 1:
                                    ctrl.Enabled = true;
                                    break;
                                case 2:
                                    ctrl.Visible = true;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        switch (iAction)
                        {
                            case 1:
                                ctrl.Enabled = false;
                                ctrl.BackColor = System.Drawing.Color.FromName("ffffcc");
                                break;
                            case 2:
                                ctrl.Visible = false;
                                break;
                        }
                    }
                }
                return;
            }
            // --------------------------- RadMaskedTextBox
            if (control_type.Equals("RadMaskedTextBox"))
            {
                RadMaskedTextBox txt = Bas_Utility.Utilities.GetRadMaskedTextBox(wpage, control_name);
                if (txt != null)
                {
                    if (control_state_status.Equals("1"))
                    {
                        if (control_state_status.Equals("1"))
                        {
                            switch (iAction)
                            {
                                case 1:
                                    txt.Enabled = true;
                                    break;
                                case 2:
                                    txt.Visible = true;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        if (control_state_status.Equals("0"))
                        {
                            switch (iAction)
                            {
                                case 1:
                                    txt.Enabled = false;
                                    break;
                                case 2:
                                    txt.Visible = false;
                                    break;
                            }
                        }
                    }
                }
                return;
            }

            // --------------------------- RadTextBox
            if (control_type.Equals("RadTextBox"))
            {
                RadTextBox txt = Bas_Utility.Utilities.GetRadTextBox(wpage, control_name);
                if (txt != null)
                {
                    if (control_state_status.Equals("1"))
                    {
                        if (control_state_status.Equals("1"))
                        {
                            switch (iAction)
                            {
                                case 1:
                                    txt.Enabled = true;
                                    break;
                                case 2:
                                    txt.Visible = true;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        if (control_state_status.Equals("0"))
                        {
                            switch (iAction)
                            {
                                case 1:
                                    txt.Enabled = false;
                                    break;
                                case 2:
                                    txt.Visible = false;
                                    break;
                            }
                        }
                    }
                }
                return;
            }
            // --------------------------- RadComboBox
            if (control_type.Equals("RadComboBox"))
            {
                RadComboBox txt = Bas_Utility.Utilities.GetRadComboBox(wpage, control_name);
                if (txt != null)
                {
                    if (control_state_status.Equals("1"))
                    {
                        if (control_state_status.Equals("1"))
                        {
                            switch (iAction)
                            {
                                case 1:
                                    txt.Enabled = true;
                                    break;
                                case 2:
                                    txt.Visible = true;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        if (control_state_status.Equals("0"))
                        {
                            switch (iAction)
                            {
                                case 1:
                                    txt.Enabled = false;
                                    break;
                                case 2:
                                    txt.Visible = false;
                                    break;
                            }
                        }
                    }
                }
                return;
            }
            // --------------------------- RadDateInput
            if (control_type.Equals("RadDateInput"))
            {
                RadDateInput txt = Bas_Utility.Utilities.GetRadDateInput(wpage, control_name);
                if (txt != null)
                {
                    if (control_state_status.Equals("1"))
                    {
                        if (control_state_status.Equals("1"))
                        {
                            switch (iAction)
                            {
                                case 1:
                                    txt.Enabled = true;
                                    break;
                                case 2:
                                    txt.Visible = true;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        if (control_state_status.Equals("0"))
                        {
                            switch (iAction)
                            {
                                case 1:
                                    txt.Enabled = false;
                                    break;
                                case 2:
                                    txt.Visible = false;
                                    break;
                            }
                        }
                    }
                }
                return;
            }
            // --------------------------- RadDatePicker
            if (control_type.Equals("RadDatePicker"))
            {
                RadDatePicker txt = Bas_Utility.Utilities.GetRadDatePicker(wpage, control_name);
                if (txt != null)
                {
                    if (control_state_status.Equals("1"))
                    {
                        if (control_state_status.Equals("1"))
                        {
                            switch (iAction)
                            {
                                case 1:
                                    txt.Enabled = true;
                                    break;
                                case 2:
                                    txt.Visible = true;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        if (control_state_status.Equals("0"))
                        {
                            switch (iAction)
                            {
                                case 1:
                                    txt.Enabled = false;
                                    break;
                                case 2:
                                    txt.Visible = false;
                                    break;
                            }
                        }
                    }
                }
                return;
            }
            // --------------------------- RadEditor
            if (control_type.Equals("RadEditor"))
            {
                RadEditor txt = Bas_Utility.Utilities.GetRadEditor(wpage, control_name);
                if (txt != null)
                {
                    if (control_state_status.Equals("1"))
                    {
                        if (control_state_status.Equals("1"))
                        {
                            switch (iAction)
                            {
                                case 1:
                                    txt.Enabled = true;
                                    break;
                                case 2:
                                    txt.Visible = true;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        if (control_state_status.Equals("0"))
                        {
                            switch (iAction)
                            {
                                case 1:
                                    txt.Enabled = false;
                                    break;
                                case 2:
                                    txt.Visible = false;
                                    break;
                            }
                        }
                    }
                }
                return;
            }
            // --------------------------- RadMaskedTextBox
            if (control_type.Equals("RadMaskedTextBox"))
            {
                RadMaskedTextBox txt = Bas_Utility.Utilities.GetRadMaskedTextBox(wpage, control_name);
                if (txt != null)
                {
                    if (control_state_status.Equals("1"))
                    {
                        if (control_state_status.Equals("1"))
                        {
                            switch (iAction)
                            {
                                case 1:
                                    txt.Enabled = true;
                                    break;
                                case 2:
                                    txt.Visible = true;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        if (control_state_status.Equals("0"))
                        {
                            switch (iAction)
                            {
                                case 1:
                                    txt.Enabled = false;
                                    break;
                                case 2:
                                    txt.Visible = false;
                                    break;
                            }
                        }
                      
                    }
                }
                return;
            }


        }



        public static void Start(Page wpage)
        {
            SetControlsStatus(wpage);
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            
        } 
    }
}
