using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI.HtmlControls;

namespace DocumentReportBuilder
{
    public partial class TeacherBuilder : System.Web.UI.Page
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

                ////// Генерация меню в правом верхнем углу

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
            

            string Styletext = (string)Session["STYLETEXT"]; // количество созданных стилей для текста
            int styletext = Int32.Parse(Styletext);

            string Styletable = (string)Session["STYLETABLE"]; // количество созданных стилей для таблицы
            int styletable = Int32.Parse(Styletable);

            string Stylelist = (string)Session["STYLELIST"]; // количество созданных стилей для списка
            int stylelist = Int32.Parse(Stylelist);

            string Stylepic = (string)Session["STYLEPIC"]; // количество созданных стилей для картинки
            int stylepic = Int32.Parse(Stylepic);
   
            
                string LastTextStyles = "SELECT TOP " + styletext + " * FROM [TEXT] WHERE [CREATEDBY]='" + UserMail + "' ORDER BY [ID] DESC";
                SqlCommand commandText = new SqlCommand(LastTextStyles, con);
                SqlDataReader TextReader = commandText.ExecuteReader();
                while (TextReader.Read())
                {

                    string TextName = (string)TextReader["StyleName"];
                    int id = TextReader.GetInt32(TextReader.GetOrdinal("ID"));
                    AddSavedStyleToList(TextName, id);
                }
                TextReader.Close();

            string LastListStyles = "SELECT TOP " + stylelist + " * FROM [LIST] WHERE [CREATEDBY]='" + UserMail + "' ORDER BY [ID] DESC";
            SqlCommand commandlist = new SqlCommand(LastListStyles, con);
            SqlDataReader ListReader = commandlist.ExecuteReader();
            while (ListReader.Read())
            {

                string ListName = (string)ListReader["StyleName"];
                int id = ListReader.GetInt32(ListReader.GetOrdinal("ID"));
                AddSavedStyleToList(ListName, id);
            }
            ListReader.Close();

            string LastTableStyles = "SELECT TOP " + styletable + " * FROM [TABLE] WHERE [CREATEDBY]='" + UserMail + "' ORDER BY [ID] DESC";
            SqlCommand commandTable = new SqlCommand(LastTableStyles, con);
            SqlDataReader TableReader = commandTable.ExecuteReader();
            while (TableReader.Read())
            {

                string TableName = (string)TableReader["StyleName"];
                int id = TableReader.GetInt32(TableReader.GetOrdinal("ID"));
                AddSavedStyleToList(TableName, id);
            }
            TableReader.Close();

            string LastPicStyles = "SELECT TOP " + stylepic + " * FROM [IMAGE] WHERE [CREATEDBY]='" + UserMail + "' ORDER BY [ID] DESC";
            SqlCommand commandPic = new SqlCommand(LastPicStyles, con);
            SqlDataReader PicReader = commandPic.ExecuteReader();
            while (PicReader.Read())
            {

                string PicName = (string)PicReader["StyleName"];
                int id = PicReader.GetInt32(PicReader.GetOrdinal("ID"));
                AddSavedStyleToList(PicName, id);
            }
            PicReader.Close();


            con.Close();

        }


        protected void Page_PreInit(object sender, EventArgs e)
        {
            
        }

        protected void AddSavedStyleToList(string Text, int id)
        {
            Button style = new Button();
            style.Click += ButtonRecreateStyle_Click;
            style.Text = Text;
            style.CssClass = "LIST_Buttons";
            style.Width = 152;
            style.ID = String.Concat("style_", id);
            style.Attributes.Add("runat", "server");
            SavedStyles.Controls.Add(style);
        }

        protected void ButtonRecreateStyle_Click(object sender, EventArgs e)
        {

        }



        protected void ButtonCreateMainList_Click(object sender, EventArgs e)
        {
            con.Open();

            string UserMail = (string)Session["USERMAIL"]; // почта пользователя

            string TBT1 = TextBoxTop1.Text;
            string TBT2 = TextBoxTop2.Text;
            string TBT3 = TextBoxTop3.Text;
            string TBT4 = TextBoxTop4.Text;
            string TBL1 = TextBoxLeft1.Text;
            string TBR1 = TextBoxRight1.Text;
            string TBB1 = TextBoxBot1.Text;
            string TBB3 = TextBoxBot3.Text;
            string TBB5 = TextBoxBot5.Text;
            string TBB7 = TextBoxBot7.Text;
            string TBB9 = TextBoxBot9.Text;

            string titleinsert = "INSERT INTO [TitleList]([CREATEDBY],[TBT1],[TBT2],[TBT3],[TBT4],[TBL1],[TBR1],[TBB1],[TBB3],[TBB5],[TBB7],[TBB9]) VALUES('" + UserMail + "', N'" + TBT1 +  "', N'" + TBT2 + "', N'" + TBT3 + "', N'" + TBT4 + "', N'" + TBL1 + "', N'" + TBR1 + "', N'" + TBB1 + "', N'" + TBB3 + "', N'" + TBB5 + "', N'" + TBB7 + "', N'" + TBB9 + "')";
            SqlCommand TitleInsert = new SqlCommand(titleinsert, con);
            TitleInsert.ExecuteNonQuery();
            Session["STYLETITLE"] = "Yes";
            con.Close();
        }

        protected void ButtonCreateTitleList_Click(object sender, EventArgs e)
        {
            TopBoxes.Style.Add("visibility", "visible");
            LeftBoxes.Style.Add("visibility", "visible");
            RightBoxes.Style.Add("visibility", "visible");
            BotBoxes.Style.Add("visibility", "visible");
            SaveTitle.Style.Add("visibility", "visible");
            
        }

        protected void ButtonTextStyle_Click(object sender, EventArgs e)
        {
            TopBoxes.Style.Add("visibility", "hidden");
            LeftBoxes.Style.Add("visibility", "hidden");
            RightBoxes.Style.Add("visibility", "hidden");
            BotBoxes.Style.Add("visibility", "hidden");
            SaveTitle.Style.Add("visibility", "hidden");
            TextStyle.Style.Add("visibility", "hidden");
            Liststyle.Style.Add("visibility", "hidden");
            Picstyle.Style.Add("visibility", "hidden");
            TableStyle.Style.Add("visibility", "hidden");

            TextStyle.Style.Add("visibility", "visible");
            MainButtons.Style.Add("visibility", "visible");


            Session["STATUS"] = "Text";

        }

        protected void ButtonListStyle_Click(object sender, EventArgs e)
        {
            TopBoxes.Style.Add("visibility", "hidden");
            LeftBoxes.Style.Add("visibility", "hidden");
            RightBoxes.Style.Add("visibility", "hidden");
            BotBoxes.Style.Add("visibility", "hidden");
            SaveTitle.Style.Add("visibility", "hidden");
            TextStyle.Style.Add("visibility", "hidden");
            Liststyle.Style.Add("visibility", "hidden");
            Picstyle.Style.Add("visibility", "hidden");
            TableStyle.Style.Add("visibility", "hidden");

            Liststyle.Style.Add("visibility", "visible");


            Session["STATUS"] = "List";
        }

        protected void ButtonTableStyle_Click(object sender, EventArgs e)
        {
            TopBoxes.Style.Add("visibility", "hidden");
            LeftBoxes.Style.Add("visibility", "hidden");
            RightBoxes.Style.Add("visibility", "hidden");
            BotBoxes.Style.Add("visibility", "hidden");
            SaveTitle.Style.Add("visibility", "hidden");
            TextStyle.Style.Add("visibility", "hidden");
            Liststyle.Style.Add("visibility", "hidden");
            Picstyle.Style.Add("visibility", "hidden");
            TableStyle.Style.Add("visibility", "hidden");

            TableStyle.Style.Add("visibility", "visible");


            Session["STATUS"] = "Table";
        }

        protected void ButtonPicStyle_Click(object sender, EventArgs e)
        {
            TopBoxes.Style.Add("visibility", "hidden");
            LeftBoxes.Style.Add("visibility", "hidden");
            RightBoxes.Style.Add("visibility", "hidden");
            BotBoxes.Style.Add("visibility", "hidden");
            SaveTitle.Style.Add("visibility", "hidden");
            TextStyle.Style.Add("visibility", "hidden");
            Liststyle.Style.Add("visibility", "hidden");
            Picstyle.Style.Add("visibility", "hidden");
            TableStyle.Style.Add("visibility", "hidden");

            Picstyle.Style.Add("visibility", "visible");


            Session["STATUS"] = "Pic";
        }


        protected void ButtonSaveStyle_Click(object sender, EventArgs e)
        {
            con.Open();
            string status = (string)Session["STATUS"]; // стиль для чего создает пользователь

            string Styletext = (string)Session["STYLETEXT"]; // количество созданных стилей для текста
            int styletext = Int32.Parse(Styletext);

            string Styletable = (string)Session["STYLETABLE"]; // количество созданных стилей для таблицы
            int styletable = Int32.Parse(Styletable);

            string Stylelist = (string)Session["STYLELIST"]; // количество созданных стилей для списка
            int stylelist = Int32.Parse(Stylelist);

            string Stylepic = (string)Session["STYLEPIC"]; // количество созданных стилей для картинки
            int stylepic = Int32.Parse(Stylepic);

            string UserMail = (string)Session["USERMAIL"]; // почта пользователя

            if (status == "Text") // если найдено Value для текста
            {
                string DropDownValue = TextFontList.SelectedValue.ToString();
                string DropDownAlign = DropDownTextAlign.SelectedValue.ToString();
                int textSize = Int32.Parse(TextBoxSize.Text);
                int intervalAfter = Int32.Parse(TextBoxAfter.Text);
                int intervalBefore = Int32.Parse(TextBoxBefore.Text);
                // заносим стиль текста в базу
                string TextStyle = "INSERT INTO[TEXT]([CREATEDBY],[StyleName],[Font],[Alignment],[FontSize],[IntervalAfter],[IntervalBefore])VALUES('" + UserMail + "', N'" + TextBoxName.Text + "', '" + DropDownValue + "','" + DropDownAlign + "',"+textSize+"," + intervalAfter + "," + intervalBefore + ")";
                SqlCommand TextStyleInsert = new SqlCommand(TextStyle, con);
                TextStyleInsert.ExecuteNonQuery();

                AddSavedStyleToList(TextBoxName.Text, styletext);

                styletext++;
                Session["STYLETEXT"] = styletext.ToString();
            }
            else if (status == "Table") // если найдено Value для таблицы
            {
                string DropDownName = TableFontList.SelectedValue.ToString();
                int textSize = Int32.Parse(TextBoxTableFontSize.Text);
                string DropDownTableAlignment = TableAlignList.SelectedValue.ToString();
                string DropDownCellAlignment = CellAlignList.SelectedValue.ToString();

                // заносим стиль таблицы в базу
                string TableStyle = "INSERT INTO [TABLE] ([CREATEDBY],[StyleName],[Font],[FontSize],[TableAlignment],[CellAlignment])VALUES('" + UserMail + "', N'" + TableStyleNameBox.Text + "', '" + DropDownName + "'," + textSize + ", '" + DropDownTableAlignment + "', '" + DropDownCellAlignment + "')";
                SqlCommand TableStyleInsert = new SqlCommand(TableStyle, con);
                TableStyleInsert.ExecuteNonQuery();
                AddSavedStyleToList(TableStyleNameBox.Text, styletable);
                styletable++;
                Session["STYLETABLE"] = styletable.ToString();
            }
            else if (status == "List") // если найдено Value для списка
            {
                string DropDownListValue = TStyle_List.SelectedValue.ToString();
                int ListSize = Int32.Parse(TextBoxTSize.Text);

                // заносим стиль списка в базу
                string ListStyle = "INSERT INTO [LIST] ([CREATEDBY],[StyleName],[Font],[FontSize])VALUES('" + UserMail + "', N'" + TextBoxSName.Text + "','" + DropDownListValue + "','" + ListSize + "')";
                SqlCommand ListStyleInsert = new SqlCommand(ListStyle, con);
                ListStyleInsert.ExecuteNonQuery();
                AddSavedStyleToList(TextBoxSName.Text, stylelist);
                stylelist++;
                Session["STYLELIST"] = stylelist.ToString();
            }

            else if (status == "Pic") // если найдено Value для картинки
            {
                string DropDownIMGValue = PAlign_List.SelectedValue.ToString();

                // заносим стиль картинки в базу
                string ImageStyle = "INSERT INTO [IMAGE] ([CREATEDBY],[StyleName],[Name],[Alignment])VALUES('"+ UserMail + "', N'" + TextBoxPName.Text + "', N'" + TextBoxPTitle.Text + "', '" + DropDownIMGValue + "')";
                SqlCommand IMGStyleInsert = new SqlCommand(ImageStyle, con);
                IMGStyleInsert.ExecuteNonQuery();
                AddSavedStyleToList(TextBoxPName.Text,stylepic);
                stylepic++;
                Session["STYLEPIC"] = stylepic.ToString();
            }
            else
            {

            }
            con.Close();
        }

        protected void ButtonGoBack_Click(object sender, EventArgs e)
        {
            TopBoxes.Style.Add("visibility", "hidden");
            LeftBoxes.Style.Add("visibility", "hidden");
            RightBoxes.Style.Add("visibility", "hidden");
            SaveTitle.Style.Add("visibility", "hidden");
            BotBoxes.Style.Add("visibility", "hidden");
            TextStyle.Style.Add("visibility", "hidden");
            Liststyle.Style.Add("visibility", "hidden");
            Picstyle.Style.Add("visibility", "hidden");
            TableStyle.Style.Add("visibility", "hidden");
            TextStyle.Style.Add("visibility", "hidden");
        }


        protected void ButtonSaveConf_Click(object sender, EventArgs e)
        {
            con.Open();

            string Styletext = (string)Session["STYLETEXT"]; // количество созданных стилей для текста
            int styletext = Int32.Parse(Styletext);

            
            string Styletable = (string)Session["STYLETABLE"]; // количество созданных стилей для таблицы
            int styletable = Int32.Parse(Styletable);

            
            string Stylelist = (string)Session["STYLELIST"]; // количество созданных стилей для списка
            int stylelist = Int32.Parse(Stylelist);

            
            string Stylepic = (string)Session["STYLEPIC"]; // количество созданных стилей для картинки
            int stylepic = Int32.Parse(Stylepic);

            string StyleTitle = (string)Session["STYLETITLE"]; // создан ли стиль для титульника

            string UserMail = (string)Session["USERMAIL"]; // почта пользователя

            int[] text = new int[5]; // массив для айди созданных стилей текста
            int[] table = new int[5]; // массив для айди созданных стилей таблицы
            int[] list = new int[5]; // массив для айди созданных стилей списка
            int[] pic = new int[5]; // массив для айди созданных стилей картинки


            // Находим айди стилей текста которые надо внести в конфигурацию

            string textselect = "SELECT TOP " + styletext + " * FROM [TEXT] WHERE [CREATEDBY]='" + UserMail + "' ORDER BY [ID] DESC ";
            SqlCommand selecttext = new SqlCommand(textselect, con);
            SqlDataReader textreader = selecttext.ExecuteReader();
            int i = 0;
            while (textreader.Read())
            {
                
                text[i]= textreader.GetInt32(textreader.GetOrdinal("ID"));
                i++;

            }
            textreader.Close();

            i = 0;

            // Находим айди стилей таблицы которые надо внести в конфигурацию

            string tableselect = "SELECT TOP " + styletable + " * FROM [TABLE] WHERE [CREATEDBY]='" + UserMail + "' ORDER BY [ID] DESC ";
            SqlCommand selecttable = new SqlCommand(tableselect, con);
            SqlDataReader tablereader = selecttable.ExecuteReader();

            while (tablereader.Read())
            {

                table[i] = tablereader.GetInt32(tablereader.GetOrdinal("ID"));
                i++;
            }
            tablereader.Close();

            i = 0;

            // Находим айди стилей списка которые надо внести в конфигурацию

            string listselect = "SELECT TOP " + stylelist + " * FROM [LIST] WHERE [CREATEDBY]='" + UserMail + "' ORDER BY [ID] DESC ";
            SqlCommand selectlist = new SqlCommand(listselect, con);
            SqlDataReader listreader = selectlist.ExecuteReader();

            while (listreader.Read())
            {

                list[i] = listreader.GetInt32(listreader.GetOrdinal("ID"));
                i++;
            }
            listreader.Close();

            i = 0;

            // Находим айди стилей картинки которые надо внести в конфигурацию

            string picselect = "SELECT TOP " + stylepic + " * FROM [IMAGE] WHERE [CREATEDBY]='" + UserMail + "' ORDER BY [ID] DESC ";
            SqlCommand selectpic = new SqlCommand(picselect, con);
            SqlDataReader picreader = selectpic.ExecuteReader();

            while (picreader.Read())
            {

                pic[i] = picreader.GetInt32(picreader.GetOrdinal("ID"));
                i++;
            }
            picreader.Close();
            i = 0;

            int title = 0;
            if (StyleTitle == "Yes")
            {
                
                string titleselect = "SELECT TOP 1 * FROM [TitleList] WHERE [CREATEDBY]='" + UserMail + "' ORDER BY [ID] DESC ";
                SqlCommand selecttitle = new SqlCommand(titleselect, con);
                SqlDataReader titlereader = selecttitle.ExecuteReader();

                while (titlereader.Read())
                {
                    title = titlereader.GetInt32(titlereader.GetOrdinal("ID"));

                }
                titlereader.Close();
            }
            else { }


            // Заносим айди стилей в общую конфигурацию

            string confinsert = "INSERT INTO [CONFIGURATION] ([CONFNAME],[CREATEDBY],[TEXT1],[TEXT2],[TEXT3],[TEXT4],[TEXT5],[TABLE1],[TABLE2],[TABLE3],[TABLE4],[TABLE5],[LIST1],[LIST2],[LIST3],[LIST4],[LIST5],[IMG1],[IMG2],[IMG3],[IMG4],[IMG5],[TITLELIST]) VALUES(N'"+TextBoxConfName.Text+"','"+UserMail+"','" + text[0] + "','" + text[1] + "','" + text[2] + "','" + text[3] + "','" + text[4] + "','" + table[0] + "','" + table[1] + "','" + table[2] + "','" + table[3] + "','" + table[4] + "','" + list[0] + "','" + list[1] + "','" + list[2] + "','" + list[3] + "','" + list[4] + "','" + pic[0] + "','" + pic[1] + "','" + pic[2] + "','" + pic[3] + "','" + pic[4] + "','" + title + "')";
            SqlCommand insertconf = new SqlCommand(confinsert, con);
            insertconf.ExecuteNonQuery();

            con.Close();
        }


        ////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////
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