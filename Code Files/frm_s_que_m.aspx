<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="frm_s_que_m.aspx.cs" Inherits="frm_s_que_m" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
    <section class="content-header">
                    <h1>
                        Subjective Question                    
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="frm_admin_main.aspx"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li>Questions</li>
                        <li class="active">Subjective Question</li>
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
                                data-toggle="dropdown">
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
                            Minimum Marks :
                        </div>
                        <div class="col-xs-4 box-body">
                            <asp:TextBox ID="txtmarks" runat="server" CssClass="form-control" placeholder="Enter Minimum Marks"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtmarks"
                                ErrorMessage="Minimum Marks Required" ForeColor="Red" ValidationGroup="txt1"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-xs-2 box-body">
                            Maximum Marks :
                        </div>
                        <div class="col-xs-4 box-body">
                            <asp:TextBox ID="txtmarksm" runat="server" CssClass="form-control" placeholder="Enter Maximum Marks"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtmarksm"
                                ErrorMessage="Maximum Marks Required" ForeColor="Red" ValidationGroup="txt1"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="compmarks" runat="server" ControlToCompare="txtmarks" ControlToValidate="txtmarksm"
                                Operator="GreaterThanEqual" ErrorMessage="Max marks >= Min marks" ForeColor="Red"
                                Display="Dynamic"></asp:CompareValidator>
                        </div>
                    </div>
                    <%-- <div class="col-lg-12">
                    <div class="col-xs-2 box-body">
                        Group :
                    </div>
                    <%--<div class="col-xs-10 box-body">
                        <asp:DropDownList ID="drpgroup" runat="server" class="btn btn-default dropdown-toggle"
                            data-toggle="dropdown">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpgroup"
                            ErrorMessage="Group Required" ForeColor="Red" ValidationGroup="txt1"></asp:RequiredFieldValidator>
                    </div>
                </div>--%>
                    <%--<div class="col-lg-12">
                    <div class="col-xs-2 box-body">
                        Tag :
                    </div>
                    <div class="col-xs-10 box-body">
                        <asp:DropDownList ID="drptag" runat="server" class="btn btn-default dropdown-toggle"
                            data-toggle="dropdown">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="drptag"
                            ErrorMessage="Tag Required" ForeColor="Red" ValidationGroup="txt1"></asp:RequiredFieldValidator>
                    </div>
                </div>--%>
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
                            <asp:GridView ID="Grdsquestion" AutoGenerateColumns="false" runat="server" OnRowCommand="grdsquestion_RowCommand"
                                AllowSorting="true" AllowPaging="true" PageSize="15" OnPageIndexChanging="Grdsquestion_PageIndexChanging"
                                CssClass="table table-mailbox" HorizontalAlign="Center">
                                <Columns>
                                    <asp:TemplateField HeaderText="Question">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" Text="<%#Bind('[S_Que_Id]') %>" CommandName="S_Que_Id"
                                                CommandArgument='<%#Bind("[S_Que_Id]") %>'>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Sem_Name" HeaderText="Semester" />
                                    <asp:BoundField DataField="Sub_Name" HeaderText="Subject" />
                                    <asp:BoundField DataField="Unit_Id" HeaderText="Unit" />
                                    <asp:BoundField DataField="Que_Text" HeaderText="Question" />
                                    <asp:BoundField DataField="Min_value" HeaderText="Minimum Marks" />
                                    <asp:BoundField DataField="Max_value" HeaderText="Maximum Marks" />
                                    <%--<asp:BoundField DataField="Group_Name" HeaderText="Group" SortExpression="group_name" />
                            <asp:BoundField DataField="Tag_Name" HeaderText="Tag" SortExpression="tag_name" />--%>
                                </Columns>
                                <FooterStyle BackColor="#FFFF99" BorderColor="#FF9900" BorderStyle="Dashed" Wrap="True" />
                                <HeaderStyle BackColor="Gray" BorderColor="Gray" />
                                <PagerStyle BackColor="LightGray" BorderColor="LightGray" />
                                <RowStyle BackColor="#CCCCCC" BorderColor="#CCCCCC" />
                            </asp:GridView>
                            <asp:HiddenField ID="hdnsquestion" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
