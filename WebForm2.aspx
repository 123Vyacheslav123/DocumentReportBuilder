<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="DocumentReportBuilder.WebForm2" %>

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
            width: 900

        });
    </script>
  
</body>
</html>
