<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="frm_fact_sub.aspx.cs" Inherits="frmfactsub" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<form id="form1" runat="server">
    <section class="content-header">
                    <h1>
                        Manage Faculty                       
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="frm_admin_main.aspx"><i class="fa fa-home"></i> Home</a></li>
                        
                        <li class="active">Manage Faculty</li>
                    </ol>
                </section>
    <div class="col-xs-12">
        <div class="col-md-12">
            <div class="box box-primary">
                <div class="col-lg-12">
                    <div class="col-xs-2 box-body">
                        Select Semester :
                    </div>
                    <div class="col-xs-10 box-body">
                        <asp:DropDownList ID="drpsem" runat="server" class="btn btn-default dropdown-toggle" data-toggle="dropdown"
                         AutoPostBack="False">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="msg1"
                            ControlToValidate="drpsem" ErrorMessage="Semester Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-lg-12">
                    <div class="col-xs-2 box-body">
                        Select Faculty :
                    </div>
                    <div class="col-xs-10 box-body">
                        <asp:DropDownList ID="drpfact" runat="server"
                            class="btn btn-default dropdown-toggle" data-toggle="dropdown" 
                            AutoPostBack="False">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="msg1"
                            ControlToValidate="drpfact" ErrorMessage="Faculty Name Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                    <div class="col-lg-12">
                    <div class="col-xs-2 box-body">
                        Select Subject :
                    </div>
                    <div class="col-xs-10 box-body">
                        <asp:DropDownList ID="drpsub" runat="server" class="btn btn-default dropdown-toggle" data-toggle="dropdown" 
                            AutoPostBack="False">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="msg1"
                            ControlToValidate="drpsub" ErrorMessage="Subject Name Required" ForeColor="Red"></asp:RequiredFieldValidator>
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
                    <asp:GridView ID="grdfactsub" AutoGenerateColumns="false" runat="server" OnRowCommand="grid_factsub_RowCommand"
                        AllowPaging="true" AllowSorting="true" PageSize="15" CssClass="table table-mailbox"
                        HorizontalAlign="Center" onpageindexchanging="grdfactsub_PageIndexChanging" 
                       >
                        <Columns>
                            <asp:TemplateField HeaderText="Id">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" Text="<%#Bind('[Id]') %>" CommandName="Id"
                                        CommandArgument='<%#Bind("[Id]") %>'>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField="Sem_Name" HeaderText="Semester" SortExpression="Sem_Name" />
                            <asp:BoundField DataField="F_Name" HeaderText="Fact Name" SortExpression="F_Name" />
                            <asp:BoundField DataField="Sub_Code" HeaderText="Subject Code" SortExpression="sub_code" />
                            <asp:BoundField DataField="Sub_Name" HeaderText="Subject" SortExpression="Sub_Name" />
                        </Columns>
                        <FooterStyle BackColor="#FFFF99" BorderColor="#FF9900" BorderStyle="Dashed" Wrap="True" />
                        <HeaderStyle BackColor="Gray" BorderColor="Gray" />
                        <PagerStyle BackColor="LightGray" BorderColor="LightGray"  />
                        <RowStyle BackColor="#CCCCCC" BorderColor="#CCCCCC"  />
                    </asp:GridView>
                    <asp:HiddenField ID="hiddenfactsubid" runat="server" />
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
