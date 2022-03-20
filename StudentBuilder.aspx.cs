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

namespace DocumentReportBuilder
{
    public partial class StudentBuilder : System.Web.UI.Page
    { 

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            int Columns = 10;
            int Rows = 10;
            string style = "hidden";
            this.CreateTextBoxes(Rows, Columns, style);
        }

        protected void TextBoxEditing_TextChanged1(object sender, EventArgs e)
        {
           
        }

        protected void DropDownListForElements_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonChoose_Click(object sender, EventArgs e)  // поиск по Value из DropDownListForElements
        {
             ButtonAddTtitle.Visible = false;
            string redline = "\u2007\u2007\u2007\u2007\u2007"; // красная строка
            TopBoxes.Style.Add("visibility", "hidden");
            LeftBoxes.Style.Add("visibility", "hidden");
            RightBoxes.Style.Add("visibility", "hidden");
            BotBoxes.Style.Add("visibility", "hidden");
            Images.Style.Add("visibility", "hidden");
            List.Style.Add("visibility", "hidden");
            TextAndList.Style.Add("visibility", "hidden");
            Title.Style.Add("visibility", "hidden");
            Tables.Style.Add("visibility", "hidden");

            if ((DropDownListForElements.SelectedItem.Value) == "0") // если найдено Value для текста
            {
                TextAndList.Style.Add("visibility", "visible");
                TextBoxEditing.Text = redline; // красная строка
            }  
            else if ((DropDownListForElements.SelectedItem.Value) == "1") // если найдено Value для Таблицы
            {
                Tables.Style.Add("visibility", "visible");

            }   
            else if ((DropDownListForElements.SelectedItem.Value) == "2") // если найдено Value для Списка
            {
                TextAndList.Style.Add("visibility", "visible");
                List.Style.Add("visibility", "visible");
                TextBoxEditing.Text = String.Concat(redline,"1.","\u2007"); // красная строка
            }   
                
            else if ((DropDownListForElements.SelectedItem.Value) == "3") // если найдено Value для картинки
            {
                Images.Style.Add("visibility", "visible");
            }
            else
            {
                ButtonAddList.Visible = false;
                TextBoxEditing.Visible = true;
                TextBoxEditing.Text = "Ошибка";
            }
        }

        protected void ButtonAddToMain_Click(object sender, EventArgs e)   // добавление текста на главный лист
        {
            string TextToAdd;
            TextToAdd =String.Concat(TextBoxEditing.Text, "\n");
            string downloadsPath = new KnownFolder(KnownFolderType.Downloads).Path;
            string filepath = String.Concat(downloadsPath, "/Test.docx");
            var doc = DocX.Load(filepath);
            var par = doc.InsertParagraph();
            par.Append(TextToAdd)    // форматирование документа
            .Font(new Xceed.Document.NET.Font("Times New Roman"))
            .FontSize(14)
            .SpacingBefore(0)
            .SpacingAfter(6)
            .SpacingLine(18);
            doc.Save();
            TextBoxEditing.Text = "\u2007\u2007\u2007\u2007\u2007"; // очистка листа после добавления текста
        }

        protected void ButtonAddTitle_Click(object sender, EventArgs e)   // добавление текста на главный лист
        {
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

            string downloadsPath = new KnownFolder(KnownFolderType.Downloads).Path;
            string filepath = String.Concat(downloadsPath, "/Test.docx");
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

            doc.Save();
        }

        protected void ButtonCreateFile_Click(object sender, EventArgs e)
        {
            string downloadsPath = new KnownFolder(KnownFolderType.Downloads).Path;
            string filepath = String.Concat(downloadsPath, "/Test.docx");
            var doc = DocX.Create(filepath);
            doc.Save();
            Session["COUNTERIMG"] = "1";
            Session["COUNTERLIST"] = "2";
        }
        protected void ButtonToWebForm2_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/TeacherBuilder.aspx");
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
            
            string folderPath = MapPath("~/Images/");

            //Save the File to the Directory (Folder).
            FileUpload.SaveAs(folderPath + Path.GetFileName(FileUpload.FileName));

            //Display the Picture in Image control.
            Image1.ImageUrl = "~/Images/" + Path.GetFileName(FileUpload.FileName);
            Session["IMGPATH"]= Path.GetFileName(FileUpload.FileName);
        }

        protected void ButtonAddImage_Click(object sender, EventArgs e)
        {
           
            string downloadsPath = new KnownFolder(KnownFolderType.Downloads).Path;
            string filepath = String.Concat(downloadsPath, "/Test.docx");
            var doc = DocX.Load(filepath);
            string imgPath = (string)Session["IMGPATH"];
            Image img = doc.AddImage(MapPath("~/Images/")+imgPath);
            Picture p = img.CreatePicture(200,200);
            string counterimg = (string)Session["COUNTERIMG"];
            int ImgID = Int32.Parse(counterimg);
            string imginsert = String.Concat("Рисунок ", counterimg," -");
            Paragraph par = doc.InsertParagraph(imginsert);
            par.AppendPicture(p);
            doc.Save();
            Session["IMGPATH"]="";
            ImgID++;
            Session["COUNTERIMG"] = ImgID.ToString();
        }

        protected void TextBoxCounter_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonTitle_Click(object sender, EventArgs e)
        {
            Title.Style.Add("visibility", "visible"); ;
            TopBoxes.Style.Add("visibility","visible");
            LeftBoxes.Style.Add("visibility", "visible");
            RightBoxes.Style.Add("visibility", "visible");
            BotBoxes.Style.Add("visibility", "visible");
            TextBoxTop1.Text = (string)Session["TBT1"];
            TextBoxTop2.Text = (string)Session["TBT2"];
            TextBoxTop3.Text = (string)Session["TBT3"];
            TextBoxTop4.Text = (string)Session["TBT4"];
            TextBoxLeft1.Text = (string)Session["TBL1"];
            TextBoxRight1.Text = (string)Session["TBR1"];
            TextBoxBot1.Text = (string)Session["TBB1"];
            TextBoxBot3.Text = (string)Session["TBB3"];
            TextBoxBot5.Text = (string)Session["TBB5"];
            TextBoxBot7.Text = (string)Session["TBB7"];
            TextBoxBot9.Text = (string)Session["TBB9"];
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
            int Columns = Int32.Parse(TextBoxColumn.Text);
            int Rows = Int32.Parse(TextBoxRows.Text);
            string downloadsPath = new KnownFolder(KnownFolderType.Downloads).Path;
            string filepath = String.Concat(downloadsPath, "/Test.docx");
            var doc = DocX.Load(filepath);

            // создаём таблицу
            Xceed.Document.NET.Table table = doc.AddTable(Rows, Columns);

            // располагаем таблицу по центру
            table.Alignment = Alignment.center;

            // меняем стандартный дизайн таблицы
            table.Design = TableDesign.TableGrid;

            //заполнение ячейки текстом
            for (int Rows_X = 0; Rows_X < Rows; Rows_X++)
            {
                for (int Columns_Y = 0; Columns_Y < Columns; Columns_Y++)
                {
                    string cellid = "cell_ID" + Columns_Y + Rows_X;
                    TextBox text = (TextBox)pnlTextBoxes.FindControl(cellid);
                    table.Rows[Rows_X].Cells[Columns_Y].Paragraphs.First().Append(text.Text);

                }
            }
            // создаём параграф и вставляем таблицу
            doc.InsertTable(table);
            // сохраняем документ
            doc.Save();
        }

        protected void CreateTextBoxes(int Rows, int Columns, string style)
        {

            int counter_rows = 1;
            int posleftCounter = 250;
            int postopCounter = 160;
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
                posleftCounter = 250;
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
    }
}