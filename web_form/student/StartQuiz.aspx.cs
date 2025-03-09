using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;


namespace vclass_clone.web_form.student
{
    public partial class StartQuiz : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadQuiz();
        }

        private void LoadQuiz()
        {     string quizStr = Session["SelectedQuizId"] as string;

            if (quizStr == null)
                { return; }
            Guid quizId;
            Guid.TryParse(quizStr, out quizId);

            using (var context = new LMSContext())
            {
                var questions = context.Questions
                    .Where(q => q.QuizId == quizId)
                    .OrderBy(q => q.Id)
                    .ToList();

                var quizQuestions = questions.Select(q => new
                {
                    q.Id,
                    q.QuestionText,
                    Options = new List<string> { q.Option1, q.Option2, q.Option3, q.Option4 }
                        .Where(opt => !string.IsNullOrEmpty(opt)) 
                        .ToList()
                }).ToList();

                rptQuestions.DataSource = quizQuestions;
                rptQuestions.DataBind();
            }
        }



        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int score = 0;
            var quizId = (Guid)Session["SelectedQuizId"];
            var studentId = (Guid)Session["UserId"];

            using (var context = new LMSContext())
            {
                var questions = context.Questions
                    .Where(q => q.QuizId == quizId)
                    .ToList();

                foreach (RepeaterItem item in rptQuestions.Items)
                {
                    var lblQuestionId = (Label)item.FindControl("lblid");
                    var rblOptions = (RadioButtonList)item.FindControl("rblOptions");

                    Guid questionId = Guid.Parse(lblQuestionId.Text);
                    var question = questions.FirstOrDefault(q => q.Id == questionId);

                    if (question != null && question.Answer == rblOptions.SelectedValue)
                    {
                        score++;
                    }
                }

                // Save the submission details
                var submission = new QuizSubmissionDB
                {
                    QuizId = quizId,
                    StudentId = studentId,
                    SubmissionDate = DateTime.Now,
                    Score = score,
                    IsCompleted = true
                };

                context.QuizSubmissions.Add(submission);
                context.SaveChanges();
            }

            Response.Redirect("QuizResults.aspx");
        }
    }

}
