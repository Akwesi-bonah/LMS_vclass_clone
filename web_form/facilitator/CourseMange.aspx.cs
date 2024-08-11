using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using vclass_clone.Models;

namespace vclass_clone.web_form.facilitator
{
    public partial class CourseMange : System.Web.UI.Page
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

        protected void SectionsRepeater_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                string contentId = e.CommandArgument.ToString();
                string courseId = Session["CourseId"] as string;

                if (!string.IsNullOrEmpty(courseId) && !string.IsNullOrEmpty(contentId))
                {
                    Session["ContentId"] = contentId;

                    // Redirect to the edit page
                    Response.Redirect("~/web_form/facilitator/CourseEdit.aspx");
                }
                else
                {
                    lblMessage.Text = "Course or content ID is missing.";
                    lblMessage.CssClass = "alert alert-danger";
                }
            }
        }
    }
}