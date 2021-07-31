<%@ Page Title="OnlineExam" Language="C#" AutoEventWireup="true" CodeFile="frmlogin_m.aspx.cs"
    Inherits="frmlogin_m" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   
    <title></title>
    <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no'
        name='viewport'>
    <!-- bootstrap 3.0.2 -->
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- font Awesome -->
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- Theme style -->
    <link href="css/AdminLTE.css" rel="stylesheet" type="text/css" />
</head>
<body class="bg-black" style="background-image:url('images/hero-bg.jpg')" onload="FullScreenMode()">
<div class="panel-img">
    <div class="form-box" id="login-box">
        <div class="header">
            L.J. Online Examination System
            Sign In</div>
        <form id="form1" runat="server">
        <div class="body bg-gray">
            <div class="form-group">
                Email
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtemail" runat="server" CssClass="form-control" placeholder="Eg : fy1@ljcca.com" ></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtemail"
                    ErrorMessage="Pl.Enter Valid Email Address!" ForeColor="#CC0000" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtemail"
                    ErrorMessage="Email Required" ForeColor="#CC0000" ValidationGroup="submit1"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                Password
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Eg : 1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtpassword"
                    ErrorMessage="Password Required" ForeColor="#CC0000" ValidationGroup="submit1"></asp:RequiredFieldValidator>
            </div>
            <asp:Button ID="btnlogin" runat="server" CssClass="btn bg-olive btn-block" OnClick="btnlogin_Click"
                Text="Login" ValidationGroup="submit1" />
            <asp:Button ID="btncancle" runat="server" CssClass="btn bg-olive btn-block" Text="Cancel"
                OnClick="btncancle_Click" />
       </div>
        <asp:HiddenField ID="hdnemail" runat="server" />
        <br />
        <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
        </form>
         </div>
    </div>
</body>
</html>
