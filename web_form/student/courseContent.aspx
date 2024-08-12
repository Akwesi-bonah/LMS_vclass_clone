<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Student.Master" AutoEventWireup="true" CodeBehind="courseContent.aspx.cs" Inherits="vclass_clone.web_form.student.courseContent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper">
        <div class="row">
            <div class="col-12">
                <h1 class="mt-4">Course Details</h1>

                <!-- Message Label for displaying errors or notifications -->
                <asp:Label ID="lblMessage" runat="server" CssClass="alert"></asp:Label>

                <!-- Course Information and Content Card -->
                <div class="card mb-4 shadow-sm">
                    <div class="card-header bg-primary text-white d-flex justify-content-between align-items-center">
                        <div>
                            <asp:Label ID="lblCourseName" runat="server" Text="" CssClass="h4"></asp:Label> -
                            <asp:Label ID="lblCourseCode" runat="server" Text="" CssClass="h5"></asp:Label>
                        </div>

                        <!-- Dropdown Icon for Settings -->
                        <div class="dropdown">
                            <a class="nav-link dropdown-toggle text-white" href="#" role="button" id="settingsDropdown" data-bs-toggle="dropdown" aria-expanded="false">
                                <i class="typcn typcn-cog-outline"></i>
                            </a>
                            <ul class="dropdown-menu dropdown-menu-end" aria-labelledby="settingsDropdown">
                                <asp:LinkButton ID="btnUnenroll" runat="server" CssClass="dropdown-item" OnClick="btnUnenroll_Click" OnClientClick="return confirm('Are you sure you want to unenroll from this course?');">
                                    Unenroll
                                </asp:LinkButton>
                            </ul>
                        </div>
                    </div>

                    <div class="card-body">
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
            </div>
        </div>
    </div>
</asp:Content>
