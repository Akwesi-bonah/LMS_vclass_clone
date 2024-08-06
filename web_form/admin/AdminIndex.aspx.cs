using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

namespace vclass_clone.web_form.admin
{
    public partial class index : System.Web.UI.Page

    {
        private LMSContext db = new LMSContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStatistics();
            }
        }
        private void LoadStatistics()
        {
            var totalAdmins = db.Admins.Count();
            var totalFacilitators = db.Facilitators.Count();
            var totalStudents = db.Students.Count();
            var totalCourses = db.Courses.Count();
            var assignedCourses = db.CourseAssignments.Select(ca => ca.CourseId).Distinct().Count();
            var unassignedCourses = totalCourses - assignedCourses;

            lblTotalAdmins.Text = totalAdmins.ToString();
            lblTotalFacilitators.Text = totalFacilitators.ToString();
            lblTotalStudents.Text = totalStudents.ToString();
            lblTotalCourses.Text = totalCourses.ToString();
            lblAssignedCourses.Text = assignedCourses.ToString();
            lblUnassignedCourses.Text = unassignedCourses.ToString();
        }
    }
}