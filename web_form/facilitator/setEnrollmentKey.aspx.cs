using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

namespace vclass_clone.web_form.facilitator
{
    public partial class setEnrollmentKey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSetEnrollmentKey_Click(object sender, EventArgs e)
        {
            string courseId = Request.QueryString["courseId"];
            string enrollmentKey = txtEnrollmentKey.Text.Trim();

            if (!string.IsNullOrEmpty(courseId) && !string.IsNullOrEmpty(enrollmentKey))
            {
                using (var context = new LMSContext())
                {
                    Guid courseGuid = Guid.Parse(courseId);
                    var course = context.Courses.FirstOrDefault(c => c.Id == courseGuid);
                    if (course != null)
                    {
                        course.EnrollmentKey = enrollmentKey; // Assuming you have an EnrollmentKey field in your Course model
                        context.SaveChanges();
                        lblKeyMessage.Text = "Enrollment key set successfully.";
                        lblKeyMessage.Visible = true;
                    }
                }
            }
            else
            {
                lblKeyMessage.Text = "Please enter a valid enrollment key.";
                lblKeyMessage.Visible = true;
            }
        }

    }
}