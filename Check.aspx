<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Check.aspx.cs" Inherits="DocumentReportBuilder.Check" %>
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

        .SAVE_Buttons {
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
        .SAVE_Buttons:hover{
            background-color: cornflowerblue;
        }

        .LIST_Buttons {
            margin-bottom:10px;
            padding-top: 5px;
            padding-bottom: 5px;
            padding-left: 10px;
            padding-right: 10px;
            border: none;
            border-radius: 10px;
             font-size: 14px; /*меняем размер шрифта*/
            font-weight: bold;
            transition: all 0.3s 0.01s ease; /*делаем плавный переход*/
        }
        .LIST_Buttons:hover{
            background-color: cornflowerblue;
        }


        .ZAD_TIT {
            position: absolute;
            left: 20%;
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
    width: 12%;
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
              <li class="CL3"><a class="CL3a" href="/Configurations.aspx">Сохранённые конфигурации</a></li>
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
        
        <ul class="Buttons" >
            <p>Сохранённые стили</p>

            <li id="SavedStyles" runat="server">
                 
                <%--<%--<%--Динамическое заполнение--%>

                <%--<asp:Button ID="Button2" runat="server" Height="22px" style="margin-left: 0px; margin-bottom: 20px" Text="Таблица" Width="152px"/>
                <asp:Button ID="Button3" runat="server" Height="22px" style="margin-left: 0px; margin-bottom: 20px" Text="Стиль текста" Width="152px" />
                <asp:Button ID="Button4" runat="server" Height="22px" style="margin-left: 0px; margin-bottom: 20px" Text="Изображение" Width="152px" />--%>

            </li>
           
            </ul>

    <div id="Title" runat="server">
        
            <div id="TopBoxes" style="visibility:hidden" runat="server">
        <asp:TextBox ID="TextBoxTop1" Width="25%" style="position:absolute; top:13%; left:60%; border:2px solid black" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxTop1_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBoxTop2" Width="25%" style="position:absolute; top:18%; left:60%; border:2px solid black" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxTop2_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBoxTop3" Width="25%" style="position:absolute; top:23%; left:60%; border:2px solid black" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxTop3_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBoxTop4" Width="25%" style="position:absolute; top:28%; left:60%; border:2px solid black" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxTop4_TextChanged"></asp:TextBox>
            </div>

           <div id="LeftBoxes" style="visibility:hidden" runat="server">
                <asp:TextBox ID="TextBoxLeft1" Width="17%" style="position:absolute; top:35%; left:48%; border:2px solid black" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxLeft1_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxLeft2" Width="17%" style="position:absolute; top:40%; left:48%; border:2px solid black" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxLeft2_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxLeft3" Width="17%" style="position:absolute; top:45%; left:48%; border:2px solid black" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxLeft3_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxLeft4" Width="17%" style="position:absolute; top:50%; left:48%; border:2px solid black" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxLeft4_TextChanged"></asp:TextBox>
            </div>

            <div id="RightBoxes" style="visibility:hidden" runat="server">
                <asp:TextBox ID="TextBoxRight1" Width="17%" style="position:absolute; top:35%; left:77%; border:2px solid black" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxRight1_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxRight2" Width="17%" style="position:absolute; top:40%; left:77%; border:2px solid black" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxRight2_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxRight3" Width="17%" style="position:absolute; top:45%; left:77%; border:2px solid black" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxRight3_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxRight4" Width="17%" style="position:absolute; top:50%; left:77%; border:2px solid black" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxRight4_TextChanged"></asp:TextBox>
            </div>


           <div id="BotBoxes" style="visibility:hidden" runat="server">
                <asp:TextBox ID="TextBoxBot1" Width="25%" style="position:absolute; top:55%; left:55%; border:2px solid black" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxBot1_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot2" Width="2%" style="position:absolute; top:55%; left:82%; border:2px solid black" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxBot2_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot3" Width="10%" style="position:absolute; top:60%; left:68%; border:2px solid black" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxBot3_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot4" Width="25%" style="position:absolute; top:65%; left:60%; border:2px solid black" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxBot4_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot5" Width="10%" style="position:absolute; top:70%;  left:65%; border:2px solid black" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxBot5_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot6" Width="2%" style="position:absolute; top:70%; left:76%; border:2px solid black" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxBot6_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot7" Width="10%" style="position:absolute; top:75%; left:68%; border:2px solid black" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxBot7_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot8" Width="25%" style="position:absolute; top:80%; left:60%; border:2px solid black" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxBot8_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot9" Width="15%" style="position:absolute; top:85%;  left:65%; border:2px solid black" CssClass="AllBoxes" runat="server" OnTextChanged="TextBoxBot9_TextChanged"></asp:TextBox>
            </div>
            
        </div>

        <div id="TextStyle" style="visibility:hidden;" runat="server">

            <asp:Label ID="Textsettings" runat="server" style="position:absolute; top:29%; left:17%" Width="15%" Font-Size="18px"  Text="Настройка стиля текста"></asp:Label>

            <asp:Label ID="LabelName" style="position:absolute; top:33%; left:17%" runat="server" Text="Название:"></asp:Label>
            <asp:TextBox ID="TextBoxName" Width="10%" style="position:absolute; top:33%; left:22%" runat="server"></asp:TextBox>

             <asp:Label ID="LabelSize" style="position:absolute; top:38%; left:32%" runat="server" Text="Размер шрифта:"></asp:Label>
            <asp:TextBox ID="TextBoxSize" Width="50px" style="position:absolute; top:38%; left:39%" TextMode="Number" runat="server">12</asp:TextBox>

            <asp:Label ID="LabelStyle"  style="position:absolute; top:38%; left:17%" runat="server" Text="Шрифт:"></asp:Label>
                <asp:DropDownList ID="TextFontList" Width="10%" runat="server" style="position:absolute; top: 38%; left: 21%" OnSelectedIndexChanged="DropDownListForElements_SelectedIndexChanged">
                    <asp:ListItem Value="Times New Roman">Times New Roman</asp:ListItem>
                    <asp:ListItem Value="Courier New">Courier New</asp:ListItem>
                    <asp:ListItem Value="Calibri">Calibri</asp:ListItem>
                    <asp:ListItem Value="Comic Sans MS">Comic Sans</asp:ListItem>
                </asp:DropDownList>

            <asp:Label ID="LabelTextAlign" style="position:absolute; top:43%;left:17%" runat="server">Выравнивание:</asp:Label>
                <asp:DropDownList ID="DropDownTextAlign" Width="10%" runat="server" style="position:absolute; top: 46%; left: 17%" OnSelectedIndexChanged="DropDownListForElements_SelectedIndexChanged">
                    <asp:ListItem Value="left">Левый край</asp:ListItem>
                    <asp:ListItem Value="center">Центр</asp:ListItem>
                    <asp:ListItem Value="right">Правый край</asp:ListItem>
                    <asp:ListItem Value="both">По ширине</asp:ListItem>
                </asp:DropDownList>

             <asp:Label ID="LabelIndent" style="position:absolute; top:50%; left:17%" runat="server" Text="Отступы:"></asp:Label>

            <asp:Label ID="LabelBefore" style="position:absolute; top:55%; left:17%" runat="server" Text="До:"></asp:Label>
            <asp:TextBox ID="TextBoxBefore" Width="50px" style="position:absolute; top:55%; left:350px" TextMode="Number" runat="server">0</asp:TextBox>

            <asp:Label ID="LabelAfter" style="position:absolute; top:60%; left:17%" runat="server" Text="После:"></asp:Label>
            <asp:TextBox ID="TextBoxAfter" Width="50px" style="position:absolute; top:60%; left:350px" TextMode="Number" runat="server">0</asp:TextBox>

            </div>

             <div id="Liststyle" runat="server" style="visibility:hidden;">

                <asp:Label ID="SSettings_Label" style="position:absolute; top:29%; left:17%" Width="15%" Font-Size="18px" runat="server">Настройка стиля списка</asp:Label>

                <asp:Label ID="TextBoxSName_Label" style="position:absolute; top:33%; left:17%" runat="server">Название:</asp:Label>
                <asp:TextBox ID="TextBoxSName" Width="10%" style="position:absolute; top:33%; left:22%" runat="server"></asp:TextBox>

                <asp:Label ID="TStyle_Label" style="position:absolute; top:38%; left:17%" runat="server">Шрифт:</asp:Label>
                <asp:DropDownList ID="TStyle_List" Width="10%" runat="server" style="position:absolute;top: 38%; left: 21%" OnSelectedIndexChanged="DropDownListForElements_SelectedIndexChanged">
                    <asp:ListItem Value="Times New Roman">Times New Roman</asp:ListItem>
                    <asp:ListItem Value="Courier New">Courier New</asp:ListItem>
                    <asp:ListItem Value="Calibri">Calibri</asp:ListItem>
                    <asp:ListItem Value="Comic Sans MS">Comic Sans</asp:ListItem>
                </asp:DropDownList>

                <asp:Label ID="TextBoxTSize_Label" style="position:absolute; top:43%; left:17%" runat="server">Размер:</asp:Label>
                <asp:TextBox ID="TextBoxTSize" Width="70px" style="position:absolute; top:43%; left:21%" TextMode="Number" runat="server">12</asp:TextBox>
            </div>

            <div id="Picstyle" runat="server" style="visibility:hidden">

                <asp:Label ID="PSettings_Label" style="position:absolute; top:29%; left:17%" Width="15%" Font-Size="18px" runat="server">Настройка стиля картинки</asp:Label>

                <asp:Label ID="TextVoxPName_Label" style="position:absolute; top:33%; left:17%" runat="server">Название:</asp:Label>
                <asp:TextBox ID="TextBoxPName" Width="10%" style="position:absolute; top:33%; left:22%" runat="server"></asp:TextBox>

                <asp:Label ID="TextBoxPTitle_Label" style="position:absolute; top:38%; left:17%" runat="server">Имя:</asp:Label>
                <asp:TextBox ID="TextBoxPTitle" Width="10%" style="position:absolute; top:38%; left:21%" runat="server"></asp:TextBox>

                <asp:Label ID="PAlign_Label" style="position:absolute; top:43%; left:17%" runat="server">Выравнивание:</asp:Label>
                <asp:DropDownList ID="PAlign_List" Width="10%" runat="server" style="position:absolute; top:43%; left:24%" OnSelectedIndexChanged="DropDownListForElements_SelectedIndexChanged">
                    <asp:ListItem Value="left">Левый край</asp:ListItem>
                    <asp:ListItem Value="center">Центр</asp:ListItem>
                    <asp:ListItem Value="right">Правый край</asp:ListItem>
                    <asp:ListItem Value="both">По ширине</asp:ListItem>
                </asp:DropDownList>
            </div>

        <div id="TableStyle" style="visibility:hidden" runat="server">
            <asp:Label ID="TableSettings" runat="server" style="position:absolute; top:29%; left:17%" Width="15%" Font-Size="18px"  Text="Настройка стиля таблицы"></asp:Label>

            <asp:Label ID="TableStyleName" style="position:absolute; top:33%; left:17%" runat="server">Название:</asp:Label>
            <asp:TextBox ID="TableStyleNameBox" Width="10%" style="position:absolute;top:33%; left:22%" runat="server"></asp:TextBox>

            <asp:Label ID="LabelTableFontSize" style="position:absolute; top:38%; left:32%" runat="server" Text="Размер шрифта:"></asp:Label>
            <asp:TextBox ID="TextBoxTableFontSize" Width="3%" style="position:absolute; top:38%; left:39%" TextMode="Number" runat="server">12</asp:TextBox>

            <asp:Label ID="LabelTableFont" style="position:absolute; top:38%; left:17%" runat="server">Шрифт:</asp:Label>
                <asp:DropDownList ID="TableFontList" Width="10%" runat="server" style="position:absolute; top: 38%; left: 21%" OnSelectedIndexChanged="DropDownListForElements_SelectedIndexChanged">
                    <asp:ListItem Value="Times New Roman">Times New Roman</asp:ListItem>
                    <asp:ListItem Value="Courier New">Courier New</asp:ListItem>
                    <asp:ListItem Value="Calibri">Calibri</asp:ListItem>
                    <asp:ListItem Value="Comic Sans MS">Comic Sans</asp:ListItem>
                </asp:DropDownList>

                <asp:Label ID="LabelTableAlign" style="position:absolute; top:43%;left:17%" runat="server">Выравнивание таблицы:</asp:Label>
                <asp:DropDownList ID="TableAlignList" Width="10%" runat="server" style="position:absolute; top: 46%; left: 17%" OnSelectedIndexChanged="DropDownListForElements_SelectedIndexChanged">
                    <asp:ListItem Value="left">Левый край</asp:ListItem>
                    <asp:ListItem Value="center">Центр</asp:ListItem>
                    <asp:ListItem Value="right">Правый край</asp:ListItem>
                    <asp:ListItem Value="both">По ширине</asp:ListItem>
                </asp:DropDownList>

             <asp:Label ID="LabelCellAlign" style="position:absolute;top:51%;left:17%" runat="server">Выравнивание ячейки:</asp:Label>
             <asp:DropDownList ID="CellAlignList" Width="10%" runat="server" style="position:absolute; top: 54%; left: 17%" OnSelectedIndexChanged="DropDownListForElements_SelectedIndexChanged">
                    <asp:ListItem Value="top">Верх</asp:ListItem>
                    <asp:ListItem Value="center">Центр</asp:ListItem>
                    <asp:ListItem Value="bottom">Низ</asp:ListItem>
                </asp:DropDownList>

        </div>

                <div id="MainButtons" runat="server" >

            <asp:Button ID="ButtonGoBack" CssClass="SAVE_Buttons" style="position:absolute; top:75%; left:37%" runat="server" Text="Отмена" OnClick="ButtonGoBack_Click" />

               </div>

        <div id="rectangleStyles" runat="server" style="position:absolute; background:white; z-index:-1; left:16%; top:27%; width:28%; height:40%; " ></div>

         <div id="rectangleBoxes" runat="server" style="position:absolute; background:white; z-index:-1; left:47%; top:12%; width:48%; height:76%; " ></div>



                
        <div id="sql" runat="server">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [USERS]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [TEXT]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [TABLE]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [LIST]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [IMAGE]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [CONFIGURATION]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [ReportUsers]"></asp:SqlDataSource>     
        </div>

         </form>

</body>
</html>
