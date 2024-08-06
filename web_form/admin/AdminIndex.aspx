<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Admin.Master" AutoEventWireup="true" CodeBehind="AdminIndex.aspx.cs" Inherits="vclass_clone.web_form.admin.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper">
            <div class="row">
                <div class="col-xl-12 grid-margin stretch-card flex-column">
                    <h5 class="mb-2 text-titlecase mb-4">Status Statistics</h5>
                    <div class="row">
                        <!-- Admins Card -->
                        <div class="col-md-3 grid-margin stretch-card">
                            <div class="card bg-primary text-white">
                                <div class="card-body d-flex flex-column justify-content-between">
                                    <div class="d-flex justify-content-between align-items-center mb-2">
                                        <div>
                                            <p class="mb-0">Admins</p>
                                            <h4><asp:Label ID="lblTotalAdmins" runat="server" Text=""></asp:Label></h4>
                                        </div>
                                        <i class="fas fa-user-shield fa-2x"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- Facilitators Card -->
                        <div class="col-md-3 grid-margin stretch-card">
                            <div class="card bg-success text-white">
                                <div class="card-body d-flex flex-column justify-content-between">
                                    <div class="d-flex justify-content-between align-items-center mb-2">
                                        <div>
                                            <p class="mb-0">Facilitators</p>
                                            <h4><asp:Label ID="lblTotalFacilitators" runat="server" Text=""></asp:Label></h4>
                                        </div>
                                        <i class="fas fa-chalkboard-teacher fa-2x"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- Students Card -->
                        <div class="col-md-3 grid-margin stretch-card">
                            <div class="card bg-info text-white">
                                <div class="card-body d-flex flex-column justify-content-between">
                                    <div class="d-flex justify-content-between align-items-center mb-2">
                                        <div>
                                            <p class="mb-0">Students</p>
                                            <h4><asp:Label ID="lblTotalStudents" runat="server" Text=""></asp:Label></h4>
                                        </div>
                                        <i class="fas fa-user-graduate fa-2x"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- Total Courses Card -->
                        <div class="col-md-3 grid-margin stretch-card">
                            <div class="card bg-warning text-white">
                                <div class="card-body d-flex flex-column justify-content-between">
                                    <div class="d-flex justify-content-between align-items-center mb-2">
                                        <div>
                                            <p class="mb-0">Total Courses</p>
                                            <h4><asp:Label ID="lblTotalCourses" runat="server" Text=""></asp:Label></h4>
                                        </div>
                                        <i class="fas fa-book fa-2x"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- Assigned Courses Card -->
                        <div class="col-md-3 grid-margin stretch-card">
                            <div class="card bg-secondary text-white">
                                <div class="card-body d-flex flex-column justify-content-between">
                                    <div class="d-flex justify-content-between align-items-center mb-2">
                                        <div>
                                            <p class="mb-0">Assigned Courses</p>
                                            <h4><asp:Label ID="lblAssignedCourses" runat="server" Text=""></asp:Label></h4>
                                        </div>
                                        <i class="fas fa-tasks fa-2x"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- Unassigned Courses Card -->
                        <div class="col-md-3 grid-margin stretch-card">
                            <div class="card bg-danger text-white">
                                <div class="card-body d-flex flex-column justify-content-between">
                                    <div class="d-flex justify-content-between align-items-center mb-2">
                                        <div>
                                            <p class="mb-0">Unassigned Courses</p>
                                            <h4><asp:Label ID="lblUnassignedCourses" runat="server" Text=""></asp:Label></h4>
                                        </div>
                                        <i class="fas fa-exclamation-circle fa-2x"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
