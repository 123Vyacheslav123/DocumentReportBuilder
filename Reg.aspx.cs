using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace DocumentReportBuilder
{
    public partial class Reg : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
        }

        protected void Page_PreInit(object sender,EventArgs e)
        {
    
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected  void ButtonRegistration_Click(object sender, EventArgs e)
        {
            string TypeOfAccount="";
            string DropDownValue =DropDownListReg.SelectedValue.ToString();
            int DropDownValueInt=Int32.Parse(DropDownValue);
            if (DropDownValueInt==0)
            {
                TypeOfAccount = "Teacher";
            }
            else
            {
                TypeOfAccount = "Student";
            }
            SqlCommand cmd = new SqlCommand("INSERT INTO [USERS]([Firstname],[Surname],[Patronymic],[Mail],[Typeofaccount],[Password]) VALUES('"+TextBoxFirstNameReg.Text+"','"+TextBoxLastNameReg.Text+"','"+ TextBoxPatronymicReg.Text+ "','"+TextBoxMailReg.Text+ "','"+ TypeOfAccount + "','"+TextBoxPassReg.Text+"')", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}