<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Facilitator.Master" AutoEventWireup="true" CodeBehind="DiscussionPosts.aspx.cs" Inherits="vclass_clone.web_form.facilitator.DiscussionPosts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container mt-5">
        <!-- Discussion Posts -->
        <div class="card">
            <div class="card-header">
                <h4 class="card-title">Discussion Responses</h4>
            </div>
            <div class="card-body">
                <asp:Repeater ID="PostsRepeater" runat="server">
                    <ItemTemplate>
                        <div class="post mb-3 p-3 border rounded">
                            <p><strong><%# Eval("Student.FirstName") %> <%# Eval("Student.LastName") %>:</strong></p>
                            <p><%# Eval("Content") %></p>
                            <p class="text-muted"><small><%# Eval("PostDate", "{0:MMMM dd, yyyy HH:mm}") %></small></p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>

        <!-- Post Form -->
        <div class="card mt-4">
            <div class="card-header">
                <h4 class="card-title">Post a Reply</h4>
            </div>
            <div class="card-body">
                <asp:TextBox ID="txtPostContent" runat="server" CssClass="form-control" TextMode="MultiLine" Placeholder="Your reply"></asp:TextBox>
                <asp:Button ID="btnPost" runat="server" Text="Post Reply" CssClass="btn btn-primary mt-2" OnClick="btnPost_Click" />
            </div>
        </div>
    </div>
</asp:Content>
