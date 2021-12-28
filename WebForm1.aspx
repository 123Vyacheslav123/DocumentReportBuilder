<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Report_Generator.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            height: 670px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           
  
            <asp:TextBox ID="TextBoxEditing" runat="server" Width="700px" AcceptsTab="True" TextAlign="Distribute" Wrap="true" style="position:absolute;bottom:428px; left: 26px; height: 107px;" TextMode="MultiLine"></asp:TextBox> 
        </div>
        <p>
            <asp:Button ID="Button1" runat="server" Height="40px" Width="120px" OnClick="ButtonDownload_Click" Text="Скачать" style="position:absolute;left:632px; bottom:65px;" />  <%-- Кнопка скачивания --%>
            <%-- Вспомогательный ТекстБокс --%>

            <asp:TextBox ID="MainTextBox" runat="server" Width="700px" AcceptsTab="True" TextAlign="Distribute" TextMode="MultiLine" style="position:absolute;left:843px; top: 49px; height: 603px;" OnTextChanged="MainTextBox_TextChanged"></asp:TextBox> <%-- Главный ТекстБокс --%>
            <%-- Кнопка выбора элемента --%>
        <asp:Button ID="ButtonTable" runat="server" Height="40px" style="position:absolute; top: 418px; left: 189px;" Width="120px" OnClick="ButtonTable_Click" Text="Таблица" />

        </p>
        <asp:DropDownList ID="DropDownListForElements" Width="250px" runat="server" style="position:absolute; top: 259px; left: 366px;" OnSelectedIndexChanged="DropDownListForElements_SelectedIndexChanged"> <%-- Список элементов --%>
            <asp:ListItem Value="0">Текст</asp:ListItem>
            <asp:ListItem Value="1">Таблица</asp:ListItem>
            <asp:ListItem Value="2">Список</asp:ListItem>
            <asp:ListItem Value="3">Рисунок</asp:ListItem>
            <asp:ListItem Value="4">Жёсткий текст</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="ButtonAddToMain" Height="40px" Width="200px" runat="server" style="position:absolute; top: 418px; left: 588px;" OnClick="ButtonAddToMain_Click" Text="Добавить на лист" /> <%-- Список элементов --%>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="Ready" runat="server" OnClick="Ready_Click" Text="Готово" style="position:absolute; top: 350px" />
            <asp:TextBox ID="Numb_Sy" runat="server" OnTextChanged="Numb_Sy_TextChanged" style="position:absolute; top: 350px; left: 100px;" TextMode="Number"></asp:TextBox>
        </p>
        <asp:TextBox ID="TextBoxRows" style="position:absolute; top: 474px; left: 194px;" runat="server" OnTextChanged="TextBoxRows_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBoxColumns" style="position:absolute; top: 518px; left: 193px;" runat="server" OnTextChanged="TextBoxColumns_TextChanged"></asp:TextBox>
        <asp:Button ID="ButtonAddTable" runat="server" Height="40px" Width="120px" style="position:absolute; top: 561px; left: 186px; right: 635px;" OnClick="ButtonAddTable_Click" Text="Добавить" />
        <asp:Button ID="ButtonCreateFile" runat="server" Height="40px" Width="200px" style="position:absolute; top: 503px; left: 589px;" Text="Создать документ" OnClick="ButtonCreateFile_Click" />

            <asp:Button ID="ButtonChoose" runat="server" Height="40px" Width="120px" OnClick="ButtonChoose_Click" style="position:absolute; top: 250px; left: 638px;" Text="Выбрать" /> 
        <embed ID="qw" runat="server" src="C:/Users/Admin/Desktop/1.pdf" style="position: absolute; left: 357px; top: 374px; z-index: 10; width: 200px;" aria-atomic="True" aria-busy="True" aria-checked="mixed" aria-disabled="True" aria-dropeffect="move" aria-sort="descending" />
        <iframe id="FRAME1" src="http://www.google.com" style="position: absolute; left: 900px; top: 81px; height: 472px; width: 554px;"></iframe>
    </form>
    
</body>
</html>
