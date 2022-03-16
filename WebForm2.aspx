<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="DocumentReportBuilder.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>


    <form id="form1" runat="server">
            <div id="TopBoxes" style="visibility:hidden;" runat="server">
        <asp:TextBox ID="TextBoxTop1" Width="600px" style="position:absolute; top:100px; margin-left:300px;margin-right:0px;left:800px; text-align: center; font-family:'Times New Roman';" runat="server" OnTextChanged="TextBoxTop1_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBoxTop2" Width="600px" style="position:absolute; top:150px; margin-left:300px;margin-right:0px;left:800px; text-align: center; font-family:'Times New Roman';" runat="server" OnTextChanged="TextBoxTop2_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBoxTop3" Width="600px" style="position:absolute; top:200px; margin-left:300px;margin-right:0px;left:800px; text-align: center; font-family:'Times New Roman';" runat="server" OnTextChanged="TextBoxTop3_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBoxTop4" Width="600px" style="position:absolute; top:250px; margin-left:300px;margin-right:0px;left:800px; text-align: center; font-family:'Times New Roman';" runat="server" OnTextChanged="TextBoxTop4_TextChanged"></asp:TextBox>
            </div>

           <div id="LeftBoxes" style="visibility:hidden" runat="server">
                <asp:TextBox ID="TextBoxLeft1" Width="300px" style="position:absolute; top:350px; margin-left:100px; margin-right:0px; left:800px; text-align: center; font-family:'Times New Roman';" runat="server" OnTextChanged="TextBoxLeft1_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxLeft2" Width="300px" style="position:absolute; top:400px; margin-left:100px; margin-right:0px; left:800px; text-align: center; font-family:'Times New Roman';" runat="server" OnTextChanged="TextBoxLeft2_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxLeft3" Width="300px" style="position:absolute; top:450px; margin-left:100px; margin-right:0px; left:800px; text-align: center; font-family:'Times New Roman';" runat="server" OnTextChanged="TextBoxLeft3_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxLeft4" Width="300px" style="position:absolute; top:500px; margin-left:100px; margin-right:0px; left:800px; text-align: center; font-family:'Times New Roman';" runat="server" OnTextChanged="TextBoxLeft4_TextChanged"></asp:TextBox>

            </div>

            <div id="RightBoxes" style="visibility:hidden" runat="server">
                <asp:TextBox ID="TextBoxRight1" Width="300px" style="position:absolute; top:350px; margin-left:800px;margin-right:0px;left:800px; text-align: center; font-family:'Times New Roman';" runat="server" OnTextChanged="TextBoxRight1_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxRight2" Width="300px" style="position:absolute; top:400px; margin-left:800px;margin-right:0px;left:800px; text-align: center; font-family:'Times New Roman';" runat="server" OnTextChanged="TextBoxRight2_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxRight3" Width="300px" style="position:absolute; top:450px; margin-left:800px;margin-right:0px;left:800px; text-align: center; font-family:'Times New Roman';" runat="server" OnTextChanged="TextBoxRight3_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxRight4" Width="300px" style="position:absolute; top:500px; margin-left:800px;margin-right:0px;left:800px; text-align: center; font-family:'Times New Roman';" runat="server" OnTextChanged="TextBoxRight4_TextChanged"></asp:TextBox>

            </div>


           <div id="BotBoxes" style="visibility:hidden" runat="server">
                <asp:TextBox ID="TextBoxBot1" Width="600px" style="position:absolute; top:550px; margin-left:300px;margin-right:0px;left:800px; text-align: center; font-family:'Times New Roman';" runat="server" OnTextChanged="TextBoxBot1_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot2" Width="30px" style="position:absolute; top:550px; margin-left:910px;margin-right:0px;left:800px; text-align: center; font-family:'Times New Roman';" runat="server" OnTextChanged="TextBoxBot2_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot3" Width="200px" style="position:absolute; top:600px; margin-left:500px;margin-right:0px;left:800px; text-align: center; font-family:'Times New Roman';" runat="server" OnTextChanged="TextBoxBot3_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot4" Width="600px" style="position:absolute; top:650px; margin-left:300px;margin-right:0px;left:800px; text-align: center; font-family:'Times New Roman';" runat="server" OnTextChanged="TextBoxBot4_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot5" Width="200px" style="position:absolute; top:700px; margin-left:500px;margin-right:0px;left:800px; text-align: center; font-family:'Times New Roman';" runat="server" OnTextChanged="TextBoxBot5_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot6" Width="30px" style="position:absolute; top:700px; margin-left:710px;margin-right:0px;left:800px; text-align: center; font-family:'Times New Roman';" runat="server" OnTextChanged="TextBoxBot6_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot7" Width="200px" style="position:absolute; top:800px; margin-left:500px;margin-right:0px;left:800px; text-align: center; font-family:'Times New Roman';" runat="server" OnTextChanged="TextBoxBot7_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot8" Width="600px" style="position:absolute; top:850px; margin-left:300px;margin-right:0px;left:800px; text-align: center; font-family:'Times New Roman';" runat="server" OnTextChanged="TextBoxBot8_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot9" Width="600px" style="position:absolute; top:1100px; margin-left:300px;margin-right:0px;left:800px; text-align: center; font-family:'Times New Roman';" runat="server" OnTextChanged="TextBoxBot9_TextChanged"></asp:TextBox>
            </div>
            
   

    <div>
        <asp:Button ID="ButtonCreateMainList" style="position:absolute; top:880px; margin-left:600px;margin-right:0px;" runat="server" Text="Сохранить титульник" OnClick="ButtonCreateMainList_Click" />
    </div>

    <div>
         <asp:Button ID="ButtonTest" style="position:absolute; top:50px; margin-left:300px;margin-right:0px;" runat="server" Text="Transfer" OnClick="ButtonTest_Click" />


         


    </div>
         <asp:Button ID="ButtonCreateTitleList" style="position:absolute; top:150px; left:250px" runat="server" Text="Задать титульник" OnClick="ButtonCreateTitleList_Click" />

         <asp:Button ID="ButtonCreateStyle" style="position:absolute; top:150px; margin-left:550px;margin-right:0px;" runat="server" Text="Создать стиль" OnClick="ButtonCreateStyle_Click" />

        <asp:DropDownList ID="DropDownListForElements" Width="250px" runat="server" style="position:absolute; top:200px; margin-left:550px;margin-right:0px;" OnSelectedIndexChanged="DropDownListForElements_SelectedIndexChanged"> <%-- Список элементов --%>
            <asp:ListItem Value="0">Текст</asp:ListItem>
            <asp:ListItem Value="1">Таблица</asp:ListItem>
            <asp:ListItem Value="2">Список</asp:ListItem>
            <asp:ListItem Value="3">Рисунок</asp:ListItem>
        </asp:DropDownList>

        <div id="TextStyle" style="visibility:hidden" runat="server">

            <asp:Label ID="LabelName" style="position:absolute; top:300px; left:250px" runat="server" Text="Имя"></asp:Label>

            <asp:TextBox ID="TextBoxName" Width="250px" style="position:absolute; top:300px; left:320px" runat="server"></asp:TextBox>

             <asp:Label ID="LabelStyle"  style="position:absolute; top:350px; left:250px" runat="server" Text="Стиль"></asp:Label>

            <asp:TextBox ID="TextBoxStyle" Width="250px" style="position:absolute; top:350px; left:320px" runat="server"></asp:TextBox>

            <asp:Label ID="LabelSize" style="position:absolute; top:300px; left:600px" runat="server" Text="Размер"></asp:Label>

            <asp:TextBox ID="TextBoxSize" Width="250px" style="position:absolute; top:350px; left:600px" runat="server"></asp:TextBox>

            <asp:Label ID="LabelRight" style="position:absolute; top:500px; left:250px" runat="server" Text="Справа"></asp:Label>

            <asp:TextBox ID="TextBoxRight" Width="50px" style="position:absolute; top:500px; left:330px" runat="server"></asp:TextBox>

            <asp:Label ID="LabelLeft" style="position:absolute; top:450px; left:250px" runat="server" Text="Слева"></asp:Label>

            <asp:TextBox ID="TextBoxLeft" Width="50px" style="position:absolute; top:450px; left:330px" runat="server"></asp:TextBox>

            <asp:Label ID="LabelSpace" style="position:absolute; top:420px; left:170px" runat="server" Text="Отступ"></asp:Label>

            <asp:Label ID="LabeL1stString" style="position:absolute; top:450px; left:600px" runat="server" Text="Первая строка"></asp:Label>

            <asp:TextBox ID="TextBox1stString" Width="100px" style="position:absolute; top:500px; left:600px" runat="server"></asp:TextBox>

            <asp:Label ID="LabeLOn" style="position:absolute; top:450px; left:820px" runat="server" Text="На"></asp:Label>

            <asp:TextBox ID="TextBoxOn" Width="50px" style="position:absolute; top:500px; left:820px" runat="server"></asp:TextBox>

            <asp:Label ID="LabelInterval" style="position:absolute; top:600px; left:170px" runat="server" Text="Интервал"></asp:Label>

            <asp:Label ID="LabelBefore" style="position:absolute; top:700px; left:250px" runat="server" Text="До"></asp:Label>

            <asp:TextBox ID="TextBoxBefore" Width="50px" style="position:absolute; top:700px; left:330px" runat="server"></asp:TextBox>

            <asp:Label ID="LabelAfter" style="position:absolute; top:650px; left:250px" runat="server" Text="После"></asp:Label>

            <asp:TextBox ID="TextBoxAfter" Width="50px" style="position:absolute; top:650px; left:330px" runat="server"></asp:TextBox>

            <asp:Label ID="LabeLInterline" style="position:absolute; top:650px; left:600px" runat="server" Text="Междустрочный"></asp:Label>

            <asp:TextBox ID="TextBoxInterline" Width="100px" style="position:absolute; top:700px; left:600px" runat="server"></asp:TextBox>

            <asp:Label ID="LabeLValue" style="position:absolute; top:650px; left:820px" runat="server" Text="Значение"></asp:Label>

            <asp:TextBox ID="TextBoxValue" Width="50px" style="position:absolute; top:700px; left:820px" runat="server"></asp:TextBox>

            </div>

                <div id="MainButtons" runat="server" >

            <asp:Button ID="ButtonSaveStyle" style="position:absolute; top:800px; left:600px" runat="server" Text="Сохранить" OnClick="ButtonSaveStyle_Click" />
            
            <asp:Button ID="ButtonGoBack" style="position:absolute; top:800px; left:800px" runat="server" Text="Отмена" OnClick="ButtonGoBack_Click" />

               </div>
                
         </form>

</body>
</html>
