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

            bool mailcheck;
            string sqlCheckMail = "IF NOT('"+TextBoxMailReg.Text+"' LIKE '%[A-Z0-9][@][A-Z0-9]%[.][A-Z0-9]%' AND '"+TextBoxMailReg.Text+"' NOT LIKE '%[ <> ]%' BEGIN SELECT 'FALSE' END ELSE BEGIN SELECT 'TRUE' END)";
            SqlCommand sqlmailcheck = new SqlCommand(sqlCheckMail,con);
            mailcheck = Convert.ToBoolean(sqlmailcheck.ExecuteScalar());


            if (mailcheck == true) //// проверка на корректность почты
            {
                bool status;
                string sqlExistsMail = "IF EXISTS(SELECT [Mail] FROM [USERS] WHERE [Mail] = '" + TextBoxMailReg.Text + "') BEGIN SELECT 'TRUE' END ELSE BEGIN SELECT 'FALSE' END";
                SqlCommand mailexists = new SqlCommand(sqlExistsMail, con);
                status = Convert.ToBoolean(mailexists.ExecuteScalar());

                
                if (status == false) ///////////// проверка на наличие уже зарегистрированной почты
                {
                    /////////////// вставка пользователя в бд
                    string SqlInsertUser = "INSERT INTO[USERS]([Firstname],[Surname],[Patronymic],[Mail],[Typeofaccount],[Password]) VALUES('" + TextBoxFirstNameReg.Text + "', '" + TextBoxLastNameReg.Text + "', '" + TextBoxPatronymicReg.Text + "', '" + TextBoxMailReg.Text + "', '" + TypeOfAccount + "', '" + TextBoxPassReg.Text + "')";
                    SqlCommand cmd = new SqlCommand(SqlInsertUser, con);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    ////  если такая почта существует в базе
                }

            }
            else
            {
                ////// если почта не корректна

            }

            con.Close();
        }
    }
}