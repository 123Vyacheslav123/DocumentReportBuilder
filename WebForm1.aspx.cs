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

        protected void TextBoxEditing_TextChanged1(object sender, EventArgs e)
        {
           
        }

        protected void DropDownListForElements_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonChoose_Click(object sender, EventArgs e)  // поиск по Value из DropDownListForElements
        {
            string redline = "\u2007\u2007\u2007\u2007\u2007"; // красная строка
            

           if ((DropDownListForElements.SelectedItem.Value) =="0") // если найдено Value для текста
            {
                ButtonAddList.Visible = false;
                TextBoxEditing.Visible = true;
                TextBoxEditing.Text = redline; // красная строка
            }  
            else if ((DropDownListForElements.SelectedItem.Value) == "1") // если найдено Value для Таблицы
            {
                ButtonAddList.Visible = false;
                TextBoxEditing.Visible = false;
            }   
            else if ((DropDownListForElements.SelectedItem.Value) == "2") // если найдено Value для Списка
            {
                ButtonAddList.Visible = true;
                TextBoxEditing.Visible = true;
                TextBoxEditing.Text = String.Concat(redline,"1.","\u2007"); // красная строка
            }   
                
            else if ((DropDownListForElements.SelectedItem.Value) == "3") // если найдено Value для картинки
            {
                ButtonAddList.Visible = false;
                TextBoxEditing.Visible = false;
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
            MainTextBox.Text +=TextToAdd;
            TextBoxEditing.Text = "\u2007\u2007\u2007\u2007\u2007"; // очистка листа после добавления текста
        }

        protected void ButtonCreateFile_Click(object sender, EventArgs e)
        {
            string downloadsPath = new KnownFolder(KnownFolderType.Downloads).Path;
            string filepath = String.Concat(downloadsPath, "/Test.docx");
            var doc = DocX.Create(filepath);
            doc.Save();

        }
        protected void ButtonToWebForm2_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/WebForm2.aspx");
        }

        protected void ButtonAddList_Click(object sender, EventArgs e)
        {
            string redline = "\u2007\u2007\u2007\u2007\u2007"; // красная строка
            int listID = 2;
            TextBoxEditing.Text += String.Concat(Environment.NewLine,redline,listID,".", "/u2007");
            listID++;
        }
    }
}