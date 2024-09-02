<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Student.Master" AutoEventWireup="true" CodeBehind="QuizConfirm.aspx.cs" Inherits="vclass_clone.web_form.student.QuizConfirm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container d-flex justify-content-center align-items-center" style="min-height: 100vh;">
        <div class="card shadow">
            <div class="card-header text-center bg-primary text-white">
                <asp:Label ID="lblQuizTitle" runat="server" Text="Quiz Title"></asp:Label>
            </div>
            <div class="card-body">
                <p class="lead"><asp:Label ID="lblQuizDescription" runat="server" Text="Quiz Description"></asp:Label></p>
                <hr />
                <p><strong>Duration:</strong> <asp:Label ID="lblQuizDuration" runat="server" Text="Duration"></asp:Label></p>
                <p><strong>Max Attempts:</strong> <asp:Label ID="lblMaxAttempts" runat="server" Text="Max Attempts"></asp:Label></p>
                <div class="text-center mt-4">
                    <asp:Button ID="btnStartQuiz" runat="server" CssClass="btn btn-success btn-lg" Text="Start Quiz" OnClick="StartQuiz_Click" />
                </div>
            </div>
        </div>
    </div>


    </asp:Content>
