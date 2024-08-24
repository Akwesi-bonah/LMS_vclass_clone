<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Facilitator.Master" AutoEventWireup="true" CodeBehind="assigmentList.aspx.cs" Inherits="vclass_clone.web_form.facilitator.assigmentList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <div class="d-flex justify-content-between align-items-center mb-4">
            <h2>Assignments</h2>
            <asp:LinkButton ID="btnAddAssignment" runat="server" CssClass="btn btn-primary" PostBackUrl="../facilitator/addAssigment.aspx" OnClick="btnAddAssignment_Click">
                <i class="fa fa-plus"></i> Add New Assignment
            </asp:LinkButton>
        </div>

        <!-- Message Label -->
        <asp:Label ID="lblAssignmentMessage" runat="server" Text="" CssClass="alert alert-info mt-3" Visible="false"></asp:Label>

        <div class="card shadow-sm">
            <div class="card-body">
                <asp:GridView ID="gvAssignments" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover" OnRowCommand="gvAssignments_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Title" HeaderText="Title" />
                        <asp:BoundField DataField="Description" HeaderText="Description" />
                        <asp:BoundField DataField="DueDate" HeaderText="Due Date" DataFormatString="{0:yyyy-MM-dd}" />
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <div class="btn-group">
                                    <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-warning btn-sm">
                        <i class="fa fa-edit"></i> Edit
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnViewSubmissions" runat="server" CommandName="ViewSubmissions" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-info btn-sm">
                        <i class="fa fa-folder-open"></i> View Submissions
                                    </asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>
        </div>
    </div>
</asp:Content>


