<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="frm_select_exam.aspx.cs" Inherits="select_exam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
    <section class="content-header">
                    <h1>
                        Exam Status                
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="frm_admin_main.aspx"><i class="fa fa-home"></i> Home</a></li>
                        <li class="active">Exam Status</li>
                        
                    </ol>
                </section>
    <div class="col-xs-12">
        <div class="box box-primary">
            <div class="box-body">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select Exam :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpexamname" class="btn btn-default dropdown-toggle" data-toggle="dropdown"
                                runat="server" AutoPostBack="False">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select Status :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpstartstop" runat="server" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown" AutoPostBack="False">
                                <asp:ListItem Text="--Select Status--" Value=""></asp:ListItem>
                                <asp:ListItem Text="Stop" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Start" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfs" runat="server" ControlToValidate="drpstartstop"
                                ErrorMessage=" Please select the exam status"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="box-body pad table-responsive">
                            <div class="rounded-button">
                                <asp:Button ID="btnexam" runat="server" Text="CHANGE STATUS" OnClick="btnexam_Click"
                                    class="btn btn-success btn-sm" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </div>
    </div>
    </form>
</asp:Content>
