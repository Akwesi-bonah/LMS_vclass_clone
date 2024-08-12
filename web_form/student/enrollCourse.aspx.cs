using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

namespace vclass_clone.web_form.student
{
    public partial class enrollCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConfirmEnrollment_Click(object sender, EventArgs e)
        {
            Guid? courseId = Session["SelectedCourseId"] as Guid?;
            Guid? userId = Session["userid"] as Guid?;
            string enrollmentKey = txtEnrollmentKey.Text.Trim();

            if (courseId.HasValue && userId.HasValue)
            {
                using (var context = new LMSContext())
                {
                    var course = context.Courses.FirstOrDefault(c => c.Id == courseId.Value);
                    var student = context.Students.FirstOrDefault(s => s.UserId == userId.Value);

                    if (course != null && student != null)
                    {
                        // Check if the student is already enrolled in the course
                        var existingEnrollmentCheck = context.CourseEnrollments
                            .FirstOrDefault(enrollment => enrollment.CourseId == courseId.Value && enrollment.StudentId == student.Id);

                        if (existingEnrollmentCheck != null)
                        {
                            // Display an error message if the student is already enrolled
                            lblEnrollmentKeyLabel.Text = "You are already enrolled in this course.";
                            return;
                        }

                        // Check if the student's level matches the course level
                        if (course.Level == student.Level)
                        {
                            // Check if the enrollment key is required and if it matches
                            if (string.IsNullOrEmpty(course.EnrollmentKey) || course.EnrollmentKey == enrollmentKey)
                            {
                                // Enroll the student
                                var enrollment = new CourseEnrollmentDB
                                {
                                    StudentId = student.Id,
                                    CourseId = course.Id
                                };

                                context.CourseEnrollments.Add(enrollment);
                                context.SaveChanges();

                                // Redirect to the course page or show success message
                                Response.Redirect(Page.GetRouteUrl("StuCourse", null));
                            }
                            else
                            {
                                // Display an error message for incorrect enrollment key
                                lblEnrollmentKeyLabel.Text = "Incorrect enrollment key. Please try again.";
                            }
                        }
                        else
                        {
                            // Display an error message for level mismatch
                            lblEnrollmentKeyLabel.Text = "Your level does not match the course level.";
                        }
                    }
                }
            }
            else
            {
                // Handle the case where courseId or userId is null
                lblEnrollmentKeyLabel.Text = "Course or User not found. Please try again.";
            }
        }

    }
}