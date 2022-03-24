using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DocumentReportBuilder.Functions;
using MongoDB.Driver;

namespace Registration
{
    public partial class Reg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Page_PreInit(object sender,EventArgs e)
        {
    
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected  void ButtonRegistration_Click(object sender, EventArgs e)
        {
            /////Подключение БД
            MongoClient client = new MongoClient(
            ConfigurationManager.AppSettings["connectionString"]);
            MongoServer server = client.GetServer();

            string databaseName = "ReportBuilderDB"; // Имя БД
            string collectionName = "Users"; // Имя коллекции с пользователями

            MongoDatabase db = server.GetDatabase(databaseName);
            MongoCollection<PersonModel> collection = db.GetCollection<PersonModel>(collectionName);
            
        }
    }
}