﻿<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Facilitator.Master" AutoEventWireup="true" CodeBehind="addAssigment.aspx.cs" Inherits="vclass_clone.web_form.facilitator.addAssigment"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <div class="card">
            <div class="card-header bg-primary text-white">
                <h2 class="mb-0">Add New Assignment</h2>
            </div>
            <div class="card-body">
                <!-- Message Label -->
                <asp:Label ID="lblAssignmentMessage" runat="server" Text="" CssClass="alert alert-info mt-3" Visible="false"></asp:Label>

                <!-- Assignment Title Input -->
                <div class="form-group">
                    <asp:Label ID="lblAssignmentTitle" runat="server" Text="Assignment Title" CssClass="form-label"></asp:Label>
                    <asp:TextBox TextMode="SingleLine" ID="txtAssignmentTitle" runat="server" CssClass="form-control" placeholder="Enter assignment title"></asp:TextBox>
                </div>

                <!-- Assignment Description -->
                <div class="form-group">
                    <asp:Label ID="lblAssignmentDescription" runat="server" Text="Assignment Description" CssClass="form-label"></asp:Label>
                    <asp:TextBox TextMode="MultiLine" ID="txtAssignmentDescription" runat="server" CssClass="form-control" placeholder="Enter assignment description" Rows="5"></asp:TextBox>
                </div>

                <!-- Assignment Due Date -->
                <div class="form-group">
                    <asp:Label ID="lblDueDate" runat="server" Text="Due Date" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtDueDate" runat="server" CssClass="form-control" TextMode="DateTimeLocal" placeholder="Enter due date"></asp:TextBox>
                </div>

                <!-- Assignment File Upload -->
                <div class="form-group">
                    <asp:Label ID="lblAssignmentFile" runat="server" Text="Upload Assignment File (optional)" CssClass="form-label"></asp:Label>
                    <asp:FileUpload ID="fileUploadAssignment" runat="server" CssClass="form-control-file" />
                </div>

                <!-- Upload Button -->
                <div class="form-group">
                    <asp:Button ID="btnAddAssignment" runat="server" Text="Add Assignment" CssClass="btn btn-primary" OnClick="btnAddAssignment_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
