<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="frm_import.aspx.cs" Inherits="frm_import" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form" runat="server">
    <section class="content-header">
                    <h1>
                        Objective Questions     
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="frm_admin_main.aspx"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li><a href="#">Import Files</a></li>
                        <li class="active">Objective Questions</li>
                    </ol>
                </section>
    <div class="col-xs-12">
        <div class="box box-primary">
            <div class="box-body">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select Semester :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList runat="server" ID="drpsem" AutoPostBack="True" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown" OnSelectedIndexChanged="drpsem_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="drpsem"
                                ErrorMessage="Semester Required" ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select Subject :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList runat="server" ID="drpsub" AutoPostBack="True" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpsub"
                                ErrorMessage="Subject Required" ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            <asp:FileUpload runat="server" ID="fileuploadexcel" />
                        </div>
                        <div class="col-xs-12">
                            <div class="col-xs-2 box-body">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="msg1"
                                    ControlToValidate="fileuploadexcel" ErrorMessage="File Upload Required" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="box-body pad table-responsive">
                            <div class="rounded-button">
                                <asp:Button runat="server" ID="btnexcel" Text="Generate Excel" OnClick="btnexcel_Click"
                                    ValidationGroup="msg1" class="btn btn-success btn-sm" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
