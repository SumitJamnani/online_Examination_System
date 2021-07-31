<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="frm_city.aspx.cs" Inherits="frmcity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
    <section class="content-header">
                    <h1>
                        City                        
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="frm_admin_main.aspx"><i class="fa fa-home"></i> Home</a></li>
                        
                        <li class="active">City</li>
                    </ol>
                </section>
    <div class="col-xs-12">
        <div class="box box-primary">
            <div class="box-body">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            City Name :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtcityname" runat="server" CssClass="form-control" placeholder="Enter City Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="msg1"
                                ControlToValidate="txtcityname" ErrorMessage="City Name Required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select State :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpstate" runat="server" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown" AutoPostBack="False">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="msg1"
                                ControlToValidate="drpstate" ErrorMessage="State Required" ForeColor="Red"></asp:RequiredFieldValidator>
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
                        <div class="box-body">
                            <asp:GridView ID="grdcity" AutoGenerateColumns="false" runat="server" OnRowCommand="grdcity_RowCommand"
                                AllowPaging="true" AllowSorting="true" PageSize="15" CssClass="table table-mailbox"
                                HorizontalAlign="Center">
                                <Columns>
                                    <asp:TemplateField HeaderText="City Id">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" Text="<%#Bind('[City_Id]') %>" CommandName="City_Id"
                                                CommandArgument='<%#Bind("[City_Id]") %>'>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="City_Name" HeaderText="City Name" />
                                    <asp:BoundField DataField="state_name" HeaderText="State Name" />
                                </Columns>
                                <FooterStyle BackColor="#FFFF99" BorderColor="#FF9900" BorderStyle="Dashed" Wrap="True" />
                                <HeaderStyle BackColor="Gray" BorderColor="Gray" />
                                <PagerStyle BackColor="LightGray" BorderColor="LightGray" />
                                <RowStyle BackColor="#CCCCCC" BorderColor="#CCCCCC" />
                            </asp:GridView>
                            <asp:HiddenField ID="hdncityid" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
