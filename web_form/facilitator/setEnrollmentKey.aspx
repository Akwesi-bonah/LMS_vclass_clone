<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Facilitator.Master" AutoEventWireup="true" CodeBehind="setEnrollmentKey.aspx.cs" Inherits="vclass_clone.web_form.facilitator.setEnrollmentKey" %>

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
                <li class="nav-item"><a class="nav-link" href="#">Setting</a></li>
                <li class="nav-item"><a class="nav-link" href="#">Add Content</a></li>
                <li class="nav-item"><a class="nav-link" href="#">Assigment</a></li>
                <li class="nav-item"><a class="nav-link" href="#">Set Quiz</a></li>
                <li class="nav-item"><a class="nav-link" href="#">Enroll List</a></li>

            </ul>
        </div>
    </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblEnrollmentKey" runat="server" Text="Set Enrollment Key"></asp:Label>
    <asp:TextBox ID="txtEnrollmentKey" runat="server"></asp:TextBox>
    <asp:Button ID="btnSetEnrollmentKey" runat="server" Text="Set Key" OnClick="btnSetEnrollmentKey_Click" />
    <asp:Label ID="lblKeyMessage" runat="server" Text="" Visible="false"></asp:Label>

</asp:Content>
