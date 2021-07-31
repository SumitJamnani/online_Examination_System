<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="frm_s_excel_import.aspx.cs" Inherits="frm_s_excel_import" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
    <section class="content-header">
                    <h1>
                       Subjective Questions                     
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="frm_admin_main.aspx"><i class="fa fa-home"></i> Home</a></li>
                        <li>Import Questions</li>
                        <li class="active">Subjective Questions</li>
                    </ol>
                </section>
    <div class="col-xs-12">
        <div class="box box-primary">
            <div class="box-body">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            <asp:FileUpload runat="server" ID="fileuploadsubexcel" />
                        </div>
                        <div class="col-xs-12">
                            <div class="col-xs-2 box-body">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="msg1"
                                    ControlToValidate="fileuploadsubexcel" ErrorMessage="File Upload Required" ForeColor="Red"></asp:RequiredFieldValidator>
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
    </div>
    </form>
</asp:Content>
