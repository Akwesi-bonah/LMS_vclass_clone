<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Student.Master" AutoEventWireup="true" CodeBehind="courseAssigDetail.aspx.cs" Inherits="vclass_clone.web_form.student.courseAssigDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper">
        <div class="row">
            <div class="col-md-12">
                <asp:Panel ID="pnlCourseDetails" runat="server" CssClass="card">
                    <div class="card-body">
                        <h4 class="card-title">Course Information</h4>
                        <p class="card-text"><strong>Title:</strong>
                            <asp:Label ID="lblCourseTitle" runat="server" Text="Course Title"></asp:Label></p>
                        <p class="card-text"><strong>Description:</strong>
                            <asp:Label ID="lblCourseDescription" runat="server" Text="Course Description"></asp:Label></p>
                    </div>
                </asp:Panel>
            </div>
        </div>

        <div class="row mt-4">
            <div class="col-md-12">
                <asp:Panel ID="pnlAssignmentDetails" runat="server" CssClass="card">
                    <div class="card-body">
                        <h4 class="card-title">Assignment Details</h4>
                        <p class="card-text"><strong>Title:</strong>
                            <asp:Label ID="lblAssignmentTitle" runat="server" Text="Assignment Title"></asp:Label></p>
                        <p class="card-text"><strong>Description:</strong>
                            <asp:Label ID="lblAssignmentDescription" runat="server" Text="Assignment Description"></asp:Label></p>
                        <p class="card-text"><strong>Due Date:</strong>
                            <asp:Label ID="lblAssignmentDueDate" runat="server" Text="Assignment Due Date"></asp:Label></p>
                        <p class="card-text">
                            <strong>File:</strong>
                            <asp:HyperLink ID="lnkAssignmentFile" runat="server" Text="Download File" NavigateUrl="#" />
                        </p>

                        <!-- Display if assignment has been submitted -->
                        <asp:Panel ID="pnlSubmissionStatus" runat="server" CssClass="alert alert-success mt-4" Visible="false">
                            <strong>Submitted on:</strong>
                            <asp:Label ID="lblSubmissionDate" runat="server" />
                            <asp:Button ID="btnResubmitAssignment" runat="server" Text="Resubmit Assignment" CssClass="btn btn-warning btn-sm ml-3" OnClick="btnSubmitAssignment_Click" />
                        </asp:Panel>

                        <!-- Display if deadline has passed -->
                        <asp:Panel ID="pnlDeadlinePassed" runat="server" CssClass="alert alert-danger mt-4" Visible="false">
                            <strong>Deadline has passed!</strong> You can no longer submit or edit this assignment.
                           
                        </asp:Panel>

                        <!-- Submission form -->
                        <asp:Panel ID="pnlSubmissionForm" runat="server" CssClass="mt-4" Visible="false">
                            <h5>Submit Your Work</h5>
                            <asp:FileUpload ID="fileUploadSubmission" runat="server" CssClass="form-control-file mb-2" />
                            <asp:Button ID="btnSubmitAssignment" runat="server" Text="Submit Assignment" CssClass="btn btn-primary btn-sm" OnClick="btnSubmitAssignment_Click" />
                        </asp:Panel>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
