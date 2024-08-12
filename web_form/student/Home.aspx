<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Student.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="vclass_clone.web_form.student.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<div class="content-wrapper">
    <div class="row">
        <!-- Upcoming Events Card -->
        <div class="col-lg-4 col-md-6 mb-4">
            <div class="card shadow-sm h-100">
                <div class="card-header bg-primary text-white d-flex align-items-center">
                    <i class="typcn typcn-calendar-outline typcn-2x mr-3"></i>
                    <h5>Upcoming Events</h5>
                </div>
                <div class="card-body">
                    <p class="card-text text-center">
                        <!-- Load content dynamically from backend -->
                        <span id="upcoming-events">None, No upcoming events</span>
                    </p>
                </div>
            </div>
        </div>

        <!-- Current Week Activities Card -->
        <div class="col-lg-4 col-md-6 mb-4">
            <div class="card shadow-sm h-100">
                <div class="card-header bg-success text-white d-flex align-items-center">
                    <i class="typcn typcn-clipboard typcn-2x mr-3"></i>
                    <h5>Current Week Activities</h5>
                </div>
                <div class="card-body">
                    <p class="card-text text-center">
                        <!-- Load content dynamically from backend -->
                        <span id="current-week-activities">None, No current activities</span>
                    </p>
                </div>
            </div>
        </div>

        <!-- Any Order Card -->
        <div class="col-lg-4 col-md-6 mb-4">
            <div class="card shadow-sm h-100">
                <div class="card-header bg-info text-white d-flex align-items-center">
                    <i class="typcn typcn-document-text typcn-2x mr-3"></i>
                    <h5>Any Order</h5>
                </div>
                <div class="card-body">
                    <p class="card-text text-center">
                        <!-- Load content dynamically from backend -->
                        <span id="any-order">None, No orders available</span>
                    </p>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <!-- Course Progress Card -->
        <div class="col-lg-6 col-md-6 mb-4">
            <div class="card shadow-sm h-100">
                <div class="card-header bg-warning text-dark d-flex align-items-center">
                    <i class="typcn typcn-chart-bar typcn-2x mr-3"></i>
                    <h5>Course Progress</h5>
                </div>
                <div class="card-body">
                    <p class="card-text text-center">
                        <!-- Load content dynamically from backend -->
                        <span id="course-progress">None, No progress data available</span>
                    </p>
                </div>
            </div>
        </div>

        <!-- Announcements Card -->
        <div class="col-lg-4 col-md-6 mb-4">
            <div class="card shadow-sm h-100">
                <div class="card-header bg-danger text-white d-flex align-items-center">
                    <i class="typcn typcn-megaphone typcn-2x mr-3"></i>
                    <h5>Announcements</h5>
                </div>
                <div class="card-body">
                    <p class="card-text text-center">
                        <!-- Load content dynamically from backend -->
                        <span id="announcements">None, No announcements available</span>
                    </p>
                </div>
            </div>
        </div>

        <!-- Quick Links Card -->
        <div class="col-lg-4 col-md-6 mb-4">
            <div class="card shadow-sm h-100">
                <div class="card-header bg-secondary text-white d-flex align-items-center">
                    <i class="typcn typcn-link-outline typcn-2x mr-3"></i>
                    <h5>Quick Links</h5>
                </div>
                <div class="card-body">
                    <p class="card-text text-center">
                        <!-- Load content dynamically from backend -->
                        <span id="quick-links">None, No quick links available</span>
                    </p>
                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
