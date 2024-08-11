<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Facilitator.Master" AutoEventWireup="true" CodeBehind="assigmentList.aspx.cs" Inherits="vclass_clone.web_form.facilitator.assigmentList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2>Assignments</h2>
        
        <asp:GridView ID="gvAssignments" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
            <Columns>
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-warning btn-sm">Edit</asp:LinkButton>
                        <asp:LinkButton ID="btnViewSubmissions" runat="server" CommandName="ViewSubmissions" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-info btn-sm">View Submissions</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        
        <asp:LinkButton ID="btnAddAssignment" runat="server" CssClass="btn btn-primary mt-4" PostBackUrl="~/AddAssignment.aspx">Add New Assignment</asp:LinkButton>
    </div>
</asp:Content>

