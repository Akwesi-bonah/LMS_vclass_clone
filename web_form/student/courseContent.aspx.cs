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
                LoadAssignments();
                ///*LoadQuizzes*/();
            }
        }

        private void LoadCourseDetails()
        {
            var courseId = Session["CourseId"] as string;

            if (!string.IsNullOrEmpty(courseId))
            {
                try
                {
                    Guid courseGuid = Guid.Parse(courseId);

                    using (var context = new LMSContext())
                    {
                        var course = context.Courses.FirstOrDefault(c => c.Id == courseGuid);

                        var sections = context.CourseMaterials
                                              .Where(cm => cm.CourseId == courseGuid)
                                              .Include(cm => cm.Files)
                                              .OrderBy(cm => cm.UploadedDate)
                                              .ToList();

                        if (course != null)
                        {
                            lblCourseName.Text = course.Name;
                            lblCourseCode.Text = course.Code;
                            lblCourseDescription.Text = course.Description;

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

        private void LoadAssignments()
        {
            var courseId = Session["CourseId"] as string;

            if (!string.IsNullOrEmpty(courseId))
            {
                try
                {
                    Guid courseGuid = Guid.Parse(courseId);

                    using (var context = new LMSContext())
                    {
                        var assignments = context.Assignments
                                                 .Where(a => a.CourseId == courseGuid)
                                                 .OrderBy(a => a.DueDate)
                                                 .ToList();

                        AssignmentsRepeater.DataSource = assignments;
                        AssignmentsRepeater.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "An error occurred while loading assignments: " + ex.Message;
                    lblMessage.CssClass = "alert alert-danger";
                }
            }
        }

        //private void LoadQuizzes()
        //{
        //    var courseId = Session["CourseId"] as string;

        //    if (!string.IsNullOrEmpty(courseId))
        //    {
        //        try
        //        {
        //            Guid courseGuid = Guid.Parse(courseId);

        //            using (var context = new LMSContext())
        //            {
        //                var quizzes = context.Quizzes
        //                                     .Where(q => q.CourseId == courseGuid)
        //                                     .OrderBy(q => q.Title)
        //                                     .ToList();

        //                QuizzesRepeater.DataSource = quizzes;
        //                QuizzesRepeater.DataBind();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            lblMessage.Text = "An error occurred while loading quizzes: " + ex.Message;
        //            lblMessage.CssClass = "alert alert-danger";
        //        }
        //    }
        //}

        protected void btnUnenroll_Click(object sender, EventArgs e)
        {
           var courseId = Session["CourseId"] as Guid?;
            var userId = Session["UserId"] as Guid?;

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