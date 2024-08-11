using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using vclass_clone.Models;

namespace vclass_clone.web_form.facilitator
{
    public partial class courseSettings : System.Web.UI.Page
    {
        private string courseImagePath;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["CourseId"] != null)
                {
                    Guid courseId;
                    if (Guid.TryParse(Session["CourseId"].ToString(), out courseId))
                    {
                        LoadCourseInfo(courseId);
                    }
                    else
                    {
                        lblMessage.Text = "Invalid course. Please try again.";
                        lblMessage.CssClass = "alert alert-danger mt-3";
                        lblMessage.Visible = true;
                    }
                }
                else
                {
                    lblMessage.Text = "No course selected. Please select a course.";
                    lblMessage.CssClass = "alert alert-danger mt-3";
                    lblMessage.Visible = true;
                }
            }
        }


        private void LoadCourseInfo(Guid courseId)
        {
            try
            {
                using (var context = new LMSContext())
                {
                    var course = context.Courses.SingleOrDefault(c => c.Id == courseId);
                    if (course != null)
                    {
                        txtCourseName.Text = course.Name;
                        txtCourseCode.Text = course.Code;
                        txtCourseDescription.Text = course.Description;
                        txtCourseLevel.Text = course.Level;
                        txtEnrollmentKey.Text = course.EnrollmentKey;
                        courseImagePath = course.ImagePath ?? "~/Uploads/defaultCourse.jpeg";

                        // Apply the background image to the courseInfoCard
                        courseInfoCard.Attributes["style"] = $"background-image: url('{courseImagePath}'); background-size: cover;";
                    }
                    else
                    {
                        lblMessage.Text = "Course not found.";
                        lblMessage.CssClass = "alert alert-danger mt-3";
                        lblMessage.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Error loading course info: {ex.Message}";
                lblMessage.CssClass = "alert alert-danger mt-3";
                lblMessage.Visible = true;
            }
        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Session["CourseId"] != null)
            {
                Guid courseId;
                if (Guid.TryParse(Session["CourseId"].ToString(), out courseId))
                {
                    UpdateCourseInfo(courseId);
                }
                else
                {
                    lblMessage.Text = "Invalid course. Please try again.";
                    lblMessage.CssClass = "alert alert-danger mt-3";
                    lblMessage.Visible = true;
                }
            }
            else
            {
                lblMessage.Text = "No course selected. Please select a course.";
                lblMessage.CssClass = "alert alert-danger mt-3";
                lblMessage.Visible = true;
            }
        }

        private void UpdateCourseInfo(Guid courseId)
        {
            try
            {
                using (var context = new LMSContext())
                {
                    var course = context.Courses.SingleOrDefault(c => c.Id == courseId);
                    if (course != null)
                    {
                        course.Name = txtCourseName.Text.Trim();
                        course.Code = txtCourseCode.Text.Trim();
                        course.Description = txtCourseDescription.Text.Trim();
                        course.Level = txtCourseLevel.Text.Trim();
                        course.EnrollmentKey = txtEnrollmentKey.Text.Trim();

                        // Handle file upload for course image
                        if (fileUploadImage.HasFile)
                        {
                            var fileName = Path.GetFileName(fileUploadImage.FileName);
                            var filePath = Path.Combine(Server.MapPath("~/Uploads/CourseImages/"), fileName);
                            fileUploadImage.SaveAs(filePath);

                            // Update course image path (assuming you have a property for image path in your CourseDB)
                            course.ImagePath = $"~/Uploads/CourseImages/{fileName}";
                        }

                        context.SaveChanges();

                        lblMessage.Text = "Course updated successfully.";
                        lblMessage.CssClass = "alert alert-success mt-3";
                        lblMessage.Visible = true;
                    }
                    else
                    {
                        lblMessage.Text = "Course not found.";
                        lblMessage.CssClass = "alert alert-danger mt-3";
                        lblMessage.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Error updating course info: {ex.Message}";
                lblMessage.CssClass = "alert alert-danger mt-3";
                lblMessage.Visible = true;
            }
        }
    }
}