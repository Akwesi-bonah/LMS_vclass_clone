<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Facilitator.Master" AutoEventWireup="true" CodeBehind="QuizAdd.aspx.cs" Inherits="vclass_clone.web_form.facilitator.QuizAdd" %>
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
                        <asp:HyperLink ID="HyperLink1" runat="server">
                            <asp:HyperLink ID="HyperLink2" NavigateUrl="~/teachers/subjects.aspx" runat="server">Subjects</asp:HyperLink>
                        </asp:HyperLink>
                    </li>
                    <li class="breadcrumb-item active" aria-current="page">Add Quiz</li>
                </ol>
            </nav>
        </div>
    </div>

    <div class="card">
        <div class="card-body">
            <h4 class="card-title">Add a New Quiz</h4>
            <asp:Label ID="lblMessage" runat="server" CssClass="" Text=""></asp:Label>

            <!-- Quiz Title -->
            <div class="form-group row">
                <label for="txtQuizTitle" class="col-sm-3 col-form-label">Quiz Title</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtQuizTitle" CssClass="form-control" runat="server" Placeholder="Enter quiz title" aria-describedby="QuizTitleHelp"></asp:TextBox>
                    <small id="QuizTitleHelp" class="form-text text-muted">Give your quiz a descriptive title.</small>
                </div>
            </div>

            <!-- Quiz Description -->
            <div class="form-group row">
                <label for="txtQuizDesc" class="col-sm-3 col-form-label">Quiz Description</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtQuizDesc" TextMode="Multiline" CssClass="form-control" runat="server" Rows="4" Placeholder="Enter a brief description of the quiz" aria-describedby="QuizDescHelp"></asp:TextBox>
                    <small id="QuizDescHelp" class="form-text text-muted">Describe the contents or purpose of the quiz.</small>
                </div>
            </div>

            <!-- Start Time -->
            <div class="form-group row">
                <label for="txtStartTime" class="col-sm-3 col-form-label">Start Time</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtStartTime" TextMode="DateTimeLocal" CssClass="form-control" runat="server" aria-describedby="StartTimeHelp"></asp:TextBox>
                    <small id="StartTimeHelp" class="form-text text-muted">Set the date and time when the quiz will become available.</small>
                </div>
            </div>

            <!-- Duration -->
            <div class="form-group row">
                <label for="txtTestTime" class="col-sm-3 col-form-label">Duration (Minutes)</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtTestTime" TextMode="Number" CssClass="form-control" runat="server" Placeholder="Enter duration in minutes" aria-describedby="DurationHelp"></asp:TextBox>
                    <small id="DurationHelp" class="form-text text-muted">Specify how long the quiz will be available to students.</small>
                </div>
            </div>

            <!-- End Time -->
            <div class="form-group row">
                <label for="txtEndDate" class="col-sm-3 col-form-label">End Time</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtEndDate" TextMode="DateTimeLocal" CssClass="form-control" runat="server" aria-describedby="EndTimeHelp"></asp:TextBox>
                    <small id="EndTimeHelp" class="form-text text-muted">Set the date and time when the quiz will close.</small>
                </div>
            </div>

            <!-- Submit Button -->
            <div class="form-group row">
                <div class="col-sm-9 offset-sm-3">
                    <asp:Button ID="Button1" CssClass="btn btn-primary mb-2" runat="server" Text="Add Quiz" OnClick="Button1_Click" />
                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
