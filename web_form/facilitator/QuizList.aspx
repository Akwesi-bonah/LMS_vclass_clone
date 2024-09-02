<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Facilitator.Master" AutoEventWireup="true" CodeBehind="QuizList.aspx.cs" Inherits="vclass_clone.web_form.facilitator.QuizList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container mt-5">
            <div class="page-header">
                <h3 class="page-title">
                    <asp:Label ID="lblCode" runat="server" Text="Label"></asp:Label>
                    (<asp:Label ID="lblSubj" runat="server" Text="Label"></asp:Label>)
                </h3>
            </div>

         <div class="card">
    <div class="card-body">
        <h4 class="card-title">
            Quizzes
            <a class="btn btn-info btn-sm ml-2" href="<%= Page.GetRouteUrl("FacQuizAdd", null) %>">Add Quiz</a>
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
                                    <asp:Button ID="btnViewQuestions" runat="server" Text="View Questions" CommandArgument='<%# Eval("Id") %>' OnClick="btnViewQuestions_Click" CssClass="btn btn-info btn-sm" />
                                </td>
                                <td>
                                    <span class="badge <%# Eval("StatusClass") %>"><%# Eval("Status") %></span>
                                </td>
                                <td>
                                    <asp:Button runat="server" ID="btnEditQuiz" Text="Edit" CssClass="btn btn-warning btn-sm" CommandArgument='<%# Eval("Id") %>' OnClick="btnEditQuiz_Click" />
                                    <asp:Button runat="server" ID="btnDeleteQuiz" Text="Delete" CssClass="btn btn-danger btn-sm" CommandArgument='<%# Eval("Id") %>' OnClick="btnDeleteQuiz_Click" />
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


