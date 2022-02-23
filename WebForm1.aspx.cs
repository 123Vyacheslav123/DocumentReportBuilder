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
                Image1.Visible = false;
                FileUpload.Visible = false;
                ButtonUploadImg.Visible = false;
                ButtonAddImage.Visible = false;
                ButtonAddToMain.Visible = true;
                ButtonAddList.Visible = false;
                TextBoxEditing.Visible = true;
                TextBoxEditing.Text = redline; // красная строка
            }  
            else if ((DropDownListForElements.SelectedItem.Value) == "1") // если найдено Value для Таблицы
            {
                Image1.Visible = false;
                FileUpload.Visible = false;
                ButtonUploadImg.Visible = false;
                ButtonAddImage.Visible = false;
                ButtonAddToMain.Visible = false;
                ButtonAddList.Visible = false;
                TextBoxEditing.Visible = false;
            }   
            else if ((DropDownListForElements.SelectedItem.Value) == "2") // если найдено Value для Списка
            {
                Image1.Visible = false;
                FileUpload.Visible = false;
                ButtonUploadImg.Visible = false;
                ButtonAddImage.Visible = false;
                ButtonAddToMain.Visible = true;
                ButtonAddList.Visible = true;
                TextBoxEditing.Visible = true;
                TextBoxEditing.Text = String.Concat(redline,"1.","\u2007"); // красная строка
            }   
                
            else if ((DropDownListForElements.SelectedItem.Value) == "3") // если найдено Value для картинки
            {
                ButtonAddToMain.Visible = false;
                ButtonAddList.Visible = false;
                TextBoxEditing.Visible = false;
                Image1.Visible = true;
                FileUpload.Visible = true;
                ButtonUploadImg.Visible = true;
                ButtonAddImage.Visible = true;
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
            TextBoxEditing.Text += String.Concat(Environment.NewLine,redline,listID,".", "\u2007");
            listID++;
        }

        protected void UploadFile(object sender, EventArgs e)
        {
            
            string folderPath = MapPath("~/Images/");

            ////Save the File to the Directory (Folder).
            FileUpload.SaveAs(folderPath + Path.GetFileName(FileUpload.FileName));

            //Display the Picture in Image control.
            Image1.ImageUrl = "~/Images/" + Path.GetFileName(FileUpload.FileName);
            TextBoxStorage.Text=Path.GetFileName(FileUpload.FileName);
        }

        protected void ButtonAddImage_Click(object sender, EventArgs e)
        {
            string folderPath = MapPath("~/Images/");
            string downloadsPath = new KnownFolder(KnownFolderType.Downloads).Path;
            string filepath = String.Concat(downloadsPath, "/Test.docx");
            var doc = DocX.Load(filepath);
            string imgPath = TextBoxStorage.Text;
            Image img = doc.AddImage(MapPath("~/Images/")+imgPath);
            Picture p = img.CreatePicture(200,200);
            Paragraph par = doc.InsertParagraph("Рисунок 1 - ");
            par.AppendPicture(p);
            doc.Save();
            TextBoxStorage.Text = "";
        }

        protected void TextBoxStorage_TextChanged(object sender, EventArgs e)
        {

        }
    }
}