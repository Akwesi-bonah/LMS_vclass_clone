using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

namespace vclass_clone.web_form.facilitator
{
    public partial class QuestionList : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                LoadQuestions();
            }
        }

        private void LoadQuestions()
        {
            Guid courseId;
            Guid quizid;

            string courseIdString = Session["CourseId"] as string;
            string quizidString = Session["QuizId"] as string;
           
            if (string.IsNullOrEmpty(quizidString) && string.IsNullOrEmpty(courseIdString) )
            {
                // Handle the error, quiz ID is missing
                lblError.Text = "Quiz ID is missing or invalid.";
                lblError.CssClass = "alert alert-danger";
                return;
            }
            else
            {
                Guid.TryParse(courseIdString, out courseId);
                Guid.TryParse(quizidString, out quizid);
            }

            using (var context = new LMSContext())
            {
                var quiz = context.Quizzes.Include("Questions")
                    .FirstOrDefault(q => q.Id == quizid);

                if (quiz != null)
                {
                    lblCode.Text = quiz.Course.Code;
                    lblSubj.Text = quiz.Course.Name;
                    lblError.Text = quiz.Title;

                    var questions = quiz.Questions.Select(q => new
                    {
                        q.Id,
                        q.QuestionText,
                        q.Answer
                    }).ToList();

                    QuestionRepeater.DataSource = questions;
                    QuestionRepeater.DataBind();
                }
                else
                {
                    lblError.Text = "Quiz not found.";
                    lblError.CssClass = "alert alert-warning";
                }
            }
        }

        protected void btnAddQuestion_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.GetRouteUrl("FacQuestionAdd", null));
        }
    }
}