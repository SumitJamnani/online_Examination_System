<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource4" 
            AutoGenerateColumns="False" DataKeyNames="Email">
            <Columns>
                <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" 
                    SortExpression="Email" />
                <asp:BoundField DataField="Password" HeaderText="Password" 
                    SortExpression="Password" />
                <asp:BoundField DataField="Type_FSD" HeaderText="Type_FSD" 
                    SortExpression="Type_FSD" />
                <asp:BoundField DataField="Sec_Id" HeaderText="Sec_Id" 
                    SortExpression="Sec_Id" />
                <asp:BoundField DataField="Sec_Ans" HeaderText="Sec_Ans" 
                    SortExpression="Sec_Ans" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
            ConnectionString="<%$ ConnectionStrings:databaseConnectionString %>" 
            SelectCommand="SELECT * FROM [Login_M]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
