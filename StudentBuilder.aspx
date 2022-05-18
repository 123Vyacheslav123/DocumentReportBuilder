<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentBuilder.aspx.cs" Inherits="DocumentReportBuilder.StudentBuilder" %>

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
              <li class="CL1"><a class="CL1a" href="/Main.aspx">Главная</a></li>
              <li class="CL2"><a class="CL2a" href="/Tasks.aspx">Задания</a></li>
              <li class="CL3"><a class="CL3a" href="#">Отправленные</a></li>
              <li class="CL4"><a class="CL4a" href="#">Сохранённые</a></li>
           
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
        
        <ul class="Buttons">
            <p>Сохранённые стили</p>

            <li id="SavedStyles" runat="server">
                 
                <%--Динамическое заполнение--%>

                <%--<asp:Button ID="Button2" runat="server" Height="22px" style="margin-left: 0px; margin-bottom: 20px" Text="Таблица" Width="152px"/>
                <asp:Button ID="Button3" runat="server" Height="22px" style="margin-left: 0px; margin-bottom: 20px" Text="Стиль текста" Width="152px" />
                <asp:Button ID="Button4" runat="server" Height="22px" style="margin-left: 0px; margin-bottom: 20px" Text="Изображение" Width="152px" />--%>

            </li>
           
            </ul>


        <div id="Based" style="visibility:visible" runat="server">

            <asp:Button ID="ButtonCreateFile" runat="server" Height="40px" Width="200px" style="position:absolute; top: 800px; left: 520px;" Text="Создать документ" OnClick="ButtonCreateFile_Click" />

            <asp:SqlDataSource ID="SqlDataSource8" runat="server"></asp:SqlDataSource>

        </div>

        <div id ="TextAndList" style="visibility:hidden" runat="server">

            <asp:TextBox ID="TextBoxEditing" runat="server" Height="300px" Width="500px" AcceptsTab="True" TextAlign="Distribute" Wrap="true" style="position:absolute; top:270px; left: 400px;" TextMode="MultiLine" OnTextChanged="TextBoxEditing_TextChanged1"></asp:TextBox> <%-- Вспомогательный ТекстБокс --%>
            <asp:Button ID="ButtonAddToMain" Height="40px" Width="200px" runat="server" style="position:absolute; top:600px; left: 700px;" OnClick="ButtonAddToMain_Click" Text="Добавить Текст" />

        </div>

        <div id="List" style="visibility:hidden" runat="server">

            <asp:Button ID="ButtonAddList" runat="server" Height="40px" Width="200px" style="position:absolute; top:600px; left: 400px;" OnClick="ButtonAddList_Click" Text="Следующий пункт" />

        </div>

        <div id="Images" style="visibility:hidden" runat="server">
         
            <asp:Button ID="ButtonAddImage" runat="server" Height="40px" Width="200px" style="position:absolute; top: 550px; left: 450px;" OnClick="ButtonAddImage_Click" Text="Добавить фото" />
            <asp:FileUpload ID="FileUpload" style="position:absolute;top:500px; left: 600px;" runat="server" /><br/>
            <asp:Button ID="ButtonUploadImg" runat="server" style="position:absolute;top:500px; left: 450px;" Text="Загрузить фото" OnClick="UploadFile" /><br/>
            <asp:Image ID="Image1" style="position:absolute;top:250px; left: 350px; width:400px; height:250px" runat="server" />
            
        </div>

        <div id="Title" style="visibility:hidden" runat="server">

             <asp:Button ID="ButtonAddTtitle" runat="server" Height="40px" Width="200px" style="position:absolute;top:800px; left: 720px;" OnClick="ButtonAddTitle_Click" Text="Добавить титульник" />

        </div>
       
      <div id="TitleBoxes" runat ="server" style="visibility:hidden">

        <div id="TopBoxes" runat="server">
        <asp:TextBox ID="TextBoxTop1" Width="600px" ReadOnly="true" CssClass="AllBoxes" style="position:absolute; top:150px; left:20%" runat="server" OnTextChanged="TextBoxTop1_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBoxTop2" Width="600px" ReadOnly="true" CssClass="AllBoxes" style="position:absolute; top:190px; left:20%" runat="server" OnTextChanged="TextBoxTop2_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBoxTop3" Width="600px" ReadOnly="true" CssClass="AllBoxes" style="position:absolute; top:240px; left:20%" runat="server" OnTextChanged="TextBoxTop3_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBoxTop4" Width="600px" ReadOnly="true" CssClass="AllBoxes" style="position:absolute; top:270px; left:20%" runat="server" OnTextChanged="TextBoxTop4_TextChanged"></asp:TextBox>
            </div>

            <div id="LeftBoxes" runat="server">
                <asp:TextBox ID="TextBoxLeft1" Width="200px" ReadOnly="true" CssClass="AllBoxes" style="position:absolute; top:310px; left:20%" runat="server" OnTextChanged="TextBoxLeft1_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxLeft2" Width="200px" CssClass="AllBoxes" style="position:absolute; left:20%" runat="server" OnTextChanged="TextBoxLeft3_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxLeft3" Width="200px" CssClass="AllBoxes" style="position:absolute; top:390px; left:20%" runat="server" OnTextChanged="TextBoxLeft3_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxLeft4" Width="200px" CssClass="AllBoxes" style="position:absolute; top:430px; left:20%" runat="server" OnTextChanged="TextBoxLeft4_TextChanged"></asp:TextBox>
            </div>


            <div id="RightBoxes" runat="server">
                <asp:TextBox ID="TextBoxRight1" Width="200px" CssClass="AllBoxes" ReadOnly="true" style="position:absolute; top:310px;left:45%" runat="server" OnTextChanged="TextBoxRight1_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxRight2" Width="200px" CssClass="AllBoxes" style="position:absolute; top:350px; left:45%" runat="server" OnTextChanged="TextBoxRight2_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxRight3" Width="200px" CssClass="AllBoxes" style="position:absolute; top:390px; left:45%" runat="server" OnTextChanged="TextBoxRight3_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxRight4" Width="200px" CssClass="AllBoxes" style="position:absolute; top:430px; left:45%" runat="server" OnTextChanged="TextBoxRight4_TextChanged"></asp:TextBox>

            </div>


            <div id="BotBoxes" runat="server">
                <asp:TextBox ID="TextBoxBot1" Width="400px" CssClass="AllBoxes" ReadOnly="true" style="position:absolute; top:470px; left:25%" runat="server" OnTextChanged="TextBoxBot1_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot2" Width="30px" CssClass="AllBoxes" style="position:absolute; top:470px; left:50%" runat="server" OnTextChanged="TextBoxBot2_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot3" Width="150px" CssClass="AllBoxes" ReadOnly="true" style="position:absolute; top:510px; left:35%" runat="server" OnTextChanged="TextBoxBot3_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot4" Width="400px" CssClass="AllBoxes" style="position:absolute; top:550px; left:27%" runat="server" OnTextChanged="TextBoxBot4_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot5" Width="150px" CssClass="AllBoxes" ReadOnly="true" style="position:absolute; top:590px; left:32%" runat="server" OnTextChanged="TextBoxBot5_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot6" Width="30px" CssClass="AllBoxes" style="position:absolute; top:590px; left:42%" runat="server" OnTextChanged="TextBoxBot6_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot7" Width="150px" CssClass="AllBoxes" ReadOnly="true" style="position:absolute; top:630px; left:35%" runat="server" OnTextChanged="TextBoxBot7_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot8" Width="400px" CssClass="AllBoxes" style="position:absolute; top:670px; left:28%" runat="server" OnTextChanged="TextBoxBot8_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot9" Width="400px" CssClass="AllBoxes" ReadOnly="true" style="position:absolute; top:710px; left:28%" runat="server" OnTextChanged="TextBoxBot9_TextChanged"></asp:TextBox>
            </div>

          </div>

        <div id ="Tables" style="visibility:hidden"  runat="server" >   <%--Кнопки для таблиц --%>

                <asp:Panel ID="pnlTextBoxes" style="position:absolute" runat="server"> </asp:Panel>
            <p>
                <asp:Label ID="LabelColumn" style="position:absolute; bottom:600px; left:400px" runat="server" Text="Столбцы"></asp:Label>
                <asp:TextBox ID="TextBoxColumn" style="position:absolute; left:500px; bottom:600px;" runat="server" Height="16px" TextMode="Number" Width="66px"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="LabelRows" style="position:absolute; bottom:550px; left:400px" runat="server" Text="Строки"></asp:Label>
                <asp:TextBox ID="TextBoxRows" style="position:absolute; left:500px; bottom:550px" runat="server" TextMode="Number" Width="65px"></asp:TextBox>
            </p>
                <asp:Button ID="ButtonTableCreate" style="position:absolute; bottom:500px; left:400px" runat="server" OnClick="ButtonTableCreate_Click" Text="Выбрать" />
                <asp:Button ID="ButtonToWord" style="position:absolute;left:520px; bottom:500px" runat="server" OnClick="ButtonToWord_Click" Text="Добавить" />

        </div>

        <div id="sql" runat="server">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [USERS]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [TEXT]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [TABLE]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [LIST]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [IMAGE]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [CONFIGURATION]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [ReportUsers]"></asp:SqlDataSource>     
        </div>

          <%--вывод предпросмотра документа:--%>
    <div id="preview" style="position:absolute;top:100px; left:1000px; width:620px; height:800px;">
        <iframe id="showPDF" runat="server" width="620" height="800"></iframe>
    </div>


    </form>

           
</body>
</html>
