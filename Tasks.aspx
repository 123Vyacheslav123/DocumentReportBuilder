<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Tasks.aspx.cs" Inherits="DocumentReportBuilder.Tasks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Styles/Main/FIR.css" rel="stylesheet" />
    <link href="Styles/Main/MENU.css" rel="stylesheet" />
    <link href="Styles/Main/CARDS.css" rel="stylesheet" />
     <link href="Styles/TABLES.css" rel="stylesheet" />
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
         
        <style>
            body {
                    background-color: #b0cece;
            }
           #Label1 {
               position: relative;
               font-weight: bold;
               font-size: 18px;
           }
           #Label2, #Label3, #Label4 {
  position: relative;
  margin-bottom: 5px;
  font-weight: bold;
  font-size: 18px;
           }
           #TextBox2, #TextBox3 {
               position: relative;
               margin-bottom: 5px;
           }

           #Button1 {
    position: relative;
    margin: 0;
    text-decoration: none; /*убираем подчеркивание текста ссылок*/
    background-color: cadetblue;
    color: #fff; /*меняем цвет ссылок*/
    padding-top: 10px; /*добавляем отступ*/
    padding-bottom: 10px; /*добавляем отступ*/
    padding-left: 20px; /*добавляем отступ*/
    padding-right: 20px; /*добавляем отступ*/
    font-family: arial; /*меняем шрифт*/
    font-size: 16px; /*меняем размер шрифта*/
    border-style: none;
    border-radius: 20px; /*добавляем скругление*/
    transition: all 0.3s 0.01s ease; /*делаем плавный переход*/
    -moz-transition: all 0.3s 0.01s ease; /*делаем плавный переход*/
    -o-transition: all 0.3s 0.01s ease;
    -webkit-transition: all 0.3s 0.01s ease;
           }
           #Button1:hover {
                background-color: darkcyan;
           }
            .Blok {
                position: absolute;
                text-align: center;
                top: 35%;
                left: 72%;
                width: 200px;
                height: 300px;
            }
            .Blok2 {
                position: absolute;
                text-align: center;
                top: 35%;
                left: 32%;
                width: 350px;
                display: flex;
                flex-direction: column;
            }
           .Blok3 {
               position: absolute; 
               margin-top: 50px;
               margin-left: 4%;
               top: 15%; 
               left: 0px; 
               height: 120px; 
               width: 300px;
               display: flex;
               flex-direction: row;
           }
           .SubBlock3 {
               position: relative;
               display: flex;
               flex-direction: column;
               font-weight: bold;
               font-size: 16px;
               margin-left: 5px;
           }

        </style>
      

            <ul class="FIR">
              <li class="CL1"><a class="CL1a" href="/Main.aspx">Главная</a></li>
              <li class="CL2"><a class="CL2a" href="/Tasks.aspx">Задания</a></li>
              <li class="CL3"><a class="CL3a" href="#">Отправленные</a></li>
              <li class="CL4"><a class="CL4a" href="#">Сохранённые</a></li>
           
  <nav>
<ul class="topmenu" id ="MenuList" runat="server">


    <%--Заменено генерацией в Page_load--%>

    <%--<li><a href="/Profile.aspx" class="down">СОН.Х.М</a>
      <ul class="submenu">
        <li><a href="/Profile.aspx">Профиль</a></li>
        <li><a href="/Reg.aspx">Выход</a></li>
      </ul>
    </li>--%>


  </ul>
      </nav>   
             </ul>

        <div id="Configs" runat="server">

        </div>




        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [USERS]"></asp:SqlDataSource>
       <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [ReportUsers]"></asp:SqlDataSource> 



         <asp:GridView ID="GridViewTableTask" AutoGenerateColumns="false" Width="550px" style="left:35%;top:35%;position:absolute; font-size:20px" CssClass="TABLE1" runat="server">
             <Columns>
                 <asp:BoundField DataField ="ID" HeaderText ="№" ReadOnly="true" />
                 <asp:BoundField DataField ="CONFNAME" HeaderText ="Название" ReadOnly="true" />
                 <asp:BoundField DataField ="ShortUserName" HeaderText ="Кем отправлено" ReadOnly="true" />
                 <asp:BoundField DataField ="Date" HeaderText ="Срок сдачи" ReadOnly="true" />
                 <asp:TemplateField>
                     <ItemTemplate>
                         <asp:Button runat="server" Text="Открыть" OnClick="ButtonOpen_Click" Font-Size="18px" CssClass="BUTTON_STYLE" />
                     </ItemTemplate>
                 </asp:TemplateField>
                     
             </Columns>


         </asp:GridView>
                     


       

      
    </form>
</body>
</html>
