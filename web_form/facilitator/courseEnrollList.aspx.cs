using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

namespace vclass_clone.web_form.facilitator
{
    public partial class courseEnrollList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCourseAndEnrolledStudents();
            }
        }


        private void LoadCourseAndEnrolledStudents()
        {
            string courseId = Session["CourseId"] as string;

            try
            {

                if (!string.IsNullOrEmpty(courseId))
                {
                    Guid courseGuid = Guid.Parse(courseId);

                    using (var context = new LMSContext())
                    {
                        // Fetch the course details
                        var course = context.Courses.FirstOrDefault(c => c.Id == courseGuid);



                        lblCourseTitle.Text = course.Name;
                        lblCourseDescription.Text = course.Description;

                        // Fetch enrolled students
                        var enrolledStudents = context.CourseEnrollments
                                                      .Where(e => e.CourseId == courseGuid)
                                                      .Select(e => new
                                                      {
                                                          e.Student.FirstName,
                                                          e.Student.LastName,
                                                          e.Student.StudentNumber,
                                                          e.Student.Level,
                                                          StudentId = e.Student.Id
                                                      })
                                                      .ToList();

                        // Debugging: Display the number of students retrieved
                        lblError.Text = $"Found {enrolledStudents.Count} students.";
                        lblError.Visible = true;

                        if (enrolledStudents.Any())
                        {
                            StudentsGridView.DataSource = enrolledStudents;
                            StudentsGridView.DataBind();
                        }
                        else
                        {
                            lblError.Text = "No students enrolled in this course.";
                            lblError.Visible = true;
                        }
                    }


                } else
                {
                    lblError.Text = "Invalid course ID.";
                    lblError.Visible = true;
                    return;
                }

               
            }
            catch (Exception ex)
            {
                // Log the exception and display a user-friendly error message
                lblError.Text = "An error occurred while loading the course and students: " + ex.Message;
                lblError.Visible = true;
            }
        }


        protected void StudentsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                // Get the student ID from the CommandArgument
                Guid studentId = Guid.Parse(e.CommandArgument.ToString());

                // Redirect to the student details page using the mapped route and passing the student ID as a route parameter
                Session["StudentID"] = studentId;
                Response.Redirect(Page.GetRouteUrl("FacStudentList", null));
            }
        }


    }
}