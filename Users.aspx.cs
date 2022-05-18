using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI.HtmlControls;

namespace DocumentReportBuilder
{
    public partial class Users : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

            // это нужно для того чтобы работало создание конфигурации
            Session["STYLETEXT"] = "0";
            Session["STYLETABLE"] = "0";
            Session["STYLEPIC"] = "0";
            Session["STYLELIST"] = "0";



            con.Open();
            // находим имя текущего пользвателя
            string UserMail = (string)Session["USERMAIL"];
            string sqlName = "SELECT [ShortUserName] FROM [USERS] WHERE [Mail]='" + UserMail + "' ";
            SqlCommand profile = new SqlCommand(sqlName, con);
            SqlDataReader ProfileReader = profile.ExecuteReader();
            while (ProfileReader.Read())
            {
                string ShortUserName = (string)ProfileReader["ShortUserName"];

                ////// Генерация меню в правом верхнем углу

                HtmlGenericControl li = new HtmlGenericControl("li");
                MenuList.Controls.Add(li);

                HtmlGenericControl anchor = new HtmlGenericControl("a");
                anchor.Attributes.Add("href", "/Profile.aspx");
                anchor.Attributes.Add("class", "down");
                anchor.InnerText = ShortUserName;

                li.Controls.Add(anchor);



                HtmlGenericControl ul = new HtmlGenericControl("ul");
                ul.Attributes.Add("class", "submenu");
                li.Controls.Add(ul);

                HtmlGenericControl li1 = new HtmlGenericControl("li");
                ul.Controls.Add(li1);


                HtmlGenericControl anchor1 = new HtmlGenericControl("a");
                anchor1.Attributes.Add("href", "/Profile.aspx");
                anchor1.InnerText = "Профиль";
                li1.Controls.Add(anchor1);

                HtmlGenericControl anchor2 = new HtmlGenericControl("a");
                anchor2.Attributes.Add("href", "/Reg.aspx");
                anchor2.InnerText = "Выход";
                li1.Controls.Add(anchor2);
            }
            ProfileReader.Close();


            // находим айди пользователя
            string getuserid = "SELECT [ID] FROM [USERS] WHERE [Mail] = '" + UserMail + "' ";
            SqlCommand getid = new SqlCommand(getuserid, con);
            SqlDataReader finduserid = getid.ExecuteReader();
            int id = 0;
            while (finduserid.Read())
            {
                id = (int)finduserid["ID"];
            }
            finduserid.Close();

            if (!IsPostBack)
            {

                string UsersTable = "SELECT [ShortUserName],[Mail] FROM [USERS] WHERE [TypeofAccount]= 'Student'";

                SqlCommand users = new SqlCommand(UsersTable, con);
                SqlDataReader usersreader = users.ExecuteReader();

                if (usersreader.HasRows == true)
                {

                    GridViewTableUsers.DataSource = usersreader;
                    GridViewTableUsers.DataBind();
                }
                usersreader.Close();
            }
            con.Close();
        }


        protected void ButtonChoose_Click(object sender, EventArgs e)
        {
            //находим на какую кнопку нажали
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            string mailtosend = row.Cells[1].Text;


            // берем текст из текстбокса для даты
            TextBox tb = row.FindControl("TextBoxDate") as TextBox;
            string datetosend = tb.Text;
        

            string confname = (string)Session["NAMEOFCONF"];

  

            con.Open();
            string UserMail = (string)Session["USERMAIL"];
            int conftosend = 0;

            // находим нужную конфигурацию
            string sqldatatosend = "SELECT [ID] FROM [CONFIGURATION] WHERE [CREATEDBY] = '" + UserMail + "' AND [CONFNAME] = N'" + confname + "'  ";
            SqlCommand sendconf = new SqlCommand(sqldatatosend, con);
            SqlDataReader datatosend = sendconf.ExecuteReader();
            while (datatosend.Read())
            {
                conftosend = datatosend.GetInt32(datatosend.GetOrdinal("ID"));
            }
            datatosend.Close();

            // находим айди пользователя которому отправляем
            string getuserid = "SELECT [ID] FROM [USERS] WHERE [Mail] = '" + mailtosend + "' ";
            SqlCommand getid = new SqlCommand(getuserid, con);
            SqlDataReader finduserid = getid.ExecuteReader();
            int id = 0;
            while (finduserid.Read())
            {
                id = (int)finduserid["ID"];
            }
            finduserid.Close();



            // привязываем конфигурацию к пользователю
            string sendingconf = "INSERT INTO [ReportUsers] ([Configuration],[User],[Date]) VALUES('" + conftosend + "'," + id + ",'"+datetosend+"')";
            SqlCommand confsending = new SqlCommand(sendingconf, con);
            confsending.ExecuteNonQuery();
            con.Close();
        }

    }
}