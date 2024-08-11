<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Facilitator.Master" AutoEventWireup="true" CodeBehind="CourseMange.aspx.cs" Inherits="vclass_clone.web_form.facilitator.CourseMange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiderContent" runat="server">
    <li class="nav-item">
        <a class="nav-link" data-bs-toggle="collapse" href="#u-profile" aria-expanded="false" aria-controls="u-profile">
            <i class="typcn typcn-document-text menu-icon"></i>
            <span class="menu-title">Management</span>
            <i class="menu-arrow"></i>
        </a>
        <div class="collapse" id="u-profile">
            <ul class="nav flex-column sub-menu">
                <li class="nav-item"><a class="nav-link" href="<%=Page.GetRouteUrl("FacManageCourseSet", null) %>">Setting</a></li>
                <li class="nav-item"><a class="nav-link" href="<%=Page.GetRouteUrl("FacSetMaterial", null) %>">Add Content</a></li>
                <li class="nav-item"><a class="nav-link" href="<%=Page.GetRouteUrl("FacSetAssigment", null) %>">Assigment</a></li>
                <li class="nav-item"><a class="nav-link" href="#">Set Quiz</a></li>
                <li class="nav-item"><a class="nav-link" href="#">Enroll List</a></li>

            </ul>
        </div>
    </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper">
        <h1 class="mt-4">Course Details</h1>

        <!-- Message Label for displaying errors or notifications -->
        <asp:Label ID="lblMessage" runat="server" CssClass="alert"></asp:Label>

        <!-- Course Information and Content Card -->
        <div class="card mb-4">
            <div class="card-header bg-primary text-white">
                <h4 class="mb-0 d-flex justify-content-between align-items-center">
                    <span>
                        <asp:Label ID="lblCourseName" runat="server" Text=""></asp:Label>
                        - 
                        <asp:Label ID="lblCourseCode" runat="server" Text=""></asp:Label>
                    </span>
                </h4>
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
                    <asp:Repeater ID="SectionsRepeater" runat="server" OnItemCommand="SectionsRepeater_ItemCommand">
                        <ItemTemplate>
                            <div class="section mb-4 p-3 border rounded">
                                <!-- Section Header with Title and Edit Button -->
                                <div class="d-flex justify-content-between align-items-center mb-3">
                                    <h5 class="section-title text-secondary mb-0">
                                        <%# Eval("Title") %>
                                    </h5>
                                    <!-- Redirect to edit page with material ID in the query string -->
                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-sm btn-outline-secondary">Edit</asp:LinkButton>

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
</asp:Content>
