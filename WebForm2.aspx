<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="DocumentReportBuilder.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>


    <form id="form1" runat="server">
            <div runat="server">
        <asp:TextBox ID="TextBoxTop1" Width="600px" style="position:absolute; top:100px; margin-left:500px;margin-right:0px;" runat="server" OnTextChanged="TextBoxTop1_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBoxTop2" Width="600px" style="position:absolute; top:150px; margin-left:500px;margin-right:0px;" runat="server" OnTextChanged="TextBoxTop2_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBoxTop3" Width="600px" style="position:absolute; top:200px; margin-left:500px;margin-right:0px;" runat="server" OnTextChanged="TextBoxTop3_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBoxTop4" Width="600px" style="position:absolute; top:250px; margin-left:500px;margin-right:0px;" runat="server" OnTextChanged="TextBoxTop4_TextChanged"></asp:TextBox>
            </div>

            <div runat="server">
                <asp:TextBox ID="TextBoxLeft1" Width="300px" style="position:absolute; top:350px; margin-left:300px;margin-right:0px;" runat="server" OnTextChanged="TextBoxLeft1_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxLeft2" Width="300px" style="position:absolute; top:400px; margin-left:300px;margin-right:0px;" runat="server" OnTextChanged="TextBoxLeft2_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxLeft3" Width="300px" style="position:absolute; top:450px; margin-left:300px;margin-right:0px;" runat="server" OnTextChanged="TextBoxLeft3_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxLeft4" Width="300px" style="position:absolute; top:500px; margin-left:300px;margin-right:0px;" runat="server" OnTextChanged="TextBoxLeft4_TextChanged"></asp:TextBox>

            </div>

            <div runat="server">
                <asp:TextBox ID="TextBoxRight1" Width="300px" style="position:absolute; top:350px; margin-left:1000px;margin-right:0px;" runat="server" OnTextChanged="TextBoxRight1_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxRight2" Width="300px" style="position:absolute; top:400px; margin-left:1000px;margin-right:0px;" runat="server" OnTextChanged="TextBoxRight2_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxRight3" Width="300px" style="position:absolute; top:450px; margin-left:1000px;margin-right:0px;" runat="server" OnTextChanged="TextBoxRight3_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxRight4" Width="300px" style="position:absolute; top:500px; margin-left:1000px;margin-right:0px;" runat="server" OnTextChanged="TextBoxRight4_TextChanged"></asp:TextBox>

            </div>


            <div runat="server">
                <asp:TextBox ID="TextBoxBot1" Width="600px" style="position:absolute; top:550px; margin-left:500px;margin-right:0px;" runat="server" OnTextChanged="TextBoxBot1_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot2" Width="30px" style="position:absolute; top:550px; margin-left:1110px;margin-right:0px;" runat="server" OnTextChanged="TextBoxBot1_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot3" Width="200px" style="position:absolute; top:600px; margin-left:700px;margin-right:0px;" runat="server" OnTextChanged="TextBoxBot2_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot4" Width="600px" style="position:absolute; top:650px; margin-left:500px;margin-right:0px;" runat="server" OnTextChanged="TextBoxBot3_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot5" Width="200px" style="position:absolute; top:700px; margin-left:700px;margin-right:0px;" runat="server" OnTextChanged="TextBoxBot4_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot6" Width="30px" style="position:absolute; top:700px; margin-left:910px;margin-right:0px;" runat="server" OnTextChanged="TextBoxBot4_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot7" Width="200px" style="position:absolute; top:800px; margin-left:700px;margin-right:0px;" runat="server" OnTextChanged="TextBoxBot5_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot8" Width="600px" style="position:absolute; top:850px; margin-left:500px;margin-right:0px;" runat="server" OnTextChanged="TextBoxBot6_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBoxBot9" Width="600px" style="position:absolute; top:1100px; margin-left:500px;margin-right:0px;" runat="server" OnTextChanged="TextBoxBot7_TextChanged"></asp:TextBox>
            </div>
            
   

    <div>
        <asp:Button ID="ButtonCreateMainList" style="position:absolute; top:250px; margin-left:1400px;margin-right:0px;" runat="server" Text="Сохранить титульник" OnClick="ButtonCreateMainList_Click" />
    </div>

    <div>
         <asp:Button ID="ButtonTest" style="position:absolute; top:250px; margin-left:300px;margin-right:0px;" runat="server" Text="Transfer" OnClick="ButtonTest_Click" />
    </div>



         </form>

</body>
</html>
