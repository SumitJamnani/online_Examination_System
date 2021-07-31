<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="select_exam.aspx.cs" Inherits="select_exam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-lg-4">
    </div>
    <div class="col-lg-4">
    Select Exam    <asp:DropDownList ID="drpexamname" runat="server">
        </asp:DropDownList><br />

Select Status        <asp:DropDownList ID="drpstartstop" runat="server">
<asp:ListItem Text="--Select Status--" Value = ""></asp:ListItem>
<asp:ListItem Text="Stop" Value = "0"></asp:ListItem>
<asp:ListItem Text="Start" Value = "1"></asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfs" runat="server" ControlToValidate="drpstartstop" ErrorMessage =" Please select the exam status"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="btnexam" runat="server" Text="EXAM" OnClick="btnexam_Click" />
    </div>
    <div class="col-lg-4">
    </div>
</asp:Content>
