<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="frm_subsection.aspx.cs" Inherits="frm_subsection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
    <section class="content-header">
                    <h1>
                        SubSection                       
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="frm_admin_main.aspx"><i class="fa fa-home"></i> Home</a></li>
                        
                        <li class="active">SubSection</li>
                    </ol>
                </section>
    <div class="col-xs-10">
        <div class="box box-primary">
            <div class="box-body">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select Template :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drptemp" runat="server" AutoPostBack="True" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown" OnSelectedIndexChanged="drptemp_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="drptemp"
                                ErrorMessage="Template Required" ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select Section :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpsec" runat="server" AutoPostBack="True" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown" OnSelectedIndexChanged="drpsec_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpsec"
                                ErrorMessage="Section Required" ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select Question :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpque" runat="server" AutoPostBack="True" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown" OnSelectedIndexChanged="drpque_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="drpque"
                                ErrorMessage="Question Required" ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                        </div>



                     <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Same As Which Question :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpsame" runat="server" AutoPostBack="True" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="drpque"
                                ErrorMessage="Question Required" ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                        </div>


                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Enter Marks :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtmarks" runat="server" CssClass="form-control" placeholder="Enter Marks"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtmarks"
                                ErrorMessage="Marks Required" ForeColor="Red" ValidationGroup="msg2"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select Subjective/Objective :
                        </div>
                        <div class="col-xs-10 box-body">
                            <div class="form-group">
                                <asp:RadioButtonList ID="rblquetype" runat="server" AutoPostBack="false">
                                    <asp:ListItem>Subjective</asp:ListItem>
                                    <asp:ListItem>Objective</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            How Many Questions ? :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtsubque" runat="server" CssClass="form-control" placeholder="Enter Question"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtsubque"
                                ErrorMessage="How Many Questions Required" ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="box-body pad table-responsive">
                            <div class="rounded-button">
                                <asp:Button ID="btnsubmit" runat="server" Text="SUBMIT" class="btn btn-success btn-sm"
                                    ValidationGroup="msg1" OnClick="btnsubmit_Click" />
                                <asp:Button ID="btnupdate" runat="server" Text="BIND MARKS" ValidationGroup="msg2"
                                    class="btn btn-success btn-sm" OnClick="btnupdate_Click" />
                                <asp:Button ID="btnclear" runat="server" Text="Clear" class="btn btn-success btn-sm"
                                    OnClick="btnclear_Click" />
                                <asp:Button ID="btntemp" runat="server" Text="TEMPLATE" class="btn btn-success btn-sm"
                                    OnClick="btntemp_Click" />
                                <asp:Button ID="btnsec" runat="server" Text="SECTION" class="btn btn-success btn-sm"
                                    OnClick="btnsec_Click" />
                                    <asp:Button ID="btnnext" runat="server" Text="Go To Generate Page" class="btn btn-success btn-sm"
                                    OnClick="btnnext_Click" />
                                    <asp:Button ID="btnsameas" runat="server" Text="Same AS" class="btn btn-success btn-sm"
                                    OnClick="btnsameas_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-xs-2">
        <div class="box box-primary">
            <div class="box-body">
                <div class="row">
                    <div class="col-xs-12">
                        <asp:TreeView ID="TreeView1" runat="server">
                        </asp:TreeView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
