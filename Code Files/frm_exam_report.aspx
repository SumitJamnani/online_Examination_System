<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="frm_exam_report.aspx.cs" Inherits="exam_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
    <section class="content-header">
                    <h1>
                        Report                
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="frm_admin_main.aspx"><i class="fa fa-home"></i> Home</a></li>
                        <li class="active">Report</li>
                        
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
                            <asp:DropDownList ID="drpsem" runat="server" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown" AutoPostBack="True" OnSelectedIndexChanged="drpsem_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="drpsem"
                                ErrorMessage="Semester Required" ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select Faculty :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpf" runat="server" AutoPostBack="true" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown" OnSelectedIndexChanged="drpf_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpf"
                                ErrorMessage="Faculty Required" ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select Exam :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpexamname" runat="server" AutoPostBack="True" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="drpexamname"
                                ErrorMessage="Exam Required" ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="box-body pad table-responsive">
                            <div class="rounded-button">
                                <asp:Button ID="btnresult" runat="server" Text="RESULTS" OnClick="btnresult_Click"
                                    class="btn btn-success btn-sm" ValidationGroup="msg1" />
                                <asp:Button ID="btngenerateexcel" runat="server" Text="Generate Excel" class="btn btn-success btn-sm"
                                    OnClick="btngenerateexcel_Click" ValidationGroup="msg1"/>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="box-body">
                            <div class="callout callout-info">
                                <asp:Label ID="lblpass" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblfail" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblab" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="box-body">
                            <asp:GridView ID="grd_result" AutoGenerateColumns="true" runat="server" OnRowDataBound="grd_result_RowDataBound"
                                CssClass="table table-mailbox">
                                <FooterStyle BackColor="#FFFF99" BorderColor="#FF9900" BorderStyle="Dashed" Wrap="True" />
                                <HeaderStyle BackColor="Gray" BorderColor="Gray" />
                                <PagerStyle BackColor="LightGray" BorderColor="LightGray" />
                                <RowStyle BackColor="#CCCCCC" BorderColor="#CCCCCC" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <asp:Label runat="server" ID="lblmsg"></asp:Label>
                    </div>
                    <div class="col-xs-12">
                        <div class="box-body pad table-responsive">
                            <div class="rounded-button">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
