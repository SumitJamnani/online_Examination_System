<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="frm_studentprofile.aspx.cs" Inherits="frm_studentprofile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript">

        /*  function Samplefunction() {
        document.getElementById('txtname').txtname_TextChanged();
        document.getElementById('btnsearch').click();
        }


        $(function () {

        $("input[type=text]").keypress(function () {

        alert("hi");



        });

        });*/
 
    </script>
    <form id="form1" runat="server">
    <section class="content-header">
                    <h1>
                        Update Student Profile                       
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="frm_admin_main.aspx"><i class="fa fa-home"></i> Home</a></li>
                        
                        <li class="active">Update Student Profile</li>
                    </ol>
                </section>
    <div class="col-md-12">
        <!-- general form elements -->
        <div class="box box-primary">
            <div class="box-body">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select Year :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpyear" class="btn btn-default dropdown-toggle" data-toggle="dropdown"
                                runat="server" AutoPostBack="False">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="drpyear"
                                ErrorMessage="Year Required" ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Search :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtname" runat="server" CssClass="form-control" placeholder="Enter Exam Name"
                                OnTextChanged="txtname_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtname"
                                ErrorMessage="Exam Name Required" ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="box-body">
                            <asp:GridView ID="grdstud" AutoGenerateColumns="false" runat="server" OnRowCommand="grdstud_RowCommand"
                                OnPageIndexChanging="grdstud_PageIndexChanging" CssClass="table table-mailbox"
                                HorizontalAlign="Center">
                                <Columns>
                                    <asp:TemplateField HeaderText="Roll No">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" Text="<%#Bind('[Roll_No]') %>" CommandName="Roll_No"
                                                CommandArgument='<%#Bind("[Roll_No]") %>'>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                                    <asp:BoundField DataField="F_name" HeaderText="Student Name" SortExpression="Student_Name" />
                                </Columns>
                                <FooterStyle BackColor="#FFFF99" BorderColor="#FF9900" BorderStyle="Dashed" Wrap="True" />
                                <HeaderStyle BackColor="Gray" BorderColor="Gray" />
                                <PagerStyle BackColor="LightGray" BorderColor="LightGray" />
                                <RowStyle BackColor="#CCCCCC" BorderColor="#CCCCCC" />
                            </asp:GridView>
                            <asp:HiddenField ID="hdnyear" runat="server" />
                            <asp:HiddenField ID="hdnregid" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
