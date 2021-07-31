<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="frm_que_m.aspx.cs" Inherits="frm_que_m" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
    <section class="content-header">
                    <h1>
                        Objective Question                  
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="frm_admin_main.aspx"><i class="fa fa-home"></i> Home</a></li>
                        <li>Questions</li>
                        <li class="active">Objective Question</li>
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
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="drpsem"
                                ErrorMessage="Semester Required" ForeColor="Red" ValidationGroup="txt1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select Subject :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpsub" runat="server" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="drpsub"
                                ErrorMessage="Subject Required" ForeColor="Red" ValidationGroup="txt1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select Unit :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpunit" runat="server" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="drpunit"
                                ErrorMessage="Unit Required" ForeColor="Red" ValidationGroup="txt1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select Question Type :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drptype" runat="server" AutoPostBack="False" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown" OnSelectedIndexChanged="drptype_SelectedIndexChanged">
                                <asp:ListItem Value="1">MCQ</asp:ListItem>
                                <asp:ListItem Value="2">True False</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drptype"
                                ErrorMessage="Type Required" ForeColor="Red" ValidationGroup="txt1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Question Text :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtquestion" runat="server" TextMode="MultiLine" CssClass="form-control"
                                placeholder="Enter Question Text"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtquestion"
                                ErrorMessage="Question Text Required" ForeColor="Red" ValidationGroup="txt1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Option 1 :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txto1" runat="server" CssClass="form-control" placeholder="Enter Option 1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txto1"
                                ErrorMessage="Option 1 Required" ForeColor="Red" ValidationGroup="txt1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Option 2 :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txto2" runat="server" CssClass="form-control" placeholder="Enter Option 2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txto2"
                                ErrorMessage="Option 2 Required" ForeColor="Red" ValidationGroup="txt1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Option 3 :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txto3" runat="server" CssClass="form-control" placeholder="Enter Option 3"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Option 4 :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txto4" runat="server" CssClass="form-control" placeholder="Enter Option 4"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Correct Answer :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txt_c_ans" runat="server" CssClass="form-control" placeholder="Enter Correct Answer"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_c_ans"
                                ErrorMessage="Correct Ans Required" ForeColor="Red" ValidationGroup="txt1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select Complexity :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpcomplexity" runat="server" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="drpcomplexity"
                                ErrorMessage="Complexity Required" ForeColor="Red" ValidationGroup="txt1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="box-body pad table-responsive">
                            <div class="rounded-button">
                                <asp:Button ID="btnsubmit" runat="server" OnClick="btnsubmit_Click" Text="SUBMIT"
                                    ValidationGroup="txt1" class="btn btn-success btn-sm" />
                                <asp:Button ID="btnupdate" runat="server" Text="UPDATE" OnClick="btnupdate_Click"
                                    class="btn btn-primary btn-sm" />
                                <asp:Button ID="btndelete" runat="server" Text="DELETE" OnClick="btndelete_Click"
                                    class="btn btn-danger btn-sm" />
                                <asp:Button ID="btncancel" runat="server" Text="CANCEL" class="btn btn-warnings btn-sm"
                                    OnClick="btncancel_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="box-body">
                            <asp:GridView ID="Grdquestion" AutoGenerateColumns="false" runat="server" OnRowCommand="grdquestion_RowCommand"
                                AllowSorting="true" AllowPaging="true" PageSize="15" OnPageIndexChanging="Grdquestion_PageIndexChanging"
                                OnSelectedIndexChanging="Grdquestion_SelectedIndexChanging" CssClass="table table-mailbox"
                                HorizontalAlign="Center">
                                <Columns>
                                    <asp:TemplateField HeaderText="Question">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" Text="<%#Bind('[Que_Id]') %>" CommandName="Que_Id"
                                                CommandArgument='<%#Bind("[Que_Id]") %>'>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Sem_Name" HeaderText="Semester" />
                                    <asp:BoundField DataField="Sub_Name" HeaderText="Subject" />
                                    <asp:BoundField DataField="Unit_Id" HeaderText="Unit" />
                                    <asp:BoundField DataField="Que_Text" HeaderText="Question" />
                                    <asp:BoundField DataField="o1" HeaderText="Option A" />
                                    <asp:BoundField DataField="o2" HeaderText="Option B" />
                                    <asp:BoundField DataField="o3" HeaderText="Option C" />
                                    <asp:BoundField DataField="o4" HeaderText="Option D" />
                                    <asp:BoundField DataField="Correct_Ans" HeaderText="Correct Answer" />
                                </Columns>
                                <FooterStyle BackColor="#FFFF99" BorderColor="#FF9900" BorderStyle="Dashed" Wrap="True" />
                                <HeaderStyle BackColor="Gray" BorderColor="Gray" />
                                <PagerStyle BackColor="LightGray" BorderColor="LightGray" />
                                <RowStyle BackColor="#CCCCCC" BorderColor="#CCCCCC" />
                            </asp:GridView>
                            <asp:HiddenField ID="hdnquestion" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
