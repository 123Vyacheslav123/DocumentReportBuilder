﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="DocumentReportBuilder.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title> 
   <script src ="Scripts/ckeditor/ckeditor.js" ></script>
    
</head>
<body>

   <div>
       <textarea id ="content" name="content"></textarea>
   </div>

    <script>
        var editor = CKEDITOR.replace('content', {
            height: 400,
            width: 900,
            toolbar: [
                { name: 'document', groups: ['mode', 'document', 'doctools'], items: ['ExportPdf'] },
                { name: 'clipboard', groups: ['clipboard', 'undo'], items: [] },
                { name: 'editing', groups: ['find', 'selection', 'spellchecker'], items: ['Find'] },
                { name: 'forms', items: [] },
                '/',
                { name: 'basicstyles', groups: ['basicstyles', 'cleanup'], items: ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript', '-', 'RemoveFormat'] },
                { name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi'], items: ['NumberedList', 'BulletedList', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'] },
                { name: 'links', items: [] },
                { name: 'insert', items: ['Image', 'Flash', 'Table','SpecialChar'] },
                '/',
                { name: 'styles', items: ['Styles', 'Format', 'Font', 'FontSize'] },
                { name: 'colors', items: ['TextColor', 'BGColor'] },
                { name: 'tools', items: [] },
                { name: 'others', items: ['-'] },
                { name: 'about', items: [] }
            ]
            });
    </script>
  
</body>
</html>
