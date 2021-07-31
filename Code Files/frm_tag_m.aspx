<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="frm_tag_m.aspx.cs" Inherits="frm_tag_m" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form id="form1" runat="server">
<section class="content-header">
                    <h1>
                       Tag                       
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="frm_admin_main.aspx"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li><a href="#">Master Pages</a></li>
                        <li class="active">Tag</li>
                    </ol>
                </section>
                
    <div class="col-xs-12">
        <div class="col-md-12">
            <div class="box box-primary">
                <div class="col-lg-12">
                    <div class="col-xs-2 box-body">
                        Tag Name :
                    </div>
                    <div class="col-xs-10 box-body">
                        <asp:TextBox ID="txttagname" runat="server" CssClass="form-control" 
                            placeholder="Enter Tag Name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="msg1"
                            ControlToValidate="txttagname" ErrorMessage="Tag Name Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="box-body pad table-responsive">
                        <div class="rounded-button">
                            <asp:Button ID="btnsubmit" runat="server" Text="SUBMIT" OnClick="btnsubmit_Click"
                                ValidationGroup="msg1" class="btn btn-success btn-sm" />
                            <asp:Button ID="btnupdate" runat="server" Text="UPDATE" OnClick="btnupdate_Click"
                                class="btn btn-primary btn-sm" />
                            <asp:Button ID="btndelete" runat="server" Text="DELETE" OnClick="btndelete_Click"
                                class="btn btn-danger btn-sm" />
                            <asp:Button ID="btncancel" runat="server" Text="CANCEL" OnClick="btncancel_Click"
                                class="btn btn-warnings btn-sm" />
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <asp:Label ID="label_error" runat="server" Text=""></asp:Label>
                </div>
                
                <div class="box-body">
                    <asp:GridView ID="grid_tag" runat="server" AutoGenerateColumns="false" OnRowCommand="tag_RowCommand"
                        AllowPaging="true" AllowSorting="true" PageSize="15" CssClass="table table-mailbox"
                        HorizontalAlign="Center">
                        <Columns>
                            <asp:TemplateField HeaderText="tag Id">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" Text="<%#Bind('[Tag_Id]') %>" CommandName="Tag_Id"
                                        CommandArgument='<%#Bind("[Tag_Id]") %>'>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Tag_Name" HeaderText="Tag Name" />
                            
                        </Columns>
                        <FooterStyle BackColor="#FFFF99" BorderColor="#FF9900" BorderStyle="Dashed" Wrap="True" />
                        <HeaderStyle BackColor="Gray" BorderColor="Gray" />
                        <PagerStyle BackColor="LightGray" BorderColor="LightGray" />
                        <RowStyle BackColor="#CCCCCC" BorderColor="#CCCCCC" />
                    </asp:GridView>
                    <asp:HiddenField ID="hiddentagid" runat="server" />
                </div>
                
            </div>
        </div>
    </div>
    </form>
</asp:Content>

