<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Facilitator.Master" AutoEventWireup="true" CodeBehind="AssignmentEdit.aspx.cs" Inherits="vclass_clone.web_form.facilitator.AssignmentEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2>Edit Assignment</h2>

        <asp:Label ID="lblMessage" runat="server" CssClass="alert" Visible="false"></asp:Label>

        <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" Placeholder="Assignment Title"></asp:TextBox>
        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="form-control mt-2" Placeholder="Assignment Description"></asp:TextBox>

        <asp:Button ID="btnSave" runat="server" Text="Save Changes" CssClass="btn btn-primary mt-4" OnClick="btnSave_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary mt-4" OnClick="btnCancel_Click" />
    </div>
</asp:Content>

