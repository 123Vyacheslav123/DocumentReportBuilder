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

namespace DocumentReportBuilder
{
    public partial class WebForm1 : System.Web.UI.Page
    { 



        protected void Page_Load(object sender, EventArgs e)
        {
            TextBoxRows.Visible = false;
            TextBoxColumns.Visible = false;
            ButtonAddTable.Visible = false;
        }

        protected void ButtonDownload_Click(object sender, EventArgs e)   // кнопка скачивания документа
        {
            string text;
            text = MainTextBox.Text; // берем текст из MainTextBox
            string downloadsPath = new KnownFolder(KnownFolderType.Downloads).Path;
            string filepath = String.Concat(downloadsPath, "/Test.docx");
            var doc = DocX.Load(filepath);
            var par = doc.InsertParagraph();
            par.Append(text)    // форматирование документа
            .Font(new Xceed.Document.NET.Font("Times New Roman"))
            .FontSize(14)
            .SpacingBefore(0)
            .SpacingAfter(6)
            .SpacingLine(18);

            doc.Save();
        }

        protected void MainTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBoxEditing_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownListForElements_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonChoose_Click(object sender, EventArgs e)  // поиск по Value из DropDownListForElements
        {
           if ((DropDownListForElements.SelectedItem.Value) =="0") // если найдено Value для текста
            {
                TextBoxEditing.Text ="\u2007\u2007\u2007\u2007\u2007"; // красная строка
            }
            else                                                   // для остальных(пока что)
            {
                TextBoxEditing.Text = "Пока что не доступно";
            }
           
        }

        protected void ButtonAddToMain_Click(object sender, EventArgs e)   // добавление текста на главный лист
        {
            string TextToAdd;
            TextToAdd =String.Concat(TextBoxEditing.Text, "\n");
            MainTextBox.Text +=TextToAdd;
            TextBoxEditing.Text = "\u2007\u2007\u2007\u2007\u2007"; // очистка листа после добавления текста
        }

        protected void ButtonTable_Click(object sender, EventArgs e)
        {
            TextBoxRows.Visible = true;
            TextBoxColumns.Visible = true;
            ButtonAddTable.Visible = true;
        }

        protected void ButtonAddTable_Click(object sender, EventArgs e)
        {
            string downloadsPath = new KnownFolder(KnownFolderType.Downloads).Path;
            string filepath = String.Concat(downloadsPath, "/Test.docx");

            string Rows = TextBoxRows.Text.ToString();
            int Rows_int = Int32.Parse(Rows);
            string Columns = TextBoxColumns.Text.ToString();
            int Columns_int = Int32.Parse(Columns);
            
                var doc = DocX.Load(filepath);
                Border b = new Border();
                b.Color = Color.Black;
                var t = doc.AddTable(Rows_int, Columns_int);
                t.SetBorder(TableBorderType.Bottom, b);
                t.SetBorder(TableBorderType.InsideH, b);
                t.SetBorder(TableBorderType.InsideV, b);
                t.SetBorder(TableBorderType.Left, b);
                t.SetBorder(TableBorderType.Right, b);
                t.SetBorder(TableBorderType.Top, b);
                t.Rows[0].Cells[0].Paragraphs.First().Append("");
                t.Rows[1].Cells[0].Paragraphs.First().Append("");
                t.Rows[2].Cells[0].Paragraphs.First().Append("");
                doc.InsertTable(t);
                doc.SaveAs(filepath);

        }

        protected void TextBoxRows_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBoxColumns_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonCreateFile_Click(object sender, EventArgs e)
        {
            string downloadsPath = new KnownFolder(KnownFolderType.Downloads).Path;
            string filepath = String.Concat(downloadsPath, "/Test.docx");
            var doc = DocX.Create(filepath);
            doc.Save();

        }

        protected void ButtonToTeacher_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/WebForm2.aspx");
        }
    }
}