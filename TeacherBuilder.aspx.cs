using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DocumentReportBuilder
{
    public partial class TeacherBuilder : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void ButtonCreateMainList_Click(object sender, EventArgs e)
        {
            Session["TBT1"] = TextBoxTop1.Text;
            Session["TBT2"] = TextBoxTop2.Text;
            Session["TBT3"] = TextBoxTop3.Text;
            Session["TBT4"] = TextBoxTop4.Text;
            Session["TBL1"] = TextBoxLeft1.Text;
            Session["TBR1"] = TextBoxRight1.Text;
            Session["TBB1"] = TextBoxBot1.Text;
            Session["TBB3"] = TextBoxBot3.Text;
            Session["TBB5"] = TextBoxBot5.Text;
            Session["TBB7"] = TextBoxBot7.Text;
            Session["TBB9"] = TextBoxBot9.Text;

        }

        protected void ButtonTest_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/StudentBuilder.aspx");
        }

        protected void ButtonCreateTitleList_Click(object sender, EventArgs e)
        {
            TopBoxes.Style.Add("visibility", "visible");
            LeftBoxes.Style.Add("visibility", "visible");
            RightBoxes.Style.Add("visibility", "visible");
            BotBoxes.Style.Add("visibility", "visible");
            ButtonCreateMainList.Style.Add("visibility", "visible");
        }

        protected void ButtonCreateStyle_Click(object sender, EventArgs e)
        {
            TopBoxes.Style.Add("visibility", "hidden");
            LeftBoxes.Style.Add("visibility", "hidden");
            RightBoxes.Style.Add("visibility", "hidden");
            BotBoxes.Style.Add("visibility", "hidden");
            TextStyle.Style.Add("visibility", "hidden");
            Liststyle.Style.Add("visibility", "hidden");
            Picstyle.Style.Add("visibility", "hidden");
            TableStyle.Style.Add("visibility","hidden");

            if ((DropDownListForElements.SelectedItem.Value) == "0") // если найдено Value для текста
            {
                TextStyle.Style.Add("visibility", "visible");
                MainButtons.Style.Add("visibility", "visible");

            }
            else if ((DropDownListForElements.SelectedItem.Value) == "1") // если найдено Value для Таблицы
            {
                TableStyle.Style.Add("visibility", "visible");
            }
            else if ((DropDownListForElements.SelectedItem.Value) == "2") // если найдено Value для Списка
            {
                Liststyle.Style.Add("visibility", "visible");
            }

            else if ((DropDownListForElements.SelectedItem.Value) == "3") // если найдено Value для картинки
            {
                Picstyle.Style.Add("visibility", "visible");
            }
            else
            {
                
            }
        }

        protected void ButtonSaveStyle_Click(object sender, EventArgs e)
        {
            con.Open();
            if ((DropDownListForElements.SelectedItem.Value) == "0") // если найдено Value для текста
            {
                string DropDownValue = TextFontList.SelectedValue.ToString();
                int textSize = Int32.Parse(TextBoxSize.Text);
                int indentRight = Int32.Parse(TextBoxRight.Text);
                int indentLeft = Int32.Parse(TextBoxLeft.Text);
                int firstLine = Int32.Parse(TextBox1stString.Text);
                int firstLineTo = Int32.Parse(TextBoxOn.Text);
                int intervalAfter = Int32.Parse(TextBoxAfter.Text);
                int intervalBefore = Int32.Parse(TextBoxBefore.Text);
                int interline = Int32.Parse(TextBoxInterline.Text);
                int value = Int32.Parse(TextBoxAfter.Text);
                string TextStyle = "INSERT INTO[TEXT]([StyleName],[Font],[FontSize],[IndentRight],[IndentLeft],[FirstLine],[FirsLineTo],[IntervalAfter],[IntervalBefore],[Interline],[Value])VALUES('"+TextBoxName.Text+"', '"+DropDownValue+"', "+textSize+","+indentRight+","+indentLeft+", '"+firstLine+"',"+firstLineTo+","+intervalAfter+","+intervalBefore+", '"+interline+"',"+value+")";
                SqlCommand TextStyleInsert = new SqlCommand(TextStyle, con);
                TextStyleInsert.ExecuteNonQuery();
            }
            else if ((DropDownListForElements.SelectedItem.Value) == "1") // если найдено Value для Таблицы
            {
                string DropDownName = TableFontList.SelectedValue.ToString();
                int textSize = Int32.Parse(TextBoxTableFontSize.Text);
                string DropDownTableAlignment = TableAlignList.SelectedValue.ToString(); ;
                string DropDownCellAlignment = CellAlignList.SelectedValue.ToString(); ;
                string TableStyle = "INSERT INTO [TABLE] ([StyleName],[Font],[FontSize],[TableAlignment],[CellAlignment])VALUES('"+TableStyleNameBox.Text+"', '"+DropDownName+"',"+textSize+", '"+DropDownTableAlignment+"', '"+DropDownCellAlignment+"')";
                SqlCommand TableStyleInsert = new SqlCommand(TableStyle, con);
                TableStyleInsert.ExecuteNonQuery();
            }
            else if ((DropDownListForElements.SelectedItem.Value) == "2") // если найдено Value для Списка
            {
                
            }

            else if ((DropDownListForElements.SelectedItem.Value) == "3") // если найдено Value для картинки
            {
                
            }
            else
            {

            }
            con.Close();
        }

        protected void ButtonGoBack_Click(object sender, EventArgs e)
        {
            TextStyle.Style.Add("visibility", "hidden");
            MainButtons.Style.Add("visibility", "hidden");
        }


        ////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////
        protected void TextBoxTop1_TextChanged(object sender, EventArgs e)
        {

        }
        protected void TextBoxTop2_TextChanged(object sender, EventArgs e)
        {

        }
        protected void TextBoxTop3_TextChanged(object sender, EventArgs e)
        {

        }
        protected void TextBoxTop4_TextChanged(object sender, EventArgs e)
        {

        }
        protected void TextBoxLeft1_TextChanged(object sender, EventArgs e)
        {

        }
        protected void TextBoxLeft2_TextChanged(object sender, EventArgs e)
        {

        }
        protected void TextBoxLeft3_TextChanged(object sender, EventArgs e)
        {

        }
        protected void TextBoxLeft4_TextChanged(object sender, EventArgs e)
        {

        }
        protected void TextBoxRight1_TextChanged(object sender, EventArgs e)
        {

        }
        protected void TextBoxRight2_TextChanged(object sender, EventArgs e)
        {

        }
        protected void TextBoxRight3_TextChanged(object sender, EventArgs e)
        {

        }
        protected void TextBoxRight4_TextChanged(object sender, EventArgs e)
        {

        }
        protected void TextBoxBot1_TextChanged(object sender, EventArgs e)
        {

        }
        protected void TextBoxBot2_TextChanged(object sender, EventArgs e)
        {

        }
        protected void TextBoxBot3_TextChanged(object sender, EventArgs e)
        {

        }
        protected void TextBoxBot4_TextChanged(object sender, EventArgs e)
        {

        }
        protected void TextBoxBot5_TextChanged(object sender, EventArgs e)
        {

        }
        protected void TextBoxBot6_TextChanged(object sender, EventArgs e)
        {

        }
        protected void TextBoxBot7_TextChanged(object sender, EventArgs e)
        {

        }
        protected void TextBoxBot8_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBoxBot9_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownListForElements_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextFontList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}