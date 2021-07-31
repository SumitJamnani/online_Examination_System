<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="frm_Gen_Paper.aspx.cs" Inherits="frm_Gen_Paper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
    <section class="content-header">
                    <h1>
                        Generate Paper       
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="frm_admin_main.aspx"><i class="fa fa-home"></i> Home</a></li>
                        <li>Generate Paper</li>
                        
                    </ol>
                    </section>
    <div class="col-xs-4">
        <div class="box box-primary">
            <div class="box-body">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="col-xs-4 box-body">
                            Select Sem:
                        </div>
                        <div class="col-xs-8 box-body">
                            <asp:DropDownList ID="drpsem" runat="server" AutoPostBack="True" class="btn btn-default dropdown-toggle"
                                OnSelectedIndexChanged="drpsem_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="drpsem"
                                ErrorMessage="Semester Required" ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-4 box-body">
                            Select subject :
                        </div>
                        <div class="col-xs-8 box-body">
                            <asp:DropDownList ID="drpsub" runat="server" AutoPostBack="True" class="btn btn-default dropdown-toggle">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpsub"
                                ErrorMessage="Subject Required" ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-4 box-body">
                            Select template :
                        </div>
                        <div class="col-xs-8 box-body">
                            <asp:DropDownList ID="drptemp" runat="server" AutoPostBack="True" class="btn btn-default dropdown-toggle"
                                OnSelectedIndexChanged="drptemp_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="drptemp"
                                ErrorMessage="Template Required" ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-4 box-body">
                            Select Section :
                        </div>
                        <div class="col-xs-8 box-body">
                            <asp:DropDownList ID="drpsection" runat="server" AutoPostBack="True" class="btn btn-default dropdown-toggle"
                                OnSelectedIndexChanged="drpsection_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="drpsection"
                                ErrorMessage="Section Required" ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-4 box-body">
                            Select Que :
                        </div>
                        <div class="col-xs-8 box-body">
                            <asp:DropDownList ID="drpque" runat="server" class="btn btn-default dropdown-toggle"
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-4 box-body">
                            Select Unit :
                        </div>
                        <div class="col-xs-8 box-body">
                            <asp:DropDownList ID="drpunit" runat="server" class="btn btn-default dropdown-toggle">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="box-body pad table-responsive">
                            <div class="rounded-button">
                                <asp:Button ID="btnsubmit" runat="server" Text="Bind Unit With Question" class="btn btn-success btn-sm"
                                    OnClick="btnsubmit_Click" ValidationGroup="msg1" />
                                <asp:Button ID="btngenpaper" runat="server" Text="Generate Paper" class="btn btn-success btn-sm"
                                    OnClick="btngenpaper_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <asp:Label ID="lblmismatch" runat="server" Text=""></asp:Label>
                        
                    </div>
                    <div class="col-xs-12">
                        <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                        
                    </div>
                       <div class="col-xs-12">
                        <asp:Label ID="lblemail" runat="server" Text=""></asp:Label>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-xs-8">
        <div class="box box-primary">
            <div class="box-body">
                <div class="row">
                    <div class="col-xs-12" style="overflow:scroll">
                        <asp:TreeView ID="TreeView1" runat="server">
                        </asp:TreeView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
