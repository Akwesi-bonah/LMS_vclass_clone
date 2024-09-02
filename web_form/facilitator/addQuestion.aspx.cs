using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

namespace vclass_clone.web_form.facilitator
{
    public partial class addQuestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                LoadSubjectDetails();
            }
        }

        private void LoadSubjectDetails()
        {
            string course_id = Session["CourseID"] as String;
            Guid courseGuid = Guid.Parse(course_id);
            if ( courseGuid != null)
            {
                using (var context = new LMSContext()) // Ensure proper disposal of the DbContext
                {
                    var subject = context.Courses.FirstOrDefault(s => s.Id == courseGuid);
                    if (subject != null)
                    {
                        lblSubj.Text = subject.Name;
                        lblCode.Text = subject.Code;
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtQuestion.Text))
            {
                lblMessage.Text = "Please enter a question.";
                lblMessage.CssClass = "alert alert-danger";
                lblMessage.Visible = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtOption1.Text))
            {
                lblMessage.Text = "Option A is required.";
                lblMessage.CssClass = "alert alert-danger";
                lblMessage.Visible = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtOption2.Text))
            {
                lblMessage.Text = "Option B is required.";
                lblMessage.CssClass = "alert alert-danger";
                lblMessage.Visible = true;
                return;
            }

            string quiz_id = Session["QuizID"] as string;

            if (!Guid.TryParse(quiz_id, out Guid quizGuid))
            {
                lblMessage.Text = "Invalid quiz ID.";
                lblMessage.CssClass = "alert alert-danger";
                lblMessage.Visible = true;
                return;
            }

            try
            {
                using (var context = new LMSContext())
                {
                    // Create a new question object
                    var question = new QuestionDB
                    {
                        QuizId = quizGuid,
                        QuestionText = txtQuestion.Text.Trim(),
                        Option1 = txtOption1.Text.Trim(),
                        Option2 = txtOption2.Text.Trim(),
                        Option3 = string.IsNullOrWhiteSpace(txtOption3.Text) ? null : txtOption3.Text.Trim(),
                        Option4 = string.IsNullOrWhiteSpace(txtOption4.Text) ? null : txtOption4.Text.Trim(),
                        Answer = answer.SelectedValue
                    };

                    // Add the question to the database
                    context.Questions.Add(question);
                    context.SaveChanges();
                }

                // Provide feedback to the user
                lblMessage.Text = "Question added successfully!";
                lblMessage.CssClass = "alert alert-success";
                lblMessage.Visible = true;

                // Clear the form fields for the next input
                txtQuestion.Text = string.Empty;
                txtOption1.Text = string.Empty;
                txtOption2.Text = string.Empty;
                txtOption3.Text = string.Empty;
                txtOption4.Text = string.Empty;
                answer.SelectedIndex = -1;
            }
            
            //catch (DbEntityValidationException ex)
            //{
            //    var validationErrors = ex.EntityValidationErrors
            ////        .SelectMany(e => e.ValidationErrors)
            ////        .Select(e => e.ErrorMessage);

            //    lblMessage.Text = "Validation error: " + string.Join("; ", validationErrors);
            //    lblMessage.CssClass = "alert alert-danger";
            //    lblMessage.Visible = true;
            //}
            catch (Exception ex)
            {
                lblMessage.Text = "An error occurred while adding the question: " + ex.Message;
                lblMessage.CssClass = "alert alert-danger";
                lblMessage.Visible = true;
            }


        }

    }
}