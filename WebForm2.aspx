<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="DocumentReportBuilder.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title> 
   <%-- <script src ="Scripts/ckeditor5test/build/ckeditor.js" ></script>--%>
    <script src="https://cdn.ckeditor.com/ckeditor5/32.0.0/decoupled-document/ckeditor.js"></script>
</head>
<body>

    <style>
  .ck-editor__editable {
  min-height: 600px;
  max-width: 600px
}
  .ck.ck-toolbar {
    max-width: 620px;
    min-width: 600px;
}
    </style>




    <h1>Создание конфигурации</h1>

    <!-- The toolbar will be rendered in this container. -->
    <div id="toolbar-container"></div>

    <!-- This container will become the editable. -->
    <div id="editor">
        <p></p>
    </div>



    <script>
        DecoupledEditor
            .create(document.querySelector('#editor'))
            .then(editor => {
                const toolbarContainer = document.querySelector('#toolbar-container');

                toolbarContainer.appendChild(editor.ui.view.toolbar.element);
            })
            .catch(error => {
                console.error(error);
            });
    </script>
</body>
</html>
