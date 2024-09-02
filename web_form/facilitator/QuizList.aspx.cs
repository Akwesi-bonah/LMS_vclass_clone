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
        public List<QuizInfo> Quiz_List = new List<QuizInfo>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadQuizzes();
            }
        }

        private void LoadQuizzes()
        {
            string courseIdString = Session["CourseId"] as string;

            if (string.IsNullOrEmpty(courseIdString) || !Guid.TryParse(courseIdString, out Guid courseId))
            {
                lblMessage.Text = "Course ID is missing or invalid.";
                lblMessage.CssClass = "alert alert-danger";
                return;
            }

            try
            {
                using (var context = new LMSContext())
                {
                    var course = context.Courses.FirstOrDefault(c => c.Id == courseId);
                    var quizzes = context.Quizzes
                                         .Where(q => q.CourseId == courseId)
                                         .Select(q => new
                                         {
                                             q.Id,
                                             q.Title,
                                             q.Description,
                                             q.StartTime,
                                             q.DueDate,
                                             q.Duration
                                         })
                                         .ToList();

                    if (course != null)
                    {
                        lblSubj.Text = course.Name;
                        lblCode.Text = course.Code;

                        var quizList = quizzes.Select(q => new QuizInfo
                        {
                            Id = q.Id.ToString(),
                            Title = q.Title,
                            Description = q.Description,
                            StartDate = q.StartTime.ToString("yyyy-MM-dd HH:mm"),
                            EndDate = q.DueDate.ToString("yyyy-MM-dd HH:mm"),
                            Duration = q.Duration.ToString(),
                            Status = (DateTime.Now > q.DueDate) ? "Done" : "Not Done",
                            StatusClass = (DateTime.Now > q.DueDate) ? "badge-success" : "badge-danger"
                        }).ToList();

                        QuizRepeater.DataSource = quizList;
                        QuizRepeater.DataBind();
                    }
                    else
                    {
                        lblMessage.Text = "Course not found.";
                        lblMessage.CssClass = "alert alert-warning";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"An error occurred while loading quizzes. Please try again later. {ex.Message}";
                lblMessage.CssClass = "alert alert-danger";
            }
        }

        protected void btnViewQuestions_Click(object sender, EventArgs e)
        {
            // Cast the sender to a Button
            Button btn = (Button)sender;

            // Retrieve the quizId from the CommandArgument of the Button
            string quizId = btn.CommandArgument;


            if (!string.IsNullOrEmpty(quizId))
            {
                Session["QuizId"] = quizId;

                Response.Redirect(Page.GetRouteUrl("FacQuestionList", null));
            }
            else
            {
                // Handle the case where quizId or courseId is missing
                lblMessage.Text = "Quiz ID or Course ID is missing.";
                lblMessage.CssClass = "alert alert-danger";
            }
        }

        protected void btnEditQuiz_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var quizId = new Guid(btn.CommandArgument); // Assuming CommandArgument is stored as a GUID

            // Redirect to the edit page or open a modal for editing
            Response.Redirect(Page.GetRouteUrl("FacQuizEdit", null));
        }

        protected void btnDeleteQuiz_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var quizId = new Guid(btn.CommandArgument);

            // Confirm deletion
            // Implement your delete logic here

            using (var context = new LMSContext())
            {
                var quiz = context.Quizzes.Find(quizId);
                if (quiz != null)
                {
                    context.Quizzes.Remove(quiz);
                    context.SaveChanges();
                }
            }

            // Rebind the Repeater to reflect changes
            BindQuizzes();
        }

        private void BindQuizzes()
        {
            using (var context = new LMSContext())
            {
                var quizzes = context.Quizzes.ToList();
                QuizRepeater.DataSource = quizzes;
                QuizRepeater.DataBind();
            }
        }


        public class QuizInfo
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }
            public string Duration { get; set; }
            public string Status { get; set; }
            public string StatusClass { get; set; }
        }
    }
}
