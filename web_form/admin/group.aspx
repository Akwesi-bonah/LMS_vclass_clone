<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Admin.Master" AutoEventWireup="true" CodeBehind="group.aspx.cs" Inherits="vclass_clone.web_form.admin.group" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper">
        <div class="row">
            <div class="container">
                <div class="row">
                    <!-- Form Section: Small on the left -->
                    <div class="col-md-4">
                        <div class="card mb-4">
                            <div class="card-header bg-primary text-white">
                                <h3>Add Group</h3>
                            </div>
                            <div class="card-body">
                                <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="False" />
                                <div class="form-group">
                                    <label for="txtGroupName">Name</label>
                                    <asp:TextBox ID="txtGroupName" TextMode="SingleLine" runat="server" CssClass="form-control" Placeholder="Group Name" />
                                </div>
                                <div class="form-groud">
                                    <asp:DropDownList ID="DropDownList1" CssClass="form-select" runat="server" DataSourceID="sqlDepartment" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
                                    <asp:SqlDataSource ID="sqlDepartment" runat="server" ConnectionString="<%$ ConnectionStrings:LMSContext %>" SelectCommand="SELECT [Id], [Name] FROM [DepartmentDBs]"></asp:SqlDataSource>
                                </div>
                                <div class="form-group">
                                    <label for="txtGroupDescription">Description</label>
                                    <asp:TextBox ID="txtGroupDescription" TextMode="MultiLine" runat="server" CssClass="form-control" Placeholder="Group Description" />
                                </div>
                                <asp:Button ID="btnAddGroup" runat="server" Text="Add Group" CssClass="btn btn-primary" OnClick="btnAddGroup_Click" />
                            </div>
                        </div>
                    </div>

                    <!-- Table Section: Large on the right -->
                    <div class="col-md-8">
                        <div class="card mb-4">
                            <div class="card-body">
                                <h4 class="card-title">Group List</h4>
                                <p class="card-description">Manage your user groups here.</p>
                                <div class="table-responsive">
                                    <asp:GridView ID="groupList" CssClass="table table-striped" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlGroup" DataKeyNames="Id">
                                        <Columns>
                                            <asp:BoundField DataField="Id" HeaderText="Id"  ReadOnly="True" SortExpression="Id" />
                                            <asp:BoundField DataField="GroupName" HeaderText="Name" SortExpression="Name" />
                                            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                                            <asp:BoundField DataField="DepartmentName" HeaderText="Department Name" SortExpression="DepartmentName" />

                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CommandArgument='<%# Eval("Id") %>' Text="Edit" CssClass="btn btn-primary btn-sm" />
                                                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("Id") %>' Text="Delete" CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure you want to delete this record?');" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="SqlGroup" runat="server" ConnectionString="<%$ ConnectionStrings:LMSContext %>"
                                        SelectCommand="SELECT g.Id, g.Name AS GroupName, g.Description, d.Name AS DepartmentName 
                    FROM [GroupDBs] g 
                    LEFT JOIN [DepartmentDBs] d ON g.DepartmentId = d.Id"></asp:SqlDataSource>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
