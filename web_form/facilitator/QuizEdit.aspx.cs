using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

namespace vclass_clone.web_form
{
    public partial class QuizEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadQuiz();
            }
        }

        private void LoadQuiz()
        {
            string quizIdString = Session["QuizId"] as string;

            Guid quizId;
            if (string.IsNullOrEmpty(quizIdString) || !Guid.TryParse(quizIdString, out  quizId))
            {
                lblMessage.Text = "Quiz ID is missing or invalid.";
                lblMessage.CssClass = "alert alert-danger";
                return;
            }

            using (var context = new LMSContext())
            {
                var quiz = context.Quizzes.FirstOrDefault(q => q.Id == quizId);

                if (quiz != null)
                {
                    txtQuizTitle.Text = quiz.Title;
                    txtQuizDesc.Text = quiz.Description;
                    txtStartTime.Text = quiz.StartTime.ToString("yyyy-MM-ddTHH:mm");
                    txtEndDate.Text = quiz.DueDate.ToString("yyyy-MM-ddTHH:mm");
                    txtDuration.Text = quiz.Duration.TotalMinutes.ToString(); // Convert TimeSpan to total minutes
                    txtMaxAttempts.Text = quiz.MaxAttempts.ToString();
                    txtPassingScore.Text = quiz.PassingScore.ToString();
                    txtTotalMarks.Text = quiz.TotalMarks.ToString();
                    chkIsPublished.Checked = quiz.IsPublished;
                }
                else
                {
                    lblMessage.Text = "Quiz not found.";
                    lblMessage.CssClass = "alert alert-warning";
                }
            }
        }


        protected void btnSaveQuiz_Click(object sender, EventArgs e)
        {
            string quizIdString = Request.QueryString["quizId"];

            if (string.IsNullOrEmpty(quizIdString) || !Guid.TryParse(quizIdString, out Guid quizId))
            {
                lblMessage.Text = "Quiz ID is missing or invalid.";
                lblMessage.CssClass = "alert alert-danger";
                return;
            }

            DateTime startTime;
            DateTime endTime;
            double duration;
            int maxAttempts;
            int passingScore;
            int totalMarks;

            if (!DateTime.TryParse(txtStartTime.Text, out startTime))
            {
                lblMessage.Text = "Invalid start time.";
                lblMessage.CssClass = "alert alert-danger";
                return;
            }

            if (!DateTime.TryParse(txtEndDate.Text, out endTime))
            {
                lblMessage.Text = "Invalid end time.";
                lblMessage.CssClass = "alert alert-danger";
                return;
            }

            if (!double.TryParse(txtDuration.Text, out duration) || duration <= 0)
            {
                lblMessage.Text = "Invalid duration. It must be a positive number.";
                lblMessage.CssClass = "alert alert-danger";
                return;
            }

            if (!int.TryParse(txtMaxAttempts.Text, out maxAttempts) || maxAttempts <= 0)
            {
                lblMessage.Text = "Invalid maximum attempts. It must be a positive integer.";
                lblMessage.CssClass = "alert alert-danger";
                return;
            }

            if (!int.TryParse(txtPassingScore.Text, out passingScore) || passingScore < 0 || passingScore > 100)
            {
                lblMessage.Text = "Invalid passing score. It must be between 0 and 100.";
                lblMessage.CssClass = "alert alert-danger";
                return;
            }

            if (!int.TryParse(txtTotalMarks.Text, out totalMarks) || totalMarks <= 0)
            {
                lblMessage.Text = "Invalid total marks. It must be a positive integer.";
                lblMessage.CssClass = "alert alert-danger";
                return;
            }

            using (var context = new LMSContext())
            {
                var quiz = context.Quizzes.FirstOrDefault(q => q.Id == quizId);

                if (quiz != null)
                {
                    quiz.Title = txtQuizTitle.Text;
                    quiz.Description = txtQuizDesc.Text;
                    quiz.StartTime = startTime;
                    quiz.DueDate = endTime;
                    quiz.Duration = TimeSpan.FromMinutes(duration); // Convert minutes to TimeSpan
                    quiz.MaxAttempts = maxAttempts;
                    quiz.PassingScore = passingScore;
                    quiz.TotalMarks = totalMarks;
                    quiz.IsPublished = chkIsPublished.Checked;

                    context.SaveChanges();
                    lblMessage.Text = "Quiz updated successfully.";
                    lblMessage.CssClass = "alert alert-success";
                }
                else
                {
                    lblMessage.Text = "Quiz not found.";
                    lblMessage.CssClass = "alert alert-warning";
                }
            }
        }


    }
}