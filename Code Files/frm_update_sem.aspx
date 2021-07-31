<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="frm_update_sem.aspx.cs" Inherits="frm_update_sem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <form id="form1" runat="server">
    <asp:DropDownList ID="drpoldsem" runat="server" AutoPostBack="True">
    </asp:DropDownList><br />
    <asp:DropDownList ID="drpnewsem" runat="server" AutoPostBack="True">
    </asp:DropDownList><br />
    <asp:Button ID="btnupdatesem" runat="server" Text="Button" />
    </form>
</asp:Content>

