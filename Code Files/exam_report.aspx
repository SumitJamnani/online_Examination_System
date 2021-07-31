<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="exam_report.aspx.cs" Inherits="exam_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="col-lg-4">
    </div>
    <div class="col-lg-4">
    Select Exam
    <asp:DropDownList ID="drpexamname" runat="server" AutoPostBack="True">
    </asp:DropDownList>
  <asp:Button ID="btnresult" runat="server" Text="RESULT RATIO" 
           onclick="btnresult_Click" />
  
    <asp:GridView ID="grd_result" runat="server" 
        onrowdatabound="grd_result_RowDataBound">
    </asp:GridView>
       </div>
    <div class="col-lg-4">
    </div>
</asp:Content>

