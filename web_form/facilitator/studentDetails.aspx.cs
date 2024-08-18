using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;
using System.Data.Entity;

namespace vclass_clone.web_form.facilitator
{
    public partial class studentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStudentDetails();
            }
        }

        private void LoadStudentDetails()
        {
            try
            {
                // Assuming StudentId is passed via query string or route data
                string studentIdStr = Session["StudentID"] as string;

                if (Guid.TryParse(studentIdStr, out Guid studentId))
                {
                    using (var context = new LMSContext())
                    {
                        // Fetch the student details based on StudentId
                        var student = context.Students
                            .Include(s => s.Group)  
                            .FirstOrDefault(s => s.Id == studentId);

                        if (student != null)
                        {
                            // Populate the UI labels with student data
                            lblFirstName.Text = student.FirstName;
                            lblLastName.Text = student.LastName;
                            lblStudentNumber.Text = student.StudentNumber;
                            lblGender.Text = student.Gender;
                            lblLevel.Text = student.Level;
                            lblGroup.Text = student.Group != null ? student.Group.Name : "N/A";
                            lblUserId.Text = student.UserId.ToString();
                        }
                        else
                        {
                            // Show an error message if student not found
                            lblError.Text = "Student not found.";
                            lblError.Visible = true;
                        }
                    }
                }
                else
                {
                    // Show an error message if StudentId is invalid
                    lblError.Text = "Invalid Student ID.";
                    lblError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                // Log the exception and display an error message
                lblError.Text = "An error occurred while loading the student details: " + ex.Message;
                lblError.Visible = true;
            }
        }

    }
}