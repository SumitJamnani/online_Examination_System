<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="frm_reg.aspx.cs" Inherits="frmreg" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hdnregid" runat="server" />
    <table>
        <tr>
            <td>
                Email
            </td>
            <td>
                <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="msg1"
                    ControlToValidate="txtemail" ErrorMessage="Pl. Enter Valid Email" ForeColor="#CC0000"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="msg1"
                    ControlToValidate="txtemail" ErrorMessage="Email Requierd" ForeColor="#CC0000"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                First Name
            </td>
            <td>
                <asp:TextBox ID="txtfname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Middle Name
            </td>
            <td>
                <asp:TextBox ID="txtmname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Last Name
            </td>
            <td>
                <asp:TextBox ID="txtlname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Gender
            </td>
            <td>
                <asp:RadioButtonList ID="rblgender" runat="server" AutoPostBack="True">
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rblgender"
                    ErrorMessage="Pl. Select Gender" ForeColor="#CC0000"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Date Of Birth
            </td>
            <td>
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
                <asp:TextBox ID="txtdate" runat="server" CssClass="form-control" />
                
                <asp:ImageButton ID="calimgbtn" runat="server" Height="19px" 
                    ImageUrl="~/CalenderImageIcon.png" Width="21px" />
                <asp:CalendarExtender ID="txtdatecalext" runat="server" Format="MM/dd/yyyy" 
                    PopupButtonID="calimgbtn" PopupPosition="BottomRight" 
                    TargetControlID="txtdate" >
                </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td>
                Add_1
            </td>
            <td>
                <asp:TextBox ID="txtadd1" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Add_2
            </td>
            <td>
                <asp:TextBox ID="txtadd2" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                City Name
            </td>
            <td>
                <asp:DropDownList ID="drpcity" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Semester :
            </td>
            <td>
                <asp:DropDownList ID="drpsem" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
                <tr>
                <td>
                    Roll No : 
                </td>
                <td>
                    <asp:TextBox ID="txtrollno" runat="server"></asp:TextBox>
                </td>
                </tr>

                <tr>
                    <td>Division : </td>
                    <td>
                        <asp:DropDownList ID="drpdivision" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>

        <tr>
            <td>
                Password
            </td>
            <td>
                <asp:TextBox ID="txtpassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Confirm Password
            </td>
            <td>
                <asp:TextBox ID="txtcpassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ValidationGroup="msg1"
                    ControlToCompare="txtpassword" ControlToValidate="txtcpassword" ErrorMessage="Password not Matched"
                    ForeColor="#CC0000"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>
                Photo
            </td>
            <td>
                <asp:FileUpload ID="flupload" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Security Que
            </td>
            <td>
                <asp:DropDownList ID="drpsecque" runat="server" AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Security Ans
            </td>
            <td>
                <asp:TextBox ID="txtsecans" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtsecans"
                    ErrorMessage="Pl. Enter Sec Ans"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Recaptcha
            </td>
            <td>
                <cc1:CaptchaControl ID="cptCaptcha" runat="server" CaptchaBackgroundNoise="Low" CaptchaLength="5"
                    CaptchaHeight="60" CaptchaWidth="200" CaptchaLineNoise="None" CaptchaMinTimeout="5"
                    CaptchaMaxTimeout="240" FontColor="#529E00" BackColor="White" />
                <asp:TextBox ID="txtrecaptcha" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtrecaptcha"
                    ErrorMessage="Pl. Enter Captcha"></asp:RequiredFieldValidator>
                <asp:Label ID="lblcaptcha" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnsubmit" runat="server" Text="Submit" ValidationGroup="msg1" OnClick="btnsubmit_Click" />
                <asp:Button ID="btncancel" runat="server" Text="Cancel" OnClick="btncancel_Click" />
                <br />
                <asp:Label ID="lbl" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <asp:GridView ID="grdreg" AutoGenerateColumns="false" runat="server" OnRowCommand="grdreg_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="Reg Id">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" Text="<%#Bind('[Reg_Id]') %>" CommandName="Reg_Id"
                            CommandArgument='<%#Bind("[Reg_Id]") %>'>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="email" HeaderText="Email" />
                <asp:BoundField DataField="f_name" HeaderText="First Name" />
                <asp:BoundField DataField="m_name" HeaderText="Middle Name" />
                <asp:BoundField DataField="l_name" HeaderText="Last Name" />
                <asp:BoundField DataField="gender" HeaderText="Gender" />
                <asp:BoundField DataField="dob" HeaderText="DOB" />
                <asp:BoundField DataField="add_1" HeaderText="Add 1" />
                <asp:BoundField DataField="add_2" HeaderText="Add 2" />
                <asp:BoundField DataField="city_name" HeaderText="City" />
                <asp:BoundField DataField="sec_id" HeaderText="sec_ans" />
            </Columns>
        </asp:GridView>
    </table>
</asp:Content>
