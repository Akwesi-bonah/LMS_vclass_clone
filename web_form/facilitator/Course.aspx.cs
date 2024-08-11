using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

namespace vclass_clone.web_form.facilitator
{
    public partial class Course : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCourseRepeater();
            }
        }

       
      
        private void BindCourseRepeater()
        {

            // Retrieve the user ID from the session
            var userId = Session["FacilitatorId"] as Guid?;

            // Ensure the user ID is not null
            if (userId.HasValue)
            {
                using (var context = new LMSContext())
                {
                    // Retrieve courses assigned to the logged-in user (facilitator)
                    var courses = context.CourseAssignments
                        .Where(ca => ca.FacilitatorId == userId.Value)
                        .Select(ca => ca.Course)
                        .ToList();

                    // Bind the courses to the repeater
                    CoursesRepeater.DataSource = courses;
                    CoursesRepeater.DataBind();
                }
            }
            else
            {

                Response.Redirect(Page.GetRouteUrl("Login"));
            }
        }

        protected void CoursesRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ManageCourse")
            {
                // Retrieve the course ID from the CommandArgument
                var courseId = e.CommandArgument.ToString();

                // Store the course ID in the session
                Session["CourseId"] = courseId;

                // Redirect to the course management page
                Response.Redirect(Page.GetRouteUrl("FacManageCourse", null));
            }
        }

    }

}