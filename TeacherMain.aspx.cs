using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI.HtmlControls;

namespace DocumentReportBuilder
{
    public partial class TeacherMain : System.Web.UI.Page
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

                ////// Генерация меня в правом верхнем углу

                HtmlGenericControl li = new HtmlGenericControl("li");
                MenuList.Controls.Add(li);

                HtmlGenericControl anchor = new HtmlGenericControl("a");
                anchor.Attributes.Add("href", "/TeacherProfile.aspx");
                anchor.Attributes.Add("class", "down");
                anchor.InnerText = ShortUserName;

                li.Controls.Add(anchor);



                HtmlGenericControl ul = new HtmlGenericControl("ul");
                ul.Attributes.Add("class", "submenu");
                li.Controls.Add(ul);

                HtmlGenericControl li1 = new HtmlGenericControl("li");
                ul.Controls.Add(li1);


                HtmlGenericControl anchor1 = new HtmlGenericControl("a");
                anchor1.Attributes.Add("href", "/TeacherProfile.aspx");
                anchor1.InnerText = "Профиль";
                li1.Controls.Add(anchor1);

                HtmlGenericControl anchor2 = new HtmlGenericControl("a");
                anchor2.Attributes.Add("href", "/Reg.aspx");
                anchor2.InnerText = "Выход";
                li1.Controls.Add(anchor2);
            }
            ProfileReader.Close();
            con.Close();

            // это нужно для того чтобы работало создание конфигурации
            Session["STYLETEXT"] = "0";
            Session["STYLETABLE"] = "0";
            Session["STYLEPIC"] = "0";
            Session["STYLELIST"] = "0";
        }


        protected void Button1_Click(object sender, EventArgs e)
        {


            Thread t = new Thread(new ThreadStart(() =>
            {
                var fileDialog = new OpenFileDialog();
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {

                }

            }));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();




        
        }
    }

}