<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Student.Master" AutoEventWireup="true" CodeBehind="enrollCourse.aspx.cs" Inherits="vclass_clone.web_form.student.enrollCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container d-flex justify-content-center align-items-center" style="min-height: 100vh;">
        <div class="card w-50">
            <div class="card-body">
                <div class="row mb-4">
                    <div class="col-md-12">
                        <h1 class="mb-0 text-center">Course Enrollment</h1>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12 text-center">
                        <asp:Label ID="lblCourseName" runat="server" CssClass="h4"></asp:Label>
                        <asp:Label ID="lblCourseCode" runat="server" CssClass="h5 text-muted"></asp:Label>
                    </div>
                    <div class="col-md-12 mt-4 text-center">
                        <asp:Label ID="lblCourseDescription" runat="server" CssClass="text-muted"></asp:Label>
                    </div>
                    <div class="col-md-12 mt-4 text-center">
                        <asp:Image ID="imgCourse" runat="server" CssClass="img-fluid" />
                    </div>
                    <div class="col-md-12 mt-4">
                        <div class="form-group">
                            <asp:Label ID="lblEnrollmentKeyLabel" runat="server" Text="Enter Enrollment Key:" AssociatedControlID="txtEnrollmentKey" CssClass="form-label" />
                            <asp:TextBox ID="txtEnrollmentKey" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="col-md-12 mt-4 text-center">
                        <asp:Button ID="btnConfirmEnrollment" runat="server" Text="Enroll" CssClass="btn btn-primary" OnClick="btnConfirmEnrollment_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
