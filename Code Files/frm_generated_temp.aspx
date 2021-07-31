<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="frm_generated_temp.aspx.cs" Inherits="frm_generated_temp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center><font>LJ COLLEGE OF COMPUTER APPLICATIONS</font></center>
<form runat="server">
<%=qstr %>

<asp:Label runat="server" ID="sub"></asp:Label>
<asp:TreeView ID="TreeView1" runat="server"></asp:TreeView>
</form>
</asp:Content>

