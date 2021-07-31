<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="frm_student_update_profile.aspx.cs" Inherits="frm_student_update_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
    <asp:HiddenField ID="hdnregid" runat="server" />
    <section class="content-header">
                    <h1>
                        Student Profile                      
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="frm_admin_main.aspx"><i class="fa fa-home"></i> Home</a></li>
                        
                        <li class="active">Student Profile</li>
                    </ol>
                </section>
    <div class="col-xs-12">
        <div class="box box-primary">
            <div class="box-body">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Roll No :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtrollno" runat="server" CssClass="form-control" placeholder="Enter Roll No"
                                ReadOnly="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtrollno"
                                ErrorMessage="Roll No Required" ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Email :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtemail" runat="server" CssClass="form-control" placeholder="Enter Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtemail"
                                ErrorMessage="Email Required" ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Name :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtname" runat="server" CssClass="form-control" placeholder="Enter Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtname"
                                ErrorMessage="Name Required" ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="box-body pad table-responsive">
                            <div class="rounded-button">
                                <asp:Button runat="server" ID="btnupdate" Text="Update" OnClick="btnupdate_Click"
                                    ValidationGroup="msg1" class="btn btn-success btn-sm" />
                                <asp:Button runat="server" ID="btnback" Text="Back" class="btn btn-success btn-sm"
                                    OnClick="btnback_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
