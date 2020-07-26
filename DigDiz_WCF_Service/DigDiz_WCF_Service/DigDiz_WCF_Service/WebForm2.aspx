<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="DigDiz_WCF_Service.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <script src="~/Scripts/jquery-3.4.1.js"></script>
<script src="~/Scripts/bootstrap.js"></script>
    <form id="Form1" runat="server">
        <div style="margin-left: 23px; margin-top: 21px">
            Path in folder<br/>
            <asp:TextBox ID = "Path" runat="server" Width="351px"></asp:TextBox>
        <br />
            Angle<br/>
        <asp:TextBox ID = "Angle" runat="server" Width="351px"></asp:TextBox>
        <br />
        <br/>
        <asp:Button Text="Go" runat="server" Width="150px" OnClick="Unnamed1_Click" />
            <br />
            <br />
            <asp:TextBox ID ="Result" runat="server"  ReadOnly="true" Height="35px" Width="346px"/>
        </div>
    </form>
</body>
</html>
