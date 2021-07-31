<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frm_result.aspx.cs" Inherits="frm_result" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="col-xs-12">
<div style="background-color:#FFCC99;  ">

<center>
    <asp:Label ID="txt" runat="server" Text="RESULT" 
        Font-Bold="True" Font-Italic="False" Font-Size="X-Large" Font-Strikeout="False" 
        Font-Underline="False" ForeColor="Black" Font-Names="Britannic Bold"></asp:Label>
        <br />
        <br />
<div class="box-body">
    <table class="table table-responsive"  style="width: 600px">
       
        
        <tr>
            <th>
                Exam Name  
            </th>
            <td>
                :
            </td>
            <td>
                <asp:Label ID="lbl_exam_name" runat="server" Text=""></asp:Label>
            </td>
        </tr>  

       
         <tr>
            <th>
                Total Questions  
            </th>
            <td>
                :
            </td>
            <td>
                <asp:Label ID="tot_questions" runat="server" Text=""></asp:Label>
            </td>
        </tr>  
         <tr>
            <th>
                Right Answers  
            </th>
            <td>
                :
            </td>
            <td>
                <asp:Label ID="lbl_right_ans" runat="server" Text=""></asp:Label>
            </td>
        </tr>  

         <tr>
            <th>
                Wrong Answers   
            </th>
            <td>
                :
            </td>
            <td>
                <asp:Label ID="lbl_wrong_ans" runat="server" Text=""></asp:Label>
            </td>
        </tr>  

         <tr>
            <th>
                Status  
            </th>
            <td>
                :
            </td>
            <td>
                <asp:Label ID="lbl_status" runat="server" Text=""></asp:Label>
            </td>
        </tr>  

         <tr>
            <th>
               <%-- Score  --%>
               Marks Obtained
            </th>
            <td>
                :
            </td>
            <td>
                <asp:Label ID="lbl_score" runat="server" Text=""></asp:Label>
            </td>


        </tr>
        
        <tr>
            <th>
                 Passing Marks
            </th>
            <td>
                :
            </td>
            <td>
                <asp:Label ID="lbl_passing" runat="server" Text=""></asp:Label>
            </td>
        </tr>    
        <tr>
            <th>
                 Total Marks
            </th>
            <td>
                :
            </td>
            <td>
                <asp:Label ID="lbl_totalmarks" runat="server" Text=""></asp:Label>
            </td>
        </tr>    
         <tr>
            <th>
                 Percentage 
            </th>
            <td>
                :
            </td>
            <td>
                <asp:Label ID="lbl_percentage" runat="server" Text=""></asp:Label>
            </td>
        </tr>  
        
        

    </table>
                    
                                   
                                   
</div>

    </div>
    <div style="text-align:center;">
    <asp:Button ID="btnview" runat="server" Text="View Answers" 
            CssClass="btn btn-primary btn-sm" onclick="btnview_Click"  /> </div>
            </div>

</center>
</asp:Content>