using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace DocumentReportBuilder
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


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