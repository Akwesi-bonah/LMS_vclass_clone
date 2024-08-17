<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Student.Master" AutoEventWireup="true" CodeBehind="courseContent.aspx.cs" Inherits="vclass_clone.web_form.student.courseContent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper">
        <div class="row">
            <div class="card">
                <div class="card-header bg-primary text-white">
                    <h2 class="mb-0">Course Details</h2>

                    <div>
                        <asp:Label ID="lblCourseName" runat="server" Text="" CssClass="h4"></asp:Label>


                        <asp:Label ID="lblCourseCode" runat="server" Text="" CssClass="h5"></asp:Label>
                    </div>
                </div>
                <div class="card-body">
                    <!-- Message Label for displaying errors or notifications -->
                    <asp:Label ID="lblMessage" runat="server" CssClass="alert"></asp:Label>

                    <!-- Tabs Navigation -->
                    <ul class="nav nav-tabs" id="courseTabs" role="tablist">
                        <li class="nav-item" role="presentation">
                            <a class="nav-link active" id="content-tab" data-bs-toggle="tab" href="#content" role="tab" aria-controls="content" aria-selected="true">Course Content</a>
                        </li>
                        <li class="nav-item" role="presentation">
                            <a class="nav-link" id="assignments-tab" data-bs-toggle="tab" href="#assignments" role="tab" aria-controls="assignments" aria-selected="false">Assignments</a>
                        </li>
                        <li class="nav-item" role="presentation">
                            <a class="nav-link" id="quizzes-tab" data-bs-toggle="tab" href="#quizzes" role="tab" aria-controls="quizzes" aria-selected="false">Quizzes</a>
                        </li>
                    </ul>

                    <!-- Tabs Content -->
                    <div class="tab-content" id="courseTabsContent">
                        <!-- Course Content Tab -->
                        <div class="tab-pane fade show active" id="content" role="tabpanel" aria-labelledby="content-tab">
                            <!-- Course Information and Content Card -->

                            <div class="mb-4 mt-4">
                                <!-- Course Description -->
                                <div class="mb-4">
                                    <h5 class="card-title">Course Description</h5>
                                    <p class="card-text">
                                        <asp:Label ID="lblCourseDescription" runat="server" Text=""></asp:Label>
                                    </p>
                                </div>

                                <!-- Course Content Sections -->
                                <div class="course-content">
                                    <asp:Repeater ID="SectionsRepeater" runat="server">
                                        <ItemTemplate>
                                            <div class="section mb-4 p-3 border rounded bg-light">
                                                <!-- Section Header with Title -->
                                                <div class="d-flex justify-content-between align-items-center mb-3">
                                                    <h5 class="section-title text-secondary mb-0">
                                                        <%# Eval("Title") %>
                                                    </h5>
                                                </div>

                                                <!-- Section Content -->
                                                <p class="section-content mb-3">
                                                    <%# Eval("Content") %>
                                                </p>

                                                <!-- Files for Download -->
                                                <div class="files">
                                                    <asp:Repeater ID="FilesRepeater" runat="server">
                                                        <ItemTemplate>
                                                            <div class="file mb-2">
                                                                <a href='<%# ResolveUrl("~/Uploads/Materials/" + Eval("FileName")) %>' download class="btn btn-sm btn-outline-primary">
                                                                    <%# Eval("FileName") %>
                                                                </a>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>

                        <!-- Assignments Tab -->
                        <div class="tab-pane fade" id="assignments" role="tabpanel" aria-labelledby="assignments-tab">
                            <div class="mt-4">
                                <asp:Repeater ID="AssignmentsRepeater" runat="server">
                                    <ItemTemplate>
                                        <div class="assignment mb-4 p-3 border rounded bg-light">
                                            <h5 class="assignment-title text-secondary mb-0">
                                                <%# Eval("Title") %>
                                            </h5>
                                            <p class="assignment-description">
                                                <%# Eval("Description") %>
                                            </p>
                                            <p class="assignment-due-date text-muted">
                                                Due Date: <%# Eval("DueDate", "{0:MMMM dd, yyyy}") %>
                                            </p>
                                            <!-- View Details LinkButton using Route -->
                                            <asp:LinkButton ID="lnkViewDetails" runat="server" CssClass="btn btn-info btn-sm"
                                                PostBackUrl='<%# ResolveUrl("~/defualt/course_assignment/") + Eval("Id") %>'>
                        View Details
                                            </asp:LinkButton>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>


                        <!-- Quizzes Tab -->
                        <div class="tab-pane fade" id="quizzes" role="tabpanel" aria-labelledby="quizzes-tab">
                            <div class="mt-4">
                                <asp:Repeater ID="QuizzesRepeater" runat="server">
                                    <ItemTemplate>
                                        <div class="quiz mb-4 p-3 border rounded bg-light">
                                            <h5 class="quiz-title text-secondary mb-0">
                                                <%# Eval("Title") %>
                                            </h5>
                                            <p class="quiz-description">
                                                <%# Eval("Description") %>
                                            </p>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

