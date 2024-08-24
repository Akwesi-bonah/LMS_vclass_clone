<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Facilitator.Master" AutoEventWireup="true" CodeBehind="QuizEdit.aspx.cs" Inherits="vclass_clone.web_form.QuizEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
      <div class="container mt-5">
             <div class="card">
                <div class="card-header">
                    <h3>Edit Quiz</h3>
                </div>
                <div class="card-body">
                    <asp:Label ID="lblMessage" runat="server" CssClass="alert" Visible="false"></asp:Label>

                    <div class="form-group row">
                        <label class="col-sm-3 col-form-label">Quiz Title</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="txtQuizTitle" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group row">
                        <label class="col-sm-3 col-form-label">Quiz Description</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="txtQuizDesc" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group row">
                        <label class="col-sm-3 col-form-label">Start Time</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="txtStartTime" TextMode="DateTimeLocal" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group row">
                        <label class="col-sm-3 col-form-label">End Time</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="txtEndDate" TextMode="DateTimeLocal" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group row">
                        <label class="col-sm-3 col-form-label">Duration (Minutes)</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="txtDuration" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <asp:Button ID="btnSaveQuiz" CssClass="btn btn-primary" runat="server" Text="Save Quiz" OnClick="btnSaveQuiz_Click" />
                </div>
            </div>
        </div>
</asp:Content>
