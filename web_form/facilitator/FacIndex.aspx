<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Facilitator.Master" AutoEventWireup="true" CodeBehind="FacIndex.aspx.cs" Inherits="vclass_clone.web_form.facilitator.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="content-wrapper">
            <h2 class="mt-4">Facilitator Dashboard</h2>
            <div class="row">
                <div class="col-md-4">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">Course Materials</h5>
                            <p class="card-text">Add and manage course materials.</p>
                            <a href="ManageCourseMaterials.aspx" class="btn btn-primary">Go to Course Materials</a>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">Assignments</h5>
                            <p class="card-text">Add and manage assignments.</p>
                            <a href="ManageAssignments.aspx" class="btn btn-primary">Go to Assignments</a>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">Quizzes</h5>
                            <p class="card-text">Create and manage quizzes.</p>
                            <a href="ManageQuizzes.aspx" class="btn btn-primary">Go to Quizzes</a>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 mt-4">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">Enrollment Keys</h5>
                            <p class="card-text">Generate and manage enrollment keys.</p>
                            <a href="ManageEnrollmentKeys.aspx" class="btn btn-primary">Go to Enrollment Keys</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
