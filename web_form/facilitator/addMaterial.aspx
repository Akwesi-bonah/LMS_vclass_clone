<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Facilitator.Master" AutoEventWireup="true" CodeBehind="addMaterial.aspx.cs" Inherits="vclass_clone.web_form.facilitator.addMaterial"  ValidateRequest="false" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdn.ckeditor.com/4.18.0/standard/ckeditor.js"></script>
        <link href="https://cdn.ckeditor.com/4.16.0/standard/ckeditor.css" rel="stylesheet">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2 class="mb-4">Add Course Resources</h2>

        <!-- Message Label -->
        <asp:Label ID="lblMaterialMessage" runat="server" Text="" CssClass="alert alert-info mt-3" Visible="false"></asp:Label>
    
        <!-- Material Title Input -->
        <div class="form-group">
            <asp:Label ID="lblMaterialTitle" runat="server" Text="Material Title" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtMaterialTitle" runat="server" CssClass="form-control" placeholder="Enter material title"></asp:TextBox>
        </div>

        <!-- Rich Text Editor for Material Content -->
        <div class="form-group">
            <asp:Label ID="lblMaterialContent" runat="server" Text="Material Content" CssClass="form-label"></asp:Label>
            <CKEditor:CKEditorControl ID="txtMaterialContent" runat="server"></CKEditor:CKEditorControl>

        </div>

        <!-- Material File Upload -->
        <div class="form-group">
            <asp:Label ID="lblMaterialFile" runat="server" Text="Upload Material" CssClass="form-label"></asp:Label>
            <asp:FileUpload ID="fileUploadMaterial"  runat="server" CssClass="form-control-file" AllowMultiple="true"/>
        </div>

        <!-- Upload Button -->
        <div class="form-group">
            <asp:Button ID="btnUploadMaterial" runat="server" Text="Upload" CssClass="btn btn-primary" OnClick="btnUploadMaterial_Click" />
        </div>

        </div>

    <!-- Initialize CKEditor -->
    <script>
        CKEDITOR.replace('<%= txtMaterialContent.ClientID %>');
    </script>
</asp:Content>

