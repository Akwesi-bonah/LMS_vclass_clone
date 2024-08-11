<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Facilitator.Master" AutoEventWireup="true" CodeBehind="QuizList.aspx.cs" Inherits="vclass_clone.web_form.facilitator.QuizList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper">
        <asp:Repeater ID="QuizRepeater" runat="server">
            <ItemTemplate>
                <div class="col-md-4 mb-2">
                    <div class="card p-2 quiz-wrapper">
                        <div class="d-flex justify-content-between align-items-center text-success mb-4">
                            <em class="text-left">Quiz</em>
                            <div class="text-right text-light bg-danger px-2 small rounded">
                                Questions
                            </div>
                        </div>
                        <h6><%# Eval("QuizHeader") %></h6>
                    </div>
                    <div class="dropup">
                        <button class="btn btn-sm p-0 ms-2" type="button" data-bs-toggle="dropdown"><i class="fas fa-ellipsis-v m-0"></i></button>
                        <div class="dropdown-menu" aria-labelledby="dropdown01">
                            <div class="dropdown-item">
                                <a href="#" class="update" onclick='EditQuiz(<%# Eval("QuizId") %>)'><i class="fas fa-pencil-alt"></i>Edit</a>
                            </div>
                            <div class="dropdown-item">
                                <a href="#" class="delete" onclick='DeleteQuiz(<%# Eval("QuizId") %>)'><i class="fas fa-trash-alt"></i>Delete</a>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>


