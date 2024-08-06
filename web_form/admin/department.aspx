<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Admin.Master" AutoEventWireup="true" CodeBehind="department.aspx.cs" Inherits="vclass_clone.web_form.admin.department" %>

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
                            <h3>Add Department</h3>
                        </div>
                        <div class="card-body">
                            <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="False" />
                            <div class="form-group">
                                <label for="txtName">Name</label>
                                <asp:TextBox ID="txtName" TextMode="SingleLine" runat="server" CssClass="form-control" Placeholder="Department Name" />
                            </div>
                            <div class="form-group">
                                <label for="txtDescription">Description</label>
                                <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" CssClass="form-control" Placeholder="Department Description" />
                            </div>
                            <asp:Button ID="btnAddDepartment" runat="server" Text="Add Department" CssClass="btn btn-primary" OnClick="btnAddDepartment_Click" />
                        </div>
                    </div>
                </div>
                
                <!-- Table Section: Large on the right -->
                <div class="col-md-8">
                    <div class="card mb-4">
                        <div class="card-body">
                            <h4 class="card-title">Department List</h4>
                            <p class="card-description">Manage your departments here.</p>
                            <div class="table-responsive">
                                <asp:GridView ID="departmentList" CssClass="table table-striped" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="Sqldepartment" DataKeyNames="Id">
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CommandArgument='<%# Eval("Id") %>' Text="Edit" CssClass="btn btn-primary btn-sm" />
                                                <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("Id") %>' Text="Delete" CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure you want to delete this record?');" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="Sqldepartment" runat="server" ConnectionString="<%$ ConnectionStrings:LMSContext %>" SelectCommand="SELECT [Id], [Name], [Description] FROM [DepartmentDBs]"></asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
