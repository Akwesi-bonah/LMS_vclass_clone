﻿<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Admin.Master" AutoEventWireup="true" CodeBehind="FacilitatorAdd.aspx.cs" Inherits="vclass_clone.web_form.admin.FacilitatorAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper">
        <div class="row">
            <div>
                <asp:Button runat="server" Text="Go Back" ID="goBack" CssClass="btn btn-success font-weight-bold" OnClick="goBack_Click" />
            </div>
            <br />
            <div class="container vertical-center">
                <div class="row justify-content-center">
                    <div class="col-md-8">
                        <div class="card centered-form">
                            <div class="card-header badge-primary">
                                <h3>Add Facilitator</h3>
                            </div>
                            <div class="card-body">
                                <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="False" />
                                <div class="row">
                                    <div class="col-md-6 form-group">
                                        <label for="txtFirstName">First Name</label>
                                        <asp:TextBox ID="txtFirstName" TextMode="SingleLine" runat="server" CssClass="form-control" />
                                    </div>
                                    <div class="col-md-6 form-group">
                                        <label for="txtLastName">Last Name</label>
                                        <asp:TextBox ID="txtLastName" TextMode="SingleLine" runat="server" CssClass="form-control" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6 form-group">
                                        <label for="txtPhone">Phone</label>
                                        <asp:TextBox ID="txtPhone" TextMode="Number" runat="server" CssClass="form-control" />
                                    </div>
                                    <div class="col-md-6 form-group">
                                        <label for="txtEmail">Email</label>
                                        <asp:TextBox ID="txtEmail" TextMode="Email" runat="server" CssClass="form-control" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6 form-group">
                                        <label for="lbldepartment">Department</label>
                                        <asp:DropDownList ID="departmentList" CssClass="form-select" runat="server" DataSourceID="aqldepartment" DataTextField="Name" DataValueField="Id">
                                            <asp:ListItem>Test</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="aqldepartment" runat="server" ConnectionString="<%$ ConnectionStrings:LMSContext %>" SelectCommand="SELECT [Id], [Name] FROM [DepartmentDBs]"></asp:SqlDataSource>
                                    </div>
                                    <div class="col-md-6 form-group">
                                        <label for="txtAddress">Address</label>
                                        <asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server" CssClass="form-control" />
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-md-6 form-group">
                                        <label for="txtPwd">Password</label>
                                        <asp:TextBox ID="txtPwd" runat="server" CssClass="form-control" TextMode="Password" />
                                    </div>
                                    <div class="col-md-6 form-group">
                                        <label for="txtCpwd">Confirm Password</label>
                                        <asp:TextBox ID="txtCpwd" runat="server" CssClass="form-control" TextMode="Password" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:Button ID="btnAddFac" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnAddFac_Click" />
                                    </div>
                                    <div class="col-md-6 text-right">
                                        <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-secondary" OnClick="btnClear_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

    <div class="content-wrapper">

        <div class="row">
            <div class="container vertical-center">
                <div class="row justify-content-center">
                    <div class="col-md-8">
                        <div class="card centered-form">
                            <div class="card-header badge-primary">
                                <h2>Edit Course Settings</h2>
                            </div>
                            <div class="card-body">
                                <!-- Course Info Card with Background Image -->
                                <div class="card mb-4" runat="server" id="courseInfoCard" cssclass="course-info-card" style="position: relative; background: url('<%= courseImagePath %>') no-repeat center center; background-size: cover;">
                                    <div class="card-img-overlay d-flex flex-column justify-content-end">
                                        <div class="card-body text-light">
                                            <h5 class="card-title mb-3">Course Information</h5>

                                            <!-- Course Name and Course Code -->
                                            <div class="row mb-3">
                                                <div class="col-md-6">
                                                    <asp:Label ID="lblCourseName" runat="server" Text="Course Name" CssClass="form-label"></asp:Label>
                                                    <asp:TextBox ID="txtCourseName" runat="server" CssClass="form-control" placeholder="Enter course name"></asp:TextBox>
                                                </div>
                                                <div class="col-md-6">
                                                    <asp:Label ID="lblCourseCode" runat="server" Text="Course Code" CssClass="form-label"></asp:Label>
                                                    <asp:TextBox ID="txtCourseCode" runat="server" CssClass="form-control" placeholder="Enter course code"></asp:TextBox>
                                                </div>
                                            </div>

                                            <!-- Course Description -->
                                            <div class="mb-3">
                                                <asp:Label ID="lblCourseDescription" runat="server" Text="Course Description" CssClass="form-label"></asp:Label>
                                                <asp:TextBox ID="txtCourseDescription" TextMode="MultiLine" Rows="3" runat="server" CssClass="form-control" placeholder="Enter course description"></asp:TextBox>
                                            </div>

                                            <!-- Course Level and Enrollment Key -->
                                            <div class="row mb-3">
                                                <div class="col-md-6">
                                                    <asp:Label ID="lblCourseLevel" runat="server" Text="Course Level" CssClass="form-label"></asp:Label>
                                                    <asp:TextBox ID="txtCourseLevel" runat="server" CssClass="form-control" placeholder="Enter course level"></asp:TextBox>
                                                </div>
                                                <div class="col-md-6">
                                                    <asp:Label ID="lblEnrollmentKey" runat="server" Text="Enrollment Key" CssClass="form-label"></asp:Label>
                                                    <asp:TextBox ID="txtEnrollmentKey" runat="server" CssClass="form-control" placeholder="Enter enrollment key"></asp:TextBox>
                                                </div>
                                            </div>

                                            <!-- Save Button -->
                                            <div class="mb-3 text-center">
                                                <asp:Button ID="btnSave" runat="server" Text="Save Changes" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                                            </div>

                                            <!-- Message Label -->
                                            <asp:Label ID="lblMessage" runat="server" Text="" CssClass="alert alert-info mt-3" Visible="false"></asp:Label>
                                        </div>
                                    </div>
                                </div>

                                <!-- Upload Course Image Card -->
                                <div class="card mb-4">
                                    <div class="card-header">
                                        <h5 class="card-title">Upload New Course Image</h5>
                                    </div>
                                    <div class="card-body">
                                        <div class="mb-3">
                                            <asp:Label ID="lblCourseImage" runat="server" Text="Upload Course Image" CssClass="form-label"></asp:Label>
                                            <asp:FileUpload ID="fileUploadImage" runat="server" CssClass="form-control-file" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
