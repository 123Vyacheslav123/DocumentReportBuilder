<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherBuilder.aspx.cs" Inherits="DocumentReportBuilder.TeacherBuilder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="Styles/Boxes.css" />
    <link href="Styles/Builder/FIR.css" rel="stylesheet" />
    <link href="Styles/Builder/Menu.css" rel="stylesheet" />
    <link href="Styles/Builder/STYLE.css" rel="stylesheet" />
    <title></title>
    <style>
        .ZAD_TIT {
            position: absolute;
            background-color: gray;
            left: 30%;
            top: 20%;
            padding-top: 10px;
            padding-bottom: 10px;
         padding-left: 15px;
         padding-right: 15px;
            border: none;
            border-radius: 15px;
             font-size: 16px; /*меняем размер шрифта*/
            font-weight: bold;
            transition: all 0.3s 0.01s ease; /*делаем плавный переход*/
        }
        .ZAD_TIT:hover {
            background-color: cornflowerblue;
        }
         .Buttons {
    position: absolute;
    left: 2%;
    top: 25%;
    border: 2px solid black;
    list-style-type: none;
    width: 17%;
    height: 60%;
    padding-top: 20px;
    text-align: center;
    padding-left: 0;
}
         #Button2, #Button3, #Button4 {
             border: none;
             background-color: gainsboro;
             transition: .3s;
         }
          #Button2:hover, #Button3:hover, #Button4:hover {
             background-color: cornflowerblue;
         }

    </style>
</head>
<body>


    <form id="form1" runat="server">

        



        <div>

            <ul class="FIR">
              <li class="CL1"><a class="CL1a" href="/TeacherMain.aspx">Главная</a></li>
              <li class="CL2"><a class="CL2a" href="/TeacherBuilder.aspx">Создать шаблон</a></li>
              <li class="CL3"><a class="CL3a" href="#">Сохранённые конфигурации</a></li>
              <li class="CL4"><a class="CL4a" href="#">Отправленные</a></li>
           
  <nav>

<ul class="topmenu" id ="MenuList" runat="server">

    <%--Заменено генерацией в Page_load--%>

    <%--<li><a href="/TeacherProfile.aspx" class="down">СОН.Х.М</a>
      <ul class="submenu">
        <li><a href="/TeacherProfile.aspx">Профиль</a></li>
        <li><a href="/Reg.aspx">Выход</a></li>
      </ul>
    </li>--%>
  </ul>


      </nav>   
             </ul>

            
        </div>
        <asp:Button ID="ButtonCreateTitleList_" CssClass="ZAD_TIT" runat="server" Text="Задать титульник" OnClick="ButtonCreateTitleList_Click" />
        <nav>
<ul class="topmenu1">
    <li><a href="" class="down1">Задать стиль</a>
      <ul class="submenu1">
        <li><a><asp:Button ID="ButtonTextStyle" BackColor="White" BorderStyle="None" runat="server" Text="Текст" OnClick="ButtonTextStyle_Click" /></a></li>
        <li><a><asp:Button ID="ButtonListStyle" BackColor="White" BorderStyle="None" runat="server" Text="Список" OnClick="ButtonListStyle_Click" /></a></li>
          <li><a><asp:Button ID="ButtonTableStyle" BackColor="White" BorderStyle="None" runat="server" Text="Таблица" OnClick="ButtonTableStyle_Click"/></a></li>
          <li><a><asp:Button ID="ButtonPicStyle" BackColor="White" BorderStyle="None" runat="server" Text="Рисунок" OnClick="ButtonPicStyle_Click"/></a></li>
      </ul>
    </li>
  </ul>
      </nav>
        
        <ul class="Buttons">
            <p>Сохранённые стили</p>
            <li>
                 <asp:Button ID="Button2" runat="server" Height="22px" style="margin-left: 0px; margin-bottom: 20px" Text="Таблица" Width="152px"/>
                <asp:Button ID="Button3" runat="server" Height="22px" style="margin-left: 0px; margin-bottom: 20px" Text="Стиль текста" Width="152px" />
        <asp:Button ID="Button4" runat="server" Height="22px" style="margin-left: 0px; margin-bottom: 20px" Text="Изображение" Width="152px" />
            </li>
           
            </ul>


















    <div id="Title" runat="server">
            <div id="TopBoxes" style="visibility:hidden;" runat="server">
        <asp:TextBox ID="TextBoxTop1" Width="600px" style="position:absolute; top:100px; margin-left:300px;margin-right:0px;left:800px;" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxTop1_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBoxTop2" Width="600px" style="position:absolute; top:150px; margin-left:300px;margin-right:0px;left:800px;" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxTop2_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBoxTop3" Width="600px" style="position:absolute; top:200px; margin-left:300px;margin-right:0px;left:800px;" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxTop3_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBoxTop4" Width="600px" style="position:absolute; top:250px; margin-left:300px;margin-right:0px;left:800px;" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxTop4_TextChanged"></asp:TextBox>
            </div>

           <div id="LeftBoxes" style="visibility:hidden" runat="server">
                <asp:TextBox ID="TextBoxLeft1" Width="300px" style="position:absolute; top:350px; margin-left:100px; margin-right:0px; left:800px;" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxLeft1_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxLeft2" Width="300px" style="position:absolute; top:400px; margin-left:100px; margin-right:0px; left:800px;" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxLeft2_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxLeft3" Width="300px" style="position:absolute; top:450px; margin-left:100px; margin-right:0px; left:800px;" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxLeft3_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxLeft4" Width="300px" style="position:absolute; top:500px; margin-left:100px; margin-right:0px; left:800px;" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxLeft4_TextChanged"></asp:TextBox>
            </div>

            <div id="RightBoxes" style="visibility:hidden" runat="server">
                <asp:TextBox ID="TextBoxRight1" Width="300px" style="position:absolute; top:350px; margin-left:800px;margin-right:0px;left:800px;" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxRight1_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxRight2" Width="300px" style="position:absolute; top:400px; margin-left:800px;margin-right:0px;left:800px;" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxRight2_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxRight3" Width="300px" style="position:absolute; top:450px; margin-left:800px;margin-right:0px;left:800px;" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxRight3_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxRight4" Width="300px" style="position:absolute; top:500px; margin-left:800px;margin-right:0px;left:800px;" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxRight4_TextChanged"></asp:TextBox>
            </div>


           <div id="BotBoxes" style="visibility:hidden" runat="server">
                <asp:TextBox ID="TextBoxBot1" Width="600px" style="position:absolute; top:550px; margin-left:300px;margin-right:0px;left:800px;" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxBot1_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot2" Width="30px" style="position:absolute; top:550px; margin-left:910px;margin-right:0px;left:800px;" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxBot2_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot3" Width="200px" style="position:absolute; top:600px; margin-left:500px;margin-right:0px;left:800px;" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxBot3_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot4" Width="600px" style="position:absolute; top:650px; margin-left:300px;margin-right:0px;left:800px;" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxBot4_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot5" Width="200px" style="position:absolute; top:700px; margin-left:500px;margin-right:0px;left:800px;" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxBot5_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot6" Width="30px" style="position:absolute; top:700px; margin-left:710px;margin-right:0px;left:800px;" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxBot6_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot7" Width="200px" style="position:absolute; top:800px; margin-left:500px;margin-right:0px;left:800px;" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxBot7_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot8" Width="600px" style="position:absolute; top:850px; margin-left:300px;margin-right:0px;left:800px;" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxBot8_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot9" Width="600px" style="position:absolute; top:1100px; margin-left:300px;margin-right:0px;left:800px;" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxBot9_TextChanged"></asp:TextBox>
            </div>
            
        </div>

      <div id="SaveButtons" runat="server" >
        <asp:Button ID="ButtonCreateMainList" style="position:absolute; top:880px; margin-left:600px;margin-right:0px;" runat="server" Text="Сохранить титульник" OnClick="ButtonCreateMainList_Click" />
      </div>

        <div id="TextStyle" style="visibility:hidden" runat="server">
            <asp:Label ID="Textsettings" runat="server" style="position:absolute; top:300px; margin-left:50px;margin-right:0px;"  Text="Настройка стиля текста"></asp:Label>

            <asp:Label ID="LabelName" style="position:absolute; top:350px; left:250px" runat="server" Text="Имя"></asp:Label>
            <asp:TextBox ID="TextBoxName" Width="250px" style="position:absolute; top:350px; left:320px" runat="server"></asp:TextBox>

            <asp:Label ID="LabelStyle"  style="position:absolute; top:400px; left:200px" runat="server" Text="Шрифт"></asp:Label>
                <asp:DropDownList ID="TextFontList" Width="300px" runat="server" style="position:absolute; top: 400px; left: 270px;" OnSelectedIndexChanged="DropDownListForElements_SelectedIndexChanged">
                    <asp:ListItem Value="Times New Roman">Times New Roman</asp:ListItem>
                    <asp:ListItem Value="Courier New">Courier New</asp:ListItem>
                    <asp:ListItem Value="Calibri">Calibri</asp:ListItem>
                    <asp:ListItem Value="Comic Sans MS">Comic Sans</asp:ListItem>
                </asp:DropDownList>

            <asp:Label ID="LabelSize" style="position:absolute; top:350px; left:600px" runat="server" Text="Размер"></asp:Label>
            <asp:TextBox ID="TextBoxSize" Width="250px" style="position:absolute; top:400px; left:600px" TextMode="Number" runat="server"></asp:TextBox>

            <asp:Label ID="LabelRight" style="position:absolute; top:500px; left:250px" runat="server" Text="Справа"></asp:Label>
            <asp:TextBox ID="TextBoxRight" Width="50px" style="position:absolute; top:550px; left:330px" TextMode="Number" runat="server"></asp:TextBox>

            <asp:Label ID="LabelLeft" style="position:absolute; top:550px; left:250px" runat="server" Text="Слева"></asp:Label>
            <asp:TextBox ID="TextBoxLeft" Width="50px" style="position:absolute; top:500px; left:330px" TextMode="Number" runat="server"></asp:TextBox>

            <asp:Label ID="LabelSpace" style="position:absolute; top:470px; left:170px" runat="server" TextMode="Number" Text="Отступ"></asp:Label>

            <asp:Label ID="LabeL1stString" style="position:absolute; top:500px; left:600px" runat="server" Text="Первая строка"></asp:Label>
            <asp:TextBox ID="TextBox1stString" Width="100px" style="position:absolute; top:550px; left:600px" TextMode="Number" runat="server"></asp:TextBox>

            <asp:Label ID="LabeLOn" style="position:absolute; top:500px; left:820px" runat="server" Text="На"></asp:Label>
            <asp:TextBox ID="TextBoxOn" Width="50px" style="position:absolute; top:550px; left:820px" TextMode="Number" runat="server"></asp:TextBox>

            <asp:Label ID="LabelInterval" style="position:absolute; top:650px; left:170px" runat="server" TextMode="Number" Text="Интервал"></asp:Label>

            <asp:Label ID="LabelBefore" style="position:absolute; top:750px; left:250px" runat="server" Text="До"></asp:Label>
            <asp:TextBox ID="TextBoxBefore" Width="50px" style="position:absolute; top:750px; left:330px" TextMode="Number" runat="server"></asp:TextBox>

            <asp:Label ID="LabelAfter" style="position:absolute; top:700px; left:250px" runat="server" Text="После"></asp:Label>
            <asp:TextBox ID="TextBoxAfter" Width="50px" style="position:absolute; top:700px; left:330px" TextMode="Number" runat="server"></asp:TextBox>

            <asp:Label ID="LabeLInterline" style="position:absolute; top:700px; left:600px" runat="server" Text="Междустрочный"></asp:Label>
            <asp:TextBox ID="TextBoxInterline" Width="100px" style="position:absolute; top:750px; left:600px" TextMode="Number" runat="server"></asp:TextBox>

            <asp:Label ID="LabeLValue" style="position:absolute; top:700px; left:820px" runat="server" Text="Значение"></asp:Label>
            <asp:TextBox ID="TextBoxValue" Width="50px" style="position:absolute; top:750px; left:820px" TextMode="Number" runat="server"></asp:TextBox>
            </div>

             <div id="Liststyle" runat="server" style="visibility:hidden">
                <asp:Label ID="SSettings_Label" style="position:absolute; top:300px; margin-left:50px;margin-right:0px;" runat="server">Настройка стиля списка</asp:Label>

                <asp:Label ID="TextBoxSName_Label" style="position:absolute; top:350px; margin-left:80px;margin-right:0px;" runat="server">Название:</asp:Label>
                <asp:TextBox ID="TextBoxSName" Width="300px" style="position:absolute; top:350px; margin-left:200px;margin-right:0px;" runat="server"></asp:TextBox>

                <asp:Label ID="TStyle_Label" style="position:absolute; top:400px; margin-left:80px;margin-right:0px;" runat="server">Шрифт:</asp:Label>
                <asp:DropDownList ID="TStyle_List" Width="300px" runat="server" style="position:absolute; top: 400px; left: 200px;" OnSelectedIndexChanged="DropDownListForElements_SelectedIndexChanged">
                    <asp:ListItem Value="Times New Roman">Times New Roman</asp:ListItem>
                    <asp:ListItem Value="Courier New">Courier New</asp:ListItem>
                    <asp:ListItem Value="Calibri">Calibri</asp:ListItem>
                    <asp:ListItem Value="Comic Sans MS">Comic Sans</asp:ListItem>
                </asp:DropDownList>

                <asp:Label ID="TextBoxTSize_Label" style="position:absolute; top:400px; margin-left:550px;margin-right:0px;" runat="server">Размер:</asp:Label>
                <asp:TextBox ID="TextBoxTSize" Width="70px" style="position:absolute; top:400px; margin-left:630px;margin-right:0px;" TextMode="Number" runat="server"></asp:TextBox>
            </div>

            <div id="Picstyle" runat="server" style="visibility:hidden">
                <asp:Label ID="PSettings_Label" style="position:absolute; top:300px; margin-left:50px;margin-right:0px;" runat="server">Настройка стиля картинки</asp:Label>

                <asp:Label ID="TextVoxPName_Label" style="position:absolute; top:350px; margin-left:80px;margin-right:0px;" runat="server">Название:</asp:Label>
                <asp:TextBox ID="TextBoxPName" Width="300px" style="position:absolute; top:350px; margin-left:200px;margin-right:0px;" runat="server"></asp:TextBox>

                <asp:Label ID="TextBoxPTitle_Label" style="position:absolute; top:400px; margin-left:80px;margin-right:0px;" runat="server">Имя:</asp:Label>
                <asp:TextBox ID="TextBoxPTitle" Width="300px" style="position:absolute; top:400px; margin-left:200px;margin-right:0px;" runat="server"></asp:TextBox>

                <asp:Label ID="PAlign_Label" style="position:absolute; top:450px; margin-left:80px;margin-right:0px;" runat="server">Выравнивание:</asp:Label>
                <asp:DropDownList ID="PAlign_List" Width="300px" runat="server" style="position:absolute; top: 450px; left: 208px;" OnSelectedIndexChanged="DropDownListForElements_SelectedIndexChanged">
                    <asp:ListItem Value="left">Левый край</asp:ListItem>
                    <asp:ListItem Value="center">Центр</asp:ListItem>
                    <asp:ListItem Value="right">Правый край</asp:ListItem>
                    <asp:ListItem Value="just">По ширине</asp:ListItem>
                </asp:DropDownList>
            </div>

        <div id="TableStyle" style="visibility:hidden" runat="server">
            <asp:Label ID="TableSettings" runat="server" style="position:absolute; top:300px; margin-left:50px;margin-right:0px;"  Text="Настройка стиля таблицы"></asp:Label>

            <asp:Label ID="TableStyleName" style="position:absolute; top:350px; margin-left:80px;margin-right:0px;" runat="server">Название:</asp:Label>
            <asp:TextBox ID="TableStyleNameBox" Width="300px" style="position:absolute; top:350px; margin-left:170px;margin-right:0px;" runat="server"></asp:TextBox>

            <asp:Label ID="LabelTableFontSize" style="position:absolute; top:350px; left:600px" runat="server" Text="Размер шрифта"></asp:Label>
            <asp:TextBox ID="TextBoxTableFontSize" Width="50px" style="position:absolute; top:400px; left:600px" TextMode="Number" runat="server"></asp:TextBox>

            <asp:Label ID="LabelTableFont" style="position:absolute; top:400px; margin-left:80px;margin-right:0px;" runat="server">Шрифт:</asp:Label>
                <asp:DropDownList ID="TableFontList" Width="300px" runat="server" style="position:absolute; top: 400px; left: 170px;" OnSelectedIndexChanged="DropDownListForElements_SelectedIndexChanged">
                    <asp:ListItem Value="Times New Roman">Times New Roman</asp:ListItem>
                    <asp:ListItem Value="Courier New">Courier New</asp:ListItem>
                    <asp:ListItem Value="Calibri">Calibri</asp:ListItem>
                    <asp:ListItem Value="Comic Sans MS">Comic Sans</asp:ListItem>
                </asp:DropDownList>

                <asp:Label ID="LabelTableAlign" style="position:absolute; top:450px; margin-left:80px;margin-right:0px;" runat="server">Выравнивание таблицы:</asp:Label>
                <asp:DropDownList ID="TableAlignList" Width="300px" runat="server" style="position:absolute; top: 450px; left: 270px;" OnSelectedIndexChanged="DropDownListForElements_SelectedIndexChanged">
                    <asp:ListItem Value="left">Левый край</asp:ListItem>
                    <asp:ListItem Value="center">Центр</asp:ListItem>
                    <asp:ListItem Value="right">Правый край</asp:ListItem>
                    <asp:ListItem Value="just">По ширине</asp:ListItem>
                </asp:DropDownList>

             <asp:Label ID="LabelCellAlign" style="position:absolute; top:500px; margin-left:80px;margin-right:0px;" runat="server">Выравнивание ячейки:</asp:Label>
             <asp:DropDownList ID="CellAlignList" Width="300px" runat="server" style="position:absolute; top: 500px; left: 270px;" OnSelectedIndexChanged="DropDownListForElements_SelectedIndexChanged">
                    <asp:ListItem Value="left">Левый край</asp:ListItem>
                    <asp:ListItem Value="center">Центр</asp:ListItem>
                    <asp:ListItem Value="right">Правый край</asp:ListItem>
                    <asp:ListItem Value="just">По ширине</asp:ListItem>
                </asp:DropDownList>

        </div>

                <div id="MainButtons" runat="server" >

            <asp:Button ID="ButtonSaveStyle" style="position:absolute; top:800px; left:600px" runat="server" Text="Сохранить" OnClick="ButtonSaveStyle_Click" />
            
            <asp:Button ID="ButtonGoBack" style="position:absolute; top:800px; left:800px" runat="server" Text="Отмена" OnClick="ButtonGoBack_Click" />

               </div>
                
        <div id="sql" runat="server">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [USERS]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [TEXT]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [TABLE]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [LIST]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [IMAGE]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [StyleList]"></asp:SqlDataSource>
        </div>



         </form>

</body>
</html>
