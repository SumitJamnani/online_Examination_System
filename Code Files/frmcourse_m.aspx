<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="frmcourse_m.aspx.cs" Inherits="frmcourse_m" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
    <section class="content-header">
                    <h1>
                        Course                        
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="frm_admin_main.aspx"><i class="fa fa-home"></i> Home</a></li>
                        
                        <li class="active">Course</li>
                    </ol>
                </section>
    <div class="col-xs-12">
        <div class="box box-primary">
            <div class="box-body">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Course Name :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtcname" runat="server" CssClass="form-control" placeholder="Enter Course Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtcname"
                                ErrorMessage="Course Name Required" ForeColor="Red" ValidationGroup="txt1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select Director :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpcname" runat="server" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpcname"
                                ErrorMessage="Director Name Required" ForeColor="Red" ValidationGroup="txt1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="box-body pad table-responsive">
                            <div class="rounded-button">
                                <asp:Button ID="btnsubmit" runat="server" Text="SUBMIT" OnClick="btnsubmit_Click"
                                    class="btn btn-success btn-sm" ValidationGroup="txt1" />
                                <asp:Button ID="btnupdate" runat="server" Text="UPDATE" class="btn btn-primary btn-sm"
                                    OnClick="btnupdate_Click" />
                                <asp:Button ID="btndelete" runat="server" Text="DELETE" class="btn btn-danger btn-sm"
                                    OnClick="btndelete_Click" />
                                <asp:Button ID="btncancel" runat="server" Text="CANCEL" class="btn btn-warnings btn-sm" />
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="box-body">
                            <asp:HiddenField ID="hdncourse" runat="server" />
                            <asp:GridView ID="Grdcourse" AutoGenerateColumns="false" runat="server" AllowPaging="true"
                                OnRowCommand="grdcourse_RowCommand" AllowSorting="true" OnSelectedIndexChanging="Grdcourse_SelectedIndexChanging"
                                PageSize="15" OnPageIndexChanging="Grdcourse_PageIndexChanging" CssClass="table table-mailbox"
                                HorizontalAlign="Center">
                                <Columns>
                                    <asp:TemplateField HeaderText="Course">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" Text="<%#Bind('[C_Id]') %>" CommandName="C_Id"
                                                CommandArgument='<%#Bind("[C_Id]") %>'>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="c_name" HeaderText="Course Name" />
                                    <asp:BoundField DataField="f_name" HeaderText="Director Name" />
                                </Columns>
                                <FooterStyle BackColor="#FFFF99" BorderColor="#FF9900" BorderStyle="Dashed" Wrap="True" />
                                <HeaderStyle BackColor="Gray" BorderColor="Gray" />
                                <PagerStyle BackColor="LightGray" BorderColor="LightGray" />
                                <RowStyle BackColor="#CCCCCC" BorderColor="#CCCCCC" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
