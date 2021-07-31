<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="frm_static_template.aspx.cs" Inherits="frm_static_template" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="frm" runat="server">
    <section class="content-header">
                    <h1>
                        Template                        
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="frm_admin_main.aspx"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li><a href="#">Master Pages</a></li>
                        <li class="active">Template</li>
                    </ol>
                </section>
    <%--template--%>
    <div class="col-xs-12">
        <div class="col-md-12">
            <div class="box box-primary">
                <asp:Panel ID="pnltemp" runat="server">
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Template Name :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txttpname" runat="server" CssClass="form-control" placeholder="Enter Template Name"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Total Marks :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtmarks" runat="server" CssClass="form-control" placeholder="Enter Total Marks"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Total Subjective Questions :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtsubjective" runat="server" CssClass="form-control" placeholder="Enter Total Subjective Questions"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Total Objective Questions :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtobjective" runat="server" CssClass="form-control" placeholder="Enter Total Objective Questions"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="box-body pad table-responsive">
                            <div class="rounded-button">
                                <asp:Button ID="btnnext" runat="server" Text="Next Panel" class="btn btn-success btn-sm"
                                    OnClick="btnnext_Click" />
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <%--section--%>
                <asp:Panel ID="pnlsection" runat="server">
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Enter Section Name :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtsecname" runat="server" CssClass="form-control" placeholder="Enter Total Marks"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Enter Marks of Section :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtsecmarks" runat="server" CssClass="form-control" placeholder="Enter Total Marks"></asp:TextBox>
                            <asp:Label runat="server" ID="lblsecmarks"></asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Enter Questions :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtsubsec" runat="server" CssClass="form-control" placeholder="Enter Total Marks"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <asp:Button ID="btnsave1" runat="server" Text="Save" OnClick="btnsave1_Click" />
                        <asp:Button ID="btnnext1" runat="server" Text="Next Panel" OnClick="btnnext1_Click" />
                        <asp:Button ID="btnno" runat="server" Text="No" OnClick="btnno_Click" />
                    </div>
                    <div class="col-lg-12">
                        <div class="box-body">
                            <asp:GridView ID="grdpnl1" AutoGenerateColumns="false" runat="server" 
                               CssClass="table table-mailbox"
                                HorizontalAlign="Center" onrowcommand="grdpnl1_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="Section Id">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" Text="<%#Bind('[Section_Id]') %>" CommandName="Section_Id"
                                                CommandArgument='<%#Bind("[Section_Id]") %>'>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Section_Name" HeaderText="Section Name" />
                                    <asp:BoundField DataField="Marks" HeaderText="Marks" />
                                    <asp:BoundField DataField="noofquestions" HeaderText="No of Question" />
                                </Columns>
                                <FooterStyle BackColor="#FFFF99" BorderColor="#FF9900" BorderStyle="Dashed" Wrap="True" />
                                <HeaderStyle BackColor="Gray" BorderColor="Gray" />
                                <PagerStyle BackColor="LightGray" BorderColor="LightGray" />
                                <RowStyle BackColor="#CCCCCC" BorderColor="#CCCCCC" />
                            </asp:GridView>
                            
                            <asp:HiddenField ID="hdngrdpnl1" runat="server" />
                        </div>
                    </div>
                </asp:Panel>
                <%--  sub section--%>
                <asp:Panel ID="pnlsubsection" runat="server">
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select Section Name :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpsection" runat="server" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown" AutoPostBack="True" 
                                OnSelectedIndexChanged="drpsection_SelectedIndexChanged" Width="82px">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select Question Name :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpsubsection" runat="server" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown" OnSelectedIndexChanged="drpsubsection_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtsubsecmarks" runat="server"></asp:TextBox>
                            <asp:Label runat="server" ID="lblsubsecmarks"></asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Enter Sub Question :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtsubsec1" runat="server" CssClass="form-control" placeholder="Enter Total Marks"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <asp:Button ID="btnsave2" runat="server" Text="Save" OnClick="btnsave2_Click" />
                        <asp:Button ID="btnnext2" runat="server" Text="Next Panel" OnClick="btnnext2_Click" />
                        <asp:Button ID="btnno2" runat="server" Text="No" OnClick="btnno2_Click" />
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlsubsection1" runat="server">
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select Section :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpsection1" runat="server" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown" AutoPostBack="True" OnSelectedIndexChanged="drpsection1_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select Question :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpsubsection1" runat="server" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown" AutoPostBack="True" OnSelectedIndexChanged="drpsubsection1_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select Sub Question :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpsubsec1" runat="server" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown" OnSelectedIndexChanged="drpsubsec1_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtsubsecmarks1" runat="server" CssClass="form-control" placeholder="Enter Total Marks"></asp:TextBox>
                            <asp:Label runat="server" ID="lblsubquemks"></asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Enter Subquestion :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtsubsec2" runat="server" CssClass="form-control" placeholder="Enter Total Marks"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <asp:Button ID="btnsave3" runat="server" Text="Save" OnClick="btnsave3_Click" />
                        <asp:Button ID="btnnext3" runat="server" Text="No" OnClick="btnnext3_Click" />
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlquestion" runat="server">
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select Section :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpsection2" runat="server" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown" AutoPostBack="True" OnSelectedIndexChanged="drpsection2_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select Question :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpsubsection2" runat="server" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown" AutoPostBack="True" OnSelectedIndexChanged="drpsubsection2_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select Sub Question :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpsubsec2" runat="server" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown" AutoPostBack="True" OnSelectedIndexChanged="drpsubsec2_SelectedIndexChanged"
                                Height="16px">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Question :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpque" runat="server" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown" OnSelectedIndexChanged="drpque_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtselque" runat="server" placeholder="Enter Total Marks"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Subjective/Objective :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:RadioButtonList ID="rblquetype" runat="server" AutoPostBack="True">
                                <asp:ListItem>Subjective</asp:ListItem>
                                <asp:ListItem>Objective</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Or Question :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtor" runat="server" CssClass="form-control" placeholder="Enter Total Marks"></asp:TextBox>
                            <asp:LinkButton ID="lbor" runat="server" OnClick="lbor_Click">OR</asp:LinkButton>
                            <asp:DropDownList ID="drpor" runat="server" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown" OnSelectedIndexChanged="drpor_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtormarks" runat="server" CssClass="form-control" placeholder="Enter Total Marks"></asp:TextBox>
                            <asp:RadioButtonList ID="rblorquetype" runat="server" AutoPostBack="True">
                                <asp:ListItem>Subjective</asp:ListItem>
                                <asp:ListItem>Objective</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <asp:Button ID="btnsave4" runat="server" Text="Save" OnClick="btnsave4_Click" />
                        <asp:Button ID="btnfinish" runat="server" Text="Finish" />
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlquestion1" runat="server">
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select Section :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpsection3" runat="server" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown" AutoPostBack="True" OnSelectedIndexChanged="drpsection3_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select Question Name :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpque3" runat="server" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtquemarks3" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Subjective/Objective :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:RadioButtonList ID="rbnquetype1" runat="server" AutoPostBack="True">
                                <asp:ListItem>Subjective</asp:ListItem>
                                <asp:ListItem>Objective</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Or Question :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtor1" runat="server" CssClass="form-control" placeholder="Enter Total Marks"></asp:TextBox>
                            <asp:LinkButton ID="lbor1" runat="server" OnClick="lbor1_Click">OR</asp:LinkButton>
                            <asp:DropDownList ID="drpor1" runat="server" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtormarks1" runat="server" CssClass="form-control" placeholder="Enter Total Marks"></asp:TextBox>
                            <asp:RadioButtonList ID="rblorquetype1" runat="server" AutoPostBack="True">
                                <asp:ListItem>Subjective</asp:ListItem>
                                <asp:ListItem>Objective</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <asp:Button ID="btnsave5" runat="server" Text="Save" OnClick="btnsave5_Click" />
                        <asp:Button ID="btnfinish1" runat="server" Text="Finish" />
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlquestion2" runat="server">
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select Section :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpsection4" runat="server" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown" AutoPostBack="True" OnSelectedIndexChanged="drpsection4_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select Question Name :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpsubsection4" runat="server" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown" AutoPostBack="True" OnSelectedIndexChanged="drpsubsection4_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Select Sub Question :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:DropDownList ID="drpsubsec4" runat="server" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtquemarks4" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Subjective/Objective :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:RadioButtonList ID="rblquetype2" runat="server" AutoPostBack="True">
                                <asp:ListItem>Subjective</asp:ListItem>
                                <asp:ListItem>Objective</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-xs-2 box-body">
                            Or Question :
                        </div>
                        <div class="col-xs-10 box-body">
                            <asp:TextBox ID="txtor2" runat="server" CssClass="form-control" placeholder="Enter Total Marks"></asp:TextBox>
                            <asp:LinkButton ID="lbor2" runat="server" OnClick="lbor2_Click">OR</asp:LinkButton>
                            <asp:DropDownList ID="drpor2" runat="server" class="btn btn-default dropdown-toggle"
                                data-toggle="dropdown">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtormarks2" runat="server" CssClass="form-control" placeholder="Enter Total Marks"></asp:TextBox>
                            <asp:RadioButtonList ID="rblorquetype2" runat="server" AutoPostBack="True">
                                <asp:ListItem>Subjective</asp:ListItem>
                                <asp:ListItem>Objective</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <asp:Button ID="btnsave6" runat="server" Text="Save" OnClick="btnsave6_Click" />
                        <asp:Button ID="btnfinish2" runat="server" Text="Finish" />
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
