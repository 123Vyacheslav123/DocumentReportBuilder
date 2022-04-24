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
    //internal sealed class Table
    //{
    //    public int ID { get; set; }
    //    public string Name { get; set; }
    //    public string Date { get; set; }
    //    public string Createdby { get; set; }
    //    public bool ActiveRow { get; set; }
    //}

    public partial class Configurations : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            // находим имя текущего пользвателя
            string UserMail = (string)Session["USERMAIL"];
            string sqlName = "SELECT [Firstname], [Surname], [Patronymic], [Typeofaccount] FROM [USERS] WHERE [Mail]='" + UserMail + "' ";
            SqlCommand profile = new SqlCommand(sqlName, con);
            SqlDataReader ProfileReader = profile.ExecuteReader();
            while (ProfileReader.Read())
            {
                string Firstname = (string)ProfileReader["Firstname"];
                string Surname = (string)ProfileReader["Surname"];
                string Patronymic = (string)ProfileReader["Patronymic"];

                // фамилия и иницаиалы текущего пользователя

                char name = Firstname.FirstOrDefault();
                char pat = Patronymic.FirstOrDefault();
                string ShortUserName = string.Concat(Surname, ".", name, ".", pat);
                Session["SHORTUSERNAME"] = ShortUserName;
                ////// Генерация меня в правом верхнем углу

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

            string userconfs = "SELECT [CONFNAME] FROM [CONFIGURATION] WHERE [CREATEDBY] ='"+UserMail+"'";
            SqlCommand getconfnames = new SqlCommand(userconfs, con);
            //  SqlDataReader

            string ShrtUserName = (string)Session["SHORTUSERNAME"];

            //List<Table> tables = new List<Table>()
            //{
            //    new Table{ID=1,Name=UserMail,Date="24.04.2022",Createdby=ShrtUserName,ActiveRow=false }
            //};

            string conftable = "SELECT [CONFNAME],[CREATEDBY],[Firstname], [Surname], [Patronymic] FROM [CONFIGURATION] INNER JOIN [USERS] ON CREATEDBY=Mail WHERE Mail='"+UserMail+"'  ";
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



        protected void ButtonChoose_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            Session["NAMEOFCONF"] = row.Cells[0].Text;
            Server.Transfer("~/Users.aspx");
        }

    }
}