<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="frm_section.aspx.cs" Inherits="frm_section" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
    <section class="content-header">
                    <h1>
                        Section                       
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="frm_admin_main.aspx"><i class="fa fa-home"></i> Home</a></li>
                        
                        <li class="active">Section</li>
                    </ol>
                </section>
    <div class="col-xs-12">
        <div class="box box-primary">
            <div class="box-body">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select Template :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drptemp" runat="server" AutoPostBack="True" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="drptemp"
                                ErrorMessage="Template Required" ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Section Name :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtsecname" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtsecname"
                                ErrorMessage="Section Name Required" ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Marks of Section :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtsecmarks" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtsecmarks"
                                ErrorMessage="Marks of Section Required" ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            How many questions you want to enter :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtqueno" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtqueno"
                                ErrorMessage="How Many Questions Required" ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="box-body pad table-responsive">
                            <div class="rounded-button">
                                <asp:Button ID="btnsubmit" runat="server" Text="SUBMIT" OnClick="btnsubmit_Click"
                                    ValidationGroup="msg1" class="btn btn-success btn-sm" />
                                <asp:Button ID="btntemp" runat="server" Text="TEMPLATE" OnClick="btntemp_Click" class="btn btn-success btn-sm" />
                                <asp:Button ID="btnsubsec" runat="server" Text="SUBSECTION" OnClick="btnsubsec_Click"
                                    class="btn btn-success btn-sm" />
                            </div>
                        </div>
                    </div>
                    
                </div>
            </div>
        </div>
    </form>
</asp:Content>
