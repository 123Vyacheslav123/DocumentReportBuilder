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
    public partial class Profile : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            // находим имя текущего пользвателя
            Image1.ImageUrl = "~/Images/Empty.png";
            Image2.ImageUrl = "~/Images/Empty.png";
            string UserMail = (string)Session["USERMAIL"];
            string sqlName = "SELECT [Firstname], [Surname], [Patronymic],[ShortUserName], [Typeofaccount] FROM [USERS] WHERE [Mail]='"+UserMail+"' ";
            SqlCommand profile = new SqlCommand(sqlName, con);
            SqlDataReader ProfileReader = profile.ExecuteReader();
            while (ProfileReader.Read())
            {
                string Firstname = (string)ProfileReader["Firstname"];
                string Surname = (string)ProfileReader["Surname"];
                string Patronymic = (string)ProfileReader["Patronymic"];
                string Typeofaccount = (string)ProfileReader["Typeofaccount"];
                string UserName = string.Concat(Firstname," ",Surname," ",Patronymic);
                LabelName.Text = UserName;
                LabelUserType.Text = Typeofaccount;
                TextBoxUserName.Text = UserName;
                TextBoxUserMail.Text = UserMail;

                // фамилия и иницаиалы текущего пользователя

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
            con.Close();

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



            if (Image1.ImageUrl == null)
            {
                Image1.ImageUrl = "Images/12.jpg";
            }
        }
    }
}