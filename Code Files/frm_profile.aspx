<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="frm_profile.aspx.cs" Inherits="frm_profile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
    <section class="content-header">
                    <h1>
                        Profile                   
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="frm_admin_main.aspx"><i class="fa fa-home"></i> Home</a></li>
                        
                        <li class="active">Profile</li>
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
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Middle Name :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtmname" runat="server" CssClass="form-control" placeholder="Enter Middle Name"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Last Name :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtlname" runat="server" CssClass="form-control" placeholder="Enter Lastname"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Email :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtemail" runat="server" CssClass="form-control" placeholder="Enter Email"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Date of Birth :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                            </asp:ToolkitScriptManager>
                            <asp:TextBox ID="txtdob" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            <asp:ImageButton ID="calimgbtn" runat="server" Height="19px" ImageUrl="~/CalenderImageIcon.png"
                                Width="21px" />
                            <asp:CalendarExtender ID="txtdatecalext" runat="server" Format="MM/dd/yyyy" PopupButtonID="calimgbtn"
                                PopupPosition="BottomRight" TargetControlID="txtdob">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Gender:
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:RadioButtonList ID="rblgender" runat="server" AutoPostBack="True">
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Address 1 :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtadd1" runat="server" CssClass="form-control" placeholder="Enter Address"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Address 2 :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtadd2" runat="server" CssClass="form-control" placeholder="Enter Address"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="box-body pad table-responsive">
                            <div class="rounded-button">
                                <asp:Button ID="btnupdate" runat="server" Text="UPDATE" ValidationGroup="msg1" class="btn btn-success btn-sm"
                                    OnClick="btnupdate_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
