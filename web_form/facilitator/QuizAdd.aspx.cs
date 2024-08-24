using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

namespace vclass_clone.web_form.facilitator
{
    public partial class QuizAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Retrieve input values
            string title = txtQuizTitle.Text.Trim();
            string description = txtQuizDesc.Text.Trim();
            DateTime startTime;
            DateTime endTime;
            int duration;

            // Validate input
            if (string.IsNullOrEmpty(title))
            {
                lblMessage.Text = "Quiz title is required.";
                lblMessage.CssClass = "alert alert-danger";
                return;
            }

            if (string.IsNullOrEmpty(description))
            {
                lblMessage.Text = "Quiz description is required.";
                lblMessage.CssClass = "alert alert-danger";
                return;
            }

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

            if (!int.TryParse(txtTestTime.Text, out duration) || duration <= 0)
            {
                lblMessage.Text = "Invalid duration. It must be a positive integer.";
                lblMessage.CssClass = "alert alert-danger";
                return;
            }

            // Get the course ID from the session
            string courseIdString = Session["CourseId"] as string;
            if (string.IsNullOrEmpty(courseIdString) || !Guid.TryParse(courseIdString, out Guid courseId))
            {
                lblMessage.Text = "Course ID is missing or invalid.";
                lblMessage.CssClass = "alert alert-danger";
                return;
            }

            // Save the new quiz to the database
            try
            {
                using (var context = new LMSContext())
                {
                    var quiz = new QuizDB
                    {
                        Id = Guid.NewGuid(),
                        Title = title,
                        Description = description,
                        StartTime = startTime,
                        DueDate = endTime,
                        Duration = duration,
                        CourseId = courseId
                    };

                    context.Quizzes.Add(quiz);
                    context.SaveChanges();

                    lblMessage.Text = "Quiz added successfully.";
                    lblMessage.CssClass = "alert alert-success";
                }
            }
            catch (Exception ex)
            {
                // Log the exception and display a user-friendly message
                // Consider using a logging framework like NLog or log4net
                lblMessage.Text = $"An error occurred while adding the quiz: {ex.Message}";
                lblMessage.CssClass = "alert alert-danger";
                // Log exception: e.g., LogManager.GetLogger(typeof(AddQuiz)).Error(ex);
                // For simplicity, showing message on page instead of logging
            }
        }
    }
}
}