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
                    // Select only the necessary fields for better performance
                    var course = context.Courses.FirstOrDefault(c => c.Id == courseId);
                    var quizzes = context.Quizzes
                                         .Where(q => q.CourseId == courseId)
                                         .Select(q => new QuizInfo
                                         {
                                             Id = q.Id.ToString(),
                                             Title = q.Title,
                                             Description = q.Description,
                                             StartDate = q.StartTime.ToString("MM/dd/yyyy HH:mm"),
                                             EndDate = q.DueDate.ToString("MM/dd/yyyy HH:mm"),
                                             Duration = q.Duration.ToString()
                                         })
                                         .ToList();

                    if (course != null)
                    {
                        lblSubj.Text = course.Name;
                        lblCode.Text = course.Code;

                        Quiz_List = quizzes;
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
                // You can use a logging framework here instead of showing the message to users
                lblMessage.Text = "An error occurred while loading quizzes. Please try again later.";
                lblMessage.CssClass = "alert alert-danger";
                // Log the exception, e.g., LogManager.GetLogger(typeof(QuizList)).Error(ex);
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
        }
    }
}
