<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="frm_change_user_type.aspx.cs" Inherits="frm_change_user_type" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
    <section class="content-header">
                    <h1>
                        Change User Type                       
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="frm_admin_main.aspx"><i class="fa fa-home"></i> Home</a></li>
                        
                        <li class="active">Change User Type</li>
                    </ol>
                </section>
    <div class="col-xs-12">
        <div class="box box-primary">
            <div class="box-body">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Enter Email :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txt_email" runat="server" CssClass="form-control" placeholder="Enter Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txt_email"
                                ErrorMessage="Email Required" ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select Type :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drp_type" class="btn btn-default dropdown-toggle" data-toggle="dropdown"
                                runat="server" AutoPostBack="False">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="drp_type"
                                ErrorMessage="Type Required" ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="box-body pad table-responsive">
                            <div class="rounded-button">
                                <asp:Button ID="Button1" runat="server" Text="Change User Type" OnClick="btn_type_Click"
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
