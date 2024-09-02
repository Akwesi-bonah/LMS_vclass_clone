<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Student.Master" AutoEventWireup="true" CodeBehind="StartQuiz.aspx.cs" Inherits="vclass_clone.web_form.student.StartQuiz" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="card">
            <div class="card-header">
                <h3 id="lblQuizTitle">Quiz Title</h3>
            </div>
            <div class="card-body">
                <asp:Repeater ID="rptQuestions" runat="server">
                    <ItemTemplate>
                        <div class="question-page" style="display:none;">
                            <asp:Label ID="lblQuestionText" runat="server" Text='<%# Eval("QuestionText") %>'></asp:Label>
                            <asp:RadioButtonList ID="rblOptions" runat="server">
                                <asp:ListItem Text='<%# Eval("Option1") %>' Value="1"></asp:ListItem>
                                <asp:ListItem Text='<%# Eval("Option2") %>' Value="2"></asp:ListItem>
                                <asp:ListItem Text='<%# Eval("Option3") %>' Value="3"></asp:ListItem>
                                <asp:ListItem Text='<%# Eval("Option4") %>' Value="4"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="pagination-controls mt-3">
                    <asp:Button ID="btnPrevious" runat="server" CssClass="btn btn-secondary" Text="Previous" OnClick="btnPrevious_Click" />
                    <asp:Button ID="btnNext" runat="server" CssClass="btn btn-primary" Text="Next" OnClick="btnNext_Click" />
                    <asp:Label ID="lblPageNumber" runat="server" Text="Page X of Y"></asp:Label>
                </div>
            </div>
        </div>
    </div>

    </asp:Content>
