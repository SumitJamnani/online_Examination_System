<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="frm_exam_list.aspx.cs" Inherits="frmexamlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 0);
        window.onunload = function () { null };

        //     function FullScreenMode() {
        //         var win = window.open("", "full", "dependent=yes, fullscreen=yes");
        //         win.location = window.location.href;
        //         window.opener = null;
        //   }
 
    </script>
    <%--   <script type="text/javascript">
        var win = "location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,status=yes";
        window.opener = self;
        window.close();
        window.open('', '', win);
        window.moveTo(0, 0);
        window.resizeTo(screen.width, screen.height - 100);
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-lg-12">
        <div class="col-lg-4 col-xs-6 text-center-block">
            <!-- small box -->
            <div class="small-box bg-red">
                <div class="inner">
                    <font size="20px">
                        <center>
                            Expire Exam
                        </center>
                    </font>
                </div>
                <div class="inner">
                </div>
                <div class="icon">
                    <i class="ion ion-pie-graph"></i>
                </div>
                <a href="#" class="small-box-footer">
                    <asp:Button ID="btnexpire" runat="server" Text="Click Here" CssClass="btn btn-danger btn-lg"
                        OnClick="btnexpire_Click" />
                    <i class="fa fa-arrow-circle-right"></i></a>
            </div>
        </div>
        <div class="col-lg-4 col-xs-6 text-center-block">
            <!-- small box -->
            <div class="small-box bg-green">
                <div class="inner">
                    <font size="20px">
                        <center>
                            Current Exam
                        </center>
                    </font>
                </div>
                <div class="inner">
                </div>
                <div class="icon">
                    <i class="ion ion-stats-bars"></i>
                </div>
                <a href="#" class="small-box-footer">
                    <asp:Button ID="btncurrent" runat="server" Text="Click Here" OnClick="btncurrent_Click"
                        CssClass="btn btn-success btn-lg" />
                    <i class="fa fa-arrow-circle-right"></i></a>
            </div>
        </div>
        <div class="col-lg-4 col-xs-6 text-center-block">
            <!-- small box -->
            <div class="small-box bg-aqua">
                <div class="inner">
                    <font size="20px">
                        <center>
                            Result</center>
                    </font>
                </div>
                <div class="inner">
                </div>
                <div class="icon">
                    <i class="ion ion-bag"></i>
                </div>
                <a href="#" class="small-box-footer">
                    <asp:Button ID="btnresult" runat="server" Text="Click Here" OnClick="btnresult_Click"
                        CssClass="btn btn-info btn-lg" /><i class="fa fa-arrow-circle-right"></i>
                </a>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12 invoice-col">
                <div class="col-md-12">
                    <div class="box box-solid box-warning">
                        <div class="box-header">
                            <h3 class="box-title">
                                <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label></h3>
                        </div>
                        <div class="box-body">
                             <%--current exam--%>
                            <asp:GridView ID="grd_current_exam" runat="server" AutoGenerateColumns="false" OnRowCommand="grd_current_exam_list_RowCommand"
                                CssClass="table table-mailbox" HorizontalAlign="Center">
                                <Columns>
                                    <asp:TemplateField HeaderText="Exam Name">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="linkbtnexamname" runat="server" Text="<%#Bind('[Exam_Name]') %>"
                                                CommandName="Exam_Id" CommandArgument='<%#Bind("[Exam_Id]") %>'>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Exam Start Date">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="linkbtn_exam_start_date" runat="server" Text="<%#Bind('[Exam_Start_Date]') %>"
                                                CommandName="Exam_Id" CommandArgument='<%#Bind("[Exam_Id]") %>'>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Exam End Date">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="linkbtn_exam_end_date" runat="server" Text="<%#Bind('[Exam_End_Date]') %>"
                                                CommandName="Exam_Id" CommandArgument='<%#Bind("[Exam_Id]") %>'>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Registration Date">
                                        <ItemTemplate>
                                                <asp:LinkButton ID="linkbtn_reg_date" runat="server" Text="<%#Bind('[Reg_Date]') %>"
                                                    CommandName="Exam_Id" CommandArgument='<%#Bind("[Exam_Id]") %>'>
                                                </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total Mark">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="linkbtn_tot_marks" runat="server" Text="<%#Bind('[Tot_Marks]') %>"
                                                CommandName="Exam_Id" CommandArgument='<%#Bind("[Exam_Id]") %>'>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Passing Mark">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="linkbtn_passing_marks" runat="server" Text="<%#Bind('[Passing_Marks]') %>"
                                                CommandName="Exam_Id" CommandArgument='<%#Bind("[Exam_Id]") %>'>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>                                    
                                </Columns>
                                <FooterStyle BackColor="#FFFF99" BorderColor="#FF9900" BorderStyle="Dashed" Wrap="True" />
                                <HeaderStyle BackColor="Gray" BorderColor="Gray" HorizontalAlign="Center" />
                                <PagerStyle BackColor="#FFFF99" BorderColor="#FFCC00" HorizontalAlign="Center" />
                                <RowStyle BackColor="#CCCCCC" BorderColor="#CCCCCC" HorizontalAlign="Center" />
                            </asp:GridView>


                            <%--expire exam--%>
                            <asp:GridView ID="grd_expire_exam" runat="server" AutoGenerateColumns="false" CssClass="table table-mailbox" HorizontalAlign="Center">
                            <Columns>
                            <asp:BoundField DataField="exam_name" HeaderText="Exam Name" SortExpression="Exam_Name" />
                            <asp:BoundField DataField="sub_name" HeaderText="Subject Name" SortExpression="sub_name" />
                            <asp:BoundField DataField="exam_start_date" HeaderText="Start Date" SortExpression="exam_start_date" />
                            <asp:BoundField DataField="exam_end_date" HeaderText="End Date" SortExpression="exam_end_date" />
                            <asp:BoundField DataField="tot_marks" HeaderText="Total Marks" SortExpression="tot_marks" />
                            <asp:BoundField DataField="passing_marks" HeaderText="Pssing Marks" SortExpression="passing_marks" />
                            <asp:BoundField DataField="duration" HeaderText="Duration" SortExpression="duration" />
                            <asp:BoundField DataField="tot_que" HeaderText="Total Question" SortExpression="tot_que" />
                            </Columns>
                                <FooterStyle BackColor="#FFFF99" BorderColor="#FF9900" BorderStyle="Dashed" Wrap="True" />
                                <HeaderStyle BackColor="Gray" BorderColor="Gray" HorizontalAlign="Center" />
                                <PagerStyle BackColor="#FFFF99" BorderColor="#FFCC00" HorizontalAlign="Center" />
                                <RowStyle BackColor="#CCCCCC" BorderColor="#CCCCCC" HorizontalAlign="Center" />
                            </asp:GridView>
                            



                            <%--result panel--%>
                            <asp:GridView ID="grdresult" runat="server" AutoGenerateColumns="false" CssClass="table table-mailbox" HorizontalAlign="Center" OnRowCommand="grd_result_RowCommand"> 
                            <Columns>
                            <asp:TemplateField HeaderText="Exam Name">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="linkbtnexamname1" runat="server" Text="<%#Bind('[Exam_Name]') %>"
                                                CommandName="Exam_Id" CommandArgument='<%#Bind("[Exam_Id]") %>'>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="exam_name" HeaderText="Exam Name" SortExpression="Exam_Name" />--%>
                            <asp:BoundField DataField="reg_date" HeaderText="Registration Date" SortExpression="reg_date" />
                            <asp:BoundField DataField="Exam_Date" HeaderText="Exam Date" SortExpression="exam_date" />
                            <asp:BoundField DataField="exam_given_date" HeaderText="Exam Given Date" SortExpression="exam_given_date" />
                            <asp:BoundField DataField="Result" HeaderText="Result" SortExpression="status_pf" />
                            <asp:BoundField DataField="Score" HeaderText="Score" SortExpression="score" />
                            <asp:BoundField DataField="percentage" HeaderText="Percentage" SortExpression="percentage" />
                            <asp:BoundField DataField="tot_marks" HeaderText="Total Marks" SortExpression="tot_marks" />
                            <asp:BoundField DataField="passing_marks" HeaderText="Passing Marks" SortExpression="passing_marks" />
                            </Columns>
                                <FooterStyle BackColor="#FFFF99" BorderColor="#FF9900" BorderStyle="Dashed" Wrap="True" />
                                <HeaderStyle BackColor="Gray" BorderColor="Gray" HorizontalAlign="Center" />
                                <PagerStyle BackColor="#FFFF99" BorderColor="#FFCC00" HorizontalAlign="Center" />
                                <RowStyle BackColor="#CCCCCC" BorderColor="#CCCCCC" HorizontalAlign="Center" />
                            </asp:GridView>


                            <asp:HiddenField ID="hdn_exam_list" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
