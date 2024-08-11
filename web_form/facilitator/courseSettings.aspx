<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Facilitator.Master" AutoEventWireup="true" CodeBehind="courseSettings.aspx.cs" Inherits="vclass_clone.web_form.facilitator.courseSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper">
        <div class="container vertical-center">
            <div class="row justify-content-center">
                <div class="col-md-12">
                    <div class="card centered-form" runat="server" id="courseInfoCard">
                        <div class="card-header badge-info">
                            <h3>Edit Course Settings</h3>
                        </div>
                        <div class="card-body">
                            <h5 class="card-title mb-3">Course Information</h5>

                            <div>
                                 <!-- Message Label -->
                            <asp:Label ID="lblMessage" runat="server" Text="" CssClass="alert alert-info mt-3" Visible="false"></asp:Label>
                            </div>
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

                           
                        </div>

                        <!-- Upload Course Image Card -->
                        <div class="card-footer">
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
</asp:Content>
