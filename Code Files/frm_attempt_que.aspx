<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="frm_attempt_que.aspx.cs" Inherits="frm_attempt_que" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 0);
        window.onunload = function () { null };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="col-lg-12">
    <div class="box box-success">
        <div class="box-header">
            <h3 class="box-title">
                <asp:Label ID="lblquestion" runat="server" Text=""></asp:Label>
            </h3>
        </div>
        <div class="box-body">
            <div class="form-group">
                <asp:RadioButton ID="o1" runat="server" GroupName="options" AutoPostBack="false" /><br />
                <asp:RadioButton ID="o2" runat="server" GroupName="options" AutoPostBack="false" /><br />
                <asp:RadioButton ID="o3" runat="server" GroupName="options" AutoPostBack="false" /><br />
                <asp:RadioButton ID="o4" runat="server" GroupName="options" AutoPostBack="false" />
            </div>
        </div>
        <div class="box-body pad table-responsive">
            <div class="rounded-button">
                <asp:Button ID="btnsubmit" runat="server" Text="Next" OnClick="btnsubmit_Click" Width="58px"
                    class="btn btn-success btn-sm" />
                <asp:Button ID="btn_end" runat="server" Text="SUBMIT" Visible="False" OnClick="btn_end_Click"
                    class="btn btn-success btn-sm" />
                <asp:Button ID="btncancel" runat="server" Text="Cancel" OnClick="btncancel_Click"
                    class="btn btn-success btn-sm" />
                <%-- <asp:Button ID="btn_pre" runat="server" Text="Previous" />--%>
            </div>
        </div>
    </div>
    <div>
        <asp:UpdateProgress ID="prg_ans" runat="server">
        </asp:UpdateProgress>
    </div>
    <div class="box box-info">
        <div class="box-header">
            <h3 class="box-title">
                <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                <asp:Label ID="lbl_questions" runat="server" Text=""></asp:Label></h3>
        </div>
    </div>
</div>
    <asp:HiddenField ID="hdn_que_id" runat="server" />
    <asp:HiddenField ID="hdnquestion" runat="server" />
    <asp:HiddenField ID="hdntotQ" runat="server" />
    </asp:Timer>
    <asp:HiddenField ID="hdn_number" runat="server" Value="0" />
    <asp:HiddenField ID="hdn_result" runat="server" />
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
</asp:Content>
