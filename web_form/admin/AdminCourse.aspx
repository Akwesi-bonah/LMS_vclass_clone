<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Admin.Master" AutoEventWireup="true" CodeBehind="AdminCourse.aspx.cs" Inherits="vclass_clone.web_form.admin.Course" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper">
        <div class="row">
            <div class="container">
                <div class="row">
                    <!-- Form Section -->
                    <div class="col-md-4">
                        <div class="card mb-">
                            <div class="card-header bg-primary text-white">
                                <asp:Label runat="server" ID="lblheader" Text="Add Course"></asp:Label>
                            </div>
                            <div class="card-body">
                             <asp:HiddenField ID="hCuId" runat="server" />

                                <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="False" />
                                <asp:Label ID="lblSuccess" runat="server" CssClass="badge badge-success" Visible="false">
                                    Success message here
                                </asp:Label>
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
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:Button ID="btnAddCourse" runat="server" Text="Add Course" CssClass="btn btn-primary" OnClick="btnAddCourse_Click" />
                                        <asp:Button ID="btnUpdateCourse" runat="server" Text="Update Course" CssClass="btn btn-primary" OnClick="btnUpdateCourse_Click" Visible="false" />
                                    </div>

                                    <div class="col-md-6 text-right">
                                        <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-secondary" OnClick="btnClear_Click" />
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>

                    <!-- Table Section -->
                    <div class="col-md-8">
                        <div class="card mb-4">
                            <div class="card-body">
                                <h4 class="card-title">Course List</h4>
                                <p class="card-description">Manage your courses here.</p>
                                <asp:Label ID="lblgsus" runat="server" CssClass="badge badge-success" Visible="false">
                                    Success message here
                                </asp:Label>
                                <div class="table-responsive">

                                    <asp:GridView ID="CourseList" CssClass="table table-boarded" runat="server" AllowPaging="True"
                                        AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" OnRowCommand="CourseList_RowCommand" OnRowDeleting="CourseList_RowDeleting">
                                        <Columns>
                                            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" Visible="false" />
                                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                            <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code" />
                                            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                                            <asp:BoundField DataField="Level" HeaderText="Level" SortExpression="Level" />
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEdit" runat="server" CommandName="EditCourse" CommandArgument='<%# Eval("Id") %>'
                                                        Text="Edit" CssClass="btn btn-primary" />
                                                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="DeleteCourse" CommandArgument='<%# Eval("Id") %>'
                                                        Text="Delete" CssClass="btn btn-danger" OnClientClick="return confirm('Are you sure you want to delete this record?');" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
