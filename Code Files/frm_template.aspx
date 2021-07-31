<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="frm_template.aspx.cs" Inherits="frm_temp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
    <section class="content-header">
                    <h1>
                        Template                       
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="frm_admin_main.aspx"><i class="fa fa-home"></i> Home</a></li>
                        
                        <li class="active">Template</li>
                    </ol>
                </section>
    <div class="col-xs-6">
        <div class="box box-primary">
            <div class="box-body">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Template Name :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txttempname" runat="server" CssClass="form-control" placeholder="Enter Template Name"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txttempname"
                                ErrorMessage="Tamplate Name Required" ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Template Marks :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txttempmarks" runat="server" CssClass="form-control" placeholder="Enter Template Marks"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txttempmarks"
                                ErrorMessage="Tamplate Marks Required" ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="box-body pad table-responsive">
                            <div class="rounded-button">
                                <asp:Button ID="btnsubmit" runat="server" Text="SUBMIT" ValidationGroup="msg1" class="btn btn-success btn-sm"
                                    OnClick="btnsubmit_Click1" />
                                <asp:Button ID="btnsection" runat="server" Text="SECTION" class="btn btn-success btn-sm"
                                    OnClick="btnsection_Click1" />
                                <asp:Button ID="btnsubsection" runat="server" Text="SUBSECTION" class="btn btn-success btn-sm"
                                    OnClick="btnsubsection_Click" />
                                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Paper Demo</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-xs-6">
        <div class="box box-primary">
            <div class="box-body">
                <div class="row">
                    <div class="col-lg-12">
                        <asp:Image ID="img1" runat="server" Height="390px" Width="284px" ImageUrl="~/images/paper1.jpg"
                            ImageAlign="AbsMiddle" />
                        <asp:Image ID="img2" runat="server" Height="390px" Width="284px" ImageUrl="~/images/paper2.jpg"
                            ImageAlign="AbsMiddle" />
                    </div>
                </div>
            </div>
        </div>
    </div>
 
    </form>
</asp:Content>
