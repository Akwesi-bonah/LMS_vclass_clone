<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Facilitator.Master" AutoEventWireup="true" CodeBehind="QuizList.aspx.cs" Inherits="vclass_clone.web_form.facilitator.QuizList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
   <div class="content-wrapper">
    <div class="row">
        <div class="page-header">
            <h3 class="page-title">
                <asp:Label ID="lblCode" runat="server" Text="Label"></asp:Label> 
                (<asp:Label ID="lblSubj" runat="server" Text="Label"></asp:Label>)
            </h3>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item">
                        <asp:HyperLink ID="HyperLink1" NavigateUrl="~/teachers/subjects.asp" runat="server">Subjects</asp:HyperLink>
                    </li>
                    <li class="breadcrumb-item active" aria-current="page">
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </li>
                </ol>
            </nav>
        </div>
    </div>

    <div class="card">
        <div class="card-body">
            <h4 class="card-title">
                Quizzes
                <a class="btn btn-info btn-sm ml-2" href="add_quiz.aspx?subjectid=<%= Request.QueryString["subjectid"] %>">Add Quiz</a>
            </h4>
            <asp:Label ID="lblMessage" runat="server" CssClass="" Text=""></asp:Label>
            <div class="table-responsive">
                <table class="table table-striped table-hover">
                    <thead>
                        <tr>
                            <th>Quiz Title</th>
                            <th>Description</th>
                            <th>Start Time</th>
                            <th>Duration</th>
                            <th>End Time</th>
                            <th>Questions</th>
                            <th>Status</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="QuizRepeater" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("Title") %></td>
                                    <td><%# Eval("Description") %></td>
                                    <td><%# Eval("StartDate") %></td>
                                    <td><%# Eval("Duration") %> Mins</td>
                                    <td><%# Eval("EndDate") %></td>
                                    <td>
                                        <a class="badge badge-info" href="questions.aspx?quizid=<%# Eval("Id") %>&subjectid=<%= Request.QueryString["subjectid"] %>">Questions</a>
                                    </td>
                                    <td>
                                        <% 
                                            var now = DateTime.Now;
                                            string status = (DateTime.Parse(Eval("EndDate").ToString()) < now) ? "Done" : "Not Done";
                                            string statusClass = (status == "Done") ? "badge-success" : "badge-danger";
                                        %>
                                        <span class="badge <%= statusClass %>"><%= status %></span>
                                    </td>
                                    <td>
                                        <a href="editQuiz.aspx?id=<%# Eval("Id") %>&subjectid=<%= Request.QueryString["subjectid"] %>" class="btn btn-info btn-xs">
                                            <i class="fa fa-edit"></i>
                                        </a>
                                        <a href="deleteQuiz.aspx?id=<%# Eval("Id") %>&subjectid=<%= Request.QueryString["subjectid"] %>" class="btn btn-danger btn-xs">
                                            <i class="fa fa-trash"></i>
                                        </a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>

</asp:Content>


