<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentBuilder.aspx.cs" Inherits="DocumentReportBuilder.StudentBuilder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="Styles/Boxes.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div id="Based" style="visibility:visible" runat="server">

            <asp:Button ID="ButtonChoose" runat="server" Height="40px" Width="120px" OnClick="ButtonChoose_Click" style="position:absolute; top: 146px; left: 638px;" Text="Выбрать" /> <%-- Кнопка выбора элемента --%>
            <asp:Button ID="ButtonTitle" Height="40px" Width="250px" style="position:absolute; top: 80px; width: 251px; left: 30px;" runat="server" Text="Заполнить Титульник" OnClick="ButtonTitle_Click" />
            <asp:Button ID="ButtonToWebForm2" runat="server" Height="40px" Width="250px" style="position:absolute; top: 80px; width: 251px; left: 307px;" OnClick="ButtonToWebForm2_Click" Text="Создание конфигурации" />
            <asp:DropDownList ID="DropDownListForElements" Width="250px" runat="server" style="position:absolute; top: 156px; left: 190px;" OnSelectedIndexChanged="DropDownListForElements_SelectedIndexChanged"> <%-- Список элементов --%>
                <asp:ListItem Value="0">Текст</asp:ListItem>
                <asp:ListItem Value="1">Таблица</asp:ListItem>
                <asp:ListItem Value="2">Список</asp:ListItem>
                <asp:ListItem Value="3">Рисунок</asp:ListItem>
            </asp:DropDownList>

            <asp:Button ID="ButtonCreateFile" runat="server" Height="40px" Width="200px" style="position:absolute; top: 503px; left: 583px;" Text="Создать документ" OnClick="ButtonCreateFile_Click" />

        </div>

        <div id ="TextAndList" style="visibility:hidden" runat="server">

            <asp:TextBox ID="TextBoxEditing" runat="server" Height="200px" Width="700px" AcceptsTab="True" TextAlign="Distribute" Wrap="true" style="position:absolute;bottom:516px; left: 92px;" TextMode="MultiLine" OnTextChanged="TextBoxEditing_TextChanged1"></asp:TextBox> <%-- Вспомогательный ТекстБокс --%>
            <asp:Button ID="ButtonAddToMain" Height="40px" Width="200px" runat="server" style="position:absolute; top: 418px; left: 588px;" OnClick="ButtonAddToMain_Click" Text="Добавить Текст" />

        </div>

        <div id="List" style="visibility:hidden" runat="server">

            <asp:Button ID="ButtonAddList" runat="server" style="position:absolute; top: 523px; left: 120px;" OnClick="ButtonAddList_Click" Text="Следующий пункт" Visible="False" />

        </div>

        <div id="Images" style="visibility:hidden" runat="server">
         
            <asp:Button ID="ButtonAddImage" runat="server" Height="40px" Width="200px" style="position:absolute; top: 550px; left: 200px;" OnClick="ButtonAddImage_Click" Text="Добавить фото" />
            <asp:FileUpload ID="FileUpload" style="position:absolute;top:500px; left: 300px;" runat="server" /><br/>
            <asp:Button ID="ButtonUploadImg" runat="server" style="position:absolute;top:500px; left: 150px;" Text="Загрузить фото" OnClick="UploadFile" /><br/>
            <asp:Image ID="Image1" style="position:absolute;top:250px; left: 150px; width:400px; height:250px" runat="server" />
            
        </div>

        <div id="Title" style="visibility:hidden" runat="server">

             <asp:Button ID="ButtonAddTtitle" runat="server" Height="40px" Width="200px" Visible="False" style="position:absolute; top: 418px; left: 588px;" OnClick="ButtonAddTitle_Click" Text="Добавить титульник" />

        </div>
       
        
        <div id="TopBoxes" style="visibility:hidden" runat="server">
        <asp:TextBox ID="TextBoxTop1" Width="600px" ReadOnly="true" CssClass="AllBoxes" style="position:absolute; top:100px; margin-left:1100px;margin-right:0px;" runat="server" OnTextChanged="TextBoxTop1_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBoxTop2" Width="600px" ReadOnly="true" CssClass="AllBoxes" style="position:absolute; top:150px; margin-left:1100px;margin-right:0px;" runat="server" OnTextChanged="TextBoxTop2_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBoxTop3" Width="600px" ReadOnly="true" CssClass="AllBoxes" style="position:absolute; top:200px; margin-left:1100px;margin-right:0px;" runat="server" OnTextChanged="TextBoxTop3_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBoxTop4" Width="600px" ReadOnly="true" CssClass="AllBoxes" style="position:absolute; top:250px; margin-left:1100px;margin-right:0px;" runat="server" OnTextChanged="TextBoxTop4_TextChanged"></asp:TextBox>
            </div>

            <div id="LeftBoxes" style="visibility:hidden" runat="server">
                <asp:TextBox ID="TextBoxLeft1" Width="300px" ReadOnly="true" CssClass="AllBoxes" style="position:absolute; top:350px; margin-left:900px;margin-right:0px;" runat="server" OnTextChanged="TextBoxLeft1_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxLeft2" Width="300px" CssClass="AllBoxes" style="position:absolute; top:400px; margin-left:900px;margin-right:0px;" runat="server" OnTextChanged="TextBoxLeft3_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxLeft3" Width="300px" CssClass="AllBoxes" style="position:absolute; top:450px; margin-left:900px;margin-right:0px;" runat="server" OnTextChanged="TextBoxLeft3_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxLeft4" Width="300px" CssClass="AllBoxes" style="position:absolute; top:500px; margin-left:900px;margin-right:0px;" runat="server" OnTextChanged="TextBoxLeft4_TextChanged"></asp:TextBox>
            </div>


            <div id="RightBoxes" style="visibility:hidden" runat="server">
                <asp:TextBox ID="TextBoxRight1" Width="300px" CssClass="AllBoxes" ReadOnly="true" style="position:absolute; top:350px; margin-left:1600px;margin-right:0px;" runat="server" OnTextChanged="TextBoxRight1_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxRight2" Width="300px" CssClass="AllBoxes" style="position:absolute; top:400px; margin-left:1600px;margin-right:0px;" runat="server" OnTextChanged="TextBoxRight2_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxRight3" Width="300px" CssClass="AllBoxes" style="position:absolute; top:450px; margin-left:1600px;margin-right:0px;" runat="server" OnTextChanged="TextBoxRight3_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxRight4" Width="300px" CssClass="AllBoxes" style="position:absolute; top:500px; margin-left:1600px;margin-right:0px;" runat="server" OnTextChanged="TextBoxRight4_TextChanged"></asp:TextBox>

            </div>


            <div id="BotBoxes" style="visibility:hidden" runat="server">
                <asp:TextBox ID="TextBoxBot1" Width="600px" CssClass="AllBoxes" style="position:absolute; top:550px; margin-left:1100px;margin-right:0px;" runat="server" OnTextChanged="TextBoxBot1_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot2" Width="30px" CssClass="AllBoxes" style="position:absolute; top:550px; margin-left:1710px;margin-right:0px;" runat="server" OnTextChanged="TextBoxBot2_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot3" Width="200px" CssClass="AllBoxes" style="position:absolute; top:600px; margin-left:1300px;margin-right:0px;" runat="server" OnTextChanged="TextBoxBot3_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot4" Width="600px" CssClass="AllBoxes" style="position:absolute; top:650px; margin-left:1100px;margin-right:0px;" runat="server" OnTextChanged="TextBoxBot4_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot5" Width="200px" CssClass="AllBoxes" style="position:absolute; top:700px; margin-left:1300px;margin-right:0px;" runat="server" OnTextChanged="TextBoxBot5_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot6" Width="30px" CssClass="AllBoxes" style="position:absolute; top:700px; margin-left:1510px;margin-right:0px;" runat="server" OnTextChanged="TextBoxBot6_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot7" Width="200px" CssClass="AllBoxes" style="position:absolute; top:800px; margin-left:1300px;margin-right:0px;" runat="server" OnTextChanged="TextBoxBot7_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot8" Width="600px" CssClass="AllBoxes" style="position:absolute; top:850px; margin-left:1100px;margin-right:0px;" runat="server" OnTextChanged="TextBoxBot8_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot9" Width="600px" CssClass="AllBoxes" style="position:absolute; top:1100px; margin-left:1100px;margin-right:0px;" runat="server" OnTextChanged="TextBoxBot9_TextChanged"></asp:TextBox>
            </div>


        <div id ="Tables" style="visibility:hidden"  runat="server" >   <%--Кнопки для таблиц --%>

                <asp:Panel ID="pnlTextBoxes" style="position:absolute" runat="server"> </asp:Panel>
            <p>
                <asp:Label ID="LabelColumn" style="position:absolute; bottom:650px" runat="server" Text="Столбцы"></asp:Label>
                <asp:TextBox ID="TextBoxColumn" style="position:absolute; left:100px; bottom:650px;" runat="server" Height="16px" TextMode="Number" Width="66px"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="LabelRows" style="position:absolute; bottom:600px" runat="server" Text="Строки"></asp:Label>
                <asp:TextBox ID="TextBoxRows" style="position:absolute; left:100px; bottom:600px" runat="server" TextMode="Number" Width="65px"></asp:TextBox>
            </p>
                <asp:Button ID="ButtonTableCreate" style="position:absolute; bottom:550px" runat="server" OnClick="ButtonTableCreate_Click" Text="Выбрать" />
                <asp:Button ID="ButtonToWord" style="position:absolute;left:120px; bottom:550px" runat="server" OnClick="ButtonToWord_Click" Text="Добавить" />

        </div>



    </form>

           
</body>
</html>
