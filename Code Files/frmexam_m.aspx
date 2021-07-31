<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="frmexam_m.aspx.cs" Inherits="frmexam_m" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
    <section class="content-header">
                    <h1>
                        Manage Exam                       
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="frm_admin_main.aspx"><i class="fa fa-home"></i> Home</a></li>
                        
                        <li class="active">Manage Exam</li>
                    </ol>
                </section>
    <div class="col-xs-12">
        <div class="box box-primary">
            <div class="box-body">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Exam Name :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtename" runat="server" CssClass="form-control" placeholder="Enter Exam Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtename"
                                ErrorMessage="Exam Name Required" ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Subject :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpsubject" class="btn btn-default dropdown-toggle" data-toggle="dropdown"
                                runat="server" AutoPostBack="False">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="drpsubject"
                                ErrorMessage="Subject Name Required" ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Unit :
                        </div>
                        <div class="icheckbox_flat-red col-xs-2 box-body">
                            <asp:CheckBoxList ID="chkunit" runat="server" class="icheckbox_flat-red" AutoPostBack="False">
                                <asp:ListItem Value="1"> Unit 1</asp:ListItem>
                                <asp:ListItem Value="2"> Unit 2</asp:ListItem>
                                <asp:ListItem Value="3"> Unit 3</asp:ListItem>
                                <asp:ListItem Value="4"> Unit 4</asp:ListItem>
                            </asp:CheckBoxList>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="upcalender" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                            </asp:ToolkitScriptManager>
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <div class="col-xs-2 box-body">
                                        Start Date :
                                    </div>
                                    <div class="col-xs-10 box-body">
                                        <div class="input-group">
                                            <asp:TextBox ID="txtsdate" runat="server" CssClass="form-control" placeholder="Enter Exam Start Date"
                                                onfocus="this.blur();" />
                                            <div class="input-group-addon">
                                                <asp:ImageButton ID="calsimgbtn" runat="server" Height="19px" ImageUrl="~/CalenderImageIcon.png"
                                                    Width="21px" OnClick="calsimgbtn_Click" />
                                            </div>
                                        </div>
                                        <!-- /.input group -->
                                    </div>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtsdate"
                                    ErrorMessage="Start Date Required " ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                                <asp:CalendarExtender ID="txtsdatecalext" runat="server" Format="yyyy/MM/dd" PopupButtonID="calsimgbtn"
                                    PopupPosition="BottomRight" TargetControlID="txtsdate">
                                </asp:CalendarExtender>
                            </div>
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <div class="col-xs-2 box-body">
                                        End Date :
                                    </div>
                                    <div class="col-xs-10 box-body">
                                        <div class="input-group">
                                            <asp:TextBox ID="txtedate" runat="server" CssClass="form-control" placeholder="Enter Exam End Date"
                                                onfocus="this.blur();" />
                                            <div class="input-group-addon">
                                                <asp:ImageButton ID="caleimgbtn" runat="server" Height="19px" ImageUrl="~/CalenderImageIcon.png"
                                                    Width="21px" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtedate"
                                    ErrorMessage="End Date Required " ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                                <asp:CalendarExtender ID="txtedatecalext" runat="server" Format="yyyy/MM/dd" PopupButtonID="caleimgbtn"
                                    PopupPosition="BottomRight" TargetControlID="txtedate">
                                </asp:CalendarExtender>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Total Marks :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txttotmarks" runat="server" CssClass="form-control" placeholder="Enter Total Marks"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txttotmarks"
                                ErrorMessage="Total Marks Required" ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Passing Marks :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtpassingmarks" runat="server" CssClass="form-control" placeholder="Enter Passing Marks"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Passing Marks Required "
                                ForeColor="Red" ValidationGroup="msg1" ControlToValidate="txtpassingmarks"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Duration :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtduration" runat="server" CssClass="form-control" placeholder="Enter Duration"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtduration"
                                ErrorMessage="Duration Required" ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Total Question :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txttotque" runat="server" CssClass="form-control" placeholder="Enter Total Question"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txttotque"
                                ErrorMessage="Total Questions Required " ForeColor="Red" ValidationGroup="msg1"></asp:RequiredFieldValidator>
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
                                <asp:Button ID="btncancel" runat="server" Text="CANCEL" class="btn btn-warnings btn-sm" />
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="box-body">
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <asp:GridView ID="grdexam" AutoGenerateColumns="false" runat="server" OnRowCommand="grdexam_RowCommand"
                                AllowPaging="true" PageSize="15" OnPageIndexChanging="grdexam_PageIndexChanging"
                                AllowSorting="true" OnSorting="grdexam_Sorting" CssClass="table table-mailbox"
                                HorizontalAlign="Center">
                                <Columns>
                                    <asp:TemplateField HeaderText="Exam">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" Text="<%#Bind('[Exam_Id]') %>" CommandName="Exam_Id"
                                                CommandArgument='<%#Bind("[Exam_Id]") %>'>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="exam_name" HeaderText="Exam Name" />
                                    <asp:BoundField DataField="sub_name" HeaderText="Subject Name" />
                                    <asp:BoundField DataField="exam_start_date" HeaderText="Start Date" />
                                    <asp:BoundField DataField="exam_end_date" HeaderText="End Date" />
                                    <asp:BoundField DataField="tot_marks" HeaderText="Total Marks" />
                                    <asp:BoundField DataField="passing_marks" HeaderText="Pssing Marks" />
                                    <asp:BoundField DataField="duration" HeaderText="Duration" />
                                    <asp:BoundField DataField="tot_que" HeaderText="Total Question" />
                                </Columns>
                                <FooterStyle BackColor="#FFFF99" BorderColor="#FF9900" BorderStyle="Dashed" Wrap="True" />
                                <HeaderStyle BackColor="Gray" BorderColor="Gray" />
                                <PagerStyle BackColor="LightGray" BorderColor="LightGray" />
                                <RowStyle BackColor="#CCCCCC" BorderColor="#CCCCCC" />
                            </asp:GridView>
                            <asp:HiddenField ID="hdnexam" runat="server" />
                            <asp:HiddenField ID="hdnexamid" runat="server" />
                            <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick">
                            </asp:Timer>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
