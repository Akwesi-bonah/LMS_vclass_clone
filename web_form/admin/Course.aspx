<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Admin.Master" AutoEventWireup="true" CodeBehind="Course.aspx.cs" Inherits="vclass_clone.web_form.admin.Course" %>
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
                            <h3>Add Course</h3>
                        </div>
                        <div class="card-body">
                            <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="False" />
                            <div class="form-group">
                                <label for="txtCourseName">Name</label>
                                <asp:TextBox ID="txtCourseName" TextMode="SingleLine" runat="server" CssClass="form-control" Placeholder="Course Name" />
                            </div>
                            <div class="form-group">
                                <label for="txtCourseCode">Code</label>
                                <asp:TextBox ID="txtCourseCode" TextMode="SingleLine" runat="server" CssClass="form-control" Placeholder="Course Code" />
                            </div>
                            <div class="form-group">
                                <label for="txtCourseDescription">Description</label>
                                <asp:TextBox ID="txtCourseDescription" TextMode="MultiLine" runat="server" CssClass="form-control" Placeholder="Course Description" />
                            </div>
                            <div class="form-group">
                                <label for="txtCourseLevel">Level</label>
                                <asp:DropDownList ID="dbLevel" CssClass="form-select" runat="server">
                                    <asp:ListItem>select level</asp:ListItem>
                                    <asp:ListItem>100</asp:ListItem>
                                    <asp:ListItem>200</asp:ListItem>
                                    <asp:ListItem>300</asp:ListItem>
                                    <asp:ListItem>400</asp:ListItem>

                                </asp:DropDownList>
                                <asp:TextBox ID="txtCourseLevel" TextMode="SingleLine" runat="server" CssClass="form-control" Placeholder="Course Level" />
                            </div>
                            <%--<div class="form-group">
                                <label for="DropDownListDepartments">Department</label>
                                <asp:DropDownList ID="DropDownListDepartments" CssClass="form-select" runat="server" DataSourceID="sqlDepartment" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
                                <asp:SqlDataSource ID="sqlDepartment" runat="server" ConnectionString="<%$ ConnectionStrings:LMSContext %>" SelectCommand="SELECT [Id], [Name] FROM [DepartmentDBs]"></asp:SqlDataSource>
                            </div>--%>
                            <asp:Button ID="btnAddCourse" runat="server" Text="Add Course" CssClass="btn btn-primary" OnClick="btnAddCourse_Click" />
                        </div>
                    </div>
                </div>

                <!-- Table Section: Large on the right -->
                <div class="col-md-8">
                    <div class="card mb-4">
                        <div class="card-body">
                            <h4 class="card-title">Course List</h4>
                            <p class="card-description">Manage your courses here.</p>
                            <div class="table-responsive">
                                <asp:GridView ID="courseList" CssClass="table table-striped" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlCourse" DataKeyNames="Id">
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                        <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code" />
                                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                                        <asp:BoundField DataField="Level" HeaderText="Level" SortExpression="Level" />
                                       <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CommandArgument='<%# Eval("Id") %>' Text="Edit" CssClass="btn btn-primary" />
                                                <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("Id") %>' Text="Delete" CssClass="btn btn-danger" OnClientClick="return confirm('Are you sure you want to delete this record?');" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlCourse" runat="server" ConnectionString="<%$ ConnectionStrings:LMSContext %>"
                                    SelectCommand="SELECT * FROM [CourseDBs]"></asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
