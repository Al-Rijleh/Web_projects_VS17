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
    public partial class GetPageControls : System.Web.UI.Page
    {
        public static string session_id = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            session_id = Request.Cookies["Session_ID"].Value.ToString();
        }

        public static void GetFields(Control oMe,string session_id_, Oracle.DataAccess.Client.OracleConnection conn)
        {
            session_id = session_id_;
            GetTextBox(oMe, conn);
            GetPanel(oMe, conn);
            GetLinkButton(oMe, conn);
            GetHyperLink(oMe, conn);
            GetDropDownList(oMe, conn);
            GetListBox(oMe, conn);
            GetCheckBox(oMe, conn);
            GetCheckBoxList(oMe, conn);
            GetRadioButton(oMe, conn);
            GetRadComboBox(oMe, conn);
            GetRadDateInput(oMe, conn);
            GetRadDatePicker(oMe, conn);
            GetRadEditor(oMe, conn);
            GetRadNumericTextBox(oMe, conn);
            GetRadTextBox(oMe, conn);
            GetRadMaskedTextBox(oMe, conn);

        }

        public static void SaveControl(string strControlName,string strControlType,Oracle.DataAccess.Client.OracleConnection conn)
        {            
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_","in","varchar2",session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("control_name_", "in", "varchar2", strControlName));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("control_type_", "in", "varchar2", strControlType));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_web_pages_managmwnts.saveDefaultControl", al, conn);
        }

        public static void GetTextBox(Control oMe, Oracle.DataAccess.Client.OracleConnection conn)
        {
            int cnt = oMe.Controls.Count;
            TextBox cntrl = null;
            for (int i = 0; i < cnt; i++)
            {
                string s = oMe.Controls[i].GetType().ToString();
                if ((oMe.Controls[i].GetType().ToString() ==
                    "System.Web.UI.WebControls.TextBox"))
                {
                    cntrl = (TextBox)oMe.Controls[i];
                    SaveControl(cntrl.ID, "TextBox", conn);
                }
                else
                    if (oMe.Controls[i].HasControls())
                    {
                        GetTextBox(oMe.Controls[i], conn);
                    }
            }
        }

        public static void GetPanel(Control oMe, Oracle.DataAccess.Client.OracleConnection conn)
        {
            int cnt = oMe.Controls.Count;
            Panel cntrl = null;
            for (int i = 0; i < cnt; i++)
            {
                string s = oMe.Controls[i].GetType().ToString();
                if ((oMe.Controls[i].GetType().ToString() ==
                    "System.Web.UI.WebControls.Panel"))
                {
                    cntrl = (Panel)oMe.Controls[i];
                    SaveControl(cntrl.ID, "Panel", conn);
                }
                else
                    if (oMe.Controls[i].HasControls())
                    {
                        GetPanel(oMe.Controls[i], conn);
                    }
            }
        }

        public static void GetLinkButton(Control oMe, Oracle.DataAccess.Client.OracleConnection conn)
        {
            int cnt = oMe.Controls.Count;
            LinkButton cntrl = null;
            for (int i = 0; i < cnt; i++)
            {
                string s = oMe.Controls[i].GetType().ToString();
                if ((oMe.Controls[i].GetType().ToString() ==
                    "System.Web.UI.WebControls.LinkButton"))
                {
                    cntrl = (LinkButton)oMe.Controls[i];
                    SaveControl(cntrl.ID, "LinkButton", conn);
                }
                else
                    if (oMe.Controls[i].HasControls())
                    {
                        GetLinkButton(oMe.Controls[i], conn);
                    }
            }
        }

        public static void GetHyperLink(Control oMe, Oracle.DataAccess.Client.OracleConnection conn)
        {
            int cnt = oMe.Controls.Count;
            HyperLink cntrl = null;
            for (int i = 0; i < cnt; i++)
            {
                string s = oMe.Controls[i].GetType().ToString();
                if ((oMe.Controls[i].GetType().ToString() ==
                    "System.Web.UI.WebControls.HyperLink"))
                {
                    cntrl = (HyperLink)oMe.Controls[i];
                    SaveControl(cntrl.ID, "HyperLink", conn);
                }
                else
                    if (oMe.Controls[i].HasControls())
                    {
                        GetHyperLink(oMe.Controls[i], conn);
                    }
            }
        }

        public static void GetDropDownList(Control oMe, Oracle.DataAccess.Client.OracleConnection conn)
        {
            int cnt = oMe.Controls.Count;
            DropDownList cntrl = null;
            for (int i = 0; i < cnt; i++)
            {
                string s = oMe.Controls[i].GetType().ToString();
                if ((oMe.Controls[i].GetType().ToString() ==
                    "System.Web.UI.WebControls.DropDownList"))
                {
                    cntrl = (DropDownList)oMe.Controls[i];
                    SaveControl(cntrl.ID, "DropDownList", conn);
                }
                else
                    if (oMe.Controls[i].HasControls())
                    {
                        GetDropDownList(oMe.Controls[i], conn);
                    }
            }
        }

        public static void GetListBox(Control oMe, Oracle.DataAccess.Client.OracleConnection conn)
        {
            int cnt = oMe.Controls.Count;
            ListBox cntrl = null;
            for (int i = 0; i < cnt; i++)
            {
                string s = oMe.Controls[i].GetType().ToString();
                if ((oMe.Controls[i].GetType().ToString() ==
                    "System.Web.UI.WebControls.ListBox"))
                {
                    cntrl = (ListBox)oMe.Controls[i];
                    SaveControl(cntrl.ID, "ListBox", conn);
                }
                else
                    if (oMe.Controls[i].HasControls())
                    {
                        GetListBox(oMe.Controls[i], conn);
                    }
            }
        }

        public static void GetCheckBox(Control oMe, Oracle.DataAccess.Client.OracleConnection conn)
        {
            int cnt = oMe.Controls.Count;
            CheckBox cntrl = null;
            for (int i = 0; i < cnt; i++)
            {
                string s = oMe.Controls[i].GetType().ToString();
                if ((oMe.Controls[i].GetType().ToString() ==
                    "System.Web.UI.WebControls.CheckBox"))
                {
                    cntrl = (CheckBox)oMe.Controls[i];
                    SaveControl(cntrl.ID, "CheckBox", conn);
                }
                else
                    if (oMe.Controls[i].HasControls())
                    {
                        GetCheckBox(oMe.Controls[i], conn);
                    }
            }
        }

        public static void GetCheckBoxList(Control oMe, Oracle.DataAccess.Client.OracleConnection conn)
        {
            int cnt = oMe.Controls.Count;
            CheckBoxList cntrl = null;
            for (int i = 0; i < cnt; i++)
            {
                string s = oMe.Controls[i].GetType().ToString();
                if ((oMe.Controls[i].GetType().ToString() ==
                    "System.Web.UI.WebControls.CheckBoxList"))
                {
                    cntrl = (CheckBoxList)oMe.Controls[i];
                    SaveControl(cntrl.ID, "CheckBoxList", conn);
                }
                else
                    if (oMe.Controls[i].HasControls())
                    {
                        GetCheckBoxList(oMe.Controls[i], conn);
                    }
            }
        }

        public static void GetRadioButton(Control oMe, Oracle.DataAccess.Client.OracleConnection conn)
        {
            int cnt = oMe.Controls.Count;
            RadioButton cntrl = null;
            for (int i = 0; i < cnt; i++)
            {
                string s = oMe.Controls[i].GetType().ToString();
                if ((oMe.Controls[i].GetType().ToString() ==
                    "System.Web.UI.WebControls.RadioButton"))
                {
                    cntrl = (RadioButton)oMe.Controls[i];
                    SaveControl(cntrl.ID, "RadioButton", conn);
                }
                else
                    if (oMe.Controls[i].HasControls())
                    {
                        GetRadioButton(oMe.Controls[i], conn);
                    }
            }
        }

        public static void GetRadComboBox(Control oMe, Oracle.DataAccess.Client.OracleConnection conn)
        {
            int cnt = oMe.Controls.Count;
            RadComboBox cntrl = null;
            for (int i = 0; i < cnt; i++)
            {
                string s = oMe.Controls[i].GetType().ToString();
                if ((oMe.Controls[i].GetType().ToString() ==
                    "Telerik.Web.UI.RadComboBox"))
                {
                    cntrl = (RadComboBox)oMe.Controls[i];
                    SaveControl(cntrl.ID, "RadComboBox", conn);
                }
                else
                    if (oMe.Controls[i].HasControls())
                    {
                        GetRadComboBox(oMe.Controls[i], conn);
                    }
            }
        }

        public static void GetRadDateInput(Control oMe, Oracle.DataAccess.Client.OracleConnection conn)
        {
            int cnt = oMe.Controls.Count;
            RadDateInput cntrl = null;
            for (int i = 0; i < cnt; i++)
            {
                string s = oMe.Controls[i].GetType().ToString();
                if ((oMe.Controls[i].GetType().ToString() ==
                    "Telerik.Web.UI.RadDateInput"))
                {
                    cntrl = (RadDateInput)oMe.Controls[i];
                    SaveControl(cntrl.ID, "RadDateInput", conn);
                }
                else
                    if (oMe.Controls[i].HasControls())
                    {
                        GetRadDateInput(oMe.Controls[i], conn);
                    }
            }
        }

        public static void GetRadDatePicker(Control oMe, Oracle.DataAccess.Client.OracleConnection conn)
        {
            int cnt = oMe.Controls.Count;
            RadDatePicker cntrl = null;
            for (int i = 0; i < cnt; i++)
            {
                string s = oMe.Controls[i].GetType().ToString();
                if ((oMe.Controls[i].GetType().ToString() ==
                    "Telerik.Web.UI.RadDatePicker"))
                {
                    cntrl = (RadDatePicker)oMe.Controls[i];
                    SaveControl(cntrl.ID, "RadDatePicker", conn);
                }
                else
                    if (oMe.Controls[i].HasControls())
                    {
                        GetRadDatePicker(oMe.Controls[i], conn);
                    }
            }
        }

        public static void GetRadEditor(Control oMe, Oracle.DataAccess.Client.OracleConnection conn)
        {
            int cnt = oMe.Controls.Count;
            RadEditor cntrl = null;
            for (int i = 0; i < cnt; i++)
            {
                string s = oMe.Controls[i].GetType().ToString();
                if ((oMe.Controls[i].GetType().ToString() ==
                    "Telerik.Web.UI.RadEditor"))
                {
                    cntrl = (RadEditor)oMe.Controls[i];
                    SaveControl(cntrl.ID, "RadEditor", conn);
                }
                else
                    if (oMe.Controls[i].HasControls())
                    {
                        GetRadEditor(oMe.Controls[i], conn);
                    }
            }
        }

        public static void GetRadNumericTextBox(Control oMe, Oracle.DataAccess.Client.OracleConnection conn)
        {
            int cnt = oMe.Controls.Count;
            RadNumericTextBox cntrl = null;
            for (int i = 0; i < cnt; i++)
            {
                string s = oMe.Controls[i].GetType().ToString();
                if ((oMe.Controls[i].GetType().ToString() ==
                    "Telerik.Web.UI.RadNumericTextBox"))
                {
                    cntrl = (RadNumericTextBox)oMe.Controls[i];
                    SaveControl(cntrl.ID, "RadNumericTextBox", conn);
                }
                else
                    if (oMe.Controls[i].HasControls())
                    {
                        GetRadNumericTextBox(oMe.Controls[i], conn);
                    }
            }
        }

        public static void GetRadTextBox(Control oMe, Oracle.DataAccess.Client.OracleConnection conn)
        {
            int cnt = oMe.Controls.Count;
            RadTextBox cntrl = null;
            for (int i = 0; i < cnt; i++)
            {
                string s = oMe.Controls[i].GetType().ToString();
                if ((oMe.Controls[i].GetType().ToString() ==
                    "Telerik.Web.UI.RadTextBox"))
                {
                    cntrl = (RadTextBox)oMe.Controls[i];
                    SaveControl(cntrl.ID, "RadTextBox", conn);
                }
                else
                    if (oMe.Controls[i].HasControls())
                    {
                        GetRadTextBox(oMe.Controls[i], conn);
                    }
            }
        }

        public static void GetRadMaskedTextBox(Control oMe, Oracle.DataAccess.Client.OracleConnection conn)
        {
            int cnt = oMe.Controls.Count;
            RadMaskedTextBox cntrl = null;
            for (int i = 0; i < cnt; i++)
            {
                string s = oMe.Controls[i].GetType().ToString();
                if ((oMe.Controls[i].GetType().ToString() ==
                    "Telerik.Web.UI.RadMaskedTextBox"))
                {
                    cntrl = (RadMaskedTextBox)oMe.Controls[i];
                    SaveControl(cntrl.ID, "RadMaskedTextBox", conn);
                }
                else
                    if (oMe.Controls[i].HasControls())
                    {
                        GetRadMaskedTextBox(oMe.Controls[i], conn);
                    }
            }
        }

        public static void GetRadioButtonList(Control oMe, Oracle.DataAccess.Client.OracleConnection conn)
        {
            int cnt = oMe.Controls.Count;
            RadioButtonList cntrl = null;
            for (int i = 0; i < cnt; i++)
            {
                string s = oMe.Controls[i].GetType().ToString();
                if ((oMe.Controls[i].GetType().ToString() ==
                    "System.Web.UI.WebControls.RadioButtonList"))
                {
                    cntrl = (RadioButtonList)oMe.Controls[i];
                    SaveControl(cntrl.ID, "RadioButtonList", conn);
                }
                else
                    if (oMe.Controls[i].HasControls())
                    {
                        GetRadioButtonList(oMe.Controls[i],conn);
                    }
            }
        } 
    }
}
