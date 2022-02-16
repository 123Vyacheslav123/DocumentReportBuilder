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
        <div>
        </div>
        <p>
            <asp:Button ID="Button1" runat="server" Height="40px" Width="120px" OnClick="ButtonDownload_Click" Text="Скачать" style="position:absolute;left:674px; bottom:65px;" />  <%-- Кнопка скачивания --%>

            <asp:TextBox ID="TextBoxEditing" runat="server" Height="200px" Width="700px" AcceptsTab="True" TextAlign="Distribute" Wrap="true" style="position:absolute;bottom:515px; left: 93px;" TextMode="MultiLine"></asp:TextBox> <%-- Вспомогательный ТекстБокс --%>

            <asp:TextBox ID="MainTextBox" runat="server" Height="850px" Width="700px" AcceptsTab="True" TextAlign="Distribute" TextMode="MultiLine" style="position:absolute;left:843px; top: 49px;" OnTextChanged="MainTextBox_TextChanged"></asp:TextBox> <%-- Главный ТекстБокс --%>

            <asp:Button ID="ButtonChoose" runat="server" Height="40px" Width="120px" OnClick="ButtonChoose_Click" style="position:absolute; top: 146px; left: 638px;" Text="Выбрать" /> <%-- Кнопка выбора элемента --%>
        <asp:Button ID="ButtonTable" runat="server" Height="40px" style="position:absolute; top: 422px; left: 219px;" Width="120px" OnClick="ButtonTable_Click" Text="Таблица" />

            <asp:Button ID="ButtonToTeacher" runat="server" Height="40px" style="position:absolute; top: 80px; left: 166px;" Width="200px" OnClick="ButtonToTeacher_Click" Text="Создание шаблона" PostBackUrl="~/Views/Home/Index.cshtml" />

        </p>
        <asp:DropDownList ID="DropDownListForElements" Width="250px" runat="server" style="position:absolute; top: 156px; left: 190px;" OnSelectedIndexChanged="DropDownListForElements_SelectedIndexChanged"> <%-- Список элементов --%>
            <asp:ListItem Value="0">Текст</asp:ListItem>
            <asp:ListItem Value="1">Таблица</asp:ListItem>
            <asp:ListItem Value="2">Список</asp:ListItem>
            <asp:ListItem Value="3">Рисунок</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="ButtonAddToMain" Height="40px" Width="200px" runat="server" style="position:absolute; top: 418px; left: 588px;" OnClick="ButtonAddToMain_Click" Text="Добавить на лист" /> <%-- Список элементов --%>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <asp:TextBox ID="TextBoxRows" style="position:absolute; top: 474px; left: 194px;" runat="server" OnTextChanged="TextBoxRows_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBoxColumns" style="position:absolute; top: 518px; left: 193px;" runat="server" OnTextChanged="TextBoxColumns_TextChanged"></asp:TextBox>
        <asp:Button ID="ButtonAddTable" runat="server" Height="40px" Width="120px" style="position:absolute; top: 567px; left: 210px;" OnClick="ButtonAddTable_Click" Text="Добавить" />
        <asp:Button ID="ButtonCreateFile" runat="server" Height="40px" Width="200px" style="position:absolute; top: 503px; left: 583px;" Text="Создать документ" OnClick="ButtonCreateFile_Click" />
         
    </form>
</body>
</html>
