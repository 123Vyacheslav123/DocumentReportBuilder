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

    public partial class Configurations : System.Web.UI.Page
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

            string conftable = "SELECT [CONFNAME],[CREATEDBY],[ShortUserName] FROM [CONFIGURATION] INNER JOIN [USERS] ON CREATEDBY=Mail WHERE Mail='" + UserMail + "'  ";
            SqlCommand tableconf = new SqlCommand(conftable, con);
            SqlDataReader tableofconf = tableconf.ExecuteReader();

            if (tableofconf.HasRows==true)
            {
                GridViewTableConf.DataSource = tableofconf;
                GridViewTableConf.DataBind();
            }
            tableofconf.Close();
            con.Close();

        }

        protected void ButtonCheck_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            Session["NAMEOFCONF"] = row.Cells[0].Text;
            Session["CREATOR"] = row.Cells[1].Text;
            Server.Transfer("~/Check.aspx");
        }

        protected void ButtonChoose_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            Session["NAMEOFCONF"] = row.Cells[0].Text;
            Server.Transfer("~/Users.aspx");
        }

    }
}