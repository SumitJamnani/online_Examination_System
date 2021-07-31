<%@ Page Language="C#" AutoEventWireup="true" CodeFile="excel_import.aspx.cs" Inherits="excel_import" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no'
        name='viewport'>
    <!-- bootstrap 3.0.2 -->
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- font Awesome -->
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- Ionicons -->
    <link href="css/ionicons.min.css" rel="stylesheet" type="text/css" />
    <!-- Theme style -->
    <link href="css/AdminLTE.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="col-lg-4 col-xs-6 text-center-block">
                            <!-- small box -->
                            <div class="small-box bg-purple">
                                <div class="inner">
                                <font size="20px"><center>Import File </center></font>
                               </div>
                               <div class="inner">
                                 <asp:FileUpload runat="server" ID="fileuploadexcel"/> 
                                </div>
                                <div class="icon">
                                    <i class="ion ion-pie-graph"></i>
                                </div>
                                <a href="#" class="small-box-footer">                                    
                                    <asp:Button runat="server" ID="btnexcel" Text="Import" CssClass="btn bg-purple btn-flat margin" onclick="btnexcel_Click"/><i class="ion ion-ios7-briefcase-outline"></i>
                                </a>
                            </div>
                        </div>
    <div>
       <table>
       <tr>
       <td>
       
       </td>
       </tr>
       <tr>
       <td></td>
       <td>
        <asp:Label runat="server" ID="lblmsg"></asp:Label>
       </td>
       </tr>
       </table>
    </div>
    </form>
</body>
</html>
