<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Facilitator.Master" AutoEventWireup="true" CodeBehind="addQuestion.aspx.cs" Inherits="vclass_clone.web_form.facilitator.addQuestion" ValidateRequest="false" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdn.ckeditor.com/4.18.0/standard/ckeditor.js"></script>
    <link href="https://cdn.ckeditor.com/4.16.0/standard/ckeditor.css" rel="stylesheet">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
  <div class="content-wrapper">
    <div class="page-header">
        <h3 class="page-title">
            <asp:Label ID="lblCode" runat="server" Text="Label"></asp:Label>
            (<asp:Label ID="lblSubj" runat="server" Text="Label"></asp:Label>)
        </h3>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <asp:HyperLink ID="HyperLink1" runat="server">
                        <asp:HyperLink ID="HyperLink2" NavigateUrl="~/teachers/subjects.aspx" runat="server">Subjects</asp:HyperLink>
                    </asp:HyperLink>
                </li>
                <li class="breadcrumb-item active" aria-current="page">Add Question</li>
            </ol>
        </nav>
    </div>

    <div class="card">
        <div class="card-body">
            <!-- Feedback message -->
            <asp:Label ID="lblMessage" runat="server" CssClass="alert" Visible="false"></asp:Label>

            <!-- Question Input -->
            <div class="form-group row">
                <label class="col-sm-3 col-form-label">Question</label>
                <div class="col-sm-9">
                    <CKEditor:CKEditorControl ID="txtQuestion" runat="server"></CKEditor:CKEditorControl>

                </div>
               
            </div>

            <!-- Options Input -->
            <div class="form-group row">
                <label class="col-sm-3 col-form-label">Options
                </label>
                &nbsp;<div class="col-sm-9">
                    <div class="form-group">
                        <asp:Label ID="Label3" runat="server" Text="A:" CssClass="mr-2"></asp:Label>
                        <asp:TextBox ID="txtOption1" CssClass="form-control mb-2" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label4" runat="server" Text="B:" CssClass="mr-2"></asp:Label>
                        <asp:TextBox ID="txtOption2" CssClass="form-control mb-2" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label5" runat="server" Text="C:" CssClass="mr-2"></asp:Label>
                        <asp:TextBox ID="txtOption3" CssClass="form-control mb-2" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label6" runat="server" Text="D:" CssClass="mr-2"></asp:Label>
                        <asp:TextBox ID="txtOption4" CssClass="form-control mb-2" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>

            <!-- Answer Selection -->
            <div class="form-group row">
                <label class="col-sm-3 col-form-label">Correct Answer</label>
                <div class="col-sm-9">
                    <asp:DropDownList ID="answer" CssClass="form-control" runat="server">
                        <asp:ListItem Text="A" Value="1"></asp:ListItem>
                        <asp:ListItem Text="B" Value="2"></asp:ListItem>
                        <asp:ListItem Text="C" Value="3"></asp:ListItem>
                        <asp:ListItem Text="D" Value="4"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <!-- Add Question Button -->
            <div class="form-group row">
                <div class="col-sm-12 text-right">
                    <asp:Button ID="Button1" CssClass="btn btn-primary mb-2" runat="server" Text="Add Question" OnClick="Button1_Click" />
                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
