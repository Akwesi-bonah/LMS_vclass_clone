<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Facilitator.Master" AutoEventWireup="true" CodeBehind="CourseEdit.aspx.cs" Inherits="vclass_clone.web_form.facilitator.CourseEdit"  ValidateRequest="false" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="https://cdn.ckeditor.com/4.18.0/standard/ckeditor.js"></script>
        <link href="https://cdn.ckeditor.com/4.16.0/standard/ckeditor.css" rel="stylesheet">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h1 class="mb-4">Edit Course Content</h1>

        <!-- Message Label -->
        <asp:Label ID="lblEditMessage" runat="server" CssClass="alert" Visible="false"></asp:Label>

        <!-- Material Title Input -->
        <div class="form-group">
            <asp:Label ID="lblEditMaterialTitle" runat="server" Text="Material Title" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtEditMaterialTitle" runat="server" CssClass="form-control" placeholder="Enter material title"></asp:TextBox>
        </div>

        <!-- Rich Text Editor for Material Content -->
        <div class="form-group">
            <asp:Label ID="lblEditMaterialContent" runat="server" Text="Material Content" CssClass="form-label"></asp:Label>
            <CKEditor:CKEditorControl ID="txtEditMaterialContent" runat="server"></CKEditor:CKEditorControl>
        </div>

        <!-- Material File Upload -->
        <div class="form-group">
            <asp:Label ID="lblEditMaterialFile" runat="server" Text="Upload New Files" CssClass="form-label"></asp:Label>
            <asp:FileUpload ID="fileUploadEditMaterial" runat="server" CssClass="form-control-file" AllowMultiple="true" />
        </div>

        <!-- Save and Cancel Buttons -->
        <div class="form-group">
            <asp:Button ID="btnSaveChanges" runat="server" Text="Save Changes" CssClass="btn btn-primary" OnClick="btnSaveChanges_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" OnClick="btnCancel_Click" />
        </div>

        <!-- Files for Download -->
        <div class="form-group">
            <h5 class="mt-4">Existing Files</h5>
            <asp:Repeater ID="FilesRepeater" runat="server">
                <ItemTemplate>
                    <div class="file mb-2">
                        <a href='<%# ResolveUrl("~/Uploads/Materials/" + Eval("FileName")) %>' download class="btn btn-sm btn-outline-primary">
                            <%# Eval("FileName") %>
                        </a>
                        <asp:LinkButton ID="btnDeleteFile" runat="server" CommandName="DeleteFile" CommandArgument='<%# Eval("FileId") %>' CssClass="btn btn-sm btn-outline-danger ms-2">
                            Delete
                        </asp:LinkButton>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

    <!-- Initialize CKEditor -->
    <script>
        CKEDITOR.replace('<%= txtEditMaterialContent.ClientID %>');
    </script>
</asp:Content>
