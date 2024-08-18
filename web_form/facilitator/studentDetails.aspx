<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Facilitator.Master" AutoEventWireup="true" CodeBehind="studentDetails.aspx.cs" Inherits="vclass_clone.web_form.facilitator.studentDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
    <!-- Card Header -->
    <div class="card">
        <div class="card-header">
            <h2 class="mb-0">Student Information</h2>
        </div>

        <!-- Error Label -->
        
            <asp:Label ID="lblError" CssClass="alert alert-dange"  runat="server"></asp:Label>
        <!-- Card Body with Student Details -->
        <div class="card-body">
            <div class="row mb-3">
                <div class="col-md-6">
                    <strong>First Name:</strong>
                    <asp:Label ID="lblFirstName" runat="server" CssClass="form-control-plaintext"></asp:Label>
                </div>
                <div class="col-md-6">
                    <strong>Last Name:</strong>
                    <asp:Label ID="lblLastName" runat="server" CssClass="form-control-plaintext"></asp:Label>
                </div>
            </div>

            <div class="row mb-3">
                <div class="col-md-6">
                    <strong>Student Number:</strong>
                    <asp:Label ID="lblStudentNumber" runat="server" CssClass="form-control-plaintext"></asp:Label>
                </div>
                <div class="col-md-6">
                    <strong>Gender:</strong>
                    <asp:Label ID="lblGender" runat="server" CssClass="form-control-plaintext"></asp:Label>
                </div>
            </div>

            <div class="row mb-3">
                <div class="col-md-6">
                    <strong>Level:</strong>
                    <asp:Label ID="lblLevel" runat="server" CssClass="form-control-plaintext"></asp:Label>
                </div>
                <div class="col-md-6">
                    <strong>Group:</strong>
                    <asp:Label ID="lblGroup" runat="server" CssClass="form-control-plaintext"></asp:Label>
                </div>
            </div>

            <div class="row mb-3">
                <div class="col-md-6">
                    <strong>User ID:</strong>
                    <asp:Label ID="lblUserId" runat="server" CssClass="form-control-plaintext"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
