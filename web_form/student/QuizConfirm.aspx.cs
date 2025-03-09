using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

namespace vclass_clone.web_form.student
{
    public partial class QuizConfirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadQuizOverview();
            }
        }

        private void LoadQuizOverview()
        {
            string quizId = Session["SelectedQuizId"] as string; 

            if (Guid.TryParse(quizId, out Guid parsedQuizId))
            {
                using (var context = new LMSContext())
                {
                    var quiz = context.Quizzes
                        .Where(q => q.Id == parsedQuizId)
                        .Select(q => new
                        {
                            q.Title,
                            q.Description,
                            q.Duration,
                            q.MaxAttempts
                        })
                        .FirstOrDefault();

                    if (quiz != null)
                    {
                        lblQuizTitle.Text = quiz.Title;
                        lblQuizDescription.Text = quiz.Description;
                        lblQuizDuration.Text = $"{quiz.Duration.Hours} hours {quiz.Duration.Minutes} minutes";
                        lblMaxAttempts.Text = quiz.MaxAttempts.ToString();
                    }
                    else
                    {
                        lblQuizTitle.Text = "Quiz not found.";
                    }
                }
            }
            else
            {
                lblQuizTitle.Text = "Invalid Quiz ID.";
            }
        }

        protected void StartQuiz_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.GetRouteUrl("stuCourseQuizAttempt", null));
        }

    }
}