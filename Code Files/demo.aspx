<%@ Page Language="C#" AutoEventWireup="true" CodeFile="demo.aspx.cs" Inherits="demo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem>Q1</asp:ListItem>
            <asp:ListItem>Q2</asp:ListItem>
            <asp:ListItem>Q3</asp:ListItem>
            <asp:ListItem>Q4</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <br />
        <asp:Panel ID="Panel2" runat="server">
            <asp:Label ID="Label1" runat="server" Text="Repeat Same As Above ? "></asp:Label>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
                AutoPostBack="True">
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
            </asp:RadioButtonList>
        </asp:Panel>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Paper Demo</asp:LinkButton>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click1" 
            Text="Button" />
        <br />
        <br />
        <br />
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        <br />
        <br />
        <br />
        <br />
        <asp:Panel ID="Panel1" runat="server">
            <asp:Image ID="Image1" runat="server" Height="116px" ImageUrl="~/p1.jpg" 
                Width="167px" />
        </asp:Panel>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
