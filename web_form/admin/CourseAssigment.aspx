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
                            <h3>Add Course Assignment</h3>
                        </div>
                        <div class="card-body">
                            <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="False" />
                            <div class="form-group">
                                <label for="DropDownListCourses">Course</label>
                                <asp:DropDownList ID="DropDownListCourses" CssClass="form-select" runat="server" DataSourceID="sqlCourse" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
                                <asp:SqlDataSource ID="sqlCourse" runat="server" ConnectionString="<%$ ConnectionStrings:LMSContext %>" SelectCommand="SELECT [Id], [Name] FROM [CourseDBs]"></asp:SqlDataSource>
                            </div>
                            <div class="form-group">
                                <label for="DropDownListFacilitators">Facilitator</label>
                                <asp:DropDownList ID="DropDownListFacilitators" CssClass="form-select" runat="server" DataSourceID="sqlFacilitator" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
                                <asp:SqlDataSource ID="sqlFacilitator" runat="server" ConnectionString="<%$ ConnectionStrings:LMSContext %>" SelectCommand="SELECT [Id], [LastName] FROM [FacilitatorDBs]"></asp:SqlDataSource>
                            </div>
                            <div class="form-group">
                                <label for="txtStartDate">Start Date</label>
                                <asp:TextBox ID="txtStartDate" TextMode="SingleLine" runat="server" CssClass="form-control" Placeholder="Start Date (YYYY-MM-DD)" />
                            </div>
                            <div class="form-group">
                                <label for="txtEndDate">End Date</label>
                                <asp:TextBox ID="txtEndDate" TextMode="SingleLine" runat="server" CssClass="form-control" Placeholder="End Date (YYYY-MM-DD)" />
                            </div>
                            <asp:Button ID="btnAddAssignment" runat="server" Text="Add Assignment" CssClass="btn btn-primary" OnClick="btnAddAssignment_Click" />
                        </div>
                    </div>
                </div>

                <!-- Table Section: Large on the right -->
                <div class="col-md-8">
                    <div class="card mb-4">
                        <div class="card-body">
                            <h4 class="card-title">Course Assignment List</h4>
                            <p class="card-description">Manage your course assignments here.</p>
                            <div class="table-responsive">
                                <asp:GridView ID="assignmentList" CssClass="table table-striped" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlAssignment" DataKeyNames="Id">
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                                        <asp:BoundField DataField="CourseId" HeaderText="CourseId" SortExpression="CourseId" />
                                        <asp:BoundField DataField="FacilitatorId" HeaderText="FacilitatorId" SortExpression="FacilitatorId" />
                                        <asp:BoundField DataField="StartDate" HeaderText="StartDate" SortExpression="StartDate" />
                                        <asp:BoundField DataField="EndDate" HeaderText="EndDate" SortExpression="EndDate" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlAssignment" runat="server" ConnectionString="<%$ ConnectionStrings:LMSContext %>" SelectCommand="SELECT * FROM [CourseAssignmentDBs]"></asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
