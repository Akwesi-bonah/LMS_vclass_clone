using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

namespace vclass_clone.web_form.student
{
    public partial class courseContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCourseDetails();
            }
        }

        private void LoadCourseDetails()
        {
            // Retrieve the course ID from the session
            var courseId = Session["CourseId"] as string;

            if (!string.IsNullOrEmpty(courseId))
            {
                try
                {
                    // Parse the course ID to GUID
                    Guid courseGuid = Guid.Parse(courseId);

                    using (var context = new LMSContext())
                    {
                        // Retrieve the course and its sections from the database
                        var course = context.Courses
                                            .FirstOrDefault(c => c.Id == courseGuid);

                        var sections = context.CourseMaterials
                                              .Where(cm => cm.CourseId == courseGuid)
                                              .Include(cm => cm.Files)
                                              .OrderBy(cm => cm.UploadedDate)
                                              .ToList();

                        if (course != null)
                        {
                            // Set course details
                            lblCourseName.Text = course.Name;
                            lblCourseCode.Text = course.Code;
                            lblCourseDescription.Text = course.Description;

                            // Bind course sections to repeater
                            SectionsRepeater.DataSource = sections;
                            SectionsRepeater.DataBind();
                        }
                        else
                        {
                            lblMessage.Text = "Course not found.";
                            lblMessage.CssClass = "alert alert-danger";
                        }
                    }
                }
                catch (FormatException)
                {
                    lblMessage.Text = "Invalid course ID format.";
                    lblMessage.CssClass = "alert alert-danger";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "An error occurred: " + ex.Message;
                    lblMessage.CssClass = "alert alert-danger";
                }
            }
            else
            {
                lblMessage.Text = "Course ID is missing.";
                lblMessage.CssClass = "alert alert-danger";
            }
        }

        protected void btnUnenroll_Click(object sender, EventArgs e)
        {
            Guid? courseId = Session["CourseId"] as Guid?;
            Guid? userId = Session["Userid"] as Guid?;

            if (courseId.HasValue && userId.HasValue)
            {
                using (var context = new LMSContext())
                {
                    var student = context.Students.FirstOrDefault(s => s.UserId == userId.Value);
                    if (student != null)
                    {
                        var enrollment = context.CourseEnrollments.FirstOrDefault(enr => enr.CourseId == courseId.Value && enr.StudentId == student.Id);
                        if (enrollment != null)
                        {
                            context.CourseEnrollments.Remove(enrollment);
                            context.SaveChanges();

                            // Redirect to the student's course list page or show success message
                            lblMessage.Text = "You have successfully unenrolled from the course.";
                            lblMessage.CssClass = "alert alert-success";
                        }
                        else
                        {
                            lblMessage.Text = "You are not enrolled in this course.";
                            lblMessage.CssClass = "alert alert-warning";
                        }
                    }
                }
            }
            else
            {
                lblMessage.Text = "Course or User not found. Please try again.";
                lblMessage.CssClass = "alert alert-danger";
            }
        }

    }
}