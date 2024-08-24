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
            string quizIdString = Request.QueryString["quizId"];

            if (string.IsNullOrEmpty(quizIdString) || !Guid.TryParse(quizIdString, out Guid quizId))
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
                    txtDuration.Text = quiz.Duration.ToString();
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

            using (var context = new LMSContext())
            {
                var quiz = context.Quizzes.FirstOrDefault(q => q.Id == quizId);

                if (quiz != null)
                {
                    quiz.Title = txtQuizTitle.Text;
                    quiz.Description = txtQuizDesc.Text;
                    quiz.StartTime = DateTime.Parse(txtStartTime.Text);
                    quiz.DueDate = DateTime.Parse(txtEndDate.Text);
                    quiz.Duration = DateTime.Parse(txtDuration.Text);

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