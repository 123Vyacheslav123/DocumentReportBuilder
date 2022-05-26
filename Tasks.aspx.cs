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
using Xceed.Words.NET;
using Xceed.Document.NET;

namespace DocumentReportBuilder
{
    internal sealed class Task
    {
        public int ID { get; set; }
        public string CONFNAME { get; set; }
        public string ShortUserName { get; set; }
        public string Date { get; set; }

    }

    public partial class Tasks : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            // находим имя текущего пользвателя
            string UserMail = (string)Session["USERMAIL"];
            string sqlName = "SELECT [ShortUserName] FROM [USERS] WHERE [Mail]='" + UserMail + "' ";
            SqlCommand profile = new SqlCommand(sqlName, con);
            SqlDataReader ProfileReader = profile.ExecuteReader();
            while (ProfileReader.Read())
            {
                string ShortUserName = (string)ProfileReader["ShortUserName"];
                Session["FORFILENAME"] = ShortUserName;
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
            SqlCommand getid = new SqlCommand(getuserid,con);
            SqlDataReader finduserid = getid.ExecuteReader();
            int id=0;
            while (finduserid.Read())
            {
                id = (int)finduserid["ID"];
            }
            finduserid.Close();

            // находим конфигурации привязанные к пользователю
            string sqlgetconf = "SELECT [Configuration],[Date] FROM [ReportUsers] WHERE [User]='" + id + "' ORDER BY [ID] DESC ";
            SqlCommand allconf = new SqlCommand(sqlgetconf, con);
            SqlDataReader confreader = allconf.ExecuteReader();
            int i = 0;
            int[] confids = new int[100]; // список айди конфиуграций отправленных пользователю
            string[] confdates = new string[100];
            while (confreader.Read())
            {
                confids[i] = (int)confreader["Configuration"];
                confdates[i] = (string)confreader["Date"];
                i++;
            }
            confreader.Close();

            string[] confnames = new string[100]; // список названий конфигураций отправленных пользователю
            string[] confcheck = new string[1000];
            int[] idscheck = new int[1000];

            // находим названия конфигураций привязанных к пользователю
            string sqlgetnames = "SELECT [ID],[CONFNAME] FROM [CONFIGURATION] ORDER BY [ID] DESC ";
            SqlCommand getconfname = new SqlCommand(sqlgetnames, con);
            SqlDataReader confnamereader = getconfname.ExecuteReader();
            int j = 0;
            while (confnamereader.Read())
            {

                confcheck[j] = (string)confnamereader["CONFNAME"];
                idscheck[j] = (int)confnamereader["ID"];
                j++;
            }
            confnamereader.Close();

            // короткие имена тех кто отправил конфигурацию
            string[] shortusernames = new string[1000]; //все короткие имена преподов отправивших конфигурацию
            string[] shortusername = new string[1000]; // те короткие имена которые нужны
            string[] confname = new string[1000];
            string sqlshortnames = "SELECT [ShortUserName],[CONFNAME] FROM [USERS] INNER JOIN [CONFIGURATION] ON [Mail] = [CREATEDBY] ORDER BY [USERS].[ID] DESC";
            SqlCommand getshortusernames = new SqlCommand(sqlshortnames, con);
            SqlDataReader shortusernamesreader = getshortusernames.ExecuteReader();
            int n = 0;
            while (shortusernamesreader.Read())
            {
                confname[n] = (string)shortusernamesreader["CONFNAME"];
                shortusernames[n] = (string)shortusernamesreader["ShortUserName"];
                n++;
            }


            int count = 0;
            for (int k = 0; k < j; k++)
            {
                for (int l = 0; l < j; l++)
                {
                    if (idscheck[k] == confids[l])
                    {
                        confnames[count] = confcheck[k];
                        count++;
                    }
                }

            }



            count = 0;
            for (int k = 0; k < j; k++)
            {
                for (int l = 0; l < j; l++)
                {
                    if (confname[k] == confnames[l])
                    {
                        shortusername[count] = shortusernames[k];
                        count++;
                    }
                }

            }



            List<Task> tasks = new List<Task>();
            for (int k = 0; k < i; k++)
            {
                Task table = new Task();
                table.ID = (k + 1);
                table.CONFNAME = confnames[k];
                table.ShortUserName = shortusername[k];
                table.Date = confdates[k];
                tasks.Add(table);
            }
            GridViewTableTask.DataSource = tasks;
            GridViewTableTask.DataBind();


            con.Close();

        }

        protected void ButtonOpen_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            Session["NAMEOFTASK"] = row.Cells[1].Text;
            Session["TASKFROM"] = row.Cells[2].Text;
            CreateFile();
            Server.Transfer("~/StudentBuilder.aspx");
        }

        protected void CreateFile()
        {
            string savingPath = MapPath("~/Docx/");
            string confname = (string)Session["NAMEOFTASK"];

            string name = (string)Session["FORFILENAME"];

            string filename = String.Concat(confname, " ", name, ".docx");

            string filepath = String.Concat(savingPath, filename);

            var doc = DocX.Create(filepath);
            doc.Sections[0].MarginTop = 56;
            doc.Sections[0].MarginFooter = 56;
            doc.Sections[0].MarginLeft = 84;
            doc.Sections[0].MarginRight = 42;
            doc.Save();
            Session["COUNTERIMG"] = "1";
            Session["COUNTERLIST"] = "2";
        }


    }
}