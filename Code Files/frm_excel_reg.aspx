<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="frm_excel_reg.aspx.cs" Inherits="frm_excel_reg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
    <section class="content-header">
                    <h1>
                        Registration                     
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="frm_admin_main.aspx"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li><a href="#">Import Files</a></li>
                        <li class="active">Registration</li>
                    </ol>
                </section>
    <div class="col-xs-12">
        <div class="col-md-12">
            <div class="box box-primary">
                <div class="col-lg-12">
                    <div class="col-xs-2 box-body">
                        <asp:FileUpload runat="server" ID="fileuploadexcel" />
                    </div>
                    <div class="col-xs-12">
                        <div class="col-xs-2 box-body">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="msg1"
                                ControlToValidate="fileuploadexcel" ErrorMessage="File Upload Required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="box-body pad table-responsive">
                        <div class="rounded-button">
                            <asp:Button runat="server" ID="btnexcel" Text="Import" OnClick="btnexcel_Click" ValidationGroup="msg1"
                                class="btn btn-success btn-sm" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
