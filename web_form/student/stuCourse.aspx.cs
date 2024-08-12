using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

namespace vclass_clone.web_form.student
{
    public partial class stuCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindEnrolledCourses();
            }
        }

        private void BindEnrolledCourses()
        {
            Guid? userId = Session["userid"] as Guid?;

            if (userId.HasValue)
            {
                using (var context = new LMSContext())
                {
                    var student = context.Students.FirstOrDefault(s => s.UserId == userId.Value);
                    if (student != null)
                    {
                        var enrolledCourses = context.CourseEnrollments
                            .Where(e => e.StudentId == student.Id)
                            .Select(e => new
                            {
                                e.Course.Id,
                                e.Course.Name,
                                e.Course.Code,
                                e.Course.Description,
                                e.Course.ImagePath
                            }).ToList();

                        rptEnrolledCourses.DataSource = enrolledCourses;
                        rptEnrolledCourses.DataBind();
                    }
                }
            }
        }


        protected void rptEnrolledCourses_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        
            if (e.CommandName == "ViewCourse")
            {

                // Retrieve the course ID from the CommandArgument
                var courseId = e.CommandArgument.ToString();

                // Store the course ID in the session
                Session["CourseId"] = courseId;

                // Redirect to the course content page
                Response.Redirect(Page.GetRouteUrl("stuCourseContext", null));
            }
        }

        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.GetRouteUrl("stuSearch", null));
        }
    }
}