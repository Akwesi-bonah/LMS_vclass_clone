<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Student.Master" AutoEventWireup="true" CodeBehind="StartQuiz.aspx.cs" Inherits="vclass_clone.web_form.student.StartQuiz" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
   <div class="container mt-5">
    <div class="card">
        <div class="card-header">
            <h3 id="lblQuizTitle"><%# Eval("Title") %></h3>
            <p id="lblQuizDescription"><%# Eval("Description") %></p>

            <div class="inn-title">
                <h4>Time Remaining (<asp:Label ID="lblTimeLeft" runat="server" Text=""></asp:Label> <b>)</b></h4>
            </div>

            <div class="quiz-info">
                <p><strong>Max Attempts: </strong><%# Eval("MaxAttempts") %></p>
                <p><strong>Passing Score: </strong><%# Eval("PassingScore") %>%</p>
                <p><strong>Total Marks: </strong><%# Eval("TotalMarks") %></p>
                <p><strong>Duration: </strong><%# Eval("Duration") %> minutes</p>
                <p><strong>Start Time: </strong><%# Eval("StartTime", "{0:MM/dd/yyyy HH:mm}") %></p>
                <p><strong>Due Date: </strong><%# Eval("DueDate", "{0:MM/dd/yyyy HH:mm}") %></p>
            </div>
        </div>

        <div class="card-body">
            <asp:Repeater ID="rptQuestions" runat="server">
                <ItemTemplate>
                    <div class="question-page" style="display: none;">
                        <asp:Label ID="lblid" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                        <asp:Label ID="lblQuestionText" runat="server" Text='<%# Eval("QuestionText") %>'></asp:Label>

                        <asp:RadioButtonList ID="rblOptions" runat="server" DataSource='<%# Eval("Options") %>'>
                        </asp:RadioButtonList>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <script type="text/javascript">
            window.onload = function () {
                startCountdown(60); // Set the time based on quiz duration
            };

            function startCountdown(timeLeft) {
                var interval = setInterval(countdown, 1000);
                update();

                function countdown() {
                    if (--timeLeft > 0) {
                        update();
                    } else {
                        clearInterval(interval);
                        update();
                        completed();
                    }
                }

                function update() {
                    var hours = Math.floor(timeLeft / 3600);
                    var minutes = Math.floor((timeLeft % 3600) / 60);
                    var seconds = timeLeft % 60;

                    document.getElementById('<%= lblTimeLeft.ClientID %>').innerHTML = hours + ' : ' + minutes + ' : ' + seconds;
                }

                function completed() {
                    alert("Time's up! Your answers are being submitted.");
                }
            }
        </script>
    </div>
</div>

</asp:Content>
