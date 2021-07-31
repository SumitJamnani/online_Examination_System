<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frm_stud_exam_reg.aspx.cs" Inherits="frm_stud_exam_reg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table>

    <tr>
        <td>Exam_Name</td>
        <td>
            <asp:DropDownList ID="drpexamname" runat="server"  AutoPostBack="true"
                onselectedindexchanged="drpexamname_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
    </tr>
   
   <tr>
    <td>
        Subject Name :
    </td>
    <td>
        <asp:Label ID="lblsubname" runat="server"></asp:Label>
        
    </td>
   </tr>

   <tr>
        <td> 
            Unit Name :
        </td>
        <td>
        <asp:Label ID="lblunit" runat="server"></asp:Label>
        
        </td>

   </tr>

    
    <tr>
        <td>Exam Date</td>
        <td>
            <asp:TextBox ID="txtdate" runat="server"  
                ReadOnly="True" ></asp:TextBox>
            <asp:Calendar ID="calender_exam_type" runat="server" 
                ondayrender="calender_exam_type_DayRender" 
                onselectionchanged="calender_exam_type_SelectionChanged" BackColor="White" 
                BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" 
                ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
                    VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" 
                    Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                <TodayDayStyle BackColor="#CCCCCC" />
            </asp:Calendar>

        </td>
        
    </tr>
      <tr>
        <td>
            <asp:Button ID="btnsubmit" runat="server" Text="Submit" 
                onclick="btnsubmit_Click" />
         </td>
         <td>
             <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
         </td>
      </tr>
</table>

    <asp:GridView ID="grdexamstud" runat="server" AutoGenerateColumns="false"
    AllowSorting="true" AllowPaging="true" onpageindexchanging="grdexamstud_PageIndexChanging"
     >
     <Columns>
           
              <asp:TemplateField HeaderText="Student Id">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server"  Text="<%#Bind('[Stud_Id]') %>"
                                    CommandName="Stud_Id" CommandArgument='<%#Bind("[Stud_Id]") %>'>
                                </asp:LinkButton>
                            </ItemTemplate>

                        </asp:TemplateField>
                      
            <asp:BoundField DataField="Exam_Name" HeaderText="Exam Name" SortExpression="exam_name"/> 
            <asp:BoundField DataField="Sub_Name" HeaderText="Subject Name" SortExpression="sub_name"/>          
          <asp:BoundField DataField="Exam_Date" HeaderText="Exam Date" SortExpression="exam_date"/> 
                 
        </Columns>
    </asp:GridView>
</asp:Content>

