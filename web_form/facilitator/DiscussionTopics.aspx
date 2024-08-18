<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Facilitator.Master" AutoEventWireup="true" CodeBehind="DiscussionTopics.aspx.cs" Inherits="vclass_clone.web_form.facilitator.DiscussionTopics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <!-- Discussion Topics -->
        <div class="card">
            <div class="card-header">
                <h4 class="card-title">Discussion Topics</h4>
            </div>
            <div class="card-body">
                <asp:Repeater ID="TopicsRepeater" runat="server">
                    <ItemTemplate>
                        <div class="discussion-topic mb-3 p-3 border rounded">
                            <h5 class="discussion-title"><%# Eval("Title") %></h5>
                            <p class="discussion-description"><%# Eval("Description") %></p>
                            <a class="btn btn-primary btn-sm" href="DiscussionPosts.aspx?topicId=<%# Eval("Id") %>">View Responses</a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>

        <!-- Create New Topic Form -->
        <div class="card mt-4">
            <div class="card-header">
                <h4 class="card-title">Create New Topic</h4>
            </div>
            <div class="card-body">
                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" Placeholder="Title"></asp:TextBox>
                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control mt-2" TextMode="MultiLine" Placeholder="Description"></asp:TextBox>
                <asp:Button ID="btnCreateTopic" runat="server" Text="Create Topic" CssClass="btn btn-primary mt-2" OnClick="btnCreateTopic_Click" />
            </div>
        </div>
    </div>
</asp:Content>
