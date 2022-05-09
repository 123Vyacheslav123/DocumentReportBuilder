<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reg.aspx.cs" Inherits="DocumentReportBuilder.Reg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Styles/Registration/Menu.css" rel="stylesheet" />
    <link href="Styles/Registration/MAIN.css" rel="stylesheet" />
    <title></title>
    <script type="text/javascript">
		<!--//--><![CDATA[//><!--
    var images = new Array()
    function preload() {
        for (i = 0; i < preload.arguments.length; i++) {
            images[i] = new Image()
            images[i].src = preload.arguments[i]
        }
    }
    preload(
        "images/2.png",
        "images/3.png",
        "images/4.png"
    )
		//--><!]]>
</script>

    <script>
        function changeItem() {
            document.getElementById('FIRST').style.visibility = "visible"; // show
            document.getElementById('SECOND').style.visibility = "hidden"; // show
            document.getElementById('THIRD').style.visibility = "hidden"; // show  
            document.body.style.backgroundImage = "url('images/2.png')";
        };
        function changeItem_2() {
            document.getElementById('SECOND').style.visibility = "visible"; // show
            document.getElementById('FIRST').style.visibility = "hidden"; // show
            document.getElementById('THIRD').style.visibility = "hidden"; // show
            document.body.style.backgroundImage = "url('images/3.png')";
        };
        function changeItem_3() {
            document.getElementById('SECOND').style.visibility = "hidden"; // show
            document.getElementById('FIRST').style.visibility = "hidden"; // show
            document.getElementById('THIRD').style.visibility = "visible"; // show
            document.body.style.backgroundImage = "url('images/4.png')";
        };
       
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <style>
            body{
               background-image:url('images/2.png');
               background-repeat:no-repeat;
               height:100vh;
               background-size:cover;
            }

        </style>

        <nav>
  <ul class="topmenu">
    <li><a class="down">Авторизация</a>
      <ul class="submenu">
        <li><a class="" id="One" onclick="changeItem()">Преподаватель</a></li>
        <li><a class="" id="Two" onclick="changeItem_2()">Студент</a></li>
        <li><a class="" id="Third" onclick="changeItem_3()">Регистрация</a></li>
      
      </ul>
    </li>
  </ul>
</nav>

        <%--Авторизация преподавателя--%>

        <div class="First" id="FIRST" style="position:absolute; display: flex; flex-direction: column; left: 40%; top: 25%; background-color: lightgray; width: 250px; height: 400px; visibility: hidden; border-radius: 10px;">
          <p class="Text_1" style="position:relative; left:0; margin-bottom: 5px; background-color: #387ebf; color: white; padding-left: 5px;">Авторизация</p>
          <p class="Text_2" style="position:relative; left: 10px; margin-bottom: 20px;">Преподаватель</p>

        <asp:Label ID="LabelMailTeacherAutho" CssClass="RE1" runat="server" Text="Почта:" Width="70%"></asp:Label>
       <asp:TextBox ID="TextBoxMailTeacherAutho" CssClass="RE" runat="server" Width="70%"></asp:TextBox>

        <asp:Label ID="LabelPassTeacherAutho" CssClass="RE2" runat="server" Text="Пароль" Width="70%"></asp:Label>
        <asp:TextBox ID="TextBoxPassTeacherAutho" CssClass="RE3" runat="server" Width="70%"></asp:TextBox>

        <asp:Button ID="ButtonTeacherAutho" CssClass="RE4" runat="server" OnClick="ButtonTeacherAutho_Click" Text="Войти" Width="30%" BackColor="#387ebf" />
        <p class="Text_3" style="position:relative; width:80%; left: 10%">Ещё не зарегистрированы?</p>

        <asp:Button ID="ButtonTeacherAuthoReg" CssClass="RE5" Width="40%" runat="server" OnClick="ButtonTeacherAuthoReg_Click" Text="Регистрация" BackColor="#387ebf" />
        <asp:Button ID="Button3TeacherAuthoForgotPass" CssClass="RE6" Width="50%" runat="server" Text="Забыли пароль?" BackColor="#387ebf" />
        </div>
       

        <%--Авторизация студента--%>

        <div class="Second" id="SECOND" style="position:absolute; left: 40%; top: 25%; background-color: lightgray; width: 250px; height: 400px; display:flex; flex-direction:column; visibility:hidden; border-radius: 10px;">
          <p class="Text_1" style="position:relative; left:0; margin-bottom: 5px; background-color: #387ebf; color: white; padding-left: 5px;">Авторизация</p>
          <p class="Text_2" style="position:relative; left: 10px; margin-bottom: 20px;">Студент</p>

        <asp:Label ID="LabelMailStudAutho" CssClass="RE1" runat="server" Text="Почта:" Width="70%"></asp:Label>
       <asp:TextBox ID="TextBoxMailStudAutho" CssClass="RE" runat="server" Width="70%"></asp:TextBox>

        <asp:Label ID="LabelPassStudAutho" CssClass="RE2" runat="server" Text="Пароль:" Width="70%"></asp:Label>
        <asp:TextBox ID="TextBoxPassStudAutho" CssClass="RE3" runat="server" Width="70%"></asp:TextBox>

        <asp:Button ID="ButtonStudAutho" CssClass="RE4" runat="server" OnClick="ButtonStudAutho_Click" Text="Войти" Width="30%" BackColor="#387ebf" />
        <p class="Text_3" style="position:relative; width:80%; left: 10%">Ещё не зарегистрированы?</p>

        <asp:Button ID="ButtonStudAuthoReg" CssClass="RE5" Width="40%" runat="server" Text="Регистрация" BackColor="#387ebf"/>
        <asp:Button ID="ButtonStudAuthoForgotPass" CssClass="RE6" Width="50%" runat="server" Text="Забыли пароль?" BackColor="#387ebf" />
        </div>


        <%--Регистрация--%>

         <div class="Third" id="THIRD" style="position:absolute; left: 40%; top: 25%; background-color: lightgray; width: 250px; height: 450px; display:flex; flex-direction:column; visibility:hidden; border-radius: 10px;">
          <p class="Text_1" style="position:relative; left:0; margin-bottom: 20px; background-color: #387ebf; color: white; padding-left: 5px;">Регистрация</p>
          

        <asp:Label ID="LabelFirstNameReg" CssClass="RE1" runat="server" Text="Имя:" Width="70%"></asp:Label>
       <asp:TextBox ID="TextBoxFirstNameReg" CssClass="RE" runat="server" Width="70%"></asp:TextBox>

        <asp:Label ID="LabelPatronymicReg" CssClass="RE2" runat="server" Text="Отчество:" Width="70%"></asp:Label>
        <asp:TextBox ID="TextBoxPatronymicReg" CssClass="RE3" runat="server" Width="70%"></asp:TextBox>

        <asp:Label ID="LabelLastNameReg" CssClass="RE2" runat="server" Text="Фамилия:" Width="70%"></asp:Label>
        <asp:TextBox ID="TextBoxLastNameReg" CssClass="RE3_1" runat="server" Width="70%"></asp:TextBox>

        <asp:Label ID="LabelMailReg" CssClass="RE2" runat="server" Text="Почта:" Width="70%"></asp:Label>
        <asp:TextBox ID="TextBoxMailReg" CssClass="RE3_1" runat="server" Width="70%"></asp:TextBox>

        <asp:Label ID="LabelPassReg" CssClass="RE2" runat="server" Text="Пароль:" Width="70%"></asp:Label>
        <asp:TextBox ID="TextBoxPassReg" CssClass="RE3_1" runat="server" Width="70%"></asp:TextBox>


        <asp:DropDownList ID="DropDownListReg" runat="server" CssClass="DROP" Width="70%">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem Value="0">Преподаватель</asp:ListItem>
            <asp:ListItem Value="1">Студент</asp:ListItem>
        </asp:DropDownList>

        <asp:Button ID="ButtonRegistration" CssClass="RE4_Welc" runat="server" OnClick="ButtonRegistration_Click" Text="Зарегистрироваться" Width="60%" BackColor="#387ebf" />
</div>

        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [USERS]"></asp:SqlDataSource>

        
    </form>
</body>
</html>
