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

            <asp:TextBox ID="TextBoxEditing" runat="server" Height="200px" Width="700px" AcceptsTab="True" TextAlign="Distribute" Wrap="true" style="position:absolute;bottom:516px; left: 92px;" TextMode="MultiLine" OnTextChanged="TextBoxEditing_TextChanged1"></asp:TextBox> <%-- Вспомогательный ТекстБокс --%>
            
            <asp:FileUpload ID="FileUpload" style="position:absolute;bottom:515px; left: 300px;" Visible="False" runat="server" /><br/>

            <asp:Button ID="ButtonUploadImg" runat="server" style="position:absolute;bottom:515px; left: 90px;" Text="Загрузить фото" Visible="False" OnClick="UploadFile" /><br/>

            <asp:Image ID="Image1" style="position:absolute;bottom:250px; left: 90px; width:400px; height:250px" Visible="False" runat="server" />

            <asp:Button ID="ButtonChoose" runat="server" Height="40px" Width="120px" OnClick="ButtonChoose_Click" style="position:absolute; top: 146px; left: 638px;" Text="Выбрать" /> <%-- Кнопка выбора элемента --%>

            <asp:Button ID="ButtonToWebForm2" runat="server" Height="40px" Width="250px" style="position:absolute; top: 80px; width: 251px; left: 307px;" OnClick="ButtonToWebForm2_Click" Text="Создание конфигурации" />

            <asp:Button ID="ButtonTitle" Height="40px" Width="250px" style="position:absolute; top: 80px; width: 251px; left: 30px;" runat="server" Text="Заполнить Титульник" OnClick="ButtonTitle_Click" />

        </p>
        <asp:DropDownList ID="DropDownListForElements" Width="250px" runat="server" style="position:absolute; top: 156px; left: 190px;" OnSelectedIndexChanged="DropDownListForElements_SelectedIndexChanged"> <%-- Список элементов --%>
            <asp:ListItem Value="0">Текст</asp:ListItem>
            <asp:ListItem Value="1">Таблица</asp:ListItem>
            <asp:ListItem Value="2">Список</asp:ListItem>
            <asp:ListItem Value="3">Рисунок</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="ButtonAddToMain" Height="40px" Width="200px" runat="server" style="position:absolute; top: 418px; left: 588px;" OnClick="ButtonAddToMain_Click" Text="Добавить Текст" />
       
        
        <asp:Button ID="ButtonCreateFile" runat="server" Height="40px" Width="200px" style="position:absolute; top: 503px; left: 583px;" Text="Создать документ" OnClick="ButtonCreateFile_Click" />
         
        <asp:Button ID="ButtonAddList" runat="server" style="position:absolute; top: 523px; left: 120px;" OnClick="ButtonAddList_Click" Text="Следующий пункт" Visible="False" />
         
        <asp:Button ID="ButtonAddImage" runat="server" Height="40px" Width="200px" Visible="False" style="position:absolute; top: 418px; left: 588px;" OnClick="ButtonAddImage_Click" Text="Добавить фото" />
         
        <asp:TextBox ID="TextBoxStorage" runat="server" OnTextChanged="TextBoxStorage_TextChanged" Visible="False"></asp:TextBox>
         
        <asp:TextBox ID="TextBoxCounter" runat="server" OnTextChanged="TextBoxCounter_TextChanged" Visible="False"></asp:TextBox>
         
        
        <div id="TopBoxes" style="visibility:hidden" runat="server">
        <asp:TextBox ID="TextBoxTop1" Width="600px" ReadOnly="true" style="position:absolute; top:100px; margin-left:1100px;margin-right:0px;" runat="server" OnTextChanged="TextBoxTop1_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBoxTop2" Width="600px" ReadOnly="true" style="position:absolute; top:150px; margin-left:1100px;margin-right:0px;" runat="server" OnTextChanged="TextBoxTop2_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBoxTop3" Width="600px" ReadOnly="true" style="position:absolute; top:200px; margin-left:1100px;margin-right:0px;" runat="server" OnTextChanged="TextBoxTop3_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBoxTop4" Width="600px" ReadOnly="true" style="position:absolute; top:250px; margin-left:1100px;margin-right:0px;" runat="server" OnTextChanged="TextBoxTop4_TextChanged"></asp:TextBox>
            </div>

            <div id="LeftBoxes" style="visibility:hidden" runat="server">
                <asp:TextBox ID="TextBoxLeft1" Width="300px" ReadOnly="true" style="position:absolute; top:350px; margin-left:900px;margin-right:0px;" runat="server" OnTextChanged="TextBoxLeft1_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxLeft2" Width="300px" style="position:absolute; top:400px; margin-left:900px;margin-right:0px;" runat="server" OnTextChanged="TextBoxLeft3_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxLeft3" Width="300px" style="position:absolute; top:450px; margin-left:900px;margin-right:0px;" runat="server" OnTextChanged="TextBoxLeft3_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxLeft4" Width="300px" style="position:absolute; top:500px; margin-left:900px;margin-right:0px;" runat="server" OnTextChanged="TextBoxLeft4_TextChanged"></asp:TextBox>

            </div>

            <div id="RightBoxes" style="visibility:hidden" runat="server">
                <asp:TextBox ID="TextBoxRight1" Width="300px" ReadOnly="true" style="position:absolute; top:350px; margin-left:1600px;margin-right:0px;" runat="server" OnTextChanged="TextBoxRight1_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxRight2" Width="300px" style="position:absolute; top:400px; margin-left:1600px;margin-right:0px;" runat="server" OnTextChanged="TextBoxRight2_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxRight3" Width="300px" style="position:absolute; top:450px; margin-left:1600px;margin-right:0px;" runat="server" OnTextChanged="TextBoxRight3_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxRight4" Width="300px" style="position:absolute; top:500px; margin-left:1600px;margin-right:0px;" runat="server" OnTextChanged="TextBoxRight4_TextChanged"></asp:TextBox>

            </div>


            <div id="BotBoxes" style="visibility:hidden" runat="server">
                <asp:TextBox ID="TextBoxBot1" Width="600px" ReadOnly="true" style="position:absolute; top:550px; margin-left:1100px;margin-right:0px;" runat="server" OnTextChanged="TextBoxBot1_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot2" Width="30px" ReadOnly="true" style="position:absolute; top:550px; margin-left:1710px;margin-right:0px;" runat="server" OnTextChanged="TextBoxBot1_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot3" Width="200px" style="position:absolute; top:600px; margin-left:1300px;margin-right:0px;" runat="server" OnTextChanged="TextBoxBot2_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot4" Width="600px" ReadOnly="true" style="position:absolute; top:650px; margin-left:1100px;margin-right:0px;" runat="server" OnTextChanged="TextBoxBot3_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot5" Width="200px" ReadOnly="true" style="position:absolute; top:700px; margin-left:1300px;margin-right:0px;" runat="server" OnTextChanged="TextBoxBot4_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot6" Width="30px" style="position:absolute; top:700px; margin-left:1510px;margin-right:0px;" runat="server" OnTextChanged="TextBoxBot4_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot7" Width="200px" ReadOnly="true" style="position:absolute; top:800px; margin-left:1300px;margin-right:0px;" runat="server" OnTextChanged="TextBoxBot5_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot8" Width="600px" style="position:absolute; top:850px; margin-left:1100px;margin-right:0px;" runat="server" OnTextChanged="TextBoxBot6_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot9" Width="600px" style="position:absolute; top:1100px; margin-left:1100px;margin-right:0px;" runat="server" OnTextChanged="TextBoxBot7_TextChanged"></asp:TextBox>
            </div>

         
    </form>

           
</body>
</html>
