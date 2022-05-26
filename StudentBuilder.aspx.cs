using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;
using Xceed.Document.NET;
using System.Web.Mvc;
using System.Drawing;
using System.IO;
using Syroot.Windows.IO;
using Image = Xceed.Document.NET.Image;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using SautinSoft.Document;
using VerticalAlignment = Xceed.Document.NET.VerticalAlignment;

namespace DocumentReportBuilder
{
    public partial class StudentBuilder : System.Web.UI.Page
    {
        ////////// ПЕРЕМЕННЫЕ ДЛЯ СТИЛЯ //////////
        string TextStyleName = "Text1";
        Xceed.Document.NET.Font TextFontFont = new Xceed.Document.NET.Font("Times New Roman");
        int TextFontSize = 14;
        int TextSpacingBefore = 0;
        int TextSpacingAfter = 8;
        string TextAlign = "both";

        string ImageStyleName = "Image1";
        int ImageSpacingBefore = 0;
        int ImageSpacingAfter = 0;
        int ImageSpacingLine = 18;
        string ImageAlign = "center";
        //Xceed.Document.NET.Alignment ImageAlign = Xceed.Document.NET.Alignment.center;

        string ListStyleName = "List1";
        Xceed.Document.NET.Font ListFontFont = new Xceed.Document.NET.Font("Times New Roman");
        int ListFontSize = 14;

        string TableStyleName = "Table1";
        Xceed.Document.NET.Font TableFontFont = new Xceed.Document.NET.Font("Times New Roman");
        string TableCellAlign = "center";
        string TableAlign = "center";
        int TableFontSize = 14;

        ///////////////////////////////////////////

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

            
            string confname = (string)Session["NAMEOFTASK"];
            string shortname = (string)Session["TASKFROM"];

            // находим почту пользователя того, кто отправил конфигурацию
            string taskfrom = "SELECT [Mail] FROM [USERS] WHERE [ShortUserName] = N'"+shortname+"' ";
            SqlCommand fromshortname = new SqlCommand(taskfrom, con);
            SqlDataReader shortnamereader = fromshortname.ExecuteReader();
            string mailfrom="test";
            while (shortnamereader.Read())
            {
                mailfrom = (string)shortnamereader["Mail"];
            }
            shortnamereader.Close();

            //находим айди стилей в присланной конфигурации
            string styles = "SELECT [CONFNAME],[CREATEDBY],[TEXT1],[TEXT2],[TEXT3],[TEXT4],[TEXT5],[TABLE1],[TABLE2],[TABLE3],[TABLE4],[TABLE5],[LIST1],[LIST2],[LIST3],[LIST4],[LIST5],[IMG1],[IMG2],[IMG3],[IMG4],[IMG5],[TITLELIST] FROM [CONFIGURATION] WHERE [CONFNAME] = N'"+confname+"' AND [CREATEDBY] = '"+mailfrom+"' ";
            SqlCommand taskstyles = new SqlCommand(styles,con);
            SqlDataReader stylesreader = taskstyles.ExecuteReader();

            int text1=0;
            int text2=0;
            int text3=0;
            int text4=0;
            int text5=0;
            int table1=0;
            int table2=0;
            int table3=0;
            int table4=0;
            int table5=0;
            int list1=0;
            int list2=0;
            int list3=0;
            int list4=0;
            int list5=0;
            int img1=0;
            int img2=0;
            int img3=0;
            int img4=0;
            int img5=0;
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
                textid[i]= textstylesreader.GetInt32(textstylesreader.GetOrdinal("ID"));
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

            if(titlelist!= 0)
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


        protected void AddSavedStyleToList(string Text, int id,string type)
        {
            Button style = new Button();
            style.Text = Text;
            style.ID = String.Concat("style_",type, id);
            style.Width = 152;
            style.CssClass = "LIST_Buttons";
            style.Attributes.Add("runat", "server");

            if (type == "text")
            {
                style.Click += new EventHandler(this.ButtonChooseText_Click);
            }
            else if (type == "table")
            {
                style.Click += new EventHandler(this.ButtonChooseTable_Click);
            }
            else if (type == "list")
            {
                style.Click += new EventHandler(this.ButtonChooseList_Click);
            }
            else if (type == "img")
            {
                style.Click += new EventHandler(this.ButtonChoosePic_Click);
            }
            else if (type == "title")
            {
                style.Click += new EventHandler(this.ButtonTitle_Click);
            }

            SavedStyles.Controls.Add(style);
        }

        protected void workWithPdf() // процедура для создания и показа файла pdf
        {
            string confname = (string)Session["NAMEOFTASK"];
            string name = (string)Session["FORFILENAME"];

            string filename = String.Concat(confname, " ", name, ".docx");
            // конвертация в pdf
            string getDownloads = MapPath("~/Docx/"); ;
            string FullFilePath = String.Concat(getDownloads, filename);
            DocumentCore dc = DocumentCore.Load(FullFilePath);

            string PDFfilename = String.Concat(confname, " ", name, ".pdf");
            // сохранение pdf на сервер
            string savingPath = MapPath("~/Pdfs/");
            dc.Save(String.Concat(savingPath + PDFfilename));
            showPDF.Src = "~/Pdfs/" + PDFfilename; //показать документ
        }
        protected void CreateTextBoxes(int Rows, int Columns, string style)
        {

            int counter_rows = 1;
            int posleftCounter = 400;
            int postopCounter = 400;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    TextBox tb = new TextBox();
                    tb.ID = "cell_ID" + i + j;
                    tb.Width = 80;
                    tb.Style["position"] = "absolute";
                    tb.Style["left"] = posleftCounter.ToString() + "px";
                    tb.Style["top"] = postopCounter.ToString() + "px";
                    tb.Style["visibility"] = style;
                    posleftCounter = posleftCounter + 100;
                    pnlTextBoxes.Controls.Add(tb);
                    counter_rows++;

                    Literal lt = new Literal();
                    lt.Text = "<br />";
                    pnlTextBoxes.Controls.Add(lt);


                }
                postopCounter = postopCounter + 30;
                posleftCounter = 400;
            }
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {

            // текстбоксы преинит
            int Columns = 10;
            int Rows = 10;
            string style = "hidden";
            this.CreateTextBoxes(Rows, Columns, style);


            //кнопки преинит
            for(int i = 0; i < 5; i++) 
            { 
                Button btn = new Button();
              //  btn.ID = String.Concat("style_","text", i);
                btn.Style.Add("position","absolute");
                btn.Attributes.Add("runat", "server");
                btn.Click += new EventHandler(this.ButtonChooseText_Click);
                btn.Style["visibility"] = "hidden";
                SavedStyles.Controls.Add(btn);
            }

            for (int i = 0; i < 5; i++)
            {
                Button btn = new Button();
              //  btn.ID = String.Concat("style_", "table", i);
                btn.Style.Add("position", "absolute");
                btn.Attributes.Add("runat", "server");
                btn.Click += new EventHandler(this.ButtonChooseTable_Click);
                btn.Style["visibility"] = "hidden";
                SavedStyles.Controls.Add(btn);
            }

            for (int i = 0; i < 5; i++)
            {
                Button btn = new Button();
             //   btn.ID = String.Concat("style_", "list", i);
                btn.Style.Add("position", "absolute");
                btn.Attributes.Add("runat", "server");
                btn.Click += new EventHandler(this.ButtonChooseList_Click);
                btn.Style["visibility"] = "hidden";
                SavedStyles.Controls.Add(btn);
            }

            for (int i = 0; i < 5; i++)
            {
                Button btn = new Button();
              //  btn.ID = String.Concat("style_", "img", i);
                btn.Style.Add("position", "absolute");
                btn.Attributes.Add("runat", "server");
                btn.Click += new EventHandler(this.ButtonChoosePic_Click);
                btn.Style["visibility"] = "hidden";
                SavedStyles.Controls.Add(btn);
            }

            workWithPdf();
        }

        protected void ButtonChooseText_Click(object sender,EventArgs e) // если выбран текст
        {
            Button button = sender as Button;
            if (button != null)
            {
                int value;
                string buttonid = button.ID;
                int.TryParse(string.Join("", buttonid.Where(c => char.IsDigit(c))), out value);
                int buttonnumb = value;
                string style = value.ToString();
                Session["TEXTADD"] = style;
                Session["ADDSTATUS"] = "Text";
            }

            rectangleTitle.Visible = false;
            TitleBoxes.Style.Add("visibility", "hidden");
            Images.Style.Add("visibility", "hidden");
            List.Style.Add("visibility", "hidden");
            TextAndList.Style.Add("visibility", "hidden");
            Title.Style.Add("visibility", "hidden");
            Tables.Style.Add("visibility", "hidden");
            string redline = "\u2007\u2007\u2007\u2007\u2007"; // красная строка

            TextAndList.Style.Add("visibility", "visible");
            TextBoxEditing.Text = redline; // красная строка

        }
        protected void ButtonChooseTable_Click(object sender, EventArgs e) //если выбрана таблица
        {
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

            rectangleTitle.Visible = false;
            TitleBoxes.Style.Add("visibility", "hidden");
            Images.Style.Add("visibility", "hidden");
            List.Style.Add("visibility", "hidden");
            TextAndList.Style.Add("visibility", "hidden");
            Title.Style.Add("visibility", "hidden");
            Tables.Style.Add("visibility", "hidden");

            Tables.Style.Add("visibility", "visible");
        }

        protected void ButtonChooseList_Click(object sender, EventArgs e) // если выбран список
        {
            Session["COUNTERLIST"] = "2";
            Button button = sender as Button;
            if (button != null)
            {
                int value;
                string buttonid = button.ID;
                int.TryParse(string.Join("", buttonid.Where(c => char.IsDigit(c))), out value);
                int buttonnumb = value;
                string style = value.ToString();
                Session["LISTADD"] = style;
                Session["ADDSTATUS"] = "List";
            }

            rectangleTitle.Visible = false;
            TitleBoxes.Style.Add("visibility", "hidden");
            Images.Style.Add("visibility", "hidden");
            List.Style.Add("visibility", "hidden");
            TextAndList.Style.Add("visibility", "hidden");
            Title.Style.Add("visibility", "hidden");
            Tables.Style.Add("visibility", "hidden");
            string redline = "\u2007\u2007\u2007\u2007\u2007"; // красная строка

            TextAndList.Style.Add("visibility", "visible");
            List.Style.Add("visibility", "visible");
            TextBoxEditing.Text = String.Concat(redline,"1.","\u2007"); // красная строка
        }

        protected void ButtonChoosePic_Click(object sender, EventArgs e) //если выбрана картинка
        {
            Session["COUNTERIMG"] = "1";
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

            rectangleTitle.Visible = false;
            TitleBoxes.Style.Add("visibility", "hidden");
            Images.Style.Add("visibility", "hidden");
            List.Style.Add("visibility", "hidden");
            TextAndList.Style.Add("visibility", "hidden");
            Title.Style.Add("visibility", "hidden");
            Tables.Style.Add("visibility", "hidden");
            Images.Style.Add("visibility", "visible");
        }

        protected void ButtonAddToMain_Click(object sender, EventArgs e)   // добавление текста в документ
        {

            string confname = (string)Session["NAMEOFTASK"];
            string name = (string)Session["FORFILENAME"];

            con.Open();
            string status = (string)Session["ADDSTATUS"];
            if (status == "Text")
            {
                // id  стиля
                string styleid = (string)Session["TEXTADD"];
                int idforstring = Int32.Parse(styleid);
                string textstylenames = "SELECT [ID],[Font],[Alignment],[FontSize],[IntervalAfter],[IntervalBefore] FROM [TEXT] WHERE [ID] ='"+idforstring+"' ";
                SqlCommand textstyles = new SqlCommand(textstylenames, con);
                SqlDataReader textstylesreader = textstyles.ExecuteReader();
                while (textstylesreader.Read())
                {
                    TextFontFont = new Xceed.Document.NET.Font((string)textstylesreader["Font"]);
                    TextFontSize = textstylesreader.GetInt32(textstylesreader.GetOrdinal("FontSize"));
                    TextSpacingAfter = textstylesreader.GetInt32(textstylesreader.GetOrdinal("IntervalAfter"));
                    TextSpacingBefore = textstylesreader.GetInt32(textstylesreader.GetOrdinal("IntervalBefore"));
                    TextAlign = (string)textstylesreader["Alignment"];
                }
                textstylesreader.Close();

                string TextToAdd;
                TextToAdd = String.Concat(TextBoxEditing.Text, "\n");


                string filename = String.Concat("/", confname, " ", name, ".docx");
                string downloadsPath = MapPath("~/Docx/");
                string filepath = String.Concat(downloadsPath, filename);


                var doc = DocX.Load(filepath);
                var par = doc.InsertParagraph();
                if (TextAlign == "both")
                {
                    Xceed.Document.NET.Alignment TextAlignment = Xceed.Document.NET.Alignment.both;
                    par.Append(TextToAdd)    // форматирование документа
                    .Font(TextFontFont)
                    .FontSize(TextFontSize)
                    .SpacingBefore(TextSpacingBefore)
                    .SpacingAfter(TextSpacingAfter)
                    .Alignment = TextAlignment;
                } 
                else if (TextAlign == "left")
                {
                    Xceed.Document.NET.Alignment TextAlignment = Xceed.Document.NET.Alignment.left;
                    par.Append(TextToAdd)    // форматирование документа
                    .Font(TextFontFont)
                    .FontSize(TextFontSize)
                    .SpacingBefore(TextSpacingBefore)
                    .SpacingAfter(TextSpacingAfter)
                    .Alignment = TextAlignment;
                }
                else if (TextAlign == "right")
                {
                    Xceed.Document.NET.Alignment TextAlignment = Xceed.Document.NET.Alignment.right;
                    par.Append(TextToAdd)    // форматирование документа
                    .Font(TextFontFont)
                    .FontSize(TextFontSize)
                    .SpacingBefore(TextSpacingBefore)
                    .SpacingAfter(TextSpacingAfter)
                    .Alignment = TextAlignment;
                }
                else if (TextAlign == "center")
                {
                    Xceed.Document.NET.Alignment TextAlignment = Xceed.Document.NET.Alignment.center;
                    par.Append(TextToAdd)    // форматирование документа
                    .Font(TextFontFont)
                    .FontSize(TextFontSize)
                    .SpacingBefore(TextSpacingBefore)
                    .SpacingAfter(TextSpacingAfter)
                    .Alignment = TextAlignment;
                }
                doc.Save();
                TextBoxEditing.Text = "\u2007\u2007\u2007\u2007\u2007"; // очистка листа после добавления текста
            }
            else // для списка
            {
                // id  стиля
                string styleid = (string)Session["LISTADD"];
                int idforstring = Int32.Parse(styleid);
                string liststylenames = "SELECT [ID],[Font],[FontSize] FROM [LIST] WHERE [ID] ='" + idforstring + "' ";
                SqlCommand liststyles = new SqlCommand(liststylenames, con);
                SqlDataReader liststylesreader = liststyles.ExecuteReader();
                while (liststylesreader.Read())
                {
                    ListFontFont = new Xceed.Document.NET.Font((string)liststylesreader["Font"]);
                    ListFontSize = liststylesreader.GetInt32(liststylesreader.GetOrdinal("FontSize"));
                }
                liststylesreader.Close();
                string TextToAdd;
                TextToAdd = String.Concat(TextBoxEditing.Text, "\n");
                string downloadsPath = new KnownFolder(KnownFolderType.Downloads).Path;
                string filepath = String.Concat(downloadsPath, "/Test.docx");
                var doc = DocX.Load(filepath);
                var par = doc.InsertParagraph();
                par.Append(TextToAdd)    // форматирование документа
                    .Font(ListFontFont)
                    .FontSize(ListFontSize);
                doc.Save();
                TextBoxEditing.Text = "\u2007\u2007\u2007\u2007\u2007"; // очистка листа после добавления текста
            }
            workWithPdf();
            con.Close();
        }

        protected void ButtonAddTitle_Click(object sender, EventArgs e)   // добавление титульника в документ
        {
            string confname = (string)Session["NAMEOFTASK"];
            string name = (string)Session["FORFILENAME"];


            string tbt1 = TextBoxTop1.Text;
            string tbt2 = TextBoxTop2.Text;
            string tbt3 = TextBoxTop3.Text;
            string tbt4 = TextBoxTop4.Text;
            string tbl1 = TextBoxLeft1.Text;
            string tbl2 = TextBoxLeft2.Text;
            string tbl3 = TextBoxLeft3.Text;
            string tbl4 = TextBoxLeft4.Text;
            string tbr1 = TextBoxRight1.Text;
            string tbr2 = TextBoxRight2.Text;
            string tbr3 = TextBoxRight3.Text;
            string tbr4 = TextBoxRight4.Text;
            string tbb1 = TextBoxBot1.Text;
            string tbb2 = TextBoxBot2.Text;
            string tbb3 = TextBoxBot3.Text;
            string tbb4 = TextBoxBot4.Text;
            string tbb5 = TextBoxBot5.Text;
            string tbb6 = TextBoxBot6.Text;
            string tbb7 = TextBoxBot7.Text;
            string tbb8 = TextBoxBot8.Text;
            string tbb9 = TextBoxBot9.Text;


            ///////////////////////////////////////////////////////////////
            ///////////////////    ТЕКСТ ДЛЯ ТИТУЛЬНИКА    ////////////////
            ///////////////////////////////////////////////////////////////


            string filename = String.Concat("/", confname, " ", name, ".docx");
            string downloadsPath = MapPath("~/Docx/");
            string filepath = String.Concat(downloadsPath, filename);

            var doc = DocX.Load(filepath);
            var part1 = doc.InsertParagraph();
            part1.Append(tbt1)    // форматирование документа
            .Font(new Xceed.Document.NET.Font("Times New Roman"))
            .FontSize(14)
            .SpacingBefore(0)
            .SpacingAfter(10);
            part1.Alignment = Alignment.center;

            /////////////////////////////////////////////////////////////

            var part2 = doc.InsertParagraph();
            part2.Append(tbt2)
            .Font(new Xceed.Document.NET.Font("Times New Roman"))
            .FontSize(14)
            .SpacingBefore(0)
            .SpacingAfter(10);
            part2.Alignment = Alignment.center;
            part2.CapsStyle(CapsStyle.caps);
            part2.UnderlineColor(System.Drawing.Color.Black);

            /////////////////////////////////////////////////////////////

            var part3 = doc.InsertParagraph();
            part3.Append(tbt3)
            .Font(new Xceed.Document.NET.Font("Times New Roman"))
            .FontSize(14)
            .SpacingBefore(0)
            .SpacingAfter(10);
            part3.Alignment = Alignment.center;
            part3.CapsStyle(CapsStyle.caps);

            /////////////////////////////////////////////////////////////

            var part4 = doc.InsertParagraph();
            part4.Append(tbt4)
            .Font(new Xceed.Document.NET.Font("Times New Roman"))
            .FontSize(14)
            .SpacingBefore(0)
            .SpacingAfter(54);
            part4.Alignment = Alignment.center;
            part4.CapsStyle(CapsStyle.caps);

            /////////////////////////////////////////////////////////////

            var parm1 = doc.InsertParagraph();
            string strm1 = String.Concat(tbl1, "\t", tbr1);
            parm1.Append(strm1)
            .Font(new Xceed.Document.NET.Font("Times New Roman"))
            .FontSize(14)
            .SpacingBefore(0)
            .Bold()
            .SpacingAfter(10);
            parm1.Alignment = Alignment.left;
            parm1.CapsStyle(CapsStyle.caps);
            parm1.InsertTabStopPosition(Alignment.right, 456);

            /////////////////////////////////////////////////////////////

            var parm2 = doc.InsertParagraph();
            string strm2 = String.Concat(tbl2, "\t", tbr2);
            parm2.Append(strm2)
            .Font(new Xceed.Document.NET.Font("Times New Roman"))
            .FontSize(14)
            .SpacingBefore(0)
            .SpacingAfter(10);
            parm2.Alignment = Alignment.left;
            parm2.InsertTabStopPosition(Alignment.right, 456);

            /////////////////////////////////////////////////////////////

            var parm3 = doc.InsertParagraph();
            string strm3 = String.Concat(tbl3, "\t", tbr3);
            parm3.Append(strm3)
            .Font(new Xceed.Document.NET.Font("Times New Roman"))
            .FontSize(14)
            .SpacingBefore(0)
            .SpacingAfter(10);
            parm3.Alignment = Alignment.left;
            parm3.InsertTabStopPosition(Alignment.right, 456);

            /////////////////////////////////////////////////////////////

            var parm4 = doc.InsertParagraph();
            string strm4 = String.Concat(tbl4, "\t", tbr4);
            parm4.Append(strm4)
            .Font(new Xceed.Document.NET.Font("Times New Roman"))
            .FontSize(14)
            .SpacingBefore(0)
            .SpacingAfter(10);
            parm4.Alignment = Alignment.left;
            parm4.InsertTabStopPosition(Alignment.right,456);

            /////////////////////////////////////////////////////////////

            var parb1 = doc.InsertParagraph();
            string tbnumb = String.Concat(tbb1," ",tbb2);
            parb1.Append(tbnumb)    // форматирование документа
            .Font(new Xceed.Document.NET.Font("Times New Roman"))
            .FontSize(24)
            .SpacingBefore(0)
            .Bold()
            .SpacingAfter(10);
            parb1.Alignment = Alignment.center;

            /////////////////////////////////////////////////////////////

            var parb3 = doc.InsertParagraph();
            parb3.Append(tbb3)    // форматирование документа
            .Font(new Xceed.Document.NET.Font("Times New Roman"))
            .FontSize(11)
            .SpacingBefore(0)
            .SpacingAfter(10);
            parb3.Alignment = Alignment.center;

            /////////////////////////////////////////////////////////////

            var parb4 = doc.InsertParagraph();
            parb4.Append(tbb4)    // форматирование документа
            .Font(new Xceed.Document.NET.Font("Times New Roman"))
            .FontSize(22)
            .SpacingBefore(0)
            .SpacingAfter(10);
            parb4.Alignment = Alignment.center;

            /////////////////////////////////////////////////////////////

            var parb5 = doc.InsertParagraph();
            string tbvar=String.Concat(tbb5," ",tbb6);
            parb5.Append(tbvar)    // форматирование документа
            .Font(new Xceed.Document.NET.Font("Times New Roman"))
            .FontSize(11)
            .SpacingBefore(0)
            .SpacingAfter(48);
            parb5.Alignment = Alignment.center;

            /////////////////////////////////////////////////////////////

            var parb7 = doc.InsertParagraph();
            parb7.Append(tbb7)    // форматирование документа
            .Font(new Xceed.Document.NET.Font("Times New Roman"))
            .FontSize(11)
            .SpacingBefore(0)
            .SpacingAfter(10);
            parb7.Alignment = Alignment.center;

            /////////////////////////////////////////////////////////////

            var parb8 = doc.InsertParagraph();
            parb8.Append(tbb8)    // форматирование документа
            .Font(new Xceed.Document.NET.Font("Times New Roman"))
            .FontSize(22)
            .SpacingBefore(0)
            .SpacingAfter(168);
            parb8.Alignment = Alignment.center;

            /////////////////////////////////////////////////////////////

            var parb9 = doc.InsertParagraph();
            parb9.Append(tbb9)    // форматирование документа
            .Font(new Xceed.Document.NET.Font("Times New Roman"))
            .FontSize(11)
            .Bold()
            .SpacingBefore(0)
            .SpacingAfter(10);
            parb9.Alignment = Alignment.center;

            /////////////////////////////////////////////////////////////
            doc.InsertSectionPageBreak();
            doc.Save();
            workWithPdf();
        }

        protected void ButtonAddList_Click(object sender, EventArgs e)
        {
            string redline = "\u2007\u2007\u2007\u2007\u2007"; // красная строка
            string LISTID = (string)Session["COUNTERLIST"];
            int listID = Int32.Parse(LISTID);
            TextBoxEditing.Text += String.Concat(Environment.NewLine,redline,listID,".", "\u2007");
            listID++;
            Session["COUNTERLIST"] = listID.ToString();
            
        }

        protected void UploadFile(object sender, EventArgs e)
        {
            string confname = (string)Session["NAMEOFTASK"];
            string name = (string)Session["FORFILENAME"];

            string folderPath = MapPath("~/Images/");
            
            //Save the File to the Directory (Folder).
            FileUpload.SaveAs(folderPath + Path.GetFileName(FileUpload.FileName));

            //Display the Picture in Image control.
            Image1.ImageUrl = "~/Images/" + Path.GetFileName(FileUpload.FileName);
            Session["IMGPATH"]= Path.GetFileName(FileUpload.FileName);
        }

        protected void ButtonAddImage_Click(object sender, EventArgs e)
        {
            string confname = (string)Session["NAMEOFTASK"];
            string name = (string)Session["FORFILENAME"];

            string filename = String.Concat("/", confname, " ", name, ".docx");
            string downloadsPath = MapPath("~/Docx/");
            string filepath = String.Concat(downloadsPath, filename);
            var doc = DocX.Load(filepath);
            string imgPath = (string)Session["IMGPATH"];
            Image img = doc.AddImage(MapPath("~/Images/")+imgPath);
            Picture p = img.CreatePicture(200,200);
            string counterimg = (string)Session["COUNTERIMG"];
            int ImgID = Int32.Parse(counterimg);
            string imginsert = String.Concat("Рисунок ", counterimg," -");
            Xceed.Document.NET.Paragraph par = doc.InsertParagraph(imginsert);
            par.AppendPicture(p);
            doc.Save();
            Session["IMGPATH"]="";
            ImgID++;
            Session["COUNTERIMG"] = ImgID.ToString();
            workWithPdf();
        }

        protected void TextBoxCounter_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonTitle_Click(object sender, EventArgs e)
        {
            con.Open();

            Images.Style.Add("visibility", "hidden");
            List.Style.Add("visibility", "hidden");
            TextAndList.Style.Add("visibility", "hidden");
            Title.Style.Add("visibility", "hidden");
            Tables.Style.Add("visibility", "hidden");

            rectangleTitle.Visible = true;
            Title.Style.Add("visibility", "visible");
            TitleBoxes.Style.Add("visibility", "visible");

            Button button = sender as Button;
                int value;
                string buttonid = button.ID;
                int.TryParse(string.Join("", buttonid.Where(c => char.IsDigit(c))), out value);
                int buttonnumb = value;

            string titletext = "SELECT [TBT1],[TBT2],[TBT3],[TBT4],[TBL1],[TBR1],[TBB1],[TBB3],[TBB5],[TBB7],[TBB9] FROM [TitleList] WHERE [ID] ='"+value+"' ";
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


        protected void ButtonTableCreate_Click(object sender, EventArgs e)
        {

            int Columns = Int32.Parse(TextBoxColumn.Text);
            int Rows = Int32.Parse(TextBoxRows.Text);
            int index = pnlTextBoxes.Controls.OfType<TextBox>().ToList().Count + (Rows * Columns);
            string style = "visible";
            this.CreateTextBoxes(Rows, Columns, style);

        }

        protected void ButtonToWord_Click(object sender, EventArgs e)
        {
            string confname = (string)Session["NAMEOFTASK"];
            string name = (string)Session["FORFILENAME"];

            con.Open();
            // id  стиля
            string styleid = (string)Session["TABLEADD"];
            int idforstring = Int32.Parse(styleid);
            string tablestylenames = "SELECT [ID],[Font],[FontSize],[TableAlignment],[CellAlignment] FROM [TABLE] WHERE [ID] ='" + idforstring + "' ";
            SqlCommand tablestyles = new SqlCommand(tablestylenames, con);
            SqlDataReader tablestylesreader = tablestyles.ExecuteReader();
            while (tablestylesreader.Read())
            {
                TableFontFont = new Xceed.Document.NET.Font((string)tablestylesreader["Font"]);
                TableFontSize = tablestylesreader.GetInt32(tablestylesreader.GetOrdinal("FontSize"));
                TableAlign = (string)tablestylesreader["TableAlignment"];
                TableCellAlign = (string)tablestylesreader["CellAlignment"];
            }
            tablestylesreader.Close();

            int Columns = Int32.Parse(TextBoxColumn.Text);
            int Rows = Int32.Parse(TextBoxRows.Text);

            string filename = String.Concat("/", confname, " ", name, ".docx");
            string downloadsPath = MapPath("~/Docx/");
            string filepath = String.Concat(downloadsPath, filename);
            var doc = DocX.Load(filepath);

            // создаём таблицу
            Xceed.Document.NET.Table table = doc.AddTable(Rows, Columns);
            // меняем стандартный дизайн таблицы
            table.Design = TableDesign.TableGrid;


            if (TableAlign == "center")
            {
                Xceed.Document.NET.Alignment TableAlignment = Xceed.Document.NET.Alignment.center;
                table.Alignment = TableAlignment;
            }
            else if(TableAlign == "left")
            {
                Xceed.Document.NET.Alignment TableAlignment = Xceed.Document.NET.Alignment.left;
                table.Alignment = TableAlignment;
            }
            else if (TableAlign == "right")
            {
                Xceed.Document.NET.Alignment TableAlignment = Xceed.Document.NET.Alignment.right;
                table.Alignment = TableAlignment;
            }
            else if (TableAlign == "both")
            {
                Xceed.Document.NET.Alignment TableAlignment = Xceed.Document.NET.Alignment.both;
                table.Alignment = TableAlignment;
            }

            if(TableCellAlign == "top")
            {
                //заполнение ячеек текстом
                for (int Rows_X = 0; Rows_X < Rows; Rows_X++)
                {
                    for (int Columns_Y = 0; Columns_Y < Columns; Columns_Y++)
                    {
                        string cellid = "cell_ID" + Rows_X + Columns_Y;
                        TextBox text = (TextBox)pnlTextBoxes.FindControl(cellid);
                        string cell = text.Text;
                        cell = cell.Remove(0, 1);
                        table.Rows[Rows_X].Cells[Columns_Y].Paragraphs.First().Append(cell)
                            .Font(TableFontFont)
                            .FontSize(TableFontSize);
                        table.Rows[Rows_X].Cells[Columns_Y].VerticalAlignment = VerticalAlignment.Top;
                    }
                }
            }
            else if (TableCellAlign == "center")
            {
                //заполнение ячеек текстом
                for (int Rows_X = 0; Rows_X < Rows; Rows_X++)
                {
                    for (int Columns_Y = 0; Columns_Y < Columns; Columns_Y++)
                    {
                        string cellid = "cell_ID" + Rows_X + Columns_Y;
                        TextBox text = (TextBox)pnlTextBoxes.FindControl(cellid);
                        string cell = text.Text;
                        cell = cell.Remove(0, 1);
                        table.Rows[Rows_X].Cells[Columns_Y].Paragraphs.First().Append(cell)
                            .Font(TableFontFont)
                            .FontSize(TableFontSize);
                        table.Rows[Rows_X].Cells[Columns_Y].VerticalAlignment = VerticalAlignment.Center;
                    }
                }
            }
            else if (TableCellAlign == "bottom")
            {
                //заполнение ячеек текстом
                for (int Rows_X = 0; Rows_X < Rows; Rows_X++)
                {
                    for (int Columns_Y = 0; Columns_Y < Columns; Columns_Y++)
                    {
                        string cellid = "cell_ID" + Rows_X + Columns_Y;
                        TextBox text = (TextBox)pnlTextBoxes.FindControl(cellid);
                        string cell = text.Text;
                        cell = cell.Remove(0, 1);
                        table.Rows[Rows_X].Cells[Columns_Y].Paragraphs.First().Append(cell)
                            .Font(TableFontFont)
                            .FontSize(TableFontSize);
                        table.Rows[Rows_X].Cells[Columns_Y].VerticalAlignment = VerticalAlignment.Bottom;
                    }
                }
            }
            // создаём параграф и вставляем таблицу
            doc.InsertTable(table);
            // сохраняем документ
            doc.Save();
            workWithPdf();
            con.Close();
        }

        protected void ButtonDownloadWord_Click(object sender, EventArgs e)
        {
            string confname = (string)Session["NAMEOFTASK"];
            string name = (string)Session["FORFILENAME"];

            string fileName = String.Concat("/", confname, " ", name, ".docx");
            string downloadsPath = MapPath("~/Docx/");
            string strLocalFilePath = String.Concat(downloadsPath, fileName);

            Response.Clear();

            Stream iStream = null;

            const int bufferSize = 64 * 1024;

            byte[] buffer = new Byte[bufferSize];

            int length;

            long dataToRead;

            try
            {
                iStream = new FileStream(strLocalFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                dataToRead = iStream.Length;
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);

                while (dataToRead > 0)
                {
                    if (Response.IsClientConnected)
                    {
                        length = iStream.Read(buffer, 0, bufferSize);
                        Response.OutputStream.Write(buffer, 0, length);
                        Response.Flush();
                        buffer = new byte[bufferSize];
                        dataToRead = dataToRead - length;
                    }
                    else
                    {
                        //prevent infinate loop on disconnect
                        dataToRead = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                //Your exception handling here
            }
            finally
            {
                if (iStream != null)
                {
                    iStream.Close();
                }
                Response.Close();
            }
        }

        protected void ButtonDownloadPdf_Click(object sender, EventArgs e)
        {
            string confname = (string)Session["NAMEOFTASK"];
            string name = (string)Session["FORFILENAME"];

            string fileName = String.Concat("/", confname, " ", name, ".pdf");
            string downloadsPath = MapPath("~/Pdfs/");
            string strLocalFilePath = String.Concat(downloadsPath, fileName);

            Response.Clear();

            Stream iStream = null;

            const int bufferSize = 64 * 1024;

            byte[] buffer = new Byte[bufferSize];

            int length;

            long dataToRead;

            try
            {
                iStream = new FileStream(strLocalFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                dataToRead = iStream.Length;
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);

                while (dataToRead > 0)
                {
                    if (Response.IsClientConnected)
                    {
                        length = iStream.Read(buffer, 0, bufferSize);
                        Response.OutputStream.Write(buffer, 0, length);
                        Response.Flush();
                        buffer = new byte[bufferSize];
                        dataToRead = dataToRead - length;
                    }
                    else
                    {
                        //prevent infinate loop on disconnect
                        dataToRead = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                //Your exception handling here
            }
            finally
            {
                if (iStream != null)
                {
                    iStream.Close();
                }
                Response.Close();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////

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
        protected void TextBoxEditing_TextChanged1(object sender, EventArgs e)
        {

        }

        protected void DropDownListForElements_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}