<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="frmsem_m.aspx.cs" Inherits="frmsem_m" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
    <section class="content-header">
                    <h1>
                        Semester                        
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="frm_admin_main.aspx"><i class="fa fa-home"></i> Home</a></li>
                        
                        <li class="active">Semester</li>
                    </ol>
                </section>
    <div class="col-xs-12">
        <div class="box box-primary">
            <div class="box-body">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Semester :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtsemname" runat="server" CssClass="form-control" placeholder="Enter Semester"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtsemname"
                                ErrorMessage="Semester Name Required" ForeColor="Red" ValidationGroup="txt1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select Subject :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpsem" runat="server" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown" AutoPostBack="False">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpsem"
                                ErrorMessage="Subject Name Required" ForeColor="Red" ValidationGroup="txt1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="box-body pad table-responsive">
                            <div class="rounded-button">
                                <asp:Button ID="btnsubmit" runat="server" Text="SUBMIT" OnClick="btnsubmit_Click"
                                    class="btn btn-success btn-sm" ValidationGroup="txt1" />
                                <asp:Button ID="btnupdate" runat="server" Text="UPDATE" OnClick="btnupdate_Click"
                                    class="btn btn-primary btn-sm" />
                                <asp:Button ID="btndelete" runat="server" Text="DELETE" class="btn btn-danger btn-sm"
                                    OnClick="btndelete_Click" />
                                <asp:Button ID="btncancel" runat="server" Text="CANCEL" class="btn btn-warnings btn-sm" />
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="box-body">
                            <asp:GridView ID="Grdsem" AutoGenerateColumns="false" runat="server" OnRowCommand="grdsem_RowCommand"
                                AllowPaging="true" AllowSorting="true" OnSelectedIndexChanging="Grdsem_SelectedIndexChanging"
                                PageSize="15" OnPageIndexChanging="Grdsem_PageIndexChanging" CssClass="table table-mailbox"
                                HorizontalAlign="Center">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sem Id">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" Text="<%#Bind('[Sem_Id]') %>" CommandName="Sem_Id"
                                                CommandArgument='<%#Bind("[Sem_Id]") %>'>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Sem_Name" HeaderText="Semester" />
                                    <asp:BoundField DataField="C_Name" HeaderText="Course Name" />
                                </Columns>
                                <FooterStyle BackColor="#FFFF99" BorderColor="#FF9900" BorderStyle="Dashed" Wrap="True" />
                                <HeaderStyle BackColor="Gray" BorderColor="Gray" />
                                <PagerStyle BackColor="LightGray" BorderColor="LightGray" />
                                <RowStyle BackColor="#CCCCCC" BorderColor="#CCCCCC" />
                            </asp:GridView>
                            <asp:HiddenField ID="hdnsem" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
