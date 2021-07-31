<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reg_excel_import.aspx.cs" Inherits="reg_excel_import" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
    <tr>
    <td>
        <asp:FileUpload ID="fileuploadreg" runat="server" /></td>
    </tr>
    <tr>
    <td>
        <asp:Button ID="Button1" runat="server" Text="Import" onclick="Button1_Click" /></td>
    <td>
        <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label></td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
