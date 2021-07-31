<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
        <form id="form1" runat="server">
    <section class="content-header">
                    
    
    <div class="col-xs-12">
        <div class="col-md-12">
            <div class="box box-primary">
                <div class="col-lg-12">
                    <div class="col-xs-2 box-body">
                        Select Sem:
                    </div>
                    <div class="col-xs-10 box-body">
                        <asp:DropDownList ID="drpsem" runat="server" class="btn btn-default dropdown-toggle"
                            data-toggle="dropdown" AutoPostBack="True" 
                            onselectedindexchanged="drpsem_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
               
              <div class="col-lg-12">
                    <div class="col-xs-2 box-body">
                        select faculty :
                    </div>
                    <div class="col-xs-10 box-body">
                      <asp:DropDownList ID="drpf" runat="server" class="btn btn-default dropdown-toggle"
                            data-toggle="dropdown" AutoPostBack="True" 
                            onselectedindexchanged="drpf_SelectedIndexChanged"></asp:DropDownList>
                      </div>
                </div>
                    <div class="col-lg-12">
                    <div class="col-xs-2 box-body">
                       select exam :
                    </div>
                    <div class="col-xs-10 box-body">
                      <asp:DropDownList ID="drpe" runat="server" class="btn btn-default dropdown-toggle"
                            data-toggle="dropdown"></asp:DropDownList>
                      </div>
                </div>
                <div class="col-xs-12">
                    <div class="box-body pad table-responsive">
                        <div class="rounded-button">
                            <asp:Button ID="btnresult" runat="server" Text="RESULTS" OnClick="btnresult_Click"
                                class="btn btn-success btn-sm" />
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <asp:Label ID="lblpass" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblfail" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblab" runat="server" Text=""></asp:Label>
                </div>
                <div class="box-body">
                    
                </div>
                <div class="col-xs-12">
                    <div class="box-body pad table-responsive">
                        <div class="rounded-button">
                            <asp:Button ID="btngenerateexcel" runat="server" Text="Generate Excel" class="btn btn-success btn-sm"
                                OnClick="btngenerateexcel_Click" />
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <asp:Label runat="server" ID="lblmsg"></asp:Label>
                </div>
                <div class="col-xs-12">
                    <div class="box-body pad table-responsive">
                        <div class="rounded-button">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
                </section>
    </form>
</body>
</html>
