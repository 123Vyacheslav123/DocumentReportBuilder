<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="DocumentReportBuilder.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>

    </title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <asp:Button ID="Button1" runat="server" Height="40px" Width="120px" OnClick="ButtonDownload_Click" Text="Скачать" style="position:absolute;left:674px; bottom:65px;" />  <%-- Кнопка скачивания --%>

            <asp:TextBox ID="TextBoxEditing" runat="server" Height="200px" Width="700px" AcceptsTab="True" TextAlign="Distribute" Wrap="true" style="position:absolute;bottom:515px; left: 93px;" TextMode="MultiLine" OnTextChanged="TextBoxEditing_TextChanged1"></asp:TextBox> <%-- Вспомогательный ТекстБокс --%>
            
            <asp:FileUpload ID="FileUpload" style="position:absolute;bottom:515px; left: 300px;" Visible="False" runat="server" /><br/>

            <asp:Button ID="ButtonUploadImg" runat="server" style="position:absolute;bottom:515px; left: 90px;" Text="Загрузить фото" Visible="False" OnClick="UploadFile" /><br/>

            <asp:Image ID="Image1" style="position:absolute;bottom:250px; left: 90px; width:400px; height:250px" Visible="False" runat="server" />

            <asp:TextBox ID="MainTextBox" runat="server" Height="850px" Width="700px" AcceptsTab="True" TextAlign="Distribute" TextMode="MultiLine" style="position:absolute;left:843px; top: 49px;" OnTextChanged="MainTextBox_TextChanged"></asp:TextBox> <%-- Главный ТекстБокс --%>

            <asp:Button ID="ButtonChoose" runat="server" Height="40px" Width="120px" OnClick="ButtonChoose_Click" style="position:absolute; top: 146px; left: 638px;" Text="Выбрать" /> <%-- Кнопка выбора элемента --%>

            <asp:Button ID="ButtonToWebForm2" runat="server" Height="40px" Width="250px" style="position:absolute; top: 80px; width: 251px; left: 307px;" OnClick="ButtonToWebForm2_Click" Text="Создание конфигурации" />

        </p>
        <asp:DropDownList ID="DropDownListForElements" Width="250px" runat="server" style="position:absolute; top: 156px; left: 190px;" OnSelectedIndexChanged="DropDownListForElements_SelectedIndexChanged"> <%-- Список элементов --%>
            <asp:ListItem Value="0">Текст</asp:ListItem>
            <asp:ListItem Value="1">Таблица</asp:ListItem>
            <asp:ListItem Value="2">Список</asp:ListItem>
            <asp:ListItem Value="3">Рисунок</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="ButtonAddToMain" Height="40px" Width="200px" runat="server" style="position:absolute; top: 418px; left: 588px;" OnClick="ButtonAddToMain_Click" Text="Добавить Текст" />
       
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <asp:Button ID="ButtonCreateFile" runat="server" Height="40px" Width="200px" style="position:absolute; top: 503px; left: 583px;" Text="Создать документ" OnClick="ButtonCreateFile_Click" />
         
        <asp:Button ID="ButtonAddList" runat="server" style="position:absolute; top: 523px; left: 120px;" OnClick="ButtonAddList_Click" Text="Следующий пункт" Visible="False" />
         
        <asp:Button ID="ButtonAddImage" runat="server" Height="40px" Width="200px" Visible="False" style="position:absolute; top: 418px; left: 588px;" OnClick="ButtonAddImage_Click" Text="Добавить фото" />
         
       
         
        <asp:TextBox ID="TextBoxStorage" runat="server" OnTextChanged="TextBoxStorage_TextChanged" Visible="False"></asp:TextBox>
         
       
         
    </form>
</body>
</html>
