<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Facilitator.Master" AutoEventWireup="true" CodeBehind="addAssigment.aspx.cs" Inherits="vclass_clone.web_form.facilitator.addAssigment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblAssignmentTitle" runat="server" Text="Assignment Title"></asp:Label>
<asp:TextBox ID="txtAssignmentTitle" runat="server"></asp:TextBox>
<br />
<asp:Label ID="lblAssignmentDescription" runat="server" Text="Description"></asp:Label>
<asp:TextBox ID="txtAssignmentDescription" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
<br />
<asp:Label ID="lblDueDate" runat="server" Text="Due Date"></asp:Label>
<asp:TextBox ID="txtDueDate" runat="server"></asp:TextBox>
<asp:Button ID="btnCreateAssignment" runat="server" Text="Create Assignment" OnClick="btnCreateAssignment_Click" />
<asp:Label ID="lblAssignmentMessage" runat="server" Text="" Visible="false"></asp:Label>

</asp:Content>
