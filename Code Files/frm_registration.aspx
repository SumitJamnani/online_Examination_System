<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="frm_registration.aspx.cs" Inherits="frm_registration" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form id="form1" runat="server">
    <section class="content-header">
                    <h1>
                       Add User                       
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="frm_admin_main.aspx"><i class="fa fa-home"></i> Home</a></li>
                        
                        <li class="active">Add User</li>
                    </ol>
                </section>
    <div class="col-xs-12">
        <div class="box box-primary">
            <div class="box-body">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            First Name :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtfname" runat="server" CssClass="form-control" placeholder="Enter First Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="msg1"
                                ControlToValidate="txtfname" ErrorMessage="First Name Required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Middle Name :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtmname" runat="server" CssClass="form-control" placeholder="Enter Middle Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="msg1"
                                ControlToValidate="txtmname" ErrorMessage="Middle Name Required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Last Name :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtlname" runat="server" CssClass="form-control" placeholder="Enter Last Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="msg1"
                                ControlToValidate="txtlname" ErrorMessage="Last Name Required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Gender :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:RadioButtonList ID="rblgender" runat="server" AutoPostBack="True">
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="rblgender"
                                ErrorMessage="Grnder Required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Date Of Birth :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                            </asp:ToolkitScriptManager>
                            <asp:TextBox ID="txtdate" runat="server" CssClass="form-control" placeholder="Enter Date of Birth"/>
                            <asp:ImageButton ID="calimgbtn" runat="server" Height="19px" ImageUrl="~/CalenderImageIcon.png"
                                Width="21px" />
                            <asp:CalendarExtender ID="txtdatecalext" runat="server" Format="MM/dd/yyyy" PopupButtonID="calimgbtn"
                                PopupPosition="BottomRight" TargetControlID="txtdate">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Address 1 :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtadd1" runat="server" CssClass="form-control" placeholder="Enter Address 1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="msg1"
                                ControlToValidate="txtadd1" ErrorMessage="Address1 Required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Address 2 :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtadd2" runat="server" CssClass="form-control" placeholder="Enter Address 2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="msg1"
                                ControlToValidate="txtadd2" ErrorMessage="Address2 Required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            City :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpcity" runat="server" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Semester :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpsem" runat="server" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Division :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpdivision" runat="server" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Email :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtemail" runat="server" CssClass="form-control" placeholder="Enter Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ValidationGroup="msg1"
                                ControlToValidate="txtemail" ErrorMessage="Email Required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Password :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtpassword" runat="server" CssClass="form-control" placeholder="Enter Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="msg1"
                                ControlToValidate="txtpassword" ErrorMessage="Password Required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Confirm Password :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtcpassword" runat="server" CssClass="form-control" placeholder="Enter Confirm Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="msg1"
                                ControlToValidate="txtcpassword" ErrorMessage="Confirm Password Required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Security Question :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpsecque" runat="server" AutoPostBack="True" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Security Answer :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtsans" runat="server" CssClass="form-control" 
                                placeholder="Enter Security Answer" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ValidationGroup="msg1"
                                ControlToValidate="txtsans" ErrorMessage="Security Answer Required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="box-body pad table-responsive">
                            <div class="rounded-button">
                                <asp:Button ID="btnsubmit" runat="server" Text="Submit" ValidationGroup="msg1" 
                                    onclick="btnsubmit_Click" />
                                <asp:Button ID="btncancel" runat="server" Text="Cancel" onclick="btncancel_Click" 
                                     />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>

