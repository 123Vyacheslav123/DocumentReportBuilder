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


namespace DocumentReportBuilder
{
    public partial class Profile : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            Image1.ImageUrl = "Images/Empty.png";
            Image2.ImageUrl = "Images/Empty.png";
            string UserMail = (string)Session["USERMAIL"];
            string sqlName = "SELECT [Firstname], [Surname], [Patronymic], [Typeofaccount] FROM [USERS] WHERE [Mail]='"+UserMail+"' ";
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
            }
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