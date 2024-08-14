using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

namespace vclass_clone.web_form.facilitator
{
    public partial class QuizList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadQuizzes();
            }
        }

        private void LoadQuizzes()
        {
            var subjectIdString = Request.QueryString["subjectid"];
            if (string.IsNullOrEmpty(subjectIdString))
            {
                lblMessage.Text = "Subject ID is missing.";
                lblMessage.CssClass = "alert alert-danger";
                return;
            }

            try
            {
                Guid subjectId = Guid.Parse(subjectIdString);

                using (var context = new LMSContext())
                {
                    var quizzes = context.Quizze
                                         .Where(q => q.CourseId == subjectId)
                                         .Select(q => new
                                         {
                                             q.Id,
                                             q.Title,
                                             q.Description,
                                             StartTime = q.StartTime,
                                             DueDate = q.DueDate,
                                             DurationInMinutes = (q.DueDate - q.StartTime).TotalMinutes
                                         })
                                         .OrderBy(q => q.StartTime)
                                         .ToList();

                    QuizRepeater.DataSource = quizzes;
                    QuizRepeater.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "An error occurred while loading quizzes: " + ex.Message;
                lblMessage.CssClass = "alert alert-danger";
            }
        }
    }
}