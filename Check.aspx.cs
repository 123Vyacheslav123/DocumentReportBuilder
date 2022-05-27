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
    public partial class Check : System.Web.UI.Page
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

            string creator = (string)Session["CREATOR"];
            string confname = (string)Session["NAMEOFCONF"];

            string findcreator = "SELECT [Mail] FROM [USERS] WHERE [ShortUserName] = N'"+creator+"' ";
            SqlCommand creatorcom = new SqlCommand(findcreator, con);
            SqlDataReader creatorReader = creatorcom.ExecuteReader();

            string creatormail = "";
            while (creatorReader.Read()) 
            {
                creatormail = (string)creatorReader["Mail"];

            }
            creatorReader.Close();

            //находим айди стилей в присланной конфигурации
            string styles = "SELECT [CONFNAME],[CREATEDBY],[TEXT1],[TEXT2],[TEXT3],[TEXT4],[TEXT5],[TABLE1],[TABLE2],[TABLE3],[TABLE4],[TABLE5],[LIST1],[LIST2],[LIST3],[LIST4],[LIST5],[IMG1],[IMG2],[IMG3],[IMG4],[IMG5],[TITLELIST] FROM [CONFIGURATION] WHERE [CONFNAME] = N'" + confname + "' AND [CREATEDBY] = '" + creatormail + "' ";
            SqlCommand taskstyles = new SqlCommand(styles, con);
            SqlDataReader stylesreader = taskstyles.ExecuteReader();

            int text1 = 0;
            int text2 = 0;
            int text3 = 0;
            int text4 = 0;
            int text5 = 0;
            int table1 = 0;
            int table2 = 0;
            int table3 = 0;
            int table4 = 0;
            int table5 = 0;
            int list1 = 0;
            int list2 = 0;
            int list3 = 0;
            int list4 = 0;
            int list5 = 0;
            int img1 = 0;
            int img2 = 0;
            int img3 = 0;
            int img4 = 0;
            int img5 = 0;
            int titlelist = 0;
            while (stylesreader.Read())
            {
                text1 = stylesreader.GetInt32(stylesreader.GetOrdinal("TEXT1"));
                text2 = stylesreader.GetInt32(stylesreader.GetOrdinal("TEXT2"));
                text3 = stylesreader.GetInt32(stylesreader.GetOrdinal("TEXT3"));
                text4 = stylesreader.GetInt32(stylesreader.GetOrdinal("TEXT4"));
                text5 = stylesreader.GetInt32(stylesreader.GetOrdinal("TEXT5"));
                table1 = stylesreader.GetInt32(stylesreader.GetOrdinal("TABLE1"));
                table2 = stylesreader.GetInt32(stylesreader.GetOrdinal("TABLE2"));
                table3 = stylesreader.GetInt32(stylesreader.GetOrdinal("TABLE3"));
                table4 = stylesreader.GetInt32(stylesreader.GetOrdinal("TABLE4"));
                table5 = stylesreader.GetInt32(stylesreader.GetOrdinal("TABLE5"));
                list1 = stylesreader.GetInt32(stylesreader.GetOrdinal("LIST1"));
                list2 = stylesreader.GetInt32(stylesreader.GetOrdinal("LIST2"));
                list3 = stylesreader.GetInt32(stylesreader.GetOrdinal("LIST3"));
                list4 = stylesreader.GetInt32(stylesreader.GetOrdinal("LIST4"));
                list5 = stylesreader.GetInt32(stylesreader.GetOrdinal("LIST5"));
                img1 = stylesreader.GetInt32(stylesreader.GetOrdinal("IMG1"));
                img2 = stylesreader.GetInt32(stylesreader.GetOrdinal("IMG2"));
                img3 = stylesreader.GetInt32(stylesreader.GetOrdinal("IMG3"));
                img4 = stylesreader.GetInt32(stylesreader.GetOrdinal("IMG4"));
                img5 = stylesreader.GetInt32(stylesreader.GetOrdinal("IMG5"));
                titlelist = stylesreader.GetInt32(stylesreader.GetOrdinal("TITLELIST"));
            }
            stylesreader.Close();


            string[] text = new string[5]; // массив для названий стилей текста
            string[] table = new string[5]; // массив для названий стилей таблицы
            string[] list = new string[5]; // массив для названий стилей списка
            string[] img = new string[5]; // массив для названий стилей картинки

            int[] textid = new int[5]; // массив для id стилей текста
            int[] tableid = new int[5]; // массив для id стилей таблицы
            int[] listid = new int[5]; // массив для id стилей списка
            int[] imgid = new int[5]; // массив для id стилей картинки

            //находим названия стилей текста
            string textstylenames = "SELECT [ID],[StyleName] FROM [TEXT] WHERE [ID] = '" + text1 + "' OR [ID] = '" + text2 + "' OR [ID] = '" + text3 + "' OR [ID] = '" + text4 + "' OR [ID] = '" + text5 + "'ORDER BY [ID] ASC";
            SqlCommand textstyles = new SqlCommand(textstylenames, con);
            SqlDataReader textstylesreader = textstyles.ExecuteReader();
            int i = 0;

            while (textstylesreader.Read())
            {
                text[i] = (string)textstylesreader["StyleName"];
                textid[i] = textstylesreader.GetInt32(textstylesreader.GetOrdinal("ID"));
                i++;
            }
            textstylesreader.Close();
            i = 0;

            //находим названия стилей таблиц
            string tablestylenames = "SELECT [ID],[StyleName] FROM [TABLE] WHERE [ID] = '" + table1 + "' OR [ID] = '" + table2 + "' OR [ID] = '" + table3 + "' OR [ID] = '" + table4 + "' OR [ID] = '" + table5 + "'ORDER BY [ID] ASC";
            SqlCommand tablestyles = new SqlCommand(tablestylenames, con);
            SqlDataReader tablestylesreader = tablestyles.ExecuteReader();

            while (tablestylesreader.Read())
            {
                table[i] = (string)tablestylesreader["StyleName"];
                tableid[i] = tablestylesreader.GetInt32(tablestylesreader.GetOrdinal("ID"));
                i++;
            }
            tablestylesreader.Close();
            i = 0;

            //находим названия стилей списка
            string liststylenames = "SELECT [ID],[StyleName] FROM [LIST] WHERE [ID] = '" + list1 + "' OR [ID] = '" + list2 + "' OR [ID] = '" + list3 + "' OR [ID] = '" + list4 + "' OR [ID] = '" + list5 + "'ORDER BY [ID] ASC";
            SqlCommand liststyles = new SqlCommand(liststylenames, con);
            SqlDataReader liststylesreader = liststyles.ExecuteReader();

            while (liststylesreader.Read())
            {
                list[i] = (string)liststylesreader["StyleName"];
                listid[i] = liststylesreader.GetInt32(liststylesreader.GetOrdinal("ID"));
                i++;
            }
            liststylesreader.Close();
            i = 0;

            //находим названия стилей картинки
            string imgstylenames = "SELECT [ID],[StyleName] FROM [IMAGE] WHERE [ID] = '" + img1 + "' OR [ID] = '" + img2 + "' OR [ID] = '" + img3 + "' OR [ID] = '" + img4 + "' OR [ID] = '" + img5 + "'ORDER BY [ID] ASC";
            SqlCommand imgstyles = new SqlCommand(imgstylenames, con);
            SqlDataReader imgstylesreader = imgstyles.ExecuteReader();

            while (imgstylesreader.Read())
            {
                img[i] = (string)imgstylesreader["StyleName"];
                imgid[i] = imgstylesreader.GetInt32(imgstylesreader.GetOrdinal("ID"));
                i++;
            }
            imgstylesreader.Close();
            i = 0;

            if (titlelist != 0)
            {
                AddSavedStyleToList("Титульник", titlelist, "title");
            }
            if (text1 != 0)
            {
                AddSavedStyleToList(text[i], textid[i], "text");
                i++;
            }
            if (text2 != 0)
            {
                AddSavedStyleToList(text[i], textid[i], "text");
                i++;
            }
            if (text3 != 0)
            {
                AddSavedStyleToList(text[i], textid[i], "text");
                i++;
            }
            if (text4 != 0)
            {
                AddSavedStyleToList(text[i], textid[i], "text");
                i++;
            }
            if (text5 != 0)
            {
                AddSavedStyleToList(text[i], textid[i], "text");

            }
            i = 0;
            if (table1 != 0)
            {
                AddSavedStyleToList(table[i], tableid[i], "table");
                i++;
            }
            if (table2 != 0)
            {
                AddSavedStyleToList(table[i], tableid[i], "table");
                i++;
            }
            if (table3 != 0)
            {
                AddSavedStyleToList(table[i], tableid[i], "table");
                i++;
            }
            if (table4 != 0)
            {
                AddSavedStyleToList(table[i], tableid[i], "table");
                i++;
            }
            if (table5 != 0)
            {
                AddSavedStyleToList(table[i], tableid[i], "table");

            }
            i = 0;
            if (list1 != 0)
            {
                AddSavedStyleToList(list[i], listid[i], "list");
                i++;
            }
            if (list2 != 0)
            {
                AddSavedStyleToList(list[i], listid[i], "list");
                i++;
            }
            if (list3 != 0)
            {
                AddSavedStyleToList(list[i], listid[i], "list");
                i++;
            }
            if (list4 != 0)
            {
                AddSavedStyleToList(list[i], listid[i], "list");
                i++;
            }
            if (list5 != 0)
            {
                AddSavedStyleToList(list[i], listid[i], "list");

            }
            i = 0;
            if (img1 != 0)
            {
                AddSavedStyleToList(img[i], imgid[i], "img");
                i++;
            }
            if (img2 != 0)
            {
                AddSavedStyleToList(img[i], imgid[i], "img");
                i++;
            }
            if (img3 != 0)
            {
                AddSavedStyleToList(img[i], imgid[i], "img");
                i++;
            }
            if (img4 != 0)
            {
                AddSavedStyleToList(img[i], imgid[i], "img");
                i++;
            }
            if (img5 != 0)
            {
                AddSavedStyleToList(img[i], imgid[i], "img");
            }
            i = 0;


            con.Close();

        }


        protected void Page_PreInit(object sender, EventArgs e)
        {
            //кнопки преинит
            for (int i = 0; i < 5; i++)
            {
                Button btn = new Button();
                //  btn.ID = String.Concat("style_","text", i);
                btn.Style.Add("position", "absolute");
                btn.Attributes.Add("runat", "server");
                btn.Click += new EventHandler(this.ButtonTextStyle_Click);
                btn.Style["visibility"] = "hidden";
                SavedStyles.Controls.Add(btn);
            }

            for (int i = 0; i < 5; i++)
            {
                Button btn = new Button();
                //  btn.ID = String.Concat("style_", "table", i);
                btn.Style.Add("position", "absolute");
                btn.Attributes.Add("runat", "server");
                btn.Click += new EventHandler(this.ButtonTableStyle_Click);
                btn.Style["visibility"] = "hidden";
                SavedStyles.Controls.Add(btn);
            }

            for (int i = 0; i < 5; i++)
            {
                Button btn = new Button();
                //   btn.ID = String.Concat("style_", "list", i);
                btn.Style.Add("position", "absolute");
                btn.Attributes.Add("runat", "server");
                btn.Click += new EventHandler(this.ButtonListStyle_Click);
                btn.Style["visibility"] = "hidden";
                SavedStyles.Controls.Add(btn);
            }

            for (int i = 0; i < 5; i++)
            {
                Button btn = new Button();
                //  btn.ID = String.Concat("style_", "img", i);
                btn.Style.Add("position", "absolute");
                btn.Attributes.Add("runat", "server");
                btn.Click += new EventHandler(this.ButtonPicStyle_Click);
                btn.Style["visibility"] = "hidden";
                SavedStyles.Controls.Add(btn);
            }
        }

        protected void AddSavedStyleToList(string Text, int id, string type)
        {
            Button style = new Button();
            style.Text = Text;
            style.ID = String.Concat("style_", type, id);
            style.Width = 152;
            style.CssClass = "LIST_Buttons";
            style.Attributes.Add("runat", "server");

            if (type == "text")
            {
                style.Click += new EventHandler(this.ButtonTextStyle_Click);
            }
            else if (type == "table")
            {
                style.Click += new EventHandler(this.ButtonTableStyle_Click);
            }
            else if (type == "list")
            {
                style.Click += new EventHandler(this.ButtonListStyle_Click);
            }
            else if (type == "img")
            {
                style.Click += new EventHandler(this.ButtonPicStyle_Click);
            }
            else if (type == "title")
            {
                style.Click += new EventHandler(this.ButtonCreateTitleList_Click);
            }

            SavedStyles.Controls.Add(style);
        }

        protected void ButtonRecreateStyle_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonCreateTitleList_Click(object sender, EventArgs e)
        {
            con.Open();
            TopBoxes.Style.Add("visibility", "visible");
            LeftBoxes.Style.Add("visibility", "visible");
            RightBoxes.Style.Add("visibility", "visible");
            BotBoxes.Style.Add("visibility", "visible");

            Button button = sender as Button;
            int value;
            string buttonid = button.ID;
            int.TryParse(string.Join("", buttonid.Where(c => char.IsDigit(c))), out value);
            int buttonnumb = value;

            string titletext = "SELECT [TBT1],[TBT2],[TBT3],[TBT4],[TBL1],[TBR1],[TBB1],[TBB3],[TBB5],[TBB7],[TBB9] FROM [TitleList] WHERE [ID] ='" + value + "' ";
            SqlCommand titleText = new SqlCommand(titletext, con);
            SqlDataReader titletextreader = titleText.ExecuteReader();
            while (titletextreader.Read())
            {
                TextBoxTop1.Text = (string)titletextreader["TBT1"];
                TextBoxTop2.Text = (string)titletextreader["TBT2"];
                TextBoxTop3.Text = (string)titletextreader["TBT3"];
                TextBoxTop4.Text = (string)titletextreader["TBT4"];
                TextBoxLeft1.Text = (string)titletextreader["TBL1"];
                TextBoxRight1.Text = (string)titletextreader["TBR1"];
                TextBoxBot1.Text = (string)titletextreader["TBB1"];
                TextBoxBot3.Text = (string)titletextreader["TBB3"];
                TextBoxBot5.Text = (string)titletextreader["TBB5"];
                TextBoxBot7.Text = (string)titletextreader["TBB7"];
                TextBoxBot9.Text = (string)titletextreader["TBB9"];
            }
            titletextreader.Close();

            con.Close();

        }

        protected void ButtonTextStyle_Click(object sender, EventArgs e)
        {
            con.Open();

            TopBoxes.Style.Add("visibility", "hidden");
            LeftBoxes.Style.Add("visibility", "hidden");
            RightBoxes.Style.Add("visibility", "hidden");
            BotBoxes.Style.Add("visibility", "hidden");

            TextStyle.Style.Add("visibility", "hidden");
            Liststyle.Style.Add("visibility", "hidden");
            Picstyle.Style.Add("visibility", "hidden");
            TableStyle.Style.Add("visibility", "hidden");

            TextStyle.Style.Add("visibility", "visible");
            MainButtons.Style.Add("visibility", "visible");

            Button button = sender as Button;
            if (button != null)
            {
                int value;
                string buttonid = button.ID;
                int.TryParse(string.Join("", buttonid.Where(c => char.IsDigit(c))), out value);
                int buttonnumb = value;
                string style = value.ToString();
                Session["TEXTADD"] = style;
            }

            string styleid = (string)Session["TEXTADD"];
            int idforstring = Int32.Parse(styleid);
            string textstylenames = "SELECT [ID],[StyleName],[Font],[Alignment],[FontSize],[IntervalAfter],[IntervalBefore] FROM [TEXT] WHERE [ID] ='" + idforstring + "' ";
            SqlCommand textstyles = new SqlCommand(textstylenames, con);
            SqlDataReader textstylesreader = textstyles.ExecuteReader();
            while (textstylesreader.Read())
            {
                TextBoxName.Text = (string)textstylesreader["StyleName"];


                string TextFontFont = (string)textstylesreader["Font"];
                if (TextFontFont == "Times New Roman")
                {
                    TextFontList.SelectedValue = "Times New Roman";
                }

                else if (TextFontFont == "Courier New")
                {
                    TextFontList.SelectedValue = "Courier New";
                }

                else if (TextFontFont == "Calibri")
                {
                    TextFontList.SelectedValue = "Calibri";
                }
                else
                {
                    TextFontList.SelectedValue = "Comic Sans MS";
                }

                TextBoxSize.Text = (textstylesreader.GetInt32(textstylesreader.GetOrdinal("FontSize")).ToString());

                TextBoxAfter.Text = (textstylesreader.GetInt32(textstylesreader.GetOrdinal("IntervalAfter")).ToString());

                TextBoxBefore.Text = (textstylesreader.GetInt32(textstylesreader.GetOrdinal("IntervalBefore")).ToString());

                string TextAlign = (string)textstylesreader["Alignment"];

                if (TextAlign == "left")
                {
                    DropDownTextAlign.SelectedValue = "left";
                }

                else if (TextAlign == "center")
                {
                    DropDownTextAlign.SelectedValue = "center";
                }

                else if (TextAlign == "right")
                {
                    DropDownTextAlign.SelectedValue = "right";
                }
                else
                {
                    DropDownTextAlign.SelectedValue = "both";
                }

            }
            textstylesreader.Close();

            con.Close();
        }

        protected void ButtonListStyle_Click(object sender, EventArgs e)
        {
            con.Open();

            TopBoxes.Style.Add("visibility", "hidden");
            LeftBoxes.Style.Add("visibility", "hidden");
            RightBoxes.Style.Add("visibility", "hidden");
            BotBoxes.Style.Add("visibility", "hidden");
            
            TextStyle.Style.Add("visibility", "hidden");
            Liststyle.Style.Add("visibility", "hidden");
            Picstyle.Style.Add("visibility", "hidden");
            TableStyle.Style.Add("visibility", "hidden");

            Liststyle.Style.Add("visibility", "visible");

            Button button = sender as Button;
            if (button != null)
            {
                int value;
                string buttonid = button.ID;
                int.TryParse(string.Join("", buttonid.Where(c => char.IsDigit(c))), out value);
                int buttonnumb = value;
                string style = value.ToString();
                Session["LISTADD"] = style;
            }


            // id  стиля
            string styleid = (string)Session["LISTADD"];
            int idforstring = Int32.Parse(styleid);
            string liststylenames = "SELECT [ID],[StyleName],[Font],[FontSize] FROM [LIST] WHERE [ID] ='" + idforstring + "' ";
            SqlCommand liststyles = new SqlCommand(liststylenames, con);
            SqlDataReader liststylesreader = liststyles.ExecuteReader();
            while (liststylesreader.Read())
            {
                TextBoxSName.Text = (string)liststylesreader["StyleName"];

                string ListFontFont = (string)liststylesreader["Font"];

                if (ListFontFont == "Times New Roman")
                {
                    TStyle_List.SelectedValue = "Times New Roman";
                }

                else if (ListFontFont == "Courier New")
                {
                    TStyle_List.SelectedValue = "Courier New";
                }

                else if (ListFontFont == "Calibri")
                {
                    TStyle_List.SelectedValue = "Calibri";
                }
                else
                {
                    TStyle_List.SelectedValue = "Comic Sans MS";
                }

                TextBoxTSize.Text = (liststylesreader.GetInt32(liststylesreader.GetOrdinal("FontSize")).ToString());
            }

            liststylesreader.Close();


            con.Close();
        }

        protected void ButtonTableStyle_Click(object sender, EventArgs e)
        {
            con.Open();

            TopBoxes.Style.Add("visibility", "hidden");
            LeftBoxes.Style.Add("visibility", "hidden");
            RightBoxes.Style.Add("visibility", "hidden");
            BotBoxes.Style.Add("visibility", "hidden");
           
            TextStyle.Style.Add("visibility", "hidden");
            Liststyle.Style.Add("visibility", "hidden");
            Picstyle.Style.Add("visibility", "hidden");
            TableStyle.Style.Add("visibility", "hidden");

            TableStyle.Style.Add("visibility", "visible");

            Button button = sender as Button;
            if (button != null)
            {
                int value;
                string buttonid = button.ID;
                int.TryParse(string.Join("", buttonid.Where(c => char.IsDigit(c))), out value);
                int buttonnumb = value;
                string style = value.ToString();
                Session["TABLEADD"] = style;
            }

            string styleid = (string)Session["TABLEADD"];

            int idforstring = Int32.Parse(styleid);
            string tablestylenames = "SELECT [ID],[StyleName],[Font],[FontSize],[TableAlignment],[CellAlignment] FROM [TABLE] WHERE [ID] ='" + idforstring + "' ";
            SqlCommand tablestyles = new SqlCommand(tablestylenames, con);
            SqlDataReader tablestylesreader = tablestyles.ExecuteReader();
            while (tablestylesreader.Read())
            {
                TableStyleNameBox.Text = (string)tablestylesreader["StyleName"];

                string TableFontFont = (string)tablestylesreader["Font"];

                if (TableFontFont == "Times New Roman")
                {
                    TableFontList.SelectedValue = "Times New Roman";
                }

                else if (TableFontFont == "Courier New")
                {
                    TableFontList.SelectedValue = "Courier New";
                }

                else if (TableFontFont == "Calibri")
                {
                    TableFontList.SelectedValue = "Calibri";
                }
                else
                {
                    TableFontList.SelectedValue = "Comic Sans MS";
                }

                TextBoxTableFontSize.Text = (tablestylesreader.GetInt32(tablestylesreader.GetOrdinal("FontSize")).ToString());

                string TableAlign = (string)tablestylesreader["TableAlignment"];

                if (TableAlign == "left")
                {
                    TableAlignList.SelectedValue = "left";
                }

                else if (TableAlign == "center")
                {
                    TableAlignList.SelectedValue = "center";
                }

                else if (TableAlign == "right")
                {
                    TableAlignList.SelectedValue = "right";
                }
                else
                {
                    TableAlignList.SelectedValue = "both";
                }

                string TableCellAlign = (string)tablestylesreader["CellAlignment"];

                if (TableCellAlign == "top")
                {
                    CellAlignList.SelectedValue = "top";
                }

                else if (TableCellAlign == "center")
                {
                    CellAlignList.SelectedValue = "center";
                }

                else
                {
                    CellAlignList.SelectedValue = "bottom";
                }

            }

            tablestylesreader.Close();
            con.Close();
        }

        protected void ButtonPicStyle_Click(object sender, EventArgs e)
        {
            con.Open();

            TopBoxes.Style.Add("visibility", "hidden");
            LeftBoxes.Style.Add("visibility", "hidden");
            RightBoxes.Style.Add("visibility", "hidden");
            BotBoxes.Style.Add("visibility", "hidden");
           
            TextStyle.Style.Add("visibility", "hidden");
            Liststyle.Style.Add("visibility", "hidden");
            Picstyle.Style.Add("visibility", "hidden");
            TableStyle.Style.Add("visibility", "hidden");

            Picstyle.Style.Add("visibility", "visible");

            Button button = sender as Button;
            if (button != null)
            {
                int value;
                string buttonid = button.ID;
                int.TryParse(string.Join("", buttonid.Where(c => char.IsDigit(c))), out value);
                int buttonnumb = value;
                string style = value.ToString();
                Session["PICADD"] = style;
            }

            string styleid = (string)Session["PICADD"];

            int idforstring = Int32.Parse(styleid);
            string picstylenames = "SELECT [ID],[StyleName],[Name],[Alignment] FROM [IMAGE] WHERE [ID] ='" + idforstring + "' ";
            SqlCommand picstyles = new SqlCommand(picstylenames, con);
            SqlDataReader picstylesreader = picstyles.ExecuteReader();

            while (picstylesreader.Read())
            {
                TextBoxPName.Text = (string)picstylesreader["StyleName"];
                TextBoxPTitle.Text = (string)picstylesreader["Name"];

                string picalign = (string)picstylesreader["Alignment"];

                if (picalign == "left")
                {
                    PAlign_List.SelectedValue = "left";
                }

                else if (picalign == "center")
                {
                    PAlign_List.SelectedValue = "center";
                }

                else if (picalign == "right")
                {
                    PAlign_List.SelectedValue = "right";
                }
                else
                {
                    PAlign_List.SelectedValue = "both";
                }

            }
            picstylesreader.Close();
            con.Close();
        }

        protected void ButtonGoBack_Click(object sender, EventArgs e)
        {
            TopBoxes.Style.Add("visibility", "hidden");
            LeftBoxes.Style.Add("visibility", "hidden");
            RightBoxes.Style.Add("visibility", "hidden");
           
            BotBoxes.Style.Add("visibility", "hidden");
            TextStyle.Style.Add("visibility", "hidden");
            Liststyle.Style.Add("visibility", "hidden");
            Picstyle.Style.Add("visibility", "hidden");
            TableStyle.Style.Add("visibility", "hidden");
            TextStyle.Style.Add("visibility", "hidden");
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