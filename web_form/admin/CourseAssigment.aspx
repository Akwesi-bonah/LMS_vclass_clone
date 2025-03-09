<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Admin.Master" AutoEventWireup="true" CodeBehind="CourseAssigment.aspx.cs" Inherits="vclass_clone.web_form.admin.CourseAssigment" %>

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
                                <asp:Label runat="server" ID="lblheader" Text="Assign Course"></asp:Label>
                            </div>
                            <div class="card-body">
                                <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="False" />
                                <asp:Label ID="lblSuccess" runat="server" CssClass="badge badge-success" Visible="false">Success message here</asp:Label>
                                <div class="form-group">
                                    <asp:HiddenField ID="hCuId" runat="server" />
                                    <label for="DropDownListCourses">Course</label>
                                    <asp:DropDownList ID="DropDownListCourses" CssClass="form-select" runat="server" DataSourceID="sqlCourse" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
                                    <asp:SqlDataSource ID="sqlCourse" runat="server" ConnectionString="<%$ ConnectionStrings:LMSContext %>" SelectCommand="SELECT [Id], [Name] FROM [CourseDBs]"></asp:SqlDataSource>
                                </div>
                                <div class="form-group">
                                    <label for="DropDownListFacilitators">Facilitator</label>
                                    <asp:DropDownList ID="DropDownListFacilitators" CssClass="form-select" runat="server" DataSourceID="sqlFacilitator" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
                                    <asp:SqlDataSource ID="sqlFacilitator" runat="server" ConnectionString="<%$ ConnectionStrings:LMSContext %>" SelectCommand="SELECT [Id], ([LastName] + ' ' + [FirstName]) AS [Name] FROM [FacilitatorDBs]"></asp:SqlDataSource>
                                </div>
                                <div class="form-group">
                                    <label for="DropDownStudentGroup">Student Group</label>
                                    <asp:DropDownList ID="DropDownStudentGroup" CssClass="form-select" runat="server" DataSourceID="SqlGroup" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlGroup" runat="server" ConnectionString="<%$ ConnectionStrings:LMSContext %>" SelectCommand="SELECT [Id], [Name] FROM [GroupDBs]"></asp:SqlDataSource>
                                </div>
                                <div class="form-group">
                                    <label for="txtStartDate">Start Date</label>
                                    <asp:TextBox ID="txtStartDate" TextMode="Date" runat="server" CssClass="form-control" Placeholder="Start Date (YYYY-MM-DD)" />
                                </div>
                                <div class="form-group">
                                    <label for="txtEndDate">End Date</label>
                                    <asp:TextBox ID="txtEndDate" TextMode="Date" runat="server" CssClass="form-control" Placeholder="End Date (YYYY-MM-DD)" />
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:Button ID="btnAddAssignment" runat="server" Text="Add Course" CssClass="btn btn-primary" OnClick="btnAddAssignment_Click" />
                                        <asp:Button ID="btnUpdateAssigmen" runat="server" Text="Update Course" CssClass="btn btn-primary" OnClick="btnUpdateAssignment_Click" Visible="false" />
                                    </div>
                                    <div class="col-md-6 text-right">
                                        <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-secondary" OnClick="btnClear_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-8">
                        <div class="card mb-4">
                            <div class="card-body">
                                <h4 class="card-title">Course Assignment List</h4>
                                <p class="card-description">Manage your course assignments here.</p>
                                <div class="table-responsive">
                                    <asp:GridView ID="assignmentList" CssClass="table table-striped" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" OnRowCommand="assignmentList_RowCommand">
                                        <Columns>
                                            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" Visible="false" />
                                            <asp:TemplateField HeaderText="Course Name">
                                                <ItemTemplate><%# Eval("Course.Name") %></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Course Code">
                                                <ItemTemplate><%# Eval("Course.Code") %></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student Group">
                                                <ItemTemplate><%# Eval("Groups.Name") %></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Facilitator">
                                                <ItemTemplate><%# Eval("Facilitator.FirstName") %> <%# Eval("Facilitator.LastName") %></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="StartDate" HeaderText="Start Date" SortExpression="StartDate" DataFormatString="{0:yyyy-MM-dd}" />
                                            <asp:BoundField DataField="EndDate" HeaderText="End Date" SortExpression="EndDate" DataFormatString="{0:yyyy-MM-dd}" />
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEdit" runat="server" CommandName="AssignEdit" CommandArgument='<%# Eval("Id") %>' Text="Edit" CssClass="btn btn-primary btn-sm" />
                                                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="AssignDelete" CommandArgument='<%# Eval("Id") %>' Text="Delete" CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure you want to delete this record?');" />
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
